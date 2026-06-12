---
title: Gestire i fotogrammi video nelle presentazioni usando PHP
linktitle: Fotogramma video
type: docs
weight: 10
url: /it/php-java/video-frame/
keywords:
- aggiungere video
- creare video
- incorporare video
- estrarre video
- recuperare video
- fotogramma video
- sorgente web
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Impara ad aggiungere ed estrarre programmaticamente i fotogrammi video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per PHP tramite Java. Guida rapida passo-passo."
---
## **Introduzione**

Un video ben inserito in una presentazione può rendere il tuo messaggio più persuasivo e aumentare i livelli di coinvolgimento del pubblico. 

PowerPoint consente di aggiungere video a una diapositiva in una presentazione in due modi:

* Aggiungere o incorporare un video locale (memorizzato sul tuo computer)
* Aggiungere un video online (da una sorgente web come YouTube).

Per consentirti di aggiungere video (oggetti video) a una presentazione, Aspose.Slides fornisce la classe [Video](https://reference.aspose.com/slides/it/php-java/aspose.slides/video/) , la classe [VideoFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/) e altri tipi pertinenti.

## **Creare fotogrammi video incorporati**

Se il file video che desideri aggiungere alla tua diapositiva è memorizzato localmente, puoi creare un fotogramma video per incorporare il video nella tua presentazione. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) .
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Aggiungi un oggetto [Video](https://reference.aspose.com/slides/it/php-java/aspose.slides/video/) e passa il percorso del file video per incorporare il video nella presentazione.
4. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/) per creare un fotogramma per il video.
5. Salva la presentazione modificata. 

Questo codice PHP mostra come aggiungere un video memorizzato localmente a una presentazione:

```php
  # Istanzia la classe Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Carica il video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Ottiene la prima diapositiva e aggiunge un fotogramma video
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Salva la presentazione su disco
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

In alternativa, puoi aggiungere un video passando direttamente il suo percorso file al metodo [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addvideoframe/) :

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Creare fotogrammi video con video da sorgenti web**

Microsoft [PowerPoint 2013 e versioni successive](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) supporta i video di YouTube nelle presentazioni. Se il video che desideri utilizzare è disponibile online (ad esempio su YouTube), puoi aggiungerlo alla tua presentazione tramite il suo link web. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) 
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Aggiungi un oggetto [Video](https://reference.aspose.com/slides/it/php-java/aspose.slides/video/) e passa il link al video.
4. Imposta una miniatura per il fotogramma video. 
5. Salva la presentazione. 

Questo codice PHP mostra come aggiungere un video dal web a una diapositiva in una presentazione PowerPoint:

```php
  # Istanzia un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Gestire i sottotitoli video**

Aspose.Slides ti consente di gestire i sottotitoli chiusi per i fotogrammi video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati nel formato WebVTT e sono accessibili tramite il metodo [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/#getCaptionTracks) .

**Aggiungere sottotitoli a un fotogramma video**

Per aggiungere sottotitoli a un fotogramma video:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) .
2. Aggiungi un video alla presentazione.
3. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/) a una diapositiva.
4. Utilizza la raccolta [CaptionsCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/captionscollection/) restituita da [getCaptionTracks](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/#getCaptionTracks) per aggiungere una traccia di sottotitoli WebVTT.
5. Salva la presentazione modificata.

Il codice seguente mostra come aggiungere sottotitoli a un fotogramma video:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Aggiunge una nuova traccia di sottotitoli da un file WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/captionscollection/) fornisce anche un overload che consente di aggiungere sottotitoli da uno stream.

**Estrarre i sottotitoli da un fotogramma video**

Per estrarre i sottotitoli da un fotogramma video:

1. Carica la presentazione che contiene il video.
2. Trova l'oggetto [VideoFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/) target.
3. Itera attraverso la raccolta [getCaptionTracks](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/#getCaptionTracks) .
4. Salva ogni traccia di sottotitoli in un file `.vtt` .

Il codice seguente mostra come estrarre i sottotitoli da un fotogramma video:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Salva la traccia di sottotitoli in un file WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Ogni oggetto [Captions](https://reference.aspose.com/slides/it/php-java/aspose.slides/captions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF-8.

**Rimuovere i sottotitoli da un fotogramma video**

Per rimuovere i sottotitoli da un fotogramma video:

1. Carica la presentazione che contiene il video.
2. Ottieni l'oggetto [VideoFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/) target.
3. Rimuovi le tracce di sottotitoli dalla raccolta [getCaptionTracks](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/#getCaptionTracks) .
4. Salva la presentazione modificata.

Il codice seguente mostra come rimuovere tutti i sottotitoli da un fotogramma video:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // tipo: VideoFrame

    // Rimuove tutti i sottotitoli dal fotogramma video.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se è necessario rimuovere solo una traccia di sottotitoli, usa i metodi [remove](https://reference.aspose.com/slides/it/php-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/it/php-java/aspose.slides/captionscollection/#removeAt) anziché [clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/captionscollection/#clear).

## **Estrarre video dalle diapositive**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) per caricare la presentazione contenente il video.
2. Itera attraverso tutti gli oggetti [Slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/) .
3. Itera attraverso tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) per trovare un [VideoFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/) .
4. Salva il video su disco.

Questo codice PHP mostra come estrarre il video da una diapositiva di una presentazione:

```php
  # Istanzia un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Ottiene l'estensione del file
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un VideoFrame?**

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/setplaymode/) (automatica o al clic) e il [looping](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/setplayloopmode/) . Queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/) .

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari sono inclusi nel documento, quindi la dimensione della presentazione cresce proporzionalmente alle dimensioni del file. Quando aggiungi un video online, viene incorporato un link e una miniatura, quindi l'aumento di dimensione è minore.

**Posso sostituire il video in un VideoFrame esistente senza modificare la sua posizione e dimensione?**

Sì. Puoi scambiare il [contenuto video](https://reference.aspose.com/slides/it/php-java/aspose.slides/videoframe/setembeddedvideo/) all'interno del fotogramma mantenendo la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [tipo di contenuto](https://reference.aspose.com/slides/it/php-java/aspose.slides/video/getcontenttype/) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.