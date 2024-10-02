---
title: Область графика
type: docs
url: /ru/php-java/chart-plot-area/
---


## **Получить ширину и высоту области графика**
Aspose.Slides для PHP через Java предоставляет простой API для .

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте график с данными по умолчанию.
1. Вызовите метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) перед получением актуальных значений.
1. Получите актуальное положение по оси X (лево) элемента графика относительно верхнего левого угла графика.
1. Получите актуальное положение по оси Y (верх) элемента графика относительно верхнего левого угла графика.
1. Получите актуальную ширину элемента графика.
1. Получите актуальную высоту элемента графика.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установить режим компоновки области графика**
Aspose.Slides для PHP через Java предоставляет простой API для установки режима компоновки области графика. Методы [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) и [**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) были добавлены в класс [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) и интерфейс [**IChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartPlotArea). Если компоновка области графика определена вручную, это свойство указывает, следует ли компоновку области графика проводить внутри (не включая оси и подписи к осям) или снаружи (включая оси и подписи к осям). Существует два возможных значения, которые определены в перечислении [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - указывает, что размер области графика должен определять размер области графика, не включая метки делений и подписи к осям.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - указывает, что размер области графика должен определять размер области графика, включая метки делений и подписи к осям.

Пример кода приведен ниже.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```