---
title: مدیریت فهرست‌های بولت‌دار و شماره‌دار در ارائه‌ها با پایتون
linktitle: مدیریت فهرست‌ها
type: docs
weight: 70
url: /fa/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
- بولت
- فهرست بولت‌دار
- فهرست شماره‌دار
- بولت نماد
- بولت تصویری
- بولت سفارشی
- فهرست چندسطحی
- ایجاد بولت
- افزودن بولت
- افزودن فهرست
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه فهرست‌های بولت‌دار، تصویری، چندسطحی و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides برای Python از طریق .NET به شما امکان ایجاد و قالب‌بندی فهرست‌های بولت‌دار و شماره‌دار در ارائه‌های PowerPoint و OpenDocument را می‌دهد. یک مورد فهرست یک پاراگراف است که تنظیمات بولت آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از ویژگی [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورودی اصلی [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) است که یک شیء [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) را برمی‌گرداند. با استفاده از این شیء می‌توانید نوع بولت، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شماره شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- ایجاد یک فهرست بولت‌دار با نماد سفارشی
- ایجاد یک بولت تصویری
- ایجاد یک فهرست چندسطحی با تنظیم عمق پاراگراف
- ایجاد یک فهرست شماره‌دار
- بازرسی و تغییر قالب‌بندی فهرست در یک ارائه موجود
- خواندن نشانگرها و شماره‌های واقعی فهرست همراه با متن پاراگراف

## **ایجاد یک فهرست بولت‌دار**

برای ایجاد یک فهرست بولت‌دار، اشیاء [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) را به یک [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) اضافه کنید و ویژگی [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) را به [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/)، [BulletFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/color/)، و [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) را برای کنترل ظاهر بولت تنظیم کنید.

کد Python زیر نحوه ایجاد یک فهرست بولت‌دار در یک اسلاید را نشان می‌دهد:

```py
import aspose.slides as slides

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = slides.Color.indian_red
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

![بولت‌های نمادین](symbol_bullets.png)

## **ایجاد یک فهرست شماره‌دار**

از فهرست‌های شماره‌دار وقتی که ترتیب موارد مهم است استفاده کنید. ویژگی [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) را به [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید یک فرمت شماره‌گذاری را با [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) انتخاب کنید یا هنگامی که فهرست باید از مقدار دیگری غیر از 1 آغاز شود، [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) را تنظیم کنید.

کد Python زیر نشان می‌دهد چگونه یک فهرست شماره‌دار در یک اسلاید ایجاد کنید:

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

## **ایجاد یک بولت تصویری**

Aspose.Slides به شما اجازه می‌دهد نماد بولت معمولی را با یک تصویر جایگزین کنید. بولت‌های تصویری بهترین عملکرد را با تصاویر ساده‌ای که در اندازه کوچک قابل خواندن باقی می‌مانند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="info" title="Note" %}}
در حالت ایده‌آل، اگر قصد دارید نماد بولت معمولی را با یک تصویر جایگزین کنید، بهتر است یک گرافیک ساده با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای بولت سفارشی به‌خوبی کار می‌کنند.

به خاطر داشته باشید که تصویر به اندازهٔ بسیار کوچکی مقیاس می‌شود. به همین دلیل، به‌شدت توصیه می‌کنیم تصویری را انتخاب کنید که هنگام استفاده به‌عنوان بولت در فهرست واضح و از نظر بصری مؤثر بماند.
{{% /alert %}}

برای ایجاد یک بولت تصویری، یک تصویر را به [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) اضافه کنید و شیء تصویر بازگشتی را به [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) اختصاص دهید. پیش از اختصاص تصویر، ویژگی [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) را به [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) تنظیم کنید.

فرض کنید فایلی به نام "image.png" داریم:

![تصویری برای بولت‌ها](picture_for_bullets.png)

کد Python زیر نشان می‌دهد چگونه بولت‌های تصویری را در یک اسلاید ایجاد کنید:

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

## **ایجاد یک فهرست چندسطحی**

از [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیر آن تو در تو قرار می‌گیرد و به همین ترتیب. عمق فقط تنظیم تو رفتگی را کنترل می‌کند؛ وقتی سطوح باید بولت نیز داشته باشند، [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) را برای هر پاراگراف تنظیم کنید.

کد Python زیر نشان می‌دهد چگونه یک فهرست چندسطحی ایجاد کنید:

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

![فهرست چندسطحی](multilevel_list.png)

## **تغییر یک فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، پاراگراف هدف را دسترسی پیدا کنید و تنظیمات [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) آن را به‌روزرسانی کنید. همان ویژگی‌هایی که برای ایجاد فهرست‌ها استفاده می‌شوند می‌توانند برای بازرسی یا اصلاح فهرست‌های بارگذاری شده از یک فایل PPT، PPTX یا ODP به کار روند.

کد Python زیر پاراگراف اول در یک فریم متنی را به استفاده از سبک فهرست شماره‌دار تغییر می‌دهد:

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

## **خواندن مقادیر واقعی بولت**

هنگام استخراج محتوای ارائه، نشانگرهای فهرست را همراه با متن پاراگراف نگه دارید. تابع [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/) را صدا بزنید و به [IParagraphFormatEffectiveData.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformateffectivedata/bullet/) دسترسی پیدا کنید تا قالب بولت مؤثر را دریافت کنید. قبل از خواندن [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/)، نوع آن را با [type](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/type/) بررسی کنید.

برای فهرست‌های شماره‌دار، این سه مقدار را تشخیص دهید:

- [numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_style/) فرمت را تعیین می‌کند، مانند اعداد عربی به‌همراه یک نقطه یا حروف کوچک به‌همراه یک نقطه.
- [numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_start_with/) شماره شروع را برای گروهی از پاراگراف‌های شماره‌دار مشخص می‌کند.
- [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) نشانگر قالب‌بندی‌شده برای یک پاراگراف خاص را برمی‌گرداند. به‌عنوان مثال، دومین مورد در فهرستی که از 5 شروع می‌شود، `6.` را باز می‌گرداند.

با هر پاراگراف [depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) را حفظ کنید تا سطح تو در تویی خود را نگه دارد. نشانگر واقعی کامل سلسله‌مراتب را رمزگذاری نمی‌کند: یک مورد تو در تو می‌تواند `c.` را برگرداند نه برچسب ترکیبی مانند `6.c.`.

مثال خودمستقلی زیر فهرست‌ها را ایجاد می‌کند، آنها را در یک ارائه ذخیره می‌نماید و سپس ارائه را بارگذاری مجدد می‌کند تا متن، عمق، نوع بولت و مقدار واقعی هر پاراگراف را گزارش دهد. نشانگر تصویر آبی کوچک از SVG درون‌خطی ساخته می‌شود.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 440, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20, 660, 400)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    # ایجاد یک نشانگر تصویری بدون فایل تصویر خارجی.
    svg = slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.images.add_image(svg)

    def add_paragraph(text, depth, bullet_type, start=1, style=slides.NumberedBulletStyle.BULLET_ARABIC_PERIOD):
        paragraph = slides.Paragraph()
        paragraph.text = text

        paragraph_format = paragraph.paragraph_format
        paragraph_format.depth = depth
        paragraph_format.margin_left = 30 + depth * 40
        paragraph_format.indent = -28
        paragraph_format.space_after = 8
        paragraph_format.default_portion_format.font_height = 22
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = slides.Color.black
        paragraph_format.bullet.type = bullet_type
        paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
        paragraph_format.bullet.color.color = slides.Color.black
        if bullet_type == slides.BulletType.NUMBERED:
            paragraph_format.bullet.numbered_bullet_style = style
            paragraph_format.bullet.numbered_bullet_start_with = start
        elif bullet_type == slides.BulletType.SYMBOL:
            paragraph_format.bullet.char = "\u2022"
        elif bullet_type == slides.BulletType.PICTURE:
            paragraph_format.bullet.picture.image = bullet_image

        text_frame.paragraphs.add(paragraph)

    add_paragraph("First item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Second item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Next nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Deep item", 2, slides.BulletType.NUMBERED, 4, slides.NumberedBulletStyle.BULLET_ROMAN_LC_PERIOD)
    add_paragraph("Back to top level", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Symbol marker", 0, slides.BulletType.SYMBOL)
    add_paragraph("No bullet", 0, slides.BulletType.NONE)
    add_paragraph("Picture marker", 0, slides.BulletType.PICTURE)
    presentation.save("actual_bullet_values.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("actual_bullet_values.pptx") as loaded_presentation:
    loaded_shape = loaded_presentation.slides[0].shapes[0]
    bullet_type_names = {slides.BulletType.NUMBERED: "NUMBERED", slides.BulletType.SYMBOL: "SYMBOL", slides.BulletType.NONE: "NONE", slides.BulletType.PICTURE: "PICTURE"}
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.text_frame.paragraphs:
        bullet = paragraph.paragraph_format.get_effective().bullet
        if bullet.type in (slides.BulletType.NUMBERED, slides.BulletType.SYMBOL):
            marker = bullet.actual_bullet_value
        elif bullet.type == slides.BulletType.NONE:
            marker = f"{bullet.actual_bullet_value} (no bullet)"
        elif bullet.type == slides.BulletType.PICTURE:
            marker = f"{bullet.actual_bullet_value} (image required)"
        else:
            marker = "unsupported bullet type"
        bullet_type_name = bullet_type_names.get(bullet.type, "UNKNOWN")
        print(f"{paragraph.text} | {paragraph.paragraph_format.depth} | {bullet_type_name} | {marker}")
```

فهرست‌های منبع در زیر نشان داده شده‌اند.

![فهرست‌هایی که از 5 شروع می‌شوند، موارد حروف تو در تو و عدد رومی، یک نشانگر نماد، یک پاراگراف بدون بولت، و یک نشانگر تصویر آبی](actual_bullet_values.png)

گزارش با نشانگرهای نمایش داده‌شده در PowerPoint مطابقت دارد:

```text
Text | Depth | Type | Actual value
First item | 0 | NUMBERED | 5.
Second item | 0 | NUMBERED | 6.
Nested item | 1 | NUMBERED | c.
Next nested item | 1 | NUMBERED | d.
Deep item | 2 | NUMBERED | iv.
Back to top level | 0 | NUMBERED | 7.
Symbol marker | 0 | SYMBOL | •
No bullet | 0 | NONE | None (no bullet)
Picture marker | 0 | PICTURE | None (image required)
```

برای [BulletType.NONE and BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)، [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) مقدار `None` را برمی‌گرداند، نه یک رشته خالی. این انواع را به‌صورت جداگانه پردازش کنید: مورد اول هیچ نشانگری ندارد، در حالی که مورد دوم نیاز به استخراج تصویر بولت به‌صورت جداگانه دارد. یک بولت تصویری را نمی‌توان تنها با استخراج یک نشانگر متنی بازتولید کرد.

## **سوالات متداول**

**آیا فهرست‌های بولت‌دار و شماره‌دار می‌توانند به PDF یا تصویرها صادر شوند؟**

بله. Aspose.Slides قالب‌بندی فهرست را حفظ می‌کند هنگامی که فرمت هدف از چیدمان متن و ویژگی‌های بولت مربوطه پشتیبانی کند.

**آیا می‌توانم فهرست‌ها را در ارائه‌های موجود ویرایش کنم؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) آن را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

**آیا فهرست‌ها می‌توانند شامل متن‌های غیر لاتین باشند؟**

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونی‌کد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که قلم‌های استفاده‌شده در ارائه از کاراکترهای مورد نیاز پشتیبانی می‌کنند.