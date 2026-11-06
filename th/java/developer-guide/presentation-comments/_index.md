---
title: จัดการความคิดเห็นในการนำเสนอด้วย Java
linktitle: ความคิดเห็นการนำเสนอ
type: docs
weight: 100
url: /th/java/presentation-comments/
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
- Java
- Aspose.Slides
description: "จัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for Java: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบความคิดเห็นในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for Java โดยแนะนำประเภทหลักที่เกี่ยวข้องกับความคิดเห็นและสาธิตวิธีการเพิ่มความคิดเห็นลงในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่, และลบความคิดเห็นออกจากงานนำเสนอ

ตัวอย่างครอบคลุมสถานการณ์การรีวิวและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน, การอ่านข้อความและเมตาดาต้าของความคิดเห็น, การสร้างห่วงโซ่การตอบกลับ, และการลบความคิดเห็นที่เลือกหรือทั้งหมด

ใน PowerPoint ความคิดเห็นจะแสดงเป็นคำอธิบายบนสไลด์ การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

เพื่อขอให้แสดงความคิดเห็นแสดงหรือซ่อนเมื่อเปิดงานนำเสนอโดยไม่เปลี่ยนแสดงความคิดเห็นเอง โปรดดู [แสดงหรือซ่อนความคิดเห็นเมื่อเปิดการนำเสนอ](/slides/th/java/presentation-view-properties/)

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อรีวิวงานนำเสนอได้

Aspose.Slides for Java มี API ต่อไปนี้สำหรับทำงานกับความคิดเห็น:

* The [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/) interface, which represents the comments associated with an individual author.
* The [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/) interface, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **เพิ่มความคิดเห็นในสไลด์**

