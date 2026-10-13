---
title: Grafiekassen aanpassen in presentaties met Python
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
description: "Ontdek hoe u Aspose.Slides voor Python via .NET kunt gebruiken om grafiekassen aan te passen in PowerPoint- en OpenDocument-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe je diagramassen kunt aanpassen met Aspose.Slides voor Python via .NET. Het behandelt berekende aswaarden, het omwisselen van rijen en kolommen in diagrammen, zichtbaarheid van assen, intervallen voor categorie‑labels en tik‑markeringen, datumcategorieën en opmaak, rotatie van titels, positie van assen, weergave‑eenheden en logaritmische schaal.

## **Maximumwaarden op de verticale as van diagrammen ophalen**

Maak een [Presentatie](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en voeg een vlakdiagram toe met standaardgegevens. Roep [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) aan voordat je berekende aswaarden uitleest zodat de diagramlay‑out up‑to‑date is.

Lees [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) en [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) voor de asgrenzen, en [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) en [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) voor de tik‑intervallen. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) en [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) leveren tijd‑eenheidsschaal – relevant voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat het diagram op.

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

## **Gegevens tussen assen wisselen**

Gebruik [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) om de rollen van series en categorieën in diagramgegevens uit te wisselen. Elke voormalige categorie wordt een serie, en elke voormalige serie wordt een categorie. Dit verandert hoe de gegevens worden gegroepeerd; het verwisselt niet de horizontale en verticale assen. Het voorbeeld gebruikt [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) om de standaardgegevens te binden aan `Sheet1!A1:D5`, inclusief de koprij en categoriekolom, voordat rijen en kolommen worden omgewisseld. Het slaat een diagram op met vier series en drie categorieën.

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

## **Categorie‑as wijzigen**

Stel [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) in om een datum‑ of tekstcategorie‑as te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een diagram als eerste vorm op de eerste dia en categoriecellen die numerieke Excel‑datumnummers bevatten. Het wijzigt de horizontale as naar een datum‑as. Door [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) op `False` te zetten, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) op `1` en [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) op maanden, worden hoofd‑tikmarks geplaatst met een interval van één maand.

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

## **Intervallen voor categorie‑as‑labels regelen**

Wanneer een diagram veel categorieën bevat, kun je het aantal zichtbare as‑labels verminderen zonder categorieën of gegevenspunten te verwijderen. Zet [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) op `False` en stel vervolgens [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) in op het gewenste categorie‑interval. Voor tekstcategorieën in hun normale volgorde begint tellen bij de eerste categorie:

| Interval | Labels die in het voorbeeld worden weergegeven |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Een interval van `3` toont elk derde label, waarbij twee labels verborgen blijven tussen de weergegeven labels. Het verwijdert niet de corresponderende kolommen. Automatische spacing kiest een interval op basis van de beschikbare ruimte; het toont niet per se elk label.

Tik‑marks hebben afzonderlijke instellingen. Zet [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) op `False` en gebruik [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) om hun interval in te stellen. Bijvoorbeeld, `1` behoudt een tik‑mark op elk categorie‑interval terwijl labels slechts elke derde categorie verschijnen. Zet [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) op een zichtbare stijl zodat je het resultaat kunt zien. Beide automatische‑spacing‑eigenschappen weer op `True` laten het diagram dat interval opnieuw kiezen.

Het volgende zelf‑containende voorbeeld maakt 24 categorieën en één serie, slaat vervolgens drie dia’s op in `CategoryAxisIntervals.pptx`: automatische spacing, handmatige labelspacing met onafhankelijke tik‑marks, en herstelde automatische spacing. De twee kopieën behouden de oorspronkelijke diagramgegevens. Er is geen invoer‑presentatie nodig. Horizontale labeltekst maakt het verschil in dichtheid duidelijk zichtbaar.

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

    # Slide 2: toon elke derde label, maar behoud een tik-markering voor elke categorie.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Slide 3: laat het diagram beide intervallen opnieuw kiezen.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatische spacing (dia 1):** In deze weergave wordt elke tweede categorielabel getoond en wordt deze over twee regels verdeeld. Het automatische resultaat kan variëren met diagramgrootte, lettertypes en de renderer.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Handmatige spacing (dia 2):** Elke derde label wordt op één regel getoond, terwijl tik‑marks behouden blijven bij elk categorie‑interval. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische weergave die hierboven werd getoond.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Kies de juiste as en interval**

