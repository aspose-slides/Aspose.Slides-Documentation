---
title: تعزيز معالجة الصور باستخدام الواجهة الحديثة
linktitle: الواجهة الحديثة
type: docs
weight: 237
url: /ar/java/modern-api/
keywords:
- الواجهة الحديثة
- الرسم
- صورة مصغرة للشريحة
- تحويل الشريحة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض
- تحويل العرض إلى صور
- إضافة صورة
- إضافة صورة
- Java
- Aspose.Slides
description: "تحديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات المتقادمة للصور بالواجهة الحديثة لجافا لتوفير أتمتة سلسة لملفات PowerPoint وOpenDocument."
---
## **المقدمة**

تاريخيًا، تعتمد Aspose Slides على java.awt وتحتوي الواجهة العامة على الفئات التالية من هناك:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

اعتبارًا من الإصدار 24.4، تم إعلان أن هذه الواجهة العامة مهجورة.

من أجل التخلص من الاعتماد على هذه الفئات، أضفنا ما يسمى بـ "Modern API" - أي الواجهة التي يجب استخدامها بدلاً من الواجهة المهجورة، والتي لا تحتوي توقيعاتها على تبعيات على [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). تم إعلان [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) مهجور وتم إزالة دعمه من الواجهة العامة لـ Slides.

في الإصدارات الحالية، اعتبر الواجهة العامة التي تعتمد على أنواع java.awt قديمة/مهجورة. استخدم الواجهة الحديثة للكود الجديد وعند ترحيل سير عمل معالجة الصور الحالي.

## **الواجهة الحديثة**

تمت إضافة الفئات والعدادات (enums) التالية إلى الواجهة العامة:

- [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) - تمثّل الصورة النقطية أو المتجهة.
- [ImageFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imageformat/) - تمثّل تنسيق ملف الصورة.
- [Images](https://reference.aspose.com/slides/ar/java/com.aspose.slides/images/) - طرق لإنشاء والعمل مع واجهة [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/).

يرجى ملاحظة أن [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) قابل للتخلص منه ويجب أن يتبعه استدعاء `dispose()` أو أي نمط التخلص المناسب.

استخدم `getImage` لتوليد شريحة أو شكل واحد. استخدم `getImages` لتوليد عدة شرائح عرض. استخدم طرق [Images](https://reference.aspose.com/slides/ar/java/com.aspose.slides/images/) لتحميل الصور، `addImage` مع [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) لإضافتها إلى عرض تقديمي، و `replaceImage` مع [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) لتحديث صورة موجودة في العرض.

مثال نموذجي لاستخدام الواجهة الجديدة قد يبدو كما يلي:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // إنشاء كائن IImage قابل للتخلص منه من الملف على القرص.
    IImage image = Images.fromFile("image.png");
    try {
        // إنشاء صورة PowerPoint بإضافة كائن IImage إلى صور العرض التقديمي.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة شكل صورة على الشريحة #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على كائن IImage الذي يمثل الشريحة #1.
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

بشكل عام، ستحتاج إلى استبدال الاستدعاءات التي تستخدم [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) و ImageIO بالطرق الجديدة التي تستخدم [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/).

الواجهة القديمة/المهجورة:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
الواجهة الحديثة:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **الحصول على صورة مصغرة للشريحة**

الواجهة القديمة/المهجورة:

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

الواجهة القديمة/المهجورة:

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

الواجهة القديمة/المهجورة:

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

### **إضافة صورة إلى عرض تقديمي**

الواجهة القديمة/المهجورة:

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

## **الطرق المهجورة واستبدالها في الواجهة الحديثة**

### **Presentation**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| توقيع الطريقة | توقيع الطريقة البديلة |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| توقيع الطريقة | توقيع الطريقة البديلة |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | لا يوجد بديل في الواجهة الحديثة |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | لا يوجد بديل في الواجهة الحديثة |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | لا يوجد بديل في الواجهة الحديثة |

### **Output**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| توقيع الطريقة | توقيع الطريقة البديلة |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **دعم API لـ Graphics2D**

الطرق التي تستخدم [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) تم إعلانها مهجورة ولا يوجد لها بديل مباشر في الواجهة الحديثة.

استخدم طرق عرض الصور في الواجهة الحديثة بدلاً من الواجهة التي تعرض إلى [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **الأسئلة المتكررة**

**لماذا تم إلغاء [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)؟**

تم إلغاء دعم [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) في الواجهة العامة لتوحيد العمل مع العرض والصور، وإزالة الروابط إلى تبعيات خاصة بالمنصة، والتحول إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/). استخدم `getImage` أو `getImages` بدلاً من العرض إلى [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**ما الفائدة العملية من [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) مقارنة بـ [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)؟**

[IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) يوحد العمل مع كل من الصور النقطية والمتجهة ويبسّط حفظها بأشكال متعددة عبر [ImageFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imageformat/).

**هل ستؤثر الواجهة الحديثة على أداء توليد الصور المصغرة؟**

التحول من `getThumbnail` إلى `getImage` لا يفاقم السيناريوهات: الطرق الجديدة توفر نفس القدرات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات العرض. الفائدة أو الفقد المحدد يعتمد على السيناريو، لكن وظيفيًا البدائل متكافئة.