---
title: دریافت مرزهای پاراگراف از ارائه‌ها در پایتون
linktitle: مرزهای پاراگراف
type: docs
weight: 43
url: /fa/python-net/paragraph-bounds/
keywords:
- مرزهای پاراگراف
- مختصات پاراگراف
- اندازه پاراگراف
- قاب متن
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه مرزهای پاراگراف را در Aspose.Slides برای پایتون از طریق .NET دریافت کنید تا موقعیت‌یابی متن را در ارائه‌های PowerPoint و OpenDocument بهینه کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه مرزها، اندازه و مختصات پاراگراف‌ها را در Aspose.Slides به‌دست آورید. نشان می‌دهد چگونه مستطیل یک پاراگراف را از یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) با استفاده از [Paragraph.get_rect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/get_rect/) بازیابی کنید، چگونه مختصات پاراگراف را در داخل TextFrame سلول جدول به‌دست آورید، و جزئیات مهمی مانند واحدهای اندازه‌گیری، تأثیر بسته شدن متن بر مرزها، تبدیل به پیکسل، و مقادیر قالب‌بندی «موثر» پاراگراف را برجسته می‌کند.

## **دریافت مختصات مستطیلی یک پاراگراف**

از [Paragraph.get_rect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/get_rect/) برای دریافت مستطیل محدوده یک پاراگراف استفاده کنید.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **دریافت اندازه یک پاراگراف در داخل TextFrame سلول جدول**

برای به‌دست آوردن اندازه و مختصات یک [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) در یک TextFrame سلول جدول، از [Paragraph.get_rect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/get_rect/) استفاده کنید. مستطیل بازگشتی نسبت به TextFrame سلول جدول است، بنابراین هنگام نیاز به مختصات سطح اسلاید، موقعیت جدول و جابجایی سلول را اضافه کنید.

مثال زیر مرزهای پاراگراف را در داخل سلول جدول دریافت کرده و مستطیل‌هایی را روی اسلاید رسم می‌کند تا این مرزها را به‌صورت بصری نشان دهد:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**مختصات پاراگراف‌ها با چه واحدی اندازه‌گیری می‌شوند؟**

آنها بر حسب نقطه (point) اندازه‌گیری می‌شوند، به‌طوری‌که ۱ اینچ برابر ۷۲ نقطه است. این برای تمام مختصات و ابعاد روی اسلاید اعمال می‌شود.

**آیا بسته شدن متن بر مرزهای پاراگراف تأثیر می‌گذارد؟**

بله. اگر گزینه [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/wrap_text/) برای [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) فعال باشد، متن برای متناسب شدن با عرض ناحیه شکسته می‌شود که باعث تغییر مرزهای واقعی پاراگراف می‌شود.

**آیا می‌توان مختصات پاراگراف را به‌صورت قابل اعتماد به پیکسل‌ها در تصویر صادرشده تبدیل کرد؟**

بله. برای تبدیل نقطه به پیکسل می‌توانید از فرمول زیر استفاده کنید: پیکسل = نقطه × (DPI / ۷۲). نتیجه بستگی به DPI انتخاب‌شده برای رندر یا خروجی دارد.

**چگونه پارامترهای قالب‌بندی «موثر» پاراگراف را که وراثت سبک را در نظر می‌گیرد، دریافت کنم؟**

از [effective paragraph formatting data structure](/slides/fa/python-net/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی یکپارچه برای تورفتگی‌ها، فاصله‌ها، بسته شدن متن، راست به چپ (RTL) و موارد دیگر را برمی‌گرداند.