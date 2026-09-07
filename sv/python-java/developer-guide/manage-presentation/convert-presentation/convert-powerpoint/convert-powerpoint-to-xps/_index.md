---
title: Konvertera PowerPoint-presentationer till XPS i Python
linktitle: PowerPoint till XPS
type: docs
weight: 70
url: /sv/python-java/convert-powerpoint-to-xps/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera PPT
- konvertera PPTX
- PowerPoint till XPS
- presentation till XPS
- PPT till XPS
- PPTX till XPS
- spara PPT som XPS
- spara PPTX som XPS
- exportera PPT till XPS
- exportera PPTX till XPS
- Python
- Java
- Aspose.Slides
description: "Konvertera PowerPoint PPT- och PPTX-presentationer till XPS i Python med Aspose.Slides för Python via Java, med standard- eller anpassade exportinställningar."
---
## **Översikt**

Aspose.Slides för Python via Java låter dig konvertera PowerPoint‑presentationer till XPS genom att spara en PPT‑ eller PPTX‑fil i XPS‑format. Denna artikel förklarar när XPS kan vara användbart och visar hur du exporterar en presentation med antingen standardinställningar eller anpassade [XpsOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xpsoptions/) inställningar.

## **Om XPS**

XPS (XML Paper Specification) är ett XML‑baserat dokumentformat utvecklat av Microsoft. Det beskriver fasta sidor och bevarar layouten för text och grafik för visning och utskrift med kompatibel programvara.

## **När du bör använda Microsoft XPS‑format**

Använd XPS när ett dokumentflöde kräver fasta layoutfiler för delning eller utskrift via XPS‑kompatibla verktyg. Mottagarna behöver programvara som stöder XPS. Om ditt flöde kräver PDF istället, se [Convert PowerPoint to PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
För att prova konvertera en PPT‑ eller PPTX‑presentation till XPS, använd den [gratis onlinekonverteraren](https://products.aspose.app/slides/sv/conversion).
{{% /alert %}}

| Ingående PowerPoint‑presentation | Utgående XPS‑dokument |
| --- | --- |
| ![Original PowerPoint-presentation](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Presentation konverterad till XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **XPS‑konvertering med Aspose.Slides**

Använd metoden [save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) i klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) med [SaveFormat.Xps](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Xps) för att exportera en presentation. Du kan använda standardexportinställningarna eller ange [XpsOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xpsoptions/) för att anpassa resultatet.

Varje exempel nedan startar Java‑virtualmaskinen om det behövs och frigör presentationen efter användning. Ersätt filnamnet för indata med sökvägen till din PPT‑ eller PPTX‑fil.

### **Konvertera presentationer till XPS med standardinställningar**

Följande Python‑kod konverterar en presentation till XPS med standardinställningarna:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Spara presentationen som ett XPS-dokument.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Konvertera presentationer till XPS med anpassade inställningar**

Följande exempel använder [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) för att spara metafiler som PNG‑bilder i det resulterande XPS‑dokumentet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Spara presentationen med de anpassade XPS-inställningarna.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Kan jag spara XPS till en ström istället för en fil?**

Ja. Metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) har överlagringar som accepterar en Java‑utgångsström. Med Python via Java, använd en kompatibel Java‑ström via JPype, exempelvis en Java‑byte‑array‑utgångsström, för att behålla de exporterade data i minnet.

**Inkluderas dolda bilder i XPS‑utdata?**

Dolda bilder exkluderas som standard. För att inkludera dem, sätt [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) till `True` innan du sparar.

**Bevaras animationer och bildövergångar i XPS?**

Nej. XPS innehåller fasta sidor, så de exporterade bilderna spelar inte upp animationer eller övergångseffekter.