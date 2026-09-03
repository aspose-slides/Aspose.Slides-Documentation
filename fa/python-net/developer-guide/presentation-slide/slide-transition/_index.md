---
title: مدیریت انتقال‌های اسلاید در ارائه‌ها با استفاده از Python
linktitle: انتقال اسلاید
type: docs
weight: 90
url: /fa/python-net/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال پیشرفته اسلاید
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "انتقال‌های اسلاید را اعمال کنید، پیشرفت خودکار اسلایدها را پیکربندی کنید و اثرات Morph و سایر اثرات انتقال را با Aspose.Slides برای Python از طریق .NET سفارشی کنید."
---
## **مرور کلی**

انتقال‌های اسلاید کنترل می‌کنند که اسلایدها چگونه در حین نمایش اسلاید ظاهر می‌شوند. با Aspose.Slides برای Python از طریق .NET، می‌توانید برای هر اسلاید یک اثر انتقال انتخاب کنید، پیشرفت با کلیک ماوس یا زمان‌سنج را پیکربندی کنید و گزینه‌های خاص یک اثر را تنظیم کنید. این مقاله از مثال‌های Python برای اعمال انتقال‌ها، تنظیم مدت دقیق انتقال، مدیریت زمان اسلاید و ایجاد انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند چگونه تنظیمات را در یک فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری کنید و به ویژگی [slide_show_transition](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/slide_show_transition/) اسلاید دسترسی پیدا کنید. مقدار [type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/type/) آن را به یکی از مقادیر موجود در شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitiontype/) تنظیم کنید، سپس ارائه را ذخیره کنید.

مثال زیر یک انتقال Circle را به اسلاید اول و یک انتقال Comb را به اسلاید دوم اعمال می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **افزودن انتقال پیشرفته اسلاید**

می‌توانید مدت زمان ماندن یک اسلاید روی صفحه و این که آیا کلیک ماوس پیشرفت نمایش اسلاید را اجرا می‌کند، تنظیم کنید. ویژگی‌های زیر این رفتار را کنترل می‌کنند:

- [advance_on_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) اجازه می‌دهد بیننده با کلیک ماوس پیشرفت کند.
- [advance_after](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) پیشرفت خودکار را فعال می‌کند.
- [advance_after_time](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) تاخیر قبل از پیشرفت خودکار را برحسب میلی‌ثانیه مشخص می‌کند.

هر دو پیشرفت با کلیک و پیشرفت زمان‌دار را فعال کنید تا بیننده بتواند با کلیک ادامه دهد یا صبر کند تا زمان‌سنج جلوی پیشرفت را بگیرد. برای استفاده فقط از زمان‌سنج، [advance_on_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) را به `False` تنظیم کنید. تاخیر زمان‌سنج زمان پیشرفت نمایش اسلاید را تعیین می‌کند؛ مدت زمان اثر انتقال بصری را تعیین نمی‌کند.

این مثال اثرهای مختلفی را به سه اسلاید اول اختصاص می‌دهد و پیشرفت خودکار را پس از 3، 5 و 7 ثانیه به ترتیب فعال می‌کند. کلیک‌های ماوس نیز می‌توانند این اسلایدها را پیشرفت دهند. از فایلی به نام `input.pptx` که حداقل سه اسلاید دارد استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

برای بررسی اینکه آیا پیشرفت زمان‌دار فعال است یا نه، مقدار [advance_after](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) را بخوانید. یک تاخیر ذخیره‌شده به تنهایی نشانگر فعال بودن زمان‌سنج نیست.

مثال بعدی فایلی را که در بالا ذخیره شد باز می‌کند، هر زمان‌سنج فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای آن اسلایدها کلیک ماوس را فعال می‌کند و تنظیمات به‌روز شده را ذخیره می‌نماید.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **کنترل دقیق زمان‌بندی انتقال**

از [duration](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/duration/) برای مشخص کردن طول دقیق یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. ویژگی [slide_show_transition](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/slide_show_transition/) اسلاید این تنظیمات را از طریق [SlideShowTransition](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/) در دسترس می‌گذارد:

