---
title: مدیریت جایگزین‌کننده‌های ارائه در .NET
linktitle: مدیریت جایگزین‌کننده‌ها
type: docs
weight: 10
url: /fa/net/manage-placeholder/
keywords:
- جایگزین‌کننده
- جایگزین‌کننده متن
- جایگزین‌کننده تصویر
- جایگزین‌کننده نمودار
- جایگزین‌کننده محتوا
- متن راهنما
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه جایگزین‌کننده‌های متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و ارث‌بری جایگزین‌کننده‌ها را با Aspose.Slides برای .NET درک کنید."
---
## **مروری کلی**

یک placeholder شکلی است که یک موقعیت را برای نوع خاصی از محتوا در قالب یک ارائه رزرو می‌کند. مثال‌های رایج شامل placeholderهای عنوان، بدنه، تصویر، نمودار و placeholderهای محتوای عمومی هستند. برخلاف یک شکل عادی، یک placeholder می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از اسلاید طرح‌بندی یا اسلاید اصلی به ارث ببرد.

Aspose.Slides اطلاعات placeholder را از طریق ویژگی [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) افشا می‌کند. این ویژگی یک شیء [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) یا `null` برای یک شکل عادی برمی‌گرداند. برای تعیین محتوایی که placeholder قرار است شامل شود از [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) استفاده کنید.

رابط شکل همچنان پس از دانستن نوع placeholder مهم است:

- یک placeholder خالی متن، تصویر، نمودار یا محتوا معمولاً توسط یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) نمایش داده می‌شود.
- یک placeholder تصویر پر شده می‌تواند توسط یک [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) نمایش داده شود.
- یک placeholder نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) نمایش داده شود.
- یک placeholder محتوا می‌تواند چندین نوع محتوا را در خود داشته باشد. به جای این‌که فرض کنید هر placeholder یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) است، هم [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) و هم رابط شکل در زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) نقش یک placeholder را توصیف می‌کند؛ این تضمین نمی‌کند که نوع شکل در زمان اجرا چه خواهد بود. همیشه قبل از دسترسی به اعضای مربوط به متن، تصویر، نمودار، جدول یا رسانه، یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک ارث‌بری placeholder**

placeholderها یک سلسله مراتب تشکیل می‌دهند:

1. یک اسلاید master سبک‌های قابل استفاده مجدد را تعریف می‌کند و در برخی موارد، placeholderهای سطح master را نیز دارد.
2. یک اسلاید layout چیدمان مورد استفاده توسط یک یا چند اسلاید عادی را تعیین می‌کند و می‌تواند از master ارث‌بری کند.
3. یک اسلاید عادی شامل placeholderهای مربوط به آن اسلاید می‌شود و می‌تواند از layout خود ارث‌بری کند.

برای حرکت یک سطح بالاتر در این سلسله مراتب، [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) را فراخوانی کنید. یک placeholder اسلاید معمولاً placeholder layout خود را برمی‌گرداند؛ یک placeholder layout می‌تواند placeholder master را برگرداند. این متد زمانی که شکل هیچ placeholder پایه‌ای ندارد `null` برمی‌گرداند.

مثال زیر placeholderهای موجود در اولین اسلاید را فهرست می‌کند و placeholderهای پایه آن‌ها را گزارش می‌دهد:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

ویرایش یک placeholder در اسلاید عادی یک بازنویسی محلی برای آن اسلاید ایجاد یا تغییر می‌دهد. ویرایش layout یا master مرتبط می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را ارث می‌برند اثر بگذارد. یک شکل عادی محلی هیچ placeholder پایه‌ای ندارد و فقط به این دلیل که همان مختصات را اشغال می‌کند، شروع به ارث‌بری نمی‌کند.

## **حذف وضعیت placeholder**

هنگام تطبیق یک قالب، از [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) استفاده کنید تا یک شی موجود را به عنوان یک شکل عادی نگه دارید. ویژگی [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) آن `null` می‌شود، اما شکل در مجموعه اسلاید باقی می‌ماند. در مقابل، [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) شکل را از آن مجموعه حذف می‌کند.

مثال زیر به فایلی به نام `template.pptx` نیاز دارد که حداقل یک اسلاید و یک placeholder متن غیر خالی در اولین اسلاید داشته باشد. از یک placeholder با قالب‌بندی ارث‌بری شده از layout یا master استفاده کنید تا اثر حذف آن رابطه را ببینید. مثال بررسی می‌کند که همان شکل باقی می‌ماند، دوباره متد را بر روی شکل اکنون عادی صدا می‌زند و نتیجه را ذخیره می‌کند.

