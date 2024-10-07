---
title: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 237
url: /androidjava/modern-api/
keywords: "واجهة برمجة التطبيقات الحديثة متعددة المنصات"
description: "واجهة برمجة التطبيقات الحديثة"
---

## مقدمة

تاريخيًا، تعتمد Aspose Slides على java.awt وتحتوي على الفئات التالية من هناك في واجهة البرمجة العامة:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

اعتبارًا من الإصدار 24.4، تم الإعلان عن هذه الواجهة البرمجية العامة على أنها قديمة.

للتخلص من الاعتماد على هذه الفئات، أضفنا ما يسمى "واجهة برمجة التطبيقات الحديثة" - أي الواجهة التي ينبغي استخدامها بدلاً من القديمة، والتي تحتوي توقيعاتها على اعتماد على Bitmap. تم الإعلان عن Canvas على أنها قديمة وتمت إزالة دعمها من واجهة برمجة تطبيقات Slides العامة.

سيتم إزالة واجهة البرمجة العامة القديمة التي تعتمد على System.Drawing في الإصدار 24.8.

## واجهة برمجة التطبيقات الحديثة

أضيفت الفئات والأنماط التالية إلى الواجهة البرمجية العامة:

- IImage - تمثل الصورة النقطية أو الصورة المتجهة.
- ImageFormat - تمثل تنسيق ملف الصورة.
- Images - طرق لإنشاء وإدارة واجهة IImage.

يرجى ملاحظة أن IImage يمكن التخلص منها (تImplement الواجهة IDisposable ويجب تغليف استخدامها داخل استخدام أو التخلص منه بطريقة مريحة أخرى).

قد يبدو سيناريو استخدام الواجهة الجديدة على النحو التالي:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // إنشاء مثيل قابل للتخلص من IImage من ملف على القرص.
    IImage image = Images.fromFile("image.png");
    try {
        // إنشاء صورة PowerPoint عن طريق إضافة مثيل IImage إلى صور العرض التقديمي.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة شكل صورة على الشريحة #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // الحصول على مثيل IImage يمثل الشريحة #1.
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

## استبدال الكود القديم بواجهة برمجة التطبيقات الحديثة

بشكل عام، ستحتاج إلى استبدال الاتصال بالطريقة القديمة باستخدام ImageIO بالطريقة الجديدة.

قديم:
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
جديد:
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

### الحصول على صورة مصغرة لشريحة

كود يستخدم واجهة برمجة التطبيقات القديمة:

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

كود يستخدم واجهة برمجة التطبيقات القديمة:

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

كود يستخدم واجهة برمجة التطبيقات القديمة:

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

واجهة برمجة التطبيقات الحديثة:

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

### إضافة صورة إلى العرض التقديمي

كود يستخدم واجهة برمجة التطبيقات القديمة:

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

## الطرق التي سيتم إزالتها واستبدالها بواجهة برمجة التطبيقات الحديثة

### العرض التقديمي
| توقيع الطريقة                               | توقيع الطريقة البديلة                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### الشكل
| توقيع الطريقة                                                      | توقيع الطريقة البديلة                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### الشريحة
| توقيع الطريقة                                                      | توقيع الطريقة البديلة                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | سيتم حذفه بالكامل  |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | سيتم حذفه بالكامل  |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | سيتم حذفه بالكامل  |

### الإخراج
| توقيع الطريقة                                                | توقيع الطريقة البديلة                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### مجموعة الصور
| توقيع الطريقة                          | توقيع الطريقة البديلة               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### PPImage
| توقيع الطريقة                     | توقيع الطريقة البديلة   |
|--------------------------------------|-----------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### تنسيق الأنماط
| توقيع الطريقة                                          | توقيع الطريقة البديلة                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor)   | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### بيانات تنسيق الأنماط الفعالة
| توقيع الطريقة                                          | توقيع الطريقة البديلة                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## سيتم إيقاف دعم واجهة البرمجة لإطار الرسم Canvas

تم الإعلان عن الطرق باستخدام [Canvas](https://developer.android.com/reference/android/graphics/Canvas) على أنها قديمة وسيتم إزالة دعمها من واجهة البرمجة العامة.

سيتم إزالة الجزء من واجهة البرمجة الذي يستخدمها:

[Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)