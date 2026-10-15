---
title: Assen van diagrammen aanpassen in presentaties met Python
linktitle: Grafiekas
type: docs
url: /nl/python-net/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as titel
- aspositie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor Python via .NET kunt gebruiken om grafiekassen aan te passen in PowerPoint- en OpenDocument-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u de assen van diagrammen kunt aanpassen met Aspose.Slides voor Python via .NET. Het behandelt berekende aswaarden, het wisselen van rijen en kolommen in een diagram, zichtbaarheid van assen, intervallen voor categorielabels en tikmarkeringen, datumcategorieën en -opmaak, rotatie van de titel, positie van de as, weergave‑eenheden en logaritmische schaal.

## **De maximale waarden op de verticale as ophalen in diagrammen**

Maak een [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) aan en voeg een gebiedsdiagram toe met standaardgegevens. Roep [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) aan voordat u berekende aswaarden uitleest, zodat de diagramindeling up-to-date is.

Lees [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) en [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) voor de aslimieten, en [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) en [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) voor de tik‑intervallen. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) en [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) bieden tijdseenheidsschaal, wat relevant is voor datumassen. Het voorbeeld slaat deze waarden op in locale variabelen en slaat het diagram op.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gegevens tussen assen uitwisselen**

Gebruik [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) om de rollen van reeksen en categorieën in de diagramgegevens om te wisselen. Elke voormalige categorie wordt een reeks, en elke voormalige reeks wordt een categorie. Dit verandert hoe de gegevens gegroepeerd zijn; het wisselt niet de horizontale en verticale assen uit. Het voorbeeld gebruikt [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) om de standaardgegevens te binden aan `Sheet1!A1:D5`, inclusief de koprij en categoriekolom, vóór het wisselen van rijen en kolommen. Het slaat een diagram op met vier reeksen en drie categorieën.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Volgorde van tekenen van een as omkeren**

Gebruik [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) om een categorie‑ of waardas om te keren. Bijvoorbeeld, een horizontale staafdiagram kan projectfasen van boven naar beneden tonen in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as verandert de tekenrichting; het sorteert of herschikt de werkboekgegevens niet. Ter vergelijking wisselt [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) de rollen van reeksen en categorieën.

