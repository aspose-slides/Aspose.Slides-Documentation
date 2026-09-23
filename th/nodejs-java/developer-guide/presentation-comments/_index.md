---
title: จัดการคอมเมนต์งานนำเสนอใน Node.js
linktitle: คอมเมนต์งานนำเสนอ
type: docs
weight: 100
url: /th/nodejs-java/presentation-comments/
keywords:
- คอมเมนต์
- คอมเมนต์สมัยใหม่
- คอมเมนต์ PowerPoint
- คอมเมนต์งานนำเสนอ
- คอมเมนต์สไลด์
- เพิ่มคอมเมนต์
- เข้าถึงคอมเมนต์
- แก้ไขคอมเมนต์
- ตอบคอมเมนต์
- ลบคอมเมนต์
- ลบคอมเมนต์
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการคอมเมนต์งานนำเสนอด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java: เพิ่ม, อ่าน, แก้ไข, ตอบ, และลบคอมเมนต์ในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการคอมเมนต์ของงานนำเสนอด้วย Aspose.Slides for Node.js via Java โดยแนะนำประเภทของคอมเมนต์หลักและสาธิตวิธีการเพิ่มคอมเมนต์ลงในสไลด์, เข้าถึงคอมเมนต์ที่มีอยู่, ทำงานกับการตอบกลับและคอมเมนต์สมัยใหม่, และลบคอมเมนต์ออกจากงานนำเสนอ

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดคอมเมนต์ให้กับผู้เขียน, การอ่านข้อความคอมเมนต์และข้อมูลเมตา, การสร้างสายตอบกลับ, และการลบคอมเมนต์ที่เลือกหรือคอมเมนต์ทั้งหมด

ใน PowerPoint คอมเมนต์จะแสดงเป็นคำอธิบายบนสไลด์ การเลือกคอมเมนต์จะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

เพื่อขอให้คอมเมนต์แสดงหรือซ่อนเมื่อเปิดงานนำเสนอโดยไม่เปลี่ยนแปลงคอมเมนต์เอง, ดูที่ [แสดงหรือซ่อนคอมเมนต์เมื่อเปิดงานนำเสนอ](/slides/th/nodejs-java/presentation-view-properties/)

## **ทำไมต้องเพิ่มคอมเมนต์ในงานนำเสนอ?**

คุณสามารถใช้คอมเมนต์เพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อทำการตรวจงานนำเสนอ

Aspose.Slides for Node.js via Java มี API ต่อไปนี้สำหรับทำงานกับคอมเมนต์:

* The [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) class, คลาสที่ให้การเข้าถึงผู้เขียนคอมเมนต์ของงานนำเสนอ.
* The [CommentCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/commentcollection/) class, คลาสที่แสดงคอมเมนต์ที่เชื่อมโยงกับผู้เขียนแต่ละคน.
* The [Comment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/) class, คลาสที่ให้ข้อมูลเกี่ยวกับคอมเมนต์ รวมถึงผู้เขียน, เวลาสร้าง, ตำแหน่ง, และข้อความ.
* The [CommentAuthor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/commentauthor/) class, คลาสที่ให้ข้อมูลเกี่ยวกับผู้เขียน รวมถึงชื่อ, ชื่อย่อ, และคอมเมนต์ที่เชื่อมโยง.

## **เพิ่มคอมเมนต์บนสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มคอมเมนต์ลงในสไลด์ของงานนำเสนอ PowerPoint:

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

## **เข้าถึงคอมเมนต์บนสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเข้าถึงคอมเมนต์ที่มีอยู่ในงานนำเสนอ PowerPoint:

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

## **ตอบกลับคอมเมนต์**

คอมเมนต์หลักคือคอมเมนต์ต้นฉบับที่อยู่ด้านบนของลำดับชั้นการตอบกลับ เมธอด [Comment.getParentComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/getparentcomment/) และ [Comment.setParentComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/setparentcomment/) ให้คุณดึงหรือกำหนดคอมเมนต์หลักของคอมเมนต์

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มการตอบกลับและตรวจสอบโครงสร้างคอมเมนต์ที่ได้:

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
* เมื่อใช้เมธอด [Comment.remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/remove/) เพื่อลบคอมเมนต์ การตอบกลับทั้งหมดที่เชื่อมโยงกับคอมเมนต์นั้นจะถูกลบด้วย
* หาก [Comment.setParentComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/setparentcomment/) สร้างการอ้างอิงแบบวงกลม จะทำให้เกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มคอมเมนต์สมัยใหม่**

คอมเมนต์สมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปทรงเฉพาะ, หรือกับช่วงข้อความภายใน [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/). เมธอด [CommentCollection.addModernComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) รับอาร์กิวเมนต์ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) เพิ่มเติมนอกจากสไลด์และพิกัดของเครื่องหมายคอมเมนต์

