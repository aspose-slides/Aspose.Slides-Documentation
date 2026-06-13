---
title: จัดการคอมเมนต์งานนำเสนอใน Java
linktitle: คอมเมนต์งานนำเสนอ
type: docs
weight: 100
url: /th/java/presentation-comments/
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
- ถอนคอมเมนต์
- ลบคอมเมนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมคอมเมนต์งานนำเสนอด้วย Aspose.Slides สำหรับ Java: เพิ่ม, อ่าน, แก้ไข และลบคอมเมนต์ในไฟล์ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการคอมเมนต์ในงานนำเสนอด้วย Aspose.Slides โดยแสดงชนิดข้อมูลที่เกี่ยวข้องกับคอมเมนต์หลักและสาธิตวิธีเพิ่มคอมเมนต์ลงในสไลด์, เข้าถึงคอมเมนต์ที่มีอยู่, ทำงานกับการตอบกลับ, ใช้คอมเมนต์สมัยใหม่, และลบคอมเมนต์ออกจากงานนำเสนอ

ตัวอย่างมุ่งเน้นการรีวิวและการทำงานร่วมกันที่พบบ่อยใน PowerPoint เช่น การมอบหมายคอมเมนต์ให้ผู้เขียน, การอ่านเนื้อหาและเมตาดาต้าของคอมเมนต์, การสร้างสายตอบกลับ, และการลบคอมเมนต์ทั้งหมดหรือคอมเมนต์ที่เลือก

ใน PowerPoint คอมเมนต์จะแสดงเป็นหมายเหตุหรือคำอธิบายบนสไลด์ เมื่อคลิกที่คอมเมนต์เนื้อหาหรือข้อความของมันจะปรากฏขึ้น

## **ทำไมต้องเพิ่มคอมเมนต์ในงานนำเสนอ?**

คุณอาจต้องการใช้คอมเมนต์เพื่อให้ข้อเสนอแนะหรือสื่อสารกับเพื่อนร่วมงานเมื่อทำการรีวิวงานนำเสนอ

เพื่อให้คุณสามารถใช้คอมเมนต์ในงานนำเสนอ PowerPoint, Aspose.Slides for Java มีให้

* คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่มีคอลเลกชันของผู้เขียน (จากอินเทอร์เฟซ [ICommentAuthorCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICommentAuthorCollection)). ผู้เขียนจะเพิ่มคอมเมนต์ในสไลด์  
* อินเทอร์เฟซ [ICommentCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICommentCollection) ที่เก็บคอลเลกชันของคอมเมนต์สำหรับผู้เขียนแต่ละคน  
* คลาส [IComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/IComment) ที่มีข้อมูลเกี่ยวกับผู้เขียนและคอมเมนต์ของพวกเขา: ใครเพิ่มคอมเมนต์, เวลาเพิ่มคอมเมนต์, ตำแหน่งของคอมเมนต์ ฯลฯ  
* คลาส [CommentAuthor](https://reference.aspose.com/slides/th/java/com.aspose.slides/CommentAuthor) ที่มีข้อมูลของผู้เขียนแต่ละคน: ชื่อผู้เขียน, ตัวอักษรย่อ, คอมเมนต์ที่เชื่อมโยงกับชื่อผู้เขียน ฯลฯ  

## **เพิ่มคอมเมนต์สไลด์**
โค้ด Java นี้แสดงวิธีเพิ่มคอมเมนต์ลงในสไลด์ของงานนำเสนอ PowerPoint:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // เพิ่มสไลด์เปล่า
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // เพิ่มผู้เขียน
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // กำหนดตำแหน่งสำหรับคอมเมนต์
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // เพิ่มคอมเมนต์สไลด์สำหรับผู้เขียนบนสไลด์ 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // เพิ่มคอมเมนต์สไลด์สำหรับผู้เขียนบนสไลด์ 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // เข้าถึง ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // เมื่อส่งค่า null เป็นอาร์กิวเมนต์ คอมเมนต์จากผู้เขียนทั้งหมดจะถูกนำมาที่สไลด์ที่เลือก
    IComment[] Comments = slide.getSlideComments(author);

    // เข้าถึงคอมเมนต์ที่ตำแหน่งดัชนี 0 สำหรับสไลด์ 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // เลือกคอลเลกชันคอมเมนต์ของผู้เขียนที่ตำแหน่งดัชนี 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **เข้าถึงคอมเมนต์สไลด์**
โค้ด Java นี้แสดงวิธีเข้าถึงคอมเมนต์ที่มีอยู่บนสไลด์ของงานนำเสนอ PowerPoint:

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตอบคอมเมนต์**
คอมเมนต์หลักคือคอมเมนต์ต้นหรือคอมเมนต์แรกในโครงสร้างลำดับของคอมเมนต์หรือการตอบกลับ โดยใช้เมธอด [getParentComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/IComment#getParentComment--) หรือ [setParentComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (จากอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/IComment)) คุณสามารถตั้งหรือรับคอมเมนต์หลักได้

โค้ด Java นี้แสดงวิธีเพิ่มคอมเมนต์และรับการตอบกลับของคอมเมนต์:

```java
Presentation pres = new Presentation();
try {
    // เพิ่มคอมเมนต์
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // เพิ่มการตอบกลับให้กับ comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // เพิ่มการตอบกลับอื่นให้กับ comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // เพิ่มการตอบกลับให้กับการตอบกลับที่มีอยู่
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // แสดงโครงสร้างคอมเมนต์บนคอนโซล
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // ลบ comment1 และการตอบกลับทั้งหมดของมัน
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="แจ้งเตือน" %}} 
* เมื่อเมธอด [Remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/IComment#remove--) (จากอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/IComment)) ถูกใช้เพื่อลบคอมเมนต์ การตอบกลับของคอมเมนต์นั้นก็จะถูกลบด้วย  
* หากการตั้งค่า [setParentComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) ทำให้เกิดการอ้างอิงวนกลับ จะเกิดการโยนข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/java/com.aspose.slides/PptxEditException)
{{% /alert %}}

## **เพิ่มคอมเมนต์สมัยใหม่**

ในปี 2021 Microsoft ได้นำ *คอมเมนต์สมัยใหม่* เข้ามาใน PowerPoint คุณสมบัติคอมเมนต์สมัยใหม่ช่วยปรับการทำงานร่วมกันใน PowerPoint อย่างมีนัยสำคัญ ผ่านคอมเมนต์สมัยใหม่ ผู้ใช้ PowerPoint สามารถแก้ไขคอมเมนต์, ผูกคอมเมนต์เข้ากับวัตถุและข้อความ, และทำปฏิสัมพันธ์ได้ง่ายกว่าที่เคย

ใน [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/th/java/aspose-slides-for-java-21-11-release-notes/) เราได้เพิ่มการสนับสนุนคอมเมนต์สมัยใหม่โดยการเพิ่มคลาส [ModernComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/ModernComment) เมธอด [addModernComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) และ [insertModernComment](https://reference.aspose.com/slides/th/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) ถูกเพิ่มเข้าไปในคลาส [CommentCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/CommentCollection)

โค้ด Java นี้แสดงวิธีเพิ่มคอมเมนต์สมัยใหม่ลงในสไลด์ของงานนำเสนอ PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบคอมเมนต์**

### **ลบคอมเมนต์และผู้เขียนทั้งหมด**
โค้ด Java นี้แสดงวิธีลบคอมเมนต์และผู้เขียนทั้งหมดในงานนำเสนอ:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // ลบคอมเมนต์ทั้งหมดจากงานนำเสนอ
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // ลบผู้เขียนทั้งหมด
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **ลบคอมเมนต์เฉพาะ**
โค้ด Java นี้แสดงวิธีลบคอมเมนต์เฉพาะบนสไลด์:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มคอมเมนต์...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // ลบคอมเมนต์ทั้งหมดที่มีข้อความ "comment 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับสถานะเช่น 'resolved' สำหรับคอมเมนต์สมัยใหม่หรือไม่?**  
ใช่. [Modern comments](https://reference.aspose.com/slides/th/java/com.aspose.slides/moderncomment/) มีเมธอด [setStatus](https://reference.aspose.com/slides/th/java/com.aspose.slides/moderncomment/#setStatus-byte-) คุณสามารถกำหนดสถานะของคอมเมนต์ (เช่น ทำเครื่องหมายว่าถูกแก้ไข) และสถานะนี้จะถูกบันทึกในไฟล์และ PowerPoint จะรับรู้

**รองรับการสนทนาตามลำดับ (สายตอบกลับ) หรือไม่ และมีขีดจำกัดการซ้อนกันหรือไม่?**  
ใช่. คอมเมนต์แต่ละรายการสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/java/com.aspose.slides/comment/#getParentComment--) ทำให้สามารถสร้างสายตอบกลับได้ตามต้องการ API ไม่ได้กำหนดขีดจำกัดความลึกของการซ้อนกัน

**ตำแหน่งของตัวบ่งชี้คอมเมนต์บนสไลด์กำหนดในระบบพิกัดใด?**  
ตำแหน่งถูกจัดเก็บเป็นจุดทศนิยมในระบบพิกัดของสไลด์ ทำให้คุณสามารถวางตัวบ่งชี้คอมเมนต์ได้อย่างแม่นยำตามที่ต้องการ