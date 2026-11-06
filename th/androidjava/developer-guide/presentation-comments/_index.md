---
title: จัดการความคิดเห็นการนำเสนอบน Android
linktitle: ความคิดเห็นการนำเสนอ
type: docs
weight: 100
url: /th/androidjava/presentation-comments/
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
- Android
- Java
- Aspose.Slides
description: "จัดการความคิดเห็นการนำเสนอด้วย Aspose.Slides สำหรับ Android ผ่าน Java: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบความคิดเห็นในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for Android via Java จะอธิบายประเภทที่เกี่ยวข้องกับความคิดเห็นหลักและสาธิตวิธีการเพิ่มความคิดเห็นในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่, และลบความคิดเห็นออกจากงานนำเสนอ  

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน, การอ่านข้อความและข้อมูลเมตาของความคิดเห็น, การสร้างสายตอบกลับ, และการลบความคิดเห็นที่เลือกหรือความคิดเห็นทั้งหมด  

ใน PowerPoint ความคิดเห็นจะแสดงเป็นคำอธิบายบนสไลด์ การเลือกความคิดเห็นจะทำให้แสดงข้อความและการสนทนาที่เกี่ยวข้อง  

หากต้องการให้แสดงหรือซ่อนความคิดเห็นเมื่อเปิดงานนำเสนอโดยไม่เปลี่ยนแสดงความคิดเห็นเอง ให้ดูที่ [แสดงหรือซ่อนความคิดเห็นเมื่อเปิดงานนำเสนอ](/slides/th/androidjava/presentation-view-properties/)

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและร่วมมือกับเพื่อนร่วมงานเมื่อทำการตรวจสอบงานนำเสนอ  

Aspose.Slides for Android via Java มี API ต่อไปนี้สำหรับทำงานกับความคิดเห็น:

* คลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ซึ่งให้การเข้าถึงผู้เขียนความคิดเห็นของงานนำเสนอ
* อินเทอร์เฟซ [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/) ซึ่งแทนความคิดเห็นที่เชื่อมโยงกับผู้เขียนแต่ละคน
* อินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/) ซึ่งให้ข้อมูลเกี่ยวกับความคิดเห็น รวมถึงผู้เขียน, เวลาการสร้าง, ตำแหน่งและข้อความ
* คลาส [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentauthor/) ซึ่งให้ข้อมูลเกี่ยวกับผู้เขียน รวมถึงชื่อ, อักษรย่อและความคิดเห็นที่เชื่อมโยง

## **เพิ่มความคิดเห็นในสไลด์**

ตัวอย่างสร้างสไลด์สองหน้าและลงทะเบียนผู้เขียนความคิดเห็นด้วยเมธอด [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) ใช้เมธอด [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) เพื่อวางความคิดเห็นหนึ่งรายการบนแต่ละสไลด์ จากนั้นเรียกคืนความคิดเห็นของสไลด์แรกสำหรับผู้เขียนนั้นด้วยเมธอด [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) คอนโซลจะแสดงข้อความของความคิดเห็นแรกสองครั้ง เพื่อสาธิตการเข้าถึงผ่านสไลด์และผู้เขียน และงานนำเสนอที่บันทึกจะมีทั้งสองความคิดเห็น

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    PointF position = new PointF(0.2f, 0.2f);
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

## **ค้นหาหรือสร้างผู้เขียนความคิดเห็น**

เมื่อตรวจสอบอัตโนมัติโปรเซสงานนำเสนอเดียวกันหลายครั้ง ให้ค้นหาคอลเลกชันที่คืนค่าจากเมธอด [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) ก่อนเพิ่มผู้เขียน เมธอด [findByNameAndInitials](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) จะจับคู่ทั้งชื่อและอักษรย่อและคืนค่าอาเรย์ของผู้เขียนที่ตรงกัน หรืออาเรย์เปล่า หากไม่มีผลลัพธ์ ในขณะที่เมธอด [findByName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) ค้นหาเฉพาะด้วยชื่อโดยไม่คำนึงถึงอักษรย่อ การเรียกเมธอด [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) ด้วยชื่อและอักษรย่อที่มีอยู่แล้วในคอลเลกชันจะทำให้เกิดข้อยกเว้น  

