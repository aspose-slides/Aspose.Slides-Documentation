---
title: إدارة تعليقات العرض التقديمي في بايثون
linktitle: تعليقات العرض التقديمي
type: docs
weight: 100
url: /ar/python-net/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض التقديمي
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى التعليق
- تحرير التعليق
- الرد على التعليق
- إزالة التعليق
- حذف التعليق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides لبايثون عبر .NET: إضافة، قراءة، تحرير، الرد على، وإزالة التعليقات في عروض PowerPoint."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides للغة Python عبر .NET. تُعرف الأنواع الرئيسية المرتبطة بالتعليقات وتُظهر كيفية إضافة تعليقات إلى الشرائح، الوصول إلى التعليقات الموجودة، العمل مع الردود والتعليقات الحديثة، وإزالة التعليقات من العرض التقديمي.

تغطي الأمثلة سيناريوهات المراجعة والتعاون الشائعة في PowerPoint، مثل تعيين التعليقات إلى المؤلفين، قراءة نص التعليق والبيانات الوصفية، بناء سلاسل الردود، وإزالة التعليقات المحددة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كتعليقات توضيحية على الشرائح. عند تحديد تعليق يتم عرض نصه والنقاش المتعلق به.

لطلب إظهار أو إخفاء التعليقات عند فتح العرض التقديمي دون تغيير التعليقات نفسها، راجع [Show or Hide Comments When Opening a Presentation](/slides/ar/python-net/presentation-view-properties/).

## **لماذا إضافة تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم الملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

يوفر Aspose.Slides للغة Python عبر .NET واجهات برمجة التطبيقات التالية للعمل مع التعليقات:

* الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) التي توفر الوصول إلى مؤلفي التعليقات في العرض التقديمي.
* الفئة [CommentCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/commentcollection/) التي تمثل التعليقات المرتبطة بمؤلف معين.
* الفئة [Comment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/comment/) التي توفر معلومات حول التعليق، بما في ذلك مؤلفه، وقت الإنشاء، الموضع، والنص.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/ar/python-net/aspose.slides/commentauthor/) التي توفر معلومات حول المؤلف، بما في ذلك اسمه، الأحرف الأولى، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشرائح**

توضح المثال التالي كيفية إضافة تعليقات إلى الشرائح في عرض PowerPoint:

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

## **الوصول إلى تعليقات الشرائح**

يوضح المثال التالي كيفية الوصول إلى التعليقات الموجودة في عرض PowerPoint:

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

## **الرد على التعليقات**

التعليق الأصلي هو التعليق الأول في تسلسل الردود. تسمح الخاصية [parent_comment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/comment/parent_comment/) من الفئة [Comment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/comment/) بالحصول على أو تعيين التعليق الأصلي.

يوضح المثال التالي كيفية إضافة الردود وفحص هيكل التعليقات الناتج:

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

{{% alert color="warning" title="Warning" %}}
* عند استخدام طريقة [remove](https://reference.aspose.com/slides/ar/python-net/aspose.slides/comment/remove/) من الفئة [Comment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/comment/) لحذف تعليق، يتم حذف جميع الردود على ذلك التعليق أيضًا.
* إذا أدت الخاصية [parent_comment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/comment/parent_comment/) إلى إنشاء إشارة دائرية، يتم رفع استثناء [PptxEditException](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشرائح نفسها، أو بشكل محدد، أو بنطاق نص داخل AutoShape. تقبل طريقة [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/commentcollection/add_modern_comment/) وسيطًا من نوع [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) بالإضافة إلى إحداثيات الشريحة وعلامة التعليق.

عند تمرير `None` كقيمة للوسيطة shape، يكون التعليق تعليقًا على مستوى الشريحة. يتم وضع علامته وفقًا للإحداثيات المقدمة، لكنه غير مرتبط بشكل معين، لذا تُعيد [ModernComment.shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncomment/shape/) القيمة `None`. عندما يتم توفير [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/)، يتم تثبيت التعليق على ذلك الشكل. لا تزال الإحداثيات تحدد موضع علامة التعليق على الشريحة، بينما يمكن استرداد ارتباط الشكل عبر [ModernComment.shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncomment/shape/).

### **تثبيت تعليق حديث إلى شكل**

يوضح المثال التالي إنشاء كل من تعليق حديث على مستوى الشريحة وتعليق حديث مثبت إلى AutoShape محدد. ثم يقرأ الشكل المرتبط بكل تعليق.

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

### **تثبيت التعليقات إلى أنواع أشكال مختلفة**

يمكن استخدام أي كائن شريحة مشتق من [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) كمرساة شكل. تشمل الأمثلة الشائعة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/ar/python-net/aspose.slides/connector/), و[GraphicalObject](https://reference.aspose.com/slides/ar/python-net/aspose.slides/graphicalobject/) مثل المخططات.

يوضح المثال التالي إنشاء عدة أنواع شائعة من الأشكال وربط تعليق حديث بكل منها.

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

### **تثبيت تعليق إلى نص وتعيين حالته**

بالنسبة لتعليق حديث مرتبط بـ [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/)، تحدد الخاصية [ModernComment.text_selection_start](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncomment/text_selection_start/) موضع البداية للنص المحدد في إطار النص الخاص بالشكل، بينما تحدد [ModernComment.text_selection_length](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncomment/text_selection_length/) طول التحديد. معًا، تربط هذه الخصائص التعليق بنطاق نص محدد داخل الـ AutoShape.

يمكن قراءة الخاصية [ModernComment.status](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncomment/status/) أو تحديثها بقيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — لا يتم تعريف حالة تعليق حديث محددة.
- `ACTIVE` — التعليق نشط.
- `RESOLVED` — تم حل التعليق.
- `CLOSED` — التعليق مغلق.

يوضح المثال التالي إنشاء تعليق حديث مثبت إلى شكل، ربطه بتحديد نص، تعيينه كمنحل، حفظ العرض التقديمي، والتحقق من القيم بعد إعادة فتح الملف.

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

### **فحص التعليقات الحديثة الموجودة**

لفحص عرض تقديمي موجود، تحقق من أي التعليقات هي مثيلات [ModernComment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncomment/)، ثم فحص [ModernComment.shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncomment/text_selection_length/), و[ModernComment.status](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncomment/status/). يشير الشكل `None` إلى تعليق على مستوى الشريحة. بالنسبة لمرساة [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/)، تحدد خصائص تحديد النص النطاق المرتبط في إطار نص الشكل.

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

## **إزالة التعليقات**

### **إزالة جميع التعليقات ومؤلفي التعليقات**

يوضح المثال التالي كيفية إزالة جميع التعليقات ومؤلفي التعليقات من عرض تقديمي:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **إزالة تعليقات محددة**

يوضح المثال التالي كيفية إزالة تعليقات محددة من شريحة:

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

## **الأسئلة الشائعة**

**هل يدعم Aspose.Slides حالة الحل للتعليقات الحديثة؟**

نعم. يمكن قراءة وتعيين الخاصية [ModernComment.status](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncomment/status/) بقيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/ar/python-net/aspose.slides/moderncommentstatus/)، بما في ذلك `RESOLVED`. تُخزن الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل يتم دعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/ar/python-net/aspose.slides/comment/parent_comment/)، مما يتيح سلاسل الردود. لا تحدد واجهة برمجة التطبيقات حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يتم تعريف موضع العلامة بإحداثيات نقطية (floating‑point) في نظام إحداثيات الشريحة، مما يتيح لك وضعها بدقة على الشريحة.