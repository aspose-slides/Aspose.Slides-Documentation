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
- حذف نظر
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت نظرات ارائه با Aspose.Slides برای Node.js از طریق Java: افزودن، خواندن، ویرایش، پاسخ‌دادن و حذف نظرات در ارائه‌های PowerPoint."
---
## **مرور کلی**

این مقاله نحوه مدیریت نظرات ارائه را با Aspose.Slides برای Node.js از طریق Java توضیح می‌دهد. این مقاله انواع اصلی مرتبط با نظرات را معرفی کرده و نشان می‌دهد چگونه نظرات را به اسلایدها اضافه کنید، نظرات موجود را دسترسی پیدا کنید، با پاسخ‌ها و نظرات مدرن کار کنید و نظرات را از یک ارائه حذف کنید.

مثال‌ها سناریوهای رایج بررسی و همکاری در PowerPoint را پوشش می‌دهند، از جمله اختصاص نظرات به نویسندگان، خواندن متن نظرسین و متادیتا، ساخت زنجیره‌های پاسخ و حذف نظرات انتخاب‌شده یا همه نظرات.

در PowerPoint، نظرات به‌عنوان حاشیه‌نویسی بر روی اسلایدها نمایش داده می‌شوند. انتخاب یک نظر متن و بحث مربوطه را نشان می‌دهد.

برای درخواست نمایش یا پنهان‌کردن نظرات هنگام باز کردن یک ارائه بدون تغییر خود نظرات، ببینید [نمایش یا پنهان کردن نظرات هنگام باز کردن یک ارائه](/slides/fa/nodejs-java/presentation-view-properties/).

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بازبینی ارائه‌ها استفاده کنید.

Aspose.Slides برای Node.js از طریق Java APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation] که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* کلاس [CommentCollection] که نظرات مرتبط با یک نویسنده خاص را نشان می‌دهد.
* کلاس [Comment] که اطلاعاتی درباره یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن را ارائه می‌دهد.
* کلاس [CommentAuthor] که اطلاعاتی درباره یک نویسنده شامل نام، حروف ابتدایی و نظرات مرتبط را فراهم می‌کند.

## **اضافه کردن نظرات اسلاید**

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

مثال زیر نشان می‌دهد چگونه نظرات موجود در یک ارائه PowerPoint را دسترسی پیدا کنید:

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

یک نظر والد، نظر اصلی در بالای یک سلسله‌مراتبی پاسخ است. متدهای [Comment.getParentComment] و [Comment.setParentComment] به شما امکان می‌دهند والد یک نظر را دریافت یا تنظیم کنید.

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

{{% alert color="warning" title="Warning" %}}
* هنگامی که متد [Comment.remove] برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر [Comment.setParentComment] یک ارجاع حلقوی ایجاد کند، یک [PptxEditException] پرتاب می‌شود.
{{% /alert %}}

## **اضافه کردن نظرات مدرن**

نظرات مدرن می‌توانند با خود اسلاید، یک شکل خاص یا یک بازه متن داخل یک [AutoShape] مرتبط شوند. متد [CommentCollection.addModernComment] علاوه بر اسلاید و مختصات نشانگر نظر، یک پارامتر [Shape] می‌پذیرد.

زمانی که مقدار `null` برای پارامتر shape ارسال شود، نظر به‌صورت نظر سطح اسلاید است. نشانگر آن توسط مختصات ارائه شده موقعیت می‌گیرد، اما به شکل خاصی مرتبط نیست، بنابراین [ModernComment.getShape] مقدار `null` برمی‌گرداند. زمانی که یک [Shape] ارائه شود، نظر به آن شکل متصل می‌شود. مختصات هنوز موقعیت نشانگر نظر را روی اسلاید تعریف می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [ModernComment.getShape] بازیابی شود.

### **اتصال یک نظر مدرن به یک شکل**

مثال زیر هم یک نظر مدرن سطح اسلاید و هم یک نظر مدرن متصل به یک [AutoShape] خاص ایجاد می‌کند. سپس شکل مرتبط با هر نظر را می‌خواند.

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

### **اتصال نظرات به انواع مختلف شکل**

هر شیء اسلایدی که از [Shape] مشتق شده باشد می‌تواند به‌عنوان لنگر شکل استفاده شود. نمونه‌های رایج شامل [AutoShape]، [PictureFrame]، [GroupShape]، [Connector] و نمونه‌های [GraphicalObject] مانند نمودارها هستند.

مثال زیر چندین نوع شکل رایج ایجاد می‌کند و یک نظر مدرن را به هر کدام پیوند می‌دهد.

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

### **اتصال یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن که به یک [AutoShape] مرتبط است، متدهای [ModernComment.getTextSelectionStart] و [ModernComment.setTextSelectionStart] موقعیت شروع متن انتخاب‌شده در فریم متن شکل را دسترسی می‌دهند. متدهای [ModernComment.getTextSelectionLength] و [ModernComment.setTextSelectionLength] طول انتخاب را برمی‌گردانند. این مقادیر با هم نظر را به یک بازه متن خاص داخل [AutoShape] مرتبط می‌کنند.

متدهای [ModernComment.getStatus] و [ModernComment.setStatus] مقدار یک عضو از شمارش‌گذاری [ModernCommentStatus] را برمی‌گردانند:

- `NotDefined` — هیچ وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل‌ شده است.
- `Closed` — نظر بسته شده است.

مثال زیر یک نظر مدرن متصل به شکل ایجاد می‌کند، آن را به یک انتخاب متن پیوند می‌دهد، به عنوان حل‌ شده علامت‌گذاری می‌کند، ارائه را ذخیره می‌کند و پس از بازگشایی فایل مقادیر را تأیید می‌کند.

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

برای بررسی یک ارائه موجود، ابتدا نظراتی که از نوع [ModernComment] هستند شناسایی کنید، سپس [ModernComment.getShape]، [ModernComment.getTextSelectionStart]، [ModernComment.getTextSelectionLength] و [ModernComment.getStatus] را بررسی نمایید. یک شکل `null` نشانگر یک نظر سطح اسلاید است. برای لنگر [AutoShape]، متدهای انتخاب متن بازه مرتبط در فریم متن شکل را مشخص می‌کنند.

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

## **سوالات متداول**

**آیا Aspose.Slides وضعیت حل‌ شده برای نظرات مدرن را پشتیبانی می‌کند؟**

بله. متدهای [ModernComment.getStatus] و [ModernComment.setStatus] مقدار یک [ModernCommentStatus] را، از جمله `Resolved`، برمی‌گردانند. این وضعیت در ارائه ذخیره می‌شود و پس از بازگشایی فایل می‌تواند دوباره خوانده شود.

**آیا بحث‌های رشتۀ (زنجیره پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای تو در تو بودن وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment] خود ارجاع دهد و زنجیره‌های پاسخ را فعال کند. API محدودیت خاصی برای عمق تو در تو تعریف نمی‌کند.

**موقعیت نشانگر نظر بر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت نشانگر توسط مختصات نقطه‌ای شناور در سیستم مختصات اسلاید تعریف می‌شود، که امکان قرار دادن دقیق آن را روی اسلاید فراهم می‌آورد.