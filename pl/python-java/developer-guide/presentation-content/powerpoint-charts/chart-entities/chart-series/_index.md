---
title: Zarządzanie seriami danych wykresu w prezentacjach w Pythonie
linktitle: Serie danych
type: docs
url: /pl/python-java/chart-series/
keywords:
- seria wykresu
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
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem, szerokością przerwy i wartościami ujemnymi w prezentacjach przy użyciu Aspose.Slides dla Pythona poprzez Javę."
---
## **Przegląd**

Wykres przechowuje swoje dane wykreślone w skoroszycie danych wykresu. [ChartSeries](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [ChartDataPoint](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/) w serii odnosi się do jednej lub kilku komórek skoroszytu. Obiekty [ChartCategory](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartcategory/) dostarczają etykiety lub wartości grupowania współdzielone przez serie. Nazwa serii, kategorie i wartości punktów są więc połączone z obiektami [ChartDataCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/), a nie przechowywane jedynie jako tekst wyświetlany.

Dla typowego wykresu kategorii domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii oraz pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#getCell) są zerowe. Ten układ jest przydatny, gdy tworzysz wykres z domyślnymi danymi, ale nie zakładaj, że każdy istniejący wykres go używa. Dla załadowanej prezentacji sprawdź komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak [ChartSeries.getFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getFormat), określają domyślny wygląd wszystkich punktów w jednej serii.
- Ustawienia punktu danych, takie jak [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#getFormat), nadpisują wygląd serii dla jednego punktu.
- Ustawienia grupy odnoszą się do kompatybilnych serii należących do tej samej [ChartSeriesGroup](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/). Uzyskaj dostęp do grupy przez [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getParentSeriesGroup), gdy potrzebujesz ustawić opcje takie jak nakładanie lub szerokość przerwy.

Gdy nie jest ustawione żadne wyraźne wypełnienie punktu ani serii, styl i motyw wykresu określają automatyczny wygląd. Gdy istnieje zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw nakładanie serii wykresu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getOverlap) informuje, w jakim stopniu słupki lub kolumny zachodzą na siebie w wykresie 2D, w zakresie od -100 do 100 procent. Jest to projekcja tylko do odczytu ustawienia w grupie serii nadrzędnej. Użyj [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#setOverlap), aby zaktualizować wszystkie kompatybilne serie w tej grupie. Opcja ta dotyczy typów wykresów wyświetlających grupowane słupki lub kolumny; nie wpływa na niepowiązane grupy serii w wykresie kombinowanym.

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

Użyj [ChartSeries.getFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getFormat), aby ustawić domyślne wypełnienie całej serii. Jeśli punkt już ma wyraźne wypełnienie, jego ustawienie [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#getFormat) nadpisuje wypełnienie serii dla tego punktu.

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

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zazwyczaj wyświetlana w legendzie. W domyślnym skoroszycie utworzonym dla wykresu słupkowego grupowanego, komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Zmienne nazwane w poniższym przykładzie wyraźnie odzwierciedlają tę strukturę:

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

Możesz także zaktualizować komórkę już odwoływaną przez [ChartSeries.getName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getName). Takie podejście unika zakładania konkretnego wiersza i kolumny w istniejącym wykresie:

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

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) zwraca kolor obliczony na podstawie indeksu serii i stylu wykresu. Jest to kolor używany, gdy wypełnienie serii nie zostało wyraźnie określone. Wywołanie metody odczytuje obliczony kolor; nie przypisuje nowego wypełnienia.

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

Dla serii słupkowych, kolumnowych i bąbelkowych, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#setInvertIfNegative) może wyświetlać wartości ujemne innym wypełnieniem. Ustaw regularne wypełnienie serii na jednolite, włącz odwrócenie i przypisz kolor wartości ujemnej przez [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Ujemne liczby pozostają niezmienione w skoroszycie; zmienia się tylko ich kolor wyświetlania.

Poniższy przykład zastępuje domyślne dane wykresu jedną serią. Wiersz 0 arkusza zawiera nazwę serii, kolumna 0 zawiera nazwy kategorii, a kolumna 1 zawiera wartości:

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

Możesz włączyć odwrócenie dla jednego punktu poprzez [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). W poniższym przykładzie odwrócenie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punktowi przypisano także wartość ujemną, aby efekt był widoczny:

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

Aby uczynić jeden punkt pustym bez usuwania pozostałych punktów, ustaw jego komórkę w skoroszycie na `None`. Dla wykresu kolumnowego wykreślona wartość jest dostępna przez [ChartDataPoint.getValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#getValue). Punkt danych pozostaje na tej samej pozycji kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

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

Wykresy punktowe (scatter) używają osobnych komórek X i Y, a wykresy bąbelkowe dodatkowo używają komórki rozmiaru. Czyść tylko komórkę, która reprezentuje wartość, którą chcesz usunąć. Nie wywołuj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapointcollection/#clear), gdy chcesz zachować pozostałe punkty, ponieważ metoda ta usuwa wszystkie punkty danych z kolekcji.

## **Kontroluj wyświetlanie pustych komórek**

Ukryte komórki zawierające wartości to odrębny przypadek od pustych komórek. Aby uwzględnić lub wykluczyć dane z ukrytych wierszy i kolumn arkusza, zobacz [Include Data from Hidden Rows and Columns](/slides/pl/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Pusta komórka skoroszytu reprezentuje brakujące dane; komórka zawierająca `0` reprezentuje znaną wartość liczbową. Wywołaj [ChartDataCell.setValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#setValue) z `None`, aby uczynić komórkę pustą. Liczbowe zero pozostaje zerem niezależnie od ustawienia pustych komórek.

Użyj [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#setDisplayBlanksAs), aby wybrać, jak wykres wyświetla puste komórki. To ustawienie ma zastosowanie do całego wykresu. Zmienia sposób, w jaki puste miejsca są wykreślane, bez wypełniania pustej komórki zerem lub interpolowaną wartością.

Poniższy, samodzielny przykład tworzy wykres liniowy z jedną serią, czyści wartość dla Dnia 3 i zapisuje ten sam wykres w każdym trybie. Plik wejściowy nie jest wymagany. [ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/) używa arkusza 0, kolumny 0 dla etykiet kategorii oraz kolumny 1 dla wartości; wiersz 0 zawiera nazwę serii. Końcowe dane to `10, 20, empty, 30, 40`.

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

    # Pozostaw Dzień 3 naprawdę pusty, zachowując jego kategorię i punkt danych.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Każdy plik wyjściowy przechowuje tryb przypisany przed zapisem: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` i `empty_cells_Span.pptx`. Aby zapisać tylko jedną wersję, ustaw żądany tryb i zapisz prezentację raz, zamiast iterować po trybach.

Poniższe porównanie pokazuje te same dane w trzech plikach. Dzień 3 jest pusty w skoroszycie w każdym przypadku:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Widoczny efekt zależy od typu wykresu. Wykres liniowy ułatwia porównanie wszystkich trzech trybów. Wykresy słupkowe i kolumnowe nie mają linii łączącej brakującą kategorię, więc `Span` nie może wygenerować segmentu połączenia pokazanego powyżej; brakująca kolumna i kolumna o wysokości zero mogą wyglądać podobnie. Podobnie wykres punktowy (scatter) z samymi znacznikami nie ma linii łączącej. Nie oczekuj trzech odrębnych wyników dla każdego typu wykresu; sprawdź rezultat dla wykorzystywanego typu.

## **Ustaw szerokość przerwy serii**

Szerokość przerwy to odległość między sąsiadującymi grupami słupków lub kolumn, wyrażona jako procent szerokości słupka lub kolumny. Podobnie jak nakładanie, należy do grupy serii nadrzędnej, a nie do jednej serii. Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#setGapWidth) raz dla grupy. Większa wartość tworzy więcej przestrzeni między grupami; mniejsza wartość sprawia, że są one bardziej zwarte.

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

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/) używają danych wykresu, ale ich serie nie zawsze mają taką samą strukturę wartości lub ustawienia. Na przykład wykresy kategorii używają kategorii i wartości, wykresy punktowe (scatter) używają wartości X i Y, a wykresy bąbelkowe dodają rozmiary bąbelków. Użyj metody tworzenia punktu danych pasującej do typu serii. Opcje takie jak nakładanie i szerokość przerwy mają zastosowanie tylko do kompatybilnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/) zawiera kompatybilne serie, które dzielą ustawienia wykreślania na poziomie grupy. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy uzyskanej przez jedną serię niekoniecznie zmieni wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera domyślne dane?**

Tak. Domyślnie [ShapeCollection.addChart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addChart) tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub wyczyścić zarówno kolekcje serii, jak i kategorii przed dodaniem całkowicie własnego zestawu danych. Przeciążenie może także utworzyć wykres bez danych domyślnych.

**Jak obiekty wykresu są połączone z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/). Zmiana odwoływanej komórki aktualizuje odpowiadający element wykresu. Budując własne dane, utrzymuj rzędy kategorii i rzędy wartości serii wyrównane, aby każdy punkt był wykreślony pod właściwą kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `None`, aby zachować pozycję kategorii punktu jako pusty punkt. Używaj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapointcollection/#clear) tylko wtedy, gdy zamierzasz usunąć wszystkie punkty z tej serii. Jeśli usuń także kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu i wartości skonfigurowanej przez [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#setDisplayBlanksAs). Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zero lub łącząc sąsiednie punkty. Wybierz ustawienie pasujące do znaczenia brakujących danych w Twojej prezentacji. Zobacz [Control the Display of Empty Cells](#control-the-display-of-empty-cells) po pełny przykład i porównanie wizualne.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#setInvertIfNegative) i ustaw kolor zwrócony przez [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Możesz nadpisać zachowanie dla pojedynczego punktu za pomocą [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Metody te wpływają na formatowanie, a nie na przechowywane wartości liczbowe.

**Które formatowanie wygrywa, gdy zarówno seria, jak i punkt są sformatowane?**

Jawne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty nadal korzystają z wyraźnego formatu serii lub, gdy format serii nie jest określony, z automatycznego stylu i motywu wykresu. Ustawienia grupy, takie jak nakładanie i szerokość przerwy, kontrolują układ i nie są nadpisaniami na poziomie punktu.

**Czy istnieje limit liczby serii w wykresie?**

Aspose.Slides nie narzuca osobnego stałego limitu liczby serii. W praktyce ograniczenia pliku prezentacji, dostępna pamięć, czas renderowania i czytelność wykresu określają praktyczny limit.

**Co zmienić, gdy kolumny są za blisko siebie lub za daleko od siebie?**

Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#setGapWidth) na odpowiedniej grupie serii nadrzędnej. Zwiększ wartość, aby poszerzyć przerwę między grupami, lub zmniejsz ją, aby przybliżyć grupy do siebie.