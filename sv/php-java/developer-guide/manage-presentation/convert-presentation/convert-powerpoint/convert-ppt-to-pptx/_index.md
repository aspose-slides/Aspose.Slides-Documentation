---
title: Konvertera PPT till PPTX i PHP
linktitle: PPT till PPTX
type: docs
weight: 20
url: /sv/php-java/convert-ppt-to-pptx/
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
- PHP
- Aspose.Slides
description: "Konvertera äldre PPT-presentationer till moderna PPTX snabbt med Aspose.Slides för PHP via Java — tydlig handledning, gratis kodexempel, utan beroende av Microsoft Office."
---
## **Översikt**

Denna artikel förklarar hur du konverterar PowerPoint‑presentation i PPT‑format till PPTX‑format med PHP och med den online PPT till PPTX‑konverteringsappen. Följande ämne behandlas.

- Konvertera PPT till PPTX

## **Konvertera PPT till PPTX i PHP**

För Java‑exempelkod för att konvertera PPT till PPTX, se avsnittet nedan [i.e. [Convert PPT to PPTX](#convert-ppt-to-pptx)](#convert-ppt-to-pptx). Det laddar bara PPT‑filen och sparar den i PPTX‑format. Genom att ange olika sparformat kan du också spara PPT‑filen till många andra format som PDF, XPS, ODP, HTML osv. som diskuteras i dessa artiklar.

- [Konvertera PPT till PDF i PHP](/slides/sv/php-java/convert-powerpoint-to-pdf/)
- [Konvertera PPT till XPS i PHP](/slides/sv/php-java/convert-powerpoint-to-xps/)
- [Konvertera PPT till HTML i PHP](/slides/sv/php-java/convert-powerpoint-to-html/)
- [Konvertera PPT till ODP i PHP](/slides/sv/php-java/save-presentation/)
- [Konvertera PPT till PNG i PHP](/slides/sv/php-java/convert-powerpoint-to-png/)

## **Om PPT till PPTX‑konvertering**
Konvertera gammalt PPT‑format till PPTX med Aspose.Slides API. Om du behöver konvertera tusentals PPT‑presentationer till PPTX‑format är den bästa lösningen att göra det programmässigt. Med Aspose.Slides API är det möjligt att göra det på bara några rader kod. API:et stöder full kompatibilitet för att konvertera PPT‑presentation till PPTX och det är möjligt att:

- Konvertera komplicerade strukturer av masterbilder, layouter och bilder.
- Konvertera presentation med diagram.
- Konvertera presentation med gruppegenskaper, autoformer (som rektanglar och ellipser), former med anpassad geometri.
- Konvertera presentation med texturer och bildfyllnadsstilar för autoformer.
- Konvertera presentation med platshållare, textfält och textinnehavare.

{{% alert color="primary" %}} 

Ta en titt på[**Aspose.Slides PPT till PPTX‑konvertering**](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx)‑appen:

[](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx)

Denna app är byggd på[**Aspose.Slides API**](https://products.aspose.com/slides/sv/php-java/), så du kan se ett levande exempel på grundläggande PPT‑till‑PPTX‑konverteringsfunktioner. Aspose.Slides Conversion är en webbapp som låter dig dra en presentationsfil i PPT‑format och ladda ner den konverterad till PPTX.

Hitta andra levande[**Aspose.Slides Conversion**](https://products.aspose.app/slides/sv/conversion/)‑exempel.
{{% /alert %}} 

## **Konvertera PPT till PPTX**
Aspose.Slides för PHP via Java underlättar nu för utvecklare att komma åt PPT‑filen med [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation)‑klassinstansen och konvertera den till respektive [PPTX](https://docs.fileformat.com/presentation/pptx/)-format. För närvarande stöder den partiell konvertering av [PPT](https://docs.fileformat.com/presentation/ppt/) till PPTX. För mer information om vilka funktioner som stöds respektive inte stöds i PPT‑till‑PPTX‑konverteringen, gå till denna dokumentations[link](/slides/sv/php-java/ppt-to-pptx-conversion/).

Aspose.Slides för PHP via Java erbjuder [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation)-klass som representerar en **PPTX**‑presentationsfil. Presentation‑klassen kan nu också komma åt **PPT** via Presentation när objektet instansieras. Följande exempel visar hur du konverterar en PPT‑presentation till PPTX‑presentation.

```php
  # Instansiera ett Presentation-objekt som representerar en PPTX-fil
  $pres = new Presentation("Aspose.ppt");
  try {
    # Spara PPTX-presentationen i PPTX-format
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figur: Ursprunglig PPT‑presentation**|

Koden ovan genererade följande PPTX‑presentation efter konvertering

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figur: Genererad PPTX‑presentation efter konvertering**|

## **FAQ**

**Vad är skillnaden mellan PPT‑ och PPTX‑formaten?**

PPT är det äldre binära filformatet som används av Microsoft PowerPoint, medan PPTX är det nyare XML‑baserade formatet som introducerades med Microsoft Office 2007. PPTX‑filer erbjuder bättre prestanda, minskad filstorlek och förbättrad dataräddning.

**Stöder Aspose.Slides batchkonvertering av flera PPT‑filer till PPTX?**

Ja, du kan använda Aspose.Slides i en loop för att programmässigt konvertera flera PPT‑filer till PPTX, vilket gör det lämpligt för batchkonverteringsscenario.

**Kommer innehållet och formateringen att behållas efter konvertering?**

Aspose.Slides bibehåller hög noggrannhet vid konvertering av presentationer. Bildlayouter, animationer, former, diagram och andra designelement bevaras under PPT‑till‑PPTX‑konverteringen.

**Kan jag konvertera andra format som PDF eller HTML från PPT‑filer?**

Ja, Aspose.Slides stöder konvertering av PPT‑filer till [flera format](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/), inklusive PDF, XPS, HTML, ODP och bildformat som PNG och JPEG.

**Är det möjligt att konvertera PPT till PPTX utan att Microsoft PowerPoint är installerat?**

Ja, Aspose.Slides är ett fristående API och kräver ingen installation av Microsoft PowerPoint eller annan tredjepartsprogramvara för att utföra konverteringen.

**Finns det ett online‑verktyg för PPT till PPTX‑konvertering?**

Ja, du kan använda den kostnadsfria[ Aspose.Slides PPT till PPTX‑Converter](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx)‑webbapplikationen för att utföra konverteringen direkt i din webbläsare utan att skriva någon kod.