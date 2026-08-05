---
title: "مدیریت پاراگراف‌های متن PowerPoint در Python"
linktitle: "مدیریت پاراگراف"
type: docs
weight: 40
url: /fa/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
  - "افزودن متن"
  - "افزودن پاراگراف"
  - "مدیریت متن"
  - "مدیریت پاراگراف"
  - "مدیریت بولت"
  - "تورفتگی پاراگراف"
  - "تورفتگی معلق"
  - "بولت پاراگراف"
  - "فهرست شماره‌دار"
  - "فهرست بولت‌دار"
  - "ویژگی‌های پاراگراف"
  - "وارد کردن HTML"
  - "متن به HTML"
  - "پاراگراف به HTML"
  - "پاراگراف به تصویر"
  - "متن به تصویر"
  - "صادرات پاراگراف"
  - "پاورپوینت"
  - "ارائه"
  - "Python"
  - "Aspose.Slides"
description: "قالب‌بندی پیشرفته پاراگراف‌ها را با Aspose.Slides برای Python از طریق .NET تسلط پیدا کنید—هم‌راستایی، فواصل و سبک را در ارائه‌های PowerPoint و OpenDocument بهینه کنید تا مخاطبان را جذب کنید."
---
## **مقدمه**

Aspose.Slides کلاس‌های مورد نیاز برای کار با متن‌های PowerPoint در Python را فراهم می‌کند.

* Aspose.Slides کلاس [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) را برای ایجاد اشیای فریم متن فراهم می‌کند. یک شیء `TextFrame` می‌تواند یک یا چند پاراگراف (هر پاراگراف با یک برگشت carriage جدا می‌شود) را در خود داشته باشد.
* Aspose.Slides کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) را برای ایجاد اشیای پاراگراف فراهم می‌کند. یک شیء `Paragraph` می‌تواند یک یا چند Portion متن داشته باشد.
* Aspose.Slides کلاس [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) را برای ایجاد اشیای Portion متن و تعیین ویژگی‌های قالب‌بندی آن‌ها فراهم می‌کند.

یک شیء `Paragraph` می‌تواند متن را با ویژگی‌های قالب‌بندی مختلف از طریق اشیای `Portion` زیرین خود مدیریت کند.

## **افزودن چند پاراگراف شامل چند Portion**

این مراحل نشان می‌دهند چگونه یک فریم متن که شامل سه پاراگراف است، هر کدام با سه Portion، اضافه کنیم:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از ایندکس آن، به اسلاید هدف ارجاع بگیرید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. ‏[TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را دریافت کنید.
5. دو شیء [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و آن‌ها را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید (به همراه پاراگراف پیش‌فرض، این مجموعاً سه پاراگراف می‌شود).
6. برای هر پاراگراف، سه شیء [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) ایجاد کنید و به مجموعه Portionهای آن پاراگراف اضافه کنید.
7. متن هر Portion را تنظیم کنید.
8. هر Portion متن را با استفاده از ویژگی‌های ارائه‌شده توسط [Portion](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portion/) قالب‌بندی مورد نظر خود اعمال کنید.
9. ارائه اصلاح‌شده را ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# نمونه‌سازی از کلاس Presentation برای ایجاد یک فایل PPTX جدید.
with slides.Presentation() as presentation:

    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن AutoShape مستطیلی.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # دسترسی به TextFrame شکل.
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
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # ذخیره کردن PPTX در دیسک.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **مدیریت بولت‌های پاراگراف**

فهرست‌های بولت به شما کمک می‌کنند تا اطلاعات را به‌سرعت و به‌صورت کارآمد سازماندهی و ارائه کنید. پاراگراف‌های دارای بولت معمولاً خواندن و درک آنها آسان‌تر است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را بر اساس ایندکس آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame] شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) حذف کنید.
6. پاراگراف اول را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید.
7. نوع بولت پاراگراف را به `SYMBOL` تنظیم کنید و کاراکتر بولت را مشخص کنید.
8. متن پاراگراف را تنظیم کنید.
9. تورفتگی بولت برای پاراگراف را تنظیم کنید.
10. رنگ بولت را تنظیم کنید.
11. اندازه (ارتفاع) بولت را تنظیم کنید.
12. پاراگراف را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.
Add a second paragraph and repeat steps 7–12.
Save the presentation.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از ارائه ایجاد کنید.
with slides.Presentation() as presentation:

    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن و دسترسی به AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # دسترسی به فریم متن AutoShape ایجاد شده.
    text_frame = shape.text_frame

    # حذف پاراگراف پیش‌فرض.
    text_frame.paragraphs.remove_at(0)

    # ایجاد یک پاراگراف.
    paragraph = slides.Paragraph()

    # تنظیم سبک و نماد بولت پاراگراف.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # تنظیم متن پاراگراف.
    paragraph.text = "Welcome to Aspose.Slides"

    # تنظیم تورفتگی بولت.
    paragraph.paragraph_format.indent = 25

    # تنظیم رنگ بولت.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # تنظیم ارتفاع بولت.
    paragraph.paragraph_format.bullet.height = 100

    # افزودن پاراگراف به فریم متن.
    text_frame.paragraphs.add(paragraph)

    # ایجاد پاراگراف دوم.
    paragraph2 = slides.Paragraph()

    # تنظیم نوع و سبک بولت پاراگراف.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # تنظیم متن پاراگراف.
    paragraph2.text = "This is numbered bullet"

    # تنظیم تورفتگی بولت.
    paragraph2.paragraph_format.indent = 25

    # تنظیم رنگ بولت.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # تنظیم ارتفاع بولت.
    paragraph2.paragraph_format.bullet.height = 100

    # افزودن پاراگراف به فریم متن.
    text_frame.paragraphs.add(paragraph2)

    # ذخیره ارائه به عنوان فایل PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **مدیریت بولت‌های تصویری**

