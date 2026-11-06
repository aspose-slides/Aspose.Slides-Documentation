---
title: จัดการความคิดเห็นการนำเสนอใน Node.js
linktitle: ความคิดเห็นการนำเสนอ
type: docs
weight: 100
url: /th/nodejs-java/presentation-comments/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- ความคิดเห็น PowerPoint
- ความคิดเห็นการนำเสนอ
- ความคิดเห็นสไลด์
- เพิ่มความคิดเห็น
- เข้าถึงความคิดเห็น
- แก้ไขความคิดเห็น
- ตอบกลับความคิดเห็น
- ลบความคิดเห็น
- ลบความคิดเห็น
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการความคิดเห็นการนำเสนอด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบความคิดเห็นในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการความคิดเห็นบนการนำเสนอด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java. มันแนะนำประเภทที่เกี่ยวข้องกับความคิดเห็นหลักและแสดงวิธีการเพิ่มความคิดเห็นลงในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่, และลบความคิดเห็นออกจากการนำเสนอ

ตัวอย่างครอบคลุมสถานการณ์การตรวจทานและการทำงานร่วมกันที่พบบ่อยใน PowerPoint, เช่น การกำหนดความคิดเห็นให้กับผู้เขียน, การอ่านข้อความและเมทาดาต้าของความคิดเห็น, การสร้างสายตอบกลับ, และการลบความคิดเห็นที่เลือกหรือความคิดเห็นทั้งหมด

ใน PowerPoint, ความคิดเห็นจะแสดงเป็นหมายเหตุบนสไลด์. การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

หากต้องการร้องขอให้แสดงหรือซ่อนความคิดเห็นเมื่อเปิดการนำเสนอโดยไม่เปลี่ยนแปลงความคิดเห็นเอง, โปรดดูที่ [Show or Hide Comments When Opening a Presentation](/slides/th/nodejs-java/presentation-view-properties/).

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อทำการตรวจทานงานนำเสนอ

Aspose.Slides สำหรับ Node.js ผ่าน Java มี API ต่อไปนี้สำหรับทำงานกับความคิดเห็น:

* The [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) class, which represents the comments associated with an individual author.
* The [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) class, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **เพิ่มความคิดเห็นบนสไลด์**

ตัวอย่างสร้างสไลด์สองสไลด์และลงทะเบียนผู้เขียนความคิดเห็นด้วย [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/). ตัวอย่างใช้ [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) เพื่อวางความคิดเห็นหนึ่งรายการบนแต่ละสไลด์, จากนั้นดึงความคิดเห็นของสไลด์แรกสำหรับผู้เขียนคนนั้นด้วย [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/). คอนโซลจะแสดงข้อความของความคิดเห็นแรกสองครั้ง, แสดงการเข้าถึงผ่านทั้งสไลด์และผู้เขียน, และการนำเสนอที่บันทึกไว้จะมีทั้งสองความคิดเห็น

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

## **ค้นหาหรือสร้างผู้เขียนความคิดเห็น**

เมื่อการตรวจทานอัตโนมัติโปรเซสการนำเสนอเดียวกันหลายครั้ง, ควรค้นหาในคอลเล็กชันที่返回โดย [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) ก่อนเพิ่มผู้เขียน. [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) จะจับคู่ทั้งชื่อและตัวย่อและ返回อาร์เรย์ของผู้เขียนที่ตรงกัน, หรืออาร์เรย์ว่างหากไม่มีการจับคู่. ในทางกลับกัน, [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) ค้นหาโดยใช้ชื่ออย่างเดียวโดยไม่คำนึงถึงตัวย่อ. การเรียก [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) ด้วยชื่อและตัวย่อที่มีอยู่แล้วในคอลเล็กชันจะทำให้เกิดข้อยกเว้น

ตัวอย่างต้องการไฟล์การนำเสนอที่มีสไลด์อย่างน้อยหนึ่งสไลด์. ในสองรอบ, จะใช้ผู้เขียนที่ตรงกันแรกซ้ำ, หรือสร้างใหม่เมื่อผลลัพธ์ว่างเปล่า. หากมีหลายการจับคู่, จะเลือกอิลิเมนต์แรกของอาร์เรย์โดยไม่รวมหรือเอาผู้เขียนคนอื่นออก. จากนั้นจะเรียก [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) สำหรับผู้เขียนที่เลือกและบันทึกการนำเสนอ. รอบที่สองจะเปิดผลลัพธ์ของรอบแรกและทำซ้ำการดำเนินการ

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

