---
title: Экспорт диаграмм презентаций на Android
linktitle: Экспорт диаграммы
type: docs
weight: 90
url: /ru/androidjava/export-chart/
keywords:
- диаграмма
- диаграмма в изображение
- диаграмма как изображение
- извлечение изображения диаграммы
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как экспортировать диаграммы презентаций с помощью Aspose.Slides для Android через Java, поддерживая форматы PPT и PPTX, и упростите создание отчетов в любом рабочем процессе."
---

## **Получить изображение диаграммы**
Aspose.Slides для Android через Java поддерживает извлечение изображения конкретной диаграммы. Ниже приведён пример.
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Могу ли я экспортировать диаграмму как вектор (SVG), а не растровое изображение?**

Да. Диаграмма является фигурой, её содержимое можно сохранить в SVG с помощью [shape-to-SVG saving method](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Как указать точный размер экспортируемой диаграммы в пикселях?**

Используйте перегрузки рендеринга изображения, которые позволяют задать размер или масштаб — библиотека поддерживает рендеринг объектов с указанными размерами/масштабом.

**Что делать, если шрифты в подписьях и легенде выглядят неправильно после экспорта?**

[Load the required fonts](/slides/ru/androidjava/custom-font/) через [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) — это гарантирует сохранение метрик шрифтов и правильное отображение текста при рендеринге диаграммы.

**Сохраняет ли экспорт тему, стили и эффекты PowerPoint?**

Да. Рендерер Aspose.Slides учитывает форматирование презентации (темы, стили, заливки, эффекты), поэтому внешний вид диаграммы сохраняется.

**Где можно узнать о доступных возможностях рендеринга/экспорта помимо изображений диаграмм?**

Смотрите [API](https://reference.aspose.com/slides/androidjava/com.aspose.slides/)/[documentation](/slides/ru/androidjava/convert-powerpoint/) для целевых форматов вывода ([PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/ru/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/ru/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/ru/androidjava/convert-powerpoint-to-html/), и т.д.) и связанные параметры рендеринга.