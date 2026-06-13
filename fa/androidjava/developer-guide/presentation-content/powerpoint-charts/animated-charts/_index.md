---
title: انیمیشن نمودارهای PowerPoint در اندروید
linktitle: نمودارهای انیمیشنی
type: docs
weight: 80
url: /fa/androidjava/animated-charts/
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
- Android
- Java
- Aspose.Slides
description: "نمودارهای انیمیشنی خیره‌کننده را در جاوا با Aspose.Slides برای اندروید ایجاد کنید. ارائه‌ها را با تصاویر پویا در فایل‌های PPT و PPTX تقویت کنید—همین حالا شروع کنید."
---
## **معرفی**

Aspose.Slides برای اندروید از طریق جاوا از انیمیشن عناصر نمودار پشتیبانی می‌کند. **Series**, **Categories**, **Series Elements**, **Categories Elements** می‌توانند با متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) و دو مقدار enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/EffectChartMajorGroupingType) و [EffectChartMinorGroupingType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/EffectChartMinorGroupingType) انیمیشن شوند.

## **انیمیشن سری نمودار**
اگر می‌خواهید یک سری نمودار را انیمیشن کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شیء نمودار را دریافت کنید.
1. سری را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

در مثال زیر، ما سری نمودار را انیمیشن کردیم.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // دریافت مرجع شیء نمودار
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // انیمیشن سری
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // نوشتن ارائهٔ تغییر یافته روی دیسک
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **انیمیشن دسته نمودار**
اگر می‌خواهید یک دسته نمودار را انیمیشن کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شیء نمودار را دریافت کنید.
1. دسته را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

در مثال زیر، ما دسته نمودار را انیمیشن کردیم.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **انیمیشن در عنصر سری**
اگر می‌خواهید عناصر سری را انیمیشن کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شیء نمودار را دریافت کنید.
1. عناصر سری را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

در مثال زیر، ما عناصر سری را انیمیشن کردیم.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // دریافت مرجع شیء نمودار
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // انیمیشن عناصر سری
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // نوشتن فایل ارائه روی دیسک 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **انیمیشن در عنصر دسته**
اگر می‌خواهید عناصر دسته را انیمیشن کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شیء نمودار را دریافت کنید.
1. عناصر دسته را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

در مثال زیر، ما عناصر دسته را انیمیشن کردیم.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // دریافت مرجع شیء نمودار
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // انیمیشن عناصر دسته‌ها
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // نوشتن فایل ارائه روی دیسک
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا انواع مختلف اثر (مانند ورودی، تأکید، خروج) برای نمودارها همانند اشکال عادی پشتیبانی می‌شوند؟**

بله. یک نمودار به عنوان یک شکل در نظر گرفته می‌شود، بنابراین انواع استاندارد اثرهای انیمیشن، از جمله ورودی، تأکید و خروج را پشتیبانی می‌کند و کنترل کامل از طریق جدول زمانی اسلاید و توالی‌های انیمیشن فراهم می‌شود.

**آیا می‌توانم انیمیشن نمودار را با انتقال اسلاید ترکیب کنم؟**

بله. [Transitions](/slides/fa/androidjava/slide-transition/) به اسلاید اعمال می‌شوند، در حالی که اثرهای انیمیشن به اشیاء موجود در اسلاید اعمال می‌شوند. می‌توانید هر دو را در یک ارائه استفاده کنید و به طور مستقل کنترل کنید.

**آیا انیمیشن‌های نمودار هنگام ذخیره به PPTX حفظ می‌شوند؟**

بله. هنگامی که شما [save to PPTX](/slides/fa/androidjava/save-presentation/) را انجام می‌دهید، تمام اثرهای انیمیشن و ترتیب آنها حفظ می‌شوند زیرا بخشی از مدل انیمیشن بومی ارائه هستند.

**آیا می‌توانم انیمیشن‌های موجود نمودار را از یک ارائه بخوانم و آنها را اصلاح کنم؟**

بله. API دسترسی به جدول زمانی اسلاید، توالی‌ها و اثرها را فراهم می‌کند، به شما امکان می‌دهد انیمیشن‌های موجود نمودار را بررسی کنید و بدون نیاز به بازسازی کامل، آنها را تنظیم کنید.

**آیا می‌توانم ویدئویی تولید کنم که شامل انیمیشن‌های نمودار باشد با استفاده از Aspose.Slides؟**

بله. می‌توانید [export a presentation to video](/slides/fa/androidjava/convert-powerpoint-to-video/) کنید در حالی که انیمیشن‌ها حفظ می‌شوند، زمان‌بندی‌ها و سایر تنظیمات خروجی را پیکربندی کنید تا کلیپ نهایی بازپخش انیمیشن‌شده را نشان دهد.