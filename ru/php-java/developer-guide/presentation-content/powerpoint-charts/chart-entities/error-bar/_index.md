---
title: Настройка линий ошибок в диаграммах презентаций с использованием PHP
linktitle: Линия ошибок
type: docs
url: /ru/php-java/error-bar/
keywords:
- линия ошибок
- пользовательское значение
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как добавлять и настраивать линии ошибок на диаграммах с помощью Aspose.Slides for PHP via Java — оптимизируйте визуализацию данных в презентациях PowerPoint."
---

## **Добавить линии ошибок**
Aspose.Slides for PHP via Java предоставляет простой API для управления значениями линий ошибок. Пример кода применяется при использовании пользовательского типа значения. Чтобы задать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат линии ошибок X.
1. Получите первую серию диаграммы и задайте формат линии ошибок Y.
1. Установите значения линий и их формат.
1. Сохраните изменённую презентацию в файл PPTX.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Создание пузырчатой диаграммы
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Добавление линий ошибок и установка их формата
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Сохранение презентации
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Добавить пользовательские значения линии ошибок**
Aspose.Slides for PHP via Java предоставляет простой API для управления пользовательскими значениями линий ошибок. Пример кода применяется, когда свойство [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--) равно **Custom**. Чтобы задать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат линии ошибок X.
1. Получите первую серию диаграммы и задайте формат линии ошибок Y.
1. Получите отдельные точки данных серии диаграммы и задайте значения линии ошибок для каждой отдельной точки данных серии.
1. Установите значения линий и их формат.
1. Сохраните изменённую презентацию в файл PPTX.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Создание пузырчатой диаграммы
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Добавление пользовательских линий ошибок и установка их формата
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Доступ к точке данных серии диаграммы и установка значений линий ошибок для
    # отдельной точки
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Установка линий ошибок для точек серии диаграммы
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Сохранение презентации
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Что происходит с линиями ошибок при экспорте презентации в PDF или изображения?**

Они отрисовываются как часть диаграммы и сохраняются при конвертации вместе с остальным форматированием диаграммы, при условии совместимой версии или рендерера.

**Можно ли комбинировать линии ошибок с маркерами и метками данных?**

Да. Линии ошибок являются отдельным элементом и совместимы с маркерами и метками данных; если элементы перекрываются, возможно, придётся скорректировать форматирование.

**Где можно найти список свойств и классов для работы с линиями ошибок в API?**

В справочнике API: класс [ErrorBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/) и связанные классы [ErrorBarType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbartype/) и [ErrorBarValueType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarvaluetype/).