---
title: Dostosowywanie osi wykresu w prezentacjach przy użyciu Pythona
linktitle: Oś wykresu
type: docs
url: /pl/python-net/chart-axis/
keywords:
- oś wykresu
- oś pionowa
- oś pozioma
- dostosowywanie osi
- manipulowanie osią
- zarządzanie osią
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

Ten artykuł wyjaśnia, jak dostosować osie wykresu przy użyciu Aspose.Slides for Python via .NET. Omówiono obliczone wartości osi, zamianę wierszy i kolumn danych wykresu, widoczność osi, interwały etykiet kategorii i znaczników podziałki, kategorie dat i formatowanie, obrót tytułu, pozycjonowanie osi, jednostki wyświetlania oraz skalowanie logarytmiczne.

## **Uzyskanie maksymalnych wartości na osi pionowej wykresów**

Utwórz [Prezentacja](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) i dodaj wykres obszarowy z domyślnymi danymi. Wywołaj [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) przed odczytaniem obliczonych wartości osi, aby układ wykresu był aktualny.

Odczytaj [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) i [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) jako granice osi oraz [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) i [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) jako interwały podziałek. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) i [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) podają skale jednostek czasu, co ma znaczenie dla osi dat. Przykład przechowuje te wartości w zmiennych lokalnych i zapisuje wykres.

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

## **Zamiana danych między osiami**

Użyj [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/), aby wymienić role serii i kategorii w danych wykresu. Każda poprzednia kategoria staje się serią, a każda poprzednia seria staje się kategorią. Zmienia to sposób grupowania danych; nie wymienia to osi poziomej i pionowej. Przykład używa [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) do powiązania domyślnych danych z `Sheet1!A1:D5`, włączając wiersz nagłówka i kolumnę kategorii, przed zamianą wierszy i kolumn. Zapisuje wykres z czterema seriami i trzema kategoriami.

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

## **Odwrócenie kolejności rysowania osi**

Użyj [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/), aby odwrócić oś kategorii lub wartości. Na przykład wykres słupkowy poziomy może pokazywać etapy projektu od góry do dołu w tej samej kolejności, co arkusz: Planowanie, Rozwój, Testowanie. Odwrócenie osi zmienia kierunek rysowania; nie sortuje ani nie przestawia danych w skoroszycie. Dla porównania, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) wymienia role serii i kategorii.

Poniższy przykład tworzy wykres słupkowy poziomy z trzema etapami i jedną serią. Zapisuje prezentację z trzema slajdami: normalna kolejność, odwrócone kategorie i odwrócone wartości. Każda kopia używa tego samego zestawu danych, a na każdej odwrócona jest tylko jedna oś.

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

    # Slajd 2: wyświetl pierwszą kategorię na górze.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Zachowaj poziomą oś wartości na dole.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Slajd 3: odwróć tylko poziomą skalę numeryczną.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Odwrócenie osi może także przenieść prostopadłą oś na przeciwległą stronę wykresu. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) kontroluje, gdzie druga oś przecina konfigurowaną oś. Na slajdzie 2 ustawienie jej na `MAXIMUM` na odwróconej osi kategorii utrzymuje poziomą oś wartości na dole. Dla określonego punktu przecięcia użyj [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Sprawdź ustawienia przecięcia przy zmianie kierunku, zwłaszcza jeśli wykres już ma niestandardowy punkt przecięcia. Ustaw `is_plot_order_reversed` z powrotem na `False`, aby przywrócić normalny kierunek rysowania; ustawienia przecięcia są odrębne.

