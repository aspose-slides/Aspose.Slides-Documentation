---
title: Grafiekassen aanpassen in presentaties met Python
linktitle: Grafiekas
type: docs
url: /nl/python-java/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as-eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as-titel
- aspositie
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor Python via Java kunt gebruiken om grafiekassen aan te passen in PowerPoint-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe je diagramassen kunt aanpassen met Aspose.Slides voor Python via Java. Het behandelt berekende aswaarden, het wisselen van rijen en kolommen in diagrammen, aszichtbaarheid, interval van categorielabels en tikkende markeringen, datumcategorieën en opmaak, titelrotatie, aspositionering, weergave‑eenheden en logaritmische schaling.

## **Maximumwaarden op de verticale as van een diagram ophalen**

Maak een [Presentatie](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) aan en voeg een vlakdiagram toe met standaardgegevens. Roep [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) aan voordat je berekende aswaarden uitleest, zodat de diagramlay-out up-to-date is.

Lees [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) en [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) voor de aslimieten, en [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) en [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) voor de tikintervalen. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) en [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) bieden tijdseenheidsschalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat het diagram op.

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

## **Gegevens tussen assen verwisselen**

Gebruik [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) om de rollen van reeksen en categorieën in diagramgegevens uit te wisselen. Elke voormalige categorie wordt een reeks, en elke voormalige reeks wordt een categorie. Dit verandert de groepering van de gegevens; het wisselt niet de horizontale en verticale assen uit. Het voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) om de standaardgegevens te koppelen aan `Sheet1!A1:D5`, inclusief de koprij en categoriekolom, voordat rijen en kolommen worden verwisseld. Het slaat een diagram op met vier reeksen en drie categorieën.

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

## **De plotvolgorde van een as omkeren**

Gebruik [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) om een categorie- of waardeas om te keren. Bijvoorbeeld, een horizontale staafdiagram kan projectfasen van boven naar beneden tonen in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as wijzigt de plotrichting; het sorteert of herschikt de werkboekgegevens niet. Ter vergelijking, [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) wisselt de rollen van reeksen en categorieën uit.

Het volgende voorbeeld maakt een horizontale staafdiagram met drie fasen en één reeks. Het slaat een presentatie op met drie dia's: gewone volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde dataset, en slechts één as wordt omgekeerd per kopie.

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

    # Slide 2: toon de eerste categorie bovenaan.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Beh houd de horizontale waardeas onderaan.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Slide 3: keer alleen de horizontale numerieke schaal om.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het omkeren van een as kan ook de loodrechte as naar de tegenovergestelde kant van de plot verplaatsen. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2, wanneer deze wordt aangeroepen met [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) op de omgekeerde categorieas, blijft de horizontale waardeas onderaan. Voor een specifiek kruispunt, gebruik [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Controleer de kruisst instellingen bij het wijzigen van de richting, vooral als het diagram al een aangepast kruispunt heeft. Roep [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) aan met `False` om de normale plotrichting te herstellen; kruisst instellingen zijn apart.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden stijgen van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en de rijvolgorde van het werkboek blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden stijgen van rechts naar links. De categorieas kruist bij nul aan de rechterkant. |

## **Verticale as uitschakelen voor lijndiagrammen**

Roep [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) aan met `False` op de verticale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de verticale as verborgen.

```python
import jpime
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

## **Horizontale as uitschakelen voor lijndiagrammen**

Roep [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) aan met `False` op de horizontale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de horizontale as verborgen.

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

## **Een categorieas wijzigen**

Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) om een datum- of tekstcategorieas te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een diagram als het eerste vormobject op de eerste dia en categoriecellen die numerieke Excel‑datumwaarden bevatten. Het wijzigt de horizontale as naar een datumas. Het aanroepen van [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) met `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) met `1`, en [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) met [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) plaatst de hoofd‑tikken op één‑maand‑intervalen.

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

## **Interval voor categorielabels op de as beheren**

