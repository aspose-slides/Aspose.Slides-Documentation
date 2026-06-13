---
title: "پویاسازی نمودارهای پاورپوینت در پایتون"
linktitle: "نمودارهای انیمیشن‌شده"
type: docs
weight: 80
url: /fa/python-net/animated-charts/
keywords:
- "نمودار"
- "نمودار انیمیشن‌شده"
- "انیمیشن نمودار"
- "سری نمودار"
- "دسته‌بندی نمودار"
- "عنصر سری"
- "عنصر دسته‌بندی"
- "افزودن افکت"
- "نوع افکت"
- "پاورپوینت"
- "ارائه"
- "پایتون"
- "Aspose.Slides"
description: "نمودارهای انیمیشن‌شده و خیره‌کننده‌ای را در پایتون با Aspose.Slides ایجاد کنید. ارائه‌ها را با تصاویر پویا در فایل‌های PPT، PPTX و ODP ارتقا دهید—همین حالا شروع کنید."
---
## **معرفی**

Aspose.Slides for Python via .NET از انیمیشن عناصر نمودار پشتیبانی می‌کند. **Series**، **Categories**، **Series Elements**، **Categories Elements** می‌توانند با روش [ISequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/isequence/) و دو enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) و [EffectChartMinorGroupingType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effectchartminorgroupingtype/) انیمیت شوند.
## **انیمیشن سری نمودار**
اگر می‌خواهید یک سری نمودار را انیمیت کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را به دست آورید.
1. سری را انیمیت کنید.
1. فایل ارائه را روی دیسک ذخیره کنید.

در مثال زیر، ما سری نمودار را انیمیت کردیم.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که فایل ارائه را نمایندگی می‌کند 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # دریافت ارجاع شی نمودار
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # انیمیت کردن سری‌ها
    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectType.FADE, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectChartMajorGroupingType.BY_SERIES, 0, 
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 1,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 2,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 3,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # نوشتن ارائه‌ی تغییر یافته روی دیسک 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```


## **انیمیشن دسته‌بندی نمودار**
اگر می‌خواهید یک دسته‌بندی نمودار را انیمیت کنید، کد را طبق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را به دست آورید.
1. دسته‌بندی را انیمیت کنید.
1. فایل ارائه را روی دیسک ذخیره کنید.

در مثال زیر، ما دسته‌بندی نمودار را انیمیت کردیم.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # دریافت ارجاع به شی نمودار
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # انیمیت کردن عناصر دسته‌بندی‌ها
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # نوشتن فایل ارائه روی دیسک
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```


## **انیمیشن در عنصر سری**
اگر می‌خواهید عناصر سری را انیمیت کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را به دست آورید.
1. عناصر سری را انیمیت کنید.
1. فایل ارائه را روی دیسک ذخیره کنید.

در مثال زیر، ما عناصر سری را انیمیت کرده‌ایم.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# بارگذاری یک ارائه
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # دریافت مرجع شی نمودار
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # انیمیت کردن عناصر سری
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # نوشتن فایل ارائه روی دیسک 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```


## **انیمیشن در عنصر دسته‌بندی**
اگر می‌خواهید عناصر دسته‌بندی را انیمیت کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع شی نمودار را به دست آورید.
1. عناصر دسته‌بندی را انیمیت کنید.
1. فایل ارائه را روی دیسک ذخیره کنید.

در مثال زیر، ما عناصر دسته‌بندی را انیمیت کرده‌ایم.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # دریافت مرجع شی نمودار
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # انیمیت کردن عناصر دسته‌بندی‌ها
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # نوشتن فایل ارائه روی دیسک
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا انواع مختلف افکت (مانند ورود، تأکید، خروج) برای نمودارها همانند اشکال عادی پشتیبانی می‌شود؟**

بله. یک نمودار به عنوان یک شکل در نظر گرفته می‌شود، بنابراین انواع استاندارد افکت‌های انیمیشن شامل ورود، تأکید و خروج را پشتیبانی می‌کند و کنترل کامل از طریق جدول زمانی اسلاید و توالی‌های انیمیشن فراهم می‌شود.

**آیا می‌توانم انیمیشن نمودار را با انتقالات اسلاید ترکیب کنم؟**

بله. [Transitions](/slides/fa/python-net/slide-transition/) بر روی اسلاید اعمال می‌شود، در حالی که افکت‌های انیمیشن بر روی اشیاء داخل اسلاید اعمال می‌شوند. می‌توانید هر دو را همزمان در یک ارائه استفاده کنید و به‌صورت مستقل آنها را کنترل کنید.

**آیا انیمیشن‌های نمودار هنگام ذخیره به PPTX حفظ می‌شوند؟**

بله. وقتی شما [save to PPTX](/slides/fa/python-net/save-presentation/) می‌کنید، تمام افکت‌های انیمیشن و ترتیب آنها حفظ می‌شوند زیرا بخشی از مدل بومی انیمیشن ارائه هستند.

**آیا می‌توانم انیمیشن‌های موجود نمودار را از یک ارائه بخوانم و آنها را تغییر دهم؟**

بله. [API](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/) دسترسی به جدول زمانی اسلاید، توالی‌ها و افکت‌ها را فراهم می‌کند، که امکان بررسی انیمیشن‌های موجود نمودار و تنظیم آنها بدون نیاز به ساخت مجدد از ابتدا را می‌دهد.

**آیا می‌توانم با استفاده از Aspose.Slides for Python via .NET یک ویدیو شامل انیمیشن‌های نمودار تولید کنم؟**

بله. می‌توانید [export a presentation to video](/slides/fa/python-net/convert-powerpoint-to-video/) کنید در حالی که انیمیشن‌ها حفظ می‌شوند، زمان‌بندی‌ها و سایر تنظیمات صادرات را پیکربندی کنید تا کلیپ نهایی بازپخش انیمیشنی را نشان دهد.