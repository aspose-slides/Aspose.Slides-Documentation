---
title: Создание эскизов фигур
type: docs
weight: 70
url: /androidjava/create-shape-thumbnails/
---


## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides для Android на Java можно использовать для создания файлов презентаций, в которых каждая страница соответствует слайду. Слайды можно просматривать, открывая файлы презентаций с помощью Microsoft PowerPoint. Однако разработчикам иногда необходимо просматривать изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides для Android на Java помогает им генерировать эскизы изображений фигур слайдов.

{{% /alert %}} 

В этой теме мы покажем, как генерировать эскизы слайдов в различных ситуациях:

- Генерация эскиза фигуры внутри слайда.
- Генерация эскиза фигуры для фигуры слайда с заданными пользователем размерами.
- Генерация эскиза фигуры в границах внешнего вида фигуры.

## **Генерация эскизов фигур из слайдов**
Чтобы сгенерировать эскиз фигуры из любого слайда, используя Aspose.Slides для Android на Java, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Получите изображение эскиза фигуры](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--) ссылочного слайда в масштабе по умолчанию.
1. Сохраните изображение эскиза в предпочитаемом вами формате изображения.

Этот образец кода демонстрирует, как сгенерировать эскиз фигуры из слайда:

```java
// Создаем экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создаем изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Сохраняем изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Генерация эскизов фигур с заданным пользователем коэффициентом масштабирования**
Чтобы сгенерировать эскиз фигуры слайда, используя Aspose.Slides для Android на Java, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Получите изображение эскиза фигуры](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) ссылочного слайда с заданными пользователем размерами.
1. Сохраните изображение эскиза в предпочитаемом вами формате изображения.

Этот образец кода демонстрирует, как сгенерировать эскиз фигуры на основе заданного коэффициента масштабирования:

```java
// Создаем экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создаем изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Сохраняем изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Генерация эскиза фигуры границ**
Этот метод создания эскизов фигур позволяет разработчикам генерировать эскиз в границах внешнего вида фигуры. Он учитывает все эффекты фигуры. Сгенерированный эскиз фигуры ограничен границами слайда. Чтобы сгенерировать эскиз фигуры слайда в границах ее внешнего вида, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение эскиза ссылочного слайда с границами фигуры как внешним видом.
1. Сохраните изображение эскиза в предпочитаемом вами формате изображения.

Этот образец кода основан на шагах выше:

```java
// Создаем экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создаем изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Сохраняем изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```