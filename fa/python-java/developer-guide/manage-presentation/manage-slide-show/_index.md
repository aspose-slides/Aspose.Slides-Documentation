---
title: مدیریت نمایش اسلایدها در پایتون از طریق جاوا
linktitle: نمایش اسلاید
type: docs
weight: 90
url: /fa/python-java/manage-slide-show/
keywords:
- نوع نمایش
- ارائه‌شده توسط گوینده
- مرور توسط فرد
- مرور در کیوسک
- گزینه‌های نمایش
- حلقه‌سازی مداوم
- نمایش بدون روایت
- نمایش بدون انیمیشن
- رنگ قلم
- نمایش اسلایدها
- نمایش سفارشی
- پیشبرد اسلایدها
- به‌صورت دستی
- استفاده از زمان‌بندی‌ها
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه نمایش اسلایدها را در Aspose.Slides برای پایتون از طریق جاوا مدیریت کنید. انتقال اسلایدها، زمان‌بندی‌ها و موارد دیگر را به آسانی در فرمت‌های PPT، PPTX و ODP کنترل کنید."
---
## **معرفی**

گزینه‌های **Set Up Show** مایکروسافت پاورپوینت به شما امکان می‌دهند نوع نمایش را انتخاب کنید، حلقه‌سازی را فعال کنید، اسلایدها را برگزینید و نحوه پیشرفت اسلایدها را کنترل کنید. با Aspose.Slides برای Python از طریق Java، می‌توانید این گزینه‌ها را به‌صورت برنامه‌ای پیکربندی کرده و در یک فایل ارائه ذخیره کنید.

متد [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlideShowSettings) یک شیء [SlideShowSettings](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/) را برمی‌گرداند که این گزینه‌ها را کنترل می‌کند. مثال‌های زیر به Aspose.Slides برای Python از طریق Java و یک زمان‌اجرای سازگار Java نیاز دارند. هر مثال JVM را در صورت نیاز راه‌اندازی می‌کند و پس از اتمام ارائه را آزاد می‌سازد.

## **انتخاب نوع نمایش**

متد [SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setSlideShowType) نوع نمایش اسلاید را تعریف می‌کند که می‌تواند نمونه‌ای از کلاس‌های زیر باشد: [PresentedBySpeaker](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/fa/python-java/aspose.slides/browsedbyindividual/), یا [BrowsedAtKiosk](https://reference.aspose.com/slides/fa/python-java/aspose.slides/browsedatkiosk/). استفاده از این متد به شما اجازه می‌دهد ارائه را برای سناریوهای مختلف استفاده، مانند کیوسک‌های خودکار یا ارائه‌های دستی، تنظیم کنید.

کد مثال زیر یک ارائه جدید ایجاد می‌کند و نوع نمایش را به "Browsed by an individual" بدون نمایش نوار اسکرول تنظیم می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **فعال‌سازی گزینه‌های نمایش**

متد [SlideShowSettings.setLoop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setLoop) تعیین می‌کند آیا نمایش اسلاید باید به‌صورت حلقه‌ای تا زمان توقف دستی تکرار شود یا نه. این مورد برای ارائه‌های خودکاری که نیاز به اجرا به‌صورت مداوم دارند مفید است. متد [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setShowNarration) تعیین می‌کند آیا روایت صوتی باید در طول نمایش اسلاید پخش شود یا نه. این برای ارائه‌های خودکاری که شامل راهنمای صوتی برای مخاطب هستند مفید است. متد [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setShowAnimation) تعیین می‌کند آیا انیمیشن‌های اضافه‌شده به اشیای اسلاید باید پخش شوند یا نه. این برای ارائه اثر بصری کامل مفید است.

کد مثال زیر یک ارائه جدید ایجاد می‌کند و نمایش اسلاید را به‌صورت حلقه‌ای فعال می‌سازد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **انتخاب اسلایدهای نمایش داده‌شده**

متد [SlideShowSettings.setSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setSlides) به شما امکان می‌دهد بازه‌ای از اسلایدها را برای نمایش در طول ارائه انتخاب کنید. این برای موقعیتی که فقط بخشی از ارائه نیاز به نمایش دارد نه تمام اسلایدها مفید است. کد مثال زیر یک ارائه با نه اسلاید ایجاد می‌کند و اسلایدهای 2 تا 9 را انتخاب می‌کند. بازه از شماره‌های اسلاید یک‌پایه استفاده می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # نه اسلاید ایجاد می‌کنیم تا بازه انتخاب‌شده وجود داشته باشد.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **کنترل پیشرفت اسلاید**

متد [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setUseTimings) به شما امکان می‌دهد استفاده از زمان‌بندی‌های پیش‌فرض برای هر اسلاید را فعال یا غیرفعال کنید. این برای نمایش خودکار اسلایدها با مدت زمان‌های از پیش تعریف‌شده مفید است. کد مثال زیر یک ارائه جدید ایجاد می‌کند و استفاده از زمان‌بندی‌ها را غیرفعال می‌سازد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **نمایش کنترل‌های رسانه‌ای**

متد [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) تعیین می‌کند آیا کنترل‌های رسانه‌ای (مانند پخش، pause و stop) در طول نمایش اسلاید زمانی که محتوای چندرسانه‌ای (مثلاً ویدئو یا صدا) پخش می‌شود، نمایش داده شوند یا نه. این برای زمانی که می‌خواهید به ارائه‌کننده امکان کنترل پخش رسانه‌ای را در طول ارائه بدهید مفید است.

کد مثال زیر یک ارائه جدید ایجاد می‌کند و نمایش کنترل‌های رسانه‌ای را فعال می‌سازد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**آیا می‌توانم یک ارائه را طوری ذخیره کنم که مستقیماً در حالت نمایش اسلاید باز شود؟**

بله. فایل را به صورت PPSX یا PPSM ذخیره کنید؛ این فرمت‌ها هنگام باز شدن در PowerPoint مستقیم به حالت نمایش اسلاید می‌روند. در Aspose.Slides، قالب ذخیره‌سازی متناظر را در [در زمان خروجی](/slides/fa/python-java/save-presentation/) انتخاب کنید.

**آیا می‌توانم اسلایدهای فردی را از نمایش حذف کنم بدون اینکه آنها را از فایل حذف کنم؟**

بله. یک اسلاید را به عنوان [hidden](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#setHidden) علامت بزنید. اسلایدهای مخفی در ارائه باقی می‌مانند اما در حین نمایش اسلاید نشان داده نمی‌شوند.

**آیا Aspose.Slides می‌تواند یک نمایش اسلاید را پخش کند یا یک ارائه زنده را روی صفحه کنترل کند؟**

خیر. Aspose.Slides ویرایش، تجزیه و تحلیل و تبدیل فایل‌های ارائه را انجام می‌دهد؛ پخش واقعی توسط برنامه‌ای نظیر PowerPoint انجام می‌شود.