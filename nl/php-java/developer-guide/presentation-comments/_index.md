---
title: Presentatiecommentaren beheren in PHP
linktitle: Presentatiecommentaren
type: docs
weight: 100
url: /nl/php-java/presentation-comments/
keywords:
- commentaar
- modern commentaar
- PowerPoint commentaren
- presentatiecommentaren
- dia-commentaren
- commentaar toevoegen
- commentaar benaderen
- commentaar bewerken
- commentaar beantwoorden
- commentaar verwijderen
- commentaar wissen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Beheer presentatiecommentaren met Aspose.Slides voor PHP via Java: voeg commentaren toe, lees, bewerk, beantwoord en verwijder commentaren in PowerPoint-presentaties snel en eenvoudig."
---
## **Overzicht**

Dit artikel beschrijft hoe u presentatiecommentaren kunt beheren met Aspose.Slides voor PHP via Java. Het introduceert de belangrijkste typen die met commentaren te maken hebben en laat zien hoe u commentaren aan dia's kunt toevoegen, bestaande commentaren kunt benaderen, met antwoorden en moderne commentaren kunt werken, en commentaren uit een presentatie kunt verwijderen.

De voorbeelden behandelen veelvoorkomende review‑ en samenwerkingsscenario's in PowerPoint, zoals commentaren toewijzen aan auteurs, commentaartekst en metadata lezen, antwoordketens opbouwen en geselecteerde commentaren of alle commentaren verwijderen.

In PowerPoint verschijnen commentaren als annotaties op dia's. Het selecteren van een commentaar toont de tekst en de bijbehorende discussie.

## **Waarom commentaren aan presentaties toevoegen?**

U kunt commentaren gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides voor PHP via Java biedt de volgende API's voor het werken met commentaren:

* De [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse, die toegang biedt tot de commentaarauteurs van de presentatie.
* De [CommentCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentcollection/)‑klasse, die de commentaren weergeeft die aan een individuele auteur zijn gekoppeld.
* De [Comment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/)‑klasse, die informatie over een commentaar biedt, inclusief auteur, aanmaaktijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentauthor/)‑klasse, die informatie over een auteur biedt, inclusief hun naam, initialen en gekoppelde commentaren.

## **Commentaren aan dia's toevoegen**

Het volgende voorbeeld toont hoe u commentaren aan dia's kunt toevoegen in een PowerPoint‑presentatie:

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

## **Commentaren op dia's benaderen**

Het volgende voorbeeld toont hoe u bestaande commentaren in een PowerPoint‑presentatie kunt benaderen:

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

## **Antwoorden op commentaren**

Een hoofdcommentaar is het oorspronkelijke commentaar bovenaan een antwoorderhiarchie. De [Comment::getParentComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/getparentcomment/) en [Comment::setParentComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/setparentcomment/)‑methoden laten u de ouder van een commentaar ophalen of instellen.

Het volgende voorbeeld toont hoe u antwoorden kunt toevoegen en de resulterende commentaarhiërarchie kunt inspecteren:

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

{{% alert color="warning" title="Waarschuwing" %}}
* Wanneer de [Comment::remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/remove/)‑methode wordt gebruikt om een commentaar te verwijderen, worden ook alle antwoorden op dat commentaar verwijderd.
* Als [Comment::setParentComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/setparentcomment/) een circulaire verwijzing creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxeditexception/) opgegooid.
{{% /alert %}}

## **Moderne commentaren toevoegen**

Moderne commentaren kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstreeks binnen een AutoShape. De [CommentCollection::addModernComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentcollection/addmoderncomment/)‑methode accepteert een [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/)‑argument naast de dia‑ en commentaar‑markercoördinaten.

