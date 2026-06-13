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
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมความคิดเห็นการนำเสนอด้วย Aspose.Slides สำหรับ Android ผ่าน Java: เพิ่ม, อ่าน, แก้ไข และลบความคิดเห็นในไฟล์ PowerPoint อย่างรวดเร็วและง่ายดาย."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการความคิดเห็นในการนำเสนอด้วย Aspose.Slides แสดงประเภทหลักที่เกี่ยวข้องกับความคิดเห็นและสาธิตวิธีการเพิ่มความคิดเห็นลงในสไลด์, เข้าถึงความคิดเห็นที่มีอยู่, ทำงานกับการตอบกลับ, ใช้ความคิดเห็นสมัยใหม่, และลบความคิดเห็นออกจากการนำเสนอ

ตัวอย่างจะเน้นที่สถานการณ์การตรวจสอบและการทำงานร่วมกันทั่วไปใน PowerPoint เช่น การกำหนดความคิดเห็นให้กับผู้เขียน, การอ่านเนื้อหาและเมทาดาทาของความคิดเห็น, การสร้างห่วงโซ่การตอบกลับ, และการลบความคิดเห็นทั้งหมดหรือการลบความคิดเห็นที่เลือกไว้

ใน PowerPoint ความคิดเห็นจะแสดงเป็นโน้ตหรือคำอธิบายบนสไลด์ เมื่อคลิกที่ความคิดเห็น เนื้อหาหรือข้อความของมันจะปรากฏขึ้น

### **ทำไมต้องเพิ่มความคิดเห็นในงานนำเสนอ?**

คุณอาจต้องการใช้ความคิดเห็นเพื่อให้ข้อเสนอแนะหรือสื่อสารกับเพื่อนร่วมงานเมื่อคุณตรวจสอบงานนำเสนอ

เพื่อให้คุณสามารถใช้ความคิดเห็นในงานนำเสนอ PowerPoint ได้ Aspose.Slides for Android via Java มีให้
* The [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) class, ซึ่งบรรจุคอลเลกชันของผู้เขียน (จากอินเทอร์เฟซ [ICommentAuthorCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICommentAuthorCollection)). ผู้เขียนจะเพิ่มความคิดเห็นลงในสไลด์.
* The  [ICommentCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICommentCollection) interface, ซึ่งบรรจุคอลเลกชันของความคิดเห็นสำหรับผู้เขียนแต่ละคน.
* The  [IComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IComment) class, ซึ่งบรรจุข้อมูลเกี่ยวกับผู้เขียนและความคิดเห็นของพวกเขา: ผู้ที่เพิ่มความคิดเห็น, เวลาเพิ่มความคิดเห็น, ตำแหน่งของความคิดเห็น ฯลฯ.
* The [CommentAuthor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/CommentAuthor) class, ซึ่งบรรจุข้อมูลเกี่ยวกับผู้เขียนแต่ละคน: ชื่อผู้เขียน, อักษรย่อของเขา, ความคิดเห็นที่เชื่อมโยงกับชื่อผู้เขียน ฯลฯ.

## **เพิ่มความคิดเห็นในสไลด์**
โค้ด Java นี้แสดงวิธีการเพิ่มความคิดเห็นลงในสไลด์ของงานนำเสนอ PowerPoint:

