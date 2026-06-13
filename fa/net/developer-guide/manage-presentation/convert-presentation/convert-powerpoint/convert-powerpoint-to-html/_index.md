---
title: تبدیل ارائه‌های PowerPoint به HTML در .NET
linktitle: PowerPoint به HTML
type: docs
weight: 30
url: /fa/net/convert-powerpoint-to-html/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به HTML
- ارائه به HTML
- اسلاید به HTML
- PPT به HTML
- PPTX به HTML
- ذخیره PowerPoint به عنوان HTML
- ذخیره ارائه به عنوان HTML
- ذخیره اسلاید به عنوان HTML
- ذخیره PPT به عنوان HTML
- ذخیره PPTX به عنوان HTML
- صادرات PPT به HTML
- صادرات PPTX به HTML
- .NET
- C#
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به HTML در .NET. از Aspose.Slides برای صادرات فایل‌های PPT و PPTX، اسلایدهای انتخابی، یادداشت‌ها، قلم‌ها، تصاویر، SVG و رسانه‌ها استفاده کنید."
---
## **بررسی کلی**

Aspose.Slides for .NET می‌تواند ارائه‌های PowerPoint را بدون Microsoft PowerPoint به HTML ذخیره کند. تبدیل پایه شامل یک بارگذاری [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) و یک فراخوانی [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) با [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) است. هنگام نیاز به کنترل چیدمان خروجی، قلم‌ها، تصاویر، یادداشت‌ها، نظرات، خروجی SVG یا منابع پیوست‌شده از [HtmlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmloptions/) استفاده کنید.

این راهنما بر سناریوهای عملی صادرات HTML تمرکز دارد:

- صادرات تمام ارائه یا اسلایدهای انتخابی.
- تولید HTML با چیدمان ثابت، واکنش‌گرا یا مبتنی بر SVG.
- گنجاندن یادداشت‌های گوینده و نظرات.
- کنترل کیفیت تصویر و داده‌های تصاویر برش‌خورده.
- جاسازی قلم‌ها یا ذخیره فایل‌های قلم به‌صورت جداگانه.
- انتخاب نحوه نوشتن و ارجاع به منابع خارجی و فایل‌های رسانه‌ای.

به‌طور پیش‌فرض، صادرات HTML یک سند HTML خودکفا تولید می‌کند که بیشتر منابع درون‌ساخته هستند. این برای به‌اشتراک‌گذاری یک فایل مناسب است، اما می‌تواند اندازه خروجی را افزایش دهد. برای انتشار وب، منابع خارجی، DPI پایین‌تر تصویر و فقط جاسازی قلم‌هایی که به‌طور قابل اعتماد در محیط هدف در دسترس نیستند را در نظر بگیرید.

## **تبدیل یک ارائه به HTML**

