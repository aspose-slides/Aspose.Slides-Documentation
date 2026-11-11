---
title: نمایش اسلایدهای ارائه به‌صورت تصاویر SVG در .NET
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
description: صادرات اسلایدهای PowerPoint به‌صورت تصاویر SVG در .NET و کنترل قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها با Aspose.Slides.
---
## **نمای کلی**

SVG یک قالب تصویر مبتنی بر XML مقیاس‌پذیر است که برای انتشار وب، نمایش‌گرهای اسلاید، گردش‌کارهای دسترسی‌پذیری و پردازش پس‌زمینه خودکار مناسب می‌باشد. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما اجازه می‌دهد نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را کنترل کنید.

از [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) هنگامی استفاده کنید که SVG صادر شده باید فشرده، پیش‌بینی‌پذیر در مرورگرها یا آمادهٔ استفاده تعاملی باشد.

## **صادر کردن اسلاید به عنوان SVG**

یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به یک فایل SVG جداگانه صادر می‌کند.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

نام فایل از [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) به‌جای اندیس حلقه استفاده می‌کند. همچنین می‌توانید یک شکل فردی را با [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) صادر کنید وقتی نمایش‌گر اسلاید یا صفحهٔ وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) رندر SVG را کنترل می‌کند. برای قاب‌های متنی، [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) قاب متن را در ناحیهٔ رندر گنجانده و [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) تعیین می‌کند آیا چرخش قاب اعمال شود یا نه. هنگام نیاز به رندر متن بدون لیگچرها، [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) را روی `true` تنظیم کنید.

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

## **کنترل برش انتهای خط در سرهای پیکان**

در SVG 1.1 تنظیمی برای تعیین نقطهٔ توقف خط زیر سر پیکان وجود ندارد. به‌طور پیش‌فرض، Aspose.Slides طول خط صادر شده را کوتاه می‌کند تا خط نقاشی از طریق مارکر بیرون نیاید. برای کشیدن خط تمام‌طول تا نقطهٔ اولیهٔ انتهای خط، [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) را روی `true` تنظیم کنید. این تنظیم فقط بر خروجی SVG تأثیر دارد؛ موقعیت و طول خط در اسلاید همچنان ثابت می‌ماند.

مثال سرهای پیکان مثلثی و الماس‌دار را بر روی خطوطی به عرض ۲ و ۱۰ پوینت می‌کشد. همان اسلاید دو بار صادر می‌شود که فقط گزینهٔ برش تغییر می‌کند.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

مقایسه سر پیکان مثلثی در خط ۱۰‑پوینت را نشان می‌دهد. با فعال بودن برش، نوک تیز است. با غیرفعال بودن برش، خط نقاشی از طرف‌های مورب مارکر بیرون می‌آید و انتهایی صاف می‌گیرد.

![مثلث بزرگ شدهٔ ۱۰‑پوینت با نوک تیز وقتی برش فعال است و انتهای صاف وقتی برش غیرفعال است](line-end-cropping.png)

در سایر خطوط مثال، خط بیرون‌زن کمتر بر روی مثلث ۲‑پوینت قابل مشاهده است. الماس پر شده انتهای خط را در هر دو عرض پوشش می‌دهد.

## **کنترل متن و قلم‌ها**

هنگام صادر کردن اسلایدها به SVG، می‌توانید کنترل کنید که آیا متن به‌عنوان متن باقی بماند یا به گرافیک برداری تبدیل شود، و قلم‌های خارجی چگونه گنجانده یا ارجاع داده شوند. گزینه‌های زیر به شما کمک می‌کند تا تعادل بین سازگاری بصری، قابلیت انتخاب متن و وابستگی‌های قلم در SVG صادر شده را برقرار کنید.

### **برداری‌سازی تمام متن**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) را روی `true` تنظیم کنید تا تمام متن اسلاید به گرافیک برداری نوشته شود. این کار وابستگی‌های قلم را حذف می‌کند و نتایج بصری را بین مرورگرها ثابت‌تر می‌سازد، اما متن دیگر قابل انتخاب یا جستجو به‌عنوان متن SVG نخواهد بود.

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

### **انتخاب نحوهٔ پردازش قلم‌های خارجی**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) برای قلم‌های بارگذاری‌شده به‌صورت خارجی استفاده می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه، `Embed` را برای گنجاندن داده‌های قلم در SVG، یا `Vectorize` را برای رندر کردن فقط متن‌هایی که از قلم‌های خارجی استفاده می‌کنند به‌صورت گرافیک انتخاب کنید. قبل از گنجاندن قلم‌ها، مجوزهای مربوطه را بررسی کنید.

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

