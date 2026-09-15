---
title: مدیریت انتقال اسلایدها در ارائه‌ها با استفاده از پایتون از طریق جاوا
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/python-java/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال پیشرفته اسلاید
- انتقال مورف
- نوع انتقال
- اثر انتقال
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "اعمال انتقال اسلایدها، پیکربندی پیشرفت خودکار اسلایدها و سفارشی‌سازی اثرات Morph و سایر اثرات انتقال با Aspose.Slides برای پایتون از طریق جاوا."
---
## **نمای کلی**

انتقال اسلایدها نحوه نمایش اسلایدها را در طول نمایش اسلایدها کنترل می‌کند. با Aspose.Slides for Python via Java می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشرفت را با کلیک ماوس یا زمان‌سنج تنظیم کنید و گزینه‌های خاص یک اثر را تنظیم کنید. این مقاله از مثال‌های پایتون برای اعمال انتقال‌ها، تنظیم دقیق مدت زمان انتقال، مدیریت زمان اسلاید و ایجاد یک انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند که چگونه تنظیمات را در یک فایل PPTX ذخیره کنید.

## **اضافه کردن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال اسلاید را از طریق [getSlideShowTransition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getSlideShowTransition) دریافت کنید. از [setType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setType) با مقداری از شمارش [TransitionType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/transitiontype/) استفاده کنید، سپس ارائه را ذخیره کنید.

مثال زیر یک انتقال Circle را به اسلاید اول و یک انتقال Comb را به اسلاید دوم اعمال می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **اضافه کردن انتقال پیشرفته اسلاید**

می‌توانید مدت زمان ماندن یک اسلاید روی صفحه و این که آیا کلیک ماوس پیشرفت نمایش اسلایدها را انجام می‌دهد یا نه را پیکربندی کنید. روش‌های زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) به بیننده اجازه می‌دهد با کلیک ماوس پیشرفت کند.
- [setAdvanceAfter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) پیشرفت خودکار را فعال می‌سازد.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) تاخیر قبل از پیشرفت خودکار را بر حسب میلی‌ثانیه تعیین می‌کند.

هر دو پیشرفت کلیک و زمان‌بندی را فعال کنید تا بیننده بتواند با کلیک یا منتظر تایمر ادامه دهد. برای استفاده فقط از تایمر، `False` را به [setAdvanceOnClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) پاس بدهید. تاخیر زمان‌بندی زمانی که نمایش اسلاید پیش می‌رود را کنترل می‌کند؛ این مقدار مدت زمان اثر بصری انتقال را تعیین نمی‌کند.

این مثال اثرهای مختلفی را به اولین سه اسلاید اختصاص می‌دهد و پیشرفت خودکار را پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک ماوس نیز می‌تواند این اسلایدها را پیش ببرد. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

برای بررسی اینکه آیا پیشرفت زمان‌بندی شده فعال است یا نه، [getAdvanceAfter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) را فراخوانی کنید. فقط ذخیره یک تاخیر نشانگر فعال بودن تایمر نیست.

مثال بعدی فایلی را که در بالا ذخیره شد باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای آن اسلایدها کلیک ماوس را فعال می‌کند و تنظیمات به‌روز شده را ذخیره می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **کنترل دقیق زمان‌بندی انتقال**

از [setDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setDuration) برای تعیین دقیق طول یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید این تنظیمات را از طریق کلاس [SlideShowTransition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/) در دسترس می‌گذارد:

| متد | هدف |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setDuration) | مدت زمان خود اثر انتقال را بر حسب میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | تاخیر پیشرفت خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال کردن این تایمر `True` را به [setAdvanceAfter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) پاس بدهید. |
| [setSpeed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setSpeed) | یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/transitionspeed/) انتخاب می‌کند: Slow، Medium یا Fast. زمانی که مدت زمان دقیق مشخص نشده باشد استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setDuration) فقط اثر انتقال را کنترل می‌کند؛ اینکه اسلاید چه مدت قابل مشاهده باشد را تعیین نمی‌کند. تاخیر پیشرفت خودکار را به طور جداگانه پیکربندی کنید. وقتی مدت زمان صریحی تنظیم نشود، Aspose.Slides مدت زمان اثر را از نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#getSpeed) تعیین می‌کند.

### **اعمال همان مدت زمان به همه اسلایدها**

برای حفظ سرعت ثابت، همان اثر و مدت زمان دقیق را به همه اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/transitiontype/) انتخاب می‌کند و به هر انتقال مدت زمان ۷۵۰ میلی‌ثانیه می‌دهد. به طور جداگانه پیشرفت خودکار را پس از ۵۰۰۰ میلی‌ثانیه فعال می‌کند و پیشرفت با کلیک ماوس را غیرفعال می‌نماید، سپس نتیجه را به صورت PPTX ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # پیکربندی پیشرفت خودکار به‌صورت مستقل از مدت زمان اثر.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تنظیم مدت زمان‌های متفاوت برای اسلایدهای فردی**

اسلایدهای مختلف می‌توانند مدت زمان‌های متفاوتی داشته باشند. برای مثال، از یک انتقال کوتاه برای اسلاید عنوان و یک انتقال طولانی‌تر برای معرفی بخش استفاده کنید. این مثال ۵۰۰ میلی‌ثانیه برای اسلاید اول و ۱۲۰۰ میلی‌ثانیه برای اسلاید دوم تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **هماهنگی انتقال‌ها با خروجی‌های متحرک**

هنگامی که یک [animated GIF](/slides/fa/python-java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/python-java/export-to-html5/) یا [video](/slides/fa/python-java/convert-powerpoint-to-video/) آماده می‌کنید، قبل از خروجی‌گیری مدت زمان دقیق انتقال‌ها را تنظیم کنید تا با سرعت مطلوب هماهنگ شوند. برای مثال، یک محو شدن ۶۰۰ میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را به طور جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن داشته باشید.

