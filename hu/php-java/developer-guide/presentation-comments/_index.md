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
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for PHP via Java segítségével: adjon hozzá, olvassa, szerkessze, válaszoljon, és távolítson el megjegyzéseket PowerPoint prezentációkban gyorsan és könnyen."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a prezentációs megjegyzések az Aspose.Slides for PHP via Java segítségével. Bemutatja a megjegyzésekkel kapcsolatos fő típusokat, és demonstrálja, hogyan lehet megjegyzéseket hozzáadni a diákhoz, létező megjegyzéseket elérni, válaszokkal és modern megjegyzésekkel dolgozni, valamint megjegyzéseket eltávolítani egy prezentációból.

A példák a PowerPointban gyakran előforduló felülvizsgálati és együttműködési forgatókönyveket fedik le, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, a válaszláncok felépítését, valamint a kiválasztott megjegyzések vagy az összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztásakor megjelenik a szövege és a kapcsolódó beszélgetés.

Ahhoz, hogy a megjegyzések megjelenjenek vagy el legyenek rejtve a prezentáció megnyitásakor anélkül, hogy magukat a megjegyzéseket módosítanánk, lásd a [Show or Hide Comments When Opening a Presentation](/slides/hu/php-java/presentation-view-properties/) cikket.

## **Miért adjunk megjegyzéseket a prezentációkhoz?**

Megjegyzésekkel visszajelzést adhat és együttműködhet kollégáival a prezentációk felülvizsgálata során.

Az Aspose.Slides for PHP via Java a következő API-kat biztosítja a megjegyzésekkel való munkához:

