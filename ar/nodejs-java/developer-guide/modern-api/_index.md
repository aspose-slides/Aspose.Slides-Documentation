---
title: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 237
url: /ar/nodejs-java/modern-api/
keywords: "واجهة برمجة التطبيقات الحديثة عبر الأنظمة"
description: "واجهة برمجة التطبيقات الحديثة"
---

## مقدمة

تاريخياً، تعتمد Aspose Slides على java.awt وتحتوي في واجهة برمجة التطبيقات العامة على الفئات التالية من هناك:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

اعتبارًا من الإصدار 24.4، تم إعلان هذه الواجهة العامة كمُهملة.

للتخلص من الاعتمادات على هذه الفئات، أضفنا ما يسمى "واجهة برمجة التطبيقات الحديثة" - أي الواجهة التي يجب استخدامها بدلاً من الواجهة المُهملة، والتي تحتوي توقيعاتها على اعتمادات على BufferedImage. تم إعلان Graphics2D مُهملة وتمت إزالة دعمها من واجهة برمجة التطبيقات العامة لـ Slides.

سيتم إزالة الواجهة العامة المُهملة التي تعتمد على System.Drawing في الإصدار 24.8.

## واجهة برمجة التطبيقات الحديثة

تمت إضافة الفئات والأنماط التالية إلى الواجهة العامة:

- IImage - تمثل الصورة النقطية أو المتجهة.
- ImageFormat - تمثل صيغة ملف الصورة.
- Images - طرق لإنشاء والعمل مع واجهة IImage.

يرجى الملاحظة أن IImage قابلة للتخلص منها (تطبق واجهة IDisposable ويجب لف استخدامها ضمن using أو التخلص منها بطريقة ملائمة أخرى).

ربما يبدو السيناريو التقليدي لاستخدام الواجهة الجديدة كما يلي:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // إنشاء مثيل قابل للتخلص من IImage من الملف على القرص.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // إنشاء صورة PowerPoint عن طريق إضافة مثيل IImage إلى صور العرض التقديمي.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة شكل صورة على الشريحة #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // الحصول على مثيل من IImage يمثل الشريحة #1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // حفظ الصورة على القرص.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## استبدال الشيفرة القديمة بواجهة برمجة التطبيقات الحديثة

بشكل عام، ستحتاج إلى استبدال استدعاء الطريقة القديمة باستخدام ImageIO بالطريقة الجديدة.

قديم:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
جديد:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### الحصول على صورة مصغرة لشريحة

الشيفرة التي تستخدم واجهة برمجة التطبيقات المُهملة:

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

واجهة برمجة التطبيقات الحديثة:

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

### الحصول على صورة مصغرة لشكل

الشيفرة التي تستخدم واجهة برمجة التطبيقات المُهملة:

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

واجهة برمجة التطبيقات الحديثة:

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

### الحصول على صورة مصغرة للعرض التقديمي

الشيفرة التي تستخدم واجهة برمجة التطبيقات المُهملة:

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

واجهة برمجة التطبيقات الحديثة:

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

### إضافة صورة إلى عرض تقديمي

الشيفرة التي تستخدم واجهة برمجة التطبيقات المُهملة:

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

واجهة برمجة التطبيقات الحديثة:

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

## طرق سيتم إزالتها واستبدالها في واجهة برمجة التطبيقات الحديثة

### العرض التقديمي
| توقيع الطريقة                               | توقيع طريقة الاستبدال                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### الشكل
| توقيع الطريقة                                                      | توقيع طريقة الاستبدال                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                        | public final IImage getImage()                                                           |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### الشريحة
| توقيع الطريقة                                                      | توقيع طريقة الاستبدال                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | سيتم حذفه تمامًا  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | سيتم حذفه تمامًا  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | سيتم حذفه تمامًا  |

### الإخراج
| توقيع الطريقة                                                | توقيع طريقة الاستبدال                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### مجموعة الصور
| توقيع الطريقة                          | توقيع طريقة الاستبدال               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### PPImage
| توقيع الطريقة                     | توقيع طريقة الاستبدال   |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### PatternFormat
| توقيع الطريقة                                          | توقيع طريقة الاستبدال                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) |public final IImage getTile(Color background, Color foreground) |

### PatternFormatEffectiveData
| توقيع الطريقة                                          | توقيع طريقة الاستبدال                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## دعم واجهة برمجة التطبيقات لGraphics2D سيتم إيقافه

تم إعلان الطرق باستخدام [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) بأنها مُهملة وسيتم إزالة دعمها من واجهة برمجة التطبيقات العامة.

سيتم إزالة الجزء من واجهة برمجة التطبيقات الذي يستخدمه:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)