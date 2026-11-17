---
title: مدیریت انتقال اسلایدها در ارائه‌ها با استفاده از Python از طریق Java
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/python-java/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال اسلاید پیشرفته
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "انتقال اسلایدها را اعمال کنید، پیشروی خودکار اسلایدها را پیکربندی کنید، و اثرهای Morph و سایر اثرهای انتقال را با Aspose.Slides برای Python از طریق Java سفارشی کنید."
---
## **مرور کلی**

انتقالات اسلاید کنترل می‌کند که اسلایدها چگونه در حین نمایش اسلاید ظاهر می‌شوند. با Aspose.Slides برای Python از طریق Java، می‌توانید برای هر اسلاید یک افکت انتقال انتخاب کنید، پیشروی را با کلیک ماوس یا تایمر تنظیم کنید و گزینه‌های خاص یک افکت را تنظیم کنید. این مقاله از مثال‌های Python برای اعمال انتقال‌ها، تنظیم مدت زمان دقیق انتقال، مدیریت زمان اسلاید و ایجاد انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند که چگونه تنظیمات را در یک فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال اسلاید را از طریق [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) دسترسی پیدا کنید. از [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) با مقدار از enum [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) استفاده کنید، سپس ارائه را ذخیره کنید.

مثال زیر انتقال Circle را به اسلاید اول و انتقال Comb را به اسلاید دوم اعمال می‌کند. از یک فایل `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

## **انتقال چرخ**

از [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) برای انتخاب Wheel از [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) استفاده کنید. سپس با فراخوانی [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) به تنظیمات [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) دسترسی پیدا کنید. متد [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) تعداد بخش‌های شعاعی که اسلاید مقصد را نمایش می‌دهند، کنترل می‌کند.

مثال دو جفت اسلاید یکسان ایجاد می‌کند. هر جفت با یک اسلاید سیاه شروع می‌شود و با یک مستطیل طلایی تمام‑اسلاید تمام می‌شود. هر دو اسلاید مقصد از سرعت آهسته یکسانی که با [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) تنظیم شده و مدت زمان صریح ۸۰۰۰ میلی‌ثانیه که با [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) تنظیم شده استفاده می‌کنند. تنها تعداد شاخ‌ها تغییر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

فایل `wheel-transitions.pptx` را در PowerPoint باز کنید و نمایش اسلاید را شروع کنید. از اسلاید ۱ به اسلاید ۲ پیش بروید تا یک sweep ساعتگرد مستطیل طلایی را نشان دهد. سپس از اسلاید ۳ به اسلاید ۴ پیش بروید تا هشت بخش شعاعی همزمان مستطیل را آشکار کنند.

## **افزودن انتقال اسلاید پیشرفته**

می‌توانید مدت زمانی که یک اسلاید روی صفحه می‌ماند و این‌که آیا کلیک ماوس نمایش اسلاید را پیش می‌برد را پیکربندی کنید. متدهای زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) امکان پیشروی با کلیک ماوس را برای بیننده فعال می‌کند.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) پیشروی خودکار را فعال می‌کند.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) تاخیر قبل از پیشروی خودکار را بر حسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشروی با کلیک و پیشروی زمان‌دار را فعال کنید تا بیننده بتواند با کلیک ادامه دهد یا تا تایمر صبر کند. برای استفاده فقط از تایمر، `False` را به [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) بدهید. تاخیر زمان پیشروی را کنترل می‌کند؛ مدت زمان افکت انتقال بصری را تنظیم نمی‌کند.

این مثال افکت‌های مختلف را به سه اسلاید اول اختصاص می‌دهد و پیشروی خودکار پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک‌های ماوس نیز می‌توانند این اسلایدها را پیش ببرند. از یک فایل `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

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

برای بررسی اینکه آیا پیشروی زمان‌دار فعال است یا نه، [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) را فراخوانی کنید. تنها داشتن یک تاخیر ذخیره‌شده نشان‌دهنده فعال بودن تایمر نیست.

مثال بعدی فایل ذخیره‌شده در بالا را باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشروی خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای آن اسلایدها کلیک ماوس فعال می‌شود و تنظیمات به‌روزرسانی‌شده ذخیره می‌گردد.

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

از [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) برای مشخص کردن طول دقیق یک افکت انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید این تنظیمات را از طریق [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) در دسترس می‌گذارد:

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | مدت زمان خود افکت انتقال را بر حسب میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | تاخیر قبل از پیشروی خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این تایمر `True` را به [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) بدهید. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) را انتخاب می‌کند: Slow، Medium یا Fast. وقتی مدت زمان صریحی تعیین نشده باشد، استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) فقط افکت انتقال را کنترل می‌کند؛ مدت زمانی که اسلاید دیده می‌شود را تعیین نمی‌کند. تاخیر پیشروی خودکار را جداگانه تنظیم کنید. وقتی مدت زمان صریحی تنظیم نشده باشد، Aspose.Slides مدت زمان افکت را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) محاسبه می‌کند.

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*نمونه مشترک برای هر اسلاید یک انتقال Fade ۷۵۰‑ms فراهم می‌کند و پیشروی خودکار ۵۰۰۰ ms را جداگانه فعال می‌کند. مدت زمان انتقال فقط افکت را کنترل می‌کند؛ پیشروی زمان خروج از اسلاید را. این نوارها تنظیمات شماتیک هستند، نه یک خط زمان ترکیبی اندازه‌گیری‌شده.*
<!-- visual-explanation:slide-transition:end -->

### **اعمال یک مدت زمان یکسان بر تمام اسلایدها**

