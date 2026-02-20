---
title: コメント
type: docs
weight: 230
url: /ja/php-java/examples/elements/comment/
keywords:
- コメント
- モダン コメント
- コメントを追加
- コメントにアクセス
- コメントを削除
- コメントに返信
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でスライド コメントを管理します：追加、読み取り、返信、編集、削除、および PowerPoint と OpenDocument 用のスレッド化されたコメントを操作します。"
---
**Aspose.Slides for PHP via Java** を使用して、モダン コメントの追加、読み取り、削除、および返信を示します。

## **モダン コメントの追加**

ユーザーが作成したコメントを作成し、プレゼンテーションを保存します。

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // モダン コメントを追加します。
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **モダン コメントへのアクセス**

既存のプレゼンテーションからモダン コメントを読み取ります。

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

## **モダン コメントの削除**

コメントを削除し、更新されたファイルを保存します。

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

## **モダン コメントへの返信**

親のモダン コメントに返信を追加します。

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // コメント作成者を追加します。
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // 親コメントと返信を追加します。
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // 返信の親コメントを設定します。
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // 返信付きでプレゼンテーションを保存します。
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```