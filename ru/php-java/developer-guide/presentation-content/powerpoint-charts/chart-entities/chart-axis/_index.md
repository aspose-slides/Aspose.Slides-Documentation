---
title: Настройка осей диаграмм в презентациях с помощью PHP
linktitle: Ось диаграммы
type: docs
url: /ru/php-java/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- управление осью
- управление осью
- свойства оси
- максимальное значение
- минимальное значение
- линия оси
- формат даты
- заголовок оси
- позиция оси
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides for PHP via Java для настройки осей диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---

## **Получить максимальные значения на вертикальной оси диаграмм**
Aspose.Slides for PHP via Java позволяет получать минимальные и максимальные значения на вертикальной оси. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Получите фактическое максимальное значение на оси.
1. Получите фактическое минимальное значение на оси.
1. Получите фактическую основную единицу измерения оси.
1. Получите фактическую вспомогательную единицу измерения оси.
1. Получите фактический масштаб основной единицы измерения оси.
1. Получите фактический масштаб вспомогательной единицы измерения оси.

Этот пример кода — реализация вышеуказанных шагов — показывает, как получить требуемые значения :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Сохраняет презентацию
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Переставить данные между осями**
Aspose.Slides позволяет быстро переставлять данные между осями — данные, представленные на вертикальной оси (y‑ось), перемещаются на горизонтальную ось (x‑ось) и наоборот.

Этот PHP‑код показывает, как выполнить задачу перестановки данных между осями на диаграмме:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Переключает строки и столбцы
    $chart->getChartData()->switchRowColumn();
    # Сохраняет презентацию
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Отключить вертикальную ось для линейных диаграмм**
Этот PHP‑код показывает, как скрыть вертикальную ось для линейной диаграммы:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Отключить горизонтальную ось для линейных диаграмм**
Этот код показывает, как скрыть горизонтальную ось для линейной диаграммы:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Изменить категориальную ось**
С помощью свойства **CategoryAxisType** вы можете указать желаемый тип категориальной оси (**date** или **text**). Этот код демонстрирует операцию:
```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Установить формат даты для значений категориальной оси**
Aspose.Slides for PHP via Java позволяет установить формат даты для значения категориальной оси. Операция продемонстрирована в этом PHP‑коде:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **Установить угол поворота заголовка оси диаграммы**
Aspose.Slides for PHP via Java позволяет установить угол поворота заголовка оси диаграммы. Этот PHP‑код демонстрирует операцию:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить положение оси на категориальной или оси значений**
Aspose.Slides for PHP via Java позволяет установить позицию оси в категориальной или оси значений. Этот PHP‑код показывает, как выполнить задачу:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Включить отображение подписи единицы измерения на оси значений диаграммы**
Aspose.Slides for PHP via Java позволяет настроить диаграмму для отображения подписи единицы измерения на оси значений. Этот PHP‑код демонстрирует операцию:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Часто задаваемые вопросы**

**Как задать значение, где одна ось пересекает другую (пересечение осей)?**

Оси предоставляют [crossing setting](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/): вы можете выбрать пересечение в нуле, в максимальной категории/значении или в конкретном числовом значении. Это полезно для смещения оси X вверх или вниз или для выделения базовой линии.

**Как позиционировать метки делений относительно оси (рядом, снаружи, внутри)?**

Установите [label position](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) в значение "cross", "outside" или "inside". Это влияет на читаемость и помогает экономить место, особенно на маленьких диаграммах.