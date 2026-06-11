---
title: Hiperłącze
type: docs
weight: 130
url: /pl/php-java/examples/elements/hyperlink/
keywords:
- hiperłącze
- dodaj hiperłącze
- uzyskaj dostęp do hiperłącza
- usuń hiperłącze
- zaktualizuj hiperłącze
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dodawaj, edytuj i usuwaj hiperłącza w PHP przy użyciu Aspose.Slides: tekst linku, kształty, slajdy, adresy URL i e-mail; ustawiaj cele i akcje dla PPT, PPTX i ODP."
---
Prezentuje dodawanie, dostęp, usuwanie i aktualizowanie hiperłączy w kształtach przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj hiperłącze**

Utwórz prostokątny kształt z hiperłączem prowadzącym do zewnętrznej witryny.

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

## **Uzyskaj dostęp do hiperłącza**

Odczytaj informacje o hiperłączu z fragmentu tekstu kształtu.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszy kształt zawiera hiperłącze.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Usuń hiperłącze**

Wyczyść hiperłącze z tekstu kształtu.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszy kształt zawiera hiperłącze.
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

## **Aktualizuj hiperłącze**

Zmień docelowy adres istniejącego hiperłącza. Użyj `HyperlinkManager`, aby zmodyfikować tekst, który już zawiera hiperłącze, co naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszy kształt zawiera hiperłącze.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Zmiana hiperłącza w istniejącym tekście powinna być wykonana za pomocą
        // HyperlinkManager zamiast bezpośredniego ustawiania właściwości.
        // To naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```