---
title: Audioframes beheren in presentaties met PHP
linktitle: Audioframe
type: docs
weight: 10
url: /nl/php-java/audio-frame/
keywords:
- audio
- audioframe
- miniatuur
- audio toevoegen
- audio-eigenschappen
- audio-opties
- audio extraheren
- PHP
- Aspose.Slides
description: "Audio insluiten in dia's, het audio-icoon wijzigen, de weergave configureren, WebVTT-bijschriften beheren en geluiden van dia-overgangen extraheren met Aspose.Slides for PHP via Java."
---
## **Overzicht**

Een audioframe stelt u in staat een geluid af te spelen op een dia. Met Aspose.Slides for PHP via Java kunt u een audiobestand insluiten, de afbeelding kiezen die het representeert, de weergave aanpassen en bijschriften toevoegen. U kunt ook een geluid ophalen dat aan een diaovergang is toegewezen.

## **Audioframes maken**

Gebruik [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) om een lokaal audiobestand in te sluiten op de eerste dia. De eerste twee coördinaten positioneren het frame op de dia, en de volgende twee waarden stellen de breedte en hoogte in, allen in points. In dit voorbeeld wordt [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) aangeroepen om de clip automatisch te starten en wordt [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) aangeroepen om de luide voorinstelling te selecteren.

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

## **Miniatuur van het audioframe wijzigen**

Standaard toont een audioframe een luidsprekerpictogram. Om een aangepaste miniatuur weer te geven, voegt u een afbeelding toe aan de presentatie met [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) en stelt u deze in op de afbeelding van het frame met [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/). Het voorbeeld gebruikt een JPEG als miniatuur voor een ingesloten audiobestand.

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

## **Audio-afspeelopties wijzigen**

De **Audio-opties** van PowerPoint bepalen wanneer een clip start, hoe hard het klinkt en hoe het zich gedraagt tijdens een diavoorstelling.

![PowerPoint-audio-optie-bedieningsknoppen voor een audioframe](audio_frame_0.png)

| PowerPoint-bediening | Aspose.Slides voor PHP via Java-methode |
| --- | --- |
| Starten | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Volumepreset | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Afspelen over dia's | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Lus tot gestopt | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Verbergen tijdens weergave | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Terugspoelen na afspelen | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Infaden | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Uitfaden | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Begin van audio bijsnijden | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Einde van audio bijsnijden | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volumeschuifregelaar | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

Het voorbeeld zoekt het eerste audioframe op de eerste dia, roept [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) aan om de weergave te starten bij een klik, en selecteert de lage volumepreset. De clip blijft afspelen over dia's met de lus uitgeschakeld. Het pictogram blijft verborgen tijdens de weergave, en de clip wordt teruggespoeld na het afspelen.

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

Voor een clip langer dan 3,5 seconden slaat dit voorbeeld de eerste 1,5 seconden en de laatste 2 seconden over. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) neemt de duur die van het einde van de clip moet worden weggelaten. Om de eindtijd te verkrijgen die in PowerPoint wordt weergegeven, trekt u die offset af van de volledige clipduur. De bijgesneden clip fadt in over 200 milliseconden en fadt uit over 500 milliseconden. Alle vier methoden verwachten waarden in milliseconden.

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

Om het afspeelvolume op een specifiek percentage in te stellen, gebruikt u [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Dit voorbeeld stelt het eerste audioframe op de eerste dia in op 85%.

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

## **Audio‑bijschriften beheren**

Elk audioframe biedt toegang tot zijn bijschriftsporen via [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks). Gebruik de collectie om WebVTT‑bijschriften aan de clip toe te voegen, bestaande sporen te exporteren of ze te verwijderen.

### **Audio‑bijschriften toevoegen**

Het voorbeeld slijt een audioclip in op de eerste dia en gebruikt [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) om een lokaal WebVTT‑spoor toe te voegen. Het eerste argument geeft het label van het spoor, en het tweede identificeert het bestand dat de getimede bijschriften bevat.

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

### **Audio‑bijschriften extraheren**

Dit voorbeeld exporteert elk bijschriftspoor dat aan een audioframe op de eerste dia is gekoppeld. Het schrijft de bytes die door [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) worden geretourneerd naar een WebVTT‑bestand en gebruikt de identifier die door [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) wordt geretourneerd als bestandsnaam zodat elk spoor een aparte output krijgt.

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

### **Audio‑bijschriften verwijderen**

Gebruik [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) om een individueel spoor te verwijderen. Het voorbeeld gebruikt [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) om alle bijschriften van het eerste audioframe op de eerste dia te verwijderen terwijl de clip behouden blijft.

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

### **Een regel in audio‑bijschriften vinden**

Om een regel in de audio‑bijschriften op de eerste dia te vinden, zoekt u in het geheugen naar de tekst die door [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) wordt geretourneerd. In een platte‑tekst WebVTT‑cue bevat de timing‑regel `-->`, de bijschrift‑regels volgen, en een lege regel beëindigt de cue. Dit voorbeeld drukt het spoor‑label en elke bijschriftregel af die “café” bevat.

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

## **Audio extraheren**

Een diaovergang kan een eigen geluid hebben. Om dit op te halen, roept u [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) aan op de diaovergang. Het voorbeeld krijgt de bytes die door [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) worden geretourneerd en drukt het aantal bytes af. Als de eerste dia geen overgangsgeluid heeft, wordt in plaats daarvan een bericht afgedrukt.

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

## **Veelgestelde vragen**

**Kan ik dezelfde audioclIP op meerdere dia's hergebruiken zonder het te dupliceren?**

Ja. Voeg de clip één keer toe aan de [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) van de presentatie en geef hetzelfde audio‑object door aan [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) voor elke dia.

**Kan ik het geluid in een bestaand audioframe vervangen?**

Ja. Voor een gekoppeld geluid gebruikt u [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) om naar het vervangende bestand te wijzen. Voor een ingesloten geluid selecteert u een andere clip uit de audio‑collectie van de presentatie met [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). Beide benaderingen behouden het bestaande frame.

**Verandert bijsnijden de audio­data die in de presentatie is opgeslagen?**

Nee. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) en [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) stellen afspeelgrenzen in. U kunt nog steeds de volledige clip ophalen via [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/).