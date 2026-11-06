---
title: Zarządzanie komentarzami w prezentacji w PHP
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
- pobierz komentarz
- edytuj komentarz
- odpowiedz na komentarz
- usuń komentarz
- kasuj komentarz
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj komentarzami w prezentacji przy użyciu Aspose.Slides for PHP via Java: dodawaj, odczytuj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy użyciu Aspose.Slides for PHP via Java. Przedstawia główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu komentarza i metadanych, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W PowerPoint komentarze pojawiają się jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst oraz powiązaną dyskusję.

Aby żądać, aby komentarze były wyświetlane lub ukrywane podczas otwierania prezentacji bez zmiany samych komentarzy, zobacz [Pokaż lub ukryj komentarze podczas otwierania prezentacji](/slides/pl/php-java/presentation-view-properties/).

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz używać komentarzy, aby przekazywać opinie i współpracować z kolegami podczas przeglądania prezentacji.

Aspose.Slides for PHP via Java udostępnia następujące API do pracy z komentarzami:

* Klasa [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), która zapewnia dostęp do autorów komentarzy w prezentacji.
* Klasa [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/), która reprezentuje komentarze powiązane z konkretnym autorem.
* Klasa [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/), która dostarcza informacji o komentarzu, w tym jego autora, czas utworzenia, pozycję i tekst.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/), która dostarcza informacji o autorze, w tym jego imię, inicjały i powiązane komentarze.

## **Dodaj komentarze do slajdu**

Przykład tworzy dwa slajdy i rejestruje autora komentarzy za pomocą [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/). Używa [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/), aby umieścić po jednym komentarzu na każdym slajdzie, a następnie pobiera komentarze pierwszego slajdu dla tego autora za pomocą [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/). Konsola wyświetla tekst pierwszego komentarza dwa razy, demonstrując dostęp zarówno przez slajd, jak i autora, a zapisana prezentacja zawiera oba komentarze.

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

## **Znajdź lub utwórz autora komentarza**

Gdy automatyczna recenzja przetwarza tę samą prezentację wielokrotnie, przed dodaniem autora przeszukaj kolekcję zwróconą przez [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/). [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) dopasowuje zarówno nazwę, jak i inicjały i zwraca tablicę pasujących autorów lub pustą tablicę, jeśli nie ma dopasowań. Natomiast [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) wyszukuje tylko po nazwie, niezależnie od inicjałów. Wywołanie [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) z nazwą i inicjałami już istniejącymi w kolekcji powoduje wyrzucenie wyjątku.

Przykład wymaga pliku prezentacji z co najmniej jednym slajdem. W każdej z dwóch iteracji ponownie wykorzystuje pierwszego pasującego autora albo tworzy nowego tylko wtedy, gdy wynik jest pusty. Jeśli istnieje wiele dopasowań, wybiera pierwszy element tablicy bez łączenia lub usuwania pozostałych autorów. Następnie wywołuje [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) dla wybranego autora i zapisuje prezentację. Druga iteracja otwiera wynik pierwszej i powtarza operację.

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

Druga iteracja dodaje kolejny komentarz bez dodawania nowego autora ani usuwania istniejących komentarzy. Końcowy plik, `review_pass_2.pptx`, zawiera oba nowe komentarze wraz z ewentualnymi oryginalnymi komentarzami. Ponowne użycie autora nie eliminuje duplikatów komentarzy: aby uniknąć wielokrotnego dodawania tego samego komentarza, zaimplementuj oddzielne wykrywanie duplikatów przed jego dodaniem.

## **Uzyskaj dostęp do komentarzy slajdu**

Przykład otwiera istniejącą prezentację i odczytuje kolekcję zwróconą przez [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/). Dla każdego autora iteruje po kolekcji zwróconej przez [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) i wypisuje numer slajdu, tekst komentarza, nazwę autora oraz czas utworzenia. Wejściowa prezentacja musi zawierać komentarze, aby wyświetlić wynik w konsoli.

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

Komentarz nadrzędny to oryginalny komentarz na szczycie hierarchii odpowiedzi. Metody [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) i [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) umożliwiają pobranie lub ustawienie nadrzędnego komentarza.

Przykład tworzy komentarze od dwóch autorów i używa [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/), aby budować odpowiedzi, w tym odpowiedź na inną odpowiedź. Przekazanie `null` do [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) pobiera komentarze od wszystkich autorów; konsola wcięciem oznacza każdy wpis zgodnie z jego głębokością w hierarchii odpowiedzi. Przykład zapisuje pełną dyskusję, wywołuje [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) dla pierwszego komentarza głównego i zapisuje drugą prezentację, w której ten komentarz i jego odpowiedzi zostały usunięte.

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
* Gdy metoda [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) jest używana do usunięcia komentarza, wszystkie odpowiedzi do tego komentarza są również usuwane.
* Jeśli [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) tworzy odwołanie cykliczne, zostaje zgłoszony [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodaj nowoczesne komentarze**

Nowoczesne komentarze mogą być powiązane z samym slajdem, konkretnym kształtem lub zakresem tekstu wewnątrz AutoShape. Metoda [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) przyjmuje argument [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) oprócz slajdu i współrzędnych znacznika komentarza.

Gdy jako argument shape przekazywane jest `null`, komentarz jest komentarzem na poziomie slajdu. Jego znacznik jest pozycjonowany według podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) zwraca `null`. Gdy podany jest [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), komentarz jest zakotwiczony do tego kształtu. Współrzędne nadal definiują pozycję znacznika komentarza na slajdzie, a powiązanie z kształtem można uzyskać poprzez [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/).

