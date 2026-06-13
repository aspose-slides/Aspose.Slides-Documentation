---
title: انتقال اسلاید
type: docs
weight: 110
url: /fa/net/examples/elements/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- دسترسی به انتقال اسلاید
- حذف انتقال اسلاید
- مدت زمان انتقال
- مثال کد
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "در Aspose.Slides برای .NET، انتقال‌های اسلاید را به‌طور کامل مدیریت کنید: افزودن، سفارشی‌سازی و ترتیب‌گذاری افکت‌ها و مدت‌ها با مثال‌های C# برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه اعمال افکت‌ها و زمان‌بندی‌های انتقال اسلاید را با **Aspose.Slides for .NET** نشان می‌دهد.

## **افزودن انتقال اسلاید**

یک افکت انتقال محو را بر روی اولین اسلاید اعمال کنید.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // یک انتقال محو اعمال کنید.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **دسترسی به انتقال اسلاید**

نوع انتقالی که در حال حاضر به یک اسلاید اختصاص داده شده است را بخوانید.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // دسترسی به نوع انتقال.
    var type = slide.SlideShowTransition.Type;
}
```

## **حذف انتقال اسلاید**

هر افکت انتقالی را با تنظیم نوع به `None` پاک کنید.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // حذف انتقال با تنظیم به None.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **تنظیم مدت زمان انتقال**

مدت زمانی که اسلاید قبل از پیشروی خودکار نمایش داده می‌شود را مشخص کنید.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // در میلی ثانیه
}
```