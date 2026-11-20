---
title: Diagramassen aanpassen in presentaties met Python
linktitle: Diagramas
type: docs
url: /nl/python-net/chart-axis/
keywords:
- diagramas
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
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor Python via .NET kunt gebruiken om diagramassen aan te passen in PowerPoint- en OpenDocument-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u de assen van diagrammen kunt aanpassen met Aspose.Slides voor Python via .NET. Het behandelt berekende aswaarden, het wisselen van rijen en kolommen in diagrammen, aszichtbaarheid, categorie‑etiketten‑ en tick‑intervallen, datum‑categorieën en opmaak, rotatie van titels, aspositionering, weergave‑eenheden en logaritmische schaling.

## **Maximale waarden op de verticale as van diagrammen ophalen**

Maak een [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) aan en voeg een gebiedsdiagram toe met standaardgegevens. Roep [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) aan voordat u berekende aswaarden leest, zodat de diagramlay-out up‑to‑date is.

Lees [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) en [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) voor de aslimieten, en [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) en [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) voor de tick‑intervallen. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) en [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) geven tijd‑eenheidschalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat het diagram op.

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

Gebruik [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) om de rollen van reeksen en categorieën in diagramgegevens om te wisselen. Elke voormalige categorie wordt een reeks, en elke voormalige reeks wordt een categorie. Dit verandert hoe de gegevens worden gegroepeerd; het wisselt niet de horizontale en verticale assen. Het voorbeeld gebruikt [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) om de standaardgegevens te koppelen aan `Sheet1!A1:D5`, inclusief de koprij en categorie‑kolom, voordat rijen en kolommen worden gewisseld. Het slaat een diagram op met vier reeksen en drie categorieën.

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

## **Volgorde van plotten van een as omkeren**

Gebruik [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) om een categorie‑ of waardenas om te keren. Bijvoorbeeld, een horizontaal staafdiagram kan projectfasen van boven naar beneden weergeven in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as verandert de plot­richting; het sorteert of herschikt de werkboek‑gegevens niet. Ter vergelijking wisselt [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) de rollen van reeksen en categorieën.

Het volgende voorbeeld maakt een horizontaal staafdiagram met drie fasen en één reeks. Het slaat een presentatie op met drie dia’s: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde dataset, en op elke kopie wordt slechts één as omgekeerd.

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

    # Dia 2: de eerste categorie bovenaan weergeven.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Houd de horizontale waardenas onderaan.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Dia 3: alleen de horizontale numerieke schaal omkeren.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Het omkeren van een as kan ook de loodrechte as naar de andere kant van het diagram verplaatsen. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 wordt deze ingesteld op `MAXIMUM` op de omgekeerde categorie‑as, waardoor de horizontale waardenas onderaan blijft. Voor een specifiek kruispunt gebruik je [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Controleer de kruisinginstellingen bij het wijzigen van de richting, vooral als het diagram al een aangepast kruispunt heeft. Stel `is_plot_order_reversed` terug in op `False` om de normale plot­richting te herstellen; kruisinginstellingen zijn gescheiden.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontaal staafdiagram met normale categorie‑ en waardenas volgorde](axis-order-normal.png) | ![Horizontaal staafdiagram met categorieën weergegeven van boven naar beneden](axis-order-categories-reversed.png) | ![Horizontaal staafdiagram met een omgekeerde waardenas en nul aan de rechterkant](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden nemen toe van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en werkboek‑rijvolgorde blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden nemen toe van rechts naar links. De categorie‑as kruist bij nul aan de rechterkant. |

## **De verticale as uitschakelen voor lijndiagrammen**

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

## **De horizontale as uitschakelen voor lijndiagrammen**

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

## **Rasterlijnen van diagrammen weergeven of verbergen**

