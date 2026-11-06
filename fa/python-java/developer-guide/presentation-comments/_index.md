---
title: مدیریت نظرات ارائه در پایتون از طریق جاوا
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/python-java/presentation-comments/
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
- پاک‌کردن نظر
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "نظرات ارائه را با Aspose.Slides برای Python از طریق Java مدیریت کنید: افزودن، خواندن، ویرایش، پاسخ‌دادن و حذف نظرات در ارائه‌های PowerPoint به‌صورت سریع و آسان."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه نظرات ارائه را با Aspose.Slides برای Python via Java مدیریت کنید. انواع اصلی مرتبط با نظر معرفی می‌شوند و نشان داده می‌شود چگونه نظرات را به اسلایدها اضافه کنید، به نظرات موجود دسترسی پیدا کنید، با پاسخ‌ها و نظرات مدرن کار کنید و نظرات را از یک ارائه حذف کنید.

مثال‌ها سناریوهای رایج بازبینی و همکاری در PowerPoint را پوشش می‌دهند، از جمله اختصاص نظرات به نویسندگان، خواندن متن نظر و فراداده‌ها، ساخت زنجیره پاسخ‌ها، و حذف نظرات انتخاب‌شده یا تمام نظرات.

در PowerPoint، نظرات به‌عنوان حاشیه‌نویسی روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر، متن و بحث مرتبط با آن را نمایش می‌دهد.

برای درخواست نمایش یا پنهان‌سازی نظرات هنگام باز شدن ارائه بدون تغییر در خود نظرات، به [Show or Hide Comments When Opening a Presentation](/slides/fa/python-java/presentation-view-properties/) نگاه کنید.

## **چرا نظرات به ارائه‌ها اضافه شوند؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بازبینی ارائه‌ها استفاده کنید.

Aspose.Slides برای Python via Java APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* کلاس [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) که نظرات مرتبط با یک نویسنده خاص را نمایندگی می‌کند.
* کلاس [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) که اطلاعاتی دربارهٔ یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن را ارائه می‌دهد.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) که اطلاعاتی دربارهٔ نویسنده شامل نام، حروف اولیه و نظرات مرتبط را فراهم می‌کند.

## **افزودن نظرات به اسلاید**

این مثال دو اسلاید ایجاد می‌کند و یک نویسنده نظر را با استفاده از [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) ثبت می‌نماید. سپس با استفاده از [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) یک نظر را روی هر اسلاید قرار می‌دهد، سپس نظرات اولین اسلاید را برای آن نویسنده با [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) بازیابی می‌کند. کنسول متن اولین نظر را دو بار نمایش می‌دهد تا دسترسی از طریق اسلاید و نویسنده نشان داده شود و ارائه ذخیره‌شده شامل هر دو نظر است.

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

## **یافتن یا ایجاد نویسنده نظر**

هنگامی که یک بازبینی خودکار به‌طور مکرر همان ارائه را پردازش می‌کند، پیش از افزودن نویسنده، مجموعهٔ برگشتی از [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) را جستجو کنید. [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) هم نام و هم حروف اولیه را مقایسه می‌کند و آرایه‌ای از نویسندگان مطابقت‌دهنده یا آرایهٔ خالی برمی‌گرداند. در مقابل، [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) فقط بر اساس نام جستجو می‌کند، بدون در نظر گرفتن حروف اولیه. فراخوانی [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) با نام و حروف اولیه‌ای که پیشتر در مجموعه وجود دارد، استثنا پرتاب می‌کند.

این مثال به فایلی از ارائه با حداقل یک اسلاید نیاز دارد. در هر یک از دو عبور، نویسندهٔ مطابق اولین پیدا‌شده را دوباره استفاده می‌کند یا تنها زمانی که نتیجه خالی باشد، یک نویسنده جدید می‌سازد. اگر تطبیق‌های متعددی وجود داشته باشد، اولین عنصر آرایه را انتخاب می‌کند بدون ترکیب یا حذف دیگر نویسندگان. سپس برای نویسندهٔ انتخاب‌شده با [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) نظر افزوده و ارائه را ذخیره می‌کند. عبور دوم خروجی عبور اول را باز می‌کند و عملیات را تکرار می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

