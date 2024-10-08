---
title: تعليقات العرض
type: docs
weight: 100
url: /ar/androidjava/presentation-comments/
keywords: "تعليقات, تعليقات باوربوينت, عرض باوربوينت, جافا, Aspose.Slides لـ Android عبر جافا"
description: "إضافة تعليقات وردود في عرض باوربوينت باستخدام جافا"
---

في باوربوينت، تظهر التعليقات كملحوظات أو تعليقات على الشريحة. عندما يتم النقر على تعليق، تظهر محتوياته أو رسائله.

### **لماذا إضافة تعليقات إلى العروض؟**

قد ترغب في استخدام التعليقات لتقديم ملاحظات أو التواصل مع زملائك عند مراجعة العروض.

لتمكينك من استخدام التعليقات في عروض باوربوينت، توفر Aspose.Slides لـ Android عبر جافا

* فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)، التي تحتوي على مجموعات المؤلفين (من واجهة [ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection)). يقوم المؤلفون بإضافة التعليقات إلى الشرائح.
* واجهة [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection)، التي تحتوي على مجموعة من التعليقات لكل مؤلف فردي.
* فئة [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)، التي تحتوي على معلومات حول المؤلفين وتعليقاتهم: من أضاف التعليق، الوقت الذي أضيف فيه التعليق، موقع التعليق، إلخ.
* فئة [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor)، التي تحتوي على معلومات عن المؤلفين الفرديين: اسم المؤلف، الأحرف الأولى، التعليقات المرتبطة باسم المؤلف، إلخ.

## **إضافة تعليق على الشريحة**
يظهر هذا الكود بلغة جافا كيفية إضافة تعليق إلى شريحة في عرض باوربوينت:

```java
// ينشئ مثيل لفئة Presentation
Presentation pres = new Presentation();
try {
    // يضيف شريحة فارغة
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // يضيف مؤلفًا
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // يحدد الموقع للتعليقات
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // يضيف تعليق شريحة لمؤلف على الشريحة 1
    author.getComments().addComment("مرحبًا يا جواد، هذا هو تعليق الشريحة", pres.getSlides().get_Item(0), point, new Date());

    // يضيف تعليق شريحة لمؤلف على الشريحة 2
    author.getComments().addComment("مرحبًا يا جواد، هذا هو تعليق الشريحة الثانية", pres.getSlides().get_Item(1), point, new Date());

    // يصل إلى ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // عند تمرير null كوسيلة، يتم جلب التعليقات من جميع المؤلفين إلى الشريحة المحددة
    IComment[] Comments = slide.getSlideComments(author);

    // يصل إلى التعليق في الفهرس 0 لشريحة 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // يحدد مجموعة تعليقات المؤلف في الفهرس 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى تعليقات الشريحة**
يظهر هذا الكود بلغة جافا كيفية الوصول إلى تعليق موجود على شريحة في عرض باوربوينت:

```java
// ينشئ مثيل لفئة Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " لديه تعليق: " + comment.getText() +
                    " مع المؤلف: " + comment.getAuthor().getName() + " تم نشره في الوقت :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ردود التعليقات**
التعليق الرئيسي هو التعليق الأعلى أو الأصلي في تسلسل هرمي من التعليقات أو الردود. باستخدام طرق [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) أو [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (من واجهة [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment))، يمكنك تعيين أو الحصول على تعليق رئيسي.

يظهر هذا الكود بلغة جافا كيفية إضافة التعليقات والحصول على الردود عليها:

```java
Presentation pres = new Presentation();
try {
    // يضيف تعليقًا
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // يضيف ردًا على comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("رد 1 على التعليق 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // يضيف ردًا آخر على comment1
    IComment reply2 = author2.getComments().addComment("رد 2 على التعليق 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // يضيف ردًا على رد موجود
    IComment subReply = author1.getComments().addComment("رد فرعي 3 على الرد 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("رد 4 على التعليق 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // يعرض تسلسل التعليقات على وحدة التحكم
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

    // يزيل comment1 وجميع الردود عليه
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="تنبيه" %}} 

* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) (من واجهة [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)) لحذف تعليق، يتم أيضًا حذف الردود على التعليق.
* إذا كانت إعدادات [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) تؤدي إلى مرجع دائري، سيتم طرح [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت مايكروسوفت *التعليقات الحديثة* في باوربوينت. تحسن ميزة التعليقات الحديثة بشكل كبير التعاون في باوربوينت. من خلال التعليقات الحديثة، يتمكن مستخدمو باوربوينت من حل التعليقات، ربط التعليقات بالأشياء والنصوص، والانخراط في التفاعلات بسهولة أكبر من قبل.

في [Aspose Slides لـ Java 21.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-11-release-notes/)، قمنا بتنفيذ دعم التعليقات الحديثة من خلال إضافة فئة [ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment). تم إضافة طرق [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) و [insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) إلى فئة [CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection).

يظهر هذا الكود بلغة جافا كيفية إضافة تعليق حديث إلى شريحة في عرض باوربوينت: 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("هذا هو تعليق حديث", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة تعليق**

### **حذف جميع التعليقات والمؤلفين**

يظهر هذا الكود بلغة جافا كيفية إزالة جميع التعليقات والمؤلفين في عرض تقديمي:

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

يظهر هذا الكود بلغة جافا كيفية حذف تعليقات محددة على شريحة:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة التعليقات...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // إزالة جميع التعليقات التي تحتوي على نص "comment 1"
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