```java
    // สร้างอินสแตนซ์ของคลาส Presentation
    Presentation pres = new Presentation();
    try {
        // เพิ่มสไลด์เปล่า
        pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    
        // เพิ่มผู้เขียน
        ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    
        // ตั้งค่าตำแหน่งสำหรับความคิดเห็น
        Point2D.Float point = new Point2D.Float(0.2f, 0.2f);
    
        // เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ที่ 1
        author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());
    
        // เพิ่มความคิดเห็นสไลด์สำหรับผู้เขียนบนสไลด์ที่ 2
        author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());
    
        // เข้าถึง ISlide 1
        ISlide slide = pres.getSlides().get_Item(0);
    
        // เมื่อส่งค่า null เป็นอาร์กิวเมนต์ ความคิดเห็นจากผู้เขียนทั้งหมดจะถูกนำมาที่สไลด์ที่เลือก
        IComment[] Comments = slide.getSlideComments(author);
    
        // เข้าถึงความคิดเห็นที่ตำแหน่งดัชนี 0 สำหรับสไลด์ที่ 1
        String str = Comments[0].getText();
    
        pres.save("Comments_out.pptx", SaveFormat.Pptx);
    
        if (Comments.length > 0)
        {
            // เลือกคอลเลกชันความคิดเห็นของผู้เขียนที่ดัชนี 0
            ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
            String Comment = commentCollection.get_Item(0).getText();
        }
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **เข้าถึงความคิดเห็นในสไลด์**
โค้ด Java นี้แสดงวิธีการเข้าถึงความคิดเห็นที่มีอยู่ในสไลด์ของงานนำเสนอ PowerPoint:

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

## **ตอบกลับความคิดเห็น**
ความคิดเห็นพาเรนท์คือความคิดเห็นระดับบนหรือความคิดเห็นต้นฉบับในโครงสร้างของความคิดเห็นหรือการตอบกลับ โดยใช้เมธอด [getParentComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IComment#getParentComment--) หรือ [setParentComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (จากอินเทอร์เฟซ [IComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IComment)) คุณสามารถตั้งหรือรับความคิดเห็นพาเรนท์ได้

โค้ด Java นี้แสดงวิธีการเพิ่มความคิดเห็นและรับการตอบกลับต่อความคิดเห็นเหล่านั้น:

```java
Presentation pres = new Presentation();
try {
    // เพิ่มความคิดเห็น
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // เพิ่มการตอบกลับให้ comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // เพิ่มการตอบกลับอื่นให้ comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // เพิ่มการตอบกลับให้การตอบกลับที่มีอยู่
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // แสดงลำดับความสัมพันธ์ของความคิดเห็นบนคอนโซล
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

{{% alert color="warning" title="Attention" %}} 
* เมื่อเมธอด [Remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IComment#remove--) (จากอินเทอร์เฟซ [IComment]) ถูกใช้เพื่อลบความคิดเห็น การตอบกลับของความคิดเห็นนั้นก็จะถูกลบด้วย
* หากการตั้งค่า [setParentComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) ทำให้เกิดการอ้างอิงแบบวงกลม จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PptxEditException) 
{{% /alert %}}

## **เพิ่มความคิดเห็นสมัยใหม่**

ในปี 2021 Microsoft ได้แนะนำ *ความคิดเห็นสมัยใหม่* ใน PowerPoint ฟีเจอร์ความคิดเห็นสมัยใหม่ช่วยปรับปรุงการทำงานร่วมกันใน PowerPoint อย่างมีนัยสำคัญ ด้วยความคิดเห็นสมัยใหม่ ผู้ใช้ PowerPoint สามารถแก้ไขความคิดเห็น, ยึดความคิดเห็นกับวัตถุและข้อความ, และมีปฏิสัมพันธ์ได้ง่ายขึ้นมากกว่าก่อน

Aspose.Slides รองรับความคิดเห็นสมัยใหม่ด้วยคลาส [ModernComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ModernComment). เพิ่มเมธอด [addModernComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) และ [insertModernComment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) ในคลาส [CommentCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/CommentCollection)

โค้ด Java นี้แสดงวิธีการเพิ่มความคิดเห็นสมัยใหม่ลงในสไลด์ของงานนำเสนอ PowerPoint: 

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

## **ลบความคิดเห็น**

### **ลบความคิดเห็นและผู้เขียนทั้งหมด**
โค้ด Java นี้แสดงวิธีการลบความคิดเห็นและผู้เขียนทั้งหมดในงานนำเสนอ:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // ลบความคิดเห็นทั้งหมดจากงานนำเสนอ
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

### **ลบความคิดเห็นที่ระบุ**
โค้ด Java นี้แสดงวิธีการลบความคิดเห็นที่ระบุบนสไลด์:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มความคิดเห็น...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // ลบความคิดเห็นทั้งหมดที่มีข้อความ "comment 1"
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

**Aspose.Slides รองรับสถานะเช่น 'resolved' สำหรับความคิดเห็นสมัยใหม่หรือไม่?**

ใช่. [Modern comments](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/moderncomment/) มีเมธอด [setStatus](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-); คุณสามารถกำหนด [สถานะของความคิดเห็น](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/moderncommentstatus/) (เช่น ทำเครื่องหมายว่า resolved) และสถานะนี้จะถูกบันทึกในไฟล์และ PowerPoint จะรับรู้

**รองรับการสนทนาแบบเธรด (ห่วงโซ่การตอบกลับ) หรือไม่, และมีขีดจำกัดการซ้อนกันหรือไม่?**

ใช่. แต่ละความคิดเห็นสามารถอ้างอิงถึง [parent comment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/comment/#getParentComment--) ทำให้สามารถสร้างห่วงโซ่การตอบกลับได้อย่างอิสระ API ไม่ได้ระบุขีดจำกัดความลึกของการซ้อนกัน

**ตำแหน่งของเครื่องหมายความคิดเห็นบนสไลด์กำหนดในระบบพิกัดใด?**

ตำแหน่งจะถูกเก็บเป็นจุดทศนิยมในระบบพิกัดของสไลด์ ซึ่งช่วยให้คุณวางเครื่องหมายความคิดเห็นได้อย่างแม่นยำตามที่ต้องการ