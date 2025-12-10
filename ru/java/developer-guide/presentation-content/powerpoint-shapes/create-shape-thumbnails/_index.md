---
title: Создание миниатюр фигур презентации на Java
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/java/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- отрисовка фигуры
- рендеринг фигуры
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint с помощью Aspose.Slides для Java – легко создавайте и экспортируйте миниатюры презентаций."
---

## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides for Java можно использовать для создания файлов презентаций, где каждая страница соответствует слайду. Слайды можно просматривать, открывая файлы презентаций с помощью Microsoft PowerPoint. Однако разработчикам иногда требуется просматривать изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides for Java помогает генерировать миниатюрные изображения фигур слайдов.

{{% /alert %}} 

В этой статье мы покажем, как генерировать миниатюры слайдов в различных ситуациях:

- Генерация миниатюры фигуры внутри слайда.
- Генерация миниатюры фигуры с пользовательскими размерами.
- Генерация миниатюры фигуры в границах ее отображения.

## **Создать миниатюру фигуры со слайда**
Чтобы создать миниатюру фигуры с любого слайда с помощью Aspose.Slides for Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Получите миниатюрное изображение фигуры](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--) выбранного слайда в масштабе по умолчанию.
1. Сохраните миниатюрное изображение в предпочтительном формате.

Этот пример кода показывает, как создать миниатюру фигуры со слайда:
```java
// Создать объект класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создать изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Сохранить изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создать миниатюру с пользовательским масштабом**
Чтобы создать миниатюру фигуры слайда с пользовательскими размерами с помощью Aspose.Slides for Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Получите миниатюрное изображение фигуры](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-) выбранного слайда с заданными размерами.
1. Сохраните миниатюрное изображение в предпочтительном формате.

Этот пример кода показывает, как создать миниатюру фигуры на основе заданного коэффициента масштабирования:
```java
// Создать экземпляр класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создать изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Сохранить изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создать миниатюру фигуры на основе её границ отображения**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах отображения фигуры. При этом учитываются все визуальные эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда. Чтобы создать миниатюру фигуры слайда в границе её отображения, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите миниатюрное изображение выбранного слайда с границами фигуры в качестве отображения.
1. Сохраните миниатюрное изображение в предпочтительном формате.

Этот пример кода основан на приведенных выше шагах:
```java
// Создать экземпляр класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создать изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Сохранить изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/), а также другие. Фигуры также можно [экспортировать как векторный SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) путем сохранения содержимого фигуры в формате SVG.

**В чём разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/java/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отрисована как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на отображение в слайд-шоу, но не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) и [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/)), можно сохранить как миниатюру или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/java/custom-font/) (или [настроить замену шрифтов](/slides/ru/java/font-substitution/)), чтобы избежать нежелательных замен и переполнения текста.