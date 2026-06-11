---
title: Optymalizacja obliczeń wykresów w prezentacjach w Javie
linktitle: Obliczenia wykresów
type: docs
weight: 50
url: /pl/java/chart-calculations/
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
- Java
- Aspose.Slides
description: "Zrozum obliczenia wykresów, aktualizacje danych i kontrolę precyzji w Aspose.Slides dla Javy w formatach PPT i PPTX, z praktycznymi przykładami kodu w Javie."
---
## **Przegląd**

Aspose.Slides udostępnia interfejsy API do pracy z obliczeniami wykresów i danymi układu w prezentacjach. Ten artykuł pokazuje, jak pobrać rzeczywiste wartości elementów wykresu, w tym rzeczywistą pozycję i rozmiar elementów implementujących `IActualLayout` oraz rzeczywiste wartości osi wykresu. Wyjaśnia także, że wartości te są wypełniane po walidacji układu wykresu.

Dodatkowo artykuł demonstruje, jak uzyskać rzeczywistą pozycję nadrzędnych elementów wykresu oraz jak ukrywać komponenty wykresu, takie jak tytuł, osie, legenda i linie siatki. Razem te przykłady pomagają przeglądać informacje o układzie wykresu i programowo kontrolować widoczność elementów wykresu w prezentacjach PowerPoint.

## **Obliczanie rzeczywistych wartości elementów wykresu**
Aspose.Slides for Java udostępnia prosty interfejs API do pobierania tych właściwości. Właściwości interfejsu [IAxis](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAxis) dostarczają informacji o rzeczywistej pozycji elementu osi wykresu ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Należy wcześniej wywołać metodę [IChart.validateChartLayout()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChart#validateChartLayout--) aby wypełnić właściwości rzeczywistymi wartościami.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obliczanie rzeczywistej pozycji nadrzędnych elementów wykresu**
Aspose.Slides for Java udostępnia prosty interfejs API do pobierania tych właściwości. Właściwości interfejsu [IActualLayout](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IActualLayout) dostarczają informacji o rzeczywistej pozycji nadrzędnego elementu wykresu ([IActualLayout.getActualX](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IActualLayout#getActualHeight--)). Należy wcześniej wywołać metodę [IChart.validateChartLayout()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChart#validateChartLayout--) aby wypełnić właściwości rzeczywistymi wartościami.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ukrywanie elementów wykresu**
Ten temat pomaga zrozumieć, jak ukrywać informacje na wykresie. Korzystając z Aspose.Slides for Java możesz ukryć **Tytuł, Oś pionową, Oś poziomą** oraz **Linie siatki** na wykresie. Poniższy przykład kodu pokazuje, jak używać tych właściwości.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Ukrywanie tytułu wykresu
    chart.setTitle(false);

    ///Ukrywanie osi wartości
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Widoczność osi kategorii
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Ukrywanie legendy
    chart.setLegend(false);

    //Ukrywanie głównych linii siatki
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Ustawianie koloru linii serii
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy zewnętrzne skoroszyty Excela działają jako źródło danych i jak to wpływa na przeliczanie?**

Tak. Wykres może odwoływać się do zewnętrznego skoroszytu: gdy połączysz się lub odświeżysz zewnętrzne źródło, formuły i wartości są pobierane z tego skoroszytu, a wykres odzwierciedla aktualizacje podczas operacji otwierania/edycji. API umożliwia [określenie zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) oraz zarządzanie połączonymi danymi.

**Czy mogę obliczyć i wyświetlić linie trendu bez samodzielnego implementowania regresji?**

Tak. [Linie trendu](/slides/pl/java/trend-line/) (liniowe, wykładnicze i inne) są dodawane i aktualizowane przez Aspose.Slides; ich parametry są automatycznie przeliczane na podstawie danych serii, więc nie musisz implementować własnych obliczeń.

**Jeśli prezentacja zawiera wiele wykresów z zewnętrznymi odnośnikami, czy mogę kontrolować, który skoroszyt używa każdy wykres do obliczonych wartości?**

Tak. Każdy wykres może wskazywać własny [zewnętrzny skoroszyt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), lub możesz utworzyć/zastąpić zewnętrzny skoroszyt dla każdego wykresu niezależnie od pozostałych.