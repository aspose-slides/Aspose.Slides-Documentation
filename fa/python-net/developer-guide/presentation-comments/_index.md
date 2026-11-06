---
title: مدیریت نظرات ارائه در پایتون
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/python-net/presentation-comments/
keywords:
- نظر
- نظر مدرن
- نظرات پاورپوینت
- نظرات ارائه
- نظرات اسلاید
- افزودن نظر
- دسترسی به نظر
- ویرایش نظر
- پاسخ به نظر
- حذف نظر
- حذف نظر
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت نظرات ارائه با Aspose.Slides برای پایتون عبر .NET: افزودن، خواندن، ویرایش، پاسخ به و حذف نظرات در ارائه‌های پاورپوینت."
---
## **نمای کلی**

این مقاله نحوه مدیریت نظرات ارائه در Aspose.Slides for Python via .NET را توضیح می‌دهد. این مقاله انواع اصلی مربوط به نظرات را معرفی می‌کند و نشان می‌دهد چگونه نظرات را به اسلایدها اضافه کنید، نظرات موجود را دسترسی داشته باشید، با پاسخ‌ها و نظرات مدرن کار کنید و نظرات را از یک ارائه حذف کنید.

مثال‌ها شامل سناریوهای رایج بازبینی و همکاری در PowerPoint هستند، مانند اختصاص نظرات به نویسندگان، خواندن متن نظرات و متاداده، ساخت زنجیره‌های پاسخ، و حذف نظرات انتخاب شده یا تمام نظرات.

در PowerPoint، نظرات به صورت حاشیه‌نویسی بر روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن آن و بحث مرتبط را نشان می‌دهد.

برای درخواست نمایش یا مخفی‌کردن نظرات هنگام باز کردن ارائه بدون تغییر نظرات خود، به [نمایش یا مخفی‌کردن نظرات هنگام باز کردن ارائه](/slides/fa/python-net/presentation-view-properties/) مراجعه کنید.

## **چرا نظرات به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بررسی ارائه‌ها استفاده کنید.

Aspose.Slides for Python via .NET APIهای زیر را برای کار با نظرات فراهم می‌کند:
* کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* کلاس [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) که نظرات مربوط به یک نویسنده خاص را نمایندگی می‌کند.
* کلاس [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) که اطلاعاتی درباره یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن را فراهم می‌کند.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) که اطلاعاتی درباره یک نویسنده شامل نام، حروف اولیه و نظرات مرتبط را فراهم می‌کند.

## **افزودن نظرات اسلاید**

مثال دو اسلاید ایجاد می‌کند و یک نویسنده‌ی نظر را با [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) ثبت می‌نماید. سپس با استفاده از [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) یک نظر روی هر اسلاید قرار می‌دهد، سپس نظرات اسلاید اول برای آن نویسنده را با [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) بازیابی می‌کند. کنسول متن اولین نظر را دو بار نمایش می‌دهد، که دسترسی از طریق هر دو اسلاید و نویسنده را نشان می‌دهد، و ارائه‌ی ذخیره‌شده شامل هر دو نظر است.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **یافتن یا ایجاد نویسنده‌ی نظر**

زمانی که یک بازبینی خودکار به‌صورت مکرر همان ارائه را پردازش می‌کند، قبل از افزودن نویسنده، مجموعه‌ی [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) آن را جستجو کنید. متد [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) هم نام و هم حروف اولیه را مطابقت می‌دهد و آرایه‌ای از نویسندگان مطابق را برمی‌گرداند، یا آرایه‌ای خالی اگر هیچ مطابقتی وجود نداشته باشد. در مقابل، متد [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) تنها براساس نام جستجو می‌کند، صرف‌نظر از حروف اولیه. فراخوانی [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) با نام و حروف اولیه‌ای که از قبل در مجموعه موجود هستند، موجب بروز استثنا می‌شود.

این مثال به یک فایل ارائه با حداقل یک اسلاید نیاز دارد. در هر یک از دو گذر، نویسنده‌ی اولین مطابقت را مجدداً استفاده می‌کند، یا تنها زمانی که نتیجه خالی باشد یک نویسنده جدید ایجاد می‌کند. اگر چندین مطابقت وجود داشته باشد، عنصر اول آرایه را انتخاب می‌کند بدون ادغام یا حذف دیگر نویسندگان. سپس برای نویسنده انتخاب شده [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) را فراخوانی می‌کند و ارائه را ذخیره می‌نماید. گذر دوم خروجی گذر اول را باز می‌کند و عملیات را تکرار می‌کند.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

