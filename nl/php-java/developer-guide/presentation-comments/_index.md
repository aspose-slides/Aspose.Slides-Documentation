---
title: Beheer presentatie‑opmerkingen in PHP
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
- opmerking wissen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Beheer presentatie‑opmerkingen met Aspose.Slides voor PHP via Java: voeg opmerkingen toe, lees, bewerk, beantwoord en verwijder ze snel en eenvoudig in PowerPoint‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatieopmerkingen kunt beheren met Aspose.Slides voor PHP via Java. Het introduceert de belangrijkste opmerkinggerelateerde typen en toont hoe u opmerkingen aan dia's kunt toevoegen, bestaande opmerkingen kunt benaderen, met antwoorden en moderne opmerkingen kunt werken, en opmerkingen uit een presentatie kunt verwijderen.

De voorbeelden behandelen gangbare controle‑ en samenwerkingsscenario's in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van de tekstopmerking en metadata, het opbouwen van antwoordketens, en het verwijderen van geselecteerde opmerkingen of alle opmerkingen.

In PowerPoint verschijnen opmerkingen als annotaties op dia's. Het selecteren van een opmerking toont de tekst en de gerelateerde discussie.

Om verzoeken te doen dat opmerkingen worden getoond of verborgen bij het openen van een presentatie zonder de opmerkingen zelf te wijzigen, zie [Opmerkingen tonen of verbergen bij het openen van een presentatie](/slides/nl/php-java/presentation-view-properties/).

## **Waarom opmerkingen toevoegen aan presentaties?**

U kunt opmerkingen gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides voor PHP via Java biedt de volgende API's voor het werken met opmerkingen:

* De [Presentatie](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) klasse, die toegang biedt tot de auteurs van opmerkingen in de presentatie.
* De [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) klasse, die de opmerkingen vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) klasse, die informatie over een opmerking biedt, inclusief de auteur, aanmaaktijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) klasse, die informatie over een auteur biedt, inclusief hun naam, initialen en bijbehorende opmerkingen.

## **Opmerkingen aan dia's toevoegen**

Het voorbeeld maakt twee dia's aan en registreert een opmerkingauteur met [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/). Het gebruikt [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) om één opmerking op elke dia te plaatsen, en haalt vervolgens de opmerkingen van de eerste dia op voor die auteur met [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/). De console toont de tekst van de eerste opmerking twee keer, waarmee de toegang via zowel de dia als de auteur wordt aangetoond, en de opgeslagen presentatie bevat beide opmerkingen.

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

## **Zoek of maak een opmerkingauteur**

Wanneer een geautomatiseerde controle dezelfde presentatie herhaaldelijk verwerkt, doorzoek dan de collectie die wordt geretourneerd door [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) voordat u een auteur toevoegt. [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) vergelijkt zowel de naam als de initialen en retourneert een array met overeenkomende auteurs, of een lege array als er geen overeenkomsten zijn. In tegenstelling hiermee zoekt [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) alleen op naam, ongeacht de initialen. Het aanroepen van [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) met een naam en initialen die al in de collectie aanwezig zijn, veroorzaakt een uitzondering.

Het voorbeeld vereist een presentatiebestand met minstens één dia. Tijdens twee doorlopen gebruikt het de eerst gevonden overeenkomende auteur opnieuw, of maakt het er één aan wanneer het resultaat leeg is. Als er meerdere overeenkomsten zijn, selecteert het het eerste array‑element zonder de andere auteurs samen te voegen of te verwijderen. Vervolgens wordt [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) aangeroepen voor de geselecteerde auteur en wordt de presentatie opgeslagen. De tweede doorloop opent de uitvoer van de eerste doorloop en herhaalt de bewerking.

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

De tweede doorloop voegt een extra opmerking toe zonder een extra auteur toe te voegen of bestaande opmerkingen te verwijderen. Het uiteindelijke bestand, `review_pass_2.pptx`, bevat beide nieuwe opmerkingen naast eventuele oorspronkelijke opmerkingen. Het hergebruiken van een auteur leidt niet tot deduplicatie van opmerkingen: om te voorkomen dat dezelfde opmerking herhaaldelijk wordt toegevoegd, implementeer u aparte duplicaatdetectie vóór het toevoegen.

## **Toegang tot dia‑opmerkingen**

Het voorbeeld opent een bestaande presentatie en leest de collectie die wordt geretourneerd door [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/). Voor elke auteur itereert het door de collectie die wordt geretourneerd door [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) en drukt het het dianummer, de opmerkingtekst, de auteursnaam en de aanmaaktijd af. De invoerpresentatie moet opmerkingen bevatten om console‑output te genereren.

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

## **Antwoorden op opmerkingen**

Een bovenliggende opmerking is de oorspronkelijke opmerking bovenaan een antwoordhiërarchie. De methoden [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) en [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) stellen u in staat om de bovenliggende opmerking van een opmerking op te halen of in te stellen.

Het voorbeeld maakt opmerkingen van twee auteurs en gebruikt [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) om antwoorden te bouwen, inclusief een antwoord op een ander antwoord. Het doorgeven van `null` aan [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) haalt opmerkingen op van alle auteurs; de console inspringt elk item volgens de diepte in de antwoordhiërarchie. Het voorbeeld slaat de volledige discussie op, roept [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) aan op de eerste wortelopmerking, en slaat een tweede presentatie op waarin die opmerking en de bijbehorende antwoorden zijn verwijderd.

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
* Wanneer de [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) methode wordt gebruikt om een opmerking te verwijderen, worden ook alle antwoorden op die opmerking verwijderd.
* Als [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) een circulaire referentie creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/) gegooid.
{{% /alert %}}

