---
title: بهینه‌سازی مدیریت تصاویر در ارائه‌ها با .NET
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/net/image/
keywords:
- افزودن تصویر
- افزودن عکس
- افزودن بیت‌مپ
- جایگزینی تصویر
- جایگزینی عکس
- از وب
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- منابع خارجی SVG
- حل‌کننده SVG
- تصاویر SVG لینک‌شده
- فونت‌های SVG
- افزودن EMF
- افزودن WMF
- افزودن TIFF
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت تصاویر را در PowerPoint و OpenDocument با Aspose.Slides برای .NET ساده‌سازی کنید، عملکرد را بهینه‌سازی کرده و جریان کار خود را خودکار کنید."
---
## **معرفی**

تصاویر، ارائه‌ها را جذاب‌تر و بصری‌تر می‌کنند. در مایکروسافت پاورپوینت، می‌توانید تصاویر را از فایل‌ها، اینترنت یا منابع دیگر روی اسلایدها وارد کنید. به همین ترتیب، Aspose.Slides به شما اجازه می‌دهد تصاویر را به اسلایدهای ارائه به چندین روش اضافه کنید.

{{% alert  title="Tip" color="info" %}} 

Aspose مبدل‌های رایگانی ارائه می‌دهد—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به شما امکان می‌دهد به سرعت ارائه‌ها را از تصاویر ایجاد کنید. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

اگر می‌خواهید یک تصویر را به‌عنوان قاب تصویر اضافه کنید—به‌ویژه اگر قصد تغییر اندازه، اعمال افکت‌ها یا استفاده از سایر گزینه‌های قالب‌بندی استاندارد را دارید—به [قاب تصویر](/slides/fa/net/picture-frame/) مراجعه کنید. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

