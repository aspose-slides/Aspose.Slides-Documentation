---
title: Преобразовать слайды PowerPoint в PNG на Java
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/java/convert-powerpoint-to-png/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PNG
- презентацию в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- Java
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в высококачественные PNG‑изображения быстро с помощью Aspose.Slides для Java, обеспечивая точные, автоматизированные результаты."
---

## **О преобразовании PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё равно очень популярен. 

**Случай использования:** Когда у вас сложное изображение и размер не важен, PNG — более подходящий формат изображения, чем JPEG. 

{{% alert title="Tip" color="primary" %}} Возможно, вам будет интересно ознакомиться с бесплатными конвертерами Aspose **PowerPoint в PNG**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живой пример процесса, описанного на этой странице. {{% /alert %}}

## **Преобразовать PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите объект слайда из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) через интерфейс [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide).
3. Вызовите метод [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) чтобы получить миниатюру каждого слайда.
4. Используйте метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String%20formatName,%20int%20imageFormat)) чтобы сохранить миниатюру слайда в формате PNG.

Этот Java‑код демонстрирует, как преобразовать презентацию PowerPoint в PNG:
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


## **Преобразовать PowerPoint в PNG с пользовательскими размерами**

Если вам нужны PNG‑файлы определённого масштаба, вы можете задать значения `desiredX` и `desiredY`, которые определяют размеры полученной миниатюры. 

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


## **Преобразовать PowerPoint в PNG с пользовательским размером**

Если вам нужны PNG‑файлы определённого размера, вы можете передать желаемые аргументы `width` и `height` для `ImageSize`. 

Этот код показывает, как преобразовать PowerPoint в PNG, задавая размер изображений: 
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
