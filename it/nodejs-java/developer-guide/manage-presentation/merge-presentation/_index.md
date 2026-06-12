---
title: Unisci Efficientemente le Presentazioni in JavaScript
linktitle: Unisci Presentazioni
type: docs
weight: 40
url: /it/nodejs-java/merge-presentation/
keywords:
- unire PowerPoint
- unire presentazioni
- unire diapositive
- unire PPT
- unire PPTX
- unire ODP
- combinare PowerPoint
- combinare presentazioni
- combinare diapositive
- combinare PPT
- combinare PPTX
- combinare ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "Unisci senza sforzo presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP) in JavaScript con Aspose.Slides per Node.js, semplificando il tuo flusso di lavoro."
---
## **Panoramica**

Aspose.Slides ti consente di unire presentazioni clonando diapositive da una presentazione all’altra. Questo articolo spiega come unire intere presentazioni o diapositive selezionate, utilizzare un master delle diapositive o un layout specifico durante l’unione, gestire presentazioni con dimensioni di diapositiva diverse e aggiungere diapositive unite a una sezione della presentazione. Copre anche note pratiche relative al contenuto unito, incluse note del relatore, commenti, file di origine protetti da password e utilizzo dei thread.

## **Unione di Presentazioni**

Quando unisci una presentazione a un’altra, combini effettivamente le loro diapositive in un’unica presentazione per ottenere un solo file. 

{{% alert title="Info" color="info" %}}

La maggior parte dei programmi di presentazione (PowerPoint o OpenOffice) non dispone di funzioni che consentono agli utenti di combinare presentazioni in questo modo. 

[**Aspose.Slides per Node.js via Java**](https://products.aspose.com/slides/it/nodejs-java/), tuttavia, ti permette di unire presentazioni in modi diversi. Puoi unire presentazioni con tutte le loro forme, stili, testi, formattazioni, commenti, animazioni, ecc., senza preoccuparti della perdita di qualità o dati.

**Vedi anche**

[Clona Diapositive](https://docs.aspose.com/slides/it/nodejs-java/clone-slides/).

{{% /alert %}}

### **Cosa Può Essere Unito**

Con Aspose.Slides, puoi unire 

* intere presentazioni. Tutte le diapositive delle presentazioni finiscono in un’unica presentazione
* diapositive specifiche. Le diapositive selezionate finiscono in un’unica presentazione
* presentazioni in un formato (PPT a PPT, PPTX a PPTX, ecc.) e in formati diversi (PPT a PPTX, PPTX a ODP, ecc.) l’una con l’altra. 

### **Opzioni di Unione**

Puoi applicare opzioni che determinano se

* ogni diapositiva nella presentazione di output mantiene uno stile unico
* uno stile specifico è usato per tutte le diapositive nella presentazione di output. 

Per unire presentazioni, Aspose.Slides fornisce i metodi [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (dalla classe [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection)). Ci sono diverse implementazioni dei metodi `addClone` che definiscono i parametri del processo di fusione delle presentazioni. Ogni oggetto Presentation possiede una collezione [Slides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) , quindi puoi chiamare un metodo `addClone` dalla presentazione in cui desideri unire le diapositive.

Il metodo `addClone` restituisce un oggetto `Slide`, che è una copia della diapositiva di origine. Le diapositive in una presentazione di output sono semplicemente una copia delle diapositive della sorgente. Pertanto, puoi modificare le diapositive risultanti (ad esempio, applicare stili o opzioni di formattazione o layout) senza preoccuparti che le presentazioni di origine vengano alterate. 

## **Unire Presentazioni** 

Aspose.Slides fornisce il metodo [**AddClone(ISlide)**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) che ti permette di combinare diapositive mantenendo i loro layout e stili (parametri predefiniti).

Questo codice JavaScript mostra come unire presentazioni:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Unire Presentazioni con Master delle Diapositive**

Aspose.Slides fornisce il metodo [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) che ti consente di combinare diapositive applicando un modello di master delle diapositive. In questo modo, se necessario, puoi modificare lo stile delle diapositive nella presentazione di output.

Questo codice JavaScript dimostra l’operazione descritta:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

Il layout della diapositiva per il master è determinato automaticamente. Quando non è possibile determinare un layout appropriato, se il parametro booleano `allowCloneMissingLayout` del metodo `addClone` è impostato su true, viene usato il layout della diapositiva di origine. Altrimenti verrà sollevata un’eccezione [PptxEditException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PptxEditException). 

{{% /alert %}}

Se desideri che le diapositive nella presentazione di output abbiano un layout diverso, utilizza il metodo [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) durante l’unione.

## **Unire Diapositive Specifiche da Presentazioni**

Unire diapositive specifiche da più presentazioni è utile per creare deck personalizzati. Aspose.Slides per Node.js via Java ti consente di selezionare e importare solo le diapositive di cui hai bisogno. L’API preserva la formattazione, il layout e il design delle diapositive originali.

Il seguente codice JavaScript crea una nuova presentazione, aggiunge diapositive titolo da due altre presentazioni e salva il risultato in un file:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **Unire Presentazioni con Layout delle Diapositive**

Questo codice JavaScript mostra come combinare diapositive da presentazioni applicando il layout desiderato per ottenere una singola presentazione di output:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Unire Presentazioni con Dimensioni di Diapositiva Diverse**

{{% alert title="Note" color="warning" %}} 

Non è possibile unire presentazioni con dimensioni di diapositiva diverse. 

{{% /alert %}}

Per unire 2 presentazioni con dimensioni di diapositiva diverse, devi ridimensionare una delle presentazioni in modo che la sua dimensione corrisponda a quella dell’altra presentazione. 

Questo esempio di codice dimostra l’operazione descritta:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Unire Diapositive in una Sezione della Presentazione**

Questo codice JavaScript mostra come unire una diapositiva specifica in una sezione di una presentazione:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

La diapositiva viene aggiunta alla fine della sezione. 

## **FAQ**

**Le note del relatore vengono mantenute durante l’unione?**

Sì. Quando si clonano le diapositive, Aspose.Slides trasferisce tutti gli elementi della diapositiva, incluse note, formattazione e animazioni.

**I commenti e i loro autori vengono trasferiti?**

I commenti, come parte del contenuto della diapositiva, vengono copiati insieme alla diapositiva. Le etichette degli autori dei commenti sono preservate come oggetti commento nella presentazione risultante.

**Cosa succede se la presentazione di origine è protetta da password?**

Deve essere [aperta con la password](/slides/it/nodejs-java/password-protected-presentation/) tramite [LoadOptions.setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/setpassword/); dopo il caricamento, quelle diapositive possono essere clonate in modo sicuro in un file di destinazione non protetto (o anche protetto).

**Quanto è thread‑safe l’operazione di unione?**

Non utilizzare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) da [più thread](/slides/it/nodejs-java/multithreading/). La regola consigliata è “un documento — un thread”; file diversi possono essere elaborati in parallelo in thread separati.

## **Vedi anche**

Aspose offre un [FREE Online Collage Maker](https://products.aspose.app/slides/it/collage). Utilizzando questo servizio online, puoi unire immagini [JPG a JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG a PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e altro ancora.

Dai un’occhiata al [Aspose FREE Online Merger](https://products.aspose.app/slides/it/merger). Ti consente di unire presentazioni PowerPoint nello stesso formato (ad es., PPT a PPT, PPTX a PPTX) o tra formati diversi (ad es., PPT a PPTX, PPTX a ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/it/merger)