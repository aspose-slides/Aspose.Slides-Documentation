---
title: Zarządzanie seriami danych wykresu w prezentacjach w Pythonie
linktitle: Serie danych
type: docs
url: /pl/python-java/chart-series/
keywords:
- serie wykresu
- nakładanie serii
- kolor serii
- nazwa serii
- punkt danych
- komórka skoroszytu
- przerwa serii
- wartość ujemna
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem, szerokością przerwy oraz wartościami ujemnymi w prezentacjach przy użyciu Aspose.Slides dla Pythona w środowisku Java."
---
## **Przegląd**

Wykres przechowuje swoje wykreślone dane w skoroszycie danych wykresu. **ChartSeries** reprezentuje jeden zestaw powiązanych wartości, a każdy **ChartDataPoint** w serii odnosi się do jednej lub kilku komórek skoroszytu. Obiekty **ChartCategory** dostarczają etykiety lub wartości grupujące współdzielone przez serie. Nazwa serii, kategorie i wartości punktów są więc powiązane z obiektami **ChartDataCell**, a nie przechowywane wyłącznie jako tekst wyświetlany.

Dla typowego wykresu kategorialnego domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii oraz pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumn przekazywane do **ChartDataWorkbook.getCell** są zerowe. Takie ułożenie jest przydatne przy tworzeniu wykresu z danymi domyślnymi, ale nie należy zakładać, że każdy istniejący wykres używa go. Dla załadowanej prezentacji sprawdź komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak **ChartSeries.getFormat**, określają domyślny wygląd wszystkich punktów w jednej serii.
- Ustawienia punktu danych, takie jak **ChartDataPoint.getFormat**, nadpisują wygląd serii dla jednego punktu.
- Ustawienia grupy dotyczą zgodnych serii należących do tego samego **ChartSeriesGroup**. Dostęp do grupy uzyskuje się przez **ChartSeries.getParentSeriesGroup**, gdy trzeba ustawić opcje takie jak nakładanie lub szerokość przerwy.

Gdy nie jest ustawione wyraźne wypełnienie punktu lub serii, styl i motyw wykresu określają automatyczny wygląd. Gdy obecne są zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw nakładanie serii wykresu**

**ChartSeries.getOverlap** podaje, jak bardzo słupki lub kolumny nachodzą na siebie w wykresie 2 D, w przedziale od ‑100 do 100 procent. Jest to odczytowa projekcja ustawienia w grupie nadrzędnej serii. Użyj **ChartSeriesGroup.setOverlap**, aby zaktualizować wszystkie zgodne serie w tej grupie. Opcja ta ma zastosowanie do typów wykresów wyświetlających grupowane słupki lub kolumny; nie wpływa na niepowiązane grupy serii w wykresie kombinowanym.

Poniższy przykład ustawia nakładanie dla grupy zawierającej pierwszą serię:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Nowy wykres zawiera przykładowe serie, kategorie i wartości.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![The series overlap](series_overlap.png)

## **Zmień kolor wypełnienia serii**

Użyj **ChartSeries.getFormat**, aby ustawić domyślne wypełnienie dla całej serii. Jeśli punkt ma już wyraźne wypełnienie, jego ustawienie **ChartDataPoint.getFormat** nadpisuje wypełnienie serii dla tego punktu.

Poniższy przykład stosuje jednolite niebieskie wypełnienie do pierwszej serii:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![The color of the series](series_color.png)

## **Zmień nazwę serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zwykle wyświetlana w legendzie. W domyślnym skoroszycie utworzonym dla wykresu kolumnowego grupowanego komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Zmienna w poniższym przykładzie wyraźnie określa tę strukturę:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Możesz także zaktualizować komórkę już odwoływaną przez **ChartSeries.getName**. Takie podejście unika założenia określonego wiersza i kolumny w istniejącym wykresie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![The series name](series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

**ChartSeries.getAutomaticSeriesColor** zwraca kolor wyliczony na podstawie indeksu serii i stylu wykresu. Jest to kolor używany, gdy wypełnienie serii nie zostało jawnie określone. Wywołanie metody odczytuje wyliczony kolor; nie przypisuje nowego wypełnienia.

