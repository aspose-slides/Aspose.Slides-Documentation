---
title: Создание эскизов фигур
type: docs
weight: 70
url: /java/create-shape-thumbnails/
---


## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides для Java может быть использован для создания файлов презентаций, в которых каждая страница соответствует слайду. Слайды можно просматривать, открыв файлы презентаций с помощью Microsoft PowerPoint. Однако разработчикам иногда нужно отдельно просматривать изображения фигур в просмотрщике изображений. В таких случаях Aspose.Slides для Java помогает им генерировать эскизы изображений фигур слайдов.

{{% /alert %}} 

В этом разделе мы покажем, как генерировать миниатюры слайдов в различных ситуациях:

- Генерация эскиза фигуры внутри слайда.
- Генерация эскиза фигуры для слайда с пользовательскими размерами.
- Генерация эскиза фигуры в пределах внешнего вида фигуры.

## **Генерация эскизов фигур из слайдов**
Чтобы сгенерировать эскиз фигуры из любого слайда с помощью Aspose.Slides для Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Получите изображение эскиза фигуры](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--) ссылающегося слайда в масштабе по умолчанию.
1. Сохраните изображение миниатюры в предпочтительном формате изображения.

Этот пример кода показывает, как сгенерировать эскиз фигуры из слайда:

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создайте изображение полного размера
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

## **Генерация эскизов фигур с пользовательским коэффициентом масштабирования**
Чтобы сгенерировать эскиз фигуры слайда с помощью Aspose.Slides для Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Получите изображение эскиза фигуры](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-) ссылающегося слайда с пользовательскими размерами.
1. Сохраните изображение миниатюры в предпочтительном формате изображения.

Этот пример кода показывает, как сгенерировать эскиз фигуры на основе заданного коэффициента масштабирования:

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создайте изображение полного размера
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

## **Генерация эскиза фигуры в пределах внешнего вида**
Этот метод создания эскизов фигур позволяет разработчикам генерировать эскиз в пределах внешнего вида фигуры. Он учитывает все эффекты фигуры. Сгенерированный эскиз фигуры ограничен границами слайда. Чтобы сгенерировать эскиз фигуры слайда в пределах его внешнего вида, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение эскиза ссылающегося слайда с границами фигуры как внешним видом.
1. Сохраните изображение миниатюры в предпочтительном формате изображения.

Этот пример кода основан на вышеуказанных шагах:

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создайте изображение полного размера
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