Lees [show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) en [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) om te controleren welke rasterlijnen een as weergeeft. Beide eigenschappen zijn alleen‑lezen. Om minder belangrijke rasterlijnen weer te geven, stel je de lijnvulling in [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) in op een effen vulling en kies je een zichtbare kleur. Om ze te verbergen, stel je het vultype in op `FillType.NO_FILL`. Voor hoofd‑rasterlijnen gebruik je [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format`. Het wijzigen van de vulling behoudt de as‑zichtbaarheid en tick‑marks.

De verticale as van dit gegroepeerde kolomdiagram begint met hoofd‑rasterlijnen zichtbaar en minder belangrijke rasterlijnen verborgen. Het voorbeeld toont de minder belangrijke rasterlijnen in oranje, waarna deze weer worden verborgen voordat de presentatie wordt opgeslagen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| Minder belangrijke rasterlijnen ingeschakeld | Minder belangrijke rasterlijnen verborgen |
| --- | --- |
| ![Oranje minder belangrijke rasterlijnen tussen de hoofd‑rasterlijnen op de verticale as](minor-gridlines-enabled.png) | ![Hetzelfde kolomdiagram met alleen hoofd‑rasterlijnen zichtbaar](minor-gridlines-hidden.png) |

## **Een categorie‑as wijzigen**

Stel [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) in om een datum‑ of tekst‑categorie‑as te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een diagram als het eerste object op de eerste dia en categorie‑cellen die numerieke Excel‑datumnummers bevatten. Het wijzigt de horizontale as naar een datum‑as. Door [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) op `False` te zetten, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) op `1`, en [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) op maanden, worden grote tick‑marks geplaatst met tussenpozen van één maand.

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

### **Het type categorie‑as bepalen vanuit de gegevens**

Roep [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/) aan na het vullen van de categorieën, en lees vervolgens [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) om de selectie te inspecteren. Dit is handig wanneer hetzelfde diagram ofwel tekst‑labels ofwel numerieke datumwaarden krijgt. De methode bepaalt het type op het moment van aanroep; hij activeert geen permanente modus die later gegevenswijzigingen opnieuw evalueert. Roep hem opnieuw aan na het vervangen van de categorieën.

Het volgende voorbeeld maakt een diagram met tekst‑categorieën en drukt `TEXT` af. Vervolgens vervangt het de categorie‑celwaarden door datums en roept de methode opnieuw aan, waardoor `DATE` wordt afgedrukt. Datums worden opgeslagen als numerieke OLE‑Automation‑waarden, hier berekend als het aantal dagen sinds 30 december 1899, in plaats van datum‑strings. [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) bepaalt hoe die waarden worden weergegeven; hij converteert geen tekst naar numerieke datums. Voor meer over categorie‑cellen, zie [Chart Workbook](/slides/nl/python-net/chart-workbook/).

Gebruik automatische bepaling wanneer bekend is dat de invoer tekst‑categorieën of numerieke datums bevat, zoals in dit voorbeeld. Voor gewone numerieke labels, gecombineerde categorieën of lege gegevens, stel expliciet [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) in op de gewenste betekenis. Alleen numerieke waarden bewijzen niet dat de categorieën datum­representaties zijn.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # TEKST

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # DATUM

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Intervallen van categorie‑as‑etiketten regelen**

Wanneer een diagram veel categorieën bevat, kunt u het aantal zichtbare as‑etiketten verminderen zonder categorieën of datapunten te verwijderen. Stel [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) in op `False`, en zet vervolgens [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) op het gewenste categorie‑interval. Voor tekst‑categorieën in hun normale volgorde start de telling bij de eerste categorie:

| Interval | Labels die in het voorbeeld worden weergegeven |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, … Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, … Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, … Categorie 22 |

Een interval van `3` toont elk derde label, waarbij twee labels verborgen blijven tussen de weergegeven labels. Het verwijdert de overeenkomstige kolommen niet. Automatische spatiëring kiest een interval op basis van de beschikbare ruimte; hij toont niet noodzakelijk elk label.

Tick‑marks hebben aparte instellingen. Stel [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) in op `False` en gebruik [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) om hun interval te bepalen. Bijvoorbeeld, `1` houdt een tick‑mark bij elk categorie‑interval terwijl de labels slechts om de derde categorie verschijnen. Stel [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) in op een zichtbaar teken om het resultaat te zien. Het terugzetten van beide automatische‑spacing‑eigenschappen naar `True` laat het diagram het interval opnieuw kiezen.

Het volgende zelf‑standende voorbeeld maakt 24 categorieën en één reeks, en slaat drie dia’s op in `CategoryAxisIntervals.pptx`: automatische spatiëring, handmatige labelspatiëring met onafhankelijke tick‑marks, en herstelde automatische spatiëring. De twee kopieën behouden de oorspronkelijke diagramgegevens. Er is geen invoerpresentatie nodig. Horizontale labeltekst maakt het verschil in dichtheid duidelijk zichtbaar.

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

    # Dia 2: elke derde label weergeven, maar een tick-mark behouden voor elke categorie.
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

**Automatische spatiëring (dia 1):** In deze weergave wordt elk tweede categorie‑label weergegeven en wordt het op twee regels afgebroken. Het automatische resultaat kan variëren afhankelijk van diagramgrootte, lettertypen en de renderer.

![Automatische categorie‑etiket‑spatiëring met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige spatiëring (dia 2):** Elk derde label wordt op één regel weergegeven, terwijl tick‑marks behouden blijven bij elk categorie‑interval. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische weergave zoals hierboven weergegeven.

![Handmatige categorie‑etiket‑interval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **De juiste as en het juiste interval kiezen**

Gebruik dit categorie‑aantal‑interval voor een tekst‑categorie‑as, zoals de categorie‑as van een kolom‑, lijn‑, gebied‑ of staafdiagram. In een kolomdiagram is dit de horizontale as. In een horizontaal staafdiagram is de categorie‑as verticaal, dus pas deze instellingen toe op [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Tick‑mark‑spatiëring is ook van toepassing op een reeks‑as in diagrammen die er één hebben.

Gebruik geen categorie‑etiket‑spatiëring om de numerieke schaal van een waardenas te bepalen. Op een waardenas bepaalt [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) een waardeverschil: bijvoorbeeld, een grote eenheid van `10` levert ticks op 0, 10, 20, enz. wanneer de as bij nul start. Een categorie‑etiket‑interval van `3` telt echter categorie‑posities, ongeacht hun gegevenswaarden. Spreidings‑ en bubbel‑diagrammen gebruiken waardenasen in plaats van een tekst‑categorie‑as. Voor een datum‑as gebruikt u tijd‑gebaseerde grote eenheden en schalen zoals beschreven in [Een categorie‑as wijzigen](#een-categorie-as-wijzigen).

## **Datumopmaak voor categorie‑as‑waarden instellen**

Het voorbeeld vervangt de standaarddiagramgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`). Stel [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) in op een datum‑as, schakel [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) uit, en wijs `yyyy` toe aan [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) zodat de categorie‑labels viercijferige jaren tonen, onafhankelijk van de celopmaak.

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

