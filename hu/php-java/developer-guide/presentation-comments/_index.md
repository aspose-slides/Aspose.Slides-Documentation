---
title: Prezentációs megjegyzések kezelése PHP-ben
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/php-java/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- prezentációs megjegyzések
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- megjegyzésre válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for PHP via Java segítségével: adjon hozzá, olvassa, szerkessze, válaszoljon és távolítsa el a megjegyzéseket PowerPoint prezentációkban gyorsan és egyszerűen."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan kezelhetők a prezentációs megjegyzések az Aspose.Slides for PHP via Java segítségével. Bemutatja a fő, a megjegyzésekkel kapcsolatos típusokat, és demonstrálja, hogyan adhatunk megjegyzéseket a diákhoz, hogyan érhetünk el meglévő megjegyzéseket, hogyan dolgozhatunk válaszokkal és modern megjegyzésekkel, valamint hogyan távolíthatók el a megjegyzések a prezentációból.

Az példák a PowerPoint általános felülvizsgálati és együttműködési forgatókönyveit fedik le, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, a válaszláncok építését és a kiválasztott vagy az összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti a szövegét és a kapcsolódó megbeszélést.

A megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor a megjegyzéseket módosítás nélkül, lásd [Megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor](/slides/hu/php-java/presentation-view-properties/).

## **Miért adjunk megjegyzéseket a prezentációkhoz?**

A megjegyzésekkel visszajelzést adhat és együttműködhet kollégáival a prezentációk felülvizsgálata során.

Az Aspose.Slides for PHP via Java a következő API-kat biztosítja a megjegyzésekkel való munkához:

* A [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály, amely hozzáférést biztosít a prezentáció megjegyzés‑szerzőihez.
* A [CommentCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commentcollection/) osztály, amely egy adott szerzőhöz kapcsolódó megjegyzéseket képviseli.
* A [Comment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/) osztály, amely információkat szolgáltat egy megjegyzésről, beleértve a szerzőt, a létrehozás időpontját, a pozíciót és a szöveget.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commentauthor/) osztály, amely információkat ad egy szerzőről, beleértve a nevét, a monogramját és a kapcsolódó megjegyzéseket.

## **Dia megjegyzések hozzáadása**

Az alábbi példa bemutatja, hogyan adhatunk megjegyzéseket a diákhoz egy PowerPoint‑prezentációban:

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

## **Dia megjegyzések elérése**

Az alábbi példa bemutatja, hogyan érhetünk el meglévő megjegyzéseket egy PowerPoint‑prezentációban:

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

## **Válasz a megjegyzésekre**

A szülő megjegyzés a válaszhierarchia csúcsán lévő eredeti megjegyzés. A [Comment::getParentComment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/getparentcomment/) és a [Comment::setParentComment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/setparentcomment/) metódusok lehetővé teszik egy megjegyzés szülőjének lekérését vagy beállítását.

Az alábbi példa bemutatja, hogyan adhatunk válaszokat, és hogyan vizsgálhatjuk meg a keletkezett megjegyzés‑hierarchiát:

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
* Ha a [Comment::remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/remove/) metódust használják egy megjegyzés törlésére, akkor a megjegyzéshez tartozó összes válasz is törlődik.
* Ha a [Comment::setParentComment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/setparentcomment/) körkörös hivatkozást hoz létre, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxeditexception/) kivétel kerül dobásra.
{{% /alert %}}

## **Modern megjegyzések hozzáadása**

A modern megjegyzések a diára, egy konkrét alakzatra vagy egy AutoShape‑on belüli szövegtartományra is hivatkozhatók. A [CommentCollection::addModernComment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commentcollection/addmoderncomment/) metódus a dián és a megjegyzés‑marker koordinátáin kívül egy [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) argumentumot is elfogad.

Ha a shape argumentumnak `null`‑t adunk, a megjegyzés dia‑szintű megjegyzés lesz. A marker a megadott koordináták alapján helyezkedik el, de nem kapcsolódik konkrét alakzathoz, ezért a [ModernComment::getShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/getshape/) `null`‑t ad vissza. Ha egy [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) kerül megadásra, a megjegyzés ahhoz az alakzathoz lesz rögzítve. A koordináták továbbra is meghatározzák a megjegyzés‑marker pozícióját a dián, míg az alakzathoz való kapcsolódás a [ModernComment::getShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/getshape/)‑on keresztül lekérhető.

