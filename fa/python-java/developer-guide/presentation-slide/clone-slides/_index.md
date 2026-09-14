---
title: "کپی اسلایدهای ارائه در پایتون"
linktitle: "کپی اسلایدها"
type: docs
weight: 35
url: /fa/python-java/clone-slides/
keywords:
- "کلون اسلاید"
- "کپی اسلاید"
- "ذخیره اسلاید"
- "پاورپوینت"
- "OpenDocument"
- "ارائه"
- "پایتون"
- "Aspose.Slides"
description: "اسلایدهای پاورپوینت را به‌سرعت با Aspose.Slides برای پایتون از طریق جاوا تکرار کنید. مثال‌های کد واضح ما را دنبال کنید تا در چند ثانیه ایجاد PPT را خودکار کنید و کار دستی را حذف کنید."
---
## **مقدمه**

کلونینگ فرایند ساخت یک نسخه دقیق یا شبیه‌سازی از چیزی است. Aspose.Slides برای Python از طریق Java همچنین امکان ساخت یک کپی یا کلون از هر اسلاید را فراهم می‌کند و سپس آن اسلاید کلون‌شده را در ارائه جاری یا هر ارائه باز دیگری وارد می‌کند. فرایند کلون کردن اسلاید یک اسلاید جدید ایجاد می‌کند که می‌تواند توسط توسعه‌دهندگان بدون تغییر اسلاید اصلی اصلاح شود. چند روش مختلف برای کلون‌کردن اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیتی دیگر درون یک ارائه.
- کلون در انتهای یک ارائه دیگر.
- کلون در موقعیتی دیگر در یک ارائه دیگر.
- کلون همراه با اسلاید مستر آن به یک ارائه دیگر.

در Aspose.Slides برای Python از طریق Java، مجموعه اسلایدها (مجموعه‌ای از اشیاء [Slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) ) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ارائه می‌شود، متدهای [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) و [insertClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#insertClone) را برای انجام انواع کلون‌کردن اسلایدهای فوق فراهم می‌کند.

## **کلون یک اسلاید در انتهای یک ارائه**

اگر می‌خواهید یک اسلاید را کلون کنید و سپس آن را در همان فایل ارائه در انتهای اسلایدهای موجود استفاده کنید، مطابق مراحل زیر از متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. شیء [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) را با ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ارائه شده است، دریافت کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) ارائه شده است فراخوانی کنید و اسلایدی که باید کلون شود را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) پاس دهید.
1. فایل ارائهٔ اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید (که در اولین موقعیت – ایندکس صفر – ارائه قرار دارد) را به انتهای ارائه کلون کرده‌ایم.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # کلون اسلاید موردنظر به انتهای مجموعه اسلایدها در همان ارائه
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # ذخیرهٔ ارائهٔ اصلاح‌شده روی دیسک
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **کلون یک اسلاید به موقعیت دیگری درون یک ارائه**

اگر می‌خواهید یک اسلاید را کلون کنید và سپس آن را در همان فایل ارائه اما در موقعیت متفاوتی استفاده کنید، از متد [insertClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#insertClone) استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به مجموعه اسلایدها که توسط متد [getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بازگردانده می‌شود، دریافت کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#insertClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) ارائه شده است فراخوانی کنید và اسلایدی که باید کلون شود را همراه با ایندکس موقعیت جدید به عنوان پارامتر به متد [insertClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#insertClone) پاس دهید.
1. فایل ارائهٔ اصلاح‌شده را به صورت PPTX بنویسید.

در مثال زیر، یک اسلاید (که در ایندکس 1 – موقعیت 2 – ارائه قرار دارد) را به ایندکس 2 – موقعیت 3 – ارائه کلون کرده‌ایم.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # دریافت مجموعه اسلایدها در ارائه
    slides = presentation.getSlides()

    # کلون اسلاید موردنظر به ایندکس مشخص شده در همان ارائه
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # ذخیرهٔ ارائهٔ اصلاح‌شده بر روی دیسک
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **کلون یک اسلاید در انتهای یک ارائه دیگر**

اگر نیاز دارید یک اسلاید را از یک ارائه کلون کرده و در فایل ارائهٔ دیگری، در انتهای اسلایدهای موجود استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید که شامل ارائه‌ای است که اسلاید از آن کلون خواهد شد.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید که شامل ارائهٔ مقصد است که اسلاید به آن اضافه خواهد شد.
1. شیء [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) را با ارجاع به مجموعه اسلایدهایی که توسط متد [getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ارائهٔ مقصد بازگردانده می‌شود، دریافت کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) ارائه شده است فراخوانی کنید و اسلاید از ارائهٔ منبع را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید (از ایندکس 0 از ارائهٔ منبع) را به انتهای ارائهٔ مقصد کلون کرده‌ایم.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # نمونه‌سازی کلاس Presentation برای PPTX مقصد (جایی که اسلاید باید کلون شود)
    destination_presentation = Presentation()
    try:
        # کلون اسلاید موردنظر از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # ذخیرهٔ ارائه مقصد بر روی دیسک
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **کلون یک اسلاید به موقعیت دیگری در یک ارائه دیگر**

اگر نیاز دارید یک اسلاید را از یک ارائه کلون کرده و در یک فایل ارائهٔ دیگر، در موقعیت خاصی استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید که شامل ارائهٔ منبع باشد که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید که شامل ارائه‌ای باشد که اسلاید به آن اضافه می‌شود.
1. شیء [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) را با ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ارائهٔ مقصد ارائه شده است، دریافت کنید.
1. متد [insertClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#insertClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) ارائه شده است فراخوانی کنید và اسلاید از ارائهٔ منبع را همراه با موقعیت دلخواه به عنوان پارامتر به متد [insertClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#insertClone) پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید (از ایندکس صفر ارائهٔ منبع) را به ایندکس 1 (موقعیت 2) ارائهٔ مقصد کلون کرده‌ایم.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # نمونه‌سازی کلاس Presentation برای PPTX مقصد (جایی که اسلاید باید کلون شود)
    destination_presentation = Presentation()
    try:
        # کلون اسلاید موردنظر از ارائه منبع به ایندکس مشخص شده در ارائه مقصد
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # ذخیرهٔ ارائه مقصد بر روی دیسک
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **کلون یک اسلاید همراه با اسلاید مستر آن به یک ارائه دیگر**

اگر نیاز دارید یک اسلاید همراه با اسلاید مستر آن را از یک ارائه کلون کرده و در یک ارائه دیگر استفاده کنید، ابتدا باید اسلاید مستر موردنظر را از ارائهٔ منبع به ارائهٔ مقصد کلون کنید. سپس هنگام کلون کردن اسلاید، از اسلاید مستر کلون‌شده استفاده کنید. متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) انتظار دارد اسلاید مستر از ارائهٔ مقصد باشد نه از منبع. برای کلون کردن اسلاید همراه با مستر، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید که شامل ارائهٔ منبع باشد که اسلاید از آن کلون می‌شود.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید که شامل ارائهٔ مقصد باشد که اسلاید به آن کلون خواهد شد.
1. به اسلایدی که باید کلون شود به همراه اسلاید مستر آن دسترسی پیدا کنید.
1. شیء [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/) را با ارجاع به مجموعه Masters که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ارائهٔ مقصد ارائه شده است، دریافت کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/#addClone) را که توسط شیء [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/) ارائه شده است فراخوانی کنید và مستر از فایل PPTX منبع که باید کلون شود را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslidecollection/#addClone) پاس دهید.
1. شیء [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) را با ارجاع به مجموعه Slides که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ارائهٔ مقصد ارائه شده است، دریافت کنید.
1. متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) را که توسط شیء [SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/) ارائه شده است فراخوانی کنید và اسلاید از ارائهٔ منبع که باید کلون شود و اسلاید مستر را به عنوان پارامتر به متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone) پاس دهید.
1. فایل ارائهٔ مقصد اصلاح‌شده را بنویسید.

