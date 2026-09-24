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
  - مدیریت گلوله
  - تو رفتگی پاراگراف
  - تو رفتگی معلق
  - گلوله پاراگراف
  - فهرست عددی
  - فهرست نقطه‌دار
  - خصوصیات پاراگراف
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
description: "یادگیری نحوه ایجاد و قالب‌بندی پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های عددی، تو رفتگی‌ها، محتوای HTML و تصاویر پاراگراف با Aspose.Slides برای پایتون از طریق .NET."
---
## **نمای کلی**

Aspose.Slides for Python via .NET متن را به صورت یک سلسله‌مراتب از **TextFrame**، **Paragraph** و **Portion** نمایش می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) نمایانگر محفظهٔ متن در یک شکل است و دسترسی به مجموعهٔ پاراگراف‌های آن را فراهم می‌کند.
* [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) نمایانگر یک پاراگراف در یک TextFrame است و دسترسی به Portionها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) نمایانگر یک بخش متن داخل یک پاراگراف است. هر Portion می‌تواند متن و قالب‌بندی سطح کاراکتر خود را داشته باشد.

بنابراین یک Paragraph می‌تواند متن با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف را با استفاده از چندین Portion در خود داشته باشد.

## **ایجاد و قالب‌بندی Paragraphها**

### **ایجاد Paragraphها با چندین Portion**

مراحل زیر یک TextFrame با سه Paragraph ایجاد می‌کند که هر کدام شامل سه Portion هستند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق اندیس آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به **TextFrame** شکل دسترسی پیدا کنید.
5. از Paragraph پیش‌فرض استفاده کنید و دو شیء [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) دیگر به TextFrame اضافه کنید.
6. به اندازه کافی شیء [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) برای هر Paragraph اضافه کنید تا هر کدام سه Portion داشته باشند. Paragraph پیش‌فرض در حال حاضر یک Portion خالی دارد.
7. متن هر Portion را تنظیم کنید.
8. قالب‌بندی سطح کاراکتر را از طریق [Portion.portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/portion_format/) اعمال کنید.
9. ارائه (Presentation) اصلاح‌شده را ذخیره کنید.

این مثال پایتون این مراحل را پیاده‌سازی می‌کند:

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

## **ایجاد فهرست‌های نقطه‌ای و عددی**

### **ایجاد فهرست نقطه‌ای یا عددی**