گذر دوم یک نظر دیگر اضافه می‌کند بدون افزودن نویسنده جدید یا حذف نظرات موجود. فایل نهایی، `review_pass_2.pptx`، هر دو نظر جدید را همراه با هر نظر اصلی در بر دارد. استفاده مجدد از یک نویسنده، نظرات را تکراری نمی‌کند: برای جلوگیری از افزودن مکرر همان نظر، پیش از افزودن، تشخیص تکرار جداگانه‌ای پیاده‌سازی کنید.

## **دسترسی به نظرات اسلاید**

مثال یک ارائه موجود را باز می‌کند و مجموعه‌ی [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) آن را می‌خواند. برای هر نویسنده، از طریق [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) حلقه می‌زند و شماره اسلاید، متن نظر، نام نویسنده و زمان ایجاد را چاپ می‌کند. ارائه ورودی باید شامل نظرات باشد تا خروجی کنسول تولید شود.

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **پاسخ به نظرات**

یک نظر والد، نظر اصلی در بالای یک سلسله‌مراتبی پاسخ‌ها است. خاصیت [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) کلاس [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) به شما امکان می‌دهد والد یک نظر را دریافت یا تنظیم کنید.

مثال نظراتی از دو نویسنده ایجاد می‌کند و با استفاده از [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) پاسخ‌ها را می‌سازد، از جمله پاسخی به یک پاسخ دیگر. ارسال `None` به [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) نظرات تمام نویسندگان را بازیابی می‌کند؛ کنسول هر ورودی را بر اساس عمق آن در سلسله‌مراتبی پاسخ‌ها تو رفتگی می‌دهد. مثال بحث کامل را ذخیره می‌کند، برای اولین نظر ریشه‌ای [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) را فراخوانی می‌کند، و ارائه‌ی دوم را با حذف آن نظر و پاسخ‌هایش حفظ می‌کند.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* وقتی متد [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) کلاس [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر خاصیت [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) یک ارجاع چرخشی ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند با خود اسلاید، با یک شکل خاص، یا با یک بازه‌متن داخل AutoShape مرتبط شوند. متد [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) یک پارامتر [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) را علاوه بر مختصات اسلاید و نشانگر نظر می‌پذیرد.

وقتی برای پارامتر shape مقدار `None` ارسال شود، نظر یک نظر سطح اسلاید است. نشانگر آن بر اساس مختصات ارائه‌شده قرار می‌گیرد، اما به شکل خاصی مرتبط نیست، بنابراین [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) مقدار `None` برمی‌گرداند. هنگامی که یک [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) ارائه شود، نظر به آن شکل متصل می‌شود. مختصات همچنان موقعیت نشانگر نظر را بر روی اسلاید تعریف می‌کند، در حالی که ارتباط شکل از طریق [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) قابل بازیابی است.

### **اتصال یک نظر مدرن به یک شکل**

مثال دو بار [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) را فراخوانی می‌کند: یک بار با شکل `None` برای یک نظر سطح اسلاید و یک بار با یک مستطیل به‌عنوان نقطه‌ی اتصال. خواندن [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) مقدار `True` را برای بررسی تهی بودن نظر سطح اسلاید و `Revenue title` را برای نظر متصل شده چاپ می‌کند. هر دو نظر همراه با ارائه ذخیره می‌شوند.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **اتصال نظرات به انواع مختلف شکل‌ها**

هر شیء اسلایدی که از [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) مشتق شده باشد می‌تواند به‌عنوان نقطه‌ی اتصال شکل استفاده شود. مثال‌های رایج شامل [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/)، و نمونه‌های [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) مانند نمودارها هستند.

مثال از [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) برای ارتباط یک نظر با هر یک از پنج نوع شکل استفاده می‌کند: یک AutoShape، یک PictureFrame، یک GroupShape، یک Connector و یک Chart. تصویر از داده‌های تصویری جاسازی‌شده استفاده می‌کند، بنابراین نیازی به تصویر خارجی نیست. هر نظر موقعیت نشانگر خود را دارد و ارائه ذخیره‌شده تمام پنج ارتباط شکل را حفظ می‌کند.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **اتصال نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن که به یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) مرتبط است، [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) موقعیت شروع متن انتخاب‌شده در فریم متنی شکل را مشخص می‌کند، در حالی که [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) طول انتخاب را تعیین می‌کند. این دو خاصیت با هم نظر را به یک بازه متنی خاص داخل AutoShape پیوند می‌دهند.

