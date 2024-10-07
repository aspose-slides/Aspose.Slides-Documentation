---
title: تعليقات العرض
type: docs
weight: 100
url: /python-net/presentation-comments/
keywords: "تعليقات، تعليقات PowerPoint، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "إضافة تعليقات وردود في عرض PowerPoint باستخدام بايثون"
---

في PowerPoint، تظهر التعليقات كملاحظة أو تعبير على شريحة. عند النقر على تعليق، يتم الكشف عن محتوياته أو رسائله.

### **لماذا تضيف التعليقات إلى العروض؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض.

لتمكينك من استخدام التعليقات في عروض PowerPoint، فإن Aspose.Slides لبايثون عبر .NET يوفر

* فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ، التي تحتوي على مجموعات من المؤلفين (من خاصية [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/)). يضيف المؤلفون تعليقات إلى الشرائح.
* واجهة [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/) ، التي تحتوي على مجموعة من التعليقات لمؤلفين فرديين.
* فئة [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) ، التي تحتوي على معلومات عن المؤلفين وتعليقاتهم: من أضاف التعليق، وقت إضافة التعليق، موقع التعليق، إلخ.
* فئة [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) ، التي تحتوي على معلومات عن مؤلفين فرديين: اسم المؤلف، الأحرف الأولى، التعليقات المرتبطة باسم المؤلف، إلخ.

## **إضافة تعليق إلى الشريحة**
هذا الكود بايثون يوضح لك كيفية إضافة تعليق إلى شريحة في عرض PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# إنشاء مثيل لفئة Presentation
with slides.Presentation() as presentation:
    # إضافة شريحة فارغة
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # إضافة مؤلف
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # تعيين الموضع للتعليقات
    point = draw.PointF(0.2, 0.2)

    # إضافة تعليق إلى الشريحة للمؤلف على الشريحة 1
    author.comments.add_comment("مرحبًا Jawad، هذا تعليق الشريحة", presentation.slides[0], point, datetime.date.today())

    # إضافة تعليق إلى الشريحة للمؤلف على الشريحة 2
    author.comments.add_comment("مرحبًا Jawad، هذا هو تعليق الشريحة الثاني", presentation.slides[1], point, datetime.date.today())

    # الوصول إلى الشريحة 1
    slide = presentation.slides[0]

    # عندما يتم تمرير null كحجة، يتم جلب التعليقات من جميع المؤلفين إلى الشريحة المختارة
    comments = slide.get_slide_comments(author)

    # الوصول إلى التعليق في الفهرس 0 للشريحة 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # اختيار مجموعة تعليقات المؤلف عند الفهرس 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **الوصول إلى تعليقات الشريحة**
هذا الكود بايثون يوضح لك كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint:

```python
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " تحتوي على تعليق: " + comment.text + 
            " من المؤلف: " + comment.author.name + 
            " تم نشره في الوقت :" + str(comment.created_time) + "\n")
```

## **رد التعليقات**
التعليق الرئيسي هو أعلى أو تعليق أصلي في تسلسل من التعليقات أو الردود. باستخدام خاصية `parent_comment` (من واجهة [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/))، يمكنك تعيين أو الحصول على تعليق رئيسي.

هذا الكود بايثون يوضح لك كيفية إضافة تعليقات والحصول على ردود عليها:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # إضافة تعليق
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # إضافة رد على comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("رد 1 على التعليق 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # إضافة رد آخر على comment1
    reply2 = author2.comments.add_comment("رد 2 على التعليق 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # إضافة رد على رد موجود
    subReply = author1.comments.add_comment("رد فرعي 3 على الرد 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("تعليق 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("تعليق 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("رد 4 على التعليق 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # عرض تسلسل التعليقات على الكونسول
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

    # إزالة comment1 وجميع الردود عليه
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="تنبيه" %}} 

* عند استخدام طريقة `Remove` (من واجهة [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)) لحذف تعليق، يتم أيضًا حذف الردود على التعليق. 
* إذا كانت إعدادات `parent_comment` تؤدي إلى تدوير مرجعية، سيتم طرح استثناء `PptxEditException`.

{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. ميزة التعليقات الحديثة تحسن بشكل كبير التعاون في PowerPoint. من خلال التعليقات الحديثة، يتمكن مستخدمو PowerPoint من حل التعليقات، ربط التعليقات بالأشياء والنصوص، والانخراط في التفاعلات بسهولة أكبر من قبل.

قمنا بتنفيذ دعم التعليقات الحديثة من خلال إضافة فئة [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/). تم إضافة طرق `add_modern_comment` و `insert_modern_comment` إلى فئة [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) .

هذا الكود بايثون يوضح لك كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("مؤلف ما", "SA")
    modernComment = newAuthor.comments.add_modern_comment("هذا تعليق حديث", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة التعليق**

### **حذف جميع التعليقات والمؤلفين**

هذا الكود بايثون يوضح لك كيفية إزالة جميع التعليقات والمؤلفين في عرض:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # حذف جميع التعليقات من العرض
    for author in presentation.comment_authors:
        author.comments.clear()

    # حذف جميع المؤلفين
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **حذف تعليقات محددة**

هذا الكود بايثون يوضح لك كيفية حذف تعليقات محددة على شريحة:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # إضافة تعليقات...
    author = presentation.comment_authors.add_author("مؤلف", "A")
    author.comments.add_comment("تعليق 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("تعليق 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # إزالة جميع التعليقات التي تحتوي على نص "تعليق 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "تعليق 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```