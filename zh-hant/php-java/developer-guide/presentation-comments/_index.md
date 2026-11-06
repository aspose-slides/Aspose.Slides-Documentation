---
title: 在 PHP 中管理簡報批註
linktitle: 簡報批註
type: docs
weight: 100
url: /zh-hant/php-java/presentation-comments/
keywords:
- 批註
- 現代批註
- PowerPoint 批註
- 簡報批註
- 投影片批註
- 新增批註
- 存取批註
- 編輯批註
- 回覆批註
- 移除批註
- 刪除批註
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理簡報批註：快速且輕鬆地在 PowerPoint 簡報中新增、閱讀、編輯、回覆及移除批註。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for PHP via Java 來管理簡報批註。它會介紹主要的批註相關型別，並示範如何在投影片上新增批註、存取既有批註、處理回覆與現代批註，以及如何從簡報中移除批註。

這些範例涵蓋 PowerPoint 中常見的審閱與協作情境，例如指派批註給作者、讀取批註文字與中繼資料、建立回覆鏈，以及移除選取的批註或全部批註。

在 PowerPoint 中，批註會顯示為投影片上的註解。選取批註時會顯示其文字及相關討論。

若要在開啟簡報時請求顯示或隱藏批註（而不變更批註本身），請參閱 [Show or Hide Comments When Opening a Presentation](/slides/zh-hant/php-java/presentation-view-properties/)。

## **為何要在簡報中加入批註？**

在審閱簡報時，您可以使用批註提供回饋並與同事協作。

Aspose.Slides for PHP via Java 提供以下 API 以處理批註：

* [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別，提供存取簡報的批註作者。
* [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) 類別，表示與單一作者相關的批註集合。
* [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) 類別，提供批註資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) 類別，提供作者資訊，包括姓名、姓名縮寫與相關批註。

## **新增投影片批註**

此範例建立兩張投影片，並使用 [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) 註冊批註作者。它透過 [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) 在每張投影片上放置一則批註，接著使用 [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) 取得該作者在第一張投影片的批註。主控台會兩次顯示第一則批註的文字，示範透過投影片與作者兩種方式存取，同時已儲存的簡報會包含兩則批註。

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

## **尋找或建立批註作者**

當自動化審閱重複處理相同簡報時，請在新增作者之前先搜尋由 [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) 回傳的集合。[findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) 同時比對姓名與縮寫，並回傳符合的作者陣列；若無符合者則回傳空陣列。相較之下，[findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) 僅依姓名搜尋，與縮寫無關。使用已存在於集合中的姓名與縮寫呼叫 [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) 會拋出例外。

此範例需要一個至少含有一張投影片的簡報檔案。於兩次執行的每一次，它都會重複使用第一個符合的作者，或在結果為空時才建立新作者。若有多筆符合，會選取陣列的第一個元素，而不會合併或移除其他作者。然後它會為選取的作者呼叫 [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) 並儲存簡報。第二次執行會開啟第一次的輸出並重複此操作。

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

第二次執行會新增另一則批註，但不會再新增作者或移除既有批註。最終檔案 `review_pass_2.pptx` 會同時包含兩則新批註以及任何原始批註。重複使用作者不會去除重複的批註：若要避免重複加入相同批註，請在加入前自行實作重複偵測。

## **存取投影片批註**

此範例開啟現有簡報，讀取由 [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) 回傳的集合。對於每位作者，它會遍歷由 [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) 回傳的集合，並印出投影片編號、批註文字、作者姓名與建立時間。輸入簡報必須包含批註才能產生主控台輸出。

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

## **回覆批註**

父批註是回覆階層最上層的原始批註。[Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) 與 [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) 方法讓您取得或設定批註的父批註。

