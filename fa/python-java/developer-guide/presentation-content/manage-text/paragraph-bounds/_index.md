---
title: دریافت محدوده‌های پاراگراف از ارائه‌ها در پایتون از طریق جاوا
linktitle: محدوده‌های پاراگراف
type: docs
weight: 43
url: /fa/python-java/paragraph-bounds/
keywords:
- محدوده‌های پاراگراف
- مختصات پاراگراف
- اندازه پاراگراف
- چارچوب متن
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه محدوده‌های پاراگراف را در Aspose.Slides برای پایتون از طریق جاوا بازیابی کنید تا موقعیت‌یابی متن را در ارائه‌های پاورپوینت بهینه کنید."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که چگونه محدوده‌ها، اندازه و مختصات پاراگراف‌ها را در Aspose.Slides به دست آورید. نشان می‌دهد چگونه با استفاده از [Paragraph.getRect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/#getRect) یک مستطیل پاراگراف را از یک [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) بازیابی کنید، چگونه مختصات پاراگراف را در داخل چارچوب متن سلول جدول دریافت کنید، و جزئیات مهمی مانند واحدهای اندازه‌گیری، تأثیر بسته شدن متن بر محدوده‌ها، تبدیل به پیکسل و مقادیر فرمت‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دست‌یابی به مختصات مستطیلی یک پاراگراف**

از [Paragraph.getRect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/#getRect) برای دریافت مستطیل محاطی یک پاراگراف استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **دریافت اندازه یک پاراگراف در داخل چارچوب متن سلول جدول**

برای دریافت اندازه و مختصات یک [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) در چارچوب متن سلول جدول، از [Paragraph.getRect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/#getRect) استفاده کنید. مستطیل بازگشتی نسبت به چارچوب متن سلول جدول است، بنابراین هنگامی که به مختصات سطح اسلاید نیاز دارید، موقعیت جدول و جابجایی سلول را اضافه کنید.

مثال زیر محدوده‌های پاراگراف را در داخل یک سلول جدول دریافت می‌کند و مستطیل‌هایی را بر روی اسلاید رسم می‌نماید تا آن محدوده‌ها را به تصویر بکشد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**واحدهای اندازه‌گیری مختصات پاراگراف چیست؟**

آنها بر حسب نقطه (point) اندازه‌گیری می‌شوند، به طوری که 1 اینچ برابر 72 نقطه است. این برای تمام مختصات و ابعاد روی اسلاید صادق است.

**آیا بسته شدن متن تأثیری بر محدوده پاراگراف دارد؟**

بله. اگر [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setWrapText) برای [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) فعال باشد، متن برای پر شدن عرض ناحیه شکسته می‌شود که باعث تغییر محدوده واقعی پاراگراف می‌گردد.

**آیا می‌توان مختصات پاراگراف را به‌طور قابل اطمینان به پیکسل در تصویر خروجی تبدیل کرد؟**

بله. نقاط را به پیکسل با استفاده از این فرمول تبدیل کنید: پیکسل = نقطه × (DPI / 72). نتیجه به DPI انتخاب شده برای رندر یا خروجی بستگی دارد.

**چگونه می‌توان پارامترهای فرمت‌بندی «مؤثر» پاراگراف را که وراثت استایل را در نظر می‌گیرند به دست آورد؟**

از [ساختار داده‌های فرمت‌بندی مؤثر پاراگراف](/slides/fa/python-java/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی یکپارچه برای تو رفتگی‌ها، فاصله‌ها، بسته شدن، راست به چپ و موارد دیگر را برمی‌گرداند.