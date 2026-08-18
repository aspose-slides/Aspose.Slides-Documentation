---
title: Clona le diapositive di presentazione in .NET
linktitle: Clona diapositive
type: docs
weight: 40
url: /it/net/clone-slides/
keywords:
- clona diapositiva
- copia diapositiva
- salva diapositiva
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Duplica rapidamente le diapositive PowerPoint con Aspose.Slides per .NET. Segui i nostri chiari esempi di codice per automatizzare la creazione di PPT in pochi secondi ed eliminare il lavoro manuale."
---
## **Introduzione**

Il clonaggio è il processo di creare una copia esatta o una replica di qualcosa. Aspose.Slides consente anche di copiare (clonare) qualsiasi diapositiva e quindi inserire la diapositiva clonata nella presentazione corrente o in un'altra presentazione aperta. Il clonaggio di diapositive crea una nuova diapositiva che gli sviluppatori possono modificare senza influire sulla diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clona alla fine di una presentazione.
- Clona in un'altra posizione all'interno di una presentazione.
- Clona alla fine di un'altra presentazione.
- Clona in un'altra posizione in un'altra presentazione.
- Clona insieme alla sua diapositiva master in un'altra presentazione.

In Aspose.Slides per .NET, la raccolta di diapositive (una raccolta di oggetti [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/) ) esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) fornisce i metodi [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) e [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/insertclone/) per eseguire le operazioni di clonazione delle diapositive descritte sopra.

## **Clona una diapositiva alla fine di una presentazione**

Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione alla fine delle diapositive esistenti, utilizza il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) secondo i passaggi elencati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) facendo riferimento alla raccolta Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) e passa la diapositiva da clonare come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Scrivi il file della presentazione modificata.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (situata nella prima posizione – indice zero – della presentazione) alla fine della presentazione.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Clona la diapositiva desiderata alla fine della raccolta di diapositive nella stessa presentazione
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Scrivi la presentazione modificata su disco
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Clona una diapositiva in un'altra posizione all'interno di una presentazione**

Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una posizione diversa, utilizza il metodo [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides.ishapecollection/insertclone/methods/1) :

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
1. Istanzia la classe facendo riferimento alla raccolta **Slides** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
1. Chiama il metodo [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides.ishapecollection/insertclone/methods/1) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) e passa la diapositiva da clonare insieme all'indice per la nuova posizione come parametro al metodo [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides.ishapecollection/insertclone/methods/1) .
1. Scrivi la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (situata all'indice 1 – posizione 2 – della presentazione) all'indice 2 – posizione 3 – della presentazione.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Clona la diapositiva desiderata alla fine della raccolta di diapositive nella stessa presentazione
    ISlideCollection slds = pres.Slides;

    // Clona la diapositiva desiderata all'indice specificato nella stessa presentazione
    slds.InsertClone(2, pres.Slides[1]);

    // Scrivi la presentazione modificata su disco
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Clona una diapositiva alla fine di un'altra presentazione**

Se è necessario clonare una diapositiva da una presentazione e usarla in un altro file di presentazione, alla fine delle diapositive esistenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione da cui verrà clonata la diapositiva.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione di destinazione a cui verrà aggiunta la diapositiva.
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) facendo riferimento alla raccolta **Slides** esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) e passa la diapositiva della presentazione di origine come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (dal primo indice della presentazione di origine) alla fine della presentazione di destinazione.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation per caricare il file di presentazione di origine
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Istanzia la classe Presentation per il PPTX di destinazione (dove la diapositiva deve essere clonata)
    using (Presentation destPres = new Presentation())
    {
        // Clona la diapositiva desiderata dalla presentazione di origine alla fine della raccolta di diapositive nella presentazione di destinazione
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Scrivi la presentazione di destinazione su disco
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Clona una diapositiva in un'altra posizione in un'altra presentazione**

Se è necessario clonare una diapositiva da una presentazione e usarla in un altro file di presentazione, in una posizione specifica:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione di origine da cui verrà clonata la diapositiva.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione a cui verrà aggiunta la diapositiva.
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) facendo riferimento alla raccolta Slides esposta dall'oggetto Presentation della presentazione di destinazione.
1. Chiama il metodo [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides.ishapecollection/insertclone/methods/1) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) e passa la diapositiva della presentazione di origine insieme alla posizione desiderata come parametro al metodo [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides.ishapecollection/insertclone/methods/1) .
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (dal indice zero della presentazione di origine) all'indice 1 (posizione 2) della presentazione di destinazione.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation per caricare il file di presentazione di origine
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Istanzia la classe Presentation per il PPTX di destinazione (dove la diapositiva deve essere clonata)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Scrivi la presentazione di destinazione su disco
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Clona una diapositiva con la sua diapositiva master in un'altra presentazione**

