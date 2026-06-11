---
title: Inställning av Reporting Services
type: docs
weight: 30
url: /sv/reportingservices/setting-up-reporting-services/
---
{{% alert color="primary" %}} 

Vårt första stopp på RS‑servern är Reporting Services Configuration Manager. 

{{% /alert %}} 
## **Servicekonto**
Se till att du förstår vilket servicekonto du använder för Reporting Services. Om vi stöter på problem kan det bero på det servicekonto du använder. Standard är Network Service. När jag distribuerar nya byggnader använder jag alltid domänkonton, eftersom det är där jag ofta stöter på problem. För den här konfigurationen på min server har jag använt ett domänkonto som heter **RSService**. 
## **Webbtjänst‑URL**
Vi måste konfigurera Webbtjänst‑URL. Detta är den **ReportServer**‑virtuella katalogen (vdir) som hostar de Webbtjänster som Reporting Services använder, och som SharePoint kommer att kommunicera med. Om du inte vill anpassa egenskaperna för vdir (t.ex. SSL, portar, host‑headers osv.) bör du bara kunna klicka på Apply här och vara klar. 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)


**Figur 3**: Ställa in Webbtjänst‑URL 

När det är gjort bör du se följande figur. 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**Figur 4**: Lyckad inställning av Webbtjänst‑URL 
## **Databas**
Vi måste skapa Reporting Services‑katalogdatabasen. Den kan placeras på vilken SQL 2008‑ eller SQL 2008 R2‑databasmotor som helst. SQL11 skulle också fungera, men den är fortfarande i BETA. Denna åtgärd kommer som standard att skapa två databaser, **ReportServer** och **ReportServerTempDB**. 
Det andra viktiga steget är att se till att du väljer SharePoint Integrated för databastypen. När detta val har gjorts kan det inte ändras. Se figurerna 5, 6 och 7 för referens. 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**Figur 5**: Skapa Report Server‑databas 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**Figur 6**: Ställa in databasserver och autentiseringstyp 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**Figur 7**: Ställa in databasenamn och läge 

För autentiseringsuppgifterna är det så här Report Server kommer att kommunicera med SQL Server. Vilket konto du väljer får vissa rättigheter i katalogdatabasen samt i några av systemdatabaserna via RSExecRole. MSDB är en av dessa databaser för prenumerationsanvändning eftersom vi använder SQL Agent. 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**Figur 8**: Ställa in Report Server‑databasens autentiseringsuppgifter 

När det är klart bör det se ut som figuren nedan. 

![todo:image_alt_text](setting-up-reporting-services_8.png)


**Figur 9**: Framsteg mot att slutföra konfigurationen av Report Server‑databasen 
## **Report Manager‑URL**
Vi kan hoppa över Report Manager‑URL, eftersom den inte används när vi är i SharePoint Integrated‑läge. SharePoint är vårt front‑end. Report Manager fungerar inte. 
## **Krypteringsnycklar**
Säkerhetskopiera dina krypteringsnycklar och se till att du vet var du har dem lagrade. Om du hamnar i en situation där du måste migrera databasen eller återställa den, kommer du behöva dessa. 

![todo:image_alt_text](setting-up-reporting-services_9.png)

Det var allt för Reporting Services Configuration Manager. Om du öppnar URL‑en på fliken Webbtjänst‑URL bör den visa något liknande följande figur. 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**Figur 12**: Åtkomst till Report Server efter installation 

Vad hände? SharePoint är installerat på min WFE och jag har avslutat konfigurationen av Reporting Services. I det här exemplet är Reporting Services och SharePoint på olika maskiner. Om de hade varit på samma maskin hade du inte sett detta fel. Vi måste tekniskt sett installera SharePoint på RS‑boxen. Det betyder att IIS också kommer att aktiveras.