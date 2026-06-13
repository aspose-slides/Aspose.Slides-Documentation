---
title: نظر
type: docs
weight: 230
url: /fa/java/examples/elements/comment/
keywords:
- مثال کد
- نظر
- پاورپوینت
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "کار با نظرات اسلاید در Aspose.Slides for Java: افزودن، پاسخ، ویرایش، حل و استخراج نظرات در ارائه‌های PPT، PPTX و ODP با مثال‌های کد Java."
---
این مقاله نشان می‌دهد چگونه نظرات مدرن را اضافه، خوانده، حذف و پاسخ‌داده شوند با استفاده از **Aspose.Slides for Java**.

## **افزودن نظر مدرن**

یک نظر توسط کاربر ایجاد کنید و ارائه را ذخیره کنید.

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

## **دسترسی به نظر مدرن**

یک نظر مدرن را از یک ارائه موجود بخوانید.

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

## **حذف نظر مدرن**

یک نظر را حذف کنید و فایل به‌روزرسانی‌شده را ذخیره کنید.

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

## **پاسخ به نظر مدرن**

پاسخ‌ها را به یک نظر مدرن اصلی اضافه کنید.

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