---
title: Unire Presentazioni in modo Efficiente in .NET
linktitle: Unisci Presentazioni
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

Aspose.Slides consente di unire presentazioni clonando diapositive da una presentazione a un'altra. Questo articolo spiega come unire presentazioni intere o diapositive selezionate, utilizzare un master diapositiva o un layout specifico durante l’unione, gestire presentazioni con dimensioni di diapositiva diverse e aggiungere diapositive unite a una sezione della presentazione. Copre inoltre note pratiche relative al contenuto unito, incluse note del relatore, commenti, file di origine protetti da password e utilizzo dei thread.

## **Ottimizza l’Unione delle Presentazioni**

Con [Aspose.Slides for .NET](https://products.aspose.com/slides/it/net/), combina senza problemi le presentazioni PowerPoint mantenendo stili, layout e tutti gli elementi. A differenza di altri strumenti, Aspose.Slides fonde le presentazioni senza compromettere la qualità o perdere dati. Unisci presentazioni intere, diapositive specifiche e persino formati di file diversi (PPT in PPTX, ecc.).

### **Funzionalità di Unione**

- **Unione di Presentazione Intera:** Assembla tutte le diapositive in un unico file.
- **Unione di Diapositive Specifiche:** Seleziona e combina le diapositive desiderate.
- **Unione Tra Formati Diversi:** Integra presentazioni di formati differenti, mantenendo l’integrità.

{{% alert title="Tip" color="info" %}}  
Cerchi uno **strumento online gratuito** per **unire presentazioni PowerPoint**? Prova l’[**Aspose PowerPoint Merger**](https://products.aspose.app/slides/it/merger).  
- **Unisci file PowerPoint facilmente**: Combina più presentazioni **PPT, PPTX, ODP** in un unico file.  
- **Supporta formati diversi**: Unisci **PPT in PPTX**, **PPTX in ODP** e altro ancora.  
- **Nessuna installazione necessaria**: Funziona direttamente nel browser, veloce e sicuro.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/it/merger)  

Inizia a unire i tuoi file PowerPoint con lo **strumento gratuito online di Aspose** oggi!  
{{% /alert %}}

## **Unione delle Presentazioni**

Quando [unisci una presentazione a un’altra](https://products.aspose.com/slides/it/net/merger/ppt/), combini effettivamente le loro diapositive in una singola presentazione per ottenere un unico file.

{{% alert title="Info" color="info" %}}

La maggior parte dei programmi di presentazione (PowerPoint o OpenOffice) non dispone di funzioni che consentono agli utenti di combinare presentazioni in questo modo.  

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/it/net/) consente invece di unire presentazioni in diversi modi. Puoi unire presentazioni con tutte le loro forme, stili, testi, formattazioni, commenti, animazioni, ecc., senza preoccuparti della perdita di qualità o dati.  

**Vedi anche**

[Clone Slides](https://docs.aspose.com/slides/it/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.*  
{{% /alert %}}

### **Cosa È Possibile Unire**

Con Aspose.Slides, puoi unire  

* presentazioni intere. Tutte le diapositive delle presentazioni finiscono in una singola presentazione  
* diapositive specifiche. Le diapositive selezionate finiscono in una singola presentazione  
* presentazioni in un formato (PPT in PPT, PPTX in PPTX, ecc.) e in formati diversi (PPT in PPTX, PPTX in ODP, ecc.) tra loro.  

{{% alert title="Note" color="warning" %}}  
Oltre alle presentazioni, Aspose.Slides consente di unire altri file:  

* [Immagini](https://products.aspose.com/slides/it/net/merger/image-to-image/), come [JPG in JPG](https://products.aspose.com/slides/it/net/merger/jpg-to-jpg/) o [PNG in PNG](https://products.aspose.com/slides/it/net/merger/png-to-png/)  
* Documenti, come [PDF in PDF](https://products.aspose.com/slides/it/net/merger/pdf-to-pdf/) o [HTML in HTML](https://products.aspose.com/slides/it/net/merger/html-to-html/)  
* E due file diversi come [immagine in PDF](https://products.aspose.com/slides/it/net/merger/image-to-pdf/), [JPG in PDF](https://products.aspose.com/slides/it/net/merger/jpg-to-pdf/) o [TIFF in PDF](https://products.aspose.com/slides/it/net/merger/tiff-to-pdf/).  
{{% /alert %}}

### **Opzioni di Unione**

Puoi applicare opzioni che determinano se  

* ogni diapositiva nella presentazione di output mantiene uno stile unico  
* uno stile specifico è usato per tutte le diapositive nella presentazione di output.  

Per unire presentazioni, Aspose.Slides fornisce i metodi [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone) (dall’interfaccia [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection)). Esistono diverse implementazioni dei metodi `AddClone` che definiscono i parametri del processo di unione. Ogni oggetto Presentation ha una collezione [Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/properties/slides), quindi puoi chiamare un metodo `AddClone` dalla presentazione in cui desideri unire le diapositive.  

Il metodo `AddClone` restituisce un oggetto `ISlide`, che è una clonazione della diapositiva di origine. Le diapositive nella presentazione di output sono semplicemente una copia delle diapositive di origine. Pertanto, puoi modificare le diapositive risultanti (ad esempio, applicare stili, opzioni di formattazione o layout) senza preoccuparti che le presentazioni di origine vengano influenzate.  

## **Unire Presentazioni**  

Aspose.Slides fornisce il metodo [**AddClone (ISlide)**](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/methods/addclone) che consente di combinare diapositive mantenendo i loro layout e stili (parametri predefiniti).  

Questo codice C# mostra come unire presentazioni:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Unire Presentazioni con un Master Diapositiva**

Aspose.Slides fornisce il metodo [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/it/net/aspose.slides.islidecollection/addclone/methods/2) che consente di combinare diapositive applicando un modello di master diapositiva. In questo modo, se necessario, puoi modificare lo stile delle diapositive nella presentazione di output.  

Questo codice C# dimostra l’operazione descritta:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert title="Note" color="warning" %}}  
Il layout della diapositiva per il master viene determinato automaticamente. Quando non è possibile determinare un layout appropriato, se il parametro booleano `allowCloneMissingLayout` del metodo `AddClone` è impostato su true, viene usato il layout della diapositiva di origine. Altrimenti verrà lanciata un’`[PptxEditException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxeditexception)`.  
{{% /alert %}}

Se desideri che le diapositive nella presentazione di output abbiano un layout diverso, utilizza invece il metodo [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/net/aspose.slides.islidecollection/addclone/methods/1) durante l’unione.  

## **Unire Diapositive Specifiche da Presentazioni**

Unire diapositive specifiche da più presentazioni è utile per creare deck personalizzati. Aspose.Slides for .NET consente di selezionare e importare solo le diapositive necessarie. L’API preserva formattazione, layout e design delle diapositive originali.  

Il codice C# seguente crea una nuova presentazione, aggiunge diapositive titolo da due altre presentazioni e salva il risultato in un file:  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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
```cs
using Aspose.Slides;

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

## **Unire Presentazioni con un Layout Diapositiva**

Questo codice C# mostra come combinare diapositive da presentazioni applicando il layout diapositiva preferito per ottenere una presentazione di output unica:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Unire Presentazioni con Dimensioni di Diapositiva Diverse**

{{% alert title="Note" color="warning" %}}  
Unire presentazioni con dimensioni di diapositiva diverse non genera un errore, ma le diapositive unite assumono la dimensione della diapositiva della presentazione di destinazione, mentre le loro forme mantengono posizioni e dimensioni originali; il contenuto potrebbe quindi risultare spostato o fuori dai bordi della diapositiva.  
{{% /alert %}}

Per unire 2 presentazioni con dimensioni diverse mantenendo correttamente il contenuto, ridimensiona una delle presentazioni in modo che la sua dimensione corrisponda a quella dell’altra.  

Questo esempio di codice dimostra l’operazione descritta:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Unire Diapositive in una Sezione della Presentazione**

Questo codice C# mostra come unire una diapositiva specifica in una sezione della presentazione:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert title="Tip" color="info" %}}  
Aspose offre un’app web **GRATUITA** per collage ([FREE Collage web app](https://products.aspose.app/slides/it/collage)). Utilizzando questo servizio online, puoi unire [JPG in JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG in PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e altro ancora.  
{{% /alert %}}

## **FAQ**

### Le note del relatore vengono preserve durante l’unione?

Sì. Quando si clonano diapositive, Aspose.Slides trasferisce tutti gli elementi della diapositiva, incluse le note, la formattazione e le animazioni.

### I commenti e i loro autori vengono trasferiti?

I commenti, come parte del contenuto della diapositiva, vengono copiati con la diapositiva. Le etichette degli autori dei commenti sono preservate come oggetti commento nella presentazione risultante.

### Cosa succede se la presentazione di origine è protetta da password?

Deve essere [aperta con la password](/slides/it/net/password-protected-presentation/) tramite [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/); dopo il caricamento, quelle diapositive possono essere clonate in modo sicuro in un file di destinazione non protetto (oppure protetto).

### Quanto è thread‑safe l’operazione di unione?

Non utilizzare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) da [thread multipli](/slides/it/net/multithreading/). La regola consigliata è “un documento — un thread”; file diversi possono essere elaborati in parallelo su thread separati.