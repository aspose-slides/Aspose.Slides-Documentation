---
title: Настройка 3D диаграмм в презентациях с помощью PHP
linktitle: 3D Диаграмма
type: docs
url: /ru/php-java/3d-chart/
keywords:
- 3D диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать и настраивать 3-D диаграммы в Aspose.Slides for PHP via Java, с поддержкой файлов PPT и PPTX — улучшите свои презентации уже сегодня."
---

## **Установите свойства RotationX, RotationY и DepthPercents трехмерной диаграммы**
Aspose.Slides for PHP via Java предоставляет простой API для установки этих свойств. В следующей статье показано, как установить различные свойства, такие как **X, Y Rotation, DepthPercents** и др. Пример кода демонстрирует настройку указанных выше свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Добавьте диаграмму с данными по умолчанию.
4. Установите свойства Rotation3D.
5. Запишите изменённую презентацию в файл PPTX.
```php
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить диаграмму с данными по умолчанию
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Установка индекса листа данных диаграммы
    $defaultWorksheetIndex = 0;
    # Получение листа данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Добавить серию
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Добавить категории
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Установить свойства Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Получить вторую серию диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Сейчас заполняем данные серии
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Установить значение Overlap
    $series->getParentSeriesGroup()->setOverlap(100);
    # Сохранить презентацию на диск
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Какие типы диаграмм поддерживают 3D-режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D-варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100% Stacked Column 3D, а также связанные 3D-типы, доступные через класс [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Для точного актуального списка проверьте члены [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) в справочнике API вашей установленной версии.

**Можно ли получить растровое изображение 3D-диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение через [chart API](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) или [отобразить весь слайд](/slides/ru/php-java/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это полезно, когда требуется пиксельно‑точный превью или нужно встроить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости использовать PowerPoint.

**Насколько производительно построение и рендеринг больших 3D-диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для достижения наилучших результатов держите 3D‑эффекты минимальными, избегайте тяжёлых текстур на стенах и областях построения, по возможности ограничивайте количество точек данных в серии и рендерьте в вывод подходящего размера (разрешение и размеры), соответствующий целевому дисплею или печати.