---
title: Gestire i frame video nelle presentazioni usando PHP
linktitle: Frame video
type: docs
weight: 10
url: /it/php-java/video-frame/
keywords:
- aggiungere video
- creare video
- incorporare video
- estrarre video
- recuperare video
- frame video
- sorgente web
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Impara ad aggiungere ed estrarre programmaticamente i frame video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per PHP via Java. Guida rapida passo passo."
---
## **Introduzione**

I video possono aiutare a spiegare le idee e coinvolgere il pubblico. Aspose.Slides per PHP via Java consente di aggiungere frame video alle diapositive, regolare le impostazioni di riproduzione, gestire i sottotitoli e estrarre i dati video incorporati.

PowerPoint supporta video locali e collegamenti a video online, come i video di YouTube.

Per rappresentare i dati video e i frame video, Aspose.Slides fornisce la classe [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) , la classe [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) e altri tipi pertinenti.

## **Crea un frame video incorporato**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, puoi creare un frame video per incorporare il video nella tua presentazione.

Questo esempio incorpora un video locale nella prima diapositiva di una presentazione esistente e salva il risultato. Le coordinate e le dimensioni del frame sono espresse in punti. Lo stream rimane aperto fino al completamento del salvataggio perché [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) lo mantiene bloccato mentre la presentazione lo utilizza.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

Puoi anche passare direttamente un percorso video locale a [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Questo esempio incorpora il video nella prima diapositiva di una nuova presentazione. Il video deve rimanere accessibile fino al salvataggio della presentazione.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Crea un frame video con video da una fonte web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supporta video online nelle presentazioni. Puoi creare un frame video che collega a un video online, come un video di YouTube.

Questo esempio aggiunge un collegamento a un video YouTube e una miniatura alla prima diapositiva. Sostituisci l'identificatore del video per utilizzare un altro video. Il metodo [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) richiede la riproduzione automatica. Il download della miniatura e la riproduzione del video richiedono l'accesso a internet. Il visualizzatore della presentazione deve inoltre supportare la riproduzione di video online.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Riproduci un video in modalità a schermo intero**

In una presentazione formativa, puoi riprodurre una dimostrazione software in modalità a schermo intero in modo che il pubblico possa vedere i dettagli. Chiama [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) con `true` per abilitare questo comportamento durante la riproduzione.

Questo esempio apre una presentazione, trova il primo [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) nella prima diapositiva e abilita la riproduzione a schermo intero. La presentazione di input deve contenere almeno una diapositiva con un frame video esistente nella prima diapositiva.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La riproduzione a schermo intero controlla come viene visualizzato il video. In modo indipendente, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) controlla se inizia automaticamente o al clic, e [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) controlla se si ripete. Per scegliere il comportamento di avvio, imposta la modalità di riproduzione su [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). L'esempio conserva le impostazioni di avvio e di loop esistenti.

## **Riavvolgi un video dopo la riproduzione**

In una presentazione formativa, riportare un video dimostrativo all'inizio lo rende pronto per il presentatore per essere riprodotto nuovamente. Chiama [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) con `true` per riportare il video all'inizio dopo il termine della riproduzione.

Questo esempio apre una presentazione, trova il primo [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) nella prima diapositiva e abilita il riavvolgimento. Disabilita il loop in modo che la riproduzione possa terminare e imposta l'avvio della riproduzione al clic. La presentazione di input deve contenere almeno una diapositiva con un frame video esistente nella prima diapositiva.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il riavvolgimento riporta il video all'inizio senza avviarlo nuovamente. Al contrario, chiamare [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) con `true` ripete la riproduzione automaticamente. Mantieni il loop disabilitato quando vuoi che il video termini e rimanga pronto per essere riprodotto di nuovo. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) controlla indipendentemente l'avvio automatico o al clic; questo esempio utilizza [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) così il presentatore controlla quando inizia la riproduzione. Imposta la modalità di riproduzione dopo l'impostazione del loop, come mostrato nell'esempio. Il riavvolgimento funziona indipendentemente da [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Ritaglia un frame video**

Usa [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) e [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) per saltare una parte dell'inizio o della fine di un video durante la riproduzione. Entrambi i valori sono espressi in millisecondi. Il ritaglio modifica le impostazioni di riproduzione senza modificare i dati video incorporati.

**Imposta le impostazioni di ritaglio**

Questo esempio incorpora un video locale e salta i primi 2,5 secondi e l'ultimo secondo durante la riproduzione. Usa un video più lungo di 3,5 secondi in modo che rimanga un segmento riproducibile.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Leggi le impostazioni di ritaglio**

Questo esempio stampa i valori di ritaglio del primo frame video nella prima diapositiva in millisecondi. La presentazione deve contenere almeno una diapositiva. Se quella diapositiva non ha un frame video, non viene stampato nulla. L'esempio precedente produce valori di 2500 e 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Gestisci i sottotitoli video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i frame video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati nel formato WebVTT e sono accessibili tramite il metodo [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Aggiungi sottotitoli a un frame video**

Questo esempio incorpora un video locale e aggiunge una traccia di sottotitoli WebVTT etichettata English. I timestamp dei sottotitoli dovrebbero corrispondere al video. La presentazione salvata include sia il video sia i suoi sottotitoli.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) fornisce anche un overload che consente di aggiungere sottotitoli da uno stream.

**Estrai i sottotitoli da un frame video**

Questo esempio salva tutte le tracce di sottotitoli dei frame video nella prima diapositiva come file WebVTT separati. I numeri sequenziali mantengono i file di output distinti. La console riporta il numero di tracce estratte. La presentazione deve contenere almeno una diapositiva.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Ogni oggetto [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF-8.

**Rimuovi i sottotitoli da un frame video**

Questo esempio rimuove tutti i sottotitoli dal frame video nella prima posizione della forma nella prima diapositiva e salva il risultato. Si assume che la diapositiva e la forma esistano e che la forma sia un frame video.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se devi rimuovere solo una traccia di sottotitoli, usa i metodi [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) invece di [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Estrai video da una diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

Questo esempio estrae i video incorporati da ogni diapositiva in file binari separati e numerati. I video collegati vengono ignorati perché non hanno dati incorporati. La console stampa il tipo MIME di ciascun video e il conteggio totale. L'output utilizza l'estensione generica `.bin`; cambiala per corrispondere al tipo di media segnalato quando necessario.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un frame video?**

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (auto o al clic) e la [ripetizione](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Queste opzioni sono disponibili tramite i metodi dell'oggetto [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari vengono inclusi nel documento, quindi la dimensione della presentazione cresce in proporzione alla dimensione del file. Quando colleghi un video online e aggiungi una miniatura, la presentazione memorizza il collegamento e l'immagine di anteprima anziché i dati video, quindi l'aumento di dimensione è solitamente minore.

**Posso sostituire il video in un frame video esistente senza cambiarne posizione e dimensione?**

Sì. Puoi scambiare il [contenuto video](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) all'interno del frame mantenendo la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [tipo di contenuto](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.