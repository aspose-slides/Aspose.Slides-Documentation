---
title: مدیریت پاراگراف‌های متنی پاورپوینت در پایتون
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- افزودن متن
- افزودن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت نقطه
- تورفتگی پاراگراف
- تورفتگی معلق
- نقطه پاراگراف
- فهرست شماره‌دار
- فهرست نقطه‌دار
- ویژگی‌های پاراگراف
- واردات HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- صادرات پاراگراف
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، نقطه‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای پایتون از طریق .NET ایجاد و قالب‌بندی کنید."
---
## **مرور کلی**

Aspose.Slides برای Python از طریق .NET متن را به صورت یک سلسله‌مراتبی از چارچوب‌های متن، پاراگراف‌ها و بخش‌ها نمایش می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) نمایانگر محفظه متن در یک شکل است و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) نمایانگر یک پاراگراف در یک چارچوب متن است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) نمایانگر یک بخش متن در داخل یک پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی سطح کاراکتر خاص خود را داشته باشد.

بدین ترتیب یک پاراگراف می‌تواند متن با قلم‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های متفاوت را با استفاده از بخش‌های متعدد شامل شود.

## **ایجاد و فرمت‌بندی پاراگراف‌ها**

پاراگراف‌ها را در چارچوب متن یک شکل ایجاد کنید و از بخش‌ها برای قالب‌بندی اجراهای متنی جداگانه استفاده کنید. این بخش نشان می‌دهد چگونه چندین بخش را در هر پاراگراف ترکیب کنید و رنگ‌ها، اندازه‌های قلم و سبک‌های مختلف را اعمال کنید.

### **ایجاد پاراگراف‌ها با بخش‌های متعدد**

مثال پایتون زیر سه پاراگراف ایجاد می‌کند که هر کدام شامل سه اجرای متنی در مجموعهٔ [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/) خود هستند. این مثال پاراگراف پیش‌فرض و بخش خالی آن را مجدداً استفاده می‌کند، سپس پاراگراف‌ها و بخش‌های باقی‌مانده را اضافه می‌کند. قالب‌بندی از طریق [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) اعمال می‌شود: اولین بخش در هر پاراگراف قرمز، توپر و به اندازهٔ 15 پوینت است؛ دومین بخش آبی، ایتالیک و به اندازهٔ 18 پوینت؛ بخش سوم قالب‌بندی پیش‌فرض خود را حفظ می‌کند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **ایجاد فهرست‌های نقطه‌دار و شماره‌دار**

متن پاراگراف را به صورت فهرست‌ها با نمادها، اعداد یا تصاویر سفارشی سازمان‌دهی کنید. مثال‌های این بخش شامل قالب‌بندی نقطه‌ها، فهرست‌های چندسطحی و شماره‌گذاری‌های سفارشی است.

### **ایجاد فهرست نقطه‌دار یا شماره‌دار**

نقطه‌ها و شماره‌گذاری موارد مرتبط را برای اسکن آسان‌تر می‌کند. در Aspose.Slides تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) تعریف می‌شود.

این مثال پایتون یک نقطه نمادین و یک آیتم شماره‌دار را به همان چارچوب متن اضافه می‌کند. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) نوع نقطه را انتخاب می‌کند، در حالی که [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) نماد را فراهم می‌کند و [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) سبک شماره‌گذاری را انتخاب می‌کند. هر دو مورد از نقطه‌های سیاه با ارتفاع 100 درصد و تورفتگی پاراگراف 25 پوینت استفاده می‌کنند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **استفاده از نقطه‌های تصویری**

نقطه‌های تصویری به شما اجازه می‌دهند به جای نماد یا عدد از یک تصویر سفارشی استفاده کنید.

این مثال به فایل `bullets.png` در پوشهٔ کاری نیاز دارد. این مثال پایتون تصویری را به مجموعهٔ تصاویر ارائه به عنوان یک [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) اضافه می‌کند و از آن به عنوان نقطهٔ پاراگراف استفاده می‌کند. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) برای استفاده از نقطهٔ تصویری تنظیم می‌شود و تصویر از طریق [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) تخصیص داده می‌شود. [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) به 100 درصد تنظیم می‌شود تا نقطه نسبت به متن پاراگراف اندازه‌گیری شود:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **ایجاد فهرست چندسطحی**

[ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالا دارای عمق `0` است.

این مثال پایتون مقادیر [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) را از 0 تا 3 به چهار پاراگراف اختصاص می‌دهد و یک سلسله‌مراتب در یک چارچوب متن ایجاد می‌کند. هر پاراگراف از نقطهٔ نمادین استفاده می‌کند و [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) بین نقطهٔ گرد و خط تیره برای تمایز سطوح مجاور تعویض می‌شود:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **شروع آیتم‌های فهرست شماره‌دار با مقادیر سفارشی**

از [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) برای تنظیم عدد اولیه نمایش داده شده برای پاراگراف شماره‌دار استفاده کنید.

این مثال پایتون [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) را برای استفاده از شماره‌گذاری در سه پاراگراف تنظیم می‌کند و مقادیر [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) را به ترتیب 2، 3 و 7 اختصاص می‌دهد. مقدار شروع به طور جداگانه برای هر پاراگراف پیکربندی می‌شود تا اعداد نمایش داده شده مقادیر را از بین ببرند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **کنترل چیدمان پاراگراف و ویژگی‌های انتهای آن**

حاشیه‌ها و تورفتگی‌های پاراگراف را تنظیم کنید تا موقعیت خط اول و خطوط بسته‌شده را کنترل کنید. همچنین می‌توانید علامت پایان پاراگراف را جدا از بخش‌های متنی قابل مشاهده فرمت‌بندی کنید.

### **تنظیم تورفتگی خط اول**

از ویژگی [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این ویژگی فقط خط اول را نسبت به حاشیه سمت چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به راست می‌برد، در حالی که خطوط باقی‌مانده به تراز بدنهٔ پاراگراف می‌مانند.

از [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) زمانی که نیاز به جابه‌جایی کل پاراگراف دارید استفاده کنید. از [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) زمانی که تنها خط اول را می‌خواهید جابه‌جا کنید استفاده کنید.

مثال زیر سه پاراگراف را با همان [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) برابر با 20 پوینت و مقادیر [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) برابر با 0، 20 و 40 پوینت تنظیم می‌کند. خطوط اول به تدریج در افست‌های بزرگتر شروع می‌شوند، در حالی که خطوط بسته‌شده همان حاشیهٔ چپ را حفظ می‌کنند:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The first-line indent of the paragraphs](first_line_indent.png)

### **تنظیم تورفتگی معلق**

تورفتگی معلق نوعی چیدمان پاراگراف است که در آن خط اول نسبت به بقیه خطوط به سمت چپ شروع می‌شود. در Aspose.Slides این اثر را با ویژگی [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) ایجاد می‌کنید. مقدار `indent` را به یک مقدار منفی تنظیم کنید تا خط اول نسبت به بدنهٔ پاراگراف به سمت چپ حرکت کند.

در عمل، [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) موقعیت چپ بدنهٔ پاراگراف را تعریف می‌کند و [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) موقعیت خط اول را نسبت به آن حاشیه تعیین می‌کند. برای ایجاد تورفتگی معلق، مقدار `margin_left` را مثبت و مقدار `indent` را منفی تنظیم کنید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، واژه‌نامه‌ها و دیگر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنهٔ پاراگراف تراز شوند مفید است.

مثال پایتون زیر مقادیر [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) برابر با 40 و 60 پوینت را با مقادیر [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) برابر با -20 و -30 پوینت ترکیب می‌کند. در هر پاراگراف، خط اول نسبت به خطوط بسته‌شده به سمت چپ شروع می‌شود؛ پاراگراف دوم تورفتگی معلق عمیق‌تری دارد:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The hanging indent of the paragraphs](hanging_indent.png)

### **تنظیم ویژگی‌های انتهای پاراگراف**

ویژگی [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) قالب‌بندی علامت پایان پاراگراف را کنترل می‌کند. مثال فایل `Test.pptx` را بارگذاری می‌کند (باید حداقل یک اسلاید داشته باشد) و یک [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) با [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) برابر 48 پوینت و [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) برابر Times New Roman ایجاد می‌کند. این قالب را به علامت پایان پاراگراف دوم اختصاص می‌دهد، در حالی که بخش‌های متنی قابل مشاهده بدون تغییر می‌مانند:

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **شمارش خطوط رندر شده**

برای قوانین پاراگراف که بر بسته شدن خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به [Control Line Breaking](/slides/fa/python-net/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/python-net/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) برای شمارش خطوطی که یک پاراگراف پس از چیدمان متن اشغال می‌کند (از جمله بسته شدن خودکار) استفاده کنید. این برای بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

