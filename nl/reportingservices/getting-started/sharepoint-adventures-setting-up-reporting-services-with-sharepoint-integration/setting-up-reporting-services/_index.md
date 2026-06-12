---
title: Reporting Services instellen
type: docs
weight: 30
url: /nl/reportingservices/setting-up-reporting-services/
---
{{% alert color="primary" %}} 

Onze eerste stop op de RS Server is de Reporting Services Configuration Manager. 

{{% /alert %}} 
## **Serviceaccount**
Zorg ervoor dat u begrijpt welk serviceaccount u gebruikt voor Reporting Services. Als we tegen problemen aanlopen, kan dat te maken hebben met het serviceaccount dat u gebruikt. Standaard is Network Service. Telkens wanneer ik nieuwe builds uitrol, gebruik ik altijd domeinaccounts, omdat daar waarschijnlijk problemen ontstaan. Voor deze configuratie op mijn server heb ik een domeinaccount gebruikt genaamd **RSService**. 
## **Web Service URL**
We moeten de Web Service URL configureren. Dit is de **ReportServer** virtuele directory (vdir) die de webservices host die Reporting Services gebruikt, en waarmee SharePoint communiceert. Tenzij u de eigenschappen van de vdir wilt aanpassen (bijv. SSL, poorten, host‑headers, enz.), zou u hier gewoon op Toepassen moeten kunnen klikken en verder kunnen gaan. 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)


**Figuur 3**: Instellen van de Web Service URL 

Wanneer dat gedaan is, zou u de volgende afbeelding moeten zien. 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**Figuur 4**: Succesvolle installatie van de Web Service URL 
## **Database**
We moeten de Reporting Services Catalog‑database aanmaken. Deze kan op elke SQL 2008‑ of SQL 2008 R2‑Database Engine worden geplaatst. SQL 11 zou ook prima werken, maar die zit nog in BETA. Deze actie maakt standaard twee databases aan, **ReportServer** en **ReportServerTempDB**. 
De andere belangrijke stap hierbij is ervoor te zorgen dat u **SharePoint Integrated** kiest als het databasetype. Zodra deze keuze is gemaakt, kan deze niet meer worden gewijzigd. Zie de Figuur 5, 6 en 7 ter referentie. 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**Figuur 5**: Aanmaken van de Report Server-database 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**Figuur 6**: Configureren van de database‑server en authenticatietype 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**Figuur 7**: Configureren van databasenaam en modus 

Voor de referenties is dit hoe de Report Server met de SQL Server zal communiceren. Het account dat u kiest, krijgt bepaalde rechten binnen de Catalog‑database en enkele systeemdatabases via de RSExecRole. MSDB is een van die databases voor abonnementgebruik omdat we SQL Agent gebruiken. 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**Figuur 8**: Configureren van de Report Server-database‑referenties 

Zodra dat klaar is, zou het er als volgt uit moeten zien. 

![todo:image_alt_text](setting-up-reporting-services_8.png)


**Figuur 9**: Voortgang om de Report Server-database‑configuratie te voltooien 
## **Report Manager URL**
We kunnen de Report Manager‑URL overslaan, want die wordt niet gebruikt wanneer we in SharePoint Integrated‑modus werken. SharePoint is onze front‑end. Report Manager werkt niet. 
## **Encryptiesleutels**
Maak een back‑up van uw encryptiesleutels en zorg dat u weet waar u ze bewaart. Als u in een situatie komt waarin u de database moet migreren of herstellen, hebt u deze nodig. 

![todo:image_alt_text](setting-up-reporting-services_9.png)

Dat is alles voor de Reporting Services Configuration Manager. Als u naar de URL op het tabblad Web Service URL gaat, zou er iets vergelijkbaars moeten verschijnen als de onderstaande afbeelding. 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**Figuur 12**: Toegang tot Report Server na installatie 

Wat is er gebeurd? SharePoint is geïnstalleerd op mijn WFE en ik heb de installatie van Reporting Services afgerond. In dit voorbeeld staan Reporting Services en SharePoint op verschillende machines. Als ze op dezelfde machine hadden gestaan, zou u deze fout niet hebben gezien. Technisch gezien moeten we SharePoint op de RS‑box installeren. Dat betekent dat IIS ook ingeschakeld wordt.