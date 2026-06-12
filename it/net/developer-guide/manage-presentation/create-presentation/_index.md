---
title: Crea presentazioni in .NET
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/net/create-presentation/
keywords:
- creare presentazione
- nuova presentazione
- creare PPT
- nuovo PPT
- creare PPTX
- nuovo PPTX
- creare ODP
- nuovo ODP
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea presentazioni in .NET con Aspose.Slides—produci file PPT, PPTX e ODP, beneficiti del supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides, aggiungere contenuto semplice a una diapositiva e salvare il risultato come file. Dimostra inoltre come creare e salvare una nuova presentazione, aprire una presentazione esistente in un formato supportato e salvarla in un altro formato. Inoltre, l'articolo contiene una breve FAQ che copre le domande comuni relative a formati, modelli, dimensionamento delle diapositive, unità, utilizzo della memoria, threading, licenze, firme digitali e supporto VBA.

## **Crea una presentazione PowerPoint**

Per aggiungere una semplice linea piana a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

1. Crea un'istanza della classe Presentation.  
2. Ottieni il riferimento di una diapositiva usando il suo indice.  
3. Aggiungi un'AutoShape di tipo Linea utilizzando il metodo AddAutoShape esposto dall'oggetto Shapes.  
4. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

```c#
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
using (Presentation presentation = new Presentation())
{
    // Ottenere la prima diapositiva
    ISlide slide = presentation.Slides[0];

    // Aggiungere un'autoshape di tipo linea
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **Crea e salva una presentazione**

<a name="csharp-create-save-presentation"><strong>Passaggi: Crea e salva la presentazione in C#</strong></a>

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).  
2. Salva _Presentation_ in qualsiasi formato supportato da [SaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/).

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Apri e salva una presentazione**

<a name="csharp-open-save-presentation"><strong>Passaggi: Apri e salva la presentazione in C#</strong></a>

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) con qualsiasi formato, ad esempio PPT, PPTX, ODP ecc.  
2. Salva _Presentation_ in qualsiasi formato supportato da [SaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/).

```c#
// Carica un file supportato in Presentation, ad es. ppt, pptx, odp ecc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **FAQ**

**In quali formati posso salvare una nuova presentazione?**

Puoi salvare in [PPTX, PPT, and ODP](/slides/it/net/save-presentation/), e esportare in [PDF](/slides/it/net/convert-powerpoint-to-pdf/), [XPS](/slides/it/net/convert-powerpoint-to-xps/), [HTML](/slides/it/net/convert-powerpoint-to-html/), [SVG](/slides/it/net/convert-powerpoint-to-png/), e [images](/slides/it/net/convert-powerpoint-to-png/), tra gli altri.

**Posso partire da un modello (POTX/POTM) e salvarlo come un PPTX normale?**

Sì. Carica il modello e salvalo nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/net/supported-file-formats/).

**Come posso controllare la dimensione/aspetto della diapositiva quando creo una presentazione?**

Imposta la [slide size](/slides/it/net/slide-size/) (incluse le impostazioni predefinite come 4:3 e 16:9 o dimensioni personalizzate) e scegli come il contenuto deve essere scalato.

**In quali unità vengono misurate le dimensioni e le coordinate?**

In punti: 1 pollice corrisponde a 72 unità.

**Come gestire presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?**

Utilizza le [BLOB management strategies](/slides/it/net/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei e preferisci flussi di lavoro basati su file rispetto a stream completamente in memoria.

**Posso creare/salvare presentazioni in parallelo?**

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) da [multiple threads](/slides/it/net/multithreading/). Esegui istanze separate e isolate per thread o processo.

**Come rimuovere la filigrana di prova e le limitazioni?**

[Apply a license](/slides/it/net/licensing/) una volta per processo. Il file XML della licenza deve rimanere non modificato e la configurazione della licenza dovrebbe essere sincronizzata se più thread sono coinvolti.

**Posso firmare digitalmente il PPTX che creo?**

Sì. Le [Digital signatures](/slides/it/net/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

**Le macro (VBA) sono supportate nelle presentazioni create?**

Sì. È possibile [create/edit VBA projects](/slides/it/net/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.