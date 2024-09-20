---
title: Вычисления диаграмм
type: docs
weight: 50
url: /php-java/chart-calculations/
---

## **Вычисление фактических значений элементов диаграммы**
Aspose.Slides для PHP через Java предоставляет простой API для получения этих свойств. Свойства интерфейса [IAxis](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis) предоставляют информацию о фактическом положении элемента диаграммы оси ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnitScale--)). Перед заполнением свойств фактическими значениями необходимо вызвать метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--).

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

## **Вычисление фактического положения родительских элементов диаграммы**
Aspose.Slides для PHP через Java предоставляет простой API для получения этих свойств. Свойства интерфейса [IActualLayout](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout) предоставляют информацию о фактическом положении родительского элемента диаграммы ([IActualLayout.getActualX](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualHeight--)). Перед заполнением свойств фактическими значениями необходимо вызвать метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--).

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

## **Скрытие информации из диаграммы**
Эта тема поможет вам понять, как скрыть информацию из диаграммы. Используя Aspose.Slides для PHP через Java, вы можете скрыть **Заголовок, Вертикальную ось, Горизонтальную ось** и **Сетку** из диаграммы. Пример кода ниже показывает, как использовать эти свойства.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Скрытие заголовка диаграммы
    $chart->setTitle(false);
    # /Скрытие оси значений
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Видимость оси категорий
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Скрытие легенды
    $chart->setLegend(false);
    # Скрытие MajorGridLines
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Установка цвета линии серии
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