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
description: "اعمال انتقال اسلایدها، پیکربندی پیشرفت خودکار اسلایدها، و سفارشی‌سازی مورف و دیگر افکت‌های انتقال با Aspose.Slides برای Python از طریق Java."
---
## **نمای کلی**

انتقالات اسلاید کنترل می‌کنند که اسلایدها در طول نمایش اسلاید چگونه ظاهر می‌شوند. با Aspose.Slides برای Python از طریق Java می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشرفت را با کلیک ماوس یا زمان‌سنج تنظیم کنید، و گزینه‌های خاص یک اثر را تنظیم کنید. این مقاله از مثال‌های Python برای اعمال انتقال‌ها، تنظیم دقیق مدت زمان انتقال، مدیریت زمان‌بندی اسلاید، و ایجاد انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند چگونه تنظیمات را در فایلی با فرمت PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بارگذاری کنید و تنظیمات انتقال اسلاید را از طریق [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) دسترسی پیدا کنید. از [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) همراه با مقداری از شمارش [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) استفاده کنید و سپس ارائه را ذخیره کنید.

مثال زیر یک انتقال Circle را به اسلاید اول و یک انتقال Comb را به اسلاید دوم اعمال می‌کند. از فایل `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

## **Wheel Transition**

از [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) برای انتخاب Wheel از [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) استفاده کنید. سپس با فراخوانی [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) به تنظیمات [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) دسترسی پیدا کنید. روش [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) تعداد بخش‌های شعاعی که اسلاید مقصد را نشان می‌دهند تنظیم می‌کند.

مثال دو جفت اسلاید مشابه ایجاد می‌کند. هر جفت با یک اسلاید سیاه شروع می‌شود و با یک مستطیل طلایی تمام‌صفحه پایان می‌یابد. هر دو اسلاید مقصد از همان سرعت کم که با [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) تنظیم شده و همان مدت زمان صریح ۸۰۰۰ میلی‌ثانیه که با [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) تنظیم شده‌اند استفاده می‌کنند. تنها تعداد بخش‌ها تغییر می‌کند.

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

فایل `wheel-transitions.pptx` را در PowerPoint باز کنید و نمایش اسلاید را شروع کنید. از اسلاید ۱ به اسلاید ۲ پیش بروید تا یک چرخش ساعتگرد مستطیل طلایی را نشان دهد. سپس از اسلاید ۳ به اسلاید ۴ پیش بروید تا هشت بخش شعاعی همزمان مستطیل را نشان دهند.

## **Fade Through Black with the Reveal Transition**

نوع انتقال اسلاید مقصد را به Reveal تنظیم کنید، سپس بر روی تنظیمات [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/) متد [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) را فراخوانی کنید. مثال یک اسلاید منبع به رنگ سبز دریایی و یک اسلاید مقصد به رنگ مرجانی ایجاد می‌کند، سپس هر دو را کلون می‌کند. هر جفت از یک انتقال Reveal دو ثانیه‌ای یکسان استفاده می‌کند. تنها جفت دوم از حالت عبور از سیاه استفاده می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

فایل `reveal-transitions.pptx` را در PowerPoint باز کنید و نمایش اسلاید را شروع کنید. از اسلاید ۱ به اسلاید ۲ پیش بروید تا رنگ سبز دریایی مستقیم به رنگ مرجانی محو شود. سپس از اسلاید ۳ به اسلاید ۴ پیش بروید. صفحه برای لحظه‌ای به نزدیک سیاه تاریک می‌شود قبل از این که اسلاید مرجانی ظاهر شود. هر دو اسلاید پس‌زمینه رنگ اصلی خود را حفظ می‌کنند.

سطرهای زیر فریم‌هایی از PowerPoint با فواصل نیم‌ثانیه‌ای نشان می‌دهند. برای مشاهده اثر، فریم میانی هر ردیف را مقایسه کنید.

![پخش PowerPoint با غیرفعال بودن fade through black (بالا) و فعال بودن (پایین). فقط ردیف پایینی از نزدیک سیاه می‌گذرد.](reveal-through-black.png)

## **افزودن انتقال پیشرفته اسلاید**

می‌توانید مدت زمانی که یک اسلاید روی صفحه می‌ماند و این که آیا کلیک ماوس باعث پیشرفت نمایش اسلاید می‌شود یا نه را تنظیم کنید. روش‌های زیر این رفتار را کنترل می‌کنند:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) اجازه می‌دهد بیننده با کلیک ماوس پیش برود.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) پیشرفت خودکار را فعال می‌کند.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) تاخیر قبل از پیشرفت خودکار را بر حسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشرفت کلیکی و زمان‌دار را فعال کنید تا بیننده یا با کلیک یا پس از زمان‌سنج حرکت کند. برای استفاده فقط از زمان‌سنج، `False` را به [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) پاس دهید. تاخیر زمان‌بندی زمانی را که نمایش اسلاید پیش می‌رود تعیین می‌کند؛ این مقدار مدت زمان اثر بصری انتقال را تنظیم نمی‌کند.

این مثال اثرهای مختلفی را به اولین سه اسلاید اختصاص می‌دهد و پیشرفت خودکار پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک‌های ماوس نیز می‌توانند این اسلایدها را پیش ببرند. از فایل `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

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

