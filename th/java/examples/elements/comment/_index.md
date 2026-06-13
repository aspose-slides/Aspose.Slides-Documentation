---
title: ความคิดเห็น
type: docs
weight: 230
url: /th/java/examples/elements/comment/
keywords:
- ตัวอย่างโค้ด
- ความคิดเห็น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ทำงานกับความคิดเห็นบนสไลด์ใน Aspose.Slides for Java: เพิ่ม, ตอบกลับ, แก้ไข, แก้ปัญหา, และส่งออกความคิดเห็นในงานนำเสนอ PPT, PPTX, และ ODP ด้วยตัวอย่างโค้ด Java."
---
บทความนี้สาธิตการเพิ่ม, อ่าน, ลบ, และตอบกลับคอมเมนต์สมัยใหม่โดยใช้ **Aspose.Slides for Java**.

## **เพิ่มคอมเมนต์สมัยใหม่**

สร้างคอมเมนต์ที่เขียนโดยผู้ใช้และบันทึกงานนำเสนอ

```java
static void addModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");
        author.getComments().addModernComment(
                "This is a modern comment", slide, null, new Point2D.Float(100, 100), new java.util.Date());

        presentation.save("modern_comment.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงคอมเมนต์สมัยใหม่**

อ่านคอมเมนต์สมัยใหม่จากงานนำเสนอที่มีอยู่

```java
static void accessModernComment() {
    Presentation presentation = new Presentation("modern_comment.pptx");
    try {
        ICommentAuthor author = presentation.getCommentAuthors().get_Item(0);
        IModernComment comment = (IModernComment) author.getComments().get_Item(0);
        System.out.println("Author: " + author.getName() + ", Comment: " + comment.getText() + ", Position: " + comment.getPosition());
    } finally {
        presentation.dispose();
    }
}
```

## **ลบคอมเมนต์สมัยใหม่**

ลบคอมเมนต์และบันทึกไฟล์ที่อัปเดต

```java
static void removeModernComment() {
    Presentation presentation = new Presentation("modern_comment.pptx");
    try {
        ICommentAuthor author = presentation.getCommentAuthors().get_Item(0);

        IComment comment = author.getComments().get_Item(0);
        comment.remove();

        presentation.save("modern_comment_removed.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ตอบกลับคอมเมนต์สมัยใหม่**

เพิ่มการตอบกลับให้กับคอมเมนต์หลักสมัยใหม่

```java
static void replyToModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");

        IModernComment parentComment = author.getComments().addModernComment(
                "Parent comment", slide, null, new Point2D.Float(100, 100), new java.util.Date());
        
        IModernComment reply1 = author.getComments().addModernComment(
                "Reply 1", slide, null, new Point2D.Float(110, 100), new java.util.Date());
        
        IModernComment reply2 = author.getComments().addModernComment(
                "Reply 2", slide, null, new Point2D.Float(120, 100), new java.util.Date());

        reply1.setParentComment(parentComment);
        reply2.setParentComment(parentComment);

        presentation.save("modern_comment_replies.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```