---
title: Dostosowywanie osi wykresów w prezentacjach przy użyciu Pythona
linktitle: Oś wykresu
type: docs
url: /pl/python-net/chart-axis/
keywords:
- oś wykresu
- oś pionowa
- oś pozioma
- dostosowanie osi
- manipulacja osi
- zarządzanie osiami
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
description: "Dowiedz się, jak używać Aspose.Slides dla Pythona via .NET, aby dostosować osie wykresów w prezentacjach PowerPoint i OpenDocument do raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresów przy użyciu Aspose.Slides dla Pythona via .NET. Obejmuje on obliczane wartości osi, zamianę wierszy i kolumn wykresu, widoczność osi, interwały etykiet kategorii i znaczników podziałek, kategorie dat i formatowanie, obrót tytułu, pozycjonowanie osi, jednostki wyświetlania oraz skalowanie logarytmiczne.

## **Uzyskanie maksymalnych wartości na osi pionowej wykresów**

Utwórz [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) i dodaj wykres obszarowy z domyślnymi danymi. Wywołaj [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) przed odczytaniem obliczonych wartości osi, aby układ wykresu był aktualny.

Odczytaj [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) i [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) dla limitów osi oraz [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) i [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) dla odstępów podziałek. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) i [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) dostarczają skal jednostek czasu, które są istotne dla osi dat. Przykład przechowuje te wartości w zmiennych lokalnych i zapisuje wykres.

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

Użyj [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) , aby wymienić role serii i kategorii w danych wykresu. Każda była kategoria staje się serią, a każda była seria staje się kategorią. Zmienia to sposób grupowania danych; nie zamienia to osi poziomej i pionowej. Przykład używa [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) , aby powiązać domyślne dane z `Sheet1!A1:D5`, włączając wiersz nagłówka i kolumnę kategorii, przed zamianą wierszy i kolumn. Zapisuje wykres z czterema seriami i trzema kategoriami.

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

Użyj [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) , aby odwrócić oś kategorii lub wartości. Na przykład wykres słupkowy poziomy może wyświetlać etapy projektu od góry do dołu w takiej samej kolejności jak w arkuszu: Planowanie, Rozwój, Testowanie. Odwrócenie osi zmienia kierunek rysowania; nie sortuje ani nie przestawia danych w skoroszycie. Dla porównania, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) wymienia role serii i kategorii.

Następujący przykład tworzy wykres słupkowy poziomy z trzema etapami i jedną serią. Zapisuje prezentację z trzema slajdami: normalna kolejność, odwrócone kategorie i odwrócone wartości. Każda kopia używa tego samego zestawu danych, a na każdej odwrócona jest tylko jedna oś.

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

    # Slajd 2: wyświetl pierwszą kategorię u góry.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Utrzymaj poziomą oś wartości na dole.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Slajd 3: odwróć tylko poziomą skalę liczbową.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Odwrócenie osi może także przenieść oś prostopadłą na przeciwległą stronę wykresu. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) kontroluje, gdzie druga oś przecina konfigurowaną oś. Na slajdzie 2 ustawienie jej na `MAXIMUM` na odwróconej osi kategorii utrzymuje poziomą oś wartości u dołu. Aby ustawić konkretny punkt przecięcia, użyj [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Sprawdź ustawienia przecięcia przy zmianie kierunku, szczególnie jeśli wykres ma już niestandardowy punkt przecięcia. Ustaw `is_plot_order_reversed` z powrotem na `False`, aby przywrócić normalny kierunek rysowania; ustawienia przecięcia są oddzielne.

| Normalna kolejność (slajd 1) | Odwrócone kategorie (slajd 2) | Odwrócone wartości (slajd 3) |
| --- | --- | --- |
| ![Wykres słupkowy poziomy z normalnym porządkiem osi kategorii i wartości](axis-order-normal.png) | ![Wykres słupkowy poziomy z kategoriami wyświetlanymi od góry do dołu](axis-order-categories-reversed.png) | ![Wykres słupkowy poziomy z odwróconą osią wartości i zerem po prawej](axis-order-values-reversed.png) |
| Kategorie rosną od dołu do góry; wartości rosną od lewej do prawej. | Planowanie, Rozwój i Testowanie przebiegają od góry do dołu. Wartości i kolejność wierszy w skoroszycie pozostają niezmienione. | Kategorie zachowują swój normalny porządek; wartości rosną od prawej do lewej. Oś kategorii przecina zero po prawej stronie. |

