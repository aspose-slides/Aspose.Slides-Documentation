---
title: Optymalizacja obliczeń wykresów dla prezentacji w Pythonie za pośrednictwem Javy
linktitle: Obliczenia wykresów
type: docs
weight: 50
url: /pl/python-java/chart-calculations/
keywords:
- obliczenia wykresów
- elementy wykresu
- pozycja elementu
- rzeczywista pozycja
- element podrzędny
- element nadrzędny
- wartości wykresu
- rzeczywista wartość
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zrozum obliczenia wykresów, aktualizacje danych i kontrolę precyzji w Aspose.Slides dla Pythona za pośrednictwem Javy dla PPT i PPTX, z praktycznymi przykładami kodu w Pythonie."
---
## **Przegląd**

Aspose.Slides udostępnia interfejsy API do pracy z obliczeniami wykresów i danymi układu w prezentacjach. Ten artykuł pokazuje, jak pobrać rzeczywiste wartości elementów wykresu, w tym rzeczywistą pozycję i rozmiar elementów wykresu oraz rzeczywiste wartości osi wykresu. Wyjaśnia także, że wartości te są wypełniane po walidacji układu wykresu.

Dodatkowo artykuł demonstruje, jak uzyskać rzeczywistą pozycję nadrzędnych elementów wykresu oraz jak ukrywać komponenty wykresu, takie jak tytuł, osie, legenda i linie siatki. Razem te przykłady pomagają programowo sprawdzać informacje o układzie wykresu i kontrolować widoczność elementów wykresu w prezentacjach PowerPoint.

## **Obliczanie rzeczywistych wartości elementów wykresu**
Aspose.Slides for Python via Java provides a simple API for getting these properties. Methods of the [Axis](https://reference.aspose.com/slides/pl/python-java/aspose.slides/axis/) class provide information about the actual values of chart axes ([getActualMaxValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/pl/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/pl/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/pl/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/pl/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Call the [Chart.validateChartLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#validateChartLayout) method first to populate these properties with actual values.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Obliczanie rzeczywistej pozycji nadrzędnych elementów wykresu**
Aspose.Slides for Python via Java provides a simple API for getting these properties. Methods of the [ChartPlotArea](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartplotarea/) class provide information about the actual position and size of the chart plot area ([getActualX](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartplotarea/#getActualHeight)). Call the [Chart.validateChartLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#validateChartLayout) method first to populate these properties with actual values.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Ukrywanie elementów wykresu**
This section explains how to hide information from a chart. Using Aspose.Slides for Python via Java, you can hide the **Title, Vertical Axis, Horizontal Axis**, and **Grid Lines**. The following code example shows how to use these properties.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Ukryj tytuł wykresu.
    chart.setTitle(False)

    # Ukryj oś wartości.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Ukryj oś kategorii.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Ukryj legendę.
    chart.setLegend(False)

    # Ukryj główne linie siatki.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Zachowaj tylko pierwszą serię. Usuwanie od końca utrzymuje poprawność pozostałych indeksów.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Ustaw kolor linii serii.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy zewnętrzne skoroszyty Excel działają jako źródło danych i jak wpływa to na ponowne obliczenia?**

Tak. Wykres może odwoływać się do zewnętrznego skoroszytu: po połączeniu lub odświeżeniu zewnętrznego źródła, formuły i wartości są pobierane z tego skoroszytu, a wykres odzwierciedla aktualizacje podczas operacji otwierania/edycji. API umożliwia [określenie ścieżki do zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setExternalWorkbook) i zarządzanie powiązanymi danymi.

**Czy mogę obliczyć i wyświetlić linie trendu bez implementowania regresji samodzielnie?**

Tak. [Linie trendu](/slides/pl/python-java/trend-line/) (liniowe, wykładnicze i inne) są dodawane i aktualizowane przez Aspose.Slides; ich parametry są automatycznie przeliczane na podstawie danych serii, więc nie musisz implementować własnych obliczeń.

**Jeśli prezentacja zawiera wiele wykresów z zewnętrznymi odnośnikami, czy mogę kontrolować, który skoroszyt używa każdy wykres do obliczonych wartości?**

Tak. Każdy wykres może wskazywać własny [zewnętrzny skoroszyt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setExternalWorkbook), albo możesz tworzyć/zastępować zewnętrzny skoroszyt dla każdego wykresu niezależnie od pozostałych.