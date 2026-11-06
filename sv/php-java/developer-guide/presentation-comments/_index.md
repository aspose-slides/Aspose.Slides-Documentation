---
title: Hantera presentationskommentarer i PHP
linktitle: Presentationskommentarer
type: docs
weight: 100
url: /sv/php-java/presentation-comments/
keywords:
- kommentar
- modern kommentar
- PowerPoint-kommentarer
- presentationskommentarer
- bildkommentarer
- lägg till kommentar
- åtkomst till kommentar
- redigera kommentar
- svara på kommentar
- ta bort kommentar
- radera kommentar
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Hantera presentationskommentarer med Aspose.Slides för PHP via Java: lägg till, läs, redigera, svara på och ta bort kommentarer i PowerPoint-presentationer snabbt och enkelt."
---
## **Översikt**

Den här artikeln förklarar hur du hanterar presentationskommentarer med Aspose.Slides för PHP via Java. Den introducerar de viktigaste typerna relaterade till kommentarer och visar hur du lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga gransknings‑ och samarbetsscenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentars­text och metadata, bygga svarskedjor och ta bort valda kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som annoteringar på bilder. När du markerar en kommentar visas dess text och tillhörande diskussion.

För att begära att kommentarer visas eller döljes när en presentation öppnas utan att ändra själva kommentarer, se [Visa eller dölj kommentarer när en presentation öppnas](/slides/sv/php-java/presentation-view-properties/).

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge återkoppling och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för PHP via Java tillhandahåller följande API:er för att arbeta med kommentarer:

* The [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) class, which represents the comments associated with an individual author.
* The [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) class, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **Lägg till bildkommentarer**

Exemplet skapar två bilder och registrerar en kommentarförfattare med [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/). Det använder [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) för att placera en kommentar på varje bild, hämtar sedan den första bildens kommentarer för den författaren med [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/). Konsolen visar den första kommentarens text två gånger, vilket demonstrerar åtkomst både via bilden och författaren, och den sparade presentationen innehåller båda kommentarerna.

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

## **Hitta eller skapa en kommentarförfattare**

När en automatiserad granskning bearbetar samma presentation upprepade gånger, sök i samlingen som returneras av [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) innan du lägger till en författare. [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) matchar både namn och initialer och returnerar en array med matchande författare, eller en tom array om inga matchningar finns. I kontrast söker [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) bara på namn, oavsett initialer. Att anropa [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) med ett namn och initialer som redan finns i samlingen kastar ett undantag.

Exemplet kräver en presentationsfil med minst en bild. På varje av två genomgångar återanvänder det den första matchande författaren, eller skapar en ny endast när resultatet är tomt. Om det finns flera matchningar väljs det första array‑elementet utan att sammanslå eller ta bort de andra författarna. Därefter anropas [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) för den valda författaren och presentationen sparas. Den andra genomgången öppnar output från den första genomgången och upprepar operationen.

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

Den andra genomgången lägger till en annan kommentar utan att lägga till en ny författare eller ta bort befintliga kommentarer. Den slutliga filen, `review_pass_2.pptx`, innehåller båda nya kommentarer tillsammans med eventuella ursprungliga kommentarer. Återanvändning av en författare deduplicerar inte kommentarer: för att undvika att upprepade gånger lägga till samma kommentar, implementera separat dubblettdetektering innan du lägger till den.

## **Åtkomst till bildkommentarer**

Exemplet öppnar en befintlig presentation och läser samlingen som returneras av [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/). För varje författare itererar det genom samlingen som returneras av [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) och skriver ut bildnummer, kommentartext, författarnamn och skapningstid. Inmatningspresentationen måste innehålla kommentarer för att producera konsolutdata.

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

## **Svara på kommentarer**

En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. Metoderna [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) och [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) låter dig hämta eller sätta föräldern till en kommentar.

