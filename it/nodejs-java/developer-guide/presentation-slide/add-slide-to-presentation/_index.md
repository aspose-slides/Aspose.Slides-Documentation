---
title: Aggiungi Diapositive alle Presentazioni in JavaScript
linktitle: Aggiungi Diapositiva
type: docs
weight: 10
url: /it/nodejs-java/add-slide-to-presentation/
keywords:
- aggiungi diapositiva
- crea diapositiva
- diapositiva vuota
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Aggiungi facilmente diapositive alle tue presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Node.js tramite Java — inserimento di diapositive fluido ed efficiente in pochi secondi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere diapositive a presentazioni PowerPoint in modo programmatico. Una presentazione contiene diapositive master/layout e diapositive normali, e le diapositive normali sono organizzate tramite un indice basato su zero. Ogni diapositiva ha un ID univoco e i file di presentazione senza diapositive non sono supportati.

Questo articolo spiega come creare un oggetto `Presentation`, accedere alla sua collezione di diapositive, aggiungere una diapositiva vuota, lavorare con la diapositiva appena aggiunta e salvare la presentazione aggiornata. Copre inoltre punti correlati come l'inserimento di diapositive in una posizione specifica, l'uso dei layout e la comprensione della diapositiva vuota presente in una presentazione appena creata.

## **Aggiungere Diapositiva alla Presentazione**

Prima di parlare dell'aggiunta di diapositive ai file di presentazione, discutiamo alcuni fatti sulle diapositive. Ogni file di presentazione PowerPoint contiene una diapositiva **Master / Layout** e altre diapositive **Normali**. Ciò significa che un file di presentazione contiene almeno una diapositiva. È importante sapere che i file di presentazione senza diapositive non sono supportati da Aspose.Slides per Node.js tramite Java. Ogni diapositiva ha un Id univoco e tutte le Diapositive Normali sono organizzate in un ordine specificato da un indice basato su zero.

Aspose.Slides per Node.js tramite Java consente agli sviluppatori di aggiungere diapositive vuote alla loro presentazione. Per aggiungere una diapositiva vuota nella presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
- Istanzia la classe [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection) impostando un riferimento alla proprietà [Slides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) (collezione di oggetti Slide di contenuto) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
- Aggiungi una diapositiva vuota alla presentazione alla fine della collezione di diapositive di contenuto chiamando i metodi [**addEmptySlide**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) esposti dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection).
- Esegui alcune operazioni con la diapositiva vuota appena aggiunta.
- Infine, scrivi il file della presentazione utilizzando l'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).

```javascript
// Istanzia la classe Presentation che rappresenta il file di presentazione
var pres = new aspose.slides.Presentation();
try {
    // Istanzia la classe SlideCollection
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Aggiungi una diapositiva vuota alla collezione Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Esegui alcune operazioni sulla diapositiva appena aggiunta
    // Salva il file PPTX sul disco
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Domande frequenti**

**Posso inserire una nuova diapositiva in una posizione specifica, non solo alla fine?**

Sì. La libreria supporta le collezioni di diapositive e le operazioni [insert](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/insertclone/), quindi è possibile aggiungere una diapositiva all'indice richiesto anziché solo alla fine.

**I temi/stili vengono conservati quando si aggiunge una diapositiva basata su un layout?**

Sì. Un layout eredita la formattazione dal suo master, e la nuova diapositiva eredita dal layout selezionato e dal suo master associato.

**Quale diapositiva è presente in una nuova presentazione "vuota" prima di aggiungere diapositive?**

Una presentazione appena creata contiene già una diapositiva vuota con indice zero. Questo è importante da considerare quando si calcolano gli indici di inserimento.

**Come scelgo il layout "giusto" per una nuova diapositiva se il master ha molte opzioni?**

In genere scegli il [LayoutSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/) che corrisponde alla struttura richiesta ([Titolo e contenuto, Due contenuti, ecc.](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidelayouttype/)). Se tale layout è mancante, puoi [aggiungerlo al master](/slides/it/nodejs-java/slide-layout/) e poi usarlo.