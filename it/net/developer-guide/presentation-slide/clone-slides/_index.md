---
title: Clona diapositive di presentazione in .NET
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

Il clonaggio è il processo di creare una copia esatta o una replica di qualcosa. Aspose.Slides consente inoltre di copiare (clonare) qualsiasi diapositiva e poi inserire la diapositiva clonata nella presentazione corrente o in qualsiasi altra presentazione aperta. Il clonaggio diapositive crea una nuova diapositiva che gli sviluppatori possono modificare senza influire sulla diapositiva originale. Esistono diversi modi per clonare una diapositiva:

- Clona alla fine di una presentazione.  
- Clona in un’altra posizione all’interno di una presentazione.  
- Clona alla fine di un’altra presentazione.  
- Clona in un’altra posizione in un’altra presentazione.  
- Clona in una posizione specifica in un’altra presentazione.

In Aspose.Slides for .NET, la collezione di diapositive (una collezione di oggetti [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/) ) esposta dall’oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) fornisce i metodi [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) e [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/insertclone/) per eseguire le operazioni di clonaggio descritte sopra.

## **Clona una diapositiva alla fine di una presentazione**

Se desideri clonare una diapositiva e poi usarla all’interno dello stesso file di presentazione alla fine delle diapositive esistenti, utilizza il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) secondo i passaggi elencati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).  
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) facendo riferimento alla collezione Slides esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).  
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) esposto dall'oggetto [ISlideCollection] e passa la diapositiva da clonare come parametro al metodo [AddClone].  
1. Scrivi il file di presentazione modificato.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (situata nella prima posizione – indice zero – della presentazione) alla fine della presentazione.

```c#
// Istanzia la classe Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Clona la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Scrivi la presentazione modificata su disco
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Clona una diapositiva in un'altra posizione all'interno di una presentazione**

Se desideri clonare una diapositiva e poi usarla nello stesso file di presentazione ma in una posizione diversa, utilizza il metodo [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).  
1. Istanzia la classe facendo riferimento alla collezione **Slides** esposta dall'oggetto [Presentation].  
1. Chiama il metodo [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides.ishapecollection/insertclone/methods/1) esposto dall'oggetto [ISlideCollection] e passa la diapositiva da clonare insieme all’indice per la nuova posizione come parametro al metodo [InsertClone].  
1. Scrivi la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (situata all'indice zero – posizione 1 – della presentazione) all'indice 1 – Posizione 2 – della presentazione.

```c#
// Instanzia la classe Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Clona la diapositiva desiderata alla fine della collezione di diapositive nella stessa presentazione
    ISlideCollection slds = pres.Slides;

    // Clona la diapositiva desiderata all'indice specificato nella stessa presentazione
    slds.InsertClone(2, pres.Slides[1]);

    // Scrivi la presentazione modificata su disco
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Clona una diapositiva alla fine di un'altra presentazione**

Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, alla fine delle diapositive esistenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione da cui la diapositiva sarà clonata.  
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione di destinazione a cui la diapositiva sarà aggiunta.  
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) facendo riferimento alla collezione **Slides** esposta dall'oggetto Presentation della presentazione di destinazione.  
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) esposto dall'oggetto [ISlideCollection] e passa la diapositiva dalla presentazione sorgente come parametro al metodo [AddClone].  
1. Scrivi il file di presentazione di destinazione modificato.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (dal primo indice della presentazione sorgente) alla fine della presentazione di destinazione.

```c#
// Instanzia la classe Presentation per caricare il file di presentazione sorgente
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanzia la classe Presentation per il PPTX di destinazione (dove la diapositiva sarà clonata)
    using (Presentation destPres = new Presentation())
    {
        // Clona la diapositiva desiderata dalla presentazione sorgente alla fine della collezione di diapositive nella presentazione di destinazione
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Scrivi la presentazione di destinazione su disco
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Clona una diapositiva in un'altra posizione in un'altra presentazione**

Se devi clonare una diapositiva da una presentazione e usarla in un'altra presentazione, in una posizione specifica:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione sorgente da cui la diapositiva sarà clonata.  
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione a cui la diapositiva sarà aggiunta.  
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) facendo riferimento alla collezione Slides esposta dall'oggetto Presentation della presentazione di destinazione.  
1. Chiama il metodo [InsertClone](https://reference.aspose.com/slides/it/net/aspose.slides.ishapecollection/insertclone/methods/1) esposto dall'oggetto [ISlideCollection] e passa la diapositiva dalla presentazione sorgente insieme alla posizione desiderata come parametro al metodo [InsertClone].  
1. Scrivi il file di presentazione di destinazione modificato.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva (dal indice zero della presentazione sorgente) all'indice 1 (posizione 2) della presentazione di destinazione.

```c#
// Instanzia la classe Presentation per caricare il file di presentazione sorgente
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanzia la classe Presentation per il PPTX di destinazione (dove la diapositiva sarà clonata)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Scrivi la presentazione di destinazione su disco
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Clona una diapositiva in una posizione specifica in un'altra presentazione**

