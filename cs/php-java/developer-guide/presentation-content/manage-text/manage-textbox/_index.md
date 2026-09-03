---
title: Správa textových polí v prezentacích pomocí PHP
linktitle: Spravovat textové pole
type: docs
weight: 20
url: /cs/php-java/manage-textbox/
keywords:
- textové pole
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat textový sloupec
- přidat hyperodkaz
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvořit, identifikovat, formátovat a aktualizovat textová pole v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Javu."
---
## **Úvod**

V Aspose.Slides pro PHP prostřednictvím Javy je text snímku uložen v textových rámečcích, které patří k tvarům. Třída [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) představuje nejčastější tvar obsahující text a zpřístupňuje jeho text prostřednictvím metody [AutoShape::getTextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Poznámka" %}}
Každý automatický tvar je odvozen od třídy [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/), ale ne každý tvar je automatický tvar nebo podporuje textový rámec. Při zpracování existující prezentace použijte `java_instanceof` k ověření, že tvar je [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) před získáním přístupu k jeho textu.
{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole přidejte automatický tvar na snímek, přidejte text do jeho textového rámce a uložte prezentaci. Následující příklad vytvoří obdélníkové textové pole:

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

Souřadnice a rozměry předávané metodě [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addAutoShape) jsou měřeny v bodech. [AutoShape::addTextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/#addTextFrame) inicializuje textový rámec s dodaným textem.

## **Kontrola, zda jde o tvar textového pole**

Použijte metodu [AutoShape::isTextBox](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/#isTextBox) k určení, zda je automatický tvar považován za textové pole. To je užitečné, když prezentace obsahuje jak textové, tak čistě grafické automatické tvary.

![Textové pole a tvar](istextbox.png)

Následující příklad prozkoumá každý automatický tvar v prezentaci:

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

Nově přidaný automatický tvar se nepovažuje za textové pole, dokud neobsahuje neprázdný text. Text můžete zadat pomocí [AutoShape::addTextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/#addTextFrame) nebo [TextFrame::setText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#setText). Přidání nebo přiřazení prázdného řetězce způsobí, že [AutoShape::isTextBox](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/#isTextBox) vrátí `false`:

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

První dva volání vypíšou `true`; poslední dvě vypíšou `false`.

## **Nalezení tvaru, který vlastní textový rámec**

Obecný kód pro zpracování textu může získat [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) aniž by věděl, který objekt prezentace jej obsahuje. Použijte jen pro čtení metodu [TextFrame::getParentShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParentShape) k návratu k jeho vlastnickému [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/).

Pro textový rámec vlastněný automatickým tvarem nebo jiným tvarem obsahujícím text metoda [TextFrame::getParentShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParentShape) vrací vlastníka a [TextFrame::getParentCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParentCell) vrací `null`. Před přístupem zkontrolujte vrácenou hodnotu pomocí `java_is_null`. Pro identifikaci jak tvarových, tak buňkových vlastníků, včetně tvarů spojených se uzly SmartArt, viz [Search and Replace Text](/slides/cs/php-java/search-and-replace-text/).

## **Přidání sloupců do textového pole**

Metoda [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setColumnCount) rozdělí textový rámec do sloupců, zatímco [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setColumnSpacing) nastaví mezeru mezi sloupci v bodech. Obě nastavení patří do [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/) a lze je změnit přes textový rámec existujícího textového pole. Text se přetéká mezi sloupci uvnitř stejného tvaru; nepřechází do jiného tvaru.

Následující příklad vytvoří třísloupcové textové pole s 10 body mezi sloupci, uloží prezentaci a načte uložená nastavení ze výstupního souboru:

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

## **Extrahování textu z jednotlivých sloupců**

Použijte [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#splitTextByColumns) k získání textu přiřazeného každému vizuálnímu sloupci v existujícím textovém rámci. Metoda vrací jeden řetězec pro každý sloupec ve sloupcovém pořadí čtení. Jednosloupcový textový rámec vrátí pole s jedním prvkem a prázdný sloupec je reprezentován prázdným řetězcem. Řetězce obsahují pouze prostý text; formátování na úrovni částí není zachováno.

Je to užitečné, když potřebujete:
- Extrahovat text při zachování sloupcového pořadí čtení.
- Indexovat nebo porovnat obsah více sloupcových snímků.
- Exportovat každý sloupec do samostatného souboru, databázového pole nebo jiného cíle.
- Zkontrolovat, jak je text přerozdělen po změně počtu sloupců pomocí [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setColumnCount), mezery pomocí [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setColumnSpacing), písma nebo velikosti textového rámce.

Metoda hlásí text rozdělený v aktuálním [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/); automaticky netvoří tok textu mezi samostatnými tvary nebo textovými poli. Rozdělení do sloupců může záviset na dostupných fontech a dalších nastaveních rozložení textu, takže se ujistěte, že požadované fonty jsou k dispozici, když jsou důležité konzistentní výsledky.

Následující příklad načte prezentaci, najde první více sloupcový automatický tvar s textovým rámcem, přečte jeho nastavený počet sloupců a zapíše text z každého sloupce do samostatného souboru. Tvary, které neposkytují textový rámec, jsou přeskočeny.

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

## **Aktualizace textu**

Aby bylo možné aktualizovat text v celé prezentaci, projděte snímky a tvary, vyberte automatické tvary a poté upravte jejich textové části. Práce na úrovni částí vám umožní měnit jak text, tak formátování znaků.

Následující příklad nahradí každé výskyt `years` za `months` v textu automatických tvarů a každou dotčenou část zvýrazní tučným stylem:

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

Tento průchod aktualizuje text pouze v automatických tvarech. Text uložený v tabulkách, grafech, SmartArt nebo seskupených tvarech vyžaduje průchod jejich vlastních kolekcí.

## **Přidání textového pole s hyperodkazem**

Hyperodkaz může být přiřazen konkrétní textové části, takže pouze tento text funguje jako klikací odkaz. Použijte [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) k přiřazení části k externí URL.

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

## **Často kladené otázky**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem na hlavním nebo rozložení snímku?**

Zástupce může dědit svou pozici a formátování z [master slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/) nebo [layout slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/). Běžné textové pole je nezávislý tvar na snímku, kde bylo vytvořeno, a při změně rozvržení nezíská chování zástupce.

**Jak mohu nahradit text, aniž bych změnil text v grafech, tabulkách nebo SmartArt?**

Omezte průchod na objekty [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) jak je ukázáno v příkladu Aktualizace textu. Grafy, tabulky a SmartArt ukládají text ve svých vlastních modelových objektech, takže nejsou tímto cyklem upraveny.