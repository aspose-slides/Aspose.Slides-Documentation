---
title: Optymalizacja obliczeń wykresów w prezentacjach w PHP
linktitle: Obliczenia wykresów
type: docs
weight: 50
url: /pl/php-java/chart-calculations/
keywords:
- obliczenia wykresu
- elementy wykresu
- pozycja elementu
- rzeczywista pozycja
- element podrzędny
- element nadrzędny
- wartości wykresu
- rzeczywista wartość
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zrozum obliczenia wykresów, aktualizacje danych i kontrolę precyzji w Aspose.Slides dla PHP via Java dla plików PPT i PPTX, z praktycznymi przykładami kodu."
---
## **Przegląd**

Aspose.Slides udostępnia interfejsy API do pracy z obliczeniami wykresów i danymi układu w prezentacjach. Ten artykuł pokazuje, jak pobrać rzeczywiste wartości elementów wykresu, w tym rzeczywistą pozycję i rozmiar elementów oraz rzeczywiste wartości osi wykresu. Wyjaśnia również, że wartości te są wypełniane po weryfikacji układu wykresu.

Ponadto artykuł demonstruje, jak uzyskać rzeczywistą pozycję elementów nadrzędnych wykresu oraz jak ukrywać komponenty wykresu, takie jak tytuł, osie, legenda i linie siatki. Razem te przykłady pomagają przeglądać informacje o układzie wykresu i sterować widocznością elementów wykresu w prezentacjach PowerPoint programowo.

## **Oblicz rzeczywiste wartości elementów wykresu**
Aspose.Slides dla PHP via Java zapewnia prosty interfejs API do pobierania tych właściwości. Metody klasy [Axis](https://reference.aspose.com/slides/pl/php-java/aspose.slides/axis/) dostarczają informacji o rzeczywistej pozycji elementu osi wykresu ([getActualMaxValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/pl/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/pl/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/pl/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/pl/php-java/aspose.slides/axis/getactualminorunitscale/)). Należy wcześniej wywołać metodę [Chart.validateChartLayout](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/validatechartlayout/), aby wypełnić właściwości rzeczywistymi wartościami.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Oblicz rzeczywistą pozycję elementów nadrzędnych wykresu**
Aspose.Slides dla PHP via Java zapewnia prosty interfejs API do pobierania tych właściwości. Metody klasy `ActualLayout` dostarczają informacji o rzeczywistej pozycji elementu nadrzędnego wykresu (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). Należy wcześniej wywołać metodę [Chart.validateChartLayout](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/validatechartlayout/), aby wypełnić właściwości rzeczywistymi wartościami.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ukryj elementy wykresu**
Ten temat pomaga zrozumieć, jak ukrywać informacje w wykresie. Korzystając z Aspose.Slides dla PHP via Java możesz ukryć **Tytuł, Oś pionową, Oś poziomą** oraz **Linie siatki** w wykresie. Poniższy przykład kodu pokazuje, jak używać tych właściwości.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Ukrywanie tytułu wykresu
    $chart->setTitle(false);
    # /Ukrywanie osi wartości
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Widoczność osi kategorii
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Ukrywanie legendy
    $chart->setLegend(false);
    # Ukrywanie głównych linii siatki
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Ustawianie koloru linii serii
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy zewnętrzne skoroszyty Excel mogą być używane jako źródło danych i jak to wpływa na ponowne obliczenia?**

Tak. Wykres może odwoływać się do zewnętrznego skoroszytu: po połączeniu lub odświeżeniu zewnętrznego źródła, formuły i wartości są pobierane z tego skoroszytu, a wykres odzwierciedla aktualizacje podczas operacji otwierania/edytowania. API umożliwia [określenie zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/setexternalworkbook/) ścieżki i zarządzanie połączonymi danymi.

**Czy mogę obliczyć i wyświetlić linie trendu bez własnej implementacji regresji?**

Tak. [Trendlines](/slides/pl/php-java/trend-line/) (linia, wykładnicza i inne) są dodawane i aktualizowane przez Aspose.Slides; ich parametry są automatycznie przeliczane na podstawie danych serii, więc nie musisz implementować własnych obliczeń.

**Jeśli prezentacja zawiera wiele wykresów z zewnętrznymi odnośnikami, czy mogę kontrolować, który skoroszyt używa każdy wykres do obliczonych wartości?**

Tak. Każdy wykres może wskazywać własny [zewnętrzny skoroszyt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/setexternalworkbook/), lub możesz utworzyć/zastąpić zewnętrzny skoroszyt dla każdego wykresu niezależnie od pozostałych.