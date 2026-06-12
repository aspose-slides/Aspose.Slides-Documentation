---
title: Aggiungere diapositive alle presentazioni in C++
linktitle: Aggiungi diapositiva
type: docs
weight: 10
url: /it/cpp/add-slide-to-presentation/
keywords:
- aggiungere diapositiva
- creare diapositiva
- diapositiva vuota
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Aggiungi facilmente diapositive alle tue presentazioni PowerPoint e OpenDocument usando Aspose.Slides per C++ — inserimento di diapositive fluido ed efficiente in pochi secondi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere diapositive alle presentazioni PowerPoint in modo programmatico. Una presentazione contiene diapositive Master/Layout e diapositive normali, e le diapositive normali sono ordinate tramite un indice a base zero. Ogni diapositiva ha un ID univoco e i file di presentazione senza diapositive non sono supportati.

Questo articolo spiega come creare un oggetto `Presentation`, accedere alla sua raccolta di diapositive, aggiungere una diapositiva vuota, lavorare con la diapositiva appena aggiunta e salvare la presentazione aggiornata. Copre anche punti correlati come l’inserimento di diapositive in una posizione specifica, l’uso dei layout e la comprensione della diapositiva vuota presente in una presentazione appena creata.

## **Aggiungere una diapositiva a una presentazione**
Prima di parlare dell’aggiunta di diapositive ai file di presentazione, esaminiamo alcuni fatti sulle diapositive. Ogni file di presentazione PowerPoint contiene diapositive Master / Layout e altre diapositive Normali. Ciò significa che un file di presentazione contiene almeno una diapositiva. È importante sapere che i file di presentazione senza diapositive non sono supportati da Aspose.Slides for C++. Ogni diapositiva ha un Id univoco e tutte le Diapositive Normali sono ordinate in base a un indice a base zero. Aspose.Slides for C++ consente agli sviluppatori di aggiungere diapositive vuote alla loro presentazione. Per aggiungere una diapositiva vuota nella presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
- Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/) impostando un riferimento alla proprietà Slides (collezione di oggetti Slide di contenuto) esposta dall'oggetto Presentation.
- Aggiungi una diapositiva vuota alla presentazione alla fine della collezione di diapositive di contenuto chiamando i metodi AddEmptySlide esposti dall'oggetto ISlideCollection.
- Esegui qualche operazione con la diapositiva vuota appena aggiunta.
- Infine, scrivi il file di presentazione utilizzando l'oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **FAQ**

**Posso inserire una nuova diapositiva in una posizione specifica, non solo alla fine?**

Sì. La libreria supporta le collezioni di diapositive e le operazioni [insert](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidecollection/insertclone/) , quindi è possibile aggiungere una diapositiva all'indice richiesto anziché solo alla fine.

**I temi/stili sono preservati quando si aggiunge una diapositiva basata su un layout?**

Sì. Un layout eredita la formattazione dal suo master, e la nuova diapositiva eredita dal layout selezionato e dal master associato.

**Quale diapositiva è presente in una nuova presentazione "vuota" prima di aggiungere diapositive?**

Una presentazione appena creata contiene già una diapositiva vuota con indice zero. È importante considerare ciò quando si calcolano gli indici di inserimento.

**Come scegliere il layout "giusto" per una nuova diapositiva se il master ha molte opzioni?**

In genere scegli il [LayoutSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/layoutslide/) che corrisponde alla struttura richiesta ([Titolo e contenuto, Due contenuti, ecc.](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidelayouttype/)). Se tale layout è mancante, puoi [add it to the master](/slides/it/cpp/slide-layout/) e poi usarlo.