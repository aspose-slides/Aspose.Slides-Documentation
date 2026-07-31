---
title: مدیریت فهرست‌های نقطه‌دار و عدددار در ارائه‌ها با Python
linktitle: مدیریت فهرست‌ها
type: docs
weight: 70
url: /fa/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
- گلوله
- فهرست نقطه‌دار
- فهرست عدددار
- گلوله نمادین
- گلوله تصویری
- گلوله سفارشی
- فهرست چندسطحی
- ایجاد گلوله
- افزودن گلوله
- افزودن فهرست
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "بیاموزید چگونه فهرست‌های نقطه‌دار، تصویری، چندسطحی و عدددار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET ایجاد و قالب‌بندی کنید."
---
## **Overview**

Aspose.Slides for Python via .NET به شما امکان می‌دهد فهرست‌های نقطه‌دار و عدددار را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست یک پاراگراف است که تنظیمات گلوله آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از خصوصیت [Paragraph.paragraph_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/paragraph_format/) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطهٔ ورود اصلی، [ParagraphFormat.bullet](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/bullet/) است که یک شیء [BulletFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/) برمی‌گرداند. با این شیء می‌توانید نوع گلوله، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شمارهٔ شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- فهرست نقطه‌دار با نماد سفارشی ایجاد کنید
- گلولهٔ تصویری بسازید
- فهرست چندسطحی را با تنظیم عمق پاراگراف ایجاد کنید
- فهرست عدددار بسازید
- قالب‌بندی فهرست را در یک ارائهٔ موجود بررسی و تغییر دهید

## **Create a Bulleted List**

برای ایجاد فهرست نقطه‌دار، اشیاء [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) را به یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید و [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را روی [BulletType.SYMBOL](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید [BulletFormat.char](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/char/)، [BulletFormat.color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/color/)، و [BulletFormat.height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/height/) را برای کنترل ظاهر گلوله تنظیم کنید.

کد پایتون زیر نحوهٔ ایجاد فهرست نقطه‌دار در یک اسلاید را نشان می‌دهد:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The symbol bullets](symbol_bullets.png)

## **Create a Numbered List**

زمانی که ترتیب موارد مهم است از فهرست‌های عدددار استفاده کنید. [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را روی [BulletType.NUMBERED](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید یک قالب شماره‌گذاری را با [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/numbered_bullet_style/) انتخاب کرده یا وقتی فهرست باید از مقداری غیر از 1 شروع شود، [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) را تنظیم کنید.

کد پایتون زیر نحوهٔ ایجاد فهرست عدددار در یک اسلاید را نشان می‌دهد:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The numbered bullets](numbered_bullets.png)

## **Create a Picture Bullet**

Aspose.Slides به شما اجازه می‌دهد نماد گلولهٔ معمولی را با یک تصویر جایگزین کنید. گلوله‌های تصویری بهترین عملکرد را با تصاویر ساده‌ای دارند که در اندازهٔ کوچک نیز خوانا باقی می‌مانند، مانند آیکن‌ها یا فایل‌های PNG شفاف کوچک.

{{% alert color="primary" %}}
در صورت برنامه‌ریزی برای جایگزینی نماد گلولهٔ معمولی با تصویر، بهتر است یک گرافیک ساده با پس‌زمینهٔ شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای گلولهٔ سفارشی به خوبی کار می‌کنند.
{{% /alert %}}

برای ایجاد گلولهٔ تصویری، یک تصویر را به [Presentation.images](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/images/) اضافه کنید و شیء تصویر بازگشتی را به [BulletFormat.picture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/picture/) اختصاص دهید. قبل از اختصاص تصویر، [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را روی [BulletType.PICTURE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید.

فرض کنیم فایلی به نام "image.png" داریم:

![A picture for the bullets](picture_for_bullets.png)

کد پایتون زیر نحوهٔ ایجاد گلوله‌های تصویری در یک اسلاید را نشان می‌دهد:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The picture bullets](picture_bullets.png)

## **Create a Multilevel List**

از [ParagraphFormat.depth](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/depth/) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیر آن تو در تو می‌شود، و به همین ترتیب.

کد پایتون زیر نحوهٔ ایجاد فهرست نقطه‌دار چندسطحی را نشان می‌دهد:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The multilevel list](multilevel_list.png)

## **Change an Existing List**

برای تغییر قالب‌بندی فهرست در یک ارائهٔ موجود، به پاراگراف هدف دسترسی پیدا کنید و تنظیمات [ParagraphFormat.bullet](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/bullet/) آن را به‌روزرسانی کنید. همان خصوصیات استفاده شده برای ایجاد فهرست‌ها می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری‌شده از یک فایل PPT، PPTX یا ODP به کار روند.

کد پایتون زیر اولین پاراگراف در یک فریم متنی را طوری تغییر می‌دهد که از سبک فهرست عدددار استفاده کند:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can bulleted and numbered lists be exported to PDF or images?**

بله. Aspose.Slides قالب‌بندی فهرست‌ها را زمانی که فرمت هدف از چیدمان متن و ویژگی‌های گلوله مربوطه پشتیبانی کند، حفظ می‌کند.

**Can I edit lists in existing presentations?**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [ParagraphFormat.bullet](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/bullet/) را بررسی یا به‌روزرسانی کنید، و سپس ارائه را ذخیره نمایید.

**Can lists contain non-Latin text?**

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که فونت‌های استفاده‌شده در ارائه، کاراکترهای مورد نیاز شما را پشتیبانی می‌کنند.