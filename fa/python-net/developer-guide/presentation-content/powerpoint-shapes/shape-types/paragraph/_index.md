---
title: دریافت محدوده پاراگراف‌ها از ارائه‌ها در پایتون
linktitle: پاراگراف
type: docs
weight: 60
url: /fa/python-net/paragraph/
keywords:
- محدوده پاراگراف
- محدوده بخش متن
- مختصات پاراگراف
- مختصات بخش
- اندازه پاراگراف
- اندازه بخش متن
- قاب متن
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه محدوده‌های پاراگراف و بخش متن را در Aspose.Slides برای پایتون از طریق .NET بازیابی کنید تا موقعیت‌یابی متن در ارائه‌های پاورپوینت و OpenDocument بهینه شود."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه مرزها، اندازه و مختصات پاراگراف‌ها و بخش‌های متن در Aspose.Slides را دریافت کنید. نشان می‌دهد چگونه مستطیل یک پاراگراف را در یک `TextFrame` با استفاده از `get_rect()` بازیابی کنید، چگونگی دریافت مختصات پاراگراف و بخش داخل قاب متن سلول جدول، و جزئیات مهمی مانند واحدهای اندازه‌گیری، تأثیر بسته‌بندی متن بر مرزها، تبدیل به پیکسل، و مقادیر قالب‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دریافت مختصات پاراگراف و بخش در TextFrame**

با استفاده از Aspose.Slides for Python via .NET، توسعه‌دهندگان اکنون می‌توانند مختصات مستطیلی یک Paragraph را در مجموعه پاراگراف‌های TextFrame دریافت کنند. همچنین امکان دریافت مختصات بخش داخل مجموعه بخش‌های یک پاراگراف را فراهم می‌کند. در این موضوع، با کمک یک مثال نشان خواهیم داد که چگونه مختصات مستطیلی یک پاراگراف را همراه با موقعیت بخش داخل آن دریافت کنیم.

## **دریافت مختصات مستطیلی پاراگراف**

متد جدید **GetRect()** افزوده شده است. این متد امکان دریافت مستطیل مرزهای پاراگراف را فراهم می‌کند.

```py
import aspose.slides as slides

# شیء Presentation را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **دریافت اندازه پاراگراف و بخش داخل قاب متن سلول جدول** ##

برای دریافت اندازه و مختصات [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) یا [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) در یک قاب متن سلول جدول، می‌توانید از متدهای [IPortion.GetRect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iportion/) و [IParagraph.GetRect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iparagraph/) استفاده کنید.

این کد نمونه عملیات توصیف شده را نشان می‌دهد:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **پرسش‌های متداول**

**مختصات بازگردانده‌شده برای یک پاراگراف و بخش‌های متن بر حسب چه واحدی اندازه‌گیری می‌شود؟**

در واحد نقطه (points) است، به طوری که 1 اینچ = 72 نقطه. این برای تمام مختصات و ابعاد روی اسلاید اعمال می‌شود.

**آیا بسته‌بندی متن (word wrapping) بر مرزهای یک پاراگراف تأثیر می‌گذارد؟**

بله. اگر [wrapping](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/wrap_text/) در [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) فعال باشد، متن به‌طوری شکسته می‌شود که با عرض ناحیه مطابقت داشته باشد، که باعث تغییر مرزهای واقعی پاراگراف می‌شود.

**آیا می‌توان مختصات پاراگراف را به‌طور قابل اعتماد به پیکسل‌ها در تصویر خروجی تبدیل کرد؟**

بله. می‌توانید نقاط را به پیکسل تبدیل کنید با استفاده از: pixels = points × (DPI / 72). نتیجه به DPI انتخاب‌شده برای رندر/صدور وابسته است.

**چگونه می‌توانم پارامترهای قالب‌بندی «موثر» پاراگراف را دریافت کنم که ارث‌بری استایل را نیز در نظر بگیرد؟**

از [ساختار داده قالب‌بندی مؤثر پاراگراف](/slides/fa/python-net/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی تجمعی برای تو رفتگی‌ها، فواصل، بسته‌بندی، راست به چپ و موارد دیگر را برمی‌گرداند.