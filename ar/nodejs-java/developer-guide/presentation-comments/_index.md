---
title: إدارة تعليقات العروض التقديمية في Node.js
linktitle: تعليقات العرض التقديمي
type: docs
weight: 100
url: /ar/nodejs-java/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض التقديمي
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى التعليق
- تعديل تعليق
- الرد على التعليق
- إزالة تعليق
- حذف تعليق
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة تعليقات العروض التقديمية باستخدام Aspose.Slides لـ Node.js عبر Java: إضافة، قراءة، تعديل، الرد على، وإزالة التعليقات في عروض PowerPoint."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إدارة تعليقات العروض التقديمية باستخدام Aspose.Slides لـ Node.js عبر Java. تقدم الأنواع الرئيسية المتعلقة بالتعليقات وتوضح كيفية إضافة تعليقات إلى الشرائح، والوصول إلى التعليقات الموجودة، والعمل مع الردود والتعليقات الحديثة، وإزالة التعليقات من عرض تقديمي.

تغطي الأمثلة سيناريوهات المراجعة والتعاون الشائعة في PowerPoint، مثل تعيين التعليقات للمؤلفين، قراءة نص التعليق والبيانات الوصفية، بناء سلاسل الردود، وإزالة التعليقات المحددة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كتعليقات توضيحية على الشرائح. يؤدي اختيار تعليق إلى عرض نصه والنقاش المرتبط به.

لرؤية كيفية إظهار أو إخفاء التعليقات عند فتح عرض تقديمي دون تعديل التعليقات نفسها، انظر [إظهار أو إخفاء التعليقات عند فتح عرض تقديمي](/slides/ar/nodejs-java/presentation-view-properties/).

## **لماذا إضافة تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم الملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

يوفر Aspose.Slides لـ Node.js عبر Java واجهات برمجة التطبيقات التالية للعمل مع التعليقات:

* الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) التي توفر الوصول إلى مؤلفي تعليقات العرض التقديمي.
* الفئة [CommentCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/commentcollection/) التي تمثل التعليقات المرتبطة بكاتب معين.
* الفئة [Comment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/comment/) التي توفر معلومات حول التعليق، بما في ذلك مؤلفه، وقت الإنشاء، الموقع، والنص.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/commentauthor/) التي توفر معلومات عن الكاتب، بما في ذلك اسمه، الأحرف الأولى، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشريحة**

يوضح المثال التالي كيفية إضافة تعليقات إلى الشرائح في عرض PowerPoint تقديمي:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الوصول إلى تعليقات الشريحة**

يوضح المثال التالي كيفية الوصول إلى التعليقات الموجودة في عرض PowerPoint تقديمي:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **الرد على التعليقات**

التعليق الأصلي هو التعليق الأصلي في أعلى تسلسل الردود. تسمح لك طريقتا [Comment.getParentComment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/comment/getparentcomment/) و[Comment.setParentComment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/comment/setparentcomment/) بالحصول على أصل التعليق أو تعيينه.

يوضح المثال التالي كيفية إضافة ردود وفحص تسلسل التعليقات الناتج:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* عند استخدام طريقة [Comment.remove](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/comment/remove/) لحذف تعليق، يتم أيضًا حذف جميع الردود على ذلك التعليق.
* إذا أنشأت [Comment.setParentComment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/comment/setparentcomment/) مرجعًا دائريًا، يتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشريحة نفسها، أو بشكل محدد، أو بنطاق نص داخل [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/). تقبل طريقة [CommentCollection.addModernComment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) معاملًا من نوع [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/) إلى جانب إحداثيات الشريحة وعلامة التعليق.

عند تمرير `null` كقيمة للمعامل shape، يكون التعليق تعليقا على مستوى الشريحة. يتم تموضع علامته بالإحداثيات المقدمة، لكنه غير مرتبط بشكل معين، لذا تُرجع [ModernComment.getShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/getshape/) القيمة `null`. عندما يتم توفير [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/)، يتم تثبيت التعليق على ذلك الشكل. لا تزال الإحداثيات تحدد موقع علامة التعليق على الشريحة، بينما يمكن استرجاع ارتباط الشكل عبر [ModernComment.getShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/getshape/).

### **تثبيت تعليق حديث إلى شكل**

يُنشئ المثال التالي كلًا من تعليق حديث على مستوى الشريحة وتعليق حديث مثبت إلى [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) محدد. ثم يقرأ الشكل المرتبط من كل تعليق.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تثبيت التعليقات على أنواع أشكال مختلفة**

يمكن استخدام أي كائن شريحة مشتق من [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/) كمرساة شكل. تشمل الأمثلة الشائعة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/connector/)، ونسخ [GraphicalObject](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/graphicalobject/) مثل المخططات.

يُنشئ المثال التالي عدة أنواع شائعة من الأشكال ويربط تعليقا حديثًا بكل منها.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تثبيت تعليق إلى نص وتعيين حالته**

بالنسبة لتعليق حديث مرتبط بـ [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/)، تسمح طريقتا [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) و[ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) بالوصول إلى موضع البداية للنص المحدد في إطار نص الشكل. وتتيح طريقتا [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) و[ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) طول التحديد. معًا، تربط هذه القيم التعليق بنطاق نص معين داخل [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/).

توفر طريقتا [ModernComment.getStatus](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/getstatus/) و[ModernComment.setStatus](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/setstatus/) قيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncommentstatus/):
- `NotDefined` — لا يتم تعريف حالة تعليق حديث محددة.
- `Active` — التعليق نشط.
- `Resolved` — تم حل التعليق.
- `Closed` — التعليق مغلق.

يُنشئ المثال التالي تعليقًا حديثًا مثبتًا إلى شكل، ويربطه بتحديد نص، ويضع علامة بأنه تم حله، ثم يحفظ العرض التقديمي، ويتحقق من القيم بعد إعادة فتح الملف.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **فحص التعليقات الحديثة الموجودة**

لفحص عرض تقديمي موجود، تحقق من أي التعليقات هي مثيلات [ModernComment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/)، ثم فحص [ModernComment.getShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), و[ModernComment.getStatus](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/getstatus/). يشير الشكل `null` إلى تعليق على مستوى الشريحة. بالنسبة لمرساة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/)، تحدد طرق اختيار النص النطاق المرتبط في إطار نص الشكل.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **إزالة التعليقات**

### **إزالة جميع التعليقات ومؤلفي التعليقات**

يوضح المثال التالي كيفية إزالة جميع التعليقات ومؤلفي التعليقات من عرض تقديمي:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **إزالة تعليقات محددة**

يوضح المثال التالي كيفية إزالة تعليقات محددة من شريحة:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides حالة حل للتعليقات الحديثة؟**

نعم. تُتيح [ModernComment.getStatus](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/getstatus/) و[ModernComment.setStatus](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncomment/setstatus/) الوصول إلى قيمة من [ModernCommentStatus](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/moderncommentstatus/)، بما في ذلك `Resolved`. يتم تخزين الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود)، وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [التعليق الأصلي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/comment/getparentcomment/)، مما يتيح سلاسل الردود. لا تحدد واجهة البرمجة حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تحديد موضع علامة التعليق على الشريحة؟**

يتم تعريف موضع العلامة بواسطة إحداثيات ذات فاصلة عائمة في نظام إحداثيات الشريحة، مما يتيح لك وضعها بدقة على الشريحة.