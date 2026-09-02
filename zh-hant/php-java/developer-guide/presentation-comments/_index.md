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
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理簡報評論：快速且輕鬆地在 PowerPoint 簡報中新增、讀取、編輯、回覆及移除評論。"
---
## **概述**

本文說明如何使用 Aspose.Slides for PHP via Java 來管理簡報評論。它會介紹主要的與評論相關的類型，並示範如何向投影片新增評論、存取現有評論、處理回覆與現代評論，以及從簡報中移除評論。

範例涵蓋 PowerPoint 中常見的審閱與協作情境，例如將評論指派給作者、讀取評論文字與中繼資料、建立回覆鏈以及移除選取的評論或全部評論。

在 PowerPoint 中，評論顯示為投影片上的標註。選取評論時會顯示其文字與相關討論。

## **為何在簡報中加入評論？**

在審閱簡報時，可使用評論提供回饋並與同事協作。

Aspose.Slides for PHP via Java 提供以下 API 以處理評論：

* The [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [CommentCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commentcollection/) class, which represents the comments associated with an individual author.
* The [Comment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/) class, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **新增投影片評論**

以下範例說明如何在 PowerPoint 簡報的投影片中新增評論：

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

## **存取投影片評論**

以下範例說明如何存取 PowerPoint 簡報中已存在的評論：

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

## **回覆評論**

父評論是回覆階層頂端的原始評論。[Comment::getParentComment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/getparentcomment/) 與 [Comment::setParentComment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/setparentcomment/) 方法讓您取得或設定評論的父項。

以下範例說明如何新增回覆並檢查產生的評論階層：

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
* 使用 [Comment::remove](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/remove/) 方法刪除評論時，該評論的所有回覆也會一起被刪除。
* 若 [Comment::setParentComment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/setparentcomment/) 產生循環參考，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **新增現代評論**

現代評論可以關聯至整張投影片、特定形狀，或 AutoShape 內的文字範圍。[CommentCollection::addModernComment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/commentcollection/addmoderncomment/) 方法除了接受投影片與評論標記座標外，還接受一個 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 參數。

當 shape 參數傳入 `null` 時，評論為投影片層級的評論。其標記會依提供的座標定位，但不會與特定形狀關聯，因此 [ModernComment::getShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/getshape/) 會回傳 `null`。若提供了 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/)，則評論會錨定至該形狀。座標仍然定義評論標記在投影片上的位置，而形狀關聯可透過 [ModernComment::getShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/getshape/) 取得。

### **將現代評論錨定至形狀**

以下範例同時建立投影片層級的現代評論與錨定至特定 AutoShape 的現代評論，並從每個評論中讀取關聯的形狀。

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

### **將評論錨定至不同形狀類型**

任何由 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 類別表示的投影片物件皆可作為形狀錨點。常見範例包括 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/connector/) 與 [GraphicalObject](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/graphicalobject/)（例如圖表）等實例。

以下範例建立多種常見形狀類型，並為每個形狀關聯一個現代評論。

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

### **將評論錨定至文字並設定其狀態**

對於關聯至 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 的現代評論， [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/gettextselectionstart/) 與 [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/settextselectionstart/) 取得形狀文字框中選取文字的起始位置。 [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/gettextselectionlength/) 與 [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/settextselectionlength/) 取得選取的長度。這兩個值共同將評論與 AutoShape 內的特定文字範圍關聯起來。

[ModernComment::getStatus](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/getstatus/) 與 [ModernComment::setStatus](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/setstatus/) 方法存取 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncommentstatus/) 常數中的值：

- `NotDefined` — 未定義特定的現代評論狀態。
- `Active` — 評論為活躍狀態。
- `Resolved` — 評論已解決。
- `Closed` — 評論已關閉。

以下範例建立形狀錨定的現代評論，將其與文字選取關聯，標記為已解決，儲存簡報，並在重新開啟檔案後驗證其值。

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

### **檢查現有的現代評論**

檢查現有簡報時，先判斷每個評論是否為 [ModernComment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/)，然後檢查 [ModernComment::getShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/getshape/)、[ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/gettextselectionstart/)、[ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/gettextselectionlength/) 與 [ModernComment::getStatus](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/getstatus/)。`null` 形狀表示投影片層級的評論。若為 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 錨點，文字選取方法會指出形狀文字框中的相關範圍。

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

## **移除評論**

### **移除所有評論及評論作者**

以下範例示範如何從簡報中移除所有評論與評論作者：

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

### **移除特定評論**

以下範例示範如何從投影片中移除特定評論：

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

## **常見問題**

**Aspose.Slides 是否支援現代評論的已解決狀態？**

是的。[ModernComment::getStatus](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/getstatus/) 與 [ModernComment::setStatus](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncomment/setstatus/) 可存取 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/moderncommentstatus/) 值，其中包括 `Resolved`。此狀態會儲存在簡報中，重新開啟檔案後仍可讀取。

**是否支援串聯討論（回覆鏈），且是否有巢狀深度限制？**

是的。每個評論皆可參照其 [parent comment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/comment/getparentcomment/)，從而形成回覆鏈。API 並未定義具體的巢狀深度上限。

**評論標記在投影片上的位置是以哪種座標系統定義的？**

標記位置以浮點座標在投影片座標系統中定義，讓您能精確地將其放置於投影片上。