---
title: Unire presentazioni in modo efficiente su Android
linktitle: Unisci presentazioni
type: docs
weight: 40
url: /it/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Unisci facilmente presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP) con Aspose.Slides per Android tramite Java, semplificando il tuo flusso di lavoro."
---
## **Panoramica**

Unire presentazioni PowerPoint e OpenDocument è un compito comune in molte applicazioni Android, specialmente quando si generano report, si compilano diapositive da fonti diverse o si automatizzano flussi di lavoro di presentazione. Aspose.Slides fornisce un'API potente e facile da usare per combinare più file PPT, PPTX o ODP in un'unica presentazione senza installare Microsoft PowerPoint, LibreOffice o OpenOffice.

In questa guida imparerai a unire presentazioni PowerPoint e OpenDocument usando solo poche righe di codice. Forniremo esempi pronti all'uso e mostreremo come preservare la formattazione delle diapositive, i layout e gli altri elementi della presentazione durante il processo di unione.

Che tu stia costruendo un'applicazione a livello enterprise o uno strumento di automazione semplice, Aspose.Slides rende l'unione delle presentazioni rapida, affidabile e scalabile. Aspose.Slides ti permette di unire presentazioni in diversi modi. Puoi combinare presentazioni con tutte le loro forme, stili, testo, formattazione, commenti, animazioni e altro—senza preoccuparti della perdita di qualità o dati.

{{% alert color="info" %}}
Vedi anche: [Clona diapositive](https://docs.aspose.com/slides/it/androidjava/clone-slides/)
{{% /alert %}}

### **Cosa può essere unito**

Con Aspose.Slides, è possibile unire  

* presentazioni intere. Tutte le diapositive delle presentazioni finiscono in un'unica presentazione  
* diapositive specifiche. Le diapositive selezionate finiscono in un'unica presentazione  
* presentazioni in un unico formato (PPT a PPT, PPTX a PPTX, ecc.) e in formati diversi (PPT a PPTX, PPTX a ODP, ecc.) tra loro.  

### **Opzioni di unione**

Puoi applicare opzioni che determinano se  

* ogni diapositiva nella presentazione di output mantiene uno stile unico  
* uno stile specifico è utilizzato per tutte le diapositive nella presentazione di output.  

Per unire presentazioni, Aspose.Slides fornisce metodi [AddClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (dall'interfaccia [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection)). Esistono diverse implementazioni dei metodi `AddClone` che definiscono i parametri del processo di unione della presentazione. Ogni oggetto Presentation ha una collezione [Slides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) , quindi puoi chiamare un metodo `AddClone` dalla presentazione nella quale desideri unire le diapositive.

Il metodo `AddClone` restituisce un oggetto `ISlide`, che è un clone della diapositiva sorgente. Le diapositive in una presentazione di output sono semplicemente una copia delle diapositive della sorgente. Pertanto, puoi modificare le diapositive risultanti (ad esempio, applicare stili, opzioni di formattazione o layout) senza preoccuparti che le presentazioni sorgente vengano influenzate.  

## **Unire presentazioni** 

Aspose.Slides fornisce il metodo [**AddClone(ISlide)**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) che consente di combinare diapositive mantenendo i loro layout e stili (parametri predefiniti).

Questo codice Java ti mostra come unire presentazioni:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Unire presentazioni con un master delle diapositive** 

Aspose.Slides fornisce il metodo [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) che consente di combinare diapositive applicando un modello di master delle diapositive. In questo modo, se necessario, puoi modificare lo stile delle diapositive nella presentazione di output.

Questo codice Java dimostra l'operazione descritta:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Nota" color="warning" %}} 
Il layout della diapositiva per il master è determinato automaticamente. Quando non è possibile determinare un layout appropriato, se il parametro booleano `allowCloneMissingLayout` del metodo `AddClone` è impostato su true, viene utilizzato il layout della diapositiva sorgente. Altrimenti verrà sollevata una [PptxEditException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/PptxEditException). 
{{% /alert %}}

Se desideri che le diapositive nella presentazione di output abbiano un layout diverso, utilizza invece il metodo [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) durante l'unione.  

## **Unire diapositive specifiche da presentazioni** 

Unire diapositive specifiche da più presentazioni è utile per creare deck personalizzati. Aspose.Slides per Android via Java ti permette di selezionare e importare solo le diapositive di cui hai bisogno. L'API preserva la formattazione, il layout e il design delle diapositive originali.

Il seguente codice Java crea una nuova presentazione, aggiunge diapositive titolo da due altre presentazioni e salva il risultato in un file:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);

    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Unire presentazioni con un layout di diapositiva** 

Questo codice Java ti mostra come combinare diapositive da presentazioni applicando il layout di diapositiva preferito per ottenere un'unica presentazione di output:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Unire presentazioni con dimensioni di diapositiva diverse** 

{{% alert title="Nota" color="warning" %}} 
Non è possibile unire presentazioni con dimensioni di diapositiva diverse. 
{{% /alert %}}

Per unire 2 presentazioni con dimensioni di diapositiva diverse, è necessario ridimensionare una delle presentazioni in modo che le sue dimensioni corrispondano a quelle dell'altra presentazione. 

Questo esempio di codice dimostra l'operazione descritta:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Unire diapositive in una sezione della presentazione** 

Questo codice Java ti mostra come unire una diapositiva specifica in una sezione di una presentazione:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

La diapositiva viene aggiunta alla fine della sezione. 

{{% alert title="Suggerimento" color="info" %}}
Aspose offre una [app web Collage GRATUITA](https://products.aspose.app/slides/it/collage). Utilizzando questo servizio online, puoi unire [JPG a JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG a PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e così via. 
{{% /alert %}}

## **FAQ**

### Ci sono limitazioni sul numero di diapositive quando si uniscono presentazioni?

Nessuna limitazione rigorosa. Aspose.Slides può gestire file di grandi dimensioni, ma le prestazioni dipendono dalla dimensione e dalle risorse di sistema. Per presentazioni molto grandi, si consiglia di utilizzare una JVM a 64 bit e di allocare sufficiente memoria heap.

### Posso unire presentazioni con video o audio incorporati?

Sì, Aspose.Slides preserva i contenuti multimediali incorporati nelle diapositive, ma la presentazione finale potrebbe diventare notevolmente più grande.

### I caratteri saranno preservati durante l'unione delle presentazioni?

Sì. I caratteri utilizzati nelle presentazioni sorgente sono preservati nel file di output, a condizione che siano installati sul sistema o [incorporati](/slides/it/androidjava/embedded-font/).