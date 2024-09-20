---
title: Маркер данных диаграммы
type: docs
url: /php-java/chart-data-marker/
---

## **Настройка параметров маркера диаграммы**
Маркеры могут быть настроены на точках данных диаграммы внутри конкретных серий. Для того чтобы настроить параметры маркера диаграммы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Создайте стандартную диаграмму.
- Установите изображение.
- Получите первую серию диаграммы.
- Добавьте новую точку данных.
- Сохраните презентацию на диск.

В приведенном ниже примере мы задали параметры маркера диаграммы на уровне точек данных.

```php
  # Создание пустой презентации
  $pres = new Presentation();
  try {
    # Доступ к первому слайду
    $slide = $pres->getSlides()->get_Item(0);
    # Создание стандартной диаграммы
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Получение индекса рабочего листа данных диаграммы
    $defaultWorksheetIndex = 0;
    # Получение рабочего листа данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Удаление демонстрационной серии
    $chart->getChartData()->getSeries()->clear();
    # Добавление новой серии
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Серия 1"), $chart->getType());
    # Загрузка изображения 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Загрузка изображения 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Получение первой серии диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Добавление новой точки (1:3) туда.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Изменение маркера серии диаграммы
    $series->getMarker()->setSize(15);
    # Сохранение презентации с диаграммой
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```