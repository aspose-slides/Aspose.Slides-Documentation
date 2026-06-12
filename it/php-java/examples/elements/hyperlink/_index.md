---
title: Collegamento ipertestuale
type: docs
weight: 130
url: /it/php-java/examples/elements/hyperlink/
keywords:
- collegamento ipertestuale
- aggiungi collegamento ipertestuale
- accedi al collegamento ipertestuale
- rimuovi collegamento ipertestuale
- aggiorna collegamento ipertestuale
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Aggiungi, modifica e rimuovi collegamenti ipertestuali in PHP con Aspose.Slides: testo del collegamento, forme, diapositive, URL e email; imposta destinazioni e azioni per PPT, PPTX e ODP."
---
Dimostra come aggiungere, accedere, rimuovere e aggiornare i collegamenti ipertestuali su forme utilizzando **Aspose.Slides for PHP via Java**.

## **Aggiungere un collegamento ipertestuale**

Crea una forma rettangolare con un collegamento ipertestuale che punta a un sito web esterno.

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

## **Accedere a un collegamento ipertestuale**

Leggi le informazioni del collegamento ipertestuale dalla porzione di testo di una forma.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supponendo che la prima forma contenga il collegamento ipertestuale.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovere un collegamento ipertestuale**

Rimuovi il collegamento ipertestuale dal testo di una forma.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supponendo che la prima forma contenga il collegamento ipertestuale.
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

## **Aggiornare un collegamento ipertestuale**

Modifica la destinazione di un collegamento ipertestuale esistente. Usa `HyperlinkManager` per modificare il testo che contiene già un collegamento ipertestuale, simulando il modo in cui PowerPoint aggiorna i collegamenti ipertestuali in modo sicuro.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supponendo che la prima forma contenga il collegamento ipertestuale.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Modificare un collegamento ipertestuale all'interno del testo esistente dovrebbe essere fatto via
        // HyperlinkManager piuttosto che impostare direttamente la proprietà.
        // Questo riproduce il modo in cui PowerPoint aggiorna in modo sicuro i collegamenti ipertestuali.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```