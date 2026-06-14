---
title: Bình luận
type: docs
weight: 230
url: /vi/php-java/examples/elements/comment/
keywords:
- bình luận
- bình luận hiện đại
- thêm bình luận
- truy cập bình luận
- xóa bình luận
- trả lời bình luận
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý bình luận trên slide trong PHP với Aspose.Slides: thêm, đọc, trả lời, chỉnh sửa, xóa và làm việc với các bình luận dạng chuỗi cho PowerPoint và OpenDocument."
---
Minh họa cách thêm, đọc, xóa và trả lời các bình luận hiện đại bằng **Aspose.Slides for PHP via Java**.

## **Thêm bình luận hiện đại**

Tạo một bình luận do người dùng viết và lưu bản trình chiếu.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Thêm một bình luận hiện đại.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập bình luận hiện đại**

Đọc một bình luận hiện đại từ bản trình chiếu hiện có.

```php
function accessModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);
        echo "Author: " . $author->getName() . ", Comment: " . $comment->getText() . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa bình luận hiện đại**

Xóa bình luận và lưu tệp đã cập nhật.

```php
function removeModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);

        $comment->remove();

        $presentation->save("modern_comment_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Trả lời bình luận hiện đại**

Thêm phản hồi cho bình luận hiện đại cha.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Thêm một tác giả bình luận.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Thêm một bình luận cha và các phản hồi.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Đặt bình luận cha cho các phản hồi.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Lưu bản trình chiếu kèm các phản hồi.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```