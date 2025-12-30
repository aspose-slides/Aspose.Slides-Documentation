---
title: Управление сериями данных диаграмм в презентациях с помощью PHP
linktitle: Серии данных
type: docs
url: /ru/php-java/chart-series/
keywords:
- серии диаграмм
- перекрытие серий
- цвет серии
- цвет категории
- имя серии
- точка данных
- промежуток серии
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как управлять сериями данных диаграмм в PHP для PowerPoint (PPT/PPTX) с практическими примерами кода и лучшими практиками для улучшения ваших презентаций данных."
---

Ряд (или столбец) — это набор чисел, отображаемый на диаграмме.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серии диаграммы**

С помощью свойства [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) вы можете указать, насколько столбцы и бары должны перекрываться на 2D‑диаграмме (диапазон: -100 до 100). Это свойство применяется ко всем сериям родительской группы серий: это проекция соответствующего свойства группы. Следовательно, это свойство доступно только для чтения.

Используйте свойство `ParentSeriesGroup.Overlap` для чтения/записи, чтобы задать желаемое значение `Overlap`.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте кластеризованную столбчатую диаграмму на слайд.
1. Получите доступ к первой серии диаграммы.
1. Получите доступ к `ParentSeriesGroup` серии диаграммы и задайте желаемое значение перекрытия для серии.
1. Сохраните изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как установить перекрытие для серии диаграммы:
```php
  $pres = new Presentation();
  try {
    # Добавляет диаграмму
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Устанавливает перекрытие серии
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Записывает файл презентации на диск
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Изменить цвет серии**

Aspose.Slides for PHP via Java позволяет изменить цвет серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Получите доступ к серии, цвет которой вы хотите изменить.
1. Установите желаемый тип заливки и цвет заливки.
1. Сохраните изменённую презентацию.

Этот PHP‑код демонстрирует, как изменить цвет серии:
```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Изменить цвет категории серии**

Aspose.Slides for PHP via Java позволяет изменить цвет категории серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Получите доступ к категории серии, цвет которой вы хотите изменить.
1. Установите желаемый тип заливки и цвет заливки.
1. Сохраните изменённую презентацию.

Этот код демонстрирует, как изменить цвет категории серии:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Изменить имя серии** 

По умолчанию имена в легенде диаграммы берутся из содержимого ячеек над каждым столбцом или строкой данных. 

В нашем примере (пример изображения),

* столбцы — *Series 1, Series 2,* и *Series 3*;
* строки — *Category 1, Category 2, Category 3,* и *Category 4.* 

Aspose.Slides for PHP via Java позволяет обновлять или изменять имя серии в данных диаграммы и в легенде.

Этот PHP‑код демонстрирует, как изменить имя серии в данных диаграммы `ChartDataWorkbook`:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Этот PHP‑код демонстрирует, как изменить имя серии в легенде через`Series`:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить цвет заливки серии диаграммы**

Aspose.Slides for PHP via Java позволяет задать автоматический цвет заливки для серии диаграммы внутри области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию, основываясь на выбранном типе (в примере ниже мы использовали `ChartType::ClusteredColumn`).
1. Получите доступ к серии диаграммы и задайте цвет заливки как Automatic.
1. Сохраните презентацию в файл PPTX.

Этот PHP‑код демонстрирует, как задать автоматический цвет заливки для серии диаграммы:
```php
  $pres = new Presentation();
  try {
    # Создает кластеризованную столбчатую диаграмму
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Устанавливает автоматический формат заливки серии
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Записывает файл презентации на диск
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Задать инвертированный цвет заливки для серии диаграммы**

Aspose.Slides позволяет задать инвертированный цвет заливки для серии диаграммы внутри области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию, основываясь на выбранном типе (в примере ниже мы использовали `ChartType::ClusteredColumn`).
1. Получите доступ к серии диаграммы и задайте цвет заливки как invert.
1. Сохраните презентацию в файл PPTX.

Этот PHP‑код демонстрирует операцию:
```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Добавляет новые серии и категории
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Берёт первую серию диаграммы и заполняет её данные.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Задать инвертирование серии при отрицательном значении**

Aspose.Slides позволяет задавать инвертирование через свойства`IChartDataPoint.InvertIfNegative` и `ChartDataPoint.InvertIfNegative`. При установленном инвертировании точка данных меняет цвета, когда получает отрицательное значение. 

Этот PHP‑код демонстрирует операцию:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Очистить данные конкретной точки**

Aspose.Slides for PHP via Java позволяет очистить данные `DataPoints` для конкретной серии диаграммы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на диаграмму по её индексу.
4. Переберите все `DataPoints` диаграммы и задайте `XValue` и `YValue` значение null.
5. Очистите все`DataPoints` для конкретной серии диаграммы.
6. Сохраните изменённую презентацию в файл PPTX.

Этот PHP‑код демонстрирует операцию:
```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Задать ширину промежутка серии**

Aspose.Slides for PHP via Java позволяет задать ширину промежутка (**`GapWidth`**) для серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Получите доступ к любой серии диаграммы.
1. Задайте свойство `GapWidth`.
1. Сохраните изменённую презентацию в файл PPTX.

Этот код демонстрирует, как задать ширину промежутка серии:
```php
  # Создает пустую презентацию
  $pres = new Presentation();
  try {
    # Получает первый слайд презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет диаграмму с данными по умолчанию
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Устанавливает индекс листа данных диаграммы
    $defaultWorksheetIndex = 0;
    # Получает лист данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Добавляет серии
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Добавляет категории
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Получает вторую серию диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Заполняет данные серии
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Устанавливает значение GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Сохраняет презентацию на диск
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Часто задаваемые вопросы**

**Есть ли ограничение на количество серий в одной диаграмме?**

Aspose.Slides не накладывает фиксированного ограничения на количество добавляемых серий. Практический предел определяется читаемостью диаграммы и объёмом доступной памяти вашего приложения.

**Что делать, если столбцы в кластере расположены слишком близко друг к другу или слишком далеко?**

Отрегулируйте параметр `GapWidth` для этой серии (или её родительской группы серий). Увеличение значения расширяет пространство между столбцами, уменьшение — делает их ближе друг к другу.