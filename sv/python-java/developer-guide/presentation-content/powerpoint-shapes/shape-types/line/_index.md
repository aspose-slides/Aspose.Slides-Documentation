---
title: Lägg till linjeformer i presentationer i Python via Java
linktitle: Linje
type: docs
weight: 50
url: /sv/python-java/line/
keywords:
- linje
- skapa linje
- lägg till linje
- enkel linje
- konfigurera linje
- anpassa linje
- streckstil
- pilspets
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig att manipulera linjeformatering i PowerPoint-presentationer med Aspose.Slides för Python via Java. Upptäck egenskaper, metoder och exempel."
---
## **Översikt**

Aspose.Slides gör det möjligt att lägga till linjeformer i PowerPoint-bilder programatiskt. Den här artikeln visar hur du skapar en enkel linje och hur du anpassar en linje så att den visas som en pil.

Du kommer att lära dig hur du lägger till en linjeform på en bild, justerar dess visuella utseende och sparar den uppdaterade presentationen. Exemplen fokuserar på praktiska inställningar för linjeformattering såsom stil, bredd, streckmönster, pilarhuvudalternativ och fyllningsfärg.

## **Skapa en vanlig linje**

För att lägga till en enkel linje på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑klassen.  
- Hämta en referens till en bild med dess index.  
- Lägg till en linjeform med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addAutoShape) i objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/).  
- Skriv den modifierade presentationen som en PPTX‑fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Skapa en instans av Presentation-klassen som representerar PPTX-filen.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en linjeform.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Skriv PPTX-filen till disk.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Skapa en pilformad linje**

Aspose.Slides för Python via Java låter också utvecklare konfigurera linjeegenskaper för att få en linje att se mer attraktiv ut. För att konfigurera en linje så att den ser ut som en pil, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑klassen.  
- Hämta en referens till en bild med dess index.  
- Lägg till en linjeform med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addAutoShape) i objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/).  
- Ange [linjestil](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linestyle/) till en av de stilar som erbjuds av Aspose.Slides för Python via Java.  
- Ange linjens bredd.  
- Ange [streckstil](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linedashstyle/) till en av de stilar som erbjuds av Aspose.Slides för Python via Java.  
- Ange [pilspetsstil](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linearrowheadstyle/) och [längd](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linearrowheadlength/) i början av linjen.  
- Ange [pilspetsstil](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linearrowheadstyle/) och [längd](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linearrowheadlength/) i slutet av linjen.  
- Skriv den modifierade presentationen som en PPTX‑fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Skapa en instans av Presentation-klassen som representerar PPTX-filen.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en linjeform.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Tillämpa formatering på linjen.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Skriv PPTX-filen till disk.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Kan jag konvertera en vanlig linje till en anslutning så att den ”snäpper” till former?**

Nej. En vanlig linje (en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) av typen [Line](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/)) blir inte automatiskt en anslutning. För att få den att snäppa till former, använd den dedikerade [Connector](https://reference.aspose.com/slides/sv/python-java/aspose.slides/connector/)‑typen och de [motsvarande API](/slides/sv/python-java/connector/) för anslutningar.

**Vad ska jag göra om en linjes egenskaper ärvs från temat och det är svårt att avgöra de slutgiltiga värdena?**

[Läs de effektiva egenskaperna](/slides/sv/python-java/shape-effective-properties/) för linjen och dess fyllning – dessa tar redan hänsyn till arv och temastilar.

**Kan jag låsa en linje så att den inte kan redigeras (flyttas, storleksändras)?**

Ja. Former tillhandahåller [låsta objekt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/#getAutoShapeLock) som låter dig [förbjuda redigeringsåtgärder](/slides/sv/python-java/applying-protection-to-presentation/).