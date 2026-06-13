---
title: انیمیشن متن PowerPoint در Python
linktitle: متن انیمیشن‌دار
type: docs
weight: 60
url: /fa/python-net/animated-text/
keywords:
- متن انیمیشن‌دار
- انیمیشن متن
- پاراگراف انیمیشن‌دار
- انیمیشن پاراگراف
- اثر انیمیشن
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "متن پویا و انیمیشن‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET ایجاد کنید، همراه با مثال‌های کد ساده و بهینه."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Python انیمیشن دهید. شما می‌آموزید چگونه افکت‌ها را به پاراگراف‌های جداگانه اضافه کنید، ترِیگرها را تنظیم کنید و توالی‌های انیمیشن موجود را بخوانید. در پایان قادر خواهید بود جریان‌های کار انیمیشن متن قابل استفاده مجدد ایجاد کنید که به فرمت استاندارد PPTX صادر می‌شوند و در PowerPoint به درستی اجرا می‌شوند.

## **افکت‌های انیمیشن پاراگراف اضافه کنید**

متد [add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) کلاس [Sequence](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/) به شما اجازه می‌دهد یک افکت انیمیشن را به یک پاراگراف واحد اعمال کنید. کد نمونه زیر نشان می‌دهد چگونه این کار را انجام دهید:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # برای افزودن افکت پاراگراف را انتخاب کنید.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # افزودن افکت انیمیشن Fly به پاراگراف انتخاب‌شده.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **دریافت افکت‌های انیمیشن پاراگراف**

ممکن است بخواهید تعیین کنید چه افکت‌های انیمیشن بر روی یک پاراگراف اعمال شده‌اند—به عنوان مثال اگر قصد دارید آن افکت‌ها را به پاراگراف یا شکل دیگری کپی کنید.

Aspose.Slides برای Python به شما امکان می‌دهد تمام افکت‌های انیمیشن اعمال‌شده به پاراگراف‌های یک فریم متن (شکل) را بازیابی کنید. کد نمونه زیر نشان می‌دهد چگونه افکت‌های انیمیشن یک پاراگراف را دریافت کنید:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **سؤالات متداول**

**انیمیشن‌های متن چگونه با انتقال اسلاید متفاوت هستند و آیا می‌توان آنها را ترکیب کرد؟**

انیمیشن‌های متن رفتار شیء را در طول زمان روی یک اسلاید کنترل می‌کنند، در حالی که [transitions](/slides/fa/python-net/slide-transition/) نحوه تغییر اسلایدها را تعیین می‌کنند. این دو مستقل هستند و می‌توانند همراه هم استفاده شوند؛ ترتیب پخش توسط خط زمان انیمیشن و تنظیمات انتقال تعیین می‌شود.

**آیا انیمیشن‌های متن در هنگام صادرات به PDF یا تصویر حفظ می‌شوند؟**

نه. PDF و تصاویر رستری ایستا هستند، بنابراین فقط یک وضعیت ثابت از اسلاید بدون حرکت مشاهده می‌کنید. برای حفظ حرکت، از صادرات [video](/slides/fa/python-net/convert-powerpoint-to-video/) یا [HTML](/slides/fa/python-net/export-to-html5/) استفاده کنید.

**آیا انیمیشن‌های متن در لایه‌ها و اسلاید مستر کار می‌کنند؟**

افکت‌های اعمال‌شده به اشیاء لایه/مستر توسط اسلایدها ارث می‌برند، اما زمان‌بندی و تعامل آنها با انیمیشن‌های سطح اسلاید وابسته به توالی نهایی روی اسل slid است.