---
title: Dodaj linie trendu do wykresów w prezentacji w Pythonie
linktitle: Linia trendu
type: docs
url: /pl/python-java/trend-line/
keywords:
- wykres
- linia trendu
- linia trendu wykładnicza
- linia trendu liniowa
- linia trendu logarytmiczna
- linia trendu średniej kroczącej
- linia trendu wielomianowa
- linia trendu potęgowa
- własna linia trendu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Szybko dodaj i dostosuj linie trendu w wykresach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java — praktyczny przewodnik, który przyciągnie Twoją publiczność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z różnymi typami linii trendu, w tym wykładniczymi, liniowymi, logarytmicznymi, średnimi kroczącymi, wielomianowymi i potęgowymi.

Opisuje również, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu w przód i w tył oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG i przy renderowaniu wykresów jako obrazy.

## **Dodaj linię trendu**

Użyj [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add), aby dodać linię trendu do serii wykresu, wybierając jej typ za pomocą [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). Przykład tworzy skumulowany wykres kolumnowy z domyślnymi danymi i dodaje dwie linie trendu do każdej z trzech serii.

Linia trendu wykładnicza ukrywa równanie i wartość R-kwadrat przy użyciu [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) i [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), podczas gdy linia trendu liniowa jest czerwona. Linia trendu logarytmiczna używa [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) do niestandardowej etykiety. Średnia krocząca korzysta z [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) ustawionego na trzy punkty danych oraz niestandardowego [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName).

Linia trendu wielomianowa ma rząd trzeci, ustawiany za pomocą [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) i rozciąga się o jedną kategorię w przód dzięki [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). Linia trendu potęgowa rozciąga się o jedną kategorię w tył za pomocą [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw przecięcie linii trendu**

Użyj [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept), aby ustawić wartość Y linii trendu przy X = 0. To ustawienie jest obsługiwane dla linii trendu liniowych, wykładniczych i wielomianowych.

Na przykład model kosztów produkcji może wymagać rozpoczęcia od znanych stałych kosztów równych 100, nawet gdy pomiary przy niezerowych wolumenach produkcji sugerują inną bazę. Dla liniowej linii trendu, ustalenie przecięcia ogranicza równanie `y = ax + b` do `b = 100`; nachylenie jest dopasowywane do danych przy tym ograniczeniu. Nie powoduje to po prostu przesunięcia już dopasowanej linii. Ustawienia przecięcia osi kontrolują, gdzie osie wykresu się spotykają, a nie współczynniki dopasowanej linii trendu.

Poniższy przykład tworzy wykres punktowy (XY) z wolumenami produkcji od 1 do 4 oraz kosztami 170, 200, 230 i 260. Zapisuje wykres z domyślnym automatycznym przecięciem, ustawia przecięcie na 100 i zapisuje drugi plik PPTX. Dwa pliki różnią się wyłącznie ustawieniem przecięcia. Linia trendu wyświetla swoje równanie i rozciąga się do X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Przy automatycznym obliczeniu te dane dają `y = 30x + 140`. Ustawienie przecięcia na 100 zamiast tego daje w przybliżeniu `y = 43.33x + 100`: dopasowana wartość przy zerze odpowiada znanej bazie, podczas gdy linia nie przechodzi już przez każdy punkt danych.

| Automatyczne przecięcie | Stałe przecięcie 100 |
| --- | --- |
| ![Liniowa linia trendu z automatycznie obliczonym przecięciem 140](intercept-automatic.png) | ![Liniowa linia trendu ze stałym przecięciem 100](intercept-fixed.png) |

Oba obrazy używają tych samych danych i skali osi. Linie trendu są rozciągnięte do X = 0, aby pokazać ich przecięcia.

Domyślnie [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) zwraca `NaN`, co oznacza nieokreślone przecięcie, a nie zero. Przecięcie jest wtedy obliczane automatycznie na podstawie danych.

## **Dodaj własną linię**

Własna linia to kształt narysowany nad wykresem, a nie linia trendu obliczona na podstawie danych serii. Ten przykład używa [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape), aby dodać poziomą linię do slajdu nad wykresem. Pozycja linii jest określona w współrzędnych slajdu, mierzonych w punktach, więc zaczyna się od lewej krawędzi wykresu i znajduje się w połowie wysokości wykresu. Jej szerokość odpowiada szerokości wykresu. Metoda [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) zapewnia dostęp do formatowania linii używanego do zastosowania jednolitego czerwonego koloru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Co oznaczają wartości „forward” i „backward” dla linii trendu?**

Są to długości linii trendu projekowane w przód/tył: dla wykresów punktowych (XY) – w jednostkach osi; dla wykresów niepunktowych – w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu zostanie zachowana przy eksportowaniu prezentacji do PDF lub SVG oraz przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/) lub [SVG](/slides/pl/python-java/render-a-slide-as-an-svg-image/) oraz renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest również metoda umożliwiająca [eksport obrazu wykresu](/slides/pl/python-java/create-shape-thumbnails/).