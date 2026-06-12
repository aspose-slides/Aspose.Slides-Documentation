---
title: Clona le diapositive di presentazione in Java
linktitle: Clona Diapositive
type: docs
weight: 35
url: /it/java/clone-slides/
keywords:
- clona diapositiva
- copia diapositiva
- salva diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Duplica rapidamente le diapositive PowerPoint con Aspose.Slides per Java. Segui i nostri chiari esempi di codice per automatizzare la creazione di PPT in pochi secondi ed eliminare il lavoro manuale."
---
## **Introduzione**

Il clonaggio è il processo di creazione di una copia esatta o replica di qualcosa. Aspose.Slides for Java consente anche di creare una copia o clone di qualsiasi diapositiva e quindi inserire quella diapositiva clonata nella presentazione corrente o in un’altra presentazione aperta. Il processo di clonazione della diapositiva crea una nuova diapositiva che può essere modificata dagli sviluppatori senza alterare la diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clona alla fine all’interno di una presentazione.
- Clona in un’altra posizione all’interno della presentazione.
- Clona alla fine in un’altra presentazione.
- Clona in un’altra posizione in un’altra presentazione.
- Clona in una posizione specifica in un’altra presentazione.

In Aspose.Slides for Java, (una raccolta di [ISlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlide) objects) esposta dall’oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) fornisce i metodi [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) e [insertClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) per eseguire i tipi di clonazione diapositive descritti sopra.

