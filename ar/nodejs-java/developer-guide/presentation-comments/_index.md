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
- تعليقات العرض
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى التعليق
- تحرير التعليق
- الرد على التعليق
- إزالة التعليق
- حذف التعليق
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة تعليقات العروض التقديمية باستخدام Aspose.Slides لـ Node.js عبر Java: إضافة، قراءة، تحرير، الرد على، وإزالة التعليقات في عروض PowerPoint."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إدارة تعليقات العروض التقديمية باستخدام Aspose.Slides for Node.js عبر Java. وهي تقدم الأنواع الرئيسية المتعلقة بالتعليقات وتظهر كيفية إضافة تعليقات إلى الشرائح، والوصول إلى التعليقات الموجودة، والعمل مع الردود والتعليقات الحديثة، وإزالة التعليقات من العرض التقديمي.

تغطي الأمثلة سيناريوهات المراجعة والتعاون الشائعة في PowerPoint، مثل تعيين التعليقات إلى المؤلفين، وقراءة نص التعليق والبيانات الوصفية، وبناء سلاسل الردود، وإزالة التعليقات المحددة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كحواشي على الشرائح. عند تحديد تعليق يتم عرض نصه والنقاش المتعلق به.

لطلب إظهار أو إخفاء التعليقات عند فتح العرض التقديمي دون تغيير التعليقات نفسها، انظر [إظهار أو إخفاء التعليقات عند فتح العرض التقديمي](/slides/ar/nodejs-java/presentation-view-properties/).

## **لماذا إضافة تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم الملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

توفر Aspose.Slides for Node.js via Java واجهات برمجة التطبيقات التالية للعمل مع التعليقات:

* الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) التي توفر الوصول إلى مؤلفي تعليقات العرض.
* الفئة [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) التي تمثل التعليقات المرتبطة بمؤلف فردي.
* الفئة [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) التي توفر معلومات عن التعليق، بما في ذلك المؤلف، وقت الإنشاء، الموضع، والنص.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) التي توفر معلومات عن المؤلف، بما في ذلك اسمه، الحروف الأولى، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشرائح**

يقوم المثال بإنشاء شريحتين وتسجيل مؤلف تعليق باستخدام [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/). يستخدم [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) لوضع تعليق واحد على كل شريحة، ثم يسترجع تعليقات الشريحة الأولى لذلك المؤلف باستخدام [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/). تعرض وحدة التحكم نص التعليق الأول مرتين، تُظهر الوصول عبر كل من الشريحة والمؤلف، وتحتوي العرض المحفوظ على كلا التعليقين.

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

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **البحث أو إنشاء مؤلف تعليق**

عند معالجة مراجعة تلقائية للعرض نفسه بشكل متكرر، ابحث في المجموعة التي تُرجعها [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) قبل إضافة مؤلف. تتطابق [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) مع كل من الاسم والحروف الأولى وتُرجع مصفوفة من المؤلفين المطابقين، أو مصفوفة فارغة إذا لم توجد مطابقة. بالمقابل، تبحث [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) بالاسم فقط، بغض النظر عن الحروف الأولى. عند استدعاء [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) باسم وحروف أولى موجودين بالفعل في المجموعة فإنها تُطلق استثناءً.

يتطلب المثال ملف عرض يحتوي على شريحة واحدة على الأقل. في كل من المرورين، يعيد استخدام المؤلف المطابق الأول، أو ينشئ واحدًا فقط عندما تكون النتيجة فارغة. إذا كان هناك عدة مطابقات، يختار العنصر الأول في المصفوفة دون دمج أو إزالة المؤلفين الآخرين. ثم يستدعي [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) للمؤلف المختار ويحفظ العرض. يفتح المرور الثاني ناتج المرور الأول ويكرر العملية.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

يضيف المرور الثاني تعليقًا آخر دون إضافة مؤلف آخر أو إزالة تعليقات موجودة. يحتوي الملف النهائي `review_pass_2.pptx` على كلا التعليقين الجديدين إلى جانب أي تعليقات أصلية. إعادة استخدام المؤلف لا تُزيل التكرارات: لتجنب إضافة التعليق نفسه مرارًا، نفّذ كشف التكرارات بشكل منفصل قبل إضافته.

## **الوصول إلى تعليقات الشرائح**

يفتح المثال عرضًا موجودًا ويقرأ المجموعة التي تُرجعها [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/). لكل مؤلف، يتنقل عبر المجموعة التي تُرجعها [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) ويطبع رقم الشريحة، نص التعليق، اسم المؤلف، ووقت الإنشاء. يجب أن يحتوي عرض الإدخال على تعليقات للحصول على مخرجات وحدة التحكم.

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

التعليق الأصلي هو التعليق الأصلي في قمة هيكل الردود. تسمح طريقتا [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) و[Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) بالحصول على أصل التعليق أو تعيينه.

