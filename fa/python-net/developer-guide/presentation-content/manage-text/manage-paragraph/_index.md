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
- مدیریت گلوله
- تورفتگی پاراگراف
- تورفتگی آویز
- گلوله پاراگراف
- فهرست شماره‌دار
- فهرست گلوله‌ای
- ویژگی‌های پاراگراف
- وارد کردن HTML
- تبدیل متن به HTML
- تبدیل پاراگراف به HTML
- تبدیل پاراگراف به تصویر
- تبدیل متن به تصویر
- صادر کردن پاراگراف
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML، و تصاویر پاراگراف را با Aspose.Slides برای پایتون از طریق .NET ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides for Python via .NET متن را به‌صورت سلسله‌مراتبی از فریم‌های متنی، پاراگراف‌ها و بخش‌ها (Portion) نمایان می‌کند:

* [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) نمایانگر مخزن متن در یک شکل است و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) نمایانگر یک پاراگراف در یک فریم متنی است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) نمایانگر یک بخش متن درون یک پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی سطح کاراکتر خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متنی با قلم‌ها، رنگ‌ها، اندازه‌ها و سایر قالب‌بندی‌های متفاوت را با استفاده از چندین بخش داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با بخش‌های متعدد**

مراحل زیر یک فریم متنی با سه پاراگراف، که هر یک شامل سه بخش هستند، ایجاد می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیل به اسلاید اضافه کنید.
4. به [TextFrame] شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء دیگر از نوع [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) به فریم متنی اضافه کنید.
6. برای هر پاراگراف به اندازه کافی شیء [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) اضافه کنید تا شامل سه بخش شود. پاراگراف پیش‌فرض از قبل شامل یک بخش خالی است.
7. متن هر بخش را تنظیم کنید.
8. قالب‌بندی سطح کاراکتر را از طریق [Portion.portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/portion_format/) اعمال کنید.
9. ارائه اصلاح‌شده را ذخیره کنید.

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

## **ایجاد فهرست‌های گلوله‌ای و شماره‌دار**

### **ایجاد یک فهرست گلوله‌ای یا شماره‌دار**

