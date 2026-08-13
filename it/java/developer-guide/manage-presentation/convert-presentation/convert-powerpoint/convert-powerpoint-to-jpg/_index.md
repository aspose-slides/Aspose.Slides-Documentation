---
title: Converti PPT e PPTX in JPG in Java
linktitle: PowerPoint in JPG
type: docs
weight: 60
url: /it/java/convert-powerpoint-to-jpg/
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
- salva PowerPoint come JPG
- salva presentazione come JPG
- salva diapositiva come JPG
- salva PPT come JPG
- salva PPTX come JPG
- esporta PPT in JPG
- esporta PPTX in JPG
- Java
- Aspose.Slides
description: "Converti le diapositive PowerPoint (PPT, PPTX) in immagini JPG di alta qualità in Java con Aspose.Slides for Java usando esempi di codice rapidi e affidabili."
---
## **Introduzione**

Convertire presentazioni PowerPoint e OpenDocument in immagini JPG aiuta a condividere le diapositive, ottimizzare le prestazioni e incorporare contenuti in siti web o applicazioni. Aspose.Slides consente di trasformare i file PPTX, PPT e ODP in immagini JPEG di alta qualità. Questa guida spiega i diversi metodi per la conversione.

Con queste funzionalità, è facile implementare il proprio visualizzatore di presentazioni e creare una miniatura per ogni diapositiva. Questo può essere utile se si desidera proteggere le diapositive da copie o mostrare la presentazione in modalità sola lettura. Aspose.Slides consente di convertire l'intera presentazione o una diapositiva specifica in formati immagine.

## **Convertire PowerPoint PPT/PPTX in JPG**

Ecco i passaggi per convertire PPT/PPTX in JPG:

1. Crea un'istanza del tipo [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottieni l'oggetto diapositiva del tipo [ISlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlide) dalla collezione [Presentation.getSlides()](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getSlides--).
3. Crea la miniatura di ogni diapositiva e poi convertila in JPG. Il metodo [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlide#getImage-float-float-) viene utilizzato per ottenere una miniatura di una diapositiva, restituisce un oggetto [Images](https://reference.aspose.com/slides/it/java/com.aspose.slides/Images) come risultato. Il metodo [getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) deve essere chiamato dalla diapositiva desiderata del tipo [ISlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlide), le scale della miniatura risultante vengono passate al metodo.
4. Dopo aver ottenuto la miniatura della diapositiva, chiama il metodo [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) dall'oggetto miniatura. Passa il nome file risultante e il formato immagine al metodo.

{{% alert color="info" %}}
**Nota**: la conversione da PPT/PPTX a JPG differisce dalla conversione verso altri tipi nell'API Aspose.Slides. Per altri tipi, solitamente si utilizza il metodo [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), ma qui è necessario il metodo [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Crea un'immagine a scala piena
        IImage slideImage = sld.getImage(1f, 1f);

        // Salva l'immagine su disco in formato JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertire PowerPoint PPT/PPTX in JPG con Dimensioni Personalizzate**

Per modificare le dimensioni della miniatura e dell'immagine JPG risultanti, è possibile impostare i valori *ScaleX* e *ScaleY* passandoli ai metodi [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlide#getImage-float-float-):

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Definisce le dimensioni
    int desiredX = 1200;
    int desiredY = 800;
    // Ottiene i valori scalati di X e Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Crea un'immagine a scala piena
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Salva l'immagine su disco in formato JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Renderizzare i Commenti Quando Si Salvano le Diapositive come Immagini**

Aspose.Slides per Java fornisce una funzionalità che consente di renderizzare i commenti nelle diapositive di una presentazione quando si convertono quelle diapositive in immagini. Questo codice Java dimostra l'operazione:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose offre una [app web GRATUITA Collage](https://products.aspose.app/slides/it/collage). Utilizzando questo servizio online, è possibile unire immagini [JPG a JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG a PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid), e così via. 

Usando gli stessi principi descritti in questo articolo, è possibile convertire le immagini da un formato all'altro. Per ulteriori informazioni, vedere queste pagine: convertire [image to JPG](https://products.aspose.com/slides/it/java/conversion/image-to-jpg/); convertire [JPG to image](https://products.aspose.com/slides/it/java/conversion/jpg-to-image/); convertire [JPG to PNG](https://products.aspose.com/slides/it/java/conversion/jpg-to-png/), convertire [PNG to JPG](https://products.aspose.com/slides/it/java/conversion/png-to-jpg/); convertire [PNG to SVG](https://products.aspose.com/slides/it/java/conversion/png-to-svg/), convertire [SVG to PNG](https://products.aspose.com/slides/it/java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

### Questo metodo supporta la conversione batch?

Sì, Aspose.Slides consente la conversione batch di più diapositive in JPG in un'unica operazione.

### La conversione supporta SmartArt, grafici e altri oggetti complessi?

Sì, Aspose.Slides renderizza tutti i contenuti, inclusi SmartArt, grafici, tabelle, forme e altro. Tuttavia, la precisione del rendering può variare leggermente rispetto a PowerPoint, soprattutto quando si utilizzano font personalizzati o mancanti.

### Ci sono limiti al numero di diapositive che possono essere elaborate?

Aspose.Slides di per sé non impone limiti rigidi al numero di diapositive che è possibile elaborare. Tuttavia, potresti incorrere in errori di memoria insufficiente quando lavori con presentazioni di grandi dimensioni o immagini ad alta risoluzione.

## **Vedi anche**

Vedi altre opzioni per convertire PPT/PPTX in immagine, come:

- [Conversione PPT/PPTX in SVG](/slides/it/java/render-a-slide-as-an-svg-image/).