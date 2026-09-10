---
title: Anpassa diagramförklaringar i presentationer med Python
linktitle: Diagramförklaring
type: docs
url: /sv/python-java/chart-legend/
keywords:
- diagramförklaring
- förklaringsposition
- teckenstorlek
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Anpassa diagramförklaringar med Aspose.Slides för Python via Java för att optimera PowerPoint-presentationer med skräddarsydd förklaringsformatering."
---
## **Översikt**

Aspose.Slides erbjuder alternativ för att anpassa diagramförklaringar i PowerPoint-presentationer. Denna artikel visar hur man positionerar och storlekar en förklaring, anger teckenstorleken för hela förklaringen och tillämpar formatering på ett enskilt förklaringsobjekt.

Den täcker även flera relaterade beteenden i vanliga frågor, inklusive att använda icke‑överlappningsläge så att diagramområdet ger plats åt förklaringen, tillåter långa förklaringsetiketter att radbrytas eller använda radbrytningar, och låter förklaringsformatering ärva från presentationens tema när explicita text‑ och fyllningsinställningar inte tillämpas.

## **Placering av förklaring**

För att ställa in förklaringsegenskaperna, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till bilden.
3. Lägg till ett diagram på bilden.
4. Ställ in förklaringsegenskaperna.
5. Spara presentationen som en PPTX‑fil.

Följande exempel anger position och storlek för en diagramförklaring.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Skapa en tom presentation.
presentation = Presentation()
try:
    # Hämta en referens till bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till ett klustrat kolumndiagram på bilden.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Ställ in förklaringsegenskaperna.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Spara presentationen till disk.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange teckenstorlek för en förklaring**

Aspose.Slides för Python via Java låter dig ange teckenstorleken för en förklaring. Följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Skapa standarddiagrammet.
3. Ange teckenstorleken.
4. Ange det minsta axelvärdet.
5. Ange det största axelvärdet.
6. Spara presentationen till disk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Skapa en tom presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange teckenstorlek för ett enskilt förklaringsobjekt**

Aspose.Slides för Python via Java låter dig ange teckenstorleken för enskilda förklaringsobjekt. Följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Skapa standarddiagrammet.
3. Kom åt ett förklaringsobjekt.
4. Ange teckenstorleken.
5. Spara presentationen till disk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Skapa en tom presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Kan jag aktivera förklaringen så att diagrammet automatiskt avsätter utrymme för den istället för att överlappa den?**

Ja. Använd [setOverlay](https://reference.aspose.com/slides/sv/python-java/aspose.slides/legend/#setOverlay) med `False` för att aktivera icke‑överlappningsläge; i så fall kommer diagramområdet att krympa för att rymma förklaringen.

**Kan jag skapa flerradiga förklaringsetiketter?**

Ja. Långa etiketter radbryts automatiskt när utrymmet är otillräckligt; tvingade radbrytningar stöds via nyradstecken i seriens namn.

**Hur får jag förklaringen att följa presentationens temafärgschema?**

Ange inte explicita färger, fyllningar eller teckensnitt för förklaringen eller dess text. De kommer då att ärva från temat och uppdateras korrekt när designen förändras.