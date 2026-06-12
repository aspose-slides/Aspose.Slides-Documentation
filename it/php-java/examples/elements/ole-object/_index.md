---
title: OleObject
type: docs
weight: 210
url: /it/php-java/examples/elements/ole-object/
keywords:
- oggetto OLE
- aggiungi oggetto OLE
- accedi all'oggetto OLE
- rimuovi oggetto OLE
- aggiorna oggetto OLE
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Lavora con gli oggetti OLE in PHP usando Aspose.Slides: inserisci o aggiorna file incorporati, imposta icone o collegamenti, estrai contenuti, controlla il comportamento per PPT, PPTX e ODP."
---
Dimostra come incorporare un file come oggetto OLE e aggiornare i suoi dati utilizzando **Aspose.Slides for PHP via Java**.

## **Aggiungi un oggetto OLE**

Incorpora un file PDF in una presentazione.

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedi a un oggetto OLE**

Recupera il primo frame dell'oggetto OLE in una diapositiva.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi al primo frame OLE nella diapositiva.
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi un oggetto OLE**

Elimina un oggetto OLE incorporato dalla diapositiva.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supponendo che la prima forma nella diapositiva sia il frame OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Aggiorna i dati dell'oggetto OLE**

Sostituisci i dati incorporati in un oggetto OLE esistente.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Si presume che la prima forma nella diapositiva sia il frame OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```