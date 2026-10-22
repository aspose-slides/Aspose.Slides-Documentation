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
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem, szerokością przerwy i wartościami ujemnymi w prezentacjach z Aspose.Slides dla Pythona poprzez Java."
---
## **Przegląd**

Wykres może przechowywać swoje wartości w komórkach skoroszytu lub bezpośrednio jako literały liczbowe. [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) reprezentuje punkt w tej serii. Obiekty [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) dostarczają etykiety lub wartości grupujące współdzielone przez serie. W wykresach tworzonych z danymi domyślnymi nazwy serii, kategorie i wartości punktów używają obiektów [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) z skoroszytu wykresu.

Dla typowego wykresu kategoriowego domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii oraz pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) są zerowe. Ten układ jest przydatny, gdy tworzysz wykres z danymi domyślnymi, ale nie zakładaj, że każdy istniejący wykres go używa. Dla załadowanej prezentacji sprawdź komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia poziomu serii, takie jak [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), zapewniają domyślny wygląd wszystkich punktów w jednej serii.
- Ustawienia punktu danych, takie jak [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), nadpisują wygląd serii dla jednego punktu.
- Ustawienia grupy mają zastosowanie do kompatybilnych serii należących do tej samej [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/). Uzyskaj dostęp do grupy przez [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup), gdy musisz ustawić opcje takie jak nakładanie lub szerokość przerwy.

Gdy nie jest ustawione wyraźne wypełnienie punktu lub serii, styl wykresu i motyw określają automatyczny wygląd. Gdy istnieje zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![seria wykresu PowerPoint](chart-series-powerpoint.png)

## **Ustaw wartości serii przy użyciu literałów liczbowych**

Używaj literałów liczbowych, gdy wartości serii pochodzą z danych aplikacji lub obliczeń i nie wymagają odwołań do komórek arkusza. Wywołaj [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) z [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) przed przypisaniem wyniku [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) każdego punktu za pomocą [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble).

Ustawienie kolekcji kontroluje typ źródła wszystkich wartości punktów w tej serii. Metoda [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) każdego punktu zgłasza wybrany typ; zmień go poprzez ustawienie kolekcji. Z `Worksheet` użyj [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell), aby uzyskać dostęp do odwołanej komórki. Z `DoubleLiterals` użyj [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) lub `setAsLiteralDouble`, aby odczytać lub zapisać liczbę bezpośrednio.

Poniższy przykład tworzy wykres kolumnowy z domyślnymi seriami i kategoriami, a następnie przypisuje obliczone wartości 10, 20 i kolejne do istniejących punktów pierwszej serii. Zapisuje prezentację, otwiera ją ponownie i wypisuje zapisane wartości.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

Typ źródła wartości punktu jest oddzielny od [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType), który określa wewnętrzną lub zewnętrzną konfigurację skoroszytu wykresu. Użycie literałów liczbowych samo w sobie nie usuwa osadzonego skoroszytu. W tym przykładzie skoroszyt pozostaje dostępny dla etykiet kategorii, nazw serii i pozostałych serii. Zobacz [Chart Workbook](/slides/pl/python-java/chart-workbook/) po informacje o zarządzaniu skoroszytem.

Dla wykresów rozrzutu i bąbelkowych użyj [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) i [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues), aby wybrać źródła dla [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) i [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue). Wykresy bąbelkowe używają także [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) dla [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize). Ustaw każdy odpowiedni źródło na `DoubleLiterals` przed przypisaniem liczb przez metodę `setAsLiteralDouble` tego wartości.

## **Ustaw nakładanie serii wykresu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) informuje, jak bardzo słupki lub kolumny nakładają się w wykresie 2D, w przedziale od -100 do 100 procent. Jest to tylko odczytowa projekcja ustawienia w grupie serii nadrzędnej. Użyj [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap), aby zaktualizować każdą kompatybilną serię w tej grupie. Opcja dotyczy typów wykresów wyświetlających grupowane słupki lub kolumny; nie wpływa na niepowiązane grupy serii w wykresie złożonym.

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

    # Nowy wykres zawiera przykładowe serie, kategorie oraz wartości.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Nakładanie serii](series_overlap.png)

## **Zmień kolor wypełnienia serii**

Użyj [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), aby ustawić domyślne wypełnienie dla całej serii. Jeśli punkt ma już wyraźne wypełnienie, jego ustawienie [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) nadpisuje wypełnienie serii dla tego punktu.

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

![Kolor serii](series_color.png)

## **Zmień nazwę serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zwykle wyświetlana w legendzie. W domyślnym skoroszycie utworzonym dla skumulowanego wykresu kolumnowego komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Zmienna w poniższym przykładzie explicite odzwierciedla tę strukturę:

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

Możesz również zaktualizować komórkę już odwoływaną przez [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName). To podejście unika założeń o konkretnym wierszu i kolumnie w istniejącym wykresie:

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

