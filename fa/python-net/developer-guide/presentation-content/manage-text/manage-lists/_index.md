---
title: "مدیریت فهرست‌های بولت‌دار و شماره‌دار در ارائه‌ها با پایتون"
linktitle: "مدیریت فهرست‌ها"
type: docs
weight: 70
url: /fa/python-net/manage-lists/
keywords:
- "بولت"
- "فهرست بولت‌دار"
- "فهرست شماره‌دار"
- "بولت نماد"
- "بولت تصویری"
- "بولت سفارشی"
- "فهرست چندسطحه‌ای"
- "ایجاد بولت"
- "افزودن بولت"
- "افزودن فهرست"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Python"
- "Aspose.Slides"
description: "نحوه ایجاد و قالب‌بندی فهرست‌های بولت‌دار، تصویری، چندسطحه‌ای و شماره‌دار در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET را بیاموزید."
---
## **بررسی کلی**

Aspose.Slides برای Python از طریق .NET به شما امکان ایجاد و قالب‌بندی فهرست‌های بولت‌دار و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument می‌دهد. یک آیتم فهرست یک پاراگراف است که تنظیمات بولت آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از ویژگی [Paragraph.paragraph_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/paragraph_format/) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورودی اصلی [ParagraphFormat.bullet](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/bullet/) است که یک شیء [BulletFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/) را برمی‌گرداند. با استفاده از این شیء می‌توانید نوع بولت، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و عدد شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:
- یک فهرست بولت‌دار با نماد سفارشی ایجاد کنید
- یک بولت تصویری ایجاد کنید
- یک فهرست چندسطحه‌ای با تنظیم عمق پاراگراف ایجاد کنید
- یک فهرست شماره‌دار ایجاد کنید
- قالب‌بندی فهرست را در یک ارائه موجود بررسی و تغییر دهید

## **ایجاد فهرست بولت‌دار**

برای ایجاد یک فهرست بولت‌دار، اشیاء [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) را به یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید و [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.SYMBOL](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید [BulletFormat.char](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/char/)، [BulletFormat.color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/color/)، و [BulletFormat.height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/height/) را برای کنترل ظاهر بولت تنظیم کنید.

کد پایتون زیر نحوه ایجاد یک فهرست بولت‌دار در یک اسلاید را نشان می‌دهد:

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

![بولت‌های نماد](symbol_bullets.png)

## **ایجاد فهرست شماره‌دار**

از فهرست‌های شماره‌دار زمانی استفاده کنید که ترتیب آیتم‌ها مهم باشد. [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.NUMBERED](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید. می‌توانید همچنین یک قالب شماره‌گذاری را با [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/numbered_bullet_style/) انتخاب کنید یا هنگام شروع فهرست از مقداری جز 1، [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) را تنظیم کنید.

کد پایتون زیر نشان می‌دهد چگونه یک فهرست شماره‌دار در یک اسلاید ایجاد کنید:

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

![بولت‌های شماره‌دار](numbered_bullets.png)

## **ایجاد بولت تصویری**

Aspose.Slides به شما اجازه می‌دهد نماد بولت معمولی را با یک تصویر جایگزین کنید. بولت‌های تصویری بهترین عملکرد را با تصاویر ساده‌ای دارند که در اندازه کوچک قابل خواندن باقی می‌مانند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک.

{{% alert color="primary" %}}
در حالت ایده‌آل، اگر قصد دارید نماد بولت معمولی را با یک تصویر جایگزین کنید، بهتر است یک گرافیک ساده با پس‌زمینه شفاف انتخاب کنید. اینگونه تصاویر به عنوان نمادهای بولت سفارشی به خوبی کار می‌کنند.

به‌خاطر داشته باشید که تصویر به اندازه بسیار کوچک کاهش خواهد یافت. به همین دلیل، به شدت توصیه می‌کنیم که تصویری را انتخاب کنید که در هنگام استفاده به‌عنوان بولت در یک فهرست، واضح و بصری مؤثر باقی بماند.
{{% /alert %}}

برای ایجاد یک بولت تصویری، یک تصویر را به [Presentation.images](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/images/) اضافه کنید و شیء تصویری برگردانده شده را به [BulletFormat.picture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/picture/) اختصاص دهید. قبل از اختصاص تصویر، [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.PICTURE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید.

فرض کنید فایل "image.png" را داریم:

![تصویری برای بولت‌ها](picture_for_bullets.png)

کد پایتون زیر نشان می‌دهد چگونه بولت‌های تصویری را در یک اسلاید ایجاد کنید:

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

![بولت‌های تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحه‌ای**

از [ParagraphFormat.depth](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/depth/) برای قرار دادن آیتم‌های فهرست در سطوح مختلف استفاده کنید. سطح ۰ بالاترین سطح است، سطح ۱ زیر آن تو در تو می‌شود و به همین ترتیب.

کد پایتون زیر نشان می‌دهد چگونه یک فهرست بولت‌دار چندسطحه‌ای ایجاد کنید:

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

![فهرست چندسطحه‌ای](multilevel_list.png)

## **تغییر فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، به پاراگراف هدف دسترسی پیدا کنید و تنظیمات [ParagraphFormat.bullet](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/bullet/) آن را به‌روزرسانی کنید. همان خصوصیات استفاده شده برای ایجاد فهرست‌ها می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری شده از یک فایل PPT، PPTX یا ODP نیز به کار روند.

کد پایتون زیر پاراگراف اول در یک فریم متنی را به استفاده از سبک فهرست شماره‌دار تغییر می‌دهد:

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

## **سوالات متداول**

**آیا فهرست‌های بولت‌دار و شماره‌دار می‌توانند به PDF یا تصاویر صادر شوند؟**

بله. Aspose.Slides قالب‌بندی فهرست را حفظ می‌کند هنگامی که فرمت هدف از چیدمان متن و ویژگی‌های بولت متناظر پشتیبانی می‌کند.

**آیا می‌توانم فهرست‌ها را در ارائه‌های موجود ویرایش کنم؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [ParagraphFormat.bullet](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/bullet/) آن را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

**آیا فهرست‌ها می‌توانند شامل متن غیرلاتین باشند؟**

بله. متن آیتم فهرست می‌تواند شامل کاراکترهای یونی‌کد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چند زبانه ایجاد کنید. اطمینان حاصل کنید که فونت‌های استفاده شده در ارائه از کاراکترهای مورد نیاز شما پشتیبانی می‌کنند.