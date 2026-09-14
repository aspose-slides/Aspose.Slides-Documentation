---
title: مدیریت قلم‌ها در ارائه‌ها با استفاده از Python via Java
linktitle: مدیریت قلم‌ها
type: docs
weight: 10
url: /fa/python-java/manage-fonts/
keywords:
- مدیریت قلم‌ها
- ویژگی‌های قلم
- پاراگراف
- قالب‌بندی متن
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "قلم‌ها را در Python via Java با Aspose.Slides کنترل کنید: تعبیه، جایگزینی و بارگذاری قلم‌های سفارشی برای حفظ وضوح، امنیت برند و سازگاری ارائه‌های PPT، PPTX و ODP."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های قلم را در متن ارائه‌ها مستقیماً از کد خود مدیریت کنید. می‌توانید متن را در اسلایدها از طریق اشکال، فریم‌های متن، پاراگراف‌ها و بخش‌ها دسترسی داشته باشید و سپس قالب‌بندی را بر روی متن انتخاب شده اعمال کنید.

این مقاله توضیح می‌دهد چگونه ویژگی‌های مربوط به قلم برای متن موجود در یک ارائه تنظیم شود، شامل خانواده قلم، استایل‌های بولد و ایتالیک، تراز پاراگراف و رنگ قلم. همچنین نحوه ایجاد یک جعبه متن، افزودن متن به آن، و تنظیم ویژگی‌های قلم مانند خانواده قلم، بولد، ایتالیک، زیرخط، اندازه قلم و رنگ قبل از ذخیره نتیجه به عنوان فایل PPTX را نشان می‌دهد.

## **مدیریت ویژگی‌های مربوط به قلم**
{{% alert color="info" title="Note" %}} 

ارائه‌ها معمولاً شامل هر دو متن و تصویر هستند. متن می‌تواند به روش‌های مختلفی قالب‌بندی شود، چه برای برجسته‌سازی بخش‌ها و کلمات خاص و چه برای مطابقت با سبک‌های شرکتی. قالب‌بندی متن به کاربران امکان می‌دهد ظاهر محتوای ارائه را متنوع سازند. این مقاله نشان می‌دهد چگونه از Aspose.Slides برای Python via Java برای پیکربندی ویژگی‌های قلم پاراگراف‌های متن در اسلایدها استفاده شود.

{{% /alert %}} 

برای مدیریت ویژگی‌های قلم یک پاراگراف با استفاده از Aspose.Slides برای Python via Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، مرجع یک اسلاید را دریافت کنید.
1. اشکال [Placeholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/placeholder/) را در اسلاید به عنوان [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) دسترسی پیدا کنید.
1. [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) را از [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) که توسط [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) ارائه شده، دریافت کنید.
1. پاراگراف را تنظیم (Justify) کنید.
1. متن یک [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) را از طریق [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) دسترسی پیدا کنید.
1. قلم را با استفاده از [FontData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontdata/) تعریف کنید و **Font** متن [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) را به‌طور مناسب تنظیم کنید.
   1. قلم را به بولد تنظیم کنید.
   1. قلم را به ایتالیک تنظیم کنید.
1. رنگ قلم را با استفاده از [FillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/) که توسط شیء [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) ارائه شده، تنظیم کنید.
1. ارائهٔ تغییر یافته را به فایل PPTX ذخیره کنید.

پیاده‌سازی مراحل فوق در زیر آورده شده است. این کد یک ارائهٔ ساده را می‌گیرد و قلم‌های یک اسلاید را قالب‌بندی می‌کند. اسکرین‌شات‌های زیر فایل ورودی و نحوهٔ تغییر آن توسط کدها را نشان می‌دهند. کد قلم، رنگ و استایل قلم را تغییر می‌دهد.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**شکل: متن در فایل ورودی**|


|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**شکل: همان متن با قالب‌بندی به‌روز شده**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

    # بارگذاری ارائه.
    presentation = Presentation("FontProperties.pptx")
    try:
        # دسترسی به اولین اسلاید و فریم‌های متنی دو جای‌دارندهٔ اول آن.
        slide = presentation.getSlides().get_Item(0)
        title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
        body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

        # دسترسی به اولین پاراگراف در هر فریم متن.
        title_paragraph = title_text_frame.getParagraphs().get_Item(0)
        body_paragraph = body_text_frame.getParagraphs().get_Item(0)
        body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

        # دسترسی به اولین بخش در هر پاراگراف.
        title_portion = title_paragraph.getPortions().get_Item(0)
        body_portion = body_paragraph.getPortions().get_Item(0)

        # تعریف و اختصاص قلم‌های جدید.
        title_font = FontData("Elephant")
        body_font = FontData("Castellar")
        title_portion.getPortionFormat().setLatinFont(title_font)
        body_portion.getPortionFormat().setLatinFont(body_font)

        # تنظیم قلم‌ها به حالت بولد و ایتالیک.
        title_portion.getPortionFormat().setFontBold(NullableBool.True_)
        body_portion.getPortionFormat().setFontBold(NullableBool.True_)
        title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
        body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

        # تنظیم رنگ قلم‌ها.
        title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
        body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

        # ذخیرهٔ ارائه.
        presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

## **تنظیم ویژگی‌های قلم متن**
{{% alert color="info" title="Note" %}} 

همان‌طور که در **مدیریت ویژگی‌های مربوط به قلم** اشاره شد، یک [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) برای نگهداری متنی با سبک قالب‌بندی مشابه در یک پاراگراف استفاده می‌شود. این مقاله نشان می‌دهد چگونه از Aspose.Slides برای Python via Java برای ایجاد یک جعبه متن با برخی متن و سپس تعریف قلم خاص و ویژگی‌های مختلف قلم استفاده شود.

{{% /alert %}} 

برای ایجاد یک جعبه متن و تنظیم ویژگی‌های قلم متن داخل آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، مرجع یک اسلاید را دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) از نوع **Rectangle** به اسلاید اضافه کنید.
1. سبک پر کننده مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) را حذف کنید.
1. به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) شیء [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) دسترسی پیدا کنید.
1. برخی متن را به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) اضافه کنید.
1. به شیء [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) مرتبط با [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) دسترسی پیدا کنید.
1. قلم مورد استفاده برای [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) را تعریف کنید.
1. سایر ویژگی‌های قلم مانند بولد، ایتالیک، زیرخط، رنگ و ارتفاع را با استفاده از ویژگی‌های مربوطه که توسط شیء [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) ارائه شده، تنظیم کنید.
1. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

پیاده‌سازی مراحل فوق در زیر آورده شده است.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**شکل: متن با برخی ویژگی‌های قلم که توسط Aspose.Slides برای Python via Java تنظیم شده است**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # دریافت اولین اسلاید و افزودن یک مستطیل.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # حذف پر شدن شکل.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # افزودن متن به فریم متنی شکل.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # تنظیم خانواده قلم.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # تنظیم بولد، ایتالیک، زیرخط و اندازه قلم.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # تنظیم رنگ قلم.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # ذخیرهٔ ارائه.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```