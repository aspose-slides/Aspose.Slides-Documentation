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
description: "إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides للغة بايثون عبر .NET: إضافة، قراءة، تحرير، الرد على، وإزالة التعليقات في عروض PowerPoint التقديمية."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides للغة بايثون عبر .NET. تُقدم الأنواع الأساسية المتعلقة بالتعليقات وتظهر كيفية إضافة تعليقات إلى الشرائح، الوصول إلى التعليقات الموجودة، التعامل مع الردود والتعليقات الحديثة، وإزالة التعليقات من العرض التقديمي.

تغطي الأمثلة سيناريوهات المراجعة والتعاون الشائعة في PowerPoint، مثل تعيين التعليقات للمؤلفين، قراءة نص التعليق والبيانات الوصفية، بناء سلاسل الردود، وإزالة التعليقات المحددة أو جميع التعليقات.

في PowerPoint، تُظهر التعليقات كتوثيقات على الشرائح. اختيار تعليق يعرض نصه والنقاش المتعلق به.

لطلب إظهار أو إخفاء التعليقات عند فتح العرض التقديمي دون تعديل التعليقات نفسها، راجع [إظهار أو إخفاء التعليقات عند فتح عرض تقديمي](/slides/ar/python-net/presentation-view-properties/).

## **لماذا نضيف تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم ملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

توفر Aspose.Slides للغة بايثون عبر .NET APIs التالية للعمل مع التعليقات:

* The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class، التي توفر الوصول إلى مؤلفي تعليقات العرض التقديمي.
* The [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) class، التي تمثل التعليقات المرتبطة بمؤلف فردي.
* The [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) class، التي توفر معلومات حول تعليق بما في ذلك مؤلفه، وقت الإنشاء، الموقع، والنص.
* The [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) class، التي توفر معلومات حول مؤلف بما في ذلك اسمه، الأحرف الأولية، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشرائح**

تنشئ المثال شريحتين وتُسجِّل مؤلف تعليق باستخدام [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). يستخدم [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) لوضع تعليق واحد على كل شريحة، ثم يسترجع تعليقات الشريحة الأولى لهذا المؤلف باستخدام [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). تعرض وحدة التحكم نص التعليق الأول مرتين، مظهرةً الوصول عبر كلٍ من الشريحة والمؤلف، ويتضمن العرض التقديمي المحفوظ كلاً من التعليقين.

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

## **البحث عن أو إنشاء مؤلف تعليق**

عند معالجة مراجعة آلية لنفس العرض التقديمي بشكل متكرر، ابحث في مجموعة [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) قبل إضافة مؤلف. يطابق [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) كلًا من الاسم والأحرف الأولية ويعيد مصفوفة من المؤلفين المطابقين، أو مصفوفة فارغة إذا لم توجد مطابقات. بالمقابل، يبحث [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) بالاسم فقط، بغض النظر عن الأحرف الأولية. استدعاء [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) باسم وأحرف أولية موجودة بالفعل في المجموعة يرمي استثناءً.

يتطلب المثال ملف عرض تقديمي يحتوي على شريحة واحدة على الأقل. في كل من المرورين، يعيد استخدام أول مؤلف مطابق، أو ينشئ واحدًا فقط عندما تكون النتيجة فارغة. إذا كان هناك عدة مطابقات، يختار العنصر الأول في المصفوفة دون دمج أو إزالة المؤلفين الآخرين. ثم يستدعى [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) للمؤلف المحدد ويحفظ العرض التقديمي. يفتح المرور الثاني ناتج المرور الأول ويكرر العملية.

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

يضيف المرور الثاني تعليقًا آخر دون إضافة مؤلف جديد أو إزالة التعليقات الموجودة. يحتوي الملف النهائي، `review_pass_2.pptx`، على كلا التعليقين الجديدين إلى جانب أي تعليقات أصلية. إعادة استخدام المؤلف لا تُزيل التكرار في التعليقات: لتجنب إضافة نفس التعليق مرارًا، نفّذ كشفًا منفصلًا للتكرار قبل إضافته.

## **الوصول إلى تعليقات الشرائح**

يفتح المثال عرض تقديمي موجودًا ويقرأ مجموعة [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). لكل مؤلف، يمر عبر [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) ويطبع رقم الشريحة، نص التعليق، اسم المؤلف، ووقت الإنشاء. يجب أن يحتوي عرض تقديمي الإدخال على تعليقات لإنتاج مخرجات وحدة التحكم.

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

التعليق الأساسي هو التعليق الأصلي في أعلى هيكل الردود. تسمح خاصية [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) في فئة [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) بالحصول على التعليق الأصل أو تعيينه.

