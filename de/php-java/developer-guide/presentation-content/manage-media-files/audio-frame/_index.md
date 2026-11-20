---
title: Audio‑Frames in Präsentationen mit PHP verwalten
linktitle: Audio‑Frame
type: docs
weight: 10
url: /de/php-java/audio-frame/
keywords:
- Audio
- Audio‑Frame
- Vorschaubild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- PHP
- Aspose.Slides
description: "Audio in Folien einbetten, das Audiosymbol ändern, die Wiedergabe konfigurieren, WebVTT-Untertitel verwalten und Folienübergangstöne extrahieren mit Aspose.Slides für PHP via Java."
---
## **Übersicht**

Ein Audio‑Frame ermöglicht das Abspielen eines Sounds auf einer Folie. Mit Aspose.Slides für PHP via Java können Sie einen Audio‑Clip einbetten, das Bild auswählen, das ihn darstellt, die Wiedergabe anpassen und Untertitel hinzufügen. Sie können auch einen einem Folienübergang zugewiesenen Sound abrufen.

## **Audio‑Frames erstellen**

Verwenden Sie [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) , um einen lokalen Audio‑Clip auf der ersten Folie einzubetten. Die ersten beiden Koordinaten positionieren den Frame auf der Folie, und die nächsten beiden Werte legen seine Breite und Höhe fest, alles in Punkten. Dieses Beispiel ruft [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) auf, um den Clip automatisch zu starten, und ruft [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) auf, um die laute Voreinstellung auszuwählen.

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

## **Thumbnail des Audio‑Frames ändern**

Standardmäßig zeigt ein Audio‑Frame ein Lautsprechersymbol an. Um ein benutzerdefiniertes Thumbnail anzuzeigen, fügen Sie der Präsentation mit [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) ein Bild hinzu und setzen es mit [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/) auf das Bild des Frames. Das Beispiel verwendet ein JPEG als Thumbnail für einen eingebetteten Audio‑Clip.

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

## **Audio‑Wiedergabeoptionen ändern**

Die **Audio‑Optionen** von PowerPoint bestimmen, wann ein Clip startet, wie laut er ist und wie er während einer Bildschirmpräsentation funktioniert.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint‑Steuerelement | Aspose.Slides für PHP via Java‑Methode |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Lautstärke‑Voreinstellung | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Wiedergabe über Folien hinweg | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Schleife bis gestoppt | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Während der Präsentation ausblenden | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Nach der Wiedergabe zurückspulen | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Einblenden | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Ausblenden | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Audio‑Startzeit zuschneiden | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Audio‑Endzeit zuschneiden | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Lautstärkeregler | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

Das Beispiel findet den ersten Audio‑Frame auf der ersten Folie, ruft [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) auf, um die Wiedergabe bei einem Klick zu starten, und wählt die niedrige Lautstärke‑Voreinstellung aus. Der Clip wird über Folien hinweg fortgesetzt, wobei die Schleife deaktiviert ist. Das Symbol bleibt während der Präsentation ausgeblendet, und der Clip wird nach der Wiedergabe zurückgespult.

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

Für einen Clip, der länger als 3,5 Sekunden ist, überspringt dieses Beispiel die ersten 1,5 Sekunden und die letzten 2 Sekunden. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) nimmt die Dauer, die am Ende des Clips weggelassen werden soll. Um die in PowerPoint angezeigte Endzeit zu erhalten, ziehen Sie diesen Versatz von der Gesamtdauer des Clips ab. Der zugeschnittene Clip blendet über 200 Millisekunden ein und über 500 Millisekunden aus. Alle vier Methoden erwarten Werte in Millisekunden.

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

Um die Wiedergabelautstärke auf einen bestimmten Prozentsatz einzustellen, verwenden Sie [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Dieses Beispiel setzt den ersten Audio‑Frame auf der ersten Folie auf 85 %.

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

## **Audio‑Untertitel verwalten**

Jeder Audio‑Frame bietet über [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks) Zugriff auf seine Untertitelspuren. Verwenden Sie die Sammlung, um WebVTT‑Untertitel dem Clip hinzuzufügen, vorhandene Spuren zu exportieren oder zu entfernen.

### **Audio‑Untertitel hinzufügen**

Das Beispiel bettet einen Audio‑Clip auf der ersten Folie ein und verwendet [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add), um eine lokale WebVTT‑Spur hinzuzufügen. Das erste Argument liefert die Spurenbezeichnung, das zweite identifiziert die Datei mit den zeitlich abgestimmten Untertiteln.

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

### **Audio‑Untertitel extrahieren**

Dieses Beispiel exportiert jede Untertitelspur, die an einem Audio‑Frame auf der ersten Folie angehängt ist. Es schreibt die von [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) zurückgegebenen Bytes in eine WebVTT‑Datei und verwendet die von [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) zurückgegebene Kennung als Dateinamen, sodass jede Spur eine separate Ausgabe hat.

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

### **Audio‑Untertitel entfernen**

Verwenden Sie [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt), um eine einzelne Spur zu löschen. Das Beispiel verwendet [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear), um alle Untertitel vom ersten Audio‑Frame auf der ersten Folie zu entfernen, während der Clip erhalten bleibt.

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

### **Eine Zeile in Audio‑Untertiteln finden**

Um eine Zeile in den Audio‑Untertiteln auf der ersten Folie zu finden, durchsuchen Sie den von [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) zurückgegebenen Text im Speicher. In einem Klartext‑WebVTT‑Cue enthält die Zeitzeile `-->`, die Untertitelzeilen folgen darauf, und eine leere Zeile beendet den Cue. Dieses Beispiel gibt die Spurenbezeichnung und jede Untertitelzeile aus, die „café“ enthält.

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

## **Audio extrahieren**

Ein Folienübergang kann einen eigenen Sound haben. Um ihn abzurufen, rufen Sie [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) beim Folienübergang auf. Das Beispiel greift auf die von [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) zurückgegebenen Bytes zu und gibt die Anzahl der Bytes aus. Hat die erste Folie keinen Übergangssound, wird stattdessen eine Meldung ausgegeben.

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

**Kann ich denselben Audio‑Clip auf mehreren Folien wiederverwenden, ohne ihn zu duplizieren?**

Ja. Fügen Sie den Clip einmal zur [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) der Präsentation hinzu und übergeben Sie dasselbe Audio‑Objekt bei jedem Aufruf von [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) an die jeweilige Folie.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen?**

Ja. Für einen verknüpften Sound verwenden Sie [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/), um auf die Ersatzdatei zu verweisen. Für einen eingebetteten Sound wählen Sie einen anderen Clip aus der Audio‑Sammlung der Präsentation mit [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). Beide Vorgehensweisen erhalten den bestehenden Frame.

**Verändert das Trimmen die in der Präsentation gespeicherten Audiodaten?**

Nein. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) und [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) setzen nur die Wiedergabegrenzen. Sie können den vollständigen Clip weiterhin über [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/) abrufen.