برای حفظ سرعت ثابت، همان افکت و همان مدت زمان دقیق را به همه اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) انتخاب می‌کند و به هر انتقال یک مدت زمان ۷۵۰ میلی‌ثانیه می‌دهد. پیشروی خودکار را پس از ۵۰۰۰ میلی‌ثانیه جداگانه فعال کرده و پیشروی با کلیک ماوس را غیرفعال می‌کند، سپس نتیجه را به صورت PPTX ذخیره می‌نماید.

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

### **تنظیم مدت زمان‌های متفاوت برای اسلایدهای منفرد**

اسلایدهای مختلف می‌توانند مدت زمان افکت‌های متفاوتی داشته باشند. به عنوان مثال، از یک انتقال کوتاه برای اسلاید عنوان و یک انتقال طولانی‌تر برای معرفی بخش استفاده کنید. این مثال ۵۰۰ میلی‌ثانیه برای اسلاید اول و ۱۲۰۰ میلی‌ثانیه برای اسلاید دوم تنظیم می‌کند. از یک فایل `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

### **همگام‌سازی انتقال‌ها با خروجی انیمیشنی**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/python-java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/python-java/export-to-html5/) یا [video](/slides/fa/python-java/convert-powerpoint-to-video/)، قبل از خروجی‌گیری مدت زمان دقیق انتقال‌ها را تنظیم کنید تا با سرعت موردنظر هم‌خوانی داشته باشد. به عنوان مثال، از یک fade ۶۰۰ میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشروی هر اسلاید را جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن داشته باشید.

برای GIF و ویدئو، نرخ فریم خروجی را با مدت زمان افکت هماهنگ کنید: ۶۰۰ میلی‌ثانیه معادل ۱۸ فریم در ۳۰ فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. فرمت خروجی انتخابی را برای اثرات و گزینه‌های زمان‌بندی پشتیبانی‌شده بررسی کنید و برای اطمینان از همگام‌سازی پیش‌نمایش کنید.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال، [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) را فراخوانی کنید تا ببینید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` یعنی هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیر منفی مدت زمان ذخیره‌شده را بر حسب میلی‌ثانیه نشان می‌دهد. این مقدار تنظیم‌نشده، مدت زمان پخش محاسبه‌شده نیست: Aspose.Slides با استفاده از نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) آن را تعیین می‌کند. تنظیم یک نوع انتقال می‌تواند یک مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

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

انتقال Morph تغییرات بین اشیاء روی اسلایدهای متوالی را انیمیشن می‌دهد. برای ایجاد یک اثر ساده Morph، یک اسلاید را کپی کنید، شیء را روی کپی جابه‌جا یا تغییر اندازه دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار اشیاء مرتبط را بین حالت اصلی و اصلاح‌شده آن‌ها انیمیشن می‌کند.

مثال زیر یک اسلاید با یک مستطیل متن ایجاد می‌کند، اسلاید را کپی می‌کند و موقعیت و اندازه مستطیل را در کپی تغییر می‌دهد. سپس برای اسلاید دوم Morph را از enum [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) انتخاب می‌کند. فایل ذخیره‌شده را در یک نمایش‌کننده‌ای که Morph را پشتیبانی می‌کند باز کنید تا اثر را در حین نمایش اسلاید ببینید.

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

enum [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) نحوه تطبیق و انیمیشن محتوا توسط Morph را کنترل می‌کند:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) هر شکل را به عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) متن را با تطبیق کلمات (در صورت امکان) انیمیشن می‌کند.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) متن را با تطبیق حروف (در صورت امکان) انیمیشن می‌کند.

از [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) برای انتخاب Morph قبل از دسترسی به [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) استفاده کنید. سپس مقدار برگشتی یک نمونه از کلاس [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/) است که متد [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) آن حالت تطبیق را انتخاب می‌کند.

این مثال ارائه‌ای را که در بخش قبلی ساخته شد باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph مبتنی بر کلمه تنظیم می‌کند.

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

## **تنظیم افکت‌های انتقال**

برخی از انتقال‌ها گزینه‌های اضافی مانند جهت یا این که افکت از صفحه سیاه شروع شود را در اختیار می‌گذارند. گزینه‌های موجود به انتقالی که با [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) انتخاب شده بستگی دارد. ابتدا نوع را تنظیم کنید، سپس از کلاس مناسب از طریق [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) استفاده کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. از طریق [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) متد [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) را فراخوانی می‌کند تا انتقال از صفحه سیاه آغاز شود.

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

## **پرسش‌های متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. هنگام نیاز به مدت زمان دقیق افکت بر حسب میلی‌ثانیه، ترجیحاً از [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) استفاده کنید. وقتی یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) (Slow، Medium یا Fast) کافی است و مدت زمان صریحی تنظیم نشده، از [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) استفاده کنید. این تنظیمات افکت انتقال را به‌صورت مستقل از تاخیر پیشروی خودکار کنترل می‌کنند.

**آیا می‌توانم صوتی را به یک انتقال وصل کنم و آن را حلقه‌ای کنم؟**

بله. صدای داخلی را با [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound) تخصیص دهید، مقدار StartSound از enum [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) را به [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) بدهید و با `True` به [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) فعال کنید. صدا تا رویداد صوتی بعدی در نمایش اسلاید حلقه می‌زند.

**سریع‌ترین راه برای اعمال یک انتقال یکسان به تمام اسلایدها چیست؟**

در مجموعه [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) ارائه حلقه بزنید و برای هر اسلاید متد [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) را با همان مقدار فراخوانی کنید. هر تنظیم زمان و گزینه افکت را در همان حلقه تنظیم کنید تا رفتار در تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که چه انتقالی در حال حاضر بر روی یک اسلاید تنظیم شده است؟**

بر روی نتیجه [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید، [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) را فراخوانی کنید. این متد یک مقدار از enum [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) بازمی‌گرداند؛ مقدار None_ نشان می‌دهد که هیچ افکت انتقالی اعمال نشده است.