Gebruik dit categorie‑aantal‑interval voor een tekstcategorie‑as, zoals de categorie‑as van een kolom‑, lijn‑, vlak‑ of staafdiagram. In een kolomdiagram is dit de horizontale as. In een horizontale staafdiagram is de categorie‑as verticaal, dus pas deze instellingen toe op [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Tik‑mark‑spacing geldt ook voor een series‑as in diagrammen die die hebben.

Gebruik geen categorie‑labelspacing om de numerieke schaal van een waardenas in te stellen. Op een waardenas specificeert [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) een verschil in waarden: bijvoorbeeld, een hoofd‑eenheid van `10` levert tik‑marks op 0, 10, 20, … wanneer de as op nul begint. Een categorie‑labelinterval van `3` telt daarentegen categorie‑posities, ongeacht hun gegevenswaarden. Spreidings‑ en bubbel‑diagrammen gebruiken waardenassen in plaats van een tekstcategorie‑as. Voor een datum‑as gebruik je tijd‑gebaseerde hoofd‑eenheden en schalen zoals beschreven in [Categorie‑as wijzigen](#categorie‑as-wijzigen).

## **Datumopmaak voor categorie‑as‑waarden instellen**

Het voorbeeld vervangt de standaarddiagramgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`). Stel [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) in op een datum‑as, schakel [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) uit, en ken `yyyy` toe aan [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) zodat de categorie‑labels viercijferige jaartallen tonen, onafhankelijk van de celopmaak.

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

## **Rotatie‑hoek voor een as‑titel instellen**

Schakel [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) in op de verticale as, geef een titeltekst op, en stel [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) in om de titel te draaien. De hoek wordt in graden gemeten; dit voorbeeld slaat een kolomdiagram op met de waardenas‑titel geroteerd naar 90 graden.

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

## **As‑positie op een categorie‑ of waardenas instellen**

Gebruik [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) om te bepalen of de waardenas de categorie‑as kruist tussen categorieën of op categoriektik‑marks. Deze eigenschap geldt voor categorie‑assen. Het voorbeeld zet deze op `True` voor de horizontale categorie‑as van een kolomdiagram en slaat het resultaat op.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Weergave‑eenheid op een waardenas instellen**

Stel [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) in om de labels op een waardenas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) ingesteld op `MILLIONS` wordt een waarde van 60 000 000 weergegeven als 60. Het voorbeeld maakt een kolomdiagram en past de miljoenen‑weergave‑eenheid toe op de verticale as.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden verschillende grootheidsordes beslaan. Bijvoorbeeld, een dienst kan 10, 100, 1 000, 10 000 en 100 000 verzoeken ontvangen over vijf periodes. Op een lineaire schaal liggen de kleinere waarden dicht bij elkaar rond nul. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden staan voor gelijke verhoudingen in plaats van gelijke verschillen.

Stel [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) in op `True` voor de waardenas en gebruik [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) om de basis te kiezen. Dit wijzigt alleen hoe de bestaande waarden worden weergegeven; het verandert de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn is een apart kenmerk dat een aangepaste relatie in de data weergeeft.

### **Waarde‑as en basis kiezen**

Voor een lijn‑ of kolomdiagram is de waardenas [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Voor een horizontale staafdiagram is het [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Spreidings‑ en bubbel‑diagrammen hebben twee waardenassen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas logaritmische schaal niet toe op een categorie‑as.

De standaard logaritmische basis is `10`. Voor PPTX‑diagrammen kun je een basis kiezen van `2` tot en met `1000`, inclusief; breuk‑basissen zoals `2.5` worden eveneens ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1 000 en 10 000 evenredig verdeeld.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelf‑containende voorbeeld maakt een lijndiagram met de vijf verzoektellingen op de eerste dia, kloont die dia vervolgens en schakelt een logaritmische waardenas met basis 10 in op de tweede. Beide dia’s behouden dezelfde gegevens.

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

    # Behoud de eerste dia lineair en wijzig alleen de schaal van de waardenas van de kopie.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Lineaire schaal (dia 1):** Gelijke verticale afstanden staan voor gelijke verschillen in verzoektellingen. De grootste waarde domineert het diagram, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden staan voor gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, waardoor de punten een rechte stijgende lijn vormen op de basis‑10‑schaal. De as‑labels tonen nog steeds de oorspronkelijke verzoektellingen.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Nul‑ en negatieve waarden afhandelen**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat je deze inschakelt. Als nul‑ of negatieve waarden betekenis hebben, behoud dan een lineaire schaal of toon ze apart. Als het uitsluiten van die waarden passend is voor de analyse, leg dan de reden van weglating uit. Vervang ze niet stilletjes door kleine positieve getallen, want dat verandert de betekenis van de data. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet eveneens positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) om het kruis‑gedrag te selecteren. Om een numerieke kruis‑waarde op te geven, zet je [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Deze instellingen laten je de as‑kruising verplaatsen naar een geschikt referentieniveau.

**Hoe kan ik tick‑labels positioneren ten opzichte van de as?**

Stel [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) in met behulp van [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` of `NONE`. Om de tik‑marks zelf te regelen, gebruik je [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) of [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); deze staan los van de label‑positionering.