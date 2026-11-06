---
title: Zarządzaj etykietami danych wykresu w prezentacjach przy użyciu Pythona
linktitle: Etykieta danych
type: docs
url: /pl/python-java/chart-data-label/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać i formatować etykiety danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona via Java, aby uzyskać bardziej angażujące slajdy."
---
## **Wprowadzenie**

Etykiety danych wyświetlają informacje o seriach wykresu i poszczególnych punktach danych, pomagając odbiorcom zidentyfikować wartości i zrozumieć wykres. Ten artykuł wyjaśnia, jak formatować wartości, wyświetlać procenty, odczytywać tekst etykiety, kontrolować etykiety poza maksymalnym zakresem osi, dostosowywać odstępy etykiet osi kategorii oraz pozycjonować etykiety wykresu kołowego.

## **Policzenie widocznych etykiet danych**

Użyj [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCountOfVisibleDataLabels), aby sprawdzić, ile etykiet danych jest włączonych do wyświetlania przed opublikowaniem prezentacji. W odróżnieniu od [getCount](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCount), który zwraca całkowitą liczbę etykiet w kolekcji, metoda ta uwzględnia domyślne ustawienia serii oraz indywidualne ustawienia etykiet.

Ten przykład tworzy wykres kolumnowy z jedną serią i trzema punktami danych. Dostęp do kolekcji etykiet serii uzyskuje się przez [getLabels](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getLabels) i wypisuje liczbę widocznych etykiet w miarę zmiany ustawień: **0, 3, 2, 3**. Łączna liczba pozostaje **3**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    series_cell = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    for i in range(3):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JDouble((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    labels = series.getLabels()
    print(f"Total: {labels.getCount()}; visible: {labels.getCountOfVisibleDataLabels()}")  # Razem: 3; widoczne: 0

    labels.getDefaultDataLabelFormat().setShowValue(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Widoczne: 3

    labels.get_Item(1).getDataLabelFormat().setShowValue(False)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Widoczne: 2

    labels.get_Item(1).getDataLabelFormat().setShowLegendKey(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Widoczne: 3
finally:
    presentation.dispose()
```

Metoda [getDefaultDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getDefaultDataLabelFormat) serii zwraca domyślne ustawienia. Przekazanie `True` do [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) powoduje wyświetlenie wartości dla wszystkich trzech etykiet. Przekazanie `False` poprzez [getDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getDataLabelFormat) jednej etykiety nadpisuje to ustawienie dla wybranej etykiety. Przekazanie `True` do [setShowLegendKey](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLegendKey) powoduje, że etykieta znowu liczy się jako widoczna, mimo że jej wartość pozostaje ukryta.

Liczba widocznych etykiet odzwierciedla ustawienia widoczności. Nie mierzy ona, czy etykiety nachodzą na siebie, są przycięte lub czytelne w renderowanym wykresie.

## **Ustaw precyzję wartości w etykietach danych wykresu**

Użyj [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues), aby formatować wartości serii. Ten przykład tworzy wykres liniowy z danymi domyślnymi, wyświetla jego tabelę danych i włącza etykiety wartości dla pierwszej serii. Format `#,##0.00` wyświetla separator tysięcy i dwa miejsca po przecinku bez zmiany wartości źródłowych.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aby sformatować komórki numeryczne w osadzonej książce roboczej wykresu, zobacz [Ustaw niestandardowe formaty liczb dla komórek książki roboczej](/slides/pl/python-java/chart-workbook/#set-custom-number-formats-for-workbook-cells). Ten przykład pokazuje także, że etykiety wartości zachowują formaty źródłowych komórek, jednocześnie zachowując przechowywane wartości liczbowe.

## **Wyświetl procent jako etykietę**

Wykres słupkowy skumulowany: oblicz każdą wartość jako procent sumy w swojej kategorii i przypisz tekst do ramki tekstowej zwróconej przez [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Ten przykład używa domyślnych danych wykresu i wyświetla procenty z dwoma miejscami po przecinku czcionką 8 punktów. Kategorie o sumie zero są pomijane, aby uniknąć dzielenia przez zero. Przelicz niestandardowy tekst etykiety, jeśli dane wykresu ulegną zmianie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw znak procenta w etykietach danych wykresu**

Gdy wartości są przechowywane jako ułamki, użyj [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat), aby wyświetlać procenty. Przekaż `False` do [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource), aby zastosować format etykiety niezależnie od komórek źródłowych.

Ten przykład tworzy wykres słupkowy skumulowany 100 % z czerwoną i niebieską serią w czterech kategoriach. Każda para wartości sumuje się do 1. Format etykiety `0.0%` wyświetla 0.30 jako 30.0 %, podczas gdy oś pionowa używa dwóch miejsc po przecinku. Obie serie używają białego tekstu etykiety 10‑punktowego.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Odczytaj rzeczywisty tekst etykiet danych**

Użyj [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText), aby pobrać tekst wygenerowany na podstawie ustawień etykiety danych. Jest to przydatne przy wyodrębnianiu etykiet do raportów, przeszukiwaniu zawartości prezentacji lub weryfikacji wygenerowanych wykresów. W poniższym przykładzie domyślny [format etykiety danych](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) łączy nazwę kategorii, nazwę serii i wartość. Jeden punkt formatuje swoją wartość jako procent, a inny używa własnego tekstu z [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Liczba przechowywana w punkcie danych pozostaje `0.75`, nawet gdy jego etykieta pokazuje `75 %` wraz z nazwami kategorii i serii. Własny tekst zastępuje wygenerowany tekst etykiety. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) zwraca wynikowy ciąg etykiety w obu przypadkach. Sprawdzaj [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) osobno, jak pokazano wyżej, gdy chcesz wyodrębnić tylko widoczne etykiety.

## **Kontroluj etykiety danych poza maksymalnym zakresem osi**

Gdy ręcznie ograniczasz zakres osi, niektóre punkty danych mogą przekraczać jej maksimum. Użyj [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum), aby kontrolować, czy ich etykiety danych są wyświetlane. To ustawienie zmienia widoczność etykiet; nie zmienia zakresu osi ani wartości danych.

Poniższy przykład tworzy wykres kolumnowy grupowany 2D z wartościami 60 i 120. Przekazuje `False` do [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) i ustawia maksimum na 100 za pomocą [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) na osi pionowej. Pierwszy slajd zezwala na etykiety poza maksimum; kopia tego slajdu wyłącza je. Oba slajdy są zapisywane w `DataLabelsOverMaximum.pptx`.

Włącz etykiety wartości za pomocą [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Ustawienie na poziomie wykresu nie włącza wyświetlania wartości samo w sobie ani nie nadpisuje wyłączonego wyświetlania wartości dla poszczególnej etykiety. Ten przykład włącza wartości dla całej serii i używa [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition), aby umieścić etykiety na zewnętrznej końcówce każdej kolumny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poniższe obrazy przedstawiają zapisane slajdy renderowane w Microsoft PowerPoint. Przy `True` etykieta **120** jest widoczna przy górnej granicy; przy `False` jest ukryta. Etykieta **60** pozostaje widoczna, maksimum osi wynosi **100**, a drugi punkt danych pozostaje **120** w obu przypadkach.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Wykres PowerPoint pokazujący etykietę wartości 120 przy maksymalnym limicie osi 100](data-labels-over-maximum-true.png) | ![Wykres PowerPoint ukrywający etykietę wartości 120 przy maksymalnym limicie osi 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Typ wykresu" %}}

Ten przykład używa wykresu kolumnowego 2D z osią wartości. Wykresy bez osi wartości, takie jak wykresy kołowe i pierścieniowe, nie mają maksymalnego limitu osi w ten sposób.

{{% /alert %}}

## **Ustaw odległość etykiety od osi**

Użyj [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset), aby kontrolować odległość między etykietami osi kategorii a samą osią. Wartość jest procentem maksymalnego rozmiaru czcionki etykiet osi. Ten przykład tworzy wykres kolumnowy grupowany i ustawia offset etykiet osi poziomej na 500. Ustawienie to wpływa na etykiety osi kategorii, a nie na etykiety dołączone do pojedynczych punktów danych.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dostosuj położenie etykiet**

W wykresie kołowym dostosuj pozycje etykiet danych, aby poprawić rozmieszczenie i zrobić miejsce dla linii prowadzących.

Ten przykład wyświetla wartość pierwszego punktu danych, umieszcza jego etykietę poza wycinką i dostosowuje jej przesunięcia poziome i pionowe za pomocą [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) i [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Przesunięcia te są względne względem szerokości i wysokości wykresu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Wykres kołowy z dostosowaną pozycją etykiety danych](pie-chart-adjusted-label.png)

## **Formatuj linie prowadzące**

Gdy etykiety wykresu kołowego znajdują się poza wycinkami, linie prowadzące pomagają odbiorcom dopasować każdą wartość do właściwej wycinki. Kontrastujący kolor i nieco grubsza linia mogą ułatwić śledzenie połączeń, a przezroczystość i styl przerywany sprawiają, że linie są wizualnie dyskretne.

Użyj [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat), aby formatować linie prowadzące na poziomie kolekcji etykiet danych serii. Ustawienia w `series.getLabels().getLeaderLinesFormat().getLine()` mają zastosowanie do całej kolekcji, a nie do pojedynczej etykiety.

Ten przykład tworzy wykres kołowy z danymi domyślnymi, wyświetla wartości poza wycinkami i włącza [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines). Przesuwa dwie etykiety dalej od ich wycinków, używając przesunięć [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) i [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY), wyrażonych jako ułamki szerokości i wysokości wykresu. Nie jest wymagana żadna prezentacja wejściowa.

Metoda [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) linii ustawia jednolity niebieski kolor z wartością alfa 191 z 255, co daje około 25 % przezroczystości. [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) ustawia grubość na 2 punkty, a [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) nadaje linii styl przerywany.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # Przesuń dwie etykiety dalej od ich wycinków.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Włączenie linii prowadzących nie gwarantuje, że linia pojawi się przy każdej etykiecie. Widoczność zależy od położenia etykiety i zachowania układu wykresu. W tym przykładzie dwie przesunięte etykiety mają widoczne linie prowadzące; etykiety pozostające blisko swoich wycinków nie potrzebują ich.

Poniższy obraz przedstawia zapisany plik `FormattedLeaderLines.pptx` renderowany przy użyciu Aspose.Slides:

![Wykres kołowy z niebieskimi, półprzezroczystymi, przerywanymi liniami prowadzącymi łączącymi dwie zewnętrzne etykiety z ich wycinkami](formatted-leader-lines.png)

## **Dodaj wiele wierszy etykiet danych nad wykresem kolumnowym**

Ten przykład tworzy wykres kolumnowy z dwoma wierszami etykiet danych nad obszarem wykresu. Seria A wyświetla widoczne kolumny, natomiast Serie B i C dostarczają dodatkowe etykiety. Ich kolumny są ukryte przez usunięcie wypełnienia i konturu. Metoda [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) wyrównuje wszystkie trzy serie względem tych samych centrów kategorii.

Ustawienia [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) rezerwują miejsce dla wierszy etykiet. Po wywołaniu [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout), które oblicza domyślne pozycje, [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) i [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) zachowują wyrównanie poziome i stosują pionowe przesunięcia, aby ułożyć etykiety w dwóch wierszach. Liczby pozostają etykietami danych powiązanymi z wartościami serii; jedynie nagłówki wierszy są oddzielnymi kształtami tekstowymi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # Ukryj kolumny serii B i C, ale zachowaj ich etykiety danych.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Wyrównaj wszystkie trzy serie względem tych samych środków kategorii.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Użyj mniejszej liczby linii siatki w tym zwartym przykładzie.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Zarezerwuj miejsce nad obszarem wykresu dla dwóch wierszy etykiet danych.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # Zachowaj domyślną pozycję poziomą. Y jest przesunięciem od
            # domyślnej pozycji etykiety, wyrażonego jako ułamek wysokości wykresu.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Tylko nagłówek wiersza jest osobnym kształtem tekstowym.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Wykres kolumnowy z dwoma wierszami etykiet danych nad obszarem wykresu](multiple-rows-of-labels.png)

## **FAQ**

**Jak mogę zapobiec nakładaniu się etykiet danych na gęstych wykresach?**

Połącz automatyczne rozmieszczanie etykiet, linie prowadzące oraz zmniejszenie rozmiaru czcionki; w razie potrzeby ukryj niektóre pola (np. kategorię) lub wyświetlaj etykiety tylko dla wartości ekstremalnych lub kluczowych punktów.

**Jak mogę wyłączyć etykiety tylko dla wartości zerowych, ujemnych lub pustych?**

Filtruj punkty danych przed włączeniem etykiet i wyłącz wyświetlanie dla wartości równych 0, wartości ujemnych lub brakujących zgodnie ze zdefiniowaną regułą.

**Jak zapewnić spójny styl etykiet przy eksporcie do PDF/obrazów?**

Jawnie ustaw rodzinę i rozmiar czcionki oraz zweryfikuj, że czcionka jest dostępna w środowisku renderującym, aby uniknąć użycia czcionki zapasowej.