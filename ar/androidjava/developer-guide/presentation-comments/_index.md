---
title: إدارة تعليقات العرض التقديمي على Android
linktitle: تعليقات العرض التقديمي
type: docs
weight: 100
url: /ar/androidjava/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض التقديمي
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى تعليق
- تعديل تعليق
- الرد على تعليق
- إزالة تعليق
- حذف تعليق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إتقان تعليقات العرض التقديمي باستخدام Aspose.Slides لنظام Android عبر Java: إضافة، قراءة، تعديل، وحذف التعليقات في ملفات PowerPoint بسرعة وسهولة."
---

في PowerPoint، يظهر التعليق كملاحظة أو توضيح على شريحة. عند النقر على التعليق، يتم إظهار محتواه أو رسائله. 

### **لماذا نضيف تعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض التقديمية.

لتمكينك من استخدام التعليقات في عروض PowerPoint التقديمية، توفر Aspose.Slides لنظام Android عبر Java

* الفئة [العرض](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي تحتوي على مجموعات المؤلفين (من الواجهة [ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection)). يقوم المؤلفون بإضافة تعليقات إلى الشرائح.
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection) التي تحتوي على مجموعة التعليقات لكل مؤلف.
* الفئة [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) التي تحتوي على معلومات حول المؤلفين وتعليقاتهم: من أضاف التعليق، وقت إضافة التعليق، موضع التعليق، إلخ.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor) التي تحتوي على معلومات حول كل مؤلف: اسم المؤلف، الأحرف الأولى منه، التعليقات المرتبطة باسم المؤلف، إلخ.

## **إضافة تعليق إلى الشريحة**
يعرض هذا الكود بجافا كيفية إضافة تعليق إلى شريحة في عرض PowerPoint تقديمي:
```java
// إنشاء كائن من الفئة Presentation
Presentation pres = new Presentation();
try {
    // إضافة شريحة فارغة
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // إضافة مؤلف
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // تحديد موضع التعليقات
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // إضافة تعليق شريحة لمؤلف على الشريحة 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // إضافة تعليق شريحة لمؤلف على الشريحة 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // الوصول إلى ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // عند تمرير null كمعامل، يتم جلب تعليقات جميع المؤلفين إلى الشريحة المحددة
    IComment[] Comments = slide.getSlideComments(author);

    // الوصول إلى التعليق في الفهرس 0 للشريحة 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // اختيار مجموعة تعليقات المؤلف في الفهرس 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **الوصول إلى تعليقات الشريحة**
يعرض هذا الكود بجافا كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint تقديمي:
```java
// إنشاء كائن من الفئة Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **الرد على التعليقات**
التعليق الأصلي هو التعليق الأعلى أو الأصلي في تسلسل هرمي من التعليقات أو الردود. باستخدام طريقتي [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) أو [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (من الواجهة [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment))، يمكنك تعيين أو الحصول على التعليق الأصلي.

يعرض هذا الكود بجافا كيفية إضافة تعليقات والحصول على الردود عليها:
```java
Presentation pres = new Presentation();
try {
    // يضيف تعليقًا
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // يضيف ردًا على comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // يضيف ردًا آخر على comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // يضيف ردًا إلى رد موجود
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // يعرض هيكل التعليقات الهرمي على وحدة التحكم
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // يحذف comment1 وجميع الردود عليه
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" title="انتباه" %}} 
* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) (من الواجهة [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)) لحذف تعليق، يتم أيضًا حذف الردود على ذلك التعليق.
* إذا أدى ضبط [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) إلى إشارة دائرية، سيتم إطلاق استثناء [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

## **إضافة تعليق حديث**
في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. تُحسّن ميزة التعليقات الحديثة التعاون في PowerPoint بشكل كبير. من خلال التعليقات الحديثة، يمكن لمستخدمي PowerPoint حل التعليقات، تثبيت التعليقات على الكائنات والنصوص، والتفاعل بسهولة أكبر من ذي قبل. 

يدعم Aspose.Slides التعليقات الحديثة عبر الفئة [ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment). تم إضافة الطريقتين [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) و[insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) إلى الفئة [CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection).

يعرض هذا الكود بجافا كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint تقديمي: 
```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إزالة تعليق**

### **حذف جميع التعليقات والمؤلفين**
يعرض هذا الكود بجافا كيفية إزالة جميع التعليقات والمؤلفين في عرض تقديمي:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // حذف جميع التعليقات من العرض التقديمي
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // حذف جميع المؤلفين
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


### **حذف تعليقات محددة**
يعرض هذا الكود بجافا كيفية حذف تعليقات معينة على شريحة:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة تعليقات...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // إزالة جميع التعليقات التي تحتوي على النص "comment 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides حالة مثل 'تم الحل' للتعليقات الحديثة؟**  
نعم. تُظهر [Modern comments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/) طريقة [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-); يمكنك كتابة [comment’s state](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) (على سبيل المثال، وضع علامة تم الحل)، ويتم حفظ هذه الحالة في الملف وتتعرف عليها PowerPoint.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعمق؟**  
نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/comment/#getParentComment--) الخاص به، مما يتيح سلاسل ردود غير محدودة. لا يحدد API حدًا معينًا لعمق التداخل.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**  
يُخزن الموضع كنقطة ذات قيمة عائمة في نظام إحداثيات الشريحة. يتيح لك ذلك وضع علامة التعليق بدقة في المكان المطلوب.