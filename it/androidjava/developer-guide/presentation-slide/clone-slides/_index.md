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

Il cloning è il processo di creazione di una copia esatta o replica di qualcosa. Aspose.Slides for Android via Java permette anche di creare una copia o clone di qualsiasi diapositiva e quindi inserire quella diapositiva clonata nella presentazione corrente o in qualsiasi altra presentazione aperta. Il processo di clonazione delle diapositive crea una nuova diapositiva che può essere modificata dagli sviluppatori senza alterare la diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clona alla fine all'interno di una presentazione.
- Clona in un'altra posizione all'interno della presentazione.
- Clona alla fine in un'altra presentazione.
- Clona in un'altra posizione in un'altra presentazione.
- Clona in una posizione specifica in un'altra presentazione.

In Aspose.Slides for Android via Java, (una collezione di [ISlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlide) objects) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) fornisce i metodi [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) e [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) per eseguire i tipi di clonazione descritti sopra.

## **Clona una diapositiva alla fine di una presentazione**
Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione alla fine delle diapositive esistenti, utilizza il metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) secondo i passaggi elencati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) facendo riferimento alla collezione Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Scrivi il file della presentazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata alla prima posizione – indice zero – della presentazione) alla fine della presentazione.

```java
import com.aspose.slides.*;

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

## **Clona una diapositiva in un'altra posizione all'interno di una presentazione**
Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una posizione diversa, utilizza il metodo [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Istanzia la classe facendo riferimento alla collezione [**Slides**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva da clonare insieme all'indice per la nuova posizione come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (situata all'indice 1 – posizione 2 – della presentazione) all'indice 2 – Posizione 3 – della presentazione.

```java
import com.aspose.slides.*;

// Istanzia la classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Ottieni la collezione di diapositive nella stessa presentazione
    ISlideCollection slds = pres.getSlides();

    // Clona la diapositiva desiderata all'indice specificato nella stessa presentazione
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Scrivi la presentazione modificata su disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clona una diapositiva alla fine di un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, alla fine delle diapositive esistenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) contenente la presentazione da cui verrà clonata la diapositiva.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) contenente la presentazione di destinazione a cui sarà aggiunta la diapositiva.
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection) facendo riferimento alla collezione [**Slides**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione di origine come parametro al metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dal primo indice della presentazione di origine) alla fine della presentazione di destinazione.

```java
import com.aspose.slides.*;

// Istanzia la classe Presentation per caricare il file di presentazione di origine
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Istanzia la classe Presentation per il PPTX di destinazione (dove la diapositiva deve essere clonata)
    Presentation destPres = new Presentation();
    try {
        // Clona la diapositiva desiderata dalla presentazione di origine alla fine della collezione di diapositive nella presentazione di destinazione
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

## **Clona una diapositiva in un'altra posizione in un'altra presentazione**
Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, in una posizione specifica:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) contenente la presentazione di origine da cui verrà clonata la diapositiva.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) contenente la presentazione a cui sarà aggiunta la diapositiva.
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) facendo riferimento alla collezione Slides esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione di origine insieme alla posizione desiderata come parametro al metodo [insertClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva (dal indice zero della presentazione di origine) all'indice 1 (posizione 2) della presentazione di destinazione.

```java
import com.aspose.slides.*;

// Instanzia la classe Presentation per caricare il file di presentazione di origine
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanzia la classe Presentation per il PPTX di destinazione (dove la diapositiva deve essere clonata)
    Presentation destPres = new Presentation();
    try {
        // Clona la diapositiva desiderata dalla presentazione di origine all'indice specificato nella presentazione di destinazione
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Scrivi la presentazione di destinazione su disco
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clona una diapositiva in una posizione specifica in un'altra presentazione**
Se devi clonare una diapositiva con diapositiva master da una presentazione e usarla in un'altra presentazione, devi prima clonare la diapositiva master desiderata dalla presentazione di origine a quella di destinazione. Quindi utilizza quella master per clonare la diapositiva con master. Il metodo [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) richiede una master slide della presentazione di destinazione piuttosto che di quella di origine. Per clonare la diapositiva con master, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) contenente la presentazione di origine da cui verrà clonata la diapositiva.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) contenente la presentazione di destinazione a cui sarà clonata la diapositiva.
1. Accedi alla diapositiva da clonare insieme alla master slide.
1. Istanzia la classe [IMasterSlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IMasterSlideCollection) facendo riferimento alla collezione Masters esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall'oggetto [IMasterSlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IMasterSlideCollection) e passa la master della presentazione PPTX di origine da clonare come parametro al metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) impostando il riferimento alla collezione Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) della presentazione di destinazione.
1. Chiama il metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) e passa la diapositiva dalla presentazione di origine da clonare e la master slide come parametri al metodo [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Scrivi il file della presentazione di destinazione modificato.

Nell'esempio mostrato di seguito, abbiamo clonato una diapositiva con master (situata all'indice zero della presentazione di origine) alla fine della presentazione di destinazione usando una master dalla diapositiva di origine.

```java
import com.aspose.slides.*;

// Istanzia la classe Presentation per caricare il file di presentazione di origine
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Istanzia la classe Presentation per la presentazione di destinazione (dove la diapositiva deve essere clonata)
    Presentation destPres = new Presentation();
    try {
        // Istanzia ISlide dalla collezione di diapositive nella presentazione di origine insieme a
        // Diapositiva master
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clona la master slide desiderata dalla presentazione di origine nella collezione di master nella
        // presentazione di destinazione
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Clona la diapositiva desiderata dalla presentazione di origine con il master desiderato alla fine della
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

## **Clona una diapositiva alla fine di una sezione specificata**
Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una sezione diversa, utilizza il metodo [**addClone**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) esposto dall'interfaccia [**ISlideCollection**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides for Android via Java rende possibile clonare una diapositiva dalla prima sezione e poi inserire quella diapositiva clonata nella seconda sezione della stessa presentazione.

Il frammento di codice seguente mostra come clonare una diapositiva e inserire quella diapositiva clonata in una sezione specificata.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Salva la presentazione di destinazione su disco
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Assicurare dimensioni delle diapositive corrispondenti**

Quando cloni diapositive in un'altra presentazione, assicurati che la presentazione di destinazione abbia le stesse dimensioni di diapositiva della sorgente. Se le dimensioni differiscono, Aspose.Slides non ridimensiona automaticamente le forme clonate: le loro coordinate e dimensioni originali vengono mantenute, il che può provocare un allineamento errato o elementi che fuoriescono dai bordi della diapositiva.

Puoi impostare la dimensione delle diapositive della presentazione di destinazione per farla corrispondere a quella della sorgente prima di clonare la master e la diapositiva:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Esegui questa operazione prima di clonare la master e la diapositiva.

## **FAQ**

**Le note del relatore e i commenti dei revisori vengono clonati?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nella copia. Se non li vuoi, [remove them](/slides/it/androidjava/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro fonti dati?**

L'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad es., una cartella di lavoro OLE incorporata), quel collegamento viene conservato come un [OLE object](/slides/it/androidjava/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per il clone?**

Sì. Puoi inserire il clone a un indice di diapositiva specifico e posizionarlo in una [section](/slides/it/androidjava/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.