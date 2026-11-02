---
title: مدیریت فهرست‌های گلوله‌ای و شماره‌دار در ارائه‌ها با استفاده از Python از طریق Java
linktitle: مدیریت فهرست‌ها
type: docs
weight: 60
url: /fa/python-java/manage-lists/
keywords:
- گلوله
- فهرست گلوله‌ای
- فهرست شماره‌دار
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
- Java
- Aspose.Slides
description: "نحوه ایجاد و قالب‌بندی فهرست‌های گلوله‌ای، گلوله‌های تصویری، فهرست‌های چندسطحی و فهرست‌های شماره‌دار در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق Java را بیاموزید."
---
## **بررسی کلی**

Aspose.Slides برای Python از طریق Java به شما امکان ایجاد و قالب‌بندی فهرست‌های نقطه‌دار و شماره‌دار در ارائه‌های PowerPoint و OpenDocument را می‌دهد. یک مورد فهرست یک پاراگراف است که تنظیمات گلوله آن از طریق قالب‌بندی پاراگراف آن کنترل می‌شود.

از روش [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورود اصلی [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) است که یک شیء [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) برمی‌گرداند. با این شیء می‌توانید نوع گلوله، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و عدد شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- ایجاد فهرست گلوله‌ای با نماد سفارشی
- ایجاد گلوله تصویری
- ایجاد فهرست چندسطحی با تنظیم عمق پاراگراف
- ایجاد فهرست شماره‌دار
- بررسی و تغییر قالب‌بندی فهرست در یک ارائه موجود
- خواندن نشانگرها و شماره‌های واقعی فهرست همراه با متن پاراگراف

## **ایجاد فهرست گلوله‌ای**

برای ایجاد فهرست گلوله‌ای، اشیاء [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) را به یک [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) اضافه کنید و [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) را به [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol) تنظیم کنید. سپس می‌توانید از [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar)، [BulletFormat.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getColor) و [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) برای کنترل ظاهر گلوله استفاده کنید.

کد Python زیر نحوه ایجاد فهرست گلوله‌ای در یک اسلاید را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![گلوله‌های نماد](symbol_bullets.png)

## **ایجاد فهرست شماره‌دار**

از فهرست‌های شماره‌دار زمانی استفاده کنید که ترتیب موارد اهمیت دارد. [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) را به [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered) تنظیم کنید. همچنین می‌توانید یک قالب شماره‌گذاری را با [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) انتخاب کنید یا وقتی فهرست باید با مقدار دیگری غیر از 1 شروع شود از [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) استفاده کنید.

کد Python زیر نشان می‌دهد چگونه یک فهرست شماره‌دار در یک اسلاید ایجاد کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![گلوله‌های شماره‌دار](numbered_bullets.png)

## **ایجاد گلوله تصویری**

Aspose.Slides به شما امکان می‌دهد نماد گلوله معمولی را با یک تصویر جایگزین کنید. گلوله‌های تصویری بهترین عملکرد را با تصاویر ساده‌ای دارند که در اندازه کوچک نیز قابل خواندن باشند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک.

{{% alert color="info" title="Note" %}}
اگر قصد دارید نماد گلوله معمولی را با یک تصویر جایگزین کنید، یک گرافیک ساده با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای سفارشی گلوله به‌خوبی کار می‌کنند.
{{% /alert %}}

به یاد داشته باشید که تصویر به اندازه بسیار کوچکی مقیاس‌گذاری خواهد شد. به همین دلیل، شدیداً توصیه می‌کنیم تصویری را انتخاب کنید که در مقیاس کوچک واضح و بصری مؤثر بماند هنگامی که به‌عنوان گلوله در یک فهرست استفاده می‌شود.

برای ایجاد گلوله تصویری، یک تصویر را به [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) اضافه کنید و شیء تصویر برگشتی را به [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) اختصاص دهید. قبل از اختصاص تصویر، [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) را به [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) تنظیم کنید.

فرض کنید تصویری به نام "image.png" داریم:

![عکس برای گلوله‌ها](picture_for_bullets.png)

کد Python زیر نشان می‌دهد چگونه گلوله‌های تصویری را در یک اسلاید ایجاد کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![گلوله‌های تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیر آن قرار می‌گیرد و به همین ترتیب.

کد Python زیر نشان می‌دهد چگونه یک فهرست گلوله‌ای چندسطحی ایجاد کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![فهرست چندسطحی](multilevel_list.png)

## **تغییر فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، به پاراگراف هدف دسترسی پیدا کنید و تنظیمات [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) آن را به‌روز کنید. همان ویژگی‌هایی که برای ایجاد فهرست‌ها استفاده می‌شوند می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری‌شده از فایل‌های PPT، PPTX یا ODP به‌کار روند.

کد Python زیر پاراگراف اول در یک فریم متن را به استفاده از سبک فهرست شماره‌دار تغییر می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **خواندن مقادیر واقعی گلوله**

هنگام استخراج محتوای ارائه، نشانگرهای فهرست را همراه با متن پاراگراف نگه دارید. متد [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective) را فراخوانی کنید و به `getBullet` دسترسی پیدا کنید تا قالب گلوله مؤثر را به‌دست آورید. قبل از خواندن `getActualBulletValue`، `getType` آن را بررسی کنید.

برای فهرست‌های شماره‌دار، این سه مقدار را متمایز کنید:

- ``getNumberedBulletStyle`` قالب را تعیین می‌کند، مثلاً اعداد عربی با نقطه یا حروف کوچک با نقطه.
- ``getNumberedBulletStartWith`` عدد شروع برای گروهی از پاراگراف‌های شماره‌دار را مشخص می‌کند.
- ``getActualBulletValue`` نشانگر قالب‌بندی شده برای یک پاراگراف خاص را برمی‌گرداند. برای مثال، مورد دوم در فهرستی که از 5 شروع می‌شود، ``6.`` را بازمی‌گرداند.

[getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDepth) را برای هر پاراگراف حفظ کنید تا سطح تو در تویی آن را نگه دارید. نشانگر واقعی کل ساختار سلسله‌مراتبی را رمزگذاری نمی‌کند: یک مورد تو در تو می‌تواند ``c.`` را برگرداند نه یک برچسب ترکیبی مانند ``6.c.``.

مثال زیر که به‌صورت خودمستقل است، فهرست‌ها را ایجاد می‌کند، آنها را در یک ارائه ذخیره می نماید و سپس ارائه را دوباره بارگذاری می‌کند تا متن، عمق، نوع گلوله و مقدار واقعی هر پاراگراف را گزارش دهد. نشانگر تصویر کوچک آبی از SVG درون‌خطی ساخته می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, SvgImage
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # یک نشانگر تصویری بدون استفاده از فایل تصویر خارجی ایجاد کنید.
    svg = SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.getImages().addImage(svg)

    def add_paragraph(text, depth, bullet_type, start, style):
        paragraph = Paragraph()
        paragraph.setText(text)

        paragraph_format = paragraph.getParagraphFormat()
        paragraph_format.setDepth(depth)
        paragraph_format.setMarginLeft(30 + depth * 40)
        paragraph_format.setIndent(-28)
        paragraph_format.setSpaceAfter(8)
        paragraph_format.getDefaultPortionFormat().setFontHeight(22)
        paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        paragraph_format.getBullet().setType(bullet_type)
        paragraph_format.getBullet().setBulletHardColor(NullableBool.True_)
        paragraph_format.getBullet().getColor().setColor(Color.BLACK)
        if bullet_type == BulletType.Numbered:
            paragraph_format.getBullet().setNumberedBulletStyle(style)
            paragraph_format.getBullet().setNumberedBulletStartWith(start)
        elif bullet_type == BulletType.Symbol:
            paragraph_format.getBullet().setChar('\u2022')
        elif bullet_type == BulletType.Picture:
            paragraph_format.getBullet().getPicture().setImage(bullet_image)

        text_frame.getParagraphs().add(paragraph)

    add_paragraph("First item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Second item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod)
    add_paragraph("Back to top level", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Symbol marker", 0, BulletType.Symbol, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("No bullet", 0, BulletType.None_, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Picture marker", 0, BulletType.Picture, 1, NumberedBulletStyle.BulletArabicPeriod)
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

loaded_presentation = Presentation("actual_bullet_values.pptx")
try:
    loaded_shape = loaded_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    type_names = {
        BulletType.Numbered: "Numbered",
        BulletType.Symbol: "Symbol",
        BulletType.None_: "None",
        BulletType.Picture: "Picture",
    }
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.getTextFrame().getParagraphs():
        bullet = paragraph.getParagraphFormat().getEffective().getBullet()
        bullet_type = bullet.getType()
        if bullet_type in (BulletType.Numbered, BulletType.Symbol):
            marker = bullet.getActualBulletValue()
        elif bullet_type == BulletType.None_:
            marker = f"{bullet.getActualBulletValue()} (no bullet)"
        elif bullet_type == BulletType.Picture:
            marker = f"{bullet.getActualBulletValue()} (image required)"
        else:
            marker = "unsupported bullet type"
        type_name = type_names.get(bullet_type, "Unknown")
        print(f"{paragraph.getText()} | {paragraph.getParagraphFormat().getDepth()} | {type_name} | {marker}")
finally:
    loaded_presentation.dispose()
```

فهرست‌های منبع در زیر نمایش داده شده‌اند.

![فهرست‌هایی که از 5 شروع می‌شوند، موارد حروف تو در تو و شماره‌های رومی، یک نشانگر نماد، یک پاراگراف بدون گلوله، و یک نشانگر تصویر آبی](actual_bullet_values.png)

گزارش با نشانگرهای نمایش داده شده در PowerPoint مطابقت دارد:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | None (no bullet)
Picture marker | 0 | Picture | None (image required)
```

برای [BulletType.None_ and BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/)، `getActualBulletValue` مقدار `None` (در Java `null`) را بازمی‌گرداند، نه یک رشته خالی. این انواع را جداگانه مدیریت کنید: مورد اول هیچ نشانگری ندارد، در حالی که مورد دوم نیاز به استخراج تصویر گلوله به‌صورت جداگانه دارد. یک گلوله تصویری تنها با استخراج یک نشانگر متنی قابل بازتولید نیست.

## **سؤالات متداول**

**آیا فهرست‌های گلوله‌ای و شماره‌دار می‌توانند به PDF یا تصاویر صادر شوند؟**

بله. Aspose.Slides قالب‌بندی فهرست را حفظ می‌کند هنگامی که فرمت هدف از چیدمان متن مربوطه و ویژگی‌های گلوله پشتیبانی کند.

**آیا می‌توانم فهرست‌ها را در ارائه‌های موجود ویرایش کنم؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) آن را بررسی یا به‌روز کنید، و سپس ارائه را ذخیره کنید.

**آیا فهرست‌ها می‌توانند متن غیرلاتین داشته باشند؟**

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که فونت‌های استفاده‌شده در ارائه از کاراکترهای مورد نیاز پشتیبانی می‌کنند.