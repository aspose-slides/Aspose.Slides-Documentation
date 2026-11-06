---
title: Správa komentářů v prezentaci v PHP
linktitle: Komentáře v prezentaci
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
- přístup k komentáři
- upravit komentář
- odpověď na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte komentáře v prezentacích pomocí Aspose.Slides pro PHP prostřednictvím Javy: přidávejte, čtěte, upravujte, odpovídejte a odstraňujte komentáře v prezentacích PowerPoint rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentaci pomocí Aspose.Slides pro PHP prostřednictvím Javy. Představuje hlavní typy související s komentáři a ukazuje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi a moderními komentáři a odstraňovat komentáře z prezentace.

Příklady pokrývají běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazení komentářů autorům, čtení textu a metadat komentáře, vytváření řetězců odpovědí a odstraňování vybraných komentářů nebo všech komentářů.

V PowerPointu se komentáře zobrazují jako anotace na snímcích. Vybráním komentáře se zobrazí jeho text a související diskuze.

Chcete-li požadovat, aby byly komentáře při otevření prezentace zobrazeny nebo skryty, aniž byste měnili samotné komentáře, viz [Zobrazit nebo skrýt komentáře při otevření prezentace](/slides/cs/php-java/presentation-view-properties/).

## **Proč přidávat komentáře do prezentací?**

Komentáře můžete použít k poskytování zpětné vazby a spolupráci s kolegy při revizi prezentací.

Aspose.Slides pro PHP prostřednictvím Javy poskytuje následující API pro práci s komentáři:

* The [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class, která poskytuje přístup k autorům komentářů v prezentaci.
* The [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) class, která představuje komentáře přiřazené konkrétnímu autorovi.
* The [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) class, která poskytuje informace o komentáři, včetně jeho autora, času vytvoření, pozice a textu.
* The [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) class, která poskytuje informace o autorovi, včetně jeho jména, iniciál a přiřazených komentářů.

## **Přidat komentáře ke snímkům**

Příklad vytvoří dva snímky a zaregistruje autora komentáře pomocí [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/). Použije [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) k umístění jednoho komentáře na každý snímek, poté získá komentáře prvního snímku pro toho autora pomocí [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/). Konzole dvakrát zobrazí text prvního komentáře, čímž demonstruje přístup jak přes snímek, tak přes autora, a uložená prezentace obsahuje oba komentáře.

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

## **Najít nebo vytvořit autora komentáře**

Když automatizovaná revize opakovaně zpracovává stejnou prezentaci, vyhledejte v kolekci vrácené metodou [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) před přidáním autora. Metoda [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) porovnává jak jméno, tak iniciály a vrací pole odpovídajících autorů nebo prázdné pole, pokud neexistují žádné shody. Naopak [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) vyhledává pouze podle jména, nezávisle na iniciálech. Volání [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) s již v kolekci existujícím jménem a iniciálami vyvolá výjimku.

Příklad vyžaduje soubor prezentace s alespoň jedním snímkem. Každý ze dvou průchodů znovu použije prvního odpovídajícího autora nebo jej vytvoří pouze v případě, že výsledek je prázdný. Pokud existuje více shod, vybere první prvek pole bez slučování či odstraňování ostatních autorů. Poté zavolá [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) pro vybraného autora a uloží prezentaci. Druhý průchod otevře výstup prvního průchodu a operaci zopakuje.

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

Druhý průchod přidá další komentář bez vytvoření dalšího autora nebo odstranění existujících komentářů. Konečný soubor `review_pass_2.pptx` obsahuje oba nové komentáře vedle všech původních komentářů. Znovupoužití autora nededuplicuje komentáře: pro zabránění opakovanému přidávání stejných komentářů implementujte samostatné detekování duplicit před jejich přidáním.

## **Přistupovat ke komentářům na snímcích**

Příklad otevře existující prezentaci a načte kolekci vrácenou metodou [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/). Pro každého autora iteruje přes kolekci vrácenou metodou [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) a vypíše číslo snímku, text komentáře, jméno autora a čas vytvoření. Vstupní prezentace musí obsahovat komentáře, aby byl vytvořen výstup v konzoli.

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

Komentář rodič je původní komentář na vrcholu hierarchie odpovědí. Metody [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) a [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) umožňují získat nebo nastavit rodiče komentáře.

Příklad vytvoří komentáře od dvou autorů a použije [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) k vytvoření odpovědí, včetně odpovědi na další odpověď. Předáním `null` metodě [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) se získají komentáře od všech autorů; konzole odsazuje každou položku podle hloubky v hierarchii odpovědí. Příklad uloží kompletní diskusi, zavolá [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) na první kořenový komentář a uloží druhou prezentaci, kde jsou tento komentář a jeho odpovědi odstraněny.

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
* Když je metoda [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) použita k smazání komentáře, jsou také smazány všechny odpovědi na tento komentář.
* Pokud metoda [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) vytvoří kruhový odkaz, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Přidat moderní komentáře**

Moderní komentáře mohou být přiřazeny přímo ke snímku, ke konkrétnímu tvaru nebo k textovému rozsahu uvnitř AutoShape. Metoda [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) přijímá argument [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) kromě snímku a souřadnic značky komentáře.

Když je pro argument shape předáno `null`, jedná se o komentář na úrovni snímku. Jeho značka je umístěna podle zadaných souřadnic, ale není svázána s konkrétním tvarem, takže [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) vrací `null`. Když je předán objekt [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), je komentář ukotven k tomuto tvaru. Souřadnice i nadále definují pozici značky komentáře na snímku, zatímco spojení s tvarem lze získat pomocí [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/).

### **Ukotvit moderní komentář k tvaru**

Příklad dvakrát zavolá [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/): jednou s `null` tvarem pro komentář na úrovni snímku a podruhé s obdélníkem jako ukotvením. Čtením [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) se pro komentář na úrovni snímku vytiskne `true` a pro ukotvený komentář se vytiskne `Revenue title`. Oba komentáře jsou uloženy s prezentací.

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

Jakýkoli objekt snímku reprezentovaný třídou [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) může být použit jako ukotvení. Běžné příklady zahrnují [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) a instance [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) jako jsou grafy.

Příklad používá [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) k přiřazení komentáře každému z pěti typů tvarů: AutoShape, rámečku obrázku, skupině, spojce a grafu. Obrázek používá vložená data, takže není vyžadován externí soubor. Každý komentář má vlastní pozici značky a uložená prezentace zachovává všech pět ukotvení.

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

U moderního komentáře spojeného s [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) metody [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) a [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) získávají počáteční pozici vybraného textu v textovém rámci tvaru. Metody [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) a [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) získávají délku výběru. Tyto hodnoty společně spojují komentář s konkrétním textovým rozsahem uvnitř AutoShape.

Metody [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) a [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) přistupují k hodnotě ze konstant [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — není definován žádný konkrétní stav moderního komentáře.
- `Active` — komentář je aktivní.
- `Resolved` — komentář byl vyřešen.
- `Closed` — komentář je uzavřen.

Příklad ukotví moderní komentář k slovům „quarterly revenue“ v textu obdélníku. Vypočítá nulový index začátku výběru z textu a předá jej metodě [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/), poté použije [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) pro nastavení počtu vybraných znaků. Po volání [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) s hodnotou `Resolved` prezentaci uloží a znovu otevře. Čtyři kontroly v konzoli by měly každá vypsat `true`, což potvrzuje zachování ukotvení tvaru, textového rozsahu a stavu.

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

Příklad vyžaduje existující prezentaci obsahující moderní komentáře a vypisuje jejich text, stav a podrobnosti ukotvení. Pro kontrolu zjistěte, zda je každý komentář typu [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/), poté prozkoumejte [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) a [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/). `null` tvar označuje komentář na úrovni snímku. U ukotvení k [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) metody výběru textu určují přidružený rozsah v textovém rámci tvaru.

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

Aspose.Slides pro PHP prostřednictvím Javy umožňuje odstranit všechny komentáře a jejich autory z prezentace nebo smazat vybrané komentáře při zachování ostatních. Následující příklady ukazují oba přístupy a ukládají aktualizovanou prezentaci.

### **Odstranit všechny komentáře a jejich autory**

Příklad otevře existující prezentaci a zavolá [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) pro každého autora, poté zavolá [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) pro odstranění samotných autorů. Uložená prezentace neobsahuje ani komentáře, ani jejich autory. Použijte prezentaci obsahující komentáře, abyste viděli odstranění.

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

Příklad vytvoří dva komentáře na jednom snímku a použije [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) k nalezení komentářů od každého autora. Shromáždí komentáře, jejichž text se rovná „comment 1“, před zavoláním [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/), aby se zabránilo změnám kolekce během výběru. Uložená prezentace zachová jen „comment 2“.

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

**Podporuje Aspose.Slides stav vyřešený pro moderní komentáře?**

Ano. Metody [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) a [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) přistupují k hodnotě [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/), včetně `Resolved`. Stav je uložen v prezentaci a lze jej znovu přečíst po opětovném otevření souboru.

**Jsou podporovány vlákna diskuzí (řetězce odpovědí) a existuje nějaký limit hloubky vnoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), což umožňuje řetězce odpovědí. API nedefinuje konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice značky je definována pomocí desetinných souřadnic v souřadnicovém systému snímku, což umožňuje přesné umístění na snímku.