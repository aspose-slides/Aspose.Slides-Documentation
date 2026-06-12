---
title: Inchiostro
type: docs
weight: 180
url: /it/php-java/examples/elements/ink/
keywords:
- inchiostro
- accesso inchiostro
- rimuovi inchiostro
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci l'inchiostro digitale sulle diapositive in PHP con Aspose.Slides: aggiungi tratti di penna, modifica percorsi, imposta colore e spessore, ed esporta i risultati per PowerPoint e OpenDocument."
---
Fornisce esempi di accesso a forme di inchiostro esistenti e della loro rimozione utilizzando **Aspose.Slides for PHP via Java**.

> ❗ **Nota:** Le forme di inchiostro rappresentano l'input dell'utente da dispositivi specializzati. Aspose.Slides non può creare nuovi tratti di inchiostro programmaticamente, ma è possibile leggere e modificare l'inchiostro esistente.

## **Accesso Inchiostro**

Ottieni la prima forma di inchiostro in una diapositiva.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi alla prima forma di inchiostro nella diapositiva.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi Inchiostro**

Elimina una forma di inchiostro dalla diapositiva.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supponendo che la prima forma nella diapositiva sia una forma di inchiostro.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```