Het volgende voorbeeld maakt een horizontale staafdiagram met drie fasen en één reeks. Het slaat een presentie op met drie dia’s: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde dataset, en slechts één as wordt per kopie omgekeerd.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Dia 2: toon de eerste categorie bovenaan.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Houd de horizontale waardas onderaan.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Dia 3: keer alleen de horizontale numerieke schaal om.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Het omkeren van een as kan de loodrechte as ook naar de tegenoverliggende kant van het diagram verplaatsen. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 houdt de instelling op `MAXIMUM` op de omgekeerde categorias de horizontale waardas onderaan. Voor een specifiek kruispunt, gebruik [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Controleer de kruisinginstellingen bij het wijzigen van de richting, zeker als het diagram al een aangepast kruispunt heeft. Zet `is_plot_order_reversed` terug naar `False` om de normale tekenrichting te herstellen; kruisinginstellingen zijn afzonderlijk.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontale staafdiagram met normale volgorde van categorie- en waardas](axis-order-normal.png) | ![Horizontale staafdiagram met categorieën weergegeven van boven naar beneden](axis-order-categories-reversed.png) | ![Horizontale staafdiagram met een omgekeerde waardas en nul aan de rechterkant](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden stijgen van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en de rijvolgorde van het werkboek blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden stijgen van rechts naar links. De categorieas kruist bij nul aan de rechterkant. |

## **Verticale as uitschakelen voor lijndiagrammen**

Stel [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) in op `False` voor de verticale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de verticale as verborgen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Horizontale as uitschakelen voor lijndiagrammen**

Stel [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) in op `False` voor de horizontale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de horizontale as verborgen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Een categorieas wijzigen**

Stel [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) in om een datum‑ of tekst‑categorieas te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een diagram als het eerste object op de eerste dia en categoriecellen die numerieke Excel‑datumnummers bevatten. Het verandert de horizontale as in een datumas. Instellen van [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) op `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) op `1` en [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) op maanden plaatst hoofd‑tikstippen op een‑maandintervallen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Interval voor categorieas‑labels beheren**

Wanneer een diagram veel categorieën heeft, kunt u het aantal zichtbare as‑labels verminderen zonder categorieën of datapunten te verwijderen. Stel [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) in op `False`, en stel vervolgens [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) in op het gewenste categorie‑interval. Voor tekstcategorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | Weergegeven labels in het voorbeeld |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, ... Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, ... Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, ... Categorie 22 |

Een interval van `3` toont elke derde label, met twee verborgen labels tussen de getoonde. Het verwijdert niet de bijbehorende kolommen. Automatische spatiëring kiest een interval op basis van de beschikbare ruimte; het toont niet per se elk label.

Tik‑markeringen hebben aparte instellingen. Stel [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) in op `False` en gebruik [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) om hun interval te bepalen. Bijvoorbeeld, `1` houdt een tikstreep bij elk categorie‑interval terwijl labels alleen elke derde categorie verschijnen. Stel [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) in op een zichtbaar type zodat u het resultaat kunt zien. Het terugzetten van een automatische‑spatiëringseigenschap naar `True` laat het diagram dat interval opnieuw kiezen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Dia 2: toon elk derde label, maar behoud een tikstreep voor elke categorie.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Dia 3: laat het diagram beide intervallen opnieuw kiezen.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatische spatiëring (dia 1):** In deze weergave wordt elke tweede categorielabel getoond en worden ze op twee regels afgebroken. Het automatische resultaat kan variëren met diagramgrootte, lettertypen en de renderer.

![Automatische categorie‑labelspatiëring met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige spatiëring (dia 2):** Elke derde label wordt op één regel getoond, terwijl tik‑markeringen behouden blijven bij elk categorie‑interval. Alle 24 kolommen, inclusief die zonder label, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische weergave zoals hierboven getoond.

![Handmatig categorie‑labelinterval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **Kies de juiste as en interval**

Gebruik dit categorie‑aantal‑interval voor een tekst‑categorieas, zoals de categorieas van een kolom‑, lijn‑, gebieds‑ of staafdiagram. In een kolomdiagram is dit de horizontale as. In een horizontale staafdiagram is de categorieas verticaal, dus pas deze instellingen toe op [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Tik‑markering‑spatiëring geldt ook voor een seriële as in diagrammen die er een hebben.

Gebruik geen categorie‑labelspatiëring om de numerieke schaal van een waardas in te stellen. Op een waardas bepaalt [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) een waardedifferentie: bijvoorbeeld, een hoofd‑eenheid van `10` geeft tikken bij 0, 10, 20, enzovoort wanneer de as bij nul start. Een categorie‑labelinterval van `3` telt in plaats daarvan categorieposities, ongeacht hun waardes. Spreidings‑ en bubbel‑diagrammen gebruiken waardassen in plaats van een tekst‑categorieas. Voor een datumas gebruikt u tijd‑gebaseerde hoofd‑eenheden en schalen zoals beschreven in [Een categorieas wijzigen](#een-categorieas-wijzigen).

## **Datumformaat voor categorieas‑waarden instellen**

Het voorbeeld vervangt de standaard diagramgegevens door vier jaarlijkse waarden. Data worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`). Stel [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) in op een datumas, schakel [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) uit, en ken `yyyy` toe aan [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) zodat de categorie‑labels viercijferige jaartallen weergeven, onafhankelijk van de celopmaak.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Rotatiehoek voor een diagramas‑titel instellen**

