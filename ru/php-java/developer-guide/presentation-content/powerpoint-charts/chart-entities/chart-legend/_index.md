---
title: Настройка легенд диаграмм в презентациях с использованием PHP
linktitle: Легенда диаграммы
type: docs
url: /ru/php-java/chart-legend/
keywords:
- легенда диаграммы
- положение легенды
- размер шрифта
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides for PHP via Java, чтобы оптимизировать презентации PowerPoint с индивидуальным форматированием легенд."
---

## **Расположение легенды**
Чтобы задать свойства легенды, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд.
- Добавьте диаграмму на слайд.
- Установите свойства легенды.
- Сохраните презентацию в файл PPTX.

В приведённом ниже примере мы задали положение и размер легенды диаграммы.
```php
  # Создайте экземпляр класса Presentation
  $pres = new Presentation();
  try {
    # Получите ссылку на слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавьте на слайд группированную столбчатую диаграмму
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Установите свойства легенды
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Сохраните презентацию на диск
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить размер шрифта легенды**
Aspose.Slides for PHP via Java позволяет разработчикам задавать размер шрифта легенды. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Создайте диаграмму по умолчанию.
- Установите размер шрифта.
- Задайте минимальное значение оси.
- Задайте максимальное значение оси.
- Сохраните презентацию на диск.
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


## **Установить размер шрифта отдельной записи легенды**
Aspose.Slides for PHP via Java позволяет разработчикам задавать размер шрифта отдельных записей легенды. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Создайте диаграмму по умолчанию.
- Получите доступ к записи легенды.
- Установите размер шрифта.
- Задайте минимальное значение оси.
- Задайте максимальное значение оси.
- Сохраните презентацию на диск.
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


## **FAQ**

**Могу ли я включить легенду, чтобы диаграмма автоматически выделяла для неё место вместо наложения?**

Да. Используйте режим без наложения ([setOverlay(false)](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/)); в этом случае область построения уменьшится, чтобы разместить легенду.

**Могу ли я сделать многострочные подписи легенды?**

Да. Длинные подписи автоматически переносятся, если места недостаточно; принудительные разрывы строки поддерживаются символами новой строки в названии серии.

**Как сделать так, чтобы легенда следовала цветовой схеме темы презентации?**

Не задавайте явные цвета/заливки/шрифты для легенды или её текста. Они будут наследоваться из темы и корректно обновляться при изменении дизайна.