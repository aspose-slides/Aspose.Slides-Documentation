---
title: "Gestire l'accessibilità delle presentazioni in PHP"
linktitle: "Accessibilità delle presentazioni"
type: docs
weight: 30
url: /it/php-java/presentation-accessibility/
keywords:
- accessibilità delle presentazioni
- contrassegna come decorativo
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come Aspose.Slides aiuta ad automatizzare i controlli di accessibilità delle presentazioni nei file PPT, PPTX e ODP—migliora l'esperienza del lettore di schermo e aumenta la conformità."
---
## **Panoramica**

L'accessibilità delle presentazioni garantisce che le persone che utilizzano tecnologie assistive—come lettori di schermo, display braille o navigazione solo da tastiera—possano comprendere e navigare le tue diapositive con la stessa efficacia del pubblico vedente che utilizza il mouse. Le buone pratiche si concentrano su un ordine di lettura chiaro, testo alternativo significativo per i contenuti visivi informativi, contrasto cromatico sufficiente, tipografia leggibile, testo descrittivo per i collegamenti e sul non trasmettere significato solo tramite colore o posizione. Quando l'accessibilità è pianificata fin dall'inizio, il risultato è una struttura più pulita, elementi visivi più coerenti e contenuti che raggiungono ogni spettatore senza soluzioni alternative.

## **Contrassegna come decorativo**

Il flag Mark as decorative indica elementi visivi puramente ornamentali affinché i lettori di schermo li ignorino, riducendo il rumore e mantenendo il focus sui contenuti significativi. Applicalo a sfondi, decorazioni e spaziatori—mai a grafici, icone o immagini che trasmettono informazioni. Aspose.Slides espone questo flag per il rilevamento e la convalida, consentendo controlli di accessibilità automatizzati e pulizia.

![Mark as Decorative](mark_as_decorative.png)

Il seguente esempio di codice mostra come determinare se una forma è contrassegnata come decorativa.

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Is shape decorative: " . ($shape->isDecorative() ? "true" : "false") . "\n";
} finally {
    $presentation->dispose();
}
```