برای بررسی اینکه آیا پیشرفت زمان‌دار فعال است یا خیر، [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) را فراخوانی کنید. تنها داشتن یک تاخیر ذخیره‌شده نشاندهنده فعال بودن تایمر نیست.

مثال بعدی فایلی که بالا ذخیره شده را باز می‌کند، هر تایمر فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای آن اسلایدها کلیک‌های ماوس فعال می‌شود و تنظیمات به‌روزرسانی شده ذخیره می‌شوند.

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

از [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) برای مشخص کردن دقیق مدت زمان یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. متد [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید این تنظیمات را از طریق [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) در اختیار می‌گذارد:

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | مدت زمان خود اثر انتقال را بر حسب میلی‌ثانیه تنظیم می‌کند. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | تاخیر قبل از پیشرفت خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این تایمر `True` را به [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) پاس دهید. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | یک دسته سرعت پیش‌فرض از [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) (Slow, Medium یا Fast) را انتخاب می‌کند. زمانی که مدت زمان صریحی تعیین نشده باشد استفاده می‌شود. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) فقط اثر انتقال را کنترل می‌کند؛ مدت زمانی که اسلاید روی صفحه می‌ماند را تعیین نمی‌کند. تأخیر پیشرفت خودکار را به‌طور جداگانه تنظیم کنید. وقتی مدت زمان صریحی تنظیم نشده باشد، Aspose.Slides مدت زمان اثر را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) محاسبه می‌کند.

