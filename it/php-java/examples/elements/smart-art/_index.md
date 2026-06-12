---
title: SmartArt
type: docs
weight: 140
url: /it/php-java/examples/elements/smartart/
keywords:
- SmartArt
- aggiungi SmartArt
- accedi a SmartArt
- rimuovi SmartArt
- layout SmartArt
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Crea e modifica SmartArt in PHP con Aspose.Slides: aggiungi nodi, cambia layout e stili, converti in forme con precisione e esporta per PPT, PPTX e ODP."
---
Mostra come aggiungere grafici SmartArt, accedervi, rimuoverli e modificare i layout utilizzando **Aspose.Slides for PHP via Java**.

## **Aggiungi SmartArt**

Inserisci un grafico SmartArt utilizzando uno dei layout incorporati.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedi a SmartArt**

Recupera il primo oggetto SmartArt su una diapositiva.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi al primo SmartArt nella diapositiva.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi SmartArt**

Elimina una forma SmartArt dalla diapositiva.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supponendo che la prima forma sulla diapositiva sia un SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Modifica layout SmartArt**

Aggiorna il tipo di layout di un grafico SmartArt esistente.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supponendo che la prima forma sulla diapositiva sia un SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Cambia il layout dello SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```