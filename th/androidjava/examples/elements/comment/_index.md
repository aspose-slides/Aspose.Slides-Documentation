---
title: ความคิดเห็น
type: docs
weight: 230
url: /th/androidjava/examples/elements/comment/
keywords:
- ตัวอย่างโค้ด
- ความคิดเห็น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำงานกับความคิดเห็นสไลด์ใน Aspose.Slides for Android: เพิ่ม, ตอบกลับ, แก้ไข, แก้ปัญหา, และส่งออกความคิดเห็นในงานนำเสนอ PPT, PPTX และ ODP ด้วยตัวอย่างโค้ด Java."
---
บทความนี้สาธิตการเพิ่ม, การอ่าน, การลบและการตอบกลับความคิดเห็นสมัยใหม่โดยใช้ **Aspose.Slides for Android via Java**.

## **เพิ่มความคิดเห็นสมัยใหม่**

สร้างความคิดเห็นที่เขียนโดยผู้ใช้และบันทึกงานนำเสนอ.

```java
static void addModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");
        author.getComments().addModernComment(
                "This is a modern comment", slide, null, new android.graphics.PointF(100, 100), new java.util.Date());

        presentation.save("modern_comment.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงความคิดเห็นสมัยใหม่**

อ่านความคิดเห็นสมัยใหม่จากงานนำเสนอที่มีอยู่.

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

## **ลบความคิดเห็นสมัยใหม่**

ลบความคิดเห็นและบันทึกไฟล์ที่อัปเดต.

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

## **ตอบกลับความคิดเห็นสมัยใหม่**

เพิ่มการตอบกลับให้กับความคิดเห็นสมัยใหม่หลัก.

```java
static void replyToModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");

        IModernComment parentComment = author.getComments().addModernComment(
                "Parent comment", slide, null, new android.graphics.PointF(100, 100), new java.util.Date());
        
        IModernComment reply1 = author.getComments().addModernComment(
                "Reply 1", slide, null, new android.graphics.PointF(110, 100), new java.util.Date());
        
        IModernComment reply2 = author.getComments().addModernComment(
                "Reply 2", slide, null, new android.graphics.PointF(120, 100), new java.util.Date());

        reply1.setParentComment(parentComment);
        reply2.setParentComment(parentComment);

        presentation.save("modern_comment_replies.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```