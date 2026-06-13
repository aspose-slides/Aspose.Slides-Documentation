---
title: مدیریت متن فوقانی و زیرنویس در پایتون
linktitle: متن فوقانی و زیرنویس
type: docs
weight: 80
url: /fa/python-net/superscript-and-subscript/
keywords:
- متن فوقانی
- متن زیرنویس
- اضافه کردن متن فوقانی
- اضافه کردن متن زیرنویس
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "در Aspose.Slides برای پایتون از طریق .NET به تسلط بر متن فوقانی و زیرنویس بپردازید و ارائه‌های خود را با قالب‌بندی حرفه‌ای متن برای حداکثر تأثیر ارتقا دهید."
---
## **بررسی کلی**

Aspose.Slides قابلیت‌های مورد نیاز برای ادغام متن فوقانی و زیرنویس را در ارائه‌های PowerPoint (PPT, PPTX) و OpenDocument (ODP) شما فراهم می‌کند. چه برای برجسته‌سازی فرمول‌های شیمیایی، معادلات ریاضی، یا افزودن حاشیه‌نویس به محتوا نیاز داشته باشید، این گزینه‌های قالب‌بندی تخصصی به حفظ وضوح و دقت کمک می‌کند. در این مقاله، نحوهٔ اعمال یک‌پارچهٔ سبک‌های فوقانی و زیرنویس را یاد می‌گیرید و تضمین می‌کنید که هر اسلاید نتایج حرفه‌ای داشته باشد.

## **افزودن متن فوقانی و زیرنویس**

می‌توانید متن فوقانی و زیرنویس را به هر بخش پاراگراف اضافه کنید. در Aspose.Slides، از ویژگی `escapement` کلاس [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) برای کنترل این مورد استفاده کنید.

`escapement` یک درصد بین **-100% تا 100%** است:

- **> 0** → فوقانی (مثلاً ۲۵٪ = کمی بالا; ۱۰۰٪ = فوقانی کامل)
- **0** → خط پایه (بدون فوقانی/زیرنویس)
- **< 0** → زیرنویس (مثلاً -۲۵٪ = کمی پایین; -۱۰۰٪ = زیرنویس کامل)

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و یک اسلاید به دست آورید.  
2. یک [AutoShape] مستطیل اضافه کنید و به [TextFrame] آن دسترسی پیدا کنید.  
3. پاراگراف‌های موجود را پاک کنید.  
4. برای فوقانی: یک پاراگراف و یک portion ایجاد کنید، `portion.portion_format.escapement` را به مقداری بین **0 تا 100** تنظیم کنید، متن را تنظیم کنید و portion را اضافه کنید.  
5. برای زیرنویس: یک پاراگراف و portion دیگر ایجاد کنید، `escapement` را به مقداری بین **-100 تا 0** تنظیم کنید، متن را تنظیم کنید و portion را اضافه کنید.  
6. ارائه را به صورت PPTX ذخیره کنید.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # دریافت یک اسلاید.
    slide = presentation.slides[0]

    # ایجاد یک جعبه متن.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # ایجاد یک پاراگراف برای متن فوقانی.
    superscript_paragraph = slides.Paragraph()

    # ایجاد یک بخش متن با متن عادی.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # ایجاد یک بخش متن با متن فوقانی.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # ایجاد یک پاراگراف برای متن زیرنویس.
    subscript_paragraph = slides.Paragraph()

    # ایجاد یک بخش متن با متن عادی.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # ایجاد یک بخش متن با متن زیرنویس.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # افزودن پاراگراف‌ها به جعبه متن.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا می‌توانم فوقانی/زیرنویس را در جدول‌ها و سایر کانتینرها، نه فقط در جعبه‌های متن معمولی، اعمال کنم؟**

بله. می‌توانید متن را به صورت فوقانی یا زیرنویس داخل هر شیئی که یک [TextFrame] ارائه می‌دهد (از جملهٔ سلول‌های جدول) قالب‌بندی کنید. این قالب‌بندی بر روی بخش‌های متنی داخل آن فریم اعمال می‌شود.

**آیا هنگام خروجی به PDF، HTML یا تصاویر، فوقانی/زیرنویس حفظ می‌شود؟**

بله. Aspose.Slides هنگام خروجی به قالب‌های رایج مانند [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/)، [HTML](/slides/fa/python-net/convert-powerpoint-to-html/)، و [raster images](/slides/fa/python-net/convert-powerpoint-to-png/) قالب‌بندی فوقانی/زیرنویس را حفظ می‌کند زیرا خطوط رندر متن سطح portion را رعایت می‌کند.

**آیا می‌توانم فوقانی/زیرنویس را با پیوندهای هیپرلینک در یک بخش متنی ترکیب کنم؟**

بله. [Hyperlinks](/slides/fa/python-net/manage-hyperlinks/) در سطح portion (قطعه) اختصاص می‌یابند، بنابراین یک portion می‌تواند همزمان یک هیپرلینک داشته باشد و به صورت فوقانی یا زیرنویس قالب‌بندی شود.