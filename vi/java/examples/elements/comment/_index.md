---
title: "Bình luận"
type: docs
weight: 230
url: /vi/java/examples/elements/comment/
keywords:
- "ví dụ mã"
- "bình luận"
- PowerPoint
- OpenDocument
- "bài thuyết trình"
- Java
- Aspose.Slides
description: "Làm việc với nhận xét trên slide trong Aspose.Slides for Java: thêm, trả lời, chỉnh sửa, giải quyết và xuất nhận xét trong các bản thuyết trình PPT, PPTX và ODP bằng các ví dụ mã Java."
---
Bài viết này trình bày cách thêm, đọc, xóa và trả lời các nhận xét hiện đại bằng **Aspose.Slides for Java**.

## **Thêm nhận xét hiện đại**

Tạo một nhận xét do người dùng viết và lưu bản trình chiếu.

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

## **Truy cập nhận xét hiện đại**

Đọc một nhận xét hiện đại từ bản trình chiếu hiện có.

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

## **Xóa nhận xét hiện đại**

Xóa một nhận xét và lưu file đã cập nhật.

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

## **Trả lời nhận xét hiện đại**

Thêm các phản hồi cho một nhận xét hiện đại cha.

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