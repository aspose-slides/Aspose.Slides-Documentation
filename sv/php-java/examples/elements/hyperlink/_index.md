---
title: Hyperlänk
type: docs
weight: 130
url: /sv/php-java/examples/elements/hyperlink/
keywords:
- hyperlänk
- lägg till hyperlänk
- åtkomst till hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lägg till, redigera och ta bort hyperlänkar i PHP med Aspose.Slides: länktext, former, bilder, URL:er och e-post; ange mål och åtgärder för PPT, PPTX och ODP."
---
Visar hur man lägger till, får åtkomst till, tar bort och uppdaterar hyperlänkar på former med **Aspose.Slides for PHP via Java**.

## **Lägg till en hyperlänk**

Skapa en rektangelform med en hyperlänk som pekar på en extern webbplats.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Åtkomst till en hyperlänk**

Läs hyperlänkinformation från en formes textavsnitt.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antar att den första formen innehåller hyperlänken.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Ta bort en hyperlänk**

Rensa hyperlänken från enformes text.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antar att den första formen innehåller hyperlänken.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Uppdatera en hyperlänk**

Ändra målet för en befintlig hyperlänk. Använd `HyperlinkManager` för att ändra text som redan innehåller en hyperlänk, vilket efterliknar hur PowerPoint uppdaterar hyperlänkar på ett säkert sätt.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antar att den första formen innehåller hyperlänken.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Att ändra en hyperlänk i befintlig text bör göras via
        // HyperlinkManager snarare än att sätta egenskapen direkt.
        // Detta efterliknar hur PowerPoint säkert uppdaterar hyperlänkar.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```