ตัวอย่างต้องใช้ไฟล์งานนำเสนอที่มีสไลด์อย่างน้อยหนึ่งหน้า ในแต่ละรอบของสองรอบ ตัวอย่างจะใช้ผู้เขียนที่ตรงกันรายการแรกซ้ำ หรือสร้างใหม่เมื่อผลลัพธ์ว่าง หากพบหลายรายการจะเลือกองค์ประกอบแรกของอาเรย์โดยไม่ทำการรวมหรือกำจัดผู้เขียนอื่น จากนั้นเรียกเมธอด [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) สำหรับผู้เขียนที่เลือกและบันทึกงานนำเสนอ รอบที่สองจะเปิดผลลัพธ์ของรอบแรกและทำซ้ำขั้นตอนเดิม

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

final String authorName = "Reviewer";
final String authorInitials = "RV";

String inputFile = "input.pptx";
PointF position = new PointF(20, 20);

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

รอบที่สองเพิ่มความคิดเห็นอีกหนึ่งรายการโดยไม่เพิ่มผู้เขียนใหม่หรือกำจัดความคิดเห็นที่มีอยู่ ไฟล์สุดท้าย `review_pass_2.pptx` จะมีทั้งความคิดเห็นใหม่และความคิดเห็นเดิมที่มีอยู่ การใช้ผู้เขียนซ้ำไม่ได้ทำให้ความคิดเห็นซ้ำกันถูกลบออก: หากต้องการหลีกเลี่ยงการเพิ่มความคิดเห็นเดียวกันหลายครั้ง ให้ทำการตรวจจับสำเนาก่อนเพิ่ม

## **เข้าถึงความคิดเห็นสไลด์**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และอ่านคอลเลกชันที่คืนค่าจากเมธอด [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) สำหรับผู้เขียนแต่ละคน จะวนลูปผ่านคอลเลกชันที่คืนค่าจากเมธอด [getComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthor/#getComments--) แล้วพิมพ์หมายเลขสไลด์, ข้อความความคิดเห็น, ชื่อผู้เขียนและเวลา إنشاء หากงานนำเข้าที่ใช้ไม่มีความคิดเห็น จะไม่มีการแสดงผลบนคอนโซล

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

ความคิดเห็นหลักคือความคิดเห็นต้นฉบับที่อยู่บนสุดของลำดับชั้นการตอบกลับ เมธอด [IComment.getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) และ [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) ให้คุณรับหรือกำหนดความคิดเห็นหลักของความคิดเห็น  

ตัวอย่างสร้างความคิดเห็นจากผู้เขียนสองคนและใช้เมธอด [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) เพื่อสร้างการตอบกลับ รวมถึงการตอบกลับต่อการตอบกลับอื่น การส่ง `null` ไปยังเมธอด [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) จะดึงความคิดเห็นจากผู้เขียนทั้งหมด คอนโซลจะทำการเยื้องแต่ละรายการตามความลึกของลำดับชั้นการตอบกลับ ตัวอย่างบันทึกการสนทนาที่สมบูรณ์ แล้วเรียกเมธอด [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) บนความคิดเห็นหลักแรก และบันทึกงานนำเสนอที่สองโดยมีความคิดเห็นนั้นและการตอบกลับของมันถูกลบออก

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    PointF position = new PointF(10, 10);
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
* เมื่อใช้เมธอด [IComment.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) เพื่อลบความคิดเห็น การตอบกลับทั้งหมดของความคิดเห็นนั้นก็จะถูกลบด้วย
* หากเมธอด [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) สร้างการอ้างอิงแบบวงกลม จะทำให้เกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์เอง, กับรูปทรงเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape เมธอด [ICommentCollection.addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) ยอมรับอาร์กิวเมนต์ [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) เพิ่มเติมนอกเหนือจากสไลด์และพิกัดของเครื่องหมายความคิดเห็น  

