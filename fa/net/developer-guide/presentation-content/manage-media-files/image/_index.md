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
description: "بهبود مدیریت تصاویر در PowerPoint و OpenDocument با Aspose.Slides برای .NET، بهینه‌سازی عملکرد و خودکارسازی جریان کاری شما."
---
## **معرفی**

تصاویر ارائه‌ها را جذاب‌تر و بصری‌تر می‌کنند. در Microsoft PowerPoint می‌توانید تصاویر را از فایل‌ها، اینترنت یا منابع دیگر به اسلایدها وارد کنید. به‌ طور مشابه، Aspose.Slides به شما امکان می‌دهد تصاویر را به اسلایدهای ارائه به طرق مختلف اضافه کنید.

{{% alert  title="Tip" color="primary" %}} 
Aspose مبدل‌های رایگان—[JPEG to PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG to PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را ارائه می‌دهد که به شما امکان می‌دهد به سرعت ارائه‌ها را از تصاویر ایجاد کنید. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
اگر می‌خواهید یک تصویر را به عنوان قاب تصویر اضافه کنید — به‌ویژه اگر قصد دارید آن را تغییر اندازه دهید، افکت اعمال کنید یا از گزینه‌های قالب‌بندی استاندارد دیگر استفاده کنید — به [Picture Frame](/slides/fa/net/picture-frame/) مراجعه کنید. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. صفحات زیر را ببینید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/net/conversion/image-to-jpg/)، [JPG to image](https://products.aspose.com/slides/fa/net/conversion/jpg-to-image/)، [JPG to PNG](https://products.aspose.com/slides/fa/net/conversion/jpg-to-png/)، [PNG to JPG](https://products.aspose.com/slides/fa/net/conversion/png-to-jpg/)، [PNG to SVG](https://products.aspose.com/slides/fa/net/conversion/png-to-svg/)، و [SVG to PNG](https://products.aspose.com/slides/fa/net/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides از تصاویر در فرمت‌های محبوب مانند JPEG، PNG، BMP، GIF و سایر فرمت‌ها پشتیبانی می‌کند. 

## **افزودن تصاویر ذخیره شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر ذخیره شده بر روی کامپیوتر خود را به یک اسلاید ارائه اضافه کنید. کد نمونه C# زیر نشان می‌دهد چگونه یک تصویر را به اسلاید اضافه کنید:

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

## **افزودن تصاویر از وب به اسلایدها**

اگر تصویر مورد نظر برای افزودن به اسلاید بر روی کامپیوتر شما ذخیره نشده باشد، می‌توانید آن را مستقیماً از وب اضافه کنید. 

کد نمونه C# زیر نشان می‌دهد چگونه یک تصویر را از وب به اسلاید اضافه کنید:

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

## **افزودن تصاویر به مستر اسلاید**

مستر اسلاید اطلاعاتی مانند تم و چینش را برای اسلایدهایی که از آن استفاده می‌کنند ذخیره و کنترل می‌کند. وقتی یک تصویر را به مستر اسلاید اضافه می‌کنید، تصویر در هر اسلایدی که بر پایه آن مستر باشد ظاهر می‌شود. 

کد نمونه C# زیر نشان می‌دهد چگونه یک تصویر را به مستر اسلاید اضافه کنید:

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

## **افزودن تصاویر به‌عنوان پس‌زمینه اسلاید**

می‌توانید یک تصویر را به‌عنوان پس‌زمینه برای یک یا چند اسلاید استفاده کنید. برای جزئیات، به *[Setting Images as Backgrounds for Slides](/slides/fa/net/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **افزودن SVG به ارائه‌ها**

محتوای SVG را می‌توان با استفاده از کلاس [SvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/svgimage/) به یک ارائه اضافه کرد. شیء [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/) به‌دست‌آمده سپس می‌تواند به مجموعه تصویر ارائه اضافه شود و برای ایجاد یک قاب تصویر استفاده شود.

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

فایل‌های SVG که از ابزارهای طراحی، ویرایشگرهای دیاگرام، سیستم‌های آیکون و خطوط لوله وب استخراج می‌شوند ممکن است به منابعی که خارج از سند SVG ذخیره شده‌اند ارجاع دهند. برای مثال، یک SVG می‌تواند شامل لینک تصویری مانند `images/photo.png`، مقدار CSS `url(...)` یا URL فونت باشد.

برای وارد کردن چنین محتوای SVG، یک پیاده‌سازی از [IExternalResourceResolver](https://reference.aspose.com/slides/fa/net/aspose.slides.import/iexternalresourceresolver/) ایجاد کنید و همراه با یک URI پایه به سازنده مناسب `SvgImage` پاس بدهید. URI پایه مکان سند SVG را شناسایی می‌کند و برای حل لینک‌های نسبی استفاده می‌شود.

اینترفیس [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/) دسترسی به اطلاعات مربوط به SVG وارد شده را فراهم می‌کند:

- `SvgContent` مقدار مارک‌آپ SVG را به‌صورت رشته برمی‌گرداند.
- `SvgData` محتوای SVG را به‌صورت آرایه بایت برمی‌گرداند.
- `BaseUri` URI پایه‌ای را که برای لینک‌های نسبی استفاده می‌شود برمی‌گرداند.
- `ExternalResourceResolver` حل‌کننده‌ای که به تصویر SVG اختصاص داده شده است را برمی‌گرداند.

### **پیاده‌سازی حل‌کننده منبع خارجی**

حل‌کننده دو متد دارد:

- [ResolveUri](https://reference.aspose.com/slides/fa/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) URI پایه و یک لینک منبع نسبی را ترکیب کرده و یک URI مطلق برمی‌گرداند. وقتی لینک قابل حل نیست یا اجازه ندارد `null` برگردانید.
- [GetEntity](https://reference.aspose.com/slides/fa/net/aspose.slides.import/iexternalresourceresolver/getentity/) یک جریان قابل خواندن برای یک URI منبع مطلق برمی‌گرداند. وقتی منبع موجود نیست، مسدود شده یا در دسترس نیست `null` برگردانید. در صورت نیاز می‌تواند یک جریان بازگشتی نیز ارائه دهد.

حل‌کننده زیر فقط منابع لینک‌شده را از یک پوشه محلی مجاز بارگذاری می‌کند. منابع شبکه و مسیرهای خارج از پوشه مجاز مسدود می‌شوند. برای لینک‌های تصویری حل‌نشده یک تصویر بازگشتی اختیاری برگردانده می‌شود.

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

        // این حل‌کننده به‌طور عمدی فقط فایل‌های محلی را مجاز می‌سازد.
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

        // فقط برای منابع تصویری از یک تصویر پیش‌فرض استفاده می‌شود. بازگرداندن یک جریان تصویر
        // برای فونت یا stylesheet گم‌شده معتبر نیست.
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

### **حل‌کردن منابع لینک‌شده هنگام وارد کردن SVG**

فرض کنید `assets/diagram.svg` حاوی مرجع نسبی زیر باشد:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

کد نمونه C# زیر URI فایل SVG را به‌عنوان URI پایه می‌سپارد و یک حل‌کننده سفارشی فراهم می‌کند. حل‌کننده لینک تصویر نسبی را به یک URI مطلق تبدیل کرده و یک جریان حاوی منبع لینک‌شده را باز می‌گرداند در حالی که Aspose.Slides SVG را پردازش می‌کند.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// URI پایه مکان سند SVG را نشان می‌دهد.
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

کلاس `SvgImage` همچنین overloadهایی ارائه می‌دهد که داده‌های SVG را به‌صورت آرایه بایت یا یک جریان می‌پذیرند، به همراه یک حل‌کننده منبع خارجی و یک URI پایه.

{{% alert title="Important" color="warning" %}}
حل‌کننده منبع، منابع خارجی را در حین پردازش و رندر SVG توسط Aspose.Slides در دسترس می‌گذارد. این حل‌کننده محتوای اصلی مارک‌آپ SVG را تغییر نمی‌دهد و به‌طور خودکار منابع حل‌شده را داخل آن تعبیه نمی‌کند.

وقتی یک `ISvgImage` به مجموعه تصویر ارائه اضافه می‌شود، فایل PPTX می‌تواند هم نمایه اصلی SVG و هم یک تصویر رستر fallback را شامل شود. یک منبع لینک‌شده می‌تواند در تصویر fallback تولید شده ظاهر شود در حالی که لینک نسبی مانند `images/photo.png` در SVG ذخیره‌شده بدون تغییر می‌ماند. بنابراین برنامه‌ای که نمایه SVG بومی را رندر می‌کند ممکن است محتواهای لینک‌شده را زمانی که منبع خارجی اصلی در دسترس نیست، نادیده بگیرد.
{{% /alert %}}

### **ایجاد یک تصویر SVG قابل حمل**

برای ایجاد یک تصویر SVG که به فایل‌های خارجی وابسته نباشد، قبل از ساخت `SvgImage`، SVG را به‌صورت خودمختار کنید. برای مثال، URLهای تصویر لینک‌شده را با URIهای `data:` که شامل داده تصویر هستند جایگزین کنید:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

پس از تعبیه تمام منابع مورد نیاز در محتوای SVG، `SvgImage` را بسازید، به مجموعه تصویر ارائه اضافه کنید و همان‌گونه که در مثال قبلی نشان داده شد، آن را در یک قاب تصویر وارد کنید.

### **مدیریت منابع گمشده یا مسدود شده**

زمانی که URI منبع نامعتبر، ممنوع یا غیرقابل حل باشد، از `ResolveUri` `null` برگردانید. زمانی که منبع قابل خواندن نیست، از `GetEntity` `null` برگردانید. Aspose.Slides در صورت امکان پردازش SVG را بدون آن منبع ادامه می‌دهد.

یک جریان fallback می‌تواند برای منبع گمشده بازگردانده شود، اما محتوای آن باید با نوع منبع درخواست‌شده سازگار باشد. برای مثال، فقط برای تصویر گمشده یک جریان تصویر برگردانید، نه برای فونت یا stylesheet.

{{% alert title="Security" color="warning" %}}
از حل مسیرهای فایل دلخواه یا URLهای شبکه بدون محدودیت در فایل‌های SVG غیرمطمئن خودداری کنید. طرح‌ها، پوشه‌ها و میزبان‌های مجاز را محدود کنید. برای منابع شبکه، همچنین زمان‌سنجی اتصال، محدودیت اندازه پاسخ و اعتبارسنجی محتوا را اعمال کنید.
{{% /alert %}}

## **تبدیل SVG به مجموعه‌ای از شکل‌ها**

Aspose.Slides می‌تواند یک SVG را به مجموعه‌ای از شکل‌ها تبدیل کند، مشابه عملکرد متناظر در PowerPoint:

![منوی پاپ‌آپ PowerPoint](img_01_01.png)

این قابلیت توسط overloadی از متد [AddGroupShape](https://reference.aspose.com/slides/fa/net/aspose.slides.ishapecollection/addgroupshape/methods/1) واسط [IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection) که یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage) را به‌عنوان اولین آرگومان می‌گیرد، فراهم می‌شود.

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

    // تبدیل تصویر SVG به یک گروه از شکل‌ها و مقیاس‌بندی آن به اندازه اسلاید
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // ذخیره ارائه در قالب PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **افزودن تصاویر به‌صورت EMF به اسلایدها**

Aspose.Slides for .NET به شما اجازه می‌دهد تصاویر EMF را از صفحات کاری Excel با Aspose.Cells تولید کنید و به اسلایدهای ارائه اضافه کنید.

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

    // کاربرگ را به یک جریان ذخیره کنید
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

## **جایگزینی تصاویر در مجموعه تصویر**

Aspose.Slides به شما امکان می‌دهد تصاویر ذخیره‌شده در مجموعه تصویر یک ارائه، از جمله تصاویری که توسط شکل‌های اسلاید استفاده می‌شوند، را جایگزین کنید. این بخش چند روش برای به‌روزرسانی تصاویر در مجموعه را توصیف می‌کند. می‌توانید یک تصویر را با استفاده از داده خام بایت، یک نمونه [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) یا تصویر دیگری که قبلاً در مجموعه وجود دارد، جایگزین کنید.

مراحل زیر را دنبال کنید:

1. فایل ارائه حاوی تصاویر را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بارگذاری کنید.
2. تصویر جدیدی را از یک فایل به یک آرایه بایت بارگذاری کنید.
3. تصویر هدف را با استفاده از آرایه بایت، با تصویر جدید جایگزین کنید.
4. در روش دوم، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.
5. در روش سوم، تصویر هدف را با تصویری که قبلاً در مجموعه تصویر ارائه وجود دارد، جایگزین کنید.
6. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation را که نشان‌دهنده یک فایل ارائه است، ایجاد کنید.
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

// ارائه را در یک فایل ذخیره کنید.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
با مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) از Aspose می‌توانید به‌راحتی متن را انیمیشن کنید و GIFهایی از متن بسازید. 
{{% /alert %}}

## **پرسش‌های متداول**

**آیا وضوح تصویر اصلی پس از درج حفظ می‌شود؟**  
بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی بستگی به نحوهٔ مقیاس‌گذاری [picture](/slides/fa/net/picture-frame/) در اسلاید و هر فشرده‌سازی اعمال‌شده هنگام ذخیره دارد.

**بهترین روش برای جایگزینی یک لوگوی یکسان در ده‌ها اسلاید به‌صورت همزمان چیست؟**  
لوگو را بر روی اسلاید مستر یا یک چیدمان قرار دهید و آن را در مجموعه تصویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از آن منبع استفاده می‌کنند، انتشار می‌یابد.

**آیا می‌توان یک SVG وارد‌شده را به شکل‌های قابل ویرایش تبدیل کرد؟**  
بله. می‌توانید یک SVG را به یک گروه از شکل‌ها تبدیل کنید؛ پس از آن بخش‌های فردی با ویژگی‌های استاندارد شکل قابل ویرایش می‌شوند.

**چگونه می‌توان یک تصویر را به‌عنوان پس‌زمینه برای چند اسلاید به‌صورت همزمان تنظیم کرد؟**  
[تصویر را به‌عنوان پس‌زمینه](/slides/fa/net/presentation-background/) بر روی مستر اسلاید یا چیدمان مربوطه اختصاص دهید—هر اسلایدی که از آن مستر/چیدمان استفاده می‌کند، پس‌زمینه را به ارث می‌برد.

**چگونه می‌توان از بزرگ شدن بیش از حد یک ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کرد؟**  
به‌جای تکثیر، از یک منبع تصویر واحد استفاده کنید، وضوح‌های معقول انتخاب کنید، هنگام ذخیره فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر نگه دارید.