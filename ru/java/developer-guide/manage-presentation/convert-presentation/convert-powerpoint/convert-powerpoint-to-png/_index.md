---
title: Конвертировать слайды PowerPoint в PNG на Java
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
- презентация в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- Java
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в высококачественные PNG‑изображения быстро с помощью Aspose.Slides для Java, обеспечивая точные, автоматизированные результаты."
---

## **О преобразовании PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё равно очень популярен. 

**Случай использования:** Когда у вас сложное изображение и размер не важен, PNG является лучшим форматом изображений, чем JPEG. 

{{% alert title="Tip" color="primary" %}} Возможно, вам стоит посмотреть бесплатные конвертеры Aspose **PowerPoint в PNG**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Они являются живой реализацией процесса, описанного на этой странице. {{% /alert %}}

## **Преобразование PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите объект слайда из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) под интерфейсом [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide).
3. Вызовите метод [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) чтобы получить миниатюру для каждого слайда.
4. Воспользуйтесь методом [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) чтобы сохранить миниатюру слайда в формате PNG.

Этот Java‑код показывает, как преобразовать презентацию PowerPoint в PNG:
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


## **Преобразование PowerPoint в PNG с пользовательскими размерами**

Если вы хотите получить PNG‑файлы определённого масштаба, вы можете установить значения `desiredX` и `desiredY`, которые определяют размеры результирующей миниатюры. 

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


## **Преобразование PowerPoint в PNG с пользовательским размером**

Если вы хотите получить PNG‑файлы определённого размера, вы можете передать желаемые аргументы `width` и `height` для `ImageSize`. 

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


## **FAQ**

**Как экспортировать только определённую форму (например, диаграмму или изображение), а не весь слайд?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/java/create-shape-thumbnails/); вы можете отрисовать форму в PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**

Да, но [не делитесь](/slides/ru/java/multithreading/) одной экземпляром презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Какие ограничения версии trial при экспорте в PNG?**

Режим оценки добавляет водяной знак к выводимым изображениям и вводит [другие ограничения](/slides/ru/java/licensing/) до применения лицензии.