---
title: จัดการความคิดเห็นพรีเซนเทชันใน Node.js
linktitle: ความคิดเห็นพรีเซนเทชัน
type: docs
weight: 100
url: /th/nodejs-java/presentation-comments/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- ความคิดเห็น PowerPoint
- ความคิดเห็นพรีเซนเทชัน
- ความคิดเห็นสไลด์
- เพิ่มความคิดเห็น
- เข้าถึงความคิดเห็น
- แก้ไขความคิดเห็น
- ตอบกลับความคิดเห็น
- ลบความคิดเห็น
- ลบความคิดเห็น
- PowerPoint
- พรีเซนเทชัน
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการความคิดเห็นพรีเซนเทชันด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java: เพิ่ม, อ่าน, แก้ไข, ตอบกลับและลบความคิดเห็นในพรีเซนเทชัน PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการความคิดเห็นในการพรีเซนเทชันด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java. มันแนะนำประเภทหลักที่เกี่ยวข้องกับความคิดเห็นและสาธิตวิธีการเพิ่มความคิดเห็นไปยังสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่, และลบความคิดเห็นจากพรีเซนเทชัน

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและความร่วมมือทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน, การอ่านข้อความและเมตาดาต้าของความคิดเห็น, การสร้างห่วงโซ่การตอบกลับ, และการลบความคิดเห็นที่เลือกหรือทั้งหมด

ใน PowerPoint, ความคิดเห็นปรากฏเป็นหมายเหตุบนสไลด์ การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

## **ทำไมต้องเพิ่มความคิดเห็นในพรีเซนเทชัน?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อทำการตรวจสอบพรีเซนเทชัน

Aspose.Slides for Node.js via Java ให้ API ดังต่อไปนี้สำหรับการทำงานกับความคิดเห็น:

* คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ที่ให้การเข้าถึงผู้เขียนความคิดเห็นของพรีเซนเทชัน
* คลาส [CommentCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/commentcollection/) ที่แสดงความคิดเห็นที่เชื่อมโยงกับผู้เขียนแต่ละคน
* คลาส [Comment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/) ที่ให้ข้อมูลเกี่ยวกับความคิดเห็น รวมถึงผู้เขียน, เวลาในการสร้าง, ตำแหน่ง, และข้อความ
* คลาส [CommentAuthor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/commentauthor/) ที่ให้ข้อมูลเกี่ยวกับผู้เขียน รวมถึงชื่อ, อักษรย่อ, และความคิดเห็นที่เกี่ยวข้อง

## **เพิ่มความคิดเห็นบนสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มความคิดเห็นไปยังสไลด์ในพรีเซนเทชัน PowerPoint:

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

## **เข้าถึงความคิดเห็นบนสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเข้าถึงความคิดเห็นที่มีอยู่ในพรีเซนเทชัน PowerPoint:

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

## **ตอบกลับความคิดเห็น**

ความคิดเห็นหลักคือความคิดเห็นต้นฉบับที่อยู่บนสุดของลำดับการตอบกลับ. เมธอด [Comment.getParentComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/getparentcomment/) และ [Comment.setParentComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/setparentcomment/) ให้คุณรับหรือกำหนดความคิดเห็นหลักของความคิดเห็น

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มการตอบกลับและตรวจสอบโครงสร้างความคิดเห็นที่ได้:

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

{{% alert color="warning" title="คำเตือน" %}}
* เมื่อใช้เมธอด [Comment.remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/remove/) เพื่อทำการลบความคิดเห็น ทุกการตอบกลับของความคิดเห็นนั้นจะถูกลบด้วย
* หาก [Comment.setParentComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/setparentcomment/) สร้างการอ้างอิงวงจร จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปทรงเฉพาะ, หรือกับช่วงข้อความภายใน [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ได้. เมธอด [CommentCollection.addModernComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) ยอมรับอาร์กิวเมนต์ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) นอกเหนือจากสไลด์และพิกัดของเครื่องหมายความคิดเห็น

เมื่อ `null` ถูกส่งเป็นอาร์กิวเมนต์ของ shape, ความคิดเห็นนั้นเป็นความคิดเห็นระดับสไลด์. เครื่องหมายของมันจะกำหนดตำแหน่งโดยพิกัดที่ให้ไว้ แต่จะไม่เชื่อมโยงกับรูปทรงใดเป็นพิเศษ ดังนั้น [ModernComment.getShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getshape/) จะคืนค่า `null`. เมื่อมีการระบุ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/), ความคิดเห็นจะยึดติดกับรูปทรงนั้น พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายบนสไลด์, ในขณะที่การเชื่อมโยงรูปทรงสามารถดึงข้อมูลได้ผ่าน [ModernComment.getShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getshape/)

