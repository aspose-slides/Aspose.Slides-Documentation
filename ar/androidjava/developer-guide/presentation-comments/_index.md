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
- تعليقات العرض
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى التعليق
- تحرير تعليق
- الرد على التعليق
- إزالة التعليق
- حذف التعليق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحكم كامل في تعليقات العروض التقديمية باستخدام Aspose.Slides لأندرويد عبر جافا: أضف، اقرأ، حرّر، واحذف التعليقات في ملفات PowerPoint بسرعة وسهولة."
---

في PowerPoint، يظهر التعليق كملاحظة أو توضيح على الشريحة. عند النقر على التعليق، تُكشف محتوياته أو رسائله.

### **لماذا نضيف تعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم الملاحظات أو التواصل مع زملائك عند مراجعة العروض التقديمية.

لتتيح لك استخدام التعليقات في عروض PowerPoint التقديمية، توفر Aspose.Slides for Android via Java ما يلي:

* فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي تحتوي على مجموعات المؤلفين (من واجهة [ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection)). يضيف المؤلفون تعليقات إلى الشرائح.
* واجهة [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection) التي تحتوي على مجموعة التعليقات لكل مؤلف.
* فئة [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) التي تحتوي على معلومات عن المؤلفين وتعليقاتهم: من أضاف التعليق، وقت إضافة التعليق، موقع التعليق، إلخ.
* فئة [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor) التي تحتوي على معلومات عن كل مؤلف: اسم المؤلف، الأحرف الأولى له، التعليقات المرتبطة باسمه، إلخ.

## **إضافة تعليق إلى شريحة**
يعرض هذا الكود بلغة Java كيفية إضافة تعليق إلى شريحة في عرض PowerPoint:
```java
// إنشاء كائن من فئة Presentation
Presentation pres = new Presentation();
try {
    // إضافة شريحة فارغة
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // إضافة مؤلف
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // تعيين موقع التعليقات
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // إضافة تعليق شريحة لمؤلف على الشريحة 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // إضافة تعليق شريحة لمؤلف على الشريحة 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // الوصول إلى ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // عند تمرير null كوسيطة، تُجلب التعليقات من جميع المؤلفين إلى الشريحة المختارة
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
يعرض هذا الكود بلغة Java كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint:
```java
// إنشاء كائن من فئة Presentation
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
التعليق الأصلي هو أعلى أو أول تعليق في تسلسل هرمي من التعليقات أو الردود. باستخدام طريقتي [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) أو [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (من واجهة [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment))، يمكنك تعيين أو الحصول على التعليق الأصلي.

يعرض هذا الكود بلغة Java كيفية إضافة تعليقات والحصول على الردود عليها:
```java
Presentation pres = new Presentation();
try {
    // إضافة تعليق
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // إضافة رد على التعليق 1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // إضافة رد آخر على التعليق 1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // إضافة رد على رد موجود
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // عرض تسلسل التعليقات الهرمي على وحدة التحكم
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

    // إزالة التعليق 1 وجميع الردود عليه
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" title="انتباه" %}} 

* عندما تُستخدم طريقة [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) (من واجهة [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)) لحذف تعليق، تُحذف الردود على التعليق أيضًا.
* إذا أدى إعداد [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) إلى إشارة دائرية، سيتم طرح استثناء [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. يحسن ميزة التعليقات الحديثة بشكل كبير التعاون في PowerPoint. من خلال التعليقات الحديثة، يحصل مستخدمو PowerPoint على إمكانية حل التعليقات، ربط التعليقات بالكائنات والنصوص، والتفاعل بسهولة أكبر مما كان من قبل.

في [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-11-release-notes/)، نفذنا دعم التعليقات الحديثة بإضافة فئة [ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment). تم إضافة الطريقتين [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) و [insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) إلى فئة [CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection).

يعرض هذا الكود بلغة Java كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint:
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

يعرض هذا الكود بلغة Java كيفية حذف جميع التعليقات والمؤلفين في عرض تقديمي:
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

يعرض هذا الكود بلغة Java كيفية حذف تعليقات محددة على شريحة:
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


## **الأسئلة الشائعة**

**هل تدعم Aspose.Slides حالة مثل "تم الحل" للتعليقات الحديثة؟**

نعم. تعرض [Modern comments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/) طريقة [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-); يمكنك تعيين حالة التعليق (مثلاً، وضع علامة "تم الحل")، ويتم حفظ هذه الحالة في الملف وتتعرف عليها PowerPoint.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود)، وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/comment/#getParentComment--) الخاص به، مما يتيح سلاسل ردود غير محدودة. لا تحدد الواجهة حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يتم تخزين الموضع كنقطة ذات قيمة عائمة في نظام إحداثيات الشريحة. يتيح لك ذلك وضع علامة التعليق بدقة في المكان الذي تريده.