ينشئ المثال تعليقات من مؤلفين اثنين ويستخدم [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) لبناء الردود، بما في ذلك رد على رد آخر. تمرير `null` إلى [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) يسترجع تعليقات جميع المؤلفين؛ تُفرغ وحدة التحكم كل إدخال وفق عمقه في هيكل الرد. يحفظ المثال النقاش بالكامل، يستدعي [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) على التعليق الجذري الأول، ويحفظ عرضًا ثانيًا مع إزالة ذلك التعليق وردوده.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* عند استخدام طريقة [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) لحذف تعليق، تُحذف جميع الردود على ذلك التعليق.
* إذا أنشأت [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) إشارة دائرية، يُطلق استثناء [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشريحة نفسها، أو بشكل محدد، أو بنطاق نص داخل AutoShape. تقبل طريقة [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) وسيلة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) بالإضافة إلى إحداثيات الشريحة ومُؤشر التعليق.

عند تمرير `null` كقيمة للوسيلة الشكل، يكون التعليق تعليقا على مستوى الشريحة. تُحدَّد موضع العلامة بالإحداثيات المُزودة، لكنه غير مرتبط بشكل معين، لذا تُعيد [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) `null`. عند تزويد [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)، يُربط التعليق بذلك الشكل. لا تزال الإحداثيات تُحدِّد موضع علامة التعليق على الشريحة، ويمكن استرجاع ارتباط الشكل عبر [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/).

### **تثبيت تعليق حديث إلى شكل**

يستدعي المثال [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) مرتين: مرة مع شكل `null` لتعليق على مستوى الشريحة ومرة أخرى مع مستطيل كمرساة. قراءة [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) تُطبع `true` للتحقق من وجود `null` في تعليل الشريحة و`Revenue title` للتعليق المرتبط. يتم حفظ كلا التعليقين مع العرض.

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

### **تثبيت التعليقات إلى أنواع أشكال مختلفة**

يمكن استخدام أي كائن شريحة مشتق من [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) كمرساة لل shape. تشمل الأمثلة الشائعة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/)، و[GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) مثل المخططات.

يستخدم المثال [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) لربط تعليق مع كل من الأنواع الخمسة للأشكال: AutoShape، إطار صورة، مجموعة، موصل، ومخطط. تستخدم الصورة بيانات صورة مدمجة، لذا لا يلزم صورة خارجية. لكل تعليق موضع علامة خاص به، ويحافظ العرض المحفوظ على جميع ارتباطات الأشكال الخمسة.

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

بالنسبة لتعليق حديث مرتبط بـ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)، تُتيح [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) و[ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) الوصول إلى موضع بداية النص المُختار في إطار نص الشكل. تُتيح [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) و[ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) الوصول إلى طول الاختيار. معًا، تُربط هذه القيم التعليق بنطاق نص محدد داخل AutoShape.

تُتيح طريقتا [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) و[ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) الحصول على قيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — لا يتم تعريف حالة حديثة معينة.
- `Active` — التعليق نشط.
- `Resolved` — تم حل التعليق.
- `Closed` — التعليق مُغلق.

يقوم المثال بربط تعليق حديث بالكلمات "quarterly revenue" في نص المستطيل. يحسب موضع البداية الصفري من النص ويمرره إلى [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) ويستخدم [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) لتعيين عدد الأحرف المحددة. بعد استدعاء [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) مع `Resolved`، يحفظ ويعيد فتح العرض. يجب أن تُظهر الفحوصات الأربعة في وحدة التحكم `true`، لتأكيد حفظ ارتباط الشكل، ونطاق النص، والحالة.

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
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

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

يتطلب المثال عرضًا موجودًا يحتوي على تعليقات حديثة ويطبع نصها، حالتها، وتفاصيل الارتباط. لفحصه، تحقق من أي تعليقات هي مثيلات [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/)، ثم استعرض [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)، [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/)، [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/)، و[ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/). يشير الشكل `null` إلى تعليق على مستوى الشريحة. بالنسبة لارتباط [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)، تحدد طرق اختيار النص النطاق المرتبط في إطار نص الشكل.

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

تمكنك Aspose.Slides for Node.js via Java من إزالة جميع التعليقات ومؤلفيها من العرض أو حذف تعليقات مختارة مع الحفاظ على البقية. توضح الأمثلة التالية كلا النهجين وتحفظ العرض المحدّث.

### **إزالة جميع التعليقات ومؤلفي التعليقات**

يفتح المثال عرضًا موجودًا ويستدعي [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) لكل مؤلف، ثم يستدعي [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) لإزالة المؤلفين أنفسهم. لا يحتوي العرض المحفوظ على أي تعليقات أو مؤلفي تعليقات. استخدم عرضًا يحتوي على تعليقات لملاحظة الإزالة.

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

ينشئ المثال تعليقين على شريحة واحدة ويستخدم [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) للعثور على التعليقات لكل مؤلف. يجمع التعليقات التي نصها يساوي "comment 1" قبل استدعاء [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/)، لتجنب تعديل المجموعة أثناء الاختيار. يحتفظ العرض المحفوظ فقط بـ "comment 2".

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

**هل تدعم Aspose.Slides حالة "تم الحل" للتعليقات الحديثة؟**

نعم. تُتيح [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) و[ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) الوصول إلى قيمة من تعداد [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) تشمل `Resolved`. تُحفظ الحالة في العرض ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل يتم دعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/)، مما يتيح سلاسل الردود. لا تحدد الواجهة حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يُحدد موضع علامة التعليق على الشريحة؟**

يُحدد موضع العلامة بإحداثيات ذات نقطة عائمة ضمن نظام إحداثيات الشريحة، مما يتيح وضعه بدقة على الشريحة.