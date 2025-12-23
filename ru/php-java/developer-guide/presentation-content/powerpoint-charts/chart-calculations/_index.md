---
title: "Оптимизация вычислений диаграмм для презентаций на PHP"
linktitle: "Вычисления диаграмм"
type: docs
weight: 50
url: /ru/php-java/chart-calculations/
keywords:
- "вычисления диаграмм"
- "элементы диаграмм"
- "позиция элемента"
- "фактическая позиция"
- "дочерний элемент"
- "родительский элемент"
- "значения диаграммы"
- "фактическое значение"
- "PowerPoint"
- "презентация"
- "PHP"
- "Aspose.Slides"
description: "Поймите вычисления диаграмм, обновление данных и контроль точности в Aspose.Slides for PHP via Java для PPT и PPTX, с практическими примерами кода."
---

## **Рассчитать фактические значения элементов диаграммы**
Aspose.Slides for PHP via Java предоставляет простой API для получения этих свойств. Свойства интерфейса [IAxis](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis) предоставляют информацию о фактическом положении элемента оси диаграммы ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnitScale--)). Необходимо вызвать метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) заранее, чтобы заполнить свойства фактическими значениями.
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


## **Рассчитать фактическую позицию родительских элементов диаграммы**
Aspose.Slides for PHP via Java предоставляет простой API для получения этих свойств. Свойства интерфейса [IActualLayout](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout) предоставляют информацию о фактической позиции родительского элемента диаграммы ([IActualLayout.getActualX](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualHeight--)). Необходимо вызвать метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) заранее, чтобы заполнить свойства фактическими значениями.
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


## **Скрыть элементы диаграммы**
Эта тема поможет вам понять, как скрыть информацию в диаграмме. С помощью Aspose.Slides for PHP via Java вы можете скрыть **заголовок, вертикальную ось, горизонтальную ось** и **линии сетки** в диаграмме. Ниже приведён пример кода, показывающий, как использовать эти свойства.
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
    # Скрытие основных линий сетки
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


## **FAQ**

**Работают ли внешние книги Excel в качестве источника данных и как это влияет на пересчёт?**

Да. Диаграмма может ссылаться на внешнюю книгу: при подключении или обновлении внешнего источника формулы и значения берутся из этой книги, и диаграмма отражает изменения во время открытых/редактируемых операций. API позволяет вам [указать путь к внешней книге](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) и управлять связанными данными.

**Могу ли я вычислять и отображать линии тренда без реализации регрессии самостоятельно?**

Да. [Trendlines](/slides/ru/php-java/trend-line/) (линейные, экспоненциальные и другие) добавляются и обновляются Aspose.Slides; их параметры автоматически пересчитываются из данных серии, поэтому вам не нужно реализовывать собственные вычисления.

**Если презентация содержит несколько диаграмм с внешними связями, могу ли я контролировать, какая книга используется каждой диаграммой для вычисляемых значений?**

Да. Каждая диаграмма может указывать на свою [внешнюю книгу](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), либо вы можете создавать/заменять внешнюю книгу для каждой диаграммы независимо от остальных.