## **Clonare una diapositiva alla fine di una presentazione**
Se desideri clonare una diapositiva e poi usarla all’interno dello stesso file di presentazione alla fine delle diapositive esistenti, utilizza il metodo [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) secondo i passaggi elencati di seguito:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getSlides--) facendo riferimento alla raccolta Slides esposta dall’oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
3. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall’oggetto [ISlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
4. Scrivi il file della presentazione modificata.

Nell’esempio riportato di seguito, abbiamo clonato una diapositiva (situata alla prima posizione – indice zero – della presentazione) alla fine della presentazione.

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clonare la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Scrivere la presentazione modificata su disco
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonare una diapositiva in un’altra posizione all’interno di una presentazione**
Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una posizione diversa, utilizza il metodo [insertClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Istanzia la classe facendo riferimento alla raccolta [**Slides**](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getSlides--) esposta dall’oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
3. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) esposto dall’oggetto [ISlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva da clonare insieme all’indice per la nuova posizione come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
4. Scrivi la presentazione modificata come file PPTX.

Nell’esempio riportato di seguito, abbiamo clonato una diapositiva (situata all’indice zero – posizione 1 – della presentazione) all’indice 1 – Posizione 2 – della presentazione.

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clonare la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione
    ISlideCollection slds = pres.getSlides();

    // Clonare la diapositiva desiderata all'indice specificato nella stessa presentazione
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Scrivere la presentazione modificata su disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonare una diapositiva alla fine di un’altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un’altra presentazione, alla fine delle diapositive esistenti:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) contenente la presentazione da cui la diapositiva sarà clonata.
2. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) contenente la presentazione di destinazione a cui la diapositiva sarà aggiunta.
3. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection) facendo riferimento alla raccolta [**Slides**](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getSlides--) esposta dall’oggetto Presentation della presentazione di destinazione.
4. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall’oggetto [ISlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione di origine come parametro al metodo [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
5. Scrivi il file della presentazione di destinazione modificato.

Nell’esempio riportato di seguito, abbiamo clonato una diapositiva (dal primo indice della presentazione di origine) alla fine della presentazione di destinazione.

```java
// Istanziare la classe Presentation per caricare il file di presentazione sorgente
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Istanziare la classe Presentation per il PPTX di destinazione (dove la diapositiva deve essere clonata)
    Presentation destPres = new Presentation();
    try {
        // Clonare la diapositiva desiderata dalla presentazione sorgente alla fine della collezione di diapositive nella presentazione di destinazione
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Scrivere la presentazione di destinazione su disco
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonare una diapositiva in un’altra posizione in un’altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un’altra presentazione, in una posizione specifica:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) contenente la presentazione di origine da cui la diapositiva sarà clonata.
2. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) contenente la presentazione a cui la diapositiva sarà aggiunta.
3. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getSlides--) facendo riferimento alla raccolta Slides esposta dall’oggetto Presentation della presentazione di destinazione.
4. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) esposto dall’oggetto [ISlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione di origine insieme alla posizione desiderata come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
5. Scrivi il file della presentazione di destinazione modificato.

Nell’esempio riportato di seguito, abbiamo clonato una diapositiva (dall’indice zero della presentazione di origine) all’indice 1 (posizione 2) della presentazione di destinazione.

```java
// Istanziare la classe Presentation per caricare il file di presentazione sorgente
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Istanziare la classe Presentation per il PPTX di destinazione (dove la diapositiva sarà clonata)
    Presentation destPres = new Presentation();
    try {
        // Clonare la diapositiva desiderata dalla presentazione sorgente alla fine della collezione di diapositive nella presentazione di destinazione
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Scrivere la presentazione di destinazione su disco
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonare una diapositiva in una posizione specifica in un’altra presentazione**
Se devi clonare una diapositiva con una diapositiva master da una presentazione e usarla in un’altra presentazione, è necessario prima clonare la diapositiva master desiderata dalla presentazione di origine a quella di destinazione. Successivamente, utilizza quella diapositiva master per clonare la diapositiva con master. Il metodo [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) richiede una diapositiva master dalla presentazione di destinazione anziché da quella di origine. Per clonare la diapositiva con master, segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) contenente la presentazione di origine da cui la diapositiva sarà clonata.
2. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) contenente la presentazione di destinazione a cui la diapositiva sarà clonata.
3. Accedi alla diapositiva da clonare insieme al master.
4. Istanzia la classe [IMasterSlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IMasterSlideCollection) facendo riferimento alla raccolta Masters esposta dall’oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) della presentazione di destinazione.
5. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall’oggetto [IMasterSlideCollection] e passa il master dalla presentazione PPTX di origine da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
6. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getSlides--) impostando il riferimento alla raccolta Slides esposta dall’oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) della presentazione di destinazione.
7. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall’oggetto [ISlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione di origine da clonare e il master come parametri al metodo [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
8. Scrivi il file della presentazione di destinazione modificato.

Nell’esempio riportato di seguito, abbiamo clonato una diapositiva con master (situata all’indice zero della presentazione di origine) alla fine della presentazione di destinazione utilizzando un master dalla diapositiva di origine.

```java
// Istanziare la classe Presentation per caricare il file di presentazione sorgente
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Istanziare la classe Presentation per la presentazione di destinazione (dove la diapositiva sarà clonata)
    Presentation destPres = new Presentation();
    try {
        // Istanziare ISlide dalla collezione di diapositive nella presentazione sorgente insieme a
        // Diapositiva master
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clonare la diapositiva master desiderata dalla presentazione sorgente alla collezione di master nella
        // presentazione di destinazione
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clonare la diapositiva master desiderata dalla presentazione sorgente alla collezione di master nella
        // presentazione di destinazione
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Clonare la diapositiva desiderata dalla presentazione sorgente con il master desiderato alla fine della
        // collezione di diapositive nella presentazione di destinazione
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Salvare la presentazione di destinazione su disco
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonare una diapositiva alla fine di una sezione specificata**
Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una sezione diversa, utilizza il metodo [**addClone**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) esposto dall’interfaccia [**ISlideCollection**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlideCollection). Aspose.Slides for Java consente di clonare una diapositiva dalla prima sezione e quindi inserire quella diapositiva clonata nella seconda sezione della stessa presentazione.

Il frammento di codice seguente mostra come clonare una diapositiva e inserire la diapositiva clonata in una sezione specificata.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Salvare la presentazione di destinazione su disco
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Le note del relatore e i commenti dei revisori vengono clonati?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nel clone. Se non li desideri, [rimuovili](/slides/it/java/presentation-notes/) dopo l’inserimento.

**Come vengono gestiti i grafici e le loro origini dati?**

L’oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad esempio, una cartella di lavoro OLE incorporata), quel collegamento viene conservato come [oggetto OLE](/slides/it/java/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per il clone?**

Sì. Puoi inserire il clone in un indice di diapositiva specifico e posizionarlo in una [sezione](/slides/it/java/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.