---
title: Экспорт диаграммы
type: docs
weight: 90
url: /ru/nodejs-java/export-chart/
---

## **Получить изображение диаграммы**
Aspose.Slides for Node.js via Java предоставляет возможность извлечения изображения конкретной диаграммы. Ниже приведен пример.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Могу ли я экспортировать диаграмму как вектор (SVG), а не как растровое изображение?**

Да. Диаграмма является фигурой, и её содержимое можно сохранить в SVG с помощью [метода сохранения shape-to-SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/).

**Как задать точный размер экспортируемой диаграммы в пикселях?**

Используйте перегрузки image-rendering, позволяющие указать размер или масштаб — библиотека поддерживает рендеринг объектов с заданными размерами/масштабом.

**Что делать, если после экспорта шрифты в подписи и легенде выглядят неправильно?**

[Загрузите необходимые шрифты](/slides/ru/nodejs-java/custom-font/) через [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) чтобы рендеринг диаграммы сохранял метрики и внешний вид текста.

**Учитывает ли экспорт тему, стили и эффекты PowerPoint?**

Да. Рендерер Aspose.Slides следует форматированию презентации (темы, стили, заливки, эффекты), поэтому внешний вид диаграммы сохраняется.

**Где можно найти доступные возможности рендеринга/экспорта помимо изображений диаграмм?**

Смотрите [API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/)/[документацию](/slides/ru/nodejs-java/convert-powerpoint/) для целевых форматов вывода ([PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/ru/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/ru/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/), и др.) и связанных параметров рендеринга.