فهرست‌های بولت به شما کمک می‌کنند تا اطلاعات را به سرعت و به صورت کارآمد سازماندهی و ارائه کنید. بولت‌های تصویری خواندن و درک آسانی دارند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را بر اساس ایندکس آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame] شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) حذف کنید.
6. پاراگراف اول را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید.
7. یک تصویر را به یک [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) بارگذاری کنید.
8. نوع بولت را به [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) تنظیم کنید و تصویر را اختصاص دهید.
9. متن پاراگراف را تنظیم کنید.
10. تورفتگی بولت برای پاراگراف را تنظیم کنید.
11. رنگ بولت را تنظیم کنید.
12. ارتفاع بولت را تنظیم کنید.
13. پاراگراف جدید را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.
Add a second paragraph and repeat steps 8–12.
Save the presentation.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # بارگذاری تصویر بولت.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # افزودن و دسترسی به AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # دسترسی به TextFrame AutoShape ایجاد شده.
    text_frame = auto_shape.text_frame

    # حذف پاراگراف پیش‌فرض.
    text_frame.paragraphs.remove_at(0)

    # ایجاد یک پاراگراف جدید.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # تنظیم نوع بولت پاراگراف به تصویر و اختصاص تصویر.
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

فهرست‌های بولت به شما کمک می‌کنند تا اطلاعات را به سرعت و به صورت کارآمد سازماندهی و ارائه کنید. بولت‌های چندسطحی خواندن و درک آسانی دارند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را بر اساس ایندکس آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame] شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) حذف کنید.
6. پاراگراف اول را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و عمق آن را 0 تنظیم کنید.
7. پاراگراف دوم را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و عمق آن را 1 تنظیم کنید.
8. پاراگراف سوم را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و عمق آن را 2 تنظیم کنید.
9. پاراگراف چهارم را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید و عمق آن را 3 تنظیم کنید.
10. پاراگراف‌های جدید را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.
11. ارائه را ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از ارائه ایجاد کنید.
with slides.Presentation() as presentation:

    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]
    
    # افزودن یک AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # دسترسی به TextFrame AutoShape ایجاد شده.
    text_frame = auto_shape.text_frame
    
    # پاک کردن پاراگراف پیش‌فرض.
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