* A [Presentáció](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztály, amely hozzáférést biztosít a prezentáció megjegyzés‑szerzőihez.
* A [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) osztály, amely egy adott szerzőhöz tartozó megjegyzéseket képviseli.
* A [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) osztály, amely információkat nyújt egy megjegyzésről, beleértve a szerzőt, a létrehozás időpontját, a pozíciót és a szöveget.
* A [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) osztály, amely információkat nyújt egy szerzőről, beleértve a nevét, a monogramját és a kapcsolódó megjegyzéseket.

## **Dia megjegyzések hozzáadása**

A példa két diát hoz létre, és egy megjegyzés‑szerzőt regisztrál a [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) segítségével. A [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) használatával egy megjegyzést helyez el minden dián, majd a [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) hívással lekéri az első dia megjegyzéseit az adott szerző számára. A konzol kétszer jeleníti meg az első megjegyzés szövegét, demonstrálva a hozzáférést mind a diához, mind a szerzőhöz, és a mentett prezentáció mindkét megjegyzést tartalmazza.

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

## **Megjegyzés‑szerző keresése vagy létrehozása**

Amikor egy automatizált felülvizsgálat többször dolgozza fel ugyanazt a prezentációt, a [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) által visszaadott gyűjteményben kell keresni, mielőtt szerzőt adna hozzá. A [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) mind a nevet, mind a monogramot egyezteti, és a megfelelő szerzőket tartalmazó tömböt ad vissza, vagy egy üres tömböt, ha nincs egyezés. Ezzel szemben a [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) csak a nevet keresi, a monogramtól függetlenül. Ha a [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) már meglévő nevet és monogramot ad meg a gyűjteményben, kivételt dob.

A példa egy legalább egy diát tartalmazó prezentációs fájlt igényel. Két iteráció során újra felhasználja az első egyező szerzőt, vagy csak akkor hoz létre újat, ha a lekérdezés üres. Ha több egyezés van, az első tömb‑elemet választja, anélkül, hogy egyesítené vagy eltávolítaná a többi szerzőt. Ezután a [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) hívással hozzáadja a megjegyzést a kiválasztott szerzőhöz, és menti a prezentációt. A második iteráció megnyitja az első iteráció kimenetét, és megismétli a műveletet.

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

A második iteráció egy újabb megjegyzést ad hozzá anélkül, hogy új szerzőt hozna létre, vagy a meglévő megjegyzéseket eltávolítaná. A végleges fájl, `review_pass_2.pptx`, tartalmazza az új megjegyzéseket az eredeti megjegyzésekkel együtt. A szerző újbóli felhasználása nem szűri ki a duplikált megjegyzéseket: a többszöri hozzáadás elkerüléséhez külön duplikátum‑detektálást kell megvalósítani a hozzáadás előtt.

## **Dia megjegyzések elérése**

A példa megnyit egy meglévő prezentációt, és beolvassa a [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) által visszaadott gyűjteményt. Minden szerző esetén végigjárja a [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) által visszaadott gyűjteményt, és kiírja a dia számát, a megjegyzés szövegét, a szerző nevét és a létrehozási időt. A bemeneti prezentációnak tartalmaznia kell megjegyzéseket ahhoz, hogy konzol kimenet jöjjön létre.

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

Egy szülő‑megjegyzés az eredeti megjegyzés a válaszhierarchia tetején. A [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) és a [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) metódusok lehetővé teszik a szülő megjegyzés lekérését vagy beállítását.

A példa két szerzőtől származó megjegyzéseket hoz létre, és a [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) segítségével felépíti a válaszokat, beleértve egy választ egy másik válaszra is. A `null` érték átadása a [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) hívásnak az összes szerző megjegyzéseit adja vissza; a konzol minden bejegyzést a válaszhierarchiában elfoglalt mélységnek megfelelően beljebb húz. A példa elmenti a teljes beszélgetést, a [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) metódus hívásával eltávolítja az első gyökér‑megjegyzést, majd egy második prezentációt ment, amelyből ez a megjegyzés és a válaszai hiányoznak.

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
* Ha a [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) metódust használja egy megjegyzés törlésére, a megjegyzéshez tartozó összes válasz is törlődik.
* Ha a [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) körkörös hivatkozást hoz létre, egy [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/) kivételt dob.
{{% /alert %}}

## **Modern megjegyzések hozzáadása**

A modern megjegyzések a diára, egy konkrét alakra vagy egy AutoShape szöveg‑tartományára hivatkozhatnak. A [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) metódus egy [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) argumentumot is elfogad a dia és a megjegyzés‑jelölő koordinátái mellett.

Ha a shape argumentum `null`, a megjegyzés dia‑szintű megjegyzés lesz. A jelölő a megadott koordinátákkal van elhelyezve, de nem kapcsolódik konkrét alakhoz, ezért a [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) `null`‑t ad vissza. Ha egy [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) van megadva, a megjegyzés ehhez az alakhoz van rögzítve. A koordináták továbbra is a megjegyzés‑jelölő pozícióját határozzák meg a dián, míg az alakhoz tartozás a [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) segítségével kérdezhető le.

### **Modern megjegyzés rögzítése egy alakhoz**

A példa kétszer hívja a [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) metódust: egyszer egy `null` alakgal dia‑szintű megjegyzéshez, és egyszer egy téglalappal, mint rögzítési pont. A [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) kiírása `true`‑t ad a dia‑szintű megjegyzés `null` ellenőrzésére, és a „Revenue title” szöveget az rögzített megjegyzéshez. Mindkét megjegyzés a prezentációval együtt kerül mentésre.

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

### **Megjegyzések rögzítése különböző alak‑típusokhoz**

Bármely, a [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) osztály által reprezentált dia‑objektum használható alak‑rögzítésként. Gyakori példák a [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), a [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), a [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), a [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) és a [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) példányok, például diagramok.

A példa a [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) metódust használja, hogy megjegyzést társítson öt alak‑típushoz: egy AutoShape‑hoz, egy képkerethez, egy csoporthoz, egy összekötőhöz és egy diagramhoz. A kép beágyazott képadatokat használ, ezért nincs szükség külső képre. Minden megjegyzés saját jelölőpozícióval rendelkezik, és a mentett prezentáció megőrzi az öt alak‑társítást.

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

Egy modern megjegyzés, amely egy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)-hez van kapcsolva, a [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) és a [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) metódusokkal határozza meg a kiválasztott szöveg kezdőpozícióját az alak szövegkeretében. A [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) és a [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) a kijelölés hosszát adja vissza vagy állítja be. Ezek az értékek közösen a megjegyzést egy konkrét szövegtartományhoz kötik az AutoShape‑ben.

