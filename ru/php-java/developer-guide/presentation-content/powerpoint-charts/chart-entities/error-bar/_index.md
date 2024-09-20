---
title: Ошибка бар
type: docs
url: /php-java/error-bar/
---

## **Добавить Ошибка бар**
Aspose.Slides для PHP через Java предоставляет простой API для управления значениями ошибки бар. Пример кода применяется при использовании пользовательского типа значения. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте пузырьковую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и установите формат ошибки бар X.
1. Получите первую серию диаграммы и установите формат ошибки бар Y.
1. Установите значения и формат баров.
1. Запишите измененную презентацию в файл PPTX.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Создание пузырьковой диаграммы
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Добавление ошибок бар и установка его формата
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

## **Добавить пользовательское значение ошибки бар**
Aspose.Slides для PHP через Java предоставляет простой API для управления пользовательскими значениями ошибки бар. Пример кода применяется, когда свойство [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--) равно **Custom**. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Добавьте пузырьковую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и установите формат ошибки бар X.
1. Получите первую серию диаграммы и установите формат ошибки бар Y.
1. Получите отдельные точки данных серии диаграммы и установите значения ошибки бар для индивидуальной точки данных серии.
1. Установите значения и формат баров.
1. Запишите измененную презентацию в файл PPTX.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Создание пузырьковой диаграммы
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Добавление пользовательских ошибок бар и установка его формата
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Доступ к точкам данных серии диаграммы и установка значений ошибок бар для
    # отдельной точки
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Установка ошибок бар для точек серии диаграммы
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