برای صادرات یک ارائه به HTML، آن را با [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بارگذاری کنید و با [SaveFormat.Html](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) ذخیره کنید.

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

این مثال یک فایل HTML می‌نویسد. شیء Presentation توسط عبارت `using` که در ادامه می‌آید، حذف می‌شود؛ این کار پس از صادرات، دستگیره‌های فایل و منابع رندرینگ را آزاد می‌کند.

## **استفاده از HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmloptions/) کلاس پیکربندی اصلی برای صادرات HTML است. تنظیمات رایج شامل:

- `SlidesLayoutOptions`: افزودن یادداشت‌ها، نظرات، برگه‌های توزیع یا سایر اطلاعات چیدمان.
- `HtmlFormatter`: تغییر ساختار سند HTML یا واگذاری قالب‌بندی به یک کنترل‌کننده.
- `SlideImageFormat`: تغییر نحوه نمایش اسلایدها، برای مثال به صورت SVG.
- `PicturesCompression`: کنترل DPI تصویر و اندازه خروجی.
- `DeletePicturesCroppedAreas`: نگهداری یا حذف داده‌های تصویر برش‌خورده.
- `SvgResponsiveLayout`: تنظیم محتوای SVG خروجی برای سازگار شدن با محفظه‌اش.
- `ShowHiddenSlides`: شامل کردن اسلایدهای مخفی هنگام نیاز.

بخش‌های زیر رایج‌ترین گزینه‌ها را به‌صورت جداگانه نشان می‌دهند تا بتوانید فقط موارد مورد نیاز جریان کاری خود را ترکیب کنید.

## **تبدیل اسلایدهای انتخابی به HTML**

بارگذاری [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) که شماره اسلایدها را می‌گیرد، از موقعیت‌های اسلاید ۱‑پایه استفاده می‌کند. حلقه زیر هر اسلاید را در یک فایل HTML جداگانه ذخیره می‌کند.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

از این الگو زمانی استفاده کنید که یک وب‌سایت یا برنامه به یک صفحه HTML برای هر اسلاید نیاز دارد. اگر هر اسلاید باید همان چیدمان را داشته باشد، یک نمونه [HtmlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmloptions/) ایجاد کنید و آن را به هر فراخوانی `Save` پاس دهید.

## **ایجاد HTML واکنش‌گرا**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/responsivehtmlcontroller/) خروجی HTML واکنش‌گرا را از طریق [HtmlFormatter](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmlformatter/) فراهم می‌کند. وقتی صفحه خروجی باید بهتر با عرض مرورگر سازگار شود، از آن استفاده کنید.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

برای چیدمان واکنش‌گرا مبتنی بر SVG، `SvgResponsiveLayout` را روی [HtmlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmloptions/) تنظیم کنید. این گزینه زمانی مفید است که محتوای اسلاید به‌صورت مارکاپ SVG مقیاس‌پذیر صادر می‌شود.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **گنجاندن یادداشت‌های گوینده و نظرات**

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notescommentslayoutingoptions/) از طریق `HtmlOptions.SlidesLayoutOptions` برای گنجاندن یادداشت‌های گوینده یا نظرات استفاده کنید. به‌صورت پیش‌فرض یادداشت‌ها و نظرات مخفی هستند مگر این‌که موقعیت آن‌ها را انتخاب کنید.

فرض کنید ارائه منبع دارای یادداشت‌های گوینده باشد:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

کد زیر محتوای اسلاید را به‌همراه یادداشت‌های گوینده زیر اسلاید صادر می‌کند.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

HTML صادرشده شامل ناحیه یادداشت‌ها می‌شود:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

برای صادر کردن نظرات، `CommentsPosition` را تنظیم کنید، برای مثال به `CommentsPositions.Right` یا `CommentsPositions.Bottom`. اگر فقط به نظرات نیاز دارید، `NotesPosition` را حذف کنید. اگر به هر دو نیاز دارید، هر دو ویژگی را تنظیم کنید.

## **کنترل کیفیت تصویر و نواحی برش‌خورده**