برای GIF و ویدیو، نرخ فریم خروجی را با مدت زمان اثر مطابقت دهید: ۶۰۰ میلی‌ثانیه معادل ۱۸ فریم با ۳۰ فریم در ثانیه است. در HTML5، انتقال‌های متحرک را در تنظیمات خروجی فعال کنید. گزینه‌های اثر و زمان‌بندی پشتیبانی‌شده توسط فرمت خروجی انتخابی را بررسی کنید و خروجی را پیش‌نمایش کنید تا از هم‌زمانی اطمینان حاصل شود.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال، [getDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#getDuration) را فراخوانی کنید تا بررسی کنید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به این معنی است که هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده را بر حسب میلی‌ثانیه نشان می‌دهد. این مقدار تنظیم نشده، مدت زمان پخش محاسبه‌شده نیست: Aspose.Slides نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#getSpeed) را برای تعیین آن استفاده می‌کند. تنظیم یک نوع انتقال می‌تواند یک مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **انتقال Morph**

انتقال Morph تغییرات بین اشیاء روی اسلایدهای متوالی را انیمیت می‌کند. برای ایجاد یک اثر Morph ساده، یک اسلاید را کلون کنید، شیء‌ای را روی کلون جابه‌جا یا اندازه‌اش را تغییر دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار به اشیائی که مطابق هستند اجازه می‌دهد بین حالت اولیه و تغییر یافته انیمیت شوند.

مثال زیر یک اسلاید با یک مستطیل متن ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در کلون تغییر می‌دهد. سپس Morph را از شمارش [TransitionType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/transitiontype/) برای اسلاید دوم انتخاب می‌کند. فایل ذخیره‌شده را در یک نمایشگر ارائه‌ای که Morph را پشتیبانی می‌کند باز کنید تا اثر را در حین نمایش اسلایدها ببینید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **انواع انتقال Morph**

شمارش [TransitionMorphType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/transitionmorphtype/) نحوه مطابقت و انیمیشن محتوای Morph را کنترل می‌کند:

- [ByObject](https://reference.aspose.com/slides/fa/python-java/aspose.slides/transitionmorphtype/#ByObject) هر شکل را به عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/fa/python-java/aspose.slides/transitionmorphtype/#ByWord) متن را با مطابقت کلمات (در صورت امکان) انیمیت می‌کند.
- [ByChar](https://reference.aspose.com/slides/fa/python-java/aspose.slides/transitionmorphtype/#ByChar) متن را با مطابقت کاراکترها (در صورت امکان) انیمیت می‌کند.

قبل از دسترسی به [getValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#getValue) از [setType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setType) برای انتخاب Morph استفاده کنید. سپس مقدار برگشتی یک نمونه از کلاس [MorphTransition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/morphtransition/) است که متد [setMorphType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/morphtransition/#setMorphType) حالت مطابقت را انتخاب می‌کند.

این مثال ارائه‌ای که در بخش قبلی ایجاد شد را باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph مبتنی بر کلمه تنظیم می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **تنظیم اثرهای انتقال**

برخی از انتقال‌ها گزینه‌های اضافی مانند جهت یا این که اثر از یک صفحه سیاه شروع شود را در اختیار می‌گذارند. گزینه‌های موجود به انتقالی که با [setType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setType) انتخاب شده بستگی دارد. ابتدا نوع را تنظیم کنید، سپس کلاس مناسب را از [getValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#getValue) استفاده کنید.

مثال زیر یک انتقال Cut را به اولین اسلاید `input.pptx` اعمال می‌کند. از [setFromBlack](https://reference.aspose.com/slides/fa/python-java/aspose.slides/optionalblacktransition/#setFromBlack) از طریق کلاس [OptionalBlackTransition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/optionalblacktransition/) استفاده می‌کند تا انتقال از یک صفحه سیاه آغاز شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. زمانی که به مدت دقیق اثر بر حسب میلی‌ثانیه نیاز دارید، از [setDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setDuration) استفاده کنید. وقتی یک دسته سرعت از پیش تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/transitionspeed/) (Slow، Medium یا Fast) کافی است و مقدار صریحی تنظیم نشده، از [setSpeed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setSpeed) استفاده کنید. این تنظیمات اثر انتقال را مستقل از تاخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توانم صدا را به یک انتقال وصل کنم و آن را حلقه‌دار کنم؟**

بله. صدا را با [setSound](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setSound) اختصاص دهید، مقدار StartSound از شمارش [TransitionSoundMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/transitionsoundmode/) را به [setSoundMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setSoundMode) پاس بدهید و با `True` به [setSoundLoop](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setSoundLoop) فعال کنید. صدا تا رویداد صوتی بعدی در نمایش اسلایدها حلقه می‌زند.

**سریع‌ترین راه برای اعمال همان انتقال به همه اسلایدها چیست؟**

از طریق حلقه‌زدن روی مجموعه [getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) ارائه و فراخوانی [setType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#setType) با همان مقدار برای هر اسلاید استفاده کنید. هر گزینه زمان‌بندی و اثر را در همان حلقه تنظیم کنید تا رفتار در تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که در حال حاضر چه انتقالی روی یک اسلاید تنظیم شده است؟**

روی نتیجه [getSlideShowTransition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید، متد [getType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideshowtransition/#getType) را فراخوانی کنید. این متد مقداری از شمارش [TransitionType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/transitiontype/) برمی‌گرداند؛ `None_` به این معنی است که هیچ اثر انتقالی اعمال نشده است.