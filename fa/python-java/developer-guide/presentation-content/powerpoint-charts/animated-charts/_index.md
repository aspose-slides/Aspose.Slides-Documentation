---
title: انیمیشن نمودارهای پاورپوینت در پایتون از طریق جاوا
linktitle: نمودارهای انیمیشن‌شده
type: docs
weight: 80
url: /fa/python-java/animated-charts/
keywords:
- نمودار
- نمودار انیمیشن‌شده
- انیمیشن نمودار
- سری نمودار
- دسته نمودار
- عنصر سری
- عنصر دسته
- افزودن افکت
- نوع افکت
- PowerPoint
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "نمودارهای انیمیشن‌شدهٔ شگفت‌انگیز را در پایتون از طریق جاوا با Aspose.Slides ایجاد کنید. ارائه‌ها را با تصاویر دینامیک در فایل‌های PPT و PPTX تقویت کنید — همین حالا شروع کنید."
---
## **مقدمه**

Aspose.Slides for Python via Java از قابلیت انیمیشن عناصر نمودار پشتیبانی می‌کند. **Series**، **Categories**، **Series Elements** و **Category Elements** می‌توانند با استفاده از روش [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) و دو شمارش: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effectchartmajorgroupingtype/) و [EffectChartMinorGroupingType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effectchartminorgroupingtype/) انیمیت شوند.

## **انیمیشن سری‌های نمودار**

اگر می‌خواهید یک سری نمودار را انیمیشن کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع به شیء نمودار را دریافت کنید.
1. سری را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

مثال زیر انیمیشن سری‌های نمودار را نشان می‌دهد. نمودار در فایل مثال دارای سه سری است، بنابراین برای هر ایندکس از 0 تا 2 یک اثر افزوده می‌شود. Aspose.Slides ایندکس را نسبت به داده‌های نمودار بررسی نمی‌کند و اثری که برای سری‌ای که وجود ندارد اضافه شود، در فایل نوشته می‌شود اما هیچ انیمیشنی ندارد — ایندکس را زیر تعداد سری‌های نمودار خود نگه دارید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# ارائه را بارگذاری کنید.
presentation = Presentation("ExistingChart.pptx")
try:
    # مرجع به شیء نمودار را دریافت کنید.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # عناصر نمودار را انیمیشن کنید.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # ارائهٔ اصلاح‌شده را روی دیسک ذخیره کنید.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **انیمیشن دسته‌های نمودار**

اگر می‌خواهید یک دسته نمودار را انیمیشن کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع به شیء نمودار را دریافت کنید.
1. دسته را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

مثال زیر انیمیشن دسته‌های نمودار را نشان می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# ارائه را بارگذاری کنید.
presentation = Presentation("ExistingChart.pptx")
try:
    # مرجع به شیء نمودار را دریافت کنید.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # عناصر نمودار را انیمیشن کنید.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # ارائهٔ اصلاح‌شده را روی دیسک ذخیره کنید.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **انیمیشن در یک عنصر سری**

اگر می‌خواهید عناصر سری را انیمیشن کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع به شیء نمودار را دریافت کنید.
1. عناصر سری را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

مثال زیر عناصر سری را انیمیشن می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpue.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# ارائه را بارگذاری کنید.
presentation = Presentation("ExistingChart.pptx")
try:
    # مرجع به شیء نمودار را دریافت کنید.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # عناصر نمودار را انیمیشن کنید.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # ارائهٔ اصلاح‌شده را روی دیسک ذخیره کنید.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **انیمیشن در یک عنصر دسته**

اگر می‌خواهید عناصر دسته را انیمیشن کنید، کد را مطابق مراحل زیر بنویسید:

1. یک ارائه را بارگذاری کنید.
1. مرجع به شیء نمودار را دریافت کنید.
1. عناصر دسته را انیمیشن کنید.
1. فایل ارائه را روی دیسک بنویسید.

مثال زیر عناصر دسته را انیمیشن می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# ارائه را بارگذاری کنید.
presentation = Presentation("ExistingChart.pptx")
try:
    # مرجع به شیء نمودار را دریافت کنید.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # عناصر نمودار را انیمیشن کنید.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # ارائهٔ اصلاح‌شده را روی دیسک ذخیره کنید.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا انواع مختلف افکت (مثلاً ورود، تأکید، خروج) برای نمودارها همانند اشکال عادی پشتیبانی می‌شود؟**

بله. یک نمودار به عنوان یک شکل در نظر گرفته می‌شود، بنابراین انواع استاندارد افکت‌های انیمیشن، شامل ورود، تأکید و خروج، را پشتیبانی می‌کند و کنترل کامل از طریق زمان‌بندی اسلاید و توالی‌های انیمیشن فراهم می‌شود.

**آیا می‌توانم انیمیشن نمودار را با انتقال‌های اسلاید ترکیب کنم؟**

بله. [Transitions](/slides/fa/python-java/slide-transition/) بر روی اسلاید اعمال می‌شود، در حالی که افکت‌های انیمیشن بر روی اشیاء موجود در اسلاید اعمال می‌شوند. می‌توانید هر دو را در یک ارائه استفاده کنید و به‌صورت جداگانه کنترل کنید.

**آیا انیمیشن‌های نمودار هنگام ذخیره به فرمت PPTX حفظ می‌شوند؟**

بله. زمانی که شما [save to PPTX](/slides/fa/python-java/save-presentation/) می‌کنید، تمام افکت‌های انیمیشن و ترتیب آن‌ها حفظ می‌شود زیرا بخشی از مدل بومی انیمیشن ارائه هستند.

**آیا می‌توانم انیمیشن‌های موجود در یک ارائه را بخوانم و آنها را اصلاح کنم؟**

بله. API دسترسی به زمان‌بندی اسلاید، توالی‌ها و افکت‌ها را فراهم می‌کند تا بتوانید انیمیشن‌های موجود در نمودارها را بازبینی و بدون نیاز به ساخت مجدد از ابتدا، تنظیم کنید.

**آیا می‌توانم ویدیویی تولید کنم که شامل انیمیشن‌های نمودار باشد با استفاده از Aspose.Slides؟**

بله. می‌توانید [export a presentation to video](/slides/fa/python-java/convert-powerpoint-to-video/) کنید در حالی که انیمیشن‌ها حفظ می‌شوند، زمان‌بندی‌ها و سایر تنظیمات خروجی را پیکربندی کنید تا کلیپ نهایی بازپخش انیمیشنی را نشان دهد.