عبور دوم یک نظر دیگر اضافه می‌کند بدون افزودن نویسندهٔ جدید یا حذف نظرات موجود. فایل نهایی، `review_pass_2.pptx`، هر دو نظر جدید را همراه با هر نظر اصلی نگه می‌دارد. استفاده مجدد از نویسنده باعث حذف تکراری نظرات نمی‌شود: برای جلوگیری از افزودن مکرر همان نظر، قبل از افزودن، تشخیص تکراری جداگانه‌ای پیاده‌سازی کنید.

## **دسترسی به نظرات اسلاید**

این مثال یک ارائه موجود را باز می‌کند و مجموعهٔ برگشتی از [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) را می‌خواند. برای هر نویسنده، به‌وسیلهٔ [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) از مجموعهٔ نظرات می‌گذرد و شماره اسلاید، متن نظر، نام نویسنده و زمان ایجاد را چاپ می‌کند. ارائهٔ ورودی باید شامل نظرات باشد تا خروجی کنسول تولید شود.

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

یک نظر والد، نظر اصلی در بالای یک سلسله‌مراتب پاسخ است. متدهای [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) و [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) اجازه می‌دهند والد یک نظر را دریافت یا تنظیم کنید.

این مثال نظراتی از دو نویسنده می‌سازد و با استفاده از [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) پاسخ‌ها را ساخته، از جمله پاسخی به یک پاسخ دیگر. ارسال `None` به [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) نظرات همه نویسندگان را بازیابی می‌کند؛ کنسول هر ورودی را برحسب عمق در سلسله‌مراتب پاسخ‌ها تورفتگی می‌دهد. مثال بحث کامل را ذخیره می‌کند، بر روی اولین نظر ریشه‌ای [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) فراخوانی می‌کند و ارائهٔ دوم را با حذف آن نظر و پاسخ‌هایش ذخیره می‌نماید.

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
* هنگامی که متد [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نیز حذف می‌شوند.
* اگر [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) یک ارجاع حلقوی ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص یا به یک بازهٔ متنی داخل یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) مرتبط شوند. متد [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) علاوه بر اسلاید و مختصات نشانگر نظر، یک آرگومان [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) می‌پذیرد.

هنگامی که برای آرگومان shape مقدار `None` ارسال شود، نظر یک نظر سطح اسلاید می‌شود. نشانگر آن توسط مختصات ارائه‌شده موقعیت‌یابی می‌شود، اما به شکل خاصی وابسته نیست، بنابراین [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) مقدار `None` برمی‌گرداند. وقتی یک [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) فراهم شود، نظر به آن شکل متصل می‌شود. مختصات همچنان موقعیت نشانگر نظر را روی اسلاید تعریف می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) بازیابی شود.

### **اتصال یک نظر مدرن به یک شکل**

مثال دو بار [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) را فراخوانی می‌کند: یک بار با shape `None` برای یک نظر سطح اسلاید و یک بار با یک مستطیل به‌عنوان لنگر. خواندن [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) برای نظر سطح اسلاید مقدار `True` برای بررسی `None` و برای نظر لنگرشده مقدار `Revenue title` چاپ می‌کند. هر دو نظر با ارائه ذخیره می‌شوند.

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

### **اتصال نظرات به انواع مختلف شکل**

هر شیء اسلایدی که از [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) ارث‌بری می‌کند می‌تواند به‌عنوان لنگر شکل استفاده شود. مثال‌های رایج شامل [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/) و نمونه‌های [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) مانند نمودارها هستند.

مثال از [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) برای مرتبط‌سازی یک نظر با هر یک از پنج نوع شکل استفاده می‌کند: یک AutoShape، یک PictureFrame، یک GroupShape، یک Connector و یک Chart. تصویر از داده‌های تصویر توکار استفاده می‌کند، بنابراین تصویر خارجی لازم نیست. هر نظر موقعیت نشانگر خود را دارد و ارائهٔ ذخیره‌شده تمام پنج ارتباط شکل را حفظ می‌کند.

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

