---
title: Správa komentářů prezentace v PHP
linktitle: Komentáře prezentace
type: docs
weight: 100
url: /cs/php-java/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře prezentace
- komentáře snímku
- přidat komentář
- přístup ke komentáři
- upravit komentář
- odpovědět na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte komentáře prezentace pomocí Aspose.Slides pro PHP přes Java: přidávejte, čtěte, upravujte, odpovídejte a odstraňujte komentáře v PowerPoint prezentacích rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře prezentace pomocí Aspose.Slides pro PHP přes Java. Představuje hlavní typy související s komentáři a ukazuje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi a moderními komentáři a odstraňovat komentáře z prezentace.

Příklady pokrývají běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení textu a metadat komentářů, vytváření řetězců odpovědí a odstraňování vybraných komentářů nebo všech komentářů.

V PowerPointu se komentáře zobrazují jako anotace na snímcích. Výběrem komentáře se zobrazí jeho text a související diskuse.

Pro požadavek, aby byly komentáře při otevírání prezentace zobrazeny nebo skryty bez změny samotných komentářů, viz [Zobrazit nebo skrýt komentáře při otevírání prezentace](/slides/cs/php-java/presentation-view-properties/).

## **Proč přidávat komentáře do prezentací?**

Komentáře můžete použít k poskytování zpětné vazby a spolupráci s kolegy při revizi prezentací.

Aspose.Slides pro PHP přes Java poskytuje následující rozhraní API pro práci s komentáři:

* Třída [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) poskytuje přístup k autorům komentářů prezentace.
* Třída [CommentCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commentcollection/) představuje komentáře spojené s jednotlivým autorem.
* Třída [Comment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/) poskytuje informace o komentáři, včetně jeho autora, času vytvoření, pozice a textu.
* Třída [CommentAuthor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commentauthor/) poskytuje informace o autorovi, včetně jeho jména, iniciál a přidružených komentářů.

## **Přidat komentáře do snímků**

Následující příklad ukazuje, jak přidat komentáře do snímků v PowerPoint prezentaci:

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

## **Přístup ke komentářům snímků**

Následující příklad ukazuje, jak přistupovat k existujícím komentářům v PowerPoint prezentaci:

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

## **Odpovídat na komentáře**

Rodičovský komentář je původní komentář na vrcholu hierarchie odpovědí. Metody [Comment::getParentComment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/getparentcomment/) a [Comment::setParentComment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/setparentcomment/) vám umožňují získat nebo nastavit rodiče komentáře.

Následující příklad ukazuje, jak přidávat odpovědi a prozkoumat vzniklou hierarchii komentářů:

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
* Když je použita metoda [Comment::remove](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/remove/), komentář je smazán a všechny odpovědi na tento komentář jsou také smazány.
* Pokud metoda [Comment::setParentComment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/setparentcomment/) vytvoří cyklický odkaz, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Přidat moderní komentáře**

Moderní komentáře mohou být přiřazeny přímo ke snímku, ke konkrétnímu tvaru nebo k textovému rozsahu uvnitř AutoShape. Metoda [CommentCollection::addModernComment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commentcollection/addmoderncomment/) přijímá argument typu [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) kromě snímku a souřadnic značky komentáře.

Když je pro argument shape předáno `null`, komentář je na úrovni snímku. Jeho značka je umístěna podle zadaných souřadnic, ale není přiřazena konkrétnímu tvaru, takže [ModernComment::getShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/getshape/) vrací `null`. Když je poskytnut objekt [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/), je komentář ukotven k tomuto tvaru. Souřadnice i nadále určují pozici značky komentáře na snímku, zatímco přiřazení tvaru lze získat pomocí [ModernComment::getShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/getshape/).

### **Ukotvit moderní komentář k tvaru**

Následující příklad vytvoří jak moderní komentář na úrovni snímku, tak moderní komentář ukotvený ke konkrétnímu AutoShape. Poté načte přiřazený tvar z každého komentáře.

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

### **Ukotvit komentáře k různým typům tvarů**

Jakýkoli objekt snímku reprezentovaný třídou [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) může být použit jako ukotvení tvaru. Běžné příklady zahrnují [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/cs/php-java/aspose.slides/connector/) a instance [GraphicalObject](https://reference.aspose.com/slides/cs/php-java/aspose.slides/graphicalobject/), jako jsou grafy.

Následující příklad vytvoří několik běžných typů tvarů a přiřadí k nim moderní komentář.

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

### **Ukotvit komentář k textu a nastavit jeho stav**

Pro moderní komentář spojený s [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/), metody [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/gettextselectionstart/) a [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/settextselectionstart/) získávají počáteční pozici vybraného textu v textovém rámci tvaru. Metody [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/gettextselectionlength/) a [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/settextselectionlength/) získávají délku výběru. Společně tyto hodnoty spojují komentář s konkrétním textovým rozsahem uvnitř AutoShape.

Metody [ModernComment::getStatus](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/getstatus/) a [ModernComment::setStatus](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/setstatus/) přistupují k hodnotě ze skupiny konstant [ModernCommentStatus](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — není definován žádný konkrétní stav moderního komentáře.
- `Active` — komentář je aktivní.
- `Resolved` — komentář byl vyřešen.
- `Closed` — komentář je uzavřen.

Následující příklad vytvoří moderní komentář ukotvený k tvaru, přiřadí jej k výběru textu, označí jej jako vyřešený, uloží prezentaci a ověří hodnoty po opětovném otevření souboru.

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

### **Prozkoumat existující moderní komentáře**

Pro prozkoumání existující prezentace zkontrolujte, zda je každý komentář typu [ModernComment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/), poté prozkoumejte [ModernComment::getShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/gettextselectionlength/) a [ModernComment::getStatus](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/getstatus/). `null` tvar označuje komentář na úrovni snímku. Pro ukotvení k [AutoShape] metody výběru textu identifikují odpovídající rozsah v textovém rámci tvaru.

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

## **Odstranit komentáře**

### **Odstranit všechny komentáře a autory komentářů**

Následující příklad ukazuje, jak odstranit všechny komentáře a autory komentářů z prezentace:

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

### **Odstranit konkrétní komentáře**

Následující příklad ukazuje, jak odstranit konkrétní komentáře ze snímku:

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

## **Často kladené otázky**

**Podporuje Aspose.Slides stav Vyřešeno pro moderní komentáře?**

Ano. Metody [ModernComment::getStatus](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/getstatus/) a [ModernComment::setStatus](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncomment/setstatus/) přistupují k hodnotě typu [ModernCommentStatus](https://reference.aspose.com/slides/cs/php-java/aspose.slides/moderncommentstatus/), včetně `Resolved`. Stav je uložen v prezentaci a lze jej znovu přečíst po opětovném otevření souboru.

**Podporují se vlákna diskuzí (řetězce odpovědí) a existuje omezení hloubky vnoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/comment/getparentcomment/), což umožňuje řetězce odpovědí. API nedefinuje konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice značky je definována pomocí souřadnic s desetinnou čárkou v souřadnicovém systému snímku, což vám umožňuje ji přesně umístit na snímek.