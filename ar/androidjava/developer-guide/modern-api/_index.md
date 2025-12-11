---
title: تحسين معالجة الصور باستخدام الواجهة البرمجية الحديثة
linktitle: الواجهة البرمجية الحديثة
type: docs
weight: 237
url: /ar/androidjava/modern-api/
keywords:
- System.Drawing
- واجهة برمجة التطبيقات الحديثة
- رسم
- صورة مصغرة للشرائح
- تحويل الشريحة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض التقديمي
- تحويل العرض التقديمي إلى صور
- إضافة صورة
- إضافة صورة
- Android
- Java
- Aspose.Slides
description: "قم بتحديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات التصويرية المهجورة بواجهة برمجة التطبيقات الحديثة لـ Java لتسهيل الأتمتة لـ PowerPoint و OpenDocument."
---

## **المقدمة**

تاريخياً، كان Aspose Slides يعتمد على java.awt ويحتوي في واجهة برمجة التطبيقات العامة على الفئات التالية من هناك:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

اعتبارًا من الإصدار 24.4، تم إعلان أن هذه الواجهة العامة مهجورة.

من أجل التخلص من الاعتماد على هذه الفئات، أضفنا ما يُسمى بـ “واجهة برمجة التطبيقات الحديثة” – أي الواجهة التي يجب استخدامها بدلًا من الواجهة المهجورة، التي تحتوي توقيعاتها على الاعتمادات على Bitmap. تم إعلان Canvas مهجور وتم إزالة دعمه من واجهة Slides العامة.

إزالة واجهة البرمجة العامة المهجورة التي تعتمد على System.Drawing ستكون في الإصدار 24.8.

## **واجهة برمجة التطبيقات الحديثة**

تمت إضافة الفئات والعدادات التالية إلى الواجهة العامة:

- IImage – تمثّل الصورة النقطية أو المتجهة.
- ImageFormat – تمثّل تنسيق ملف الصورة.
- Images – طرق لإنشاء والعمل مع واجهة IImage.

يرجى ملاحظة أن IImage قابل للتصريف (ينفّذ واجهة IDisposable ويجب تغليفه في using أو تصريفه بطريقة ملائمة).

سيناريو نموذجي لاستخدام الواجهة الجديدة قد يبدو كما يلي:
``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // إنشاء نسخة قابلة للتصريف من IImage من الملف على القرص.
    IImage image = Images.fromFile("image.png");
    try {
        // إنشاء صورة PowerPoint بإضافة نسخة من IImage إلى صور العرض التقديمي.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة شكل صورة إلى الشريحة رقم 1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على نسخة من IImage تمثل الشريحة رقم 1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
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


## **استبدال الكود القديم بواجهة برمجة التطبيقات الحديثة**

بشكل عام، ستحتاج إلى استبدال استدعاء الطريقة القديمة التي تستخدم ImageIO بالاستدعاء الجديد.

القديم:
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

الجديد:
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


### **الحصول على صورة مصغرة للشرائح**

كود يستخدم واجهة مهجورة:
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


واجهة حديثة:
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

كود يستخدم واجهة مهجورة:
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


واجهة حديثة:
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

كود يستخدم واجهة مهجورة:
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


واجهة حديثة:
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


### **إضافة صورة إلى العرض التقديمي**

كود يستخدم واجهة مهجورة:
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


واجهة حديثة:
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


## **الطرق التي ستُحذف واستبدالاتها في الواجهة الحديثة**

### **العرض التقديمي**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **الشكل**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **الشريحة**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | Will be deleted completely |

### **المخرجات**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|--------------------------------------|-----------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|-----------------------------------------------------------|------------------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| توقيع الطريقة | توقيع طريقة الاستبدال |
|-----------------------------------------------------------|------------------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **إيقاف دعم Canvas في الواجهة البرمجية**

الطرق التي تستخدم [Canvas](https://developer.android.com/reference/android/graphics/Canvas) معلنة كمهجورة وسيتم إزالة دعمها من الواجهة العامة.

الجزء من الواجهة الذي يستخدمها سيتم إزالته:

[Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **الأسئلة الشائعة**

**لماذا تم حذف android.graphics.Canvas؟**

يتم إزالة دعم `Canvas` من الواجهة العامة لتوحيد العمل مع التصيير والصور، وإلغاء الاعتماد على الاعتمادات الخاصة بالمنصة، والتحول إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/). ستُحذف جميع طرق التصيير إلى `Canvas`.

**ما الفائدة العملية من IImage مقارنةً بـ BufferedImage؟**

[IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) يوحّد التعامل مع الصور النقطية والمتجهة ويبسّط حفظها بصيغ مختلفة عبر [ImageFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/).

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

التحول من `getThumbnail` إلى `getImage` لا يضعف السيناريوهات: الطرق الجديدة توفر نفس القدرات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصيير. الفائدة أو الخسارة المحددة تعتمد على السيناريو، لكن بدائيًا الاستبدالات متكافئة من حيث الوظيفة.