کلاس [BulletFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/bulletformat/) ویژگی `numbered_bullet_start_with` (و دیگر ویژگی‌ها) را برای کنترل شماره‌گذاری و قالب‌بندی سفارشی پاراگراف‌ها فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدی که قرار است پاراگراف‌ها را در‌برگیرد دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame] شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) حذف کنید.
6. اولین [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) را ایجاد کنید و `numbered_bullet_start_with` را به 2 تنظیم کنید.
7. دومین [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) را ایجاد کنید و `numbered_bullet_start_with` را به 3 تنظیم کنید.
8. سومین [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) را ایجاد کنید و `numbered_bullet_start_with` را به 7 تنظیم کنید.
9. پاراگراف‌ها را به مجموعه [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.
10. ارائه را ذخیره کنید.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # افزودن و دسترسی به AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # دسترسی به TextFrame AutoShape ایجاد شده.
    text_frame = shape.text_frame

    # حذف پاراگراف پیش‌فرض موجود.
    text_frame.paragraphs.remove_at(0)

    # ایجاد اولین مورد شماره‌دار (شروع از 2، سطح عمق 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # ایجاد دومین مورد شماره‌دار (شروع از 3، سطح عمق 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # ایجاد سومین مورد شماره‌دار (شروع از 7، سطح عمق 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم تورفتگی خط اول برای یک پاراگراف**

از ویژگی [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این ویژگی فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت، خط اول را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده به بدنه پاراگراف تراز می‌مانند.

زمانی که نیاز به جابه‌جایی کل پاراگراف دارید، از [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) استفاده کنید. وقتی فقط نیاز به جابه‌جایی خط اول دارید، از [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) بهره ببرید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر مختلف `indent` را برای نشان دادن نحوه تأثیر تورفتگی خط اول بر چیدمان پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف ایجاد کنید و مقادیر مختلف [indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) را برای آن‌ها تعیین کنید.
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

نتیجه:

![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

## **تنظیم تورفتگی معلق برای یک پاراگراف**

تورفتگی معلق یک چیدمان پاراگراف است که در آن خط اول نسبت به خطوط باقی‌مانده به سمت چپ شروع می‌شود. در Aspose.Slides این اثر را با ویژگی [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) ایجاد می‌کنید. برای جابه‌جایی خط اول به سمت چپ نسبت به بدنه پاراگراف، مقدار `indent` را منفی کنید.

در عمل، [ParagraphFormat.margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [ParagraphFormat.indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) موقعیت خط اول را نسبت به آن حاشیه مشخص می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت `margin_left` و مقدار منفی `indent` تنظیم کنید.

این قالب‌بندی برای فهرست‌های مرجع، کتاب‌شناسی، واژگان و سایر پاراگراف‌هایی که خطوط بسته‌بندی شده باید زیر بدنه پاراگراف نه زیر اولین کاراکتر خط اول تراز شوند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. پاراگراف‌ها را ایجاد کنید و برای هر پاراگراف مقدار مثبت [margin_left](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/margin_left/) تعیین کنید.
6. مقدار منفی [indent](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/indent/) تنظیم کنید تا اثر تورفتگی معلق ایجاد شود.
7. پاراگراف‌ها را به فریم متن اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

```py
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

نتیجه:

![تورفتگی معلق پاراگراف‌ها](hanging_indent.png)

## **مدیریت قالب‌بندی Portion انتهای پاراگراف**

زمانی که نیاز به کنترل استایل «پایان» یک پاراگراف (قالب‌بندی اعمال‌شده پس از آخرین Portion متن) دارید، از ویژگی `end_paragraph_portion_format` استفاده کنید. مثال زیر فونت Times New Roman بزرگ‌تری را به انتهای پاراگراف دوم اعمال می‌کند.

1. یک فایل [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد یا باز کنید.
2. اسلاید هدف را بر اساس ایندکس به‌دست آورید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. از [TextFrame] شکل استفاده کنید و دو پاراگراف ایجاد کنید.
5. یک [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) با فونت Times New Roman 48pt تنظیم کنید و به عنوان قالب انتهای پاراگراف برای پاراگراف دوم اعمال کنید.
6. آن را به ویژگی `end_paragraph_portion_format` پاراگراف اختصاص دهید (برای انتهای پاراگراف دوم اعمال می‌شود).
7. ارائه اصلاح‌شده را به قالب PPTX ذخیره کنید.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

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
2. اسلاید هدف را بر اساس ایندکس دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame] شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) حذف کنید.
6. فایل HTML منبع را بخوانید.
7. اولین پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) ایجاد کنید.
8. محتوای HTML را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) اضافه کنید.
9. ارائه اصلاح‌شده را ذخیره کنید.

```python
import aspose.slides as slides

# یک نمونه خالی از Presentation ایجاد کنید.
with slides.Presentation() as presentation:

    # دسترسی به اولین اسلاید ارائه.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # افزودن AutoShape برای قرار دادن محتوای HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # پاک کردن تمام پاراگراف‌ها در فریم متن اضافه‌شده.
    shape.text_frame.paragraphs.clear()

    # بارگذاری فایل HTML.
    with open("file.html", "rt") as html_stream:
        # افزودن متن از فایل HTML به فریم متن.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # ذخیره ارائه.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **خروجی متن پاراگراف به HTML**

Aspose.Slides پشتیبانی پیشرفته‌ای برای خروجی متن به HTML فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه هدف را بارگذاری کنید.
2. اسلاید موردنظر را بر اساس ایندکس دسترسی پیدا کنید.
3. شکلی که حاوی متن موردنظر برای خروجی است را انتخاب کنید.
4. به [TextFrame] شکل دسترسی پیدا کنید.
5. یک جریان فایل برای نوشتن خروجی HTML باز کنید.
6. ایندکس شروع را مشخص کنید و پاراگراف‌های موردنیاز را صادر کنید.

```python
import aspose.slides as slides

# فایل ارائه را بارگذاری کنید.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # دسترسی به اولین اسلاید ارائه.
    slide = presentation.slides[0]

    # ایندکس شکل هدف.
    index = 0

    # دسترسی به شکل بر اساس ایندکس.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # نوشتن داده‌های پاراگراف به HTML با ارائه ایندکس شروع پاراگراف و تعداد کل پاراگراف‌های مورد خروجی.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **ذخیره یک پاراگراف به‌عنوان تصویر**

در این بخش دو مثال بررسی می‌شود که نشان می‌دهد چگونه یک پاراگراف متن، که توسط کلاس [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraph/) نمایندگی می‌شود، به عنوان تصویر ذخیره می‌شود. هر دو مثال شامل دریافت تصویر یک شکل حاوی پاراگراف با استفاده از متدهای `get_image` کلاس [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/)، محاسبه مرزهای پاراگراف درون شکل و خروجی آن به صورت تصویر bitmap می‌باشند. این روش‌ها به شما اجازه می‌دهد بخش‌های خاصی از متن را از ارائه‌های PowerPoint استخراج کرده و به‌عنوان تصویرهای جداگانه ذخیره کنید که می‌تواند در سناریوهای مختلف مفید باشد.

فرض کنیم یک فایل ارائه به نام sample.pptx با یک اسلاید داریم که اولین شکل آن یک جعبه متن حاوی سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

**مثال 1**

در این مثال، پاراگراف دوم را به‌عنوان تصویر استخراج می‌کنیم. برای این کار، تصویر شکل را از اسلاید اول استخراج می‌کنیم و سپس مرزهای پاراگراف دوم را در فریم متن شکل محاسبه می‌کنیم. سپس پاراگراف را روی یک تصویر bitmap جدید رسم می‌کنیم و به فرمت PNG ذخیره می‌کنیم. این روش به‌ویژه زمانی مفید است که بخواهید یک پاراگراف خاص را به‌صورت تصویر جداگانه ذخیره کنید در حالی که ابعاد و قالب‌بندی دقیق متن حفظ شود.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # شکل را در حافظه به‌صورت bitmap ذخیره کنید.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # یک bitmap از شکل را از حافظه ایجاد کنید.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # حدود پاراگراف دوم را محاسبه کنید.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # مختصات و اندازه تصویر خروجی را محاسبه کنید (حداقل اندازه - 1×1 پیکسل).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # bitmap شکل را برش دهید تا فقط bitmap پاراگراف به‌دست آید.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

نتیجه:

![تصویر پاراگراف](paragraph_to_image_output.png)

**مثال 2**

در این مثال، رویکرد قبلی را با افزودن عوامل مقیاس به تصویر پاراگراف گسترش می‌دهیم. شکل از ارائه استخراج می‌شود و با عامل مقیاس `2` ذخیره می‌شود. این امکان باعث می‌شود خروجی با وضوح بالاتری تولید شود. سپس مرزهای پاراگراف با در نظر گرفتن مقیاس محاسبه می‌شوند. مقیاس‌بندی می‌تواند زمانی مفید باشد که به تصویر دقیق‌تری نیاز دارید، برای مثال برای استفاده در مطالب چاپی با کیفیت بالا.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # شکل را در حافظه به‌صورت bitmap ذخیره کنید.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # یک bitmap از شکل را از حافظه ایجاد کنید.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # حدود پاراگراف دوم را محاسبه کنید.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # مختصات و اندازه تصویر خروجی را محاسبه کنید (حداقل اندازه - 1×1 پیکسل).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # bitmap شکل را برش دهید تا فقط bitmap پاراگراف به‌دست آید.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **سوالات متداول**

**آیا می‌توانم به‌طور کامل پیچ‌شدن خطوط داخل یک TextFrame را غیرفعال کنم؟**

بله. از تنظیمات پیچش متن فریم (`[wrap_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/wrap_text/)`) استفاده کنید تا پیچش را غیرفعال کنید و خطوط در لبه‌های فریم شکسته نشوند.

**چگونه می‌توانم محدوده دقیق یک پاراگراف خاص روی اسلاید را به‌دست آورم؟**

می‌توانید مستطیل مرزبندی پاراگراف (و حتی یک Portion منفرد) را بازیابی کنید تا موقعیت و اندازه دقیق آن را روی اسلاید بدانید.

**محل کنترل ترازبندی پاراگراف (چپ/راست/وسط/فقره) کجاست؟**

`[Alignment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/alignment/)` یک تنظیم سطح پاراگراف در `[ParagraphFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/paragraphformat/)` است؛ این تنظیم بر تمام پاراگراف اعمال می‌شود بدون درنظر گرفتن قالب‌بندی هر Portion به‌صورت جداگانه.

**آیا می‌توانم زبان اصلاح املا را فقط برای بخشی از یک پاراگراف (مثلاً یک کلمه) تنظیم کنم؟**

بله. زبان در سطح Portion تنظیم می‌شود (`[PortionFormat.language_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/language_id/)`)، بنابراین می‌توان چندین زبان را در یک پاراگراف هم‌زمان داشته باشید.