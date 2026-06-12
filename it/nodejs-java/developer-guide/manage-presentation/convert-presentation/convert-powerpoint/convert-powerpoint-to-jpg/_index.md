---
title: Converti PPT e PPTX in JPG in JavaScript
linktitle: PowerPoint in JPG
type: docs
weight: 60
url: /it/nodejs-java/convert-powerpoint-to-jpg/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le diapositive PowerPoint (PPT, PPTX) in immagini JPG di alta qualità in JavaScript con Aspose.Slides per Node.js tramite Java, utilizzando esempi di codice veloci e affidabili."
---
## **Introduzione**

Convertire presentazioni PowerPoint e OpenDocument in immagini JPG aiuta a condividere le diapositive, ottimizzare le prestazioni e incorporare i contenuti in siti web o applicazioni. Aspose.Slides consente di trasformare file PPTX, PPT e ODP in immagini JPEG di alta qualità. Questa guida spiega i diversi metodi per la conversione.

Con queste funzionalità, è facile implementare il proprio visualizzatore di presentazioni e creare una miniatura per ogni diapositiva. Questo può essere utile se si desidera proteggere le diapositive da copie o dimostrare la presentazione in modalità sola lettura. Aspose.Slides permette di convertire l'intera presentazione o una diapositiva specifica in formati immagine.

## **Converti PowerPoint PPT/PPTX in JPG**
Ecco i passaggi per convertire PPT/PPTX in JPG:

1. Crea un'istanza del tipo [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni l'oggetto diapositiva del tipo [Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Slide) dalla collezione [Presentation.getSlides()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getSlides--).
3. Crea la miniatura di ogni diapositiva e poi converti in JPG. Il metodo [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Slide#getImage-float-float-) è usato per ottenere una miniatura di una diapositiva, restituisce un oggetto [Imagess](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Images). Il metodo [getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) deve essere chiamato dalla diapositiva necessaria del tipo [Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Slide), le scale della miniatura risultante vengono passate al metodo.
4. Dopo aver ottenuto la miniatura della diapositiva, chiama il metodo [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/#save) dall'oggetto miniatura. Passa il nome del file risultante e il formato immagine.

{{% alert color="primary" %}}
**Nota**: la conversione PPT/PPTX in JPG differisce dalla conversione in altri formati nell'API Aspose.Slides. Per gli altri formati, di solito si usa il metodo [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), ma qui è necessario il metodo [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/#save).
{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Crea un'immagine a scala piena
        var slideImage = sld.getImage(1.0, 1.0);
        // Salva l'immagine su disco in formato JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Converti PowerPoint PPT/PPTX in JPG con Dimensioni Personalizzate**
Per modificare le dimensioni della miniatura e dell'immagine JPG risultante, è possibile impostare i valori *ScaleX* e *ScaleY* passando questi parametri al metodo [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Slide#getImage-float-float-):

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Definisce le dimensioni
    var desiredX = 1200;
    var desiredY = 800;
    // Ottiene i valori scalati di X e Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Crea un'immagine a scala piena
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Salva l'immagine su disco in formato JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Render dei commenti durante il salvataggio della Presentazione in immagine**
Aspose.Slides per Node.js tramite Java offre una funzionalità che consente di renderizzare i commenti nelle diapositive di una presentazione durante la conversione di tali diapositive in immagini. Questo codice JavaScript dimostra l'operazione:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}
Aspose fornisce una [app web GRATUITA Collage](https://products.aspose.app/slides/it/collage). Utilizzando questo servizio online, è possibile unire immagini [JPG to JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG to PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e così via. 
{{% /alert %}}

## **Vedi anche**

Vedi altre opzioni per convertire PPT/PPTX in immagine, come:

- [conversione PPT/PPTX in SVG](/slides/it/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**Questo metodo supporta la conversione batch?**

Sì, Aspose.Slides consente la conversione batch di più diapositive in JPG in un'unica operazione.

**La conversione supporta SmartArt, grafici e altri oggetti complessi?**

Sì, Aspose.Slides renderizza tutti i contenuti, inclusi SmartArt, grafici, tabelle, forme e altro. Tuttavia, la precisione del rendering può variare leggermente rispetto a PowerPoint, soprattutto quando si utilizzano caratteri personalizzati o mancanti.

**Ci sono limitazioni sul numero di diapositive che possono essere elaborate?**

Aspose.Slides di per sé non impone limiti rigidi al numero di diapositive che è possibile elaborare. Tuttavia, potresti riscontrare errori di out-of-memory lavorando con presentazioni di grandi dimensioni o immagini ad alta risoluzione.