Schakel [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) in op de verticale as, voorzie de titel van tekst, en stel [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) in om de titel te draaien. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomdiagram op met zijn waardas‑titel gedraaid met 90 graden.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Positie van de as op een categorie‑ of waardas instellen**

Gebruik [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) om te bepalen of de waardas de categorieas kruist tussen categorieën of op de tik‑markeringen van de categorie. Deze eigenschap geldt voor categorieassen. Het voorbeeld stelt dit in op `True` voor de horizontale categorieas van een kolomdiagram en slaat het resultaat op.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Weergave‑eenheid op een waardas van een diagram instellen**

Stel [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) in om de labels op een waardas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) ingesteld op `MILLIONS` wordt een waarde van 60 000 000 weergegeven als 60. Het voorbeeld maakt een kolomdiagram en past de miljoenen‑weergave‑eenheid toe op de verticale as.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Logaritmische waardas configureren**

Een logaritmische waardas is nuttig wanneer positieve waarden zich over meerdere ordes van grootte uitstrekken. Bijvoorbeeld, een service kan 10, 100, 1 000, 10 000 en 100 000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal verschijnen de kleinere waarden dicht bij nul. Een logaritmische schaal maakt hun relatieve groei makkelijker vergelijkbaar: gelijke afstanden staan voor gelijke verhoudingen in plaats van gelijke verschillen.

Stel [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) in op `True` voor de waardas en gebruik [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) om de basis te kiezen. Dit verandert hoe de bestaande waarden worden weergegeven; het wijzigt de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn is een afzonderlijke functie die een aangepaste relatie in de data representeert.

### **Kies de waardas en basis**

Voor een lijn‑ of kolomdiagram is de waardas [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Voor een horizontale staafdiagram is het [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Spreidings‑ en bubbel‑diagrammen hebben twee waardassen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorieas.

De standaard logaritmische basis is `10`. Voor PPTX‑diagrammen kunt u een basis gebruiken van `2` tot en met `1000`, inclusief; fractionele bases zoals `2.5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1 000 en 10 000 gelijkmatig gespreid.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelf‑standaard voorbeeld maakt een lijndiagram met de vijf aanvraagcijfers op de eerste dia, kloont vervolgens die dia en activeert een logaritmische waardas met basis 10 op de tweede. Beide dia’s behouden dezelfde data.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Houd de eerste dia lineair en wijzig alleen de schaal van de waardas van de kopie.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Lineaire schaal (dia 1):** Gelijke verticale afstanden staan voor gelijke verschillen in het aantal aanvragen. De grootste waarde domineert het diagram, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijndiagram in PowerPoint dat vijf aanvraagcijfers toont op een lineaire waardas](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden staan voor gelijke verhoudingen. Elke periode heeft tien keer zoveel aanvragen als de vorige, waardoor de punten een rechte stijgende lijn vormen op de basis‑10‑schaal. De as‑labels blijven de oorspronkelijke aanvraagcijfers tonen.

![Dezelfde vijf aanvraagcijfers in PowerPoint op een logaritmische waardas met basis 10](value-axis-logarithmic.png)

### **Omgaan met nul- en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de data voordat u deze inschakelt. Als nul‑ of negatieve waarden betekenisvol zijn, behoud dan een lineaire schaal of toon ze apart. Indien het weglaten van die waarden passend is voor de analyse, leg dan de reden uit. Vervang ze niet stilletjes door kleine positieve getallen, want dat wijzigt de betekenis van de data. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet ook positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop de ene as de andere kruist (as‑kruising)?**

Gebruik [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) om het kruismaatschapp gedrag te selecteren. Om een numerieke kruiswaarde op te geven, stel [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) in. Deze instellingen laten u de as‑kruising naar een geschikte basislijn verplaatsen.

**Hoe kan ik tik‑labels positioneren ten opzichte van de as?**

Stel [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) in met behulp van [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` of `NONE`. Om de tik‑markeringen zelf te regelen, gebruik [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) of [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); deze staan los van de label‑positionering.