یک پاراگراف یک مورد در [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) است و می‌تواند چندین خط رندر شده را اشغال کند. یک شکست خط صریح داخل پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف دیگری ساخته شود. بسته شدن خودکار خطوط را بر اساس عرض موجود بدون درج شکست‌های خط صریح در متن ایجاد می‌کند. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، تعداد خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشتهٔ کوتاه‌تری جایگزین می‌کند. این مثال [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) را فعال و [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) را غیرفعال می‌کند تا عرض شکل بسته شدن خودکار متن یا تغییر اندازهٔ شکل را کنترل نکند. هر اندازه‌گیری از [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) استفاده می‌کند. ابعاد شکل بر حسب پوینت هستند. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و تعداد خطوط را در تمام چارچوب متن جمع می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

با این متن و این ابعاد، باریک کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشتهٔ کوتاه تعداد خطوط را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن قلم‌ها و جایگزینی‌ها، اندازهٔ قلم، حاشیه‌ها، تورفتگی، بسته شدن و تنظیمات autofit متفاوت باشد. از قلم‌ها و تنظیمات چیدمانی که برای محیط هدف در نظر گرفته‌اید هنگام بررسی یک قالب استفاده کنید.

تنها شمارش خطوط تعیین نمی‌کند که متن از محفظه‌اش عبور می‌کند یا نه. ارتفاع موجود، ارتفاع خطوط، فاصلهٔ پاراگرافی و خطی، و رفتار autofit نیز اهمیت دارند؛ حتی یک خط واحد می‌تواند عرض موجود را هنگام غیرفعال بودن بسته شدن تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

از HTML برای آوردن متن به یک ارائه یا صادرات پاراگراف‌های موجود برای استفاده خارج از آن استفاده کنید. این بخش همچنین نشان می‌دهد چگونه پاراگراف‌های فرد را به عنوان تصویر رندر کنید، از جمله پاراگراف‌های داخل سلول‌های جدول.

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک چارچوب متن استفاده کنید.

این مثال پایتون HTML را از `file.html` در پوشهٔ کاری می‌خواند و نشانه‌گذاری را به [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) منتقل می‌کند. پاراگراف پیش‌فرض چارچوب متن را پاک می‌کند تا چارچوب فقط شامل محتویات وارد شده باشد. شکل مستطیلی حاشیهٔ 10 پوینت در هر سمت اسلاید باقی می‌گذارد:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **صادرات متن پاراگراف به HTML**

از [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) برای صادرات یک بازهٔ انتخابی از پاراگراف‌ها به HTML استفاده کنید. هنگام استفاده مجدد از متن ارائه در یک وب‌سایت، ممکن است بخواهید تأکید محلی را بدون حمل قلم، اندازه یا سبک‌های جعبهٔ متن ارائه حفظ کنید. برای کنترل میزان ارث‌بری قالب‌بندی، [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) را تنظیم کنید.

[نمونهٔ ارائه را دانلود کنید](text-inheritance.pptx) و آن را در پوشهٔ کاری برنامه قرار دهید. اسلاید اول شامل یک شکل متنی با متن «Inherited text; explicit red 18pt» است. ورودی به‌صورت عمدی چندین سطح قالب‌بندی دارد:

- سبک پیش‌فرض متن ارائه Calibri به اندازهٔ 28 پوینت است.
- سبک متن اولین سطح چارچوب متن متن آبی و ایتالیک فراهم می‌کند.
- پاراگراف به‌طور صریح متن توپر تنظیم می‌کند.
- بخش دوم، «explicit red 18pt»، به‌صورت صریح متن قرمز و اندازهٔ 18 پوینت تنظیم می‌کند.

مثال کامل زیر همان پاراگراف‌ها را سه بار صادر می‌کند. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) را به روش صادرات پاس می‌دهد و هر نتیجه را به‌صورت یک فایل HTML UTF‑8 جداگانه می‌نویسد:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

HTML تولید شده شامل CSS زیر برای اولین بخش، «Inherited text; » است. جدول اعلان‌های مربوطه را فهرست می‌کند؛ سایر ویژگی‌های تولید شده برای وضوح حذف شده‌اند.

| خروجی | CSS مربوط به اولین بخش | ظاهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، توپر، ایتالیک با 28 پوینت در Calibri، اگر قلم موجود باشد. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، توپر، ایتالیک؛ صفحه یا مرورگر حاشیهٔ قلم و اندازه را فراهم می‌کند. |
| `ParagraphOnly.html` | `font-weight:bold` | متن توپر؛ صفحه یا مرورگر قلم، اندازه، رنگ و سبک ایتالیک را فراهم می‌کند. |

