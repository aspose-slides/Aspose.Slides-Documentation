---
title: 管理 PHP 中的演示文稿批注
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
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理演示文稿批注：在 PowerPoint 演示文稿中快速轻松地添加、读取、编辑、回复和删除批注。"
---
## **概述**

本文档说明如何使用 Aspose.Slides for PHP via Java 管理演示文稿中的批注。它介绍了主要的批注相关类型，并演示了如何向幻灯片添加批注、访问现有批注、处理回复和现代批注，以及从演示文稿中删除批注。

示例覆盖了 PowerPoint 中常见的审阅与协作场景，例如为作者分配批注、读取批注文本和元数据、构建回复链以及删除选定批注或全部批注。

在 PowerPoint 中，批注显示为幻灯片上的注释。选中批注后会显示其文本及相关讨论。

## **为什么要向演示文稿添加批注？**

在审阅演示文稿时，您可以使用批注提供反馈并与同事协作。

Aspose.Slides for PHP via Java 提供了以下用于处理批注的 API：

* [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类，提供对演示文稿批注作者的访问。
* [CommentCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/commentcollection/) 类，表示与单个作者关联的批注集合。
* [Comment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/comment/) 类，提供批注的信息，包括作者、创建时间、位置和文本。
* [CommentAuthor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/commentauthor/) 类，提供作者的信息，包括姓名、缩写和关联的批注。

## **向幻灯片添加批注**

以下示例展示了如何向 PowerPoint 演示文稿的幻灯片添加批注：

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($presentation->getLayoutSlides()->get_Item(0));
    $author = $presentation->getCommentAuthors()->addAuthor("Jawad", "MF");
    $position = new Point2DFloat(0.2, 0.2);
    $createdTime = new Java("java.util.Date");

    $author->getComments()->addComment("Hello Jawad, this is a slide comment", $firstSlide, $position, $createdTime);
    $author->getComments()->addComment("Hello Jawad, this is the second slide comment", $secondSlide, $position, $createdTime);

    $comments = $firstSlide->getSlideComments($author);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    if ($commentCount > 0) {
        $firstComment = $comments[0];
        echo java_values($firstComment->getText()) . PHP_EOL;

        $authorComments = $firstComment->getAuthor()->getComments();
        $commentText = $authorComments->get_Item(0)->getText();
        echo java_values($commentText) . PHP_EOL;
    }

    $presentation->save("Comments_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **访问幻灯片批注**

以下示例展示了如何访问 PowerPoint 演示文稿中已有的批注：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Comments1.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        foreach ($author->getComments() as $comment) {
            echo "Slide: " . java_values($comment->getSlide()->getSlideNumber()) . PHP_EOL;
            echo "Comment: " . java_values($comment->getText()) . PHP_EOL;
            echo "Author: " . java_values($comment->getAuthor()->getName()) . PHP_EOL;
            echo "Posted at: " . java_values($comment->getCreatedTime()->toString()) . PHP_EOL;
            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **回复批注**

父批注是回复层次结构顶部的原始批注。`[Comment::getParentComment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/comment/getparentcomment/)` 和 `[Comment::setParentComment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/comment/setparentcomment/)` 方法可用于获取或设置批注的父批注。

以下示例展示了如何添加回复并检查生成的批注层次结构：

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $position = new Point2DFloat(10, 10);
    $createdTime = new Java("java.util.Date");

    $author1 = $presentation->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment 1", $slide, $position, $createdTime);

    $author2 = $presentation->getCommentAuthors()->addAuthor("Author_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $slide, $position, $createdTime);
    $reply1->setParentComment($comment1);

    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $slide, $position, $createdTime);
    $reply2->setParentComment($comment1);

    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $slide, $position, $createdTime);
    $subReply->setParentComment($reply2);

    $author2->getComments()->addComment("comment 2", $slide, $position, $createdTime);
    $comment3 = $author2->getComments()->addComment("comment 3", $slide, $position, $createdTime);

    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $slide, $position, $createdTime);
    $reply3->setParentComment($comment3);

    $comments = $slide->getSlideComments(null);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    for ($i = 0; $i < $commentCount; $i++) {
        $comment = $comments[$i];
        while (!java_is_null($comment->getParentComment())) {
            echo "\t";
            $comment = $comment->getParentComment();
        }

        echo java_values($comments[$i]->getAuthor()->getName()) . ": " . java_values($comments[$i]->getText()) . PHP_EOL;
    }

    $presentation->save("parent_comment.pptx", SaveFormat::Pptx);

    $comment1->remove();
    $presentation->save("remove_comment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="警告" %}}
* 当使用 `[Comment::remove](https://reference.aspose.com/slides/zh/php-java/aspose.slides/comment/remove/)` 方法删除批注时，该批注的所有回复也会被删除。
* 如果 `[Comment::setParentComment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/comment/setparentcomment/)` 创建了循环引用，则会抛出 `[PptxEditException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pptxeditexception/)`。
{{% /alert %}}

## **添加现代批注**

现代批注可以关联到幻灯片本身、特定形状或 AutoShape 中的文本范围。`[CommentCollection::addModernComment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/commentcollection/addmoderncomment/)` 方法除了接收幻灯片和批注标记坐标外，还接受一个 `[Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/)` 参数。

当为形状参数传入 `null` 时，批注为幻灯片级批注。其标记由提供的坐标定位，但不关联到特定形状，因此 `[ModernComment::getShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/getshape/)` 返回 `null`。当提供 `[Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/)` 时，批注锚定到该形状。坐标仍定义批注标记在幻灯片上的位置，而形状关联可通过 `[ModernComment::getShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/getshape/)` 获取。

### **将现代批注锚定到形状**

以下示例创建了一个幻灯片级现代批注和一个锚定到特定 AutoShape 的现代批注，然后读取每个批注的关联形状。

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 300, 80);
    $shape->setName("Revenue title");
    $shape->getTextFrame()->setText("Quarterly revenue");

    $createdTime = new Java("java.util.Date");
    $slideCommentPosition = new Point2DFloat(20, 20);
    $shapeCommentPosition = new Point2DFloat(60, 60);
    $slideComment = $author->getComments()->addModernComment("Review the overall slide layout.", $slide, null, $slideCommentPosition, $createdTime);
    $shapeComment = $author->getComments()->addModernComment("Check this title.", $slide, $shape, $shapeCommentPosition, $createdTime);

    echo (java_is_null($slideComment->getShape()) ? "true" : "false") . PHP_EOL;
    echo java_values($shapeComment->getShape()->getName()) . PHP_EOL;

    $presentation->save("modern_comments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **将批注锚定到不同的形状类型**

任何由 `[Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/)` 类表示的幻灯片对象都可用作形状锚点。常见示例包括 `[AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)`、`[PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/)`、`[GroupShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/groupshape/)`、`[Connector](https://reference.aspose.com/slides/zh/php-java/aspose.slides/connector/)` 和 `[GraphicalObject](https://reference.aspose.com/slides/zh/php-java/aspose.slides/graphicalobject/)`（如图表）实例。

以下示例创建了几种常见形状类型，并为每种形状关联了一个现代批注。

```php
use aspose\slides\ChartType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $createdTime = new Java("java.util.Date");

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 180, 60);
    $autoShape->getTextFrame()->setText("AutoShape");
    $autoShapeCommentPosition = new Point2DFloat(30, 30);
    $author->getComments()->addModernComment("Comment on an AutoShape.", $slide, $autoShape, $autoShapeCommentPosition, $createdTime);

    $imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    $base64Class = new JavaClass("java.util.Base64");
    $imageData = $base64Class->getDecoder()->decode($imageBase64);
    $image = $presentation->getImages()->addImage($imageData);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 120, 80, $image);
    $pictureCommentPosition = new Point2DFloat(230, 30);
    $author->getComments()->addModernComment("Comment on a picture.", $slide, $pictureFrame, $pictureCommentPosition, $createdTime);

    $groupShape = $slide->getShapes()->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 80, 40);
    $groupShape->getShapes()->addAutoShape(ShapeType::Ellipse, 100, 0, 80, 40);
    $groupCommentPosition = new Point2DFloat(40, 150);
    $author->getComments()->addModernComment("Comment on a group.", $slide, $groupShape, $groupCommentPosition, $createdTime);

    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 220, 150, 140, 40);
    $connectorCommentPosition = new Point2DFloat(240, 150);
    $author->getComments()->addModernComment("Comment on a connector.", $slide, $connector, $connectorCommentPosition, $createdTime);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 400, 20, 250, 180);
    $chartCommentPosition = new Point2DFloat(420, 40);
    $author->getComments()->addModernComment("Comment on a graphical object.", $slide, $chart, $chartCommentPosition, $createdTime);

    $presentation->save("modern_comment_shape_types.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **将批注锚定到文本并设置其状态**

对于关联到 `[AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)` 的现代批注，`[ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/gettextselectionstart/)` 和 `[ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/settextselectionstart/)` 访问形状文本框中选中文本的起始位置。`[ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/gettextselectionlength/)` 和 `[ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/settextselectionlength/)` 访问选区长度。这些值共同将批注关联到 AutoShape 中的特定文本范围。

`[ModernComment::getStatus](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/getstatus/)` 和 `[ModernComment::setStatus](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/setstatus/)` 方法访问来自 `[ModernCommentStatus](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncommentstatus/)` 常量的值：

- `NotDefined` — 未定义特定的现代批注状态。
- `Active` — 批注处于活动状态。
- `Resolved` — 批注已解决。
- `Closed` — 批注已关闭。

以下示例创建了一个锚定到形状的现代批注，将其关联到文本选区，标记为已解决，保存演示文稿并在重新打开文件后验证这些值。

```php
use aspose\slides\ModernCommentStatus;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$outputFile = "modern_comment_text_anchor.pptx";
$shapeText = "Review the quarterly revenue forecast.";
$selectedText = "quarterly revenue";
$expectedSelectionStart = strpos($shapeText, $selectedText);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->setName("Forecast text");
    $shape->getTextFrame()->setText($shapeText);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $commentPosition = new Point2DFloat(60, 60);
    $comment = $author->getComments()->addModernComment("Verify this forecast wording.", $slide, $shape, $commentPosition, new Java("java.util.Date"));
    $comment->setTextSelectionStart($expectedSelectionStart);
    $comment->setTextSelectionLength(strlen($selectedText));
    $comment->setStatus(ModernCommentStatus::Resolved);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedComments = $reopenedSlide->getSlideComments(null);
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");

    foreach ($reopenedComments as $reopenedComment) {
        if (!java_instanceof($reopenedComment, $modernCommentClass)) {
            continue;
        }

        $shape = $reopenedComment->getShape();
        $shapeMatches = !java_is_null($shape) && java_values($shape->getName()) === "Forecast text";
        $selectionStartMatches = java_values($reopenedComment->getTextSelectionStart()) === $expectedSelectionStart;
        $selectionLengthMatches = java_values($reopenedComment->getTextSelectionLength()) === strlen($selectedText);
        $statusMatches = java_values($reopenedComment->getStatus()) === ModernCommentStatus::Resolved;

        echo "Shape anchor preserved: " . ($shapeMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection start preserved: " . ($selectionStartMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection length preserved: " . ($selectionLengthMatches ? "true" : "false") . PHP_EOL;
        echo "Resolved status preserved: " . ($statusMatches ? "true" : "false") . PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

### **检查现有的现代批注**

要检查已有的演示文稿，首先判断每个批注是否为 `[ModernComment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/)`，然后检查 `[ModernComment::getShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/getshape/)`、`[ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/gettextselectionstart/)`、`[ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/gettextselectionlength/)` 和 `[ModernComment::getStatus](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/getstatus/)`。`null` 形状表示幻灯片级批注。对于锚定到 `[AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)` 的批注，文本选区方法标识该形状文本框中的关联范围。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("comments.pptx");
try {
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    foreach ($presentation->getSlides() as $slide) {
        $comments = $slide->getSlideComments(null);
        foreach ($comments as $comment) {
            if (!java_instanceof($comment, $modernCommentClass)) {
                continue;
            }

            echo "Slide: " . java_values($slide->getSlideNumber()) . PHP_EOL;
            echo "Text: " . java_values($comment->getText()) . PHP_EOL;
            echo "Status: " . java_values($comment->getStatus()) . PHP_EOL;

            $shape = $comment->getShape();
            if (java_is_null($shape)) {
                echo "Anchor: slide level" . PHP_EOL;
            } else {
                echo "Anchor shape: " . java_values($shape->getName()) . PHP_EOL;
                echo "Anchor type: " . java_values($shape->getClass()->getSimpleName()) . PHP_EOL;

                if (java_instanceof($shape, $autoShapeClass)) {
                    echo "Text selection start: " . java_values($comment->getTextSelectionStart()) . PHP_EOL;
                    echo "Text selection length: " . java_values($comment->getTextSelectionLength()) . PHP_EOL;
                }
            }

            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **删除批注**

### **删除所有批注及批注作者**

以下示例展示了如何删除演示文稿中的全部批注和批注作者：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("example.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        $author->getComments()->clear();
    }

    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **删除特定批注**

以下示例展示了如何从幻灯片中删除特定批注：

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $createdTime = new Java("java.util.Date");

    $firstCommentPosition = new Point2DFloat(0.2, 0.2);
    $secondCommentPosition = new Point2DFloat(0.3, 0.2);
    $author->getComments()->addComment("comment 1", $slide, $firstCommentPosition, $createdTime);
    $author->getComments()->addComment("comment 2", $slide, $secondCommentPosition, $createdTime);

    foreach ($presentation->getCommentAuthors() as $commentAuthor) {
        $commentsToRemove = new Java("java.util.ArrayList");
        $comments = $slide->getSlideComments($commentAuthor);

        foreach ($comments as $comment) {
            if ($comment->getText()->equals("comment 1")) {
                $commentsToRemove->add($comment);
            }
        }

        foreach ($commentsToRemove as $comment) {
            $commentAuthor->getComments()->remove($comment);
        }
    }

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常见问题**

**Aspose.Slides 是否支持现代批注的已解决状态？**

是的。`[ModernComment::getStatus](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/getstatus/)` 和 `[ModernComment::setStatus](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncomment/setstatus/)` 可访问 `[ModernCommentStatus](https://reference.aspose.com/slides/zh/php-java/aspose.slides/moderncommentstatus/)` 中的值，包括 `Resolved`。该状态会存储在演示文稿中，文件重新打开后仍可读取。

**是否支持线程式讨论（回复链），并且是否有嵌套深度限制？**

是的。每个批注都可以引用其 `[parent comment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/comment/getparentcomment/)`，从而实现回复链。API 未定义具体的嵌套深度限制。

**批注标记在幻灯片上的位置使用哪种坐标系定义？**

标记位置使用幻灯片坐标系中的浮点坐标，可在幻灯片上精确定位。