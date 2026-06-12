---
title: Unire presentazioni in modo efficiente su Android
linktitle: Unire presentazioni
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
description: "Unisci senza sforzo presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP) con Aspose.Slides per Android via Java, semplificando il tuo flusso di lavoro."
---
## **Panoramica**

Unire presentazioni PowerPoint e OpenDocument è un'operazione comune in molte applicazioni Android, soprattutto quando si generano report, si compilano diapositive da fonti diverse o si automatizzano i flussi di lavoro delle presentazioni. Aspose.Slides offre un'API potente e facile da usare per combinare più file PPT, PPTX o ODP in un'unica presentazione senza installare Microsoft PowerPoint, LibreOffice o OpenOffice.

In questa guida imparerai a unire presentazioni PowerPoint e OpenDocument usando solo poche righe di codice. Forniremo esempi pronti all'uso e mostreremo come conservare la formattazione delle diapositive, i layout e gli altri elementi della presentazione durante il processo di fusione.

Che tu stia sviluppando un'applicazione di livello enterprise o un semplice strumento di automazione, Aspose.Slides rende l'unione delle presentazioni rapida, affidabile e scalabile. Aspose.Slides consente di unire le presentazioni in diversi modi. Puoi combinare presentazioni con tutte le loro forme, stili, testo, formattazione, commenti, animazioni e altro ancora—senza preoccuparti della perdita di qualità o dati.

{{% alert color="primary" %}}
Vedi anche: [Clone Slides](https://docs.aspose.com/slides/it/androidjava/clone-slides/)
{{% /alert %}}

### **Cosa può essere unito**

Con Aspose.Slides, è possibile unire 

* presentazioni intere. Tutte le diapositive delle presentazioni finiscono in un'unica presentazione
* diapositive specifiche. Le diapositive selezionate finiscono in un'unica presentazione
* presentazioni in un unico formato (PPT a PPT, PPTX a PPTX, ecc.) e in formati diversi (PPT a PPTX, PPTX a ODP, ecc.) tra loro. 

### **Opzioni di unione**

È possibile applicare opzioni che determinano se

* ogni diapositiva nella presentazione di destinazione conserva uno stile unico
* viene utilizzato uno stile specifico per tutte le diapositive nella presentazione di destinazione. 

Per unire le presentazioni, Aspose.Slides fornisce i metodi [AddClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (dell'interfaccia [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection)). Esistono diverse implementazioni dei metodi `AddClone` che definiscono i parametri del processo di fusione delle presentazioni. Ogni oggetto Presentation possiede una collezione [Slides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--), quindi è possibile chiamare un metodo `AddClone` dalla presentazione in cui si desidera unire le diapositive.

Il metodo `AddClone` restituisce un oggetto `ISlide`, che è un clone della diapositiva di origine. Le diapositive in una presentazione di destinazione sono semplicemente una copia delle diapositive di origine. Pertanto, puoi modificare le diapositive risultanti (ad esempio, applicare stili, opzioni di formattazione o layout) senza preoccuparti che le presentazioni sorgenti vengano alterate.

## **Unire presentazioni** 

Aspose.Slides fornisce il metodo [**AddClone(ISlide)**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) che consente di combinare le diapositive mantenendo i loro layout e stili (parametri predefiniti).

Questo codice Java mostra come unire le presentazioni:

```java
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

## **Unire presentazioni con uno Slide Master** 

Aspose.Slides fornisce il metodo [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) che consente di combinare le diapositive applicando un modello di presentazione slide master. In questo modo, se necessario, è possibile modificare lo stile delle diapositive nella presentazione di destinazione.

Questo codice Java dimostra l'operazione descritta:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Il layout della diapositiva per lo slide master è determinato automaticamente. Quando non è possibile determinare un layout appropriato, se il parametro booleano `allowCloneMissingLayout` del metodo `AddClone` è impostato su true, viene utilizzato il layout della diapositiva di origine. Altrimenti, verrà sollevata un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

Se desideri che le diapositive nella presentazione di destinazione abbiano un layout diverso, utilizza il metodo [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) durante la fusione.

## **Unire diapositive specifiche da presentazioni** 

Unire diapositive specifiche da più presentazioni è utile per creare decks diapositive personalizzati. Aspose.Slides per Android tramite Java consente di selezionare e importare solo le diapositive necessarie. L'API preserva formattazione, layout e design delle diapositive originali.

Il seguente codice Java crea una nuova presentazione, aggiunge diapositive titolo da due altre presentazioni e salva il risultato in un file:

```java
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

Questo codice Java mostra come combinare le diapositive da presentazioni applicando il layout di diapositiva preferito per ottenere un'unica presentazione di destinazione:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
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

{{% alert title="Note" color="warning" %}} 
Non è possibile unire presentazioni con dimensioni di diapositiva diverse. 
{{% /alert %}}

Per unire 2 presentazioni con dimensioni di diapositiva diverse, è necessario ridimensionare una delle presentazioni affinché la sua dimensione corrisponda a quella dell'altra.

Questo codice di esempio dimostra l'operazione descritta:

```java
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

Questo codice Java mostra come unire una diapositiva specifica in una sezione di una presentazione:

```java
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

{{% alert title="Tip" color="primary" %}} 
Aspose offre una [app web GRATUITA Collage](https://products.aspose.app/slides/it/collage). Utilizzando questo servizio online, è possibile unire immagini [JPG a JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG a PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e così via. 
{{% /alert %}}

## **FAQ**

**Ci sono limiti al numero di diapositive durante l'unione di presentazioni?**

Nessuna limitazione rigida. Aspose.Slides può gestire file di grandi dimensioni, ma le prestazioni dipendono dalla dimensione e dalle risorse di sistema. Per presentazioni molto grandi, è consigliato usare una JVM a 64 bit e allocare sufficiente memoria heap.

**Posso unire presentazioni con video o audio incorporati?**

Sì, Aspose.Slides conserva i contenuti multimediali incorporati nelle diapositive, ma la presentazione finale potrebbe diventare significativamente più grande.

**I font saranno conservati durante l'unione delle presentazioni?**

Sì. I font utilizzati nelle presentazioni di origine sono preservati nel file di destinazione, a condizione che siano installati sul sistema o [incorporati](/slides/it/androidjava/embedded-font/).