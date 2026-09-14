---
title: دسترسی به اسلایدهای ارائه در پایتون
linktitle: دسترسی به اسلاید
type: docs
weight: 20
url: /fa/python-java/access-slide-in-presentation/
keywords:
- دسترسی به اسلاید
- ایندکس اسلاید
- شناسه اسلاید
- موقعیت اسلاید
- تغییر موقعیت
- ویژگی‌های اسلاید
- شماره اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه اسلایدها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق Java دسترسی یافته و مدیریت کنید. با مثال‌های کد بهره‌وری خود را افزایش دهید."
---
## **Overview**

این مقاله شرح می‌دهد که چگونه می‌توان اسلایدها را در یک ارائه با استفاده از Aspose.Slides دسترسی و مدیریت کرد. این مقاله نشان می‌دهد که چگونه اسلایدها را بر اساس ایندکس صفر پایه از مجموعه اسلایدها بازیابی کنید و چگونه با استفاده از روش [getSlideById](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlideById) یک اسلاید را بر اساس شناسهٔ یکتای آن دسترسی پیدا کنید.

همچنین خواهید آموخت که چگونه موقعیت یک اسلاید را با استفاده از روش [setSlideNumber](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#setSlideNumber) تغییر دهید و چگونه شمارهٔ شروع اسلایدها را برای یک ارائه با روش [setFirstSlideNumber](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#setFirstSlideNumber) تعیین کنید. مثال‌ها نشان می‌دهند که چگونه یک ارائه را بارگذاری کنید، مراجع اسلایدها را دریافت کنید، ترتیب یا شماره‌گذاری اسلایدها را به‌روزرسانی کنید و ارائهٔ اصلاح‌شده را ذخیره کنید.

## **Access a Slide by Index**

تمام اسلایدهای یک ارائه به‌صورت عددی بر اساس موقعیت اسلاید، از صفر شروع می‌شوند. اسلاید اول از طریق ایندکس 0 قابل دسترسی است؛ اسلاید دوم از طریق ایندکس 1؛ و غیره.

کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) که نمایانگر یک فایل ارائه است، تمام اسلایدها را به‌صورت یک مجموعهٔ [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) (مجموعه‌ای از اشیاء [Slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/)) در دسترس قرار می‌دهد. این کد پایتون نشان می‌دهد که چگونه یک اسلاید را از طریق ایندکس آن دسترسی پیدا کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
presentation = Presentation("demo.pptx")
try:
    # یک اسلاید را با استفاده از ایندکس آن دسترسی کنید.
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **Access a Slide by ID**

هر اسلاید در یک ارائه دارای یک شناسهٔ یکتا است. می‌توانید از روش [getSlideById](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlideById) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ارائه می‌شود) برای هدف‌گیری آن شناسه استفاده کنید. این کد پایتون نشان می‌دهد که چگونه یک شناسهٔ معتبر برای اسلاید فراهم کنید و آن اسلاید را از طریق روش [getSlideById](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlideById) دسترسی پیدا کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation

# یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
presentation = Presentation("demo.pptx")
try:
    # یک شناسه اسلاید دریافت کنید.
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # اسلاید را از طریق شناسهٔ آن دسترسی کنید.
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **Change the Slide Position**

Aspose.Slides به شما امکان می‌دهد موقعیت یک اسلاید را تغییر دهید. برای مثال می‌توانید مشخص کنید اسلاید اول به اسلاید دوم تبدیل شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلایدی که می‌خواهید موقعیتش را تغییر دهید، از طریق ایندکس آن دریافت کنید.
1. موقعیت جدیدی برای اسلاید از طریق روش [setSlideNumber](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#setSlideNumber) تنظیم کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

این کد پایتون عملی را نشان می‌دهد که در آن اسلاید در موقعیت 1 به موقعیت 2 منتقل می‌شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
presentation = Presentation("Presentation.pptx")
try:
    # اسلایدی که موقعیت آن تغییر خواهد کرد را دریافت کنید.
    slide = presentation.getSlides().get_Item(0)

    # موقعیت جدید برای اسلاید تنظیم کنید.
    slide.setSlideNumber(2)

    # ارائهٔ تغییر یافته را ذخیره کنید.
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اسلاید اول به دوم تبدیل شد؛ اسلاید دوم به اول. هنگام تغییر موقعیت یک اسلاید، اسلایدهای دیگر به‌صورت خودکار تنظیم می‌شوند.

## **Set the Slide Number**

با استفاده از روش [setFirstSlideNumber](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#setFirstSlideNumber) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ارائه می‌شود) می‌توانید شمارهٔ جدیدی برای اسلاید اول یک ارائه تعیین کنید. این عملیات باعث می‌شود شماره‌های دیگر اسلایدها مجدداً محاسبه شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. شمارهٔ اسلاید را دریافت کنید.
1. شمارهٔ اسلاید را تنظیم کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

این کد پایتون عملی را نشان می‌دهد که در آن شمارهٔ اسلاید اول برابر با 10 تنظیم می‌شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
presentation = Presentation("HelloWorld.pptx")
try:
    # شمارهٔ اسلاید را دریافت کنید.
    first_slide_number = presentation.getFirstSlideNumber()

    # شمارهٔ اسلاید را تنظیم کنید.
    presentation.setFirstSlideNumber(10)

    # ارائهٔ تغییر یافته را ذخیره کنید.
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اگر ترجیح می‌دهید اسلاید اول را نادیده بگیرید، می‌توانید شماره‌گذاری را از اسلاید دوم شروع کنید (و شماره‌گذاری برای اسلاید اول را مخفی کنید) به این صورت:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    # شمارهٔ اولین اسلاید ارائه را تنظیم کنید.
    # نمایش شماره اسلاید برای همه اسلایدها.
    # شمارهٔ اسلاید را برای اولین اسلاید مخفی کنید.
    # ارائهٔ تغییر یافته را ذخیره کنید.
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Does the slide number a user sees match the collection’s zero-based index?**

شماره‌ای که روی اسلاید نمایش داده می‌شود می‌تواند از مقدار دلخواهی (مثلاً 10) آغاز شود و لزوماً با ایندکس مطابقت نداشته باشد؛ رابطهٔ آن توسط تنظیمات «شمارهٔ اولین اسلاید» ارائه کنترل می‌شود.

**Do hidden slides affect indexing?**

بله. یک اسلاید مخفی در مجموعه باقی می‌ماند و در ایندکس‌گذاری محاسبه می‌شود؛ «مخفی» فقط به نمایش اشاره دارد، نه به موقعیت آن در مجموعه.

**Does a slide’s index change when other slides are added or removed?**

بله. ایندکس‌ها همیشه ترتیب فعلی اسلایدها را نشان می‌دهند و هنگام درج، حذف یا جابه‌جایی اسلایدها مجدداً محاسبه می‌شوند.