## **Ukrycie osi pionowej w wykresach liniowych**

Ustaw [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) na `False` na osi pionowej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą osią pionową.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Ukrycie osi poziomej w wykresach liniowych**

Ustaw [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) na `False` na osi poziomej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą osią poziomą.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Pokaż lub ukryj linie siatki wykresu**

Odczytaj [show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) i [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) , aby sprawdzić, które linie siatki wyświetla oś. Obie właściwości są tylko do odczytu. Aby wyświetlić drobne linie siatki, ustaw wypełnienie linii w [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) na jednolite i wybierz widoczny kolor. Aby je ukryć, ustaw typ wypełnienia na `FillType.NO_FILL`. Dla głównych linii siatki użyj [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format`. Zmiana wypełnienia zachowuje widoczność osi i znaczniki podziałek.

Oś pionowa tego skumulowanego wykresu słupkowego zaczyna się z widocznymi głównymi liniami siatki i ukrytymi drobnymi liniami siatki. Przykład najpierw pokazuje drobne linie siatki w pomarańczowym kolorze, a następnie je ponownie ukrywa przed zapisaniem prezentacji.

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

| Drobne linie siatki włączone | Drobne linie siatki ukryte |
| --- | --- |
| ![Pomarańczowe drobne linie siatki pomiędzy głównymi liniami siatki na osi pionowej](minor-gridlines-enabled.png) | ![Ten sam wykres słupkowy z widocznymi tylko głównymi liniami siatki](minor-gridlines-hidden.png) |

## **Zmiana osi kategorii**

Ustaw [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) , aby wybrać oś kategorii daty lub tekstu. Ten przykład wymaga pliku `ExistingChart.pptx`, z wykresem jako pierwszym kształtem na pierwszym slajdzie oraz komórkami kategorii zawierającymi numeryczne wartości dat Excel. Zmienia on oś poziomą na oś datową. Ustawienie [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) na `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) na `1` i [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) na miesiące umieszcza główne podziały w odstępach jednomiesięcznych.

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

### **Określenie typu osi kategorii na podstawie danych**

Wywołaj [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/) po wypełnieniu kategorii, a następnie odczytaj [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) , aby sprawdzić wybór. Jest to przydatne, gdy ten sam wykres otrzymuje zarówno etykiety tekstowe, jak i numeryczne wartości dat. Metoda określa typ w momencie wywołania; nie włącza trybu trwałego, który ponownie ocenia późniejsze zmiany danych. Wywołaj ją ponownie po zastąpieniu kategorii.

Następujący przykład tworzy wykres z kategoriami tekstowymi i wypisuje `TEXT`. Następnie zastępuje wartości komórek kategorii datami i ponownie wywołuje metodę, która wypisuje `DATE`. Daty są przechowywane jako numeryczne wartości OLE Automation, obliczane jako liczba dni od 30 grudnia 1899, a nie jako ciągi znaków dat. [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) kontroluje sposób wyświetlania tych wartości; nie konwertuje tekstu na numeryczne daty. Więcej o komórkach kategorii znajdziesz w [Chart Workbook](/slides/pl/python-net/chart-workbook/).

Używaj automatycznego określania, gdy wiadomo, że dane wejściowe zawierają kategorie tekstowe lub numeryczne daty, tak jak w tym przykładzie. Dla zwykłych etykiet liczbowych, mieszanych kategorii lub pustych danych, jawnie ustaw [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) , aby dopasować do zamierzonego znaczenia. Same wartości liczbowe nie dowodzą, że kategorie reprezentują daty.

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
    print(axis.category_axis_type.name)  # DATA

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Sterowanie interwałami etykiet osi kategorii**

Gdy wykres ma wiele kategorii, zmniejsz liczbę widocznych etykiet osi bez usuwania kategorii lub punktów danych. Ustaw [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) na `False`, a następnie ustaw [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) na żądany interwał kategorii. Dla tekstowych kategorii w ich normalnej kolejności liczenie zaczyna się od pierwszej kategorii:

| Interwał | Etykiety wyświetlane w przykładzie |
| --- | --- |
| `1` | Kategoria 1, Kategoria 2, Kategoria 3, ... Kategoria 24 |
| `2` | Kategoria 1, Kategoria 3, Kategoria 5, ... Kategoria 23 |
| `3` | Kategoria 1, Kategoria 4, Kategoria 7, ... Kategoria 22 |

