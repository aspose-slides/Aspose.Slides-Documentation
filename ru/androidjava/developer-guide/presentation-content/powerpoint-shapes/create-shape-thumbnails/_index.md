---
title: "Создание миниатюр фигур презентаций на Android"
linktitle: "Миниатюры фигур"
type: docs
weight: 70
url: /ru/androidjava/create-shape-thumbnails/
keywords:
  - "миниатюра фигуры"
  - "изображение фигуры"
  - "отображение фигуры"
  - "визуализация фигуры"
  - "PowerPoint"
  - "презентация"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint с помощью Aspose.Slides for Android via Java — легко создавайте и экспортируйте миниатюры презентаций."
---

## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java можно использовать для создания файлов презентаций, где каждая страница соответствует слайду. Слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Однако разработчикам иногда требуется просматривать изображения фигур отдельно в средстве просмотра изображений. В таких случаях Aspose.Slides for Android via Java помогает им создавать миниатюры фигур слайдов.

{{% /alert %}} 

В этой статье мы покажем, как создавать миниатюры слайдов в различных ситуациях:

- Создание миниатюры фигуры внутри слайда.
- Создание миниатюры фигуры с пользовательскими размерами.
- Создание миниатюры фигуры в границах её внешнего вида.

## **Создать миниатюру фигуры из слайда**
Чтобы создать миниатюру фигуры из любого слайда с помощью Aspose.Slides for Android via Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его идентификатор или индекс.
1. [Получите изображение миниатюры фигуры](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--) ссылки на слайд с масштабом по умолчанию.
1. Сохраните изображение миниатюры в нужном вам формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры из слайда:
```java
// Создайте экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создайте изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Сохраните изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создать миниатюру с пользовательским коэффициентом масштабирования**
Чтобы создать миниатюру фигуры слайда с пользовательскими размерами, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его идентификатор или индекс.
1. [Получите изображение миниатюры фигуры](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) ссылки на слайд с пользовательскими размерами.
1. Сохраните изображение миниатюры в нужном вам формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры на основе заданного коэффициента масштабирования:
```java
// Создайте экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создайте изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Сохраните изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создать миниатюру фигуры на основе границ внешнего вида**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах внешнего вида фигуры. При этом учитываются все эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда. Чтобы создать миниатюру фигуры слайда в границах её внешнего вида, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его идентификатор или индекс.
1. Получите изображение миниатюры ссылки на слайд с границами фигуры в качестве внешнего вида.
1. Сохраните изображение миниатюры в нужном вам формате изображения.

Этот пример кода основан на перечисленных шагах:
```java
// Создайте экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создайте изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Сохраните изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Вопросы и ответы**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/), и другие. Фигуры также могут быть [экспортированы как векторный SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) путем сохранения содержимого фигуры в формате SVG.

**В чем разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/androidjava/shape-effect/) (тени, свечения и т.п.).

**Что происходит, если фигура помечена как скрытая? Будет ли она все равно отображаться как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на отображение в режиме слайд-шоу и не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/) и [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)), может быть сохранён как миниатюра или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/androidjava/custom-font/) (или [настроить замену шрифтов](/slides/ru/androidjava/font-substitution/)), чтобы избежать нежелательных подстановок и переполнения текста.