A [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) és a [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) metódusok a [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) konstansai közül egy értéket adnak vissza:

- `NotDefined` — nincs meghatározott modern‑megjegyzés állapot.
- `Active` — a megjegyzés aktív.
- `Resolved` — a megjegyzés megoldott.
- `Closed` — a megjegyzés lezárt.

A példa egy modern megjegyzést rögzít a „quarterly revenue” szavakra egy téglalap szövegében. Kiszámítja a null‑alapú képszülő pozíciót a szövegből, és átadja a [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) metódusnak, majd a [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) segítségével beállítja a kijelölt karakterek számát. A [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) `Resolved` állapottal történő hívása után menti és újra megnyitja a prezentációt. A négy konzol‑ellenőrzés mindegyike `true`‑t kell, hogy kiírjon, ezzel igazolva, hogy az alak‑rögzítés, a szövegtartomány és az állapot megmaradt.

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

### **Meglévő modern megjegyzések vizsgálata**

A példa egy már létező prezentációt igényel, amely modern megjegyzéseket tartalmaz, és kiírja a szövegüket, állapotukat és rögzítési adataikat. A vizsgálathoz ellenőrizze, hogy a megjegyzés egy [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/), majd vizsgálja a [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), a [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), a [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) és a [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) metódusokat. Egy `null` alak dia‑szintű megjegyzést jelez. Egy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) rögzítés esetén a szöveg‑kijelölés‑metódusok meghatározzák a hozzárendelt tartományt az alak szövegkeretében.

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

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy egy prezentációból az összes megjegyzést és szerzőjüket eltávolítsa, vagy kiválasztott megjegyzéseket töröljön, miközben a többit meghagyja. Az alábbi példák mindkét megközelítést bemutatják, és mentik a frissített prezentációt.

### **Az összes megjegyzés és megjegyzés‑szerző eltávolítása**

A példa megnyit egy meglévő prezentációt, és minden szerzőhöz meghívja a [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) metódust, majd a [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) segítségével eltávolítja magukat a szerzőket. A mentett prezentáció sem megjegyzéseket, sem megjegyzés‑szerzőket nem tartalmaz. A törlés megfigyeléséhez használjon olyan prezentációt, amely megjegyzéseket tartalmaz.

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

### **Kiválasztott megjegyzések eltávolítása**

A példa két megjegyzést hoz létre egy dián, és a [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) segítségével megtalálja a szerzők megjegyzéseit. Az „comment 1” szövegű megjegyzéseket gyűjti össze, mielőtt meghívná a [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/) metódust, ezzel elkerülve a gyűjtemény módosítását a kiválasztás során. A mentett prezentáció csak a „comment 2” megjegyzést tartja meg.

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

**Támogatja-e az Aspose.Slides a modern megjegyzések megoldott állapotát?**

Igen. A [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) és a [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) egy [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) értéket ad vissza, amely tartalmazza a `Resolved` állapotot. Az állapot a prezentációban tárolódik, és a fájl újranyitása után újra leolvasható.

**Támogatottak-e a szálas beszélgetések (válaszláncok), és van-e beágyazási korlátozás?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/)‑ra, lehetővé téve a válaszláncokat. Az API nem definiál konkrét beágyazási mélységkorlátot.

**Milyen koordináta‑rendszerben van meghatározva egy megjegyzés‑jelölő pozíciója a dián?**

A jelölő pozíciója lebegőpontos koordinátákkal van definiálva a dia koordináta‑rendszerében, lehetővé téve a precíz elhelyezést a dián.