---
title: بهبود پردازش تصویر با API مدرن
linktitle: API مدرن
type: docs
weight: 237
url: /fa/net/modern-api/
keywords:
- System.Drawing
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
- .NET
- C#
- Aspose.Slides
description: "پردازش تصویر اسلایدها را با جایگزینی APIهای تصویر منسوخ شده با API مدرن .NET برای خودکارسازی یکپارچهٔ PowerPoint و OpenDocument به‌روز کنید."
---
## **مقدمه**

در گذشته، Aspose Slides وابستگی به System.Drawing دارد و در API عمومی کلاس‌های زیر را ارائه می‌دهد:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

از نسخه 24.4 به بعد، این API عمومی اعلام شده است که منسوخ شده است.

از آنجا که پشتیبانی از System.Drawing در نسخه‌های .NET6 و بالاتر برای نسخه‌های غیر ویندوزی حذف شده است ([تغییر شکنی](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))، Slides یک رویکرد دو بسته‌ای پیاده‌سازی کرده است:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) ‑ پشتیبانی برای .NET6+ در ویندوز، .NETStandard برای ویندوز/لینوکس/macOS، .NETFramework 2+ (ویندوز).  
  - دارای وابستگی به [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).  
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) ‑ نسخه ویندوز/لینوکس/macOS بدون وابستگی‌ها.

مشکل بسته [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) این است که نسخهٔ خود از System.Drawing را در همان فضای نام پیاده‌سازی می‌کند (برای پشتیبانی از سازگاری با API عمومی). بنابراین، هنگامی که Aspose.Slides.NET6.CrossPlatform و System.Drawing از .NET Framework یا بسته System.Drawing.Common همزمان استفاده شوند، یک تضاد نام رخ می‌دهد مگر اینکه از نام مستعار استفاده شود.

برای حذف وابستگی‌ها به System.Drawing در بستهٔ اصلی Aspose.Slides.NET، ما به اصطلاح «API مدرن» را اضافه کردیم ‑ یعنی API که باید به جای API منسوخ شده استفاده شود و امضاهای آن شامل وابستگی به انواع زیر از System.Drawing هستند: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) و [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) و [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) منسوخ اعلام شده و پشتیبانی آن‌ها از API عمومی Slides حذف شده است.

در نسخه‌های کنونی، API عمومی که به System.Drawing وابسته است به عنوان Legacy/Deprecated در نظر گرفته می‌شود. برای کد جدید و هنگام مهاجرت فرآیندهای موجود پردازش تصویر، از API مدرن استفاده کنید.

## **API مدرن**

