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
- مدیریت بولت
- تورفتگی پاراگراف
- تورفتگی آویزان
- بولت پاراگراف
- فهرست شماره‌دار
- فهرست بولت‌شده
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- خروجی پاراگراف
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "قالب‌بندی پاراگراف را با Aspose.Slides برای پایتون از طریق .NET به‌صورت بهینه تنظیم کنید—تراز، فاصله‌گذاری و سبک را در ارائه‌های PowerPoint و OpenDocument در پایتون بهبود دهید تا مخاطبان را جذب کنید."
---
## **مقدمه**

Aspose.Slides کلاس‌هایی را فراهم می‌کند که برای کار با متن PowerPoint در پایتون نیاز دارید.

* Aspose.Slides کلاس [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) را برای ایجاد اشیاء فریم متن فراهم می‌کند. یک شیء `TextFrame` می‌تواند یک یا چند پاراگراف را در خود داشته باشد (هر پاراگراف با یک کاراکتر بازگشت جدا می‌شود).
* Aspose.Slides کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) را برای ایجاد اشیاء پاراگراف فراهم می‌کند. یک شیء `Paragraph` می‌تواند یک یا چند بخش متن را در خود داشته باشد.
* Aspose.Slides کلاس [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) را برای ایجاد بخش‌های متن و تعیین ویژگی‌های قالب‌بندی آن‌ها فراهم می‌کند.

یک شیء `Paragraph` می‌تواند متنی با ویژگی‌های قالب‌بندی مختلف را از طریق اشیاء `Portion` زیرین خود مدیریت کند.

## **نصب**

```bash
pip install aspose.slides
```

## **افزودن چندین پاراگراف شامل چندین Portion**

