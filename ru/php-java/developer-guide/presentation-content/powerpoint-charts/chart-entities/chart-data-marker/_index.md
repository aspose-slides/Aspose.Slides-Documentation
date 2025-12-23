---
title: Управление маркерами данных диаграммы в презентациях с использованием PHP
linktitle: Маркер данных
type: docs
url: /ru/php-java/chart-data-marker/
keywords:
- диаграмма
- точка данных
- маркер
- параметры маркера
- размер маркера
- тип заливки
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как настроить маркеры данных диаграммы в Aspose.Slides для PHP, повышая эффективность презентаций в форматах PPT и PPTX с помощью понятных примеров кода."
---

## **Установить параметры маркеров диаграммы**
Маркеры можно задать для точек данных диаграммы внутри конкретных рядов. Чтобы установить параметры маркеров диаграммы, выполните следующие шаги:

- Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Создать диаграмму по умолчанию.
- Установить изображение.
- Получить первый ряд диаграммы.
- Добавить новую точку данных.
- Сохранить презентацию на диск.

В приведенном ниже примере мы задали параметры маркеров диаграммы на уровне точек данных.
```php
  # Создание пустой презентации
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Создание стандартной диаграммы
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Получение индекса листа данных диаграммы по умолчанию
    $defaultWorksheetIndex = 0;
    # Получение листа данных диаграммы
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Удалить демонстрационные серии
    $chart->getChartData()->getSeries()->clear();
    # Добавить новую серию
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Загрузить изображение 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Загрузить изображение 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Получить первую серию диаграммы
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Добавить новую точку (1:3) туда.
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
    # Сохранить презентацию с диаграммой
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Какие формы маркеров доступны из коробки?**

Доступны стандартные формы (круг, квадрат, ромб, треугольник и т.д.); список определяется классом [MarkerStyleType](https://reference.aspose.com/slides/php-java/aspose.slides/markerstyletype/). Если нужна нестандартная форма, используйте маркер с заполнением изображением, чтобы имитировать пользовательскую визуализацию.

**Сохраняются ли маркеры при экспорте диаграммы в изображение или SVG?**

Да. При рендеринге диаграмм в [растровые форматы](/slides/ru/php-java/convert-powerpoint-to-png/) или сохранении [форм в SVG](/slides/ru/php-java/render-a-slide-as-an-svg-image/), маркеры сохраняют свой внешний вид и настройки, включая размер, заливку и контур.