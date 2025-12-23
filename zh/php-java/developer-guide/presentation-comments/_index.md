---
title: 在 PHP 中管理演示文稿批注
linktitle: 演示文稿批注
type: docs
weight: 100
url: /zh/php-java/presentation-comments/
keywords:
- 批注
- 现代批注
- PowerPoint 批注
- 演示文稿批注
- 幻灯片批注
- 添加批注
- 访问批注
- 编辑批注
- 回复批注
- 删除批注
- 删除批注
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 精通演示文稿批注：快速、轻松地在 PowerPoint 文件中添加、读取、编辑和删除批注。"
---

在 PowerPoint 中，批注显示为幻灯片上的备注或注释。单击批注时，会显示其内容或信息。 

## **为什么要在演示文稿中添加批注？**

在审阅演示文稿时，您可能希望使用批注来提供反馈或与同事沟通。

为了让您在 PowerPoint 演示文稿中使用批注，Aspose.Slides for PHP via Java 提供了

* The [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类，包含作者集合（来自 [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection) 接口）。作者向幻灯片添加批注。  
* The  [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection) 接口，包含各个作者的批注集合。  
* The  [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) 类，包含关于作者及其批注的信息：谁添加了批注、批注添加的时间、批注的位置等。  
* The [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor) 类，包含关于单个作者的信息：作者的姓名、缩写、与作者姓名关联的批注等。  

## **添加幻灯片批注**
以下 PHP 代码演示如何在 PowerPoint 演示文稿的幻灯片中添加批注：
```php
  # 实例化 Presentation 类
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 添加空幻灯片
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # 添加作者
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # 设置批注的位置
    $point = new Point2DFloat(0.2, 0.2);
    # 为作者在幻灯片 1 上添加批注
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # 为作者在幻灯片 2 上添加批注
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # 访问 ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # 当参数为 null 时，将所有作者的批注带到所选幻灯片
    $Comments = $slide->getSlideComments($author);
    # 访问幻灯片 1 中索引 0 的批注
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # 选择作者在索引 0 处的批注集合
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **访问幻灯片批注**
以下 PHP 代码演示如何访问 PowerPoint 演示文稿中幻灯片的现有批注：
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


## **回复批注**
父批注是批注或回复层级结构中的顶层或原始批注。使用 [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) 或 [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 方法（来自 [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) 接口），可以设置或获取父批注。

以下 PHP 代码演示如何添加批注并获取对其的回复：
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 添加批注
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # 为 comment1 添加回复
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # 为 comment1 再添加一个回复
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # 为已有回复添加回复
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # 在控制台显示批注层级
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

* 当使用 [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) 方法（来自 [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) 接口）删除批注时，批注的回复也会被删除。  
* 如果 [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 设置导致循环引用，将抛出 [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) 。

{{% /alert %}}

## **添加现代批注**

2021 年，Microsoft 在 PowerPoint 中引入了 *现代批注*。现代批注功能显著提升了 PowerPoint 的协作能力。通过现代批注，PowerPoint 用户可以解决批注、将批注锚定到对象和文本，并更轻松地进行互动。

在 [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/) 中，我们通过添加 [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment) 类实现了对现代批注的支持。向 [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection) 类添加了 [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) 和 [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) 方法。

以下 PHP 代码演示如何在 PowerPoint 演示文稿的幻灯片中添加现代批注：
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


## **删除批注**

### **删除所有批注和作者**
以下 PHP 代码演示如何删除演示文稿中的所有批注和作者：
```php
  $presentation = new Presentation("example.pptx");
  try {
    # 删除演示文稿中的所有批注
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


### **删除特定批注**
以下 PHP 代码演示如何删除幻灯片上的特定批注：
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 添加批注...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # 删除所有包含 "comment 1" 文本的批注
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

**Aspose.Slides 是否支持现代批注的类似 “已解决” 的状态？**

是的。[Modern comments](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) 提供了 [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) 方法；您可以写入 [comment’s state](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/)（例如，将其标记为已解决），该状态会保存在文件中并被 PowerPoint 识别。

**是否支持线程式讨论（回复链），并且是否有嵌套深度限制？**

是的。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/)，从而实现任意的回复链。API 并未声明具体的嵌套深度限制。

**批注标记在幻灯片上的位置是在哪个坐标系中定义的？**

位置以浮点坐标点存储在幻灯片的坐标系中。这样可以将批注标记精确放置在所需位置。