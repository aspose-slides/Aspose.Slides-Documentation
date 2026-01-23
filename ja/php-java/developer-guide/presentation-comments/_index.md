---
title: PHPでプレゼンテーションコメントを管理する
linktitle: プレゼンテーションコメント
type: docs
weight: 100
url: /ja/php-java/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPointコメント
- プレゼンテーションコメント
- スライドコメント
- コメントの追加
- コメントへのアクセス
- コメントの編集
- コメントへの返信
- コメントの削除
- コメントの削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してプレゼンテーションコメントをマスターし、PowerPoint ファイルのコメントを迅速かつ簡単に追加、読み取り、編集、削除できます。"
---

PowerPoint では、コメントはスライド上のメモや注釈として表示されます。コメントをクリックすると、内容やメッセージが表示されます。

## **プレゼンテーションにコメントを追加する理由は？**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とやり取りしたりするためにコメントを使用したくなることがあります。

PowerPoint プレゼンテーションでコメントを使用できるように、Aspose.Slides for PHP via Java は以下を提供します。

* [Presentation] クラスは、[CommentAuthorCollection] クラスから取得できる作成者コレクションを含みます。作成者はスライドにコメントを追加します。
* [CommentCollection] クラスは、個々の作成者に対するコメントコレクションを含みます。
* [Comment] クラスは、作成者とそのコメントに関する情報（コメントを追加した人物、追加日時、コメントの位置など）を含みます。
* [CommentAuthor] クラスは、個々の作成者に関する情報（作成者名、イニシャル、作成者名に関連付けられたコメントなど）を含みます。

## **スライドにコメントを追加する**
この PHP コードは、PowerPoint プレゼンテーションのスライドにコメントを追加する方法を示します:
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 空のスライドを追加します
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # 作成者を追加します
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # コメントの位置を設定します
    $point = new Point2DFloat(0.2, 0.2);
    # スライド 1 の作成者にスライドコメントを追加します
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # スライド 2 の作成者にスライドコメントを追加します
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # ISlide 1 にアクセスします
    $slide = $pres->getSlides()->get_Item(0);
    # 引数に null を渡すと、すべての作成者のコメントが選択したスライドに取得されます
    $Comments = $slide->getSlideComments($author);
    # スライド 1 のインデックス 0 のコメントにアクセスします
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # インデックス 0 の作成者のコメントコレクションを選択します
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **スライドのコメントにアクセスする**
この PHP コードは、PowerPoint プレゼンテーションのスライドに既存のコメントにアクセスする方法を示します:
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **コメントに返信する**
親コメントは、コメントや返信の階層における最上位（元）のコメントです。[Comment] クラスの [getParentComment] または [setParentComment] メソッドを使用して、親コメントを取得または設定できます。

この PHP コードは、コメントを追加し、それへの返信を取得する方法を示します:
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # コメントを追加します
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # comment1 に返信を追加します
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # comment1 に別の返信を追加します
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # 既存の返信に返信を追加します
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # コンソールにコメント階層を表示します
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # comment1 とそれへのすべての返信を削除します
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" title="Attention" %}} 
* [Comment] クラスの [remove] メソッドでコメントを削除すると、コメントへの返信もすべて削除されます。
* [setParentComment] 設定が循環参照になると、[PptxEditException] がスローされます。
{{% /alert %}}

## **モダンコメントを追加する**

2021 年に Microsoft は PowerPoint に *モダンコメント* を導入しました。モダンコメント機能は、PowerPoint におけるコラボレーションを大幅に向上させます。モダンコメントにより、コメントの解決、オブジェクトやテキストへのコメントの固定、そして従来よりもはるかに簡単にやり取りできるようになりました。

Aspose Slides は [ModernComment] クラスでモダンコメントをサポートします。[CommentCollection] クラスに [addModernComment] と [insertModernComment] メソッドが追加されました。

この PHP コードは、PowerPoint プレゼンテーションのスライドにモダンコメントを追加する方法を示します:
```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **コメントを削除する**

### **すべてのコメントと作成者を削除する**

この PHP コードは、プレゼンテーション内のすべてのコメントと作成者を削除する方法を示します:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # プレゼンテーションからすべてのコメントを削除します
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # すべての作成者を削除します
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


### **特定のコメントを削除する**

この PHP コードは、スライド上の特定のコメントを削除する方法を示します:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # コメントを追加...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # "comment 1" を含むすべてのコメントを削除します
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **FAQ**

**Aspose.Slides はモダンコメントに「解決済み」などのステータスをサポートしていますか？**

はい。[Modern comments] は [setStatus] メソッドを公開しており、コメントの状態（例: 解決済みとしてマーク）を書き込むことができ、この状態はファイルに保存され PowerPoint で認識されます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？ また、入れ子の上限はありますか？**

はい。各コメントは [parent comment] を参照できるため、任意の深さの返信チェーンを構成できます。API では具体的な入れ子深さの上限は定義されていません。

**スライド上でコメントマーカーの位置はどの座標系で定義されていますか？**

位置はスライドの座標系での浮動小数点のポイントとして保存されます。これにより、必要な正確な場所にコメントマーカーを配置できます。