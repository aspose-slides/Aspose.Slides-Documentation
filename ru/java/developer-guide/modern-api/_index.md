---
title: Улучшите обработку изображений с помощью Modern API
linktitle: Modern API
type: docs
weight: 237
url: /ru/java/modern-api/
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
- Java
- Aspose.Slides
description: "Модернизируйте обработку изображений слайдов, заменив устаревшие API обработки изображений на Java Modern API для бесшовной автоматизации PowerPoint и OpenDocument."
---
## **Введение**

Исторически Aspose Slides имеет зависимость от java.awt и в публичном API содержит следующие классы из неё:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Начиная с версии 24.4, этот публичный API объявлен устаревшим.

Чтобы избавиться от зависимостей от этих классов, мы добавили так называемый «Современный API» — то есть API, который следует использовать вместо устаревшего, подписи которого содержат зависимости от [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) объявлен устаревшим, и его поддержка удалена из публичного API Slides.

В текущих версиях рассматривайте публичный API, зависящий от типов java.awt, как наследуемый/устаревший. Используйте Современный API для нового кода и при миграции существующих процессов обработки изображений.

## **Современный API**

Добавлены следующие классы и перечисления в публичный API:

- [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/) — представляет растровое или векторное изображение.  
- [ImageFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imageformat/) — представляет формат файла изображения.  
- [Images](https://reference.aspose.com/slides/ru/java/com.aspose.slides/images/) — методы для создания экземпляров и работы с интерфейсом [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/).

Обратите внимание, что [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/) является disposable, и после его использования следует вызвать `dispose()` или использовать любой другой удобный шаблон высвобождения.

Используйте `getImage` для рендеринга одного слайда или фигуры. Используйте `getImages` для рендеринга нескольких слайдов презентации. Используйте методы из [Images](https://reference.aspose.com/slides/ru/java/com.aspose.slides/images/) для загрузки изображений, `addImage` с [IImage] — для добавления их в презентацию, и `replaceImage` с [IImage] — для обновления существующего изображения в презентации.

Типичный сценарий использования нового API может выглядеть следующим образом:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // создать disposable‑экземпляр IImage из файла на диске.
    IImage image = Images.fromFile("image.png");
    try {
        // создать изображение PowerPoint, добавив экземпляр IImage в коллекцию изображений презентации.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // добавить форму изображения на слайд #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // получить экземпляр IImage, представляющий слайд #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // сохранить изображение на диске.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Замена старого кода на Современный API**

Как правило, вам потребуется заменить вызовы, использующие [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) и ImageIO, на новые методы, использующие [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/).

Legacy/deprecated API:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
Modern API:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Получение миниатюры слайда**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail();
    try {
        ImageIO.write(slideImage, "PNG", new File("slide1.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Получение миниатюры формы**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    try {
        ImageIO.write(shapeImage, "PNG", new File("shape.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Получение миниатюры презентации**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide" + index + ".png"));
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Dimension(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Добавление изображения в презентацию**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    try {
        BufferedImage bufferedImages = ImageIO.read(new File("image.png"));
        ppImage = pres.getImages().addImage(bufferedImages);
    } catch (IOException e) {
        e.printStackTrace();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Устаревшие методы и их замены в Современном API**

### **Презентация**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Форма**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Слайд**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

### **Output**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Сигнатура метода | Сигнатура заменяющего метода |
|------------------|------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Поддержка Graphics2D в API**

Методы с [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) объявлены устаревшими и не имеют прямой замены в Современном API.

Используйте методы рендеринга изображений Современного API вместо API, который рендерит в [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

- [Слайд](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Вопросы и ответы**

**Почему был удалён [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)?**

Поддержка [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) объявлена устаревшей в публичном API, чтобы унифицировать работу с рендерингом и изображениями, избавиться от привязки к платформенно‑специфическим зависимостям и перейти к кроссплатформенному подходу с использованием [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/). Вместо рендеринга в [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) используйте `getImage` или `getImages`.

**Какова практическая выгода от [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/) по сравнению с [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/) объединяет работу как с растровыми, так и с векторными изображениями и упрощает сохранение в различные форматы через [ImageFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imageformat/).

**Повлияет ли Современный API на производительность генерации миниатюр?**

Переход от `getThumbnail` к `getImage` не ухудшает ситуацию: новые методы предоставляют те же возможности по созданию изображений с различными параметрами и размерами, при этом сохраняют поддержку параметров рендеринга. Конкретный прирост или падение производительности зависит от сценария, но функционально замены эквивалентны.