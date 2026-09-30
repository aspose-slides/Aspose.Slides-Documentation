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

Aspose.Slides for Python via Java tillhandahåller alternativ för att anpassa diagramförklaringar i PowerPoint-presentationer. Denna artikel visar hur man positionerar och storlekar en förklaring, ställer in teckenstorleken för hela förklaringen, formaterar ett enskilt förklaringspost och döljer eller återställer utvalda poster.

FAQ:n täcker relaterade beteenden, inklusive att reservera utrymme för förklaringen, visa flerradiga etiketter och ärva formatering från presentationens tema.

## **Placering av förklaring**

Använd förklaringens [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) och [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) metoder för att ange dess position och storlek som bråkdelar av diagrammets dimensioner.

Detta exempel skapar en presentation och lägger till ett grupperat stapeldiagram med standarddata på den första bilden. Genom att dividera önskade förklaringsförskjutningar och dimensioner med diagrammets bredd och höjd omvandlas de till relativa värden: förklaringen förskjuts 50 punkter från diagrammets övre vänstra hörn och storleksätts till 100 × 100 punkter.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Uttryck förklaringens position och storlek relativt diagrammet.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in teckenstorlek för en förklaring**

Använd förklaringens [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) för att komma åt dess textformatering och använd [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) för att ange teckenstorleken i punkter.

Detta exempel skapar ett diagram med standarddata och ställer in förklaringstexten till 20 punkter. Det inaktiverar också automatiska gränser för den vertikala axeln och sätter dess intervall till -5 till 10.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in teckenstorlek för en enskild förklaringspost**

Använd samlingen som returneras av förklaringens [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) metod för att komma åt formatering för ett specifikt inlägg. Postindex är nollbaserade, så index `1` avser den andra posten.

Detta exempel skapar ett grupperat stapeldiagram vars standarddata innehåller minst två serier. Det formaterar den andra förklaringsposten med fet, kursiv och 20‑punkts blå text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dölj enskilda förklaringsposter**

För att utesluta en hjälpserie från förklaringen samtidigt som dess data förblir synlig, anropa [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) med `True` via [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). Detta döljer endast den valda förklaringsposten; den tar inte bort serien eller dess datapunkter. Att anropa [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) med `False` döljer däremot hela förklaringen.

Exemplet nedan skapar ett grupperat stapeldiagram med flera serier med standarddata. Det döljer den andra seriens förklaringspost (index `1`) och sparar presentationen. Det återställer sedan posten genom att anropa [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) med `False` och sparar en andra kopia. Kolumnerna förblir synliga i båda filerna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Återställ samma post utan att ändra diagramdata.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jämförelsen nedan visar samma diagram med alla poster synliga och med den andra posten dold. Den andra seriens kolumner förblir oförändrade.

![Jämförelse av ett diagram med alla förklaringsposter synliga och med Serie 2 dold i förklaringen; alla kolumner förblir synliga.](hide-legend-entry.png)

I stapel-, stång- och linjediagram identifierar förklaringsposter serier. I pajdiagram identifierar de enskilda datapunkter (bitar), så använd [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) på den valda biten istället. API:et dokumenterar denna datapunktmetod för diagramtyperna `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` och `BarOfPie`. Anta inte att den gäller för munkdiagram, som inte ingår i den listan.

## **FAQ**

**Kan jag få diagrammet att reservera utrymme för förklaringen istället för att överlagra den?**  
Ja. Anropa [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) med `False` för att reservera utrymme för förklaringen istället för att låta den överlappa plotområdet.

**Kan jag skapa flerradiga förklaringsetiketter?**  
Ja. Långa etiketter kan radbrytas när den tillgängliga bredden är otillräcklig. Du kan också använda nyradstecken i serienamn för att begära radbrytningar.

**Hur får jag förklaringen att följa presentationens temafärgschema?**  
Lämna förklaringens färger, fyllningar och teckensnitt oinställda så att den kan ärva temats formatering. Explicit formatering åsidosätter motsvarande temainställningar.