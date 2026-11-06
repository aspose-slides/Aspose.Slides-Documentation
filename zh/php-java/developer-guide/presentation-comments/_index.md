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
- 移除批注
- 删除批注
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理演示文稿批注：快速轻松地在 PowerPoint 演示文稿中添加、读取、编辑、回复和移除批注。"
---
## **概述**

本文档说明了如何使用 Aspose.Slides for PHP via Java 管理演示文稿批注。它介绍了主要的与批注相关的类型，并演示了如何向幻灯片添加批注、访问已有批注、处理回复和现代批注，以及如何从演示文稿中删除批注。

示例涵盖了 PowerPoint 中常见的审阅和协作场景，例如为作者分配批注、读取批注文本和元数据、构建回复链，以及删除选定批注或全部批注。

在 PowerPoint 中，批注显示为幻灯片上的注释。选中批注时会显示其文本和相关讨论。

如需在打开演示文稿时请求显示或隐藏批注（而不更改批注本身），请参阅 [Show or Hide Comments When Opening a Presentation](/slides/zh/php-java/presentation-view-properties/)。

## **为何向演示文稿添加批注？**

在审阅演示文稿时，您可以使用批注提供反馈并与同事协作。

Aspose.Slides for PHP via Java 提供以下用于处理批注的 API：

