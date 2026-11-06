---
title: PHP에서 프레젠테이션 주석 관리
linktitle: 프레젠테이션 주석
type: docs
weight: 100
url: /ko/php-java/presentation-comments/
keywords:
- 주석
- 현대 주석
- PowerPoint 주석
- 프레젠테이션 주석
- 슬라이드 주석
- 주석 추가
- 주석 접근
- 주석 편집
- 주석 답글
- 주석 제거
- 주석 삭제
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 프레젠테이션 주석을 관리합니다: PowerPoint 프레젠테이션에서 주석을 빠르고 쉽게 추가, 읽기, 편집, 답글 달기 및 제거합니다."
---
## **개요**

이 문서는 Aspose.Slides for PHP via Java를 사용하여 프레젠테이션 주석을 관리하는 방법을 설명합니다. 주요 주석 관련 유형을 소개하고 슬라이드에 주석을 추가하고, 기존 주석에 접근하고, 답글 및 최신 주석을 다루며, 프레젠테이션에서 주석을 제거하는 방법을 보여줍니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오를 다룹니다. 예를 들어 주석을 작성자에게 할당하고, 주석 텍스트와 메타데이터를 읽고, 답글 체인을 구성하고, 선택한 주석이나 모든 주석을 제거하는 작업을 포함합니다.

PowerPoint에서 주석은 슬라이드에 표시되는 주석 형태로 나타납니다. 주석을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

프레젠테이션을 열 때 주석을 표시하거나 숨기려면, 주석 자체를 변경하지 않은 상태에서 [프레젠테이션 열 때 주석 보이기/숨기기](/slides/ko/php-java/presentation-view-properties/)를 참조하십시오.

## **왜 프레젠테이션에 주석을 추가해야 하나요?**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하기 위해 주석을 사용할 수 있습니다.

Aspose.Slides for PHP via Java는 주석 작업을 위한 다음 API를 제공합니다:

