---
title: إدارة تعليقات العرض التقديمي في Python عبر Java
linktitle: تعليقات العرض التقديمي
type: docs
weight: 100
url: /ar/python-java/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض التقديمي
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى التعليق
- تعديل التعليق
- الرد على التعليق
- إزالة التعليق
- حذف التعليق
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides للغة Python عبر Java: إضافة، قراءة، تعديل، الرد على، وإزالة التعليقات في عروض PowerPoint بسرعة وسهولة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides للغة Python عبر Java. تقدم الأنواع الرئيسية المتعلقة بالتعليقات وتوضح كيفية إضافة تعليقات إلى الشرائح، والوصول إلى التعليقات الموجودة، والعمل مع الردود والتعليقات الحديثة، وإزالة التعليقات من العرض التقديمي.

تغطي الأمثلة سيناريوهات المراجعة والتعاون الشائعة في PowerPoint، مثل تعيين التعليقات إلى المؤلفين، قراءة نص التعليق والبيانات الوصفية، إنشاء سلسلات الردود، وإزالة التعليقات المحددة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كتوثيقات على الشرائح. عند تحديد تعليق يتم عرض نصه والنقاش المتعلق به.

## **لماذا إضافة تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم الملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

يوفر Aspose.Slides للغة Python عبر Java واجهات برمجة التطبيقات التالية للعمل مع التعليقات:

* الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي توفر الوصول إلى مؤلفي التعليقات في العرض التقديمي.
* الفئة [CommentCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commentcollection/) والتي تمثل التعليقات المرتبطة بمؤلف فردي.
* الفئة [Comment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/comment/) التي تقدم معلومات حول التعليق، بما في ذلك المؤلف، وقت الإنشاء، الموضع، والنص.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commentauthor/) التي توفر معلومات حول المؤلف، بما في ذلك اسمه، الحروف الأولى، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشرائح**

المثال التالي يوضح كيفية إضافة تعليقات إلى الشرائح في عرض PowerPoint:

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

## **الوصول إلى تعليقات الشرائح**

المثال التالي يوضح كيفية الوصول إلى التعليقات الموجودة في عرض PowerPoint:

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

## **الرد على التعليقات**

التعليق الأصلي هو التعليق الأصلي في أعلى تسلسل الردود. تسمح لك الطريقتان [Comment.getParentComment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/comment/#getParentComment) و[Comment.setParentComment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/comment/#setParentComment) بالحصول على المعرف أو ضبطه كأصل للتعليق.

المثال التالي يوضح كيفية إضافة ردود وفحص التسلسل الهرمي للتعليقات الناتج:

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
* عند استخدام طريقة [Comment.remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/comment/#remove) لحذف تعليق، يتم أيضًا حذف جميع الردود على ذلك التعليق.
* إذا أنشأت طريقة [Comment.setParentComment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/comment/#setParentComment) إشارة دائرية، يتم رفع استثناء [PptxEditException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشفرة نفسها، أو بشكل محدد، أو بنطاق نص داخل [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/). تقبل طريقة [CommentCollection.addModernComment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commentcollection/#addModernComment) معاملًا من نوع [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) بالإضافة إلى الشريحة وإحداثيات علامة التعليق.

عند تمرير `None` كقيمة للمعامل shape، يكون التعليق تعليقا على مستوى الشريحة. يتم وضع علامته وفقًا للإحداثيات المقدمة، ولكن لا يرتبط بشكل محدد، لذا تُعيد [ModernComment.getShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#getShape) القيمة `None`. عندما يتم توفير كائن [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/)، يتم تثبيت التعليق على ذلك الشكل. لا تزال الإحداثيات تحدد موقع علامة التعليق على الشريحة، بينما يمكن استرجاع ارتباط الشكل عبر [ModernComment.getShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#getShape).

### **تثبيت تعليق حديث إلى شكل**

المثال التالي ينشئ كلًا من تعليق حديث على مستوى الشريحة وتعليق حديث مثبت على [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) محدد. ثم يقرأ الشكل المرتبط من كل تعليق.

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

### **تثبيت التعليقات على أنواع أشكال مختلفة**

يمكن استخدام أي كائن شريحة يرث من [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) كمرساة شكل. تشمل الأمثلة الشائعة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/ar/python-java/aspose.slides/connector/)، ونسخ [GraphicalObject](https://reference.aspose.com/slides/ar/python-java/aspose.slides/graphicalobject/) مثل المخططات.

المثال التالي ينشئ عدة أنواع شائعة من الأشكال ويربط تعليقًا حديثًا بكلٍ منها.

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

### **تثبيت تعليق إلى نص وتعيين حالته**

بالنسبة لتعليق حديث مرتبط بـ [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/)، تتيح طريقتا [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#getTextSelectionStart) و[ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#setTextSelectionStart) الوصول إلى موضع بداية النص المحدد في إطار نص الشكل. تتيح طريقتا [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#getTextSelectionLength) و[ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#setTextSelectionLength) الوصول إلى طول التحديد. معًا، تربط هذه القيم التعليق بنطاق نص معين داخل الـ AutoShape.

توفر طريقتا [ModernComment.getStatus](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#getStatus) و[ModernComment.setStatus](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#setStatus) الوصول إلى قيمة من ثوابت [ModernCommentStatus](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncommentstatus/#NotDefined) — لا يتم تعريف حالة تعليق حديث محددة.
- [Active](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncommentstatus/#Active) — التعليق نشط.
- [Resolved](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncommentstatus/#Resolved) — تم حل التعليق.
- [Closed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncommentstatus/#Closed) — التعليق مغلق.

المثال التالي ينشئ تعليقًا حديثًا مثبتًا على شكل، يربطه بتحديد نص، يعلّمه كمحلول، يحفظ العرض التقديمي، ويتحقق من القيم بعد إعادة فتح الملف.

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

### **فحص التعليقات الحديثة الموجودة**

لفحص عرض تقديمي موجود، تحقق من أي التعليقات هي مثيلات لـ [ModernComment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/)، ثم استعرض [ModernComment.getShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#getShape)، [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#getTextSelectionStart)، [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#getTextSelectionLength)، و[ModernComment.getStatus](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#getStatus). يشير الشكل `None` إلى تعليق على مستوى الشريحة. بالنسبة لمرساة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/)، تحدد طرق اختيار النص النطاق المرتبط في إطار نص الشكل.

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

## **إزالة التعليقات**

### **إزالة جميع التعليقات ومؤلفي التعليقات**

المثال التالي يوضح كيفية إزالة جميع التعليقات ومؤلفي التعليقات من عرض تقديمي:

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

### **إزالة تعليقات محددة**

المثال التالي يوضح كيفية إزالة تعليقات محددة من شريحة:

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

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides حالة مكتملة للتعليقات الحديثة؟**

نعم. تتيح طريقتا [ModernComment.getStatus](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#getStatus) و[ModernComment.setStatus](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncomment/#setStatus) الوصول إلى قيمة من [ModernCommentStatus](https://reference.aspose.com/slides/ar/python-java/aspose.slides/moderncommentstatus/)، تشمل `Resolved`. يتم تخزين الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل يتم دعم المناقشات المتسلسلة (سلاسل الردود)، وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/ar/python-java/aspose.slides/comment/#getParentComment)، مما يتيح سلاسل الردود. لا تحدد واجهة البرمجة حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يتم تعريف موضع العلامة باستخدام إحداثيات ذات نقطة عائمة في نظام إحداثيات الشريحة، مما يتيح لك وضعه بدقة على الشريحة.