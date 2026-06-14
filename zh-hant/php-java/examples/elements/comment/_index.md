---
title: 註解
type: docs
weight: 230
url: /zh-hant/php-java/examples/elements/comment/
keywords:
- 註解
- 現代註解
- 新增註解
- 存取註解
- 移除註解
- 回覆註解
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中管理投影片註解：新增、讀取、回覆、編輯、刪除，並處理 PowerPoint 與 OpenDocument 的串列註解。"
---
示範使用 **Aspose.Slides for PHP via Java** 新增、讀取、移除與回覆現代註解。

## **新增現代註解**

建立由使用者撰寫的註解並儲存簡報。

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 新增現代註解。
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **存取現代註解**

從現有簡報中讀取現代註解。

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

## **移除現代註解**

移除註解並儲存更新後的檔案。

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

## **回覆現代註解**

為父層現代註解新增回覆。

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 新增註解作者。
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // 新增父層註解與回覆。
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // 為回覆設定父層註解。
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // 儲存包含回覆的簡報。
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```