Wanneer een diagram veel categorieën heeft, kun je het aantal zichtbare aslabels verminderen zonder categorieën of gegevenspunten te verwijderen. Roep [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) aan met `False`, en geef vervolgens het gewenste categorievlag aan [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Voor tekstcategorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | Labels die in het voorbeeld worden weergegeven |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, ... Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, ... Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, ... Categorie 22 |

Een interval van `3` geeft elk derde label weer, waarbij twee labels tussen de weergegeven labels verborgen blijven. Het verwijdert niet de bijbehorende kolommen. Automatische spatiëring kiest een interval op basis van de beschikbare ruimte; het toont niet per se elk label.

Tikkende markeringen hebben afzonderlijke besturingen. Roep [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) aan met `False` en gebruik [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) om hun interval in te stellen. Bijvoorbeeld, `1` behoudt een tikkende markering bij elk categorievlag terwijl labels slechts elke derde categorie verschijnen. Gebruik [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) met een zichtbaar stijl zodat je het resultaat kunt zien. Het opnieuw aanroepen van een automatische‑spatiëringssetter met `True` laat het diagram het interval opnieuw kiezen.

Het volgende zelfvoorzienende voorbeeld maakt 24 categorieën en één reeks, en slaat vervolgens drie dia's op in `CategoryAxisIntervals.pptx`: automatische spatiëring, handmatige labelspatiëring met onafhankelijke tikkende markeringen, en herstelde automatische spatiëring. De twee kopieën behouden de oorspronkelijke diagramgegevens. Er is geen invoerpresentatie vereist. Horizontale labeltekst maakt het verschil in dichtheid goed zichtbaar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

    # Slide 2: toon elk derde label, maar behoud een tikmarkering voor elke categorie.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Slide 3: laat het diagram beide intervallen opnieuw kiezen.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Automatische spatiëring (dia 1):** In deze weergave wordt elk tweede categorielabel weergegeven en op twee regels afgebroken. Het automatische resultaat kan variëren met de diagramgrootte, lettertypen en de renderer.

![Automatische categorielabelspatiëring met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige spatiëring (dia 2):** Elk derde label wordt op één regel weergegeven, terwijl tikkende markeringen behouden blijven bij elk categorievlag. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt het automatische uiterlijk dat hierboven wordt getoond.

![Handmatig categorielabelinterval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **Kies de juiste as en interval**

Gebruik dit aantal‑categorieën‑interval voor een tekstcategorieas, zoals de categorieas van een kolom-, lijn-, vlak‑ of staafdiagram. In een kolomdiagram is dit de horizontale as. In een horizontale staafdiagram is de categorieas verticaal, dus pas deze instellingen toe op de as die wordt geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). De spatiëring van tikkende markeringen geldt ook voor een reeksas in diagrammen die er een hebben.

Gebruik de spatiëring van categorielabels niet om de numerieke schaal van een waardeas in te stellen. Op een waardeas specificeert [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) een verschil in waarden: bijvoorbeeld, een hoofd‑eenheid van `10` produceert tikkende markeringen bij 0, 10, 20, enzovoort wanneer de as bij nul start. Een categorielabelinterval van `3` telt in plaats daarvan de categorieposities, ongeacht hun gegevenswaarden. Spreidings‑ en bubbel‑diagrammen gebruiken waardeassen in plaats van een tekstcategorieas. Voor een datumas gebruik je tijdgebaseerde hoofd‑eenheden en schalen zoals beschreven in [Een categorieas wijzigen](#change-a-category-axis).

## **Het datumformaat voor categorieaswaarden instellen**

Het voorbeeld vervangt de standaard diagramgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE Automation‑serialnummers in het eerste werkblad (index `0`), berekend als het aantal dagen sinds 30 december 1899 voor deze datums. Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) met [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), roep [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) aan met `False`, en geef `yyyy` door aan [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) zodat de categorielabels viercijferige jaren weergeven, onafhankelijk van de celopmaak.

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

## **Een rotatiehoek instellen voor een diagramas‑titel**

Roep [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) aan met `True` op de verticale as, geef de titeltekst op, en stel de rotatiehoek in de tekstopmaak van het titeltekstblok in. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomdiagram op met de titel van de waardeas geroteerd met 90 graden.

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

## **De aspositie instellen op een categorie‑ of waardeas**

Gebruik [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) om te bepalen of de waardeas de categorieas tussen categorieën of bij categorietikmarkeringen kruist. Deze instelling geldt voor categorieassen. Het voorbeeld stelt dit in op `True` op de horizontale categorieas van een kolomdiagram en slaat het resultaat op.

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

## **De weergave‑eenheid instellen op een diagramwaardeas**

Gebruik [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) om de labels op een waardeas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) ingesteld op `Millions` wordt een waarde van 60.000.000 weergegeven als 60. Het voorbeeld maakt een kolomdiagram en past de miljoenen‑weergave‑eenheid toe op de verticale as.

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

## **Een logaritmische waardeas configureren**

Een logaritmische waardeas is nuttig wanneer positieve waarden zich over meerdere grootordes uitstrekken. Bijvoorbeeld, een service kan 10, 100, 1.000, 10.000 en 100.000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal staan de kleinere waarden dicht bij elkaar rond nul. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden vertegenwoordigen gelijke verhoudingen in plaats van gelijke verschillen.

Roep [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) aan met `True` op de waardeas en gebruik [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) om de basis te kiezen. Dit verandert hoe de bestaande waarden worden weergegeven; het wijzigt de gegevens niet of voegt een logaritmische trendlijn toe. Een trendlijn vertegenwoordigt een aangepaste relatie in de gegevens en is een afzonderlijke functie.

### **Kies de waardeas en basis**

Voor een lijn‑ of kolomdiagram wordt de waardeas geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Voor een horizontale staafdiagram wordt deze geretourneerd door [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Spreidings‑ en bubbel‑diagrammen hebben twee waardeassen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorieas.

De standaard logaritmische basis is `10`. Voor PPTX‑diagrammen kun je een basis gebruiken van `2` tot en met `1000`, inclusief; fractionele basissen zoals `2,5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1.000 en 10.000 gelijkmatig verdeeld.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelfvoorzienende voorbeeld maakt een lijndiagram met de vijf aanvraagtelwoorden op de eerste dia, en kloont daarna die dia en schakelt een basis‑10 logaritmische waardeas in op de tweede. Beide dia's behouden dezelfde gegevens.

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

    # Houd de eerste dia lineair en wijzig alleen de schaal van de waardenas van de kopie.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Lineaire schaal (dia 1):** Gelijke verticale afstanden vertegenwoordigen gelijke verschillen in aanvraagtelwoorden. De grootste waarde domineert het diagram, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijndiagram in PowerPoint dat vijf aanvraagtelwoorden toont op een lineaire waardeas](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden vertegenwoordigen gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, dus de punten vormen een rechte stijgende lijn op de basis‑10 schaal. De aslabels blijven de oorspronkelijke aanvraagtelwoorden tonen.

![Dezelfde vijf aanvraagtelwoorden in PowerPoint op een basis‑10 logaritmische waardeas](value-axis-logarithmic.png)

### **Omgaan met nul‑ en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat je deze inschakelt. Als nul‑ of negatieve waarden betekenisvol zijn, behoud dan een lineaire schaal of toon ze afzonderlijk. Als het weglaten van die waarden passend is voor de analyse, leg dan de omissie uit. Vervang ze niet stilzwijgend door kleine positieve getallen, omdat dit de betekenis van de gegevens verandert. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet ook positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop de ene as de andere kruist (as kruising)?**

Gebruik [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) om het kruisk gedrag te selecteren. Om een numerieke kruisingswaarde op te geven, gebruik je [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Deze instellingen laten je de askruising naar een geschikte basislijn verplaatsen.

**Hoe kan ik tiklabels positioneren ten opzichte van de as?**

Roep [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) aan met [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tikmarkeringen zelf te regelen, gebruik je [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) of [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); deze staan los van de labelpositionering.