Se devi clonare una diapositiva con una diapositiva master da una presentazione e usarla in un'altra, devi prima clonare la diapositiva master desiderata dalla presentazione sorgente a quella di destinazione. Successivamente, utilizzerai tale master per clonare la diapositiva con master. Il metodo **AddClone(ISlide, IMasterSlide)** richiede un master slide della presentazione di destinazione, non quello della sorgente. Per clonare la diapositiva con master, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione sorgente da cui la diapositiva sarà clonata.  
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) contenente la presentazione di destinazione a cui la diapositiva sarà clonata.  
1. Accedi alla diapositiva da clonare insieme alla diapositiva master.  
1. Istanzia la classe [IMasterSlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslidecollection) facendo riferimento alla collezione Masters esposta dall'oggetto [Presentation] della presentazione di destinazione.  
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) esposto dall'oggetto [IMasterSlideCollection] e passa il master dalla presentazione PPTX sorgente da clonare come parametro al metodo [AddClone].  
1. Istanzia la classe [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) impostando il riferimento alla collezione Slides esposta dall'oggetto [Presentation] della presentazione di destinazione.  
1. Chiama il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) esposto dall'oggetto [ISlideCollection] e passa la diapositiva dalla presentazione sorgente da clonare e il master slide come parametro al metodo [AddClone].  
1. Scrivi il file di presentazione di destinazione modificato.

Nell'esempio riportato di seguito, abbiamo clonato una diapositiva con master (situata all'indice zero della presentazione sorgente) alla fine della presentazione di destinazione utilizzando un master della diapositiva sorgente.

```c#
// Instanzia la classe Presentation per caricare il file di presentazione sorgente

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instanzia la classe Presentation per la presentazione di destinazione (dove la diapositiva sarà clonata)
    using (Presentation destPres = new Presentation())
    {

        // Instanzia ISlide dalla collezione di diapositive nella presentazione sorgente insieme a
        // slide master
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clona il master slide desiderato dalla presentazione sorgente alla collezione di master nella
        // presentazione di destinazione
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clona il master slide desiderato dalla presentazione sorgente alla collezione di master nella
        // presentazione di destinazione
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Clona la diapositiva desiderata dalla presentazione sorgente con il master desiderato alla fine della
        // collezione di diapositive nella presentazione di destinazione
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Clona il master slide desiderato dalla presentazione sorgente alla collezione di master nella // Destination presentation
        // Salva la presentazione di destinazione su disco
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Clona una diapositiva alla fine di una sezione specificata**

Con Aspose.Slides for .NET, puoi clonare una diapositiva da una sezione di una presentazione e inserire tale diapositiva in un'altra sezione della stessa presentazione. In questo caso, devi utilizzare il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone/index) dell’interfaccia [ISlideCollection].

Questo codice C# mostra come clonare una diapositiva e inserire la diapositiva clonata in una sezione specificata:

```c#
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

## **FAQ**

**Le note del relatore e i commenti dei revisori vengono clonate?**

Sì. La pagina delle note e i commenti di revisione sono inclusi nella clonazione. Se non li desideri, [rimuoverli](/slides/it/net/presentation-notes/) dopo l'inserimento.

**Come vengono gestiti i grafici e le loro fonti dati?**

L'oggetto grafico, la formattazione e i dati incorporati vengono copiati. Se il grafico era collegato a una fonte esterna (ad esempio, una cartella di lavoro OLE incorporata), quel collegamento viene preservato come [OLE object](/slides/it/net/manage-ole/). Dopo lo spostamento tra file, verifica la disponibilità dei dati e il comportamento di aggiornamento.

**Posso controllare la posizione di inserimento e le sezioni per la clonazione?**

Sì. Puoi inserire la clonazione in un indice diapositiva specifico e posizionarla in una [sezione](/slides/it/net/slide-section/) scelta. Se la sezione di destinazione non esiste, creala prima e poi sposta la diapositiva al suo interno.