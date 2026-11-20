---
title: Diagramassen aanpassen in presentaties met Python
linktitle: Diagramas
type: docs
url: /nl/python-java/chart-axis/
keywords:
- diagramas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as‑eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as titel
- aspositie
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor Python via Java kunt gebruiken om diagramassen aan te passen in PowerPoint‑presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u diagramassen kunt aanpassen met Aspose.Slides voor Python via Java. Het behandelt berekende aswaarden, het verwisselen van rijen en kolommen in diagrammen, aszichtbaarheid, categorie‑label‑ en tick‑mark‑intervallen, datum‑categorieën en -opmaak, titelrotatie, aspositionering, weergave‑eenheden en logaritmische schaling.

## **Maximumwaarden op de verticale as van een diagram ophalen**

Maak een [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) aan en voeg een vlakdiagram toe met standaardgegevens. Roep [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) aan voordat u berekende aswaarden uitleest, zodat de diagramindeling up-to-date is.

Lees [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) en [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) uit voor de aslimieten, en [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) en [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) voor de tick‑intervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) en [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) leveren tijd‑eenheid‑schalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat het diagram op.

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

Gebruik [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) om de rollen van reeksen en categorieën in diagramgegevens uit te wisselen. Elke vorige categorie wordt een reeks, en elke vorige reeks wordt een categorie. Dit verandert de manier waarop de gegevens worden gegroepeerd; het wisselt niet de horizontale en verticale assen uit. Het voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) om de standaardgegevens te binden aan `Sheet1!A1:D5`, inclusief de koprij en categoriekolom, vóór het verwisselen van rijen en kolommen. Het slaat een diagram op met vier reeksen en drie categorieën.

```python
import jpide
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

## **De tekenvolgorde van een as omkeren**

Gebruik [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) om een categorie‑ of waardeas om te keren. Bijvoorbeeld, een horizontale staafgrafiek kan projectfasen van boven naar beneden tonen in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as verandert de tekenrichting; het sorteert of herschikt de werkboek‑gegevens niet. Ter vergelijking verwisselt [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) de rollen van reeksen en categorieën.

Het volgende voorbeeld maakt een horizontale staafgrafiek met drie fasen en één reeks. Het slaat een presentatie op met drie dia’s: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde dataset, en op elke kopie wordt slechts één as omgekeerd.

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

    # Dia 2: toon de eerste categorie bovenaan.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Houd de horizontale waardenas onderaan.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Dia 3: keer alleen de horizontale numerieke schaal om.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het omkeren van een as kan ook de loodrechte as naar de tegenoverliggende kant van het diagram verplaatsen. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 wordt dit aangeroepen met [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) op de omgekeerde categorieas, waardoor de horizontale waardeas onderaan blijft. Voor een specifiek kruispunt gebruikt u [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Controleer de kruisinstellingen bij het wijzigen van de richting, vooral als het diagram al een aangepast kruispunt heeft. Roep [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) met `False` aan om de normale tekenrichting te herstellen; kruisinstellingen zijn onafhankelijk.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontale staafgrafiek met normale categorie‑ en waardeasvolgorde](axis-order-normal.png) | ![Horizontale staafgrafiek met categorieën weergegeven van boven naar beneden](axis-order-categories-reversed.png) | ![Horizontale staafgrafiek met een omgekeerde waardeas en nul aan de rechterkant](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden nemen toe van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en de rijvolgorde in de werkmap blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden nemen toe van rechts naar links. De categorieas kruist bij nul aan de rechterkant. |

## **De verticale as voor lijndiagrammen uitschakelen**

Roep [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) aan met `False` op de verticale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de verticale as verborgen.

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

## **De horizontale as voor lijndiagrammen uitschakelen**

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

## **Diagramrasterlijnen tonen of verbergen**

Roep [getShowMajorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMajorGridLines) en [getShowMinorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMinorGridLines) aan om te controleren welke rasterlijnen een as weergeeft. Om kleine rasterlijnen te tonen, gebruikt u [getMinorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMinorGridLinesFormat) en stelt u de lijnvulling in op een solide, zichtbare kleur. Om ze te verbergen, stelt u de vulling in op [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/#NoFill). Gebruik [getMajorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMajorGridLinesFormat) om de lijnvulling voor grote rasterlijnen op dezelfde manier aan te passen. Het wijzigen van de vulling behoudt de zichtbaarheid van de as en de tick‑markeringen.

De verticale as van dit gegroepeerde kolomdiagram toont aanvankelijk alleen grote rasterlijnen. Het voorbeeld toont de kleine rasterlijnen in donker‑oranje, verbergt ze vervolgens opnieuw en slaat de presentatie op. Het drukt de rasterlijn‑zichtbaarheid bij elke stap af.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230)
    axis = chart.getAxes().getVerticalAxis()
    print(f"Initial: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    minor_fill = axis.getMinorGridLinesFormat().getLine().getFillFormat()
    minor_fill.setFillType(FillType.Solid)
    minor_fill.getSolidFillColor().setColor(Color(255, 140, 0))
    print(f"Enabled: minor={axis.getShowMinorGridLines()}")

    minor_fill.setFillType(FillType.NoFill)
    print(f"Hidden: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Kleine rasterlijnen ingeschakeld | Kleine rasterlijnen verborgen |
| --- | --- |
| ![Oranje kleine rasterlijnen tussen de grote rasterlijnen op de verticale as](minor-gridlines-enabled.png) | ![Hetzelfde kolomdiagram met alleen grote rasterlijnen zichtbaar](minor-gridlines-hidden.png) |

## **Een categorieas wijzigen**

Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) om een datum‑ of tekst‑categorieas te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een diagram als de eerste vorm op de eerste dia en categoriecellen die numerieke Excel‑datumnummers bevatten. Het verandert de horizontale as in een datumas. Het aanroepen van [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) met `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) met `1` en [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) met [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) plaatst de grote ticks op een‑maand‑intervallen.

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

