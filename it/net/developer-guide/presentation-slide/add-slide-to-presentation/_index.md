---
title: Aggiungere diapositive alle presentazioni in .NET
linktitle: Aggiungi diapositiva
type: docs
weight: 10
url: /it/net/add-slide-to-presentation/
keywords:
- aggiungi diapositiva
- crea diapositiva
- diapositiva vuota
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Aggiungi facilmente diapositive alle tue presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET—inserimento di diapositive fluido ed efficiente in pochi secondi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere diapositive alle presentazioni PowerPoint in modo programmatico. Una presentazione contiene diapositive master/layout e diapositive normali, e le diapositive normali sono ordinate tramite un indice basato su zero. Ogni diapositiva ha un ID univoco, e i file di presentazione senza diapositive non sono supportati.

Questo articolo spiega come creare un oggetto `Presentation`, accedere alla sua collezione di diapositive, aggiungere una diapositiva vuota, lavorare con la diapositiva appena aggiunta e salvare la presentazione aggiornata. Copre anche punti correlati come l'inserimento di diapositive in una posizione specifica, l'uso dei layout e la comprensione della diapositiva vuota presente in una presentazione appena creata.

## **Aggiungere una diapositiva a una presentazione**
Prima di parlare dell'aggiunta di diapositive ai file di presentazione, discutiamo alcuni fatti sulle diapositive. Ogni file di presentazione PowerPoint contiene diapositive Master / Layout e altre diapositive Normali. Ciò significa che un file di presentazione contiene almeno una o più diapositive. È importante sapere che i file di presentazione senza diapositive non sono supportati da Aspose.Slides per .NET. Ogni diapositiva ha un Id univoco e tutte le diapositive Normali sono ordinate secondo l'indice basato su zero. Aspose.Slides per .NET consente agli sviluppatori di aggiungere diapositive vuote alla loro presentazione. Per aggiungere una diapositiva vuota nella presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
- Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) impostando un riferimento alla proprietà Slides (collezione di oggetti Slide di contenuto) esposta dall'oggetto Presentation.
- Aggiungi una diapositiva vuota alla presentazione alla fine della collezione di diapositive di contenuto chiamando i metodi AddEmptySlide esposti dall'oggetto ISlideCollection.
- Esegui alcune operazioni con la diapositiva vuota appena aggiunta.
- Infine, scrivi il file di presentazione usando l'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **FAQ**

**Posso inserire una nuova diapositiva in una posizione specifica, non solo alla fine?**

Sì. La libreria supporta le collezioni di diapositive e le operazioni [insert](https://reference.aspose.com/slides/it/net/aspose.slides/slidecollection/insertemptyslide)/[clone](https://reference.aspose.com/slides/it/net/aspose.slides/slidecollection/insertclone) così è possibile aggiungere una diapositiva all'indice richiesto invece che solo alla fine.

**Gli stili/tema vengono preservati quando si aggiunge una diapositiva basata su un layout?**

Sì. Un layout eredita la formattazione dal suo master, e la nuova diapositiva eredita dal layout selezionato e dal master associato.

**Quale diapositiva è presente in una nuova "vuota" presentazione prima di aggiungere diapositive?**

Una presentazione appena creata contiene già una diapositiva vuota con indice zero. Questo è importante da considerare quando si calcolano gli indici di inserimento.

**Come scegliere il layout "giusto" per una nuova diapositiva se il master ha molte opzioni?**

In genere scegli il [LayoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/layoutslide) che corrisponde alla struttura richiesta ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/it/net/aspose.slides/slidelayouttype)). Se tale layout manca, è possibile [add it to the master](/slides/it/net/slide-layout) e quindi usarlo.