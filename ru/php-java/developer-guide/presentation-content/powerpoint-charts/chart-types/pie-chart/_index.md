---
title: Настройка круговых диаграмм в презентациях с помощью PHP
linktitle: Круговая диаграмма
type: docs
url: /ru/php-java/pie-chart/
keywords:
- круговая диаграмма
- управление диаграммой
- настройка диаграммы
- параметры диаграммы
- настройки диаграммы
- параметры построения
- цвет сектора
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать и настраивать круговые диаграммы с помощью Aspose.Slides для PHP через Java, экспортировать их в PowerPoint и ускорять рассказ о данных за считанные секунды."
---

## **Вторичные параметры для диаграмм Pie of Pie и Bar of Pie**
Aspose.Slides for PHP via Java теперь поддерживает параметры второго графика для диаграмм Pie of Pie и Bar of Pie. В этой статье мы покажем, как задать эти параметры с помощью Aspose.Slides. Чтобы указать свойства, выполните следующее:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Укажите параметры второго графика диаграммы.
1. Сохраните презентацию на диск.

В приведённом ниже примере мы задали различные свойства диаграммы Pie of Pie.
```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Добавьте диаграмму на слайд
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Установите различные свойства
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Запишите презентацию на диск
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить автоматические цвета секторов круговой диаграммы**
Aspose.Slides for PHP via Java предоставляет простой API для автоматической установки цветов секторов круговой диаграммы. Пример кода применяет указанные выше свойства.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите заголовок диаграммы.
1. Включите отображение значений для первой серии.
1. Установите индекс листа данных диаграммы.
1. Получите лист данных диаграммы.
1. Удалите автоматически сгенерированные серии и категории.
1. Добавьте новые категории.
1. Добавьте новую серию.

Запишите изменённую презентацию в файл PPTX.
```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Добавьте диаграмму с данными по умолчанию
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Установка заголовка диаграммы
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Установите первую серию для отображения значений
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Установка индекса листа данных диаграммы
    $defaultWorksheetIndex = 0;
    # Получение листа данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Удаление автоматически сгенерированных серий и категорий
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Добавление новых категорий
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Добавление новой серии
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Теперь заполняем данные серии
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Вопросы и ответы**

**Поддерживаются ли варианты «Pie of Pie» и «Bar of Pie»?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) вторичный график для круговых диаграмм, включая типы «Pie of Pie» и «Bar of Pie».

**Можно ли экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (например, PNG) без всей презентации.