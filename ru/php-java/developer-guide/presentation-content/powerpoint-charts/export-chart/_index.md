---
title: Экспорт диаграмм презентации в PHP
linktitle: Экспорт диаграммы
type: docs
weight: 90
url: /ru/php-java/export-chart/
keywords:
- диаграмма
- диаграмма в изображение
- диаграмма как изображение
- извлечь изображение диаграммы
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как экспортировать диаграммы презентаций с помощью Aspose.Slides для PHP через Java, поддерживая форматы PPT и PPTX, и упростите создание отчетов в любой рабочий процесс."
---

## **Получить изображение диаграммы**
Aspose.Slides для PHP через Java поддерживает извлечение изображения конкретной диаграммы. Ниже приведён пример.
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Часто задаваемые вопросы**

**Могу ли я экспортировать диаграмму как вектор (SVG), а не как растровое изображение?**  
Да. Диаграмма является фигурой, и её содержимое можно сохранить в SVG с помощью [метода сохранения shape-to-SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/).

**Как задать точный размер экспортируемой диаграммы в пикселях?**  
Используйте перегрузки рендеринга изображения, позволяющие указать размер или масштаб — библиотека поддерживает рендеринг объектов с заданными размерами/масштабом.

**Что делать, если шрифты в подписьах и легенде отображаются некорректно после экспорта?**  
[Загрузите необходимые шрифты](/slides/ru/php-java/custom-font/) через [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/), чтобы рендеринг диаграммы сохранял метрики и внешний вид текста.

**Учитывает ли экспорт тему, стили и эффекты PowerPoint?**  
Да. Рендерер Aspose.Slides учитывает форматирование презентации (темы, стили, заливки, эффекты), поэтому внешний вид диаграммы сохраняется.

**Где можно найти доступные возможности рендеринга/экспорта помимо изображений диаграмм?**  
Смотрите [API](https://reference.aspose.com/slides/php-java/aspose.slides/)/[документацию](/slides/ru/php-java/convert-powerpoint/) для целевых форматов вывода ([PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/ru/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/ru/php-java/convert-powerpoint-to-xps/), [HTML](/slides/ru/php-java/convert-powerpoint-to-html/), и др.) и связанные параметры рендеринга.