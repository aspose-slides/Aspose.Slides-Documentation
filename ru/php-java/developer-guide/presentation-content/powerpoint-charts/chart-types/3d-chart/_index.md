---
title: 3D график
type: docs
url: /php-java/3d-chart/
---

## **Установите свойства RotationX, RotationY и DepthPercents для 3D графика**
Aspose.Slides для PHP через Java предоставляет простой API для настройки этих свойств. Следующая статья поможет вам установить различные свойства, такие как **X, Y Rotation, DepthPercents** и т. д. Пример кода применяет настройку вышеуказанных свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите первый слайд.
1. Добавьте график с данными по умолчанию.
1. Установите свойства Rotation3D.
1. Запишите измененную презентацию в файл PPTX.

```php
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавьте график с данными по умолчанию
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Установка индекса листа данных графика
    $defaultWorksheetIndex = 0;
    # Получение листа данных графика
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Добавьте серии
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Серия 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Серия 2"), $chart->getType());
    # Добавьте категории
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Категория 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Категория 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Категория 3"));
    # Установите свойства Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Получите вторую серию графика
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Теперь заполняем данные серии
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Установите значение OverLap
    $series->getParentSeriesGroup()->setOverlap(100);
    # Запишите презентацию на диск
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```