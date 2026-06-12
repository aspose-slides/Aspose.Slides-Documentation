---
title: "Gestire l'accessibilità delle presentazioni in .NET"
linktitle: "Accessibilità della presentazione"
type: docs
weight: 30
url: /it/net/presentation-accessibility/
keywords:
- accessibilità della presentazione
- contrassegnare come decorativo
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Automatizza i controlli di accessibilità delle presentazioni nei file PPT, PPTX e ODP con Aspose.Slides per .NET—migliora l'esperienza dei lettori di schermo e aumenta la conformità."
---
## **Introduzione**

L'accessibilità delle presentazioni garantisce che le persone che utilizzano tecnologie assistive—come i lettori di schermo, i display braille o la navigazione solo tramite tastiera—possano comprendere e navigare le vostre diapositive con la stessa efficacia del pubblico vedente che utilizza il mouse. Le buone pratiche si concentrano su un ordine di lettura chiaro, testo alternativo significativo per le immagini informative, contrasto cromatico sufficiente, tipografia leggibile, testo descrittivo per i collegamenti e sull'evitare di trasmettere significato solo mediante colore o posizione. Quando l'accessibilità è pianificata fin dall'inizio, il risultato è una struttura più pulita, elementi visivi più coerenti e contenuti che raggiungono tutti gli spettatori senza soluzioni alternative.

## **Mark as Decorative**

Il flag **Mark as decorative** indica visuali puramente ornamentali affinché i lettori di schermo le ignorino, riducendo il rumore e mantenendo il focus sul contenuto significativo. Applicatelo a sfondi, decorazioni e spaziatori—mai a grafici, icone o immagini che trasmettono informazioni. Aspose.Slides espone questo flag per il rilevamento e la convalida, consentendo controlli di accessibilità automatizzati e pulizia.

![Contrassegna come decorativo](mark_as_decorative.png)

Il seguente esempio di codice mostra come determinare se una forma è contrassegnata come decorativa.

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```