### **Zakotwicz nowoczesny komentarz do kształtu**

Przykład wywołuje [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) dwa razy: raz z `null` jako shape dla komentarza na poziomie slajdu i raz z prostokątem jako kotwicą. Odczytanie [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) wypisuje `true` dla sprawdzenia null w komentarzu slajdu oraz `Revenue title` dla zakotwiczonego komentarza. Oba komentarze są zapisywane wraz z prezentacją.

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

### **Zakotwicz komentarze do różnych typów kształtów**

Dowolny obiekt slajdu reprezentowany przez klasę [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) może być użyty jako kotwica kształtu. Typowe przykłady obejmują [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) oraz [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) takie jak wykresy.

Przykład używa [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/), aby powiązać komentarz z każdym z pięciu typów kształtów: AutoShape, ramką obrazu, grupą, łącznikiem i wykresem. Obraz wykorzystuje osadzone dane obrazu, więc nie wymagany jest zewnętrzny plik graficzny. Każdy komentarz ma własną pozycję znacznika, a zapisana prezentacja zachowuje wszystkie pięć powiązań kształtu.

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

### **Zakotwicz komentarz do tekstu i ustaw jego status**

Dla nowoczesnego komentarza powiązanego z [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) i [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) uzyskują pozycję początkową zaznaczonego tekstu w ramce tekstowej kształtu. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) i [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) uzyskują długość zaznaczenia. Razem te wartości łączą komentarz z określonym zakresem tekstu wewnątrz AutoShape.

Metody [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) i [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) uzyskują wartość z stałych [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/):
- `NotDefined` — nie zdefiniowano konkretnego statusu nowoczesnego komentarza.
- `Active` — komentarz jest aktywny.
- `Resolved` — komentarz został rozwiązany.
- `Closed` — komentarz jest zamknięty.

Przykład zakotwicza nowoczesny komentarz do słów „quarterly revenue” w tekście prostokąta. Oblicza zerowy indeks początku zaznaczenia z tekstu i przekazuje go do [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/), a następnie używa [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) do ustawienia liczby zaznaczonych znaków. Po wywołaniu [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) z wartością `Resolved`, zapisuje i ponownie otwiera prezentację. Cztery sprawdzenia w konsoli powinny wypisać `true`, potwierdzając, że zakotwiczenie kształtu, zakres tekstu i status zostały zachowane.

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

### **Sprawdź istniejące nowoczesne komentarze**

Przykład wymaga istniejącej prezentacji zawierającej nowoczesne komentarze i wypisuje ich tekst, status oraz szczegóły kotwicy. Aby je sprawdzić, należy zweryfikować, czy każdy komentarz jest [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/), a następnie zbadać [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) i [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/). Kształt `null` wskazuje na komentarz na poziomie slajdu. Dla kotwicy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) metody wyboru tekstu określają powiązany zakres w ramce tekstowej kształtu.

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

## **Usuń komentarze**

Aspose.Slides for PHP via Java umożliwia usunięcie wszystkich komentarzy i ich autorów z prezentacji lub usunięcie wybranych komentarzy przy zachowaniu pozostałych. Poniższe przykłady demonstrują oba podejścia i zapisują zaktualizowaną prezentację.

### **Usuń wszystkie komentarze i ich autorów**

Przykład otwiera istniejącą prezentację i wywołuje [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) dla każdego autora, a następnie wywołuje [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) aby usunąć samych autorów. Zapisana prezentacja nie zawiera żadnych komentarzy ani autorów komentarzy. Użyj prezentacji zawierającej komentarze, aby zobaczyć usunięcie.

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

### **Usuń wybrane komentarze**

Przykład tworzy dwa komentarze na jednym slajdzie i używa [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/), aby znaleźć komentarze każdego autora. Zbiera komentarze, których tekst równa się "comment 1" przed wywołaniem [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/), aby uniknąć zmian w kolekcji podczas wyboru. Zapisana prezentacja zachowuje tylko "comment 2".

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

Tak. [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) i [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) uzyskują wartość z [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/), w tym `Resolved`. Status jest przechowywany w prezentacji i może być ponownie odczytany po ponownym otwarciu pliku.

**Czy obsługiwane są wątki dyskusji (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżania?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), umożliwiając tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdżenia.

**W jakim układzie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest definiowana za pomocą współrzędnych zmiennoprzecinkowych w układzie współrzędnych slajdu, co pozwala precyzyjnie umieścić go na slajdzie.