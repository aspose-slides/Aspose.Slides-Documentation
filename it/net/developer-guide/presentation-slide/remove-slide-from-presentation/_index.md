---
title: Rimuovere le diapositive dalle presentazioni in .NET
linktitle: Rimuovi diapositiva
type: docs
weight: 30
url: /it/net/remove-slide-from-presentation/
keywords:
- rimuovi diapositiva
- elimina diapositiva
- rimuovi diapositiva inutilizzata
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Rimuovi facilmente le diapositive dalle presentazioni PowerPoint e OpenDocument con Aspose.Slides per .NET. Ottieni esempi di codice C# chiari e migliora il tuo flusso di lavoro."
---
## **Introduzione**

Se una diapositiva (o il suo contenuto) diventa ridondante, è possibile eliminarla. Aspose.Slides fornisce la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) che incapsula [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection), che è un repository per tutte le diapositive in una presentazione. Utilizzando puntatori (riferimento o indice) per un oggetto [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/) noto, è possibile specificare la diapositiva che si desidera rimuovere. 

## **Rimuovi una diapositiva per riferimento**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
1. Ottieni un riferimento della diapositiva che vuoi rimuovere attraverso il suo ID o indice.
1. Rimuovi la diapositiva referenziata dalla presentazione.
1. Salva la presentazione modificata. 

Questo codice C# mostra come rimuovere una diapositiva tramite il suo riferimento:

```c#
 // Istanzia un oggetto Presentation che rappresenta un file di presentazione
 using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
 {
 
     // Accede a una diapositiva tramite il suo indice nella collezione di diapositive
     ISlide slide = pres.Slides[0];
 
     // Rimuove una diapositiva tramite il suo riferimento
     pres.Slides.Remove(slide);
 
     // Salva la presentazione modificata
     pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **Rimuovi una diapositiva per indice**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
1. Rimuovi la diapositiva dalla presentazione tramite la sua posizione di indice.
1. Salva la presentazione modificata. 

Questo codice C# mostra come rimuovere una diapositiva tramite il suo indice:

```c#
 // Istanzia un oggetto Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Rimuove una diapositiva tramite il suo indice
    pres.Slides.RemoveAt(0);

    // Salva la presentazione modificata
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Rimuovi le diapositive di layout inutilizzate**

Aspose.Slides fornisce il metodo [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (dalla classe [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/) ) per consentire di eliminare layout diapositive indesiderati e inutilizzati. Questo codice C# mostra come rimuovere una diapositiva di layout da una presentazione PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Rimuovi le diapositive master inutilizzate**

Aspose.Slides fornisce il metodo [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (dalla classe [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/) ) per consentire di eliminare master diapositive indesiderati e inutilizzati. Questo codice C# mostra come rimuovere una master slide da una presentazione PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Cosa succede agli indici delle diapositive dopo aver eliminato una diapositiva?**

Dopo l'eliminazione, la [collection](https://reference.aspose.com/slides/it/net/aspose.slides/slidecollection/) si riindicizza: ogni diapositiva successiva si sposta di una posizione verso sinistra, quindi i numeri di indice precedenti diventano obsoleti. Se è necessario un riferimento stabile, utilizzare l'ID persistente di ogni diapositiva anziché il suo indice.

**L'ID di una diapositiva è diverso dal suo indice e cambia quando le diapositive vicine vengono eliminate?**

Sì. L'indice è la posizione della diapositiva e cambierà quando le diapositive vengono aggiunte o rimosse. L'ID della diapositiva è un identificatore persistente e non cambia quando altre diapositive vengono eliminate.

**In che modo l'eliminazione di una diapositiva influisce sulle sezioni delle diapositive?**

Se la diapositiva apparteneva a una sezione, quella sezione conterrà semplicemente una diapositiva in meno. La struttura della sezione rimane invariata; se una sezione diventa vuota, è possibile [rimuovere o riorganizzare le sezioni](/slides/it/net/slide-section/) secondo necessità.

**Cosa succede a note e commenti allegati a una diapositiva quando viene eliminata?**

[Notes](/slides/it/net/presentation-notes/) e [comments](/slides/it/net/presentation-comments/) sono associati a quella specifica diapositiva e vengono rimossi insieme ad essa. Il contenuto delle altre diapositive non viene influenzato.

**In che modo l'eliminazione di diapositive è diversa dalla pulizia di layout/master inutilizzati?**

L'eliminazione rimuove diapositive normali specifiche dal mazzo. La pulizia di layout/master inutilizzati elimina le diapositive di layout o master che non hanno riferimenti, riducendo le dimensioni del file senza modificare il contenuto delle diapositive rimanenti. Queste azioni sono complementari: tipicamente si elimina prima, poi si pulisce.