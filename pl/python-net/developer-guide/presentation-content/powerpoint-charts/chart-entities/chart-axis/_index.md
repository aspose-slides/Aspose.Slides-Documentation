---
title: Dostosuj osie wykresów w prezentacjach z Pythonem
linktitle: Oś wykresu
type: docs
url: /pl/python-net/chart-axis/
keywords:
- oś wykresu
- oś pionowa
- oś pozioma
- dostosuj oś
- manipuluj osią
- zarządzaj osią
- właściwości osi
- wartość maksymalna
- wartość minimalna
- linia osi
- format daty
- tytuł osi
- pozycja osi
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj, jak używać Aspose.Slides for Python via .NET do dostosowywania osi wykresów w prezentacjach PowerPoint i OpenDocument dla raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu przy użyciu Aspose.Slides for Python via .NET. Omówiono obliczane wartości osi, zamianę wierszy i kolumn wykresu, widoczność osi, interwały etykiet kategorii i znaczników podziałek, kategorie dat i formatowanie, obrót tytułu, pozycjonowanie osi, jednostki wyświetlania oraz skalowanie logarytmiczne.

## **Uzyskaj maksymalne wartości na pionowej osi wykresów**

Utwórz [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) i dodaj wykres obszarowy z domyślnymi danymi. Wywołaj [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) przed odczytaniem obliczonych wartości osi, aby układ wykresu był aktualny.

Odczytaj [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) i [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) dla limitów osi oraz [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) i [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) dla interwałów podziałek. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) i [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) dostarczają skale jednostek czasu, które są istotne dla osi datowych. Przykład przechowuje te wartości w zmiennych lokalnych i zapisuje wykres.

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

## **Zamień dane między osiami**

Użyj [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) aby zamienić role serii i kategorii w danych wykresu. Każda poprzednia kategoria staje się serią, a każda poprzednia seria staje się kategorią. Zmienia to sposób grupowania danych; nie zamienia to osi poziomej i pionowej. Przykład używa [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) aby powiązać domyślne dane z `Sheet1!A1:D5`, w tym wiersz nagłówka i kolumnę kategorii, przed zamianą wierszy i kolumn. Zapisuje wykres z czterema seriami i trzema kategoriami.

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

## **Ukryj pionową oś dla wykresów liniowych**

Ustaw [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) na `False` na osi pionowej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą pionową osią.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Ukryj poziomą oś dla wykresów liniowych**

Ustaw [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) na `False` na osi poziomej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą poziomą osią.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmień oś kategorii**