## **کاهش حجم تصویر جاسازی‌شده**

از [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) برای حذف نواحی برش‌خوردهٔ منبع، و [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را با بطور هزینهٔ وفاداری تصویر یا داده‌های تصویر حفظ‌شده کاهش می‌دهند.

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

## **کنترل وضوح رستر‌سازی متافایل**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) حد پایین وضوح را برای رستر‌سازی متافایل‌ها هنگام خروجی SVG تعیین می‌کند. از آن برای تعادل بین جزئیات و حجم فایل هنگامی که یک تصویر EMF یا WMF رستر می‌شود، استفاده کنید. این تنظیم یک DPI سراسری برای SVG تعریف نمی‌کند و همهٔ اشیاء را به تصویر رستر تبدیل نمی‌کند.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این فایل شامل یک تصویر EMF با خطوط مورب نزدیک به‌هم است. مثال زیر اولین اسلاید آن را در سه وضوح رستر‌سازی مختلف از طریق [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) صادر می‌کند. سایر تنظیمات خروجی همان‌گونه باقی می‌مانند تا نتایج قابل مقایسه باشند.

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

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ فراهم‌شده است؛ آن‌ها فرمول عمومی برای تبدیل DPI به ابعاد پیکسل نیستند.

| DPI رستر‌سازی متافایل | ابعاد PNG جاسازی‌شده | حجم فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستری جاسازی‌شده را در همان اندازهٔ نمایش بزرگ‌شده نشان می‌دهد. خطوط مورب در ۷۲ DPI پیکسل‌دار هستند و در وضوح‌های بالاتر لبه‌های صاف‌تری دارند، در حالی که حجم فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً تمام جزئیات را بهبود نمی‌بخشد یا هر تصویر صادرشده‌ای را تغییر نمی‌دهد.

![جزئیات بزرگ‌شدهٔ خط مورب در ۷۲، ۱۵۰ و ۳۰۰ DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) کنترل کاهش وضوح تصویر را بر عهده دارد و می‌تواند اثر تغییر وضوح رستر‌سازی متافایل را پنهان کند. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) کیفیت رمزگذاری JPEG را کنترل می‌کند، نه وضوح رستر‌سازی متافایل.

## **اختصاص شناسه‌های ثابت به اشکال و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) برای هر شکل SVG استفاده کنید. برای تنظیم مقادیر [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) روی عناصر `tspan` متن نیز، پیاده‌سازی [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) را در نظر بگیرید. هر دو کنترلر را با [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) اختصاص دهید.

کنترلر زیر از [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/) که برای طول عمر شکل ثابت است، و یک شمارندهٔ تکرارپذیر برای بخش‌های متنی آن استفاده می‌کند. این کار شناسه‌های تولیدشده را برای پردازش پس از انتشار ارائهٔ تغییر نکرده مناسب می‌سازد.

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

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/)، با فراخوانی [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) و مقدار [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) یک هندلر JavaScript به یک شکل صادرشده اضافه کنید. کنترلر را با [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) اختصاص دهید و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند، تعریف کنید.

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

صفحهٔ میزبانی می‌تواند تابع JavaScript ارجاع‌شده توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان‌پذیر می‌سازد تا نمایش‌گرهای اسلاید، بهبودهای دسترسی و سایر گردش‌کارهای تعاملی SVG بهره‌برداری شوند.

## **سوالات متداول**

**چه زمانی باید از [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) به‌جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) استفاده کنم؟**

زمانی که تمام متن باید مستقل از قلم‌ها باشد، از [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) استفاده کنید. هنگامی که فقط متن‌هایی که از قلم‌های خارجی استفاده می‌کنند باید به گرافیک تبدیل شوند، از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) استفاده کنید.

**بهترین راه برای کوچک کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش‌خوردهٔ تصویر، و انتخاب فایل‌های قلم پیوست‌شده وقتی محیط هدف می‌تواند آن‌ها را سرو کند، شروع کنید. نتیجه را آزمایش کنید زیرا وضوح کمتر تصویر، کیفیت کمتر JPEG و برداری‌سازی متن هرکدام تعادل متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توان پس از خروجی، عناصر SVG صادرشده را اصلاح کرد؟**

بله. شناسه‌ها را از طریق یک کنترلر قالب‌بندی اختصاص دهید، سپس عناصر SVG مطابق را در ابزار پردازش پس یا اسکریپت مرورگر خود انتخاب کنید.