Exemplet skapar kommentarer från två författare och använder [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) för att bygga svar, inklusive ett svar på ett annat svar. Att skicka `null` till [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) hämtar kommentarer från alla författare; konsolen indenterar varje post enligt dess djup i svarshierarkin. Exemplet sparar den fullständiga diskussionen, anropar [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) på den första rotkommentaren och sparar en andra presentation där den kommentaren och dess svar har tagits bort.

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
* När metoden [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) används för att radera en kommentar, tas även alla svar till den kommentaren bort.
* Om [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) skapar en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan associeras med själva bilden, med en specifik form eller med ett textintervall i en AutoShape. Metoden [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) accepterar ett [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑argument utöver bilden och koordinaterna för kommentar‑markören.

När `null` skickas för shape‑argumentet är kommentaren en bildnivåkommentar. Dess markör placeras enligt de angivna koordinaterna, men den är inte knuten till någon specifik form, så [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) returnerar `null`. När en [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) tillhandahålls är kommentaren förankrad till den formen. Koordinaterna definierar fortfarande positionen för kommentarmarkören på bilden, medan form‑associationen kan hämtas via [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/).

### **Fäst en modern kommentar till en form**

Exemplet anropar [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) två gånger: en gång med en `null`‑form för en bildnivåkommentar och en gång med en rektangel som förankring. Att läsa [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) skriver ut `true` för bildnivåkommentarens null‑kontroll och `Revenue title` för den förankrade kommentaren. Båda kommentarerna sparas med presentationen.

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

### **Fäst kommentarer till olika formtyper**

Alla bildobjekt som representeras av klassen [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) kan användas som formankare. Vanliga exempel inkluderar [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) och [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/)-instanser som diagram.

Exemplet använder [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) för att associera en kommentar med var och en av fem formtyper: en AutoShape, en bildram, en grupp, en anslutning och ett diagram. Bilden använder inbäddade bilddata, så ingen extern bild behövs. Varje kommentar har sin egen markörposition, och den sparade presentationen behåller alla fem formassociationer.

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

### **Fäst en kommentar till text och ange dess status**

För en modern kommentar som är associerad med en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), ger [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) och [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) åtkomst till startpositionen för den markerade texten i formens textruta. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) och [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) ger åtkomst till markeringens längd. Tillsammans associerar dessa värden kommentaren med ett specifikt textintervall i AutoShape.

Metoderna [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) och [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) ger åtkomst till ett värde från konstanten [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — ingen specifik modern‑kommentarstatus är definierad.
- `Active` — kommentaren är aktiv.
- `Resolved` — kommentaren har markerats som löst.
- `Closed` — kommentaren är stängd.

Exemplet förankrar en modern kommentar till orden "quarterly revenue" i en rektangels text. Det beräknar den nollbaserade startpositionen från texten och skickar den till [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) samt använder [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) för att ange antalet markerade tecken. Efter att ha anropat [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) med `Resolved` sparas och öppnas presentationen på nytt. De fyra konsollkontrollerna bör alla skriva ut `true`, vilket bekräftar att formankaret, textintervallet och statusen bevarades.

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

### **Inspektera befintliga moderna kommentarer**

Exemplet kräver en befintlig presentation som innehåller moderna kommentarer och skriver ut deras text, status och förankringsdetaljer. För att inspektera den, kontrollera om varje kommentar är en [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/), sedan granska [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) och [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/). En `null`‑form indikerar en bildnivåkommentar. För en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)‑förankring identifierar text‑urvalsmekanismerna det associerade intervallet i formens textruta.

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

## **Ta bort kommentarer**

Aspose.Slides för PHP via Java låter dig ta bort alla kommentarer och deras författare från en presentation eller radera utvalda kommentarer medan resten behålls. Följande exempel demonstrerar båda tillvägagångssätten och sparar den uppdaterade presentationen.

### **Ta bort alla kommentarer och kommentarförfattare**

Exemplet öppnar en befintlig presentation och anropar [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) för varje författare, därefter [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) för att ta bort själva författarna. Den sparade presentationen innehåller varken kommentarer eller kommentarförfattare. Använd en presentation som innehåller kommentarer för att observera borttagningen.

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

### **Ta bort specifika kommentarer**

Exemplet skapar två kommentarer på en bild och använder [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) för att hitta kommentarer för varje författare. Det samlar kommentarer vars text är lika med "comment 1" innan det anropar [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/), för att undvika förändringar i samlingen under urvalet. Den sparade presentationen behåller endast "comment 2".

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

## **Vanliga frågor**

**Stöder Aspose.Slides ett löst‑status för moderna kommentarer?**

Ja. [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) och [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) ger åtkomst till ett [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/)-värde, inklusive `Resolved`. Statusen lagras i presentationen och kan läsas igen efter att filen har öppnats på nytt.

**Stöds trådade diskussioner (svarskedjor), och finns det någon begränsning för nästling?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), vilket möjliggör svarskedjor. API:et definierar ingen specifik gräns för nästlingsdjup.

**I vilket koordinatsystem definieras en kommentarmärkares position på en bild?**

Märkarens position definieras av flyttalskoordinater i bildens koordinatsystem, vilket låter dig placera den exakt på bilden.