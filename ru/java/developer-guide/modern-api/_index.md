---
title: Улучшить обработку изображений с помощью современного API
linktitle: Современный API
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
description: "Модернизируйте обработку изображений слайдов, заменив устаревшие API обработки изображений на современный Java API для бесшовной автоматизации PowerPoint и OpenDocument."
---

## **Введение**

Исторически Aspose Slides зависит от java.awt и в публичном API содержит следующие классы из этой библиотеки:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Начиная с версии 24.4, этот публичный API объявлен устаревшим.

Для устранения зависимости от этих классов мы добавили так называемый «Современный API» — то есть API, который следует использовать вместо устаревшего, сигнатуры которого содержат зависимости от BufferedImage. Graphics2D объявлен устаревшим, а его поддержка удалена из публичного API Slides.

Удаление устаревшего публичного API с зависимостями от System.Drawing будет в выпуске 24.8.

## **Современный API**

В публичный API добавлены следующие классы и перечисления:

- IImage — представляет растровое или векторное изображение.  
- ImageFormat — представляет формат файла изображения.  
- Images — методы для создания и работы с интерфейсом IImage.

Обратите внимание, что IImage является disposable (он реализует интерфейс IDisposable, и его следует использовать в блоке using или освобождать другим удобным способом).

Типичный сценарий использования нового API может выглядеть следующим образом:
``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // создать утилизируемый экземпляр IImage из файла на диске.
    IImage image = Images.fromFile("image.png");
    try {
        // создать изображение PowerPoint, добавив экземпляр IImage в коллекцию изображений презентации.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // добавить форму изображения на слайд №1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // получить экземпляр IImage, представляющий слайд №1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // сохранить изображение на диск.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Замена старого кода на Современный API**

Как правило, вам потребуется заменить вызов старого метода, использующего ImageIO, на новый.

Старый:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```

Новый:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```


### **Получение миниатюры слайда**

Код с использованием устаревшего API:
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


Современный API:
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


### **Получение миниатюры фигуры**

Код с использованием устаревшего API:
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


Современный API:
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

Код с использованием устаревшего API:
``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide"+ index+ ".png"));
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


Современный API:
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

Код с использованием устаревшего API:
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


Современный API:
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


## **Методы, подлежащие удалению, и их замена в Современном API**

### **Presentation**
| Сигнатура метода | Сигнатура метода‑замены |
|------------------|--------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Сигнатура метода | Сигнатура метода‑замены |
|------------------|--------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Сигнатура метода | Сигнатура метода‑замены |
|------------------|--------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Will be deleted completely |

### **Output**
| Сигнатура метода | Сигнатура метода‑замены |
|------------------|--------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Сигнатура метода | Сигнатура метода‑замены |
|------------------|--------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Сигнатура метода | Сигнатура метода‑замены |
|------------------|--------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Сигнатура метода | Сигнатура метода‑замены |
|------------------|--------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Сигнатура метода | Сигнатура метода‑замены |
|------------------|--------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Поддержка Graphics2D будет прекращена**

Методы с [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) объявлены устаревшими и их поддержка будет удалена из публичного API.

Часть API, использующая его, будет удалена:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Почему был удалён java.awt.Graphics2D?**

Поддержка `Graphics2D` удаляется из публичного API для унификации работы с рендерингом и изображениями, устранения привязки к платформенно‑зависимым компонентам и перехода к кроссплатформенному подходу с использованием [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/). Все методы рендеринга в `Graphics2D` будут удалены.

**В чём практическая выгода IImage по сравнению с BufferedImage?**

[IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) объединяет работу как с растровыми, так и с векторными изображениями и упрощает сохранение в различные форматы через [ImageFormat](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/).

**Повлияет ли Современный API на производительность генерации миниатюр?**

Переход от `getThumbnail` к `getImage` не ухудшает сценарии: новые методы предоставляют те же возможности по созданию изображений с параметрами и размерами, сохраняя поддержку опций рендеринга. Конкретный прирост или падение зависят от сценария, но функционально замены эквивалентны.