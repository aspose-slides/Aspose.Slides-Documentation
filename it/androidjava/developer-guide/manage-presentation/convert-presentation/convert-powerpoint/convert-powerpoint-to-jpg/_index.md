---
title: Converti PPT e PPTX in JPG su Android
linktitle: PowerPoint in JPG
type: docs
weight: 60
url: /it/androidjava/convert-powerpoint-to-jpg/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in JPG
- presentazione in JPG
- diapositiva in JPG
- PPT in JPG
- PPTX in JPG
- salvare PowerPoint come JPG
- salvare presentazione come JPG
- salvare diapositiva come JPG
- salvare PPT come JPG
- salvare PPTX come JPG
- esportare PPT in JPG
- esportare PPTX in JPG
- Android
- Java
- Aspose.Slides
description: "Converti le diapositive PowerPoint (PPT, PPTX) in immagini JPG di alta qualità in Java con Aspose.Slides per Android utilizzando esempi di codice veloci e affidabili."
---
## **Introduzione**

Convertire presentazioni PowerPoint e OpenDocument in immagini JPG aiuta a condividere le diapositive, ottimizzare le prestazioni e incorporare contenuti in siti web o applicazioni. Aspose.Slides for Android via Java consente di trasformare file PPTX, PPT e ODP in immagini JPEG di alta qualità. Questa guida illustra diversi metodi per la conversione.

Con queste funzionalità, è facile implementare il proprio visualizzatore di presentazioni e creare una miniatura per ogni diapositiva. Questo può essere utile se desideri proteggere le diapositive da copie o mostrare la presentazione in modalità sola lettura. Aspose.Slides consente di convertire l'intera presentazione o una diapositiva specifica in formati immagine.

## **Convertire le diapositive della presentazione in immagini JPG**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Ottieni l'oggetto diapositiva di tipo [ISlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/) dalla collezione restituita dal metodo [Presentation.getSlides()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlides--).
3. Crea un'immagine della diapositiva usando il metodo [ISlide.getImage(float, float)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#getImage-float-float-).
4. Chiama il metodo [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) sull'oggetto immagine. Passa il nome del file di output e il formato immagine come argomenti.

{{% alert color="primary" %}} 
**Nota:** La conversione da PPT, PPTX o ODP a JPG differisce dalla conversione verso altri formati nell'API Aspose.Slides Android via Java. Per gli altri formati, solitamente si utilizza il metodo [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). Tuttavia, per la conversione JPG, è necessario usare il metodo [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).
{{% /alert %}} 

```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Crea un'immagine della diapositiva con la scala specificata.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // Salva l'immagine su disco in formato JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Convertire le diapositive in JPG con dimensioni personalizzate**

Per modificare le dimensioni delle immagini JPG risultanti, è possibile impostare la dimensione dell'immagine passando un valore al metodo [ISlide.getImage(Size)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-). Questo consente di generare immagini con larghezza e altezza specifiche, garantendo che l'output soddisfi i requisiti di risoluzione e rapporto d'aspetto. Questa flessibilità è particolarmente utile quando si generano immagini per applicazioni web, report o documentazione, dove sono richieste dimensioni precise dell'immagine.

```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Crea un'immagine della diapositiva con la dimensione specificata.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // Salva l'immagine su disco in formato JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Renderizzare i commenti durante il salvataggio delle diapositive come immagini**

Aspose.Slides for Android via Java offre una funzionalità che consente di renderizzare i commenti sulle diapositive di una presentazione durante la conversione in immagini JPG. Questa funzionalità è particolarmente utile per preservare annotazioni, feedback o discussioni aggiunte dai collaboratori nelle presentazioni PowerPoint. Abilitando questa opzione, i commenti risultano visibili nelle immagini generate, facilitando la revisione e la condivisione del feedback senza dover aprire il file originale della presentazione.

Supponiamo di avere un file di presentazione, "sample.pptx", con una diapositiva che contiene commenti:

![La diapositiva con commenti](slide_with_comments.png)

Il seguente codice Java converte la diapositiva in un'immagine JPG preservando i commenti:

```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // Converti la prima diapositiva in un'immagine.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'immagine JPG con commenti](image_with_comments.png)

## **Vedi anche**

Vedi altre opzioni per convertire PPT, PPTX o ODP in immagini, ad esempio:

- [Converti PowerPoint in GIF](/slides/it/androidjava/convert-powerpoint-to-animated-gif/)
- [Converti PowerPoint in PNG](/slides/it/androidjava/convert-powerpoint-to-png/)
- [Converti PowerPoint in TIFF](/slides/it/androidjava/convert-powerpoint-to-tiff/)
- [Converti PowerPoint in SVG](/slides/it/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Per vedere come Aspose.Slides converte le presentazioni PowerPoint in immagini JPG, prova questi convertitori online gratuiti: PowerPoint [PPTX in JPG](https://products.aspose.app/slides/it/conversion/pptx-to-jpg) e [PPT in JPG](https://products.aspose.app/slides/it/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Convertitore gratuito online da PPTX a JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose fornisce una [app web GRATUITA Collage](https://products.aspose.app/slides/it/collage). Utilizzando questo servizio online, è possibile unire immagini [JPG in JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG in PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e così via.

Usando gli stessi principi descritti in questo articolo, è possibile convertire le immagini da un formato all'altro. Per ulteriori informazioni, vedere queste pagine: converti [immagine in JPG](https://products.aspose.com/slides/it/java/conversion/image-to-jpg/); converti [JPG in immagine](https://products.aspose.com/slides/it/java/conversion/jpg-to-image/); converti [JPG in PNG](https://products.aspose.com/slides/it/java/conversion/jpg-to-png/), converti [PNG in JPG](https://products.aspose.com/slides/it/java/conversion/png-to-jpg/); converti [PNG in SVG](https://products.aspose.com/slides/it/java/conversion/png-to-svg/), converti [SVG in PNG](https://products.aspose.com/slides/it/java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Questo metodo supporta la conversione batch?**

Sì, Aspose.Slides consente la conversione batch di più diapositive in JPG in un'unica operazione.

**La conversione supporta SmartArt, grafici e altri oggetti complessi?**

Sì, Aspose.Slides renderizza tutti i contenuti, inclusi SmartArt, grafici, tabelle, forme e altro. Tuttavia, la precisione del rendering può variare leggermente rispetto a PowerPoint, specialmente quando si utilizzano caratteri personalizzati o mancanti.

**Ci sono limitazioni sul numero di diapositive che è possibile elaborare?**

Aspose.Slides di per sé non impone limiti rigorosi sul numero di diapositive che è possibile elaborare. Tuttavia, potresti incontrare errori di esaurimento memoria quando lavori con presentazioni di grandi dimensioni o immagini ad alta risoluzione.