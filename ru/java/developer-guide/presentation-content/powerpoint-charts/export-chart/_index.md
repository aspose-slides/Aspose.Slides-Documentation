---
title: Экспортировать диаграммы презентации в Java
linktitle: Экспортировать диаграмму
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
description: "Узнайте, как экспортировать диаграммы презентаций с помощью Aspose.Slides для Java, поддерживая форматы PPT и PPTX, и упростите составление отчетов в любой рабочий процесс."
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


## **Часто задаваемые вопросы**

**Могу ли я экспортировать диаграмму как вектор (SVG), а не растровое изображение?**

Да. Диаграмма является фигурой, и её содержимое можно сохранить в SVG с помощью [метода сохранения shape-to-SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Как установить точный размер экспортируемой диаграммы в пикселях?**

Используйте перегрузки рендеринга изображения, позволяющие задавать размер или масштаб — библиотека поддерживает отрисовку объектов с указанными размерами/масштабом.

**Что делать, если шрифты в подписьах и легенде выглядят неверно после экспорта?**

[Загрузите требуемые шрифты](/slides/ru/java/custom-font/) через [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/), чтобы при рендеринге диаграммы сохранялась метрика и отображение текста.

**Сохраняет ли экспорт тему, стили и эффекты PowerPoint?**

Да. Рендерер Aspose.Slides учитывает форматирование презентации (темы, стили, заливки, эффекты), поэтому внешний вид диаграммы сохраняется.

**Где можно найти информацию о доступных возможностях рендеринга/экспорта помимо изображений диаграмм?**

Смотрите [API](https://reference.aspose.com/slides/java/com.aspose.slides/)/[документацию](/slides/ru/java/convert-powerpoint/) для целевых форматов вывода ([PDF](/slides/ru/java/convert-powerpoint-to-pdf/), [SVG](/slides/ru/java/render-a-slide-as-an-svg-image/), [XPS](/slides/ru/java/convert-powerpoint-to-xps/), [HTML](/slides/ru/java/convert-powerpoint-to-html/), и т.д.) и связанные параметры рендеринга.