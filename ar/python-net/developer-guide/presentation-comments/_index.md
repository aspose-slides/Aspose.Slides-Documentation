---
title: "إدارة تعليقات العرض التقديمي في بايثون"
linktitle: "تعليقات العرض التقديمي"
type: docs
weight: 100
url: /ar/python-net/presentation-comments/
keywords:
- "تعليق"
- "تعليق حديث"
- "تعليقات PowerPoint"
- "تعليقات العرض التقديمي"
- "تعليقات الشريحة"
- "إضافة تعليق"
- "الوصول إلى التعليق"
- "تحرير التعليق"
- "الرد على التعليق"
- "إزالة التعليق"
- "حذف التعليق"
- "PowerPoint"
- "عرض تقديمي"
- "Python"
- "Aspose.Slides"
description: "إدارة تعليقات العروض التقديمية باستخدام Aspose.Slides لبايثون عبر .NET: إضافة، قراءة، تحرير، وحذف التعليقات في ملفات PowerPoint بسرعة وسهولة."
---

في PowerPoint، يظهر التعليق كملاحظة أو توضيح على الشريحة. عند النقر على التعليق، يتم إظهار محتوياته أو رسائله.

## **لماذا نضيف تعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك أثناء مراجعة العروض التقديمية.

لتمكينك من استخدام التعليقات في عروض PowerPoint، يوفر Aspose.Slides لبايثون عبر .NET ما يلي:

* الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، التي تحتوي على مجموعات المؤلفين (من خاصية [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/)). يقوم المؤلفون بإضافة تعليقات إلى الشرائح.  
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/)، التي تحتوي على مجموعة التعليقات لكل مؤلف.  
* الفئة [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) التي تحتوي على معلومات عن المؤلفين وتعليقاتهم: من أضاف التعليق، وقت الإضافة، موضع التعليق، إلخ.  
* الفئة [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) التي تحتوي على معلومات عن كل مؤلف: اسم المؤلف، الأحرف الأولى، التعليقات المرتبطة باسمه، إلخ.  

## **إضافة تعليق شريحة**
هذا الكود بايثون يوضح كيفية إضافة تعليق إلى شريحة في عرض PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# ينشئ كائن من فئة Presentation
with slides.Presentation() as presentation:
    # يضيف شريحة فارغة
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # يضيف مؤلفًا
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # يحدد موضع التعليقات
    point = draw.PointF(0.2, 0.2)

    # يضيف تعليق شريحة لمؤلف على الشريحة 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # يضيف تعليق شريحة لمؤلف على الشريحة 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # الوصول إلى ISlide 1
    slide = presentation.slides[0]

    # عندما يُمرّر null كمعامل، تُسترجع التعليقات من جميع المؤلفين إلى الشريحة المختارة
    comments = slide.get_slide_comments(author)

    # يتعامل مع التعليق في الفهرس 0 للشريحة 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # يختار مجموعة تعليقات المؤلف في الفهرس 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **الوصول إلى تعليقات الشريحة**
هذا الكود بايثون يوضح كيفية الوصول إلى تعليقات موجودة على شريحة في عرض PowerPoint:

```python
import aspose.slides as slides

# ينشئ كائن من فئة Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **الرد على التعليقات**
التعليق الأصلي هو التعليق الأعلى أو الأصلي في هيكل التعليقات أو الردود. باستخدام الخاصية `parent_comment` (من الواجهة [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)) يمكنك تعيين أو الحصول على التعليق الأصلي.

هذا الكود بايثون يوضح كيفية إضافة تعليقات والحصول على الردود لها:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # يضيف تعليقًا
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # يضيف ردًا على comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # يضيف ردًا آخر على comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # يضيف ردًا على الرد الموجود
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # يعرض هرمية التعليقات على وحدة التحكم
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # يزيل comment1 وجميع الردود المرتبطة به
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="انتباه" %}} 
* عند استخدام طريقة `Remove` (من واجهة [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)) لحذف تعليق، يتم أيضًا حذف الردود على التعليق.  
* إذا أدى ضبط `parent_comment` إلى إشارة دائرية، سيتم رمي استثناء `PptxEditException`. 
{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. تُحسّن ميزة التعليقات الحديثة التعاون في PowerPoint بشكل كبير. من خلال التعليقات الحديثة، يحصل مستخدمو PowerPoint على القدرة على حل التعليقات، ربط التعليقات بالأجسام والنصوص، وتسهيل التفاعل بشكل كبير مقارنةً بالسابق.

تم تنفيذ دعم التعليقات الحديثة بإضافة الفئة [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/). تمت إضافة طريقتي `add_modern_comment` و `insert_modern_comment` إلى الفئة [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/).

هذا الكود بايثون يوضح كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة التعليق**

### **حذف جميع التعليقات والمؤلفين**

هذا الكود بايثون يوضح كيفية حذف جميع التعليقات والمؤلفين في عرض تقديمي:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Deletes all comments from the presentation
    for author in presentation.comment_authors:
        author.comments.clear()

    # Deletes all authors
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **حذف التعليقات المحددة**

هذا الكود بايثون يوضح كيفية حذف تعليقات معينة على شريحة:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # add comments...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # remove all comments that contain "comment 1" text
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يدعم Aspose.Slides حالة مثل 'تم الحل' للتعليقات الحديثة؟**  
نعم. التعليقات الحديثة ([ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/)) تكشف عن خاصية [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/); يمكنك قراءة وتعيين حالة التعليق (مثلاً، وضع علامة تم الحل)، وتُحفظ هذه الحالة في الملف ويُعترف بها من قبل PowerPoint.

**هل تُدعم المناقشات المتسلسلة (سلاسل الردود)، وهل هناك حد للتعشيق؟**  
نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/parent_comment/) الخاص به، مما يتيح سلاسل رد غير محدودة. لا تحدد API حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يُحدَّد موضع علامة التعليق على الشريحة؟**  
الموضع يُخزن كنقطة ذات قيمة عائمة ضمن نظام إحداثيات الشريحة، ما يسمح بوضع علامة التعليق بدقة في المكان المطلوب.