در مثال زیر، یک اسلاید همراه با مستر (در ایندکس صفر ارائهٔ منبع) را به انتهای ارائهٔ مقصد با استفاده از مستر اسلاید منبع کلون کرده‌ایم.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه منبع
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # نمونه‌سازی کلاس Presentation برای ارائه مقصد (جایی که اسلاید باید کلون شود)
    destination_presentation = Presentation()
    try:
        # نمونه‌سازی اسلاید از مجموعه اسلایدهای ارائه منبع به همراه
        # اسلاید مستر
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # کلون اسلاید مستر موردنظر از ارائه منبع به مجموعه مسترهای
        # ارائه مقصد
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # کلون اسلاید موردنظر از ارائه منبع با مستر موردنظر به انتهای
        # مجموعه اسلایدها در ارائه مقصد
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # ذخیرهٔ ارائه مقصد بر روی دیسک
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **کلون یک اسلاید در انتهای یک بخش مشخص**

اگر می‌خواهید یک اسلاید را کلون کنید و سپس آن را در همان فایل ارائه اما در بخش متفاوتی استفاده کنید، سپس از متد **[addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addClone)** که توسط کلاس **[SlideCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/)** ارائه می‌شود استفاده کنید. Aspose.Slides برای Python از طریق Java امکان کلون کردن اسلاید از بخش اول و سپس وارد کردن آن اسلاید کلون‌شده به بخش دوم همان ارائه را فراهم می‌کند.

قطعه کد زیر نشان می‌دهد چگونه یک اسلاید را کلون کرده و اسلاید کلون‌شده را در یک بخش مشخص وارد کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # ذخیرهٔ ارائه مقصد بر روی دیسک
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اطمینان از هم‌خوانی اندازه اسلاید**

هنگام کلون کردن اسلایدها به ارائهٔ دیگری، مطمئن شوید اندازه اسلاید ارائهٔ مقصد همانند منبع باشد. اگر اندازه اسلایدها متفاوت باشد، Aspose.Slides به‌صورت خودکار شکل‌های کلون‌شده را مقیاس‌بندی نمی‌کند—مختصات و ابعاد اصلی آن‌ها حفظ می‌شود که ممکن است باعث شود محتوا نامرتب ظاهر شود یا از مرزهای اسلاید فراتر رود.

قبل از کلون کردن مستر و اسلاید می‌توانید اندازه اسلاید ارائهٔ مقصد را با منبع همسان کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

این کار را قبل از کلون کردن مستر و اسلاید انجام دهید.

## **سوالات متداول**

**آیا یادداشت‌های سخنران و نظرات مرورگر کلون می‌شوند؟**

بله. صفحه یادداشت‌ها و نظرات مرور در کلون گنجانده می‌شوند. اگر نمی‌خواهید آن‌ها را داشته باشید، پس از وارد کردن [آنها را حذف کنید](/slides/fa/python-java/presentation-notes/).

**چگونه نمودارها و منابع داده آن‌ها مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های توکار کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کتاب‌کار توکار OLE) لینک داشته باشد، آن لینک به‌عنوان یک [OLE object](/slides/fa/python-java/manage-ole/) حفظ می‌شود. پس از انتقال بین فایل‌ها، موجودیت داده‌ها و رفتار به‌روزرسانی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در یک ایندکس اسلاید خاص درج کنید و آن را در یک [section](/slides/fa/python-java/slide-section/) انتخابی قرار دهید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل کنید.