* [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스 – 프레젠테이션의 주석 작성자에 대한 액세스를 제공합니다.
* [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) 클래스 – 개별 작성자와 연결된 주석을 나타냅니다.
* [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) 클래스 – 작성자, 생성 시간, 위치 및 텍스트를 포함한 주석 정보를 제공합니다.
* [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) 클래스 – 이름, 이니셜 및 연결된 주석을 포함한 작성자 정보를 제공합니다.

## **슬라이드 주석 추가**

예제는 두 개의 슬라이드를 만들고 [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) 로 주석 작성자를 등록합니다. 그런 다음 [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) 을 사용해 각 슬라이드에 하나씩 주석을 배치하고, [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) 로 해당 작성자의 첫 번째 슬라이드 주석을 가져옵니다. 콘솔은 첫 번째 주석 텍스트를 두 번 표시하여 슬라이드와 작성자를 통해 모두 접근할 수 있음을 보여 주며, 저장된 프레젠테이션에는 두 주석이 모두 포함됩니다.

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

## **주석 작성자 찾기 또는 만들기**

자동 검토가 동일한 프레젠테이션을 반복해서 처리할 때는 [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) 로 반환된 컬렉션을 검색한 후에 작성자를 추가합니다. [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) 은 이름과 이니셜을 모두 일치시켜 일치하는 작성자 배열을 반환하며, 일치 항목이 없으면 빈 배열을 반환합니다. 반면에 [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) 은 이니셜에 관계없이 이름만으로 검색합니다. 컬렉션에 이미 존재하는 이름과 이니셜으로 [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) 를 호출하면 예외가 발생합니다.

예제는 최소 하나의 슬라이드가 포함된 프레젠테이션 파일이 필요합니다. 두 번의 반복 중 각각 첫 번째 일치하는 작성자를 재사용하거나, 결과가 비어 있을 때만 새로 만듭니다. 일치 항목이 여러 개이면 첫 번째 배열 요소를 선택하고 다른 작성자를 병합하거나 제거하지 않습니다. 그런 다음 선택된 작성자에 대해 [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) 를 호출하고 프레젠테이션을 저장합니다. 두 번째 반복에서는 첫 번째 반복의 출력 파일을 열어 동일한 작업을 다시 수행합니다.

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

두 번째 반복에서는 새로운 주석을 추가하지만 추가 작성자를 만들거나 기존 주석을 제거하지 않습니다. 최종 파일 `review_pass_2.pptx` 에는 원본 주석과 함께 두 개의 새로운 주석이 모두 포함됩니다. 작성자를 재사용한다 하더라도 주석이 중복 삭제되지 않으며, 동일한 주석이 반복해서 추가되는 것을 방지하려면 추가하기 전에 별도의 중복 검사를 구현해야 합니다.

## **슬라이드 주석 접근**

예제는 기존 프레젠테이션을 열고 [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) 로 반환된 컬렉션을 읽습니다. 각 작성자에 대해 [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) 로 반환된 컬렉션을 순회하면서 슬라이드 번호, 주석 텍스트, 작성자 이름 및 생성 시간을 출력합니다. 콘솔 출력이 나타나려면 입력 프레젠테이션에 주석이 포함되어 있어야 합니다.

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

## **주석에 답글 달기**

부모 주석은 답글 계층 구조의 최상위에 있는 원본 주석을 의미합니다. [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) 와 [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) 메서드를 사용해 주석의 부모를 가져오거나 설정할 수 있습니다.

예제는 두 명의 작성자로부터 주석을 만든 다음 [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) 로 답글을 구성합니다. 여기에는 다른 답글에 대한 답글도 포함됩니다. `null` 을 [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) 에 전달하면 모든 작성자의 주석을 가져옵니다. 콘솔은 답글 계층 깊이에 따라 각 항목을 들여쓰기합니다. 예제는 전체 토론을 저장하고 첫 번째 루트 주석에 대해 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) 를 호출한 뒤 해당 주석과 그 답글이 제거된 두 번째 프레젠테이션을 저장합니다.

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
* [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) 메서드를 사용해 주석을 삭제하면 해당 주석에 대한 모든 답글도 함께 삭제됩니다.
* [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) 가 순환 참조를 만들면 [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/) 이 발생합니다.
{{% /alert %}}

## **현대 주석 추가**

현대 주석은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위에 연결될 수 있습니다. [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) 메서드는 슬라이드와 주석 마커 좌표 외에 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 인수를 추가로 받습니다.

