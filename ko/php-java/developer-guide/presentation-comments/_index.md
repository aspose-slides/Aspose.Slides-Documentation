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
- 댓글 답글
- 댓글 제거
- 댓글 삭제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java로 프레젠테이션 댓글을 마스터하고, PowerPoint 파일에서 댓글을 빠르고 쉽게 추가, 읽기, 편집 및 삭제합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 타입을 소개하고 슬라이드에 댓글을 추가하고, 기존 댓글에 접근하고, 답글을 다루며, 최신 댓글을 사용하고, 프레젠테이션에서 댓글을 제거하는 방법을 보여줍니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오에 중점을 둡니다. 예를 들어 저자에게 댓글을 할당하고, 댓글 내용 및 메타데이터를 읽고, 답글 체인을 구성하고, 모든 댓글을 제거하거나 선택된 댓글만 삭제하는 방법을 다룹니다.

PowerPoint에서 댓글은 슬라이드에 표시되는 메모 또는 주석 형태로 나타납니다. 댓글을 클릭하면 내용이나 메시지가 표시됩니다. 

## **프레젠테이션에 댓글을 추가해야 하는 이유**

프레젠테이션을 검토할 때 피드백을 제공하거나 동료와 소통하기 위해 댓글을 사용할 수 있습니다.

PowerPoint 프레젠테이션에서 댓글을 사용할 수 있도록 Aspose.Slides for PHP via Java는 다음을 제공합니다.

* [Presentation 클래스](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) – [CommentAuthorCollection 클래스](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commentauthorcollection/)에서 제공되는 저자 컬렉션을 포함합니다. 저자는 슬라이드에 댓글을 추가합니다.
* [CommentCollection 클래스](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commentcollection/) – 개별 저자에 대한 댓글 컬렉션을 포함합니다.
* [Comment 클래스](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/) – 저자와 댓글에 대한 정보(누가 댓글을 추가했는지, 댓글이 추가된 시간, 댓글 위치 등)를 포함합니다.
* [CommentAuthor 클래스](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commentauthor/) – 개별 저자에 대한 정보(저자 이름, 약자, 해당 저자와 연결된 댓글 등)를 포함합니다.

## **슬라이드 댓글 추가**
다음 PHP 코드는 PowerPoint 프레젠테이션의 슬라이드에 댓글을 추가하는 방법을 보여줍니다:

```php
  # Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 빈 슬라이드를 추가합니다
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # 저자를 추가합니다
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # 댓글 위치를 설정합니다
    $point = new Point2DFloat(0.2, 0.2);
    # 슬라이드 1에 저자를 위한 슬라이드 댓글을 추가합니다
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # 슬라이드 2에 저자를 위한 슬라이드 댓글을 추가합니다
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # ISlide 1에 접근합니다
    $slide = $pres->getSlides()->get_Item(0);
    # 인수가 null이면 모든 저자의 댓글이 선택된 슬라이드로 가져와집니다
    $Comments = $slide->getSlideComments($author);
    # 슬라이드 1의 인덱스 0에 있는 댓글에 접근합니다
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # 인덱스 0에 있는 저자의 댓글 컬렉션을 선택합니다
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **슬라이드 댓글 접근**
다음 PHP 코드는 PowerPoint 프레젠테이션의 슬라이드에 존재하는 댓글에 접근하는 방법을 보여줍니다:

```php
  # Presentation 클래스를 인스턴스화합니다
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

## **댓글 답글**
상위 댓글은 댓글 또는 답글 계층 구조에서 최상위(원본) 댓글을 의미합니다. [Comment 클래스](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/)의 [getParentComment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/getparentcomment/) 또는 [setParentComment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/setparentcomment/) 메서드를 사용하여 상위 댓글을 설정하거나 가져올 수 있습니다.

다음 PHP 코드는 댓글을 추가하고 해당 댓글에 대한 답글을 가져오는 방법을 보여줍니다:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 댓글을 추가합니다
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # comment1에 대한 답글을 추가합니다
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # comment1에 또 다른 답글을 추가합니다
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # 기존 답글에 대한 답글을 추가합니다
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # 콘솔에 댓글 계층 구조를 표시합니다
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
    # comment1 및 해당 답글을 모두 삭제합니다
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="주의" %}} 

* [Comment 클래스](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/)의 [remove](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/remove/) 메서드로 댓글을 삭제하면 해당 댓글에 대한 답글도 함께 삭제됩니다.
* [setParentComment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/setparentcomment/) 설정으로 인해 순환 참조가 발생하면 [PptxEditException](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pptxeditexception/)이 발생합니다.

{{% /alert %}}

## **최신 댓글 추가**

2021년에 Microsoft는 PowerPoint에 *최신 댓글*을 도입했습니다. 최신 댓글 기능은 PowerPoint 협업을 크게 개선합니다. 최신 댓글을 통해 사용자는 댓글을 해결하고, 객체 및 텍스트에 댓글을 고정하며, 이전보다 훨씬 쉽게 상호 작용할 수 있습니다.

Aspose Slides는 [ModernComment 클래스](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/)를 통해 최신 댓글을 지원합니다. [CommentCollection 클래스](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commentcollection/)에 [addModernComment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commentcollection/addmoderncomment/) 및 [insertModernComment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/commentcollection/insertmoderncomment/) 메서드가 추가되었습니다.

다음 PHP 코드는 PowerPoint 프레젠테이션의 슬라이드에 최신 댓글을 추가하는 방법을 보여줍니다:

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

## **댓글 삭제**

### **모든 댓글 및 저자 삭제**

다음 PHP 코드는 프레젠테이션에서 모든 댓글 및 저자를 제거하는 방법을 보여줍니다:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # 프레젠테이션의 모든 댓글을 삭제합니다
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # 모든 저자를 삭제합니다
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **특정 댓글 삭제**

다음 PHP 코드는 슬라이드에서 특정 댓글을 삭제하는 방법을 보여줍니다:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 댓글을 추가합니다...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # \"comment 1\" 텍스트를 포함하는 모든 댓글을 제거합니다
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

## **FAQ**

**최신 댓글에 '해결됨'과 같은 상태를 지원합니까?**

예. [Modern comments](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/)는 [setStatus](https://reference.aspose.com/slides/ko/php-java/aspose.slides/moderncomment/setstatus/) 메서드를 제공하므로 댓글의 상태(예: 해결됨으로 표시)를 지정할 수 있으며, 이 상태는 파일에 저장되고 PowerPoint에서 인식됩니다.

**스레드형 토론(답글 체인)이 지원되며, 중첩 제한이 있습니까?**

예. 각 댓글은 자신의 [parent comment](https://reference.aspose.com/slides/ko/php-java/aspose.slides/comment/getparentcomment/)를 참조할 수 있어 임의 깊이의 답글 체인을 만들 수 있습니다. API에서는 특정 중첩 깊이 제한을 명시하지 않습니다.

**슬라이드에서 댓글 마커 위치는 어떤 좌표계로 정의됩니까?**

위치는 슬라이드 좌표계의 부동소수점 좌표로 저장됩니다. 이를 통해 원하는 정확한 위치에 댓글 마커를 배치할 수 있습니다.