| Property | Purpose |
| --- | --- |
| [duration](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | مدت زمان خود اثر انتقال را بر حسب میلی‌ثانیه تنظیم می‌کند. |
| [advance_after_time](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | تاخیر قبل از پیشرفت خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این زمان‌سنج، [advance_after](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) را فعال کنید. |
| [speed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | یک دسته سرعت پیش‌تعریف‌شده را از [TransitionSpeed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitionspeed/) انتخاب می‌کند: SLOW، MEDIUM یا FAST. زمانی که مدت زمان دقیق مشخص نشده باشد، استفاده می‌شود. |

[duration](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/duration/) فقط بر اثر انتقال تأثیر می‌گذارد؛ مدت زمان ماندن اسلاید روی صفحه را تعیین نمی‌کند. تاخیر پیشرفت خودکار را جداگانه تنظیم کنید. وقتی مدت زمان صریحی تنظیم نشده باشد، Aspose.Slides مدت زمان اثر را از نوع انتقال و مقدار [speed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/speed/) تعیین می‌کند.

### **اعمال همان مدت زمان به همه اسلایدها**

برای حفظ رتم ثابت، همان اثر و همان مدت زمان دقیق را به هر اسلاید اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، Fade را از [TransitionType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitiontype/) انتخاب می‌کند و به هر انتقال مدت زمان 750 میلی‌ثانیه اختصاص می‌دهد. همچنین پیشرفت خودکار پس از 5,000 میلی‌ثانیه را فعال می‌کند و پیشرفت با کلیک ماوس را غیرفعال می‌نماید، سپس نتیجه را به صورت PPTX ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # پیکربندی پیشرفت خودکار به‌صورت مستقل از مدت زمان اثر.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **تنظیم مدت زمان‌های مختلف برای اسلایدهای جداگانه**

اسلایدهای مختلف می‌توانند مدت زمان اثرهای متفاوتی داشته باشند. برای مثال، برای اسلاید عنوان یک انتقال کوتاه و برای معرفی بخش یک انتقال طولانی‌تر استفاده کنید. این مثال 500 میلی‌ثانیه برای اسلاید اول و 1,200 میلی‌ثانیه برای اسلاید دوم تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **هماهنگی انتقال‌ها با خروجی انیمیشنی**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/python-net/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/python-net/export-to-html5/)، یا [video](/slides/fa/python-net/convert-powerpoint-to-video/)، قبل از صادرات دقیق مدت زمان انتقال‌ها را تنظیم کنید تا با ریتم مورد نظر منطبق شود. برای مثال، از یک محو شدن 600 میلی‌ثانیه‌ای بین صحنه‌ها استفاده کنید و تاخیر پیشرفت هر اسلاید را به‌طور جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوای آن فراهم شود.

برای GIF و ویدئو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: 600 میلی‌ثانیه معادل 18 فریم در سرعت 30 فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. فرمت خروجی انتخابی را برای اثرات و گزینه‌های زمان‌بندی پشتیبانی‌شده بررسی کنید و خروجی را پیش‌نمایش کنید تا هماهنگی را تأیید نمایید.

### **خواندن مدت زمان انتقال موجود**

قبل از تغییر انتقال، مقدار [duration](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/duration/) را بخوانید تا مشخص شود آیا مقدار صریحی ذخیره شده است یا خیر. مقدار `-1` به این معنی است که مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده را برحسب میلی‌ثانیه نشان می‌دهد. مقدار تنظیم‌نشده برابر با مدت زمان محاسبه‌شده برای پخش نیست: Aspose.Slides از نوع انتقال و [speed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/speed/) برای تعیین آن مدت زمان استفاده می‌کند. تنظیم نوع انتقال می‌تواند یک مدت زمان را مقداردهی اولیه کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **انتقال Morph**

انتقال Morph تغییرات بین اشیاء روی اسلایدهای متوالی را انیمیت می‌کند. برای ایجاد یک اثر Morph ساده، یک اسلاید را کلون کنید، یک شیء را در کلون جابجا یا تغییر اندازه دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار به اشیاء مرتبط اجازه می‌دهد بین حالت اصلی و حالت تغییر یافته انیمیشن شوند.

مثال زیر یک اسلاید با یک مستطیل متنی ایجاد می‌کند، اسلاید را کلون می‌کند و موقعیت و اندازه مستطیل را در کلون تغییر می‌دهد. سپس Morph را از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitiontype/) برای اسلاید دوم انتخاب می‌کند. فایل ذخیره‌شده را در یک نمایشگر ارائه‌ای که Morph را پشتیبانی می‌کند باز کنید تا اثر را در حین نمایش اسلاید ببینید.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **انواع انتقال Morph**

شمارش‌گر [TransitionMorphType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitionmorphtype/) نحوه تطبیق و انیمیشن محتوا را کنترل می‌کند:

- [BY_OBJECT](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitionmorphtype/) هر شکل را به عنوان یک شیء کامل در نظر می‌گیرد.
- [BY_WORD](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitionmorphtype/) متن را با مطابقت کلمات (در صورت امکان) انیمیت می‌کند.
- [BY_CHAR](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitionmorphtype/) متن را با مطابقت حروف (در صورت امکان) انیمیت می‌کند.

قبل از دسترسی به [value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/value/) انتقال، نوع [type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/type/) را به Morph تنظیم کنید. سپس مقدار [MorphTransition](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/morphtransition/) را دریافت کنید، که ویژگی [morph_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/morphtransition/morph_type/) موضع تطبیق را انتخاب می‌کند.

این مثال ارائه‌ای که در بخش قبلی ایجاد شد را باز می‌کند و اسلاید دوم را برای استفاده از انیمیشن Morph بر پایه کلمه تنظیم می‌نماید.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **تنظیم اثرات انتقال**

برخی از انتقال‌ها گزینه‌های اضافی مانند جهت یا اینکه آیا اثر از صفحه سیاه شروع شود را افشا می‌کنند. گزینه‌های موجود بستگی به نوع انتقال [type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/type/) انتخاب‌شده دارد. ابتدا نوع را تنظیم کنید، سپس از شیء انتقال مناسب از طریق [value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/value/) استفاده کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. از [from_black](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) از طریق [OptionalBlackTransition](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/optionalblacktransition/) استفاده می‌کند تا انتقال از صفحه سیاه شروع شود.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **پرسش‌های متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. زمانی که به مدت دقیق اثر در میلی‌ثانیه نیاز دارید، از [duration](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/duration/) استفاده کنید. زمانی که یک دسته سرعت پیش‌تعریف‌شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitionspeed/) — SLOW، MEDIUM یا FAST — کافی است و مدت زمان صریحی تنظیم نشده، از [speed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/speed/) استفاده کنید. این تنظیمات اثر انتقال را به‌صورت مستقل از تاخیر پیشرفت خودکار کنترل می‌کند.

