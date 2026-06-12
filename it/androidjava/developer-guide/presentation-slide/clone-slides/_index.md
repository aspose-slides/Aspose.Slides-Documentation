---
title: Clona diapositive di presentazione su Android
linktitle: Clona diapositive
type: docs
weight: 35
url: /it/androidjava/clone-slides/
keywords:
- clona diapositiva
- copia diapositiva
- salva diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Duplica le diapositive PowerPoint con Aspose.Slides per Android. Segui i nostri chiari esempi di codice Java per automatizzare la creazione di PPT in pochi secondi ed eliminare il lavoro manuale."
---
## **Introduzione**

La clonazione è il processo di creare una copia o replica esatta di qualcosa. Aspose.Slides per Android tramite Java consente anche di creare una copia o clone di qualsiasi diapositiva e quindi inserire quella diapositiva clonata nella presentazione corrente o in qualsiasi altra presentazione aperta. Il processo di clonazione di una diapositiva crea una nuova diapositiva che può essere modificata dagli sviluppatori senza alterare la diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clona alla fine all'interno di una presentazione.
- Clona in un'altra posizione all'interno di una presentazione.
- Clona alla fine in un'altra presentazione.
- Clona in un'altra posizione in un'altra presentazione.
- Clona in una posizione specifica in un'altra presentazione.

In Aspose.Slides per Android tramite Java, (una raccolta di [ISlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlide) objects) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) fornisce i metodi [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) e [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) per eseguire i tipi di clonazione diapositive descritti sopra.

## **Clonare una diapositiva alla fine di una presentazione**
Se desideri clonare una diapositiva e poi usarla nella stessa presentazione alla fine delle diapositive esistenti, utilizza il metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) secondo i passaggi elencati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Istanzi la classe [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) facendo riferimento alla raccolta Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Scrivi il file della presentazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata nella prima posizione – indice zero – della presentazione) alla fine della presentazione.

```java
// Istanzia la classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clona la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Scrivi la presentazione modificata su disco
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonare una diapositiva in un'altra posizione all'interno di una presentazione**
Se desideri clonare una diapositiva e poi usarla nella stessa presentazione ma in una posizione diversa, utilizza il metodo [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Istanzi la classe facendo riferimento alla raccolta [**Slides**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva da clonare insieme all'indice per la nuova posizione come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata nell'indice zero – posizione 1 – della presentazione) all'indice 1 – Posizione 2 – della presentazione.

```java
// Istanzia la classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clona la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione
    ISlideCollection slds = pres.getSlides();

    // Clona la diapositiva desiderata all'indice specificato nella stessa presentazione
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Scrivi la presentazione modificata su disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonare una diapositiva alla fine di un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, alla fine delle diapositive esistenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) che contiene la presentazione da cui la diapositiva verrà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) che contiene la presentazione di destinazione a cui la diapositiva sarà aggiunta.
1. Istanzi la classe [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection) facendo riferimento alla raccolta [**Slides**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione sorgente come parametro al metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dal primo indice della presentazione sorgente) alla fine della presentazione di destinazione.

```java
// Istanzia la classe Presentation per caricare il file di presentazione sorgente
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Istanzia la classe Presentation per il PPTX di destinazione (dove la diapositiva verrà clonata)
    Presentation destPres = new Presentation();
    try {
        // Clona la diapositiva desiderata dalla presentazione sorgente alla fine della collezione di diapositive nella presentazione di destinazione
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Scrivi la presentazione di destinazione su disco
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonare una diapositiva in un'altra posizione in un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, in una posizione specifica:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) che contiene la presentazione sorgente da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) che contiene la presentazione a cui la diapositiva sarà aggiunta.
1. Istanzi la classe [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) facendo riferimento alla raccolta Slides esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione sorgente insieme alla posizione desiderata come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dall'indice zero della presentazione sorgente) all'indice 1 (posizione 2) della presentazione di destinazione.

```java
// Istanzia la classe Presentation per caricare il file di presentazione sorgente
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Istanzia la classe Presentation per il PPTX di destinazione (dove la diapositiva verrà clonata)
    Presentation destPres = new Presentation();
    try {
        // Clona la diapositiva desiderata dalla presentazione sorgente alla fine della collezione di diapositive nella presentazione di destinazione
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Scrivi la presentazione di destinazione su disco
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonare una diapositiva in una posizione specifica in un'altra presentazione**
Se devi clonare una diapositiva con una diapositiva master da una presentazione e usarla in un'altra presentazione, devi prima clonare la diapositiva master desiderata dalla presentazione sorgente alla presentazione di destinazione. Successivamente, devi usare quella master per clonare la diapositiva con master. Il metodo [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) richiede una master slide della presentazione di destinazione, non quella della sorgente. Per clonare la diapositiva con master, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) che contiene la presentazione sorgente da cui la diapositiva sarà clonata.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) che contiene la presentazione di destinazione a cui la diapositiva sarà clonata.
1. Accedi alla diapositiva da clonare insieme alla master slide.
1. Istanzi la classe [IMasterSlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IMasterSlideCollection) facendo riferimento alla raccolta Masters esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall'oggetto [IMasterSlideCollection] e passa la master della presentazione PPTX sorgente da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Istanzi la classe [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) impostando il riferimento alla raccolta Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione sorgente da clonare insieme alla master slide come parametro al metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva con master (situata nell'indice zero della presentazione sorgente) alla fine della presentazione di destinazione usando la master della diapositiva sorgente.

```java
// Istanzia la classe Presentation per caricare il file di presentazione sorgente
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Istanzia la classe Presentation per la presentazione di destinazione (dove la diapositiva sarà clonata)
    Presentation destPres = new Presentation();
    try {
        // Istanzia ISlide dalla collezione di diapositive nella presentazione sorgente insieme a
        // diapositiva master
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clona la master slide desiderata dalla presentazione sorgente alla collezione di master nella
        // presentazione di destinazione
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clona la master slide desiderata dalla presentazione sorgente alla collezione di master nella
        // presentazione di destinazione
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Clona la diapositiva desiderata dalla presentazione sorgente con il master desiderato alla fine della
        // collezione di diapositive nella presentazione di destinazione
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Salva la presentazione di destinazione su disco
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonare una diapositiva alla fine di una sezione specificata**
Se desideri clonare una diapositiva e poi usarla nella stessa presentazione ma in una sezione diversa, utilizza il metodo [**addClone**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) esposto dall'interfaccia [**ISlideCollection**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides per Android tramite Java rende possibile clonare una diapositiva dalla prima sezione e quindi inserire quella diapositiva clonata nella seconda sezione della stessa presentazione.

Il frammento di codice seguente mostra come clonare una diapositiva e inserire la diapositiva clonata in una sezione specificata.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Salva la presentazione di destinazione su disco
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Le note del relatore e i commenti dei revisori vengono clonate?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nella copia. Se non li desideri, [rimuovili](/slides/it/androidjava/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro origini dati?**

L'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad es., una cartella di lavoro OLE incorporata), quel collegamento viene mantenuto come [oggetto OLE](/slides/it/androidjava/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per la copia?**

Sì. Puoi inserire la copia in un indice di diapositiva specifico e posizionarla in una [sezione](/slides/it/androidjava/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.