Interwał `3` wyświetla każdą trzecią etykietę, ukrywając dwie etykiety pomiędzy wyświetlanymi. Nie usuwa to odpowiadających kolumn. Automatyczne rozmieszczanie wybiera interwał w zależności od dostępnej przestrzeni; nie musi wyświetlać każdej etykiety.

Znaczniki podziałek mają oddzielne sterowanie. Ustaw [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) na `False` i użyj [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) , aby ustawić ich interwał. Na przykład `1` utrzymuje znacznik podziałki przy każdym interwale kategorii, podczas gdy etykiety pojawiają się tylko co trzecią kategorię. Ustaw [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) na widoczny styl, aby zobaczyć rezultat. Ustawienie dowolnej z właściwości automatycznego rozmieszczania z powrotem na `True` pozwala wykresowi ponownie wybrać ten interwał.

Następujący samodzielny przykład tworzy 24 kategorie i jedną serię, a następnie zapisuje trzy slajdy w pliku `CategoryAxisIntervals.pptx`: automatyczne rozmieszczanie, ręczne rozmieszczanie etykiet z niezależnymi znacznikami podziałek oraz przywrócone automatyczne rozmieszczanie. Dwie kopie zachowują oryginalne dane wykresu. Nie wymaga żadnej prezentacji wejściowej. Poziomy tekst etykiet ułatwia dostrzeżenie różnicy w gęstości.

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

    # Slajd 2: pokaż każdą trzecią etykietę, ale zachowaj znacznik podziałki dla każdej kategorii.
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

**Automatyczne rozmieszczanie (slajd 1):** W tym renderowaniu każda druga etykieta kategorii jest wyświetlana i łamie się na dwie linie. Wynik automatyczny może się różnić w zależności od rozmiaru wykresu, czcionek i renderera.

![Automatyczne rozmieszczanie etykiet kategorii przy widocznych wszystkich 24 kolumnach](category-axis-automatic.png)

**Ręczne rozmieszczanie (slajd 2):** Każda trzecia etykieta jest wyświetlana w jednej linii, podczas gdy znaczniki podziałek pozostają przy każdym interwale kategorii. Wszystkie 24 kolumny, w tym te bez etykiet, pozostają widoczne z tymi samymi wartościami. Slajd 3 przywraca automatyczny wygląd pokazany powyżej.

![Ręczny interwał etykiet kategorii równy trzem przy widocznych wszystkich 24 kolumnach](category-axis-manual.png)

### **Wybór właściwej osi i interwału**