{{% alert color="warning" title="Warning" %}}
حذف وضعیت placeholder به طور خودکار تنظیمات ظاهر ارث‌بری شده را حفظ نمی‌کند. مثال زیر به عمد این تنظیمات را بدون تغییر می‌گذارد، بنابراین خروجی ممکن است متفاوت دیده شود. یک شکل که موقعیت و اندازهٔ آن به طور کامل ارث‌بری شده باشد می‌تواند پس از فراخوانی مختصات و ابعاد صفر داشته باشد و حتی اگر در مجموعه بماند نامرئی شود.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // فراخوانی این متد روی یک شکل عادی هیچ اثری ندارد.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

برای یک placeholder منطبق، هر سه بررسی `True` چاپ می‌شوند. متن باقی می‌ماند، اما موقعیت، اندازه، چرخش، فونت، تراز پاراگراف، حاشیه‌های text‑frame، تکیه‌گاه عمودی، پر کردن و تنظیمات خط می‌توانند هنگام حذف رابطه placeholder تغییر کنند. به عنوان مثال، قالب‌بندی ارث‌بری شدهٔ عنوان می‌تواند به قالب‌بندی متن معمولی بازگردد. برای اطلاعات بیشتر درباره layoutها، به [Slide Layout](/slides/fa/net/slide-layout/) مراجعه کنید.

برای حفظ ظاهر موردنظر، موقعیت، اندازه و چرخش نهایی را پیش از فراخوانی ذخیره کنید و مقادیر قالب‌بندی مؤثر مورد نیاز را در متغیرهای جداگانه کپی کنید. این مقادیر را از طریق [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/)، [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/)، [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/)، [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/)، و [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) دریافت کنید. تنها به اشیای format مؤثر تکیه نکنید، زیرا مقادیر قالب‌بندی متن آن‌ها می‌تواند پس از حذف رابطه تغییر کند. مقادیر ذخیره‌شده را به شکل عادی پس از آن به‌صورت صریح اعمال کنید، شامل خانوادهٔ فونت، اندازه، سبک، رنگ، تنظیمات پاراگراف، تنظیمات text‑frame، پر کردن و خط مورد استفاده در قالب شما.

هندسهٔ شکل ارث‌بری شده ممکن است نیاز به اختصاص صریح از طریق [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/) داشته باشد. برای یک placeholder متن مستطیلی، این به معنای اختصاص [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) است؛ بازگرداندن فقط پر کردن و خط ممکن است مستطیل قابل رویت را بازنگرداند. قالب‌هایی با افکت‌های اضافه یا قالب‌بندی پیچیده‌تر نیز نیاز به مدیریت این تنظیمات دارند.

## **تغییر متن در یک placeholder**

placeholderهای عنوان، عنوان‑متمرکز، زیرعنوان، بدنه و متن به‌طور معمول از متن پشتیبانی می‌کنند. قبل از استفاده از ویژگی [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) را بررسی کنید.

این مثال اولین placeholder عنوان در اولین اسلاید را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

این الگو از تبدیل placeholderهای تصویر، نمودار، جدول یا رسانه به [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) جلوگیری می‌کند. همچنین placeholder را بر اساس هدف شناسایی می‌کند به‌جای اتکا به یک ایندکس شکلی شکننده.

## **تنظیم متن راهنما در یک layout**

متن راهنما دستور زمان‌طراحی است که در یک placeholder خالی نمایش داده می‌شود، مانند *Click to add title*. متن راهنمای سفارشی را بر روی placeholder layout تنظیم کنید نه اینکه سعی کنید آن را از مجموعهٔ شکل‌های یک اسلاید عادی دسترسی پیدا کنید. layout را از طریق [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) بدست آورده و بر روی [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/) تکرار کنید.

مثال زیر عنوان و زیرعنوان راهنما را در layout استفاده‌شده توسط اولین اسلاید تغییر می‌دهد:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

متن راهنما محتوای عادی اسلاید نیست. این متن برای placeholderهای خالی در برنامه‌های ویرایشی مانند PowerPoint در نظر گرفته شده است. وقتی کاربر یا برنامه محتوای واقعی را وارد می‌کند، راهنما دیگر نمایش داده نمی‌شود. تغییر یک راهنما همچنین متن موجود در اسلایدهایی که از آن layout استفاده می‌کنند را جایگزین نمی‌کند.

