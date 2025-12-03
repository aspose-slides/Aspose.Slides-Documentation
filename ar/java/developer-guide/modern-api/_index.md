---
title: تعزيز معالجة الصور باستخدام الواجهة الحديثة
linktitle: الواجهة الحديثة
type: docs
weight: 237
url: /ar/java/modern-api/
keywords:
- واجهة حديثة
- رسم
- صورة مصغرة للشفرة
- تحويل الشفرة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض التقديمي
- تحويل العرض التقديمي إلى صور
- إضافة صورة
- إضافة صورة
- Java
- Aspose.Slides
description: "تحديث معالجة صور الشرائح عن طريق استبدال واجهات الصور المهجورة بواجهة Java الحديثة لتسهيل أتمتة PowerPoint و OpenDocument."
---

## **المقدمة**

تاريخيًا، كان Aspose Slides يعتمد على java.awt وكان في واجهة برمجة التطبيقات العامة يحتوي على الفئات التالية من هناك:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

اعتبارًا من الإصدار 24.4، تم الإعلان عن إهمال هذه الواجهة العامة.

من أجل التخلص من الاعتماد على هذه الفئات، أضفنا ما يُسمى "الواجهة الحديثة" – أي الواجهة التي يجب استخدامها بدلًا من الواجهة المهملة، والتي لا تتضمن توقيعات تعتمد على BufferedImage. تم إعلان Graphics2D مهجورًا وتم إزالة دعمه من واجهة Slides العامة.

إزالة الواجهة العامة المهملة التي تعتمد على System.Drawing سيكون في الإصدار 24.8.

## **الواجهة الحديثة**

تم إضافة الفئات والعدادات التالية إلى الواجهة العامة:

- IImage – تمثل الصورة النقطية أو المتجهية.
- ImageFormat – يمثل تنسيق ملف الصورة.
- Images – طرق لإنشاء والعمل مع واجهة IImage.

يرجى ملاحظة أن IImage قابلة للتصرف (تُنفّذ واجهة IDisposable ويجب تغليف استخدامها في using أو التخلص منها بطريقة ملائمة).

سيناريو نموذجي لاستخدام الواجهة الجديدة قد يبدو كما يلي:
``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // إنشاء مثيل قابل للتخلص منه من IImage من الملف على القرص.
    IImage image = Images.fromFile("image.png");
    try {
        // إنشاء صورة PowerPoint بإضافة مثيل IImage إلى صور العرض التقديمي.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة شكل صورة على الشريحة رقم 1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على مثيل IImage يمثل الشريحة رقم 1.
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


## **استبدال الكود القديم بالواجهة الحديثة**

بشكل عام، ستحتاج إلى استبدال استدعاء الطريقة القديمة باستخدام ImageIO بالبديل الجديد.

القديم:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```

الجديد:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```


### **الحصول على صورة مصغرة للشفرة**

الكود باستخدام واجهة مهملة:
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


الواجهة الحديثة:
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


### **الحصول على صورة مصغرة للشكل**

الكود باستخدام واجهة مهملة:
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


الواجهة الحديثة:
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


### **الحصول على صورة مصغرة للعرض التقديمي**

الكود باستخدام واجهة مهملة:
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


الواجهة الحديثة:
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


### **إضافة صورة إلى العرض التقديمي**

الكود باستخدام واجهة مهملة:
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


الواجهة الحديثة:
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


## **الطرق التي ستُزال وبدائلها في الواجهة الحديثة**

### **العرض التقديمي**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **الشكل**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **الشفرة**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
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

### **الإخراج**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| توقيع الطريقة | توقيع الطريقة البديلة |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **سيتم إيقاف دعم واجهة Graphics2D**

الطرق التي تستخدم [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) تم إعلانها مهملة وسيتم إزالة دعمها من الواجهة العامة.

الجزء من الواجهة الذي يستخدمها سيُحذف:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **الأسئلة المتكررة**

**لماذا تم حذف java.awt.Graphics2D؟**

يتم إزالة دعم `Graphics2D` من الواجهة العامة لتوحيد العمل مع التصيير والصور، وإلغاء الروابط إلى الاعتمادات الخاصة بالنظام الأساسي، والتحول إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/). سيتم حذف جميع طرق التصيير إلى `Graphics2D`.

**ما الفائدة العملية لـ IImage مقارنةً بـ BufferedImage؟**

[IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) يدمج العمل مع كل من الصور النقطية والمتجهية ويبسّط الحفظ إلى صيغ مختلفة عبر [ImageFormat](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/).

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

الانتقال من `getThumbnail` إلى `getImage` لا ي ухудшит الأداء في السيناريوهات العامة: الطرق الجديدة توفر نفس الإمكانات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصيير. الكسب أو الفقدان المحدد يعتمد على السيناريو، لكن الوظيفية متكافئة.