خاصیت [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) می‌تواند با مقدار از شمارش‌گر [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) خوانده یا به‌روزرسانی شود:
- `NOT_DEFINED` — وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `ACTIVE` — نظر فعال است.
- `RESOLVED` — نظر حل شده است.
- `CLOSED` — نظر بسته شده است.

مثال یک نظر مدرن را به کلمات «quarterly revenue» در متن یک مستطیل متصل می‌کند. مقدار zero-based [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) را از متن محاسبه می‌کند و [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) را به تعداد کاراکترهای انتخاب‌شده تنظیم می‌نماید. پس از تنظیم [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) به `RESOLVED`، ارائه را ذخیره و مجدداً باز می‌کند. چهار بررسی کنسول باید هر کدام `True` چاپ کنند، که تأیید می‌کند اتکا به شکل، بازه متن و وضعیت حفظ شده‌اند.

```python
from datetime import datetime

import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = slides.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **بازرسی نظرات مدرن موجود**

مثال به یک ارائه موجود شامل نظرات مدرن نیاز دارد و متن، وضعیت و جزئیات اتصال آن‌ها را چاپ می‌کند. برای بازرسی، بررسی کنید که کدام نظرات نمونه‌ای از [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) هستند، سپس [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/)، [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/)، [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) و [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) را بررسی کنید. یک شکل `None` نشان‌دهنده یک نظر سطح اسلاید است. برای یک نقطه‌ی اتصال [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)، ویژگی‌های انتخاب متن بازه مرتبط در فریم متنی شکل را مشخص می‌کنند.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **حذف نظرات**

Aspose.Slides for Python via .NET به شما اجازه می‌دهد تمام نظرات و نویسندگان آن‌ها را از یک ارائه حذف کنید یا نظرات انتخابی را حذف کنید در حالی که بقیه نگه داشته می‌شوند. مثال‌های زیر هر دو روش را نشان می‌دهند و ارائه به‌روز‌شده را ذخیره می‌کنند.

### **حذف تمام نظرات و نویسندگان نظرات**

مثال یک ارائه موجود را باز می‌کند و برای هر نویسنده [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) را فراخوانی می‌کند، سپس [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) را برای حذف خود نویسندگان فراخوانی می‌کند. ارائه ذخیره‌شده نه نظراتی دارد و نه نویسندگان نظرات. برای مشاهده حذف، از یک ارائه شامل نظرات استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **حذف نظرات خاص**

مثال دو نظر بر روی یک اسلاید ایجاد می‌کند و با استفاده از [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) نظرات هر نویسنده را پیدا می‌کند. قبل از فراخوانی [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/) نظراتی که متن آن‌ها برابر با «comment 1» است جمع‌آوری می‌کند تا از تغییر مجموعه حین انتخاب جلوگیری شود. ارائه ذخیره‌شده تنها «comment 2» را نگه می‌دارد.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**آیا Aspose.Slides وضعیت حل شده برای نظرات مدرن را پشتیبانی می‌کند؟**  
بله. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) می‌تواند با مقدار از [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/)، از جمله `RESOLVED`، خوانده و تنظیم شود. این وضعیت در ارائه ذخیره می‌شود و پس از بازگشایی مجدد فایل می‌توان آن را دوباره خواند.

**آیا بحث‌های رشته‌ای (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای عمق تو در توی آن‌ها وجود دارد؟**  
بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) خود ارجاع دهد، که زنجیره‌های پاسخ را امکان‌پذیر می‌سازد. API محدودیت خاصی برای عمق تو در تو تعریف نکرده است.

**موقعیت نشانگر نظر بر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**  
موقعیت نشانگر توسط مختصات عددی شناور در سیستم مختصات اسلاید تعریف می‌شود، به‌طوری که بتوانید آن را دقیقاً بر روی اسلاید قرار دهید.