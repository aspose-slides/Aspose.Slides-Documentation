---
title: استخراج پیشرفته متن از ارائه‌ها در پایتون
linktitle: استخراج متن
type: docs
weight: 90
url: /fa/python-net/extract-text-from-presentation/
keywords:
- استخراج متن
- استخراج متن از اسلاید
- استخراج متن از ارائه
- استخراج متن از پاورپوینت
- استخراج متن از OpenDocument
- استخراج متن از PPT
- استخراج متن از PPTX
- استخراج متن از ODP
- دریافت متن
- دریافت متن از اسلاید
- دریافت متن از ارائه
- دریافت متن از پاورپوینت
- دریافت متن از OpenDocument
- دریافت متن از PPT
- دریافت متن از PPTX
- دریافت متن از ODP
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "به سرعت متن را از ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET استخراج کنید. راهنمای ساده گام‌به‌گام ما را دنبال کنید تا زمان صرفه‌جویی کنید."
---
## **بررسی کلی**

استخراج متن از ارائه‌ها یک کار رایج اما اساسی برای توسعه‌دهندگانی است که با محتوای اسلایدها کار می‌کنند. چه با فایل‌های Microsoft PowerPoint در فرمت PPT یا PPTX، یا ارائه‌های OpenDocument (ODP) سر و کار داشته باشید، دسترسی و بازیابی داده‌های متنی می‌تواند برای تحلیل، خودکارسازی، ایندکس‌گذاری یا اهداف مهاجرت محتوا حیاتی باشد.

این مقاله راهنمای جامعی برای استخراج مؤثر متن از قالب‌های مختلف ارائه، شامل PPT، PPTX و ODP، با استفاده از Aspose.Slides for Python via .NET فراهم می‌کند. خواهید آموخت که چگونه به‌صورت سیستماتیک بر عناصر ارائه تکرار کنید تا محتوای متنی مورد نیاز خود را به‌دقت بازیابی کنید.

## **استخراج متن از یک اسلاید**

Aspose.Slides for Python via .NET فضای‌نامی [aspose.slides.util](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/) را ارائه می‌دهد که شامل کلاس [SlideUtil](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/slideutil/) است. این کلاس چندین متد ایستا (static) با بارگذاری (overloaded) برای استخراج تمام متن از یک ارائه یا اسلاید فراهم می‌کند. برای استخراج متن از یک اسلاید در یک ارائه، از متد [get_all_text_boxes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) استفاده کنید. این متد یک شیء از نوع [BaseSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/) را به‌عنوان پارامتر می‌گیرد. هنگام اجرا، متد تمام اسلاید را برای متن اسکن می‌کند و یک آرایه از اشیاء نوع [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) را بازمی‌گرداند که قالب‌بندی متن را حفظ می‌کند.

کد زیر تمام متن اولین اسلاید ارائه را استخراج می‌کند:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **استخراج متن از یک ارائه**

برای اسکن متن از کل ارائه، از متد ایستای [get_all_text_frames](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/slideutil/get_all_text_frames/) که توسط کلاس [SlideUtil](https://reference.aspose.com/slides/fa/python-net/aspose.slides.util/slideutil/) ارائه می‌شود، استفاده کنید. این متد دو پارامتر می‌پذیرد:

1. ابتدا یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) که نمایانگر یک ارائه PowerPoint یا OpenDocument است و متن از آن استخراج می‌شود.
1. دوم مقدار `Boolean` که نشان می‌دهد آیا اسلایدهای مستر هنگام اسکن متن از ارائه گنجانده شوند یا خیر.

متد یک آرایه از اشیاء نوع [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) را بازمی‌گرداند که شامل اطلاعات قالب‌بندی متن نیز می‌شود. کد زیر متن و جزئیات قالب‌بندی را از یک ارائه، شامل اسلایدهای مستر، اسکن می‌کند.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **استخراج متن دسته‌بندی‌شده و سریع**

کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/) همچنین متدهایی برای استخراج تمام متن از ارائه‌ها فراهم می‌کند:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

آرگومان enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textextractionarrangingmode/) حالت سازماندهی نتیجه استخراج متن را مشخص می‌کند و می‌تواند به مقادیر زیر تنظیم شود:
- `UNARRANGED` - متن خالص بدون توجه به موقعیت آن در اسلاید.
- `ARRANGED` - متن به همان ترتیب که در اسلاید ظاهر می‌شود، سازماندهی می‌شود.

حالت `UNARRANGED` زمانی استفاده می‌شود که سرعت مهم باشد؛ این حالت نسبت به حالت `ARRANGED` سریع‌تر است.

[PresentationText](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationtext/) متن خالص استخراج‌شده از ارائه را نمایان می‌کند. ویژگی `slides_text` آن یک آرایه از اشیاء متن اسلاید را برمی‌گرداند. هر شیء متن مربوط به اسلاید همانند زیر ویژگی‌های زیر را دارد:

- `text` - متنی که در شکل‌های اسلاید قرار دارد.
- `master_text` - متنی که در شکل‌های اسلاید مستر مرتبط با این اسلاید قرار دارد.
- `layout_text` - متنی که در شکل‌های اسلاید لایه‌بندی مرتبط با این اسلاید قرار دارد.
- `notes_text` - متنی که در شکل‌های اسلاید یادداشت‌ها مرتبط با این اسلاید قرار دارد.
- `comments_text` - متنی که در نظرات مرتبط با این اسلاید قرار دارد.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **سؤالات متداول**

**Aspose.Slides در هنگام استخراج متن چقدر سریع می‌تواند ارائه‌های بزرگ را پردازش کند؟**

Aspose.Slides برای عملکرد بالا بهینه‌سازی شده و می‌تواند حتی [ارائه‌های بزرگ](/slides/fa/python-net/open-presentation/) را پردازش کند، به‌طوری که برای سناریوهای پردازش لحظه‌ای یا دسته‌ای مناسب است.

**آیا Aspose.Slides می‌تواند متن را از جداول و نمودارها درون ارائه‌ها استخراج کند؟**

بله. Aspose.Slides می‌تواند متن را از بسیاری از عناصر اسلاید، شامل جداول و اشیاء مرتبط با نمودارها، استخراج کند، بنابراین می‌توانید به محتوای متنی در ساختارهای معمول ارائه دسترسی پیدا کنید و آن را تجزیه و تحلیل کنید.

**آیا برای استخراج متن از ارائه‌ها به لایسنس ویژه‌ای از Aspose.Slides نیاز دارم؟**

می‌توانید با نسخه آزمایشی رایگان Aspose.Slides متن را استخراج کنید، اگرچه این نسخه دارای [محدودیت‌های خاص](/slides/fa/python-net/licensing/) است، مانند پردازش تعداد محدودی اسلاید. برای استفاده بدون محدودیت و پردازش ارائه‌های بزرگ‌تر، خرید لایسنس کامل توصیه می‌شود.