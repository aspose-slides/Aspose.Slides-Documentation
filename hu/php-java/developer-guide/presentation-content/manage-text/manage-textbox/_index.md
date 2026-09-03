---
title: Szövegdobozok kezelése prezentációkban PHP segítségével
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/php-java/manage-textbox/
keywords:
- szövegdoboz
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegdoboz létrehozása
- szövegdoboz ellenőrzése
- szövegoszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Szövegdobozok létrehozása, azonosítása, formázása és frissítése PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java használatával."
---
## **Bevezetés**

Az Aspose.Slides for PHP via Java esetében a dia szövegét szövegkeretekben tárolják, amelyek alakzatokhoz tartoznak. Az [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) osztály a leggyakoribb szöveget tartalmazó alakzatot képviseli, és a szöveget a [AutoShape::getTextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/#getTextFrame) metóduson keresztül teszi elérhetővé.

{{% alert color="info" title="Note" %}}
Minden automatikus alakzat a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) osztályból származik, de nem minden alakzat automatikus alakzat, vagy támogatja a szövegkeretet. Egy meglévő prezentáció feldolgozásakor használja a `java_instanceof`-t, hogy ellenőrizze, egy alakzat [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) típusú-e, mielőtt hozzáférne a szövegéhez.
{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

Szövegdoboz létrehozásához adjon egy automatikus alakzatot a diára, szúrja be a szöveget a szövegkeretébe, és mentse a prezentációt. Az alábbi példa egy téglalap alakú szövegdobozt hoz létre:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addAutoShape) metódusnak átadott koordinátákat és méreteket pontban mérik. Az [AutoShape::addTextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/#addTextFrame) a szövegkeretet a megadott szöveggel inicializálja.

## **Ellenőrzés szövegdoboz alakzatra**

Használja az [AutoShape::isTextBox](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/#isTextBox) metódust annak meghatározására, hogy egy automatikus alakzat szövegdobozként van-e kezelve. Ez akkor hasznos, ha egy prezentáció szöveget tartalmazó és kizárólag grafikus automatikus alakzatokat is tartalmaz.

![Egy szövegdoboz és egy alakzat](istextbox.png)

Az alábbi példa minden automatikus alakzatot vizsgál meg egy prezentációban:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Az újonnan hozzáadott automatikus alakzat nem tekinthető szövegdoboznak, amíg nem tartalmaz nem üres szöveget. A szöveget megadhatja az [AutoShape::addTextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/#addTextFrame) vagy a [TextFrame::setText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#setText) segítségével. Üres karakterlánc hozzáadása vagy hozzárendelése azt eredményezi, hogy az [AutoShape::isTextBox](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/#isTextBox) `false` értékkel tér vissza:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Az első két hívás `true`-t, az utolsó két hívás `false`-t ír ki.

## **A szövegkeretet birtokló alakzat megtalálása**

Általános szövegfeldolgozó kód kaphat egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) objektumot anélkül, hogy tudná, melyik prezentációs objektum tartalmazza. Használja az csak olvasható [TextFrame::getParentShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentShape) metódust, hogy visszalépjen a tulajdonos [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) objektumra.

Egy automatikus alakzat vagy más szöveget tartalmazó alakzat által birtokolt szövegkeret esetén a [TextFrame::getParentShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentShape) a tulajdonost adja vissza, míg a [TextFrame::getParentCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentCell) `null`-t ad. A visszakapott értéket ellenőrizze a `java_is_null` használatával, mielőtt hozzáférne. A forma és táblacella tulajdonosok, beleértve a SmartArt csomópontokhoz kapcsolódó alakzatok azonosításához lásd a [Search and Replace Text](/slides/hu/php-java/search-and-replace-text/) oldalt.

## **Oszlopok hozzáadása egy szövegdobozhoz**

A [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setColumnCount) metódus oszlopokra osztja a szövegkeretet, míg a [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setColumnSpacing) a pontban megadott oszloptávolságot állítja be. Mindkét beállítás a [TextFrameFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/) része, és egy meglévő szövegdoboz szövegkeretén keresztül módosítható. A szöveg áramlik az oszlopok között ugyanazon alakzaton belül; nem folytatódik egy másik alakzatba.

Az alábbi példa egy háromoszlopos szövegdobozt hoz létre 10 pont oszloptávolsággal, menti a prezentációt, és visszaolvassa a tárolt beállításokat a kimeneti fájlból:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Szöveg kinyerése egyes oszlopokból**

Használja a [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#splitTextByColumns) metódust, hogy egy meglévő szövegkeretben minden vizuális oszlophoz hozzárendelt szöveget lekérje. A metódus minden oszlophoz egy karakterláncot ad vissza, oszlop-alapú olvasási sorrendben. Egy egyoszlopos szövegkeret egy elemmel rendelkező tömböt ad, egy üres oszlop pedig egy üres karakterlánc lesz. A karakterláncok csak egyszerű szöveget tartalmaznak; a részlet-szintű formázás nem marad meg.

Ez akkor hasznos, ha a következőkre van szükség:
- Szöveg kinyerése az oszloptáblázott olvasási sorrend megőrzésével.
- Többoszlopos diák tartalmának indexelése vagy összehasonlítása.
- Minden oszlop exportálása külön fájlba, adatbázismezőbe vagy más célhelyre.
- Ellenőrizze, hogyan oszlik újra a szöveg az oszlopszám ([TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setColumnCount)), a távolság ([TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/#setColumnSpacing)), a betűtípus vagy a szövegkeret méretének módosítása után.

A metódus a jelenlegi [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) keretben elosztott szöveget jelenti; nem automatikusan tölti át a szöveget különálló alakzatok vagy szövegdobozok között. Az oszlopeloszlás függhet a rendelkezésre álló betűtípusoktól és egyéb szövegelrendezési beállításoktól, ezért ügyeljen arra, hogy a szükséges betűtípusok elérhetők legyenek, ha konzisztens eredmények fontosak.

Az alábbi példa betölt egy prezentációt, megtalálja az első többoszlopos automatikus alakzatot szövegkerettel, kiolvassa a beállított oszlopszámot, és minden oszlop szövegét külön fájlba írja. Azok az alakzatok, amelyek nem rendelkeznek szövegkerettel, átugorásra kerülnek.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Szöveg frissítése**

A szöveg frissítéséhez egy prezentációban járja végig a diák és alakzatok sorozatát, válassza ki az automatikus alakzatokat, majd szerkessze azok szövegrétegeit. A részlet-szintű munka lehetővé teszi a szöveg és a karakterformázás egyidejű módosítását.

Az alábbi példa minden `years` előfordulást `months`-re cserél az automatikus alakzatok szövegében, és minden érintett részt félkövérre állít:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ez az átfutás csak az automatikus alakzatok szövegét frissíti. A táblákban, diagramokban, SmartArt-ban vagy csoportosított alakzatokban tárolt szöveg az adott objektumok saját gyűjteményének bejárását igényli.

## **Szövegdoboz hozzáadása hiperhivatkozással**

A hiperhivatkozás egy adott szövegrétegre rendeltethető, így csak az a szöveg lesz kattintható link. Használja a [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) metódust, hogy a részt egy külső URL-re kapcsolja.

Az alábbi példa linkelt szöveget hoz létre és elmenti egy prezentációba:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Mi a különbség egy szövegdoboz és egy szöveghelyőrző között egy fő- vagy elrendezési dián?**

Egy [placeholder](/slides/hu/php-java/manage-placeholder/) örökölheti pozícióját és formázását egy [master slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) vagy [layout slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/) részéről. Egy szabályos szövegdoboz egy önálló alakzat a dián, ahol létrejött, és nem kap helyőrző viselkedést, amikor az elrendezés változik.

**Hogyan cserélhetem ki a szöveget anélkül, hogy a diagramok, táblák vagy SmartArt szövegét módosítanám?**

Szűkítse a bejárást csak az [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) objektumokra, ahogyan az a Szöveg frissítése példában látható. A diagramok, táblák és a SmartArt saját objektummodelljeikben tárolják a szöveget, ezért az a ciklus nem módosítja őket.