### **اتصال یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن مرتبط با یک [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)، متدهای [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) و [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) به موقعیت شروع متن انتخاب‌شده در فریم متنی شکل دسترسی می‌دهند. متدهای [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) و [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) طول انتخاب را برمی‌گردانند. این مقادیر با هم نظر را به بازهٔ متنی خاصی داخل AutoShape متصل می‌کنند.

متدهای [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) و [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) به مقدار از ثابت‌های [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) دسترسی می‌دهند:

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — هیچ وضعیت خاصی برای نظر مدرن تعریف نشده است.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — نظر فعال است.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — نظر حل شده است.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — نظر بسته است.

مثال یک نظر مدرن را به کلمات «quarterly revenue» در متن یک مستطیل لنگر می‌کند. شروع انتخاب صفر پایه را از متن محاسبه می‌کند و به [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) می‌فرستد و با استفاده از [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) تعداد کاراکترهای انتخاب‌شده را تنظیم می‌کند. پس از فراخوانی [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) با `Resolved`، ارائه را ذخیره و دوباره باز می‌کند. چهار بررسی کنسول باید هرکدام `True` چاپ کنند، تأیید می‌گردد که لنگر شکل، بازهٔ متنی و وضعیت حفظ شده‌اند.

```python
import jpype
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

این مثال به ارائه‌ای موجود که شامل نظرات مدرن است نیاز دارد و متن، وضعیت و جزئیات لنگر را چاپ می‌کند. برای بررسی، بررسی کنید کدام نظرات نمونهٔ [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/) هستند، سپس [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape)، [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart)، [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) و [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) را بررسی کنید. یک shape `None` نشانگر نظر سطح اسلاید است. برای یک لنگر [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)، متدهای انتخاب متن بازهٔ مرتبط را در فریم متنی شکل شناسایی می‌کنند.

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

Aspose.Slides برای Python via Java امکان حذف تمام نظرات و نویسندگان آن‌ها از یک ارائه یا حذف نظرات منتخب در حالی که بقیه نگه داشته می‌شوند را می‌دهد. مثال‌های زیر هر دو روش را نشان می‌دهند و ارائه به‌روز‌شده را ذخیره می‌کنند.

### **حذف تمام نظرات و نویسندگان نظرات**

مثال یک ارائه موجود را باز می‌کند و برای هر نویسنده [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) را فراخوانی می‌کند، سپس برای حذف خود نویسندگان [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) را اجرا می‌کند. ارائهٔ ذخیره‌شده هیچ نظر یا نویسندهٔ نظری دربر ندارد. برای مشاهده حذف، از ارائه‌ای حاوی نظرات استفاده کنید.

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

مثال دو نظر بر روی یک اسلاید می‌سازد و با استفاده از [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) نظرات هر نویسنده را پیدا می‌کند. نظراتی که متن آن‌ها برابر با «comment 1» باشد جمع‌آوری می‌شوند قبل از فراخوانی [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove) تا در حین انتخاب، تغییراتی در مجموعه رخ ندهد. ارائهٔ ذخیره‌شده فقط «comment 2» را نگه می‌دارد.

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

**آیا Aspose.Slides وضعیت حل‌شده را برای نظرات مدرن پشتیبانی می‌کند؟**

بله. متدهای [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) و [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) به مقدار [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) دسترسی می‌دهند، از جمله `Resolved`. این وضعیت در ارائه ذخیره می‌شود و پس از بازگشایی فایل می‌تواند دوباره خوانده شود.

**آیا بحث‌های رشته‌ای (زنجیره پاسخ‌ها) پشتیبانی می‌شوند و آیا محدودیتی برای تو در تویی وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) خود ارجاع دهد، که امکان زنجیرهٔ پاسخ‌ها را فراهم می‌کند. API محدودیت عمق خاصی برای تو در تویی تعریف نمی‌کند.

**موقعیت نشانگر نظر در سیستم مختصاتی چه چیزی است؟**

موقعیت نشانگر توسط مختصات نقطه‌ای با عدد شناور در سیستم مختصاتی اسلاید تعریف می‌شود، که امکان قرار دادن دقیق آن بر روی اسلاید را می‌دهد.