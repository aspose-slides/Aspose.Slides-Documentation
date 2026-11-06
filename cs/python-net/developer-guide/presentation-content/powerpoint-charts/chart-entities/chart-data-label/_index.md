---
title: Správa popisků dat v grafech v prezentacích pomocí Pythonu
linktitle: Popisek dat
type: docs
url: /cs/python-net/chart-data-label/
keywords:
- graf
- popisek dat
- přesnost dat
- procento
- vzdálenost popisku
- umístění popisku
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se přidávat a formátovat popisky dat v grafech v PowerPoint prezentacích pomocí Aspose.Slides pro Python přes .NET a vytvořte tak poutavější snímky."
---
## **Úvod**

Popisky dat zobrazují informace o řadách grafu a jednotlivých datových bodech, pomáhají čtenářům identifikovat hodnoty a pochopit graf. Tento článek vysvětluje, jak formátovat hodnoty, zobrazovat procenta, číst text popisku, řídit popisky mimo maximum osy, upravit rozestupy popisků na kategorické ose a umístit popisky výsečových grafů.

## **Spočítat viditelné popisky dat**

Použijte [count_of_visible_data_labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/count_of_visible_data_labels/) ke zjištění, kolik popisků dat je povoleno zobrazit před publikací prezentace. Na rozdíl od `len(labels)`, který vrací celkový počet popisků v kolekci, bere v úvahu výchozí nastavení řady i individuální nastavení popisků.

Tento příklad vytváří sloupcový graf s jednou řadou a třemi datovými body. Přistupuje ke kolekci [labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/labels/) řady a vypisuje počet viditelných popisků při změně nastavení: **0, 3, 2, 3**. Celkový počet zůstává **3**.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    series_cell = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_cell, chart.type)

    for i in range(3):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    labels = series.labels
    print(f"Total: {len(labels)}; visible: {labels.count_of_visible_data_labels}")  # Celkem: 3; viditelné: 0

    labels.default_data_label_format.show_value = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # Viditelné: 3

    labels[1].data_label_format.show_value = False
    print(f"Visible: {labels.count_of_visible_data_labels}")  # Viditelné: 2

    labels[1].data_label_format.show_legend_key = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # Viditelné: 3
```

[default_data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/default_data_label_format/) řady poskytuje výchozí nastavení. Povolení [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) zde zobrazuje hodnoty pro všechny tři popisky. Nastavením na `False` přes [data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/data_label_format/) konkrétního popisku přepíše toto nastavení pro vybraný popisek. Povolení [show_legend_key](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_legend_key/) způsobí, že se popisek opět počítá jako viditelný, i když jeho hodnota zůstane skryta.

Viditelný počet odráží nastavení viditelnosti. Neměří, zda se popisky překrývají, jsou oříznuty nebo čitelné v renderovaném grafu.

## **Nastavit přesnost čísel v popiscích dat grafu**

Použijte [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) k formátování hodnot řady. Tento příklad vytvoří čárový graf s výchozími daty, zobrazí jeho datovou tabulku a povolí popisky hodnot pro první řadu. Formát `#,##0.00` zobrazuje oddělovač tisíců a dvě desetinná místa, aniž by změnil podkladové hodnoty.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

Pro formátování číselných buněk v vložené sešitu grafu viz [Set Custom Number Formats for Workbook Cells](/slides/cs/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells). Ten příklad také ukazuje popisky hodnot, které následují formáty zdrojových buněk, přičemž zachovávají uložené číselné hodnoty.

## **Zobrazit procenta jako popisky**

