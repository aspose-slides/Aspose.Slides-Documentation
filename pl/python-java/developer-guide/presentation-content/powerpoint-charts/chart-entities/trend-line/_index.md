---
title: Dodawanie linii trendu do wykresów w prezentacji w Pythonie
linktitle: Linia trendu
type: docs
url: /pl/python-java/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- liniowa linia trendu
- logarytmiczna linia trendu
- linia trendu średniej kroczącej
- wielomianowa linia trendu
- potęgowa linia trendu
- własna linia trendu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Szybko dodaj i dostosuj linie trendu w wykresach PowerPoint przy użyciu Aspose.Slides for Python via Java — praktyczny przewodnik, aby zaangażować twoją publiczność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z kilkoma typami linii trendu, w tym wykładniczymi, liniowymi, logarytmicznymi, średnią kroczącą, wielomianowymi i potęgowymi.

Opisuje także, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu w przód i w tył oraz tego, czy linie trendu są zachowywane podczas eksportu do formatu PDF lub SVG oraz przy renderowaniu wykresów jako obrazy.

## **Dodaj linię trendu**

Aspose.Slides for Python via Java provides a simple API for managing different chart trend lines:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu po jego indeksie.
3. Dodaj wykres z domyślnymi danymi i żądanym typem (w tym przykładzie użyto [ChartType.ClusteredColumn](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#ClusteredColumn)).
4. Dodaj wykładniczą linię trendu do serii wykresu 1.
5. Dodaj liniową linię trendu do serii wykresu 1.
6. Dodaj logarytmiczną linię trendu do serii wykresu 2.
7. Dodaj linię trendu średniej kroczącej do serii wykresu 2.
8. Dodaj wielomianową linię trendu do serii wykresu 3.
9. Dodaj potęgową linię trendu do serii wykresu 3.
10. Zapisz zmodyfikowaną prezentację do pliku PPTX.

The following code creates a chart with trend lines.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    # Utwórz wykres kolumnowy grupowany.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Dodaj wykładniczą linię trendu do serii wykresu 1.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Dodaj liniową linię trendu do serii wykresu 1.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Dodaj logarytmiczną linię trendu do serii wykresu 2.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Dodaj linię trendu średniej kroczącej do serii wykresu 2.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Dodaj wielomianową linię trendu do serii wykresu 3.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Dodaj potęgową linię trendu do serii wykresu 3.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Zapisz prezentację.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodaj własną linię**

Aspose.Slides for Python via Java provides a simple API to add custom lines to a chart. To add a plain line to a chart on a selected slide, follow these steps:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Uzyskaj referencję do slajdu po jego indeksie.
- Utwórz nowy wykres przy użyciu metody [addChart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addChart) klasy [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/).
- Dodaj kształt linii przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAutoShape) z [ShapeType.Line](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#Line).
- Ustaw kolor linii kształtu.
- Zapisz zmodyfikowaną prezentację do pliku PPTX.

The following code creates a chart with a custom line.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Co oznaczają „forward” i „backward” w odniesieniu do linii trendu?**

Są to długości linii trendu rzutowane w przód lub w tył: dla wykresów punktowych (XY) mierzone są w jednostkach osi; dla wykresów innych niż punktowe mierzone są w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu będzie zachowana podczas eksportu prezentacji do formatu PDF lub SVG oraz przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje na [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/pl/python-java/render-a-slide-as-an-svg-image/) oraz renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest również metoda do [eksportu obrazu wykresu](/slides/pl/python-java/create-shape-thumbnails/).