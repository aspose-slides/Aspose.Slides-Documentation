---
title: Преобразование слайдов PowerPoint в PNG на Android
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/androidjava/convert-powerpoint-to-png/
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
- Android
- Java
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в высококачественные PNG‑изображения быстро с помощью Aspose.Slides для Android на Java, обеспечивая точные и автоматизированные результаты."
---

## **О конвертации PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё равно очень популярен. 

**Случай использования:** Когда у вас сложное изображение и размер не имеет значения, PNG является лучшим форматом изображений, чем JPEG. 

{{% alert title="Tip" color="primary" %}} Возможно, вам будет интересно ознакомиться с бесплатными конвертерами Aspose **PowerPoint в PNG**: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живые реализации процесса, описанного на этой странице. {{% /alert %}}

## **Конвертировать PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите объект слайда из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) под интерфейсом [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide).
3. Вызовите метод [ISlide.getImage()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) для получения миниатюры каждого слайда.
4. Используйте метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) для сохранения миниатюры слайда в формате PNG.

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


## **Конвертировать PowerPoint в PNG с пользовательскими размерами**

Если вам нужны PNG‑файлы определённого масштаба, вы можете задать значения `desiredX` и `desiredY`, которые определяют размеры получаемой миниатюры. 

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


## **Конвертировать PowerPoint в PNG с пользовательским размером**

Если вам нужны PNG‑файлы определённого размера, вы можете передать желаемые параметры `width` и `height` для `ImageSize`. 

Этот код показывает, как конвертировать PowerPoint в PNG, указывая размер изображений: 
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


## **Вопросы и ответы**

**Как экспортировать только конкретную форму (например, диаграмму или изображение), а не весь слайд?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/androidjava/create-shape-thumbnails/); вы можете отобразить форму в PNG‑изображение.

**Поддерживается ли параллельная конвертация на сервере?**

Да, но [не делитесь](/slides/ru/androidjava/multithreading/) одной экземпляром презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Какие ограничения версии Trial при экспорте в PNG?**

Режим оценки добавляет водяной знак к выходным изображениям и накладывает [другие ограничения](/slides/ru/androidjava/licensing/) до применения лицензии.