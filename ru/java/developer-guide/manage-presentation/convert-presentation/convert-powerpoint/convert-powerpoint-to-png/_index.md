---
title: Конвертация PowerPoint в PNG
type: docs
weight: 30
url: /ru/java/convert-powerpoint-to-png/
keywords: PowerPoint в PNG, PPT в PNG, PPTX в PNG, java, Aspose.Slides для Java
description: Конвертация презентации PowerPoint в PNG
---

## **О конвертации PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но все же очень распространен.

**Случай использования:** Когда у вас есть сложное изображение и размер не имеет значения, PNG является лучшим форматом изображения, чем JPEG.

{{% alert title="Совет" color="primary" %}} Вам может быть интересно попробовать бесплатные **Конвертеры PowerPoint в PNG** от Aspose: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Они являются живой реализацией процесса, описанного на этой странице. {{% /alert %}}

## **Конвертация PowerPoint в PNG**

Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите объект слайда из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) под интерфейсом [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide).
3. Используйте метод [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide), чтобы получить миниатюру для каждого слайда.
4. Используйте метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)), чтобы сохранить миниатюру слайда в формате PNG.

Этот код на Java показывает, как конвертировать презентацию PowerPoint в PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Конвертация PowerPoint в PNG с индивидуальными размерами**

Если вы хотите получить файлы PNG определенного масштаба, вы можете установить значения для `desiredX` и `desiredY`, которые определяют размеры результирующей миниатюры.

Этот код на Java демонстрирует описанную операцию:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Конвертация PowerPoint в PNG с заданным размером**

Если вы хотите получить файлы PNG определенного размера, вы можете передать свои предпочтительные аргументы `width` и `height` для `ImageSize`.

Этот код показывает, как конвертировать PowerPoint в PNG, указывая размер для изображений:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```