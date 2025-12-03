---
title: إدارة تعليقات العرض التقديمي في Java
linktitle: تعليقات العرض التقديمي
type: docs
weight: 100
url: /ar/java/presentation-comments/
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
- OpenDocument
- العرض التقديمي
- Java
- Aspose.Slides
description: "تحكم في تعليقات العروض التقديمية باستخدام Aspose.Slides for Java: أضف، اقرأ، حرر، واحذف التعليقات في ملفات PowerPoint بسرعة وسهولة."
---

في PowerPoint، يظهر التعليق كملاحظة أو توضيح على الشريحة. عند النقر على التعليق، تظهر محتوياته أو رسائله.

## **لماذا نضيف التعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض التقديمية.

لتمكينك من استخدام التعليقات في عروض PowerPoint التقديمية، توفر Aspose.Slides for Java

* الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على مجموعات المؤلفين (من واجهة [ICommentAuthorCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentAuthorCollection)). يضيف المؤلفون التعليقات إلى الشرائح. 
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentCollection) التي تحتوي على مجموعة التعليقات للمؤلفين الفرديين. 
* الفئة [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment) التي تحتوي على معلومات عن المؤلفين وتعليقاتهم: من الذي أضاف التعليق، وقت إضافة التعليق، موقع التعليق، إلخ. 
* الفئة [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/CommentAuthor) التي تحتوي على معلومات عن المؤلفين الفرديين: اسم المؤلف، مختصراته، التعليقات المرتبطة باسم المؤلف، إلخ. 

## **إضافة تعليقات إلى الشريحة**
يعرض لك هذا الكود Java كيفية إضافة تعليق إلى شريحة في عرض PowerPoint التقديمي:
```java
// يُنشئ كائن من الفئة Presentation
Presentation pres = new Presentation();
try {
    // يضيف شريحة فارغة
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // يضيف مؤلفًا
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // يحدد موضع التعليقات
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // يضيف تعليق شريحة لمؤلف على الشريحة 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // يضيف تعليق شريحة لمؤلف على الشريحة 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // الوصول إلى ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // عند تمرير null كوسيلة، يتم جلب التعليقات من جميع المؤلفين إلى الشريحة المحددة
    IComment[] Comments = slide.getSlideComments(author);

    // الوصول إلى التعليق في الفهرس 0 للشريحة 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // يختار مجموعة تعليقات المؤلف في الفهرس 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **الوصول إلى تعليقات الشريحة**
يعرض لك هذا الكود Java كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint التقديمي:
```java
// ينشئ كائن من الفئة Presentation
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
التعليق الأصلي هو التعليق العلوي أو الأصلي في تسلسل هرمي من التعليقات أو الردود. باستخدام طريقتي [getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#getParentComment--) أو [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (من الواجهة [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment))، يمكنك تعيين أو الحصول على تعليق أصلي. 

يعرض لك هذا الكود Java كيفية إضافة تعليقات والحصول على الردود عليها:
```java
Presentation pres = new Presentation();
try {
    // يضيف تعليقًا
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // يضيف ردًا على التعليق 1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // يضيف ردًا آخر على التعليق 1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // يضيف ردًا على رد موجود
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // يعرض تسلسل التعليقات الهرمي على الشاشة
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

    // يحذف التعليق 1 وجميع الردود عليه
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" title="Attention" %}} 

* عندما تُستخدم طريقة [Remove](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#remove--) (من الواجهة [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment)) لحذف تعليق، يتم حذف الردود على التعليق أيضًا. 
* إذا أدّى ضبط [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) إلى إشارة دائرية، سيتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException).

{{% /alert %}}

## **إضافة تعليقات حديثة**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. تُحسّن ميزة التعليقات الحديثة بشكل كبير التعاون في PowerPoint. من خلال التعليقات الحديثة، يحصل مستخدمو PowerPoint على القدرة على حل التعليقات، ربط التعليقات بالكائنات والنصوص، والتفاعل بسهولة أكبر مقارنةً بالسابق. 

في [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-11-release-notes/)، نفّذنا دعم التعليقات الحديثة بإضافة الفئة [ModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/ModernComment). أُضيفت الطريقتان [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) و[insertModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) إلى الفئة [CommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection). 

يعرض لك هذا الكود Java كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint التقديمي: 
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


## **إزالة التعليقات**

### **حذف جميع التعليقات والمؤلفين**

يعرض لك هذا الكود Java كيفية إزالة جميع التعليقات والمؤلفين في عرض تقديمي:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // يحذف جميع التعليقات من العرض التقديمي
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // يحذف جميع المؤلفين
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


### **حذف تعليقات محددة**

يعرض لك هذا الكود Java كيفية حذف تعليقات محددة على شريحة:
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

**هل يدعم Aspose.Slides حالة مثل 'تم الحل' للتعليقات الحديثة؟**

نعم. تُظهر [Modern comments](https://reference.aspose.com/slides/java/com.aspose.slides/moderncomment/) طريقة [setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncomment/#setStatus-byte-)؛ يمكنك تحديد حالة [comment’s state](https://reference.aspose.com/slides/java/com.aspose.slides/moderncommentstatus/) (مثلاً، وضع علامة تم الحل)، ويتم حفظ هذه الحالة في الملف ويتم التعرف عليها من قبل PowerPoint.

**هل يتم دعم المناقشات المتسلسلة (سلاسل الرد) وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/java/com.aspose.slides/comment/#getParentComment--)، مما يتيح سلاسل رد غير محدودة. لا يحدد API حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يتم تخزين الموضع كنقطة ذات فاصلة عائمة في نظام إحداثيات الشريحة. يتيح لك ذلك وضع علامة التعليق بدقة في المكان الذي تحتاجه.