---
title: Zarządzanie komentarzami prezentacji w PHP
linktitle: Komentarze prezentacji
type: docs
weight: 100
url: /pl/php-java/presentation-comments/
keywords:
- komentarz
- nowoczesny komentarz
- komentarze PowerPoint
- komentarze prezentacji
- komentarze slajdów
- dodaj komentarz
- dostęp do komentarza
- edytuj komentarz
- odpowiedź na komentarz
- usuń komentarz
- kasuj komentarz
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj komentarzami prezentacji przy użyciu Aspose.Slides for PHP via Java: dodawaj, odczytuj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy użyciu Aspose.Slides for PHP via Java. Wprowadza główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w programie PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu komentarza i metadanych, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W programie PowerPoint komentarze pojawiają się jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst oraz powiązaną dyskusję.

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz używać komentarzy, aby przekazywać uwagi i współpracować z współpracownikami podczas przeglądania prezentacji.

Aspose.Slides for PHP via Java udostępnia następujące interfejsy API do pracy z komentarzami:

* Klasa [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) zapewnia dostęp do autorów komentarzy prezentacji.
* Klasa [CommentCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commentcollection/) reprezentuje komentarze powiązane z poszczególnym autorem.
* Klasa [Comment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/) dostarcza informacje o komentarzu, w tym jego autora, czas utworzenia, pozycję oraz tekst.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commentauthor/) dostarcza informacje o autorze, w tym jego imię i nazwisko, inicjały oraz powiązane komentarze.

## **Dodawanie komentarzy do slajdów**

Poniższy przykład pokazuje, jak dodać komentarze do slajdów w prezentacji PowerPoint:

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

## **Dostęp do komentarzy slajdów**

Poniższy przykład pokazuje, jak uzyskać dostęp do istniejących komentarzy w prezentacji PowerPoint:

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

## **Odpowiadanie na komentarze**

Komentarz nadrzędny to oryginalny komentarz znajdujący się u góry hierarchii odpowiedzi. Metody [Comment::getParentComment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/getparentcomment/) i [Comment::setParentComment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/setparentcomment/) umożliwiają odczyt lub ustawienie komentarza nadrzędnego.

Poniższy przykład pokazuje, jak dodać odpowiedzi i zbadać wynikową hierarchię komentarzy:

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
* Gdy metoda [Comment::remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/remove/) jest używana do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz również zostają usunięte.
* Jeśli [Comment::setParentComment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/setparentcomment/) tworzy odniesienie cykliczne, zostaje rzucony wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane z samym slajdem, konkretnym kształtem lub zakresem tekstu wewnątrz AutoShape. Metoda [CommentCollection::addModernComment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commentcollection/addmoderncomment/) przyjmuje argument typu [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) oprócz współrzędnych slajdu i markera komentarza.

Gdy jako argument shape przekazywany jest `null`, komentarz jest komentarzem na poziomie slajdu. Jego marker jest pozycjonowany według podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [ModernComment::getShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/getshape/) zwraca `null`. Gdy podany jest obiekt [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/), komentarz jest przypięty do tego kształtu. Współrzędne nadal określają pozycję markera komentarza na slajdzie, a powiązanie z kształtem można pobrać za pomocą [ModernComment::getShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/getshape/).

### **Przypięcie nowoczesnego komentarza do kształtu**

Poniższy przykład tworzy zarówno nowoczesny komentarz na poziomie slajdu, jak i nowoczesny komentarz przypięty do konkretnego AutoShape. Następnie odczytuje powiązany kształt z każdego komentarza.

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

### **Przypinanie komentarzy do różnych typów kształtów**

Każdy obiekt slajdu reprezentowany przez klasę [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) może być użyty jako kotwica kształtu. Przykłady typowych obiektów to [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/pl/php-java/aspose.slides/connector/) oraz wersje [GraphicalObject](https://reference.aspose.com/slides/pl/php-java/aspose.slides/graphicalobject/) takie jak wykresy.

Poniższy przykład tworzy kilka powszechnych typów kształtów i powiązuje z każdym z nich nowoczesny komentarz.

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

### **Przypięcie komentarza do tekstu i ustawienie jego statusu**

Dla nowoczesnego komentarza powiązanego z [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/), metody [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/gettextselectionstart/) i [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/settextselectionstart/) zwracają początkową pozycję wybranego tekstu w ramce tekstowej kształtu. Metody [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/gettextselectionlength/) i [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/settextselectionlength/) zwracają długość zaznaczenia. Razem te wartości wiążą komentarz z określonym zakresem tekstu wewnątrz AutoShape.

Metody [ModernComment::getStatus](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/getstatus/) i [ModernComment::setStatus](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/setstatus/) odczytują wartość z stałych [ModernCommentStatus](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — nie określono konkretnego statusu nowoczesnego komentarza.
- `Active` — komentarz jest aktywny.
- `Resolved` — komentarz został rozwiązany.
- `Closed` — komentarz jest zamknięty.

Poniższy przykład tworzy nowoczesny komentarz przypięty do kształtu, powiązuje go z zaznaczeniem tekstu, oznacza jako rozwiązany, zapisuje prezentację i weryfikuje wartości po ponownym otwarciu pliku.

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

### **Sprawdzanie istniejących nowoczesnych komentarzy**

Aby sprawdzić istniejącą prezentację, sprawdź, czy każdy komentarz jest typu [ModernComment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/), a następnie zbadaj [ModernComment::getShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/gettextselectionlength/) oraz [ModernComment::getStatus](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/getstatus/). Kształt `null` oznacza komentarz na poziomie slajdu. Dla kotwicy typu [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) metody wyboru tekstu identyfikują powiązany zakres w ramce tekstowej kształtu.

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

## **Usuwanie komentarzy**

### **Usuwanie wszystkich komentarzy i autorów komentarzy**

Poniższy przykład pokazuje, jak usunąć wszystkie komentarze i autorów komentarzy z prezentacji:

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

### **Usuwanie konkretnych komentarzy**

Poniższy przykład pokazuje, jak usunąć wybrane komentarze ze slajdu:

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

**Czy Aspose.Slides obsługuje status rozwiązany dla nowoczesnych komentarzy?**

Tak. Metody [ModernComment::getStatus](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/getstatus/) i [ModernComment::setStatus](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncomment/setstatus/) odczytują wartość z [ModernCommentStatus](https://reference.aspose.com/slides/pl/php-java/aspose.slides/moderncommentstatus/), w tym `Resolved`. Status jest przechowywany w prezentacji i może być odczytany ponownie po ponownym otwarciu pliku.

**Czy obsługiwane są dyskusje wątkowane (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżania?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/pl/php-java/aspose.slides/comment/getparentcomment/), co umożliwia tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdżenia.

**W jakim systemie współrzędnych definiowana jest pozycja markera komentarza na slajdzie?**

Pozycja markera jest definiowana za pomocą współrzędnych zmiennoprzecinkowych w systemie współrzędnych slajdu, co pozwala precyzyjnie umieścić go na slajdzie.