---
title: Unire presentazioni in modo efficiente con Python
linktitle: Unisci presentazioni
type: docs
weight: 40
url: /it/python-net/merge-presentation/
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
- Python
- Aspose.Slides
description: "Unisci facilmente presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP) con Aspose.Slides per Python via .NET, ottimizzando il tuo flusso di lavoro."
---
## **Panoramica**

Aspose.Slides consente di unire presentazioni clonando diapositive da una presentazione a un'altra. Questo articolo spiega come unire presentazioni intere o diapositive selezionate, utilizzare un master diapositive o un layout specifico durante l'unione, gestire presentazioni con diverse dimensioni della diapositiva e aggiungere diapositive unite a una sezione della presentazione. Copre anche note pratiche relative al contenuto unito, incluse note del relatore, commenti, file di origine protetti da password e utilizzo dei thread.

## **Ottimizza l'unione delle presentazioni**

Con [Aspose.Slides per Python](https://products.aspose.com/slides/it/python-net/), puoi combinare senza problemi le presentazioni PowerPoint preservando stili, layout e tutti gli elementi. Al contrario di altri strumenti, Aspose.Slides unisce le presentazioni senza compromettere la qualità o perdere dati. Unisci interi mazzi, diapositive specifiche o persino formati di file diversi (ad es., PPT in PPTX).

### **Funzionalità di unione**

- **Unione completa della presentazione:** Assembla tutte le diapositive in un unico file.  
- **Unione di diapositive specifiche:** Scegli e combina le diapositive selezionate.  
- **Unione tra formati diversi:** Integra presentazioni di formati vari, mantenendo l'integrità.  

## **Unione delle presentazioni**

Quando unisci una presentazione in un'altra, stai effettivamente combinando le loro diapositive in un'unica presentazione per produrre un solo file. La maggior parte dei programmi di presentazione — come PowerPoint o OpenOffice — non offre funzionalità che consentano di unire presentazioni in questo modo.

Tuttavia, [Aspose.Slides per Python](https://products.aspose.com/slides/it/python-net/) ti consente di unire presentazioni in diversi modi. Puoi unire presentazioni con tutte le loro forme, stili, testo, formattazione, commenti e animazioni, senza alcuna perdita di qualità o dati.

**Vedi anche**

[Clona diapositive PowerPoint in Python](/slides/it/python-net/clone-slides/)

### **Cosa può essere unito**

Con Aspose.Slides, puoi unire:

- Presentazioni intere: tutte le diapositive dei mazzi di origine vengono combinate in un'unica presentazione.  
- Diapositive specifiche: solo le diapositive selezionate vengono combinate in un'unica presentazione.  
- Presentazioni dello stesso formato (ad es., PPT→PPT, PPTX→PPTX) o tra formati diversi (ad es., PPT→PPTX, PPTX→ODP).  

### **Opzioni di unione**

Puoi controllare se:
- Ogni diapositiva nella presentazione di output conserva il proprio stile originale, oppure
- Un unico stile viene applicato a tutte le diapositive nella presentazione di output.

Per unire presentazioni, Aspose.Slides fornisce i metodi [add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) sulla classe [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/). queste sovraccarichi di metodo definiscono come viene eseguita l'unione. Ogni oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) espone una collezione [slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slides/it/), quindi chiami `add_clone` sulla collezione diapositive della presentazione di destinazione.

Il metodo `add_clone` restituisce un `Slide` — un clone della diapositiva di origine. Le diapositive nella presentazione di output sono copie delle originali, quindi puoi modificare le diapositive risultanti (ad esempio, applicare stili, formattazione o layout) senza influire sulle presentazioni di origine.

## **Unisci presentazioni** 

Aspose.Slides fornisce il metodo [add_clone(ISlide)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide), che consente di combinare diapositive preservando i loro layout e stili (usando i parametri predefiniti).

Il seguente esempio Python mostra come unire presentazioni:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Unisci presentazioni con un master diapositive**

Aspose.Slides fornisce il metodo [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool), che consente di unire diapositive applicando un master diapositive da un modello. In questo modo, quando necessario, puoi ri-stilizzare le diapositive nella presentazione di output.

Il seguente esempio Python dimostra questa operazione:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Nota" color="warning" %}}
Il layout appropriato sotto il master diapositive specificato viene determinato automaticamente. Se non è possibile trovare un layout adatto e il parametro booleano `allow_clone_missing_layout` del metodo `add_clone` è impostato su `True`, viene utilizzato il layout della diapositiva di origine. Altrimenti, viene sollevata un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

Per applicare un layout di diapositiva diverso alle diapositive nella presentazione di output, utilizza il metodo [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) durante l'unione.

## **Unisci diapositive specifiche da presentazioni**

Unire diapositive specifiche da più presentazioni è utile per creare mazzi di diapositive personalizzati. Aspose.Slides ti consente di selezionare e importare solo le diapositive necessarie, preservando la formattazione, il layout e il design delle diapositive originali.

Il seguente esempio Python crea una nuova presentazione, aggiunge diapositive titolo da altre due presentazioni e salva il risultato in un file:

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Unisci presentazioni con un layout di diapositiva**

Il seguente esempio Python mostra come unire diapositive da più presentazioni applicando un layout di diapositiva specifico per produrre un'unica presentazione di output:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Unisci presentazioni con dimensioni di diapositiva diverse**

{{% alert title="Nota" color="warning" %}}
Non è possibile unire direttamente presentazioni che hanno dimensioni di diapositiva diverse.
{{% /alert %}}

Per unire due presentazioni con dimensioni di diapositiva diverse, ridimensiona prima una presentazione affinché la sua dimensione della diapositiva corrisponda a quella dell'altra.

Il seguente codice di esempio dimostra questo processo:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Unisci diapositive in una sezione della presentazione**

Il seguente esempio Python mostra come unire una diapositiva specifica in una sezione di una presentazione:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

La diapositiva viene aggiunta alla fine della sezione. 

{{% alert title="Suggerimento" color="primary" %}}
Cerchi uno strumento online veloce e **gratuito** per **unire presentazioni PowerPoint**? Prova il [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/it/merger).

- **Unisci facilmente file PowerPoint**: combina più presentazioni **PPT, PPTX, ODP** in un unico file.  
- **Supporta formati diversi**: unisci **PPT in PPTX**, **PPTX in ODP**, e altro.  
- **Nessuna installazione necessaria**: funziona direttamente nel browser, veloce e sicuro.  

[![Unisci file PowerPoint online](slides-merger.png)](https://products.aspose.app/slides/it/merger)  

Inizia a unire i tuoi file PowerPoint con lo **strumento gratuito online di Aspose** oggi!  
{{% /alert %}}

{{% alert title="Suggerimento" color="primary" %}}
Aspose offre una [app web COLLAZIONE GRATUITA](https://products.aspose.app/slides/it/collage). Usando questo servizio online, puoi unire immagini [JPG in JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG in PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e così via. 
{{% /alert %}}

## **FAQ**

**Le note del relatore vengono conservate durante l'unione?**

Sì. Quando si clona una diapositiva, Aspose.Slides trasferisce tutti gli elementi della diapositiva, incluse le note, la formattazione e le animazioni.

**I commenti e i loro autori vengono trasferiti?**

I commenti, come parte del contenuto della diapositiva, vengono copiati con la diapositiva. Le etichette degli autori dei commenti sono conservate come oggetti commento nella presentazione risultante.

**Cosa succede se la presentazione di origine è protetta da password?**

Deve essere [aperta con la password](/slides/it/python-net/password-protected-presentation/) tramite [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/); dopo il caricamento, quelle diapositive possono essere clonate in modo sicuro in un file di destinazione non protetto (oppure protetto).

**Quanto è thread-safe l'operazione di unione?**

Non utilizzare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) da [più thread](/slides/it/python-net/multithreading/). La regola consigliata è "un documento — un thread"; file diversi possono essere elaborati in parallelo in thread separati.