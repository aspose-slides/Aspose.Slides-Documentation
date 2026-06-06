---
title: "Улучшите обработку изображений с использованием Modern API"
linktitle: "Modern API"
type: docs
weight: 237
url: /ru/androidjava/modern-api/
keywords:
- "android.graphics"
- "Современный API"
- "рисование"
- "миниатюра слайда"
- "слайд в изображение"
- "миниатюра фигуры"
- "фигура в изображение"
- "миниатюра презентации"
- "презентация в изображения"
- "добавить изображение"
- "добавить картинку"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Модернизируйте обработку изображений слайдов, заменив устаревшие API обработки изображений на Java Modern API для бесшовной автоматизации PowerPoint и OpenDocument."
---
## **Введение**

Исторически Aspose Slides зависит от android.graphics и в публичном API содержит следующие классы из него:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

Начиная с версии 24.4, этот публичный API объявлен устаревшим.

Для избавления от зависимостей от этих классов мы добавили так называемый «Modern API» — т.е. API, который следует использовать вместо устаревшего, подписи которого содержат зависимости от [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) объявлен устаревшим, и его поддержка удалена из публичного API Slides.

В текущих версиях публичный API, зависящий от типов android.graphics, следует рассматривать как наследуемый/устаревший. Используйте Modern API для нового кода и при миграции существующих рабочих потоков обработки изображений.

## **Modern API**

В публичный API добавлены следующие классы и перечисления:

- [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) — представляет растровое или векторное изображение.
- [ImageFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imageformat/) — представляет формат файла изображения.
- [Images](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/images/) — методы для создания экземпляров и работы с интерфейсом [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/).

Обратите внимание, что [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) является disposable, и после его использования следует вызвать `dispose()` или применить другой удобный паттерн освобождения.

Для рендеринга отдельного слайда или фигуры используйте `getImage`. Для рендеринга нескольких слайдов презентации используйте `getImages`. Используйте методы [Images](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/images/) для загрузки изображений, `addImage` с [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) для добавления их в презентацию и `replaceImage` с [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) для обновления существующего изображения в презентации.

Типичный сценарий использования нового API может выглядеть следующим образом:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // создать освобождаемый экземпляр IImage из файла на диске.
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
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
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

## **Замена старого кода с Modern API**

В общем случае необходимо заменить вызовы, использующие [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap), новыми методами, использующими [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/).

Унаследованный/устаревший API:
``` java
Presentation pres = new Presentation();
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail(new Size(1920, 1080));
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("image.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
Modern API:
``` java
Presentation pres = new Presentation();
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        slideImage.save("image.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Получение эскиза слайда**

Унаследованный/устаревший API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("slide1.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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

### **Получение эскиза фигуры**

Унаследованный/устаревший API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("shape.png");
        shapeImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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

### **Получение эскиза презентации**

Унаследованный/устаревший API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Size(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        android.graphics.Bitmap thumbnail = bitmaps[index];
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("slide" + index + ".png");
            thumbnail.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
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
    IImage[] images = pres.getImages(new RenderingOptions(), new Size(1980, 1028));
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

Унаследованный/устаревший API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    File file = new File("image.png");
    Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
    ppImage = pres.getImages().addImage(bitmap);

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

## **Устаревшие методы и их замена в Modern API**

### **Презентация**
| Подпись метода | Подпись заменяющего метода |
|----------------|----------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Фигура**
| Подпись метода | Подпись заменяющего метода |
|----------------|----------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Слайд**
| Подпись метода | Подпись заменяющего метода |
|----------------|----------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement |

### **Output**
| Подпись метода | Подпись заменяющего метода |
|----------------|----------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Подпись метода | Подпись заменяющего метода |
|----------------|----------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Подпись метода | Подпись заменяющего метода |
|----------------|----------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Подпись метода | Подпись заменяющего метода |
|----------------|----------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Подпись метода | Подпись заменяющего метода |
|----------------|----------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Поддержка API для Canvas**

Методы с [Canvas](https://developer.android.com/reference/android/graphics/Canvas) объявлены устаревшими и не имеют прямой замены в Modern API.

Используйте методы Modern API для рендеринга изображений вместо API, который рендерит в [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**Почему был удалён android.graphics.Canvas?**

Поддержка [Canvas](https://developer.android.com/reference/android/graphics/Canvas) устарела в публичном API, чтобы унифицировать работу с рендерингом и изображениями, устранить привязку к платформенно‑специфическим зависимостям и перейти к кросс‑платформенному подходу с использованием [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/). Используйте `getImage` или `getImages` вместо рендеринга в [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**Какова практическая выгода от использования [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) по сравнению с [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)?**

[IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) объединяет работу как с растровыми, так и с векторными изображениями и упрощает сохранение в различные форматы через [ImageFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imageformat/).

**Повлияет ли Modern API на производительность генерации эскизов?**

Переход от `getThumbnail` к `getImage` не ухудшает сценарии: новые методы предоставляют те же возможности по созданию изображений с параметрами и размерами, сохраняя поддержку параметров рендеринга. Конкретный прирост или снижение зависит от сценария, но функционально замены эквивалентны.