Ustaw [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) aby wybrać oś kategorii datową lub tekstową. Ten przykład wymaga `ExistingChart.pptx`, zawierającego wykres jako pierwszy kształt na pierwszym slajdzie oraz komórki kategorii zawierające numeryczne wartości dat Excel. Zmienia on oś poziomą na oś datową. Ustawienie [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) na `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) na `1` i [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) na miesiące umieszcza główne podziały co miesiąc.

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

## **Steruj interwałami etykiet osi kategorii**

Gdy wykres ma wiele kategorii, można zmniejszyć liczbę widocznych etykiet osi bez usuwania kategorii czy punktów danych. Ustaw [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) na `False`, a następnie ustaw [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) na żądany interwał kategorii. Dla kategorii tekstowych w ich normalnym porządku, liczenie zaczyna się od pierwszej kategorii:

| Interwał | Etykiety wyświetlane w przykładzie |
| --- | --- |
| `1` | Kategoria 1, Kategoria 2, Kategoria 3, ... Kategoria 24 |
| `2` | Kategoria 1, Kategoria 3, Kategoria 5, ... Kategoria 23 |
| `3` | Kategoria 1, Kategoria 4, Kategoria 7, ... Kategoria 22 |

Interwał `3` wyświetla każdą trzecią etykietę, ukrywając dwie etykiety pomiędzy wyświetlanymi. Nie usuwa to odpowiadających kolumn. Automatyczne rozmieszczanie wybiera interwał w zależności od dostępnej przestrzeni; niekoniecznie wyświetla wszystkie etykiety.

Znaczniki podziałek mają osobne ustawienia. Ustaw [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) na `False` i użyj [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) aby określić ich interwał. Na przykład `1` utrzymuje znacznik podziałki przy każdym interwale kategorii, podczas gdy etykiety pojawiają się tylko co trzecią kategorię. Ustaw [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) na widoczny styl, aby zobaczyć rezultat. Ustawienie którejkolwiek właściwości automatycznego rozmieszczania z powrotem na `True` pozwala wykresowi ponownie wybrać ten interwał.

Poniższy samodzielny przykład tworzy 24 kategorie i jedną serię, a następnie zapisuje trzy slajdy w `CategoryAxisIntervals.pptx`: automatyczne rozmieszczanie, ręczne rozmieszczanie etykiet z niezależnymi znacznikami oraz przywrócone automatyczne rozmieszczanie. Dwie kopie zachowują pierwotne dane wykresu. Nie wymaga żadnej prezentacji wejściowej. Tekst poziomych etykiet ułatwia dostrzeżenie różnicy w gęstości.

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

    # Slajd 2: pokaż co trzecią etykietę, ale pozostaw znacznik podziałki dla każdej kategorii.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Slajd 3: pozwól wykresowi ponownie wybrać oba interwały.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatyczne rozmieszczanie (slajd 1):** W tym renderowaniu każda druga etykieta kategorii jest wyświetlana i łamie się na dwie linie. Automatyczny wynik może się różnić w zależności od rozmiaru wykresu, czcionek i renderera.

![Automatyczne rozmieszczanie etykiet kategorii przy widocznych wszystkich 24 kolumnach](category-axis-automatic.png)

**Ręczne rozmieszczanie (slajd 2):** Każda trzecia etykieta jest wyświetlana w jednej linii, podczas gdy znaczniki podziałek pozostają przy każdym interwale kategorii. Wszystkie 24 kolumny, w tym te bez etykiet, pozostają widoczne z tymi samymi wartościami. Slajd 3 przywraca automatyczny wygląd przedstawiony powyżej.

![Ręczny interwał etykiet kategorii wynoszący trzy przy widocznych wszystkich 24 kolumnach](category-axis-manual.png)

### **Wybierz właściwą oś i interwał**

Użyj tego interwału liczenia kategorii dla tekstowej osi kategorii, takiej jak oś kategorii wykresu kolumnowego, liniowego, obszarowego lub słupkowego. W wykresie kolumnowym jest to oś pozioma. W wykresie słupkowym poziomym oś kategorii jest pionowa, więc zastosuj te ustawienia do [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Rozstawienie znaczników podziałek dotyczy również osi serii w wykresach, które ją posiadają.

Nie używaj rozmieszczania etykiet kategorii do ustawiania numerycznej skali osi wartości. Na osi wartości [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) określa różnicę w wartościach: na przykład jednostka główna `10` generuje podziały przy 0, 10, 20 itd., gdy oś zaczyna się od zera. Interwał etykiet kategorii `3` liczy pozycje kategorii, niezależnie od ich wartości danych. Wykresy rozproszenia i bąbelkowe używają osi wartości zamiast tekstowej osi kategorii. Dla osi datowej użyj jednostek i skal czasowych opisanych w [Change a Category Axis](#change-a-category-axis).

## **Ustaw format daty dla wartości osi kategorii**

Przykład zastępuje domyślne dane wykresu czterema rocznymi wartościami. Daty są przechowywane jako numery seryjne OLE Automation w pierwszym arkuszu (indeks `0`). Ustaw [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) na oś dat, wyłącz [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/), i przypisz `yyyy` do [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) aby etykiety kategorii wyświetlały czterocyfrowe lata niezależnie od formatowania komórek.

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

## **Ustaw kąt obrotu tytułu osi wykresu**

Włącz [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) na osi pionowej, podaj tekst tytułu i ustaw [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) aby obrócić tytuł. Kąt jest mierzony w stopniach; ten przykład zapisuje wykres kolumnowy z tytułem osi wartości obróconym o 90 stopni.

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

## **Ustaw pozycję osi na osi kategorii lub wartości**

Użyj [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) aby kontrolować, czy oś wartości przecina oś kategorii pomiędzy kategoriami czy na znacznikach podziałek kategorii. Właściwość ta dotyczy osi kategorii. Przykład ustawia ją na `True` na poziomej osi kategorii wykresu kolumnowego i zapisuje wynik.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw jednostkę wyświetlania na osi wartości wykresu**

Ustaw [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) aby skalować etykiety na osi wartości bez zmiany podstawowych danych. Przy ustawieniu [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) na `MILLIONS`, wartość 60 000 000 jest wyświetlana jako 60. Przykład tworzy wykres kolumnowy i stosuje jednostkę wyświetlania milionów do jego osi pionowej.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Skonfiguruj logarytmiczną oś wartości**

Logarytmiczna oś wartości jest przydatna, gdy dodatnie wartości rozciągają się na kilka rzędów wielkości. Na przykład usługa może otrzymywać 10, 100, 1 000, 10 000 i 100 000 żądań w ciągu pięciu okresów. Na skali liniowej mniejsze wartości są blisko siebie w pobliżu zera. Skala logarytmiczna ułatwia porównanie ich względnego wzrostu: równe odległości reprezentują równe stosunki, a nie równe różnice.

Ustaw [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) na `True` na osi wartości i użyj [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) aby wybrać podstawę. Zmienia to sposób wyświetlania istniejących wartości; nie zmienia danych ani nie dodaje logarytmicznej linii trendu. Linia trendu przedstawia dopasowaną zależność w danych i jest odrębną funkcją.

### **Wybierz oś wartości i podstawę**

W wykresie liniowym lub kolumnowym oś wartości to [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). W wykresie słupkowym poziomym jest to [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Wykresy punktowe i bąbelkowe mają dwie osie wartości, więc wybierz oś poziomą dla wartości X, oś pionową dla wartości Y lub obie. Nie stosuj skalowania logarytmicznego do osi kategorii.

Domyślna podstawa logarytmu to `10`. Dla wykresów PPTX użyj podstawy od `2` do `1000`, włącznie; obsługiwane są także podstawy ułamkowe, takie jak `2.5`. Przy podstawie `10` kolejne potęgi, takie jak 10, 100, 1 000 i 10 000, są równomiernie rozmieszczone.

### **Porównaj skalowanie liniowe i logarytmiczne**

Poniższy samodzielny przykład tworzy wykres liniowy z pięcioma liczbami żądań na pierwszym slajdzie, a następnie klonuje ten slajd i włącza logarytmiczną oś wartości o podstawie 10 na drugim. Oba slajdy zachowują te same dane.

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

    # Zachowaj pierwszy slajd liniowy i zmień tylko skalę osi wartości w kopii.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Skala liniowa (slajd 1):** Równe odległości pionowe reprezentują równe różnice w liczbie żądań. Największa wartość dominuje wykres, utrudniając rozróżnienie mniejszych wartości.

![Wykres liniowy w PowerPoint przedstawiający pięć liczb żądań na liniowej osi wartości](value-axis-linear.png)

**Skala logarytmiczna (slajd 2):** Równe odległości pionowe reprezentują równe stosunki. Każdy okres ma dziesięć razy więcej żądań niż poprzedni, więc punkty tworzą prostą rosnącą linię na skali o podstawie 10. Etykiety osi nadal pokazują pierwotne liczby żądań.

![Te same pięć liczb żądań w PowerPoint na logarytmicznej osi wartości o podstawie 10](value-axis-logarithmic.png)

### **Obsługa wartości zerowych i ujemnych**

Skala logarytmiczna może wyświetlać wyłącznie wartości ściśle dodatnie. Sprawdź dane przed jej włączeniem. Jeśli wartości zerowe lub ujemne mają znaczenie, zachowaj skalę liniową lub pokaż je oddzielnie. Jeśli wykluczenie tych wartości jest odpowiednie dla analizy, wyjaśnij ich pominięcie. Nie zastępuj ich po cichu małymi liczbami dodatnimi, ponieważ zmienia to znaczenie danych. Każde ręcznie skonfigurowane minimum lub maksimum dla osi logarytmicznej musi również być dodatnie.

## **FAQ**

**Jak ustawić wartość, przy której jedna oś przecina drugą (przecięcie osi)?**

Użyj [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) aby wybrać sposób przecięcia. Aby określić numeryczną wartość przecięcia, ustaw [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Te ustawienia pozwalają przenieść przecięcie osi do odpowiedniej linii bazowej.

**Jak mogę pozycjonować etykiety podziałek względem osi?**

Ustaw [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) używając [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` lub `NONE`. Aby kontrolować same znaczniki podziałek, użyj [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) lub [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); są one oddzielne od pozycjonowania etykiet.