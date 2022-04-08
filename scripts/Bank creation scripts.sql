USE Deathstar

--******** PLANETS **************************************** **************************************************** *****
CREATETABLE Planets(
IdPlanet int NOTNULL,
Names varchar(50) NOT NULL,
Rotation float NOT NULL,
Orbit float NOTNULL,
Float_diameter NOTNULL,
Weather varchar(50) NOT NULL,
Populations int NOT NULL,
)
IR
ALTER TABLE Planets ADD CONSTRAINT PK_Planets PRIMARY KEY (IdPlanet);
IR
--**************************************************** **************************************************** **************
--******** SHIPS **************************************** **************************************************** ********
CREATETABLE Ships(
IdShips int NOTNULL,
Names varchar(100) NOT NULL,
Model varchar(150) NOT NULL,
Passengers int NOT NULL,
Charge float NOTNULL,
Class varchar(100) NOT NULL,
)
IR
ALTER TABLE Naves ADD CONSTRAINT PK_Naves PRIMARY KEY (IdNave);
IR
--******** PILOTS **************************************** **************************************************** ******
--**************************************************** **************************************************** **************
CREATETABLE Pilots(
IdPilot int NOTNULL,
Names varchar(200) NOT NULL,
YearofBirth varchar(10) NOT NULL,
IdPlanet int NOTNULL,
)
IR
ALTER TABLE Pilots ADD CONSTRAINT PK_Pilots PRIMARY KEY (IdPilot);
IR
ALTER TABLE Pilots ADD CONSTRAINT FK_Pilots_Planets FOREIGN KEY(IdPlanet)
REFERENCE Planets (IdPlanet)
IR
ALTER TABLE Pilots CHECK CONSTRAINT FK_Pilots_Planets
IR
--**************************************************** **************************************************** **************
--******** PILOTS SHIPS **************************************** **************************************************** *
CREATE TABLE PilotsShips(
IdPilot int NOTNULL,
IdShip int NOTNULL,
FlagAuthorized bit NOT NULL,
)
IR
ALTER TABLE PilotsShips ADD CONSTRAINT PK_PilotsShips PRIMARY KEY (IdPilot, IdShip);
IR
ALTER TABLE PilotsShips ADD CONSTRAINT FK_PilotsShips_Pilots FOREIGN KEY(IdPilot)
REFERENCE Pilots (IdPilot)
IR
ALTER TABLE PilotsShips ADD CONSTRAINT FK_PilotsShips_Ships FOREIGN KEY(IdShip)
REFERENCE Naves (IdShip)
IR
ALTER TABLE PilotsShips ADD CONSTRAINT DF_PilotsShips_FlagAuthorized DEFAULT (1) FOR FlagAuthorized
IR
--**************************************************** **************************************************** **************
--******** TRAVEL HISTORY ************************************* ************************************************
CREATE TABLE HistoricalTravel(
IdShip int NOTNULL,
IdPilot int NOTNULL,
DtOutpu datetime NOT NULL,
DtArrival datetime NULL
)
IR

ALTER TABLE HistoricalTravel ADD CONSTRAINT FK_HistoricalTravel_PilotsShips FOREIGN KEY(IdPilot, IdShip)
REFERENCE PilotsShips (IdPilot, IdShip)
IR

ALTER TABLE HistoricalTravel CHECK CONSTRAINT FK_HistoricalTravel_PilotsShips
IR
--**************************************************** **************************************************** **************