### **Het type categorieas bepalen op basis van gegevens**

Roep [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisTypeAutomatically) aan nadat u de categorieën hebt gevuld, en lees vervolgens [getCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getCategoryAxisType) om de selectie te inspecteren. Dit is handig wanneer hetzelfde diagram ofwel tekstlabels ofwel numerieke datums ontvangt. De methode bepaalt het type bij het aanroepen; hij zet geen persistente modus aan die latere gegevenswijzigingen opnieuw evalueert. Roep hem opnieuw aan nadat u de categorieën hebt vervangen.

Het volgende voorbeeld maakt een diagram met tekstcategorieën en drukt `True` af wanneer het geselecteerde type [CategoryAxisType.Text](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Text) is. Vervolgens vervangt het de categoriecellen door datums en roept de methode opnieuw aan, waarbij `True` wordt afgedrukt wanneer het geselecteerde type [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) is. Datums worden opgeslagen als numerieke OLE‑Automation‑waarden, berekend als het aantal dagen sinds 30 december 1899, in plaats van datum‑strings. [setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) bepaalt hoe die waarden worden weergegeven; hij converteert geen tekst naar numerieke datums. Voor meer informatie over categoriecellen, zie [Chart Workbook](/slides/nl/python-java/chart-workbook/).

Gebruik automatische bepaling wanneer de invoer bekend is om tekst‑categorieën of numerieke datums te bevatten, zoals in dit voorbeeld. Voor gewone numerieke labels, gemengde categorieën of lege gegevens, roep expliciet [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) aan om het beoogde type te matchen. Alleen numerieke waarden bepalen niet dat de categorieën datum­representaties zijn.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CategoryAxisType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series_name = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.getCell(0, i + 1, 0, label)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Text)  # Waar

    base_date = date(1899, 12, 30)
    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.getCell(0, i + 1, 0)
        category_cell.setValue(float((category_date - base_date).days))
        category_cell.setCustomNumberFormat("yyyy-mm-dd")

    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Date)  # Waar

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Het interval van categorie‑aslabels beheren**

