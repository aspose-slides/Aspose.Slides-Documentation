---
title: 在 PHP 中管理簡報評論
linktitle: 簡報評論
type: docs
weight: 100
url: /zh-hant/php-java/presentation-comments/
keywords:
- 評論
- 現代評論
- PowerPoint 評論
- 簡報評論
- 投影片評論
- 新增評論
- 存取評論
- 編輯評論
- 回覆評論
- 移除評論
- 刪除評論
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 徹底掌握簡報評論：快速輕鬆地在 PowerPoint 檔案中新增、讀取、編輯與刪除評論。"
---
## **概述**

本文說明如何在 Aspose.Slides 中管理簡報評論。它展示了主要的與評論相關的類型，並示範如何向投影片新增評論、存取現有評論、處理回覆、使用現代評論，以及從簡報中移除評論。

範例聚焦於 PowerPoint 中常見的審閱與協作情境，例如將評論指派給作者、讀取評論內容與中繼資料、建立回覆鏈，以及清除所有評論或刪除選取的評論。

在 PowerPoint 中，評論會顯示為投影片上的備註或註解。點擊評論時，會展開其內容或訊息。

## **為何在簡報中加入評論？**

在審閱簡報時，您可能希望使用評論提供回饋或與同事溝通。

為了讓您在 PowerPoint 簡報中使用評論，Aspose.Slides for PHP via Java 提供

* [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別，包含作者集合（來自 [CommentAuthorCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commentauthorcollection/) 類別）。作者會在投影片上加入評論。
* [CommentCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commentcollection/) 類別，包含各作者的評論集合。
* [Comment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/) 類別，提供作者與其評論的資訊：誰加入了評論、加入時間、評論位置等。
* [CommentAuthor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commentauthor/) 類別，提供單一作者的資訊：作者名稱、縮寫、與該作者相關的評論等。

## **新增投影片評論**
此 PHP 程式碼示範如何在 PowerPoint 簡報的投影片上新增評論：

```php
  # 實例化 Presentation 類別
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 新增空白投影片
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # 新增作者
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # 設定評論的位置
    $point = new Point2DFloat(0.2, 0.2);
    # 為作者在投影片 1 新增投影片評論
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # 為作者在投影片 2 新增投影片評論
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # 存取 ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # 當參數為 null 時，會將所有作者的評論帶入選取的投影片
    $Comments = $slide->getSlideComments($author);
    # 存取投影片 1 中索引 0 的評論
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # 選取索引 0 的作者評論集合
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **存取投影片評論**
此 PHP 程式碼示範如何存取 PowerPoint 簡報投影片上既有的評論：

```php
  # 實例化 Presentation 類別
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

## **回覆評論**
父評論是層次結構中最上層或原始的評論。使用 [Comment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/) 類別的 [getParentComment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/getparentcomment/) 或 [setParentComment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/setparentcomment/) 方法，即可取得或設定父評論。

此 PHP 程式碼示範如何新增評論以及取得其回覆：

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 新增評論
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # 為 comment1 新增回覆
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # 為 comment1 再新增另一則回覆
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # 為已存在的回覆新增回覆
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # 在主控台顯示評論層級結構
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
    # 移除 comment1 以及其所有回覆
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Attention" %}} 
* 當使用 [Comment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/) 類別的 [remove](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/remove/) 方法刪除評論時，該評論的回覆也會一併被刪除。
* 若 [setParentComment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/setparentcomment/) 設定導致循環參照，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **新增現代評論**

2021 年，Microsoft 在 PowerPoint 中引入了 *現代評論*。現代評論功能顯著提升了 PowerPoint 的協作體驗。透過現代評論，使用者可以解決評論、將評論錨定至物件與文字，且互動方式比以往更加便捷。

Aspose Slides 透過 [ModernComment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/) 類別支援現代評論。[CommentCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commentcollection/) 類別新增了 [addModernComment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commentcollection/addmoderncomment/) 與 [insertModernComment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commentcollection/insertmoderncomment/) 方法。

此 PHP 程式碼示範如何在 PowerPoint 簡報的投影片上新增現代評論：

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

## **移除評論**

### **刪除所有評論與作者**

此 PHP 程式碼示範如何在簡報中移除所有評論與作者：

```php
  $presentation = new Presentation("example.pptx");
  try {
    # 刪除簡報中的所有評論
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # 刪除所有作者
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **刪除特定評論**

此 PHP 程式碼示範如何刪除投影片上的特定評論：

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 新增評論...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # 移除所有包含「comment 1」文字的評論
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

## **常見問題**

**Aspose.Slides 是否支援現代評論的「已解決」狀態？**

是的。[Modern comments](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/) 提供 [setStatus](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/setstatus/) 方法；您可以設定評論的狀態（例如標記為已解決），此狀態會儲存在檔案中，且 PowerPoint 能辨識。

**是否支援串列討論（回覆鏈），且有巢狀深度限制嗎？**

支援。每個評論皆可參照其 [parent comment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/getparentcomment/)，因此可以形成任意深度的回覆鏈。API 並未宣告特定的巢狀深度上限。

**評論標記在投影片上的位置是以哪種座標系統定義的？**

位置以浮點座標點儲存在投影片的座標系統中，讓您能精確地將評論標記放置於所需的位置。