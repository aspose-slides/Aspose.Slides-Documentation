---
title: Anpassa diagramaxlar i presentationer med Python
linktitle: Diagramaxel
type: docs
url: /sv/python-java/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelegenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axelrubrik
- axelposition
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för Python via Java för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Denna artikel förklarar hur man anpassar diagramaxlar med Aspose.Slides för Python via Java. Den täcker beräknade axelvärden, byte av diagramrader och -kolumner, axelns synlighet, intervall för kategorietiketter och tick-markeringar, datumkategorier och formatering, titelrotation, axelpositionering, visningsenheter och logaritmisk skalning.

## **Hämta de maximala värdena på diagrammets vertikala axel**

Skapa en [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) och lägg till ett ytdiagram med standarddata. Anropa [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) innan beräknade axelvärden läses så att diagramlayouten är uppdaterad.

Läs [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) och [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) för axelgränserna, och [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) och [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) för tick‑intervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) och [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) ger tidsenhetsskalar, vilket är relevant för datumaxlar. Exemplet sparar dessa värden i lokala variabler och sparar diagrammet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Byt data mellan axlar**

Använd [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) för att byta rollerna för serier och kategorier i diagramdata. Varje tidigare kategori blir en serie, och varje tidigare serie blir en kategori. Detta förändrar hur data grupperas; det byter inte de horisontella och vertikala axlarna. Exemplet använder [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) för att binda standarddata till `Sheet1!A1:D5`, inklusive rubrikraden och kategorikolumnen, innan rader och kolumner byts. Det sparar ett diagram med fyra serier och tre kategorier.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vänd plotningsordningen för en axel**

Använd [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) för att vända en kategori‑ eller värdeaxel. Till exempel kan ett horisontellt stapeldiagram visa projektfaser från topp till botten i samma ordning som kalkylbladet: Planering, Utveckling, Testning. Att vända en axel ändrar plottningsriktningen; den sorterar eller omarrangerar inte data i arbetsboken. Till jämförelse byter [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) rollerna för serier och kategorier.

