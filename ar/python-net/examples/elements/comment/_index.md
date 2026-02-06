---
title: تعليق
type: docs
weight: 230
url: /ar/python-net/examples/elements/comment/
keywords:
- تعليق
- تعليق حديث
- إضافة تعليق
- الوصول إلى تعليق
- إزالة تعليق
- الرد على تعليق
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة تعليقات الشرائح في بايثون باستخدام Aspose.Slides: إضافة، قراءة، رد، تعديل، حذف، والعمل مع تعليقات متسلسلة لـ PowerPoint و OpenDocument."
---
يوضح إضافة، قراءة، إزالة، والرد على التعليقات الحديثة باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة تعليق حديث**

إنشاء تعليق كتبه مستخدم وحفظ العرض التقديمي.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # إضافة مؤلف تعليق.
        author = presentation.comment_authors.add_author("User", "U1")

        # إضافة تعليق حديث.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى تعليق حديث**

قراءة تعليق حديث من عرض تقديمي موجود.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # الوصول إلى أول تعليق حديث.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **إزالة تعليق حديث**

إزالة التعليق وحفظ الملف المحدث.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # إزالة التعليق.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **الرد على تعليق حديث**

إضافة ردود إلى التعليق الحديث الأصلي.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # إضافة تعليق رئيسي.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # إضافة أول رد.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # إضافة رد ثانٍ.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```