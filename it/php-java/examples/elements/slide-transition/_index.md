---
title: TransizioneDiapositiva
type: docs
weight: 110
url: /it/php-java/examples/elements/slide-transition/
keywords:
- transizione diapositiva
- aggiungi transizione diapositiva
- accedi transizione diapositiva
- rimuovi transizione diapositiva
- durata della transizione
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Controlla le transizioni delle diapositive in PHP con Aspose.Slides: scegli tipi, velocità, suono e tempistica per perfezionare le presentazioni in PPT, PPTX e ODP."
---
Dimostra l'applicazione di effetti di transizione delle diapositive e dei tempi con **Aspose.Slides for PHP via Java**.

## **Aggiungi una transizione di diapositiva**

Applica un effetto di transizione dissolvenza alla prima diapositiva.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Applica una transizione di dissolvenza.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedi a una transizione di diapositiva**

Leggi il tipo di transizione assegnato a una diapositiva.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi al tipo di transizione.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi una transizione di diapositiva**

Cancella qualsiasi effetto di transizione impostando il tipo su `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Rimuovi la transizione impostando nessuna.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Imposta la durata della transizione**

Specifica per quanto tempo la diapositiva viene mostrata prima di avanzare automaticamente.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // in millisecondi.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```