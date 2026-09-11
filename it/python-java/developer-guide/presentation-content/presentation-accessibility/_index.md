---
title: Gestisci l'accessibilità delle presentazioni in Python tramite Java
linktitle: Accessibilità della presentazione
type: docs
weight: 30
url: /it/python-java/presentation-accessibility/
keywords:
- accessibilità della presentazione
- segnare come decorativo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Python tramite Java aiuta ad automatizzare i controlli di accessibilità delle presentazioni in file PPT, PPTX e ODP—migliora l'esperienza del lettore di schermo e aumenta la conformità."
---
## **Introduzione**

L'accessibilità delle presentazioni garantisce che le persone che utilizzano tecnologie assistive—come lettori di schermo, display Braille o la navigazione solo da tastiera—possano comprendere e navigare le tue diapositive con la stessa efficacia del pubblico vedente che utilizza mouse. Le buone pratiche si concentrano su un ordine di lettura chiaro, testo alternativo significativo per gli elementi visivi informativi, contrasto di colore sufficiente, tipografia leggibile, testo di collegamento descrittivo e sull'evitare di trasmettere significato solo tramite colore o posizione. Quando l'accessibilità viene pianificata fin dall'inizio, il risultato è una struttura più pulita, elementi visivi più coerenti e contenuti che raggiungono ogni spettatore senza soluzioni alternative.

## **Segna come decorativo**

Il flag Mark as decorative contrassegna gli elementi visivi puramente ornamentali in modo che i lettori di schermo li ignorino, riducendo il rumore e mantenendo l'attenzione sul contenuto significativo. Applicalo a sfondi, decorazioni e spaziatori—mai a grafici, icone o immagini che trasmettono informazioni. Aspose.Slides espone questo flag per il rilevamento e la convalida, consentendo controlli di accessibilità automatizzati e la pulizia.

![Segna come decorativo](mark_as_decorative.png)

Il seguente esempio di codice mostra come determinare se una forma è contrassegnata come decorativa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```