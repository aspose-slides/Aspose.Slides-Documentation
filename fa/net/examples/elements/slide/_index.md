---
title: اسلاید
type: docs
weight: 10
url: /fa/net/examples/elements/slide/
keywords:
- اسلاید
- افزودن اسلاید
- دسترسی به اسلاید
- ایندکس اسلاید
- کلون اسلاید
- ترتیب‌مجدد اسلایدها
- حذف اسلاید
- نمونه کد
- پاورپوینت
- سند باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اسلایدها را در Aspose.Slides برای .NET کنترل کنید: ایجاد، کلون، ترتیب‌مجدد، تغییر اندازه، تنظیم پس‌زمینه‌ها و اعمال انتقال‌ها با C# برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله مجموعه‌ای از مثال‌ها را ارائه می‌دهد که نحوه کار با اسلایدها را با استفاده از **Aspose.Slides for .NET** نشان می‌دهد. شما یاد می‌گیرید چگونه اسلایدها را اضافه، دسترسی، کلون، ترتیب‌مجدد و حذف کنید با استفاده از کلاس `Presentation`.

هر مثال زیر شامل توضیح کوتاهی است که به دنبال آن یک قطعه کد در C# آورده شده است.

## **Add a Slide**
## **اضافه کردن اسلاید**

برای اضافه کردن یک اسلاید جدید، ابتدا باید یک طرح‌بندی را انتخاب کنید. در این مثال، از طرح‌بندی `Blank` استفاده می‌کنیم و یک اسلاید خالی به ارائه اضافه می‌کنیم.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // هر اسلاید بر پایه یک طرح‌بندی است که خود بر پایه یک اسلاید اصلی ساخته شده است.
    // از طرح‌بندی Blank برای ایجاد یک اسلاید جدید استفاده کنید.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Add a new empty slide using the selected layout.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **نکته:** هر طرح‌بندی اسلاید از یک اسلاید اصلی مشتق می‌شود که طراحی کلی و ساختار جای‌دارها را تعریف می‌کند. تصویر زیر نشان می‌دهد که اسلایدهای اصلی و طرح‌بندی‌های مرتبط با آن‌ها چگونه در PowerPoint سازماندهی شده‌اند.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**
## **دسترسی به اسلایدها بر اساس ایندکس**

می‌توانید اسلایدها را با استفاده از ایندکسشان دسترسی پیدا کنید، یا ایندکس یک اسلاید را بر اساس یک مرجع پیدا کنید. این برای پیمایش یا اصلاح اسلایدهای خاص مفید است.

```csharp
static void AccessSlide()
{
    // به‌طور پیش‌فرض، یک ارائه با یک اسلاید خالی ایجاد می‌شود.
    using var presentation = new Presentation();

    // یک اسلاید خالی دیگر اضافه کنید.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // دسترسی به اسلایدها بر اساس ایندکس.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // ایندکس اسلاید را از یک مرجع دریافت کنید، سپس با ایندکس به آن دسترسی پیدا کنید.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Clone a Slide**
## **کلون کردن اسلاید**

این مثال نشان می‌دهد چگونه یک اسلاید موجود را کلون کنید. اسلاید کلون شده به‌طور خودکار به انتهای مجموعه اسلایدها اضافه می‌شود.

```csharp
static void CloneSlide()
{
    // به‌طور پیش‌فرض، ارائه یک اسلاید خالی دارد.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // اسلاید اول را کلون کنید؛ این اسلاید در انتهای ارائه اضافه خواهد شد.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // ایندکس اسلاید کلون شده 1 است (اسلاید دوم در ارائه).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Reorder Slides**
## **تغییر ترتیب اسلایدها**

می‌توانید ترتیب اسلایدها را با جابه‌جایی یک اسلاید به ایندکس جدید تغییر دهید. در این حالت، ما اسلاید کلون شده را به اولین موقعیت منتقل می‌کنیم.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // یک کلون از اسلاید اول (به‌صورت پیش‌فرض ایجاد شده) اضافه کنید.
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // اسلاید کلون شده را به موقعیت اول منتقل کنید (دیگران به پایین جابجا می‌شوند).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Remove a Slide**
## **حذف اسلاید**

برای حذف یک اسلاید، به سادگی به آن ارجاع دهید و متد `Remove` را صدا بزنید. این مثال یک اسلاید دوم اضافه می‌کند و سپس اسلاید اصلی را حذف می‌کند، طوری که فقط اسلاید جدید باقی می‌ماند.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // یک اسلاید خالی جدید اضافه کنید علاوه بر اسلاید پیش‌فرض اول.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // اسلاید اول را حذف کنید؛ فقط اسلاید جدید اضافه شده باقی می‌ماند.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```