این مراحل نشان می‌دهد چگونه یک فریم متن که شامل سه پاراگراف است و هر کدام سه Portion دارند، اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید هدف را بر اساس شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
1. فریم متن [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را دریافت کنید.
1. دو شیء [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و آن‌ها را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید (به همراه پاراگراف پیش‌فرض، این منجر به داشتن سه پاراگراف می‌شود).
1. برای هر پاراگراف، سه شیء [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) ایجاد کنید و به مجموعه Portionهای آن پاراگراف اضافه کنید.
1. متن هر Portion را تنظیم کنید.
1. هر Portion متن را با استفاده از ویژگی‌های ارائه‌شده توسط [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) فرمت دلخواه خود اعمال کنید.
1. ارائه (Presentation) اصلاح‌شده را ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# نمونه‌سازی کلاس Presentation برای ایجاد یک فایل PPTX جدید.
with slides.Presentation() as presentation:

    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن یک AutoShape مستطیلی.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # دسترسی به TextFrame شکل AutoShape.
    text_frame = shape.text_frame

    # ایجاد پاراگراف‌ها و Portionها؛ قالب‌بندی در ادامه اعمال می‌شود.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # ذخیره‌سازی فایل PPTX بر روی دیسک.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **مدیریت بولت‌های پاراگراف**

فهرست‌های بولت به شما کمک می‌کنند تا اطلاعات را به‌سرعت و به‌طور مؤثر سازماندهی و ارائه کنید. پاراگراف‌های دارای بولت معمولاً خواندن و درک آسان‌تری دارند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. به اسلاید هدف بر اساس شاخص آن دسترسی پیدا کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
1. پاراگراف پیش‌فرض را از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) حذف کنید.
1. پاراگراف اول را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید.
1. نوع بولت پاراگراف را به `SYMBOL` تنظیم کرده و کاراکتر بولت را مشخص کنید.
1. متن پاراگراف را تنظیم کنید.
1. تو رفتگی (indent) بولت را برای پاراگراف تنظیم کنید.
1. رنگ بولت را تنظیم کنید.
1. اندازه (ارتفاع) بولت را تنظیم کنید.
1. پاراگراف را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.
1. پاراگراف دوم را اضافه کنید و مراحل 7 تا 12 را تکرار کنید.
1. ارائه را ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:

    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن و دسترسی به یک AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # دسترسی به فریم متن AutoShape ساخته شده.
    text_frame = shape.text_frame

    # حذف پاراگراف پیش‌فرض.
    text_frame.paragraphs.remove_at(0)

    # ایجاد یک پاراگراف.
    paragraph = slides.Paragraph()

    # تنظیم سبک بولت و نماد پاراگراف.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # تنظیم متن پاراگراف.
    paragraph.text = "Welcome to Aspose.Slides"

    # تنظیم تورفتگی بولت.
    paragraph.paragraph_format.indent = 25

    # تنظیم رنگ بولت.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # تنظیم ارتفاع بولت.
    paragraph.paragraph_format.bullet.height = 100

    # افزودن پاراگراف به فریم متن.
    text_frame.paragraphs.add(paragraph)

    # ایجاد پاراگراف دوم.
    paragraph2 = slides.Paragraph()

    # تنظیم نوع و سبک بولت پاراگراف.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN

    # تنظیم متن پاراگراف.
    paragraph2.text = "This is numbered bullet"

    # تنظیم تورفتگی بولت.
    paragraph2.paragraph_format.indent = 25

    # تنظیم رنگ بولت.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # تنظیم ارتفاع بولت.
    paragraph2.paragraph_format.bullet.height = 100

    # افزودن پاراگراف به فریم متن.
    text_frame.paragraphs.add(paragraph2)

    # ذخیره ارائه به عنوان فایل PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **مدیریت بولت‌های تصویری**

فهرست‌های بولت به شما کمک می‌کنند تا اطلاعات را به‌سرعت و به‌طور مؤثر سازماندهی و ارائه کنید. بولت‌های تصویری خواندن و درک آسان‌تری دارند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. به اسلاید هدف بر اساس شاخص آن دسترسی پیدا کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
1. پاراگراف پیش‌فرض را از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) حذف کنید.
1. یک پاراگراف با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و متن آن را تنظیم کنید.
1. یک تصویر را بارگذاری کرده و به مجموعه تصویرهای ارائه به‌عنوان [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) اضافه کنید.
1. نوع بولت را به `PICTURE` تنظیم کنید و [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) را به بولت اختصاص دهید.
1. ارتفاع بولت را تنظیم کنید.
1. پاراگراف جدید را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.
1. ارائه را ذخیره کنید.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # بارگذاری تصویر بولت.
    with slides.Images.from_file("bullets.png") as image:
        pp_image = presentation.images.add_image(image)

    # افزودن و دسترسی به یک AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # دسترسی به TextFrame AutoShape ساخته شده.
    text_frame = auto_shape.text_frame

    # حذف پاراگراف پیش‌فرض.
    text_frame.paragraphs.remove_at(0)

    # ایجاد یک پاراگراف جدید.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # تنظیم نوع بولت پاراگراف به Picture و اختصاص تصویر.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # تنظیم ارتفاع بولت.
    paragraph.paragraph_format.bullet.height = 100

    # افزودن پاراگراف به فریم متن.
    text_frame.paragraphs.add(paragraph)

    # ذخیره ارائه به عنوان فایل PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # ذخیره ارائه به عنوان فایل PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **مدیریت بولت‌های چندسطحی**

