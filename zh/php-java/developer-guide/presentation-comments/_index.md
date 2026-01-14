---
title: 在 PHP 中管理演示文稿评论
linktitle: 演示文稿评论
type: docs
weight: 100
url: /zh/php-java/presentation-comments/
keywords:
- 评论
- 现代评论
- PowerPoint 评论
- 演示文稿评论
- 幻灯片评论
- 添加评论
- 访问评论
- 编辑评论
- 回复评论
- 删除评论
- 移除评论
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 轻松快速地在 PowerPoint 文件中添加、读取、编辑和删除演示文稿评论。"
---

在 PowerPoint 中，评论显示为幻灯片上的注释或标注。点击评论后，会显示其内容或信息。

## **为什么在演示文稿中添加评论？**

在审阅演示文稿时，您可能希望使用评论来提供反馈或与同事沟通。

为了让您在 PowerPoint 演示文稿中使用评论，Aspose.Slides for PHP via Java 提供了

* 包含作者集合的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类（来自 [CommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/) 类）。作者向幻灯片添加评论。
* 包含各个作者评论集合的 [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) 类。
* 包含作者及其评论信息的 [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) 类：谁添加了评论、添加评论的时间、评论的位置等。
* 包含单个作者信息的 [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) 类：作者姓名、缩写、与该作者姓名关联的评论等。

## **添加幻灯片评论**
以下 PHP 代码演示如何在 PowerPoint 演示文稿的幻灯片中添加评论：
```php
  # 实例化 Presentation 类
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 添加一个空幻灯片
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # 添加作者
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # 设置评论的位置
    $point = new Point2DFloat(0.2, 0.2);
    # 为作者在幻灯片 1 上添加幻灯片评论
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # 为作者在幻灯片 2 上添加幻灯片评论
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # 访问 ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # 当参数为 null 时，将所有作者的评论带到选定的幻灯片
    $Comments = $slide->getSlideComments($author);
    # 访问幻灯片 1 上索引为 0 的评论
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # 在索引 0 处选择作者的评论集合
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **访问幻灯片评论**
以下 PHP 代码演示如何访问 PowerPoint 演示文稿中幻灯片的现有评论：
```php
  # 实例化 Presentation 类
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


## **回复评论**
父评论是评论或回复层级中的顶部或原始评论。使用来自 [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) 类的 [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) 或 [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) 方法，您可以设置或获取父评论。

以下 PHP 代码演示如何添加评论并获取对其的回复：
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 添加评论
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # 为 comment1 添加回复
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # 为 comment1 添加另一条回复
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # 为已有回复添加回复
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # 在控制台显示评论层级结构
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
    # 删除 comment1 及其所有回复
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" title="Attention" %}} 
* 当使用来自 [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) 类的 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) 方法删除评论时，评论的回复也会被删除。
* 如果 [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) 设置导致循环引用，将抛出 [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **添加现代评论**

2021 年，Microsoft 在 PowerPoint 中引入了*现代评论*。现代评论功能显著提升了 PowerPoint 的协作能力。通过现代评论，PowerPoint 用户可以解决评论、将评论锚定到对象和文本，并且能够更轻松地进行交互。

在 [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/) 中，我们通过添加 [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) 类实现了对现代评论的支持。向 [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) 类中添加了 [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) 和 [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/insertmoderncomment/) 方法。

以下 PHP 代码演示如何在 PowerPoint 演示文稿的幻灯片中添加现代评论：
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


## **删除评论**

### **删除所有评论和作者**
以下 PHP 代码演示如何在演示文稿中删除所有评论和作者：
```php
  $presentation = new Presentation("example.pptx");
  try {
    # 删除演示文稿中的所有评论
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # 删除所有作者
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


### **删除特定评论**
以下 PHP 代码演示如何删除幻灯片上的特定评论：
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 添加评论...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # 删除所有包含 "comment 1" 文本的评论
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


## **常见问题**

**Aspose.Slides 是否支持现代评论的‘已解决’状态？**  
是的。[Modern comments](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) 提供了 [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) 方法；您可以写入 [comment’s state](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/)（例如，将其标记为已解决），该状态会保存在文件中并被 PowerPoint 识别。

**是否支持线程式讨论（回复链），以及是否有限制嵌套深度？**  
是的。每条评论都可以引用其 [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/)，从而实现任意的回复链。API 并未声明具体的嵌套深度限制。

**评论标记在幻灯片上的位置是基于哪种坐标系定义的？**  
位置以浮点坐标存储在幻灯片的坐标系中。这使您可以精确地将评论标记放置在所需位置。