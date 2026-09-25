---
title: Gestisci l'accessibilità delle presentazioni in .NET
linktitle: Accessibilità delle presentazioni
type: docs
weight: 30
url: /it/net/presentation-accessibility/
keywords:
- accessibilità delle presentazioni
- testo alternativo
- titolo del testo alternativo
- descrizione del testo alternativo
- contrassegna come decorativo
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Automatizza i controlli di accessibilità delle presentazioni in file PPT, PPTX e ODP con Aspose.Slides per .NET—migliora l'esperienza dei lettori di schermo e aumenta la conformità."
---
## **Introduzione**

Il testo alternativo aiuta le persone che utilizzano tecnologie assistive a comprendere il significato di immagini, grafici e altre forme informative. Questo articolo spiega come leggere e aggiornare i titoli e le descrizioni del testo alternativo con Aspose.Slides per .NET, distinguere le descrizioni di accessibilità dai nomi delle forme usati nel codice e verificare se una forma è contrassegnata come decorativa.

Queste funzionalità supportano l'accessibilità delle presentazioni, ma non la garantiscono. L'ordine di lettura, il contrasto dei colori, la leggibilità del testo e altri requisiti di accessibilità necessitano anch'essi di revisione.

## **Gestire i titoli e le descrizioni del testo alternativo**

Utilizza il testo alternativo per spiegare il significato di immagini, grafici e altre forme informative alle persone che non possono vederle. Le seguenti proprietà hanno scopi diversi:

| Property or content | Purpose |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/alternativetexttitle/) | Un titolo breve per la descrizione alternativa. |
| [AlternativeText](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/alternativetext/) | Una descrizione significativa del contenuto o dello scopo della forma nel contesto della diapositiva. |
| [Name](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/name/) | Il nome della forma, che il codice può usare per trovare una forma specifica nella presentazione. |
| Visible text | Contenuto visualizzato nella diapositiva, come il testo di una forma o il titolo e le etichette di un grafico. L'aggiornamento del testo alternativo non modifica questo contenuto. |

Quando una presentazione viene riutilizzata come modello, il codice può trovare una forma per il suo [Name](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/name/) prima di aggiornarla. Questo nome ha uno scopo diverso dal testo alternativo, che spiega cosa comunica il contenuto visivo al lettore. La ricerca per nome consente agli autori di migliorare o tradurre le descrizioni senza modificare il modo in cui il codice trova la forma. I nomi possono essere modificati e non sono garantiti unici, quindi verificare che il nome corrisponda alla forma desiderata; vedere [Identificare e trovare forme](/slides/it/net/shape-manipulations/#identify-and-find-shapes).

L'esempio seguente richiede `input.pptx` con un'immagine di un ingresso d'ufficio come prima forma nella prima diapositiva. L'immagine non deve essere contrassegnata come decorativa. L'esempio legge e stampa il titolo e la descrizione attuali del testo alternativo, aggiorna entrambi i valori e salva la presentazione come `output.pptx`. Adatta la formulazione all'immagine reale e alle informazioni che trasmette.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Aggiungere solo il testo alternativo non garantisce l'accessibilità della presentazione né la conformità agli standard di accessibilità. Revisiona le descrizioni per precisione e rilevanza, e controlla anche l'ordine di lettura, il contrasto dei colori, la leggibilità del testo e altri requisiti di accessibilità. I contenuti visivi informativi non dovrebbero essere contrassegnati come decorativi; la sezione successiva mostra come leggere [IsDecorative](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/isdecorative/).

## **Contrassegnare come decorativo**

Il flag 'Mark as decorative' indica contenuti puramente ornamentali in modo che i lettori di schermo li ignorino, riducendo il rumore e mantenendo l'attenzione sul contenuto significativo. Applicalo a sfondi, abbellimenti e spaziatori — mai a grafici, icone o immagini che trasmettono informazioni. Aspose.Slides espone questo flag per la rilevazione e la convalida, consentendo controlli di accessibilità automatizzati e pulizia.

![Mark as Decorative](mark_as_decorative.png)

Il seguente esempio di codice mostra come determinare se una forma è contrassegnata come decorativa.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **FAQ**

**Cosa dovrei inserire nel titolo e nella descrizione del testo alternativo?**

Usa un titolo breve per identificare l'oggetto e una descrizione per spiegare le informazioni che il contenuto visivo trasmette nel contesto della diapositiva. Per un grafico, descrivi la tendenza o il confronto rilevante anziché limitarti a dire "grafico".

**Devo usare il testo alternativo per individuare le forme in un modello?**

Preferisci trovare la forma per il suo [Name](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/name/) e verificare che sia la forma prevista. Il testo alternativo può essere modificato o tradotto, il che può interrompere il codice che ricerca una descrizione esatta; vedi [Identificare e trovare forme](/slides/it/net/shape-manipulations/).

**Quando una forma dovrebbe essere contrassegnata come decorativa?**

Utilizza il flag decorativo per contenuti visivi che non aggiungono informazioni, come abbellimenti ornamentali. Immagini e grafici che comunicano significato richiedono invece una descrizione appropriata.

**Aggiungere il testo alternativo rende una presentazione completamente accessibile?**

No. Il testo alternativo tratta solo una parte dell'accessibilità. È necessario inoltre revisionare l'ordine di lettura, il contrasto dei colori, la leggibilità del testo e altri requisiti applicabili; impostare solo queste proprietà non garantisce la conformità.