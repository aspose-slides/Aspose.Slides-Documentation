---
title: "Clona diapositive della presentazione in JavaScript"
linktitle: "Clona Diapositive"
type: docs
weight: 35
url: /it/nodejs-java/clone-slides/
keywords:
- "clona diapositiva"
- "copia diapositiva"
- "salva diapositiva"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Duplica rapidamente le diapositive PowerPoint con Aspose.Slides per Node.js. Segui i nostri esempi di codice per automatizzare la creazione di PPT in pochi secondi ed eliminare il lavoro manuale."
---
## **Introduzione**

Il clonaggio è il processo di creazione di una copia esatta o replica di qualcosa. Aspose.Slides per Node.js via Java consente anche di creare una copia o clonare qualsiasi diapositiva e poi inserire quella diapositiva clonata nella presentazione corrente o in qualsiasi altra presentazione aperta. Il processo di clonazione di una diapositiva crea una nuova diapositiva che può essere modificata dagli sviluppatori senza alterare la diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clona alla fine all'interno di una presentazione.
- Clona in un'altra posizione all'interno di una presentazione.
- Clona alla fine in un'altra presentazione.
- Clona in un'altra posizione in un'altra presentazione.
- Clona in una posizione specifica in un'altra presentazione.

In Aspose.Slides per Node.js via Java, (una raccolta di [Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Slide) oggetti) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) fornisce i metodi [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) e [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) per eseguire i tipi di clonazione descritti sopra.

## **Clona alla fine all'interno di una presentazione**
Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione alla fine delle diapositive esistenti, utilizza il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) secondo i passaggi elencati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Istanzia la classe [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) facendo riferimento alla raccolta Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) e passa la diapositiva da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Salva il file di presentazione modificato.

Nell'esempio seguente, abbiamo clonato una diapositiva (situata nella prima posizione – indice zero – della presentazione) alla fine della presentazione.

```javascript
// Istanziare la classe Presentation che rappresenta un file di presentazione
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

## **Clona in un'altra posizione all'interno di una presentazione**
Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una posizione diversa, utilizza il metodo [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Istanzia la classe facendo riferimento alla raccolta [**Slides**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) e passa la diapositiva da clonare insieme all'indice per la nuova posizione come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Salva la presentazione modificata come file PPTX.

Nell'esempio seguente, abbiamo clonato una diapositiva (situata all'indice zero – posizione 1 – della presentazione) all'indice 1 – Posizione 2 – della presentazione.

```javascript
// Istanziare la classe Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clona la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione
    var slds = pres.getSlides();
    // Clona la diapositiva desiderata all'indice specificato nella stessa presentazione
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Scrivi la presentazione modificata su disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clona alla fine in un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, alla fine delle diapositive esistenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione da cui la diapositiva verrà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione di destinazione a cui la diapositiva sarà aggiunta.
1. Istanzia la classe [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection) facendo riferimento alla raccolta [**Slides**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione di origine come parametro al metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Salva il file della presentazione di destinazione modificato.

Nell'esempio seguente, abbiamo clonato una diapositiva (dal primo indice della presentazione di origine) alla fine della presentazione di destinazione.

```javascript
// Istanziare la classe Presentation per caricare il file di presentazione di origine
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Istanziare la classe Presentation per il PPTX di destinazione (dove la diapositiva verrà clonata)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clona la diapositiva desiderata dalla presentazione di origine alla fine della collezione di diapositive nella presentazione di destinazione
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
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, in una posizione specifica:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione di origine da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione a cui la diapositiva sarà aggiunta.
1. Istanzia la classe [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) facendo riferimento alla raccolta Slides esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione di origine insieme alla posizione desiderata come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Salva il file della presentazione di destinazione modificato.

Nell'esempio seguente, abbiamo clonato una diapositiva (dal indice zero della presentazione di origine) all'indice 1 (posizione 2) della presentazione di destinazione.

```javascript
// Istanziare la classe Presentation per caricare il file di presentazione di origine
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Istanziare la classe Presentation per il PPTX di destinazione (dove la diapositiva verrà clonata)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clonare la diapositiva desiderata dalla presentazione di origine alla fine della collezione di diapositive nella presentazione di destinazione
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Scrivere la presentazione di destinazione su disco
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clona in una posizione specifica in un'altra presentazione**
Se devi clonare una diapositiva con una diapositiva master da una presentazione e usarla in un'altra presentazione, devi prima clonare la diapositiva master desiderata dalla presentazione di origine a quella di destinazione. Successivamente, utilizza quella master per clonare la diapositiva con master. Il metodo [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) richiede una master slide dalla presentazione di destinazione anziché da quella di origine. Per clonare la diapositiva con master, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione di origine da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) contenente la presentazione di destinazione a cui la diapositiva sarà clonata.
1. Accedi alla diapositiva da clonare insieme alla master slide.
1. Istanzia la classe [MasterSlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MasterSlideCollection) facendo riferimento alla raccolta Masters esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) esposto dall'oggetto [MasterSlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MasterSlideCollection) e passa la master dalla presentazione PPTX di origine da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Istanzia la classe [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) impostando il riferimento alla raccolta Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) esposto dall'oggetto [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione di origine da clonare e la master slide come parametro al metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Salva il file della presentazione di destinazione modificato.

Nell'esempio seguente, abbiamo clonato una diapositiva con master (situata all'indice zero della presentazione di origine) alla fine della presentazione di destinazione usando una master dalla diapositiva di origine.

```javascript
// Istanziare la classe Presentation per caricare il file di presentazione di origine
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Istanziare la classe Presentation per la presentazione di destinazione (dove la diapositiva sarà clonata)
    var destPres = new aspose.slides.Presentation();
    try {
        // Istanziare ISlide dalla collezione di diapositive nella presentazione di origine insieme a
        // diapositiva master
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clonare la diapositiva master desiderata dalla presentazione di origine alla collezione di master nella
        // presentazione di destinazione
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clonare la diapositiva master desiderata dalla presentazione di origine alla collezione di master nella
        // presentazione di destinazione
        var iSlide = masters.addClone(SourceMaster);
        // Clonare la diapositiva desiderata dalla presentazione di origine con il master desiderato alla fine della
        // collezione di diapositive nella presentazione di destinazione
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Salvare la presentazione di destinazione su disco
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clona alla fine in una sezione specificata**
Se vuoi clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una sezione diversa, utilizza il metodo [**addClone**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) esposto dalla classe [**SlideCollection**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides per Node.js via Java consente di clonare una diapositiva dalla prima sezione e poi inserire quella diapositiva clonata nella seconda sezione della stessa presentazione.

Il frammento di codice seguente mostra come clonare una diapositiva e inserire la diapositiva clonata in una sezione specificata.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Salva la presentazione di destinazione su disco
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Le note del relatore e i commenti dei revisori vengono clonate?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nella copia. Se non li desideri, [rimuoverli](/slides/it/nodejs-java/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro fonti dati?**

L'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad esempio un workbook OLE incorporato), quel collegamento viene conservato come un [oggetto OLE](/slides/it/nodejs-java/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per la copia?**

Sì. Puoi inserire la copia a un indice di diapositiva specifico e posizionarla in una [sezione](/slides/it/nodejs-java/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.