فهرست‌های بولت به شما کمک می‌کنند تا اطلاعات را به‌سرعت و به‌طور مؤثر سازماندهی و ارائه کنید. بولت‌های چندسطحی خواندن و درک آسان‌تری دارند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. به اسلاید هدف بر اساس شاخص آن دسترسی پیدا کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
1. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) مربوط به [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) دسترسی پیدا کنید.
1. پاراگراف پیش‌فرض را از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) حذف کنید.
1. پاراگراف اول را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و عمق (depth) آن را به 0 تنظیم کنید.
1. پاراگراف دوم را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و عمق آن را به 1 تنظیم کنید.
1. پاراگراف سوم را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و عمق آن را به 2 تنظیم کنید.
1. پاراگراف چهارم را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و عمق آن را به 3 تنظیم کنید.
1. پاراگراف‌های جدید را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.
1. ارائه را ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:

    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]
    
    # افزودن یک AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # دسترسی به TextFrame AutoShape ساخته شده.
    text_frame = shape.text_frame
    
    # پاک‌سازی پاراگراف پیش‌فرض.
    text_frame.paragraphs.clear()

    # افزودن پاراگراف اول.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تنظیم سطح بولت.
    paragraph1.paragraph_format.depth = 0

    # افزودن پاراگراف دوم.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تنظیم سطح بولت.
    paragraph2.paragraph_format.depth = 1

    # افزودن پاراگراف سوم.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تنظیم سطح بولت.
    paragraph3.paragraph_format.depth = 2

    # افزودن پاراگراف چهارم.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # تنظیم سطح بولت.
    paragraph4.paragraph_format.depth = 3

    # افزودن پاراگراف‌ها به مجموعه.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # ذخیره ارائه به عنوان فایل PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **مدیریت پاراگراف‌ها با فهرست‌های شماره‌گذاری سفارشی**

