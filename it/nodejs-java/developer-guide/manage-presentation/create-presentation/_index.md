---
title: Crea presentazioni in JavaScript
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea presentazioni con Aspose.Slides—produci file PPT, PPTX e ODP, beneficia del supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides, aggiungere contenuti semplici a una diapositiva e salvare il risultato in un file.

## **Crea presentazione PowerPoint**

Per aggiungere una semplice linea retta a una diapositiva selezionata della presentazione, seguire i passaggi seguenti:

1. Creare un'istanza della classe Presentation.
1. Ottenere il riferimento di una diapositiva usando il suo Index.
1. Aggiungere un AutoShape di tipo Linea utilizzando il metodo addAutoShape esposto dall'oggetto Shapes.
1. Scrivere la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, è stata aggiunta una linea alla prima diapositiva della presentazione.

```javascript
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Aggiungi un autoshape di tipo linea
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quali formati posso utilizzare per salvare una nuova presentazione?**

È possibile salvare in [PPTX, PPT e ODP](/slides/it/nodejs-java/save-presentation/), ed esportare in [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/it/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/it/nodejs-java/convert-powerpoint-to-png/), e [immagini](/slides/it/nodejs-java/convert-powerpoint-to-png/), tra gli altri.

**Posso partire da un modello (POTX/POTM) e salvarlo come normale PPTX?**

Sì. Caricare il modello e salvarlo nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/nodejs-java/supported-file-formats/).

**Come controllo la dimensione/rapporto d'aspetto della diapositiva quando creo una presentazione?**

Impostare la [slide size](/slides/it/nodejs-java/slide-size/) (inclusi preset come 4:3 e 16:9 o dimensioni personalizzate) e scegliere come il contenuto deve essere scalato.

**In quali unità sono misurate le dimensioni e le coordinate?**

In punti: 1 pollice equivale a 72 unità.

**Come gestire presentazioni molto grandi (con molti file multimediali) per ridurre l'utilizzo di memoria?**

Utilizzare le [BLOB management strategies](/slides/it/nodejs-java/manage-blob/), limitare l'archiviazione in memoria sfruttando file temporanei e preferire flussi basati su file rispetto a flussi puramente in memoria.

**È possibile creare/salvare presentazioni in parallelo?**

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) da [multiple threads](/slides/it/nodejs-java/multithreading/). Eseguire istanze separate e isolate per thread o processo.

**Come rimuovere la filigrana di prova e le limitazioni?**

[Apply a license](/slides/it/nodejs-java/licensing/) una volta per processo. L'XML della licenza deve rimanere invariato e la configurazione della licenza dovrebbe essere sincronizzata se più thread sono coinvolti.

**Posso firmare digitalmente il PPTX che creo?**

Sì. Le [Digital signatures](/slides/it/nodejs-java/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

**Le macro (VBA) sono supportate nelle presentazioni create?**

Sì. È possibile [create/edit VBA projects](/slides/it/nodejs-java/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.