Se è necessario clonare una diapositiva con una diapositiva master da una presentazione e usarla in un'altra presentazione, è necessario clonare prima la diapositiva master desiderata dalla presentazione di origine a quella di destinazione. Successivamente occorre utilizzare quella master per clonare la diapositiva con master. Il metodo **AddClone(ISlide, IMasterSlide)** si aspetta una master slide dalla presentazione di destinazione anziché da quella di origine. Per clonare la diapositiva con una master, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione di origine da cui verrà clonata la diapositiva.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione di destinazione a cui verrà clonata la diapositiva.
1. Accedi alla diapositiva da clonare insieme alla diapositiva master.
1. Istanzia la classe [IMasterSlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection) facendo riferimento alla raccolta Masters esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) della presentazione di destinazione.
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) esposto dall'oggetto [IMasterSlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection) e passa la master dal PPTX di origine da clonare come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) impostando il riferimento alla raccolta Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) della presentazione di destinazione.
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) esposto dall'oggetto [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) e passa la diapositiva della presentazione di origine da clonare e la master slide come parametro al metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) .
1. Scrivi il file della presentazione di destinazione modificata.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva con una master (situata all'indice zero della presentazione di origine) alla fine della presentazione di destinazione utilizzando una master dalla diapositiva di origine.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation per caricare il file di presentazione di origine

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Istanzia la classe Presentation per la presentazione di destinazione (dove la diapositiva deve essere clonata)
    using (Presentation destPres = new Presentation())
    {

        // Istanzia ISlide dalla raccolta di diapositive nella presentazione di origine insieme a
        // Diapositiva master
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clona la master slide desiderata dalla presentazione di origine nella raccolta di master in
        // Presentazione di destinazione
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clona la master slide desiderata dalla presentazione di origine nella raccolta di master in
        // Presentazione di destinazione
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Clona la diapositiva desiderata dalla presentazione di origine con la master desiderata alla fine della
        // Raccolta di diapositive nella presentazione di destinazione
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Clona la master slide desiderata dalla presentazione di origine nella raccolta di master nella // presentazione di destinazione
        // Salva la presentazione di destinazione su disco
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Clona una diapositiva alla fine di una sezione specificata**

Con Aspose.Slides per .NET, è possibile clonare una diapositiva da una sezione di una presentazione e inserire quella diapositiva in un'altra sezione della stessa presentazione. In questo caso, devi utilizzare il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) dall'interfaccia [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) .

Questo codice C# mostra come clonare una diapositiva e inserire la diapositiva clonata in una sezione specificata:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // da clonare
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Assicurati che le dimensioni della diapositiva corrispondano**

Quando cloni diapositive in un'altra presentazione, assicurati che la presentazione di destinazione abbia le stesse dimensioni della diapositiva dell'origine. Se le dimensioni delle diapositive differiscono, Aspose.Slides non ridimensiona automaticamente le forme clonate: le loro coordinate e dimensioni originali vengono mantenute, il che può far apparire il contenuto disallineato o estendersi oltre i bordi della diapositiva.

Puoi impostare le dimensioni della diapositiva della presentazione di destinazione per farle corrispondere a quelle dell'origine prima di clonare la master e la diapositiva:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Fallo prima di clonare la master e la diapositiva.

## **FAQ**

**Le note del relatore e i commenti dei revisori vengono clonate?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nella clonazione. Se non li desideri, [rimuovili](/slides/it/net/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro origini dati?**

L'oggetto del grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad esempio, una cartella di lavoro OLE incorporata), quel collegamento viene mantenuto come [oggetto OLE](/slides/it/net/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per la clonazione?**

Sì. Puoi inserire la clonazione a un indice di diapositiva specifico e collocarla in una [sezione](/slides/it/net/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.