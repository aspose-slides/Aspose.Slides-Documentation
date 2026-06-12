---
title: Gestire l'accessibilità delle presentazioni in Python
linktitle: Accessibilità delle presentazioni
type: docs
weight: 30
url: /it/python-net/presentation-accessibility/
keywords:
- accessibilità delle presentazioni
- segna come decorativo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come Aspose.Slides per Python aiuta ad automatizzare i controlli di accessibilità delle presentazioni in file PPT, PPTX e ODP — migliora l'esperienza dei lettori di schermo e aumenta la conformità."
---
## **Introduzione**

L'accessibilità delle presentazioni garantisce che le persone che utilizzano tecnologie assistive — come lettori di schermo, display braille o navigazione solo da tastiera — possano comprendere e navigare le tue diapositive con la stessa efficacia del pubblico vedente e che utilizza il mouse. Le buone pratiche si concentrano su un ordine di lettura chiaro, testo alternativo significativo per elementi visivi informativi, contrasto di colore sufficiente, tipografia leggibile, testo dei collegamenti descrittivo e sull'evitare di trasmettere significato solo tramite colore o posizione. Quando l'accessibilità è pianificata fin dall'inizio, il risultato è una struttura più pulita, elementi visivi più coerenti e contenuti che raggiungono ogni spettatore senza soluzioni alternative.

## **Segna come decorativo**

Segna come decorativo contrassegna gli elementi puramente ornamentali affinché i lettori di schermo li ignorino, riducendo il rumore e mantenendo l'attenzione sul contenuto significativo. Applicalo a sfondi, decorazioni e spaziatori — mai a grafici, icone o immagini che trasmettono informazioni. Aspose.Slides espone questa flag per il rilevamento e la convalida, consentendo controlli automatici di accessibilità e pulizia.

![Segna come decorativo](mark_as_decorative.png)

Il seguente esempio di codice mostra come determinare se una forma è contrassegnata come decorativa.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```