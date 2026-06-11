---
title: Optymalizacja obliczeń wykresów w prezentacjach w JavaScript
linktitle: Obliczenia wykresów
type: docs
weight: 50
url: /pl/nodejs-java/chart-calculations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Zrozum obliczenia wykresów, aktualizacje danych i kontrolę precyzji w Aspose.Slides for Node.js dla formatów PPT i PPTX, wraz z praktycznymi przykładami kodu JavaScript."
---
## **Przegląd**

Aspose.Slides udostępnia interfejsy API do pracy z obliczeniami wykresów i danymi układu w prezentacjach. Ten artykuł pokazuje, jak pobrać rzeczywiste wartości elementów wykresu, w tym rzeczywiste położenie i rozmiar elementów oraz rzeczywiste wartości osi wykresu. Wyjaśnia również, że te wartości są wypełniane po walidacji układu wykresu.

Ponadto artykuł demonstruje, jak uzyskać rzeczywiste położenie nadrzędnych elementów wykresu oraz jak ukrywać elementy wykresu, takie jak tytuł, osie, legenda i linie siatki. Razem te przykłady pomagają przeglądać informacje o układzie wykresu i sterować widocznością elementów wykresu w prezentacjach PowerPoint programowo.

## **Obliczanie rzeczywistych wartości elementów wykresu**

Aspose.Slides for Node.js via Java udostępnia prosty interfejs API do pobierania tych właściwości. Właściwości klasy [Axis](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Axis) dostarczają informacji o rzeczywistym położeniu elementu osi wykresu ([Axis.getActualMaxValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Należy najpierw wywołać metodę [Chart.validateChartLayout()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Chart#validateChartLayout--) , aby wypełnić właściwości rzeczywistymi wartościami.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Obliczanie rzeczywistego położenia nadrzędnych elementów wykresu**

Aspose.Slides for Node.js via Java udostępnia prosty interfejs API do pobierania tych właściwości. Właściwości klasy `ActualLayout` dostarczają informacji o rzeczywistym położeniu nadrzędnego elementu wykresu `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. Należy najpierw wywołać metodę [Chart.validateChartLayout()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Chart#validateChartLayout--) , aby wypełnić właściwości rzeczywistymi wartościami.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ukrywanie informacji na wykresie**

Ten temat pomaga zrozumieć, jak ukrywać informacje na wykresie. Korzystając z Aspose.Slides for Node.js via Java możesz ukryć **Tytuł, Oś pionową, Oś poziomą** oraz **Linie siatki** na wykresie. Poniższy przykład kodu pokazuje, jak używać tych właściwości.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Ukrywanie tytułu wykresu
    chart.setTitle(false);
    // /Ukrywanie osi wartości
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Widoczność osi kategorii
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Ukrywanie legendy
    chart.setLegend(false);
    // Ukrywanie głównych linii siatki
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Ustawianie koloru linii serii
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy zewnętrzne arkusze Excela działają jako źródło danych i jak to wpływa na przeliczanie?**

Tak. Wykres może odwoływać się do zewnętrznego skoroszytu: po połączeniu lub odświeżeniu zewnętrznego źródła, formuły i wartości są pobierane z tego skoroszytu, a wykres odzwierciedla aktualizacje podczas operacji otwierania/edycji. API pozwala [określić ścieżkę do zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) i zarządzać powiązanymi danymi.

**Czy mogę obliczyć i wyświetlić linie trendu bez własnej implementacji regresji?**

Tak. [Linie trendu](/slides/pl/nodejs-java/trend-line/) (liniowe, wykładnicze i inne) są dodawane i aktualizowane przez Aspose.Slides; ich parametry są automatycznie przeliczane na podstawie danych serii, więc nie musisz implementować własnych obliczeń.

**Jeśli prezentacja zawiera wiele wykresów z zewnętrznymi odnośnikami, czy mogę kontrolować, który skoroszyt każdy wykres używa do obliczonych wartości?**

Tak. Każdy wykres może wskazywać własny [zewnętrzny skoroszyt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), lub możesz utworzyć/zastąpić zewnętrzny skoroszyt dla każdego wykresu niezależnie od pozostałych.