เมื่อส่งค่า `null` เป็นอาร์กิวเมนต์ shape คอมเมนต์จะเป็นคอมเมนต์ระดับสไลด์ เครื่องหมายจะถูกกำหนดตำแหน่งโดยพิกัดที่ให้ไว้ แต่จะไม่ได้เชื่อมโยงกับรูปทรงใดโดยเฉพาะ ดังนั้นเมธอด [ModernComment.getShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getshape/) จะคืนค่า `null` หากส่งค่า [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) มา คอมเมนต์จะถูกฝังกับรูปทรงนั้น พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายคอมเมนต์บนสไลด์ ในขณะที่การเชื่อมโยงรูปทรงสามารถดึงได้ผ่าน [ModernComment.getShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getshape/).

### **ยึดคอมเมนต์สมัยใหม่กับรูปทรง**

ตัวอย่างต่อไปนี้สร้างคอมเมนต์สมัยใหม่ระดับสไลด์และคอมเมนต์สมัยใหม่ที่ยึดกับ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) เฉพาะ แล้วอ่านรูปทรงที่เชื่อมโยงจากแต่ละคอมเมนต์

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

### **ยึดคอมเมนต์กับประเภทรูปทรงต่างๆ**

ออบเจกต์สไลด์ใดๆ ที่สืบทอดจาก [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) สามารถใช้เป็นจุดยึดรูปทรงได้ ตัวอย่างทั่วไปได้แก่ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/connector/) และอินสแตนซ์ของ [GraphicalObject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/graphicalobject/) เช่นแผนภูมิ

ตัวอย่างต่อไปนี้สร้างรูปทรงทั่วไปหลายประเภทและเชื่อมโยงคอมเมนต์สมัยใหม่กับแต่ละรูปแบบ

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

### **ยึดคอมเมนต์กับข้อความและกำหนดสถานะของมัน**

สำหรับคอมเมนต์สมัยใหม่ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) เมธอด [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) และ [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) เข้าถึงตำแหน่งเริ่มต้นของข้อความที่เลือกในกรอบข้อความของรูปทรง ส่วนเมธอด [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) และ [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) เข้าถึงความยาวของการเลือก ค่าเหล่านี้ร่วมกันทำให้คอมเมนต์เชื่อมโยงกับช่วงข้อความเฉพาะภายใน [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)

เมธอด [ModernComment.getStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getstatus/) และ [ModernComment.setStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/setstatus/) เข้าถึงค่าใน [ModernCommentStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncommentstatus/) ซึ่งประกอบด้วย:

- `NotDefined` — ไม่ได้กำหนดสถานะคอมเมนต์สมัยใหม่เฉพาะใด
- `Active` — คอมเมนต์อยู่ในสถานะใช้งาน
- `Resolved` — คอมเมนต์ได้รับการแก้ไขแล้ว
- `Closed` — คอมเมนต์ถูกปิด

ตัวอย่างต่อไปนี้สร้างคอมเมนต์สมัยใหม่ที่ยึดกับรูปทรง, เชื่อมโยงกับการเลือกข้อความ, ทำเครื่องหมายเป็นแก้ไขแล้ว, บันทึกงานนำเสนอ, และตรวจสอบค่าหลังจากเปิดไฟล์ใหม่

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

### **ตรวจสอบคอมเมนต์สมัยใหม่ที่มีอยู่**

เพื่อทำการตรวจสอบงานนำเสนอที่มีอยู่ ให้ตรวจสอบคอมเมนต์ใดเป็นอินสแตนซ์ของ [ModernComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/) จากนั้นตรวจสอบ [ModernComment.getShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) และ [ModernComment.getStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getstatus/) รูปทรงที่เป็น `null` แสดงว่าคอมเมนต์ระดับสไลด์ สำหรับจุดยึดของ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) เมธอดเลือกข้อความจะระบุช่วงที่เชื่อมโยงในกรอบข้อความของรูปทรง

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

## **ลบคอมเมนต์**

### **ลบคอมเมนต์และผู้เขียนคอมเมนต์ทั้งหมด**

ตัวอย่างต่อไปนี้แสดงวิธีลบคอมเมนต์และผู้เขียนคอมเมนต์ทั้งหมดออกจากงานนำเสนอ:

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

### **ลบคอมเมนต์เฉพาะ**

ตัวอย่างต่อไปนี้แสดงวิธีลบคอมเมนต์เฉพาะจากสไลด์:

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

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะที่แก้ไขแล้วสำหรับคอมเมนต์สมัยใหม่หรือไม่?**

ใช่. เมธอด [ModernComment.getStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getstatus/) และ [ModernComment.setStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/setstatus/) เข้าถึงค่าใน [ModernCommentStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncommentstatus/) ซึ่งรวมถึง `Resolved`. สถานะนี้จะถูกบันทึกในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากเปิดไฟล์ใหม่

**รองรับการสนทนาที่มีลำดับชั้น (สายตอบกลับ) หรือไม่ และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. คอมเมนต์แต่ละรายการสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/getparentcomment/) ของมัน ทำให้สามารถสร้างสายตอบกลับได้ API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกันโดยเฉพาะ

**พิกัดของตำแหน่งเครื่องหมายคอมเมนต์บนสไลด์ใช้ระบบพิกัดใด?**

ตำแหน่งของเครื่องหมายคอมเมนต์ถูกกำหนดโดยพิกัดแบบ floating-point ในระบบพิกัดของสไลด์ ทำให้คุณสามารถวางตำแหน่งได้อย่างแม่นยำบนสไลด์