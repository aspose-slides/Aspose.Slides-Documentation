---
title: مدیریت جای‌گیرهای ارائه در .NET
linktitle: مدیریت جای‌گیرها
type: docs
weight: 10
url: /fa/net/manage-placeholder/
keywords:
- جای‌گیر
- جای‌گیر متن
- جای‌گیر تصویر
- جای‌گیر نمودار
- جای‌گیر محتوا
- متن راهنمایی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نحوه بازبینی و ویرایش جای‌گیرهای متن، تصویر، نمودار و محتوا را بیاموزید و وراثت جای‌گیرها را با Aspose.Slides برای .NET درک کنید."
---
## **نمای کلی**

یک جای‌گیر (placeholder) شکلی است که موقعیتی را برای نوع خاصی از محتوا در قالب ارائه رزرو می‌کند. نمونه‌های رایج شامل جای‌گیرهای عنوان، بدنه، تصویر، نمودار و جای‌گیرهای محتوای عمومی هستند. برخلاف یک شکل معمولی، یک جای‌گیر می‌تواند موقعیت، اندازه، قالب‌بندی و تنظیمات دیگر خود را از یک اسلاید چیدمان (layout slide) یا اسلاید اصلی (master slide) به ارث برد.

Aspose.Slides اطلاعات جای‌گیرها را از طریق ویژگی [IShape.Placeholder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/placeholder/) در اختیار می‌گذارد. این ویژگی یک شیء [IPlaceholder](https://reference.aspose.com/slides/fa/net/aspose.slides/iplaceholder/) را برمی‌گرداند یا برای یک شکل عادی `null` می‌شود. برای تعیین محتوایی که جای‌گیر قرار است شامل شود، از [IPlaceholder.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/iplaceholder/type/) استفاده کنید.

رابط شکل حتی پس از شناخت نوع جای‌گیر همچنان مهم است:

- یک جای‌گیر متن، تصویر، نمودار یا محتوای خالی معمولاً توسط یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) نشان داده می‌شود.
- یک جای‌گیر تصویر پر شده می‌تواند توسط یک [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) نمایش داده شود.
- یک جای‌گیر نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/) نشان داده شود.
- یک جای‌گیر محتوا می‌تواند انواع مختلفی از محتوا را در خود جای دهد. به جای این‌که فرض کنید هر جای‌گیری یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) است، هم [IPlaceholder.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/iplaceholder/type/) و هم رابط زمان اجرا (runtime) شکل را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/iplaceholder/type/) نقش یک جای‌گیر را توصیف می‌کند؛ اما نوع زمان اجرای شکل را تضمین نمی‌کند. همواره قبل از دسترسی به اعضای متن، تصویر، نمودار، جدول یا رسانه، یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک ارث‌بری جای‌گیرها**

جای‌گیرها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید اصلی (master slide) سبک‌های قابل استفاده مجدد و در برخی موارد جای‌گیرهای سطح اصلی را تعریف می‌کند.
2. یک اسلاید چیدمان (layout slide) ترتیب استفاده‌شده توسط یک یا چند اسلاید عادی را تعیین می‌کند و می‌تواند از اسلاید اصلی ارث ببرد.
3. یک اسلاید عادی شامل جای‌گیرهای خود است و می‌تواند از چیدمان خود ارث‌بری کند.

برای حرکت یک سطح بالا در این سلسله‌مراتب، از [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/getbaseplaceholder/) استفاده کنید. یک جای‌گیر اسلاید معمولاً جای‌گیر چیدمان خود را برمی‌گرداند؛ یک جای‌گیر چیدمان می‌تواند جای‌گیر اصلی خود را برگرداند. این متد وقتی شکل هیچ جای‌گیر پایه‌ای نداشته باشد، `null` برمی‌گرداند.

مثال زیر جای‌گیرهای اسلاید اول را فهرست می‌کند و جای‌گیرهای پایه آن‌ها را گزارش می‌دهد:

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

