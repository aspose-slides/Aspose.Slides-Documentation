---
title: คอมเมนต์
type: docs
weight: 230
url: /th/nodejs-java/examples/elements/comment/
keywords:
- ตัวอย่างโค้ด
- คอมเมนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำงานกับความคิดเห็นบนสไลด์ใน Aspose.Slides for Node.js: เพิ่ม, ตอบกลับ, แก้ไข, แก้ปัญหา, และส่งออกความคิดเห็นในงานนำเสนอรูปแบบ PPT, PPTX, และ ODP พร้อมตัวอย่างโค้ด."
---
บทความนี้แสดงวิธีการเพิ่ม, อ่าน, ลบ และตอบกลับความคิดเห็นสมัยใหม่โดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มความคิดเห็นสมัยใหม่**

สร้างความคิดเห็นที่เขียนโดยผู้ใช้และบันทึกการนำเสนอ.

```js
function addModernComment() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let author = presentation.getCommentAuthors().addAuthor("Jhon Smith", "JS");
        let position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100));
        let date = java.newInstanceSync("java.util.Date");

        author.getComments().addModernComment("This is a modern comment", slide, null, position, date);

        presentation.save("modern_comment.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงความคิดเห็นสมัยใหม่**

อ่านความคิดเห็นสมัยใหม่จากการนำเสนอที่มีอยู่.

```js
function accessModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let author = presentation.getCommentAuthors().get_Item(0);
        let comment = author.getComments().get_Item(0);
        
        console.log("Author: " + author.getName() + ", Comment: " + comment.getText());
    } finally {
        presentation.dispose();
    }
}
```

## **ลบความคิดเห็นสมัยใหม่**

ลบความคิดเห็นและบันทึกไฟล์ที่อัปเดต.

```js
function removeModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let author = presentation.getCommentAuthors().get_Item(0);

        let comment = author.getComments().get_Item(0);
        comment.remove();

        presentation.save("modern_comment_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ตอบกลับความคิดเห็นสมัยใหม่**

เพิ่มการตอบกลับให้กับความคิดเห็นสมัยใหม่ที่เป็นคอมเมนต์หลัก.

```js
function replyToModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let author = presentation.getCommentAuthors().get_Item(0);
        let comment = author.getComments().get_Item(0);

        let position1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(110), java.newFloat(100));
        let date1 = java.newInstanceSync("java.util.Date");
        let reply1 = author.getComments().addModernComment("Reply 1", slide, null, position1, date1);

        let position2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(120), java.newFloat(100));
        let date2 = java.newInstanceSync("java.util.Date");
        let reply2 = author.getComments().addModernComment("Reply 2", slide, null, position2, date2);

        reply1.setParentComment(comment);
        reply2.setParentComment(comment);

        presentation.save("modern_comment_replies.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```