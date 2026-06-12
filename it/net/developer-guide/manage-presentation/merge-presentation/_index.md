---
title: Unisci presentazioni in modo efficiente con .NET
linktitle: Unisci presentazioni
type: docs
weight: 40
url: /it/net/merge-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Unisci senza sforzo presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP) con Aspose.Slides per .NET, semplificando il tuo flusso di lavoro."
---
## **Panoramica**

Aspose.Slides consente di unire presentazioni clonando le diapositive da una presentazione a un'altra. Questo articolo spiega come unire presentazioni complete o diapositive selezionate, utilizzare un master diapositiva o un layout specifico durante l'unione, gestire presentazioni con diverse dimensioni di diapositiva e aggiungere diapositive unite a una sezione della presentazione. Copre anche note pratiche relative al contenuto unito, incluse note del relatore, commenti, file di origine protetti da password e uso dei thread.

## **Ottimizza l'unione delle presentazioni**

Con [Aspose.Slides for .NET](https://products.aspose.com/slides/it/net/), unisci senza problemi le presentazioni PowerPoint mantenendo stili, layout e tutti gli elementi. A differenza di altri strumenti, Aspose.Slides combina le presentazioni senza compromettere la qualità o perdere dati. Unisci presentazioni intere, diapositive specifiche e anche formati di file diversi (PPT in PPTX, ecc.).

### **Funzionalità di unione**

- **Unione completa di presentazione:** Assembla tutte le diapositive in un singolo file.
- **Unione di diapositive specifiche:** Scegli e combina le diapositive selezionate.
- **Unione multiformato:** Integra presentazioni di formati diversi, mantenendo l'integrità.

{{% alert title="Suggerimento" color="primary" %}}  

Cerchi uno strumento **online gratuito** e veloce per **unire presentazioni PowerPoint**? Prova l[**Aspose PowerPoint Merger**](https://products.aspose.app/slides/it/merger).  

- **Unisci facilmente file PowerPoint**: combina più presentazioni **PPT, PPTX, ODP** in un unico file.  
- **Supporta formati diversi**: unisci **PPT in PPTX**, **PPTX in ODP**, e altro.  
- **Nessuna installazione necessaria**: funziona direttamente nel tuo browser, veloce e sicuro.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/it/merger)  

Inizia a unire i tuoi file PowerPoint con lo **strumento online gratuito di Aspose** oggi!  

{{% /alert %}}

## **Unione di presentazioni**

Quando [unisci una presentazione a un'altra](https://products.aspose.com/slides/it/net/merger/ppt/), stai combinando le loro diapositive in una singola presentazione per ottenere un unico file. 

{{% alert title="Informazioni" color="info" %}}

La maggior parte dei programmi di presentazione (PowerPoint o OpenOffice) non dispone di funzioni che consentano agli utenti di combinare le presentazioni in questo modo. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/it/net/) , tuttavia, consente di unire presentazioni in diversi modi. Puoi unire presentazioni con tutte le loro forme, stili, testi, formattazioni, commenti, animazioni, ecc., senza preoccuparti di perdita di qualità o dati. 

**Vedi anche**

[Clona diapositive](https://docs.aspose.com/slides/it/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Cosa può essere unito**

Con Aspose.Slides, è possibile unire 

* presentazioni complete. Tutte le diapositive delle presentazioni finiscono in un'unica presentazione
* diapositive specifiche. Le diapositive selezionate finiscono in un'unica presentazione
* presentazioni in un unico formato (PPT in PPT, PPTX in PPTX, ecc.) e in formati diversi (PPT in PPTX, PPTX in ODP, ecc.) tra loro. 

{{% alert title="Nota" color="warning" %}} 

Oltre alle presentazioni, Aspose.Slides consente di unire altri file:

* [Immagini](https://products.aspose.com/slides/it/net/merger/image-to-image/), come [JPG in JPG](https://products.aspose.com/slides/it/net/merger/jpg-to-jpg/) o [PNG in PNG](https://products.aspose.com/slides/it/net/merger/png-to-png/)
* Documenti, come [PDF in PDF](https://products.aspose.com/slides/it/net/merger/pdf-to-pdf/) o [HTML in HTML](https://products.aspose.com/slides/it/net/merger/html-to-html/)
* E due file diversi come [immagine in PDF](https://products.aspose.com/slides/it/net/merger/image-to-pdf/) o [JPG in PDF](https://products.aspose.com/slides/it/net/merger/jpg-to-pdf/) o [TIFF in PDF](https://products.aspose.com/slides/it/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opzioni di unione**

È possibile applicare opzioni che determinano se

* ogni diapositiva nella presentazione di output mantiene uno stile unico
* uno stile specifico è usato per tutte le diapositive nella presentazione di output. 

Per unire presentazioni, Aspose.Slides fornisce i metodi [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone) (dall'interfaccia [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection)). Esistono diverse implementazioni dei metodi `AddClone` che definiscono i parametri del processo di unione della presentazione. Ogni oggetto Presentation ha una collezione [Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/properties/slides), quindi è possibile chiamare un metodo `AddClone` dalla presentazione in cui si desidera unire le diapositive. 

Il metodo `AddClone` restituisce un oggetto `ISlide`, che è una copia della diapositiva di origine. Le diapositive in una presentazione di output sono semplicemente una copia delle diapositive di origine. Pertanto, è possibile modificare le diapositive risultanti (ad esempio, applicare stili, opzioni di formattazione o layout) senza preoccuparsi che le presentazioni di origine vengano influenzate. 

## **Unisci presentazioni** 

Aspose.Slides fornisce il metodo [**AddClone (ISlide)**](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone) che consente di combinare le diapositive mantenendo i loro layout e stili (parametri predefiniti). 

Questo codice C# mostra come unire le presentazioni:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Unisci presentazioni con un master diapositiva**

Aspose.Slides fornisce il metodo [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/it/net/aspose.slides.islidecollection/addclone/methods/2) che consente di combinare le diapositive applicando un modello di master diapositiva. In questo modo, se necessario, è possibile modificare lo stile delle diapositive nella presentazione di output. 

Questo codice C# dimostra l'operazione descritta:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Nota" color="warning" %}} 

Il layout delle diapositive per il master viene determinato automaticamente. Quando non è possibile determinare un layout appropriato, se il parametro booleano `allowCloneMissingLayout` del metodo `AddClone` è impostato su true, viene utilizzato il layout della diapositiva di origine. Altrimenti, verrà sollevata l'eccezione [PptxEditException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxeditexception). 

{{% /alert %}}

Se desideri che le diapositive nella presentazione di output abbiano un layout diverso, utilizza il metodo [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/net/aspose.slides.islidecollection/addclone/methods/1) durante l'unione. 

## **Unisci diapositive specifiche da presentazioni**

La fusione di diapositive specifiche da più presentazioni è utile per creare deck personalizzati. Aspose.Slides per .NET consente di selezionare e importare solo le diapositive necessarie. L'API conserva la formattazione, il layout e il design delle diapositive originali.

Il seguente codice C# crea una nuova presentazione, aggiunge diapositive titolo da due altre presentazioni e salva il risultato in un file:

```cs
using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}
```
```cs
static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```

## **Unisci presentazioni con un layout diapositiva**

Questo codice C# mostra come combinare diapositive da presentazioni applicando il layout diapositiva preferito per ottenere una presentazione di output:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Unisci presentazioni con diverse dimensioni di diapositiva**

{{% alert title="Nota" color="warning" %}} 

Non è possibile unire presentazioni con dimensioni di diapositiva diverse. 

{{% /alert %}}

Per unire 2 presentazioni con dimensioni di diapositiva diverse, è necessario ridimensionare una delle presentazioni in modo che la sua dimensione corrisponda a quella dell'altra presentazione. 

Questo esempio di codice dimostra l'operazione descritta:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Unisci diapositive a una sezione della presentazione**

Questo codice C# mostra come unire una diapositiva specifica a una sezione di una presentazione:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

La diapositiva viene aggiunta alla fine della sezione. 

{{% alert title="Suggerimento" color="primary" %}}

Aspose offre una [app web GRATUITA Collage](https://products.aspose.app/slides/it/collage). Con questo servizio online, è possibile unire immagini [JPG in JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG in PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e altro. 

{{% /alert %}}

## **FAQ**

**Le note del relatore sono conservate durante l'unione?**

Sì. Quando si clonano le diapositive, Aspose.Slides trasferisce tutti gli elementi della diapositiva, incluse note, formattazione e animazioni.

**I commenti e i loro autori vengono trasferiti?**

I commenti, come parte del contenuto della diapositiva, vengono copiati con la diapositiva. Le etichette degli autori dei commenti sono conservate come oggetti commento nella presentazione risultante.

**Cosa succede se la presentazione di origine è protetta da password?**

Deve essere [aperta con la password](/slides/it/net/password-protected-presentation/) tramite [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/); dopo il caricamento, quelle diapositive possono essere clonate in modo sicuro in un file di destinazione non protetto (o anche protetto).

**Quanto è sicura l'operazione di unione rispetto ai thread?**

Non utilizzare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) da [più thread](/slides/it/net/multithreading/). La regola consigliata è "un documento — un thread"; file diversi possono essere elaborati in parallelo in thread separati.