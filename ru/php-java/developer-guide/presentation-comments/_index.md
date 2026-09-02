---
title: Управление комментариями презентаций в PHP
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/php-java/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии к презентации
- комментарии к слайдам
- добавить комментарий
- доступ к комментариям
- редактировать комментарий
- ответить на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Управляйте комментариями презентаций с помощью Aspose.Slides for PHP via Java: добавляйте, читайте, редактируйте, отвечайте и удаляйте комментарии в презентациях PowerPoint быстро и легко."
---
## **Обзор**

В этой статье объясняется, как управлять комментариями презентаций с помощью Aspose.Slides for PHP via Java. Представлены основные типы, связанные с комментариями, и показано, как добавлять комментарии на слайды, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как назначение комментариев авторам, чтение текста комментария и метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. Выбор комментария показывает его текст и связанную дискуссию.

## **Зачем добавлять комментарии в презентации?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при просмотре презентаций.

Aspose.Slides for PHP via Java предоставляет следующие API для работы с комментариями:

* Класс [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), который предоставляет доступ к авторам комментариев презентации.
* Класс [CommentCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/commentcollection/), представляющий комментарии, связанные с отдельным автором.
* Класс [Comment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/comment/), который предоставляет информацию о комментарии, включая автора, время создания, позицию и текст.
* Класс [CommentAuthor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/commentauthor/), который предоставляет информацию об авторе, включая его имя, инициалы и связанные комментарии.

## **Добавление комментариев к слайдам**

Следующий пример показывает, как добавить комментарии к слайдам в презентации PowerPoint:

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

## **Получение комментариев со слайдов**

Следующий пример показывает, как получить доступ к существующим комментариям в презентации PowerPoint:

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

## **Ответы на комментарии**

Родительским комментариев считается оригинальный комментарий в вершине иерархии ответов. Методы [Comment::getParentComment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/comment/getparentcomment/) и [Comment::setParentComment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/comment/setparentcomment/) позволяют получить или задать родительский комментарий.

Следующий пример показывает, как добавить ответы и проверить получившуюся иерархию комментариев:

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
* При использовании метода [Comment::remove](https://reference.aspose.com/slides/ru/php-java/aspose.slides/comment/remove/) для удаления комментария также удаляются все ответы на этот комментарий.
* Если [Comment::setParentComment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/comment/setparentcomment/) создает круговую ссылку, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Добавление современных комментариев**

Современные комментарии могут быть связаны непосредственно со слайдом, с конкретной фигурой или с диапазоном текста внутри AutoShape. Метод [CommentCollection::addModernComment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/commentcollection/addmoderncomment/) принимает аргумент [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) в дополнение к слайду и координатам маркера комментария.

Когда в качестве аргумента shape передаётся `null`, комментарий является комментарем уровня слайда. Его маркер позиционируется по указанным координатам, но не привязан к конкретной фигуре, поэтому [ModernComment::getShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/getshape/) возвращает `null`. Если передаётся объект [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/), комментарий привязывается к этой фигуре. Координаты по‑прежнему определяют позицию маркера комментария на слайде, а ассоциацию с фигурой можно получить через [ModernComment::getShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/getshape/).

### **Привязка современного комментария к фигуре**

Следующий пример создаёт как комментарий уровня слайда, так и современный комментарий, привязанный к конкретному AutoShape. Затем он считывает связанную фигуру из каждого комментария.

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

### **Привязка комментариев к различным типам фигур**

Любой объект слайда, представленный классом [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/), может быть использован в качестве привязки. Распространённые примеры включают [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/ru/php-java/aspose.slides/connector/) и экземпляры [GraphicalObject](https://reference.aspose.com/slides/ru/php-java/aspose.slides/graphicalobject/) такие как диаграммы.

Следующий пример создаёт несколько распространённых типов фигур и связывает с каждой современный комментарий.

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

### **Привязка комментария к тексту и установка его статуса**

Для современного комментария, связанного с [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/), методы [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/gettextselectionstart/) и [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/settextselectionstart/) позволяют получить начальную позицию выбранного текста во фрейме текста фигуры. Методы [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/gettextselectionlength/) и [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/settextselectionlength/) задают длину выбора. Вместе эти значения связывают комментарий с определённым диапазоном текста внутри AutoShape.

Методы [ModernComment::getStatus](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/getstatus/) и [ModernComment::setStatus](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/setstatus/) работают со значением из констант [ModernCommentStatus](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — конкретный статус современного комментария не определён.
- `Active` — комментарий активен.
- `Resolved` — комментарий разрешён.
- `Closed` — комментарий закрыт.

Следующий пример создаёт современный комментарий, привязанный к фигуре, связывает его с выделением текста, помечает как разрешённый, сохраняет презентацию и проверяет значения после повторного открытия файла.

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

### **Просмотр существующих современных комментариев**

Чтобы проанализировать существующую презентацию, проверьте, является ли каждый комментарий объектом [ModernComment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/), затем изучите [ModernComment::getShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/gettextselectionlength/) и [ModernComment::getStatus](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/getstatus/). `null` в качестве фигуры указывает на комментарий уровня слайда. Для привязки к [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) методы выбора текста определяют соответствующий диапазон во фрейме текста фигуры.

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

## **Удаление комментариев**

### **Удаление всех комментариев и их авторов**

Следующий пример показывает, как удалить все комментарии и их авторов из презентации:

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

### **Удаление конкретных комментариев**

Следующий пример показывает, как удалить выбранные комментарии со слайда:

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

## **Вопросы и ответы**

**Поддерживает ли Aspose.Slides статус «разрешён» для современных комментариев?**

Да. Методы [ModernComment::getStatus](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/getstatus/) и [ModernComment::setStatus](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncomment/setstatus/) работают со значением [ModernCommentStatus](https://reference.aspose.com/slides/ru/php-java/aspose.slides/moderncommentstatus/), включая `Resolved`. Статус сохраняется в презентации и может быть считан после повторного открытия файла.

**Поддерживаются ли дискуссии в виде цепочек ответов, и есть ли ограничение на уровень вложенности?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/comment/getparentcomment/), позволяя создавать цепочки ответов. API не определяет конкретного ограничения глубины вложенности.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция маркера задаётся координатами с плавающей запятой в системе координат слайда, что позволяет точно разместить его на слайде.