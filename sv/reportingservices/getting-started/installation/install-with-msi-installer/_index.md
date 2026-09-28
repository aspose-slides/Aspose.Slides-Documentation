---
title: Installera med MSI‑installationsprogrammet
type: docs
weight: 20
url: /sv/reportingservices/install-with-msi-installer/
keywords:
- MSI‑installationsprogram
- installation
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Installera Aspose.Slides for Reporting Services med dess MSI‑installationsprogram: vad installationsprogrammet kräver, vad det ändrar på varje rapportserverinstans och hur du kontrollerar resultatet."
---
## **Installation**

MSI‑installationsprogrammet är det enklaste sättet att installera Aspose.Slides for Reporting Services. Det kräver .NET Framework 3.5 och administratörsrättigheter på rapportservern; se [Systemkrav](/slides/sv/reportingservices/system-requirements/).

1. Ladda ner MSI‑installationsprogrammet, *Aspose.Slides for Reporting Services XX.XX*, från [nedladdningssidan](https://releases.aspose.com/slides/sv/reportingservices/) och kopiera det till rapportservern.
2. Kör den som administratör. Om .NET Framework 3.5 saknas stoppar installationsprogrammet med ett meddelande; installera .NET Framework 3.5‑funktionerna och kör det igen.
3. Godkänn licensavtalet.
4. På sidan **Custom Setup** listar feature‑trädet varje SQL Server Reporting Services‑ och Power BI Report Server‑instans som installationsprogrammet upptäcker på maskinen. För att lämna en instans oförändrad klickar du på dess ikon och väljer **Entire feature will be unavailable**. Express‑versioner stöder inte renderingstillägg, så välj inte en Express‑instans. Installationsprogrammet döljer Express‑instanser av SQL Server 2016 och tidigare.
5. Välj **Next**, och sedan **Install**.

Den valfria funktionen **Rpl Export** är inte markerad som standard. Den lägger till ett dolt tillägg som sparar rapporter i RPL‑format, vilket är användbart när du skickar en felrapport till Aspose; se [Exportera rapporter till RPL‑format](/slides/sv/reportingservices/exporting-reports-to-rpl-format/).

## **Vad installationsprogrammet ändrar**

Installationsprogrammet sparar sina filer i *Aspose\Aspose.Slides for Reporting Services* under mappen Program Files — *Program Files (x86)* på 64‑bitars Windows, eftersom installationsprogrammet är ett 32‑bitspaket. Därefter, för varje vald instans, gör det:

- kopierar *Aspose.Slides.ReportingServices.dll* till instansens *ReportServer\bin*-mapp — versionen för SQL Server 2005, eller versionen för SQL Server 2008 och senare samt Power BI Report Server;
- lägger till sex renderingstillägg — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS och ASODP — i `<Render>`‑elementet i *rsreportserver.config*;
- lägger till en kodgrupp som ger assemblyn full tillit i *rssrvpolicy.config*;
- sparar en kopia av varje konfigurationsfil den ändrar, med *.bak* tillagt i filnamnet.

[Installera manuellt](/slides/sv/reportingservices/install-manually/) visar dessa ändringar steg för steg.

Om en instans inte kan konfigureras anger installationsprogrammet den i ett meddelande och skriver detaljerna till *rserrors<date>.log* i installationsmappen. Installera tillägget på den instansen manuellt.

## **Verifiera installationen**

Öppna en paginerad rapport i webbportalen (Report Manager på SQL Server 2014 och tidigare) och öppna **Export**‑listan. Den innehåller nu följande format:

- PPT - PowerPoint‑presentation via Aspose.Slides
- PPS - PowerPoint‑bildspel via Aspose.Slides
- PPTX - PowerPoint 2007‑presentation via Aspose.Slides
- PPSX - PowerPoint 2007‑bildspel via Aspose.Slides
- ODP - OpenDocument‑presentation via Aspose.Slides
- XPS - via Aspose.Slides

Utan licens får de exporterade filerna ett utvärderingsvattenstämpel; se [Licensiering](/slides/sv/reportingservices/license-aspose-slides-for-reporting-services/).

## **När du ska installera manuellt**

Installera tillägget [manuellt](/slides/sv/reportingservices/install-manually/) istället när:

- installationsprogrammet inte kan konfigurera en instans, till exempel på grund av säkerhetsinställningar på servern;
- efter en uppgradering vill du ersätta endast assemblyn istället för att avinstallera den gamla versionen och köra det nya installationsprogrammet.

Avinstallering av produkten tar bort assemblyn och konfigurationsposterna från varje instans.