---
title: رندر اسلایدهای ارائه به عنوان تصاویر SVG در .NET
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
- گزینه‌های صادرات SVG
- SVG تعاملی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اسلایدهای PowerPoint را به عنوان تصاویر SVG در .NET صادر کنید و با Aspose.Slides فونت‌ها، متن، تصاویر، شناسه‌ها و رویدادها را کنترل کنید."
---
## **مروری کلی**

SVG یک فرمت تصویر مبتنی بر XML مقیاس‌پذیر است که برای انتشار وب، نمایش اسلاید، جریان‌های دسترسی‌پذیری و پردازش پس‌پردازش خودکار بسیار مناسب است. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما اجازه می‌دهد نحوه نوشتن متن، فونت‌ها، تصاویر و عناصر SVG را کنترل کنید.

از [SVGOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/) وقتی که SVG صادر شده باید فشرده، پیش‌بینی‌پذیر در مرورگرها باشد یا برای استفاده تعاملی آماده باشد استفاده کنید.

## **صادر کردن یک اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به عنوان یک فایل SVG جداگانه صادر می‌کند.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

نام فایل از [ISlide.SlideNumber](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/slidenumber/) به‌جای اندیس حلقه استفاده می‌کند. همچنین می‌توانید یک شکل فردی را با [IShape.WriteAsSvg](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/writeassvg/) صادر کنید وقتی که یک نمایشگر اسلاید یا صفحه وب تنها به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/) رندرینگ SVG را کنترل می‌کند. برای فریم‌های متن، [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/useframesize/) فریم متن را در ناحیه رندرینگ گنجانده و [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/useframerotation/) تعیین می‌کند که آیا چرخش فریم اعمال شود یا خیر. وقتی متن باید بدون لیگچرهای فونت رندر شود، [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/disablefontligatures/) را روی `true` تنظیم کنید.

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

## **کنترل متن و فونت‌ها**

### **وکتوریزه کردن تمام متن**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/vectorizetext/) را روی `true` تنظیم کنید تا تمام متن اسلاید به صورت گرافیک‌های برداری نوشته شود. این کار وابستگی‌های فونت را حذف می‌کند و نتایج بصری را در مرورگرها سازگارتر می‌سازد، اما متن دیگر قابل انتخاب یا جستجو به عنوان متن SVG نیست.

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

### **انتخاب نحوه مدیریت فونت‌های خارجی**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/externalfontshandling/) از یک مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgexternalfontshandling/) برای فونت‌هایی که به صورت خارجی بارگذاری می‌شوند استفاده می‌کند. گزینه `AddLinksToFontFiles` را برای ارجاع به فایل‌های فونت جداگانه، `Embed` را برای گنجاندن داده‌های فونت در SVG، یا `Vectorize` را برای رندر کردن فقط متنی که از فونت‌های خارجی استفاده می‌کند به‌صورت گرافیک انتخاب کنید. پیش از جاسازی فونت‌ها، مجوزهای فونت را بررسی کنید.

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

## **کاهش اندازه تصویر جاسازی‌شده**

از [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/picturescompression/) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) برای حذف نواحی بریده‌شده منبع، و [SVGOptions.JpegQuality](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/jpegquality/) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات اندازه فایل را با هزینه کاهش دقت تصویر یا داده‌های حفظ‌شده تصویر کاهش می‌دهند.

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

## **اختصاص شناسه‌های ثابت به شکل‌ها و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape.Id](https://reference.aspose.com/slides/fa/net/aspose.slides.export/isvgshape/id/) برای هر شکل SVG استفاده کنید. برای تنظیم مقادیر [ISvgTSpan.Id](https://reference.aspose.com/slides/fa/net/aspose.slides.export/isvgtspan/id/) بر روی عناصر `tspan` متن نیز، [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) را پیاده‌سازی کنید. هر یک از این کنترلرها را با [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) انتساب دهید.

کنترلر زیر از [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/officeinteropshapeid/) استفاده می‌کند که در طول عمر شکل ثابت است، و یک شمارنده قابل تکرار برای span‌های متن آن دارد. این باعث می‌شود شناسه‌های تولید شده برای پردازش پس از ارائهٔ بدون تغییر مناسب باشند.

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

## **افزودن هندلرهای رویداد SVG**

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/isvgshapeformattingcontroller/)، با مقدار [SvgEvent](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgevent/) متد [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/fa/net/aspose.slides.export/isvgshape/seteventhandler/) را فراخوانی کنید تا یک هندلر رویداد JavaScript به شکل صادر شده اضافه شود. کنترلر را با [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) انتساب دهید و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند تعریف کنید.

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

صفحهٔ میزبان می‌تواند تابع JavaScript ارجاع‌شده توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد قابلیت‌های بیشتری برای نمایش اسلاید، بهبود دسترسی و دیگر جریان‌های کاری تعاملی SVG فراهم می‌کند.

## **پرسش‌های متداول**

**چه زمانی باید از SVGOptions.VectorizeText به جای SvgExternalFontsHandling.Vectorize استفاده کنم؟**

از SVGOptions.VectorizeText زمانی استفاده کنید که تمام متن باید مستقل از فونت‌ها باشد. از SvgExternalFontsHandling.Vectorize زمانی استفاده کنید که فقط متن‌هایی که از فونت‌های خارجی استفاده می‌کنند باید به گرافیک تبدیل شوند.

**بهترین راه برای کوچک کردن یک SVG چیست؟**

ابتدا با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی تصویر بریده‌شده و انتخاب فایل‌های فونت لینک‌شده (در صورتی که محیط هدف بتواند آن‌ها را سرو کند) شروع کنید. نتیجه را آزمایش کنید زیرا وضوح کمتر تصویر، کیفیت JPEG پایین‌تر و متن وکتوریزه هر کدام تعادلات متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توانم عناصر SVG صادر شده را پس از استخراج تغییر دهم؟**

بله. با استفاده از یک کنترلر فرمت‌بندی شناسه‌ها را اختصاص دهید، سپس عناصر SVG مربوطه را در ابزار پس‌پردازشی یا اسکریپت مرورگر خود انتخاب کنید.