---
title: Управление подписями данных диаграмм в презентациях с использованием PHP
linktitle: Подпись данных
type: docs
url: /ru/php-java/chart-data-label/
keywords:
- диаграмма
- подпись данных
- точность данных
- процент
- расстояние подписи
- расположение подписи
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как добавлять и форматировать подписи данных диаграмм в презентациях PowerPoint с помощью Aspose.Slides for PHP via Java для более увлекательных слайдов."
---

Подписи данных на диаграмме показывают детали о серии данных диаграммы или отдельных точках данных. Они позволяют читателям быстро идентифицировать серии данных и делают диаграммы более понятными.

## **Установить точность данных в подписи диаграммы**
Этот PHP‑код показывает, как установить точность данных в подписи диаграммы:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Отображать процент в подписи**
Aspose.Slides для PHP через Java позволяет задавать процентные подписи на отображаемых диаграммах. Этот PHP‑код демонстрирует эту операцию:
```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # Сохраняет презентацию, содержащую диаграмму
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить знак процента в подписи диаграммы**
Этот PHP‑код показывает, как установить знак процента в подписи диаграммы:
```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получает ссылку на слайд по его индексу
    $slide = $pres->getSlides()->get_Item(0);
    # Создает диаграмму PercentsStackedColumn на слайде
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # Устанавливает NumberFormatLinkedToSource в false
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # Получает лист данных диаграммы
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # Добавляет новую серию
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # Устанавливает цвет заливки серии
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Устанавливает свойства формата подписи
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Добавляет новую серию
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # Устанавливает тип заливки и цвет
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # Записывает презентацию на диск
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить расстояние подписи от оси**
Этот PHP‑код показывает, как установить расстояние подписи от категориальной оси при работе с диаграммой, построенной по осям:
```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получает ссылку на слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Создает диаграмму на слайде
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # Устанавливает расстояние подписи от оси
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # Записывает презентацию на диск
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Отрегулировать положение подписи**
Когда вы создаёте диаграмму, не зависящую от осей, например круговую диаграмму, подписи данных могут оказаться слишком близко к её краю. В таком случае необходимо отрегулировать положение подписи, чтобы линии‑выноски отображались чётко.
Этот PHP‑код показывает, как отрегулировать положение подписи на круговой диаграмме:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **Вопросы и ответы**

**Как предотвратить перекрытие подписей данных на насыщенных диаграммах?**  
Используйте автоматическое размещение подписей, линии‑выноски и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или отображайте подписи только для экстремальных/ключевых точек.

**Как отключить подписи только для нулевых, отрицательных или пустых значений?**  
Отфильтруйте точки данных перед включением подписей и отключите отображение для значений 0, отрицательных значений или отсутствующих значений в соответствии с определённым правилом.

**Как обеспечить согласованный стиль подписи при экспорте в PDF/изображения?**  
Явно задайте шрифты (семейство, размер) и убедитесь, что шрифт доступен на стороне рендеринга, чтобы избежать замены.