`null` 을 shape 인수로 전달하면 주석은 슬라이드 수준 주석이 됩니다. 마커는 제공된 좌표에 배치되지만 특정 도형과 연결되지 않으므로 [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) 은 `null` 을 반환합니다. [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 가 제공되면 주석은 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 주석 마커 위치를 정의하고, 도형 연결은 [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) 를 통해 확인할 수 있습니다.

### **도형에 현대 주석 고정**

예제는 [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) 를 두 번 호출합니다. 첫 번째는 `null` shape 로 슬라이드 수준 주석을 만들고, 두 번째는 사각형을 고정점으로 사용합니다. [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) 를 읽어 슬라이드 수준 주석의 `null` 검사에서는 `true` 가 출력되고, 고정된 주석에서는 `Revenue title` 이 출력됩니다. 두 주석 모두 프레젠테이션에 저장됩니다.

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

### **다양한 도형 유형에 주석 고정**

[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 클래스로 표현되는 모든 슬라이드 객체를 도형 고정점으로 사용할 수 있습니다. 일반적인 예로 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/), 그리고 차트와 같은 [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) 인스턴스가 있습니다.

예제는 [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) 를 사용해 다섯 가지 도형 유형(자동 도형, 그림 프레임, 그룹, 연결선, 차트) 각각에 주석을 연결합니다. 그림은 임베디드 이미지 데이터를 사용하므로 외부 이미지가 필요하지 않습니다. 각 주석은 자체 마커 위치를 갖고, 저장된 프레젠테이션은 모든 다섯 도형 연결을 유지합니다.

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

### **텍스트에 주석 고정 및 상태 설정**

[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 에 연결된 현대 주석의 경우, [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) 와 [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) 은 도형 텍스트 프레임 내 선택된 텍스트 시작 위치에 접근합니다. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) 와 [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) 은 선택 길이에 접근합니다. 이 값들을 함께 사용하면 자동 도형 내부의 특정 텍스트 범위에 주석을 연결할 수 있습니다.

[ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) 와 [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) 상수 중 하나의 값을 가져오고 설정합니다:

- `NotDefined` — 특정 현대 주석 상태가 정의되지 않음.
- `Active` — 주석이 활성 상태임.
- `Resolved` — 주석이 해결됨.
- `Closed` — 주석이 닫힘.

예제는 사각형 텍스트 내 “quarterly revenue” 라는 단어에 현대 주석을 고정합니다. 텍스트에서 0 기반 선택 시작 위치를 계산해 [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) 에 전달하고, [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) 로 선택 문자 수를 설정합니다. 그런 다음 `Resolved` 로 [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) 를 호출하고 프레젠테이션을 저장·재개방합니다. 네 개의 콘솔 검사는 각각 `true` 를 출력하여 도형 고정, 텍스트 범위 및 상태가 보존되었음을 확인합니다.

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

### **기존 현대 주석 검사**

예제는 현대 주석이 포함된 기존 프레젠테이션을 요구하고, 각 주석의 텍스트, 상태 및 고정 상세 정보를 출력합니다. 검사를 위해 각 주석이 [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) 인지 확인한 뒤, [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/), [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) 를 조사합니다. `null` shape 은 슬라이드 수준 주석임을 나타냅니다. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 고정점의 경우 텍스트 선택 메서드가 도형 텍스트 프레임 내 연관 범위를 식별합니다.

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

## **주석 제거**

Aspose.Slides for PHP via Java는 프레젠테이션에서 모든 주석과 작성자를 제거하거나 선택된 주석만 삭제하고 나머지는 유지할 수 있습니다. 다음 예제는 두 접근 방식을 보여주며 업데이트된 프레젠테이션을 저장합니다.

### **모든 주석 및 주석 작성자 제거**

예제는 기존 프레젠테이션을 열고 각 작성자에 대해 [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) 를 호출한 뒤, [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) 로 작성자 자체를 제거합니다. 저장된 프레젠테이션에는 주석도 작성자도 포함되지 않습니다. 제거 효과를 확인하려면 주석이 포함된 프레젠테이션을 사용하십시오.

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

### **특정 주석 제거**

예제는 한 슬라이드에 두 개의 주석을 만든 뒤 [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) 로 각 작성자의 주석을 찾습니다. 텍스트가 “comment 1” 인 주석을 수집한 후 [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/) 를 호출해 컬렉션 변경을 방지합니다. 저장된 프레젠테이션에는 “comment 2” 만 남습니다.

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

**Aspose.Slides가 현대 주석에 대한 해결 상태를 지원하나요?**

예. [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) 와 [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) 는 `Resolved` 를 포함한 [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) 값을 접근합니다. 상태는 프레젠테이션에 저장되며 파일을 다시 열었을 때 다시 읽을 수 있습니다.

**스레드형 토론(답글 체인)이 지원되나요? 중첩 제한이 있나요?**

예. 각 주석은 [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) 를 참조할 수 있어 답글 체인을 만들 수 있습니다. API 에는 특정 중첩 깊이 제한이 정의되어 있지 않습니다.

**주석 마커 위치는 슬라이드에서 어떤 좌표계로 정의되나요?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되며, 이를 통해 슬라이드 상의 정확한 위치에 마커를 배치할 수 있습니다.