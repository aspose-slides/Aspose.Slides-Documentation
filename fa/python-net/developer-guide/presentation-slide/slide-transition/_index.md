---
title: مدیریت انتقال اسلایدها در ارائه‌ها با Python
linktitle: انتقال اسلاید
type: docs
weight: 90
url: /fa/python-net/slide-transition/
keywords:
- انتقال اسلاید
- اضافه‌کردن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال اسلاید پیشرفته
- انتقال مورف
- نوع انتقال
- افکت انتقال
- Python
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید انتقال اسلایدها را در Aspose.Slides برای Python از طریق .NET سفارشی کنید، همراه با راهنمای گام به گام برای ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

Aspose.Slides برای Python کنترل کامل بر انتقال‌های اسلاید را فراهم می‌کند، از انتخاب نوع انتقال تا پیکربندی زمان‌بندی و محرک‌ها به عنوان بخشی از جریان‌های کاری خودکار ارائه. می‌توانید اسلایدها را برای پیشرفت با کلیک و/یا پس از تأخیر مشخص تنظیم کنید و رفتار بصری را با افکت‌هایی مانند قطع به‌صورت سیاه یا ورودی‌های جهت‌دار بهبود بخشید. این کتابخانه همچنین از انتقال Morph معرفی‌شده در PowerPoint 2019 پشتیبانی می‌کند، از جمله حالت‌هایی که بر اساس شیء، کلمه یا کاراکتر مورف می‌شوند تا حرکت صاف و یکپارچه‌ای بین اسلایدها ایجاد کنند.

## **افزودن انتقال اسلاید**

برای درک آسان‌تر، این مثال نشان می‌دهد که چگونه می‌توان از Aspose.Slides برای Python برای مدیریت انتقال‌های ساده اسلاید استفاده کرد. توسعه‌دهندگان می‌توانند افکت‌های مختلف انتقال اسلاید را بر روی اسلایدها اعمال و رفتار آن‌ها را سفارشی کنند. برای ایجاد یک انتقال اسلاید ساده، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. یک انتقال اسلاید را با استفاده از یکی از افکت‌های موجود در enum [TransitionType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitiontype/) اعمال کنید.  
1. فایل ارائه اصلاح‌شده را ذخیره کنید.  

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation برای بارگذاری فایل ارائه.
with slides.Presentation("sample.pptx") as presentation:
    # اعمال انتقال دایره‌ای به اسلاید 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # اعمال انتقال شانه‌ای به اسلاید 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # ذخیرهٔ ارائه در دیسک.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن انتقال پیشرفته اسلاید**

در این بخش، یک افکت انتقال ساده را بر روی اسلاید اعمال کردیم. برای کنترل و صیقل بیشتر این افکت، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. یک انتقال اسلاید را با استفاده از یکی از افکت‌های موجود در enum [TransitionType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitiontype/) اعمال کنید.  
1. انتقال را طوری تنظیم کنید که با Advance On Click، پس از مدت زمان مشخص یا هر دو پیش برود.  
1. فایل ارائه اصلاح‌شده را ذخیره کنید.  

اگر **Advance On Click** فعال باشد، اسلاید فقط با کلیک کاربر پیش می‌رود. اگر ویژگی **Advance After Time** تنظیم شده باشد، اسلاید به‌صورت خودکار پس از بازه زمانی مشخص پیش می‌رود.  

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation برای باز کردن فایل ارائه.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # اعمال انتقال دایره‌ای به اسلاید 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # فعال‌سازی پیشروی هنگام کلیک و تنظیم پیشروی خودکار 3 ثانیه‌ای.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # اعمال انتقال شانه‌ای به اسلاید 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # فعال‌سازی پیشروی هنگام کلیک و تنظیم پیشروی خودکار 5 ثانیه‌ای.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # اعمال انتقال زوم به اسلاید 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # فعال‌سازی پیشروی هنگام کلیک و تنظیم پیشروی خودکار 7 ثانیه‌ای.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # ذخیرهٔ ارائه بر روی دیسک.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **انتقال مورف**

Aspose.Slides برای Python از [Morph transition](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/morphtransition/) پشتیبانی می‌کند که حرکت نرم از یک اسلاید به اسلاید بعدی را انیمیشن می‌نماید. این بخش توضیح می‌دهد چگونه از انتقال Morph استفاده کنید. برای استفاده مؤثر از آن، به دو اسلاید نیاز دارید که حداقل یک شیء مشترک داشته باشند. ساده‌ترین روش تکرار یک اسلاید و سپس جابجایی شیء به موقعیت متفاوت در اسلاید دوم است.

کد زیر نشان می‌دهد چگونه یک اسلاید حاوی متن را کلون کنید و انتقال Morph را به اسلاید دوم اعمال کنید.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # کپی کردن اسلاید اول برای ایجاد اسلاید دوم با همان اشکال جهت حفظ پیوستگی Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # انتخاب همان مستطیل در اسلاید دوم و تغییر موقعیت و اندازه آن.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # فعال‌سازی انتقال Morph در اسلاید دوم برای انیمیشن صاف تغییرات شکل.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **انواع انتقال مورف**

enum [TransitionMorphType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitionmorphtype/) انواع مختلف انتقال اسلایدهای Morph را نشان می‌دهد.

کد زیر نشان می‌دهد چگونه یک انتقال Morph را به اسلاید اعمال کنید و نوع morph را تغییر دهید:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم افکت‌های انتقال**

Aspose.Slides برای Python به شما امکان می‌دهد افکت‌های انتقالی مانند **From Black**، **From Left**، **From Right** و غیره را تنظیم کنید. برای پیکربندی یک افکت انتقال، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. یک مرجع به اسلاید دریافت کنید.  
1. افکت انتقال دلخواه را تنظیم کنید.  
1. ارائه را به‌صورت فایل PPTX ذخیره کنید.  

در مثال زیر، ما چندین افکت انتقال را تنظیم کرده‌ایم.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation برای باز کردن فایل ارائه.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # اعمال انتقال Cut و فعال‌سازی From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # ذخیرهٔ ارائه بر روی دیسک.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. سرعت انتقال را با استفاده از تنظیم [TransitionSpeed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/transitionspeed/) (مثلاً slow/medium/fast) تنظیم کنید. می‌توانید از [speed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/speed/) نیز استفاده نمایید.  

**آیا می‌توانم صدا به یک انتقال وصل کنم و آن را به صورت حلقه‌ای پخش کنم؟**

بله. می‌توانید صدایی را برای انتقال جاسازی کنید و رفتار آن را از طریق تنظیماتی مانند [sound](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/sound/)، [sound_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/)، [sound_loop](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) کنترل کنید، به‌علاوه داده‌های متا مانند [sound_is_built_in](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) و [sound_name](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/).  

**سریع‌ترین راه برای اعمال همان انتقال بر تمام اسلایدها چیست؟**

نوع انتقال موردنظر را در تنظیمات انتقال هر اسلاید پیکربندی کنید؛ انتقال‌ها به‌صورت جداگانه برای هر اسلاید ذخیره می‌شوند، بنابراین اعمال یک نوع یکسان بر تمام اسلایدها نتیجهٔ یکسانی می‌دهد.  

**چگونه می‌توانم بررسی کنم که کدام انتقال در حال حاضر بر روی یک اسلاید تنظیم شده است؟**

تنظیمات [transition](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/slide_show_transition/) اسلاید را بررسی کنید و مقدار [type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.slideshow/slideshowtransition/type/) آن را بخوانید؛ این مقدار دقیقاً نشان می‌دهد کدام افکت اعمال شده است.