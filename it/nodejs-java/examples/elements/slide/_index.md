---
title: Diapositiva
type: docs
weight: 10
url: /it/nodejs-java/examples/elements/slide/
keywords:
- esempio di codice
- diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Controlla le diapositive in Aspose.Slides per Node.js: crea, clona, riordina, ridimensiona, imposta sfondi e applica transizioni per presentazioni PPT, PPTX e ODP."
---
Questo articolo fornisce una serie di esempi che dimostrano come lavorare con le diapositive usando **Aspose.Slides per Node.js tramite Java**. Imparerai come aggiungere, accedere, clonare, riordinare e rimuovere le diapositive usando la classe `Presentation`.

Ogni esempio di seguito include una breve spiegazione seguita da uno snippet di codice in JavaScript.

## **Aggiungi una diapositiva**

Per aggiungere una nuova diapositiva, devi prima selezionare un layout. In questo esempio, usiamo il layout `Blank` e aggiungiamo una diapositiva vuota alla presentazione.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota:** Ogni layout di diapositiva deriva da una diapositiva master, che definisce il design complessivo e la struttura dei segnaposti. L'immagine seguente illustra come le diapositive master e i relativi layout sono organizzati in PowerPoint.

![Relazione tra Master e Layout](master-layout-slide.png)

## **Accedi alle diapositive per indice**

Puoi accedere alle diapositive usando il loro indice. Questo è utile per iterare o modificare diapositive specifiche.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Accedi a una diapositiva per indice.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Clona una diapositiva**

Questo esempio mostra come clonare una diapositiva esistente. La diapositiva clonata viene aggiunta automaticamente alla fine della collezione di diapositive.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Riordina le diapositive**

Puoi cambiare l'ordine delle diapositive spostandone una a un nuovo indice. In questo caso, spostiamo una diapositiva nella prima posizione.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Riordina le diapositive spostando la seconda diapositiva nella prima posizione.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi una diapositiva**

Per rimuovere una diapositiva, basta fare riferimento ad essa e chiamare `remove`. Questo esempio aggiunge una seconda diapositiva e poi rimuove quella originale, lasciando solo la nuova.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```