Wanneer `null` wordt doorgegeven voor het shape‑argument, is het commentaar een dia‑niveau commentaar. De marker wordt gepositioneerd volgens de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [ModernComment::getShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getshape/) `null` retourneert. Wanneer een [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) wordt opgegeven, wordt het commentaar verankerd aan die vorm. De coördinaten bepalen nog steeds de positie van de commentaar‑marker op de dia, terwijl de vormkoppeling kan worden opgehaald via [ModernComment::getShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getshape/).

### **Een modern commentaar aan een vorm verankeren**

Het volgende voorbeeld maakt zowel een modern commentaar op dia‑niveau als een modern commentaar dat verankerd is aan een specifieke AutoShape. Vervolgens leest het de gekoppelde vorm uit elk commentaar.

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

### **Commentaren aan verschillende vormtypen verankeren**

Elk dia‑object dat wordt vertegenwoordigd door de [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/)‑klasse kan worden gebruikt als vormankerpunt. Veelvoorkomende voorbeelden zijn [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nl/php-java/aspose.slides/connector/), en [GraphicalObject](https://reference.aspose.com/slides/nl/php-java/aspose.slides/graphicalobject/)-instanties zoals grafieken.

Het volgende voorbeeld maakt verschillende veelvoorkomende vormtypen en koppelt een modern commentaar aan elk van hen.

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

### **Commentaar aan tekst verankeren en status instellen**

Voor een modern commentaar dat gekoppeld is aan een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/), geven [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/gettextselectionstart/) en [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/settextselectionstart/) de startpositie van de geselecteerde tekst in het tekstvak van de vorm terug. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/gettextselectionlength/) en [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/settextselectionlength/) geven de lengte van de selectie terug. Samen associëren deze waarden het commentaar met een specifieke tekstreeks binnen de AutoShape.

De [ModernComment::getStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getstatus/) en [ModernComment::setStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/setstatus/)‑methoden lezen een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncommentstatus/)‑constants:

- `NotDefined` — er is geen specifieke status voor moderne commentaren gedefinieerd.
- `Active` — het commentaar is actief.
- `Resolved` — het commentaar is opgelost.
- `Closed` — het commentaar is gesloten.

Het volgende voorbeeld maakt een vormverankerd modern commentaar, koppelt het aan een tekstselectie, markeert het als opgelost, slaat de presentatie op en controleert de waarden na het opnieuw openen van het bestand.

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

### **Bestaande moderne commentaren inspecteren**

Om een bestaande presentatie te inspecteren, controleer of elk commentaar een [ModernComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/) is, en onderzoek vervolgens [ModernComment::getShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/gettextselectionlength/), en [ModernComment::getStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getstatus/). Een `null`‑vorm duidt op een commentaar op dia‑niveau. Voor een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑ankerpunt identificeren de tekstselectiemethoden de bijbehorende reeks in het tekstvak van de vorm.

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

## **Commentaren verwijderen**

### **Alle commentaren en commentaarauteurs verwijderen**

Het volgende voorbeeld toont hoe u alle commentaren en commentaarauteurs uit een presentatie kunt verwijderen:

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

### **Specifieke commentaren verwijderen**

Het volgende voorbeeld toont hoe u specifieke commentaren van een dia kunt verwijderen:

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

**Ondersteunt Aspose.Slides een resolved‑status voor moderne commentaren?**

Ja. [ModernComment::getStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getstatus/) en [ModernComment::setStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/setstatus/) lezen een [ModernCommentStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncommentstatus/)‑waarde, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand opnieuw is geopend.

**Worden discussies in thread‑vorm (antwoordketens) ondersteund, en is er een limiet op het aantal niveaus?**

Ja. Elk commentaar kan naar zijn [parent comment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/getparentcomment/) verwijzen, waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van nesting.

**In welk coördinatensysteem wordt de positie van een commentaar‑marker op een dia gedefinieerd?**

De markerpositie wordt gedefinieerd door zwevende‑punt coördinaten in het dia‑coördinatensysteem, waardoor u deze nauwkeurig op de dia kunt plaatsen.