Activeer [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) op de verticale as, geef titeltekst op, en stel [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) in om de titel te roteren. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomdiagram op met de waardenas‑titel geroteerd met 90 graden.

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

## **De as‑positie op een categorie‑ of waardenas instellen**

Gebruik [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) om te bepalen of de waardenas de categorie‑as tussen de categorieën of op de tick‑marks kruist. Deze eigenschap is van toepassing op categorie‑assen. Het voorbeeld zet deze op `True` op de horizontale categorie‑as van een kolomdiagram en slaat het resultaat op.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Weergave‑eenheid op een diagramwaardenas instellen**

Stel [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) in om de labels op een waardenas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) ingesteld op `MILLIONS`, wordt een waarde van 60 000 000 weergegeven als 60. Het voorbeeld maakt een kolomdiagram en past de miljoenen‑weergave‑eenheid toe op de verticale as.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Een logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden meerdere orders van grootte beslaan. Bijvoorbeeld, een dienst kan 10, 100, 1 000, 10 000 en 100 000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal lijken de kleinere waarden dicht bij nul bijeen. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden staan voor gelijke verhoudingen in plaats van gelijke verschillen.

Stel [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) in op `True` op de waardenas en gebruik [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) om de basis te kiezen. Dit wijzigt alleen hoe de bestaande waarden worden weergegeven; het verandert de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn is een aparte functionaliteit die een passende relatie in de gegevens modelleert.

### **De waardenas en de basis kiezen**

Voor een lijn‑ of kolomdiagram is de waardenas [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Voor een horizontaal staafdiagram is het [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Spreidings‑ en bubbel‑diagrammen hebben twee waardenasen, dus kies je de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaling toe op een categorie‑as.

De standaard logaritmische basis is `10`. Voor PPTX‑diagrammen mag de basis liggen tussen `2` en `1000`, inclusief; fractionele bases zoals `2.5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1 000 en 10 000 gelijkmatig gespreid.

### **Lineaire en logaritmische schaling vergelijken**

Het volgende zelf‑standende voorbeeld maakt een lijndiagram met de vijf verzoek‑aantallen op de eerste dia, dupliceert die dia en schakelt een base‑10 logaritmische waardenas in op de tweede. Beide dia’s behouden dezelfde gegevens.

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

    # Houd de eerste dia lineair en wijzig alleen de schaal van de waardenas in de kopie.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Lineaire schaal (dia 1):** Gelijke verticale afstanden staan voor gelijke verschillen in verzoek‑aantallen. De grootste waarde domineert het diagram, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijndiagram in PowerPoint met vijf verzoek‑aantallen op een lineaire waardenas](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden staan voor gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, waardoor de punten een rechte stijgende lijn vormen op de base‑10 schaal. De as‑labels tonen nog steeds de oorspronkelijke verzoek‑aantallen.

![Dezelfde vijf verzoek‑aantallen in PowerPoint op een base‑10 logaritmische waardenas](value-axis-logarithmic.png)

### **Omgaan met nul‑ en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat u deze activeert. Als nul‑ of negatieve waarden betekenisvol zijn, behoud dan een lineaire schaal of toon ze apart. Als het weglaten van die waarden passend is voor de analyse, leg dan de reden uit. Vervang ze niet stilzwijgend door kleine positieve getallen, want dat verandert de betekenis van de gegevens. Elke handmatig ingestelde minimum‑ of maximumwaarde voor een logaritmische as moet eveneens positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) om het kruispuntgedrag te kiezen. Om een numerieke kruispuntwaarde op te geven, stel je [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) in. Deze instellingen laten u de as‑kruising naar een geschikte basislijn verplaatsen.

**Hoe kan ik tick‑labels ten opzichte van de as positioneren?**

Stel [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) in met [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` of `NONE`. Om de tick‑marks zelf te regelen, gebruik je [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) of [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); deze staan los van de label‑positionering.