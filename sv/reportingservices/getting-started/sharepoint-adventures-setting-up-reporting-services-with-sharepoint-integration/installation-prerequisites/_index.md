---
title: Installationsförutsättningar
type: docs
weight: 20
url: /sv/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 
Följande förutsättningar måste uppfyllas innan vi fortsätter med installationen. 
{{% /alert %}} 
## **Reporting Services Add-In for SharePoint**
**Reporting Services Add-In for SharePoint** är en av de viktigaste komponenterna för att få integrationen att fungera korrekt. Tillägget måste installeras på någon av **Web Front Ends (WFE)** i din SharePoint-farm tillsammans med Central Admin‑servern. En av de nya förändringarna med SQL 2008 R2 & SharePoint 2010 är att 2008 R2‑tillägget nu är ett förkrav för SharePoint‑installationen. Det innebär att RS‑tillägget läggs ner när du installerar SharePoint. Det har visats och markerats i figuren nedan. Detta undviker faktiskt många problem vi såg med SP 2007 och RS 2008 vid installation av tillägget. 

![todo:image_alt_text](installation-prerequisites_1.png)

**Figur 1**: Reporting Services Add-In for SharePoint 
## **SharePoint Authentication**
Innan du går in på RS‑integrationsdelarna är en sak viktig och måste tas hand om: hur du konfigurerar din **Site** i SharePoint‑farm. Mer specifikt hur du ställer in autentisering för webbplatsen; om den ska vara **Classic** eller **Claims**. Detta val är viktigt i början. Jag tror inte att du kan ändra detta alternativ när det är gjort. Om du kan ändra det, skulle det inte vara en enkel process. 

{{% alert color="primary" %}} 
Reporting Services 2008 R2 är INTE medveten om Claims 
{{% /alert %}} 

Även om du väljer att din SharePoint‑site använder **Claims**, är Reporting Services självt inte medveten om Claims. Det påverkar hur autentisering fungerar med Reporting Services. Så, vad är skillnaden ur ett Reporting Services‑perspektiv? Det handlar om huruvida du vill vidarebefordra användaruppgifter till datakällan. 

***Classic*** - Kan använda Kerberos och vidarebefordra användarens kredentialer till din bakre datakälla (du måste använda Kerberos för det). 

***Claims*** - En Claims‑token används och inte en Windows‑token. RS kommer alltid att använda Trusted Authentication i detta scenario och har endast åtkomst till SPUser‑tokenet. Du måste lagra dina kredentialer i datakällan. 

För tillfället vill vi bara fokusera på installationen av RS. Vid detta tillfälle är SharePoint installerat på SharePoint‑Boxen och konfigurerat med en **Classic Auth Site** på **port 80**. Dessutom har jag **just installerat Reporting Services** på RS‑servern och det är allt.