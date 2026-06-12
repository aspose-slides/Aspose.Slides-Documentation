---
title: Gestisci l'accessibilità delle presentazioni su Android
linktitle: Accessibilità delle presentazioni
type: docs
weight: 30
url: /it/androidjava/presentation-accessibility/
keywords:
- accessibilità della presentazione
- contrassegna come decorativo
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Android via Java aiuta ad automatizzare i controlli di accessibilità delle presentazioni nei file PPT, PPTX e ODP - migliora l'esperienza dei lettori di schermo e aumenta la conformità."
---
## **Panoramica**

L'accessibilità delle presentazioni garantisce che le persone che utilizzano tecnologie assistive—come lettori di schermo, display braille o navigazione solo da tastiera—possano comprendere e navigare tra le diapositive con la stessa efficacia del pubblico vedente che usa il mouse. Le buone pratiche si concentrano su un ordine di lettura chiaro, testo alternativo significativo per elementi visivi informativi, contrasto cromatico sufficiente, tipografia leggibile, testo dei collegamenti descrittivo e sull'evitare di trasmettere significato solo tramite colore o posizione. Quando l'accessibilità è pianificata fin dall'inizio, il risultato è una struttura più pulita, elementi visivi più coerenti e contenuti che raggiungono ogni spettatore senza soluzioni alternative.

## **Contrassegna come decorativo**

Contrassegna come decorativo segnala elementi visivi puramente ornamentali in modo che i lettori di schermo li saltino, riducendo il rumore e mantenendo il focus sul contenuto significativo. Applicalo a sfondi, ornamenti e spaziatori—mai a grafici, icone o immagini che trasmettono informazioni. Aspose.Slides espone questo flag per il rilevamento e la convalida, consentendo controlli automatici di accessibilità e pulizia.

![Contrassegna come decorativo](mark_as_decorative.png)

Il seguente esempio di codice mostra come determinare se una forma è contrassegnata come decorativa.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```