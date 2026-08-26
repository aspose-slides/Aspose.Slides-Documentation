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

Den här artikeln förklarar hur man hanterar presentationskommentarer med Aspose.Slides för PHP via Java. Den introducerar de viktigaste typerna relaterade till kommentarer och demonstrerar hur man lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga gransknings- och samarbetsscenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentartext och metadata, bygga svarskedjor och ta bort valda kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som annoteringar på bilder. När du markerar en kommentar visas dess text och relaterade diskussion.

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge återkoppling och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för PHP via Java tillhandahåller följande API för att arbeta med kommentarer:

* Klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) ger åtkomst till presentationens kommentarförfattare.
* Klassen [CommentCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commentcollection/) representerar kommentarer som är associerade med en enskild författare.
* Klassen [Comment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/) ger information om en kommentar, inklusive dess författare, skapelsedatum, position och text.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commentauthor/) ger information om en författare, inklusive namn, initialer och associerade kommentarer.

## **Lägg till bildkommentarer**

Följande exempel visar hur man lägger till kommentarer på bilder i en PowerPoint-presentation:

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
        echo java_values($commentText) . PHP.ENDL;
    }

    $presentation->save("Comments_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Åtkomst till bildkommentarer**

Följande exempel visar hur man får åtkomst till befintliga kommentarer i en PowerPoint-presentation:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Comments1.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        foreach ($author->getComments() as $comment) {
            echo "Slide: " . java_values($comment->getSlide()->getSlideNumber()) . PHP_EOL;
            echo "Comment: " . java_values($comment->getText()) . PHP.ENDL;
            echo "Author: " . java_values($comment->getAuthor()->getName()) . PHP.ENDL;
            echo "Posted at: " . java_values($comment->getCreatedTime()->toString()) . PHP.ENDL;
            echo PHP.ENDL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Svara på kommentarer**

En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. Metoderna [Comment::getParentComment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/getparentcomment/) och [Comment::setParentComment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/setparentcomment/) låter dig hämta eller sätta föräldern för en kommentar.

Följande exempel visar hur man lägger till svar och inspekterar den resulterande kommentarshierarkin:

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

        echo java_values($comments[$i]->getAuthor()->getName()) . ": " . java_values($comments[$i]->getText()) . PHP.ENDL;
    }

    $presentation->save("parent_comment.pptx", SaveFormat::Pptx);

    $comment1->remove();
    $presentation->save("remove_comment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* När metoden [Comment::remove](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/remove/) används för att ta bort en kommentar, tas alla svar på den kommentaren också bort.
* Om [Comment::setParentComment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/setparentcomment/) skapar en cirkulär referens kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan associeras med själva bilden, med en specifik form eller med ett textintervall i en AutoShape. Metoden [CommentCollection::addModernComment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commentcollection/addmoderncomment/) accepterar ett argument av typen [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) utöver bilden och koordinaterna för kommentarmarkören.

När `null` skickas för shape‑argumentet blir kommentaren en bildnivåkommentar. Dess markör placeras med de angivna koordinaterna men är inte kopplad till någon specifik form, så [ModernComment::getShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/getshape/) returnerar `null`. När en [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) tillhandahålls, fästs kommentaren vid den formen. Koordinaterna definierar fortfarande positionen för kommentarmarkören på bilden, medan formassociationen kan hämtas via [ModernComment::getShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/getshape/).

### **Fäst en modern kommentar på en form**

Följande exempel skapar både en modern kommentar på bildnivå och en modern kommentar fäst vid en specifik AutoShape. Det läser sedan den associerade formen från varje kommentar.

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

    echo (java_is_null($slideComment->getShape()) ? "true" : "false") . PHP.ENDL;
    echo java_values($shapeComment->getShape()->getName()) . PHP.ENDL;

    $presentation->save("modern_comments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Fäst kommentarer till olika formtyper**

Alla bildobjekt som representeras av klassen [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) kan användas som en formankare. Vanliga exempel inkluderar [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/sv/php-java/aspose.slides/connector/) och [GraphicalObject](https://reference.aspose.com/slides/sv/php-java/aspose.slides/graphicalobject/) instanser såsom diagram.

Följande exempel skapar flera vanliga formtyper och associerar en modern kommentar med var och en.

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

För en modern kommentar som är associerad med en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/), ger [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/gettextselectionstart/) och [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/settextselectionstart/) åtkomst till startpositionen för den markerade texten i formens textruta. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/gettextselectionlength/) och [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/settextselectionlength/) ger åtkomst till längden på markeringen. Tillsammans associerar dessa värden kommentaren med ett specifikt textintervall i AutoShape.

Metoderna [ModernComment::getStatus](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/getstatus/) och [ModernComment::setStatus](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/setstatus/) hämtar ett värde från konstanten [ModernCommentStatus](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — ingen specifik modernkommentarstatus är definierad.
- `Active` — kommentaren är aktiv.
- `Resolved` — kommentaren har markerats som löst.
- `Closed` — kommentaren är stängd.

Följande exempel skapar en formankrad modern kommentar, associerar den med ett texturval, markerar den som löst, sparar presentationen och verifierar värdena efter att filen har öppnats igen.

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

        echo "Shape anchor preserved: " . ($shapeMatches ? "true" : "false") . PHP.ENDL;
        echo "Text selection start preserved: " . ($selectionStartMatches ? "true" : "false") . PHP.ENDL;
        echo "Text selection length preserved: " . ($selectionLengthMatches ? "true" : "false") . PHP.ENDL;
        echo "Resolved status preserved: " . ($statusMatches ? "true" : "false") . PHP.ENDL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

### **Inspektera befintliga moderna kommentarer**

För att inspektera en befintlig presentation, kontrollera om varje kommentar är en [ModernComment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/), och undersök sedan [ModernComment::getShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/gettextselectionlength/) samt [ModernComment::getStatus](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/getstatus/). En `null` form indikerar en bildnivåkommentar. För en [AutoShape]‑ankare identifierar texturvalsmetoderna det associerade intervallet i formens textruta.

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

            echo "Slide: " . java_values($slide->getSlideNumber()) . PHP.ENDL;
            echo "Text: " . java_values($comment->getText()) . PHP.ENDL;
            echo "Status: " . java_values($comment->getStatus()) . PHP.ENDL;

            $shape = $comment->getShape();
            if (java_is_null($shape)) {
                echo "Anchor: slide level" . PHP.ENDL;
            } else {
                echo "Anchor shape: " . java_values($shape->getName()) . PHP.ENDL;
                echo "Anchor type: " . java_values($shape->getClass()->getSimpleName()) . PHP.ENDL;

                if (java_instanceof($shape, $autoShapeClass)) {
                    echo "Text selection start: " . java_values($comment->getTextSelectionStart()) . PHP.ENDL;
                    echo "Text selection length: " . java_values($comment->getTextSelectionLength()) . PHP.ENDL;
                }
            }

            echo PHP.ENDL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ta bort kommentarer**

### **Ta bort alla kommentarer och kommentarförfattare**

Följande exempel visar hur man tar bort alla kommentarer och kommentarförfattare från en presentation:

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

Följande exempel visar hur man tar bort specifika kommentarer från en bild:

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

**Stöder Aspose.Slides en löst status för moderna kommentarer?**

Ja. [ModernComment::getStatus](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/getstatus/) och [ModernComment::setStatus](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncomment/setstatus/) ger åtkomst till ett värde från [ModernCommentStatus](https://reference.aspose.com/slides/sv/php-java/aspose.slides/moderncommentstatus/), inklusive `Resolved`. Statusen lagras i presentationen och kan läsas igen efter att filen har öppnats på nytt.

**Stöds trådade diskussioner (svarskedjor), och finns det någon begränsning för nästning?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/comment/getparentcomment/), vilket möjliggör svarskedjor. API:et definierar ingen specifik begränsning för hur djupt kommentarer kan nästas.

**I vilket koordinatsystem definieras en kommentarmarkörs position på en bild?**

Markörens position definieras av flyttalskoordinater i bildens koordinatsystem, vilket gör att du kan placera den exakt på bilden.