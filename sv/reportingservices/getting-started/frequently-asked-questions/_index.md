---
title: Vanliga frågor
type: docs
weight: 110
url: /sv/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 
Den här sidan samlar ett antal vanliga frågor om:

- [Stödda filformat](#Supported-File-Formats).
- [Stöd för Power BI Reporting services](#Support-for-Power-BI-Reporting-services).
- [Installation](#Installation).
- [Exportkonfiguration](#Export-Configuration).

{{% /alert %}} 
### **Supported File Formats**
#### **Q: Vilka format kan du exportera rapporter till med Aspose.Slides for Reporting Services?**
**A**: Aspose.Slides for Reporting Services gör det möjligt att exportera alla rapporter i PPT-, PPS-, PPTX-, PPSX-, XPS- eller RPL-format.
### **Support for Power BI Reporting services**
#### **Q: Stöder Aspose.Slides for Reporting Services Power BI?**
**A**: Ja. Aspose.Slides for Reporting Services stöder export av paginerade rapporter (RDL) i Power BI.
### **Installation**
#### **Q: Installationsprogrammet startar inte. Manuell installation ger inte önskat resultat.**
**A** : Se till att .NET Framework 3.5 är installerat på ditt system.
#### **Q: Exportalternativ saknas efter installation av Aspose.Slides for Reporting Services.**
**A**: Om någon CodeGroup i rssrvpolicy.config inte fungerar korrekt kan konfigurationsfilens parser hoppa över de sista sektionerna i gruppen. Flytta därför alla CodeGroups som är associerade med Aspose.Slides for Reporting Services till början av blocket som innehåller Aspose.Slides for Reporting Services CodeGroups.
#### **Q: Kunde inte läsa in filen eller assemblyn Aspose.Slides.ReportingServices (Körningsbehörighet kan inte erhållas \ Undantag från HRESULT: 0x80131418).**
**A**: Felkoden (0x80131418) indikerar att dll-modulen inte har tillräckliga rättigheter. Detta kan bero på en säkerhetsfunktion som blockerade full åtkomst till .dll-filen om den hämtades från en annan dator. Detta kan åtgärdas genom att öppna egenskapsfönstret för dll-filen och klicka på knappen "Unblock" i fliken "Security".
#### **Q: Kan inte hitta licensen 'Aspose.Slides.Reporting.Services.lic'.**
**A**: Licensfilen måste ligga bredvid dll-filen eller i katalogen Program Files(x86)\Aspose\Slides\.
### **Export Configuration**
#### **Q: Hur kan jag ändra färgen på hyperlänkar i en exporterad rapport?**
**A**: Varje renderings-extension för Aspose.Slides for Reporting Services i rsreportserver.config har sin egen konfiguration. För att ändra färgen på hyperlänkar, ange önskat värde i <HyperlinkColor>-sektionen.
#### **Q: I exporterade presentationer sträcks texten i tabeller vertikalt.**
**A**: Detta görs för att göra dokumentet lättare att läsa. För att visa texten i tabellen som den visas i rapporten, ställ in den önskade Aspose.Slides for Reporting Services-extensionen till "Normal" i rsreportserver.config-konfigurationsfilen.