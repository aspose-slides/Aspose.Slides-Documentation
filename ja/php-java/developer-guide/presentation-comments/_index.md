---
title: プレゼンテーションのコメント
type: docs
weight: 100
url: /ja/php-java/presentation-comments/
keywords: "コメント, PowerPointのコメント, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションにコメントと返信を追加する"
---

PowerPointでは、コメントはスライド上のノートや注釈として表示されます。コメントがクリックされると、その内容やメッセージが表示されます。

### **プレゼンテーションにコメントを追加する理由**

プレゼンテーションをレビューする際に、フィードバックを提供したり同僚とコミュニケーションを取るためにコメントを使用したい場合があります。

PowerPointプレゼンテーションでコメントを使用できるようにするために、Aspose.Slides for PHP via Javaは次のものを提供します。

* [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスで、[ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection)インターフェイスからの著者のコレクションが含まれています。著者はスライドにコメントを追加します。
* [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection)インターフェイスで、個々の著者のコメントのコレクションが含まれています。
* [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)クラスで、著者とそのコメントに関する情報が含まれています：誰がコメントを追加したか、コメントが追加された時間、コメントの位置など。
* [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor)クラスで、各著者に関する情報が含まれています：著者の名前、イニシャル、著者の名前に関連付けられたコメントなど。

## **スライドコメントの追加**
このPHPコードは、PowerPointプレゼンテーションのスライドにコメントを追加する方法を示しています：

```php
  # Presentationクラスのインスタンスを生成
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 空のスライドを追加
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # 著者を追加
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # コメントの位置を設定
    $point = new Point2DFloat(0.2, 0.2);
    # スライド1の著者のスライドコメントを追加
    $author->getComments()->addComment("こんにちはJawad、これはスライドコメントです", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # スライド2の著者のスライドコメントを追加
    $author->getComments()->addComment("こんにちはJawad、これは2つ目のスライドコメントです", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # スライド1のISlideにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # nullが引数として渡されると、すべての著者から選択されたスライドにコメントが取得される
    $Comments = $slide->getSlideComments($author);
    # スライド1のインデックス0のコメントにアクセス
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # インデックス0で著者のコメントコレクションを選択
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
このPHPコードは、PowerPointプレゼンテーションのスライドにある既存のコメントにアクセスする方法を示しています：

```php
  # Presentationクラスのインスタンスを生成
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " にはコメントがあります: " . $comment->getText() . " 著者: " . $comment->getAuthor()->getName() . " 投稿時間 :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **返信コメント**
親コメントは、コメントや返信の階層のトップまたは元のコメントです。[getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--)または[setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-)メソッド（[IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)インターフェイスから）を使用すると、親コメントを設定または取得できます。

このPHPコードは、コメントを追加し、それに対する返信を取得する方法を示しています：

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # コメントを追加
    $author1 = $pres->getCommentAuthors()->addAuthor("著者_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("コメント1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # コメント1への返信を追加
    $author2 = $pres->getCommentAuthors()->addAuthor("著者_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("コメント1への返信1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # コメント1への別の返信を追加
    $reply2 = $author2->getComments()->addComment("コメント1への返信2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # 既存の返信への返信を追加
    $subReply = $author1->getComments()->addComment("返信2へのサブ返信3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("コメント2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("コメント3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("コメント3への返信4", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # コンソールにコメント階層を表示
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
    # コメント1とそのすべての返信を削除
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="注意" %}} 

* [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--)メソッド（[IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)インターフェイスから）を使用してコメントを削除すると、コメントへの返信も削除されます。
* [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-)の設定が循環参照をもたらす場合、[PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException)がスローされます。

{{% /alert %}}

## **モダンコメントの追加**

2021年、MicrosoftはPowerPointに*モダンコメント*を導入しました。モダンコメント機能は、PowerPointでのコラボレーションを大幅に改善します。モダンコメントを通じて、PowerPointユーザーはコメントを解決し、コメントをオブジェクトやテキストにアンカーを付け、以前よりも容易にやり取りを行うことができます。

[Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/)では、[ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment)クラスを追加することでモダンコメントのサポートを実装しました。 [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-)および[insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-)メソッドが[CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection)クラスに追加されました。

このPHPコードは、PowerPointプレゼンテーションのスライドにモダンコメントを追加する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("著者名", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("これはモダンコメントです", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **コメントの削除**

### **すべてのコメントと著者を削除**

このPHPコードは、プレゼンテーション内のすべてのコメントと著者を削除する方法を示しています：

```php
  $presentation = new Presentation("example.pptx");
  try {
    # プレゼンテーションからすべてのコメントを削除
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # すべての著者を削除
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **特定のコメントを削除**

このPHPコードは、スライド上の特定のコメントを削除する方法を示しています：

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # コメントを追加...
    $author = $presentation->getCommentAuthors()->addAuthor("著者", "A");
    $author->getComments()->addComment("コメント1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("コメント2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # "コメント1"というテキストを含むすべてのコメントを削除
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("コメント1")) {
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