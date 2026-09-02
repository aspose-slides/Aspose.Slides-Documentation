---
title: Создание миниатюр фигур презентации на JavaScript
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/nodejs-java/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- отрисовка фигуры
- отображение фигуры
- визуальные границы
- границы фигуры
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint с помощью JavaScript и Aspose.Slides для Node.js — легко создавайте и экспортируйте миниатюры презентаций."
---
## **Введение**

Aspose.Slides используется для создания файлов презентаций, где каждая страница представляет собой слайд. Эти слайды можно просматривать, открывая файлы презентаций с помощью Microsoft PowerPoint. Но иногда разработчикам может потребоваться просматривать изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides помогает генерировать миниатюры изображений фигур слайда. Как использовать эту функцию, описано в этой статье.  
Эта статья объясняет, как создавать миниатюры слайдов различными способами:

- Создание миниатюры фигуры внутри слайда.  
- Создание миниатюры фигуры для фигуры слайда с пользовательскими размерами.  
- Создание миниатюры фигуры в границах внешнего вида фигуры.

## **Создание миниатюр фигур из слайдов**

Чтобы создать миниатюру фигуры из любого слайда с использованием Aspose.Slides для Node.js через Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).  
1. Получите ссылку на любой слайд, используя его ID или индекс.  
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Shape#getImage--) ссылочного слайда с масштабом по умолчанию.  
1. Сохраните изображение миниатюры в предпочтительном формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры из слайда:

```javascript
// Создайте экземпляр класса Presentation, который представляет файл презентации
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Создайте изображение в полном масштабе
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Сохраните изображение на диск в формате PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
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

## **Создание миниатюр фигур с пользовательским коэффициентом масштабирования**

Чтобы создать миниатюру фигуры слайда с использованием Aspose.Slides для Node.js через Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).  
1. Получите ссылку на любой слайд, используя его ID или индекс.  
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) ссылочного слайда с пользовательскими размерами.  
1. Сохраните изображение миниатюры в предпочтительном формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры на основе заданного коэффициента масштабирования:

```javascript
// Создайте экземпляр класса Presentation, который представляет файл презентации
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Создайте изображение в полном масштабе
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Сохраните изображение на диск в формате PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
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

## **Создание миниатюры фигуры в границах**

Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в пределах внешнего вида фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда. Чтобы создать миниатюру фигуры слайда в границах её внешнего вида, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).  
1. Получите ссылку на любой слайд, используя его ID или индекс.  
1. Получите изображение миниатюры ссылочного слайда с границами фигуры как внешним видом.  
1. Сохраните изображение миниатюры в предпочтительном формате изображения.

Этот пример кода основан на описанных выше шагах:

```javascript
// Создайте экземпляр класса Presentation, который представляет файл презентации
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Создайте изображение в полном масштабе
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Сохраните изображение на диск в формате PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
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

## **Получение фактических визуальных границ фигуры**

Свойства кадра [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/) — его методы `getX()`, `getY()`, `getWidth()` и `getHeight()` — описывают прямоугольник, хранящийся в модели презентации. Фактически отрисованное содержимое может выходить за пределы этого кадра или занимать иной прямоугольник, выровненный по осям. Повороты, контура, стрелки, макет и переполнение текста, генерируемая геометрия SmartArt и другие эффекты рендеринга могут менять занимаемую площадь.

Используйте [Shape.getVisualBounds](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getVisualBounds--) для вычисления этой площади без создания изображения. Метод возвращает объект [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) в координатах слайда. Возвращаемый прямоугольник не обрезается по границе слайда, поэтому его координаты могут быть отрицательными, если содержимое выходит за начало слайда.

В следующем примере получаются и сравниваются кадр и визуальные границы:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Тот же прямоугольник можно использовать для выравнивания соседних фигур по его левой, правой, верхней или нижней границе; для резервирования достаточного места в сгенерированном макете; либо для обнаружения содержимого за пределами разрешённой области. Визуальные границы особенно полезны для SmartArt, текстовых полей, стрелок, изображений, повернутых фигур и групповых фигур, когда сохранённый кадр не отражает полностью отрисованный результат.

Используйте [Shape.getVisualBounds](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getVisualBounds--) когда нужны координаты для компоновки или проверки и не требуется битмап. Используйте [Shape.getImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getImage--) когда необходимо отрисовать фигуру. С помощью [ShapeThumbnailBounds](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapethumbnailbounds/) параметр `ShapeThumbnailBounds.Shape` задаёт размер изображения по границам фигуры, включая настройки контура, тогда как `ShapeThumbnailBounds.Appearance` задаёт размер по внешнему виду фигуры и ограничивает результат границами слайда. В отличие от этого, [Shape.getVisualBounds](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getVisualBounds--) возвращает только вычисленный прямоугольник и не обрезает его по слайду.

## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imageformat/), и другие. Фигуры также можно [экспортировать как векторный SVG](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/writeassvg/) путем сохранения содержимого фигуры в формате SVG.

**В чём разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/nodejs-java/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она отображаться в виде миниатюры?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на показ слайд-шоу, но не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/) и [SmartArt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartart/)), может быть сохранён как миниатюра или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/nodejs-java/custom-font/) (или [настроить замену шрифтов](/slides/ru/nodejs-java/font-substitution/)), чтобы избежать нежелательных замен и переполнения текста.