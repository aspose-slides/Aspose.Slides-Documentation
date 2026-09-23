---
title: Beheer presentatieopmerkingen in PHP
linktitle: Presentatie‑opmerkingen
type: docs
weight: 100
url: /nl/php-java/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint‑opmerkingen
- presentatie‑opmerkingen
- dia‑opmerkingen
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking verwijderen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Beheer presentatie‑opmerkingen met Aspose.Slides for PHP via Java: voeg toe, lees, bewerk, beantwoord en verwijder opmerkingen in PowerPoint‑presentaties snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑opmerkingen beheert met Aspose.Slides for PHP via Java. Het introduceert de belangrijkste opmerking‑gerelateerde types en toont hoe u opmerkingen aan dia's toevoegt, bestaande opmerkingen benadert, werkt met antwoorden en moderne opmerkingen, en opmerkingen uit een presentatie verwijdert.

De voorbeelden behandelen veelvoorkomende beoordelings‑ en samenwerkingsscenario's in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van de opmerkingtekst en metadata, het opbouwen van antwoordketens, en het verwijderen van geselecteerde opmerkingen of alle opmerkingen.

In PowerPoint verschijnen opmerkingen als annotaties op dia's. Het selecteren van een opmerking toont de tekst en de bijbehorende discussie.

Om ervoor te zorgen dat opmerkingen worden getoond of verborgen wanneer een presentatie wordt geopend zonder de opmerkingen zelf te wijzigen, zie [Toon of verberg opmerkingen bij het openen van een presentatie](/slides/nl/php-java/presentation-view-properties/).

## **Waarom opmerkingen aan presentaties toevoegen?**

U kunt opmerkingen gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides for PHP via Java biedt de volgende API's voor het werken met opmerkingen:

* De klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) die toegang biedt tot de opmerkingauteurs van de presentatie.
* De klasse [CommentCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentcollection/) die de opmerkingen weergeeft die aan een individuele auteur zijn gekoppeld.
* De klasse [Comment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/) die informatie over een opmerking geeft, inclusief auteur, aanmaakdatum, positie en tekst.
* De klasse [CommentAuthor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentauthor/) die informatie over een auteur geeft, inclusief naam, initialen en gekoppelde opmerkingen.

## **Dia-opmerkingen toevoegen**

Het volgende voorbeeld toont hoe u opmerkingen aan dia's in een PowerPoint‑presentatie toevoegt:

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

## **Dia‑opmerkingen benaderen**

Het volgende voorbeeld toont hoe u bestaande opmerkingen in een PowerPoint‑presentatie benadert:

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

## **Beantwoorden van opmerkingen**

Een hoofdopmerking is de oorspronkelijke opmerking bovenaan een antwoordhiërarchie. De methoden [Comment::getParentComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/getparentcomment/) en [Comment::setParentComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/setparentcomment/) laten u de hoofdopmerking van een opmerking opvragen of instellen.

Het volgende voorbeeld toont hoe u antwoorden toevoegt en de resulterende opmerkinghiërarchie inspecteert:

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
* Wanneer de methode [Comment::remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/remove/) wordt gebruikt om een opmerking te verwijderen, worden ook alle antwoorden op die opmerking verwijderd.
* Als [Comment::setParentComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/setparentcomment/) een circulaire referentie creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxeditexception/) opgegooid.
{{% /alert %}}

## **Moderne opmerkingen toevoegen**

Moderne opmerkingen kunnen worden gekoppeld aan de dia zelf, aan een specifiek vormobject, of aan een tekstreeks binnen een AutoShape. De methode [CommentCollection::addModernComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commentcollection/addmoderncomment/) accepteert een argument van het type [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) naast de dia‑ en commentaar‑markercoördinaten.

Wanneer `null` wordt doorgegeven voor het vorm‑argument, is de opmerking een dia‑niveau opmerking. De marker wordt gepositioneerd op basis van de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [ModernComment::getShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getshape/) `null` retourneert. Wanneer een [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) wordt opgegeven, wordt de opmerking verankerd aan die vorm. De coördinaten definiëren nog steeds de positie van de marker op de dia, terwijl de vormassociatie kan worden opgehaald via [ModernComment::getShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getshape/).

### **Een moderne opmerking verankeren aan een vorm**

Het volgende voorbeeld maakt zowel een moderne opmerking op dia‑niveau als een moderne opmerking verankerd aan een specifieke AutoShape. Het leest vervolgens de bijbehorende vorm van elke opmerking.

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

### **Opmerkingen verankeren aan verschillende vormtypen**

Elk dia‑object dat wordt weergegeven door de klasse [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) kan worden gebruikt als vorm‑anker. Veelvoorkomende voorbeelden zijn onder andere [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nl/php-java/aspose.slides/connector/), en [GraphicalObject](https://reference.aspose.com/slides/nl/php-java/aspose.slides/graphicalobject/) zoals diagrammen.

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

### **Een opmerking verankeren aan tekst en de status instellen**

Voor een moderne opmerking die is gekoppeld aan een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/), geven [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/gettextselectionstart/) en [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/settextselectionstart/) de startpositie van de geselecteerde tekst in het tekstvak van de vorm. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/gettextselectionlength/) en [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/settextselectionlength/) geven de lengte van de selectie. Samen koppelen deze waarden de opmerking aan een specifiek tekstdomein binnen de AutoShape.

De methoden [ModernComment::getStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getstatus/) en [ModernComment::setStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/setstatus/) geven een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncommentstatus/)‑constants terug:

- `NotDefined` — er is geen specifieke moderne‑opmerkingstatus gedefinieerd.
- `Active` — de opmerking is actief.
- `Resolved` — de opmerking is opgelost.
- `Closed` — de opmerking is gesloten.

Het volgende voorbeeld maakt een vorm‑verankerde moderne opmerking, koppelt deze aan een tekstreek, markeert hem als opgelost, slaat de presentatie op en controleert de waarden na het heropenen van het bestand.

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

### **Bestaande moderne opmerkingen inspecteren**

Om een bestaande presentatie te inspecteren, controleert u of elke opmerking een [ModernComment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/) is, en bekijkt u vervolgens [ModernComment::getShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/gettextselectionlength/) en [ModernComment::getStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getstatus/). Een `null` vorm duidt op een opmerking op dia‑niveau. Voor een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑anker identificeren de tekst‑selectiemethoden het bijbehorende bereik in het tekstvak van de vorm.

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

## **Opmerkingen verwijderen**

### **Alle opmerkingen en opmerkingauteurs verwijderen**

Het volgende voorbeeld toont hoe u alle opmerkingen en opmerkingauteurs uit een presentatie verwijdert:

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

### **Specifieke opmerkingen verwijderen**

Het volgende voorbeeld toont hoe u specifieke opmerkingen van een dia verwijdert:

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

**Ondersteunt Aspose.Slides een opgeloste status voor moderne opmerkingen?**

Ja. [ModernComment::getStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/getstatus/) en [ModernComment::setStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncomment/setstatus/) geven een [ModernCommentStatus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/moderncommentstatus/)‑waarde terug, waaronder `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand is heropend.

**Worden doorlopende discussies (antwoordketens) ondersteund, en is er een limiet op nesting?**

Ja. Elke opmerking kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/comment/getparentcomment/), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke diepte‑limiet voor nesting.

**In welk coördinatensysteem is de positie van een opmerkingmarker op een dia gedefinieerd?**

De markerpositie wordt gedefinieerd door zwevende‑komma‑coördinaten in het dia‑coördinatensysteem, zodat u de marker precies op de gewenste plaats op de dia kunt positioneren.