### **Modern megjegyzés rögzítése egy alakzatra**

Az alábbi példa létrehoz egy dia‑szintű modern megjegyzést és egy konkrét AutoShape‑hez rögzített modern megjegyzést is. Ezután beolvassa az egyes megjegyzésekhez tartozó alakzatot.

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

### **Megjegyzések rögzítése különböző alakzattípusokra**

A [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) osztállyal reprezentált bármely diaobjektum használható alakzat‑ankérként. Gyakori példák: [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/hu/php-java/aspose.slides/connector/) és [GraphicalObject](https://reference.aspose.com/slides/hu/php-java/aspose.slides/graphicalobject/) például diagramok.

Az alábbi példa létrehoz több gyakori alakzattípust, és mindegyikhez modern megjegyzést kapcsol.

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

### **Megjegyzés rögzítése szöveghez és állapotának beállítása**

Egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)-hez kapcsolt modern megjegyzés esetén a [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/gettextselectionstart/) és a [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/settextselectionstart/) a kiválasztott szöveg kezdőpozícióját adja vissza az alakzat szövegkeretében. A [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/gettextselectionlength/) és a [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/settextselectionlength/) a kiválasztás hosszát adja vissza. Ezek az értékek együttesen egy adott szövegtartományhoz kötik a megjegyzést az AutoShape‑on belül.

A [ModernComment::getStatus](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/getstatus/) és a [ModernComment::setStatus](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/setstatus/) metódusok a [ModernCommentStatus](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncommentstatus/) konstansait használják:

- `NotDefined` — nincs meghatározott modern megjegyzés állapot.
- `Active` — a megjegyzés aktív.
- `Resolved` — a megjegyzés megoldott.
- `Closed` — a megjegyzés lezárt.

Az alábbi példa létrehoz egy alakzathoz rögzített modern megjegyzést, szövegkijelölést kapcsol hozzá, megoldottnak jelöli, elmenti a prezentációt, majd a fájl újbóli megnyitásakor ellenőrzi az értékeket.

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

### **Meglévő modern megjegyzések ellenőrzése**

Egy meglévő prezentáció ellenőrzéséhez ellenőrizze, hogy az egyes megjegyzések [ModernComment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/)‑ek‑e, majd vizsgálja meg a [ModernComment::getShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/getshape/), a [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/gettextselectionstart/), a [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/gettextselectionlength/) és a [ModernComment::getStatus](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/getstatus/) értékeket. Egy `null` alakzat dia‑szintű megjegyzést jelez. Egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/)‑ankér esetén a szövegkijelölés‑metódusok az alakzat szövegkeretében lévő tartományt határozzák meg.

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

## **Megjegyzések eltávolítása**

### **Minden megjegyzés és megjegyzés‑szerző eltávolítása**

Az alábbi példa bemutatja, hogyan távolíthatók el a prezentációból az összes megjegyzés és megjegyzés‑szerző:

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

### **Adott megjegyzések eltávolítása**

Az alábbi példa bemutatja, hogyan távolíthatók el a diáról konkrét megjegyzések:

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

## **GYIK**

**Támogatja-e az Aspose.Slides a megoldott állapotot a modern megjegyzésekhez?**

Igen. A [ModernComment::getStatus](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/getstatus/) és a [ModernComment::setStatus](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncomment/setstatus/) egy [ModernCommentStatus](https://reference.aspose.com/slides/hu/php-java/aspose.slides/moderncommentstatus/) értéket ad vissza, amely tartalmazza a `Resolved`‑t is. Az állapot a prezentációban tárolódik, és a fájl újranyitása után is kiolvasható.

**Támogatottak a szálas megbeszélések (válaszláncok), és van-e mélységkorlátozás?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/hu/php-java/aspose.slides/comment/getparentcomment/)‑re, ezáltal lehetővé téve a válaszláncokat. Az API nem határoz meg konkrét mélységkorlátot.

**Milyen koordináta‑rendszerben van definiálva a megjegyzés‑marker pozíciója a dián?**

A marker pozíciója lebegőpontos koordinátákkal van megadva a dia koordináta‑rendszerében, lehetővé téve a pontos elhelyezést a dián.