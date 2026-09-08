---
title: مدیریت نظرات ارائه در پایتون از طریق جاوا
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/python-java/presentation-comments/
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
- جاوا
- Aspose.Slides
description: "نظرات ارائه را با Aspose.Slides برای پایتون از طریق جاوا مدیریت کنید: اضافه کردن، خواندن، ویرایش، پاسخ به و حذف نظرات در ارائه‌های پاورپوینت به‌سرعت و به‌راحتی."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه نظرات ارائه را با Aspose.Slides برای Python از طریق Java مدیریت کنیم. این مقاله انواع اصلی مرتبط با نظرات را معرفی می‌کند و نشان می‌دهد چگونه نظرات را به اسلایدها اضافه کنیم، نظرات موجود را دسترسی داشته باشیم، با پاسخ‌ها و نظرات مدرن کار کنیم و نظرات را از یک ارائه حذف کنیم.

مثال‌ها سناریوهای رایج بررسی و همکاری در PowerPoint را پوشش می‌دهند، همچون اختصاص نظرات به نویسندگان، خواندن متن نظر و داده‌های متا، ساخت زنجیره پاسخ‌ها و حذف نظرات انتخاب شده یا تمام نظرات.

در PowerPoint، نظرات به عنوان حاشیه‌نویسی روی اسلایدها نمایش داده می‌شوند. انتخاب یک نظر متن آن و بحث مرتبط را نشان می‌دهد.

## **چرا نظرات به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بررسی ارائه‌ها استفاده کنید.

Aspose.Slides برای Python از طریق Java APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* کلاس [CommentCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commentcollection/) که نظرات مرتبط با یک نویسنده را نمایش می‌دهد.
* کلاس [Comment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/comment/) که اطلاعاتی درباره یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن را ارائه می‌دهد.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commentauthor/) که اطلاعاتی درباره یک نویسنده شامل نام، حروف اختصاری و نظرات مرتبط را فراهم می‌کند.

## **افزودن نظرات به اسلاید**

مثال زیر نشان می‌دهد چگونه نظرات را به اسلایدهای یک ارائه PowerPoint اضافه کنیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))
    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دسترسی به نظرات اسلاید**

مثال زیر نشان می‌دهد چگونه به نظرات موجود در یک ارائه PowerPoint دسترسی پیدا کنیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **پاسخ به نظرات**