ينشئ المثال تعليقات من مؤلفين اثنين ويستخدم [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) لبناء الردود، بما في ذلك رد على رد آخر. يمرر `None` إلى [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) لاسترجاع التعليقات من جميع المؤلفين؛ تُمسك وحدة التحكم كل إدخال وفقًا لعمقه في هيكل الردود. يحفظ المثال المناقشة الكاملة، يستدعي [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) على أول تعليق جذري، ويحفظ عرضًا تقديميًا ثانٍ بدون ذلك التعليق وردوده.

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
* عند استخدام طريقة [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) في فئة [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) لحذف تعليق، تُحذف جميع الردود على ذلك التعليق أيضًا.
* إذا أدت خاصية [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) إلى إنشاء مرجع دائري، يُرمى استثناء [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشرائح نفسها، أو بشكل معين، أو بنطاق نص داخل AutoShape. تقبل طريقة [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) وسيطًا من نوع [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) بالإضافة إلى إحداثيات الشريحة وعلامة التعليق.

عند تمرير `None` كقيمة للمعامل shape، يكون التعليق تعليقًا على مستوى الشريحة. يتم وضع علامته وفقًا للإحداثيات المقدمة، لكنه غير مرتبط بشكل محدد، لذا تُعيد خاصية [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) القيمة `None`. عندما يتم توفير [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)، يثبت التعليق إلى ذلك الشكل. لا تزال الإحداثيات تحدد موقع علامة التعليق على الشريحة، ويمكن استرجاع الارتباط بالشكل عبر [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/).

### **ربط تعليق حديث بشكل إلى شكل**

يستدعي المثال [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) مرتين: مرةً مع شكل `None` لإنشاء تعليق على مستوى الشريحة ومرةً أخرى مع مستطيل كمرساة. قراءة [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) تُظهر `True` للتحقق من عدم وجود شكل في التعليق على مستوى الشريحة و`Revenue title` للتعليق المرتبط. يتم حفظ كلا التعليقين مع العرض التقديمي.

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

### **ربط التعليقات بأنواع أشكال مختلفة**

يمكن استخدام أي كائن شريحة مُشتق من [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) كمرساة للشكل. تشمل الأمثلة الشائعة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/)، و[GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) مثل المخططات.

يستخدم المثال [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) لربط تعليق مع كل من خمسة أنواع أشكال: AutoShape، إطار صورة، مجموعة، موصل، ومخطط. تُضمّن الصورة بيانات صورة مضمنة، لذا لا يلزم صورة خارجية. لكل تعليق موقع علامة خاص به، ويحافظ العرض التقديمي المحفوظ على جميع الروابط الخمسة.

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

### **ربط تعليق بنص وتعيين حالته**

للتعليق الحديث المرتبط بـ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)، تحدد الخاصية [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) موضع البداية للنص المحدد داخل إطار النص بالشكل، بينما تحدد [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) طول الاختيار. معًا، تربط هذه الخصائص التعليق بنطاق نص معين داخل الـ AutoShape.

يمكن قراءة أو تحديث خاصية [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) بقيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — لا يتم تعريف حالة حديثة محددة.
- `ACTIVE` — التعليق نشط.
- `RESOLVED` — تم حل التعليق.
- `CLOSED` — التعليق مغلق.

يربط المثال تعليقًا حديثًا بكلمات "quarterly revenue" في نص مستطيل. يحسب [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) الصفري من النص ويضبط [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) على عدد الأحرف المحددة. بعد تعيين [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) إلى `RESOLVED`، يحفظ ويعيد فتح العرض التقديمي. يجب أن تطبع الفحوصات الأربعة في وحدة التحكم `True`، مؤكدًا حفظ مرساة الشكل، نطاق النص، والحالة.

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

### **فحص التعليقات الحديثة الموجودة**

يتطلب المثال وجود عرض تقديمي يحتوي على تعليقات حديثة ويطبع نصها، حالتها، وتفاصيل المرساة. لتفقده، تحقق أي التعليقات هي حالات من [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/)، ثم افحص [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/)، [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/)، [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/)، و[ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). يشير الشكل `None` إلى تعليق على مستوى الشريحة. بالنسبة لمرساة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)، تحدد خصائص اختيار النص النطاق المرتبط في إطار نص الشكل.

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

تتيح Aspose.Slides للغة بايثون عبر .NET إمكانية إزالة جميع التعليقات ومؤلفيها من عرض تقديمي أو حذف تعليقات مختارة مع الحفاظ على البقية. توضح الأمثلة التالية كلا النهجين وتحفظ العرض التقديمي المحدث.

### **إزالة جميع التعليقات ومؤلفي التعليقات**

يفتح المثال عرض تقديمي موجودًا ويستدعي [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) لكل مؤلف، ثم يستدعي [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) لإزالة المؤلفين أنفسهم. لا يحتوي العرض التقديمي المحفوظ على أي تعليقات أو مؤلفي تعليقات. استخدم عرضًا تقديميًا يحتوي على تعليقات لملاحظة الإزالة.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **إزالة تعليقات محددة**

ينشئ المثال تعليقاتين على شريحة واحدة ويستخدم [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) للعثور على التعليقات لكل مؤلف. يجمع التعليقات التي يساوي نصها "comment 1" قبل استدعاء [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/)، متجنبًا تعديل المجموعة أثناء الاختيار. يحتفظ العرض التقديمي المحفوظ فقط بـ "comment 2".

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

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides حالة "محلول" للتعليقات الحديثة؟**

نعم. يمكن قراءة وتعيين [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) باستخدام قيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/)، بما في ذلك `RESOLVED`. تُخزن الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/)، مما يتيح سلاسل الردود. لا تحدد الواجهة حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يُحدد موقع علامة التعليق على الشريحة؟**

يُحدد موقع العلامة بإحداثيات نقطية عائمة في نظام إحداثيات الشريحة، مما يتيح لك وضعها بدقة على الشريحة.