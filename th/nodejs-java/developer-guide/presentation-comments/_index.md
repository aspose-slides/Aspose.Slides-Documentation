---
title: จัดการความคิดเห็นงานนำเสนอด้วย JavaScript
linktitle: ความคิดเห็นงานนำเสนอ
type: docs
weight: 100
url: /th/nodejs-java/presentation-comments/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- ความคิดเห็น PowerPoint
- ความคิดเห็นงานนำเสนอ
- ความคิดเห็นสไลด์
- เพิ่มความคิดเห็น
- เข้าถึงความคิดเห็น
- แก้ไขความคิดเห็น
- ตอบกลับความคิดเห็น
- ลบความคิดเห็น
- ลบความคิดเห็น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เชี่ยวชาญการจัดการความคิดเห็นงานนำเสนอด้วย Aspose.Slides สำหรับ Node.js: เพิ่ม อ่าน แก้ไข และลบความคิดเห็นในไฟล์ PowerPoint ด้วย JavaScript อย่างเร็วและง่าย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides โดยแสดงประเภทที่เกี่ยวข้องกับความคิดเห็นหลักและสาธิตวิธีเพิ่มความคิดเห็นในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับ, ใช้ความคิดเห็นสมัยใหม่, และลบความคิดเห็นจากงานนำเสนอ

ตัวอย่างมุ่งเน้นไปที่สถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน, การอ่านเนื้อหาและเมตาดาต้าของความคิดเห็น, การสร้างชุดการตอบกลับ, และการลบความคิดเห็นทั้งหมดหรือการลบเฉพาะที่เลือก

ใน PowerPoint ความคิดเห็นจะแสดงเป็นบันทึกหรือคำอธิบายบนสไลด์ เมื่อคลิกที่ความคิดเห็นจะทำให้เนื้อหาหรือข้อความของมันปรากฏขึ้น

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณอาจต้องการใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะหรือสื่อสารกับเพื่อนร่วมงานเมื่อทำการตรวจทานงานนำเสนอ

เพื่อให้คุณสามารถใช้ความคิดเห็นในงานนำเสนอ PowerPoint, Aspose.Slides for Node.js via Java มีให้

* คลาส [Presentation] ซึ่งมีคอลเลกชันของผู้เขียน (จากคลาส [CommentAuthorCollection]) ผู้เขียนจะเพิ่มความคิดเห็นลงในสไลด์
* คลาส [CommentCollection] ซึ่งมีคอลเลกชันของความคิดเห็นสำหรับผู้เขียนแต่ละคน
* คลาส [Comment] ซึ่งบรรจุข้อมูลเกี่ยวกับผู้เขียนและความคิดเห็นของพวกเขา: ใครเพิ่มความคิดเห็น, เวลาที่เพิ่ม, ตำแหน่งของความคิดเห็น ฯลฯ
* คลาส [CommentAuthor] ซึ่งบรรจุข้อมูลของผู้เขียนแต่ละคน: ชื่อผู้เขียน, ย่อชื่อ, ความคิดเห็นที่เชื่อมโยงกับชื่อผู้เขียน ฯลฯ

## **เพิ่มความคิดเห็นสไลด์**
โค้ด JavaScript นี้แสดงวิธีเพิ่มความคิดเห็นลงในสไลด์ของงานนำเสนอ PowerPoint:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // เพิ่มสไลด์เปล่า
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // เพิ่มผู้เขียน
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // ตั้งค่าตำแหน่งสำหรับความคิดเห็น
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ที่ 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ที่ 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // เข้าถึง ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // เมื่อส่งค่า null เป็นอาร์กิวเมนต์ ความคิดเห็นจากผู้เขียนทั้งหมดจะถูกดึงมาในสไลด์ที่เลือก
    var Comments = slide.getSlideComments(author);
    // เข้าถึงความคิดเห็นที่ตำแหน่งดัชนี 0 สำหรับสไลด์ 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // เลือกคอลเลกชันความคิดเห็นของผู้เขียนที่ดัชนี 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เข้าถึงความคิดเห็นสไลด์**
โค้ด JavaScript นี้แสดงวิธีเข้าถึงความคิดเห็นที่มีอยู่บนสไลด์ของงานนำเสนอ PowerPoint:

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

