---
title: "انیمیشن نمودارهای پاورپوینت در جاوا"
linktitle: "نمودارهای انیمیشن‌شده"
type: docs
weight: 80
url: /fa/java/animated-charts/
keywords:
  - "نمودار"
  - "نمودار انیمیشن‌شده"
  - "انیمیشن نمودار"
  - "سری نمودار"
  - "دسته‌بندی نمودار"
  - "عنصر سری"
  - "عنصر دسته‌بندی"
  - "افزودن اثر"
  - "نوع اثر"
  - "پاورپوینت"
  - "ارائه"
  - "جاوا"
  - "Aspose.Slides"
description: "نمودارهای انیمیشن‌دار شگفت‌انگیز را در جاوا با Aspose.Slides ایجاد کنید. ارائه‌ها را با تصاویر پویا در فایل‌های PPT و PPTX تقویت کنید—همین حالا شروع کنید."
---
## **مقدمه**

Aspose.Slides for Java از انیمیشن عناصر نمودار پشتیبانی می‌کند. **Series**, **Categories**, **Series Elements**, **Categories Elements** می‌توانند با متد [ISequence.addEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) و دو مقدار enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/EffectChartMajorGroupingType) و [EffectChartMinorGroupingType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/EffectChartMinorGroupingType) انیمیشن شوند.

## **انیمیشن سری نمودار**
اگر می‌خواهید یک سری نمودار را انیمیشن کنید، کد را مطابق مراحل زیر بنویسید:

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

    // نوشتن ارائه تغییر یافته به دیسک
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **انیمیشن دسته‌بندی نمودار**
اگر می‌خواهید یک دسته‌بندی نمودار را انیمیشن کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شیء نمودار را دریافت کنید.
1. دسته‌بندی را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

در مثال زیر، ما دسته‌بندی نمودار را انیمیشن کردیم.

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
اگر می‌خواهید عناصر سری را انیمیشن کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شیء نمودار را دریافت کنید.
1. عناصر سری را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

در مثال زیر، ما عناصر سری را انیمیشن کرده‌ایم.

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

    // نوشتن فایل ارائه به دیسک 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **انیمیشن در عنصر دسته‌بندی**
اگر می‌خواهید عناصر دسته‌بندی را انیمیشن کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شیء نمودار را دریافت کنید.
1. عناصر دسته‌بندی را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

در مثال زیر، ما عناصر دسته‌بندی را انیمیشن کرده‌ایم.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // دریافت مرجع شیء نمودار
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // انیمیشن عناصر دسته‌بندی‌ها
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

    // نوشتن فایل ارائه به دیسک
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا انواع مختلف اثر (مثلاً ورود، تاکید، خروج) برای نمودارها همانند اشکال معمولی پشتیبانی می‌شود؟**

بله. یک نمودار به عنوان یک شکل در نظر گرفته می‌شود، بنابراین انواع استاندارد اثرهای انیمیشن، از جمله ورود، تاکید و خروج را پشتیبانی می‌کند و کنترل کامل از طریق خط زمان اسلاید و توالی‌های انیمیشن امکان‌پذیر است.

**آیا می‌توانم انیمیشن نمودار را با انتقالات اسلاید ترکیب کنم؟**

بله. [Transitions](/slides/fa/java/slide-transition/) بر روی اسلاید اعمال می‌شوند، در حالی که اثرهای انیمیشن بر روی اشیاء داخل اسلید اعمال می‌شوند. می‌توانید هر دو را در همان ارائه استفاده کنید و به‌صورت مستقل کنترل کنید.

**آیا انیمیشن‌های نمودار هنگام ذخیره‌سازی به PPTX حفظ می‌شوند؟**

بله. وقتی [save to PPTX](/slides/fa/java/save-presentation/) می‌کنید، تمام اثرهای انیمیشن و ترتیب آن‌ها حفظ می‌شود زیرا بخشی از مدل بومی انیمیشن ارائه هستند.

**آیا می‌توانم انیمیشن‌های موجود در یک ارائه را بخوانم و آن‌ها را اصلاح کنم؟**

بله. API دسترسی به خط زمان اسلاید، توالی‌ها و اثرها را فراهم می‌کند و به شما امکان می‌دهد انیمیشن‌های موجود در نمودارها را بررسی و بدون نیاز به بازسازی کامل، تنظیم کنید.

**آیا می‌توانم با استفاده از Aspose.Slides ویدئویی شامل انیمیشن‌های نمودار تولید کنم؟**

بله. می‌توانید [export a presentation to video](/slides/fa/java/convert-powerpoint-to-video/) کنید در حالی که انیمیشن‌ها حفظ می‌شوند، زمان‌بندی‌ها و سایر تنظیمات خروجی را پیکربندی کنید تا کلیپ نهایی انیمیشن‌های اعمال‌شده را نشان دهد.