کلاس [BulletFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/) ویژگی `numbered_bullet_start_with` (و سایر ویژگی‌ها) را برای کنترل شماره‌گذاری و قالب‌بندی سفارشی پاراگراف‌ها ارائه می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. به اسلایدی که پاراگراف‌ها در آن قرار خواهند گرفت دسترسی پیدا کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
1. پاراگراف پیش‌فرض را از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) حذف کنید.
1. پاراگراف اول را با استفاده از [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و مقدار `numbered_bullet_start_with` را به 2 تنظیم کنید.
1. پاراگراف دوم را با استفاده از [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و مقدار `numbered_bullet_start_with` را به 3 تنظیم کنید.
1. پاراگراف سوم را با استفاده از [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و مقدار `numbered_bullet_start_with` را به 7 تنظیم کنید.
1. پاراگراف‌ها را به مجموعه [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.
1. ارائه را ذخیره کنید.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # افزودن و دسترسی به یک AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # دسترسی به TextFrame AutoShape ساخته شده.
    text_frame = shape.text_frame

    # حذف پاراگراف پیش‌فرض موجود.
    text_frame.paragraphs.remove_at(0)

    # ایجاد اولین آیتم شماره‌دار (شروع از 2، سطح عمق 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # ایجاد دومین آیتم شماره‌دار (شروع از 3، سطح عمق 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # ایجاد سومین آیتم شماره‌دار (شروع از 7، سطح عمق 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم تورفتگی خط اول برای یک پاراگراف**

از ویژگی [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این ویژگی فقط خط اول را نسبت به حاشیه چپ پاراگراف جابجا می‌کند. مقدار مثبت خط اول را به سمت راست حرکت می‌دهد، در حالی که بقیه خطوط در قالب بدنه پاراگراف باقی می‌مانند.

از [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) وقتی نیاز دارید کل پاراگراف را جابه‌جا کنید استفاده کنید. از [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) وقتی فقط خط اول را می‌خواهید جابه‌جا کنید استفاده کنید.

مثال زیر چندین پاراگراف ایجاد می‌کند و مقادیر مختلف `indent` را برای نمایش تأثیر تورفتگی خط اول بر چیدمان پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کنید و مقادیر مختلف [indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به فریم متن اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

## **تنظیم تورفتگی آویزان برای یک پاراگراف**

تورفتگی آویزان یک چیدمان پاراگراف است که در آن خط اول نسبت به بقیه خطوط به سمت چپ شروع می‌شود. در Aspose.Slides این اثر را با ویژگی [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) ایجاد می‌کنید. برای جابه‌جایی خط اول به سمت چپ نسبت به بدنه پاراگراف مقدار `indent` را منفی قرار دهید.

در عمل، [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) موقعیت سمت چپ بدنه پاراگراف را تعریف می‌کند و [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) موقعیت خط اول نسبت به آن حاشیه را تعیین می‌کند. برای ایجاد تورفتگی آویزان، مقدار مثبت `margin_left` و مقدار منفی `indent` تنظیم کنید.

این قالب‌بندی برای کتاب‌شناسی‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌ها که خطوط بسته‌بندی‌شده باید زیر بدنه پاراگراف تراز شوند مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. پاراگراف‌ها را ایجاد کنید و برای هر پاراگراف مقدار مثبت [margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) تنظیم کنید.
6. مقدار منفی [indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) را تنظیم کنید تا اثر تورفتگی آویزان ایجاد شود.
7. پاراگراف‌ها را به فریم متن اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

![تورفتگی آویزان پاراگراف‌ها](hanging_indent.png)

## **مدیریت قالب‌بندی Portion انتهای پاراگراف**

وقتی نیاز دارید سبک «پایان» یک پاراگراف (قالب‌بندی اعمال‌شده پس از آخرین Portion) را کنترل کنید، از ویژگی `end_paragraph_portion_format` استفاده کنید. مثال زیر فونت Times New Roman بزرگ‌تر را بر انتهای پاراگراف دوم اعمال می‌کند.

1. یک فایل [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد یا باز کنید.
2. اسلاید هدف را برحسب شاخص دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل استفاده کنید و دو پاراگراف ایجاد کنید.
5. یک [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) با فونت Times New Roman سایز 48 pt ایجاد کنید و آن را به عنوان قالب Portion انتهای پاراگراف تنظیم کنید.
6. آن را به ویژگی `end_paragraph_portion_format` پاراگراف اختصاص دهید (بر انتهای پاراگراف دوم اعمال می‌شود).
7. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	# پاراگراف پیش‌فرض را حذف کنید.
	shape.text_frame.paragraphs.clear()

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **وارد کردن متن HTML به پاراگراف‌ها**

Aspose.Slides پشتیبانی پیشرفته‌ای برای وارد کردن متن HTML به پاراگراف‌ها فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف بر حسب شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) مربوط به [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) حذف کنید.
6. فایل HTML منبع را بخوانید.
7. محتوای HTML را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

```python
import aspose.slides as slides

# یک نمونه Presentation خالی ایجاد کنید.
with slides.Presentation() as presentation:

    # به اولین اسلاید ارائه دسترسی پیدا کنید.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # افزودن یک AutoShape برای جایگذاری محتوای HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # پاک‌سازی تمام پاراگراف‌های فریم متن افزوده‌شده.
    shape.text_frame.paragraphs.clear()

    # بارگذاری فایل HTML.
    with open("file.html", "rt") as html_stream:
        # افزودن متن از فایل HTML به فریم متن.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # ذخیره ارائه.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **صادرات متن پاراگراف به HTML**

Aspose.Slides پشتیبانی پیشرفته‌ای برای خروجی‌گیری متن به HTML فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه هدف را بارگذاری کنید.
2. به اسلاید مورد نیاز بر اساس شاخص آن دسترسی پیدا کنید.
3. شکل حاوی متنی که می‌خواهید صادر کنید را انتخاب کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. یک جریان فایل باز کنید تا خروجی HTML را بنویسید.
6. شاخص شروع را مشخص کنید و پاراگراف‌های مورد نیاز را صادر کنید.

```python
import aspose.slides as slides

# فایل ارائه را بارگذاری کنید.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # به اولین اسلاید ارائه دسترسی پیدا کنید.
    slide = presentation.slides[0]

    # شاخص شکل هدف.
    index = 0

    # دسترسی به شکل بر اساس شاخص.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # داده‌های پاراگراف را به HTML بنویسید با ارائه شاخص شروع پاراگراف و تعداد کل پاراگراف‌های خروجی.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **ذخیره یک پاراگراف به عنوان تصویر**

در این بخش، دو مثال را بررسی می‌کنیم که نشان می‌دهند چگونه یک پاراگراف متنی، که توسط کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) نمایان می‌شود، به عنوان تصویر ذخیره می‌شود. هر دو مثال شامل دریافت تصویر یک شکل حاوی پاراگراف با استفاده از متدهای `get_image` از کلاس [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/)، محاسبه مرزهای پاراگراف درون شکل و خروجی گرفتن آن به‌صورت تصویر بیت‌مپ است. این روش‌ها به شما امکان می‌دهد بخش‌های خاصی از متن ارائه‌های PowerPoint را استخراج کرده و به‌صورت تصاویر جداگانه ذخیره کنید که در سناریوهای مختلف می‌تواند مفید باشد.

فرض کنید فایلی به نام sample.pptx دارای یک اسلاید است که اولین شکل آن یک جعبه متن با سه پاراگراف است.

![کادر متن با سه پاراگراف](paragraph_to_image_input.png)

**مثال 1**

در این مثال، پاراگراف دوم به‌صورت تصویر استخراج می‌شود. برای این کار، تصویر شکل را از اسلاید اول استخراج می‌کنیم و سپس مرزهای پاراگراف دوم در فریم متن شکل را محاسبه می‌کنیم. سپس پاراگراف را بر روی یک تصویر بیت‌مپ جدید رسم کرده و در قالب PNG ذخیره می‌کنیم. این روش زمانی مفید است که بخواهید یک پاراگراف خاص را به‌صورت تصویر جداگانه ذخیره کنید و ابعاد و قالب‌بندی دقیق متن حفظ شود.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # شکل را در حافظه به‌عنوان یک بیت‌مپ ذخیره کنید.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # یک بیت‌مپ شکل از حافظه ایجاد کنید.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # مرزهای پاراگراف دوم را محاسبه کنید.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # مختصات و اندازه تصویر خروجی را محاسبه کنید (حداقل اندازه - 1x1 پیکسل).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # بیت‌مپ شکل را برش دهید تا فقط بیت‌مپ پاراگراف به‌دست آید.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

![تصویر پاراگراف](paragraph_to_image_output.png)

**مثال 2**

در این مثال، رویکرد قبلی با افزودن عوامل مقیاس به تصویر پاراگراف گسترش می‌یابد. شکل از ارائه استخراج می‌شود و با عامل مقیاس `2` به‌صورت تصویر ذخیره می‌شود. این امکان خروجی با وضوح بالاتر را هنگام استخراج پاراگراف فراهم می‌کند. سپس مرزهای پاراگراف با در نظر گرفتن مقیاس محاسبه می‌شود. مقیاس‌بندی به‌ویژه وقتی نیاز به تصویر با جزئیات بیشتر باشد، مثلاً برای استفاده در مطالب چاپی با کیفیت بالا، مفید است.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # شکل را در حافظه به‌عنوان یک بیت‌مپ ذخیره کنید.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # یک بیت‌مپ شکل از حافظه ایجاد کنید.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # مرزهای پاراگراف دوم را محاسبه کنید.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # مختصات و اندازه تصویر خروجی را محاسبه کنید (حداقل اندازه - 1x1 پیکسل).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # بیت‌مپ شکل را برش دهید تا فقط بیت‌مپ پاراگراف به دست آید.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **سوالات متداول**

### آیا می‌توانم بسته‌بندی خطوط داخل یک فریم متن را به‌طور کامل غیرفعال کنم؟

بله. از تنظیم بسته‌بندی فریم متن ([wrap_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/wrap_text/)) استفاده کنید تا بسته‌بندی را غیرفعال کنید تا خطوط در لبه‌های فریم شکسته نشوند.

### چگونه می‌توانم مرزهای دقیق یک پاراگراف خاص را روی اسلاید به‌دست آورم؟

می‌توانید مستطیل محصور کننده پاراگراف (و حتی یک Portion) را بازیابی کنید تا موقعیت و اندازه دقیق آن را روی اسلاید بدانید.

### محوریت پاراگراف (چپ/راست/وسط/توزیع) در کجا کنترل می‌شود؟

[Alignment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/alignment/) یک تنظیم در سطح پاراگراف در [ParagraphFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/) است؛ این تنظیم برای کل پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی هر Portion.

### آیا می‌توانم برای تنها قسمتی از یک پاراگراف (مثلاً یک کلمه) زبان بررسی املایی تنظیم کنم؟

بله. زبان در سطح Portion تنظیم می‌شود ([PortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/language_id/))، بنابراین می‌توان چند زبان را در یک پاراگراف همزمان داشت.