| Normalna kolejność (slajd 1) | Odwrócone kategorie (slajd 2) | Odwrócone wartości (slajd 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| Kategorie rosną od dołu do góry; wartości rosną od lewej do prawej. | Planowanie, Rozwój i Testowanie rosną od góry do dołu. Wartości i kolejność wierszy skoroszytu pozostają niezmienione. | Kategorie zachowują normalną kolejność; wartości rosną od prawej do lewej. Oś kategorii przecina się w zerze po prawej stronie. |

## **Ukrycie osi pionowej wykresu liniowego**

Ustaw [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) na `False` dla osi pionowej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą osią pionową.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Ukrycie osi poziomej wykresu liniowego**

Ustaw [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) na `False` dla osi poziomej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą osią poziomą.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmiana osi kategorii**

Ustaw [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) aby wybrać oś dat lub tekstową. Ten przykład wymaga pliku `ExistingChart.pptx`, w którym wykres jest pierwszym kształtem na pierwszym slajdzie, a komórki kategorii zawierają numeryczne wartości dat Excel. Zmienia on oś poziomą na oś dat. Ustawienie [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) na `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) na `1` oraz [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) na miesiące umieszcza główne podziały w odstępach jednog miesięcznych.

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

## **Kontrola interwałów etykiet osi kategorii**

Kiedy wykres ma wiele kategorii, można zmniejszyć liczbę widocznych etykiet osi bez usuwania kategorii ani punktów danych. Ustaw [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) na `False`, a następnie [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) na żądany interwał kategorii. Dla tekstowych kategorii w ich normalnym porządku liczenie zaczyna się od pierwszej kategorii:

| Interwał | Etykiety wyświetlane w przykładzie |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Interwał `3` wyświetla co trzecią etykietę, ukrywając dwie etykiety pomiędzy wyświetlanymi. Nie usuwa to odpowiadających kolumn. Automatyczne rozmieszczenie wybiera interwał na podstawie dostępnego miejsca; nie musi wyświetlać każdej etykiety.

Znaczniki podziałek mają oddzielne sterowanie. Ustaw [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) na `False` i użyj [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) do ustawienia ich interwału. Na przykład `1` pozostawia znacznik podziałki przy każdym odstępie kategorii, podczas gdy etykiety pojawiają się co trzecią kategorię. Ustaw [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) na widoczny styl, aby zobaczyć rezultat. Przywrócenie dowolnej właściwości automatycznego rozmieszczenia do `True` pozwala wykresowi ponownie wybrać interwał.

Poniższy, samodzielny przykład tworzy 24 kategorie i jedną serię, a następnie zapisuje trzy slajdy w pliku `CategoryAxisIntervals.pptx`: automatyczne rozmieszczenie, ręczne rozmieszczenie etykiet przy niezależnych znacznikach podziałek oraz przywrócone automatyczne rozmieszczenie. Dwie kopie zachowują oryginalne dane wykresu. Nie jest wymagana żadna prezentacja wejściowa. Tekst etykiet poziomych ułatwia ocenę gęstości.

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

    # Slajd 2: pokaż co trzecią etykietę, ale zachowaj znacznik podziałki dla każdej kategorii.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Slajd 3: niech wykres ponownie wybierze oba interwały.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatyczne rozmieszczenie (slajd 1):** W tym renderingu co druga etykieta kategorii jest wyświetlana i łamie się na dwie linie. Automatyczny wynik może się różnić w zależności od rozmiaru wykresu, czcionek i renderera.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Ręczne rozmieszczenie (slajd 2):** Co trzecia etykieta jest wyświetlana w jednej linii, podczas gdy znaczniki podziałek pozostają przy każdym odstępie kategorii. Wszystkie 24 kolumny, w tym te bez etykiet, pozostają widoczne z tymi samymi wartościami. Slajd 3 przywraca automatyczny wygląd pokazany powyżej.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Wybierz właściwą oś i interwał**

Użyj tego interwału liczby kategorii dla tekstowej osi kategorii, takiej jak oś kategorii wykresu kolumnowego, liniowego, obszarowego lub słupkowego. W wykresie kolumnowym jest to oś pozioma. W wykresie słupkowym poziomym oś kategorii jest pionowa, więc zastosuj te ustawienia do [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Rozstawienie znaczników podziałek ma również zastosowanie do osi serii w wykresach, które ją posiadają.

Nie używaj rozmieszczenia etykiet kategorii do ustawiania numerycznej skali osi wartości. Na osi wartości [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) określa różnicę wartości: na przykład jednostka główna `10` tworzy znaczniki przy 0, 10, 20 itd., gdy oś zaczyna się od zera. Interwał etykiet kategorii `3` liczy pozycje kategorii, niezależnie od ich wartości danych. Wykresy rozproszenia i bąbelkowe używają osi wartości, a nie tekstowej osi kategorii. Dla osi dat używaj jednostek czasu i skali opisanych w sekcji [Zmiana osi kategorii](#zmiana-osi-kategorii).

## **Ustaw format daty dla wartości osi kategorii**

Przykład zastępuje domyślne dane wykresu czterema rocznymi wartościami. Daty są przechowywane jako liczby seryjne OLE Automation w pierwszym arkuszu (indeks `0`). Ustaw [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) na oś dat, wyłącz [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) i przypisz `yyyy` do [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/), aby etykiety kategorii wyświetlały czterocyfrowe lata niezależnie od formatowania komórek.

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

Włącz [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) na osi pionowej, podaj tekst tytułu i ustaw [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) aby obrócić tytuł. Kąt podawany jest w stopniach; przykład zapisuje wykres kolumnowy z tytułem osi wartości obróconym o 90 stopni.

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

Użyj [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) aby kontrolować, czy oś wartości przecina oś kategorii pomiędzy kategoriami, czy na znacznikach kategorii. Właść­wość ta dotyczy osi kategorii. Przykład ustawia ją na `True` na poziomej osi kategorii wykresu kolumnowego i zapisuje wynik.

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

Ustaw [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) aby skalować etykiety na osi wartości bez zmiany danych podstawowych. Przy [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) ustawionym na `MILLIONS`, wartość 60 000 000 jest wyświetlana jako 60. Przykład tworzy wykres kolumnowy i stosuje jednostkę wyświetlania „miliony” do jego osi pionowej.

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

Logarytmiczna oś wartości jest przydatna, gdy dodatnie wartości obejmują wiele rzędów wielkości. Na przykład serwis może otrzymywać 10, 100, 1 000, 10 000 i 100 000 żądań w pięciu okresach. Na skali liniowej mniejsze wartości znajdują się blisko siebie przy zerze. Skala logarytmiczna ułatwia porównanie ich względnego wzrostu: równe odległości reprezentują równe stosunki, a nie równe różnice.

Ustaw [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) na `True` dla osi wartości i użyj [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) aby wybrać podstawę. Zmienia to sposób wyświetlania istniejących wartości; nie zmienia danych ani nie dodaje linii trendu logarytmicznego. Linia trendu jest odrębną funkcją.

### **Wybierz oś wartości i podstawę**

Dla wykresu liniowego lub kolumnowego oś wartości to [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Dla wykresu słupkowego poziomego to [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Wykresy rozproszenia i bąbelkowe mają dwie osie wartości, więc wybierz oś poziomą dla wartości X, oś pionową dla Y lub obie. Nie stosuj skalowania logarytmicznego do osi kategorii.

Domyślna podstawa logarytmu to `10`. Dla wykresów PPTX podstawa może wynosić od `2` do `1000` włącznie; obsługiwane są także ułamkowe podstawy, takie jak `2.5`. Przy podstawie `10` kolejne potęgi (10, 100, 1 000, 10 000) są równomiernie rozmieszczone.

### **Porównanie skali liniowej i logarytmicznej**

Poniższy, samodzielny przykład tworzy wykres liniowy z pięcioma liczbami żądań na pierwszym slajdzie, a następnie klonuje ten slajd i włącza logarytmiczną oś wartości o podstawie 10 na drugim. Oba slajdy zachowują te same dane.

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

    # Zachowaj pierwszy slajd w skali liniowej i zmień tylko skalę osi wartości w kopii.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Skala liniowa (slajd 1):** Równe odległości pionowe oznaczają równe różnice w liczbie żądań. Największa wartość dominuje wykres, utrudniając rozróżnienie mniejszych wartości.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Skala logarytmiczna (slajd 2):** Równe odległości pionowe oznaczają równe stosunki. Każdy okres ma dziesięć razy więcej żądań niż poprzedni, więc punkty tworzą prostą rosnącą linię na skali logarytmicznej o podstawie 10. Etykiety osi wciąż pokazują oryginalne liczby żądań.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Obsługa zer i wartości ujemnych**

Skala logarytmiczna może wyświetlać wyłącznie wartości ściśle dodatnie. Sprawdź dane przed jej włączeniem. Jeśli zero lub wartości ujemne mają znaczenie, pozostaw skalę liniową lub pokaż je osobno. Jeśli ich pominięcie jest uzasadnione, wyjaśnij przyczynę. Nie zastępuj ich cicho małymi liczbami dodatnimi, ponieważ zmienia to znaczenie danych. Każde ręcznie skonfigurowane minimum lub maksimum osi logarytmicznej musi być również dodatnie.

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Użyj [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) aby wybrać zachowanie przecięcia. Aby podać liczbową wartość przecięcia, ustaw [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Te ustawienia pozwalają przenieść przecięcie osi do odpowiedniej linii bazowej.

**Jak mogę pozycjonować etykiety znaczników względem osi?**

Ustaw [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) używając [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` lub `NONE`. Aby kontrolować same znaczniki podziałek, użyj [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) lub [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); są one oddzielne od pozycjonowania etykiet.