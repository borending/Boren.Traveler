CREATE TABLE "AspNetRoleClaims" (
  "Id" serial4,
  "RoleId" text NOT NULL,
  "ClaimType" text,
  "ClaimValue" text,
  CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id")
);
CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" USING btree (
  "RoleId" ASC NULLS LAST
);

CREATE TABLE "AspNetRoles" (
  "Id" text NOT NULL,
  "Name" varchar(256),
  "NormalizedName" varchar(256),
  "ConcurrencyStamp" text,
  CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id")
);
CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" USING btree (
  "NormalizedName" ASC NULLS LAST
);

CREATE TABLE "AspNetUserClaims" (
  "Id" serial4,
  "UserId" text NOT NULL,
  "ClaimType" text,
  "ClaimValue" text,
  CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id")
);
CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" USING btree (
  "UserId" ASC NULLS LAST
);

CREATE TABLE "AspNetUserLogins" (
  "LoginProvider" varchar(128) NOT NULL,
  "ProviderKey" varchar(128) NOT NULL,
  "ProviderDisplayName" text,
  "UserId" text NOT NULL,
  CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey")
);
CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" USING btree (
  "UserId" ASC NULLS LAST
);

CREATE TABLE "AspNetUserRoles" (
  "UserId" text NOT NULL,
  "RoleId" text NOT NULL,
  CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId")
);
CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" USING btree (
  "RoleId" ASC NULLS LAST
);

CREATE TABLE "AspNetUsers" (
  "Id" text NOT NULL,
  "UserName" varchar(256),
  "NormalizedUserName" varchar(256),
  "Email" varchar(256),
  "NormalizedEmail" varchar(256),
  "EmailConfirmed" bool NOT NULL,
  "PasswordHash" text,
  "SecurityStamp" text,
  "ConcurrencyStamp" text,
  "PhoneNumber" text,
  "PhoneNumberConfirmed" bool NOT NULL,
  "TwoFactorEnabled" bool NOT NULL,
  "LockoutEnd" timestamptz(6),
  "LockoutEnabled" bool NOT NULL,
  "AccessFailedCount" int4 NOT NULL,
  CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id")
);
CREATE INDEX "EmailIndex" ON "AspNetUsers" USING btree (
  "NormalizedEmail" ASC NULLS LAST
);
CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" USING btree (
  "NormalizedUserName" ASC NULLS LAST
);

CREATE TABLE "AspNetUserTokens" (
  "UserId" text NOT NULL,
  "LoginProvider" varchar(128) NOT NULL,
  "Name" varchar(128) NOT NULL,
  "Value" text,
  CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name")
);

CREATE TABLE "Place" (
  "Id" serial4,
  "TripId" int4 NOT NULL,
  "PlaceApiId" varchar(128) NOT NULL,
  "OriginName" varchar(255) NOT NULL,
  "CustomName" varchar(255),
  "Location" point NOT NULL,
  "Stay" timestamptz,
  "Order" int4 NOT NULL,
  "Remark" text,
  PRIMARY KEY ("Id")
);
COMMENT ON COLUMN "Place"."PlaceApiId" IS 'Place API.Id';
COMMENT ON COLUMN "Place"."OriginName" IS 'Place API.displayName';
COMMENT ON COLUMN "Place"."CustomName" IS '自訂名稱';
COMMENT ON COLUMN "Place"."Location" IS '座標';
COMMENT ON COLUMN "Place"."Stay" IS '停留時長';
COMMENT ON COLUMN "Place"."Order" IS '順序';
COMMENT ON COLUMN "Place"."Remark" IS '備註';

CREATE TABLE "Trip" (
  "Id" serial4,
  "UserId" text NOT NULL,
  "Name" varchar(255) NOT NULL,
  "Time" timestamptz NOT NULL,
  PRIMARY KEY ("Id")
);
COMMENT ON COLUMN "Trip"."Name" IS '旅程名稱';
COMMENT ON COLUMN "Trip"."Time" IS '創建時間';
COMMENT ON TABLE "Trip" IS '旅程';

ALTER TABLE "AspNetRoleClaims" ADD CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "AspNetUserClaims" ADD CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "AspNetUserLogins" ADD CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "AspNetUserRoles" ADD CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "AspNetUserRoles" ADD CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "AspNetUserTokens" ADD CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "Place" ADD FOREIGN KEY ("TripId") REFERENCES "Trip" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "Trip" ADD FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

