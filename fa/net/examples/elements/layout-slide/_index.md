---
title: اسلاید طرح‌بندی
type: docs
weight: 20
url: /fa/net/examples/elements/layout-slide/
keywords:
- اسلاید طرح‌بندی
- افزودن اسلاید طرح‌بندی
- دسترسی به اسلاید طرح‌بندی
- حذف اسلاید طرح‌بندی
- اسلاید طرح‌بندی استفاده‌نشده
- کپی‌برداری از اسلاید طرح‌بندی
- مثال کد
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اسلایدهای طرح‌بندی اصلی در Aspose.Slides برای .NET: انتخاب، اعمال و سفارشی‌سازی طرح‌بندی‌های اسلاید، مکان‌نماها و مسترها با مثال‌های C# برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد چگونه با **Layout Slides** در Aspose.Slides برای .NET کار کنید. یک اسلاید طرح‌بندی، طراحی و قالب‌بندی را که توسط اسلایدهای عادی به ارث می‌رسند، تعریف می‌کند. می‌توانید اسلایدهای طرح‌بندی را اضافه، دسترسی، تکثیر و حذف کنید، همچنین اسلایدهای استفاده نشده را پاک‌سازی کنید تا اندازه ارائه کاهش یابد.

## **افزودن یک اسلاید طرح‌بندی**

می‌توانید یک اسلاید طرح‌بندی سفارشی ایجاد کنید تا قالب‌بندی قابل استفاده مجدد را تعریف کند. به عنوان مثال، ممکن است یک کادر متن اضافه کنید که در تمام اسلایدهای استفاده‌کننده از این طرح نمایش داده شود.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // یک اسلاید طرح‌بندی با نوع طرح خالی و نام سفارشی ایجاد کنید.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // یک کادر متن به اسلاید طرح‌بندی اضافه کنید.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // دو اسلاید با استفاده از این طرح اضافه کنید؛ هر دو متن طرح را به ارث می‌برند.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **نکته 1:** اسلایدهای طرح‌بندی به عنوان قالب برای اسلایدهای جداگانه عمل می‌کنند. می‌توانید عناصر مشترک را یک بار تعریف کنید و در اسلایدهای متعدد دوباره استفاده کنید.
> 
> 💡 **نکته 2:** وقتی به یک اسلاید طرح‌بندی اشکال یا متن اضافه می‌کنید، تمام اسلایدهای مبتنی بر آن طرح، به‌طور خودکار این محتوای مشترک را نمایش می‌دهند. تصویر زیر دو اسلاید را نشان می‌دهد که هر یک یک کادر متن را از همان اسلاید طرح‌بندی به ارث می‌برند.

![اسلایدهای ارث‌برداری از محتویات طرح](layout-slide-result.png)

## **دسترسی به یک اسلاید طرح‌بندی**

می‌توان به اسلایدهای طرح‌بندی بر حسب شاخص یا بر حسب نوع طرح‌بندی (مانند `Blank`، `Title`، `SectionHeader` و غیره) دسترسی پیدا کرد.

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // دسترسی به یک اسلاید طرح‌بندی بر حسب شاخص.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // دسترسی به یک اسلاید طرح‌بندی بر حسب نوع.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **حذف یک اسلاید طرح‌بندی**

اگر دیگر نیازی به یک اسلاید طرح‌بندی خاص ندارید، می‌توانید آن را حذف کنید.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // یک اسلاید طرح‌بندی را بر حسب نوع دریافت کنید و حذف کنید.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **حذف اسلایدهای طرح‌بندی استفاده‌نشده**

برای کاهش اندازه ارائه، ممکن است بخواهید اسلایدهای طرح‌بندی که توسط هیچ اسلاید عادی استفاده نمی‌شوند را حذف کنید.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // به‌صورت خودکار تمام اسلایدهای طرح‌بندی که توسط هیچ اسلایدی ارجاع نمی‌شوند را حذف می‌کند.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **کپی‌برداری از یک اسلاید طرح‌بندی**

می‌توانید یک اسلاید طرح‌بندی را با استفاده از متد `AddClone` تکثیر کنید.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // یک اسلاید طرح‌بندی موجود را بر حسب نوع دریافت کنید.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // اسلاید طرح‌بندی را به انتهای مجموعه اسلایدهای طرح‌بندی کپی کنید.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **خلاصه:** اسلایدهای طرح‌بندی ابزارهای قدرتمندی برای مدیریت قالب‌بندی ثابت در سراسر اسلایدها هستند. Aspose.Slides کنترل کامل بر ایجاد، مدیریت و بهینه‌سازی اسلایدهای طرح‌بندی را فراهم می‌کند.