کلاس‌ها و شمارنده‌های زیر به API عمومی اضافه شده‌اند:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) ‑ نمایانگر تصویر رستری یا برداری.  
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/imageformat/) ‑ نمایانگر فرمت فایل تصویر.  
- [Aspose.Slides.Images](https://reference.aspose.com/slides/fa/net/aspose.slides/images/) ‑ متدهایی برای ایجاد نمونه و کار با رابط [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/).

لطفاً توجه داشته باشید که [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) قابل حذف است (این رابط [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) را پیاده‌سازی می‌کند و استفاده از آن باید در یک بلوک `using` یا به روش مناسب دیگری حذف شود).

از `GetImage` برای رندر یک اسلاید یا شکل استفاده کنید. از `GetImages` برای رندر چندین اسلاید ارائه استفاده کنید. از متدهای [Images](https://reference.aspose.com/slides/fa/net/aspose.slides/images/) برای بارگذاری تصاویر، `AddImage` با [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) برای افزودن به ارائه، و `ReplaceImage` با [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) برای به‌روزرسانی تصویر موجود در ارائه استفاده کنید.

یک سناریوی معمولی برای استفاده از API جدید به شکل زیر ممکن است باشد:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // یک نمونه قابل حذف از IImage را از فایل روی دیسک ایجاد کنید.
    using (IImage image = Images.FromFile("image.png"))
    {
        // یک تصویر PowerPoint با افزودن یک نمونه IImage به مجموعهٔ تصاویر ارائه می‌سازد.
        ppImage = pres.Images.AddImage(image);
    }

    // یک شکل تصویر روی اسلاید شماره ۱ اضافه کنید
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // یک نمونه از IImage که اسلاید شماره ۱ را نمایندگی می‌کند دریافت کنید.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // تصویر را بر روی دیسک ذخیره کنید.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **جایگزینی کدهای قدیمی با API مدرن**

برای آسان‌سازی انتقال، رابط [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) امضای جداگانهٔ کلاس‌های [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) و [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) را تکرار می‌کند. به طور کلی فقط کافیست فراخوانی به روش قدیمی که از System.Drawing استفاده می‌کند را با روش جدید جایگزین کنید.

### **دریافت تصویر بندانگشتی اسلاید**

API Legacy/Deprecated:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

API مدرن:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **دریافت تصویر بندانگشتی شکل**

API Legacy/Deprecated:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

API مدرن:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **دریافت تصویر بندانگشتی ارائه**

API Legacy/Deprecated:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

API مدرن:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### **افزودن تصویر به یک ارائه**

API Legacy/Deprecated:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

API مدرن:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

## **متدها/ویژگی‌های منسوخ و جایگزین‌های آن‌ها در API مدرن**

### **Presentation**
| امضای متد | امضای متد جایگزین |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | هیچ جایگزینی در API مدرن وجود ندارد |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | هیچ جایگزینی در API مدرن وجود ندارد |
| public void Print() | هیچ جایگزینی در API مدرن وجود ندارد |
| public void Print(PrinterSettings printerSettings) | هیچ جایگزینی در API مدرن وجود ندارد |
| public void Print(string printerName) | هیچ جایگزینی در API مدرن وجود ندارد |
| public void Print(PrinterSettings printerSettings, string presName) | هیچ جایگزینی در API مدرن وجود ندارد |

### **Shape**
| امضای متد | امضای متد جایگزین |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| امضای متد | امضای متد جایگزین |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | هیچ جایگزینی در API مدرن وجود ندارد |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | هیچ جایگزینی در API مدرن وجود ندارد |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | هیچ جایگزینی در API مدرن وجود ندارد |

### **Output**
| امضای متد | امضای متد جایگزین |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/fa/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| امضای متد | امضای متد جایگزین |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/fa/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| امضای متد | امضای متد جایگزین |
|----------------------------------------------------------|-----------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/fa/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| امضای متد/ویژگی | امضای متد جایگزین |
|--------------------------------------|-------------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/fa/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/fa/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| امضای متد | امضای متد جایگزین |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/fa/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/fa/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| امضای متد | امضای متد جایگزین |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/fa/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **پشتیبانی API برای Graphics و PrinterSettings**

کلاس [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) برای نسخه‌های Cross‑Platform .NET6 و بالاتر پشتیبانی نمی‌شود. در Aspose Slides، به‌جای API که به [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) رندر می‌کند، از متدهای رندر تصویر API مدرن استفاده کنید:
[ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/rendertographics/#rendertographics_5)

همچنین API مرتبط با چاپ از طریق [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) جایگزین مستقیم در API مدرن ندارد:

[IPresentation](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/print/#print_2)

## **سوالات متداول**

**چرا [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) حذف شد؟**

پشتیبانی از [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) در API عمومی منسوخ شده است تا کار با رندر و تصاویر یکپارچه شود، وابستگی به پلتفرم خاص حذف شود و به رویکرد Cross‑Platform با [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) منتقل شود. به‌جای رندر به [Graphics] از `GetImage` یا `GetImages` استفاده کنید.

**فایدهٔ عملی [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) نسبت به [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) چیست؟**

[IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) کار با تصاویر رستری و برداری را یکپارچه می‌کند، ذخیرهٔ به فرمت‌های مختلف را از طریق [ImageFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/imageformat/) ساده می‌سازد، وابستگی به `System.Drawing` را کاهش می‌دهد و کد را در محیط‌های مختلف قابل حمل‌تر می‌سازد.

**آیا API مدرن بر عملکرد تولید تصویرهای بندانگشتی تأثیر می‌گذارد؟**

تبدیل از `GetThumbnail` به `GetImage` عملکرد سناریوها را تخریبی نمی‌کند: روش‌های جدید همان قابلیت‌ها را برای تولید تصاویر با گزینه‌ها و اندازه‌ها فراهم می‌کنند و همچنان از گزینه‌های رندر پشتیبانی می‌کنند. سود یا کاهش خاصی بستگی به سناریو دارد، اما از نظر کارکرد جایگزین‌ها برابرند.