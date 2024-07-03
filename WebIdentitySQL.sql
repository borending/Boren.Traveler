﻿CREATE TABLE "AspNetRoles" (
	"Id" TEXT NOT NULL,
	"Name" CHARACTER VARYING ( 256 ),
	"NormalizedName" CHARACTER VARYING ( 256 ),
	"ConcurrencyStamp" TEXT,
	CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ( "Id" ) 
);

CREATE TABLE "AspNetUsers" (
	"Id" TEXT NOT NULL,
	"UserName" CHARACTER VARYING ( 256 ),
	"NormalizedUserName" CHARACTER VARYING ( 256 ),
	"Email" CHARACTER VARYING ( 256 ),
	"NormalizedEmail" CHARACTER VARYING ( 256 ),
	"EmailConfirmed" BOOLEAN NOT NULL,
	"PasswordHash" TEXT,
	"SecurityStamp" TEXT,
	"ConcurrencyStamp" TEXT,
	"PhoneNumber" TEXT,
	"PhoneNumberConfirmed" BOOLEAN NOT NULL,
	"TwoFactorEnabled" BOOLEAN NOT NULL,
	"LockoutEnd" TIMESTAMP WITH TIME ZONE,
	"LockoutEnabled" BOOLEAN NOT NULL,
	"AccessFailedCount" INTEGER NOT NULL,
	CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ( "Id" ) 
);

CREATE TABLE "AspNetRoleClaims" (
	"Id" INTEGER GENERATED BY DEFAULT AS IDENTITY,
	"RoleId" TEXT NOT NULL,
	"ClaimType" TEXT,
	"ClaimValue" TEXT,
	CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ( "Id" ),
	CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ( "RoleId" ) REFERENCES "AspNetRoles" ( "Id" ) ON DELETE CASCADE 
);

CREATE TABLE "AspNetUserClaims" (
	"Id" INTEGER GENERATED BY DEFAULT AS IDENTITY,
	"UserId" TEXT NOT NULL,
	"ClaimType" TEXT,
	"ClaimValue" TEXT,
	CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ( "Id" ),
	CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ( "UserId" ) REFERENCES "AspNetUsers" ( "Id" ) ON DELETE CASCADE 
);

CREATE TABLE "AspNetUserLogins" (
	"LoginProvider" CHARACTER VARYING ( 128 ) NOT NULL,
	"ProviderKey" CHARACTER VARYING ( 128 ) NOT NULL,
	"ProviderDisplayName" TEXT,
	"UserId" TEXT NOT NULL,
	CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ( "LoginProvider", "ProviderKey" ),
	CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ( "UserId" ) REFERENCES "AspNetUsers" ( "Id" ) ON DELETE CASCADE 
);

CREATE TABLE "AspNetUserRoles" (
	"UserId" TEXT NOT NULL,
	"RoleId" TEXT NOT NULL,
	CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ( "UserId", "RoleId" ),
	CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ( "RoleId" ) REFERENCES "AspNetRoles" ( "Id" ) ON DELETE CASCADE,
	CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ( "UserId" ) REFERENCES "AspNetUsers" ( "Id" ) ON DELETE CASCADE 
);

CREATE TABLE "AspNetUserTokens" (
	"UserId" TEXT NOT NULL,
	"LoginProvider" CHARACTER VARYING ( 128 ) NOT NULL,
	"Name" CHARACTER VARYING ( 128 ) NOT NULL,
	"Value" TEXT,
	CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ( "UserId", "LoginProvider", "Name" ),
	CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ( "UserId" ) REFERENCES "AspNetUsers" ( "Id" ) ON DELETE CASCADE 
);

CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ( "RoleId" );
CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ( "NormalizedName" );
CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ( "UserId" );
CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ( "UserId" );
CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ( "RoleId" );
CREATE INDEX "EmailIndex" ON "AspNetUsers" ( "NormalizedEmail" );
CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ( "NormalizedUserName" );