---
title: "بهبود پردازش تصویر با API مدرن"
linktitle: "API مدرن"
type: docs
weight: 237
url: /fa/nodejs-java/modern-api/
keywords:
- API مدرن
- ترسیم
- تصویر بندانگشتی اسلاید
- تبدیل اسلاید به تصویر
- تصویر بندانگشتی شکل
- تبدیل شکل به تصویر
- تصویر بندانگشتی ارائه
- تبدیل ارائه به تصاویر
- افزودن تصویر
- افزودن عکس
- Node.js
- JavaScript
- Aspose.Slides
description: "پردازش تصویر اسلایدها را با جایگزینی APIهای منسوخ تصویر با API مدرن جاوااسکریپت برای خودکارسازی یکپارچه PowerPoint و OpenDocument به‌روز کنید."
---
## **مقدمه**

به‌صورت تاریخی، Aspose Slides وابستگی به `java.awt` دارد و در API عمومی کلاس‌های زیر را از آن ارائه می‌دهد:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

از نسخه 24.4، این API عمومی به‌عنوان منسوخ اعلام شده است.

برای حذف وابستگی به این کلاس‌ها، «API مدرن» اضافه شد؛ یعنی APIیی که به‌جای API منسوخ استفاده شود و امضاهای آن دیگر به [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) وابسته نیستند. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) نیز منسوخ اعلام شد و پشتیبانی آن از API عمومی Slides حذف شد.

در نسخه‌های کنونی، API عمومی که به انواع `java.awt` وابسته است را به‌عنوان منسوخ/ارثی درنظر بگیرید. برای کد جدید و هنگام مهاجرت گردش‌کارهای پردازش تصویر موجود، از API مدرن استفاده کنید.

## **API مدرن**

کلاس‌ها و ‎enum‎های زیر به API عمومی اضافه شد:

- [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) – نمایانگر تصویر رستر یا برداری.
- [ImageFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imageformat/) – نشان‌دهنده فرمت فایل تصویر.
- [Images](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/images/) – متدهایی برای ایجاد نمونه و کار با کلاس [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/).

لطفاً توجه داشته باشید که [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) قابل حذف (disposable) است و پس از استفاده باید با فراخوانی `dispose()` یا الگوی مناسب دیگر آزاد شود.

از `getImage` برای رندر یک اسلاید یا شکل استفاده کنید. از `getImages` برای رندر چندین اسلاید ارائه‌نامه استفاده کنید. از متدهای ‎[Images](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/images/)‎ برای بارگذاری تصاویر، `addImage` همراه با [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) برای افزودن به ارائه‌نامه و `replaceImage` همراه با [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) برای به‌روزرسانی تصویر موجود استفاده کنید.

یک سناریوی معمول برای استفاده از API جدید به شکل زیر است:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // یک نمونه قابل حذف از IImage را از فایل روی دیسک ایجاد کنید.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // یک تصویر PowerPoint را با افزودن یک نمونه از IImage به تصاویر ارائه‌نامه ایجاد کنید.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // یک شکل تصویر را بر روی اسلاید #1 اضافه کنید.
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // یک نمونه از IImage که نمایانگر اسلاید #1 است دریافت کنید.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // تصویر را روی دیسک ذخیره کنید.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **جایگزینی کدهای قدیمی با API مدرن**

در کل، باید فراخوانی‌هایی که از [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) و [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) استفاده می‌کنند را با متدهای جدیدی که از [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) استفاده می‌کنند، جایگزین کنید.

### API منسوخ/ارثی:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
### API مدرن:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **دریافت تصویر بندانگشتی اسلاید**

API منسوخ/ارثی:

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

API مدرن:

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

### **دریافت تصویر بندانگشتی شکل**

API منسوخ/ارثی:

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

API مدرن:

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

### **دریافت تصویر بندانگشتی ارائه‌نامه**

API منسوخ/ارثی:

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

API مدرن:

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

### **افزودن تصویر به ارائه‌نامه**

API منسوخ/ارثی:

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

API مدرن:

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
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

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

متدهای دارای [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) منسوخ اعلام شده‌اند و جایگزین مستقیم Modern API ندارند.

به‌جای API که به ‎[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)‎ رندر می‌کند، از متدهای رندر تصویر Modern API استفاده کنید:

[Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **سوالات متداول**

**مزیت عملی استفاده از [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) نسبت به [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) چیست؟**

[IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) کار با تصاویر رستر و برداری را یکپارچه می‌کند و ذخیره‌سازی به فرمت‌های مختلف را از طریق [ImageFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imageformat/) ساده می‌سازد.

**آیا API مدرن بر عملکرد تولید تصویرهای بندانگشتی تأثیر می‌گذارد؟**

تغییر از `getThumbnail` به `getImage` عملکرد را خراب نمی‌کند: متدهای جدید همان قابلیت‌ها را برای تولید تصویر با گزینه‌ها و اندازه‌ها فراهم می‌کنند و همچنان از گزینه‌های رندر پشتیبانی می‌کنند. سود یا ضرر خاصی به‌صورت کلی وجود ندارد؛ به‌طور عملکردی جایگزین‌ها معادل هستند.