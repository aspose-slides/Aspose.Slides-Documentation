---
title: دریافت مرزهای بخش متن از ارائه‌ها در پایتون
linktitle: مرزهای بخش
type: docs
weight: 47
url: /fa/python-net/portion-bounds/
keywords:
- مرزهای بخش متن
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه مرزهای بخش متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون عبر .NET بازیابی کنید."
---
## **بررسی کلی**

بخش متن نمایانگر یک قطعه خاص از متن درون یک پاراگراف است و به شما امکان می‌دهد که به‌صورت مستقل بر روی آن قطعه کار کنید، جدا از محتوای اطراف. در Aspose.Slides، می‌توان از بخش‌ها زمانی استفاده کرد که نیاز به دریافت محدوده یک قطعه متن دارید، قالب‌بندی تنها بخشی از پاراگراف را اعمال کنید، یا رفتار متن را در سطح جزئی‌تری کنترل کنید.

این مقاله نشان می‌دهد چگونه با استفاده از [Portion.get_rect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/get_rect/) مستطیل مرزی یک بخش متن را به‌دست آورید. همچنین نحوه دریافت مختصات ابتدای یک بخش متن با استفاده از [Portion.get_coordinates](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/get_coordinates/) را نشان می‌دهد. به‌علاوه، سناریوهای رایج مرتبط با بخش‌ها را برجسته می‌کند، از جمله اعمال پیوند به یک قطعه متن واحد، درک چگونگی حل‌و‌فصل قالب‌بندی از طریق بخش، پاراگراف، قاب متن و ارث‌بری تم، و رسیدگی به مواردی که یک قلم مشخص در دسترس نیست.

## **دریافت محدودهٔ یک بخش متن**

از [Portion.get_rect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/get_rect/) برای دریافت مستطیل مرزی یک بخش متن استفاده کنید:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **دریافت مختصات یک بخش متن**

از [Portion.get_coordinates](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/get_coordinates/) برای دریافت مختصات ابتدای یک بخش متن استفاده کنید:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **سوالات متداول**

**آیا می‌توانم یک پیوند را فقط بر روی بخشی از متن در یک پاراگراف اعمال کنم؟**

بله، می‌توانید [یک پیوند را اختصاص دهید](/slides/fa/python-net/manage-hyperlinks/) به یک بخش خاص؛ فقط همان قطعه کلیک‌پذیر خواهد بود و کل پاراگراف نه.

**چگونه ارث‌بری سبک کار می‌کند: یک بخش چه چیزی را بازنویسی می‌کند و چه چیزی از پاراگراف یا قاب متن دریافت می‌شود؟**

خصوصیات سطح بخش بالاترین اولویت را دارند. اگر یک خصوصیت در [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) تنظیم نشده باشد، Aspose.Slides آن را از [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) می‌گیرد. اگر در آنجا هم تنظیم نشده باشد، Aspose.Slides از سبک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) یا [theme](https://reference.aspose.com/slides/fa/python-net/aspose.slides.theme/theme/) استفاده می‌کند.

**اگر قلم 지정‌شده برای یک بخش در ماشین یا سرور هدف موجود نباشد چه می‌شود؟**

قوانین جایگزینی قلم [/slides/fa/python-net/font-selection-sequence/] اعمال می‌شوند. متن ممکن است باز جریان شود: معیارها، هیفن‌گذاری و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق اهمیت دارد.

**آیا می‌توانم شفافیت یا گرادیان پر متن را به‌طور مستقل برای بخش خاصی تنظیم کنم، بدون اینکه بر بقیه پاراگراف تأثیر بگذارد؟**

بله، رنگ متن، پر و شفافیت در سطح [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) می‌تواند متفاوت از قطعات همسایه باشد.