گلوله‌ها و شماره‌گذاری موارد مرتبط را برای اسکن آسان‌تر می‌کند. در Aspose.Slides، تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید انتخاب شده اضافه کنید.
4. به [TextFrame] شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از فریم متنی حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) برای یک گلوله نمادین ایجاد کنید.
7. [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.SYMBOL](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید و کاراکتر گلوله را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ گلوله و ارتفاع گلوله را تنظیم کنید.
9. پاراگراف را به فریم متنی اضافه کنید.
10. پاراگراف دوم را ایجاد کنید و [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.NUMBERED](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید.
11. سبک گلوله شماره‌دار را پیکربندی کنید و پاراگراف را به فریم متنی اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال پایتون یک گلوله نمادین و یک گلوله شماره‌دار ایجاد می‌کند:

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

### **استفاده از گلوله‌های تصویری**

گلوله‌های تصویری به شما اجازه می‌دهند به‌جای نماد یا عدد، تصویر دلخواهی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کنید و به [TextFrame] آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از فریم متنی حذف کنید.
5. تصویر گلوله را بارگذاری کنید و به مجموعه تصاویر ارائه به‌عنوان یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و متن آن را تنظیم کنید.
7. [BulletFormat.type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/type/) را به [BulletType.PICTURE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bullettype/) تنظیم کنید.
8. تصویر را از طریق [BulletFormat.picture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/picture/) اختصاص دهید و ارتفاع گلوله را تنظیم کنید.
9. پاراگراف را به فریم متنی اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

این مثال پایتون یک گلوله تصویری ایجاد می‌کند:

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

[ParagraphFormat.depth](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/depth/) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالا دارای عمق `0` است.

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض را از فریم متنی آن پاک کنید.
3. چهار پاراگراف ایجاد کنید و نمادهای گلوله آن‌ها را پیکربندی کنید.
4. مقدارهای [ParagraphFormat.depth](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/depth/) آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به فریم متنی اضافه کنید و ارائه را ذخیره کنید.

این مثال پایتون فهرست گلوله‌ای چهارسطحی ایجاد می‌کند:

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

### **شروع شماره‌گذاری موارد فهرست با مقادیر سفارشی**

از [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) برای تنظیم عدد اولیه نمایش‌داده‌شده برای یک پاراگراف شماره‌دار استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از فریم متنی شکل پاک کنید.
3. سه پاراگراف شماره‌دار ایجاد کنید.
4. برای پاراگراف‌های مربوطه [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) را به ترتیب `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به فریم متنی اضافه کنید و ارائه را ذخیره کنید.

این مثال پایتون عدد شروع سفارشی را به هر پاراگراف اختصاص می‌دهد:

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

## **کنترل چینش پاراگراف و ویژگی‌های انتهایی**

### **تنظیم تورفتگی اولین خط**

از ویژگی [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) برای کنترل تورفتگی اولین خط پاراگراف استفاده کنید. این ویژگی فقط اولین خط را نسبت به حاشیه سمت چپ پاراگراف جابجا می‌کند. مقدار مثبت اولین خط را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده همان‌جا می‌مانند.

وقتی نیاز به جابه‌جایی کل پاراگراف دارید، از [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) استفاده کنید. وقتی فقط اولین خط را می‌خواهید جابه‌جا کنید، از [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) استفاده کنید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر مختلف [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) را برای نمایش تأثیر تورفتگی اولین خط اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame] شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف ایجاد کنید و مقادیر متفاوت [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به فریم متنی اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

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

![تورفتگی اولین خط پاراگراف‌ها](first_line_indent.png)

### **تنظیم تورفتگی آویز (Hanging Indent)**

تورفتگی آویز چینش پاراگرافی است که در آن اولین خط به سمت چپ خطوط پسین شروع می‌شود. در Aspose.Slides این اثر را با ویژگی [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) ایجاد می‌کنید. `indent` را به مقدار منفی تنظیم کنید تا اولین خط نسبت به بدن پاراگراف به چپ جابه‌جا شود.

در عمل، [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) موقعیت چپ بدن پاراگراف را تعریف می‌کند و [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) موقعیت اولین خط را نسبت به آن حاشیه تعیین می‌کند. برای ایجاد تورفتگی آویز، مقدار `margin_left` را مثبت و `indent` را منفی تنظیم کنید.

این قالب‌بندی برای کتابنامه‌ها، مراجع، اصطلاح‌نامه‌ها و سایر پاراگراف‌هایی که خطوط بسته‌بندی‌شده باید زیر بدن پاراگراف نه زیر اولین کاراکتر خط اول تراز شوند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame] شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. پاراگراف‌ها را ایجاد کنید و برای هر پاراگراف مقدار مثبت [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) تنظیم کنید.
6. مقدار منفی [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) را تنظیم کنید تا اثر تورفتگی آویز ایجاد شود.
7. پاراگراف‌ها را به فریم متنی اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد نحوه تنظیم تورفتگی آویز برای پاراگراف را نشان می‌دهد:

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

![تورفتگی آویز پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های انتهای پاراگراف (End Paragraph Run Properties)**

ویژگی [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) قالب‌بندی علامت پایان پاراگراف را کنترل می‌کند. مثال زیر اندازه قلم و قلم لاتین را به علامت پایان پاراگراف دوم اختصاص می‌دهد:

1. یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و به آن‌ها بخش‌های متنی اضافه کنید.
4. یک [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) برای علامت پایان پاراگراف دوم ایجاد کنید.
5. [PortionFormat.font_height](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/font_height/) و [PortionFormat.latin_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/latin_font/) را تنظیم کنید.
6. قالب را به [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) اختصاص دهید و ارائه را ذخیره کنید.

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

برای قواعد پاراگرافی که بر بسته‌بندی خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به بخش‌های [Control Line Breaking](/slides/fa/python-net/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/python-net/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [Paragraph.get_lines_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/get_lines_count/) برای شمارش خطوط اشغال‌شده توسط یک پاراگراف پس از چینش متن استفاده کنید، از جمله بسته‌بندی خودکار. این برای بررسی طول متن و چینش در قالب‌های ارائه مفید است.

یک پاراگراف یک مورد در [TextFrame.paragraphs](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/paragraphs/) است و می‌تواند چندین خط رندر شده داشته باشد. یک شکست خط صریح درون پاراگراف یک خط جدید ایجاد می‌کند بدون ایجاد پاراگراف جدید. بسته‌بندی خودکار خطوط را بر اساس عرض در دسترس ایجاد می‌کند بدون وارد کردن شکست‌های صریح به متن. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، شمارش خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته کوتاه‌تری جایگزین می‌کند. بسته‌بندی فعال و خودکار‌سنجی غیرفعال است تا عرض شکل بسته‌بندی را کنترل کند بدون اینکه متن به‌صورت خودکار کوچک یا شکل تغییر اندازه دهد. ابعاد شکل به پوینت است. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و مجموع خطوط را در فریم متنی محاسبه می‌کند.

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

با این متن و این ابعاد، باریک‌کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه تعداد خطوط را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن قلم‌ها و جایگزینی، اندازه قلم، حاشیه‌ها، تورفتگی، بسته‌بندی و تنظیمات خودکار‌سنجی متفاوت باشد. هنگام بررسی یک قالب، از قلم‌ها و تنظیمات چیدمان مورد نظر برای محیط هدف استفاده کنید.

تعداد خطوط به تنهایی تعیین نمی‌کند که آیا متن از مخزن خود خارج می‌شود یا نه. ارتفاع موجود، ارتفاع خطوط، فواصل پاراگراف و خط، و رفتار خودکار‌سنجی نیز مهم هستند؛ حتی یک خط می‌تواند عرض موجود را هنگام غیرفعال بودن بسته‌بندی تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/add_from_html/) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متنی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. به یک اسلاید دسترسی پیدا کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) اضافه کنید.
3. به [TextFrame] شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشته HTML را به [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/add_from_html/) منتقل کنید.
6. ارائه اصلاح‌شده را ذخیره کنید.

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

### **صادر کردن متن پاراگراف به HTML**

از [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/export_to_html/) برای صادرات یک بازه انتخاب‌شده از پاراگراف‌ها به صورت HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه موردنظر را بارگذاری کنید.
2. به اسلاید دسترسی پیدا کنید و [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) حاوی متن را پیدا کنید.
3. به [TextFrame] شکل دسترسی پیدا کنید.
4. [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphcollection/export_to_html/) را با شاخص پاراگراف شروع و تعداد پاراگراف‌های موردنظر برای صادرات فراخوانی کنید.
5. رشته HTML برگردانده‌شده را در فایلی بنویسید.

این مثال پایتون تمام پاراگراف‌های اولین شکل متنی را صادر می‌کند:

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

### **رندر کردن یک پاراگراف به عنوان تصویر**

[Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) متد `get_image` را برای رندر مستقیم یک پاراگراف ارائه می‌دهد. این متد یک [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) برمی‌گرداند که می‌توانید با [IImage.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/save/) در فایل یا جریان ذخیره کنید. نیازی به رندر شکل حاوی آن یا برش دستی بیت‌مپ نیست.

متد `get_image` می‌تواند `None` برگرداند اگر پاراگراف در مجموعه والد یافت نشود، محدوده رندر معتبری نداشته باشد یا نتواند رندر شود. قبل از ذخیره نتیجه را بررسی کنید و از تصویر برگردانده‌شده به عنوان مدیر زمینه (context manager) برای آزاد کردن منابع استفاده کنید.

#### **رندر یک پاراگراف با مقیاس پیش‌فرض**

فرض کنیم فایلی به نام `sample.pptx` داریم که شامل یک اسلاید است و اولین شکل آن یک جعبه متنی با سه پاراگراف است.

![جعبه متنی با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متنی عادی با مقیاس پیش‌فرض رندر می‌کند و تصویر برگردانده‌شده را در فرمت PNG ذخیره می‌کند:

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

#### **رندر یک پاراگراف در سلول جدول با مقیاس‌بندی**

برای کنترل اندازه پاراگراف رندرشده، مقادیر مقیاس افقی و عمودی را به `get_image` پاس می‌دهیم. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلولش با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به صورت تصویر PNG ذخیره می‌کند:

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

یک عامل مقیاس `1` آن محور را با اندازه پیش‌فرض پیکسل نگه می‌دارد. برای مثال، `2` برای هر دو عامل تصویری با عرض و ارتفاع تقریباً دو برابر ابعاد پیش‌فرض تولید می‌کند که چهار برابر پیکسل دارد. عوامل بزرگتر معمولاً متن واضح‌تری برای بزرگ‌نمایی یا خروجی با وضوح بالا تولید می‌کنند، اما حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتر با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت طول و عرض پاراگراف، عوامل مساوی استفاده کنید؛ عوامل متفاوت افقی و عمودی خروجی را به طور مستقل کش می‌دهند.

رندر کل شکل با [Shape.get_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_image/) زمانی مفید است که خروجی باید شامل پرشدگی، حاشیه یا زمینهٔ بصری شکل باشد. برای تصویر فقط پاراگراف، از `Paragraph.get_image` استفاده کنید.

## **سئوالات متداول**

**آیا می‌توانم بسته‌بندی خطوط داخل یک فریم متنی را به‌طور کامل غیرفعال کنم؟**

بله. با تنظیم [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/wrap_text/) بسته‌بندی را غیرفعال کنید تا خطوط در حاشیه فریم متنی قطع نشوند.

**چگونه می‌توانم مرزهای دقیق روی اسلاید یک پاراگراف خاص را دریافت کنم؟**

از [Paragraph.get_rect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/get_rect/) برای دریافت مستطیل محدودکننده پاراگراف استفاده کنید. [Portion.get_rect](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/get_rect/) مرزهای یک بخش جداگانه را فراهم می‌کند.

**کنترل تراز پاراگراف (چپ، راست، وسط یا توجیه) در کجا انجام می‌شود؟**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/alignment/) تنظیم سطح پاراگراف است و برای تمام پاراگراف اعمال می‌شود صرف‌نظر از قالب‌بندی هر بخش جداگانه.

**آیا می‌توانم زبان اصلاح‌نویسی (proofing) را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. با تنظیم [PortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/language_id/) برای بخش‌های جداگانه، می‌توانید یک پاراگراف را شامل متنی با چند زبان مختلف کنید.