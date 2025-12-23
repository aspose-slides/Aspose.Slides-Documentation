---
title: PHPでプレゼンテーションコメントを管理
linktitle: プレゼンテーションコメント
type: docs
weight: 100
url: /ja/php-java/presentation-comments/
keywords:
- コメント
- モダンコメント
- PowerPoint コメント
- プレゼンテーションコメント
- スライドコメント
- コメント追加
- コメント取得
- コメント編集
- コメント返信
- コメント削除
- コメント削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Javaを使用してプレゼンテーションコメントをマスター: PowerPointファイルでコメントの追加、読み取り、編集、削除を迅速かつ簡単に行う。"
---

PowerPointでは、コメントはスライド上のメモや注釈として表示されます。コメントをクリックすると、内容やメッセージが表示されます。

## **プレゼンテーションにコメントを追加する理由は？**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とコミュニケーションを取るためにコメントを使用したい場合があります。

PowerPointプレゼンテーションでコメントを使用できるように、Aspose.Slides for PHP via Java は以下を提供します

* [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスは、著者のコレクション（[ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection) インターフェイス）を含みます。著者はスライドにコメントを追加します。
* [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection) インターフェイスは、個々の著者のコメントコレクションを含みます。
* [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) クラスは、著者とコメントに関する情報（コメントを追加したユーザー、追加日時、コメントの位置など）を含みます。
* [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor) クラスは、個々の著者に関する情報（著者名、イニシャル、著者名に関連付けられたコメントなど）を含みます。

## **スライドコメントの追加**
このPHPコードは、PowerPointプレゼンテーションのスライドにコメントを追加する方法を示します。
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 空のスライドを追加します
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # 著者を追加します
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # コメントの位置を設定します
    $point = new Point2DFloat(0.2, 0.2);
    # スライド 1 に著者のスライドコメントを追加します
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # スライド 2 に著者のスライドコメントを追加します
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # ISlide 1 にアクセスします
    $slide = $pres->getSlides()->get_Item(0);
    # 引数に null を渡すと、すべての著者のコメントが選択したスライドに取得されます
    $Comments = $slide->getSlideComments($author);
    # スライド 1 のインデックス 0 のコメントにアクセスします
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # インデックス 0 の著者のコメントコレクションを選択します
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **スライドコメントへのアクセス**
このPHPコードは、PowerPointプレゼンテーションのスライド上にある既存のコメントにアクセスする方法を示します。
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


## **コメントへの返信**
親コメントは、コメントや返信の階層における最上位または元のコメントです。[getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) または [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) メソッド（[IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) インターフェイス）を使用して、親コメントを取得または設定できます。

このPHPコードは、コメントを追加し、それらへの返信を取得する方法を示します。
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # コメントを追加します
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # comment1 に対する返信を追加します
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # comment1 に別の返信を追加します
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # 既存の返信に対する返信を追加します
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
    # comment1 とそれに対するすべての返信を削除します
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" title="Attention" %}} 
* [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) メソッド（[IComment]インターフェイス）を使用してコメントを削除すると、そのコメントへの返信も同時に削除されます。
* [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) の設定により循環参照が発生した場合、[PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) がスローされます。
{{% /alert %}}

## **モダンコメントの追加**

2021、Microsoft は PowerPoint に *モダンコメント* を導入しました。モダンコメント機能は、PowerPoint におけるコラボレーションを大幅に向上させます。モダンコメントにより、PowerPoint ユーザーはコメントの解決、オブジェクトやテキストへのコメントの固定、やり取りを以前より容易に行えるようになりました。

[Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/) では、[ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment) クラスを追加することでモダンコメントのサポートを実装しました。[CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection) クラスに [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) および [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) メソッドが追加されました。

このPHPコードは、PowerPointプレゼンテーションのスライドにモダンコメントを追加する方法を示します。
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


## **コメントの削除**

### **すべてのコメントと著者の削除**
このPHPコードは、プレゼンテーション内のすべてのコメントと著者を削除する方法を示します。
```php
  $presentation = new Presentation("example.pptx");
  try {
    # プレゼンテーションからすべてのコメントを削除します
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # すべての著者を削除します
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


### **特定のコメントの削除**
このPHPコードは、スライド上の特定のコメントを削除する方法を示します。
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # コメントを追加...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # 「comment 1」テキストを含むすべてのコメントを削除
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

はい。[Modern comments](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) は [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) メソッドを提供しています。コメントの状態（例: 解決済みとしてマーク）を書き込むことができ、この状態はファイルに保存され、PowerPoint に認識されます。

**スレッド化されたディスカッション（返信チェーン）はサポートされていますか？また、ネストの深さに制限はありますか？**

はい。各コメントは [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) を参照できるため、任意の深さの返信チェーンを実現できます。API では特定のネスト深度の制限は明示されていません。

**スライド上のコメントマーカーの位置は、どの座標系で定義されていますか？**

位置はスライドの座標系で浮動小数点のポイントとして保存されます。これにより、必要な場所にコメントマーカーを正確に配置できます。