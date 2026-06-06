---
title: تحسين معالجة الصور باستخدام واجهة برمجة التطبيقات الحديثة
linktitle: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 237
url: /ar/nodejs-java/modern-api/
keywords:
- واجهة برمجة التطبيقات الحديثة
- رسم
- صورة مصغرة للشريحة
- تحويل الشريحة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض التقديمي
- تحويل العرض التقديمي إلى صور
- إضافة صورة
- إضافة صورة
- Node.js
- جافا سكريبت
- Aspose.Slides
description: "تحديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات التصويرية المهملة بواجهة برمجة التطبيقات الحديثة لجافا سكريبت لتوفير أتمتة سلسة لبرنامج PowerPoint وOpenDocument."
---
## **المقدمة**

تاريخيًا، يعتمد Aspose Slides على java.awt وله في واجهة برمجة التطبيقات العامة (API) الفئات التالية من هناك:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

اعتبارًا من الإصدار 24.4، تم إعلان أن هذه الواجهة العامة (API) قديمة.

للتخلص من الاعتماد على هذه الفئات، أضفنا ما يسمى بـ "واجهة برمجة التطبيقات الحديثة" — أي الـ API التي يجب استخدامها بدلاً من القديمة، والتي لا تحتوي توقيعاتها على اعتماد على [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). تم إعلان أن [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) قديم وتمت إزالة دعمه من واجهة برمجة تطبيقات Slides العامة.

في الإصدارات الحالية، اعتبر واجهة برمجة التطبيقات العامة التي تعتمد على أنواع java.awt كإصدار قديم/مهمل. استخدم الواجهة الحديثة للشفرة الجديدة وعند نقل سير عمل معالجة الصور الموجود.

## **واجهة برمجة التطبيقات الحديثة**

أُضيفت الفئات والعدادات (enums) التالية إلى الواجهة العامة:

- [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) — يمثل الصورة النقطية أو المتجهية.
- [ImageFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imageformat/) — يمثل تنسيق ملف الصورة.
- [Images](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/images/) — طرق لإنشاء والعمل مع فئة [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/).

يرجى ملاحظة أن [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) قابل للتصرف (disposable) ويجب أن يتبعه استدعاء `dispose()` أو نمط تصرف ملائم آخر.

استخدم `getImage` لتصيير شريحة واحدة أو شكل واحد. استخدم `getImages` لتصيير عدة شرائح عرض. استخدم طرق [Images](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/images/) لتحميل الصور، `addImage` مع [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) لإضافتها إلى عرض تقديمي، و `replaceImage` مع [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) لتحديث صورة عرض تقديمي موجودة.

قد يبدو سيناريو شائع لاستخدام الواجهة الحديثة كما يلي:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // إنشاء نسخة قابلة للتصرف من IImage من الملف الموجود على القرص.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // إنشاء صورة PowerPoint بإضافة نسخة من IImage إلى صور العرض التقديمي.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة شكل صورة على الشريحة #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // الحصول على نسخة من IImage تمثل الشريحة #1.
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

## **استبدال الشفرة القديمة بواجهة برمجة التطبيقات الحديثة**

بشكل عام، ستحتاج إلى استبدال الاستدعاءات التي تستخدم [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) و [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) بالطرق الجديدة التي تستخدم [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/).

الواجهة القديمة/المهملة:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
الواجهة الحديثة:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **الحصول على صورة مصغرة للشريحة**

الواجهة القديمة/المهملة:

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

الواجهة الحديثة:

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

### **الحصول على صورة مصغرة للشكل**

الواجهة القديمة/المهملة:

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

الواجهة الحديثة:

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

### **الحصول على صورة مصغرة للعرض التقديمي**

الواجهة القديمة/المهملة:

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

الواجهة الحديثة:

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

### **إضافة صورة إلى عرض تقديمي**

الواجهة القديمة/المهملة:

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

الواجهة الحديثة:

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

## **الطرق المهملة واستبدالاتها في الواجهة الحديثة**

### **Presentation**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | لا توجد بديلة في الواجهة الحديثة |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | لا توجد بديلة في الواجهة الحديثة |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | لا توجد بديلة في الواجهة الحديثة |

### **Output**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|---|---|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **دعم الـ API للـ Graphics2D**

الطرق التي تستخدم [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) معلنة كمهملة ولا توجد لها بديلة مباشرة في الواجهة الحديثة.

استخدم طرق تصيير الصور في الواجهة الحديثة بدلاً من الـ API الذي يصدر إلى [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **الأسئلة المتكررة**

**ما الفائدة العملية من [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) مقارنةً بـ [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)؟**

[IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/) يوحد العمل مع الصور النقطية والمتجهية ويبسّط الحفظ إلى صيغ متعددة عبر [ImageFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imageformat/).

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

التحويل من `getThumbnail` إلى `getImage` لا يُسّب تدهورًا في السيناريوهات: توفر الطرق الجديدة نفس الإمكانيات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصيير. الكسب أو الفقد المحدد يعتمد على السيناريو، لكن وظيفيًا البدائل متكافئة.