صادرات HTML می‌تواند تصاویر اسلاید را برای کاهش اندازه خروجی فشرده کند. وقتی به کیفیت تصویر بالاتر نیاز دارید، `PicturesCompression` را به مقداری از [PicturesCompression](https://reference.aspose.com/slides/fa/net/aspose.slides.export/picturescompression/) تنظیم کنید.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

به‌صورت پیش‌فرض، نواحی برش‌خورده تصاویر ممکن است از خروجی حذف شوند. داده‌های برش‌خورده را فقط زمانی نگه دارید که کاربران نیاز به بازیابی یا بررسی آن قسمت‌های مخفی تصویر داشته باشند. نگه‌دارنده آن می‌تواند اندازه HTML را افزایش دهد.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **افزودن CSS**

برای استایل ساده، یک رشته CSS را به [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmlformatter/createdocumentformatter/) پاس دهید. این کار سند HTML پیرامونی را تغییر می‌دهد در حالی که Aspose.Slides به رندر کردن محتوای اسلاید ادامه می‌دهد.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

برای افزودن هدر سفارشی سند، یک فایل CSS لینک‌شده یا مارکاپ سفارشی دور اسلایدها و اشکال، پیاده‌سازی [IHtmlFormattingController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ihtmlformattingcontroller/) و پاس دادن آن به [HtmlFormatter](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmlformatter/) با `CreateCustomFormatter` کافی است.

## **جاسازی قلم‌ها**

اگر محیط هدف ممکن است قلم‌های استفاده شده در ارائه نصب نشده باشند، با [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/embedallfontshtmlcontroller/) قلم‌ها را در HTML جاسازی کنید. جاسازی وفاداری بصری را بهبود می‌بخشد اما اندازه خروجی را افزایش می‌دهد.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

فقط زمانی قلم‌ها را حذف کنید که مطمئن هستید مرورگرها یا سیستم‌های هدف آن‌ها را در اختیار دارند. برای قلم‌های برند یا کمتر رایج، معمولاً جاسازی ایمن‌تر است.

## **پیوند کردن فایل‌های قلم به‌جای جاسازی آن‌ها**

برای کاهش اندازه فایل HTML، می‌توانید داده‌های قلم را در فایل‌های جداگانه WOFF بنویسید و قوانین `@font-face` را به HTML اضافه کنید. کمکی که در ادامه می‌آید، [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/embedallfontshtmlcontroller/) را گسترش می‌دهد و `WriteFont` را بازنویسی می‌کند.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

در این مثال، فایل‌های قلم در `html-output/fonts` ذخیره می‌شوند و HTML به آن‌ها با URLهایی مانند `fonts/BrandFont-normal-400.woff` ارجاع می‌دهد. اگر فایل HTML و قلم‌ها در مکان دیگری مستقر می‌شوند، `fontUrlPrefix` را طوری تنظیم کنید که مسیر URL مستقر شده را مطابقت دهد.

## **ذخیره منابع به‌صورت خارجی**

HTML خودکفا جابجایی آسانی دارد، اما منابع Base64 جاسازی‌شده می‌توانند فایل را بزرگ کنند. اگر برنامه شما به فایل‌های تصویری خارجی نیاز دارد، [ILinkEmbedController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ilinkembedcontroller/) را پیاده‌سازی کنید و به سازنده [HtmlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmloptions/htmloptions/) پاس دهید.

هنگام خارج‌سازی منابع، دو مسیر را به‌دقت انتخاب کنید:

- مسیر خروجی فایل سیستم، که برنامه شما فایل‌های تصویر، قلم، صدا یا ویدئوی تولیدی را در آن می‌نویسد.
- مسیر URL، که مرورگر از داخل سند HTML برای بارگذاری آن فایل‌ها استفاده می‌کند.

برای پیاده‌سازی کامل لینک‌دادن به تصویر، به مقاله [Export Presentations to HTML with Externally Linked Images](/slides/fa/net/exporting-presentations-to-html-with-externally-linked-images/) رجوع کنید.

## **صادرات فایل‌های رسانه‌ای**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/videoplayerhtmlcontroller/) فایل‌های ویدئو و صدا را صادر می‌کند و HTMLی می‌نویسد که می‌تواند آن‌ها را در مرورگر پخش کند. سازنده آن شامل:

- `path`: پوشه‌ای که فایل‌های رسانه‌ای تولیدشده در آن نوشته می‌شوند.
- `fileName`: نام فایل HTML در حال تولید.
- `baseUri`: پیشوند URI مطلقی که در لینک‌های HTML به فایل‌های رسانه‌ای استفاده می‌شود.

اگر فایل HTML `html-output/presentation.html` باشد و فایل‌های رسانه‌ای در `html-output/media` ذخیره شوند، `path` باید به پوشه رسانه‌ای روی دیسک اشاره کند، در حالی که `baseUri` باید همان مسیر را از دید مرورگر نشان دهد. برای پیش‌نمایش محلی می‌توانید URI `file:///` را از پوشه رسانه‌ای بسازید. برای برنامه مستقر، از URL مطلق پوشه رسانه‌ای منتشرشده استفاده کنید.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

از مسیرهای خروجی که برای هر کار صادراتی یکتا هستند استفاده کنید، به‌ویژه در برنامه‌های سروری. مسیرهای خروجی مشترک می‌توانند باعث بازنویسی فایل‌های تبدیل‌های مختلف شوند.

## **عملکرد و مدیریت منابع**

تبدیل HTML یک عملیات رندر است، بنابراین زمان پردازش و مصرف حافظه به تعداد اسلایدها، وضوح تصویر، قلم‌ها، اثرات، نمودارها و رسانه‌های جاسازی‌شده بستگی دارد. مقادیر بالاتر DPI در `PicturesCompression`، قلم‌های جاسازی‌شده، خروجی SVG و نگه‌داشتن نواحی برش‌خورده می‌تواند وفاداری را افزایش دهد ولی معمولاً اندازه خروجی را بزرگ می‌کند.

برای تبدیل دسته‌ایی:

- هر نمونه [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) را به‌سرعت دفع (Dispose) کنید.
- برای کارهای مختلف، پوشه‌های خروجی جداگانه استفاده کنید.
- قلم‌های عمومی را مگر آنکه وفاداری نیاز داشته باشد، جاسازی نکنید.
- DPI تصویر را وقتی HTML برای پیش‌نمایش یا تصویر بندانگشتی است، پایین‌تر ببندید.
- ارائه منبع، HTML تولیدشده و منابع خارجی را تا زمان نهایی شدن مسیرهای استقرار با هم نگه دارید.

## **سوالات متداول**

**آیا پیوندهای فرا hypertext در خروجی HTML حفظ می‌شوند؟**

بله. پیوندهای ارائه به HTML صادر می‌شوند و زمانی که URL هدف معتبر باشد، قابل کلیک هستند.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی به HTML تبدیل کنم؟**

بله، اما یک نمونه [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) را بین رشته‌ها به‌اشتراک نگذارید. فایل‌های مختلف را با نمونه‌های ارائه جداگانه، جریان‌های جداگانه و پوشه‌های خروجی جداگانه پردازش کنید. برای جزئیات به [راهنمای چندنخی](/slides/fa/net/multithreading/) مراجعه کنید.

**آیا شی Presentation thread‑safe است؟**

خیر. یک نمونه [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) باید در یک رشته بارگذاری، تغییر، ذخیره و دفع شود. برای کار همزمان، یک نمونه مستقل برای هر رشته یا فرآیند ایجاد کنید.

**چرا فایل HTML تولیدشده بزرگ است؟**

صادرات پیش‌فرض می‌تواند منابع را مستقیم در HTML جاسازی کند. قلم‌های جاسازی‌شده، تصاویر DPI بالا، رسانه‌ها، محتوای SVG و نگه‌داشتن نواحی برش‌خورده تصویر نیز اندازه را افزایش می‌دهند. برای کوچک‌تر کردن خروجی، از منابع خارجی استفاده کنید، قلم‌های عمومی را از جاسازی حذف کنید و `PicturesCompression` را پایین‌تر ببندید وقتی که اندازه کوچکتر مهم‌تر از حداکثر وفاداری است.

**چرا اندازه قلم PowerPoint مانند 24 pt در HTML به 17.999819 pt تبدیل می‌شود؟**

این به‌دلیل مدل‌های DPI متفاوت PowerPoint و HTML است. PowerPoint اندازه متن را بر پایه نقاط تایپوگرافی با 72 DPI ذخیره می‌کند، در حالی که چیدمان HTML بر پایه پیکسل‌های CSS با مدل 96 DPI است. زمانی که Aspose.Slides ارائه‌ای را به HTML صادر می‌کند، اندازه قلم بین این دو سیستم ترجمه می‌شود و تبدیل ممکن است اختلاف‌های گرد شدن جزئی ایجاد کند.

این مقادیر نشان‌دهنده تغییر واقعی در اندازه بصری قلم نیستند؛ فقط اثر جانبی ریاضی تبدیل معیارهای متنی بین PowerPoint و HTML است.

**چگونه باید baseUri را برای صادرات رسانه‌ها انتخاب کنم؟**

`baseUri` را بر پایهٔ دید مرورگر انتخاب کنید و به‌عنوان URI مطلق پاس دهید. برای پیش‌نمایش محلی می‌توانید از مسیر خروجی با `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri` استفاده کنید. برای استقرار، از URL مطلق پوشه رسانه‌ای منتشرشده استفاده کنید. مسیر فایل‌سیستم `path` و `baseUri` مرورگر نیازی به داشتن یک رشته یکسان ندارند، اما باید همان مکان منبع را توصیف کنند.

**آیا می‌توانم اسلایدهای مخفی را شامل شوم؟**

بله. وقتی اسلایدهای مخفی باید صادر شوند، `ShowHiddenSlides = true` را در [HtmlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmloptions/) تنظیم کنید.