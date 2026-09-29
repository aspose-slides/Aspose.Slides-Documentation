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
description: "Naučte se přidávat a formátovat popisky dat v grafech v PowerPoint prezentacích pomocí Aspose.Slides pro Python přes .NET pro poutavější snímky."
---
## **Úvod**

Popisky dat zobrazují informace o řadách grafu a jednotlivých datových bodech, pomáhají čtenářům identifikovat hodnoty a pochopit graf. Tento článek vysvětluje, jak formátovat hodnoty, zobrazovat procenta, číst text popisku, řídit popisky nad maximem osy, upravit rozestup popisků osy kategorií a umístit popisky výsečového grafu.

## **Nastavení přesnosti dat v popiscích grafu**

Použijte [number_format_of_values](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/number_format_of_values/) k formátování hodnot řady. Tento příklad vytváří čárový graf s výchozími daty, zobrazuje jeho datovou tabulku a povoluje popisky hodnot pro první řadu. Formát `#,##0.00` zobrazuje oddělovač tisíců a dvě desetinná místa, aniž by měnil podkladové hodnoty.

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

## **Zobrazení procent jako popisků**

Pro sloupcový graf s vrstvením vypočítejte každou hodnotu jako procento celkového součtu kategorie a přiřaďte text pomocí [text_frame_for_overriding](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Tento příklad používá výchozí data grafu a zobrazuje procenta se dvěma desetinnými místy v písmu o velikosti 8 bodů. Kategorie s nulovým součtem jsou přeskočeny, aby se zabránilo dělení nulou. Přepočítejte vlastní text popisku, pokud se data grafu změní.

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

## **Nastavení procentního znaku u popisků grafu**

Když jsou hodnoty uloženy jako zlomky, použijte [number_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabelformat/number_format/) k zobrazení procent. Nastavte [is_number_format_linked_to_source](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) na `False`, aby se formát popisku použil nezávisle na zdrojových buňkách.

Tento příklad vytváří 100 % vrstvený sloupcový graf s červenou a modrou řadou napříč čtyřmi kategoriemi. Každý pár hodnot se sčítá na 1. Formát popisku `0.0%` zobrazuje 0.30 jako 30,0 %, zatímco svislá osa používá dvě desetinná místa. Obě řady používají bílý popisek o velikosti 10 bodů.

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

## **Načtení skutečného textu popisků dat**

Použijte [get_actual_label_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) k získání textu vytvořeného nastavením popisku dat. To je užitečné při extrahování popisků pro zprávy, vyhledávání obsahu prezentace nebo ověřování vygenerovaných grafů. V níže uvedeném příkladu výchozí [data label format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabelformat/) kombinuje název každé kategorie, název řady a hodnotu. Jeden bod formátuje svou hodnotu jako procento a jiný používá vlastní text z [text_frame_for_overriding](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Číslo uložené v datovém bodu zůstává `0.75`, i když jeho popisek zobrazuje `75 %` spolu s názvem kategorie a řady. Vlastní text nahrazuje vygenerovaný text popisku. [get_actual_label_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) vrací výsledný řetězec popisku v obou případech. Zkontrolujte [is_visible](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/is_visible/) samostatně, jak je ukázáno výše, pokud chcete extrahovat pouze viditelné popisky.

## **Řízení popisků dat nad maximem osy**

Když omezíte rozsah osy ručně, některé datové body mohou překročit její maximum. Použijte [show_data_labels_over_maximum](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) k řízení, zda se jejich popisky zobrazí. Toto nastavení mění viditelnost popisku; nemění rozsah osy ani podkladové hodnoty dat.

Níže uvedený příklad vytváří 2D seskupený sloupcový graf s hodnotami 60 a 120. Nastavuje [is_automatic_max_value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/axis/is_automatic_max_value/) na `False` a [max_value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/axis/max_value/) na 100 na svislé ose. První snímek povoluje popisky nad maximem; kopie tohoto snímku je zakazuje. Oba snímky jsou uloženy v `DataLabelsOverMaximum.pptx`.

Povolte popisky hodnot pomocí [show_value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabelformat/show_value/). Nastavení na úrovni grafu samo o sobě nezpůsobí zobrazení hodnot ani nepřepíše zakázané zobrazení hodnot u jednotlivých popisků. Tento příklad povoluje hodnoty pro celou řadu a používá [position](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabelformat/position/) k umístění popisků na vnější konec každého sloupce.

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

Následující obrázky ukazují uložené snímky vykreslené v Microsoft PowerPoint. S hodnotou `True` je popisek **120** viditelný na horní hranici; s hodnotou `False` je skrytý. Popisek **60** zůstává viditelný, maximum osy zůstává na **100** a druhý datový bod zůstává **120** v obou případech.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint graf zobrazující popisek hodnoty 120 s maximem osy 100](data-labels-over-maximum-true.png) | ![PowerPoint graf skrývající popisek hodnoty 120 s maximem osy 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Tento příklad používá 2D sloupcový graf s hodnotovou osou. Grafy bez hodnotové osy, jako jsou výsečové a prstencové grafy, nemají maximum osy, které by šlo tímto způsobem omezit.
{{% /alert %}}

## **Nastavení vzdálenosti popisku od osy**

Použijte [label_offset](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/axis/label_offset/) k řízení vzdálenosti mezi popisky osy kategorií a samotnou osou. Hodnota je procento maximální velikosti písma popisků osy. Tento příklad vytvoří seskupený sloupcový graf a nastaví odsazení popisků vodorovné osy na 500. Toto nastavení ovlivňuje popisky osy kategorií, nikoli popisky připojené k jednotlivým datovým bodům.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Úprava umístění popisků**

U výsečového grafu upravte umístění popisků dat, aby se zlepšily rozestupy a uvolnilo místo pro vodicí čáry.

Tento příklad zobrazuje hodnotu prvního datového bodu, umisťuje jeho popisek mimo výseč a upravuje jeho odsazení [x](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/x/) a [y](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/y/). Tato odsazení jsou relativní k šířce a výšce grafu.

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

![Výsečový graf s upraveným umístěním popisku](pie-chart-adjusted-label.png)

## **Často kladené otázky**

**Jak mohu zabránit překrývání popisků dat v hustých grafech?**  
Kombinujte automatické umístění popisků, vodicí čáry a zmenšenou velikost písma; případně skryjte některá pole (například kategorii) nebo zobrazujte popisky jen pro extrémní hodnoty či klíčové body.

**Jak mohu zakázat popisky pouze pro nulové, záporné nebo prázdné hodnoty?**  
Filtrování datových bodů před povolením popisků a vypnutí zobrazení pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak zajistit konzistentní styl popisků při exportu do PDF/obrázků?**  
Explicitně nastavte rodinu písma a velikost a ověřte, že je písmo dostupné v prostředí vykreslování, aby nedošlo k náhradnímu použití.