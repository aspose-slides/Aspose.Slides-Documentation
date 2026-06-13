---
title: "انیمیشن نمودارهای پاورپوینت در PHP"
linktitle: "نمودارهای انیمیشنی"
type: docs
weight: 80
url: /fa/php-java/animated-charts/
keywords:
- "نمودار"
- "نمودار انیمیشنی"
- "انیمیشن نمودار"
- "سری نمودار"
- "دسته‌بندی نمودار"
- "عنصر سری"
- "عنصر دسته"
- "افزودن افکت"
- "نوع افکت"
- "پاورپوینت"
- "ارائه"
- "PHP"
- "Aspose.Slides"
description: "نمودارهای انیمیشنی خیره‌کننده را با Aspose.Slides برای PHP از طریق Java ایجاد کنید. ارائه‌ها را با تصاویر پویا در فایل‌های PPT و PPTX ارتقا دهید — همین حالا شروع کنید."
---
## **مقدمه**

Aspose.Slides برای PHP از طریق Java از انیمیشن عناصر نمودار پشتیبانی می‌کند. **سری‌ها**، **دسته‌ها**، **عناصر سری**، **عناصر دسته** می‌توانند با متد [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/#addEffect) و دو enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/EffectChartMajorGroupingType) و [EffectChartMinorGroupingType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/EffectChartMinorGroupingType) انیمیشن شوند.

## **انیمیشن سری نمودار**
اگر می‌خواهید یک سری نمودار را انیمیشن کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شیء نمودار را دریافت کنید.
1. سری را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

در مثال زیر، ما سری نمودار را انیمیشن دادیم.

```php
  # نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # دریافت مرجع شیء نمودار
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # انیمیشن سری
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # نوشتن ارائه اصلاح‌شده به دیسک
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **انیمیشن دسته نمودار**
اگر می‌خواهید یک دسته نمودار را انیمیشن کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شیء نمودار را دریافت کنید.
1. دسته را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

در مثال زیر، ما دسته نمودار را انیمیشن دادیم.

```php
  # نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **انیمیشن در عنصر سری**
اگر می‌خواهید عناصر سری را انیمیشن کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شیء نمودار را دریافت کنید.
1. عناصر سری را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

در مثال زیر، ما عناصر سری را انیمیشن دادیم.

```php
  # نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # دریافت مرجع شیء نمودار
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # انیمیشن عناصر سری
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # نوشتن فایل ارائه به دیسک
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **انیمیشن در عنصر دسته**
اگر می‌خواهید عناصر دسته را انیمیشن کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شیء نمودار را دریافت کنید.
1. عناصر دسته را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

در مثال زیر، ما عناصر دسته را انیمیشن دادیم.

```php
  # نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # دریافت مرجع شیء نمودار
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # انیمیشن عناصر دسته‌ها
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # نوشتن فایل ارائه به دیسک
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**آیا انواع مختلف افکت (مانند ورود، تأکید، خروج) برای نمودارها همانند شکل‌های معمولی پشتیبانی می‌شود؟**

بله. یک نمودار به عنوان یک شکل در نظر گرفته می‌شود، بنابراین انواع استاندارد افکت‌های انیمیشن شامل ورود، تأکید و خروج را پشتیبانی می‌کند و کنترل کامل از طریق نوار زمان اسلاید و توالی‌های انیمیشن فراهم می‌شود.

**آیا می‌توانم انیمیشن نمودار را با انتقال اسلاید ترکیب کنم؟**

بله. [Transitions](/slides/fa/php-java/slide-transition/) بر روی اسلاید اعمال می‌شود، در حالی که افکت‌های انیمیشن بر روی اشیاء داخل اسلاید اعمال می‌شوند. می‌توانید هر دو را در همان ارائه استفاده کنید و به طور مستقل کنترل کنید.

**آیا انیمیشن‌های نمودار هنگام ذخیره به PPTX حفظ می‌شوند؟**

بله. هنگام [save to PPTX](/slides/fa/php-java/save-presentation/)، تمام افکت‌های انیمیشن و ترتیب آن‌ها حفظ می‌شود زیرا بخشی از مدل انیمیشن بومی ارائه هستند.

**آیا می‌توانم انیمیشن‌های موجود در یک ارائه را خوانده و آنها را اصلاح کنم؟**

بله. API دسترسی به نوار زمان اسلاید، توالی‌ها و افکت‌ها را فراهم می‌کند، به طوری که می‌توانید انیمیشن‌های موجود در نمودارها را بررسی و بدون نیاز به ایجاد مجدد همه چیز، تنظیم کنید.

**آیا می‌توانم ویدئویی تولید کنم که شامل انیمیشن‌های نمودار باشد با استفاده از Aspose.Slides؟**

بله. می‌توانید [export a presentation to video](/slides/fa/php-java/convert-powerpoint-to-video/) کنید، در حالی که انیمیشن‌ها حفظ می‌شوند و می‌توانید زمان‌بندی‌ها و سایر تنظیمات خروجی را پیکربندی کنید تا کلیپ نهایی بازپخش انیمیشن‌ها را نشان دهد.