เมื่อส่งค่า `null` สำหรับอาร์กิวเมนต์รูปทรง ความคิดเห็นจะเป็นความคิดเห็นระดับสไลด์ เครื่องหมายจะถูกกำหนดตำแหน่งโดยพิกัดที่ให้มา แต่ไม่เชื่อมโยงกับรูปทรงใดโดยเฉพาะ ดังนั้นเมธอด [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) จะคืนค่า `null` หากส่งค่า [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) ให้กับเมธอดนั้น ความคิดเห็นจะถูกยึดกับรูปทรงนั้น พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์ ในขณะที่การเชื่อมโยงรูปทรงสามารถดึงกลับผ่านเมธอด [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--)  

### **ยึดความคิดเห็นสมัยใหม่กับรูปร่าง**

ตัวอย่างเรียกเมธอด [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) สองครั้ง: ครั้งแรกด้วยรูปทรง `null` สำหรับความคิดเห็นระดับสไลด์ และครั้งที่สองด้วยสี่เหลี่ยมเป็นจุดยึด การอ่านเมธอด [getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) จะพิมพ์ `true` สำหรับการตรวจสอบ `null` ของความคิดเห็นระดับสไลด์และพิมพ์ `Revenue title` สำหรับความคิดเห็นที่ยึดกับรูปทรง ทั้งสองความคิดเห็นจะถูกบันทึกพร้อมกับงานนำเสนอ

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    PointF slideCommentPosition = new PointF(20, 20);
    PointF shapeCommentPosition = new PointF(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ยึดความคิดเห็นกับประเภทรูปร่างต่างๆ**

อ็อบเจ็กต์สไลด์ใด ๆ ที่ทำตามอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) สามารถใช้เป็นจุดยึดรูปร่างได้ ตัวอย่างทั่วไปรวมถึง [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnector/) และอินสแตนซ์ [IGraphicalObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobject/) เช่น ชาร์ต  

