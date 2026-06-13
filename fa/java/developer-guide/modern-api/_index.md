---
title: بهبود پردازش تصویر با API مدرن
linktitle: API مدرن
type: docs
weight: 237
url: /fa/java/modern-api/
keywords:
- API مدرن
- رسم
- تصویر بندانگشتی اسلاید
- تبدیل اسلاید به تصویر
- تصویر بندانگشتی شکل
- تبدیل شکل به تصویر
- تصویر بندانگشتی ارائه
- تبدیل ارائه به تصاویر
- افزودن تصویر
- افزودن عکس
- Java
- Aspose.Slides
description: "پردازش تصویر اسلایدها را با جایگزینی APIهای منسوخ تصویربرداری با API مدرن جاوا، برای خودکارسازی یکپارچه PowerPoint و OpenDocument به‌روز کنید."
---
## **مقدمه**

به‌صورت تاریخی، Aspose Slides به java.awt وابسته بوده و در API عمومی کلاس‌های زیر را در بر می‌گیرد:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

از نسخه 24.4، این API عمومی به‌عنوان منسوخ اعلام شده است.

برای حذف وابستگی به این کلاس‌ها، “API مدرن” اضافه شد؛ یعنی APIی که به‌جای نسخهٔ منسوخ استفاده می‌شود و امضاهای آن دیگر به [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) وابسته نیستند. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) منسوخ شده و پشتیبانی آن از API عمومی Slides حذف شده است.

در نسخه‌های فعلی، API عمومی که به انواع java.awt وابسته است به‌عنوان قدیمی/منسوخ در نظر گرفته می‌شود. برای کدهای جدید و هنگام مهاجرت گردش‌کارهای پردازش تصویر، از API مدرن استفاده کنید.

## **API مدرن**

کلاس‌ها و enum‌های زیر به API عمومی اضافه شد:

- [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) – نمایانگر تصویر رستری یا برداری.
- [ImageFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imageformat/) – نمایانگر فرمت فایل تصویر.
- [Images](https://reference.aspose.com/slides/fa/java/com.aspose.slides/images/) – روش‌هایی برای ایجاد نمونه و کار با رابط [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/).

لطفاً توجه داشته باشید که [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) قابل تخلیه است و پس از استفاده باید با فراخوانی `dispose()` یا الگوی تخلیه مناسب دیگر آن را آزاد کنید.

از `getImage` برای رندر یک اسلاید یا شکل استفاده کنید. از `getImages` برای رندر چند اسلاید ارائه استفاده کنید. از متدهای [Images](https://reference.aspose.com/slides/fa/java/com.aspose.slides/images/) برای بارگذاری تصاویر، `addImage` با [IImage] برای افزودن آن‌ها به یک ارائه، و `replaceImage` با [IImage] برای به‌روزرسانی یک تصویر موجود در ارائه استفاده کنید.

یک سناریو معمول برای استفاده از API جدید به‌صورت زیر می‌باشد:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // یک نمونه قابل تخلیه از IImage را از فایل موجود روی دیسک ایجاد می‌کند.
    IImage image = Images.fromFile("image.png");
    try {
        // با افزودن یک نمونه از IImage به تصاویر ارائه، یک تصویر PowerPoint ایجاد می‌کند.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // افزودن یک شکل تصویر به اسلاید شماره ۱
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // دریافت یک نمونه از IImage که نمایانگر اسلاید شماره ۱ است.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // ذخیره تصویر روی دیسک.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **جایگزینی کدهای قدیمی با API مدرن**

به‌طور کلی، باید فراخوانی‌هایی را که از [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) و ImageIO استفاده می‌کنند، با متدهای جدیدی که از [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) استفاده می‌کنند، جایگزین کنید.

API قدیمی/منسوخ:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
API مدرن:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **دریافت تصویر بندانگشتی اسلاید**

API قدیمی/منسوخ:

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

API مدرن:

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

### **افزودن تصویر به ارائه**

API قدیمی/منسوخ:

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

## **متدهای منسوخ و جایگزین‌های آن‌ها در API مدرن**

### **Presentation**
| امضای متد | امضای متد جایگزین |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| امضای متد | امضای متد جایگزین |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| امضای متد | امضای متد جایگزین |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

### **Output**
| امضای متد | امضای متد جایگزین |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| امضای متد | امضای متد جایگزین |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| امضای متد | امضای متد جایگزین |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| امضای متد | امضای متد جایگزین |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| امضای متد | امضای متد جایگزین |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **پشتیبانی API برای Graphics2D**

متدهای استفاده‌کننده از [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) منسوخ اعلام شده‌اند و جایگزین مستقیم Modern API ندارند.

به‌جای API رندر به [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)، از متدهای رندر تصویر در API مدرن استفاده کنید:

[Slide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**چرا [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) حذف شد؟**

پشتیبانی از [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) در API عمومی منسوخ شده است تا کار با رندر و تصاویر یکپارچه شود، وابستگی به پلتفرم خاص حذف شود و به رویکردی چند‑پلتفرمی با استفاده از [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) سوئیچ شود. به‌جای رندر به [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) از `getImage` یا `getImages` استفاده کنید.

**مزیت عملی استفاده از [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) نسبت به [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) چیست؟**

[IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) کار با تصاویر رستری و برداری را یکپارچه می‌کند و ذخیره در فرمت‌های مختلف را از طریق [ImageFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imageformat/) ساده می‌سازد.

**آیا API مدرن بر عملکرد تولید تصویر بندانگشتی تأثیر می‌گذارد؟**

تغییر از `getThumbnail` به `getImage` عملکرد را کاهش نمی‌دهد؛ متدهای جدید همان قابلیت تولید تصویر با گزینه‌ها و اندازه‌ها را فراهم می‌کنند و همچنان از گزینه‌های رندر پشتیبانی می‌شود. سود یا زیان خاصی بستگی به سناریو دارد، اما از نظر کارکرد جایگزین‌ها معادل هستند.