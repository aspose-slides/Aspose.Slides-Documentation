---
title: Crea presentazioni in .NET
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/net/create-presentation/
keywords:
- crea presentazione
- nuova presentazione
- crea PPT
- nuovo PPT
- crea PPTX
- nuovo PPTX
- crea ODP
- nuovo ODP
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea presentazioni in .NET con Aspose.Slides — genera file PPT, PPTX e ODP, sfrutta il supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides, aggiungere una casella di testo alla sua prima diapositiva e salvare il risultato come file. Mostra anche come creare e salvare una presentazione vuota e come aprire una presentazione esistente in un formato supportato e salvarla in un altro formato. Una breve FAQ alla fine copre le domande comuni su formati, modelli, dimensionamento delle diapositive, unità, utilizzo della memoria, threading, licenze, firme digitali e supporto VBA.

Prima di iniziare, aggiungi Aspose.Slides al tuo progetto da NuGet. Vedi [Installation](/slides/it/net/installation/) per il pacchetto da utilizzare su Windows, Linux e macOS.

## **Crea una presentazione PowerPoint**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Una nuova presentazione contiene già una diapositiva vuota.  
2. Recupera quella diapositiva dalla collezione [Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slides/it/) usando il suo indice, 0.  
3. Aggiungi un rettangolo con il metodo [AddAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addautoshape/) e imposta il suo [text](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/text/).  
4. Salva la presentazione come file PPTX con il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

L'angolo in alto a sinistra del rettangolo è a 50 punti dal bordo sinistro e 50 punti dal bordo superiore della diapositiva, e il rettangolo è largo 400 punti e alto 100 punti. Il file salvato contiene una diapositiva con quel rettangolo e il suo testo. Senza una licenza, Aspose.Slides aggiunge anche una filigrana di valutazione a ogni diapositiva salvata; vedi [Licensing](/slides/it/net/licensing/).

## **Crea e salva una presentazione**

<a name="csharp-create-save-presentation"></a>

Per creare una presentazione vuota e salvarla, crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e salvala in qualsiasi formato dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/). Il risultato è una presentazione con una diapositiva vuota.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Apri e salva una presentazione**

<a name="csharp-open-save-presentation"></a>

Per convertire una presentazione da un formato all'altro, aprila passando il suo percorso al costruttore [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/presentation/), quindi salvala nel formato di destinazione. Aspose.Slides rileva il formato di input, come PPT, PPTX o ODP, dal file stesso.

L'esempio seguente si aspetta una presentazione OpenDocument chiamata *Sample.odp* nella directory di lavoro e la salva come PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### In quali formati posso salvare una nuova presentazione?

Puoi salvare in [PPTX, PPT e ODP](/slides/it/net/save-presentation/), ed esportare in [PDF](/slides/it/net/convert-powerpoint-to-pdf/), [XPS](/slides/it/net/convert-powerpoint-to-xps/), [HTML](/slides/it/net/convert-powerpoint-to-html/), [SVG](/slides/it/net/render-a-slide-as-an-svg-image/), e [images](/slides/it/net/convert-powerpoint-to-png/), tra gli altri.

### Posso partire da un modello (POTX/POTM) e salvarlo come un PPTX normale?

Sì. Carica il modello e salvalo nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/net/supported-file-formats/).

### Come controllo la dimensione/rapporto d'aspetto della diapositiva durante la creazione di una presentazione?

Imposta la [slide size](/slides/it/net/slide-size/) (incluse le presettature come 4:3 e 16:9 o dimensioni personalizzate) e scegli come deve scalare il contenuto.

### In quali unità vengono misurate le dimensioni e le coordinate?

In punti: 1 pollice equivale a 72 unità.

### Come gestire presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?

Usa le [BLOB management strategies](/slides/it/net/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei e preferisci flussi basati su file rispetto a stream puramente in memoria.

### Posso creare/salvare presentazioni in parallelo?

Non è possibile operare sulla stessa istanza di [Presentation] da [multiple threads](/slides/it/net/multithreading/). Esegui istanze separate e isolate per thread o processo.

### Come rimuovo la filigrana di valutazione e le limitazioni?

[Apply a license](/slides/it/net/licensing/) una volta per processo. L'XML della licenza deve rimanere non modificato e la configurazione della licenza deve essere sincronizzata se più thread sono coinvolti.

### Posso firmare digitalmente il PPTX che creo?

Sì. Le [Digital signatures](/slides/it/net/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

### Le macro (VBA) sono supportate nelle presentazioni create?

Sì. Puoi [create/edit VBA projects](/slides/it/net/presentation-via-vba/) e salvare file con macro abilitata come PPTM/PPSM.