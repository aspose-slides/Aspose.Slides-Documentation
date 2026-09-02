---
title: Clona diapositive della presentazione in JavaScript
linktitle: Clona diapositive
type: docs
weight: 35
url: /it/nodejs-java/clone-slides/
keywords:
- clona diapositiva
- copia diapositiva
- salva diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Duplica rapidamente le diapositive PowerPoint con Aspose.Slides per Node.js. Segui i nostri esempi di codice per automatizzare la creazione di PPT in pochi secondi ed eliminare il lavoro manuale."
---
## **Introduzione**

Il clonaggio è il processo di creare una copia esatta o una replica di qualcosa. Aspose.Slides per Node.js via Java consente inoltre di creare una copia o un clone di qualsiasi diapositiva e quindi inserire quella diapositiva clonata nella presentazione corrente o in qualsiasi altra presentazione aperta. Il processo di clonazione delle diapositive crea una nuova diapositiva che può essere modificata dagli sviluppatori senza modificare la diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clona alla fine all'interno di una presentazione.
- Clona in un'altra posizione all'interno della presentazione.
- Clona alla fine in un'altra presentazione.
- Clona in un'altra posizione in un'altra presentazione.
- Clona in una posizione specifica in un'altra presentazione.

In Aspose.Slides per Node.js via Java, (una raccolta di oggetti [Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Slide) ) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) fornisce i metodi [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) e [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) per eseguire i tipi di clonazione diapositive descritti sopra

## **Clona alla fine all'interno di una presentazione**
Se desideri clonare una diapositiva e quindi utilizzarla all'interno dello stesso file di presentazione alla fine delle diapositive esistenti, usa il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) secondo i passaggi elencati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Instanzia la classe [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) facendo riferimento alla collezione Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) e passa la diapositiva da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Scrivi il file della presentazione modificata.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (situata nella prima posizione – indice zero – della presentazione) alla fine della presentazione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanzia la classe Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clona la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Scrivi la presentazione modificata su disco
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clona in un'altra posizione all'interno della presentazione**
Se desideri clonare una diapositiva e quindi utilizzarla all'interno dello stesso file di presentazione ma in una posizione diversa, usa il metodo [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Instanzia la classe facendo riferimento alla collezione [**Slides**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) e passa la diapositiva da clonare insieme all'indice per la nuova posizione come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Scrivi la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (situata all'indice 1 – posizione 2 – della presentazione) all'indice 2 – posizione 3 – della presentazione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanzia la classe Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clona la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione
    var slds = pres.getSlides();
    // Clona la diapositiva desiderata nell'indice specificato nella stessa presentazione
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Scrivi la presentazione modificata su disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clona alla fine in un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un altro file di presentazione, alla fine delle diapositive esistenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione di destinazione a cui la diapositiva sarà aggiunta.
1. Instanzia la classe [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection) facendo riferimento alla collezione [**Slides**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) e passa la diapositiva della presentazione sorgente come parametro al metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (dal primo indice della presentazione di origine) alla fine della presentazione di destinazione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanzia la classe Presentation per caricare il file di presentazione sorgente
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanzia la classe Presentation per la PPTX di destinazione (dove la diapositiva sarà clonata)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clona la diapositiva desiderata dalla presentazione sorgente alla fine della collezione di diapositive nella presentazione di destinazione
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Scrivi la presentazione di destinazione su disco
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clona in un'altra posizione in un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un altro file di presentazione, in una posizione specifica:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione di origine da cui la diapositiva verrà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione a cui la diapositiva sarà aggiunta.
1. Instanzia la classe [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) facendo riferimento alla collezione Slides esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) e passa la diapositiva della presentazione sorgente insieme alla posizione desiderata come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (dal indice zero della presentazione di origine) all'indice 1 (posizione 2) della presentazione di destinazione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanzia la classe Presentation per caricare il file di presentazione sorgente
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanzia la classe Presentation per la PPTX di destinazione (dove la diapositiva sarà clonata)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clona la diapositiva desiderata dalla presentazione sorgente alla fine della collezione di diapositive nella presentazione di destinazione
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Scrivi la presentazione di destinazione su disco
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clona in una posizione specifica in un'altra presentazione**
Se devi clonare una diapositiva con una diapositiva master da una presentazione e usarla in un'altra presentazione, devi prima clonare la diapositiva master desiderata dalla presentazione di origine alla presentazione di destinazione. Successivamente devi usare quel master per clonare la diapositiva con master. Il metodo [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) si aspetta un master dalla presentazione di destinazione, non da quella di origine. Per clonare la diapositiva con master, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione di origine da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione di destinazione a cui la diapositiva sarà clonata.
1. Accedi alla diapositiva da clonare insieme alla diapositiva master.
1. Instanzia la classe [MasterSlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MasterSlideCollection) facendo riferimento alla collezione Masters esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) esposto dall'oggetto [MasterSlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MasterSlideCollection) e passa il master del PPTX di origine da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Instanzia la classe [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) impostando il riferimento alla collezione Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) e passa la diapositiva della presentazione di origine da clonare e il master come parametri al metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva con master (situata all'indice zero della presentazione di origine) alla fine della presentazione di destinazione utilizzando un master dalla diapositiva di origine.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanzia la classe Presentation per caricare il file di presentazione sorgente
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanzia la classe Presentation per la presentazione di destinazione (dove la diapositiva sarà clonata)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instanzia ISlide dalla collezione di diapositive nella presentazione sorgente insieme a
        // Diapositiva master
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clona la diapositiva master desiderata dalla presentazione sorgente alla collezione di master nella
        // presentazione di destinazione
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Clona la diapositiva desiderata dalla presentazione sorgente con il master desiderato alla fine della
        // collezione di diapositive nella presentazione di destinazione
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Salva la presentazione di destinazione su disco
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clona alla fine in una sezione specificata**
Se desideri clonare una diapositiva e quindi usarla all'interno dello stesso file di presentazione ma in una sezione diversa, utilizza il metodo [**addClone**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) esposto dalla classe [**SlideCollection**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides per Node.js via Java rende possibile clonare una diapositiva dalla prima sezione e quindi inserire quella diapositiva clonata nella seconda sezione della stessa presentazione.

Il frammento di codice seguente mostra come clonare una diapositiva e inserire la diapositiva clonata in una sezione specificata.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Salva la presentazione di destinazione su disco
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Assicurare dimensioni della diapositiva corrispondenti**

Quando cloni diapositive in un'altra presentazione, assicurati che la presentazione di destinazione abbia le stesse dimensioni della diapositiva della sorgente. Se le dimensioni delle diapositive differiscono, Aspose.Slides non ridimensiona automaticamente le forme clonate: le loro coordinate e dimensioni originali vengono preservate, il che può far apparire il contenuto disallineato o estendersi oltre i bordi della diapositiva.

Puoi impostare le dimensioni della diapositiva della presentazione di destinazione per farle corrispondere a quelle della sorgente prima di clonare il master e la diapositiva:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Fallo prima di clonare il master e la diapositiva.

## **FAQ**

**Le note del relatore e i commenti dei revisori vengono clonati?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nel clone. Se non li desideri, [rimuovili](/slides/it/nodejs-java/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro fonti dati?**

L'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad es., una cartella di lavoro OLE incorporata), quel collegamento è preservato come un [oggetto OLE](/slides/it/nodejs-java/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per il clone?**

Sì. Puoi inserire il clone in un indice di diapositiva specifico e posizionarlo in una [sezione](/slides/it/nodejs-java/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.