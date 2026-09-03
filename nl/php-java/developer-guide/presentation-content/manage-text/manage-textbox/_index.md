---
title: Beheer tekstvakken in presentaties met PHP
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/php-java/manage-textbox/
keywords:
- tekstvak
- tekstframe
- tekst toevoegen
- tekst bijwerken
- tekstvak maken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak, identificeer, formatteer en werk tekstvakken bij in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP via Java."
---
## **Inleiding**

In Aspose.Slides voor PHP via Java wordt de tekst van dia’s opgeslagen in tekstframes die bij vormen horen. De [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑klasse vertegenwoordigt de meest voorkomende tekstdragende vorm en geeft de tekst weer via de [AutoShape::getTextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/#getTextFrame)‑methode.

{{% alert color="info" title="Opmerking" %}}
Elke auto‑vorm is afgeleid van [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/), maar niet elke vorm is een auto‑vorm of ondersteunt een tekstframe. Bij het verwerken van een bestaande presentatie, gebruik `java_instanceof` om te controleren of een vorm een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) is voordat u de tekst benadert.
{{% /alert %}}

## **Een tekstvak maken op een dia**

Om een tekstvak te maken, voegt u een auto‑vorm toe aan een dia, voegt u tekst toe aan het tekstframe en slaat u de presentatie op. Het volgende voorbeeld maakt een rechthoekig tekstvak:

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

De coördinaten en afmetingen die aan [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addAutoShape) worden doorgegeven, worden gemeten in punten. [AutoShape::addTextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/#addTextFrame) initialiseert het tekstframe met de opgegeven tekst.

## **Controleren of een vorm een tekstvak is**

Gebruik de [AutoShape::isTextBox](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/#isTextBox)‑methode om te bepalen of een auto‑vorm wordt behandeld als een tekstvak. Dit is handig wanneer een presentatie zowel tekstdragende als puur grafische auto‑vormen bevat.

![Een tekstvak en een vorm](istextbox.png)

Het volgende voorbeeld inspecteert elke auto‑vorm in een presentatie:

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

Een nieuw toegevoegde auto‑vorm wordt pas als tekstvak beschouwd zodra deze niet‑lege tekst bevat. U kunt die tekst leveren via [AutoShape::addTextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/#addTextFrame) of [TextFrame::setText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#setText). Het toevoegen of toewijzen van een lege tekenreeks zorgt ervoor dat [AutoShape::isTextBox](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/#isTextBox) `false` teruggeeft:

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

De eerste twee aanroepen geven `true` weer; de laatste twee geven `false` weer.

## **De vorm vinden die een tekstframe bezit**

Generieke tekstverwerkingscode kan een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) ontvangen zonder te weten welk presentatie‑object het bevat. Gebruik de alleen‑lezen [TextFrame::getParentShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentShape)‑methode om terug te navigeren naar de bijbehorende [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/).

Voor een tekstframe dat eigendom is van een auto‑vorm of een andere tekstdragende vorm, retourneert [TextFrame::getParentShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentShape) de eigenaar en retourneert [TextFrame::getParentCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentCell) `null`. Controleer de geretourneerde waarde met `java_is_null` voordat u deze benadert. Om zowel vorm‑ als tabelcel‑eigenaars te identificeren, inclusief vormen die gekoppeld zijn aan SmartArt‑knopen, zie [Search and Replace Text](/slides/nl/php-java/search-and-replace-text/).

## **Kolommen toevoegen aan een tekstvak**

De [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setColumnCount)‑methode verdeelt het tekstframe in kolommen, terwijl [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setColumnSpacing) de tussenruimte tussen kolommen in punten instelt. Beide instellingen behoren tot [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/) en kunnen worden gewijzigd via het tekstframe van een bestaand tekstvak. Tekst stroomt opnieuw tussen kolommen binnen dezelfde vorm; het gaat niet door naar een andere vorm.

Het volgende voorbeeld maakt een drie‑koloms tekstvak met 10 punten tussen de kolommen, slaat de presentatie op en leest de opgeslagen instellingen terug uit het uitvoerbestand:

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

## **Tekst extraheren uit individuele kolommen**

Gebruik [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#splitTextByColumns) om de tekst op te halen die aan elke visuele kolom in een bestaand tekstframe is toegewezen. De methode geeft één tekenreeks terug voor elke kolom, in kolom‑gebaseerde leesvolgorde. Een één‑koloms tekstframe levert een array met één element op, en een lege kolom wordt weergegeven door een lege tekenreeks. De tekenreeksen bevatten alleen platte tekst; opgedeelde opmaak wordt niet behouden.

Dit is handig wanneer u moet:

- Tekst extraheren terwijl de kolomgerichte leesvolgorde behouden blijft.  
- De inhoud van dia’s met meerdere kolommen indexeren of vergelijken.  
- Elke kolom exporteren naar een apart bestand, databaseveld of andere bestemming.  
- Inspecteren hoe tekst opnieuw wordt verdeeld na het wijzigen van het kolomaantal met [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setColumnCount), de tussenruimte met [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setColumnSpacing), het lettertype of de grootte van het tekstframe.

De methode rapporteert de tekst die zich binnen het huidige [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) bevindt; ze laat tekst niet automatisch van de ene vorm of tekstvak naar de andere vloeien. Kolomverdeling kan afhangen van beschikbare lettertypen en andere tekstopmaak‑instellingen, dus zorg ervoor dat de benodigde lettertypen beschikbaar zijn wanneer consistente resultaten belangrijk zijn.

Het volgende voorbeeld laadt een presentatie, vindt de eerste multi‑koloms auto‑vorm met een tekstframe, leest het geconfigureerde kolomaantal en schrijft de tekst van elke kolom naar een apart bestand. Vormen die geen tekstframe bieden, worden overgeslagen.

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

## **Tekst bijwerken**

Om tekst door de gehele presentatie heen bij te werken, doorloopt u de dia’s en vormen, selecteert u auto‑vormen en bewerkt vervolgens hun tekstsegmenten. Werken op segmentniveau maakt het mogelijk zowel tekst als karakteropmaak te wijzigen.

Het volgende voorbeeld vervangt elke voorkomens van `years` door `months` in auto‑vorm‑tekst en maakt elk getroffen segment vet:

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

Deze traversering werkt tekst alleen bij in auto‑vormen. Tekst die is opgeslagen in tabellen, grafieken, SmartArt of gegroepeerde vormen vereist een traversering van de eigen collecties van die objecten.

## **Een tekstvak met een hyperlink toevoegen**

Een hyperlink kan aan een specifiek tekstsegment worden toegewezen, zodat alleen die tekst als klikbare link fungeert. Gebruik [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) om het segment aan een externe URL te koppelen.

Het volgende voorbeeld maakt gelinkte tekst aan en slaat deze op in een presentatie:

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

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder op een master‑ of lay‑outdia?**

Een [placeholder](/slides/nl/php-java/manage-placeholder/) kan zijn positie en opmaak overnemen van een [master‑slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/) of [layout‑slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/). Een regulier tekstvak is een onafhankelijke vorm op de dia waarop het is gecreëerd en krijgt geen placeholder‑gedrag wanneer de lay‑out verandert.

**Hoe kan ik tekst vervangen zonder de tekst in grafieken, tabellen of SmartArt te wijzigen?**

Beperk de traversering tot [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/)‑objecten, zoals weergegeven in het voorbeeld Tekst bijwerken. Grafieken, tabellen en SmartArt bewaren tekst in hun eigen objectmodellen, zodat ze niet door die lus worden aangepast.