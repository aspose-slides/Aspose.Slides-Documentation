---
title: 댓글
type: docs
weight: 230
url: /ko/php-java/examples/elements/comment/
keywords:
- 댓글
- 최신 댓글
- 댓글 추가
- 댓글 접근
- 댓글 제거
- 댓글 회신
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 슬라이드 댓글을 관리합니다: 추가, 읽기, 회신, 편집, 삭제 및 PowerPoint와 OpenDocument용 스레드형 댓글 작업을 수행합니다."
---
**Aspose.Slides for PHP via Java**를 사용하여 최신 댓글을 추가, 읽기, 제거 및 회신하는 방법을 보여줍니다.

## **현대 댓글 추가**

사용자가 작성한 댓글을 생성하고 프레젠테이션을 저장합니다.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 현대 댓글을 추가합니다.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **현대 댓글 접근**

기존 프레젠테이션에서 현대 댓글을 읽습니다.

```php
function accessModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);
        echo "Author: " . $author->getName() . ", Comment: " . $comment->getText() . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
}
```

## **현대 댓글 제거**

댓글을 제거하고 업데이트된 파일을 저장합니다.

```php
function removeModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);

        $comment->remove();

        $presentation->save("modern_comment_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **현대 댓글에 회신**

상위 현대 댓글에 회신을 추가합니다.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 댓글 작성자를 추가합니다.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // 상위 댓글과 회신을 추가합니다.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // 회신에 대한 상위 댓글을 설정합니다.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // 회신이 포함된 프레젠테이션을 저장합니다.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```