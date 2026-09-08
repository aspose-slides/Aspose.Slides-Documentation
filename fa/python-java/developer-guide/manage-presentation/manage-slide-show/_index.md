---
title: مدیریت نمایش اسلایدها در پایتون از طریق جاوا
linktitle: نمایش اسلاید
type: docs
weight: 90
url: /fa/python-java/manage-slide-show/
keywords:
- نوع نمایش
- ارائه توسط سخنران
- مرور توسط فرد
- مرور در کیوسک
- گزینه‌های نمایش
- حلقه‌دار شدن پیوسته
- نمایش بدون روایت
- نمایش بدون انیمیشن
- رنگ قلم
- نمایش اسلایدها
- نمایش سفارشی
- پیشروی اسلایدها
- به‌صورت دستی
- استفاده از زمان‌بندی‌ها
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه نمایش اسلایدها را در Aspose.Slides برای پایتون از طریق جاوا مدیریت کنید. انتقال‌های اسلاید، زمان‌بندی‌ها و موارد دیگر را به‌راحتی در فرمت‌های PPT، PPTX و ODP کنترل کنید."
---
## **معرفی**

گزینه‌های **Set Up Show** در مایکروسافت‌پاورپوینت به شما امکان می‌دهند نوع نمایش را انتخاب کنید، حلقه‌ای کردن را فعال کنید، اسلایدها را انتخاب کنید و پیشرفت اسلایدها را کنترل کنید. با Aspose.Slides for Python via Java، می‌توانید این گزینه‌ها را به‌صورت برنامه‌نویسی تنظیم کرده و در یک فایل ارائه ذخیره کنید.

متد [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlideShowSettings) یک شیء [SlideShowSettings](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/) برمی‌گرداند که این گزینه‌ها را کنترل می‌کند. مثال‌های زیر به Aspose.Slides for Python via Java و یک محیط اجرایی جاوا سازگار نیاز دارند. هر مثال در صورت نیاز JVM را راه‌اندازی می‌کند و پس از اتمام ارائه را آزاد می‌کند.

## **انتخاب نوع نمایش**

متد [SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setSlideShowType) نوع نمایش را تعریف می‌کند که می‌تواند یک نمونه از کلاس‌های زیر باشد: [PresentedBySpeaker](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/fa/python-java/aspose.slides/browsedbyindividual/), یا [BrowsedAtKiosk](https://reference.aspose.com/slides/fa/python-java/aspose.slides/browsedatkiosk/). استفاده از این متد به شما امکان می‌دهد ارائه را برای سناریوهای مختلف استفاده تنظیم کنید، مانند کیوسک‌های خودکار یا ارائه‌های دستی.

کد نمونه زیر یک ارائه جدید ایجاد می‌کند و نوع نمایش را به "Browsed by an individual" تنظیم می‌کند بدون اینکه نوار اسکرول نمایش داده شود.

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

متد [SlideShowSettings.setLoop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setLoop) تعیین می‌کند آیا نمایش اسلاید باید به‌صورت حلقه‌ای تا توقف دستی تکرار شود یا نه. این برای ارائه‌های خودکار که نیاز به اجرا به‌صورت مداوم دارند مفید است. متد [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setShowNarration) تعیین می‌کند آیا روایت صوتی باید در طول نمایش اسلاید پخش شود یا خیر. این برای ارائه‌های خودکاری که شامل راهنمایی صوتی برای مخاطبان هستند مفید است. متد [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setShowAnimation) تعیین می‌کند آیا انیمیشن‌های اضافه‌شده به اشیای اسلاید باید پخش شوند یا نه. این برای ارائه اثر بصری کامل مفید است.

کد مثال زیر یک ارائه جدید ایجاد می‌کند و نمایش اسلاید را حلقه می‌کند.

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

متد [SlideShowSettings.setSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setSlides) به شما امکان می‌دهد یک بازه از اسلایدها را برای نمایش در طول ارائه انتخاب کنید. این زمانی مفید است که فقط بخشی از ارائه را می‌خواهید نشان دهید نه تمام اسلایدها. کد مثال زیر یک ارائه با نه اسلاید ایجاد می‌کند و اسلایدهای ۲ تا ۹ را انتخاب می‌کند. این بازه از شماره‌های اسلاید به‌صورت یک‌پایه استفاده می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # نه اسلاید ایجاد کنید تا بازه انتخاب شده وجود داشته باشد.
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

متد [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setUseTimings) به شما امکان می‌دهد استفاده از زمان‌بندی‌های پیش‌تنظیم‌شده برای هر اسلاید را فعال یا غیرفعال کنید. این برای نمایش خودکار اسلایدها با مدت زمان نمایش از پیش تعریف‌شده مفید است. کد مثال زیر یک ارائه جدید ایجاد می‌کند و استفاده از زمان‌بندی‌ها را غیرفعال می‌سازد.

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

متد [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) تعیین می‌کند آیا کنترل‌های رسانه‌ای (مانند پخش، توقف و بازپخش) باید در طول نمایش اسلاید هنگام پخش محتوای چندرسانه‌ای (مثلاً ویدئو یا صدا) نمایش داده شوند یا نه. این زمانی مفید است که می‌خواهید به ارائه‌دهنده کنترل پخش رسانه‌ها را در طول ارائه بدهید.

کد مثال زیر یک ارائه جدید ایجاد می‌کند و نمایش کنترل‌های رسانه‌ای را فعال می‌کند.

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

## **سوالات متداول**

**آیا می‌توانم یک ارائه را ذخیره کنم طوری که مستقیماً در حالت نمایش اسلاید باز شود؟**

بله. فایل را به‌صورت PPSX یا PPSM ذخیره کنید؛ این فرمت‌ها هنگام باز شدن در PowerPoint مستقیماً در حالت نمایش اسلاید اجرا می‌شوند. در Aspose.Slides، قالب ذخیره‌سازی مناسب را در زمان [در حین خروجی](/slides/fa/python-java/save-presentation/) انتخاب کنید.

**آیا می‌توانم اسلایدهای منفرد را از نمایش حذف کنم بدون اینکه آن‌ها را از فایل حذف کنم؟**

بله. یک اسلاید را به‌عنوان [مخفی](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#setHidden) علامت‌گذاری کنید. اسلایدهای مخفی در ارائه باقی می‌مانند اما در طول نمایش اسلاید نمایش داده نمی‌شوند.

**آیا Aspose.Slides می‌تواند یک نمایش اسلاید پخش کند یا یک ارائه زنده را روی صفحه کنترل کند؟**

خیر. Aspose.Slides فایل‌های ارائه را ویرایش، تجزیه و تحلیل و تبدیل می‌کند؛ پخش واقعی توسط برنامه‌ای مانند PowerPoint انجام می‌شود.