## **ตอบกลับความคิดเห็น**
ความคิดเห็นพาเรนต์คือความคิดเห็นต้นหรือความคิดเห็นเดิมในลำดับชั้นของความคิดเห็นหรือการตอบกลับ โดยใช้เมธอด [getParentComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Comment#getParentComment--) หรือ [setParentComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (จากคลาส [Comment]) คุณสามารถตั้งหรือรับความคิดเห็นพาเรนต์ได้

โค้ด JavaScript นี้แสดงวิธีเพิ่มความคิดเห็นและรับการตอบกลับจากความคิดเห็น:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // เพิ่มความคิดเห็น
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // เพิ่มการตอบกลับให้กับ comment1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // เพิ่มการตอบกลับอื่นให้กับ comment1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // เพิ่มการตอบกลับให้กับการตอบกลับที่มีอยู่
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // แสดงลำดับขั้นของความคิดเห็นบนคอนโซล
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
    // ลบ comment1 และการตอบกลับทั้งหมดของมัน
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Attention" %}} 
* เมื่อใช้เมธอด [Remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Comment#remove--) (จากคลาส [Comment]) เพื่อลบความคิดเห็น การตอบกลับของความคิดเห็นนั้นก็จะถูกลบด้วย
* หากการตั้งค่า [setParentComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) ทำให้เกิดการอ้างอิงแบบวงกลม จะเกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PptxEditException)
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ในปี 2021 Microsoft ได้นำเสนอ *ความคิดเห็นสมัยใหม่* ใน PowerPoint ฟีเจอร์ความคิดเห็นสมัยใหม่ช่วยปรับปรุงการทำงานร่วมกันใน PowerPoint อย่างมีนัยสำคัญ ผ่านความคิดเห็นสมัยใหม่ ผู้ใช้ PowerPoint สามารถแก้ไขสถานะของความคิดเห็น, ฝังความคิดเห็นกับวัตถุและข้อความ, และมีปฏิสัมพันธ์ได้ง่ายกว่าที่เคย

Aspose.Slides รองรับความคิดเห็นสมัยใหม่ด้วยคลาส [ModernComment] เมธอด [addModernComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) และ [insertModernComment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) ถูกเพิ่มเข้ามาในคลาส [CommentCollection]

โค้ด JavaScript นี้แสดงวิธีเพิ่มความคิดเห็นสมัยใหม่ลงในสไลด์ของงานนำเสนอ PowerPoint:

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

## **ลบความคิดเห็น**

### **ลบความคิดเห็นและผู้เขียนทั้งหมด**

โค้ด JavaScript นี้แสดงวิธีลบความคิดเห็นและผู้เขียนทั้งหมดในงานนำเสนอ:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // ลบความคิดเห็นทั้งหมดจากงานนำเสนอ
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // ลบผู้เขียนทั้งหมด
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **ลบความคิดเห็นเฉพาะ**

โค้ด JavaScript นี้แสดงวิธีลบความคิดเห็นบางส่วนบนสไลด์:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // เพิ่มความคิดเห็น...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // ลบความคิดเห็นทั้งหมดที่มีข้อความ "comment 1" 

    
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

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะเช่น 'resolved' สำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. [Modern comments](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/) มีเมธอด [getStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/getstatus/) และ [setStatus](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/moderncomment/setStatus/) คุณสามารถอ่านและตั้งค่าสถานะของความคิดเห็น (เช่น ทำเครื่องหมายว่าแก้ไขแล้ว) และสถานะนี้จะถูกบันทึกในไฟล์และ PowerPoint จะรับรู้

**รองรับการสนทนาที่เป็นเธรด (ชุดการตอบกลับ) หรือไม่, และมีขีดจำกัดการซ้อนระดับใดหรือไม่?**

ใช่. แต่ละความคิดเห็นสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/comment/getparentcomment/) ของมัน ทำให้สามารถสร้างชุดการตอบกลับได้โดยอิสระ API ไม่ได้กำหนดขีดจำกัดระดับการซ้อนเฉพาะ

**ตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งถูกเก็บเป็นจุดเลขลอยในระบบพิกัดของสไลด์ ทำให้คุณสามารถวางเครื่องหมายความคิดเห็นได้อย่างแม่นยำตรงตามที่ต้องการ