<!-- visual-explanation:slide-transition:start -->
[![نوارهای جداگانه مدت زمان ۷۵۰ میلی‌ثانیه برای انتقال و ۵۰۰۰ میلی‌ثانیه برای پیشرفت خودکار را نشان می‌دهند.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*مثال مشترک برای هر اسلاید یک انتقال Fade به مدت ۷۵۰ میلی‌ثانیه اعمال می‌کند و پیشرفت خودکار را به مدت ۵۰۰۰ میلی‌ثانیه فعال می‌کند. مدت زمان انتقال فقط اثر را کنترل می‌کند؛ پیشرفت زمان خروج اسلاید را مشخص می‌کند. این نوارها تنظیمات شماتیک هستند، نه یک خط زمان ترکیبی اندازه‌گیری‌شده.*
<!-- visual-explanation:slide-transition:end -->

### **اعمال همان مدت زمان به تمام اسلایدها**

برای سرعت‌بندی یکنواخت، همان اثر و مدت زمان دقیق را به همه اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) انتخاب می‌کند و به هر انتقال مدت زمان ۷۵۰ میلی‌ثانیه می‌دهد. پیشرفت خودکار پس از ۵۰۰۰ میلی‌ثانیه فعال می‌شود و پیشرفت با کلیک ماوس غیرفعال می‌شود، سپس نتیجه به صورت PPTX ذخیره می‌شود.

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

        # پیکربندی پیشرفت خودکار به طور مستقل از مدت زمان اثر.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تنظیم مدت زمان‌های مختلف برای اسلایدهای جداگانه**

اسلایدهای مختلف می‌توانند مدت زمان‌های متفاوتی داشته باشند. به‌عنوان مثال، برای اسلاید عنوان یک انتقال کوتاه و برای معرفی بخش یک انتقال طولانی‌تر استفاده کنید. این مثال ۵۰۰ میلی‌ثانیه برای اسلاید اول و ۱۲۰۰ میلی‌ثانیه برای اسلاید دوم تنظیم می‌کند. از فایل `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

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

### **هماهنگی انتقال‌ها با خروجی‌های انیمیشنی**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/python-java/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/python-java/export-to-html5/) یا [video](/slides/fa/python-java/convert-powerpoint-to-video/)، قبل از خروجی‌گیری مدت زمان دقیق انتقال‌ها را تنظیم کنید تا با سرعت موردنظر هماهنگ شود. به‌عنوان مثال، یک محو شدن ۶۰۰ میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را به‌طور جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن فراهم شود.

برای GIF و ویدئو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: ۶۰۰ میلی‌ثانیه معادل ۱۸ فریم با ۳۰ فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. قالب خروجی انتخابی را از نظر اثرات و گزینه‌های زمان‌بندی پشتیبانی‌شده بررسی کنید و خروجی را پیش‌نمایش کنید تا همگام‌سازی را تأیید کنید.

### **خواندن مدت زمان موجود یک انتقال**

قبل از تغییر انتقال، [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) را فراخوانی کنید تا ببینید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به معنای عدم تنظیم مدت زمان صریح است؛ مقدار غیرمنفی مدت زمان ذخیره‌شده را بر حسب میلی‌ثانیه نشان می‌دهد. این مقدار تنظیم نشده، مدت زمان پخش محاسبه‌شده نیست: Aspose.Slides مدت زمان را بر اساس نوع انتقال و مقدار [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) تعیین می‌کند. تنظیم نوع انتقال می‌تواند مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

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

## **Morph Transition**

انتقال Morph تغییرات بین اشیاء در اسلایدهای متوالی را انیمیت می‌کند. برای ایجاد یک اثر ساده Morph، یک اسلاید را کلون کنید، یک شیء را در نسخه کلون شده جابجا یا اندازه‌اش تغییر دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار به اشیاء متناظر اجازه می‌دهد بین وضعیت اصلی و حالت تغییر یافته انیمیشن شوند.

مثال زیر یک اسلاید با یک مستطیل متنی ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در نسخه کلون شده تغییر می‌دهد. سپس Morph را از شمارش [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) برای اسلاید دوم انتخاب می‌کند. فایل ذخیره‌شده را در یک مرورگر ارائه‌ای که Morph را پشتیبانی می‌کند باز کنید تا اثر را در حین نمایش اسلاید ببینید.

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

## **انواع Morph Transition**

شمارش [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) تعیین می‌کند Morph چگونه محتوا را مطابقت داده و انیمیت می‌کند:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) هر شکل را به‌عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) متن را با تطبیق کلمات، در صورت امکان، انیمیت می‌کند.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) متن را با تطبیق کاراکترها، در صورت امکان، انیمیت می‌کند.

از [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) برای انتخاب Morph قبل از دسترسی به [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) استفاده کنید. مقدار بازگشتی سپس یک نمونه از کلاس [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/) است که متد [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) حالت تطبیق را انتخاب می‌کند.

این مثال ارائه‌ای که در بخش قبلی ایجاد شد را باز می‌کند و اسلاید دوم را برای انیمیشن Morph مبتنی بر کلمه تنظیم می‌کند.

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

## **تنظیم اثرات انتقال**

برخی انتقال‌ها گزینه‌های اضافی مانند جهت یا اینکه اثر از صفحه سیاه شروع شود را ارائه می‌دهند. گزینه‌های موجود بستگی به انتقالی دارد که با [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) انتخاب شده است. ابتدا نوع را تنظیم کنید، سپس از کلاس مناسب که از طریق [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) باز می‌گردد استفاده کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. از طریق [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) متد [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) فراخوانی می‌شود تا انتقال از صفحه سیاه آغاز شود.

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

## **سوالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. وقتی به مدت دقیق اثر به میلی‌ثانیه نیاز دارید از [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) استفاده کنید. وقتی یک دسته سرعت پیش‌فرض از [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) (Slow, Medium یا Fast) کافی باشد و مدت زمان صریحی تنظیم نشده باشد، از [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) استفاده کنید. این تنظیمات اثر انتقال را مستقل از تاخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توانم صدا به یک انتقال اضافه کنم و آن را حلقه‌دار کنم؟**

بله. صدا تعبیه‌شده را با [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound) اختصاص دهید، از حالت StartSound در شمارش [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) به [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) پاس بدهید و [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) را با `True` فعال کنید. صدا تا رخداد صوتی بعدی در نمایش اسلاید ادامه می‌یابد.

**سریع‌ترین راه برای اعمال یک انتقال یکسان به همه اسلایدها چیست؟**

در حلقه‌ای از مجموعه [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) ارائه عبور کنید و برای هر اسلاید [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) را با همان مقدار فراخوانی کنید. هر تنظیم زمان‌بندی و گزینه اثر را در همان حلقه تنظیم کنید تا رفتار بین اسلایدها یکسان بماند.

**چگونه می‌توانم بررسی کنم که در حال حاضر چه انتقالی بر یک اسلاید تنظیم شده است؟**

بر روی نتیجه [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) اسلاید، متد [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) را فراخوانی کنید. این متد مقداری از شمارش [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) بر می‌گرداند؛ مقدار None_ نشان می‌دهد هیچ اثر انتقالی اعمال نشده است.