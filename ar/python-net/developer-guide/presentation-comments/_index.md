---
title: إدارة تعليقات العرض التقديمي في Python
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
- الوصول إلى تعليق
- تحرير تعليق
- الرد على التعليق
- إزالة تعليق
- حذف تعليق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحكم في تعليقات العرض التقديمي باستخدام Aspose.Slides لبايثون عبر .NET: إضافة، قراءة، تحرير، وحذف التعليقات في ملفات PowerPoint بسرعة وسهولة."
---

في PowerPoint، يظهر التعليق كملاحظة أو توضيح على الشريحة. عند النقر على التعليق، يتم الكشف عن محتوياته أو رسائله.

## **لماذا نضيف تعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض التقديمية.

لتمكينك من استخدام التعليقات في عروض PowerPoint التقديمية، توفر Aspose.Slides لـ Python عبر .NET
* فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على مجموعات المؤلفين (من خاصية [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/) ). يقوم المؤلفون بإضافة تعليقات إلى الشرائح. 
* فئة [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) التي تحتوي على مجموعة التعليقات للمؤلفين الفرديين. 
* فئة [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) التي تحتوي على معلومات حول المؤلفين وتعليقاتهم: من أضاف التعليق، وقت إضافة التعليق، موضع التعليق، إلخ. 
* فئة [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) التي تحتوي على معلومات حول كل مؤلف: اسم المؤلف، أحرفه الأولى، التعليقات المرتبطة باسم المؤلف، إلخ. 

## **إضافة تعليق إلى شريحة**
هذا الكود بلغة Python يوضح لك كيفية إضافة تعليق إلى شريحة في عرض PowerPoint تقديمي:
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# ينشئ كائن من الفئة Presentation
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

    # عند تمرير قيمة null كوسيط، تُجلب التعليقات من جميع المؤلفين إلى الشريحة المحددة
    comments = slide.get_slide_comments(author)

    # يحصل على التعليق في الفهرس 0 للشريحة 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # يختار مجموعة تعليقات المؤلف في الفهرس 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```


## **الوصول إلى تعليقات الشريحة**
هذا الكود بلغة Python يوضح لك كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint تقديمي:
```python
import aspose.slides as slides

# ينشئ كائن من الفئة Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **الرد على التعليقات**
التعليق الأساسي هو التعليق العلوي أو الأصلي في تسلسل التعليقات أو الردود. باستخدام خاصية `parent_comment` (من فئة [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/)) يمكنك تعيين أو الحصول على التعليق الأساسي. 

هذا الكود بلغة Python يوضح لك كيفية إضافة تعليقات والحصول على الردود عليها:
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

    # يعرض تسلسل التعليقات في وحدة التحكم
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

    # يزيل comment1 وجميع الردود عليه
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="warning" title="Attention" %}} 
* عند استخدام طريقة `remove` (من فئة [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/)) لحذف تعليق، يتم حذف الردود على التعليق أيضًا. 
* إذا أدى ضبط `parent_comment` إلى إشارة دائرية، سيتم إطلاق استثناء `PptxEditException`.
{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. تحسن ميزة التعليقات الحديثة التعاون في PowerPoint بشكل كبير. من خلال التعليقات الحديثة، يحصل مستخدمو PowerPoint على إمكانية حل التعليقات، ربط التعليقات بالكائنات والنصوص، والتفاعل بسهولة أكبر مقارنةً بالسابق. 

قمنا بتنفيذ دعم التعليقات الحديثة بإضافة فئة [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/). تمت إضافة الطريقتين `add_modern_comment` و `insert_modern_comment` إلى فئة [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/). 

هذا الكود بلغة Python يوضح لك كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint تقديمي:
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
هذا الكود بلغة Python يوضح لك كيفية حذف جميع التعليقات والمؤلفين في عرض تقديمي:
```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # يحذف جميع التعليقات من العرض التقديمي
    for author in presentation.comment_authors:
        author.comments.clear()

    # يحذف جميع المؤلفين
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```


### **حذف تعليقات محددة**
هذا الكود بلغة Python يوضح لك كيفية حذف تعليقات محددة على شريحة:
```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # إضافة تعليقات...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # إزالة جميع التعليقات التي تحتوي على النص "comment 1"
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

نعم. تُظهر [التعليقات الحديثة](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) خاصية [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/); يمكنك قراءة وتعيين حالة [التعليق](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) (على سبيل المثال، وضع علامة تم الحل)، ويتم حفظ هذه الحالة في الملف ويُعترف بها من قبل PowerPoint.

**هل يتم دعم المناقشات المتسلسلة (سلاسل الردود)، وهل هناك حد للتعمق؟**

نعم. يمكن لكل تعليق الإشارة إلى [التعليق الأصلي](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/parent_comment/)، مما يتيح سلاسل ردود غير محدودة. لا تحدد الـ API حدًا معينًا لعمق التداخل.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يتم تخزين الموضع كنقطة ذات نقطة عائمة في نظام إحداثيات الشريحة. يتيح لك ذلك وضع علامة التعليق بدقة في الموقع الذي تحتاجه.