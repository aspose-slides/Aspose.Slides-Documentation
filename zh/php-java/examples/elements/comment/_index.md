---
title: 评论
type: docs
weight: 230
url: /zh/php-java/examples/elements/comment/
keywords:
- 评论
- 现代评论
- 添加评论
- 访问评论
- 删除评论
- 回复评论
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中管理幻灯片评论：添加、读取、回复、编辑、删除，并处理 PowerPoint 和 OpenDocument 的线程评论。"
---
演示如何使用 **Aspose.Slides for PHP via Java** 添加、读取、删除以及回复现代评论。

## **添加现代评论**

创建由用户撰写的评论并保存演示文稿。

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 添加现代评论。
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **访问现代评论**

从现有演示文稿中读取现代评论。

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

## **删除现代评论**

删除评论并保存更新后的文件。

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

## **回复现代评论**

为父级现代评论添加回复。

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 添加评论作者。
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // 添加父级评论及回复。
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // 为回复设置父级评论。
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // 保存包含回复的演示文稿。
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```