---
title: Hantera textrutor i presentationer med PHP
linktitle: Hantera textruta
type: docs
weight: 20
url: /sv/php-java/manage-textbox/
keywords:
- textruta
- textram
- lägga till text
- uppdatera text
- skapa textruta
- kontrollera textruta
- lägga till textkolumn
- lägga till hyperlänk
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa, identifiera, formatera och uppdatera textrutor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java."
---
## **Introduktion**

I Aspose.Slides för PHP via Java lagras bildtext i textramar som tillhör former. Klassen [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) representerar den vanligaste textbärande formen och exponerar dess text via metoden [AutoShape::getTextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Varje autoform ärver från [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/), men inte varje form är en autoform eller stöder en textram. När du bearbetar en befintlig presentation, använd `java_instanceof` för att kontrollera att en form är en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) innan du får åtkomst till dess text.
{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta, lägg till en autoform på en bild, lägg till text i dess textram och spara presentationen. Följande exempel skapar en rektangulär textruta:

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

Koordinaterna och dimensionerna som skickas till [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addAutoShape) mäts i punkter. [AutoShape::addTextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/#addTextFrame) initierar textramen med den angivna texten.

## **Kontrollera om en form är en textruta**

Använd metoden [AutoShape::isTextBox](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/#isTextBox) för att avgöra om en autoform behandlas som en textruta. Detta är användbart när en presentation innehåller både textbärande och enbart grafiska autoformer.

![En textruta och en form](istextbox.png)

Följande exempel inspekterar varje autoform i en presentation:

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

En nyligen tillagd autoform betraktas inte som en textruta förrän den innehåller icke‑tom text. Du kan tillhandahålla den texten genom [AutoShape::addTextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/#addTextFrame) eller [TextFrame::setText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#setText). Att lägga till eller tilldela en tom sträng får [AutoShape::isTextBox](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/#isTextBox) att returnera `false`:

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

De två första anropen skriver ut `true`; de två sista skriver ut `false`.

## **Hitta formen som äger en textram**

Generisk text‑behandlingskod kan få en [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) utan att veta vilket presentationsobjekt som innehåller den. Använd den skrivskyddade metoden [TextFrame::getParentShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#getParentShape) för att navigera tillbaka till dess ägande [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/).

För en textram som ägs av en autoform eller en annan textbärande form returnerar [TextFrame::getParentShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#getParentShape) ägaren och [TextFrame::getParentCell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#getParentCell) returnerar `null`. Kontrollera det returnerade värdet med `java_is_null` innan du får åtkomst till det. För att identifiera både form‑ och tabellcellägare, inklusive former som är associerade med SmartArt‑noder, se [Search and Replace Text](/slides/sv/php-java/search-and-replace-text/).

## **Lägg till kolumner i en textruta**

Metoden [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/#setColumnCount) delar upp textramen i kolumner, medan [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/#setColumnSpacing) anger avståndet mellan kolumner i punkter. Båda inställningarna tillhör [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/) och kan ändras via textramen i en befintlig textruta. Text flödar mellan kolumner inom samma form; den fortsätter inte i en annan form.

Följande exempel skapar en textruta med tre kolumner och 10 punkter mellan kolumnerna, sparar presentationen och läser tillbaka de lagrade inställningarna från utdatafilen:

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

## **Extrahera text från enskilda kolumner**

Använd [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#splitTextByColumns) för att hämta den text som tilldelats varje visuell kolumn i en befintlig textram. Metoden returnerar en sträng för varje kolumn i kolumnbaserad läsordning. En enkellkolumns‑textram ger en array med ett element, och en tom kolumn representeras av en tom sträng. Strängarna innehåller endast vanlig text; formatering på portionsnivå bevaras inte.

Detta är användbart när du behöver:

- Extrahera text samtidigt som du bevarar dess kolumnbaserade läsordning.
- Indexera eller jämföra innehållet i flerkolumns‑bilder.
- Exportera varje kolumn till en separat fil, databassfält eller annan destination.
- Inspektera hur text omfördelas efter att du ändrat kolumnantalet med [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/#setColumnCount), avståndet med [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/#setColumnSpacing), typsnittet eller storleken på textramen.

Metoden rapporterar den text som distribueras inom den aktuella [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/); den flödar inte automatiskt text mellan separata former eller textrutor. Kolumndistribution kan bero på tillgängliga teckensnitt och andra layoutinställningar, så se till att nödvändiga teckensnitt finns tillgängliga när konsekventa resultat är viktiga.

Följande exempel laddar en presentation, hittar den första flerkolumns‑autoformen med en textram, läser dess konfigurerade kolumnantal och skriver texten från varje kolumn till en separat fil. Former som inte tillhandahåller en textram hoppas över.

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

## **Uppdatera text**

För att uppdatera text i hela en presentation, iterera genom bilderna och formerna, välj autoformer och redigera sedan deras textportioner. Att arbeta på portionsnivå låter dig ändra både text och teckenformatering.

Följande exempel ersätter varje förekomst av `years` med `months` i autoform‑text och gör varje drabbat avsnitt fetstilat:

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

Denna genomsökning uppdaterar endast text i autoformer. Text som lagras i tabeller, diagram, SmartArt eller grupperade former kräver en traversal av respektive objekts egna samlingar.

## **Lägg till en textruta med hyperlänk**

En hyperlänk kan tilldelas en specifik textportion, så att endast den texten fungerar som den klickbara länken. Använd [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) för att koppla portionen till en extern URL.

Följande exempel skapar länkad text och sparar den i en presentation:

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

## **FAQ**

**Vad är skillnaden mellan en textruta och en textplatshållare på en master‑ eller layoutbild?**

En [placeholder](/slides/sv/php-java/manage-placeholder/) kan ärva sin position och formatering från en [master slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/) eller [layout slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/). En vanlig textruta är en självständig form på den bild där den skapades och får inte platshållarbeteende när layouten ändras.

**Hur kan jag ersätta text utan att ändra text i diagram, tabeller eller SmartArt?**

Begränsa genomsökningen till [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/)‑objekt, som visas i exemplet Uppdatera text. Diagram, tabeller och SmartArt lagrar text i sina egna objektsmodeller, så de modifieras inte av den loopen.