Följande exempel skapar ett horisontellt stapeldiagram med tre faser och en serie. Det sparar en presentation med tre bilder: normal ordning, omvända kategorier och omvända värden. Varje kopia använder samma dataset, och endast en axel är omvänd i varje kopia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Bild 2: visa den första kategorin högst upp.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Behåll den horisontella värdeaxeln längst ner.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Bild 3: vänd endast den horisontella numeriska skalan.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Att vända en axel kan också flytta den vinkelräta axeln till motsatt sida av diagrammet. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) styr var den andra axeln korsar den axel som konfigureras. På bild 2 anropas den med [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) på den omvända kategori‑axeln så att den horisontella värdeaxeln hålls längst ner. För en specifik korsningspunkt, använd [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Kontrollera korsningsinställningarna när du ändrar riktning, särskilt om diagrammet redan har en anpassad korsningspunkt. Anropa [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) med `False` för att återställa normal plottningsriktning; korsningsinställningarna är separata.

| Normal ordning (bild 1) | Omvända kategorier (bild 2) | Omvända värden (bild 3) |
| --- | --- | --- |
| ![Horisontellt stapeldiagram med normal kategori- och värdeaxelordning](axis-order-normal.png) | ![Horisontellt stapeldiagram med kategorier visade från toppen till botten](axis-order-categories-reversed.png) | ![Horisontellt stapeldiagram med omvänd värdeaxel och noll på höger sida](axis-order-values-reversed.png) |
| Kategorier löper från botten till toppen; värden ökar från vänster till höger. | Planering, Utveckling och Testning löper från toppen till botten. Värden och arbetsbokens radordning förblir oförändrade. | Kategorier behåller sin normala ordning; värden ökar från höger till vänster. Kategorielaxeln korsar vid noll på höger sida. |

## **Inaktivera den vertikala axeln för linjediagram**

Anropa [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) med `False` på den vertikala axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den vertikala axeln dold.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Inaktivera den horisontella axeln för linjediagram**

Anropa [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) med `False` på den horisontella axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den horisontella axeln dold.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ändra en kategoriaxel**

Använd [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) för att välja en datum‑ eller textkategori‑axel. Detta exempel kräver `ExistingChart.pptx`, med ett diagram som den första formen på den första bilden och kategori‑celler som innehåller numeriska Excel‑datumvärden. Det ändrar den horisontella axeln till en datumaxel. Anropa [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) med `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) med `1` och [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) med [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) för att placera huvudtickar på en‑månadsintervall.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Styr intervallen för kategoriaxelns etiketter**

När ett diagram har många kategorier, minska antalet synliga axel‑etiketter utan att ta bort kategorier eller datapunkter. Anropa [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) med `False`, och skicka sedan önskat kategoriintervall till [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). För textkategorier i deras normala ordning börjar räknandet vid den första kategorin:

| Intervall | Etiketter som visas i exemplet |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

Ett intervall på `3` visar var tredje etikett och lämnar två etiketter dolda mellan de visade. Det tar inte bort motsvarande kolumner. Automatisk spacing väljer ett intervall baserat på tillgängligt utrymme; den visar inte nödvändigtvis varje etikett.

Tick‑markeringar har separata kontroller. Anropa [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) med `False` och använd [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) för att sätta deras intervall. Till exempel, `1` behåller en tick‑markering vid varje kategoriintervall medan etiketter bara visas var tredje kategori. Använd [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) med en synlig stil så att du kan se resultatet. Att återigen sätta någon av de automatiska inställningarna till `True` låter diagrammet välja intervallet på nytt.

Följande självständiga exempel skapar 24 kategorier och en serie, och sparar tre bilder i `CategoryAxisIntervals.pptx`: automatisk spacing, manuell etikett‑spacing med oberoende tick‑markeringar, och återställd automatisk spacing. De två kopiorna behåller den ursprungliga diagramdatan. Ingen inmatningspresentation krävs. Horisontell etikett‑text gör skillnaden i densitet lätt att se.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # Bild 2: visa var tredje etikett, men behåll en tick-markering för varje kategori.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Bild 3: låt diagrammet välja båda intervallen igen.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Automatisk avstånd (bild 1):** I denna rendering visas varje andra kategorietikett och radbryts på två rader. Det automatiska resultatet kan variera med diagramstorlek, teckensnitt och renderare.

![Automatisk kategorietikettspridning med alla 24 kolumner synliga](category-axis-automatic.png)

**Manuell avstånd (bild 2):** Varje tredje etikett visas på en rad, medan tick‑markeringar förblir vid varje kategoriintervall. Alla 24 kolumner, inklusive de utan etiketter, förblir synliga med samma värden. Bild 3 återställer den automatiska utseendet som visas ovan.

![Manuellt kategorietikettintervall på tre med alla 24 kolumner synliga](category-axis-manual.png)

### **Välj rätt axel och intervall**

Använd detta kategori‑räknekortsintervall för en text‑kategori‑axel, såsom kategori‑axeln i ett stapel‑, linje‑, area‑ eller stapeldiagram. I ett stapeldiagram är den den horisontella axeln. I ett horisontellt stapeldiagram är kategori‑axeln vertikal, så tillämpa dessa inställningar på axeln som returneras av [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Tick‑spacering gäller även för en serie‑axel i diagram som har en sådan.

Använd inte kategori‑etikett‑spacing för att sätta den numeriska skalan på en värde‑axel. På en värde‑axel specificerar [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) en skillnad i värden: t.ex. ger en huvudenhet på `10` tick‑markeringar vid 0, 10, 20 osv när axeln startar vid noll. Ett kategori‑etikett‑intervall på `3` räknar istället kategori‑positioner, oavsett deras datavärden. Spridnings‑ och bubblediagram använder värde‑axlar snarare än en text‑kategori‑axel. För en datum‑axel, använd tidsbaserade huvud‑enheter och skalor som beskrivs i [Ändra en kategoriaxel](#ändra-en-kategoriaxel).

## **Ställ in datumformat för kategoriaxelvärden**

Exemplet ersätter standarddiagramdata med fyra årsvärden. Datum lagras som OLE‑Automation‑serienummer i första kalkylbladet (index `0`), beräknat som antal dagar sedan 30 december 1899 för dessa datum. Använd [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) med [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), anropa [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) med `False` och skicka `yyyy` till [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) så att kategori‑etiketterna visar fyrsiffriga år oberoende av cellformateringen.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in en rotationsvinkel för en diagramaxelrubrik**

Anropa [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) med `True` på den vertikala axeln, ange rubriktext och ställ in rotationsvinkeln i rubrikens textblock‑formatering. Vinkeln mäts i grader; detta exempel sparar ett stapeldiagram med sin värde‑axelrubrik roterad 90 grader.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in axelpositionen på en kategori- eller värdeaxel**

Använd [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) för att styra om värde‑axeln korsar kategori‑axeln mellan kategorier eller vid kategori‑tick‑markeringar. Denna inställning gäller kategori‑axlar. Exemplet sätter den till `True` på den horisontella kategori‑axeln i ett stapeldiagram och sparar resultatet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in visningsenheten på en diagramvärdeaxel**

Använd [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) för att skala etiketterna på en värde‑axel utan att ändra underliggande data. Med [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) satt till `Millions` visas ett värde på 60 000 000 som 60. Exemplet skapar ett stapeldiagram och tillämpar miljoner‑visningsenheten på dess vertikala axel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Konfigurera en logaritmisk värdeaxel**

En logaritmisk värdeaxel är användbar när positiva värden spänner över flera storleksordningar. Till exempel kan en tjänst ta emot 10, 100, 1 000, 10 000 och 100 000 förfrågningar över fem perioder. På en linjär skala hamnar de mindre värdena nära varandra nära noll. En logaritmisk skala gör deras relativa tillväxt enklare att jämföra: lika avstånd representerar lika förhållanden snarare än lika skillnader.

Anropa [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) med `True` på värde‑axeln och använd [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) för att välja basen. Detta förändrar hur befintliga värden visas; det ändrar inte data eller lägger till en logaritmisk trendlinje. En trendlinje representerar ett anpassat förhållande i data och är en separat funktion.

### **Välj värdeaxeln och basen**

För ett linje‑ eller stapeldiagram returneras värde‑axeln av [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). För ett horisontellt stapeldiagram returneras den av [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Spridnings‑ och bubblediagram har två värde‑axlar, så välj den horisontella axeln för X‑värden, den vertikala för Y‑värden eller båda. Applicera inte logaritmisk skalning på en kategori‑axel.

Standard‑logaritmbasen är `10`. För PPTX‑diagram, använd en bas från `2` till `1000`, inklusivt; bråkiga baser såsom `2.5` stöds också. Med bas `10` är successiva potenser som 10, 100, 1 000 och 10 000 lika avståndade.

### **Jämför linjär och logaritmisk skalning**

Följande självständiga exempel skapar ett linjediagram med de fem förfrågningsantalena på den första bilden, klonar sedan den bilden och aktiverar en bas‑10 logaritmisk värde‑axel på den andra. Båda bilderna behåller samma data.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Behåll den första bilden linjär och ändra endast kopians värdeaxelskala.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Linjär skala (bild 1):** Lika vertikala avstånd representerar lika skillnader i förfrågningsantal. Det största värdet dominerar diagrammet, vilket gör de mindre värdena svåra att urskilja.

![Linjediagram i PowerPoint som visar fem begärantal på en linjär värdeaxel](value-axis-linear.png)

**Logaritmisk skala (bild 2):** Lika vertikala avstånd representerar lika förhållanden. Varje period har tio gånger så många förfrågningar som den föregående, så punkterna bildar en rak stigande linje på bas‑10‑skalan. Axel‑etiketterna visar fortfarande de ursprungliga förfrågningsantalena.

![Samma fem begärantal i PowerPoint på en logaritmisk värdeaxel med bas 10](value-axis-logarithmic.png)

### **Hantera noll och negativa värden**

En logaritmisk skala kan endast visa strikt positiva värden. Kontrollera data innan du aktiverar den. Om noll eller negativa värden är meningsfulla, behåll en linjär skala eller visa dem separat. Om uteslutning av dessa värden är lämplig för analysen, förklara borttagandet. Ersätt dem inte tyst med små positiva tal, eftersom detta ändrar data­meningen. Eventuella manuellt konfigurerade min‑ eller max‑värden för en logaritmisk axel måste också vara positiva.

## **Vanliga frågor**

**Hur anger jag värdet där en axel korsar den andra (axelkorsning)?**

Använd [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) för att välja korsningsbeteende. För att specificera ett numeriskt korsningsvärde, använd [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Dessa inställningar låter dig flytta korsningen till en lämplig baslinje.

**Hur kan jag placera tick‑etiketter relativt till axeln?**

Anropa [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) med [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` eller `None`. För att styra själva tick‑markeringarna, använd [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) eller [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); dessa är separata från etikett‑positionering.