---
title: Bình luận
type: docs
weight: 230
url: /vi/androidjava/examples/elements/comment/
keywords:
- ví dụ mã
- bình luận
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Làm việc với bình luận trên slide trong Aspose.Slides cho Android: thêm, trả lời, chỉnh sửa, giải quyết và xuất bình luận trong các bản trình bày PPT, PPTX và ODP bằng các ví dụ mã Java."
---
Bài viết này trình bày cách thêm, đọc, xóa và trả lời các bình luận hiện đại bằng cách sử dụng **Aspose.Slides for Android via Java**.

## **Thêm một bình luận hiện đại**

Tạo một bình luận do người dùng viết và lưu bản trình bày.

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

## **Truy cập một bình luận hiện đại**

Đọc một bình luận hiện đại từ bản trình bày hiện có.

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

## **Xóa một bình luận hiện đại**

Xóa một bình luận và lưu tệp đã cập nhật.

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

## **Trả lời một bình luận hiện đại**

Thêm các phản hồi vào bình luận hiện đại cha.

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