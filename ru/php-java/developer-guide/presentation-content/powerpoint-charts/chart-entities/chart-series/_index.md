---
title: Серии графиков
type: docs
url: /ru/php-java/chart-series/
keywords: "Серии графиков, цвет серий, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Серии графиков в презентациях PowerPoint"
---

Серия — это строка или столбец чисел, отложенных на графике.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установка перекрытия серий графика**

С помощью свойства [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) можно указать, насколько бары и столбцы должны перекрываться на 2D-графике (диапазон: -100 до 100). Это свойство применяется ко всем сериям группы родительских серий: это проекция соответствующего свойства группы. Поэтому это свойство только для чтения.

Используйте свойство `ParentSeriesGroup.Overlap` для чтения/записи, чтобы установить свое предпочтительное значение для `Overlap`.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Добавьте сгруппированный столбчатый график на слайд.
3. Получите доступ к первой серии графика.
4. Получите доступ к `ParentSeriesGroup` серии графика и установите свое предпочтительное значение перекрытия для серии.
5. Запишите измененную презентацию в файл PPTX.

Этот код PHP показывает, как установить перекрытие для серии графика:

```php
  $pres = new Presentation();
  try {
    # Добавляет график
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

## **Изменение цвета серии**
Aspose.Slides для PHP через Java позволяет вам изменить цвет серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Добавьте график на слайд.
3. Получите доступ к серии, цвет которой вы хотите изменить.
4. Установите свой предпочтительный тип заливки и цвет заливки.
5. Сохраните измененную презентацию.

Этот код PHP показывает, как изменить цвет серии:

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

## **Изменение цвета категории серии**
Aspose.Slides для PHP через Java позволяет вам изменить цвет категории серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Добавьте график на слайд.
3. Получите доступ к категории серии, цвет которой вы хотите изменить.
4. Установите свой предпочтительный тип заливки и цвет заливки.
5. Сохраните измененную презентацию.

Этот код показывает, как изменить цвет категории серии:

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

## **Изменение имени серии**

По умолчанию имена легенд для графика — это содержимое ячеек над каждым столбцом или строкой данных.

В нашем примере (образец изображения),

* столбцы — это *Серия 1, Серия 2,* и *Серия 3*;
* строки — это *Категория 1, Категория 2, Категория 3,* и *Категория 4*.

Aspose.Slides для PHP через Java позволяет вам обновить или изменить имя серии в данных графика и легенде.

Этот код PHP показывает, как изменить имя серии в данных графика `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("Новое имя");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Этот код PHP показывает, как изменить имя серии в легенде через`Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("Новое имя");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка цвета заливки серии графика**

Aspose.Slides для PHP через Java позволяет вам установить автоматический цвет заливки для серий графиков в области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте график с данными по умолчанию в зависимости от вашего предпочтительного типа (в приведенном ниже примере мы использовали `ChartType::ClusteredColumn`).
4. Получите доступ к сериям графика и установите цвет заливки на Авто.
5. Сохраните презентацию в файл PPTX.

Этот код PHP показывает, как установить автоматический цвет заливки для серии графика:

```php
  $pres = new Presentation();
  try {
    # Создает сгруппированный столбчатый график
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Устанавливает формат заливки серии на автоматический
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

## **Установка инвертированных цветов заливки серий графика**
Aspose.Slides позволяет вам установить инвертированный цвет заливки для серий графиков в области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте график с данными по умолчанию в зависимости от вашего предпочтительного типа (в приведенном ниже примере мы использовали `ChartType::ClusteredColumn`).
4. Получите доступ к сериями графика и установите цвет заливки на инвертированный.
5. Сохраните презентацию в файл PPTX.

Этот код PHP демонстрирует операцию:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Добавляет новые серии и категории
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Серия 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Категория 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Категория 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Категория 3"));
    # Берет первую серию графика и заполняет ее данные.
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

## **Установка инвертирования серии при отрицательном значении**
Aspose.Slides позволяет устанавливать инвертирование через свойства `IChartDataPoint.InvertIfNegative` и `ChartDataPoint.InvertIfNegative`. Когда инвертирование установлено с помощью свойств, точка данных инвертирует свои цвета, когда получает отрицательное значение.

Этот код PHP демонстрирует операцию:

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

## **Очистка данных конкретных точек данных**
Aspose.Slides для PHP через Java позволяет очистить данные `DataPoints` для конкретной серии графика следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на график по его индексу.
4. Переберите все `DataPoints` графика и установите `XValue` и `YValue` в null.
5. Очистите все `DataPoints` для конкретной серии графика.
6. Запишите измененную презентацию в файл PPTX.

Этот код PHP демонстрирует операцию:

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

## **Установка ширины зазора серии**
Aspose.Slides для PHP через Java позволяет установить ширину зазора серии через свойство **`GapWidth`** следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте график с данными по умолчанию.
4. Получите доступ к любой серии графика.
5. Установите свойство `GapWidth`.
6. Запишите измененную презентацию в файл PPTX.

Этот код показывает, как установить ширину зазора серии:

```php
  # Создает пустую презентацию
  $pres = new Presentation();
  try {
    # Получает первый слайд презентации
    $slide = $pres->getSlides()->get_Item(0);
    # Добавляет график с данными по умолчанию
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Устанавливает индекс листа данных графика
    $defaultWorksheetIndex = 0;
    # Получает лист данных графика
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Добавляет серии
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Серия 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Серия 2"), $chart->getType());
    # Добавляет категории
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Категория 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Категория 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Категория 3"));
    # Берет вторую серию графика
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