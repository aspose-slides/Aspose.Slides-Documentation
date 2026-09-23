---
title: Zarządzaj etykietami danych wykresu w prezentacjach przy użyciu Pythona
linktitle: Etykieta danych
type: docs
url: /pl/python-net/chart-data-label/
keywords:
- wykres
- etykieta danych
- precyzja danych
- procent
- odległość etykiety
- położenie etykiety
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak dodawać i formatować etykiety danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez .NET, aby uzyskać bardziej atrakcyjne slajdy."
---
## **Wprowadzenie**

Etykiety danych wyświetlają informacje o seriach wykresu i poszczególnych punktach danych, pomagając czytelnikom zidentyfikować wartości i zrozumieć wykres. Ten artykuł wyjaśnia, jak formatować wartości, wyświetlać procenty, odczytywać tekst etykiety, regulować odstępy etykiet osi kategorii oraz pozycjonować etykiety wykresu kołowego.

## **Ustaw precyzję danych w etykietach wykresu**

Użyj [number_format_of_values](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartseries/number_format_of_values/) do formatowania wartości serii. Ten przykład tworzy wykres liniowy z domyślnymi danymi, wyświetla jego tabelę danych i włącza etykiety wartości dla pierwszej serii. Format `#,##0.00` wyświetla separator tysięcy oraz dwa miejsca po przecinku bez zmiany wartości podstawowych.

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

## **Wyświetl procent jako etykiety**

Dla wykresu słupkowego skumulowanego oblicz każdą wartość jako procent sumy w swojej kategorii i przypisz tekst do [text_frame_for_overriding](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Ten przykład używa domyślnych danych wykresu i wyświetla procenty z dwoma miejscami po przecinku w czcionce o rozmiarze 8 punktów. Kategorie o sumie zerowej są pomijane, aby uniknąć dzielenia przez zero. Przelicz ponownie niestandardowy tekst etykiety, jeśli dane wykresu ulegną zmianie.

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

## **Ustaw znak procenta w etykietach danych wykresu**

Gdy wartości są przechowywane jako ułamki, użyj [number_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabelformat/number_format/) do wyświetlania procentów. Ustaw [is_number_format_linked_to_source](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) na `False`, aby zastosować format etykiety niezależnie od komórek źródłowych.

Ten przykład tworzy wykres słupkowy skumulowany 100% z czerwonymi i niebieskimi seriami w czterech kategoriach. Każda para wartości sumuje się do 1. Format etykiety `0.0%` wyświetla 0,30 jako 30,0%, podczas gdy oś pionowa używa dwóch miejsc po przecinku. Obie serie używają białego tekstu etykiety o rozmiarze 10 punktów.

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

## **Odczytaj rzeczywisty tekst etykiet danych**

Użyj [get_actual_label_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) aby pobrać tekst wygenerowany na podstawie ustawień etykiety danych. Jest to przydatne przy wyodrębnianiu etykiet do raportów, przeszukiwaniu treści prezentacji lub weryfikacji wygenerowanych wykresów. W poniższym przykładzie domyślny [data label format](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabelformat/) łączy nazwę każdej kategorii, nazwę serii oraz wartość. Jeden punkt formatuje swoją wartość jako procent, a inny używa niestandardowego tekstu z [text_frame_for_overriding](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Liczba przechowywana w punkcie danych pozostaje `0.75`, nawet gdy jego etykieta wyświetla `75%` wraz z nazwą kategorii i serii. Niestandardowy tekst zastępuje wygenerowany tekst etykiety. [get_actual_label_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) zwraca wynikowy ciąg etykiety w obu przypadkach. Sprawdzaj [is_visible](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabel/is_visible/) oddzielnie, jak pokazano powyżej, gdy chcesz wyodrębnić tylko widoczne etykiety.

## **Ustaw odległość etykiety od osi**

Użyj [label_offset](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/axis/label_offset/) aby kontrolować odległość między etykietami osi kategorii a samą osią. Wartość jest wyrażona jako procent maksymalnego rozmiaru czcionki etykiet osi. Ten przykład tworzy wykres słupkowy grupowany i ustawia offset etykiet osi poziomej na 500. To ustawienie wpływa na etykiety osi kategorii, a nie na etykiety przypisane do poszczególnych punktów danych.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostosuj położenie etykiety**

W wykresie kołowym dostosuj pozycje etykiet danych, aby poprawić odstępy i pozostawić miejsce na linie pomocnicze.

Ten przykład wyświetla wartość pierwszego punktu danych, umieszcza jego etykietę poza fragmentem oraz dostosowuje offsety [x](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabel/x/) i [y](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabel/y/). Te offsety są odpowiednio względem szerokości i wysokości wykresu.

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

![Wykres kołowy z dostosowaną pozycją etykiety danych](pie-chart-adjusted-label.png)

## **FAQ**

**Jak mogę zapobiec nakładaniu się etykiet danych na gęstych wykresach?**

Połącz automatyczne rozmieszczanie etykiet, linie pomocnicze i zmniejszoną wielkość czcionki; w razie potrzeby ukryj niektóre pola (na przykład kategorię) lub wyświetlaj etykiety tylko dla wartości skrajnych lub kluczowych punktów.

**Jak mogę wyłączyć etykiety tylko dla wartości zerowych, ujemnych lub pustych?**

Przefiltruj punkty danych przed włączeniem etykiet i wyłącz wyświetlanie dla wartości równych 0, wartości ujemnych lub brakujących, zgodnie z określoną regułą.

**Jak mogę zapewnić spójny styl etykiet przy eksportowaniu do PDF/obrazów?**

Wyraźnie ustaw rodzinę i rozmiar czcionki oraz zweryfikuj, że czcionka jest dostępna w środowisku renderującym, aby uniknąć użycia zastępczej czcionki.