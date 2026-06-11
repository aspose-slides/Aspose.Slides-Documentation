---
title: Konvertera PPT till PPTX i .NET
linktitle: PPT till PPTX
type: docs
weight: 20
url: /sv/net/convert-ppt-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertera äldre PPT-presentationer till moderna PPTX snabbt i .NET med Aspose.Slides — tydlig handledning, gratis C#-kodexempel, ingen Microsoft Office-beroende."
---
## **Översikt**

Denna artikel förklarar hur man konverterar PowerPoint-presentationer i PPT-format till PPTX-format med C# och med den onlinetjänst för PPT till PPTX‑konvertering. Följande ämne behandlas.

- [Konvertera PPT till PPTX i C#](#convert-ppt-to-pptx)

## **Konvertera PPT till PPTX i .NET**

För C#‑exempelkod som konverterar PPT till PPTX, se avsnittet nedan, dvs. [Convert PPT to PPTX](#convert-ppt-to-pptx). Koden läser bara in PPT‑filen och sparar den i PPTX‑format. Genom att ange olika sparformat kan du också spara PPT‑filen i många andra format som PDF, XPS, ODP, HTML osv. som diskuteras i dessa artiklar.

- [Konvertera PPT till PDF i .NET](/slides/sv/net/convert-powerpoint-to-pdf/)
- [Konvertera PPT till XPS i .NET](/slides/sv/net/convert-powerpoint-to-xps/)
- [Konvertera PPT till HTML i .NET](/slides/sv/net/convert-powerpoint-to-html/)
- [Konvertera PPT till ODP i .NET](/slides/sv/net/save-presentation/)
- [Konvertera PPT till PNG i .NET](/slides/sv/net/convert-powerpoint-to-png/)

## **Om PPT till PPTX‑konvertering**
Konvertera gammalt PPT‑format till PPTX med Aspose.Slides API. Om du behöver konvertera tusentals PPT‑presentationer till PPTX‑format är den bästa lösningen att göra det programatiskt. Med Aspose.Slides API är det möjligt att göra det på några få kodrader. API‑et stödjer full kompatibilitet för att konvertera PPT‑presentationer till PPTX och det är möjligt att:

- Konvertera komplexa strukturer av master‑bilder, layouter och bildspel.
- Konvertera presentationer med diagram.
- Konvertera presentationer med gruppformer, auto‑former (som rektanglar och ellipser), former med anpassad geometri.
- Konvertera presentationer som har texturer och bildfyllningsstilar för auto‑former.
- Konvertera presentationer med platshållare, textramar och texthållare.

{{% alert color="primary" %}} 

Ta en titt på [**Aspose.Slides PPT till PPTX‑konvertering**](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx)‑appen:

[](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx)

Denna app är byggd på **Aspose.Slides API**, så du kan se ett levande exempel på grundläggande PPT‑till‑PPTX‑konverteringsfunktioner. Aspose.Slides Conversion är en webbapp som låter dig släppa in en presentationsfil i PPT‑format och ladda ner den konverterad till PPTX.

Hitta andra levande [**Aspose.Slides Conversion**](https://products.aspose.app/slides/sv/conversion/)‑exempel.
{{% /alert %}} 


## **Konvertera PPT till PPTX**
För att konvertera en PPT till PPTX skickar du bara filnamnet och sparformatet till [**Save**](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/methods/save/index)‑metoden på [**Presentation**](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑klassen. C#‑kodexemplet nedan konverterar en Presentation från PPT till PPTX med standardalternativ.

```c#
// Instansiera ett Presentation-objekt som representerar en PPTX-fil
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Sparar PPTX-presentationen i PPTX-format
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

Läs mer om [**PPT vs PPTX**](/slides/sv/net/ppt-vs-pptx/)‑presentationsformat och hur [**Aspose.Slides stödjer PPT till PPTX‑konvertering**](/slides/sv/net/convert-ppt-to-pptx/).

## **FAQ**

**Vad är skillnaden mellan PPT‑ och PPTX‑formaten?**

PPT är det äldre binära filformatet som används av Microsoft PowerPoint, medan PPTX är det nyare XML‑baserade formatet som introducerades med Microsoft Office 2007. PPTX‑filer ger bättre prestanda, mindre filstorlek och förbättrad dataåterställning.

**Kan jag konvertera PPT till PPTX med .NET?**

Ja, med Aspose.Slides för .NET‑biblioteket kan du enkelt läsa in en PPT‑fil och spara den i PPTX‑format med bara några få kodrader.

**Stöder Aspose.Slides batch‑konvertering av flera PPT‑filer till PPTX?**

Ja, du kan använda Aspose.Slides i en loop för att programatiskt konvertera flera PPT‑filer till PPTX, vilket är lämpligt för batch‑konverteringsscenario.

**Behåller innehållet och formateringen sin integritet efter konvertering?**

Aspose.Slides upprätthåller hög återgivning när presentationer konverteras. Bildlayouter, animationer, former, diagram och andra designelement bevaras under PPT‑till‑PPTX‑konverteringen.

**Kan jag konvertera andra format som PDF eller HTML från PPT‑filer?**

Ja, Aspose.Slides stödjer konvertering av PPT‑filer till flera format, inklusive PDF, XPS, HTML, ODP samt bildformat som PNG och JPEG.

**Är det möjligt att konvertera PPT till PPTX utan att ha Microsoft PowerPoint installerat?**

Ja, Aspose.Slides för .NET är ett fristående API och kräver inte Microsoft PowerPoint eller någon tredje‑parts‑programvara för att utföra konverteringen.

**Finns det ett online‑verktyg för PPT‑till‑PPTX‑konvertering?**

Ja, du kan använda den fria [Aspose.Slides PPT till PPTX‑konverteraren](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx) webbapplikationen för att utföra konverteringen direkt i din webbläsare utan att skriva någon kod.