此範例建立兩位作者的批註，並使用 [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) 來建立回覆，包括對另一則回覆的回覆。將 `null` 傳遞給 [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) 會取得所有作者的批註；主控台會根據回覆階層深度縮排每個條目。範例會儲存完整的討論，對第一個根批註呼叫 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/)，並儲存第二份已移除該批註及其回覆的簡報。

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
* 使用 [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) 方法刪除批註時，該批註的所有回覆也會一起被刪除。
* 若 [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) 建立循環參照，會拋出 [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **新增現代批註**

現代批註可以與投影片本身、特定圖形，或 AutoShape 內的文字範圍相關聯。[CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) 方法除了接受投影片與批註標記座標外，還接受一個 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 參數。

當傳入 `null` 作為圖形參數時，批註為投影片層級批註。其標記依提供的座標定位，但不會與特定圖形關聯，因此 [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) 會回傳 `null`。若提供 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)，批註則會錨定於該圖形。座標仍然定義批註標記在投影片上的位置，而圖形關聯可透過 [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) 取得。

### **將現代批註錨定到圖形**

此範例分別以 `null` 圖形（投影片層級批註）與矩形作為錨點兩次呼叫 [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/)。讀取 [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) 時，會對投影片層級批註的 `null` 檢查印出 `true`，對錨定批註則印出 `Revenue title`。兩則批註皆隨簡報儲存。

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

### **將批註錨定到不同類型的圖形**

任何由 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 類別表示的投影片物件都可作為圖形錨點。常見範例包括 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) 與 [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/)（例如圖表）實例。

此範例使用 [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) 為五種圖形類型各建立一則批註：AutoShape、圖片框、群組、連接線與圖表。圖片使用嵌入式影像資料，無需外部影像。每則批註都有自己的標記位置，儲存的簡報會保留所有五種圖形的關聯。

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

### **將批註錨定到文字並設定其狀態**

對於與 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 相關的現代批註，[ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) 與 [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) 取得圖形文字框中所選文字的起始位置。[ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) 與 [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) 取得選取的長度。這兩個值一起將批註與 AutoShape 內特定文字範圍關聯。

[ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) 與 [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) 方法會存取 [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) 常數中的值：

- `NotDefined` — 未定義特定的現代批註狀態。
- `Active` — 批註為啟用狀態。
- `Resolved` — 批註已解決。
- `Closed` — 批註已關閉。

此範例將現代批註錨定於矩形文字中的「quarterly revenue」字樣。它先計算零基的選取起點，傳遞給 [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/)，再使用 [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) 設定選取的字元數。之後以 `Resolved` 呼叫 [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/)，儲存並重新開啟簡報。四個主控台檢查皆應印出 `true`，以確認圖形錨點、文字範圍與狀態皆被保留。

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

### **檢視現有的現代批註**

此範例需要一個已包含現代批註的簡報，並印出其文字、狀態與錨點細節。檢視時，先確認每則批註是否為 [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/)，再檢查 [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/)、[ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/)、[ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) 與 [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/)。`null` 圖形表示投影片層級批註。若為 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 錨點，文字選取方法會指出圖形文字框中的相關範圍。

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

## **移除批註**

Aspose.Slides for PHP via Java 可讓您從簡報中移除所有批註與其作者，或僅刪除選取的批註而保留其餘批註。以下範例示範兩種作法，並儲存更新後的簡報。

### **移除全部批註與批註作者**

此範例開啟現有簡報，對每位作者呼叫 [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/)，然後呼叫 [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) 移除作者本身。儲存的簡報將不再包含批註與批註作者。請使用含有批註的簡報以觀察移除效果。

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

### **移除特定批註**

此範例在同一張投影片上建立兩則批註，並使用 [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) 依作者找出批註。它會收集文字等於「comment 1」的批註，然後呼叫 [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/) 移除它們，以避免在選取期間改變集合。儲存的簡報只會保留「comment 2」。

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

**Aspose.Slides 是否支援現代批註的已解決狀態？**

是的。[ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) 與 [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) 可存取 [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) 中的值，包括 `Resolved`。此狀態會儲存在簡報中，重新開啟檔案後仍可讀取。

**是否支援串接討論（回覆鏈），是否有巢狀深度限制？**

是的。每則批註都可以參照其 [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/)，從而形成回覆鏈。API 並未定義特定的巢狀深度限制。

**批註標記在投影片上的位置是以何種座標系統定義的？**

標記位置以浮點座標定義於投影片座標系統中，讓您可以精確地將其放置於投影片上。