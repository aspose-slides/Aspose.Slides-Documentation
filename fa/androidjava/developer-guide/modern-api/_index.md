---
title: "بهبود پردازش تصویر با API مدرن"
linktitle: "API مدرن"
type: docs
weight: 237
url: /fa/androidjava/modern-api/
keywords:
- "گرافیک اندروید"
- "API مدرن"
- "رسم"
- "تصویر بندانگشتی اسلاید"
- "تبدیل اسلاید به تصویر"
- "تصویر بندانگشتی شکل"
- "تبدیل شکل به تصویر"
- "تصویر بندانگشتی ارائه"
- "تبدیل ارائه به تصاویر"
- "افزودن تصویر"
- "افزودن تصویر"
- "اندروید"
- "جاوا"
- "Aspose.Slides"
description: "پردازش تصویر اسلاید را با جایگزینی APIهای تصویری منسوخ با API مدرن جاوا، به‌روز کنید تا خودکارسازی بی‌دردسر PowerPoint و OpenDocument فراهم شود."
---
## **مقدمه**

به‌طور تاریخی، Aspose Slides به android.graphics وابسته بوده و در API عمومی کلاس‌های زیر را از آن داشته است:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

از نسخه 24.4، این API عمومی به‌عنوان منسوخ اعلام شده است.

برای از بین بردن وابستگی‌ها به این کلاس‌ها، ما به اصطلاح «API مدرن» را اضافه کردیم – یعنی APIی که باید به‌جای نسخه منسوخ استفاده شود، که امضاهای آن شامل وابستگی به [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) هستند. [Canvas](https://developer.android.com/reference/android/graphics/Canvas) به‌عنوان منسوخ اعلام شده و پشتیبانی آن از API عمومی Slides حذف شده است.

در نسخه‌های کنونی، API عمومی که به انواع android.graphics وابسته است را به‌عنوان قبلی/منسوخ در نظر بگیرید. برای کدهای جدید و هنگام مهاجرت از گردش‌کارهای پردازش تصویر موجود از API مدرن استفاده کنید.

## **API مدرن**

کلاس‌ها و enumهای زیر به API عمومی اضافه شد:

- [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) - نمایان‌گر تصویر رستری یا برداری است.
- [ImageFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imageformat/) - نمایان‌گر فرمت فایل تصویر است.
- [Images](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/images/) - متدهایی برای نمونه‌سازی و کار با رابط [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) .

لطفاً توجه داشته باشید که [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) قابل تخلیه است و پس از استفاده باید با یک فراخوانی `dispose()` یا الگوی تخلیه مناسب دیگری دنبال شود.

از `getImage` برای رندر یک اسلاید یا شکل استفاده کنید. از `getImages` برای رندر چندین اسلاید ارائه استفاده کنید. از متدهای [Images](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/images/) برای بارگذاری تصاویر، `addImage` همراه با [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) برای افزودن آنها به یک ارائه، و `replaceImage` همراه با [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) برای به‌روزرسانی تصویر موجود در ارائه استفاده کنید.

یک سناریوی معمولی برای استفاده از API جدید به‌صورت زیر می‌تواند باشد:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // یک نمونه قابل تخلیه از IImage را از فایل روی دیسک ایجاد می‌کند.
    IImage image = Images.fromFile("image.png");
    try {
        // یک تصویر PowerPoint ایجاد می‌کند با افزودن یک نمونه از IImage به تصاویر ارائه.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // یک شکل تصویر روی اسلاید شماره 1 اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // یک نمونه از IImage که اسلاید شماره 1 را نشان می‌دهد دریافت می‌کند.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // تصویر را روی دیسک ذخیره می‌کند.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **جایگزینی کدهای قدیمی با API مدرن**

به‌طور کلی، باید فراخوانی‌هایی را که از [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) استفاده می‌کنند با متدهای جدیدی که از [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) استفاده می‌کنند جایگزین کنید.

API قدیمی/منسوخ:
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
API مدرن:
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

### **دریافت تصویر بندانگشتی اسلاید**

API قدیمی/منسوخ:

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

API مدرن:

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

### **دریافت تصویر بندانگشتی شکل**

API قدیمی/منسوخ:

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

API مدرن:

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

### **دریافت تصویر بندانگشتی ارائه**

API قدیمی/منسوخ:

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

API مدرن:

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

### **افزودن تصویر به یک ارائه**

API قدیمی/منسوخ:

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

API مدرن:

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

## **متدهای منسوخ و جایگزین‌های آنها در API مدرن**

### **Presentation**
| امضا متد | امضا متد جایگزین |
|---|---|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| امضا متد | امضا متد جایگزین |
|---|---|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| امضا متد | امضا متد جایگزین |
|---|---|
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
| امضا متد | امضا متد جایگزین |
|---|---|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| امضا متد | امضا متد جایگزین |
|---|---|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| امضا متد | امضا متد جایگزین |
|---|---|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| امضا متد | امضا متد جایگزین |
|---|---|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| امضا متد | امضا متد جایگزین |
|---|---|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **پشتیبانی API برای Canvas**

متدهایی که از [Canvas](https://developer.android.com/reference/android/graphics/Canvas) استفاده می‌کنند به‌عنوان منسوخ اعلام شده‌اند و جایگزین مستقیم در API مدرن ندارند.

به‌جای APIی که به [Canvas](https://developer.android.com/reference/android/graphics/Canvas) رندر می‌کند، از متدهای رندر تصویر API مدرن استفاده کنید:

[Slide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **سؤالات متداول**

**چرا android.graphics.Canvas حذف شد؟**

پشتیبانی از [Canvas](https://developer.android.com/reference/android/graphics/Canvas) در API عمومی منسوخ شده است تا کار با رندر و تصاویر یکپارچه شود، وابستگی‌های خاص پلتفرم حذف شوند و به رویکرد کراس‌پلتفرم با [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) تغییر یابد. به‌جای رندر به [Canvas](https://developer.android.com/reference/android/graphics/Canvas) از `getImage` یا `getImages` استفاده کنید.

**فایده عملی [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) نسبت به [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) چیست؟**

[IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) کار با هر دو نوع تصویر رستری و برداری را یکپارچه می‌کند و ذخیره‌سازی در فرمت‌های مختلف را با استفاده از [ImageFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imageformat/) ساده می‌سازد.

**آیا API مدرن بر عملکرد تولید تصویرهای بندانگشتی تأثیر خواهد گذاشت؟**

تغییر از `getThumbnail` به `getImage` باعث کاهش کارایی نمی‌شود: متدهای جدید همان قابلیت‌ها را برای تولید تصاویر با گزینه‌ها و اندازه‌ها فراهم می‌کنند، در حالی که از گزینه‌های رندر پشتیبانی می‌کنند. سود یا کاهش خاص به سناریو بستگی دارد، اما از نظر عملکردی جایگزین‌ها معادل هستند.