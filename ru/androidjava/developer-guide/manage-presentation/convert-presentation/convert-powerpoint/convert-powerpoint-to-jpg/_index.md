---
title: Конвертировать PowerPoint в JPG
type: docs
weight: 60
url: /ru/androidjava/convert-powerpoint-to-jpg/
keywords: "Конвертировать PowerPoint в JPG, PPTX в JPEG, PPT в JPEG"
description: "Конвертировать PowerPoint в JPG: PPT в JPG, PPTX в JPG на Java"
---

## **О конвертации PowerPoint в JPG**
С помощью [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/) вы можете конвертировать презентацию PowerPoint PPT или PPTX в изображение JPG. Также возможно конвертировать PPT/PPTX в JPEG, PNG или SVG. С помощью этих функций легко реализовать свой собственный просмотрщик презентаций и создать миниатюру для каждого слайда. Это может быть полезно, если вы хотите защитить слайды презентации от авторских прав, продемонстрировать презентацию в режиме только для чтения. Aspose.Slides позволяет конвертировать всю презентацию или определенный слайд в форматы изображений.

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует PowerPoint в изображения JPG, вы можете попробовать эти бесплатные онлайн-конвертеры: PowerPoint [PPTX в JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) и [PPT в JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **Конвертировать PowerPoint PPT/PPTX в JPG**
Вот шаги для конвертации PPT/PPTX в JPG:

1. Создайте экземпляр типа [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите объект слайда типа [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--).
3. Создайте миниатюру каждого слайда, а затем конвертируйте ее в JPG. Метод [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-) используется для получения миниатюры слайда, он возвращает объект [Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images) в результате. Метод [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) должен вызываться для нужного слайда типа [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide), масштабы полученной миниатюры передаются в метод.
4. После получения миниатюры слайда вызовите метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) из объекта миниатюры. Передайте в него имя результирующего файла и формат изображения. 

{{% alert color="primary" %}}

**Примечание**: Конвертация PPT/PPTX в JPG отличается от конвертации в другие типы в Aspose.Slides API. Для других типов обычно используется метод [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), но здесь нужно использовать метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)).

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Создает полноформатное изображение
        IImage slideImage = sld.getImage(1f, 1f);

        // Сохраняет изображение на диск в формате JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Конвертировать PowerPoint PPT/PPTX в JPG с пользовательскими размерами**
Чтобы изменить размер результирующей миниатюры и изображения JPG, вы можете задать значения *ScaleX* и *ScaleY*, передав их в методы [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-):

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Определяет размеры
    int desiredX = 1200;
    int desiredY = 800;
    // Получает масштабированные значения X и Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Создает полноформатное изображение
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Сохраняет изображение на диск в формате JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Отображение комментариев при сохранении презентации в изображение**
Aspose.Slides для Android через Java предоставляет возможность отображать комментарии на слайдах презентации при конвертации этих слайдов в изображения. Этот Java-код демонстрирует операцию:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет [БЕСПЛАТНОЕ веб-приложение Collage](https://products.aspose.app/slides/collage). С помощью этого онлайн-сервиса вы можете объединять [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG изображения, создавать [фото сетки](https://products.aspose.app/slides/collage/photo-grid) и так далее.

Используя те же принципы, описанные в этой статье, вы можете конвертировать изображения из одного формата в другой. Для получения дополнительной информации смотрите эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

## **См. также**

Смотрите другие варианты конвертации PPT/PPTX в изображение, такие как:

- [Конвертация PPT/PPTX в SVG](/slides/ru/androidjava/render-a-slide-as-an-svg-image/).