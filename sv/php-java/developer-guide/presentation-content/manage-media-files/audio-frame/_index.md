---
title: "Hantera ljudramar i presentationer med PHP"
linktitle: "Ljudram"
type: docs
weight: 10
url: /sv/php-java/audio-frame/
keywords:
- ljud
- ljudram
- miniatyrbild
- lägg till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- PHP
- Aspose.Slides
description: "Bädda in ljud i bilder, ändra ljudikonen, konfigurera uppspelning, hantera WebVTT-undertexter och extrahera ljud från bildövergångar med Aspose.Slides för PHP via Java."
---
## **Översikt**

En ljudram låter dig spela ett ljud på en bild. Med Aspose.Slides för PHP via Java kan du bädda in ett ljudklipp, välja bilden som representerar det, justera uppspelning och bifoga undertexter. Du kan också hämta ett ljud som tilldelats en bildövergång.

## **Skapa ljudramar**

Använd [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) för att bädda in ett lokalt ljudklipp på den första bilden. De två första koordinaterna placerar ramen på bilden, och de två nästa värdena anger dess bredd och höjd, alla i punkter. Detta exempel anropar [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) för att starta klippet automatiskt och anropar [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) för att välja det höga förinställningsvärdet.

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
## **Ändra ljudramens miniatyrbild**

Som standard visar en ljudram en högtalarikon. För att visa en anpassad miniatyr, lägg till en bild i presentationen med [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) och sätt den på ramens bild med [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/). Exemplet använder en JPEG som miniatyr för ett inbäddat ljudklipp.

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
## **Ändra ljuduppspelningsalternativ**

PowerPoints **Audio Options**-kontroller bestämmer när ett klipp startar, hur högt det låter och hur det beter sig under en bildspelsvisning.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint‑kontroll | Aspose.Slides för PHP via Java‑metod |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Volymförinställning | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Spela över bilder | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Upprepa tills stoppad | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Dölj under visning | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Spola tillbaka efter uppspelning | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Tona in | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Tona ut | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Trimma ljud starttid | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Trimma ljud sluttid | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volymreglage | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

Exemplet hittar den första ljudramen på den första bilden, anropar [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) för att starta uppspelning vid ett klick och väljer den låga volymförinställningen. Klippet fortsätter över bilder med upprepning inaktiverad. Ikonen förblir dold under visningen, och klippet spolar tillbaka efter uppspelning.

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
För ett klipp längre än 3,5 sekunder hoppar detta exempel över de första 1,5 sekunderna och de sista 2 sekunderna. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) tar den varaktighet som ska utelämnas från slutet av klippet. För att få sluttiden som visas i PowerPoint, subtrahera den förskjutningen från hela klippets varaktighet. Det trimmade klippet tonar in på 200 millisekunder och tonar ut på 500 millisekunder. Alla fyra metoder tar värden i millisekunder.

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
För att ange uppspelningsvolymen till en specifik procentsats, använd [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Detta exempel sätter den första ljudramen på den första bilden till 85 %.

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
## **Hantera ljudundertexter**

Varje ljudram ger åtkomst till sina undertextspår via [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks). Använd samlingen för att bifoga WebVTT-undertexter till klippet, exportera befintliga spår eller ta bort dem.

### **Lägg till ljudundertexter**

Exemplet bäddar in ett ljudklipp på den första bilden och använder [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) för att bifoga ett lokalt WebVTT-spår. Det första argumentet anger spårets etikett, och det andra identifierar filen som innehåller de tidskodade undertexterna.

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
### **Extrahera ljudundertexter**

Detta exempel exporterar varje undertextspår som är bifogat till en ljudram på den första bilden. Det skriver de bytes som returneras av [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) till en WebVTT‑fil och använder identifieraren som returneras av [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) som filnamn så att varje spår får en separat utdata.

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
### **Ta bort ljudundertexter**

Använd [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) för att ta bort ett enskilt spår. Exemplet använder [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) för att ta bort alla undertexter från den första ljudramen på den första bilden samtidigt som klippet bevaras.

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
### **Hitta en rad i ljudundertexter**

För att hitta en rad i ljudundertexterna på den första bilden, sök i den text som returneras av [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) i minnet. I en rentext‑WebVTT‑cue innehåller tidslinjen `-->`, följt av undertextraderna, och en tom rad avslutar cue:n. Detta exempel skriver ut spår‑etiketten och varje undertextrad som innehåller “café”.

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
## **Extrahera ljud**

En bildövergång kan ha ett eget ljud. För att hämta det, anropa [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) på bildövergången. Exemplet får åtkomst till de bytes som returneras av [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) och skriver ut antalet bytes. Om den första bilden saknar övergångsljud skrivs ett meddelande ut istället.

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
## **Vanliga frågor**

**Kan jag återanvända samma ljudklipp på flera bilder utan att duplicera det?**

Ja. Lägg till klippet en gång i presentationens [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) och skicka samma ljudobjekt till [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) för varje bild.

**Kan jag ersätta ljudet i en befintlig ljudram?**

Ja. För ett länkat ljud, använd [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) för att peka på ersättningsfilen. För ett inbäddat ljud, välj ett annat klipp från presentationens ljudsamling med [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). Båda metoderna bevarar den befintliga ramen.

**Ändrar trimning ljuddata som lagras i presentationen?**

Nej. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) och [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) anger uppspelningsgränser. Du kan fortfarande hämta hela klippet från [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/).