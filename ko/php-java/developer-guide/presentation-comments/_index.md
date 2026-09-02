---
title: PHP에서 프레젠테이션 댓글 관리
linktitle: 프레젠테이션 댓글
type: docs
weight: 100
url: /ko/php-java/presentation-comments/
keywords:
- 댓글
- 최신 댓글
- PowerPoint 댓글
- 프레젠테이션 댓글
- 슬라이드 댓글
- 댓글 추가
- 댓글 접근
- 댓글 편집
- 댓글 회신
- 댓글 제거
- 댓글 삭제
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 프레젠테이션 댓글을 관리합니다: PowerPoint 프레젠테이션에서 댓글을 빠르고 쉽게 추가, 읽기, 편집, 회신 및 제거합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for PHP via Java를 사용하여 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 유형을 소개하고 슬라이드에 댓글을 추가하고, 기존 댓글에 접근하며, 회신 및 최신 댓글을 작업하고, 프레젠테이션에서 댓글을 제거하는 방법을 보여줍니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오를 다루며, 작성자에게 댓글을 할당하고, 댓글 텍스트와 메타데이터를 읽고, 회신 체인을 구축하고, 선택된 댓글 또는 모든 댓글을 제거하는 방법을 포함합니다.

PowerPoint에서 댓글은 슬라이드에 주석으로 표시됩니다. 댓글을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

## **프레젠테이션에 댓글을 추가하는 이유**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하기 위해 댓글을 사용할 수 있습니다.

Aspose.Slides for PHP via Java는 댓글 작업을 위한 다음 API를 제공합니다.

* The [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스는 프레젠테이션의 댓글 작성자에 대한 액세스를 제공합니다.
* The [CommentCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commentcollection/) 클래스는 개별 작성자와 연결된 댓글을 나타냅니다.
* The [Comment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/) 클래스는 댓글의 작성자, 생성 시각, 위치 및 텍스트 등을 포함한 정보를 제공합니다.
* The [CommentAuthor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commentauthor/) 클래스는 이름, 이니셜 및 연관된 댓글을 포함한 작성자 정보를 제공합니다.

## **슬라이드 댓글 추가**

다음 예제는 PowerPoint 프레젠테이션의 슬라이드에 댓글을 추가하는 방법을 보여줍니다.

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

## **슬라이드 댓글 접근**

다음 예제는 PowerPoint 프레젠테이션에서 기존 댓글에 접근하는 방법을 보여줍니다.

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

## **댓글에 회신 달기**

부모 댓글은 회신 계층 구조의 최상위에 위치한 원본 댓글입니다. [Comment::getParentComment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/getparentcomment/) 및 [Comment::setParentComment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/setparentcomment/) 메서드를 사용하면 댓글의 부모를 가져오거나 설정할 수 있습니다.

다음 예제는 회신을 추가하고 결과 댓글 계층 구조를 검사하는 방법을 보여줍니다.

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
* [Comment::remove](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/remove/) 메서드로 댓글을 삭제하면 해당 댓글에 대한 모든 회신도 함께 삭제됩니다.
* [Comment::setParentComment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/setparentcomment/)가 순환 참조를 만들 경우 [PptxEditException](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **최신 댓글 추가**

최신 댓글은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위와 연결될 수 있습니다. [CommentCollection::addModernComment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commentcollection/addmoderncomment/) 메서드는 슬라이드와 댓글 마커 좌표 외에 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 인수를 허용합니다.

`null`을 shape 인수에 전달하면 댓글은 슬라이드 수준 댓글이 됩니다. 마커는 제공된 좌표에 따라 배치되지만 특정 도형에 연결되지 않으므로 [ModernComment::getShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/getshape/)은 `null`을 반환합니다. [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/)가 제공될 경우 댓글은 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 마커 위치를 정의하고, 도형 연결은 [ModernComment::getShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/getshape/)을 통해 확인할 수 있습니다.

### **도형에 최신 댓글 고정**

다음 예제는 슬라이드 수준 최신 댓글과 특정 AutoShape에 고정된 최신 댓글을 모두 생성하고, 각각의 댓글에서 연관된 도형을 읽어옵니다.

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

### **다양한 도형 유형에 댓글 고정**

[Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 클래스로 표현되는 모든 슬라이드 객체를 도형 고정점으로 사용할 수 있습니다. 일반적인 예로 [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/ko/php-java/aspose.slides/connector/), 그리고 차트와 같은 [GraphicalObject](https://reference.aspose.com/slides/ko/php-java/aspose.slides/graphicalobject/) 인스턴스가 있습니다.

다음 예제는 여러 일반적인 도형 유형을 생성하고 각 도형에 최신 댓글을 연결합니다.

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

### **텍스트에 댓글 고정 및 상태 설정**

[AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)에 연결된 최신 댓글의 경우, [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/gettextselectionstart/) 및 [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/settextselectionstart/)은 도형 텍스트 프레임에서 선택된 텍스트의 시작 위치에 접근합니다. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/gettextselectionlength/) 및 [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/settextselectionlength/)은 선택 길이에 접근합니다. 이 값들은 댓글을 AutoShape 내부의 특정 텍스트 범위와 연결합니다.

[ModernComment::getStatus](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/getstatus/) 및 [ModernComment::setStatus](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/setstatus/) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncommentstatus/) 상수 중 하나의 값을 반환하거나 설정합니다.

- `NotDefined` — 특정 최신 댓글 상태가 정의되지 않음.
- `Active` — 댓글이 활성 상태임.
- `Resolved` — 댓글이 해결됨.
- `Closed` — 댓글이 닫힘.

다음 예제는 도형에 고정된 최신 댓글을 생성하고, 텍스트 선택에 연결한 뒤, 해결된 상태로 표시하고, 프레젠테이션을 저장한 후 파일을 다시 열어 값을 확인합니다.

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

### **기존 최신 댓글 검사**

기존 프레젠테이션을 검사하려면 각 댓글이 [ModernComment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/)인지 확인한 다음, [ModernComment::getShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/gettextselectionlength/), 그리고 [ModernComment::getStatus](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/getstatus/)를 검사합니다. `null` 도형은 슬라이드 수준 댓글을 의미합니다. [AutoShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/autoshape/)에 고정된 경우, 텍스트 선택 메서드는 도형 텍스트 프레임 내 연관된 범위를 식별합니다.

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

## **댓글 제거**

### **모든 댓글 및 댓글 작성자 제거**

다음 예제는 프레젠테이션에서 모든 댓글 및 댓글 작성자를 제거하는 방법을 보여줍니다.

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

### **특정 댓글 제거**

다음 예제는 슬라이드에서 특정 댓글을 제거하는 방법을 보여줍니다.

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

## **FAQ**

**Aspose.Slides가 최신 댓글에 대한 해결 상태를 지원합니까?**

네. [ModernComment::getStatus](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/getstatus/) 및 [ModernComment::setStatus](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/setstatus/)는 `Resolved`를 포함한 [ModernCommentStatus](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncommentstatus/) 값을 사용합니다. 상태는 프레젠테이션에 저장되며 파일을 다시 연 후에도 읽을 수 있습니다.

**스레드형 토론(회신 체인)이 지원되며 중첩 제한이 있습니까?**

네. 각 댓글은 자신의 [parent comment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/getparentcomment/)를 참조할 수 있어 회신 체인을 만들 수 있습니다. API는 특정 중첩 깊이 제한을 정의하지 않습니다.

**슬라이드에서 댓글 마커 위치는 어떤 좌표계로 정의됩니까?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되어 슬라이드상의 정확한 위치에 배치할 수 있습니다.