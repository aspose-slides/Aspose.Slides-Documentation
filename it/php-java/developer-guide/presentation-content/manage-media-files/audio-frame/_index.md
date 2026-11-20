---
title: Gestire i frame audio nelle presentazioni usando PHP
linktitle: Frame audio
type: docs
weight: 10
url: /it/php-java/audio-frame/
keywords:
- audio
- frame audio
- miniatura
- aggiungi audio
- proprietà audio
- opzioni audio
- estrai audio
- PHP
- Aspose.Slides
description: "Incorpora audio nelle diapositive, cambia l'icona audio, configura la riproduzione, gestisci i sottotitoli WebVTT ed estrai i suoni di transizione delle diapositive con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Un frame audio consente di riprodurre un suono su una diapositiva. Con Aspose.Slides per PHP via Java, è possibile incorporare una clip audio, scegliere l'immagine che la rappresenta, regolare la riproduzione e allegare i sottotitoli. È inoltre possibile recuperare un suono assegnato a una transizione della diapositiva.

## **Creare frame audio**

Usa [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) per incorporare una clip audio locale nella prima diapositiva. Le prime due coordinate posizionano il frame sulla diapositiva e i successivi due valori impostano la larghezza e l'altezza, tutti in punti. Questo esempio chiama [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) per avviare automaticamente la clip e chiama [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) per selezionare il preset alto.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **Modificare la miniatura del frame audio**

Per impostazione predefinita, un frame audio visualizza un'icona dell'altoparlante. Per visualizzare una miniatura personalizzata, aggiungi un'immagine alla presentazione con [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) e impostala sull'immagine del frame con [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/). L'esempio utilizza un JPEG come miniatura per una clip audio incorporata.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **Modificare le opzioni di riproduzione audio**

I controlli **Audio Options** di PowerPoint determinano quando inizia una clip, quanto è forte e come si comporta durante una presentazione.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Controllo PowerPoint | Metodo Aspose.Slides per PHP via Java |
| --- | --- |
| Avvio | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Preset volume | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Riproduci su più diapositive | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Ripeti fino a interruzione | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Nascondi durante la presentazione | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Riavvolgi dopo la riproduzione | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Dissolvenza in entrata | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Dissolvenza in uscita | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Taglia inizio audio | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Taglia fine audio | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Regolatore volume | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

L'esempio trova il primo frame audio sulla prima diapositiva, chiama [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) per avviare la riproduzione al click e seleziona il preset di volume basso. La clip continua su più diapositive con il looping disabilitato. L'icona rimane nascosta durante la presentazione e la clip si riavvolge dopo la riproduzione.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

Per una clip più lunga di 3,5 secondi, questo esempio salta i primi 1,5 secondi e gli ultimi 2 secondi. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) restituisce la durata da omettere alla fine della clip. Per ottenere il tempo di fine mostrato in PowerPoint, sottrai quell'offset dalla durata completa della clip. La clip ritagliata sfuma in ingresso in 200 millisecondi e sfuma in uscita in 500 millisecondi. Tutti e quattro i metodi accettano valori in millisecondi.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per impostare il volume di riproduzione a una percentuale specifica, usa [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Questo esempio imposta il primo frame audio sulla prima diapositiva al 85%.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```
## **Gestire i sottotitoli audio**

Ogni frame audio fornisce l'accesso alle sue tracce di sottotitoli tramite [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks). Usa la collezione per allegare sottotitoli WebVTT alla clip, esportare le tracce esistenti o rimuoverle.

### **Aggiungere sottotitoli audio**

L'esempio incorpora una clip audio nella prima diapositiva e usa [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) per allegare una traccia WebVTT locale. Il primo argomento fornisce l'etichetta della traccia, il secondo identifica il file contenente i sottotitoli temporizzati.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **Estrarre i sottotitoli audio**

Questo esempio esporta ogni traccia di sottotitoli allegata a un frame audio sulla prima diapositiva. Scrive i byte restituiti da [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) in un file WebVTT e utilizza l'identificatore restituito da [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) come nome del file, così ogni traccia ha un output separato.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```
### **Rimuovere i sottotitoli audio**

Usa [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) per eliminare una singola traccia. L'esempio usa [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) per rimuovere tutti i sottotitoli dal primo frame audio sulla prima diapositiva preservando la clip.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```
### **Trovare una riga nei sottotitoli audio**

Per trovare una riga nei sottotitoli audio sulla prima diapositiva, cerca il testo restituito da [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) in memoria. In un cue WebVTT di testo semplice, la riga di temporizzazione contiene `-->`, le righe di sottotitolo la seguono e una riga vuota termina il cue. Questo esempio stampa l'etichetta della traccia e ciascuna riga di sottotitolo contenente “café”.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```
## **Estrarre audio**

Una transizione di diapositiva può avere un suono proprio. Per recuperarlo, chiama [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) sulla transizione della diapositiva. L'esempio accede ai byte restituiti da [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) e stampa il numero di byte. Se la prima diapositiva non ha suono di transizione, stampa un messaggio.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```
## **FAQ**

**Posso riutilizzare la stessa clip audio su più diapositive senza duplicarla?**

Sì. Aggiungi la clip una sola volta alla [collezione audio](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) della presentazione e passa lo stesso oggetto audio a [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) per ogni diapositiva.

**Posso sostituire il suono in un frame audio esistente?**

Sì. Per un suono collegato, usa [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) per puntare al file di sostituzione. Per un suono incorporato, seleziona un'altra clip dalla collezione audio della presentazione con [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). Entrambi gli approcci preservano il frame esistente.

**Il trimming modifica i dati audio memorizzati nella presentazione?**

No. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) e [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) impostano i limiti di riproduzione. È ancora possibile recuperare la clip completa da [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/).