---
title: Zarządzanie etykietami danych wykresu w prezentacjach przy użyciu Pythona
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
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak dodawać i formatować etykiety danych wykresu w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET, aby uzyskać bardziej angażujące slajdy."
---
## **Przegląd**

Etykiety danych na wykresie pokazują szczegóły dotyczące serii danych wykresu lub poszczególnych punktów danych. Pozwalają czytelnikom szybko zidentyfikować serie danych i ułatwiają zrozumienie wykresów. W Aspose.Slides for Python możesz włączać, dostosowywać i formatować etykiety danych dla dowolnego wykresu — wybierając, co wyświetlać (wartości, procenty, nazwy serii lub kategorii), gdzie umieszczać etykiety oraz jak mają wyglądać (czcionka, format liczbowy, separatory, linie prowadzące i inne). Ten artykuł opisuje najważniejsze interfejsy API i przykłady, których potrzebujesz, aby dodać przejrzyste, informacyjne etykiety do wykresów.

## **Ustaw precyzję etykiet danych**

Etykiety danych wykresu często wyświetlają wartości liczbowe, które wymagają jednolitej precyzji. W tej sekcji pokazano, jak kontrolować liczbę miejsc dziesiętnych w etykietach danych w Aspose.Slides, stosując odpowiedni format liczbowy.

Poniższy przykład w Pythonie pokazuje, jak ustawić precyzję liczbową dla etykiet danych wykresu:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Wyświetl procenty jako etykiety**

Za pomocą Aspose.Slides możesz wyświetlać procenty jako etykiety danych na wykresach. Poniższy przykład oblicza udział każdego punktu w jego kategorii i formatuje etykietę tak, aby wyświetlała procent.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Zapisz prezentację zawierającą wykres.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Pokaż znak procenta w etykietach danych wykresu**

W tej sekcji pokazano, jak wyświetlać procenty w etykietach danych wykresu i dodawać znak procenta za pomocą Aspose.Slides. Dowiesz się, jak włączać wartości procentowe dla całych serii lub konkretnych punktów (idealne dla wykresów kołowych, pierścieniowych i wykresów skumulowanych 100 %), oraz jak kontrolować formatowanie za pomocą opcji etykiety lub własnego formatu liczbowego.

Poniższy przykład w Pythonie pokazuje, jak dodać znak procenta do etykiety danych wykresu:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:

    # Uzyskaj referencję do slajdu po indeksie.
    slide = presentation.slides[0]

    # Utwórz wykres PercentsStackedColumn na slajdzie.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Uzyskaj skoroszyt danych wykresu.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Dodaj nową serię.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Ustaw kolor wypełnienia serii.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Ustaw właściwości formatu etykiety.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Dodaj nową serię.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Ustaw typ wypełnienia i kolor.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Zapisz prezentację.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw odległość etykiety od osi**

W tej sekcji pokazano, jak kontrolować odległość między etykietami danych a osią wykresu w Aspose.Slides. Dostosowanie tego offsetu pomaga zapobiegać nakładaniu się etykiet i poprawia czytelność w gęstych wizualizacjach.

Poniższy kod w Pythonie pokazuje, jak ustawić odległość etykiety od osi kategorii przy pracy z wykresem opartym na osiach:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    # Pobierz referencję do slajdu.
    slide = presentation.slides[0]

    # Utwórz wykres kolumnowy grupowany na slajdzie.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Ustaw odległość etykiety od osi kategorii (poziomej).
    chart.axes.horizontal_axis.label_offset = 500

    # Zapisz prezentację.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostosuj pozycję etykiety**

Kiedy tworzysz wykres, który nie używa osi, na przykład wykres kołowy, etykiety danych mogą być zbyt blisko krawędzi. W takim przypadku dostosuj pozycję etykiety, aby linie prowadzące były wyraźnie widoczne.

Poniższy kod w Pythonie pokazuje, jak dostosować pozycję etykiety na wykresie kołowym:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Zmieniona pozycja etykiety](changed_label_position.png)

## **FAQ**

**Jak mogę zapobiec nakładaniu się etykiet danych na gęstych wykresach?**

Połącz automatyczne rozmieszczanie etykiet, linie prowadzące oraz zmniejszenie rozmiaru czcionki; w razie potrzeby ukryj niektóre pola (np. kategorię) lub wyświetlaj etykiety tylko dla punktów skrajnych/kluczowych.

**Jak mogę wyłączyć etykiety tylko dla wartości zerowych, ujemnych lub pustych?**

Przefiltruj punkty danych przed włączeniem etykiet i wyłącz wyświetlanie dla wartości 0, wartości ujemnych lub brakujących zgodnie z określoną regułą.

**Jak mogę zapewnić spójny styl etykiet przy eksportowaniu do PDF/obrazów?**

Jawnie ustaw czcionki (rodzina, rozmiar) i sprawdź, czy czcionka jest dostępna po stronie renderowania, aby uniknąć użycia zastępczego.