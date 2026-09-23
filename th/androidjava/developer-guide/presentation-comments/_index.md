---
title: จัดการคอมเมนต์การนำเสนอบน Android
linktitle: คอมเมนต์การนำเสนอ
type: docs
weight: 100
url: /th/androidjava/presentation-comments/
keywords:
- คอมเมนต์
- คอมเมนต์สมัยใหม่
- คอมเมนต์ PowerPoint
- คอมเมนต์การนำเสนอ
- คอมเมนต์สไลด์
- เพิ่มคอมเมนต์
- เข้าถึงคอมเมนต์
- แก้ไขคอมเมนต์
- ตอบกลับคอมเมนต์
- ลบคอมเมนต์
- ลบคอมเมนต์
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการคอมเมนต์การนำเสนอด้วย Aspose.Slides สำหรับ Android ผ่าน Java: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบคอมเมนต์ในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการคอมเมนต์การนำเสนอด้วย Aspose.Slides for Android via Java. มันแนะนำประเภทที่เกี่ยวข้องกับคอมเมนต์หลักและสาธิตวิธีการเพิ่มคอมเมนต์ลงในสไลด์, เข้าถึงคอมเมนต์ที่มีอยู่, ทำงานกับการตอบกลับและคอมเมนต์สมัยใหม่, และลบคอมเมนต์จากการนำเสนอ

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดคอมเมนต์ให้กับผู้เขียน, อ่านข้อความคอมเมนต์และเมตาดาต้า, สร้างสายตอบกลับ, และลบคอมเมนต์ที่เลือกหรือทั้งหมด

ใน PowerPoint คอมเมนต์จะแสดงเป็นคำอธิบายบนสไลด์ การเลือกคอมเมนต์จะแสดงข้อความและการสนทนาที่เกี่ยวข้อง

หากต้องการร้องขอให้แสดงหรือซ่อนคอมเมนต์เมื่อเปิดการนำเสนอโดยไม่เปลี่ยนแปลงคอมเมนต์เอง ให้ดูที่ [แสดงหรือซ่อนคอมเมนต์เมื่อเปิดการนำเสนอ](/slides/th/androidjava/presentation-view-properties/)

## **ทำไมต้องเพิ่มคอมเมนต์ในงานนำเสนอ?**

คุณสามารถใช้คอมเมนต์เพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อรีวิวงานนำเสนอ

Aspose.Slides for Android via Java มี API ต่อไปนี้สำหรับการทำงานกับคอมเมนต์:

* คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ที่ให้การเข้าถึงผู้เขียนคอมเมนต์ของการนำเสนอ
* อินเทอร์เฟซ [ICommentCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icommentcollection/) ที่แสดงคอมเมนต์ที่เชื่อมโยงกับผู้เขียนแต่ละคน
* อินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icomment/) ที่ให้ข้อมูลเกี่ยวกับคอมเมนต์รวมถึงผู้เขียน, เวลาสร้าง, ตำแหน่งและข้อความ
* คลาส [CommentAuthor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/commentauthor/) ที่ให้ข้อมูลเกี่ยวกับผู้เขียนรวมถึงชื่อ, ชื่อย่อและคอมเมนต์ที่เชื่อมโยง

## **เพิ่มคอมเมนต์ในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีการเพิ่มคอมเมนต์ลงในสไลด์ของ PowerPoint presentation:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
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

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เข้าถึงคอมเมนต์ในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีการเข้าถึงคอมเมนต์ที่มีอยู่ใน PowerPoint presentation:

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

## **ตอบกลับคอมเมนต์**

คอมเมนต์พาเรนต์คือคอมเมนต์ต้นฉบับที่อยู่บนสุดของลำดับขั้นการตอบกลับ เมธอด [IComment.getParentComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icomment/#getParentComment--) และ [IComment.setParentComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) ให้คุณดึงหรือกำหนดพาเรนต์ของคอมเมนต์

ตัวอย่างต่อไปนี้แสดงวิธีการเพิ่มการตอบกลับและตรวจสอบโครงสร้างคอมเมนต์ที่ได้:

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

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

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

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* เมื่อใช้เมธอด [IComment.remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icomment/#remove--) เพื่อลบคอมเมนต์, การตอบกลับทั้งหมดของคอมเมนต์นั้นก็จะถูกลบด้วย
* หาก [IComment.setParentComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) สร้างการอ้างอิงแบบวงกลม, จะเกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxeditexception/)
{{% /alert %}}

## **เพิ่มคอมเมนต์สมัยใหม่**

คอมเมนต์สมัยใหม่สามารถเชื่อมโยงกับสไลด์โดยตรง, กับรูปร่างเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape เมธอด [ICommentCollection.addModernComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) รับอาร์กิวเมนต์ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) นอกเหนือจากสไลด์และพิกัดของเครื่องหมายคอมเมนต์