รอบที่สองเพิ่มความคิดเห็นอีกหนึ่งรายการโดยไม่เพิ่มผู้เขียนอีกคนหรือเอาความคิดเห็นที่มีอยู่ออก. ไฟล์สุดท้าย, `review_pass_2.pptx`, มีความคิดเห็นใหม่สองรายการพร้อมกับความคิดเห็นเดิมใดๆก็ตาม. การใช้ผู้เขียนซ้ำจะไม่ทำให้ความคิดเห็นทำซ้ำ: เพื่อหลีกเลี่ยงการเพิ่มความคิดเห็นเดียวซ้ำหลายครั้ง, ควรทำการตรวจจับซ้ำแยกต่างหากก่อนเพิ่ม

## **เข้าถึงความคิดเห็นบนสไลด์**

ตัวอย่างเปิดการนำเสนอที่มีอยู่และอ่านคอลเล็กชันที่返回โดย [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/). สำหรับแต่ละผู้เขียน, จะวนลูปผ่านคอลเล็กชันที่返回โดย [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) และพิมพ์หมายเลขสไลด์, ข้อความความคิดเห็น, ชื่อผู้เขียน, และเวลาการสร้าง. การนำเสนออินพุตต้องมีความคิดเห็นเพื่อให้คอนโซลแสดงผล

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

ความคิดเห็นพาเรน्टคือความคิดเห็นต้นฉบับที่อยู่บนสุดของโครงสร้างการตอบกลับ. เมธอด [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) และ [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) ให้คุณดึงหรือกำหนดพาเรนต์ของความคิดเห็น

ตัวอย่างสร้างความคิดเห็นจากผู้เขียนสองคนและใช้ [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) เพื่อสร้างการตอบกลับ, รวมถึงการตอบกลับต่อการตอบกลับอื่น. การส่ง `null` ไปที่ [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) จะดึงความคิดเห็นจากผู้เขียนทั้งหมด; คอนโซลจะเยื้องแต่ละรายการตามระดับความลึกในลำดับการตอบกลับ. ตัวอย่างบันทึกการสนทนาครบถ้วน, เรียก [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) บนความคิดเห็นรากแรก, และบันทึกการนำเสนอที่สองซึ่งความคิดเห็นนั้นและการตอบกลับของมันถูกลบออก

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
* เมื่อใช้เมธอด [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) เพื่อลบความคิดเห็น, การตอบกลับทั้งหมดของความคิดเห็นนั้นก็จะถูกลบพร้อมกัน
* หาก [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) สร้างการอ้างอิงเป็นวงกลม, จะมีการโยน [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปร่างเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape. เมธอด [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) รับอาร์กิวเมนต์ [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) เพิ่มเติมนอกจากสไลด์และพิกัดของเครื่องหมายความคิดเห็น

เมื่อส่ง `null` เป็นอาร์กิวเมนต์ shape, ความคิดเห็นนั้นจะเป็นความคิดเห็นระดับสไลด์. เครื่องหมายของมันจะอยู่ตามพิกัดที่ระบุ, แต่ไม่มีการเชื่อมโยงกับรูปร่างใด, ดังนั้น [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) จะคืนค่า `null`. เมื่อใส่ [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) รายการนั้น, ความคิดเห็นจะผูกกับรูปร่างนั้น. พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์, ในขณะที่การเชื่อมโยงรูปร่างสามารถดึงได้ผ่าน [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)

### **ผูกความคิดเห็นสมัยใหม่เข้ากับรูปร่าง**

ตัวอย่างเรียก [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) สองครั้ง: ครั้งหนึ่งกับ shape `null` สำหรับความคิดเห็นระดับสไลด์และอีกครั้งกับสี่เหลี่ยมเป็นจุดยึด. การอ่าน [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) จะพิมพ์ `true` สำหรับการตรวจสอบ null ของความคิดเห็นระดับสไลด์และพิมพ์ `Revenue title` สำหรับความคิดเห็นที่ยึดกับรูปร่าง. ทั้งสองความคิดเห็นจะถูกบันทึกพร้อมกับการนำเสนอ

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

### **ผูกความคิดเห็นกับประเภทรูปร่างต่างๆ**

ออบเจกต์สไลด์ใด ๆ ที่สืบทอดจาก [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) สามารถใช้เป็นจุดยึดรูปร่างได้. ตัวอย่างทั่วไปรวมถึง [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/), และอินสแตนซ์ของ [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) เช่น ชาร์ต

ตัวอย่างใช้ [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) เพื่อเชื่อมโยงความคิดเห็นกับรูปร่างแต่ละประเภทจากห้าชนิด: AutoShape, picture frame, group, connector, และ chart. รูปภาพใช้ข้อมูลภาพฝังอยู่, ดังนั้นไม่ต้องการไฟล์ภาพภายนอก. แต่ละความคิดเห็นมีตำแหน่งเครื่องหมายของตนเอง, และการนำเสนอที่บันทึกจะเก็บการเชื่อมโยงทั้งห้ารูปร่างไว้

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

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), เมธอด [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) และ [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) จะเข้าถึงตำแหน่งเริ่มต้นของข้อความที่เลือกในเฟรมข้อความของรูปร่าง. เมธอด [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) และ [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) จะเข้าถึงความยาวของการเลือก. ค่าทั้งสองนี้ทำให้ความคิดเห็นเชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape

