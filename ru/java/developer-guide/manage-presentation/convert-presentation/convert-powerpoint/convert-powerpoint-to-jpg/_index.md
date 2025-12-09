---
title: Преобразовать PPT и PPTX в JPG на Java
linktitle: PowerPoint в JPG
type: docs
weight: 60
url: /ru/java/convert-powerpoint-to-jpg/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- преобразовать PPTX
- PowerPoint в JPG
- презентация в JPG
- слайд в JPG
- PPT в JPG
- PPTX в JPG
- сохранить PowerPoint как JPG
- сохранить презентацию как JPG
- сохранить слайд как JPG
- сохранить PPT как JPG
- сохранить PPTX как JPG
- экспортировать PPT в JPG
- экспортировать PPTX в JPG
- Java
- Aspose.Slides
description: "Преобразовать слайды PowerPoint (PPT, PPTX) в высококачественные JPG-изображения на Java с помощью Aspose.Slides for Java, используя быстрые и надёжные примеры кода."
---

## Ищете онлайн-конвертер PPT в JPG?
Прежде чем переходить к коду Java, если вам нужен **быстрый онлайн-инструмент** для преобразования PowerPoint (PPT, PPTX) в JPG **без программирования**, ознакомьтесь с нашим онлайн-конвертером:  
[Aspose PPT to JPG Converter](https://products.aspose.app/slides/conversion/ppt-to-jpg)

Если вы **разработчик, ищущий программное решение**, продолжайте чтение, чтобы узнать, как конвертировать слайды PowerPoint в JPG с помощью **Aspose.Slides for Java**.

## **О преобразовании PowerPoint в JPG**
С помощью [**Aspose.Slides API**](https://products.aspose.com/slides/java/) вы можете преобразовать презентацию PowerPoint PPT или PPTX в изображение JPG. Также возможно конвертировать PPT/PPTX в JPEG, PNG или SVG. Благодаря этим возможностям легко реализовать собственный просмотрщик презентаций, создать эскизы для каждого слайда. Это может быть полезно, если вы хотите защитить слайды презентации от копирования, демонстрировать презентацию в режиме только для чтения. Aspose.Slides позволяет конвертировать всю презентацию или отдельный слайд в форматы изображений. 

{{% alert color="primary" %}} 
Чтобы увидеть, как Aspose.Slides конвертирует PowerPoint в изображения JPG, вы можете попробовать эти бесплатные онлайн-конвертеры: PowerPoint [PPTX в JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) и [PPT в JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **Конвертировать PowerPoint PPT/PPTX в JPG**
Here are the steps to convert PPT/PPTX to JPG:

1. Создайте экземпляр типа [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите объект слайда типа [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--).
3. Создайте эскиз каждого слайда и затем преобразуйте его в JPG. Метод [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) используется для получения эскиза слайда, он возвращает объект [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images). Метод [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) необходимо вызвать у нужного слайда типа [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide), в метод передаются масштабы результирующего эскиза.
4. После получения эскиза слайда вызовите метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) у объекта эскиза. Передайте в него полученное имя файла и формат изображения. 

{{% alert color="primary" %}}
**Note**: PPT/PPTX to JPG conversion differs from the conversion to other types in Aspose.Slides API. For other types, you usually use [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method, but here you need [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) method.
{{% /alert %}} 
```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Создаёт изображение в полном масштабе
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
To change the dimension of the resulting thumbnail and JPG image, you can set the *ScaleX* and *ScaleY* values by passing them into the [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) methods:
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
        // Создаёт изображение в полном масштабе
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


## **Отрисовка комментариев при сохранении презентации в изображение**
Aspose.Slides for Java provides a facility that allows you to render comments in a presentation's slides when you are converting those slides into images. This Java code demonstrates the operation:
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


{{% alert title="Tip" color="primary" %}}
Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

Using the same principles described in this article, you can convert images from one format to another. For more information, see these pages: convert [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).
{{% /alert %}}

## Часто задаваемые вопросы (FAQ)

### Как я могу конвертировать PowerPoint (PPT, PPTX) в JPG?  
Вы можете конвертировать слайды PowerPoint в JPG с помощью Aspose.Slides for Java. Это обеспечивает высококачественное преобразование изображений с полным контролем над настройками вывода.

### Поддерживает ли этот метод пакетную конвертацию?  
Да, Aspose.Slides позволяет выполнять пакетную конвертацию нескольких слайдов в JPG за одну операцию.

### Могу ли я установить пользовательское разрешение для выходного JPG?  
Да, с помощью API Aspose.Slides можно задать пользовательское разрешение и настройки качества изображения.

### Есть ли онлайн-конвертер PowerPoint в JPG?  
Aspose предлагает как программные решения, так и онлайн-конвертеры. Вы можете воспользоваться [Aspose Online PPT to JPG Converter](https://products.aspose.app/slides/conversion/ppt-to-jpg) для быстрой конвертации.

## **Смотрите также**
See other options to convert PPT/PPTX into image like:

- [Конвертация PPT/PPTX в SVG](/slides/ru/java/render-a-slide-as-an-svg-image/).