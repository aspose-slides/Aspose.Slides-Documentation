---
title: اسلاید اصلی
type: docs
weight: 30
url: /fa/net/examples/elements/master-slide/
keywords:
- اسلاید اصلی
- افزودن اسلاید اصلی
- دسترسی به اسلاید اصلی
- حذف اسلاید اصلی
- اسلاید اصلی بدون استفاده
- مثال کد
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نمونه‌های اسلاید اصلی Aspose.Slides برای .NET را بررسی کنید: ایجاد، ویرایش و استایل‌گذاری روی اسلایدهای اصلی، جای‌دارها و تم‌ها در PPT، PPTX و ODP با کد واضح C#."
---
اسلایدهای اصلی سطح بالایی سلسله‌مراتبی ارث‌بری اسلایدها در PowerPoint را تشکیل می‌دهند. یک **master slide** عناصر طراحی مشترک مانند پس‌زمینه‌ها، لوگوها و قالب‌بندی متن را تعریف می‌کند. **Layout slides** از اسلایدهای اصلی ارث می‌برند و **normal slides** از اسلایدهای چیدمان ارث می‌برند.

این مقاله نشان می‌دهد که چگونه می‌توان اسلایدهای اصلی را با استفاده از Aspose.Slides for .NET ایجاد، اصلاح و مدیریت کرد.

## **افزودن اسلاید اصلی**

این مثال نشان می‌دهد که چگونه با کلون کردن اسلاید پیش‌فرض، یک اسلاید اصلی جدید ایجاد می‌شود. سپس بنر نام شرکت را از طریق ارث‌بری چیدمان به تمام اسلایدها اضافه می‌کند.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // یک کپی از اسلاید اصلی پیش‌فرض ایجاد می‌کند.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // یک بنر با نام شرکت را در بالای اسلاید اصلی اضافه می‌کند.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // اسلاید اصلی جدید را به یک اسلاید چیدمان اختصاص می‌دهد.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // اسلاید چیدمان را به اولین اسلاید در ارائه اختصاص می‌دهد.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **نکته ۱:** اسلایدهای اصلی روشی برای اعمال برندینگ ثابت یا عناصر طراحی مشترک در تمام اسلایدها فراهم می‌کنند. هر تغییری که در اسلاید اصلی انجام شود، به‌صورت خودکار در اسلایدهای چیدمان وابسته و اسلایدهای معمولی بازتاب می‌یابد.

> 💡 **نکته ۲:** هر شکل یا قالب‌بندی که به یک اسلاید اصلی اضافه شود، توسط اسلایدهای چیدمان وارث می‌شود و به نوبه خود به تمام اسلایدهای معمولی که از آن چیدمان‌ها استفاده می‌کنند، منتقل می‌شود.

> تصویر زیر نشان می‌دهد که چگونه یک جعبه متن افزوده‌شده در اسلاید اصلی به‌صورت خودکار در اسلاید نهایی رندر می‌شود.

![مثال ارث‌بری اسلاید اصلی](master-slide-banner.png)

## **دسترس به یک اسلاید اصلی**

می‌توانید با استفاده از مجموعه `Presentation.Masters` به اسلایدهای اصلی دسترسی پیدا کنید. در اینجا نحوه بازیابی و کار با آن‌ها را نشان می‌دهیم:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // دسترسی به اولین اسلاید اصلی.
    var firstMasterSlide = presentation.Masters[0];

    // تغییر نوع پس‌زمینه.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **حذف یک اسلاید اصلی**

اسلایدهای اصلی می‌توانند بر اساس اندیس یا با ارجاع حذف شوند.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // حذف یک اسلاید اصلی بر اساس ایندکس.
    presentation.Masters.RemoveAt(0);

    // حذف یک اسلاید اصلی بر اساس ارجاع.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **حذف اسلایدهای اصلی بدون استفاده**

برخی از ارائه‌ها حاوی اسلایدهای اصلی هستند که استفاده نمی‌شوند. حذف این اسلایدها می‌تواند به کاهش حجم فایل کمک کند.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // حذف تمام اسلایدهای اصلی بلااستفاده (حتی آن‌هایی که به عنوان Preserve علامت‌گذاری شده‌اند).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```