بخش دوم `color:#ff0000`، `font-size:18pt` و `font-weight:bold` را در هر سه خروجی حفظ می‌کند. همچنین ایتالیک را در `ALL` و `TEXT_BOX` حفظ می‌کند اما در `PARAGRAPH_ONLY` نیست. محدود کردن ارث‌بری بنابراین قالب‌بندی صریحاً به پاراگراف یا بخش اختصاص داده شده را حذف نمی‌کند.

فایل‌ها را در همان مرورگر باز کنید تا آن‌ها را مقایسه کنید. در دو حالت محدود، خصوصیات CSS حذف‌شده توسط سبک‌های صفحه مقصد یا پیش‌فرض‌های مرورگر حل می‌شوند، بنابراین ظاهر نهایی به مکانی که HTML استفاده می‌شود بستگی دارد.

### **رندر یک پاراگراف به عنوان تصویر**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) یک پاراگراف منفرد را مستقیم رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) برمی‌گرداند. نتیجه را با [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) به فایل یا جریان ذخیره کنید. نیازی به رندر شکل حاوی یا برش بیت‌مپ به ‌صورت دستی ندارید.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) می‌تواند `None` برگرداند اگر پاراگراف در مجموعهٔ والد خود یافت نشود، مرزهای رندر معتبری نداشته باشد یا قابل رندر نباشد. قبل از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر بازگردانده شده را آزاد کنید.

#### **رندر پاراگراف با مقیاس پیش‌فرض**

این مثال از `sample.pptx` استفاده می‌کند که یک اسلاید دارد و شکل اول آن یک جعبهٔ متن حاوی سه پاراگراف است.

![The text box with three paragraphs](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در شاخص 1 انتخاب می‌کند و بدون پارامترهای مقیاس به [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) فراخوانی می‌کند. ابتدا بررسی می‌کند که شکل شامل پاراگراف مورد نیاز است و رندر یک تصویر برمی‌گرداند قبل از اینکه [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) را برای ذخیره در فرمت PNG صدا بزند. مدیر زمینه پس از استفاده منابع تصویر را آزاد می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

نتیجه:

![The paragraph image](paragraph_to_image_output.png)

#### **رندر پاراگراف در سلول جدول با مقیاس‌دهی**

از بارگذاری [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) که پارامترهای `scale_x` و `scale_y` را می‌پذیرد استفاده کنید تا عوامل مقیاس افقی و عمودی را تنظیم کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به عنوان تصویر PNG ذخیره می‌کند.

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

فاکتور مقیاس `1` آن محور را در اندازهٔ پیکسل پیش‌فرض خود نگه می‌دارد. به عنوان مثال، `2` برای هر دو فاکتور تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض است و در نتیجه چهار برابر پیکسل دارد. عوامل بزرگ‌تر معمولاً متن واضح‌تری برای بزرگ‌نمایی یا خروجی با وضوح بالا تولید می‌کنند، اما مصرف حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتری با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت عرض به ارتفاع پاراگراف، فاکتورهای مساوی استفاده کنید؛ عوامل متفاوت افقی و عمودی خروجی را به‌صورت مستقل کش می‌دهند.

رندر کل شکل با [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) همچنان وقتی که خروجی باید پرکن، حاشیه یا سایر زمینه‌های بصری شکل را شامل شود مفید است. برای تصویر تنها پاراگراف، از [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم به‌طور کامل بسته شدن خطوط داخل یک چارچوب متن را غیر فعال کنم؟**

بله. برای غیرفعال کردن بسته شدن، [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) را تنظیم کنید تا خطوط در لبه‌های چارچوب متن شکسته نشوند.

**چگونه می‌توانم محدودهٔ دقیق بر روی اسلاید یک پاراگراف خاص را دریافت کنم؟**

از [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) برای بازیابی مستطیل محدودهٔ پاراگراف استفاده کنید. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) مرزهای یک بخش فردی را فراهم می‌کند.

**کنترل ترازبندی پاراگراف (چپ، راست، وسط یا توزیع) در کجا قرار دارد؟**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) یک تنظیم سطح پاراگراف است و بر تمام پاراگراف اعمال می‌شود صرف‌نظر از قالب‌بندی بخش‌های جداگانه.

برای ترازبندی عمودی بخش‌های با اندازهٔ قلم متفاوت در هر خط، به [Align Fonts Within a Line](/slides/fa/python-net/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبانproofing را برای بخشی از پاراگراف تنظیم کنم؟**

بله. برای بخش‌های جداگند [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) را تنظیم کنید تا یک پاراگراف بتواند متنی با چند زبان مختلف داشته باشد.