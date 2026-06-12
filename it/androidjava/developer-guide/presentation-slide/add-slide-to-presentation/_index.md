---
title: Aggiungere diapositive alle presentazioni su Android
linktitle: Aggiungi diapositiva
type: docs
weight: 10
url: /it/androidjava/add-slide-to-presentation/
keywords:
- aggiungi diapositiva
- crea diapositiva
- diapositiva vuota
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Aggiungi facilmente diapositive alle tue presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Android via Java—inserimento di diapositive fluido ed efficiente in pochi secondi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere diapositive alle presentazioni PowerPoint in modo programmatico. Una presentazione contiene diapositive master/layout e diapositive normali, e le diapositive normali sono organizzate mediante un indice a base zero. Ogni diapositiva ha un ID univoco e i file di presentazione senza diapositive non sono supportati.

Questo articolo spiega come creare un oggetto `Presentation`, accedere alla sua raccolta di diapositive, aggiungere una diapositiva vuota, lavorare con la diapositiva appena aggiunta e salvare la presentazione aggiornata. Copre inoltre argomenti correlati come l'inserimento di diapositive in una posizione specifica, l'uso dei layout e la comprensione della diapositiva vuota presente in una presentazione appena creata.

## **Aggiungere una diapositiva a una presentazione**

Prima di parlare dell'aggiunta di diapositive ai file di presentazione, discutiamo alcuni fatti sulle diapositive. Ogni file di presentazione PowerPoint contiene diapositive **Master / Layout** e altre diapositive **Normali**. Ciò significa che un file di presentazione contiene almeno una o più diapositive. È importante sapere che i file di presentazione senza diapositive non sono supportati da Aspose.Slides for Android via Java. Ogni diapositiva ha un Id univoco e tutte le diapositive Normali sono disposte in un ordine specificato dall'indice a base zero.

Aspose.Slides for Android via Java consente agli sviluppatori di aggiungere diapositive vuote alla loro presentazione. Per aggiungere una diapositiva vuota nella presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
- Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection) impostando un riferimento alla proprietà [Slides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) (collezione di oggetti Slide di contenuto) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
- Aggiungi una diapositiva vuota alla presentazione alla fine della collezione di diapositive di contenuto chiamando il metodo [**addEmptySlide**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection).
- Esegui qualche operazione con la diapositiva vuota appena aggiunta.
- Infine, scrivi il file di presentazione utilizzando l'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).

```java
// Istanzia la classe Presentation che rappresenta il file di presentazione
Presentation pres = new Presentation();
try {
    // Istanzia la classe SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Aggiungi una diapositiva vuota alla collezione Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Esegui qualche operazione sulla diapositiva appena aggiunta

    // Salva il file PPTX su disco
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Posso inserire una nuova diapositiva in una posizione specifica, non solo alla fine?**

Sì. la libreria supporta le collezioni di diapositive e le operazioni [insert](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-), quindi è possibile aggiungere una diapositiva all'indice richiesto invece che solo alla fine.

**I temi/stili vengono conservati quando si aggiunge una diapositiva basata su un layout?**

Sì. Un layout eredita la formattazione dal suo master, e la nuova diapositiva eredita dal layout selezionato e dal master associato.

**Quale diapositiva è presente in una nuova presentazione "vuota" prima di aggiungere diapositive?**

Una presentazione appena creata contiene già una diapositiva vuota con indice zero. Questo è importante da considerare quando si calcolano gli indici di inserimento.

**Come scegliere il layout "giusto" per una nuova diapositiva se il master ha molte opzioni?**

In genere scegli il [LayoutSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/layoutslide/) che corrisponde alla struttura richiesta ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidelayouttype/)). Se tale layout è assente, puoi [aggiungerlo al master](/slides/it/androidjava/slide-layout/) e poi usarlo.