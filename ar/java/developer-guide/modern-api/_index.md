---
title: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 237
url: /java/modern-api/
keywords: "واجهة برمجة التطبيقات الحديثة عبر الأنظمة"
description: "واجهة برمجة التطبيقات الحديثة"
---

## المقدمة

تاريخيًا، تعتمد Aspose Slides على java.awt وتحتوي على الفئات التالية في واجهتها العامة:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

اعتبارًا من الإصدار 24.4، تم الإبلاغ عن هذه الواجهة العامة على أنها مهجورة.

للتخلص من الاعتماد على هذه الفئات، أضفنا ما يُعرف بـ "واجهة برمجة التطبيقات الحديثة" - أي الواجهة التي ينبغي استخدامها بدلاً من تلك التي تم الإبلاغ عنها بأنها مهجورة، والتي تحتوي توقيعها على اعتماد على BufferedImage. تم الإبلاغ عن Graphics2D على أنها مهجورة وتمت إزالة دعمها من واجهة Slides العامة.

سيتم إزالة واجهة برمجة التطبيقات العامة المهجورة التي تعتمد على System.Drawing في الإصدار 24.8.

## واجهة برمجة التطبيقات الحديثة

أضيفت الفئات والـ enums التالية إلى الواجهة العامة:

- IImage - تمثل الصورة النقطية أو المتجهة.
- ImageFormat - تمثل تنسيق ملف الصورة.
- Images - طرق لاستدعاء وأعمال مع واجهة IImage.

يرجى ملاحظة أن IImage قابلة للتخلص (فهي تنفذ واجهة IDisposable ويجب أن يتم لف استخدامها في using أو التخلص منها بطريقة مريحة أخرى).

سيناريو نموذجي لاستخدام الواجهة الجديدة قد يبدو كما يلي:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // استدعاء مثيل قابل للتخلص من IImage من الملف على القرص.
    IImage image = Images.fromFile("image.png");
    try {
        // إنشاء صورة PowerPoint عن طريق إضافة مثيل من IImage إلى صور العرض التقديمي.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة شكل صورة على الشريحة #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على مثيل من IImage يمثل الشريحة #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // حفظ الصورة على القرص.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## استبدال الكود القديم بواجهة برمجة التطبيقات الحديثة

بشكل عام، ستحتاج إلى استبدال الاتصال بالطريقة القديمة باستخدام ImageIO بالطريقة الجديدة.

قديم:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
جديد:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### الحصول على صورة مصغرة لشريحة

كود يستخدم واجهة برمجة تطبيقات مهجورة:

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

واجهة برمجة التطبيقات الحديثة:

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

### الحصول على صورة مصغرة لشكل

كود يستخدم واجهة برمجة تطبيقات مهجورة:

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

واجهة برمجة التطبيقات الحديثة:

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

### الحصول على صورة مصغرة للعرض التقديمي

كود يستخدم واجهة برمجة تطبيقات مهجورة:

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

واجهة برمجة التطبيقات الحديثة:

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

### إضافة صورة إلى عرض تقديمي

كود يستخدم واجهة برمجة تطبيقات مهجورة:

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

واجهة برمجة التطبيقات الحديثة:

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

## الطرق التي ستتم إزالتها واستبدالها في واجهة برمجة التطبيقات الحديثة

### العرض التقديمي
| توقيع الطريقة                               | توقيع الطريقة البديلة                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### الشكل
| توقيع الطريقة                                                      | توقيع الطريقة البديلة                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                        | public final IImage getImage()                                                           |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### الشريحة
| توقيع الطريقة                                                      | توقيع الطريقة البديلة                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | سيتم حذفه بالكامل  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | سيتم حذفه بالكامل  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | سيتم حذفه بالكامل  |

### الإخراج
| توقيع الطريقة                                                | توقيع الطريقة البديلة                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### مجموعة الصور
| توقيع الطريقة                          | توقيع الطريقة البديلة               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| توقيع الطريقة                     | توقيع الطريقة البديلة   |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### تنسيق النمط
| توقيع الطريقة                                          | توقيع الطريقة البديلة                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) |public final IImage getTile(Color background, Color foreground) |

### بيانات تنسيق النمط الفعالة
| توقيع الطريقة                                          | توقيع الطريقة البديلة                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## دعم واجهة برمجة التطبيقات لـ Graphics2D سيتم إلغاؤه

تم الإبلاغ عن الطرق التي تستخدم [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) بأنها مهجورة وسيتم إزالة دعمها من الواجهة العامة.

الجزء من واجهة برمجة التطبيقات التي تستخدمها سيتم إزالته:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)