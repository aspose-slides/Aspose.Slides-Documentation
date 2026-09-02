---
title: مدیریت نظرات ارائه در پایتون
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/python-net/presentation-comments/
keywords:
- نظر
- نظر مدرن
- نظرات PowerPoint
- نظرات ارائه
- نظرات اسلاید
- افزودن نظر
- دسترسی به نظر
- ویرایش نظر
- پاسخ به نظر
- حذف نظر
- پاک کردن نظر
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت نظرات ارائه با Aspose.Slides برای پایتون از طریق .NET: افزودن، خواندن، ویرایش، پاسخ به و حذف نظرات در ارائه‌های PowerPoint."
---
## **نمای کلی**

این مقاله نحوه مدیریت نظرات ارائه را با Aspose.Slides برای Python از طریق .NET توضیح می‌دهد. انواع اصلی مرتبط با نظر را معرفی کرده و نشان می‌دهد چگونه نظرات را به اسلایدها اضافه کنید، به نظرات موجود دسترسی داشته باشید، با پاسخ‌ها و نظرات مدرن کار کنید و نظرات را از یک ارائه حذف کنید.

مثال‌ها سناریوهای رایج بررسی و همکاری در PowerPoint را شامل می‌شوند، مانند اختصاص نظرات به نویسندگان، خواندن متن نظر و داده‌های متای آن، ساخت زنجیره‌های پاسخ و حذف نظرات انتخابی یا تمام نظرات.

در PowerPoint، نظرات به‌صورت حاشیه‌نویسی بر روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن و بحث مرتبط با آن را نمایش می‌دهد.

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بررسی ارائه‌ها استفاده کنید.

Aspose.Slides برای Python از طریق .NET APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* کلاس [CommentCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/commentcollection/) که نظرات مربوط به یک نویسنده خاص را نشان می‌دهد.
* کلاس [Comment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/comment/) که اطلاعاتی درباره یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن را فراهم می‌کند.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/python-net/aspose.slides/commentauthor/) که اطلاعاتی درباره یک نویسنده شامل نام، حروف اولیه و نظرات مرتبط را ارائه می‌دهد.

## **افزودن نظرات اسلاید**

مثال زیر نشان می‌دهد چگونه نظرات را به اسلایدهای یک ارائه PowerPoint اضافه کنید:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
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

## **دسترسی به نظرات اسلاید**

مثال زیر نشان می‌دهد چگونه به نظرات موجود در یک ارائه PowerPoint دسترسی پیدا کنید:

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

یک نظر والد همان نظر اصلی در بالای سلسله‌مراتبی پاسخ‌ها است. ویژگی [parent_comment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/comment/parent_comment/) کلاس [Comment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/comment/) به شما امکان می‌دهد والد یک نظر را دریافت یا تنظیم کنید.

