---
title: 演示文稿注释
type: docs
weight: 100
url: /php-java/presentation-comments/
keywords: "注释, PowerPoint 注释, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "在 PowerPoint 演示文稿中添加注释和回复"
---

在 PowerPoint 中，注释作为幻灯片上的备注或注解出现。当单击注释时，其内容或信息会被显示。

### **为什么要在演示文稿中添加注释？**

当您审查演示文稿时，您可能希望使用注释来提供反馈或与同事沟通。

为了让您在 PowerPoint 演示文稿中使用注释，Aspose.Slides for PHP via Java 提供了

* [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类，其中包含作者的集合（来自 [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection) 接口）。作者将注释添加到幻灯片上。
* [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection) 接口，它包含每个作者的注释集合。
* [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) 类，它包含有关作者及其评论的信息：谁添加了评论、评论添加的时间、评论的位置等。
* [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor) 类，它包含有关个别作者的信息：作者的名字、他的首字母、与作者名字相关的评论等。

## **添加幻灯片注释**
以下 PHP 代码向您展示如何在 PowerPoint 演示文稿中向幻灯片添加注释：

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
    # 在幻灯片 1 上为作者添加幻灯片注释
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # 在幻灯片 2 上为作者添加幻灯片注释
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # 访问幻灯片 1
    $slide = $pres->getSlides()->get_Item(0);
    # 当 null 被传递作为参数时，所有作者的评论会被带到所选幻灯片
    $Comments = $slide->getSlideComments($author);
    # 访问幻灯片 1 上索引为 0 的评论
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # 选择索引为 0 的作者评论集合
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
以下 PHP 代码向您展示如何访问 PowerPoint 演示文稿中幻灯片上的现有评论：

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
父评论是在评论或回复的层次结构中的顶级或原始评论。使用 [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) 或 [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 方法（来自 [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) 接口），您可以设置或获取父评论。

以下 PHP 代码向您展示如何添加评论并获取对其的回复：

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 添加一个评论
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # 添加对 comment1 的回复
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # 添加对 comment1 的另一个回复
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # 对现有回复添加一个回复
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # 在控制台上显示评论层级
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
    # 移除 comment1 和所有回复
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="注意" %}} 

* 当使用 [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) 方法（来自 [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) 接口）删除评论时，评论的回复也会被删除。
* 如果 [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 设置导致循环引用，将抛出 [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException)。

{{% /alert %}}

## **添加现代评论**

在 2021 年，微软在 PowerPoint 中引入了 *现代评论*。现代评论功能显著改善了 PowerPoint 中的协作。通过现代评论，PowerPoint 用户可以更轻松地解决评论、将评论锚定到对象和文本上，并进行互动。

在 [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/) 中，我们通过添加 [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment) 类实现了对现代评论的支持。方法 [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) 和 [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) 被添加到 [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection) 类中。

以下 PHP 代码向您展示如何在 PowerPoint 演示文稿中向幻灯片添加现代评论：

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

以下 PHP 代码向您展示如何删除演示文稿中的所有评论和作者：

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

以下 PHP 代码向您展示如何删除幻灯片上的特定评论：

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 添加评论...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # 移除所有包含 "comment 1" 文本的评论
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