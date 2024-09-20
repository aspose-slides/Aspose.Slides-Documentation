---
title: Легенда графика
type: docs
url: /php-java/chart-legend/
---

## **Позиционирование легенды**
Чтобы задать свойства легенды, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд.
- Добавьте график на слайд.
- Установите свойства легенды.
- Запишите презентацию в файл PPTX.

В приведенном ниже примере мы установили положение и размер для легенды графика.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получите ссылку на слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавьте кластеризированный столбчатый график на слайд
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Установите свойства легенды
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Запишите презентацию на диск
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установите размер шрифта легенды**
Aspose.Slides для PHP через Java позволяет разработчикам устанавливать размер шрифта легенды. Пожалуйста, выполните следующие шаги:

- Инстанцируйте класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Создайте стандартный график.
- Установите размер шрифта.
- Установите минимальное значение оси.
- Установите максимальное значение оси.
- Запишите презентацию на диск.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установите размер шрифта для отдельных элементов легенды**
Aspose.Slides для PHP через Java позволяет разработчикам устанавливать размер шрифта для отдельных элементов легенды. Пожалуйста, выполните следующие шаги:

- Инстанцируйте класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Создайте стандартный график.
- Получите доступ к элементу легенды.
- Установите размер шрифта.
- Установите минимальное значение оси.
- Установите максимальное значение оси.
- Запишите презентацию на диск.

```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```