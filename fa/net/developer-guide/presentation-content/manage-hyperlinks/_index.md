---
title: مدیریت لینک‌های ارائه در .NET
linktitle: مدیریت لینک‌ها
type: docs
weight: 20
url: /fa/net/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن هایپرلینک
- ایجاد هایپرلینک
- قالب‌بندی هایپرلینک
- حذف هایپرلینک
- به‌روزرسانی هایپرلینک
- هایپرلینک متن
- هایپرلینک اسلاید
- هایپرلینک شکل
- هایپرلینک تصویر
- هایپرلینک ویدئو
- هایپرلینک قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف هایپرلینک‌ها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET، با استفاده از مثال‌های C#."
---
## **معرفی**

یک لینک‌درشت (hyperlink) محتویات ارائه را به یک وب‌سایت یا مکان داخل خود ارائه متصل می‌کند. در PowerPoint، لینک‌ها معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از متن، شکل یا فریم رسانه‌ای.
* حرکت به اسلاید دیگری، برای مثال، از فهرست مطالب.

Aspose.Slides for .NET به شما امکان می‌دهد این لینک‌ها را اضافه کنید، ظاهر و صداهای آنها را کنترل کنید، ویژگی‌هایشان را به‌روزرسانی کنید و آن‌ها را حذف کنید. مثال‌های زیر نشان می‌دهند چگونه با لینک‌های فرادست در عناصر منفرد کار کنید و چگونه به لینک‌ها در سطح ارائه، اسلاید یا فریم‑متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}
می‌توانید ارائه‌ها را با [ویرایشگر رایگان آنلاین Aspose PowerPoint](https://products.aspose.app/slides/fa/editor) نیز ویرایش کنید.
{{% /alert %}} 

## **افزودن لینک‌های URL**

می‌توانید یک URL وب‌سایت را به متن، یک شکل یا فریم رسانه‌ای اختصاص دهید. عنصری که به آن لینک را اختصاص می‌دهید، محدوده قابل کلیک را تعیین می‌کند: بخش متنی لینک متن انتخاب شده را پیوند می‌دهد، در حالی که شکل یا فریم شی اسلاید را پیوند می‌کند.

### **افزودن لینک‌های URL به متن**

برای پیوند دادن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/fa/net/aspose.slides/hyperlink/) را به ویژگی [HyperlinkClick](https://reference.aspose.com/slides/fa/net/aspose.slides/portionformat/hyperlinkclick/) بخش متن اختصاص دهید، همان‌طور که در زیر نشان داده شده است. فقط همان بخش متن قابل کلیک می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **افزودن لینک‌های URL به اشکال و فریم‌های رسانه‌ای**

برای قابل کلیک کردن کردن یک شکل یا فریم، ویژگی [HyperlinkClick](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/hyperlinkclick/) آن را تنظیم کنید. لینک به خود شی تعلق دارد نه به بخش متنی داخل آن.

رویکرد مشابه برای فریم‌های تصویر، صدا و ویدیو کاربرد دارد: لینک را به فریم اختصاص دهید و در صورت نیاز ویژگی [Tooltip](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/tooltip/) را تنظیم کنید.

مثال زیر یک مستطیل را قابل کلیک می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **استفاده از لینک‌ها برای ایجاد فهرست مطالب**

لینک‌های داخلی به خوانندگان اجازه می‌دهند از فهرست مطالب به اسلاید خاصی پرش کنند. مثال زیر از [SetInternalHyperlinkClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) برای پیوند متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **قالب‌بندی لینک‌ها**

### **رنگ**

ویژگی [ColorSource](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/colorsource/) از [IHyperlink](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/) تعیین می‌کند که آیا یک لینک از رنگ لینک‌های ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر کردن بخش را تنظیم نمایید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو لینک متنی به همان اسلاید اضافه می‌کند. اولین لینک از پر کردن متن قرمز استفاده می‌کند، در حالی که دومین لینک رنگ پیش‌فرض لینک را حفظ می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```
### **صدا**

یک لینک می‌تواند هنگام فعال شدن صدایی را پخش کند یا صدایی که در حال پخش است متوقف نماید. از ویژگی‌های زیر برای پیکربندی این رفتارها استفاده کنید:

- [IHyperlink.Sound](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/sound/) صدا را که با لینک مرتبط است مشخص می‌کند.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/stopsoundonclick/) کنترل می‌کند که آیا فعال‌سازی لینک صدای قبلی را متوقف می‌کند یا نه.

#### **افزودن صدای لینک**

مثال زیر فایل `sampleaudio.wav` را بارگذاری می‌کند و آن را به یک دکمه در اسلاید اول پیوند می‌دهد. کلیک کردن بر روی دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌رود. شکل دوم در همان اسلاید هنگام کلیک صدا را متوقف می‌کند، بدون اینکه اقدام ناوبری انجام دهد.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **استخراج صدای لینک**

مثال زیر ارائه‌ای که در بالا ایجاد شد را باز می‌کند و صداهای لینک‌شده اولین شکل را از طریق [Sound](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/sound/) و [BinaryData](https://reference.aspose.com/slides/fa/net/aspose.slides/iaudio/binarydata/) به حافظه می‌خواند.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **راهنما (Tooltip) و تنظیمات تعامل**

پس از اختصاص یک لینک به متن یا شکل می‌توانید ویژگی‌های زیر [IHyperlink](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/) را به‌روزرسانی کنید:

- [Tooltip](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/tooltip/) متنی را تنظیم می‌کند که بیننده می‌تواند به عنوان نکته‌ای برای لینک نمایش دهد.
- [TargetFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/targetframe/) فریم هدف را در مجموعه فریم‌های HTML والد مشخص می‌کند، در صورت کاربرد.
- [History](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/history/) کنترل می‌کند که آیا فعال‌سازی لینک مقصد آن را به فهرست لینک‌های مشاهده‌شده اضافه می‌کند یا نه.
- [HighlightClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/highlightclick/) تعیین می‌کند که آیا لینک هنگام کلیک برجسته شود یا خیر.

## **حذف لینک‌ها از ارائه‌ها**

از [GetAnyHyperlinks](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) برای جمع‌آوری محفظه‌های لینک، شامل لینک‌های بخش متنی، پیش از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [RemoveHyperlinkClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) یا [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) را فراخوانی کنید؛ حذف عمل کلیک، معادل‌اش در حالت ماوس‌اور را حذف نمی‌کند.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

برای حذف بی‌قید و شرط، [RemoveAllHyperlinks](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) هر دو نوع فعال‌سازی را در محدودهٔ انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، لایه‌ها و یادداشت‌ها، به بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت فهرست کامل لینک‌ها**

قبل از توزیع یک ارائه، اقدامات تعاملی و وب‌لینک‌های آن را فهرست کنید. [GetAnyHyperlinks](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) اشیای [IHyperlinkContainer](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkcontainer/) را برمی‌گرداند، نه یک فهرست ساده از رشته‌های URL. هر دو [HyperlinkClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) و [HyperlinkMouseOver](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) را روی هر محفظه بررسی کنید. این دو مستقل هستند: یک محفظه می‌تواند هر دو عمل را ارائه دهد، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر محفظه نیاز داشته باشد.

اسکن تنها لینک‌های سطح شکل می‌تواند لینک‌های پیوست شده به بخش‌های متنی را از دست بدهد. به‌جای آن دامنهٔ مناسب را پرس‌وجو کنید و محفظه‌های بازگشتی را نگه دارید تا بعداً بتوانید اقداماتشان را به‌روزرسانی یا حذف کنید.

### **پرس و جو در سطح ارائه، اسلاید و فریم متن**

رابط [IHyperlinkQueries](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/) از طریق [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/hyperlinkqueries/)، [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/hyperlinkqueries/) و [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/hyperlinkqueries/) در دسترس است. هر دامنه همان پرس‌وجوها را پشتیبانی می‌کند:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) محفظه‌های دارای عمل کلیک را برمی‌گرداند.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) محفظه‌های دارای عمل ماوس‌اور را برمی‌گرداند.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) محفظه‌هایی که یکی یا هر دو عمل را دارند برمی‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` ایجاد می‌کند که شامل یک لینک کلیک خارجی، یک لینک ماوس‌اور فایل، ناوبری داخلی اسلاید، یک لینک ماوس‌اور متن و یک عمل ماکرو است. هیچ‌یک از این اعمال اجرا نمی‌شود. همان سه پرس‌وجو در هر دامنه کار می‌کند؛ شمارش‌ها تعداد محفظه‌ها را نشان می‌دهند، نه مجموع اعمال. دامنهٔ فریم‑متن لینک‌های مربوط به شکل محاطی را مستثنی می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

برای این مثال، پرس‌وجوهای ارائه و اسلاید هر کدام سه محفظه کلیک، دو محفظه ماوس‌اور و سه محفظه دارای هر یک از اعمال را گزارش می‌کنند. پرس‌وجوی فریم‑متن یک محفظه در هر دسته گزارش می‌دهد.

### **دسته‌بندی اعمال و مقاصد**

از [IHyperlink.ActionType](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/actiontype/) برای تفسیر یک عمل قبل از تفسیر مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/fa/net/aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب را پوشش می‌دهند:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | لینک خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | حرکت داخلی به اسلاید خاصی. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری داخلی پیش‌ساختهٔ نمایش‌اسلاید، در زمینهٔ نمایش‌اسلاید حل می‌شود. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش جاری یا شروع یک نمایش سفارشی. |
| `StartMacro` | اجرای یک ماکرو. |
| `StartProgram` | راه‌اندازی یک برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن یک فایل یا ارائهٔ دیگر؛ جداگانه از URLهای وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری، یا عمل شناخته‌نشده‌ای که نیاز به بررسی دارد. |

مقاصد خارجی را از [ExternalUrl](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/externalurl/) و مقاصد داخلی خاص را از [TargetSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/targetslide/) بخوانید. اعمال داخلی و دستورات پیش‌ساخته ممکن است URL خارجی نداشته باشند؛ یک URL خالی به معنای عدم وجود عمل در محفظه نیست. هنگامی که [ExternalUrlOriginal](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/externalurloriginal/) با URL نرمال‌شده متفاوت است، آن را حفظ کنید و در صورت وجود، [Tooltip](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlink/tooltip/) را هم شامل کنید.

### **گزارش، پاک‌سازی و تأیید لینک‌ها**

مثال زیر که برای .NET 6+ نوشته شده، یک ارائه موجود را می‌خواند (از فایلی که در بالا ایجاد شده استفاده کنید)، `hyperlink-audit.json` می‌نویسد، یک سیاست اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌کند و دوباره باز می‌کند تا هر دو نوع فعال‌سازی را دوباره بررسی کند. قبل از تغییر محفظه‌ها آن‌ها را جمع‌آوری می‌کند و برای جلوگیری از پردازش دوبار همان محفظه از برابری مرجع استفاده می‌کند. پرس‌وجوهای ارائه اسلایدهای عادی را پوشش می‌دهند؛ برای فهرست‌گذاری در سطح بسته، مسترها، لایه‌ها، یادداشت‌ها و مسترهای یادداشت و برگه توزیع نیز به صورت صریح پرس‌وجو می‌شود.

گزارش یک شاخص اسلاید یک‌پایه و [SlideId](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/slideid/) (در صورت موجود بودن) ثبت می‌کند. [ISlideComponent.Slide](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecomponent/slide/) اسلاید مالک را برای محفظه‌های پشتیبانی‌شده فراهم می‌کند. مسترها، لایه‌ها و یادداشت‌ها شاخص اسلاید معمولی ندارند و با دامنهٔ خود شناسایی می‌شوند. محفظه‌های شکل و محفظه‌های قالب‌بندی بخش متن به‌ طور جداگانه نام‌گذاری می‌شوند؛ سایر انواع محفظه نام زمان اجرا خود را حفظ می‌کنند. به هر محفظه یک شناسهٔ محلی گزارش اختصاص می‌یابد تا دو عمل آن بتوانند هم‌سو شوند.

این سیاست برنامه‌ای به‌‌طور عمدی محدودکننده تنها URLهای مطلق HTTPS و اهداف داخلی اسلاید معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اقدامات فایل، اعمال دیگر نمایش‌اسلاید، اعمال ناشناخته و سایر طرح‌های URL رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه حکم ایمنی Aspose.Slides. تنها HTTPS اعتماد ایجاد نمی‌کند: لیست‌های سفید میزبان و سایر بررسی‌ها را برای برنامه‌تان اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال کردن لینک‌ها یا اجرای اعمال ممیزی می‌کند.

برای بازسازی، [HyperlinkManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) محفظه از [SetExternalHyperlinkClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)، [RemoveHyperlinkClick](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) و [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع با یک صفحه فرود ثابت HTTPS جایگزین می‌شوند؛ کلیک‌ها و اعمال ماوس‌اور ممنوع دیگر به‌ طور جداگانه حذف می‌شوند. برای حذف تمام تخلفات سیاست، `replaceExternalClicks` را به `false` تنظیم کنید. قبل از استقرار، یک صفحهٔ جایگزین تحت مالکیت برنامه انتخاب کنید.

پرچم خروجی گزارش از یک سیاست بررسی PDF محتاطانه استفاده می‌کند: اعمال ماوس‌اور و هر چیزی غیر از لینک خارجی یا پرش اسلاید خاص را به‌ عنوان احتمالا پشتیبانی‌نشده علامت‌گذاری می‌کند. این یک نکتهٔ بررسی است، نه آزمون قابلیت یا تضمین اینکه لینک‌های بدون علامت در خروجی باقی بمانند. خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است لینک‌ها را حفظ کنند، بسته به عمل، گزینه‌های خروجی و نمایشگر. تصاویر رستری و ویدیو نمی‌توانند لینک‌های تعاملی را حفظ کنند؛ هنگام ممیزی برای آن خروجی‌ها هر عمل را علامت‌گذاری کنید.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

با ورودی که در بالا ایجاد شد، گزارش شامل پنج ردیف عمل است. لینک ماوس‌اور فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. تأیید صفر عمل ممنوع چاپ می‌کند. ورودی شامل یک URL کلیک خارجی ممنوع نیز شاخهٔ جایگزینی را اجرا می‌کند. یک محفظه با کلیک مجاز و ماوس‌اور ممنوع عمل کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی متفاوت از [RemoveAllHyperlinks](https://reference.aspose.com/slides/fa/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) است که بدون توجه به سیاست، هر دو نوع فعال‌سازی را در تمام دامنهٔ انتخاب‌شده حذف می‌کند. تأیید اینجا فقط اعمال لینک‌ها را بررسی می‌کند؛ پروژه‌های VBA جاسازی‌شده، اشیای OLE یا سایر محتوای فعال را حذف نمی‌کند و فایل PDF یا HTML خروجی را نیز اعتبارسنجی نمی‌کند.

## **سؤالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک کنم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک لینک داخلی به یک اسلاید منفرد هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم یک لینک را به عناصر اسلاید مستر بچسبانم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید مستر و لایه از لینک‌ها پشتیبانی می‌کنند. لینک‌های این عناصر در حین نمایش اسلاید بر روی اسلایدهایی که از مستر یا لایهٔ مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا لینک‌ها هنگام خروجی به PDF، HTML، تصاویر یا ویدیو حفظ می‌شوند؟**

خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است لینک‌ها را حفظ کنند؛ تصاویر رستری و ویدیو نمی‌توانند. برای جزئیات بیشتر به ملاحظات خروجی در بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.