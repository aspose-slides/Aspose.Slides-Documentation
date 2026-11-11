---
title: پردازش اسلایدهای ارائه به صورت تصاویر SVG در .NET
linktitle: اسلاید به SVG
type: docs
weight: 50
url: /fa/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint به SVG
- ارائه به SVG
- اسلاید به SVG
- PPT به SVG
- PPTX به SVG
- گزینه‌های خروجی SVG
- SVG تعاملی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اسلایدهای PowerPoint را به عنوان تصاویر SVG در .NET صادر کنید و با Aspose.Slides قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را کنترل کنید."
---
## **مرور کلی**

SVG یک قالب تصویری مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش اسلاید، جریان‌های کاری دسترس‌پذیری و پردازش پس‌زمینه خودکار مناسب است. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) استفاده کنید زمانی که SVG صادر شده باید فشرده، در مرورگرها پیش‌بینی‌پذیر یا برای استفاده تعاملی آماده باشد.

## **صادر کردن یک اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به عنوان یک فایل SVG جداگانه صادر می‌کند.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

نام فایل از [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) به جای شاخص حلقه استفاده می‌کند. همچنین می‌توانید یک شکل فردی را با [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) صادر کنید زمانی که یک نمایشگر اسلاید یا صفحه وب تنها به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) فریم متن را در منطقه رندر گنجانده و [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) تعیین می‌کند که آیا چرخش فریم اعمال شود یا نه. وقتی متن باید بدون لیگاتور رندر شود، [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) را به `true` تنظیم کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **کنترل متن و قلم‌ها**

هنگام صادر کردن اسلایدها به SVG، می‌توانید کنترل کنید که آیا متن به عنوان متن باقی بماند یا به گرافیک برداری تبدیل شود و فونت‌های خارجی چگونه گنجانده یا ارجاع داده شوند. گزینه‌های زیر به شما کمک می‌کنند بین سازگاری بصری، قابلیت انتخاب متن و وابستگی‌های قلم در SVG صادر شده تعادل برقرار کنید.

### **بردارسازی تمام متن**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) را به `true` تنظیم کنید تا تمام متن اسلاید به صورت گرافیک برداری نوشته شود. این وابستگی‌های قلم را حذف کرده و نتیجه بصری را در مرورگرها یکنواخت‌تر می‌کند، اما متن دیگر قابل انتخاب یا جستجو به‌عنوان متن SVG نیست.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **انتخاب نحوهٔ پردازش فونت‌های خارجی**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) برای فونت‌هایی که به‌صورت خارجی بارگذاری می‌شوند، استفاده می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه، `Embed` را برای گنجاندن داده‌های قلم در SVG، یا `Vectorize` را برای رندر کردن متن‌های استفاده‌کننده از فونت‌های خارجی به‌عنوان گرافیک انتخاب کنید. قبل از گنجاندن قلم‌ها، مجوزهای استفاده را بررسی کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **کاهش اندازهٔ تصویر جاسازی‌شده**

از [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) برای حذف نواحی برش‌خوردهٔ منبع، و [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات اندازهٔ فایل را با هزینه‌ای برای دقت تصویر یا حفظ داده‌های تصویر کاهش می‌دهند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **کنترل وضوح رستری‌سازی متافایل**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) حد پایین‌تر وضوح برای رستری‌سازی متافایل‌ها در هنگام خروجی SVG را تنظیم می‌کند. از آن برای تعادل بین جزئیات و حجم فایل هنگام رستری‌سازی یک تصویر EMF یا WMF استفاده کنید. این مقدار DPI سراسری برای SVG را تعیین نمی‌کند و تمام اشیاء اسلاید را به تصویر رستری تبدیل نمی‌کند.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این ارائه شامل یک تصویر EMF با خطوط قطری نزدیک به هم است. مثال زیر اولین اسلاید آن را در سه وضوح رستری‌سازی مختلف از طریق [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) صادر می‌کند. سایر تنظیمات خروجی یکسان باقی می‌مانند تا نتایج قابل مقایسه باشند.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ داده‌شده است؛ این یک فرمول کلی برای تبدیل DPI به ابعاد پیکسل نیست.

| وضوح رستری‌سازی متافایل (DPI) | ابعاد PNG جاسازی‌شده | حجم فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستری جاسازی‌شده را در ابعاد نمایش بزرگ‌شدهٔ یکسان نشان می‌دهد. خطوط قطری در 72 DPI پیکسل‌دار قابل مشاهده است و در وضوح‌های بالاتر لبه‌های نرم‌تری دارد، در حالی که حجم فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً تمام جزئیات را بهتر نمی‌کند یا هر تصویر صادرشده‌ای را تغییر نمی‌دهد.

![جزئیات بزرگ‌نمایی شدهٔ خط قطری در 72، 150 و 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) کنترل کاهش وضوح تصویر را بر عهده دارد و می‌تواند اثر تغییر وضوح رستری‌سازی متافایل را مخفی کند. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) کیفیت رمزگذاری JPEG را کنترل می‌کند، نه وضوح رستری‌سازی متافایل.

## **اختصاص شناسه‌های ثابت به اشکال و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) برای هر شکل SVG استفاده کنید. برای تنظیم مقادیر [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) بر روی عناصر `tspan` متن نیز، [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) را پیاده‌سازی کنید. هر یک از این کنترل‌کننده‌ها را با [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) اختصاص دهید.

کنترل‌کنندهٔ زیر از [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/) استفاده می‌کند که برای طول عمر شکل ثابت است و شمارنده‌ای قابل تکرار برای بازه‌های متنی آن دارد. این شناسه‌های تولیدشده برای پردازش پس از خروجی یک ارائه بدون تغییر مناسب هستند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **افزودن مدیریت‌گرهای رویداد SVG**

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/)، با فراخوانی [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) و مقدار [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) یک مدیریت‌گر جاوااسکریپت به شکل صادرشده اضافه کنید. کنترل‌کننده را با [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) اختصاص دهید و تابع جاوااسکریپت را در صفحه یا سند SVG که نتیجه را می‌زبانی می‌کند، تعریف کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

صفحهٔ میزبان می‌تواند تابع جاوااسکریپت ارجاع‌شده توسط مدیریت‌گر را تعریف کند. اختصاص شناسه‌ها و مدیریت‌گرهای رویداد امکان استفاده از نمایشگرهای اسلاید، بهبودهای دسترس‌پذیری و سایر جریان‌های کاری تعاملی SVG را فراهم می‌کند.

## **سوالات متداول**

**چه زمانی باید از [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) به‌جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) زمانی استفاده کنید که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) وقتی که تنها متنی که از قلم‌های خارجی استفاده می‌کند باید به گرافیک تبدیل شود، استفاده کنید.

**بهترین راه برای کوچک‌کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش‌خوردهٔ تصویر و انتخاب فایل‌های قلم لینک‌دار زمانی که محیط هدف می‌تواند آن‌ها را سرو کند، شروع کنید. نتیجه را تست کنید زیرا کاهش وضوح تصویر، کاهش کیفیت JPEG و بردارسازی متن هر کدام تعادل متفاوتی بین کیفیت و حجم ایجاد می‌کنند.

**آیا می‌توانم پس از خروجی SVG، عناصر آن را اصلاح کنم؟**

بله. با استفاده از یک کنترل‌کنندهٔ قالب‌بندی شناسه‌ها را اختصاص دهید، سپس عناصر SVG مطابق آن را در ابزار پردازش پس از خروجی یا اسکریپت مرورگر خود انتخاب کنید.