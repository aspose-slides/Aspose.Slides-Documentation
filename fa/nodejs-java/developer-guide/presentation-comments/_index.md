---
title: مدیریت نظرات ارائه در Node.js
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/nodejs-java/presentation-comments/
keywords:
- نظر
- نظر مدرن
- نظرات PowerPoint
- نظرات ارائه
- نظرات اسلاید
- افزودن نظر
- دسترسی به نظر
- ویرایش نظر
- پاسخ به نظر
- حذف نظر
- پاک کردن نظر
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت نظرات ارائه با Aspose.Slides برای Node.js از طریق Java: افزودن، خواندن، ویرایش، پاسخ به و حذف نظرات در ارائه‌های PowerPoint."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که چگونه نظرات ارائه را با Aspose.Slides برای Node.js از طریق Java مدیریت کنید. این مقاله انواع اصلی مرتبط با نظرات را معرفی می‌کند و نشان می‌دهد چگونه نظرات را به اسلایدها اضافه کنید، نظرات موجود را دسترسی پیدا کنید، با پاسخ‌ها و نظرات مدرن کار کنید، و نظرات را از یک ارائه حذف نمایید.

این مثال‌ها سناریوهای معمول بررسی و همکاری در PowerPoint را پوشش می‌دهند، از جمله تخصیص نظرات به نویسندگان، خواندن متن نظر و متادیتا، ساخت زنجیره‌های پاسخ، و حذف نظرات انتخاب شده یا تمام نظرات.

در PowerPoint، نظرات به‌عنوان حاشیه‌نویسی بر روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن آن و بحث مرتبط را نمایش می‌دهد.

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بررسی ارائه‌ها استفاده کنید.

Aspose.Slides برای Node.js از طریق Java APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* کلاس [CommentCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/commentcollection/) که نظرات مرتبط با یک نویسنده خاص را نشان می‌دهد.
* کلاس [Comment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/comment/) که اطلاعاتی درباره یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن را ارائه می‌دهد.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/commentauthor/) که اطلاعاتی درباره یک نویسنده شامل نام، حروف اولیه و نظرات مرتبط را ارائه می‌دهد.

## **افزودن نظرات به اسلاید**

مثال زیر نشان می‌دهد چگونه نظرات را به اسلایدهای یک ارائه PowerPoint اضافه کنید:

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

## **دسترسی به نظرات اسلاید**

مثال زیر نشان می‌دهد چگونه به نظرات موجود در یک ارائه PowerPoint دسترسی پیدا کنید:

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

## **پاسخ به نظرات**

یک نظر والد، نظر اصلی در بالای سلسله‌مراتبی پاسخ‌ها است. متدهای [Comment.getParentComment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/comment/getparentcomment/) و [Comment.setParentComment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/comment/setparentcomment/) به شما امکان می‌دهند والد یک نظر را دریافت یا تنظیم کنید.

مثال زیر نشان می‌دهد چگونه پاسخ‌ها را اضافه کنید و سلسله‌مراتبی نظرات حاصل را بررسی کنید:

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

{{% alert color="warning" title="هشدار" %}}
* هنگامی که متد [Comment.remove](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/comment/remove/) برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر [Comment.setParentComment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/comment/setparentcomment/) یک ارجاع حلقه‌ای ایجاد کند، استثنای [PptxEditException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص، یا به یک بازه متنی داخل یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مرتبط شوند. متد [CommentCollection.addModernComment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) علاوه بر اسلاید و مختصات نشانگر نظر، یک آرگومان از نوع [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) را می‌پذیرد.

هنگامی که برای آرگومان shape مقدار `null` ارسال شود، نظر یک نظر سطح اسلاید است. نشانگر آن توسط مختصات ارائه‌شده موقعیت می‌گیرد، اما به شکل خاصی مرتبط نیست، بنابراین [ModernComment.getShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/getshape/) مقدار `null` را برمی‌گرداند. وقتی یک [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) ارائه شود، نظر به آن شکل پیوند می‌یابد. مختصات همچنان موقعیت نشانگر نظر بر روی اسلاید را تعریف می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [ModernComment.getShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/getshape/) بازیابی شود.

### **پیوند یک نظر مدرن به یک شکل**

مثال زیر یک نظر مدرن سطح اسلاید و یک نظر مدرن پیوند داده‌شده به یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) خاص ایجاد می‌کند. سپس شکل مرتبط با هر نظر را می‌خواند.

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

