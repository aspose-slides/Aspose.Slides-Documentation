---
title: Textruta
type: docs
weight: 40
url: /sv/php-java/examples/elements/text-box/
keywords:
- textruta
- lägg till textruta
- åtkomst till textruta
- ta bort textruta
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Skapa och formatera textrutor i PHP med Aspose.Slides: ange typsnitt, justering, radbrytning, autofit och länkar för att förbättra bilder för PowerPoint och OpenDocument."
---
I Aspose.Slides representeras en **textruta** av en `AutoShape`. Nästan vilken form som helst kan innehålla text, men en typisk textruta har ingen fyllning eller kant och visar endast text.

Denna guide förklarar hur man lägger till, får åtkomst till och tar bort textrutor programmässigt.

## **Lägg till en textruta**

En textruta är helt enkelt en `AutoShape` utan fyllning eller kant och med lite formaterad text. Så här skapar du en:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Skapa en rektangelform (standard är fylld med kant och ingen text).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Ta bort fyllning och kant för att få den att se ut som en typisk textruta.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Ange textformatering.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Tilldela det faktiska textinnehållet.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Obs:** Alla `AutoShape` som innehåller en icke‑tom `TextFrame` kan fungera som en textruta.

## **Få åtkomst till textrutor efter innehåll**

För att hitta alla textrutor som innehåller ett specifikt nyckelord (t.ex. "Slide"), iterera genom formerna och kontrollera deras text:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Kom åt den första textrutan på bilden.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Gör något med den matchande textrutan.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Ta bort textrutor efter innehåll**

Detta exempel hittar och tar bort alla textrutor på den första bilden som innehåller ett specifikt nyckelord:

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

> 💡 **Tips:** Skapa alltid en kopia av formsamlingen innan du modifierar den under iteration för att undvika fel vid samlingsmodifikation.