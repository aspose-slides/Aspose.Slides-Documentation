---
title: Spravovat datové popisky grafů v prezentacích v Pythonu
linktitle: Datový popisek
type: docs
url: /cs/python-net/chart-data-label/
keywords:
- graf
- datový popisek
- přesnost dat
- procento
- vzdálenost popisku
- umístění popisku
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se přidávat a formátovat datové popisky grafů v prezentacích PowerPoint pomocí Aspose.Slides pro Python via .NET pro poutavější snímky."
---
## **Úvod**

Datové popisky zobrazují informace o sériích grafu a jednotlivých datech, pomáhají čtenářům identifikovat hodnoty a pochopit graf. Tento článek vysvětluje, jak formátovat hodnoty, zobrazovat procenta, číst text popisku, upravit mezery popisků osy kategorií a umístit popisky výsečového grafu.

## **Nastavení přesnosti dat v popiscích grafu**

Použijte [number_format_of_values](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/number_format_of_values/) k formátování hodnot sérií. Tento příklad vytváří čárový graf s výchozími daty, zobrazuje jeho tabulku dat a povoluje popisky hodnot pro první sérii. Formát `#,##0.00` zobrazuje oddělovač tisíců a dvě desetinná místa, aniž by měnil podkladové hodnoty.

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

## **Zobrazit procenta jako popisky**

Pro sloupcový graf se zásobníkem vypočítejte každou hodnotu jako procento celkového součtu své kategorie a přiřaďte text do [text_frame_for_overriding](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Tento příklad používá výchozí data grafu a zobrazuje procenta se dvěma desetinnými místy v písmeni o velikosti 8 bodů. Kategorie s celkovým součtem nula jsou přeskočeny, aby se zabránilo dělení nulou. Přepočítejte vlastní text popisku, pokud se data grafu změní.

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

## **Nastavení procentního znaku v popiscích grafu**

Když jsou hodnoty uloženy jako zlomky, použijte [number_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabelformat/number_format/) k zobrazení procent. Nastavte [is_number_format_linked_to_source](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) na `False`, aby se formát popisku použil nezávisle na zdrojových buňkách. Tento příklad vytváří 100 % zásobníkový sloupcový graf s červenou a modrou sérií napříč čtyřmi kategoriemi. Každý pár hodnot sečte na 1. Formát popisku `0.0%` zobrazuje 0,30 jako 30,0 %, zatímco svislá osa používá dvě desetinná místa. Obě série používají bílý text popisku o velikosti 10 bodů.

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

## **Přečíst skutečný text datových popisků**

Použijte [get_actual_label_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) k získání textu vytvořeného nastavením datového popisku. To je užitečné při extrahování popisků pro zprávy, prohledávání obsahu prezentace nebo ověřování generovaných grafů. V níže uvedeném příkladu výchozí [data label format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabelformat/) kombinuje název každé kategorie, název série a hodnotu. Jeden bod formátuje svou hodnotu jako procento a další používá vlastní text z [text_frame_for_overriding](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Číslo uložené v datovém bodu zůstává `0.75`, i když jeho popisek zobrazuje `75%` spolu s názvem kategorie a série. Vlastní text nahrazuje vygenerovaný text popisku. [get_actual_label_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) vrací výsledný řetězec popisku v obou případech. Zkontrolujte [is_visible](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/is_visible/) samostatně, jak je ukázáno výše, pokud chcete získat pouze viditelné popisky.

## **Nastavit vzdálenost popisku od osy**

Použijte [label_offset](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/axis/label_offset/) k řízení vzdálenosti mezi popisky osy kategorií a samotnou osou. Hodnota je procento maximální velikosti písma popisků osy. Tento příklad vytváří seskupený sloupcový graf a nastavuje offset popisků vodorovné osy na 500. Toto nastavení ovlivňuje popisky osy kategorií, nikoli popisky připojené k jednotlivým datovým bodům.

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

U výsečového grafu upravte umístění datových popisků pro zlepšení rozestupů a vytvoření místa pro čáry popisků. Tento příklad zobrazuje hodnotu prvního datového bodu, umisťuje jeho popisek mimo výseč a upravuje jeho offsety [x](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/x/) a [y](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/y/). Tyto offsety jsou relativní k šířce a výšce grafu.

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

![Výsečový graf s upraveným umístěním datového popisku](pie-chart-adjusted-label.png)

## **Často kladené otázky**

**Jak mohu zabránit překrývání datových popisků v hustých grafech?**

Kombinujte automatické umístění popisků, čáry popisků a sníženou velikost písma; v případě potřeby skryjte některá pole (například kategorii) nebo zobrazte popisky pouze pro krajní hodnoty či klíčové body.

**Jak mohu zakázat popisky pouze pro nulové, záporné nebo prázdné hodnoty?**

Filtrujte datové body před povolením popisků a vypněte jejich zobrazení pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak mohu zajistit konzistentní styl popisků při exportu do PDF/obrázků?**

Explicitně nastavte rodinu písma a velikost a ověřte, že je písmo dostupné v prostředí vykreslování, aby nedošlo k náhradnímu písmu.