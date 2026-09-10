---
title: Z zarządzanie seriami danych wykresu w prezentacjach w Pythonie
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
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem, szerokością przerwy i wartościami ujemnymi w prezentacjach przy użyciu Aspose.Slides dla Pythona poprzez Java."
---
## **Przegląd**

Wykres przechowuje swoje wyświetlane dane w skoroszycie danych wykresu. A [ChartSeries](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [ChartDataPoint](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/) w serii odnosi się do jednej lub wielu komórek skoroszytu. Obiekty [ChartCategory](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartcategory/) dostarczają etykiet lub wartości grupowania współdzielonych przez serie. Nazwa serii, kategorie i wartości punktów są więc połączone z obiektami [ChartDataCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/), a nie przechowywane wyłącznie jako tekst wyświetlany.

Dla typowego wykresu kategoriowego domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii i pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#getCell) są zerowe. Ten układ jest przydatny, gdy tworzysz wykres z danymi domyślnymi, ale nie zakładaj, że każdy istniejący wykres go używa. Dla wczytanej prezentacji sprawdź komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak [ChartSeries.getFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getFormat), zapewniają domyślny wygląd wszystkich punktów w jednej serii.  
- Ustawienia punktu danych, takie jak [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#getFormat), nadpisują wygląd serii dla jednego punktu.  
- Ustawienia grupy mają zastosowanie do kompatybilnych serii, które należą do tej samej [ChartSeriesGroup](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/). Dostęp do grupy uzyskujesz przez [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getParentSeriesGroup), gdy musisz ustawić opcje takie jak nakładanie lub szerokość przerwy.

Gdy nie jest ustawione wyraźne wypełnienie punktu lub serii, styl i motyw wykresu określają automatyczny wygląd. Gdy istnieje zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw nakładanie serii wykresu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getOverlap) raportuje, jak bardzo słupki lub kolumny nakładają się w wykresie 2D, w przedziale od -100 do 100 procent. Jest to projekcja tylko do odczytu ustawienia w grupie nadrzędnej serii. Użyj [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#setOverlap), aby zaktualizować każdą kompatybilną serię w tej grupie. Opcja ta obowiązuje typy wykresów wyświetlające grupowane słupki lub kolumny; nie wpływa na niepowiązane grupy serii w wykresie kombinowanym.

Poniższy przykład ustawia nakładanie dla grupy, która zawiera pierwszą serię:

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

Użyj [ChartSeries.getFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getFormat), aby ustawić domyślne wypełnienie całej serii. Jeśli punkt ma już wyraźne wypełnienie, jego ustawienie [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#getFormat) nadpisuje wypełnienie serii dla tego punktu.

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

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zazwyczaj wyświetlana jest w legendzie. W domyślnym skoroszycie utworzonym dla wykresu kolumnowego skumulowanego komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Zmienna nazwana w poniższym przykładzie wyraźnie opisuje tę strukturę:

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

Możesz także zaktualizować komórkę już odwoływaną przez [ChartSeries.getName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getName). To podejście unika zakładania określonego wiersza i kolumny w istniejącym wykresie:

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

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) zwraca kolor obliczony na podstawie indeksu serii i stylu wykresu. Jest to kolor używany, gdy wypełnienie serii nie zostało wyraźnie zdefiniowane. Wywołanie metody odczytuje obliczony kolor; nie przypisuje nowego wypełnienia.

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

Dla serii słupkowych, kolumnowych i bąbelkowych metoda [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#setInvertIfNegative) może wyświetlać wartości ujemne innym wypełnieniem. Ustaw regularne wypełnienie serii na jednolite, włącz odwracanie i przypisz kolor wartości ujemnej przez [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Ujemne liczby pozostają niezmienione w skoroszycie; zmienia się tylko ich kolor wyświetlania.

Poniższy przykład zamienia domyślne dane wykresu jedną serią. Wiersz 0 arkusza zawiera nazwę serii, kolumna 0 – nazwy kategorii, a kolumna 1 – wartości:

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

Możesz włączyć odwrócenie dla jednego punktu przez [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). W poniższym przykładzie odwrócenie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punktowi przypisano także wartość ujemną, aby efekt był widoczny:

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

## **Wyczyść określoną wartość punktu danych**

Aby uczynić jeden punkt pustym bez usuwania pozostałych, ustaw jego komórkę w skoroszycie na `None`. Dla wykresu kolumnowego wyświetlana wartość jest dostępna przez [ChartDataPoint.getValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#getValue). Punkt danych pozostaje w tej samej pozycji kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

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

Wykresy punktowe (scatter) używają oddzielnych komórek X i Y, a wykresy bąbelkowe także komórki rozmiaru. Czyść tylko tę komórkę, która reprezentuje wartość, którą chcesz usunąć. Nie wywołuj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapointcollection/#clear), gdy chcesz zachować pozostałe punkty, ponieważ metoda ta usuwa wszystkie punkty danych z kolekcji.

## **Ustaw szerokość przerwy między seriami**

Szerokość przerwy to odstęp między sąsiadującymi skupiskami słupków lub kolumn, wyrażony jako procent szerokości słupka lub kolumny. Podobnie jak nakładanie, należy ona do grupy nadrzędnej serii, a nie do jednej serii. Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#setGapWidth) raz dla grupy. większa wartość tworzy więcej przestrzeni między skupiskami; mniejsza wartość powoduje ich zagęszczenie.

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

![The gap width](gap_width.png)

## **FAQ**

**Jakie typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/) używają danych wykresu, lecz ich serie nie zawsze mają tę samą strukturę wartości ani ustawienia. Na przykład wykresy kategorii używają kategorii i wartości, wykresy rozrzutu używają wartości X i Y, a wykresy bąbelkowe dodają rozmiary bąbelków. Użyj metody tworzenia punktu danych odpowiadającej typowi serii. Opcje takie jak nakładanie i szerokość przerwy mają zastosowanie tylko do kompatybilnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/) zawiera kompatybilne serie, które współdzielą ustawienia wykresu na poziomie grupy. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy uzyskanej przez jedną serię niekoniecznie zmieni wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera domyślne dane?**

Tak. Domyślnie metoda [ShapeCollection.addChart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addChart) tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub wyczyścić zarówno kolekcje serii, jak i kategorii przed dodaniem całkowicie własnego zestawu danych. Przeciążenie może także utworzyć wykres bez danych domyślnych.

**W jaki sposób obiekty wykresu są powiązane z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [ChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/). Zmiana odwoływanej komórki aktualizuje odpowiadający element wykresu. Budując własne dane, zachowaj wyrównanie wierszy kategorii i wierszy wartości serii, aby każdy punkt był wykreślony pod odpowiednią kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `None`, aby zachować pozycję punktu w kategorii jako pusty punkt. Używaj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapointcollection/#clear) tylko wtedy, gdy zamierzasz usunąć wszystkie punkty z tej serii. Jeśli usuwasz także kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały zgodne z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu oraz wartości skonfigurowanej w [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#setDisplayBlanksAs). Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zero lub poprzez połączenie sąsiednich punktów. Wybierz ustawienie odpowiadające znaczeniu brakujących danych w Twojej prezentacji.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#setInvertIfNegative) i ustaw kolor zwracany przez [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Zachowanie można nadpisać dla pojedynczego punktu przy użyciu [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Metody te wpływają na formatowanie, a nie na przechowywane wartości liczbowe.

**Które formatowanie ma pierwszeństwo, gdy zarówno seria, jak i punkt są sformatowane?**

Wyraźne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty nadal używają wyraźnego formatu serii lub, gdy format serii nie jest zdefiniowany, automatycznego stylu i motywu wykresu. Ustawienia grupy, takie jak nakładanie i szerokość przerwy, kontrolują układ i nie są nadpisaniami formatowania na poziomie punktu.

**Czy istnieje limit liczby serii, które wykres może zawierać?**

Aspose.Slides nie narzuca odrębnego stałego limitu liczby serii. W praktyce ograniczenia wynikają z rozmiaru pliku prezentacji, dostępnej pamięci, czasu renderowania oraz czytelności wykresu.

**Co zmienić, gdy kolumny są za blisko siebie lub za daleko od siebie?**

Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#setGapWidth) na odpowiedniej grupie serii nadrzędnej. Zwiększ wartość, aby poszerzyć odstęp między grupami, lub zmniejsz ją, aby przybliżyć grupy do siebie.