เมธอด [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) และ [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) เข้าถึงค่าจากการนับแบบ [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — ไม่ได้กำหนดสถานะความคิดเห็นสมัยใหม่เฉพาะ
- `Active` — ความคิดเห็นอยู่ในสถานะใช้งาน
- `Resolved` — ความคิดเห็นได้รับการแก้ไขแล้ว
- `Closed` — ความคิดเห็นปิดแล้ว

ตัวอย่างผูกความคิดเห็นสมัยใหม่กับคำว่า "quarterly revenue" ในข้อความของสี่เหลี่ยม. มันคำนวณตำแหน่งเริ่มต้นการเลือกแบบศูนย์‑ฐานจากข้อความและส่งค่าให้กับ [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) และใช้ [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) เพื่อกำหนดจำนวนอักขระที่เลือก. หลังจากเรียก [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) ด้วย `Resolved`, จะบันทึกและเปิดการนำเสนอใหม่. การตรวจสอบสี่ครั้งบนคอนโซลควรพิมพ์ `true` ทั้งหมด, ยืนยันว่าตำแหน่งรูปร่าง, ช่วงข้อความ, และสถานะถูกเก็บไว้

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

### **ตรวจสอบความคิดเห็นสมัยใหม่ที่มีอยู่**

ตัวอย่างต้องการการนำเสนอที่มีความคิดเห็นสมัยใหม่และพิมพ์ข้อความ, สถานะ, และรายละเอียดการยึด. เพื่อตรวจสอบ, ตรวจสอบว่าความคิดเห็นเป็นออบเจกต์ของ [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/), จากนั้นดูที่ [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), และ [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/). รูปร่าง `null` แสดงว่าความคิดเห็นระดับสไลด์. สำหรับการยึดกับ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), เมธอดเลือกข้อความจะระบุช่วงที่เชื่อมโยงในเฟรมข้อความของรูปร่าง

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

Aspose.Slides สำหรับ Node.js ผ่าน Java ให้คุณลบความคิดเห็นทั้งหมดและผู้เขียนของพวกมันจากการนำเสนอหรือทำการลบความคิดเห็นที่เลือกโดยยังคงส่วนอื่นไว้. ตัวอย่างต่อไปนี้แสดงวิธีทั้งสองและบันทึกการนำเสนอที่อัปเดต

### **ลบความคิดเห็นและผู้เขียนความคิดเห็นทั้งหมด**

ตัวอย่างเปิดการนำเสนอที่มีอยู่และเรียก [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) สำหรับแต่ละผู้เขียน, จากนั้นเรียก [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) เพื่อลบผู้เขียนเอง. การนำเสนอที่บันทึกจะไม่มีความคิดเห็นหรือผู้เขียนความคิดเห็นใด ๆ. ใช้การนำเสนอที่มีความคิดเห็นเพื่อสังเกตการลบ

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

### **ลบความคิดเห็นที่ระบุ**

ตัวอย่างสร้างความคิดเห็นสองรายการบนสไลด์เดียวและใช้ [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) เพื่อค้นหาความคิดเห็นของแต่ละผู้เขียน. มันรวบรวมความคิดเห็นที่ข้อความเท่ากับ "comment 1" ก่อนเรียก [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/), เพื่อหลีกเลี่ยงการเปลี่ยนแปลงคอลเล็กชันขณะเลือก. การนำเสนอที่บันทึกจะเหลือเพียง "comment 2"

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

ใช่. [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) และ [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) เข้าถึงค่าจาก [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) ซึ่งรวม `Resolved`. สถานะจะถูกเก็บในการนำเสนอและสามารถอ่านได้อีกครั้งหลังจากไฟล์ถูกเปิดใหม่

**การสนทนาที่เป็นแถวน้ำ (สายตอบกลับ) รองรับหรือไม่, และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. แต่ละความคิดเห็นสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) ของตน, ทำให้สร้างสายตอบกลับได้. API ไม่กำหนดขีดจำกัดความลึกของการซ้อนกันเป็นพิเศษ

**ตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งเครื่องหมายกำหนดด้วยค่าพิกัดแบบ floating‑point ในระบบพิกัดของสไลด์, ทำให้คุณวางตำแหน่งได้อย่างแม่นยำบนสไลด์