مثال زیر نشان می‌دهد چگونه پاسخ‌ها را اضافه کنید و ساختار سلسله‌مراتبی نتایج را بررسی کنید:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="هشدار" %}}
* هنگامی که متد [remove](https://reference.aspose.com/slides/fa/python-net/aspose.slides/comment/remove/) کلاس [Comment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/comment/) برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر ویژگی [parent_comment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/comment/parent_comment/) یک ارجاع چرخشی ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص یا به یک بازه متنی داخل AutoShape مرتبط شوند. متد [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/commentcollection/add_modern_comment/) علاوه بر اسلاید و مختصات نشانگر نظر، یک آرگومان [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) را نیز می‌پذیرد.

وقتی برای آرگومان shape مقدار `None` منتقل شود، نظر یک نظر سطح اسلاید است. نشانگر آن با مختصات ارائه‌شده موقعیت‌یابی می‌شود، اما به شکل خاصی مرتبط نیست، بنابراین [ModernComment.shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/shape/) مقدار `None` برمی‌گرداند. وقتی یک [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) ارائه شود، نظر به آن شکل متصل می‌شود. مختصات همچنان موقعیت نشانگر نظر را بر روی اسلاید تعیین می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [ModernComment.shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/shape/) بازیابی شود.

### **پیوست یک نظر مدرن به یک شکل**

مثال زیر هم یک نظر مدرن سطح اسلاید و هم یک نظر مدرن متصل به AutoShape خاصی می‌سازد. سپس شکل مرتبط با هر نظر را می‌خواند.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **پیوست نظرات به انواع مختلف شکل**

هر شیء اسلایدی که از [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) مشتق شده باشد می‌تواند به‌عنوان نقطهٔ اتصال شکل استفاده شود. مثال‌های رایج شامل [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/fa/python-net/aspose.slides/connector/) و نمونه‌های [GraphicalObject](https://reference.aspose.com/slides/fa/python-net/aspose.slides/graphicalobject/) مانند نمودارها هستند.

مثال زیر چند نوع شکل رایج را می‌سازد و یک نظر مدرن را به هر یک متصل می‌کند.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **پیوست یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن که به یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) متصل است، ویژگی [ModernComment.text_selection_start](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/text_selection_start/) موقعیت شروع متن انتخاب‌شده در فریم متنی شکل را مشخص می‌کند، در حالی که [ModernComment.text_selection_length](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/text_selection_length/) طول انتخاب را تعیین می‌کند. این دو ویژگی با هم نظر را به بازهٔ متنی خاصی داخل AutoShape مرتبط می‌سازند.

ویژگی [ModernComment.status](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/status/) می‌تواند با مقدار از شمارش‌گر [ModernCommentStatus](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncommentstatus/) خوانده یا به‌روزرسانی شود:

- `NOT_DEFINED` — هیچ وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `ACTIVE` — نظر فعال است.
- `RESOLVED` — نظر حل‌شده است.
- `CLOSED` — نظر بسته است.

مثال زیر یک نظر مدرن متصل به شکل می‌سازد، آن را به انتخاب متنی پیوند می‌دهد، به‌عنوان حل‌شده علامت‌گذاری می‌کند، ارائه را ذخیره می‌کند و پس از باز کردن مجدد فایل مقادیر را تأیید می‌کند.

```python
from datetime import datetime

import aspose.pydrawing as draw
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
    comment_position = draw.PointF(60, 60)
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

### **بررسی نظرات مدرن موجود**

برای بررسی یک ارائه موجود، ابتدا نظراتی که از نوع [ModernComment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/) هستند شناسایی کنید، سپس به [ModernComment.shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/shape/)، [ModernComment.text_selection_start](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/text_selection_start/)، [ModernComment.text_selection_length](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/text_selection_length/) و [ModernComment.status](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/status/) نگاه کنید. یک شکل `None` نشان‌دهندهٔ نظر سطح اسلاید است. برای یک نقطهٔ اتصال [AutoShape]، ویژگی‌های انتخاب متن بازهٔ مرتبط در فریم متنی شکل را شناسایی می‌کند.

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

### **حذف تمام نظرات و نویسندگان نظرات**

مثال زیر نشان می‌دهد چگونه تمام نظرات و نویسندگان نظرات را از یک ارائه حذف کنید:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **حذف نظرات خاص**

مثال زیر نشان می‌دهد چگونه نظرات خاصی را از یک اسلاید حذف کنید:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
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

## **سوالات متداول**

**آیا Aspose.Slides از وضعیت حل‌شده برای نظرات مدرن پشتیبانی می‌کند؟**

بله. ویژگی [ModernComment.status](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncomment/status/) می‌تواند با مقدار از شمارش‌گر [ModernCommentStatus](https://reference.aspose.com/slides/fa/python-net/aspose.slides/moderncommentstatus/) خوانده و تنظیم شود، از جمله `RESOLVED`. این وضعیت در ارائه ذخیره می‌شود و پس از باز کردن مجدد فایل قابل خواندن است.

**آیا بحث‌های زنجیره‌ای (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای عمق تو در توی آنها وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/comment/parent_comment/) خود ارجاع دهد و این امکان تشکیل زنجیره‌های پاسخ را می‌دهد. API محدودیت عمق تو در تو خاصی تعریف نمی‌کند.

**موقعیت نشانگر نظر بر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت نشانگر با مختصات نقطه شناور در سیستم مختصات اسلاید تعریف می‌شود، که به شما امکان می‌دهد آن را دقیقاً بر روی اسلاید قرار دهید.