می‌توانید تصاویر را از یک قالب به قالب دیگر تبدیل کنید. صفحات زیر را ببینید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/net/conversion/image-to-jpg/)، [JPG به تصویر](https://products.aspose.com/slides/fa/net/conversion/jpg-to-image/)، [JPG به PNG](https://products.aspose.com/slides/fa/net/conversion/jpg-to-png/)، [PNG به JPG](https://products.aspose.com/slides/fa/net/conversion/png-to-jpg/)، [PNG به SVG](https://products.aspose.com/slides/fa/net/conversion/png-to-svg/)، و [SVG به PNG](https://products.aspose.com/slides/fa/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides تصاویر را در قالب‌های محبوبی مانند JPEG، PNG، BMP، GIF و سایرین پشتیبانی می‌کند. 

## **اضافه کردن تصاویر ذخیره‌شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر ذخیره‌شده بر روی کامپیوتر خود را به یک اسلاید ارائه اضافه کنید. نمونه کد C# زیر نشان می‌دهد چگونه یک تصویر به اسلاید اضافه شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **اضافه کردن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید در کامپیوتر شما ذخیره نشده باشد، می‌توانید آن را مستقیماً از وب اضافه کنید. 

نمونه کد C# زیر نشان می‌دهد چگونه یک تصویر از وب به اسلاید اضافه شود:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **اضافه کردن تصاویر به اسلاید مسترها**

یک اسلاید مستر اطلاعاتی چون تم و چیدمان را برای اسلایدهای استفاده‌کننده از آن ذخیره و کنترل می‌کند. وقتی یک تصویر به اسلاید مستر اضافه می‌شود، تصویر در هر اسلایدی که بر پایه آن مستر ساخته شده ظاهر می‌گردد. 

نمونه کد C# زیر نشان می‌دهد چگونه یک تصویر به اسلاید مستر اضافه شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **اضافه کردن تصاویر به‌عنوان پس‌زمینه اسلایدها**

می‌توانید از یک تصویر به‌عنوان پس‌زمینه برای یک یا چند اسلاید استفاده کنید. برای جزئیات، به *[تنظیم تصاویر به‌عنوان پس‌زمینه برای اسلایدها](/slides/fa/net/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **اضافه کردن SVG به ارائه‌ها**

محتوای SVG می‌تواند با استفاده از کلاس [SvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/svgimage/) به یک ارائه اضافه شود. سپس شیء [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/) حاصل می‌تواند به مجموعه تصویر ارائه اضافه شده و برای ایجاد یک قاب تصویر استفاده شود.

نمونه کد C# زیر یک رشته SVG خودکفای خود را وارد می‌کند. تمام تصاویر، سبک‌ها و منابع دیگر مورد استفاده توسط این SVG مستقیماً در محتوای SVG جاسازی شده‌اند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **وارد کردن محتوای SVG با منابع خارجی**

فایل‌های SVG که از ابزارهای طراحی، ویرایشگرهای نمودار، سیستم‌های آیکون و خطوط لوله وب استخراج می‌شوند ممکن است به منابعی که خارج از سند SVG ذخیره هستند، ارجاع دهند. برای مثال، یک SVG می‌تواند شامل لینک تصویری مانند `images/photo.png`، مقدار CSS `url(...)` یا URL یک فونت باشد.

برای وارد کردن چنین محتوای SVG، یک پیاده‌سازی از [IExternalResourceResolver](https://reference.aspose.com/slides/fa/net/aspose.slides.import/iexternalresourceresolver/) ایجاد کنید و همراه با یک URI پایه، به سازنده مناسب `SvgImage` پاس دهید. URI پایه مکان سند SVG را شناسایی می‌کند و برای حل لینک‌های نسبی استفاده می‌شود.

رابط [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/) دسترسی به اطلاعات مربوط به SVG وارد‌شده را فراهم می‌کند:

- `SvgContent` محتوای مارک‌آپ SVG را به‌صورت رشته باز می‌گرداند.
- `SvgData` محتوای SVG را به‌صورت آرایه بایت باز می‌گرداند.
- `BaseUri` URI پایه‌ای که برای لینک‌های نسبی استفاده می‌شود را باز می‌گرداند.
- `ExternalResourceResolver` حل‌کننده‌ای که به تصویر SVG اختصاص داده شده را باز می‌گرداند.

### **پیاده‌سازی یک حل‌کننده منابع خارجی**

حل‌کننده دو روش دارد:

- [ResolveUri](https://reference.aspose.com/slides/fa/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) URI پایه و یک لینک منبع نسبی را ترکیب می‌کند و یک URI مطلق باز می‌گرداند. زمانی که لینک قابل حل نباشد یا مجاز نباشد، `null` بازگردانید.
- [GetEntity](https://reference.aspose.com/slides/fa/net/aspose.slides.import/iexternalresourceresolver/getentity/) یک استریم قابل خواندن برای یک URI منبع مطلق باز می‌گرداند. زمانی که منبع گمشده، مسدود یا در دسترس نباشد، `null` بازگردانید. در صورت لزوم می‌توان یک استریم جایگزین نیز برگرداند.

حل‌کننده زیر تنها منابع لینک‌شده را از یک پوشه محلی مجاز بارگذاری می‌کند. منابع شبکه‌ای و مسیرهای خارج از پوشه مجاز مسدود می‌شوند. یک تصویر جایگزین اختیاری برای لینک‌های تصویری حل‌نشده برگردانده می‌شود.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // این حل‌کننده به‌طور عمدی فقط فایل‌های محلی را مجاز می‌داند.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // از یک منبع جایگزین فقط برای منابع تصویری استفاده کنید. بازگرداندن یک جریان تصویر
        // برای یک قلم یا استایل‌شییت گمشده معتبر نخواهد بود.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **حل لینک‌های مرتبط هنگام وارد کردن SVG**

فرض کنید `assets/diagram.svg` شامل یک ارجاع نسبی زیر باشد:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

نمونه کد C# زیر URI فایل SVG را به‌عنوان URI پایه می‌گیرد و یک حل‌کنندهٔ سفارشی ارائه می‌دهد. حل‌کننده لینک تصویر نسبی را به یک URI مطلق تبدیل می‌کند و استریمی که شامل منبع لینک‌شده است باز می‌گرداند؛ در همین حین Aspose.Slides پردازش SVG را انجام می‌دهد.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// URI پایه موقعیت سند SVG را نشان می‌دهد.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

کلاس `SvgImage` همچنین بارگذاری‌های دیگری دارد که داده‌های SVG را به‌صورت آرایه بایت یا استریم می‌پذیرند، به‌همراه یک حل‌کنندهٔ منابع خارجی و یک URI پایه.

{{% alert title="Important" color="warning" %}}

حل‌کنندهٔ منابع خارجی، منابع خارجی را هنگام پردازش و رندر SVG توسط Aspose.Slides در دسترس می‌گذارد. این حل‌کننده مارک‌آپ اصلی SVG را تغییر داده یا به‌صورت خودکار منابع حل‌شده را درون آن جاسازی نمی‌کند.

زمانی که یک `ISvgImage` به مجموعه تصویر ارائه اضافه می‌شود، فایل PPTX می‌تواند هم نمای اصلی SVG و هم یک تصویر رستر جایگزین را شامل شود. یک منبع لینک‌شده می‌تواند در تصویر جایگزین تولید‑شده ظاهر شود در حالی که لینک نسبی مانند `images/photo.png` همان‌طور که در SVG ذخیره شده باقی می‌ماند. بنابراین برنامه‌ای که نمای SVG بومی را رندر می‌کند، ممکن است محتوای لینک‌شده را وقتی منبع خارجی اصلی در دسترس نیست، نادیده بگیرد.

{{% /alert %}}

### **ایجاد یک تصویر SVG قابل‌حمل**

برای ایجاد یک تصویر SVG که به فایل‌های خارجی وابسته نیست، قبل از ساختن `SvgImage`، SVG را خودکفا کنید. برای مثال، URL‌های تصاویر لینک‌شده را با URIهای `data:` که شامل دادهٔ تصویر هستند، جایگزین کنید:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

پس از آنکه تمام منابع مورد نیاز در محتوای SVG جاسازی شدند، `SvgImage` را ایجاد کنید، به مجموعه تصویر ارائه اضافه کنید و همان‌طور که در مثال قبلی نشان داده شد، آن را در یک قاب تصویر درج کنید.

### **مدیریت منابع گمشده یا مسدود شده**

در `ResolveUri` زمانی که URI منبع نامعتبر، ممنوع یا غیرقابل حل باشد، `null` بازگردانید. در `GetEntity` زمانی که منبع قابل خواندن نیست، `null` بازگردانید. Aspose.Slides تا جایی که ممکن باشد، بدون آن منبع به پردازش SVG ادامه می‌دهد.

یک استریم جایگزین می‌تواند برای منبع گمشده برگردانده شود، ولی محتویات آن باید با نوع منبع درخواست‌شده سازگار باشد. برای مثال، فقط برای یک تصویر گمشده یک استریم تصویری برگردانید، نه برای یک فونت یا stylesheet.

{{% alert title="Security" color="warning" %}}

از حل‌کردن مسیری‌های دلخواه فایل یا URLهای شبکه‌ای نامحدود از فایل‌های SVG غیرقابل اعتماد خودداری کنید. طرح‌های مجاز، پوشه‌ها و میزبان‌ها را محدود کنید. برای منابع شبکه‌ای، همچنین زمان‌سنجی اتصال، محدودیت اندازه پاسخ و اعتبارسنجی محتوا را اعمال کنید.

{{% /alert %}}

## **تبدیل SVG به مجموعه‌ای از اشکال**
Aspose.Slides می‌تواند یک SVG را به مجموعه‌ای از اشکال تبدیل کند، مشابه عملکرد معادل در PowerPoint:

![منوی پاپ‑آپ PowerPoint](img_01_01.png)

این قابلیت توسط یک بارگذاری از متد [AddGroupShape](https://reference.aspose.com/slides/fa/net/aspose.slides.ishapecollection/addgroupshape/methods/1) واسط [IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection) که یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage) را به عنوان اولین آرگومان می‌گیرد، فراهم می‌شود.

نمونه کد C# زیر نشان می‌دهد چگونه از این متد برای تبدیل یک فایل SVG به مجموعه‌ای از اشکال استفاده شود:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// نام فایل SVG منبع
string svgFileName = "sample.svg";

// نام فایل خروجی ارائه
string outPptxPath = "presentation.pptx";

// ایجاد یک ارائه جدید
using (IPresentation presentation = new Presentation())
{
    // خواندن محتوای فایل SVG
    string svgContent = File.ReadAllText(svgFileName);

    // ایجاد یک شیء SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // دریافت اندازه اسلاید
    SizeF slideSize = presentation.SlideSize.Size;

    // تبدیل تصویر SVG به گروهی از اشکال و مقیاس‌بندی آن به اندازه اسلاید
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // ذخیره ارائه در فرمت PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **اضافه کردن تصاویر به‌عنوان EMF به اسلایدها**
Aspose.Slides برای .NET به شما اجازه می‌دهد تا تصاویر EMF را از کاربرگ‌های Excel با Aspose.Cells تولید کرده و به اسلایدهای ارائه اضافه کنید.

نمونه کد C# زیر این کار را نشان می‌دهد:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // کتاب کار را به یک جریان ذخیره کنید
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **جایگزینی تصاویر در مجموعهٔ تصویر**

Aspose.Slides به شما امکان می‌دهد تصاویر ذخیره‌شده در مجموعهٔ تصویر یک ارائه، از جمله تصاویری که توسط اشکال اسلاید استفاده می‌شوند، را جایگزین کنید. این بخش چندین روش برای به‌روزرسانی تصاویر در مجموعه را توصیف می‌کند. می‌توانید یک تصویر را با دادهٔ بایت خام، یک نمونهٔ [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) یا تصویر دیگری که قبلاً در مجموعه وجود دارد، جایگزین کنید.

مراحل زیر را دنبال کنید:

1. با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) فایل ارائه‌ای که شامل تصاویر است را بارگذاری کنید.
1. یک تصویر جدید را از یک فایل به‌صورت آرایه بایت بارگذاری کنید.
1. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.
1. در روش دوم، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.
1. در روش سوم، تصویر هدف را با یک تصویر که قبلاً در مجموعهٔ تصویر ارائه وجود دارد، جایگزین کنید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
using Presentation presentation = new Presentation("sample.pptx");

// روش اول.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// روش دوم.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// روش سوم.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// ذخیرهٔ ارائه در یک فایل.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

با مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) از Aspose می‌توانید به‌سادگی متن را متحرک کنید و GIFهایی از متن بسازید. 

{{% /alert %}}

## **سؤالات متداول**

**آیا وضوح تصویر اصلی پس از درج حفظ می‌شود؟**

بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی به نحوهٔ مقیاس‌گذاری [قاب](/slides/fa/net/picture-frame/) در اسلاید و هر فشرده‌سازی انجام‌شده هنگام ذخیره وابسته است.

**بهترین راه برای جایگزینی یک لوگو در ده‌ها اسلاید به‌صورت همزمان چیست؟**

لوگو را بر روی اسلاید مستر یا یک لایه قرار دهید و آن را در مجموعهٔ تصویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از آن منبع استفاده می‌کنند، منتشر خواهد شد.

**آیا یک SVG وارد‌شده می‌تواند به اشکال قابل ویرایش تبدیل شود؟**

بله. می‌توانید یک SVG را به یک گروه از اشکال تبدیل کنید؛ پس از آن بخش‌های منفرد با ویژگی‌های استاندارد اشکال قابل ویرایش می‌شوند.

**چگونه می‌توان یک تصویر را به‌عنوان پس‌زمینه برای چند اسلاید به‌صورت همزمان تنظیم کرد؟**

[تصویر را به‌عنوان پس‌زمینه](/slides/fa/net/presentation-background/) بر روی اسلاید مستر یا لایه مربوطه تعیین کنید—هر اسلایدی که از آن مستر/لایه استفاده کند، پس‌زمینه را به‌ارث می‌برد.

**چگونه از بزرگ‌شدن بیش از حد یک ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کنم؟**

به‌جای تکرار، یک منبع تصویری واحد را بازاستفاده کنید، وضوح‌های معقول انتخاب کنید، هنگام ذخیره فشرده‌سازی اعمال کنید و گرافیک‌های مکرر را در مستر نگه دارید.