![Nazwa serii](series_name.png)

### **Utwórz serię z nazwą z wielu komórek**

Złożona nazwa serii jest przydatna, gdy nazwa produktu i okres raportowania są przechowywane w osobnych komórkach skoroszytu. Na przykład możesz połączyć `Product A` w B1 i `2026` w C1 w jedną nazwę serii, jednocześnie utrzymując oba elementy połączone z ich komórkami źródłowymi.

Użyj [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection), aby pobrać zakres nazw, a następnie przekaż tę kolekcję do [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). Argument `skipHiddenCells` steruje, czy ukryte komórki są uwzględniane: `True` je pomija, `False` uwzględnia. Ten przykład używa `False`, aby włączyć każdą komórkę w zakresie nazw.

Poniższy przykład tworzy prezentację z jedną serią i dwoma punktami danych. Komórki B1:C1 dostarczają tylko nazwę serii; A2:A3 dostarczają etykiety kategorii, a B2:B3 wartości liczbowe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Te dwie komórki dostarczają nazwę serii.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # Oddzielne komórki dostarczają kategorie i numeryczne punkty danych.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynikowa nazwa serii to `Product A 2026`, z odstępem między dwoma wartościami komórek. Legenda wyświetla to jako jedną pozycję dla obu kolumn. Poniższy obraz ilustruje wynik:

![Wykres kolumnowy z wartościami Północ i Południe oraz złożoną nazwą serii Product A 2026 w legendzie](composite_series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) zwraca kolor obliczony na podstawie indeksu serii i stylu wykresu. To jest kolor używany, gdy wypełnienie serii nie zostało jawnie określone. Wywołanie metody odczytuje obliczony kolor; nie przypisuje nowego wypełnienia.

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

Przykładowy wynik dla domyślnego stylu wykresu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Dokładne kolory zależą od stylu wykresu i motywu.

## **Ustaw odwrócony kolor wypełnienia dla serii wykresu**

Dla serii słupkowych, kolumnowych i bąbelkowych [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) może wyświetlać ujemne wartości innym kolorem wypełnienia. Ustaw regularne wypełnienie serii na jednolite, włącz odwracanie i przypisz kolor ujemny za pomocą [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Liczby ujemne pozostają niezmienione w skoroszycie; zmienia się tylko ich kolor wyświetlania.

Poniższy przykład zastępuje domyślne dane wykresu jedną serią. Wiersz 0 arkusza zawiera nazwę serii, kolumna 0 nazwy kategorii, a kolumna 1 wartości:

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

![Odwrócony jednolity kolor wypełnienia](inverted_solid_fill_color.png)

Możesz włączyć odwracanie dla jednego punktu przez [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). W poniższym przykładzie odwracanie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punktowi przypisano także wartość ujemną, aby efekt był widoczny:

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

## **Wyczyść wartość konkretnego punktu danych**

Aby pozostawić jeden punkt pusty bez usuwania pozostałych, ustaw jego powiązaną komórkę skoroszytu na `None`. Dla wykresu kolumnowego wartość rysowana jest dostępna przez [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). Punkt pozostaje w tej samej pozycji kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

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

Wykresy rozrzutu używają osobnych komórek X i Y, a wykresy bąbelkowe także komórki rozmiaru. Czyść tylko komórkę, która reprezentuje wartość, którą chcesz usunąć. Nie wywołuj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear), gdy chcesz zachować pozostałe punkty, ponieważ metoda ta usuwa każdy punkt danych z kolekcji.

## **Steruj wyświetlaniem pustych komórek**