Poniższy przykład wypisuje automatyczny kolor każdej domyślnej serii:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Przykładowe wyjście dla domyślnego stylu wykresu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Dokładne kolory zależą od stylu i motywu wykresu.

## **Ustaw odwrócony kolor wypełnienia dla serii wykresu**

Dla serii słupkowych, kolumnowych i bąbelkowych **ChartSeries.setInvertIfNegative** może wyświetlać wartości ujemne innym wypełnieniem. Ustaw regularne wypełnienie serii na jednolite, włącz odwracanie i przypisz kolor wartości ujemnej przez **ChartSeries.getInvertedSolidFillColor**. Liczby ujemne pozostają niezmienione w skoroszycie; zmienia się jedynie ich kolor wyświetlania.

Poniższy przykład zastępuje domyślne dane wykresu jedną serią. Wiersz 0 arkusza zawiera nazwę serii, kolumna 0 – nazwy kategorii, kolumna 1 – wartości:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![The inverted solid fill color](inverted_solid_fill_color.png)

Odwrócenie można włączyć dla jednego punktu za pomocą **ChartDataPoint.setInvertIfNegative**. W poniższym przykładzie odwracanie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punkt otrzymuje także wartość ujemną, aby efekt był widoczny:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wyczyść konkretną wartość punktu danych**

Aby uczynić jeden punkt pustym bez usuwania pozostałych, ustaw jego komórkę w skoroszycie na `None`. Dla wykresu kolumnowego wyświetlana wartość jest dostępna przez **ChartDataPoint.getValue**. Punkt pozostaje na tej samej pozycji kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

Poniższy przykład czyści tylko drugi punkt w pierwszej serii:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wykresy rozrzutu używają osobnych komórek X i Y, a wykresy bąbelkowe dodatkowo komórki rozmiaru. Czyść tylko komórkę, która reprezentuje wartość, którą chcesz usunąć. Nie wywołuj **ChartDataPointCollection.clear**, gdy chcesz zachować pozostałe punkty, ponieważ metoda ta usuwa wszystkie punkty z kolekcji.

## **Kontroluj wyświetlanie pustych komórek**

Pusta komórka skoroszytu oznacza brak danych; komórka zawierająca `0` oznacza znaną wartość liczbową. Wywołaj **ChartDataCell.setValue** z `None`, aby uczynić komórkę pustą. Zero liczbowe pozostaje zerem, niezależnie od ustawienia pustej komórki.

Użyj **Chart.setDisplayBlanksAs**, aby wybrać sposób wyświetlania pustych komórek przez wykres. Ustawienie to ma zastosowanie do całego wykresu. Zmienia sposób rysowania luk, nie wypełniając pustej komórki zerem ani interpolowaną wartością.

Poniższy samodzielny przykład tworzy wykres liniowy z jedną serią, czyści wartość dla Dnia 3 i zapisuje wykres w trzech trybach. Nie wymaga pliku wejściowego. **ChartDataWorkbook** używa arkusza 0, kolumny 0 dla etykiet kategorii i kolumny 1 dla wartości; wiersz 0 zawiera nazwę serii. Ostateczne dane to `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Pozostaw dzień 3 naprawdę pusty, zachowując jego kategorię i punkt danych.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Każdy plik wynikowy przechowuje tryb przypisany przed zapisem: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` i `empty_cells_Span.pptx`. Aby zapisać tylko jedną wersję, przypisz żądany tryb i zapisz prezentację raz, zamiast iterować po trybach.

Poniższe porównanie pokazuje te same dane w trzech plikach. Dzień 3 jest pusty w skoroszycie we wszystkich przypadkach:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Widoczny efekt zależy od typu wykresu. Wykres liniowy umożliwia łatwe porównanie wszystkich trzech trybów. Wykresy słupkowe i kolumnowe nie mają linii łączącej brakującą kategorię, więc **Span** nie może utworzyć pokazanego segmentu; brakująca kolumna i kolumna o wysokości zerowej mogą wyglądać podobnie. Podobnie wykres rozrzutu z samymi znacznikami nie ma linii łączącej. Nie oczekuj trzech odrębnych wyników dla każdego typu wykresu; sprawdź wynik dla używanego typu.

