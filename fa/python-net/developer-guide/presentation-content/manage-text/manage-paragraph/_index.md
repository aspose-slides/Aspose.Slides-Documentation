---
title: مدیریت پاراگراف‌های متن پاورپوینت در پایتون
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
- فهرست نقطه‌ای
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- خروجی‌گیری پاراگراف
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "بیاموزید چگونه پاراگراف‌ها، بخش‌ها، نقطه‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای پایتون از طریق .NET ایجاد و قالب‌بندی کنید."
---
## **مرور کلی**

Aspose.Slides برای Python از طریق .NET متن را به‌صورت سلسله‌مراتبی از فریم‌های متنی، پاراگراف‌ها و بخش‌ها (Portion) نمایش می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) نمایانگر محفظه متن در یک شکل است و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) نمایانگر یک پاراگراف در یک فریم متنی است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را می‌دهد.
* [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) نمایانگر یک بخش متنی داخل پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی کاراکتری جداگانه خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متن با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف را با استفاده از بخش‌های متعدد داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با بخش‌های متعدد**

مراحل زیر یک فریم متنی با سه پاراگراف، هر یک شامل سه بخش ایجاد می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء دیگر [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) را به فریم متنی اضافه کنید.
6. برای هر پاراگراف به اندازه کافی شیء [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) اضافه کنید تا سه بخش داشته باشد. پاراگراف پیش‌فرض از قبل یک بخش خالی دارد.
7. متن هر بخش را تنظیم کنید.
8. قالب‌بندی کاراکتری را از طریق [Portion.portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/portion_format/) اعمال کنید.
9. ارائه (presentation) اصلاح شده را ذخیره کنید.

این مثال پایتون مراحل فوق را پیاده‌سازی می‌کند:

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

## **ایجاد فهرست‌های نقطه‌ای و شماره‌دار**

### **ایجاد یک فهرست نقطه‌ای یا شماره‌دار**

