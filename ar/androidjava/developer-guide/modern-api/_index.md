---
title: تعزيز معالجة الصور باستخدام API الحديثة
linktitle: API الحديثة
type: docs
weight: 237
url: /ar/androidjava/modern-api/
keywords:
- android.graphics
- API الحديثة
- رسم
- مصغّر الشريحة
- تحويل الشريحة إلى صورة
- مصغّر الشكل
- تحويل الشكل إلى صورة
- مصغّر العرض
- تحويل العرض إلى صور
- إضافة صورة
- إضافة صورة
- Android
- Java
- Aspose.Slides
description: "تحديث معالجة صور الشرائح عبر استبدال واجهات برمجة التطبيقات التصويرية المتقعدة بـ API الحديثة لجافا لتحقيق أتمتة سلسة لعروض PowerPoint ووثائق OpenDocument."
---
## **المقدمة**

تاريخياً، تعتمد Aspose Slides على android.graphics وتحتوي الواجهة البرمجية العامة على الفئات التالية منها:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

اعتباراً من الإصدار 24.4، تم إعلان أن هذه الواجهة البرمجية العامة قد عُتقِدت.

للتخلص من الاعتماد على هذه الفئات، أضفنا ما يسمى بـ "API الحديثة" – أي الواجهة التي يجب استخدامها بدلاً من القديمة، والتي لا تحتوي توقيعاتها على اعتمادات على [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). تم إعلان أن [Canvas](https://developer.android.com/reference/android/graphics/Canvas) قد عُتقِد وتم إزالة دعمه من الواجهة العامة لـ Slides.

في الإصدارات الحالية، اعتبار الواجهة العامة التي تعتمد على أنواع android.graphics قديمة/معتقَدة. استخدم الـ API الحديثة للشفرة الجديدة وعند نقل سير عمل معالجة الصور الحالي.

## **API الحديثة**

تم إضافة الفئات والعدادات التالية إلى الواجهة العامة:

- [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) – تمثّل الصورة النقطية أو المتجهة.
- [ImageFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imageformat/) – تمثّل تنسيق ملف الصورة.
- [Images](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/images/) – طرق لإنشاء والعمل مع واجهة [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/).

يرجى ملاحظة أن [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) قابل للتصرف ويجب إتباع استخدامه بنداء `dispose()` أو نمط تصرف مناسب آخر.

استخدم `getImage` لتصوير شريحة أو شكل واحد. استخدم `getImages` لتصوير عدة شرائح عرض. استخدم طرق [Images](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/images/) لتحميل الصور، `addImage` مع [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) لإضافتها إلى عرض، و `replaceImage` مع [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) لتحديث صورة موجودة في العرض.

يمكن أن يبدو سيناريو الاستخدام النموذجي للواجهة الجديدة كما يلي:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // إنشاء كائن IImage قابل للتصرف من الملف على القرص.
    IImage image = Images.fromFile("image.png");
    try {
        // إنشاء صورة PowerPoint بإضافة كائن IImage إلى صور العرض.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة شكل صورة إلى الشريحة رقم 1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على كائن IImage الذي يمثل الشريحة رقم 1.
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

## **استبدال الشيفرة القديمة بالـ API الحديثة**

بشكل عام، ستحتاج إلى استبدال الاستدعاءات التي تستخدم [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) بالطرق الجديدة التي تستخدم [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/).

الـ API القديمة/المعتقَدة:
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
الـ API الحديثة:
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

### **إنشاء صورة مصغرة لشريحة**

الـ API القديمة/المعتقَدة:

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

الـ API الحديثة:

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

### **إنشاء صورة مصغرة لشكل**

الـ API القديمة/المعتقَدة:

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

الـ API الحديثة:

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

### **إنشاء صورة مصغرة للعرض**

الـ API القديمة/المعتقَدة:

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

الـ API الحديثة:

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

### **إضافة صورة إلى عرض**

الـ API القديمة/المعتقَدة:

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

الـ API الحديثة:

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

## **الطرق المعتقَدة واستبدالها في الـ API الحديثة**

### **Presentation**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| توقيع الطريقة | توقيع الطريقة البديلة |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| توقيع الطريقة | توقيع الطريقة البديلة |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | لا يوجد بديل في الـ API الحديثة |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | لا يوجد بديل في الـ API الحديثة |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | لا يوجد بديل في الـ API الحديثة |

### **Output**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| توقيع الطريقة | توقيع الطريقة البديلة |
|--------------------------------------|-----------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **دعم الـ API للـ Canvas**

الطرق التي تحتوي على [Canvas](https://developer.android.com/reference/android/graphics/Canvas) معلنة بأنها مُعتقَدة ولا يوجد لها بديل مباشر في الـ API الحديثة.

استخدم طرق تصوير الصور في الـ API الحديثة بدلاً من تلك التي تُصوّر إلى [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **الأسئلة الشائعة**

**لماذا تم حذف android.graphics.Canvas؟**

تم اعتقاد دعم [Canvas](https://developer.android.com/reference/android/graphics/Canvas) في الواجهة العامة لتوحيد العمل مع التصوير والصور، وإزالة الروابط إلى الاعتماديات الخاصة بالمنصة، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/). استخدم `getImage` أو `getImages` بدلاً من التصوير إلى [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**ما الفائدة العملية من [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) مقارنةً بـ [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)؟**

[IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) يوحد العمل مع الصور النقطية والمتجهة ويُبسّط الحفظ إلى صيغ مختلفة عبر [ImageFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imageformat/).

**هل سيؤثر الـ API الحديثة على أداء إنشاء الصور المصغرة؟**

التحويل من `getThumbnail` إلى `getImage` لا يضيّق السيناريوهات: الطرق الجديدة توفر نفس الإمكانات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصوير. الكسب أو الفقدان المحدد يعتمد على السيناريو، لكن استبدالات الوظيفة متكافئة.