Użyj tego interwału liczby kategorii dla tekstowej osi kategorii, takiej jak oś kategorii wykresu kolumnowego, liniowego, powierzchniowego lub słupkowego. W wykresie kolumnowym jest to oś pozioma. W wykresie słupkowym poziomym oś kategorii jest pionowa, więc zastosuj te ustawienia do [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Odstępy znaczników podziałek mają także zastosowanie do osi serii w wykresach, które ją posiadają.

Nie używaj rozmieszczania etykiet kategorii do ustawiania skali numerycznej osi wartości. Na osi wartości [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) określa różnicę wartości: na przykład główna jednostka `10` tworzy podziały przy 0, 10, 20 itd., gdy oś zaczyna się od zera. Interwał etykiet kategorii `3` liczy pozycje kategorii, niezależnie od ich wartości danych. Wykresy punktowe i bąbelkowe używają osi wartości zamiast osi kategorii tekstowej. Dla osi dat użyj jednostek i skal czasowych opisanych w [Change a Category Axis](#change-a-category-axis).

## **Ustaw format daty dla wartości osi kategorii**

Przykład zastępuje domyślne dane wykresu czterema rocznymi wartościami. Daty są przechowywane jako liczby seryjne OLE Automation w pierwszym arkuszu (indeks `0`). Ustaw [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) na oś dat, wyłącz [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) , i przypisz `yyyy` do [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) , aby etykiety kategorii wyświetlały czterocyfrowe lata niezależnie od formatowania komórek.

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

Włącz [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) na osi pionowej, podaj tekst tytułu i ustaw [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) , aby obrócić tytuł. Kąt jest mierzony w stopniach; ten przykład zapisuje wykres kolumnowy z tytułem osi wartości obróconym o 90 stopni.

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

Użyj [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) , aby kontrolować, czy oś wartości przecina oś kategorii pomiędzy kategoriami czy na znacznikach podziałek kategorii. Ta właściwość dotyczy osi kategorii. Przykład ustawia ją na `True` na poziomej osi kategorii wykresu kolumnowego i zapisuje wynik.

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

Ustaw [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) , aby skalować etykiety na osi wartości bez zmiany danych podstawowych. Przy ustawieniu [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) na `MILLIONS` , wartość 60 000 000 jest wyświetlana jako 60. Przykład tworzy wykres kolumnowy i stosuje jednostkę wyświetlania milionów do jego osi pionowej.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Konfiguracja logarytmicznej osi wartości**

Logarytmiczna oś wartości jest przydatna, gdy dodatnie wartości rozciągają się na kilka rzędów wielkości. Na przykład usługa może otrzymywać 10, 100, 1 000, 10 000 i 100 000 żądań w ciągu pięciu okresów. Na skali liniowej mniejsze wartości znajdują się blisko siebie w pobliżu zera. Skala logarytmiczna ułatwia porównanie ich względnego wzrostu: równe odległości reprezentują równe proporcje, a nie równe różnice.

Ustaw [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) na `True` na osi wartości i użyj [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) , aby wybrać podstawę. To zmienia sposób wyświetlania istniejących wartości; nie zmienia danych ani nie dodaje logarytmicznej linii trendu. Linia trendu reprezentuje dopasowaną zależność w danych i jest odrębną funkcją.

### **Wybór osi wartości i podstawy**

Dla wykresu liniowego lub kolumnowego oś wartości to [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Dla wykresu słupkowego poziomego jest to [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Wykresy punktowe i bąbelkowe mają dwie osie wartości, więc wybierz oś poziomą dla wartości X, oś pionową dla wartości Y lub obie. Nie stosuj skalowania logarytmicznego do osi kategorii.

Domyślna podstawa logarytmu to `10`. Dla wykresów PPTX użyj podstawy od `2` do `1000` włącznie; obsługiwane są także podstawy ułamkowe, takie jak `2.5`. Przy podstawie `10` kolejne potęgi, takie jak 10, 100, 1 000 i 10 000, są rozmieszczone równomiernie.

### **Porównanie skalowania liniowego i logarytmicznego**

Następujący samodzielny przykład tworzy wykres liniowy z pięcioma liczbami żądań na pierwszym slajdzie, a następnie klonuje ten slajd i włącza logarytmiczną oś wartości o podstawie 10 na drugim. Oba slajdy zachowują te same dane.

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

    # Utrzymaj pierwszy slajd liniowy i zmień tylko skalę osi wartości w kopii.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Skala liniowa (slajd 1):** Równe odległości pionowe reprezentują równe różnice w liczbie żądań. Największa wartość dominuje wykres, utrudniając rozróżnienie mniejszych wartości.

![Wykres liniowy w PowerPoint pokazujący pięć liczb żądań na liniowej osi wartości](value-axis-linear.png)

**Skala logarytmiczna (slajd 2):** Równe odległości pionowe reprezentują równe proporcje. Każdy okres ma dziesięciokrotnie większą liczbę żądań niż poprzedni, więc punkty tworzą prostą rosnącą linię na skali o podstawie 10. Etykiety osi nadal pokazują pierwotne liczby żądań.

![Te same pięć liczb żądań w PowerPoint na logarytmicznej osi wartości o podstawie 10](value-axis-logarithmic.png)

### **Obsługa zerowych i ujemnych wartości**

Skala logarytmiczna może wyświetlać wyłącznie wartości ściśle dodatnie. Sprawdź dane przed jej włączeniem. Jeśli wartości zero lub ujemne mają znaczenie, zachowaj skalę liniową lub pokaż je osobno. Jeśli wykluczenie tych wartości jest właściwe dla analizy, wyjaśnij pominięcie. Nie zamieniaj ich cicho na małe liczby dodatnie, ponieważ zmienia to znaczenie danych. Każde ręcznie ustawione minimum lub maksimum dla osi logarytmicznej musi również być dodatnie.

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Użyj [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) , aby wybrać zachowanie przecięcia. Aby określić numeryczną wartość przecięcia, ustaw [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) . Te ustawienia pozwalają przenieść przecięcie osi do odpowiedniej linii bazowej.

**Jak mogę pozycjonować etykiety podziałek względem osi?**

Ustaw [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) używając [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) : `LOW`, `HIGH`, `NEXT_TO` lub `NONE`. Aby sterować samymi znacznikami podziałek, użyj [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) lub [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) ; są one oddzielne od pozycjonowania etykiet.