Wanneer een diagram veel categorieën heeft, kunt u het aantal zichtbare as‑labels verminderen zonder categorieën of gegevenspunten te verwijderen. Roep [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) aan met `False`, en geef vervolgens het gewenste categorie‑interval door aan [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Voor tekstcategorieën in hun normale volgorde start de telling bij de eerste categorie:

| Interval | Labels die in het voorbeeld worden getoond |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, … Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, … Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, … Categorie 22 |

Een interval van `3` toont elk derde label, waardoor twee labels verborgen blijven tussen de weergegeven labels. Het verwijdert niet de overeenkomstige kolommen. Automatische spatiëring kiest een interval op basis van de beschikbare ruimte; het toont niet noodzakelijk elk label.

Tick‑markeringen hebben aparte besturingselementen. Roep [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) aan met `False` en gebruik [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) om hun interval in te stellen. Bijvoorbeeld, `1` houdt een tick‑markering bij elk categorie‑interval terwijl labels alleen elke derde categorie verschijnen. Gebruik [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) met een zichtbaar stijl zodat u het resultaat kunt zien. Het opnieuw instellen van de automatische‑spacing‑setter met `True` laat het diagram het interval opnieuw kiezen.

Het volgende zelf‑standige voorbeeld maakt 24 categorieën en één reeks, en slaat drie dia’s op in `CategoryAxisIntervals.pptx`: automatische spatiëring, handmatige labelspatiëring met onafhankelijke tick‑markeringen, en herstelde automatische spatiëring. De twee kopieën behouden de oorspronkelijke diagramgegevens. Er is geen invoer‑presentatie vereist. De horizontale labeltekst maakt het verschil in dichtheid duidelijk zichtbaar.

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

    # Dia 2: toon elk derde label, maar behoud een tick-markering voor elke categorie.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Dia 3: laat het diagram beide intervallen opnieuw kiezen.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Automatische spatiëring (dia 1):** In deze weergave wordt elk tweede categorie‑label getoond en wordt het op twee regels afgebroken. Het automatische resultaat kan variëren afhankelijk van diagramgrootte, lettertypen en de renderer.

![Automatische categorie‑labelspatiëring met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige spatiëring (dia 2):** Elk derde label wordt op één regel getoond, terwijl tick‑markeringen behouden blijven bij elk categorie‑interval. Alle 24 kolommen, inclusief die zonder label, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt het automatische uiterlijk dat hierboven is getoond.

![Handmatig labelinterval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **De juiste as en interval kiezen**

Gebruik dit categorie‑telling‑interval voor een tekst‑categorieas, zoals de categorieas van een kolom-, lijn‑, vlak‑ of staafdiagram. In een kolomdiagram is dit de horizontale as. In een horizontale staafgrafiek is de categorieas verticaal, dus pas deze instellingen toe op de as die wordt geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Tick‑mark‑spatiëring geldt ook voor een reeks‑as in diagrammen die er één hebben.

Gebruik geen labelspatiëring om de numerieke schaal van een waardenas in te stellen. Op een waardenas bepaalt [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) een verschil in waarden: bijvoorbeeld, een grote eenheid van `10` produceert ticks bij 0, 10, 20, enzovoort wanneer de as bij nul begint. Een categorie‑labelinterval van `3` telt daarentegen posities van categorieën, ongeacht hun data‑waarden. Spreidings‑ en bubbel‑diagrammen gebruiken waardenasen in plaats van een tekst‑categorieas. Voor een datumas gebruikt u tijd‑gebaseerde grote eenheden en schalen zoals beschreven in [Een categorieas wijzigen](#een-categorieas-wijzigen).

## **Datumnotatie voor categorieaswaarden instellen**

Het voorbeeld vervangt de standaard diagramdata door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`), berekend als het aantal dagen sinds 30 december 1899 voor deze datums. Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) met [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), roep [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) aan met `False`, en geef `yyyy` door aan [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) zodat de categorie‑labels viercijferige jaren tonen, onafhankelijk van de celopmaak.

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

## **Rotatiehoek voor een diagramas‑titel instellen**

Roep [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) aan met `True` op de verticale as, geef titeltekst op, en stel de rotatiehoek in de tekstblok‑opmaak van de titel in. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomdiagram op met de titel van de waardenas geroteerd met 90 graden.

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

## **Aspositie op een categorie‑ of waardenas instellen**

Gebruik [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) om te bepalen of de waardenas de categorieas tussen de categorieën of op categorie‑tick‑marks kruist. Deze instelling geldt voor categorie‑assen. Het voorbeeld stelt dit in op `True` op de horizontale categorieas van een kolomdiagram en slaat het resultaat op.

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

## **Weergave‑eenheid op een waardenas van een diagram instellen**

Gebruik [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) om de labels op een waardenas te schalen zonder de onderliggende data te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) ingesteld op `Millions` wordt een waarde van 60 000 000 weergegeven als 60. Het voorbeeld maakt een kolomdiagram en past de miljoenen‑weergave‑eenheid toe op de verticale as.

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

## **Een logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden meerdere bestellingsmachten bevatten. Bijvoorbeeld, een service kan 10, 100, 1 000, 10 000 en 100 000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal verschijnen de kleinere waarden dicht bij nul. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden vertegenwoordigen gelijke verhoudingen in plaats van gelijke verschillen.

Roep [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) aan met `True` op de waardenas en gebruik [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) om de basis te kiezen. Dit verandert hoe de bestaande waarden worden weergegeven; het wijzigt de data niet en voegt geen logaritmische trendlijn toe. Een trendlijn vertegenwoordigt een aangepaste relatie in de data en is een apart kenmerk.

### **De waardenas en basis kiezen**

Voor een lijn‑ of kolomdiagram wordt de waardenas geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Voor een horizontale staafgrafiek wordt deze geretourneerd door [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Spreidings‑ en bubbel‑diagrammen hebben twee waardenasen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorieas.

De standaard‑logaritmische basis is `10`. Voor PPTX‑diagrammen mag de basis liggen tussen `2` en `1000`, inclusief; gebroken bases zoals `2.5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1 000 en 10 000 even verdeeld.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelf‑standige voorbeeld maakt een lijndiagram met de vijf aanvraag‑aantallen op dia 1, dupliceert vervolgens die dia en schakelt een base‑10 logaritmische waardenas in op dia 2. Beide dia’s behouden dezelfde data.

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

**Lineaire schaal (dia 1):** Gelijke verticale afstanden vertegenwoordigen gelijke verschillen in aanvraag‑aantallen. De grootste waarde domineert het diagram, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijndiagram in PowerPoint dat vijf aanvraag‑aantallen toont op een lineaire waardenas](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden vertegenwoordigen gelijke verhoudingen. Elke periode heeft tien keer zoveel aanvragen als de vorige, waardoor de punten een rechte stijgende lijn vormen op de base‑10 schaal. De as‑labels blijven de originele aanvraag‑aantallen weergeven.

![Dezelfde vijf aanvraag‑aantallen in PowerPoint op een base‑10 logaritmische waardenas](value-axis-logarithmic.png)

### **Nul‑ en negatieve waarden afhandelen**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de data vóór het inschakelen. Als nul‑ of negatieve waarden betekenisvol zijn, houd dan een lineaire schaal of toon ze apart. Als het uitsluiten van die waarden passend is voor de analyse, leg dan de omissie uit. Vervang ze niet stilletjes door kleine positieve getallen, want dat verandert de betekenis van de data. Elke handmatig geconfigureerde minimum‑ of maximum‑waarde voor een logaritmische as moet eveneens positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) om het kruisk gedrag te selecteren. Om een numerieke kruis‑waarde op te geven, gebruikt u [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Deze instellingen laten u de as‑kruising naar een geschikt basislijn verplaatsen.

**Hoe kan ik tick‑labels positioneren ten opzichte van de as?**

Roep [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) aan met [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tick‑markeringen zelf te besturen, gebruikt u [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) of [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); deze zijn los van de labelpositionering.