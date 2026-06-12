---
title: "Gestire l'accessibilità delle presentazioni in JavaScript"
linktitle: "Accessibilità della presentazione"
type: docs
weight: 30
url: /it/nodejs-java/presentation-accessibility/
keywords:
- "accessibilità della presentazione"
- "contrassegna come decorativo"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Automatizza i controlli di accessibilità delle presentazioni nei file PPT, PPTX e ODP con Aspose.Slides per Node.js—migliora l'esperienza dei lettori di schermo e aumenta la conformità."
---
## **Panoramica**

L'accessibilità delle presentazioni garantisce che le persone che utilizzano tecnologie assistive—come screen reader, display Braille o la navigazione solo da tastiera—possano comprendere e navigare le tue diapositive con la stessa efficacia del pubblico vedente e che utilizza il mouse. Le buone pratiche si concentrano su un ordine di lettura chiaro, testo alternativo significativo per contenuti visivi informativi, contrasto di colore sufficiente, tipografia leggibile, testo descrittivo per i collegamenti e sul non trasmettere significato esclusivamente tramite colore o posizione. Quando l'accessibilità è pianificata fin dall'inizio, il risultato è una struttura più pulita, elementi visivi più coerenti e contenuti che raggiungono ogni spettatore senza soluzioni alternative.

## **Contrassegna come decorativo**

Il contrassegno "Mark as Decorative" indica elementi visivi puramente ornamentali, così i lettori di schermo li ignorano, riducendo il rumore e mantenendo l'attenzione sul contenuto significativo. Applicalo a sfondi, abbellimenti e spaziatori—mai a grafici, icone o immagini che trasmettono informazioni. Aspose.Slides espone questa opzione per il rilevamento e la convalida, consentendo controlli automatici di accessibilità e pulizia.

![Contrassegna come decorativo](mark_as_decorative.png)

Il seguente esempio di codice mostra come determinare se una forma è contrassegnata come decorativa.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```