نقطه‌ها و شماره‌گذاری موارد مرتبط را برای اسکن آسان‌تر می‌کنند. در Aspose.Slides، تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق اندیس آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به **TextFrame** شکل دسترسی پیدا کنید.
5. Paragraph پیش‌فرض را از TextFrame حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) برای یک نقطهٔ نماد ایجاد کنید.
7. [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.SYMBOL](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید و کاراکتر نقطه را مشخص کنید.
8. متن پاراگراف، تو رفتگی، رنگ نقطه و ارتفاع نقطه را تنظیم کنید.
9. Paragraph را به TextFrame اضافه کنید.
10. یک پاراگراف دوم ایجاد کنید و [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.NUMBERED](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید.
11. سبک نقطهٔ عددی را پیکربندی کنید و پاراگراف را به TextFrame اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال پایتون یک نقطهٔ نماد و یک نقطهٔ عددی ایجاد می‌کند:

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

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق اندیس آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کنید و به **TextFrame** آن دسترسی پیدا کنید.
4. Paragraph پیش‌فرض را از TextFrame حذف کنید.
5. تصویر نقطه را بارگذاری کنید و به مجموعهٔ تصاویر ارائه به عنوان یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و متن آن را تنظیم کنید.
7. [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.PICTURE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید.
8. تصویر را از طریق [BulletFormat.picture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/picture/) اختصاص دهید و ارتفاع نقطه را تنظیم کنید.
9. Paragraph را به TextFrame اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

این مثال پایتون یک نقطهٔ تصویری ایجاد می‌کند:

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

[ParagraphFormat.depth](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/depth/) را تنظیم کنید تا Paragraphها در سطوح مختلف فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کنید و Paragraph پیش‌فرض را از TextFrame آن پاک کنید.
3. چهار Paragraph ایجاد کنید و نمادهای نقطه آن‌ها را پیکربندی کنید.
4. مقدارهای [ParagraphFormat.depth](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/depth/) آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. Paragraphها را به TextFrame اضافه کنید و ارائه را ذخیره کنید.

این مثال پایتون یک فهرست نقطه‌ای چهارسطحی ایجاد می‌کند:

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

### **شروع شماره‌گذاری فهرست از مقادیر دلخواه**

از [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) برای تعیین عدد اولیهٔ نمایش داده‌شده برای یک Paragraph عددی استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به یک اسلاید اضافه کنید.
2. Paragraph پیش‌فرض را از TextFrame شکل پاک کنید.
3. سه Paragraph عددی ایجاد کنید.
4. برای هر کدام از Paragraphها مقدار [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) را به ترتیب `2`، `3` و `7` تنظیم کنید.
5. Paragraphها را به TextFrame اضافه کنید و ارائه را ذخیره کنید.

این مثال پایتون عدد شروع سفارشی را به هر Paragraph اختصاص می‌دهد:

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

## **کنترل چیدمان Paragraph و خصوصیات انتهای آن**

### **تنظیم تو رفتگی خط اول**

از خصوصیت [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) برای کنترل تو رفتگی خط اول یک Paragraph استفاده کنید. این خصوصیت تنها خط اول را نسبت به حاشیهٔ چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست حرکت می‌دهد، در حالی که خطوط باقی‌مانده به بدنهٔ پاراگراف تراز می‌شوند.

وقتی نیاز به جابجایی کل پاراگراف دارید از [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) استفاده کنید. وقتی فقط خط اول را می‌خواهید جابه‌جا کنید از [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) استفاده کنید.

مثال زیر چند Paragraph ایجاد می‌کند و مقادیر مختلف [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) را برای نشان دادن اثر تو رفتگی خط اول اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به **TextFrame** شکل دسترسی پیدا کنید و Paragraph پیش‌فرض را حذف کنید.
5. چند Paragraph ایجاد کنید و مقادیر متفاوتی از [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) برای آن‌ها تنظیم کنید.
6. Paragraphها را به TextFrame اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تو رفتگی یک Paragraph تنظیم شود:

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

![تو رفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تو رفتگی معلق**

تو رفتگی معلق یک چیدمان پاراگراف است که در آن خط اول به سمت چپ خطوط دیگر می‌آید. در Aspose.Slides این اثر را با خصوصیت [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) ایجاد می‌کنید. مقدار `indent` را به عدد منفی تنظیم کنید تا خط اول نسبت به بدنهٔ پاراگراف به سمت چپ جابه‌جا شود.

به‌صورت عملی، [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) موقعیت چپ بدنهٔ پاراگراف را تعیین می‌کند و [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) موقعیت خط اول را نسبت به آن حاشیه مشخص می‌کند. برای ایجاد تو رفتگی معلق، مقدار مثبت `margin_left` و مقدار منفی `indent` را تنظیم کنید.

این قالب‌بندی برای کتاب‌نامه‌ها، مراجع، واژه‌نامه‌ها و پاراگراف‌های دیگری که خطوط بسته‌شده باید زیر بدنهٔ پاراگراف تراز شوند مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به **TextFrame** شکل دسترسی پیدا کنید و Paragraph پیش‌فرض را حذف کنید.
5. Paragraphها را ایجاد کنید و برای هر کدام مقدار مثبت [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) تنظیم کنید.
6. مقدار منفی [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) را تنظیم کنید تا اثر تو رفتگی معلق ایجاد شود.
7. Paragraphها را به TextFrame اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تو رفتگی معلق برای یک Paragraph تنظیم شود:

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

![تو رفتگی معلق پاراگراف‌ها](hanging_indent.png)

### **تنظیم خصوصیات انتهایی Paragraph**

خصوصیت [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) قالب‌بندی علامت پایان پاراگراف را کنترل می‌کند. مثال زیر اندازهٔ قلم و فونت لاتین را برای علامت پایان پاراگراف دوم تنظیم می‌کند:

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کنید و Paragraph پیش‌فرض آن را پاک کنید.
3. دو Paragraph ایجاد کنید و به آن‌ها Portionهای متنی اضافه کنید.
4. یک [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) برای علامت پایان پاراگراف دوم ایجاد کنید.
5. [PortionFormat.font_height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/font_height/) و [PortionFormat.latin_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/latin_font/) را تنظیم کنید.
6. این قالب را به [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) اختصاص دهید و ارائه را ذخیره کنید.

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

از [Paragraph.get_lines_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/get_lines_count/) برای شمارش خطوطی که یک Paragraph پس از چیدمان متن (شامل بسته شدن خودکار) اشغال می‌کند استفاده کنید. این کار هنگام بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

یک Paragraph یک مورد در [TextFrame.paragraphs](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/paragraphs/) است و می‌تواند چندین خط رندر شده را اشغال کند. یک شکست خط صریح داخل Paragraph یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف جدیدی ایجاد شود. بسته شدن خودکار خطوط براساس عرض موجود انجام می‌شود و یک کاراکتر شکست خط صریح را وارد نمی‌کند. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، شمارش خط رندر شده را نمی‌دهد.

مثال زیر یک شکل متن ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته‌ای کوتاه‌تر جایگزین می‌کند. بسته شدن خطوط فعال است و AutoFit غیرفعال است تا عرض شکل کنترل بسته شدن را داشته باشد بدون اینکه متن یا شکل به‌صورت خودکار کوچک شود. ابعاد شکل بر حسب پونت هستند. در نهایت، مثال یک Paragraph دیگر اضافه می‌کند و مجموع خطوط را در سراسر TextFrame جمع می‌زند.

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

با این متن و این ابعاد، باریک کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشتهٔ کوتاه‌تر آن را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن فونت، جایگزینی، اندازهٔ فونت، حاشیه‌ها، تو رفتگی، بسته شدن و تنظیمات AutoFit متفاوت باشد. برای بررسی یک قالب، از فونت‌ها و تنظیمات چیدمانی که برای محیط هدف مدنظر دارید استفاده کنید.

تنها شمارش خطوط تعیین نمی‌کند که آیا متن از محفظهٔ خود فراتر می‌رود یا نه. ارتفاع موجود، ارتفاع خطوط، فاصلهٔ پاراگراف و خط، و رفتار AutoFit نیز مهم هستند؛ حتی یک خط واحد می‌تواند عرض موجود را هنگامی که بسته شدن غیرفعال باشد، تجاوز کند.

## **واردات و صادرات محتوای Paragraph**

### **وارد کردن متن HTML به Paragraphها**

از [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/add_from_html/) برای تبدیل علامت‌گذاری HTML به Paragraphها و Portionها در یک TextFrame استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید دسترسی پیدا کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کنید.
3. به **TextFrame** شکل دسترسی پیدا کنید و Paragraph پیش‌فرض را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشتهٔ HTML را به متد [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/add_from_html/) پاس دهید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این مثال پایتون HTML را به یک TextFrame وارد می‌کند:

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

### **صادر کردن متن Paragraph به HTML**

از [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/export_to_html/) برای صادرات یک محدودهٔ منتخب از Paragraphها به صورت HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائهٔ موردنظر را بارگذاری کنید.
2. اسلاید را دسترسی پیدا کنید و [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) حاوی متن را پیدا کنید.
3. به **TextFrame** شکل دسترسی پیدا کنید.
4. متد [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/export_to_html/) را با اندیس پاراگراف شروع و تعداد پاراگراف‌های موردنظر فراخوانی کنید.
5. رشتهٔ HTML برگشتی را در فایلی بنویسید.

این مثال پایتون تمام Paragraphهای اولین شکل متنی را صادر می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **رندر کردن یک Paragraph به عنوان تصویر**

[Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) متد `get_image` را برای رندر مستقیم یک Paragraph فراهم می‌کند. این متد یک [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) برمی‌گرداند که می‌توانید با [IImage.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/save/) به فایل یا جریان ذخیره کنید. نیازی به رندر شکل حاکم یا برش بیت‌مپ به صورت دستی نیست.

متد `get_image` می‌تواند `None` بازگرداند اگر Paragraph در مجموعهٔ والد خود یافت نشود، محدودهٔ رندر معتبری نداشته باشد یا قابل رندر نباشد. قبل از ذخیره‌سازی نتیجه را بررسی کنید و از تصویر بازگردانده‌شده به‌عنوان یک Context Manager برای آزادسازی منابع استفاده کنید.

#### **رندر کردن یک Paragraph در مقیاس پیش‌فرض**

فرض کنیم فایلی به‌نام sample.pptx داریم که شامل یک اسلاید است و اولین شکل آن یک TextBox حاوی سه Paragraph است.

![TextBox حاوی سه Paragraph](paragraph_to_image_input.png)

مثال زیر Paragraph دوم را در یک شکل متنی عادی در مقیاس پیش‌فرض رندر می‌کند و تصویر بازگردانده‌شده را به‌صورت PNG ذخیره می‌نماید:

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

![تصویر Paragraph](paragraph_to_image_output.png)

#### **رندر کردن یک Paragraph در یک سلول جدول با مقیاس‌بندی**

به `get_image` عوامل مقیاس افقی و عمودی پاس دهید تا اندازهٔ Paragraph رندر شده کنترل شود. مثال زیر یک جدول ایجاد می‌کند، Paragraph را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌نماید:

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

عامل مقیاس `1` آن محور را در اندازهٔ پیش‌فرض پیکسل حفظ می‌کند. برای مثال، `2` برای هر دو عامل تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض هستند و چهار برابر پیکسل دارند. عوامل بزرگ‌تر معمولاً برای زوم یا خروجی با وضوح بالا متن واضح‌تری تولید می‌کنند، اما مصرف حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتری با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت عرض به ارتفاع Paragraph از عوامل برابر استفاده کنید؛ عوامل متفاوت محور افقی و عمودی خروجی را به‌ طور مستقل کش می‌دهند.

رندر کل یک شکل با استفاده از [Shape.get_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_image/) زمانی مفید است که خروجی نیاز به شامل پر کردن، حاشیه یا سایر زمینه‌های بصری شکل داشته باشد. برای تصویر فقط شامل Paragraph از `Paragraph.get_image` استفاده کنید.

## **سؤالات متداول**

**آیا می‌توانم بسته شدن خطوط داخل یک TextFrame را به‌طور کامل غیرفعال کنم؟**

بله. مقدار [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/wrap_text/) را تنظیم کنید تا بسته شدن غیرفعال شود و خطوط در لبه‌های TextFrame شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق روی اسلاید یک Paragraph خاص را به‌دست آورم؟**

از [Paragraph.get_rect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/get_rect/) برای دریافت مستطیل محدود کنندهٔ Paragraph استفاده کنید. [Portion.get_rect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/get_rect/) مرزهای یک Portion منفرد را فراهم می‌کند.

**محل تنظیم تراز Paragraph (چپ، راست، مرکز یا کشیده) کجاست؟**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/alignment/) یک تنظیم سطح پاراگراف است و بر کل پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی Portionهای منفرد.

**آیا می‌توانم زبان اثبات برای بخشی از یک Paragraph تنظیم کنم؟**

بله. مقدار [PortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/language_id/) را برای Portionهای منفرد تنظیم کنید تا یک Paragraph بتواند متن در چند زبان مختلف داشته باشد.