## **Moderne opmerkingen toevoegen**

Moderne opmerkingen kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstreeks binnen een AutoShape. De methode [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) accepteert een [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑argument naast de dia‑ en commentaar‑marker‑coördinaten.

Wanneer `null` wordt doorgegeven voor het vorm‑argument, is de opmerking een dia‑niveau opmerking. De marker wordt gepositioneerd op basis van de meegegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) `null` retourneert. Wanneer een [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) wordt opgegeven, wordt de opmerking verankerd aan die vorm. De coördinaten bepalen nog steeds de positie van de marker op de dia, terwijl de vormkoppeling kan worden opgehaald via [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/).

### **Een moderne opmerking aan een vorm verankeren**

Het voorbeeld roept [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) twee keer aan: eenmaal met een `null` vorm voor een dia‑niveau opmerking en eenmaal met een rechthoek als anker. Het lezen van [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) drukt `true` af voor de null‑controle van de dia‑niveau opmerking en `Revenue title` voor de verankerde opmerking. Beide opmerkingen worden met de presentatie opgeslagen.

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

### **Opmerkingen aan verschillende vormtypen verankeren**

Elk dia‑object dat wordt vertegenwoordigd door de [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) klasse kan worden gebruikt als vormanker. Veelvoorkomende voorbeelden zijn [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) en [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) exemplaren zoals grafieken.

Het voorbeeld gebruikt [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) om een opmerking te koppelen aan elk van vijf vormtypen: een AutoShape, een picture frame, een groep, een connector en een grafiek. De afbeelding gebruikt ingesloten beeldgegevens, dus er is geen externe afbeelding vereist. Elke opmerking heeft zijn eigen markerpositie, en de opgeslagen presentatie behoudt alle vijf vormkoppelingen.

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

### **Een opmerking aan tekst verankeren en de status instellen**

Voor een moderne opmerking gekoppeld aan een [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) geven [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) en [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) de startpositie van de geselecteerde tekst in het tekstvak van de vorm. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) en [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) geven de lengte van de selectie. Samen koppelen deze waarden de opmerking aan een specifiek tekstbereik binnen de AutoShape.

De methoden [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) en [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) geven een waarde uit de constanten [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) terug:

- `NotDefined` — er is geen specifieke moderne‑opmerkingstatus gedefinieerd.
- `Active` — de opmerking is actief.
- `Resolved` — de opmerking is opgelost.
- `Closed` — de opmerking is gesloten.

Het voorbeeld verankert een moderne opmerking aan de woorden “quarterly revenue” in de tekst van een rechthoek. Het berekent de nul‑gebaseerde startpositie uit de tekst en geeft deze door aan [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) en gebruikt [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) om het aantal geselecteerde tekens in te stellen. Na het aanroepen van [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) met `Resolved`, wordt de presentatie opgeslagen en opnieuw geopend. De vier console‑controles zouden elk `true` moeten afdrukken, waarmee wordt bevestigd dat het vormanker, het tekstbereik en de status zijn behouden.

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

Het voorbeeld vereist een bestaande presentatie met moderne opmerkingen en drukt hun tekst, status en anker‑details af. Om dit te inspecteren, controleert u of elke opmerking een [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) is, waarna u [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) en [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) onderzoekt. Een `null` vorm duidt op een dia‑niveau opmerking. Voor een [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) anker identificeren de tekst‑selectiemethoden het bijbehorende bereik in het tekstvak van de vorm.

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

Aspose.Slides voor PHP via Java stelt u in staat alle opmerkingen en hun auteurs uit een presentatie te verwijderen of geselecteerde opmerkingen te verwijderen terwijl de rest behouden blijft. De volgende voorbeelden demonstreren beide benaderingen en slaan de bijgewerkte presentatie op.

### **Alle opmerkingen en opmerkingauteurs verwijderen**

Het voorbeeld opent een bestaande presentatie en roept [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) aan voor elke auteur, daarna wordt [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) aangeroepen om de auteurs zelf te verwijderen. De opgeslagen presentatie bevat geen opmerkingen of opmerkingauteurs. Gebruik een presentatie met opmerkingen om de verwijdering te observeren.

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

Het voorbeeld maakt twee opmerkingen op één dia en gebruikt [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) om opmerkingen van elke auteur te vinden. Het verzamelt opmerkingen waarvan de tekst gelijk is aan “comment 1” voordat [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/) wordt aangeroepen, zodat de collectie niet wordt gewijzigd tijdens de selectie. De opgeslagen presentatie bevat alleen “comment 2”.

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

## **Veelgestelde vragen**

**Ondersteunt Aspose.Slides een resolved‑status voor moderne opmerkingen?**

Ja. [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) en [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) geven een [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/)‑waarde terug, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden uitgelezen nadat het bestand is heropend.

**Worden discussies met threads (antwoordketens) ondersteund en is er een limiet op de nesting?**

Ja. Elke opmerking kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke diepte‑limiet voor nesting.

**In welk coördinatensysteem wordt de positie van een commentaar‑marker op een dia gedefinieerd?**

De markerpositie wordt gedefinieerd door zwevende‑komma coördinaten in het dia‑coördinatensysteem, waardoor u de marker nauwkeurig op de dia kunt plaatsen.