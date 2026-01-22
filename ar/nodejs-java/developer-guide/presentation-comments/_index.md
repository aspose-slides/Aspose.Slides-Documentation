---
title: إدارة تعليقات العرض في JavaScript
linktitle: تعليقات العرض
type: docs
weight: 100
url: /ar/nodejs-java/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى التعليق
- تحرير التعليق
- الرد على التعليق
- إزالة التعليق
- حذف التعليق
- PowerPoint
- OpenDocument
- عرض
- Node.js
- JavaScript
- Aspose.Slides
description: "إتقان تعليقات العروض باستخدام Aspose.Slides لـ Node.js: إضافة، قراءة، تعديل وحذف التعليقات في ملفات PowerPoint باستخدام JavaScript بسرعة وسهولة."
---

في PowerPoint، يظهر التعليق كملاحظة أو توضيح على الشريحة. عند النقر على التعليق، يتم كشف محتوياته أو رسائله. 

## **لماذا إضافة تعليقات إلى العروض التقديمية؟**

قد ترغب في استخدام التعليقات لتوفير ملاحظات أو للتواصل مع زملائك عند مراجعة العروض التقديمية.

لتمكينك من استخدام التعليقات في عروض PowerPoint، تقدم Aspose.Slides for Node.js via Java

* الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تحتوي على مجموعات المؤلفين (من الفئة [CommentAuthorCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthorCollection)). يضيف المؤلفون تعليقات إلى الشرائح.
* الفئة [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) التي تحتوي على مجموعة التعليقات لكل مؤلف.
* الفئة [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) التي تحتوي على معلومات حول المؤلفين وتعليقاتهم: من أضاف التعليق، وقت إضافة التعليق، موقع التعليق، إلخ.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthor) التي تحتوي على معلومات حول كل مؤلف: اسم المؤلف، الأحرف الأولى له، التعليقات المرتبطة باسمه، إلخ.

## **إضافة تعليق إلى الشريحة**
هذا الكود JavaScript يوضح كيفية إضافة تعليق إلى شريحة في عرض PowerPoint:
```javascript
// إنشاء كائن الفئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // إضافة شريحة فارغة
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // إضافة مؤلف
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // تعيين موضع التعليقات
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // إضافة تعليق شريحة لمؤلف على الشريحة 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // إضافة تعليق شريحة لمؤلف على الشريحة 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // الوصول إلى ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // عند تمرير قيمة null كمعامل، يتم جلب التعليقات من جميع المؤلفين إلى الشريحة المحددة
    var Comments = slide.getSlideComments(author);
    // الوصول إلى التعليق في الفهرس 0 للشريحة 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // اختيار مجموعة تعليقات المؤلف في الفهرس 0
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
هذا الكود JavaScript يوضح كيفية الوصول إلى تعليق موجود على شريحة في عرض PowerPoint:
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
التعليق الأصل هو التعليق الأعلى أو الأولي في تسلسل التعليقات أو الردود. باستخدام الطريقة [getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#getParentComment--) أو الطريقة [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (من الفئة [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment))، يمكنك ضبط أو الحصول على التعليق الأصل.

هذا الكود JavaScript يوضح كيفية إضافة تعليقات والحصول على الردود عليها:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف تعليقًا
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
    // يعرض شجرة التعليقات على وحدة التحكم
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


{{% alert color="warning" title="انتباه" %}} 

* عند استخدام طريقة [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#remove--) (من الفئة [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment)) لحذف تعليق، يتم أيضًا حذف الردود على التعليق.
* إذا أدت إعدادات [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) إلى إشارة دائرية، سيتم طرح استثناء [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **إضافة تعليق حديث**

في عام 2021، قدمت Microsoft *التعليقات الحديثة* في PowerPoint. تحسّن ميزة التعليقات الحديثة التعاون بشكل كبير في PowerPoint. من خلال التعليقات الحديثة، يتمكن مستخدمو PowerPoint من حل التعليقات، ربط التعليقات بالكائنات والنصوص، والتفاعل بشكل أسهل بكثير مما كان عليه سابقًا. 

تدعم Aspose.Slides التعليقات الحديثة عبر الفئة [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ModernComment). تم إضافة الطريقتين [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) و [insertModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) إلى الفئة [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection).

هذا الكود JavaScript يوضح كيفية إضافة تعليق حديث إلى شريحة في عرض PowerPoint:
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

هذا الكود JavaScript يوضح كيفية حذف جميع التعليقات والمؤلفين في عرض تقديمي:
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


### **حذف تعليقات معينة**

هذا الكود JavaScript يوضح كيفية حذف تعليقات محددة على شريحة:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // إضافة تعليقات...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // إزالة جميع التعليقات التي تحتوي على النص "comment 1"
    
    
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


## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides حالة مثل 'تم الحل' للتعليقات الحديثة؟**

نعم. توفر [التعليقات الحديثة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) طريقة [getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) وطريقة [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setStatus/)؛ يمكنك قراءة وتعيين حالة التعليق (على سبيل المثال، وضع علامة تم الحل)، ويتم حفظ هذه الحالة في الملف وتتعرف عليها PowerPoint.

**هل يتم دعم المناقشات المتسلسلة (سلاسل الردود)، وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [التعليق الأصلي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/)، مما يسمح بسلاسل ردود غير محدودة. لا تحدد API حدًا محددًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يُخزن الموضع كنقطة ذات قيمة عائمة في نظام إحداثيات الشريحة. يتيح لك ذلك وضع علامة التعليق بدقة في المكان الذي تحتاجه.