### **ผูกความคิดเห็นสมัยใหม่กับรูปทรง**

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ระดับสไลด์และความคิดเห็นสมัยใหม่ที่ยึดติดกับ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) เฉพาะ จากนั้นอ่านรูปทรงที่เชื่อมโยงจากแต่ละความคิดเห็น

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

### **ผูกความคิดเห็นกับประเภทรูปทรงต่างๆ**

รูปทรงใด ๆ ที่สืบทอดจาก [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) สามารถใช้เป็นจุดเชื่อมต่อได้ ตัวอย่างทั่วไปได้แก่ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/connector/), และอินสแตนซ์ของ [GraphicalObject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/graphicalobject/) เช่น แผนภูมิ

ตัวอย่างต่อไปนี้สร้างรูปทรงหลายประเภทที่พบบ่อยและเชื่อมโยงความคิดเห็นสมัยใหม่กับแต่ละรูปทรง

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

### **ผูกความคิดเห็นกับข้อความและตั้งค่าสถานะ**

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/), เมธอด [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) และ [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) เข้าถึงตำแหน่งเริ่มต้นของข้อความที่เลือกในกรอบข้อความของรูปทรง. เมธอด [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) และ [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) เข้าถึงความยาวของการเลือก. ค่าทั้งสองนี้ทำให้ความคิดเห็นเชื่อมโยงกับช่วงข้อความเฉพาะภายใน [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)

เมธอด [ModernComment.getStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getstatus/) และ [ModernComment.setStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/setstatus/) เข้าถึงค่าจาก enumeration [ModernCommentStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncommentstatus/) :

- `NotDefined` — ไม่ได้กำหนดสถานะความคิดเห็นสมัยใหม่เฉพาะ
- `Active` — ความคิดเห็นอยู่ในสถานะใช้งาน
- `Resolved` — ความคิดเห็นได้รับการแก้ไขแล้ว
- `Closed` — ความคิดเห็นถูกปิด

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ที่ยึดติดกับรูปทรง, เชื่อมโยงกับการเลือกข้อความ, ตั้งค่าสถานะเป็นแก้ไขแล้ว, บันทึกพรีเซนเทชัน, และตรวจสอบค่าหลังจากเปิดไฟล์ใหม่

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

### **ตรวจสอบความคิดเห็นสมัยใหม่ที่มีอยู่**

เพื่อสอบถามพรีเซนเทชันที่มีอยู่, ให้ตรวจสอบว่าอินสแตนซ์เป็น [ModernComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/) หรือไม่, จากนั้นดูที่ [ModernComment.getShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), และ [ModernComment.getStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getstatus/). รูปทรงที่เป็น `null` แสดงว่าความคิดเห็นระดับสไลด์. สำหรับการยึดกับ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) วิธีการเลือกข้อความจะระบุช่วงที่เชื่อมโยงในกรอบข้อความของรูปทรง

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

## **ลบความคิดเห็น**

### **ลบความคิดเห็นทั้งหมดและผู้เขียนความคิดเห็น**

ตัวอย่างต่อไปนี้แสดงวิธีลบความคิดเห็นและผู้เขียนความคิดเห็นทั้งหมดจากพรีเซนเทชัน:

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

### **ลบความคิดเห็นเฉพาะ**

ตัวอย่างต่อไปนี้แสดงวิธีลบความคิดเห็นเฉพาะจากสไลด์:

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

**Aspose.Slides รองรับสถานะที่แก้ไขแล้วสำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. เมธอด [ModernComment.getStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getstatus/) และ [ModernComment.setStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/setstatus/) เข้าถึงค่าของ [ModernCommentStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncommentstatus/) รวมถึง `Resolved`. สถานะจะถูกบันทึกในพรีเซนเทชันและสามารถอ่านได้อีกครั้งหลังจากเปิดไฟล์ใหม่

**การสนทนาที่ต่อเนื่อง (ห่วงโซ่การตอบกลับ) รองรับหรือไม่ และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. แต่ละความคิดเห็นสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/getparentcomment/) ของมัน, ทำให้สามารถสร้างห่วงโซ่การตอบกลับได้. API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกันเป็นค่าเฉพาะ

**ตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งของเครื่องหมายกำหนดโดยพิกัดแบบ floating‑point ในระบบพิกัดของสไลด์, ซึ่งทำให้คุณสามารถวางเครื่องหมายได้อย่างแม่นยำบนสไลด์