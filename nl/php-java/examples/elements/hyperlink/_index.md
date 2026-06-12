---
title: Hyperlink
type: docs
weight: 130
url: /nl/php-java/examples/elements/hyperlink/
keywords:
- hyperlink
- hyperlink toevoegen
- hyperlink benaderen
- hyperlink verwijderen
- hyperlink bijwerken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Hyperlinks toevoegen, bewerken en verwijderen in PHP met Aspose.Slides: koppeltekst, vormen, dia's, URL's en e-mail; doelwitten en acties instellen voor PPT, PPTX en ODP."
---
Toont het toevoegen, benaderen, verwijderen en bijwerken van hyperlinks op vormen met **Aspose.Slides for PHP via Java**.

## **Hyperlink toevoegen**

Maak een rechthoekvorm met een hyperlink die naar een externe website verwijst.

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

## **Hyperlink benaderen**

Lees hyperlink‑informatie uit een tekstgedeelte van een vorm.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aangenomen dat de eerste vorm de hyperlink bevat.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Hyperlink verwijderen**

Verwijder de hyperlink uit de tekst van een vorm.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aangenomen dat de eerste vorm de hyperlink bevat.
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

## **Hyperlink bijwerken**

Wijzig het doel van een bestaande hyperlink. Gebruik `HyperlinkManager` om tekst die al een hyperlink bevat aan te passen, hetgeen nabootst hoe PowerPoint hyperlinks veilig bijwerkt.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aangenomen dat de eerste vorm de hyperlink bevat.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Een hyperlink in bestaande tekst wijzigen moet gebeuren via
        // HyperlinkManager in plaats van de eigenschap rechtstreeks in te stellen.
        // Dit boots het gedrag na van hoe PowerPoint hyperlinks veilig bijwerkt.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```