Ukryte komórki zawierające wartości to odrębny przypadek od pustych komórek. Aby włączać lub wyłączać dane z ukrytych wierszy i kolumn arkusza, zobacz [Dołącz dane z ukrytych wierszy i kolumn](/slides/pl/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Pusta komórka skoroszytu oznacza brak danych; komórka zawierająca `0` oznacza znaną wartość liczbową. Wywołaj [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) z `None`, aby uczynić komórkę pustą. Liczba zero pozostaje zerem niezależnie od ustawienia pustej komórki.

Użyj [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs), aby wybrać, jak wykres wyświetla puste komórki. To ustawienie dotyczy całego wykresu. Zmienia sposób rysowania pustek, nie wypełniając pustej komórki skoroszytu zerem ani wartością interpolowaną.

Poniższy, samodzielny przykład tworzy wykres liniowy z jedną serią, czyści wartość dla Dnia 3 i zapisuje ten sam wykres w każdym trybie. Nie wymaga pliku wejściowego. [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) używa arkusza 0, kolumny 0 dla etykiet kategorii i kolumny 1 dla wartości; wiersz 0 zawiera nazwę serii. Końcowe dane to `10, 20, empty, 30, 40`.

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

    # Zostaw Dzień 3 naprawdę pusty, zachowując jego kategorię i punkt danych.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Każdy plik wyjściowy przechowuje tryb przypisany przed zapisem: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` i `empty_cells_Span.pptx`. Aby zapisać tylko jedną wersję, przypisz żądany tryb i zapisz prezentację raz zamiast iterować po trybach.

Porównanie poniżej pokazuje te same dane w trzech plikach. Dzień 3 jest pusty w skoroszycie we wszystkich przypadkach:

![Wykresy liniowe z identycznymi danymi: Gap przerywa linię w Dniu 3, Zero obniża linię do zera, a Span łączy Dzień 2 z Dniem 4.](display_blanks_as.png)

Widoczny efekt zależy od typu wykresu. Wykres liniowy ułatwia porównanie wszystkich trzech trybów. Wykresy słupkowe i kolumnowe nie mają linii do połączenia przez brakującą kategorię, więc `Span` nie może wygenerować pokazanego odcinka; brakująca kolumna i kolumna o zerowej wysokości mogą wyglądać podobnie. Podobnie wykres rozrzutu z samymi znacznikami nie ma linii łączącej. Nie oczekuj trzech odrębnych wyników dla każdego typu wykresu; sprawdź wynik dla używanego typu.

## **Ustaw szerokość przerwy serii**

Szerokość przerwy to odstęp między sąsiadującymi grupami słupków lub kolumn, wyrażony jako procent szerokości słupka lub kolumny. Podobnie jak nakładanie, należy do grupy serii nadrzędnej, a nie do jednej serii. Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) raz dla grupy. Większa wartość zwiększa odstęp między grupami; mniejsza wartość sprawia, że są gęstsze.

Poniższy przykład zmienia szerokość przerwy i zapisuje tylko końcową prezentację:

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

![Szerokość przerwy](gap_width.png)

## **FAQ**

**Jakie typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) używają danych wykresu, ale ich serie nie mają takiej samej struktury wartości ani ustawień. Na przykład wykresy kategoriowe używają kategorii i wartości, wykresy rozrzutu X i Y, a wykresy bąbelkowe dodatkowo rozmiary bąbelków. Używaj metody tworzenia punktu danych odpowiadającej typowi serii. Opcje takie jak nakładanie i szerokość przerwy mają zastosowanie tylko do kompatybilnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) zawiera kompatybilne serie, które współdzielą ustawienia grupowe wykresu. Wykres złożony może zawierać więcej niż jedną grupę, więc zmiana grupy osiągnięta przez jedną serię niekoniecznie zmienia wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera dane domyślne?**

Tak. Domyślnie [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub wyczyścić zarówno serie, jak i kolekcje kategorii przed dodaniem całkowicie własnego zestawu danych. Przeciążenie może także utworzyć wykres bez danych domyślnych.

**Jak obiekty wykresu są powiązane z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). Zmiana odwoływanej komórki aktualizuje odpowiedni element wykresu. Tworząc własne dane, utrzymuj wiersze kategorii i wiersze wartości serii wyrównane, aby każdy punkt był rysowany pod właściwą kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `None`, aby zachować pozycję kategorii punktu jako pusty punkt. Używaj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) tylko wtedy, gdy zamierzasz usunąć wszystkie punkty z tej serii. Jeśli usuwasz także kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu i wartości skonfigurowanej przez [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs). Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zero lub poprzez połączenie sąsiednich punktów. Wybierz ustawienie odpowiadające znaczeniu brakujących danych w Twojej prezentacji. Zobacz [Steruj wyświetlaniem pustych komórek](#control-the-display-of-empty-cells) po kompletny przykład i porównanie wizualne.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) i ustaw kolor zwrócony przez [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Możesz nadpisać zachowanie dla pojedynczego punktu przy pomocy [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Metody te wpływają na formatowanie, nie na zapisane wartości liczbowe.

**Które formatowanie wygrywa, gdy zarówno seria, jak i punkt są formatowane?**

Jawne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty nadal używają jawnego formatu serii lub, gdy format serii nie jest określony, automatycznego stylu i motywu wykresu. Ustawienia grupy, takie jak nakładanie i szerokość przerwy, kontrolują układ i nie są nadpisaniami formatowania na poziomie punktu.

**Czy istnieje limit liczby serii, które wykres może zawierać?**

Aspose.Slides nie narzuca osobnego, stałego limitu liczby serii. W praktyce ograniczenia pliku prezentacji, dostępna pamięć, czas renderowania i czytelność wykresu określają użyteczny limit.

**Co zmienić, gdy kolumny są za blisko siebie lub zbyt od siebie oddalone?**

Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) na odpowiedniej grupie serii nadrzędnej. Zwiększ wartość, aby poszerzyć odstęp między grupami, lub zmniejsz ją, aby przybliżyć grupy do siebie.