เมื่อ `null` ถูกส่งเป็นอาร์กิวเมนต์รูปร่าง, คอมเมนต์จะเป็นคอมเมนต์ระดับสไลด์ เครื่องหมายจะถูกวางตามพิกัดที่ระบุ แต่จะไม่เชื่อมโยงกับรูปร่างใด, ดังนั้น [IModernComment.getShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#getShape--) จะคืนค่า `null` เมื่อส่ง [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) มา, คอมเมนต์จะถูกยึดกับรูปร่างนั้น พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายคอมเมนต์บนสไลด์, ส่วนการเชื่อมโยงรูปร่างสามารถดึงได้ผ่าน [IModernComment.getShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#getShape--)

### **ยึดคอมเมนต์สมัยใหม่เข้ากับรูปร่าง**

ตัวอย่างต่อไปนี้สร้างคอมเมนต์สมัยใหม่ระดับสไลด์และคอมเมนต์สมัยใหม่ที่ยึดกับ AutoShape เฉพาะ แล้วอ่านรูปร่างที่เชื่อมโยงจากแต่ละคอมเมนต์

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

### **ยึดคอมเมนต์ไปยังประเภทรูปร่างต่าง ๆ**

ออบเจกต์สไลด์ใดที่ implements [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) สามารถใช้เป็นจุดยึดรูปร่างได้ ตัวอย่างทั่วไปได้แก่ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iconnector/) และอินสแตนซ์ของ [IGraphicalObject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igraphicalobject/) เช่น แช็ต

ตัวอย่างต่อไปนี้สร้างรูปร่างประเภทต่าง ๆ ที่ใช้บ่อยและเชื่อมโยงคอมเมนต์สมัยใหม่กับแต่ละรูปร่าง

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
import java.util.Base64;
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
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
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

### **ยึดคอมเมนต์ไปยังข้อความและตั้งค่าสถานะ**

สำหรับคอมเมนต์สมัยใหม่ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/), เมธอด [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) และ [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) เข้าถึงตำแหน่งเริ่มต้นของข้อความที่เลือกใน TextFrame ของรูปร่าง. เมธอด [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) และ [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) เข้าถึงความยาวของการเลือก. ค่าทั้งสองนี้ทำให้คอมเมนต์เชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape

เมธอด [IModernComment.getStatus](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#getStatus--) และ [IModernComment.setStatus](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) เข้าถึงค่าจากคอนสแตนท์ [ModernCommentStatus](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — ไม่ได้กำหนดสถานะคอมเมนต์สมัยใหม่เฉพาะ
- `Active` — คอมเมนต์อยู่ในสถานะทำงาน
- `Resolved` — คอมเมนต์ได้รับการแก้ไขแล้ว
- `Closed` — คอมเมนต์ถูกปิด

ตัวอย่างต่อไปนี้สร้างคอมเมนต์สมัยใหม่ที่ยึดกับรูปร่าง, เชื่อมโยงกับการเลือกข้อความ, ตั้งค่าสถานะเป็น Resolved, บันทึกการนำเสนอและตรวจสอบค่าหลังเปิดไฟล์ใหม่

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

### **ตรวจสอบคอมเมนต์สมัยใหม่ที่มีอยู่**

เพื่อตรวจสอบการนำเสนอที่มีอยู่, ตรวจสอบคอมเมนต์ที่ implement [IModernComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/), จากนั้นดูที่ [IModernComment.getShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), และ [IModernComment.getStatus](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#getStatus--). รูปร่างที่เป็น `null` หมายถึงคอมเมนต์ระดับสไลด์ สำหรับจุดยึดเป็น [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/), เมธอดเลือกข้อความจะแสดงช่วงที่เชื่อมโยงใน TextFrame ของรูปร่าง

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

## **ลบคอมเมนต์**

### **ลบคอมเมนต์และผู้เขียนคอมเมนต์ทั้งหมด**

ตัวอย่างต่อไปนี้แสดงวิธีการลบคอมเมนต์และผู้เขียนคอมเมนต์ทั้งหมดจากการนำเสนอ:

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

### **ลบคอมเมนต์เฉพาะ**

ตัวอย่างต่อไปนี้แสดงวิธีการลบคอมเมนต์เฉพาะจากสไลด์:

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

**Aspose.Slides รองรับสถานะ Resolved สำหรับคอมเมนต์สมัยใหม่หรือไม่?**

ใช่. เมธอด [IModernComment.getStatus](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#getStatus--) และ [IModernComment.setStatus](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) เข้าถึงค่า [ModernCommentStatus](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/moderncommentstatus/) รวมถึง `Resolved`. สถานะจะถูกเก็บไว้ในการนำเสนอและสามารถอ่านได้อีกครั้งหลังจากเปิดไฟล์ใหม่

**การสนทนาที่เป็นเธรด (สายตอบกลับ) ได้รับการสนับสนุนหรือไม่, และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. คอมเมนต์แต่ละรายการสามารถอ้างอิงไปยัง [parent comment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icomment/#getParentComment--) เพื่อสร้างสายตอบกลับ API ไม่ได้กำหนดขีดจำกัดความลึกการซ้อนเฉพาะ

**ตำแหน่งของเครื่องหมายคอมเมนต์บนสไลด์ถูกกำหนดในระบบพิกัดใด?**

ตำแหน่งเครื่องหมายถูกกำหนดโดยพิกัด floating‑point ในระบบพิกัดของสไลด์ ทำให้คุณสามารถวางตำแหน่งได้อย่างแม่นยำบนสไลด์