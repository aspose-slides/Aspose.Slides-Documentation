---
title: Converti PPT e PPTX in JPG su Android
linktitle: PowerPoint in JPG
type: docs
weight: 60
url: /it/androidjava/convert-powerpoint-to-jpg/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in JPG
- presentazione in JPG
- diapositiva in JPG
- PPT in JPG
- PPTX in JPG
- salva PowerPoint come JPG
- salva presentazione come JPG
- salva diapositiva come JPG
- salva PPT come JPG
- salva PPTX come JPG
- esporta PPT in JPG
- esporta PPTX in JPG
- Android
- Java
- Aspose.Slides
description: "Converti le diapositive PowerPoint (PPT, PPTX) in immagini JPG di alta qualità in Java con Aspose.Slides per Android utilizzando esempi di codice rapidi e affidabili."
---
## **Introduzione**

Convertire presentazioni PowerPoint e OpenDocument in immagini JPG aiuta a condividere le diapositive, ottimizzare le prestazioni e incorporare contenuti in siti web o applicazioni. Aspose.Slides per Android via Java consente di trasformare file PPTX, PPT e ODP in immagini JPEG di alta qualità. Questa guida spiega i diversi metodi di conversione.

Con queste funzionalità, è facile implementare il proprio visualizzatore di presentazioni e creare una miniatura per ogni diapositiva. Questo può essere utile se si desidera proteggere le diapositive da copie o mostrare la presentazione in modalità sola lettura. Aspose.Slides consente di convertire l'intera presentazione o una diapositiva specifica in formati immagine.

## **Convertire le diapositive della presentazione in immagini JPG**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottieni l'oggetto diapositiva di tipo [ISlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/) dalla collezione restituita dal metodo [Presentation.getSlides()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlides--) .
1. Crea un'immagine della diapositiva usando il metodo [ISlide.getImage(float, float)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#getImage-float-float-) .
1. Chiama il metodo [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) sull'oggetto immagine. Passa come argomenti il nome del file di output e il formato immagine.

{{% alert color="info" %}} 
**Nota:** la conversione da PPT, PPTX o ODP a JPG differisce dalla conversione in altri formati nell'API Aspose.Slides per Android via Java. Per altri formati, solitamente si utilizza il metodo [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). Tuttavia, per la conversione in JPG, è necessario utilizzare il metodo [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) .
{{% /alert %}} 

```java
import com.aspose.slides.*;

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

Per modificare le dimensioni delle immagini JPG risultanti, è possibile impostare la dimensione dell'immagine passando un valore al metodo [ISlide.getImage(Size)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) . Questo consente di generare immagini con larghezza e altezza specifiche, garantendo che l'output soddisfi i requisiti di risoluzione e rapporto d'aspetto. Tale flessibilità è particolarmente utile quando si generano immagini per applicazioni web, report o documentazione, dove sono richieste dimensioni precise dell'immagine.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Crea un'immagine della diapositiva con le dimensioni specificate.
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

Aspose.Slides per Android via Java offre una funzionalità che consente di renderizzare i commenti sulle diapositive di una presentazione durante la conversione in immagini JPG. Questa funzionalità è particolarmente utile per preservare annotazioni, feedback o discussioni aggiunte dai collaboratori nelle presentazioni PowerPoint. Abilitando questa opzione, i commenti saranno visibili nelle immagini generate, facilitando la revisione e la condivisione del feedback senza dover aprire il file di presentazione originale.

Supponiamo di avere un file di presentazione, "sample.pptx," con una diapositiva che contiene commenti:

![La diapositiva con i commenti](slide_with_comments.png)

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // Converte la prima diapositiva in un'immagine.
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

![L'immagine JPG con i commenti](image_with_comments.png)

## **Vedi anche**

Vedi altre opzioni per convertire PPT, PPTX o ODP in immagini, ad esempio:

- [Convertire PowerPoint in GIF](/slides/it/androidjava/convert-powerpoint-to-animated-gif/)
- [Convertire PowerPoint in PNG](/slides/it/androidjava/convert-powerpoint-to-png/)
- [Convertire PowerPoint in TIFF](/slides/it/androidjava/convert-powerpoint-to-tiff/)
- [Convertire PowerPoint in SVG](/slides/it/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
Per vedere come Aspose.Slides converte le presentazioni PowerPoint in immagini JPG, prova questi convertitori online gratuiti: PowerPoint [da PPTX a JPG](https://products.aspose.app/slides/it/conversion/pptx-to-jpg) e [da PPT a JPG](https://products.aspose.app/slides/it/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Convertitore online gratuito da PPTX a JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose fornisce un'app web [GRATUITA Collage](https://products.aspose.app/slides/it/collage). Utilizzando questo servizio online, è possibile unire immagini [JPG in JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG in PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e così via. 

Utilizzando gli stessi principi descritti in questo articolo, è possibile convertire le immagini da un formato all'altro. Per ulteriori informazioni, consulta queste pagine: converti [immagine in JPG](https://products.aspose.com/slides/it/java/conversion/image-to-jpg/); converti [JPG in immagine](https://products.aspose.com/slides/it/java/conversion/jpg-to-image/); converti [JPG in PNG](https://products.aspose.com/slides/it/java/conversion/jpg-to-png/); converti [PNG in JPG](https://products.aspose.com/slides/it/java/conversion/png-to-jpg/); converti [PNG in SVG](https://products.aspose.com/slides/it/java/conversion/png-to-svg/); converti [SVG in PNG](https://products.aspose.com/slides/it/java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

### Questo metodo supporta la conversione batch?

Sì, Aspose.Slides consente la conversione batch di più diapositive in JPG in un'unica operazione.

### La conversione supporta SmartArt, grafici e altri oggetti complessi?

Sì, Aspose.Slides renderizza tutti i contenuti, inclusi SmartArt, grafici, tabelle, forme e altro. Tuttavia, la precisione del rendering potrebbe variare leggermente rispetto a PowerPoint, soprattutto quando si utilizzano caratteri personalizzati o mancanti.

### Ci sono limitazioni sul numero di diapositive che possono essere elaborate?

Aspose.Slides non impone limiti rigidi sul numero di diapositive che è possibile elaborare. Tuttavia, è possibile incontrare errori di memoria insufficiente quando si lavora con presentazioni molto grandi o immagini ad alta risoluzione.