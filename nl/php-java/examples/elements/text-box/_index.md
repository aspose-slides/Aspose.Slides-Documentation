---
title: Tekstvak
type: docs
weight: 40
url: /nl/php-java/examples/elements/text-box/
keywords:
- tekstvak
- tekstvak toevoegen
- tekstvak benaderen
- tekstvak verwijderen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Maak en formatteer tekstvakken in PHP met Aspose.Slides: stel lettertypen, uitlijning, tekstomloop, automatisch aanpassen en koppelingen in om dia's te perfectioneren voor PowerPoint en OpenDocument."
---
In Aspose.Slides wordt een **tekstvak** vertegenwoordigd door een `AutoShape`. Bijna elke vorm kan tekst bevatten, maar een typisch tekstvak heeft geen vulling of rand en toont alleen tekst.

Deze gids legt uit hoe u tekstvakken programatisch kunt toevoegen, benaderen en verwijderen.

## **Een tekstvak toevoegen**

Een tekstvak is simpelweg een `AutoShape` zonder vulling of rand en met enige opgemaakte tekst. Hieronder ziet u hoe u er één maakt:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Maak een rechthoekige vorm (standaard gevuld met rand en zonder tekst).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Verwijder vulling en rand zodat het lijkt op een typisch tekstvak.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Stel tekstopmaak in.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Ken de feitelijke tekstinhoud toe.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Opmerking:** Elke `AutoShape` die een niet‑leeg `TextFrame` bevat, kan functioneren als een tekstvak.

## **Toegang tot tekstvakken op basis van inhoud**

Om alle tekstvakken te vinden die een specifiek trefwoord bevatten (bijv. "Slide"), doorloop de vormen en controleer hun tekst:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot het eerste tekstvak op de dia.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Doe iets met het overeenkomstige tekstvak.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Verwijder tekstvakken op basis van inhoud**

Dit voorbeeld vindt en verwijdert alle tekstvakken op de eerste dia die een specifiek trefwoord bevatten:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip:** Maak altijd een kopie van de vormverzameling voordat u deze tijdens het itereren wijzigt, om fouten bij het aanpassen van de collectie te voorkomen.