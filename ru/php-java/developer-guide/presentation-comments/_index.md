---
title: Управление комментариями презентации в PHP
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/php-java/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии презентации
- комментарии слайда
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
description: "Управляйте комментариями презентации с помощью Aspose.Slides для PHP через Java: добавляйте, читайте, редактируйте, отвечайте и удаляйте комментарии в презентациях PowerPoint быстро и легко."
---
## **Обзор**

Эта статья объясняет, как управлять комментариями презентаций с помощью Aspose.Slides для PHP через Java. Она представляет основные типы, связанные с комментариями, и демонстрирует, как добавлять комментарии на слайды, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как назначение комментариев авторам, чтение текста комментария и его метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. Выбор комментария показывает его текст и связанную дискуссию.

Чтобы запросить отображение или скрытие комментариев при открытии презентации без изменения самих комментариев, см. [Показать или скрыть комментарии при открытии презентации](/slides/ru/php-java/presentation-view-properties/).

## **Зачем добавлять комментарии к презентациям?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при рецензировании презентаций.

Aspose.Slides для PHP через Java предоставляет следующие API для работы с комментариями:

* Класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) предоставляет доступ к авторам комментариев презентации.
* Класс [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) представляет комментарии, связанные с отдельным автором.
* Класс [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) предоставляет информацию о комментарии, включая его автора, время создания, позицию и текст.
* Класс [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) предоставляет информацию об авторе, включая его имя, инициалы и связанные комментарии.

## **Добавить комментарии к слайдам**

Пример создает два слайда и регистрирует автора комментария с помощью [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/). Он использует [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) для размещения одного комментария на каждом слайде, затем получает комментарии первого слайда для этого автора с помощью [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/). Консоль выводит текст первого комментария дважды, демонстрируя доступ как через слайд, так и через автора, а сохранённая презентация содержит оба комментария.

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

## **Найти или создать автора комментария**

Когда автоматический обзор обрабатывает одну и ту же презентацию неоднократно, ищите в коллекции, возвращаемой [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/), перед добавлением автора. [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) сопоставляет как имя, так и инициалы и возвращает массив совпадающих авторов или пустой массив, если совпадений нет. В отличие от этого, [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) ищет только по имени, независимо от инициалов. Вызов [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) с именем и инициалами, уже присутствующими в коллекции, генерирует исключение.

Пример требует файл презентации как минимум с одним слайдом. На каждой из двух итераций он переиспользует первого подходящего автора или создаёт нового только когда результат пуст. Если найдено несколько совпадений, выбирается первый элемент массива без объединения или удаления остальных авторов. Затем вызывается [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) для выбранного автора и сохраняется презентация. На второй итерации открывается вывод первой итерации и операция повторяется.

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

Вторая итерация добавляет ещё один комментарий без создания нового автора и без удаления существующих комментариев. Финальный файл `review_pass_2.pptx` содержит оба новых комментария вместе с любыми оригинальными комментариями. Переиспользование автора не приводит к удалению дубликатов комментариев: чтобы избежать повторного добавления одного и того же комментария, реализуйте отдельную проверку дубликатов перед добавлением.

## **Доступ к комментариям слайдов**

Пример открывает существующую презентацию и читает коллекцию, возвращаемую [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/). Для каждого автора он перебирает коллекцию, возвращаемую [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/), и выводит номер слайда, текст комментария, имя автора и время создания. Исходная презентация должна содержать комментарии, чтобы получить вывод в консоль.

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

## **Ответить на комментарии**

Родительским комментарием считается исходный комментарий в верхушке иерархии ответов. Методы [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) и [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) позволяют получить или установить родительский комментарий.

