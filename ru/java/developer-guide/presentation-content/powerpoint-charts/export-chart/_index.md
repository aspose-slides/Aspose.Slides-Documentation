---
title: Экспорт диаграмм презентации в Java
linktitle: Экспорт диаграммы
type: docs
weight: 90
url: /ru/java/export-chart/
keywords:
- диаграмма
- диаграмма в изображение
- диаграмма как изображение
- извлечение изображения диаграммы
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как экспортировать диаграммы презентаций с помощью Aspose.Slides для Java, поддерживая форматы PPT и PPTX, и упростить создание отчетов в любом процессе."
---

## **Получить изображение диаграммы**
Aspose.Slides for Java предоставляет возможность извлекать изображение конкретной диаграммы. Ниже приведён пример.
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


## **FAQ**

**Можно ли экспортировать диаграмму как вектор (SVG), а не как растровое изображение?**

Да. Диаграмма является фигурой, и её содержимое можно сохранить в SVG с помощью метода [shape-to-SVG saving method](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Как задать точный размер экспортируемой диаграммы в пикселях?**

Используйте перегрузки рендеринга изображения, позволяющие указать размер или масштаб — библиотека поддерживает рендеринг объектов с заданными размерами/масштабом.

**Что делать, если после экспорта шрифты в подпищиках и легенде отображаются неправильно?**

[Load the required fonts](/slides/ru/java/custom-font/) через [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) чтобы рендеринг диаграммы сохранял метрики и внешний вид текста.

**Учитывается ли при экспорте тема, стили и эффекты PowerPoint?**

Да. Рендерер Aspose.Slides учитывает форматирование презентации (темы, стили, заливки, эффекты), поэтому внешний вид диаграммы сохраняется.

**Где можно найти доступные возможности рендеринга/экспорта помимо изображений диаграмм?**

Смотрите [API](https://reference.aspose.com/slides/java/com.aspose.slides/)/[documentation](/slides/ru/java/convert-powerpoint/) для целевых форматов вывода ([PDF](/slides/ru/java/convert-powerpoint-to-pdf/), [SVG](/slides/ru/java/render-a-slide-as-an-svg-image/), [XPS](/slides/ru/java/convert-powerpoint-to-xps/), [HTML](/slides/ru/java/convert-powerpoint-to-html/), и т.д.) и связанные параметры рендеринга.