## **به‌روزرسانی یک placeholder تصویر**

دو حالت برای مدیریت وجود دارد:

- اگر placeholder تصویر قبلاً پر شده باشد و توسط یک [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) نمایش داده می‌شود، تصویر را از طریق [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) و [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) جایگزین کنید.
- اگر هنوز یک placeholder خالی باشد، یک picture frame در مختصات placeholder با [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) اضافه کنید و placeholder خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی می‌کند و ارائه را ذخیره می‌نماید:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

جایگزینی که برای یک placeholder خالی ایجاد می‌شود یک picture frame محلی است، نه یک placeholder جدید، زیرا [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) فقط‑خواندنی است. این موقعیت رزروشده را حفظ می‌کند اما دیگر رفتار ویژهٔ placeholder را به ارث نمی‌برد. اگر حفظ رابطهٔ placeholder حیاتی است، ابتدا placeholder را در PowerPoint آماده و پر کنید، سپس [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و دیگر افکت‌های خاص تصویر، به [Manage Picture Frames](/slides/fa/net/picture-frame/) مراجعه کنید. این عملیات‌ها به picture frame یا picture fill تعلق دارند، نه به متادیتای placeholder.

## **کار با placeholderهای نمودار و محتوا**

یک placeholder نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) نمایش داده شود. این مثال چنین نموداری را هم با توجه به نوع placeholder و هم رابط زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

یک placeholder محتوای عمومی معمولاً دارای [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) است. در PowerPoint به‌عنوان یک راه‌انداز برای انواع مختلف محتوا عمل می‌کند، شامل نمودارها، جدول‌ها، دیاگرام‌ها، تصویرها و رسانه‌ها. پس از پر شدن، رابط شکل واقعی را بررسی کنید تا ببینید چه چیزی در آن وجود دارد. layoutهای تخصصی می‌توانند همچنین [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)، [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)، [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)، [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)، یا [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) را نشان دهند.

Aspose.Slides یک [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) خالی را فقط با تغییر [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) به یک [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) تبدیل نمی‌کند؛ نوع فقط‑خواندنی است. برای پر کردن برنامه‌وار یک نمودار یا ناحیه محتوای خالی، شیء مورد نیاز را در مختصات placeholder اضافه کنید و سپس placeholder خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

نمودار اضافه‑شده یک نمودار محلی عادی است. این ناحیه placeholder را اشغال می‌کند اما از layout placeholder ارث نمی‌برد. وقتی نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های کتاب‌کار دارید، از مقالات اختصاصی [chart management articles](/slides/fa/net/powerpoint-charts/) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال انتها‑به‑انتها زیر یک قالب را باز می‌کند، اولین اسلاید را برای یک placeholder عنوان یا تصویر جستجو می‌کند، نوع placeholder و شکل را بررسی می‌کند، محتوای مناسب را به‌روزرسانی می‌کند و خروجی را ذخیره می‌نماید. این مثال عمدی از فرض ایندکس شکل یا تبدیل همه placeholderها به یک رابط واحد خودداری می‌کند.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**مکان‌نگهدار پایه چیست؟**

یک placeholder پایه شکل متناظر بر روی layout یا master است که یک placeholder دیگر از آن ارث می‌برد. برای بازیابی آن از [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) استفاده کنید. یک شکل محلی عادی `null` برمی‌گرداند زیرا بخشی از سلسله مراتب placeholderها نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک placeholder layout تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنمای ارث‌بری‌شده را از طریق layout تغییر دهید، اما محتوای واقعی عنوان در اسلایدهای عادی ذخیره می‌شود. برای جایگزینی متن عنوان در سراسر ارائه، باید بر روی اسلایدها تکرار کنید و هر placeholder عنوان را به‌روزرسانی کنید.

**چگونه placeholderهای تاریخ، شماره‑اسلاید، سرصفحه و پاورقی را مدیریت کنم؟**

از مدیران سرصفحه و پاورقی در سطح اسلاید مناسب، layout، master، notes یا handout استفاده کنید. برای مثال‌های کامل به [Manage Presentation Header and Footer](/slides/fa/net/presentation-header-and-footer/) مراجعه کنید.