Пример создаёт комментарии от двух авторов и использует [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) для построения ответов, включая ответ на другой ответ. Передача `null` в [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) получает комментарии от всех авторов; консоль отступает каждую запись в соответствии с её глубиной в иерархии ответов. Пример сохраняет полную дискуссию, вызывает [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) для первого корневого комментария и сохраняет вторую презентацию с удалённым этим комментарием и его ответами.

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
* При использовании метода [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) для удаления комментария удаляются также все ответы на этот комментарий.
* Если [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) создаёт циклическую ссылку, генерируется [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Добавить современные комментарии**

Современные комментарии могут быть связаны непосредственно со слайдом, с определённой фигурой или с диапазоном текста внутри AutoShape. Метод [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) принимает аргумент [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) в дополнение к слайду и координатам маркера комментария.

Когда в качестве аргумента shape передаётся `null`, комментарий считается слайд‑уровневым. Его маркер позиционируется по указанным координатам, но он не привязан к конкретной фигуре, поэтому [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) возвращает `null`. Если передаётся объект [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), комментарий привязывается к этой фигуре. Координаты по‑прежнему определяют позицию маркера на слайде, а привязка к фигуре может быть получена через [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/).

### **Привязать современный комментарий к фигуре**

Пример дважды вызывает [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/): один раз с `null` в качестве фигуры для слайд‑уровневого комментария и один раз с прямоугольником в качестве привязки. Чтение [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) выводит `true` для проверки `null` у слайд‑уровневого комментария и `Revenue title` для привязанного комментария. Оба комментария сохраняются в презентации.

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

### **Привязать комментарии к различным типам фигур**

Любой объект слайда, представленный классом [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), может использоваться в качестве привязки. Распространённые примеры включают [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) и экземпляры [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) такие как диаграммы.

Пример использует [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) для привязки комментария к каждому из пяти типов фигур: AutoShape, рамка изображения, группа, соединитель и диаграмма. Изображение встроено в данные, поэтому внешний файл изображения не требуется. Каждый комментарий имеет свою позицию маркера, а сохранённая презентация сохраняет все пять привязок к фигурам.

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

### **Привязать комментарий к тексту и установить его статус**

Для современного комментария, связанного с [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), методы [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) и [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) возвращают начальную позицию выбранного текста в текстовом блоке фигуры. Методы [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) и [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) возвращают длину выделения. Вместе эти значения связывают комментарий с конкретным диапазоном текста внутри AutoShape.

Методы [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) и [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) работают со значением из перечисления [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — конкретный статус современного комментария не определён.
- `Active` — комментарий активен.
- `Resolved` — комментарий решён.
- `Closed` — комментарий закрыт.

Пример привязывает современный комментарий к словам «quarterly revenue» в тексте прямоугольника. Он вычисляет нулевой индекс начала выбора из текста и передаёт его в [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/), а затем использует [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) для установки количества выбранных символов. После вызова [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) со значением `Resolved` презентация сохраняется и повторно открывается. Четыре проверки в консоли должны вывести `true`, подтверждая, что привязка к фигуре, диапазон текста и статус сохранились.

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

### **Исследовать существующие современные комментарии**

Пример требует существующую презентацию, содержащую современные комментарии, и выводит их текст, статус и детали привязки. Чтобы исследовать их, проверьте, является ли каждый комментарий объектом [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/), затем изучите [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) и [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/). `null` у shape указывает на слайд‑уровневый комментарий. Для привязки к [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) методы выбора текста определяют соответствующий диапазон в текстовом блоке фигуры.

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

## **Удалить комментарии**

Aspose.Slides для PHP через Java позволяет удалить все комментарии и их авторов из презентации или удалить выбранные комментарии, сохранив остальные. Ниже представлены примеры обоих подходов с последующим сохранением обновлённой презентации.

### **Удалить все комментарии и их авторов**

Пример открывает существующую презентацию и вызывает [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) для каждого автора, затем вызывает [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) для удаления самих авторов. Сохранённая презентация не содержит ни комментариев, ни их авторов. Используйте презентацию с комментариями, чтобы увидеть эффект удаления.

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

### **Удалить конкретные комментарии**

Пример создаёт два комментария на одном слайде и использует [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) для поиска комментариев каждого автора. Он собирает комментарии, текст которых равен «comment 1», перед вызовом [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/), чтобы избежать изменения коллекции во время выбора. Сохранённая презентация остаётся только с «comment 2».

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

**Поддерживает ли Aspose.Slides статус resolved для современных комментариев?**

Да. [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) и [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) работают со значением из [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/), включая `Resolved`. Статус сохраняется в презентации и может быть прочитан после повторного открытия файла.

**Поддерживаются ли ветвленные обсуждения (цепочки ответов) и есть ли ограничение вложенности?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), позволяя создавать цепочки ответов. API не задаёт конкретного ограничения глубины вложения.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция маркера задаётся координатами с плавающей точкой в системе координат слайда, что позволяет разместить его точно на слайде.