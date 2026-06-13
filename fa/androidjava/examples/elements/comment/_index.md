---
title: نظر
type: docs
weight: 230
url: /fa/androidjava/examples/elements/comment/
keywords:
- مثال کد
- نظر
- پاورپوینت
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "کار با نظرات اسلاید در Aspose.Slides برای Android: افزودن، پاسخ، ویرایش، حل و استخراج نظرات در ارائه‌های PPT، PPTX و ODP با مثال‌های کد Java."
---
این مقاله افزودن، خواندن، حذف و پاسخ‌دادن به نظرات مدرن را با استفاده از **Aspose.Slides for Android via Java** نشان می‌دهد.

## **افزودن یک نظر مدرن**
یک نظر ایجاد کنید که توسط کاربری نوشته شده است و ارائه را ذخیره کنید.

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

## **دسترسی به یک نظر مدرن**
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

## **حذف یک نظر مدرن**
یک نظر را حذف کنید و فایل بروز شده را ذخیره کنید.

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

## **پاسخ به یک نظر مدرن**
پاسخ‌ها را به یک نظر مدرن والد اضافه کنید.

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