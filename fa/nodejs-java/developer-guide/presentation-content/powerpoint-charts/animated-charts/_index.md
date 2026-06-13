---
title: انیمیشن نمودارهای پاورپوینت در جاوا اسکریپت
linktitle: نمودارهای انیمیشنی
type: docs
weight: 80
url: /fa/nodejs-java/animated-charts/
keywords:
- نمودار
- نمودار انیمیشنی
- انیمیشن نمودار
- سری نمودار
- دسته‌بندی نمودار
- عنصر سری
- عنصر دسته‌بندی
- افزودن افکت
- نوع افکت
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نمودارهای انیمیشنی خیره‌کننده را در جاوا اسکریپت با Aspose.Slides برای Node.js ایجاد کنید. ارائه‌ها را با تصاویر پویا در فایل‌های PPT و PPTX تقویت کنید—همین حالا شروع کنید."
---
## **مقدمه**

Aspose.Slides for Node.js via Java از انیمیشن‌گذاری عناصر نمودار پشتیبانی می‌کند. **Series**, **Categories**, **Series Elements**, **Categories Elements** می‌توانند با روش [Sequence.addEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#addEffect) و دو enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) و [EffectChartMinorGroupingType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effectchartminorgroupingtype/) انیمیت شوند.

## **انیمیشن سری نمودار**
اگر می‌خواهید یک سری نمودار را انیمیت کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را دریافت کنید.
1. سری را انیمیت کنید.
1. فایل ارائه را بر روی دیسک بنویسید.

در مثال زیر، ما سری نمودار را انیمیت کرده‌ایم.

```javascript
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // دریافت مرجع شی نمودار
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // انیمیت کردن سری‌ها
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // ذخیره‌سازی ارائه تغییر یافته بر روی دیسک
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **انیمیشن دسته‌بندی نمودار**
اگر می‌خواهید یک دسته‌بندی نمودار را انیمیت کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را دریافت کنید.
1. دسته‌بندی را انیمیت کنید.
1. فایل ارائه را بر روی دیسک بنویسید.

در مثال زیر، ما دسته‌بندی نمودار را انیمیت کرده‌ایم.

```javascript
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    pres.save("Sample_Animation_C.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **انیمیشن در عنصر سری**
اگر می‌خواهید عناصر سری را انیمیت کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را دریافت کنید.
1. عناصر سری را انیمیت کنید.
1. فایل ارائه را بر روی دیسک بنویسید.

در مثال زیر، ما عناصر سری را انیمیت کرده‌ایم.

```javascript
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // دریافت مرجع شی نمودار
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // انیمیت کردن عناصر سری
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // ذخیره‌سازی فایل ارائه بر روی دیسک
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **انیمیشن در عنصر دسته‌بندی**
اگر می‌خواهید عناصر دسته‌بندی را انیمیت کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را دریافت کنید.
1. عناصر دسته‌بندی را انیمیت کنید.
1. فایل ارائه را بر روی دیسک بنویسید.

در مثال زیر، ما عناصر دسته‌بندی را انیمیت کرده‌ایم.

```javascript
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // دریافت مرجع شی نمودار
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // انیمیت کردن عناصر دسته‌بندی
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // ذخیره‌سازی فایل ارائه بر روی دیسک
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سؤالات متداول**

**آیا انواع مختلف افکت (مانند ورود، تأکید، خروج) برای نمودارها مانند اشکال معمولی پشتیبانی می‌شوند؟**

بله. یک نمودار همچون یک شکل در نظر گرفته می‌شود، بنابراین از انواع استاندارد افکت‌های انیمیشن شامل ورود، تأکید و خروج پشتیبانی می‌کند و کنترل کامل از طریق جدول زمانی اسلاید و توالی‌های انیمیشن فراهم می‌شود.

**آیا می‌توانم انیمیشن نمودار را با انتقال‌های اسلاید ترکیب کنم؟**

بله. [Transitions](/slides/fa/nodejs-java/slide-transition/) بر روی اسلاید اعمال می‌شوند، در حالی که افکت‌های انیمیشن بر روی اشیاء داخل اسلاید اعمال می‌شوند. می‌توانید هر دو را همزمان در یک ارائه استفاده کنید و به‌صورت مستقل کنترل کنید.

**آیا انیمیشن‌های نمودار هنگام ذخیره به PPTX حفظ می‌شوند؟**

بله. هنگامی که شما [save to PPTX](/slides/fa/nodejs-java/save-presentation/) می‌کنید، تمام افکت‌های انیمیشن و ترتیب آن‌ها حفظ می‌شود زیرا بخشی از مدل بومی انیمیشن ارائه هستند.

**آیا می‌توانم انیمیشن‌های موجود در یک ارائه را بخوانم و آن‌ها را ویرایش کنم؟**

بله. API دسترسی به جدول زمانی اسלاید، توالی‌ها و افکت‌ها را فراهم می‌کند و به شما امکان می‌دهد انیمیشن‌های موجود نمودار را بررسی و بدون نیاز به بازسازی کامل، آن‌ها را تنظیم کنید.

**آیا می‌توانم ویدئویی تولید کنم که شامل انیمیشن‌های نمودار باشد با استفاده از Aspose.Slides؟**

بله. می‌توانید [export a presentation to video](/slides/fa/nodejs-java/convert-powerpoint-to-video/) کنید در حالی که انیمیشن‌ها حفظ می‌شوند، زمان‌بندی‌ها و سایر تنظیمات خروجی را پیکربندی کنید تا کلیپ نهایی بازپخش انیمیشن شده را نشان دهد.