ویرایش یک جای‌گیر در اسلاید عادی، یک بازنویسی محلی برای آن اسلاید ایجاد یا تغییر می‌دهد. ویرایش چیدمان یا اسلاید اصلی مرتبط می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را به ارث می‌برند، تأثیر بگذارد. یک شکل عادی محلی جای‌گیر پایه‌ای ندارد و فقط به دلیل اشغال همان مختصات، شروع به ارث‌بری نمی‌کند.

## **تغییر متن در یک جای‌گیر**

جای‌گیرهای عنوان، عنوان-مرکزی، زیرعنوان، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. قبل از استفاده از ویژگی [TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/textframe/) یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) را بررسی کنید.

این مثال اولین جای‌گیر عنوان در اسلاید اول را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید:

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

این الگو از تبدیل تصویر، نمودار، جدول یا رسانه به [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) جلوگیری می‌کند. همچنین جای‌گیر را بر اساس هدفش شناسایی می‌کند نه بر اساس یک شاخص شکننده شکل.

## **تنظیم متن راهنمایی (Prompt) در یک چیدمان**

متن راهنمایی (prompt) دستورالعمل زمان طراحی است که در یک جای‌گیر خالی نمایش داده می‌شود، مانند *برای افزودن عنوان کلیک کنید*. متن راهنمایی سفارشی را بر روی جای‌گیر چیدمان تنظیم کنید نه این‌که سعی کنید از طریق مجموعه اشکال اسلاید عادی به آن دسترسی پیدا کنید. چیدمان را از طریق [ISlide.LayoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/layoutslide/) دریافت کنید و بر روی [ILayoutSlide.Shapes](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/shapes/) پیمایش کنید.

مثال زیر متن راهنمایی عنوان و زیرعنوان را در چیدمانی که اسلاید اول از آن استفاده می‌کند، تغییر می‌دهد:

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

متن راهنمایی محتویات اسلاید عادی نیست. این متن برای جای‌گیرهای خالی در برنامه‌های ویرایشی مانند PowerPoint هدف‌گذاری شده است. هنگامی که کاربر یا برنامه محتوا واقعی را وارد می‌کند، راهنمایی دیگر نشان داده نمی‌شود. تغییر یک راهنمایی همچنین متن موجود در اسلایدهای استفاده‌کننده از چیدمان را جایگزین نمی‌کند.

## **به‌روزرسانی یک جای‌گیر تصویر**

دو حالت وجود دارد:

- اگر جای‌گیر تصویر قبلاً پر شده باشد و توسط یک [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) نمایان شود، تصویر را از طریق [IPictureFillFormat.Picture](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/picture/) و [ISlidesPicture.Image](https://reference.aspose.com/slides/fa/net/aspose.slides/islidespicture/image/) جایگزین کنید.
- اگر هنوز یک جای‌گیر خالی باشد، یک فریم تصویر را در مختصات جای‌گیر با استفاده از [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addpictureframe/) اضافه کنید و جای‌گیر خالی را حذف کنید.

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

جای‌گیری که برای یک جای‌گیر خالی ساخته می‌شود، یک فریم تصویر محلی است، نه یک جای‌گیر جدید، چون ویژگی [IShape.Placeholder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/placeholder/) فقط-خواندنی است. این فریم موقعیت رزرو شده را حفظ می‌کند اما دیگر رفتار ویژه جای‌گیر را به ارث نمی‌برد. اگر حفظ رابطه جای‌گیر ضروری است، ابتدا جای‌گیر را در PowerPoint آماده و پر کنید، سپس [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و سایر اثرات مختص تصویر، به مقاله [Manage Picture Frames](/slides/fa/net/picture-frame/) مراجعه کنید. این عملیات‌ها به فریم تصویر یا پرکن تصویر تعلق دارند، نه به داده‌های متادیتای جای‌گیر.

## **کار با جای‌گیرهای نمودار و محتوا**

یک جای‌گیر نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/) نشان داده شود. این مثال یک نمودار اینچنین را هم بر پایه نوع جای‌گیر و هم بر پایه رابط زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

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

یک جای‌گیر محتوا عمومی معمولاً دارای [PlaceholderType.Object](https://reference.aspose.com/slides/fa/net/aspose.slides/placeholdertype/) است. در PowerPoint به عنوان یک راه‌انداز برای چندین نوع محتوا از جمله نمودارها، جداول، دیاگرام‌ها، تصاویر و رسانه‌ها عمل می‌کند. پس از پر شدن، برای فهمیدن محتویات واقعی، رابط شکل واقعی را بررسی کنید. چیدمان‌های خاص می‌توانند همچنین [PlaceholderType.Chart](https://reference.aspose.com/slides/fa/net/aspose.slides/placeholdertype/)، [PlaceholderType.Table](https://reference.aspose.com/slides/fa/net/aspose.slides/placeholdertype/)، [PlaceholderType.Picture](https://reference.aspose.com/slides/fa/net/aspose.slides/placeholdertype/)، [PlaceholderType.Media](https://reference.aspose.com/slides/fa/net/aspose.slides/placeholdertype/)، یا [PlaceholderType.Diagram](https://reference.aspose.com/slides/fa/net/aspose.slides/placeholdertype/) را نمایش دهند.

Aspose.Slides یک جای‌گیر متن خالی [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) را صرفاً با تغییر [IPlaceholder.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/iplaceholder/type/) به یک [IChart](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/) تبدیل نمی‌کند؛ این نوع فقط-خواندنی است. برای پر کردن برنامه‌وار یک ناحیه نمودار یا محتوا خالی، شیء مورد نیاز را در مختصات جای‌گیر اضافه کنید و سپس جای‌گیر خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

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

نمودار اضافه‌شده یک نمودار محلی عادی است. این نمودار ناحیه جای‌گیر را اشغال می‌کند اما از جای‌گیر چیدمان ارث نمی‌برد. برای تعویض دسته‌ها، سری‌ها یا داده‌های کار‑کتاب، به مقالات اختصاصی [chart management](/slides/fa/net/powerpoint-charts/) مراجعه کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال پایان‑به‑پایان زیر یک قالب را باز می‌کند، اولین اسلاید را برای یافتن جای‌گیر عنوان یا تصویر جستجو می‌کند، نوع جای‌گیر و شکل را بررسی می‌نماید، محتوی مناسب را به‌روزرسانی می‌کند و خروجی را ذخیره می‌نماید. این مثال به‌صراحت از فرض یک شاخص شکل یا تبدیل همه جای‌گیرها به همان رابط اجتناب می‌کند.

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

## **پرسش‌های متداول**

**پایه‌ی یک جای‌گیر چیست؟**

پایه‌ی یک جای‌گیر شکل متناظر آن بر روی چیدمان یا اسلاید اصلی است که از آن جای‌گیر دیگر ارث می‌برد. برای دریافت آن از [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/getbaseplaceholder/) استفاده کنید. یک شکل محلی عادی `null` برمی‌گرداند زیرا جز سلسله‌مراتب جای‌گیرها نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک جای‌گیر چیدمان تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنمایی ارث‌بری شده را از طریق یک چیدمان تغییر دهید، اما محتوای واقعی عنوان‌ها در اسلایدهای عادی ذخیره می‌شود. برای جایگزینی متن عنوان در تمام ارائه، باید بر روی اسلایدها پیمایش کنید و هر جای‌گیر عنوان را به‌روزرسانی کنید.

**چگونه می‌توانم جای‌گیرهای تاریخ، شماره اسلاید، سرصفحه و پاورقی را مدیریت کنم؟**

از مدیرهای سرصفحه و پاورقی در سطح اسلاید، چیدمان، اسلاید اصلی، یادداشت‌ها یا توزیع‌های چاپی استفاده کنید. برای مثال‌های کامل به مقاله [Manage Presentation Header and Footer](/slides/fa/net/presentation-header-and-footer/) مراجعه نمایید.