## **Ustaw szerokość przerwy serii**

Szerokość przerwy to odstęp między sąsiednimi klastrami słupków lub kolumn, wyrażony jako procent szerokości słupka lub kolumny. Podobnie jak nakładanie, należy do grupy nadrzędnej serii, a nie do jednej serii. Wywołaj **ChartSeriesGroup.setGapWidth** raz dla grupy. Większa wartość tworzy większy odstęp między klastrami; mniejsza – zagęszcza je.

Poniższy przykład zmienia szerokość przerwy i zapisuje tylko ostateczną prezentację:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![The gap width](gap_width.png)

## **FAQ**

**Które typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane przez wyliczenie **ChartType** używają danych wykresu, ale ich serie nie mają takiej samej struktury wartości ani ustawień. Na przykład wykresy kategorialne używają kategorii i wartości, wykresy rozrzutu – wartości X i Y, a wykresy bąbelkowe dodatkowo rozmiary bąbelków. Użyj metody tworzenia punktu danych, która odpowiada typowi serii. Opcje takie jak nakładanie i szerokość przerwy mają zastosowanie tylko do zgodnych grup słupków lub kolumn.

** czym jest grupa serii wykresu?**

**ChartSeriesGroup** zawiera zgodne serie, które współdzielą ustawienia poziomu grupy. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy uzyskanej przez jedną serię niekoniecznie zmieni wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera domyślne dane?**

Tak. Domyślnie **ShapeCollection.addChart** tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub usunąć zarówno kolekcje serii, jak i kategorii przed dodaniem całkowicie własnego zestawu danych. Przeciążenie może także utworzyć wykres bez danych domyślnych.

**Jak obiekty wykresu są powiązane z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w **ChartDataWorkbook**. Zmiana odwołanej komórki aktualizuje odpowiadający element wykresu. Tworząc własne dane, zachowaj wyrównanie wierszy kategorii i wierszy wartości serii, aby każdy punkt był wykreślony pod właściwą kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `None`, aby zachować pozycję kategorii punktu jako pusty punkt. Używaj **ChartDataPointCollection.clear** tylko wtedy, gdy zamierzasz usunąć wszystkie punkty z tej serii. Jeśli usuwasz także kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu i ustawienia wybranego w **Chart.setDisplayBlanksAs**. Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zerowe lub łącząc sąsiednie punkty. Wybierz ustawienie odpowiadające znaczeniu brakujących danych w prezentacji. Zobacz **Kontroluj wyświetlanie pustych komórek** po kompletny przykład i porównanie wizualne.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj **ChartSeries.setInvertIfNegative** i ustaw kolor zwrócony przez **ChartSeries.getInvertedSolidFillColor**. Zachowanie można nadpisać dla pojedynczego punktu przy pomocy **ChartDataPoint.setInvertIfNegative**. Metody te wpływają na formatowanie, a nie na przechowywane wartości liczbowe.

**Które formatowanie wygrywa, gdy zarówno seria, jak i punkt są sformatowane?**

Jawne formatowanie punktu ma pierwszeństwo dla tego punktu. Inne punkty nadal używają wyraźnego formatu serii lub, gdy format serii nie jest zdefiniowany, automatycznego stylu i motywu wykresu. Ustawienia grupy, takie jak nakładanie i szerokość przerwy, kontrolują układ i nie są nadpisaniami formatowania na poziomie punktu.

**Czy istnieje limit liczby serii w wykresie?**

Aspose.Slides nie narzuca oddzielnego stałego limitu liczby serii. W praktyce ograniczenia wynikają z ograniczeń pliku prezentacji, dostępnej pamięci, czasu renderowania oraz czytelności wykresu.

**Co zmienić, gdy kolumny są zbyt blisko siebie lub zbyt daleko od siebie?**

Wywołaj **ChartSeriesGroup.setGapWidth** na odpowiedniej grupie nadrzędnej serii. Zwiększ wartość, aby poszerzyć odstęp między klastrami, lub zmniejsz, aby przybliżyć je do siebie.