### **پیوند نظرات به انواع مختلف شکل‌ها**

هر شیء اسلایدی که از [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) مشتق شده باشد می‌تواند به‌عنوان لنگر شکل استفاده شود. مثال‌های رایج شامل [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/connector/)، و نمونه‌های [GraphicalObject](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/graphicalobject/) مانند نمودارها هستند.

مثال زیر چند نوع شکل رایج ایجاد می‌کند و برای هر یک یک نظر مدرن مرتبط می‌سازد.

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

### **پیوند یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن مرتبط با یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/)، متدهای [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) و [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) موقعیت شروع متن انتخاب‌شده در چارچوب متن شکل را به‌دست می‌آورند. متدهای [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) و [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) طول انتخاب را به‌دست می‌آورند. این مقادیر با هم، نظر را به یک بازه متنی خاص داخل [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) پیوند می‌دهند.

متدهای [ModernComment.getStatus](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/getstatus/) و [ModernComment.setStatus](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/setstatus/) مقداری از شمارش‌گر [ModernCommentStatus](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncommentstatus/) را بازگردانند/تنظیم می‌کنند:

- `NotDefined` — هیچ وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل شده است.
- `Closed` — نظر بسته شده است.

مثال زیر یک نظر مدرن پیوند داده‌شده به شکل ایجاد می‌کند، آن را به یک انتخاب متن پیوند می‌دهد، به‌عنوان حل‌شده علامت‌گذاری می‌کند، ارائه را ذخیره می‌کند و پس از بازگشایی فایل مقادیر را صحت‌سنجی می‌کند.

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

### **بررسی نظرات مدرن موجود**

برای بررسی یک ارائه موجود، ابتدا بررسی کنید که کدام نظرات از نوع [ModernComment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/) هستند، سپس [ModernComment.getShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/getshape/)، [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/)، [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) و [ModernComment.getStatus](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/getstatus/) را بررسی کنید. یک شکل `null` نشان‌دهنده یک نظر در سطح اسلاید است. برای یک لنگر [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/)، متدهای انتخاب متن بازه مرتبط در چارچوب متن شکل را شناسایی می‌کنند.

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

## **حذف نظرات**

### **حذف تمام نظرات و نویسندگان نظرات**

مثال زیر نشان می‌دهد چگونه تمام نظرات و نویسندگان نظرات را از یک ارائه حذف کنید:

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

### **حذف نظرات خاص**

مثال زیر نشان می‌دهد چگونه نظرات خاصی را از یک اسلاید حذف کنید:

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

## **FAQ**

**آیا Aspose.Slides وضعیت حل‌شده برای نظرات مدرن را پشتیبانی می‌کند؟**

بله. متدهای [ModernComment.getStatus](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/getstatus/) و [ModernComment.setStatus](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncomment/setstatus/) مقدار [ModernCommentStatus](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/moderncommentstatus/) را باز می‌گردانند، شامل `Resolved`. این وضعیت در ارائه ذخیره می‌شود و پس از بازگشایی فایل می‌توان آن را دوباره خواند.

**آیا بحث‌های سلسله‌دار (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای عمق تو در تویی وجود دارد؟**

بله. هر نظر می‌تواند به [نظر والد](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/comment/getparentcomment/) خود ارجاع دهد، که امکان زنجیره‌های پاسخ را فراهم می‌کند. API محدودیت خاصی برای عمق تو در تویی تعریف نکرده است.

**موقعیت نشانگر نظر در اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت نشانگر توسط مختصات نقطه‌ای در سیستم مختصات اسلاید تعریف می‌شود، که امکان قرار دادن دقیق آن بر روی اسلاید را می‌دهد.