**آیا می‌توانم صدا به یک انتقال اضافه کنم و آن را حلقه‌دار کنم؟**

بله. صدا داخلی را به [sound](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/sound/) اختصاص دهید، [sound_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) را به START_SOUND از شمارش‌گر [TransitionSoundMode](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitionsoundmode/) تنظیم کنید و [sound_loop](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) را فعال کنید. صدا تا رخداد صوتی بعدی در نمایش اسلاید حلقه می‌زند.

**سریع‌ترین روش برای اعمال یک انتقال یکسان به همه اسلایدها چیست؟**

در مجموعه [slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slides/fa/) ارائه حلقه بزنید و برای هر اسلاید ویژگی [type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/type/) انتقال را به همان مقدار تنظیم کنید. هر گزینه زمانی و اثر را در همان حلقه تنظیم کنید تا رفتار در تمام اسلایدها یکسان باشد.

**چگونه می‌توانم بررسی کنم که چه انتقالی در حال حاضر بر روی یک اسلاید تنظیم شده است؟**

ویژگی [type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/type/) را از [slide_show_transition](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/slide_show_transition/) اسلاید بخوانید. این مقدار از شمارش‌گر [TransitionType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitiontype/) برمی‌گردد؛ NONE بدین معنی است که هیچ اثر انتقالی اعمال نشده است.