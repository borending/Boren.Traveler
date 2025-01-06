(g => { var h, a, k, p = "The Google Maps JavaScript API", c = "google", l = "importLibrary", q = "__ib__", m = document, b = window; b = b[c] || (b[c] = {}); var d = b.maps || (b.maps = {}), r = new Set, e = new URLSearchParams, u = () => h || (h = new Promise(async (f, n) => { await (a = m.createElement("script")); e.set("libraries", [...r] + ""); for (k in g) e.set(k.replace(/[A-Z]/g, t => "_" + t[0].toLowerCase()), g[k]); e.set("callback", c + ".maps." + q); a.src = `https://maps.${c}apis.com/maps/api/js?` + e; d[q] = f; a.onerror = () => h = n(Error(p + " could not load.")); a.nonce = m.querySelector("script[nonce]")?.nonce || ""; m.head.append(a) })); d[l] ? console.warn(p + " only loads once. Ignoring:", g) : d[l] = (f, ...n) => r.add(f) && u().then(() => d[l](f, ...n)) })({ key: 'AIzaSyDBkDAJEa7mkUlCQ679vaC1guj3hJ8TOG8', v: "weekly", });

let map;
async function initMap() {
    const position = { lat: 34.70317583942373, lng: 135.4976065215495 };
    const { Map } = await google.maps.importLibrary("maps");
    const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");

    map = new Map(document.getElementById("map"), {
        center: position,
        zoom: 16,
        mapId: "DEMO_MAP_ID"
    });
}
initMap();

// async function setMarker(queryText) {
//     // const { Place } = await google.maps.importLibrary("places");
//     // const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");

//     // const { places } = await Place.searchByText({
//     //     textQuery: text.value,
//     //     fields: ['displayName', 'location', 'businessStatus'],
//     //     language: 'zh-TW',
//     //     maxResultCount: 7,
//     //     useStrictTypeFiltering: false,
//     // });

//     // if (places.length) {
//     //     let place = places[0];
//     //     const markerView = new AdvancedMarkerElement({
//     //         map,
//     //         position: place.location,
//     //         title: place.displayName,
//     //     });

//     //     const { LatLngBounds } = await google.maps.importLibrary("core");
//     //     const bounds = new LatLngBounds();
//     //     bounds.extend(place.location);
//     //     map.setCenter(bounds.getCenter());

//     // 多筆
//     // places.forEach((place) => {
//     //     const markerView = new AdvancedMarkerElement({
//     //         map,
//     //         position: place.location,
//     //         title: place.displayName,
//     //     });

//     //     bounds.extend(place.location);
//     //     console.log(place);
//     // });

//     // map.setCenter(bounds.getCenter());
//     //}
//     // else
//     //     console.log('No results');
// }

let markerView
async function setMarker(item) {
    // clean old marker
    if (markerView)
        markerView.position = null

    // add new marker
    const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");
    markerView = new AdvancedMarkerElement({
        map,
        position: item.location,
        title: item.displayName,
    });

    // set map center to the marker
    const { LatLngBounds } = await google.maps.importLibrary("core");
    const bounds = new LatLngBounds();
    bounds.extend(item.location);
    map.setCenter(bounds.getCenter());
}

async function searchByText(text) {
    // https://developers.google.com/maps/documentation/javascript/place-search?hl=zh-tw
    if (text == '')
        return null

    const { Place } = await google.maps.importLibrary("places");
    const { places } = await Place.searchByText({
        textQuery: text,
        fields: ['id', 'displayName', 'location', 'adrFormatAddress'],
        language: 'zh-TW',
        maxResultCount: 20
    });

    let list = []
    if (places.length) {
        console.log(places)
        places.forEach(function (p) {
            p.address = ''
            let elements = $.parseHTML(p.adrFormatAddress);
            let locality = elements.find(x => x.className == 'locality')
            if (locality)
                p.address += locality.innerText
            let street = elements.find(x => x.className == 'street-address')
            if (street)
                p.address += street.innerText

            list.push({
                id: p.id,
                displayName: p.displayName,
                location: p.location,
                adrFormatAddress: p.adrFormatAddress,
                address: p.address
            })
        })
    }

    return list
}