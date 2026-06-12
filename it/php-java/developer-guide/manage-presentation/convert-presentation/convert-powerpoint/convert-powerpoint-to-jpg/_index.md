---
title: Converti PPT e PPTX in JPG in PHP
linktitle: PowerPoint in JPG
type: docs
weight: 60
url: /it/php-java/convert-powerpoint-to-jpg/
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
- PHP
- Aspose.Slides
description: "Converti diapositive PowerPoint (PPT, PPTX) in immagini JPG di alta qualità in PHP con Aspose.Slides per PHP usando esempi di codice rapidi e affidabili."
---
## **Introduzione**

Convertire presentazioni PowerPoint e OpenDocument in immagini JPG aiuta a condividere diapositive, ottimizzare le prestazioni e incorporare contenuti in siti web o applicazioni. Aspose.Slides consente di trasformare file PPTX, PPT e ODP in immagini JPEG di alta qualità. Questa guida spiega i diversi metodi di conversione.

Con queste funzionalità, è facile implementare il proprio visualizzatore di presentazioni e creare una miniatura per ogni diapositiva. Questo può essere utile se si desidera proteggere le diapositive da copie o mostrare la presentazione in modalità sola lettura. Aspose.Slides consente di convertire l'intera presentazione o una diapositiva specifica in formati immagine.

## **Convertire PowerPoint PPT/PPTX in JPG**

1. Crea un'istanza del tipo [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottieni l'oggetto diapositiva del tipo [Slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/) da collezione [Presentation::getSlides()](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation#getSlides--).
3. Crea la miniatura di ogni diapositiva e poi convertila in JPG. Il metodo [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage) è usato per ottenere una miniatura di una diapositiva. Il metodo [getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage) deve essere chiamato dalla diapositiva necessaria del tipo [Slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/), le scale della miniatura risultante vengono passate al metodo.
4. Dopo aver ottenuto la miniatura della diapositiva, chiama il metodo [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/it/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) dall'oggetto miniatura. Passa il nome del file risultante e il formato immagine.

{{% alert color="primary" %}}
**Nota**: La conversione da PPT/PPTX a JPG differisce dalla conversione ad altri formati nell'API Aspose.Slides. Per altri formati, di solito si usa il metodo [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/save/), ma qui è necessario il metodo [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/it/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Crea un'immagine a scala piena
      $slideImage = $sld->getImage(1.0, 1.0);
      # Salva l'immagine su disco in formato JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertire PowerPoint PPT/PPTX in JPG con dimensioni personalizzate**
Per modificare le dimensioni della miniatura risultante e dell'immagine JPG, è possibile impostare i valori *ScaleX* e *ScaleY* passando questi valori nei metodi [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage):

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Definisce le dimensioni
    $desiredX = 1200;
    $desiredY = 800;
    # Ottiene i valori scalati di X e Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Crea un'immagine a scala piena
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Salva l'immagine su disco in formato JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Renderizzare i commenti durante il salvataggio delle diapositive come immagini**
Aspose.Slides per PHP tramite Java offre una funzionalità che consente di renderizzare i commenti nelle diapositive di una presentazione durante la conversione di queste diapositive in immagini. Questo codice PHP dimostra l'operazione:

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
Aspose offre una [app web GRATUITA Collage](https://products.aspose.app/slides/it/collage). Usando questo servizio online, è possibile unire immagini [JPG a JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG a PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e così via.

Usando gli stessi principi descritti in questo articolo, è possibile convertire le immagini da un formato all'altro. Per ulteriori informazioni, vedere queste pagine: converti [immagine in JPG](https://products.aspose.com/slides/it/php-java/conversion/image-to-jpg/); converti [JPG in immagine](https://products.aspose.com/slides/it/php-java/conversion/jpg-to-image/); converti [JPG in PNG](https://products.aspose.com/slides/it/php-java/conversion/jpg-to-png/), converti [PNG in JPG](https://products.aspose.com/slides/it/php-java/conversion/png-to-jpg/); converti [PNG in SVG](https://products.aspose.com/slides/it/php-java/conversion/png-to-svg/), converti [SVG in PNG](https://products.aspose.com/slides/it/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Questo metodo supporta la conversione batch?**

Sì, Aspose.Slides consente la conversione batch di più diapositive in JPG in un'unica operazione.

**La conversione supporta SmartArt, grafici e altri oggetti complessi?**

Sì, Aspose.Slides renderizza tutto il contenuto, inclusi SmartArt, grafici, tabelle, forme e altro. Tuttavia, la precisione del rendering può variare leggermente rispetto a PowerPoint, soprattutto quando si utilizzano font personalizzati o mancanti.

**Ci sono limitazioni sul numero di diapositive che possono essere elaborate?**

Aspose.Slides di per sé non impone limiti rigidi sul numero di diapositive che è possibile elaborare. Tuttavia, potresti incontrare errori di out-of-memory quando lavori con presentazioni di grandi dimensioni o immagini ad alta risoluzione.

## **Vedi anche**

Vedi altre opzioni per convertire PPT/PPTX in immagini, come:

- [Conversione da PPT/PPTX a SVG](/slides/it/php-java/render-a-slide-as-an-svg-image/).