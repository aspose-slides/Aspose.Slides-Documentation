---
title: Повышение обработки изображений с помощью современного API
linktitle: Современный API
type: docs
weight: 237
url: /ru/nodejs-java/modern-api/
keywords:
- современный API
- рисование
- миниатюра слайда
- слайд в изображение
- миниатюра фигуры
- фигура в изображение
- миниатюра презентации
- презентация в изображения
- добавить изображение
- добавить картинку
- Node.js
- JavaScript
- Aspose.Slides
description: "Модернизируйте обработку изображений слайдов, заменив устаревшие API обработки изображений на современный JavaScript API для бесшовной автоматизации PowerPoint и OpenDocument."
---
## **Введение**

Исторически Aspose Slides зависит от java.awt и в публичном API имеет следующие классы из него:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Начиная с версии 24.4, этот публичный API объявлен устаревшим.

Чтобы избавиться от зависимостей от этих классов, мы добавили так называемый «Современный API» — то есть API, который следует использовать вместо устаревшего, сигнатуры которого содержат зависимости от [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) объявлен устаревшим, и его поддержка удалена из публичного API Slides.

В текущих версиях рассматривайте публичный API, зависящий от типов java.awt, как унаследованный/устаревший. Используйте Современный API для нового кода и при миграции существующих рабочих процессов обработки изображений.

## **Современный API**

В публичный API добавлены следующие классы и перечисления:

- [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) — представляет растровое или векторное изображение.
- [ImageFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imageformat/) — представляет формат файла изображения.
- [Images](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/images/) — методы для создания и работы с классом [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/).

Обратите внимание, что [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) является объектом, подлежащим освобождению, и после его использования следует вызвать `dispose()` или использовать другой удобный способ освобождения.

Используйте `getImage` для рендеринга одного слайда или фигуры. Используйте `getImages` для рендеринга нескольких слайдов презентации. Используйте методы [Images](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/images/) для загрузки изображений, `addImage` с [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) — для добавления их в презентацию, и `replaceImage` с [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) — для обновления изображения существующей презентации.

Типичный сценарий использования нового API может выглядеть следующим образом:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // создать временный объект IImage из файла на диске.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // создать изображение PowerPoint, добавив объект IImage в коллекцию изображений презентации.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // добавить форму изображения на слайд №1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // получить объект IImage, представляющий слайд №1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // сохранить изображение на диске.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Замена старого кода современным API**

Как правило, вам потребуется заменить вызовы, использующие [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) и [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html), новыми методами, которые используют [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/).

Устаревший API:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
Современный API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Получение миниатюры слайда**

Устаревший API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Современный API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Получение миниатюры фигуры**

Устаревший API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Современный API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Получение миниатюры презентации**

Устаревший API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Современный API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Добавление изображения в презентацию**

Устаревший API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Современный API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Устаревшие методы и их замена в современном API**

### **Презентация**
| Сигнатура метода                               | Сигнатура заменяющего метода                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Фигура**
| Сигнатура метода                                                      | Сигнатура заменяющего метода                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                        | public final IImage getImage()                                                           |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Слайд**
| Сигнатура метода                                                      | Сигнатура заменяющего метода                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement  |

### **Вывод**
| Сигнатура метода                                                | Сигнатура заменяющего метода                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Сигнатура метода                          | Сигнатура заменяющего метода               |
|-------------------------------------------|--------------------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Сигнатура метода                     | Сигнатура заменяющего метода   |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Сигнатура метода                                          | Сигнатура заменяющего метода                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Сигнатура метода                                          | Сигнатура заменяющего метода                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## **Поддержка Graphics2D в API**

Методы с [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) объявлены устаревшими и не имеют прямой замены в современном API.

Используйте методы рендеринга изображений современного API вместо API, который рендерит в [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**Какое практическое преимущество имеет [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) по сравнению с [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) объединяет работу как с растровыми, так и с векторными изображениями и упрощает сохранение в различные форматы с помощью [ImageFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imageformat/).

**Повлияет ли современный API на производительность генерации миниатюр?**

Переход от `getThumbnail` к `getImage` не ухудшает ситуацию: новые методы предоставляют те же возможности по созданию изображений с параметрами и размерами, сохраняя поддержку параметров рендеринга. Конкретный прирост или падение производительности зависит от сценария, но с функциональной точки зрения замены эквивалентны.