یک نظر والد، نظر اصلی در بالای سلسله‌مراتبی پاسخ‌ها است. متدهای [Comment.getParentComment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/comment/#getParentComment) و [Comment.setParentComment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/comment/#setParentComment) به شما اجازه می‌دهند والد یک نظر را دریافت یا تنظیم کنید.

مثال زیر نشان می‌دهد چگونه پاسخ‌ها را اضافه کرده و سلسله‌مراتب نظرات حاصل را بررسی کنیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* وقتی متد [Comment.remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/comment/#remove) برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر [Comment.setParentComment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/comment/#setParentComment) یک مرجع حلقه‌ای ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص یا به بازه متنی داخل یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) مرتبط شوند. متد [CommentCollection.addModernComment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commentcollection/#addModernComment) علاوه بر اسلاید و مختصات نشانگر نظر، پارامتر یک [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) را می‌پذیرد.

زمانی که `None` برای پارامتر shape ارسال شود، نظر یک نظر سطح اسلاید است. نشانگر آن با مختصات ارائه شده موقعیت‌گیری می‌شود اما به شکل خاصی مرتبط نیست، بنابراین [ModernComment.getShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#getShape) مقدار `None` برمی‌گرداند. وقتی یک [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) فراهم شود، نظر به آن شکل متصل می‌شود. مختصات همچنان موقعیت نشانگر نظر روی اسلاید را تعریف می‌کند، در حالی که ارتباط شکل از طریق [ModernComment.getShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#getShape) قابل بازیابی است.

### **پیوست یک نظر مدرن به یک شکل**

مثال زیر هم یک نظر مدرن سطح اسلاید و هم یک نظر مدرن متصل به یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) ایجاد می‌کند. سپس شکل مرتبط با هر نظر را می‌خواند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **پیوست نظرات به انواع مختلف شکل‌ها**

هر شیء اسلایدی که از [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) ارث‌بری می‌کند می‌تواند به عنوان لنگر شکل استفاده شود. مثال‌های رایج شامل [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/fa/python-java/aspose.slides/connector/) و نمونه‌های [GraphicalObject](https://reference.aspose.com/slides/fa/python-java/aspose.slides/graphicalobject/) مانند نمودارها هستند.

مثال زیر چند نوع شکل رایج ایجاد کرده و برای هر کدام یک نظر مدرن مرتبط می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")
    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **پیوست یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن مرتبط با یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/)، متدهای [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#getTextSelectionStart) و [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#setTextSelectionStart) موقعیت شروع متن انتخاب‌شده در قاب متن شکل را دسترسی می‌دهند. متدهای [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#getTextSelectionLength) و [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#setTextSelectionLength) طول انتخاب را باز می‌گردانند. این مقادیر با هم نظر را به بازه متنی مشخصی داخل AutoShape مرتبط می‌سازند.

متدهای [ModernComment.getStatus](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#getStatus) و [ModernComment.setStatus](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#setStatus) مقداریک از ثابت‌های [ModernCommentStatus](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncommentstatus/) را برمی‌گردانند:

- [NotDefined](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncommentstatus/#NotDefined) — هیچ وضعیت خاصی برای نظر مدرن تعریف نشده است.
- [Active](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncommentstatus/#Active) — نظر فعال است.
- [Resolved](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncommentstatus/#Resolved) — نظر حل شده است.
- [Closed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncommentstatus/#Closed) — نظر بسته است.

مثال زیر یک نظر مدرن متصل به شکل ایجاد می‌کند، آن را به یک انتخاب متنی پیوست می‌کند، به عنوان حل شده علامت‌گذاری می‌کند، ارائه را ذخیره می‌کند و پس از باز کردن مجدد فایل مقادیر را بررسی می‌کند.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **بررسی نظرات مدرن موجود**

برای بررسی یک ارائه موجود، بررسی کنید کدام نظرات نمونه [ModernComment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/) هستند، سپس به [ModernComment.getShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#getShape)، [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#getTextSelectionStart)، [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#getTextSelectionLength) و [ModernComment.getStatus](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#getStatus) مراجعه کنید. یک شکل `None` نشانگر نظری در سطح اسلاید است. برای لنگر یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/)، متدهای انتخاب متن بازه مرتبط در قاب متن شکل را شناسایی می‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **حذف نظرات**

### **حذف تمام نظرات و نویسندگان نظرات**

مثال زیر نشان می‌دهد چگونه تمام نظرات و نویسندگان نظرات را از یک ارائه حذف کنیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **حذف نظرات خاص**

مثال زیر نشان می‌دهد چگونه نظرات خاصی را از یک اسلاید حذف کنیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا Aspose.Slides از وضعیت حل شده برای نظرات مدرن پشتیبانی می‌کند؟**

بله. متدهای [ModernComment.getStatus](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#getStatus) و [ModernComment.setStatus](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncomment/#setStatus) مقدار یک [ModernCommentStatus](https://reference.aspose.com/slides/fa/python-java/aspose.slides/moderncommentstatus/) را برمی‌گردانند، از جمله `Resolved`. این وضعیت در ارائه ذخیره می‌شود و پس از باز کردن مجدد فایل قابل خواندن است.

**آیا بحث‌های رشته‌ای (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای تو در تو بودن وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/fa/python-java/aspose.slides/comment/#getParentComment) خود ارجاع دهد و زنجیره پاسخ‌ها را فعال کند. API محدودیت عمق تو در توی خاصی تعریف نمی‌کند.

**موقعیت نشانگر نظر در اسلاید بر چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت نشانگر توسط مختصات عددی شناور در سیستم مختصات اسلاید تعریف می‌شود که امکان قرار دادن دقیق آن روی اسلاید را می‌دهد.