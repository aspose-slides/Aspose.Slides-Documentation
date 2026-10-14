---
title: Dostosuj wykresy kołowe w prezentacjach przy użyciu Pythona
linktitle: Wykres kołowy
type: docs
url: /pl/python-net/pie-chart/
keywords:
- wykres kołowy
- zarządzanie wykresem
- dostosuj wykres
- opcje wykresu
- ustawienia wykresu
- opcje wykresu
- kolor wycinka
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i dostosowuj wykresy kołowe w Pythonie przy użyciu Aspose.Slides. Konfiguruj wykresy drugorzędne, wyświetlaj etykiety danych oraz stosuj automatyczne kolory wycinków w PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje wykresu drugorzędnego dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie wycinków dla standardowego wykresu kołowego.

Przykłady koncentrują się na zadaniach związanych z dostosowywaniem wykresu, takich jak dodawanie wykresu do slajdu, modyfikowanie ustawień serii i etykiet, zamiana domyślnych danych wykresu na własne kategorie i wartości oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie**

Aspose.Slides dla Pythona via .NET obsługuje opcje wykresu drugorzędnego dla wykresów Pie of Pie i Bar of Pie. Opcje te kontrolują rozmiar wykresu drugorzędnego oraz sposób podziału punktów danych pomiędzy dwa wykresy.

Poniższy przykład tworzy wykres Pie of Pie w nowej prezentacji i wyświetla wartości punktów danych jako etykiety. Właściwość [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) ustawia rozmiar wykresu drugorzędnego na 149% wykresu głównego. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) wybiera podział oparty na procentach, a [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) ustawia próg na 53%.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Wyświetl wartości i skonfiguruj wykres drugorzędny.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Wybierz kategorie dla wykresu drugorzędnego**

Użyj niestandardowego podziału, gdy chcesz pogrupować określone kategorie w wykresie drugorzędnym niezależnie od ich wartości procentowych. Na przykład raport sprzedaży może pokazywać Online i Events razem, aby czytelnicy mogli porównać te dwa kanały, mimo że stanowią 35% i 10% całkowitej sprzedaży.

Ustaw [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) na [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) i wybierz punkty za pomocą [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). Metoda [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) kolekcji przyjmuje albo indeks zerowy w serii, albo obiekt punktu danych. W tym przykładzie indeks 1 wybiera Online, a punkt o indeksie 3 wybiera Events. Partners jest również dodany tymczasowo, a następnie wykluczony przy użyciu [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Zamień domyślne dane na sprzedaż według kanału.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Wybierz Online według indeksu zerowego i Events według obiektu punktu danych.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Wyklucz Partners z wyboru bez usuwania jego danych źródłowych.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) i Events (10) pojawiają się jako oddzielne wycinki w wykresie drugorzędnym. W wykresie głównym są reprezentowane jako jeden połączony wycinek o wartości 45, obok Retail (40) i Partners (15). Usunięcie Partners z niestandardowego wyboru pozostawia go w wykresie głównym; nie usuwa kategorii ani jej wartości z danych źródłowych wykresu.

Na poniższym obrazku przedstawiona jest zapisana prezentacja w PowerPoint:

![Wykres Pie of Pie z Online i Events w wykresie drugorzędnym oraz ich łączną wartością 45 w wykresie głównym](pie_of_pie_custom.png)

## **Ustaw automatyczne kolory wycinków wykresu kołowego**

Aspose.Slides dla Pythona via .NET może automatycznie przydzielać różne kolory wycinkom wykresu kołowego. Poniższy przykład tworzy wykres kołowy z wyśrodkowanym tytułem i zamienia domyślne dane na trzy kwartalne kategorie oraz ich wartości. Właściwość [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) wyświetla wartości 20, 50 i 30 jako etykiety, natomiast [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) umożliwia nadanie odrębnego koloru każdemu wycinkowi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Dodaj wyśrodkowany tytuł wykresu.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Zamień domyślne dane przy użyciu pierwszego arkusza.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Pokaż wartości i przypisz różne kolory wycinkom.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy warianty Pie of Pie i Bar of Pie są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) wykres drugorzędny dla wykresów kołowych, w tym typy Pie of Pie i Bar of Pie.

**Czy mogę wyeksportować sam wykres jako obraz (na przykład PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (np. PNG) bez eksportowania całej prezentacji.