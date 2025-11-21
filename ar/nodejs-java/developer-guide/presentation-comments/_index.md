---
title: "تعليقات العرض التقديمي"
type: docs
weight: 100
url: /ar/nodejs-java/presentation-comments/
keywords: "تعليقات, تعليقات PowerPoint, عرض PowerPoint, Java, Aspose.Slides for Node.js عبر Java"
description: "إضافة التعليقات والردود في عرض PowerPoint باستخدام JavaScript"
---

في PowerPoint، يظهر التعليق كملاحظة أو توضيح على الشريحة. عند النقر على التعليق، يتم إظهار محتواه أو رسائله. 

## **لماذا نضيف تعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتقديم الملاحظات أو التواصل مع زملائك عند مراجعة العروض التقديمية.

لسماح لك باستخدام التعليقات في عروض PowerPoint التقديمية، يقدم Aspose.Slides for Node.js via Java

* الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تحتوي على مجموعات المؤلفين (من الفئة [CommentAuthorCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthorCollection)). يضيف المؤلفون التعليقات إلى الشرائح.
* الفئة [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) التي تحتوي على مجموعة التعليقات للمؤلفين الفرديين.
* الفئة [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) التي تحتوي على معلومات حول المؤلفين وتعليقاتهم: من أضاف التعليق، وقت إضافة التعليق، موضع التعليق، إلخ.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthor) التي تحتوي على معلومات حول المؤلفين الفرديين: اسم المؤلف، الأحرف الأولى له، التعليقات المرتبطة باسم المؤلف، إلخ.

## **إضافة تعليق إلى الشريحة**
يظهر لك هذا الكود JavaScript كيفية إضافة تعليق إلى شريحة في عرض PowerPoint تقديمي:
```javascript
// ينشئ فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // يضيف شريحة فارغة
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // يضيف مؤلفًا
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // يحدد موضع التعليقات
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // يضيف تعليق شريحة لمؤلف على الشريحة 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // يضيف تعليق شريحة لمؤلف على الشريحة 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // يصل إلى ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // عند تمرير null كوسيطة، تُجلب التعليقات من جميع المؤلفين إلى الشريحة المحددة
    var Comments = slide.getSlideComments(author);
    // يحصل على التعليق عند الفهرس 0 للشريحة 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // يحدد مجموعة تعليقات المؤلف عند الفهرس 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الوصول إلى تعليقات الشريحة**
يظهر لك هذا الكود JavaScript كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint تقديمي:
```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```



## **الرد على التعليقات**
التعليق الأصلي هو التعليق العلوي أو الأصلي في هيكلية التعليقات أو الردود. باستخدام طريقتي [getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#getParentComment--) أو [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (من الفئة [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment))، يمكنك تعيين أو الحصول على التعليق الأصلي.

يظهر لك هذا الكود JavaScript كيفية إضافة تعليقات والحصول على الردود عليها:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف تعليقاً
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // يضيف ردًا على التعليق 1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // يضيف ردًا آخر على التعليق 1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // يضيف ردًا على رد موجود
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // يعرض هيكلية التعليقات في وحدة التحكم
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // يزيل التعليق 1 وجميع الردود عليه
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" title="Attention" %}} 

* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#remove--) (من الفئة [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment)) لحذف تعليق، يتم حذف الردود على التعليق أيضًا.
* إذا أدى تعيين [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) إلى إشارة دائرية، فسيتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. تُحسّن ميزة التعليقات الحديثة كثيرًا من التعاون في PowerPoint. من خلال التعليقات الحديثة، يتمكن مستخدمو PowerPoint من حل التعليقات، ربط التعليقات بالأشياء والنصوص، والتفاعل بسهولة أكبر من ذي قبل. 

في [Aspose.Slides for Node.js via Java 21.11](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-11-release-notes/)، نفّذنا دعم التعليقات الحديثة بإضافة الفئة [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ModernComment). تم إضافة طريقتي [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) و[insertModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) إلى الفئة [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection).

يظهر لك هذا الكود JavaScript كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint تقديمي:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إزالة التعليق**

### **حذف جميع التعليقات والمؤلفين**

يظهر لك هذا الكود JavaScript كيفية إزالة جميع التعليقات والمؤلفين في عرض تقديمي:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // يحذف جميع التعليقات من العرض التقديمي
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // يحذف جميع المؤلفين
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


### **حذف تعليقات محددة**

يظهر لك هذا الكود JavaScript كيفية حذف تعليقات محددة على شريحة:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // إضافة تعليقات...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // إزالة جميع التعليقات التي تحتوي على نص "comment 1"
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**هل يدعم Aspose.Slides حالة مثل 'تم الحل' للتعليقات الحديثة؟**

نعم. تُظهر [Modern comments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) طرقًا [getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) و[setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setStatus/)؛ يمكنك قراءة حالة التعليق وتعيينها (مثلاً، تحديده كـ 'تم الحل')، وتُحفظ هذه الحالة في الملف ويُعترف بها من قبل PowerPoint.

**هل تُدعم المناقشات المتسلسلة (سلاسل الردود)، وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/)، مما يتيح سلاسل ردود غير محدودة. لا يُعلن API عن حد معين لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يتم تخزين الموضع كنقطة ذات قيمة عائمة في نظام إحداثيات الشريحة. يتيح لك ذلك وضع علامة التعليق بدقة في المكان المطلوب.