* [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类，提供对演示文稿批注作者的访问。
* [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) 类，表示与单个作者关联的批注集合。
* [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) 类，提供有关批注的信息，包括作者、创建时间、位置和文本。
* [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) 类，提供有关作者的信息，包括名称、缩写和关联的批注。

## **添加幻灯片批注**

示例创建了两张幻灯片，并使用 [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) 注册了一个批注作者。它使用 [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) 在每张幻灯片上放置一个批注，然后使用 [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) 检索该作者在第一张幻灯片上的批注。控制台两次显示第一条批注的文本，演示了通过幻灯片和作者两种方式访问，并且保存的演示文稿包含这两个批注。

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

## **查找或创建批注作者**

当自动审阅重复处理同一演示文稿时，应在添加作者之前先搜索 [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) 返回的集合。[findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) 同时匹配姓名和缩写，并返回匹配作者的数组，如无匹配则返回空数组。相比之下，[findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) 仅按姓名搜索，不考虑缩写。使用已经存在的姓名和缩写调用 [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) 会抛出异常。

示例需要一个至少包含一张幻灯片的演示文稿。两次遍历中，它复用第一个匹配的作者，或在结果为空时创建新作者。如果匹配多个，它选择数组的第一个元素，且不合并或删除其他作者。随后为选定的作者调用 [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) 并保存演示文稿。第二次遍历打开第一次的输出并重复该操作。

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$authorName = "Reviewer";
$authorInitials = "RV";

$inputFile = "input.pptx";
$position = new Point2DFloat(20, 20);
$arrayClass = new JavaClass("java.lang.reflect.Array");

for ($pass = 1; $pass <= 2; $pass++) {
    $presentation = new Presentation($inputFile);
    try {
        $matches = $presentation->getCommentAuthors()->findByNameAndInitials($authorName, $authorInitials);
        $matchCount = java_values($arrayClass->getLength($matches));

        $author = $matchCount > 0 ? $matches[0] : $presentation->getCommentAuthors()->addAuthor($authorName, $authorInitials);
        $createdTime = new Java("java.util.Date");
        $author->getComments()->addComment("Please review this slide.", $presentation->getSlides()->get_Item(0), $position, $createdTime);

        $outputFile = "review_pass_" . $pass . ".pptx";
        $presentation->save($outputFile, SaveFormat::Pptx);
        $inputFile = $outputFile;
    } finally {
        $presentation->dispose();
    }
}
```

第二次遍历在不添加新作者或删除已有批注的前提下再添加一个批注。最终文件 `review_pass_2.pptx` 包含这两个新批注以及任何原始批注。复用作者不会去重批注：若要防止重复添加相同批注，需要在添加前实现单独的去重检测。

## **访问幻灯片批注**

示例打开一个已有的演示文稿，并读取 [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) 返回的集合。对每位作者，遍历 [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) 返回的集合，并打印幻灯片编号、批注文本、作者名称和创建时间。输入的演示文稿必须包含批注才能产生控制台输出。

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

父批注是回复层级顶部的原始批注。[Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) 和 [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) 方法允许获取或设置批注的父批注。

示例创建了两位作者的批注，并使用 [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) 构建回复，包括对另一个回复的回复。向 [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) 传入 `null` 可检索所有作者的批注；控制台按回复层级深度缩进每条记录。示例保存完整的讨论，对第一个根批注调用 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/)，并保存第二个演示文稿，已删除该批注及其所有回复。

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

{{% alert color="warning" title="Warning" %}}
* 当使用 [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) 方法删除批注时，所有对此批注的回复也会被删除。
* 如果 [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) 创建了循环引用，将抛出 [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **添加现代批注**

现代批注可以关联到幻灯片本身、特定形状，或 AutoShape 内的文本范围。[CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) 方法除了接受幻灯片和批注标记坐标外，还接受一个 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 参数。

当 shape 参数为 `null` 时，批注为幻灯片级批注。其标记由提供的坐标定位，但不关联特定形状，因此 [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) 返回 `null`。当提供了 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 时，批注锚定到该形状。坐标仍定义批注标记在幻灯片上的位置，而形状关联可通过 [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) 获得。

### **将现代批注锚定到形状**

示例两次调用 [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/)：一次使用 `null` shape 添加幻灯片级批注，另一次使用矩形作为锚点。读取 [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) 时，幻灯片级批注的空检查返回 `true`，锚定批注返回 `Revenue title`。两个批注均随演示文稿一起保存。

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

任何由 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类表示的幻灯片对象都可用作形状锚点。常见示例包括 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) 和 [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/)（如图表）实例。

示例使用 [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) 将批注分别关联到五种形状类型：AutoShape、图片框、组合形状、连接线和图表。图片使用嵌入的图像数据，无需外部图像。每个批注都有自己的标记位置，保存的演示文稿保留了全部五种形状关联。

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

对于关联到 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 的现代批注，[ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) 与 [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) 访问形状文本框中所选文本的起始位置。[ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) 与 [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) 访问选区长度。两者共同将批注关联到 AutoShape 中的特定文本范围。

[ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) 与 [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) 方法访问 [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) 常量中的值：

- `NotDefined` — 未定义特定的现代批注状态。
- `Active` — 批注处于活动状态。
- `Resolved` — 批注已解决。
- `Closed` — 批注已关闭。

示例将现代批注锚定到矩形文本中的 “quarterly revenue” 四个字。它根据文本计算零基选区起始位置并传递给 [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/)，再使用 [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) 设置选中的字符数。随后调用 [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) 将状态设为 `Resolved`，保存并重新打开演示文稿。四个控制台检查应分别打印 `true`，确认形状锚点、文本范围和状态均已保留。

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

示例需要一个包含现代批注的已有演示文稿，并打印其文本、状态和锚点详情。检查每个批注是否为 [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/)，然后检查 [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/)、[ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/)、[ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) 和 [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/)。`null` shape 表示幻灯片级批注。对于 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 锚点，文本选择方法可识别形状文本框中的相应范围。

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

Aspose.Slides for PHP via Java 允许您删除演示文稿中所有批注及其作者，或在保留其余内容的前提下删除选定批注。下面的示例演示了这两种方法，并保存了更新后的演示文稿。

### **删除所有批注和批注作者**

示例打开一个已有的演示文稿，对每位作者调用 [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/)，随后调用 [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) 删除作者本身。保存的演示文稿既不包含批注，也不包含批注作者。请使用包含批注的演示文稿来观察删除效果。

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

示例在同一张幻灯片上创建两个批注，并使用 [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) 按作者查找批注。它收集文本等于 “comment 1” 的批注后，调用 [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/) 删除这些批注，避免在选择期间修改集合。保存的演示文稿仅保留 “comment 2”。

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

是的。[ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) 和 [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) 可访问 [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) 值，包括 `Resolved`。该状态存储在演示文稿中，文件重新打开后仍可读取。

**是否支持线程式讨论（回复链），且是否有嵌套深度限制？**

是的。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/)，从而形成回复链。API 并未定义具体的嵌套深度限制。

**批注标记在幻灯片上的位置采用何种坐标系定义？**

标记位置使用幻灯片坐标系中的浮点坐标定义，您可以精确地将其放置在幻灯片上的任意位置。