---
title: Gestisci l'accessibilità delle presentazioni in C++
linktitle: Accessibilità delle presentazioni
type: docs
weight: 30
url: /it/cpp/presentation-accessibility/
keywords:
- accessibilità delle presentazioni
- segna come decorativo
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come Aspose.Slides per C++ aiuta ad automatizzare i controlli di accessibilità delle presentazioni nei file PPT, PPTX e ODP—migliora l'esperienza del lettore di schermo e aumenta la conformità."
---
## **Panoramica**

L'accessibilità delle presentazioni garantisce che le persone che utilizzano tecnologie assistive—come lettori di schermo, display braille o navigazione solo da tastiera—possono comprendere e navigare le tue diapositive con la stessa efficacia del pubblico vedente e che utilizza il mouse. Le buone pratiche si concentrano su un ordine di lettura chiaro, testo alternativo significativo per elementi visivi informativi, contrasto di colore sufficiente, tipografia leggibile, testo descrittivo dei collegamenti e sull'evitare di trasmettere significato solo tramite colore o posizione. Quando l'accessibilità è pianificata fin dall'inizio, il risultato è una struttura più pulita, elementi visivi più coerenti e contenuti che raggiungono ogni spettatore senza soluzioni alternative.

## **Segna come decorativo**

Il flag Mark as decorative contrassegna gli elementi puramente ornamentali così i lettori di schermo li ignorano, riducendo il rumore e mantenendo il focus sul contenuto significativo. Applicalo a sfondi, decorazioni e spaziatori—mai a grafici, icone o immagini che trasmettono informazioni. Aspose.Slides espone questo flag per il rilevamento e la convalida, consentendo controlli automatizzati di accessibilità e pulizia.

![Segna come decorativo](mark_as_decorative.png)

Il seguente esempio di codice mostra come determinare se una forma è contrassegnata come decorativa.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```