U sloupcového grafu se stohováním vypočítejte každou hodnotu jako procento z celkového součtu kategorie a přiřaďte text do [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Tento příklad používá výchozí data grafu a zobrazuje procenta se dvěma desetinnými místy v písmenové velikosti 8 bodů. Kategorie s nulovým součtem jsou přeskočeny, aby se zabránilo dělení nulou. Přepočítejte vlastní text popisku, pokud se data grafu změní.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit znak procenta v popiscích dat grafu**

Když jsou hodnoty uloženy jako zlomky, použijte [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) k zobrazení procent. Nastavte [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) na `False`, aby se formát popisku aplikoval nezávisle na zdrojových buňkách.

Tento příklad vytvoří 100 % sloupcový graf se stohováním s červenou a modrou řadou ve čtyřech kategoriích. Každý pár hodnot sečte na 1. Formát popisku `0.0%` zobrazí 0.30 jako 30.0 %, zatímco vertikální osa používá dvě desetinná místa. Obě řady mají bílý popisek velikosti 10 bodů.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Načíst skutečný text popisků dat**

Použijte [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) k získání textu vytvořeného nastavením popisku dat. To je užitečné při extrahování popisků pro zprávy, prohledávání obsahu prezentace nebo ověřování generovaných grafů. V níže uvedeném příkladu výchozí [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) kombinuje název kategorie, název řady a hodnotu. Jeden bod formátuje svou hodnotu jako procento a další používá vlastní text z [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

Číslo uložené v datovém bodě zůstává `0.75`, i když jeho popisek zobrazuje `75 %` spolu s názvy kategorie a řady. Vlastní text nahradí vygenerovaný text popisku. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) vrací výsledný řetězec popisku v obou případech. Zkontrolujte [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) samostatně, jak je ukázáno výše, když chcete extrahovat jen viditelné popisky.

## **Řídit popisky dat mimo maximum osy**

Když ručně omezíte rozsah osy, některé datové body mohou překročit její maximum. Použijte [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) k určení, zda se mají jejich popisky zobrazit. Toto nastavení mění viditelnost popisků; nemění rozsah osy ani podkladové datové hodnoty.

Níže uvedený příklad vytvoří 2D seskupený sloupcový graf s hodnotami 60 a 120. Nastaví [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) na `False` a [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) na 100 na vertikální ose. První snímek umožňuje popisky nad maximem; kopie tohoto snímku je zakáže. Oba snímky jsou uloženy v `DataLabelsOverMaximum.pptx`.

Povolte popisky hodnot pomocí [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Nastavení na úrovni grafu nepovolí zobrazení hodnot samo o sobě ani nepřepíše zakázané zobrazení hodnot u individuálního popisku. Tento příklad povoluje hodnoty pro celou řadu a používá [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) k umístění popisků na vnější konec každého sloupce.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

Následující obrázky ukazují uložené snímky renderované v Microsoft PowerPoint. S `True` je popisek **120** viditelný na horní hranici; s `False` je skrytý. Popisek **60** zůstává viditelný, maximum osy zůstává **100** a druhý datový bod zůstává **120** v obou případech.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

Tento příklad používá 2D sloupcový graf s hodnotovou osou. Grafy bez hodnotové osy, například výsečové a prstencové grafy, nemají maximum osy, které by bylo možné takto omezit.

{{% /alert %}}

## **Nastavit vzdálenost popisku od osy**

Použijte [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) k řízení vzdálenosti mezi popisky kategoriální osy a samotnou osou. Hodnota představuje procento maximální velikosti písma popisků osy. Tento příklad vytvoří seskupený sloupcový graf a nastaví odsazení popisků horizontální osy na 500. Toto nastavení postihuje popisky kategoriální osy, nikoli popisky připojené k jednotlivým datovým bodům.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Upravit umístění popisku**

U výsečového grafu upravte polohu popisků dat, abyste zlepšili rozestupy a vytvořili prostor pro vodící čáry.

Tento příklad zobrazuje hodnotu prvního datového bodu, umístí jeho popisek mimo výseč a upraví jeho [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) a [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) odsazení. Tato odsazení jsou relativní k šířce a výšce grafu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Formátovat vodící čáry**

Když jsou popisky výsečového grafu umístěny mimo výseče, vodící čáry pomáhají čtenářům přiřadit každou hodnotu ke správné výseči. Kontrastní barva a mírně silnější čára mohou tato spojení učinit snazšími ke sledování, zatímco průhlednost a čárkovaný styl udrží čáry vizuálně nenápadné.

Použijte [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) k formátování vodících čar na úrovni kolekce popisků dat řady. Nastavení v `series.labels.leader_lines_format.line` se vztahuje na celou kolekci, nikoli na jednotlivý popisek.

Tento příklad vytvoří výsečový graf s výchozími daty, zobrazí hodnoty mimo výseče a povolí [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/). Posune dva popisky dál od jejich výsečí pomocí [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) a [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) odsazení, vyjádřených jako zlomky šířky a výšky grafu. Žádná vstupní prezentace není vyžadována.

[fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) čáry nastaví plnou modrou barvu s alfa hodnotou 191 z 255, což dává přibližně 25 % průhlednost. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) nastavení šířky na 2 body a [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) udělá čáru čárkovanou.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # Přesuňte dva popisky dále od jejich výsečí.
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

Povolení vodících čar nezaručuje, že se čára objeví u každého popisku. Viditelnost závisí na umístění popisku a chování rozvržení grafu. V tomto příkladu mají dva posunuté popisky viditelné vodící čáry; popisky, které zůstávají blízko svých výsečí, je nepotřebují.

Následující obrázek ukazuje uložený soubor `FormattedLeaderLines.pptx` renderovaný pomocí Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Přidat více řádků popisků dat nad sloupcový graf**

Tento příklad vytvoří sloupcový graf se dvěma řádky popisků nad vykreslovací oblastí. Řada A zobrazuje viditelné sloupce, zatímco řada B a řada C poskytují dodatečné popisky. Jejich sloupce jsou skryty odebráním výplně a obrysu. Vlastnost [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) zarovnává všechny tři řady ke stejným středům kategorií.

Nastavení [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) rezervuje místo pro řádky popisků. Po výpočtu výchozích pozic metodou [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) uchovává [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) a [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) vodorovné zarovnání a aplikuje svislá odsazení pro uspořádání popisků ve dvou řádcích. Čísla zůstávají popisky dat propojené s hodnotami řady; pouze nadpisy řádků jsou samostatné textové tvary.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # Skrýt sloupce B a C, ale ponechat jejich popisky dat.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Zarovnat všechny tři řady ke stejným středům kategorií.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Použít méně mřížkových čar pro tento kompaktní příklad.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Rezervovat prostor nad oblastí grafu pro dva řádky popisků dat.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # Zachovat výchozí vodorovnou pozici. Y je posun od
            # výchozí pozice popisku, vyjádřený jako zlomek výšky grafu.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Pouze nadpis řádku je samostatný textový tvar.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**Jak mohu zabránit překrývání popisků dat v hustých grafech?**

Spojte automatické umístění popisků, vodící čáry a snížení velikosti písma; v případě potřeby skryjte některá pole (například kategorii) nebo zobrazujte popisky jen pro extrémní hodnoty či klíčové body.

**Jak mohu zakázat popisky pouze pro nulové, záporné nebo prázdné hodnoty?**

Filtrovat datové body před povolením popisků a vypnout zobrazování pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak zajistit konzistentní styl popisků při exportu do PDF/obrázků?**

Explicitně nastavte rodinu písma a velikost a ověřte, že je font dostupný v prostředí renderování, aby nedošlo k náhradě.