نقطه‌ها و شماره‌ها موارد مرتبط را اسکن کردن آسان‌تر می‌کنند. در Aspose.Slides تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از فریم متنی حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) برای یک نقطه نماد (symbol bullet) ایجاد کنید.
7. [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.SYMBOL](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید و کاراکتر نقطه را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ نقطه و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به فریم متنی اضافه کنید.
10. یک پاراگراف دوم ایجاد کنید و [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.NUMBERED](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید.
11. سبک نقطه شماره‌دار را پیکربندی کنید و پاراگراف را به فریم متنی اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال پایتون یک نقطه نماد و یک نقطه شماره‌دار ایجاد می‌کند:

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

### **استفاده از نقاط تصویری**

نقاط تصویری به شما امکان می‌دهند به‌جای نماد یا عدد، تصویر سفارشی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کرده و به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از فریم متنی حذف کنید.
5. تصویر نقطه را بارگذاری کرده و به مجموعه تصاویر ارائه به‌عنوان یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کرده و متن آن را تنظیم کنید.
7. [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.PICTURE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید.
8. تصویر را از طریق [BulletFormat.picture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/picture/) اختصاص داده و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به فریم متنی اضافه کنید.
10. ارائه اصلاح شده را ذخیره کنید.

این مثال پایتون یک نقطه تصویری ایجاد می‌کند:

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

[ParagraphFormat.depth](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/depth/) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کرده و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض را از فریم متنی آن پاک کنید.
3. چهار پاراگراف ایجاد کرده و نمادهای نقطه آن‌ها را پیکربندی کنید.
4. مقدارهای [ParagraphFormat.depth](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/depth/) آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به فریم متنی اضافه کرده و ارائه را ذخیره کنید.

این مثال پایتون یک فهرست چهارسطحی نقطه‌ای ایجاد می‌کند:

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

### **شروع موارد فهرست شماره‌دار با مقادیر سفارشی**

از [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) برای تنظیم عدد اولیه نمایش داده‌شده برای یک پاراگراف شماره‌دار استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کرده و یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از فریم متنی شکل پاک کنید.
3. سه پاراگراف شماره‌دار ایجاد کنید.
4. برای پاراگراف‌های مربوطه، [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) را به ترتیب به `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به فریم متنی اضافه کرده و ارائه را ذخیره کنید.

این مثال پایتون عدد شروع سفارشی را برای هر پاراگراف اختصاص می‌دهد:

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

## **کنترل چیدمان پاراگراف و خصوصیات پایان**

### **تنظیم تورفتگی خط اول**

از ویژگی [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این ویژگی تنها خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده به بدنه پاراگراف هم‌راستا می‌مانند.

زمانی که نیاز به جابه‌جایی کل پاراگراف دارید، از [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) استفاده کنید. زمانی که فقط خط اول را می‌خواهید جابه‌جا کنید، از [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) استفاده کنید.

مثال زیر چند پاراگراف ایجاد کرده و مقادیر مختلف [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) را برای نشان دادن تأثیر تورفتگی خط اول بر چیدمان پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف ایجاد کرده و مقادیر مختلف [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به فریم متنی اضافه کنید.
7. ارائه اصلاح شده را ذخیره کنید.

این کد نحوه تنظیم تورفتگی پاراگراف را نشان می‌دهد:

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

![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تورفتگی معلق**

تورفتگی معلق چیدمان پاراگرافی است که در آن خط اول نسبت به خطوط دیگر به سمت چپ می‌آید. در Aspose.Slides این اثر را با ویژگی [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) ایجاد می‌کنید. مقدار `indent` را به مقدار منفی تنظیم کنید تا خط اول نسبت به بدنه پاراگراف به چپ حرکت کند.

در عمل، [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) موقعیت خط اول را نسبت به آن حاشیه مشخص می‌سازد. برای ایجاد تورفتگی معلق، مقدار مثبت برای `margin_left` و مقدار منفی برای `indent` تنظیم کنید.

این قالب‌بندی برای کتاب‌نامه‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط پیچیده باید زیر بدنه پاراگراف هم‌راستا شوند مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) تنظیم کنید.
6. مقدار منفی برای [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) تنظیم کنید تا اثر تورفتگی معلق ایجاد شود.
7. پاراگراف‌ها را به فریم متنی اضافه کنید.
8. ارائه اصلاح شده را ذخیره کنید.

این کد نحوه تنظیم تورفتگی معلق برای یک پاراگراف را نشان می‌دهد:

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

![تورفتگی معلق پاراگراف‌ها](hanging_indent.png)

### **تنظیم خصوصیات انتهای پاراگراف**

ویژگی [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) قالب‌بندی علامت پایان پاراگراف را کنترل می‌کند. مثال زیر اندازه قلم و فونت لاتین را برای علامت پایان پاراگراف دوم اختصاص می‌دهد:

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و به آن‌ها بخش‌های متنی اضافه کنید.
4. یک [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) برای علامت پایان پاراگراف دوم ایجاد کنید.
5. [PortionFormat.font_height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/font_height/) و [PortionFormat.latin_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/latin_font/) را تنظیم کنید.
6. قالب را به [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) اختصاص داده و ارائه را ذخیره کنید.

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

## **وارد کردن و خروجی‌گیری محتواهای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/add_from_html/) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متنی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید دسترسی پیدا کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کنید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشته HTML را به [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/add_from_html/) پاس دهید.
6. ارائه اصلاح شده را ذخیره کنید.

این مثال پایتون HTML را به یک فریم متنی وارد می‌کند:

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

### **خروجی‌گیری متن پاراگراف به HTML**

از [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/export_to_html/) برای خروجی‌گیری یک بازه انتخابی از پاراگراف‌ها به‌صورت HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه مورد نظر را بارگذاری کنید.
2. اسلاید را دسترسی پیدا کنید و [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) حاوی متن را پیدا کنید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
4. با ارائه شاخص پاراگراف شروع و تعداد پاراگراف‌های موردنظر، [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/export_to_html/) را صدا بزنید.
5. رشته HTML بازگشتی را در فایلی بنویسید.

این مثال پایتون تمام پاراگراف‌ها را از اولین شکل متنی خروجی می‌گیرد:

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

### **رندر کردن یک پاراگراف به‌صورت تصویر**

[Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) متد `get_image` را برای رندر مستقیم یک پاراگراف ارائه می‌دهد. این متد یک [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) برمی‌گرداند که می‌توانید با [IImage.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/save/) آن را در فایل یا جریان ذخیره کنید. نیازی به رندر شکل حاوی آن یا برش دستی بیت‌مپ نیست.

متد `get_image` ممکن است `None` برگرداند اگر پاراگراف در مجموعه والد یافت نشود، مرزهای رندر معتبری نداشته باشد یا قابلیت رندر نداشته باشد. قبل از ذخیره‌سازی نتیجه را بررسی کنید و از تصویر بازگردانده‌شده به‌عنوان یک context manager برای آزادسازی منابع استفاده کنید.

#### **رندر پاراگراف با مقیاس پیش‌فرض**

فرض کنید فایلی به‌نام sample.pptx داریم که یک اسلاید دارد و اولین شکل آن یک کادر متنی شامل سه پاراگراف است.

![کادر متنی با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متنی عادی با مقیاس پیش‌فرض رندر کرده و تصویر بازگشتی را در قالب PNG ذخیره می‌کند:

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

![تصویر پاراگراف](paragraph_to_image_output.png)

#### **رندر پاراگراف در یک سلول جدول با مقیاس‌دهی**

برای کنترل اندازه پاراگراف رندر شده، عوامل مقیاس افقی و عمودی را به `get_image` پاس دهید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول با دوبرابر کردن عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌نماید:

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

عامل مقیاس `1` آن محور را در اندازه پیش‌فرض پیکسل نگه می‌دارد. به‌عنوان مثال، `2` برای هر دو عامل باعث می‌شود عرض و ارتفاع تصویر تقریباً دو برابر ابعاد پیش‌فرض شود و چهار برابر پیکسل داشته باشد. عوامل بزرگ‌تر معمولاً متن واضح‌تری برای زوم یا خروجی با وضوح بالا تولید می‌کنند، اما حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتری با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت طول‌ارتفاع پاراگراف از عوامل برابر استفاده کنید؛ عوامل افقی و عمودی متفاوت خروجی را به‌صورت مستقل کشیده می‌کنند.

رندر کل شکل با [Shape.get_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_image/) زمانی مفید است که خروجی نیاز به شامل پرشدگی، حاشیه یا سایر زمینه‌های بصری شکل داشته باشد. برای تصویر فقط پاراگراف، از `Paragraph.get_image` استفاده کنید.

## **سؤالات متداول**

**آیا می‌توانم بسته شدن خودکار خطوط داخل فریم متنی را کاملاً غیرفعال کنم؟**

بله. با تنظیم [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/wrap_text/) می‌توانید بسته شدن خطوط را غیرفعال کنید تا خطوط در لبه‌های فریم متنی شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق روی اسلاید یک پاراگراف خاص را دریافت کنم؟**

از [Paragraph.get_rect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/get_rect/) برای بازیابی مستطیل محدود کننده پاراگراف استفاده کنید. [Portion.get_rect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/get_rect/) حدود یک بخش تک‌نفره را فراهم می‌آورد.

**محل تنظیم تراز پاراگراف (چپ، راست، مرکز یا هماهنگ) کجا کنترل می‌شود؟**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/alignment/) یک تنظیم سطح پاراگراف است و بر کل پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی هر بخش.

**آیا می‌توانم زبان اثبات برای بخشی از پاراگراف را تنظیم کنم؟**

بله. می‌توانید برای بخش‌های جداگانه [PortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/language_id/) را تنظیم کنید تا یک پاراگراف شامل متنی در چند زبان مختلف باشد.