---
title: Diapositiva
type: docs
weight: 10
url: /it/php-java/examples/elements/slide/
keywords:
- diapositiva
- aggiungi diapositiva
- accedi alla diapositiva
- indice della diapositiva
- clona diapositiva
- riordina diapositive
- rimuovi diapositiva
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci le diapositive in PHP con Aspose.Slides: crea, clona, riordina, nascondi, imposta sfondi e dimensioni, applica transizioni ed esporta per PowerPoint e OpenDocument."
---
Questo articolo fornisce una serie di esempi che dimostrano come lavorare con le diapositive usando **Aspose.Slides for PHP via Java**. Imparerai come aggiungere, accedere, clonare, riordinare e rimuovere diapositive utilizzando la classe `Presentation`.

Ogni esempio di seguito include una breve spiegazione seguita da uno snippet di codice in PHP.

## **Aggiungi una diapositiva**

Per aggiungere una nuova diapositiva, devi prima selezionare un layout. In questo esempio, usiamo il layout `Blank` e aggiungiamo una diapositiva vuota alla presentazione.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Ogni diapositiva è basata su un layout, che a sua volta è basato su una diapositiva master.
        // Usa il layout Blank per creare una nuova diapositiva.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Aggiungi una nuova diapositiva vuota usando il layout selezionato.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Suggerimento:** Ogni layout di diapositiva deriva da una diapositiva master, che definisce il design complessivo e la struttura dei segnaposti. L'immagine di seguito illustra come le diapositive master e i loro layout associati sono organizzati in PowerPoint.

![Relazione tra Master e Layout](master-layout-slide.png)

## **Accedi alle diapositive per indice**

Puoi accedere alle diapositive usando il loro indice.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Accedi a una diapositiva per indice.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Clona una diapositiva**

Questo esempio dimostra come clonare una diapositiva esistente. La diapositiva clonata viene aggiunta automaticamente alla fine della collezione di diapositive.

```php
function cloneSlide() {
    // Per impostazione predefinita, la presentazione contiene una diapositiva vuota.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Clona la prima diapositiva; verrà aggiunta alla fine della presentazione.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // L'indice della diapositiva clonata è 1 (seconda diapositiva nella presentazione).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Riordina le diapositive**

Puoi cambiare l'ordine delle diapositive spostandone una a un nuovo indice. In questo caso, spostiamo una diapositiva nella prima posizione.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Sposta la diapositiva nella prima posizione (le altre si spostano verso il basso).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi una diapositiva**

Per rimuovere una diapositiva, basta fare riferimento ad essa e chiamare `remove`. Questo esempio rimuove le diapositive per indice e per riferimento.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Rimuovi una diapositiva per indice.
        $presentation->getSlides()->removeAt(0);

        // Rimuovi una diapositiva per riferimento.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```