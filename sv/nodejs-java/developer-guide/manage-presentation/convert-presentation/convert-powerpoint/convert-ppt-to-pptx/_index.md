---
title: Konvertera PPT till PPTX i JavaScript
linktitle: PPT till PPTX
type: docs
weight: 20
url: /sv/nodejs-java/convert-ppt-to-pptx/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- PPT till PPTX
- spara PPT som PPTX
- exportera PPT till PPTX
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera äldre PPT-presentationer till moderna PPTX snabbt med Aspose.Slides för Node.js — tydlig handledning, gratis kodexempel, ingen Microsoft Office‑beroende."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar en PowerPoint-presentation i PPT-format till PPTX-format med JavaScript och med en online PPT till PPTX‑konverteringsapp. Följande ämne behandlas.

- Konvertera PPT till PPTX i JavaScript

## **Java Konvertera PPT till PPTX**

För JavaScript‑exempelkod för att konvertera PPT till PPTX, se avsnittet nedan, dvs.[Konvertera PPT till PPTX](#convert-ppt-to-pptx). Det laddar bara PPT‑filen och sparar i PPTX‑format. Genom att ange olika sparformat kan du också spara PPT‑filen i många andra format som PDF, XPS, ODP, HTML osv., som diskuteras i dessa artiklar.

- [Konvertera PPT till PDF i JavaScript](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/)
- [Konvertera PPT till XPS i JavaScript](/slides/sv/nodejs-java/convert-powerpoint-to-xps/)
- [Konvertera PPT till HTML i JavaScript](/slides/sv/nodejs-java/convert-powerpoint-to-html/)
- [Konvertera PPT till ODP i JavaScript](/slides/sv/nodejs-java/save-presentation/)
- [Konvertera PPT till PNG i JavaScript](/slides/sv/nodejs-java/convert-powerpoint-to-png/)

## **Om PPT till PPTX‑konvertering**
Konvertera gammalt PPT‑format till PPTX med Aspose.Slides API. Om du behöver konvertera tusentals PPT‑presentationer till PPTX‑format är den bästa lösningen att göra det programatiskt. Med Aspose.Slides API är det möjligt att göra det med bara några rader kod. API:et stöder full kompatibilitet för att konvertera PPT‑presentationer till PPTX och det är möjligt att:

- Konvertera komplexa strukturer av mastrar, layouter och bildspel.
- Konvertera presentationer med diagram.
- Konvertera presentationer med gruppformer, automatformer (såsom rektanglar och ellipser), former med anpassad geometri.
- Konvertera presentationer som har texturer och bildfyllningsstilar för automatformer.
- Konvertera presentationer med platshållare, textramar och textinnehållare.

{{% alert color="primary" %}} 

Ta en titt på [**Aspose.Slides PPT till PPTX‑konvertering**](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx)‑appen:

[](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx)

Den här appen är byggd på [**Aspose.Slides API**](https://products.aspose.com/slides/sv/nodejs-java/), så du kan se ett levande exempel på grundläggande PPT till PPTX‑konverteringsfunktioner. Aspose.Slides Conversion är en webbapp som låter dig släppa presentationsfil i PPT‑format och ladda ner den konverterad till PPTX.

Hitta andra levande [**Aspose.Slides Conversion**](https://products.aspose.app/slides/sv/conversion/) exempel.
{{% /alert %}} 

## **Konvertera PPT till PPTX**
Aspose.Slides för Node.js via Java underlättar nu för utvecklare att komma åt PPT med [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) klassinstans och konvertera den till respektive [PPTX](https://docs.fileformat.com/presentation/pptx/) format. För närvarande stödjer den partiell konvertering av [PPT ](https://docs.fileformat.com/presentation/ppt/)till PPTX.

Aspose.Slides för Node.js via Java erbjuder [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) klass som representerar en **PPTX** presentationsfil. Presentation‑klassen kan nu också komma åt **PPT** via Presentation när objektet instansieras. Följande exempel visar hur man konverterar en PPT‑presentation till en PPTX‑presentation.

```javascript
// Skapa ett Presentation-objekt som representerar en PPTX-fil
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Sparar PPTX-presentationen i PPTX-format
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figur: Källdokument PPT‑presentation**|

Koden ovan genererade följande PPTX‑presentation efter konverteringen

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figur: Genererad PPTX‑presentation efter konvertering**|

## **FAQ**

**Vad är skillnaden mellan PPT‑ och PPTX‑formaten?**

PPT är det äldre binära filformatet som används av Microsoft PowerPoint, medan PPTX är det nyare XML‑baserade formatet som introducerades med Microsoft Office 2007. PPTX‑filer erbjuder bättre prestanda, minskad filstorlek och förbättrad dataräddning.

**Stöder Aspose.Slides batch‑konvertering av flera PPT‑filer till PPTX?**

Ja, du kan använda Aspose.Slides i en loop för att programatiskt konvertera flera PPT‑filer till PPTX, vilket gör det lämpligt för batch‑konverteringsscenarier.

**Kommer innehåll och formatering att bevaras efter konvertering?**

Aspose.Slides bibehåller hög noggrannhet vid konvertering av presentationer. Bildlayout, animationer, former, diagram och andra designelement bevaras under PPT‑till‑PPTX‑konverteringen.

**Kan jag konvertera andra format som PDF eller HTML från PPT‑filer?**

Ja, Aspose.Slides stöder konvertering av PPT‑filer till flera format, inklusive PDF, XPS, HTML, ODP och bildformat som PNG och JPEG.

**Är det möjligt att konvertera PPT till PPTX utan att Microsoft PowerPoint är installerat?**

Ja, Aspose.Slides är ett fristående API och kräver varken Microsoft PowerPoint eller någon tredjepartsprogramvara för att utföra konverteringen.

**Finns det ett onlineverktyg för PPT till PPTX‑konvertering?**

Ja, du kan använda den kostnadsfria [Aspose.Slides PPT till PPTX‑Converter](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx) webbtjänsten för att utföra konverteringen direkt i din webbläsare utan att skriva någon kod.