ตัวอย่างใช้เมธอด [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) เพื่อเชื่อมโยงความคิดเห็นกับประเภทรูปร่างห้าชนิด: AutoShape, picture frame, group, connector และ chart รูปภาพใช้ข้อมูลภาพที่ฝังอยู่ ดังนั้นจึงไม่ต้องการไฟล์ภาพภายนอก แต่ละความคิดเห็นมีตำแหน่งเครื่องหมายของตนเอง และงานนำเสนอที่บันทึกจะเก็บการเชื่อมโยงกับรูปทรงทั้งห้าชนิดไว้

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
import android.graphics.PointF;
import android.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");

    PointF autoShapeCommentPosition = new PointF(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.decode(imageBase64, Base64.DEFAULT);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    PointF pictureCommentPosition = new PointF(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    PointF groupCommentPosition = new PointF(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    PointF connectorCommentPosition = new PointF(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    PointF chartCommentPosition = new PointF(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ยึดความคิดเห็นกับข้อความและตั้งค่าสถานะของมัน**

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) เมธอด [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) และ [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) เข้าถึงตำแหน่งเริ่มต้นของข้อความที่ถูกเลือกในกรอบข้อความของรูปร่าง เมธอด [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) และ [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) เข้าถึงความยาวของการเลือก ค่าทั้งสองทำให้ความคิดเห็นเชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape  

เมธอด [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) และ [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) เข้าถึงค่าจากคอนสแตนท์ [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — ไม่ได้กำหนดสถานะของความคิดเห็นสมัยใหม่ที่ชัดเจน
- `Active` — ความคิดเห็นอยู่ในสถานะใช้งาน
- `Resolved` — ความคิดเห็นได้รับการแก้ไขแล้ว
- `Closed` — ความคิดเห็นอยู่ในสถานะปิด  

ตัวอย่างยึดความคิดเห็นสมัยใหม่กับคำว่า “quarterly revenue” ในข้อความของสี่เหลี่ยม คำนวณตำแหน่งเริ่มต้นการเลือกที่เริ่มจากศูนย์จากข้อความและส่งค่าไปยังเมธอด [setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) จากนั้นใช้ [setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) เพื่อกำหนดจำนวนอักษรที่เลือก หลังจากเรียก [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) ด้วยค่า `Resolved` จะบันทึกและเปิดงานนำเสนอใหม่ ตรวจสอบคอนโซลสี่ครั้งควรพิมพ์ `true` ทั้งหมดเพื่อยืนยันว่าจุดยึดรูปทรง, ช่วงข้อความและสถานะถูกเก็บไว้

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
import android.graphics.PointF;
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
    PointF commentPosition = new PointF(60, 60);
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

ตัวอย่างต้องการงานนำเสนอที่มีความคิดเห็นสมัยใหม่อยู่แล้วและพิมพ์ข้อความ, สถานะและรายละเอียดจุดยึดของแต่ละความคิดเห็น เพื่อตรวจสอบ ให้ตรวจดูว่าความคิดเห็นใดบ้างที่ทำตามอินเทอร์เฟซ [IModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/), จากนั้นตรวจสอบเมธอด [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), และ [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) `null` shape ระบุว่าความคิดเห็นเป็นระดับสไลด์ สำหรับจุดยึดที่เป็น [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) วิธีการเลือกข้อความจะระบุช่วงที่เชื่อมโยงในกรอบข้อความของรูปร่าง

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

Aspose.Slides for Android via Java ให้คุณลบความคิดเห็นทั้งหมดและผู้เขียนความคิดเห็นจากงานนำเสนอหรือทำการลบความคิดเห็นที่เลือกไว้ขณะรักษาอื่น ๆ ไว้ ตัวอย่างต่อไปนี้สาธิตทั้งสองวิธีและบันทึกงานนำเสนอที่อัปเดต  

### **ลบความคิดเห็นและผู้เขียนความคิดเห็นทั้งหมด**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเรียกเมธอด [ICommentCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#clear--) สำหรับผู้เขียนแต่ละคน จากนั้นเรียกเมธอด [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#clear--) เพื่อลบผู้เขียนเอง งานนำเสนอที่บันทึกจะไม่มีความคิดเห็นหรือผู้เขียนความคิดเห็นเลย ใช้งานนำเสนอที่มีความคิดเห็นเพื่อสังเกตการลบ

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

ตัวอย่างสร้างความคิดเห็นสองรายการบนสไลด์เดียวและใช้เมธอด [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) เพื่อค้นหาความคิดเห็นของแต่ละผู้เขียน มันจะเก็บความคิดเห็นที่ข้อความเท่ากับ “comment 1” ก่อนเรียกเมธอด [ICommentCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-) เพื่อหลีกเลี่ยงการเปลี่ยนแปลงคอลเลกชันระหว่างการเลือก งานนำเสนอที่บันทึกจะเหลือเพียง “comment 2” เท่านั้น

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    PointF firstCommentPosition = new PointF(0.2f, 0.2f);
    PointF secondCommentPosition = new PointF(0.3f, 0.2f);
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

ใช่ — เมธอด [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) และ [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) เข้าถึงค่าจากคอนสแตนท์ [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) รวมถึง `Resolved` สถานะจะถูกบันทึกในงานนำเสนอและสามารถอ่านได้อีกครั้งเมื่อไฟล์ถูกเปิดใหม่  

**การสนทนาแบบเธรด (สายตอบกลับ) ได้รับการสนับสนุนหรือไม่ และมีขีดจำกัดการซ้อนลึกหรือไม่?**

ใช่ — แต่ละความคิดเห็นสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) ทำให้สามารถสร้างสายตอบกลับได้ API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อน  

**ตำแหน่งเครื่องหมายความคิดเห็นบนสไลด์ถูกกำหนดในระบบพิกัดใด?**

ตำแหน่งเครื่องหมายถูกกำหนดโดยพิกัดลอยตัวในระบบพิกัดของสไลด์ ทำให้คุณวางเครื่องหมายได้อย่างแม่นยำบนสไลด์  