---
title: انیمیشن نمودارهای پاورپوینت در .NET
linktitle: نمودارهای متحرک
type: docs
weight: 80
url: /fa/net/animated-charts/
keywords:
- نمودار
- نمودار انیمیشنی
- انیمیشن نمودار
- سری نمودار
- دسته نمودار
- عنصر سری
- عنصر دسته
- افزودن اثر
- نوع اثر
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نمودارهای انیمیشن جذاب را در .NET با Aspose.Slides ایجاد کنید. ارائه‌ها را با تصاویر پویا در فایل‌های PPT و PPTX تقویت کنید—همین حالا شروع کنید."
---
## **مقدمه**

Aspose.Slides for .NET از انیمیشن عناصر نمودار پشتیبانی می‌کند. **سری‌ها**, **دسته‌ها**, **عناصر سری**, **عناصر دسته** می‌توانند با متد [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/methods/addeffect) و دو نوع enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effectchartmajorgroupingtype) و [EffectChartMinorGroupingType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effectchartminorgroupingtype) انیمیت شوند.

## **انیمیشن سری نمودار**
اگر می‌خواهید یک سری نمودار را انیمیت کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را دریافت کنید.
1. سری را انیمیت کنید.
1. فایل ارائه را بر روی دیسک بنویسید.

در مثال زیر، ما سری‌های نمودار را انیمیت کردیم.

```c#
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // دریافت مرجع شی نمودار
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // انیمیت کردن سری
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
    EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 0,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 1,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 2,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 3,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // نوشتن ارائه اصلاح‌شده بر روی دیسک 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```

## **انیمیشن دسته‌بندی نمودار**
اگر می‌خواهید یک دسته‌بندی نمودار را انیمیت کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را دریافت کنید.
1. دسته‌بندی را انیمیت کنید.
1. فایل ارائه را بر روی دیسک بنویسید.

در مثال زیر، ما دسته‌بندی نمودار را انیمیت کردیم.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // دریافت مرجع شی نمودار
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // انیمیت کردن عناصر دسته‌ها
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // نوشتن فایل ارائه بر روی دیسک
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **انیمیشن در عنصر سری**
اگر می‌خواهید عناصر سری را انیمیت کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را دریافت کنید.
1. عناصر سری را انیمیت کنید.
1. فایل ارائه را بر روی دیسک بنویسید.

در مثال زیر، ما عناصر سری را انیمیت کردیم.

```c#
// بارگذاری یک ارائه
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // دریافت مرجع شی نمودار
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // انیمیت کردن عناصر سری
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // نوشتن فایل ارائه بر روی دیسک 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **انیمیشن در عنصر دسته**
اگر می‌خواهید عناصر دسته‌ها را انیمیت کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را دریافت کنید.
1. عناصر دسته‌ها را انیمیت کنید.
1. فایل ارائه را بر روی دیسک بنویسید.

در مثال زیر، ما عناصر دسته‌ها را انیمیت کردیم.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // دریافت مرجع شی نمودار
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // انیمیت کردن عناصر دسته‌ها
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // نوشتن فایل ارائه بر روی دیسک
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **سؤالات متداول**

**آیا انواع مختلف اثر (مانند ورود، تأکید، خروج) برای نمودارها همانند اشکال عادی پشتیبانی می‌شوند؟**

بله. یک نمودار به‌عنوان یک شکل در نظر گرفته می‌شود، بنابراین انواع استاندارد اثرات انیمیشن، از جمله ورود، تأکید و خروج را پشتیبانی می‌کند و کنترل کامل از طریق جدول زمان‌بندی اسلاید و توالی‌های انیمیشن فراهم می‌شود.

**آیا می‌توانم انیمیشن نمودار را با انتقال اسلاید ترکیب کنم؟**

بله. [Transitions](/slides/fa/net/slide-transition/) بر روی اسلاید اعمال می‌شوند، در حالی که اثرات انیمیشن بر روی اشیاء داخل اسلاید اعمال می‌شوند. می‌توانید هر دو را به‌طور همزمان در یک ارائه استفاده کنید و به‌صورت مستقل کنترل کنید.

**آیا انیمیشن‌های نمودار هنگام ذخیره به PPTX حفظ می‌شوند؟**

بله. وقتی [save to PPTX](/slides/fa/net/save-presentation/) را انجام می‌دهید، تمام اثرات انیمیشن و ترتیب آن‌ها حفظ می‌شوند زیرا بخشی از مدل بومی انیمیشن ارائه هستند.

**آیا می‌توانم انیمیشن‌های موجود در نمودار را از یک ارائه بخوانم و آن‌ها را تغییر دهم؟**

بله. [API](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/) دسترسی به جدول‌زمانی اسلاید، توالی‌ها و اثرات را فراهم می‌کند، به‌طوری که می‌توانید انیمیشن‌های موجود در نمودار را بررسی و بدون نیاز به بازسازی کامل، آن‌ها را تنظیم کنید.

**آیا می‌توانم با استفاده از Aspose.Slides یک ویدئو تولید کنم که شامل انیمیشن‌های نمودار باشد؟**

بله. می‌توانید [export a presentation to video](/slides/fa/net/convert-powerpoint-to-video/) را انجام دهید در حالی که انیمیشن‌ها حفظ می‌شوند، زمان‌بندی‌ها و سایر تنظیمات خروجی را پیکربندی کنید تا کلیپ نهایی بازپخش انیمیشن را نشان دهد.