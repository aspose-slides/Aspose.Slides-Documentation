---
title: Создание миниатюр фигур
type: docs
weight: 70
url: /ru/nodejs-java/create-shape-thumbnails/
---

## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java может использоваться для создания файлов презентаций, где каждая страница соответствует слайду. Слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Однако разработчикам иногда требуется просматривать изображения фигур отдельно в средстве просмотра изображений. В таких случаях Aspose.Slides for Node.js via Java помогает им создавать миниатюры фигур слайдов.

{{% /alert %}} 

В этой теме мы покажем, как генерировать миниатюры слайдов в разных ситуациях:

- Создание миниатюры фигуры внутри слайда.
- Создание миниатюры фигуры для фигуры слайда с пользовательскими размерами.
- Создание миниатюры фигуры в границах внешнего вида фигуры.

## **Создание миниатюр фигур из слайдов**
Чтобы создать миниатюру фигуры из любого слайда с помощью Aspose.Slides for Node.js via Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage--) полученного слайда в масштабе по умолчанию.
1. Сохраните изображение миниатюры в предпочитаемом формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры из слайда:
```javascript
// Создайте экземпляр класса Presentation, представляющего файл презентации
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
Чтобы создать миниатюру фигуры слайда с помощью Aspose.Slides for Node.js via Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) полученного слайда с пользовательскими размерами.
1. Сохраните изображение миниатюры в предпочитаемом формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры на основе заданного коэффициента масштабирования:
```javascript
// Создайте экземпляр класса Presentation, представляющего файл презентации
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
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах внешнего вида фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда. Чтобы создать миниатюру фигуры слайда в границах её внешнего вида, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение миниатюры указанного слайда, используя границы фигуры как внешний вид.
1. Сохраните изображение миниатюры в предпочитаемом формате изображения.

Этот пример кода основан на приведённых выше шагах:
```javascript
// Создайте экземпляр класса Presentation, представляющего файл презентации
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


## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/), и другие. Фигуры также могут быть [экспортированы как векторный SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) путем сохранения содержимого фигуры в формате SVG.

**В чём разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/nodejs-java/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отрисована как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет на отображение в слайд‑шоу, но не препятствует созданию изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) и [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)), может быть сохранён как миниатюра или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/nodejs-java/custom-font/) (или [настроить подстановки шрифтов](/slides/ru/nodejs-java/font-substitution/)), чтобы избежать нежелательных замен и переутяжеления текста.