ตัวอย่างนี้สร้างสไลด์สองหน้และลงทะเบียนผู้เขียนความคิดเห็นด้วย [addAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-). มันใช้ [addComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-java.awt.geom.Point2D.Float-java.util.Date-) เพื่อตั้งความคิดเห็นหนึ่งรายการบนแต่ละสไลด์, จากนั้นดึงความคิดเห็นของสไลด์แรกสำหรับผู้เขียนคนนั้นด้วย [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-). คอนโซลจะแสดงข้อความของความคิดเห็นแรกสองครั้ง, แสดงการเข้าถึงผ่านสไลด์และผู้เขียน, และไฟล์งานนำเสนอที่บันทึกไว้มีทั้งสองความคิดเห็น

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    Point2D.Float position = new Point2D.Float(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        String commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ค้นหา หรือสร้างผู้เขียนความคิดเห็น**

เมื่อการรีวิวอัตโนมัติทำการประมวลผลงานนำเสนอเดียวกันหลายครั้ง ให้ค้นหารายการที่คืนค่าจาก [getCommentAuthors](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getCommentAuthors--) ก่อนเพิ่มผู้เขียนใหม่. [findByNameAndInitials](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) จะจับคู่ทั้งชื่อและอักษรย่อและคืนค่าอาร์เรย์ของผู้เขียนที่ตรงกัน, หรืออาร์เรย์ว่างถ้าไม่มีการจับคู่. ในทางตรงกันข้าม, [findByName](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) ค้นหาด้วยชื่อเท่านั้นโดยไม่สนใจอักษรย่อ. การเรียก [addAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) ด้วยชื่อและอักษรย่อที่มีอยู่แล้วในคอลเลกชันจะทำให้เกิดข้อยกเว้น

ตัวอย่างต้องการไฟล์งานนำเสนอที่มีอย่างน้อยหนึ่งสไลด์. ในแต่ละรอบของสองรอบ, มันใช้ผู้เขียนที่ตรงกันแรก, หรือสร้างใหม่เมื่อผลลัพธ์เป็นว่าง. ถ้ามีหลายการจับคู่, มันเลือกองค์ประกอบแรกของอาร์เรย์โดยไม่รวมหรือลบผู้เขียนคนอื่น. จากนั้นมันเรียก [addComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-java.awt.geom.Point2D.Float-java.util.Date-) สำหรับผู้เขียนที่เลือกและบันทึกงานนำเสนอ. รอบที่สองเปิดผลลัพธ์จากรอบแรกและทำซ้ำการดำเนินการ

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

final String authorName = "Reviewer";
final String authorInitials = "RV";

String inputFile = "input.pptx";
Point2D.Float position = new Point2D.Float(20, 20);

for (int pass = 1; pass <= 2; pass++) {
    Presentation presentation = new Presentation(inputFile);
    try {
        ICommentAuthor[] matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        ICommentAuthor author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, new Date());

        String outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

รอบที่สองเพิ่มความคิดเห็นอีกหนึ่งรายการโดยไม่เพิ่มผู้เขียนอีกคนหรือทำลายความคิดเห็นที่มีอยู่. ไฟล์สุดท้าย, `review_pass_2.pptx`, มีความคิดเห็นใหม่สองรายการร่วมกับความคิดเห็นเดิมทั้งหมด. การใช้ผู้เขียนซ้ำไม่ได้ทำให้ความคิดเห็นซ้ำหายไป: เพื่อหลีกเลี่ยงการเพิ่มความคิดเห็นเดียวกันหลายครั้ง, ให้ดำเนินการตรวจจับสำเนาซ้ำแยกจากกันก่อนเพิ่ม

## **เข้าถึงความคิดเห็นในสไลด์**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และอ่านคอลเลกชันที่คืนค่าจาก [getCommentAuthors](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getCommentAuthors--). สำหรับผู้เขียนแต่ละคน, มันวนลูปผ่านคอลเลกชันที่คืนค่าจาก [getComments](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthor/#getComments--) และพิมพ์หมายเลขสไลด์, ข้อความความคิดเห็น, ชื่อผู้เขียน, และเวลาสร้าง. งานนำเข้าต้องมีความคิดเห็นเพื่อให้คอนโซลแสดงผล

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **ตอบกลับความคิดเห็น**

คอมเมนต์พาเรนต์คือคอมเมนต์ต้นฉบับที่อยู่บนสุดของโครงสร้างการตอบกลับ. เมธอด [IComment.getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#getParentComment--) และ [IComment.setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) ให้คุณรับหรือกำหนดพาเรนต์ของคอมเมนต์ได้

ตัวอย่างสร้างคอมเมนต์จากผู้เขียนสองคนและใช้ [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) เพื่อสร้างการตอบกลับ, รวมถึงการตอบกลับต่อการตอบกลับอื่น. การส่งค่า `null` ให้กับ [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) จะดึงความคิดเห็นจากผู้เขียนทั้งหมด; คอนโซลจะเยื้องแต่ละรายการตามระดับความลึกในโครงสร้างการตอบกลับ. ตัวอย่างบันทึกการสนทนาที่สมบรูณ์, เรียก [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#remove--) บนคอมเมนต์รากแรก, และบันทึกงานนำเสนอที่สองโดยคอมเมนต์และการตอบกลับของมันถูกลบออก

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Point2D.Float position = new Point2D.Float(10, 10);
    Date createdTime = new Date();

    ICommentAuthor originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    IComment secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    IComment subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    IComment separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    IComment separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    rootComment.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* เมื่อใช้เมธอด [IComment.remove](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#remove--) เพื่อลบคอมเมนต์, คอมเมนต์ตอบกลับทั้งหมดของคอมเมนต์นั้นก็จะถูกลบด้วย
* หาก [IComment.setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) สร้างการอ้างอิงแบบวงกลม, จะเกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มความคิดเห็นแบบสมัยใหม่**

ความคิดเห็นแบบสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปทรงเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape. เมธอด [ICommentCollection.addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) รับอาร์กิวเมนต์ [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) นอกเหนือจากสไลด์และพิกัดของเครื่องหมายคอมเมนต์

เมื่อส่งค่า `null` สำหรับอาร์กิวเมนต์รูปทรง, คอมเมนต์นั้นเป็นคอมเมนต์ระดับสไลด์. เครื่องหมายของมันจะถูกกำหนดตำแหน่งโดยพิกัดที่ให้ไว้, แต่ไม่เชื่อมโยงกับรูปทรงใดโดยเฉพาะ, ดังนั้น [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--) จะคืนค่า `null`. เมื่อให้ [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) แล้ว, คอมเมนต์จะยึดติดกับรูปทรงนั้น. พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายคอมเมนต์บนสไลด์, ส่วนการเชื่อมโยงรูปทรงสามารถดึงได้ผ่าน [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--)

### **ยึดความคิดเห็นแบบสมัยใหม่กับรูปทรง**

ตัวอย่างเรียก [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) สองครั้ง: ครั้งแรกกับรูปทรง `null` สำหรับคอมเมนต์ระดับสไลด์และครั้งที่สองกับสี่เหลี่ยมเป็นจุดยึด. การอ่าน [getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--) จะพิมพ์ `true` สำหรับการตรวจสอบ null ของคอมเมนต์ระดับสไลด์และพิมพ์ `Revenue title` สำหรับคอมเมนต์ที่ยึดกับรูปทรง. ทั้งสองคอมเมนต์ถูกบันทึกพร้อมกับงานนำเสนอ

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    Point2D.Float slideCommentPosition = new Point2D.Float(20, 20);
    Point2D.Float shapeCommentPosition = new Point2D.Float(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ยึดความคิดเห็นกับประเภทรูปทรงที่แตกต่างกัน**

อ็อบเจ็กต์สไลด์ใดๆ ที่ทำตามอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) สามารถใช้เป็นจุดยึดรูปทรงได้ ตัวอย่างทั่วไปได้แก่ [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/java/com.aspose.slides/iconnector/), และอินสแตนซ์ [IGraphicalObject](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobject/) เช่น ชาร์ต

ตัวอย่างใช้ [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) เพื่อเชื่อมโยงคอมเมนต์กับรูปทรงแต่ละประเภทจำนวนห้า: AutoShape, picture frame, group, connector, และ chart. ภาพใช้ข้อมูลภาพฝังจึงไม่ต้องอ้างอิงภาพภายนอก. คอมเมนต์แต่ละรายการมีตำแหน่งเครื่องหมายของตนเอง, และงานนำเสนอที่บันทึกไว้เก็บการเชื่อมโยงรูปทรงทั้งห้าไว้

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");

    Point2D.Float autoShapeCommentPosition = new Point2D.Float(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    Point2D.Float pictureCommentPosition = new Point2D.Float(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    Point2D.Float groupCommentPosition = new Point2D.Float(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    Point2D.Float connectorCommentPosition = new Point2D.Float(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    Point2D.Float chartCommentPosition = new Point2D.Float(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ยึดคอมเมนต์กับข้อความและตั้งค่าบสถานะ**

สำหรับคอมเมนต์สมัยใหม่ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/), เมธอด [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) และ [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) เข้าถึงตำแหน่งเริ่มต้นของข้อความที่เลือกในเฟรมข้อความของรูปทรง. เมธอด [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) และ [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) เข้าถึงความยาวของการเลือก. ค่าทั้งสองนี้ร่วมกันทำให้คอมเมนต์เชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape

เมธอด [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--) และ [IModernComment.setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) เข้าถึงค่าในคอนสแตนท์ [ModernCommentStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — ไม่ได้กำหนดสถานะของความคิดเห็นสมัยใหม่
- `Active` — ความคิดเห็นอยู่ในสถานะทำงาน
- `Resolved` — ความคิดเห็นได้รับการแก้ไขแล้ว
- `Closed` — ความคิดเห็นถูกปิด

ตัวอย่างยึดคอมเมนต์สมัยใหม่กับคำว่า "quarterly revenue" ในข้อความของสี่เหลี่ยม. มันคำนวนตำแหน่งเริ่มต้นของการเลือกจากข้อความและส่งค่าให้กับ [setTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) แล้วใช้ [setTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) เพื่อกำหนดจำนวนอักขระที่เลือก. หลังจากเรียก [setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) ด้วย `Resolved`, งานนำเสนอจะถูกบันทึกและเปิดใหม่. การตรวจสอบสี่ครั้งบนคอนโซลควรพิมพ์ `true` ทุกครั้ง, ยืนยันว่าการยึดรูปทรง, ช่วงข้อความ, และสถานะถูกเก็บรักษาไว้

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Point2D.Float commentPosition = new Point2D.Float(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **ตรวจสอบความคิดเห็นสมัยใหม่ที่มีอยู่**

ตัวอย่างต้องการงานนำเสนอที่มีความคิดเห็นสมัยใหม่และพิมพ์ข้อความ, สถานะ, และรายละเอียดการยึดรูปทรงของแต่ละคอมเมนต์. เพื่อทำการตรวจสอบ, ให้ตรวจสอบว่าคอมเมนต์ใดบ้างที่ทำตามอินเทอร์เฟซ [IModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/), จากนั้นตรวจสอบ [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--), และ [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--). รูปทรง `null` บ่งบอกว่าความคิดเห็นระดับสไลด์. สำหรับการยึดกับ [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) วิธีการเลือกข้อความจะระบุช่วงที่เชื่อมโยงในเฟรมข้อความของรูปทรง

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **ลบความคิดเห็น**

Aspose.Slides for Java ให้คุณลบความคิดเห็นทั้งหมดและผู้เขียนความคิดเห็นจากงานนำเสนอ หรือทำการลบความคิดเห็นที่เลือกโดยคงส่วนที่เหลือไว้ ตัวอย่างต่อไปนี้สาธิตทั้งสองวิธีและบันทึกงานนำเสนอที่อัปเดต

### **ลบความคิดเห็นทั้งหมดและผู้เขียนความคิดเห็น**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเรียก [ICommentCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#clear--) สำหรับแต่ละผู้เขียน, จากนั้นเรียก [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#clear--) เพื่อลบผู้เขียนเอง. งานนำเสนอที่บันทึกไว้จะไม่มีความคิดเห็นหรือผู้เขียนความคิดเห็นเลย. ใช้งานนำเสนอที่มีความคิดเห็นเพื่อสังเกตการลบ

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ลบความคิดเห็นเฉพาะ**

ตัวอย่างสร้างความคิดเห็นสองรายการบนสไลด์หนึ่งและใช้ [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) เพื่อค้นหาความคิดเห็นตามผู้เขียนแต่ละคน. มันรวบรวมความคิดเห็นที่ข้อความเท่ากับ "comment 1" ก่อนเรียก [ICommentCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-), เพื่อหลีกเลี่ยงการเปลี่ยนแปลงคอลเลกชันระหว่างการเลือก. งานนำเสนอที่บันทึกไว้จะเหลือเฉพาะ "comment 2"

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    Point2D.Float firstCommentPosition = new Point2D.Float(0.2f, 0.2f);
    Point2D.Float secondCommentPosition = new Point2D.Float(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะที่แก้ไขแล้วสำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. เมธอด [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--) และ [IModernComment.setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) เข้าถึงค่าของ [ModernCommentStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncommentstatus/) รวมถึง `Resolved`. สถานะนี้จะถูกเก็บในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากไฟล์ถูกเปิดใหม่

**สนับสนุนการสนทนาตามเธรด (ห่วงโซ่การตอบกลับ) หรือไม่, และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. แต่ละคอมเมนต์สามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#getParentComment--) ของมันได้, ทำให้สามารถสร้างห่วงโซ่การตอบกลับได้. API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกันเป็นค่าเฉพาะ

**ตำแหน่งของเครื่องหมายคอมเมนต์บนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งเครื่องหมายกำหนดโดยพิกัดแบบ floating‑point ในระบบพิกัดของสไลด์, ซึ่งทำให้คุณสามารถวางตำแหน่งได้อย่างแม่นยำบนสไลด์