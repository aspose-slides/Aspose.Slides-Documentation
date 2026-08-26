---
title: จัดการความคิดเห็นในงานนำเสนอด้วย Java
linktitle: ความคิดเห็นงานนำเสนอ
type: docs
weight: 100
url: /th/java/presentation-comments/
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
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for Java: เพิ่ม, อ่าน, แก้ไข, ตอบกลับ, และลบความคิดเห็นในงานนำเสนอ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการความคิดเห็นในงานนำเสนอด้วย Aspose.Slides for Java. มันแนะนำประเภทที่เกี่ยวข้องกับความคิดเห็นหลักและแสดงวิธีการเพิ่มความคิดเห็นลงในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับและความคิดเห็นสมัยใหม่, และลบความคิดเห็นออกจากงานนำเสนอ.

ตัวอย่างครอบคลุมสถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint, เช่น การกำหนดความคิดเห็นให้ผู้เขียน, การอ่านข้อความและเมตาดาต้าของความคิดเห็น, การสร้างสายการตอบกลับ, และการลบความคิดเห็นที่เลือกหรือทั้งหมด.

ใน PowerPoint, ความคิดเห็นปรากฏเป็นคำอธิบายบนสไลด์. การเลือกความคิดเห็นจะแสดงข้อความและการสนทนาที่เกี่ยวข้อง.

## **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณสามารถใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะและทำงานร่วมกับเพื่อนร่วมงานเมื่อทำการตรวจทานงานนำเสนอ.

Aspose.Slides for Java ให้ API ต่อไปนี้สำหรับการทำงานกับความคิดเห็น:

* คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ซึ่งให้การเข้าถึงผู้เขียนความคิดเห็นของงานนำเสนอ.
* อินเทอร์เฟซ [ICommentCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icommentcollection/) ที่แสดงถึงความคิดเห็นที่เชื่อมโยงกับผู้เขียนแต่ละคน.
* อินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/icomment/) ที่ให้ข้อมูลเกี่ยวกับความคิดเห็นรวมถึงผู้เขียน, เวลาในการสร้าง, ตำแหน่ง, และข้อความ.
* คลาส [CommentAuthor](https://reference.aspose.com/slides/th/java/com.aspose.slides/commentauthor/) ที่ให้ข้อมูลเกี่ยวกับผู้เขียนรวมถึงชื่อ, อักษรย่อ, และความคิดเห็นที่เชื่อมโยง.

## **เพิ่มความคิดเห็นในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มความคิดเห็นในสไลด์ของงานนำเสนอ PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
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

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เข้าถึงความคิดเห็นในสไลด์**

ตัวอย่างต่อไปนี้แสดงวิธีเข้าถึงความคิดเห็นที่มีอยู่ในงานนำเสนอ PowerPoint:

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

คอมเมนต์แม่คือคอมเมนต์ต้นฉบับที่อยู่บนสุดของลำดับตอบกลับ. วิธี [IComment.getParentComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/icomment/#getParentComment--) และ [IComment.setParentComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) ให้คุณดึงหรือกำหนดคอมเมนต์แม่ของคอมเมนต์.

ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มการตอบกลับและตรวจสอบโครงสร้างความคิดเห็นที่ได้:

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

{{% alert color="warning" title="คำเตือน" %}}
* เมื่อใช้เมธอด [IComment.remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/icomment/#remove--) เพื่อลบคอมเมนต์, การตอบกลับทั้งหมดของคอมเมนต์นั้นก็จะถูกลบด้วย.
* หาก [IComment.setParentComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) สร้างการอ้างอิงวงกลม, จะเกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ความคิดเห็นสมัยใหม่สามารถเชื่อมโยงกับสไลด์โดยตรง, กับรูปร่างเฉพาะ, หรือกับช่วงข้อความภายใน AutoShape. เมธอด [ICommentCollection.addModernComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) ยอมรับอาร์กิวเมนต์ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) นอกจากสไลด์และพิกัดของเครื่องหมายความคิดเห็นด้วย.

เมื่อส่งค่า `null` เป็นอาร์กิวเมนต์รูปทรง, ความคิดเห็นจะเป็นความคิดเห็นระดับสไลด์. เครื่องหมายจะวางตามพิกัดที่ระบุแต่ไม่ได้เชื่อมโยงกับรูปทรงใด, ดังนั้น [IModernComment.getShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#getShape--) จะคืนค่า `null`. เมื่อตั้งค่าอาร์กิวเมนต์เป็น [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/), ความคิดเห็นจะยึดติดกับรูปทรงนั้น. พิกัดยังคงกำหนดตำแหน่งของเครื่องหมายบนสไลด์, ส่วนการเชื่อมโยงกับรูปทรงสามารถดึงได้ผ่าน [IModernComment.getShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#getShape--).

### **ยึดความคิดเห็นสมัยใหม่กับรูปร่าง**

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ระดับสไลด์และความคิดเห็นสมัยใหม่ที่ยึดกับ AutoShape เฉพาะ. จากนั้นอ่านรูปร่างที่เชื่อมโยงจากแต่ละความคิดเห็น.

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

### **ยึดความคิดเห็นกับรูปแบบรูปร่างที่แตกต่างกัน**

ออบเจ็กต์สไลด์ใด ๆ ที่ทำการ 구현 [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) สามารถใช้เป็นตัวยึดรูปร่างได้. ตัวอย่างทั่วไปรวมถึง [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/th/java/com.aspose.slides/iconnector/), และอินสแตนซ์ [IGraphicalObject](https://reference.aspose.com/slides/th/java/com.aspose.slides/igraphicalobject/) เช่นแผนภูมิ.

ตัวอย่างต่อไปนี้สร้างรูปแบบรูปร่างหลายประเภทและเชื่อมโยงความคิดเห็นสมัยใหม่กับแต่ละรูปแบบ.

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

### **ยึดความคิดเห็นไปยังข้อความและกำหนดสถานะของมัน**

สำหรับความคิดเห็นสมัยใหม่ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/), เมธอด [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) และ [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) เข้าถึงตำแหน่งเริ่มต้นของข้อความที่เลือกในเฟรมข้อความของรูปร่าง. เมธอด [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) และ [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) เข้าถึงความยาวของการเลือก. ค่าต่าง ๆ เหล่านี้ทำให้ความคิดเห็นเชื่อมโยงกับช่วงข้อความเฉพาะภายใน AutoShape.

เมธอด [IModernComment.getStatus](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#getStatus--) และ [IModernComment.setStatus](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#setStatus-byte--) เข้าถึงค่าจากคอนสแตนท์ [ModernCommentStatus](https://reference.aspose.com/slides/th/java/com.aspose.slides/moderncommentstatus/) :

- `NotDefined` — ไม่ได้กำหนดสถานะของความคิดเห็นสมัยใหม่.
- `Active` — ความคิดเห็นกำลังใช้งาน.
- `Resolved` — ความคิดเห็นได้ถูกแก้ไขแล้ว.
- `Closed` — ความคิดเห็นได้ถูกปิด.

ตัวอย่างต่อไปนี้สร้างความคิดเห็นสมัยใหม่ที่ยึดกับรูปร่าง, เชื่อมโยงกับการเลือกข้อความ, ทำเครื่องหมายว่าแก้ไขแล้ว, บันทึกงานนำเสนอ, และตรวจสอบค่าเหล่านั้นหลังจากเปิดไฟล์ใหม่อีกครั้ง.

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

เพื่อทำการตรวจสอบงานนำเสนอที่มีอยู่, ตรวจสอบว่าความคิดเห็นใดบ้างที่ทำการ 구현 [IModernComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/), จากนั้นตรวจสอบ [IModernComment.getShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--), และ [IModernComment.getStatus](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#getStatus--). รูปร่าง `null` หมายถึงความคิดเห็นระดับสไลด์. สำหรับตัวยึด [IAutoShape] การใช้เมธอดเลือกข้อความจะบ่งบอกช่วงที่เชื่อมโยงในเฟรมข้อความของรูปร่าง.

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

### **ลบความคิดเห็นและผู้เขียนทั้งหมด**

ตัวอย่างต่อไปนี้แสดงวิธีลบความคิดเห็นและผู้เขียนความคิดเห็นทั้งหมดจากงานนำเสนอ:

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

### **ลบความคิดเห็นที่เฉพาะเจาะจง**

ตัวอย่างต่อไปนี้แสดงวิธีลบความคิดเห็นที่เฉพาะเจาะจงจากสไลด์:

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

ใช่. เมธอด [IModernComment.getStatus](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#getStatus--) และ [IModernComment.setStatus](https://reference.aspose.com/slides/th/java/com.aspose.slides/imoderncomment/#setStatus-byte-) เข้าถึงค่าจากคอนสแตนท์ [ModernCommentStatus](https://reference.aspose.com/slides/th/java/com.aspose.slides/moderncommentstatus/) รวมถึง `Resolved`. สถานะจะถูกเก็บในงานนำเสนอและสามารถอ่านได้อีกครั้งหลังจากเปิดไฟล์ใหม่.

**รองรับการสนทนาแบบเธรด (สายการตอบกลับ) หรือไม่, และมีขีดจำกัดระดับการซ้อนกันหรือไม่?**

ใช่. แต่ละความคิดเห็นสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/java/com.aspose.slides/icomment/#getParentComment--) ของมัน, ทำให้สามารถสร้างสายการตอบกลับได้. API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกันโดยเฉพาะ.

**ตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดอะไร?**

ตำแหน่งของเครื่องหมายถูกกำหนดด้วยพิกัดแบบ floating-point ในระบบพิกัดของสไลด์, ทำให้คุณสามารถวางตำแหน่งได้อย่างแม่นยำบนสไลด์.