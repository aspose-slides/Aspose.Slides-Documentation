---
title: Преобразование PPT и PPTX в JPG на JavaScript
linktitle: PowerPoint в JPG
type: docs
weight: 60
url: /ru/nodejs-java/convert-powerpoint-to-jpg/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Преобразуйте слайды PowerPoint (PPT, PPTX) в высококачественные JPG-изображения на JavaScript с помощью Aspose.Slides для Node.js через Java, используя быстрые и надежные примеры кода."
---

## **О конвертации PowerPoint в JPG**
С помощью [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) вы можете преобразовать презентацию PowerPoint PPT или PPTX в изображение JPG. Также возможно преобразовать PPT/PPTX в JPEG, PNG или SVG. С этими функциями легко реализовать собственный просмотрщик презентаций, создать миниатюру для каждого слайда. Это может быть полезно, если вы хотите защитить слайды презентации от копирования, демонстрировать презентацию в режиме только для чтения. Aspose.Slides позволяет конвертировать всю презентацию или отдельный слайд в форматы изображений. 

{{% alert color="primary" %}} 
Чтобы увидеть, как Aspose.Slides конвертирует PowerPoint в JPG изображения, вы можете попробовать эти бесплатные онлайн‑конвертеры: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) и [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Преобразовать PowerPoint PPT/PPTX в JPG**
Ниже перечислены шаги для конвертации PPT/PPTX в JPG:

1. Создайте экземпляр типа [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите объект слайда типа [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--).
3. Создайте миниатюру каждого слайда, а затем преобразуйте её в JPG. Метод [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) используется для получения миниатюры слайда; он возвращает объект [Imagess](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images). Метод [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) должен вызываться у нужного слайда типа [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide), масштабы результирующей миниатюры передаются в метод.
4. После получения миниатюры слайда вызовите метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) из объекта миниатюры. Передайте в него полученное имя файла и формат изображения. 

{{% alert color="primary" %}}
**Примечание**: Конвертация PPT/PPTX в JPG отличается от конвертации в другие типы в Aspose.Slides API. Для других типов обычно используется метод [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), но здесь необходимо использовать метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).
{{% /alert %}} 
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Создаёт изображение в полном масштабе
        var slideImage = sld.getImage(1.0, 1.0);
        // Сохраняет изображение на диск в формате JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Преобразовать PowerPoint PPT/PPTX в JPG с пользовательскими размерами**
Чтобы изменить размеры полученной миниатюры и JPG‑изображения, вы можете задать значения *ScaleX* и *ScaleY*, передав их в методы [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-):
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Определяет размеры
    var desiredX = 1200;
    var desiredY = 800;
    // Получает масштабированные значения X и Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Создаёт изображение в полном масштабе
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Сохраняет изображение на диск в формате JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Отображение комментариев при сохранении презентации в изображение**
Aspose.Slides для Node.js через Java предоставляет возможность отрисовывать комментарии на слайдах презентации при их конвертации в изображения. Этот код на JavaScript демонстрирует работу:
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Tip" color="primary" %}}
Aspose предоставляет [БЕСПЛАТНОЕ веб‑приложение Collage](https://products.aspose.app/slides/collage). С помощью данного онлайн‑сервиса вы можете объединять изображения [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG, создавать [фото‑сетки](https://products.aspose.app/slides/collage/photo-grid), и т.д. 
{{% /alert %}}

## **Смотрите также**
Смотрите другие варианты конвертации PPT/PPTX в изображение, например:

- [Конвертация PPT/PPTX в SVG](/slides/ru/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**Поддерживает ли этот метод пакетную конвертацию?**

Да, Aspose.Slides позволяет выполнять пакетную конвертацию нескольких слайдов в JPG за одну операцию.

**Поддерживает ли конвертация SmartArt, диаграммы и другие сложные объекты?**

Да, Aspose.Slides отображает всё содержание, включая SmartArt, диаграммы, таблицы, фигуры и т.д. Однако точность отображения может немного отличаться от PowerPoint, особенно при использовании пользовательских или отсутствующих шрифтов.

**Есть ли ограничения на количество обрабатываемых слайдов?**

Aspose.Slides сам по себе не накладывает строгих ограничений на количество обрабатываемых слайдов. Однако при работе с большими презентациями или изображениями высокого разрешения возможно возникновение ошибки нехватки памяти.