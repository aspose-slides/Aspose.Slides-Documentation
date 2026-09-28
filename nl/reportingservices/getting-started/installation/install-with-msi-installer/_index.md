---
title: Installeren met MSI installer
type: docs
weight: 20
url: /nl/reportingservices/install-with-msi-installer/
keywords:
- MSI installer
- installatie
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Installeer Aspose.Slides for Reporting Services met de MSI installer: wat de installer nodig heeft, wat hij wijzigt op elke rapportservers instance, en hoe u het resultaat controleert."
---
## **Installatie**

De MSI‑installer is de eenvoudigste manier om Aspose.Slides for Reporting Services te installeren. Hij vereist .NET Framework 3.5 en beheerdersrechten op de rapportserver; zie [Systeemvereisten](/slides/nl/reportingservices/system-requirements/).

1. Download de MSI‑installer, *Aspose.Slides for Reporting Services XX.XX*, vanaf de [downloadpagina](https://releases.aspose.com/slides/nl/reportingservices/) en kopieer deze naar de rapportserver.  
2. Voer hem uit als beheerder. Als .NET Framework 3.5 ontbreekt, stopt de installer met een melding; installeer de .NET Framework 3.5‑functies en voer hem opnieuw uit.  
3. Accepteer de licentieovereenkomst.  
4. Op de **Custom Setup**‑pagina toont de functiebomen elke SQL Server Reporting Services‑ en Power BI Report Server‑instance die de installer op de machine detecteert. Om een instance ongewijzigd te laten, klik op het pictogram en selecteer **Entire feature will be unavailable**. Express‑edities ondersteunen geen rendering‑extensies, dus selecteer geen Express‑instance. De installer verbergt Express‑instances van SQL Server 2016 en ouder.  
5. Klik op **Next**, en daarna op **Install**.

De optionele **Rpl Export**‑functie is standaard niet geselecteerd. Ze voegt een verborgen extensie toe die rapporten opslaat in RPL‑formaat, wat handig is wanneer u een probleemrapport naar Aspose stuurt; zie [Rapporten exporteren naar RPL‑formaat](/slides/nl/reportingservices/exporting-reports-to-rpl-format/).

## **Wat de installer wijzigt**

De installer legt zijn bestanden onder *Aspose\Aspose.Slides for Reporting Services* in de Program Files‑map — *Program Files (x86)* op 64‑bit Windows, omdat de installer een 32‑bit pakket is. Vervolgens wordt voor elke geselecteerde instance:

- *Aspose.Slides.ReportingServices.dll* gekopieerd naar de *ReportServer\bin*‑map van de instance — de build voor SQL Server 2005, of de build voor SQL Server 2008 en later en Power BI Report Server;  
- zes rendering‑extensies — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS en ASODP — toegevoegd aan het `<Render>`‑element van *rsreportserver.config*;  
- een code‑group toegevoegd die de assembly volledige trust verleent in *rssrvpolicy.config*;  
- een kopie van elk aangepast configuratie‑bestand bewaard met de extensie *.bak*.

[Installatie handmatig](/slides/nl/reportingservices/install-manually/) laat deze wijzigingen stap voor stap zien.

Als een instance niet geconfigureerd kan worden, noemt de installer deze in een melding en schrijft de details naar *rserrors<date>.log* in de installatiemap. Installeer de extensie handmatig op die instance.

## **Controleer de installatie**

Open een gepagineerd rapport in de webportal (Report Manager op SQL Server 2014 en ouder) en open de **Export**‑lijst. Deze bevat nu de volgende formaten:

- PPT – PowerPoint‑presentatie via Aspose.Slides  
- PPS – PowerPoint‑diavoorstelling via Aspose.Slides  
- PPTX – PowerPoint 2007‑presentatie via Aspose.Slides  
- PPSX – PowerPoint 2007‑diavoorstelling via Aspose.Slides  
- ODP – OpenDocument‑presentatie via Aspose.Slides  
- XPS – via Aspose.Slides  

Zonder licentie hebben de geëxporteerde bestanden een evaluatiewatermerk; zie [Licenties](/slides/nl/reportingservices/license-aspose-slides-for-reporting-services/).

## **Wanneer handmatig installeren**

Installeer de extensie [handmatig](/slides/nl/reportingservices/install-manually/) in plaats daarvan wanneer:

- de installer een instance niet kan configureren, bijvoorbeeld door beveiligingsinstellingen op de server;  
- na een upgrade wilt u alleen de assembly vervangen in plaats van de oude versie te de‑installeren en de nieuwe installer uit te voeren.

Het de‑installeren van het product verwijdert de assembly en de configuratie‑vermeldingen uit elke instance.