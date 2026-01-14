---
title: Оптимизация вычислений диаграмм для презентаций на PHP
linktitle: Вычисления диаграмм
type: docs
weight: 50
url: /ru/php-java/chart-calculations/
keywords:
- вычисления диаграмм
- элементы диаграмм
- положение элемента
- фактическое положение
- дочерний элемент
- родительский элемент
- значения диаграммы
- фактическое значение
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Поймите вычисления диаграмм, обновление данных и управление точностью в Aspose.Slides for PHP via Java для PPT и PPTX, с практическими примерами кода."
---

## **Вычисление фактических значений элементов диаграммы**
Aspose.Slides for PHP via Java предоставляет простой API для получения этих свойств. Методы класса [Axis](https://reference.aspose.com/slides/php-java/aspose.slides/axis/) предоставляют информацию о фактическом положении элемента диаграммы оси ([getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/)). Необходимо предварительно вызвать метод [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/), чтобы заполнить свойства фактическими значениями.
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


## **Вычисление фактической позиции родительских элементов диаграммы**
Aspose.Slides for PHP via Java предоставляет простой API для получения этих свойств. Методы класса `ActualLayout` предоставляют информацию о фактическом положении родительского элемента диаграммы (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). Необходимо предварительно вызвать метод [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/), чтобы заполнить свойства фактическими значениями.
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


## **Скрытие элементов диаграммы**
Эта тема помогает понять, как скрыть информацию на диаграмме. С помощью Aspose.Slides for PHP via Java можно скрыть **Заголовок, Вертикальная ось, Горизонтальная ось** и **Линии сетки** на диаграмме. Приведённый ниже пример кода демонстрирует, как использовать эти свойства.
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


## **Вопросы и ответы**

**Работают ли внешние книги Excel в качестве источника данных и как это влияет на пересчёт?**

Да. Диаграмма может ссылаться на внешнюю книгу: при подключении или обновлении внешнего источника формулы и значения берутся из этой книги, и диаграмма отображает изменения во время открытых/изменяемых операций. API позволяет [указать внешнюю книгу](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) и управлять связанными данными.

**Могу ли я вычислять и отображать тренд‑линии без самостоятельной реализации регрессии?**

Да. [Трендовые линии](/slides/ru/php-java/trend-line/) (линейные, экспоненциальные и др.) добавляются и обновляются Aspose.Slides; их параметры автоматически пересчитываются из данных серии, поэтому вам не нужно реализовывать собственные расчёты.

**Если презентация содержит несколько диаграмм с внешними ссылками, могу ли я управлять тем, какую книгу каждая диаграмма использует для вычисляемых значений?**

Да. Каждая диаграмма может указывать свою собственную [внешнюю книгу](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), либо вы можете создавать/заменять внешнюю книгу для каждой диаграммы независимо от остальных.