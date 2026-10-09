---
title: Beheer video‑frames in presentaties met PHP
linktitle: Video‑frame
type: docs
weight: 10
url: /nl/php-java/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- video‑frame
- webbron
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u programmatisch video‑frames kunt toevoegen en extraheren in PowerPoint‑ en OpenDocument‑dia’s met Aspose.Slides voor PHP via Java. Snelle stapsgewijze handleiding."
---
## **Introductie**

Video’s kunnen helpen ideeën uit te leggen en een publiek te boeien. Aspose.Slides voor PHP via Java stelt u in staat video‑frames aan dia’s toe te voegen, afspeelinstellingen aan te passen, ondertitels te beheren en ingesloten videogegevens te extraheren.

PowerPoint ondersteunt lokale video’s en koppelingen naar online video’s, zoals YouTube‑video’s.

Om video‑gegevens en video‑frames te representeren, levert Aspose.Slides de klasse [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/), de klasse [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) en andere relevante types.

## **Een ingesloten video‑frame maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een video‑frame maken om de video in uw presentatie in te sluiten.

Dit voorbeeld voegt een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. De coördinaten en afmetingen van het frame zijn in punten. De stream blijft geopend totdat het opslaan voltooid is, omdat [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) deze vergrendeld houdt zolang de presentatie deze gebruikt.

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

U kunt ook een lokaal video‑pad rechtstreeks doorgeven aan [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Dit voorbeeld voegt de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven totdat de presentatie is opgeslagen.

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

## **Een video‑frame maken met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video’s in presentaties. U kunt een video‑frame maken dat koppelt naar een online video, zoals een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videokoppeling en miniatuur toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De methode [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) vraagt om automatische afspelen. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatie‑viewer moet ook online video‑afspelen ondersteunen.

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

## **Een video afspelen in volledig‑schermmodus**

In een trainingspresentatie kunt u een software‑demo in volledig‑schermmodus afspelen zodat het publiek de details kan zien. Roep [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) aan met `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, zoekt het eerste [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) op de eerste dia en schakelt volledig‑scherm‑afspelen in. De invoer‑presentatie moet minimaal één dia bevatten met een bestaand video‑frame op de eerste dia.

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

Volledig‑scherm‑afspelen bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan bepaalt [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) of de video automatisch of bij een klik start, en bepaalt [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) of deze wordt herhaald. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset::Auto of VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en loop‑instellingen.

## **Een video terugspoelen na afspelen**

In een trainingspresentatie maakt het terugbrengen van een demonstratie‑video naar het begin de video klaar voor de presentator om opnieuw af te spelen. Roep [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) aan met `true` om de video na het afspelen terug naar het begin te brengen.

Dit voorbeeld opent een presentatie, zoekt het eerste [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) op de eerste dia en schakelt terugspoelen in. Het schakelt herhalen uit zodat het afspelen kan eindigen en stelt het afspelen in om bij een klik te starten. De invoer‑presentatie moet minstens één dia bevatten met een bestaand video‑frame op de eerste dia.

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

Terugspoelen brengt de video terug naar het begin zonder deze opnieuw te starten. Daarentegen zorgt het aanroepen van [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) met `true` voor automatische herhaling van het afspelen. Houd herhalen uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft om opnieuw afgespeeld te worden. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) regelt onafhankelijk automatisch of bij een klik starten; dit voorbeeld gebruikt [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen start. Stel de afspeelmodus in na de loop‑instelling, zoals in het voorbeeld wordt getoond. Terugspoelen werkt onafhankelijk van [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Een video‑frame trimmen**

Gebruik [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) en [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) om een deel van het begin of einde van een video over te slaan tijdens het afspelen. Beide waarden zijn in milliseconden. Trimmen wijzigt de afspeelinstellingen zonder de ingesloten videogegevens aan te passen.

**Triminstellingen instellen**

Dit voorbeeld voegt een lokale video in en slaat de eerste 2,5 seconde en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconde zodat er een afspeelbaar segment overblijft.

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

**Triminstellingen lezen**

Dit voorbeeld drukt de trim‑waarden van het eerste video‑frame op de eerste dia af in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen video‑frame heeft, wordt er niets afgedrukt. Het voorgaande voorbeeld levert waarden van 2500 en 1000.

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

## **Video‑bijschriften beheren**

Aspose.Slides stelt u in staat gesloten bijschriften voor video‑frames in PowerPoint‑presentaties te beheren. Bijschriften worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de methode [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Bijschriften toevoegen aan een video‑frame**

Dit voorbeeld voegt een lokale video in en voegt een WebVTT‑bijschrifttrack toe met het label English. De tijdstempels van het bijschrift moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de bijschriften.

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

De klasse [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) biedt bovendien een overload waarmee u bijschriften vanuit een stream kunt toevoegen.

**Bijschriften extraheren uit een video‑frame**

Dit voorbeeld slaat alle bijschrifttracks van video‑frames op de eerste dia op als afzonderlijke WebVTT‑bestanden. Opeenvolgende nummers houden de uitvoerbestanden onderscheidend. De console meldt het aantal geëxtraheerde tracks. De presentatie moet minstens één dia bevatten.

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

Elk [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) object maakt de bijschrift‑identifier, het label, de binaire data en de bijschrift‑tekst bloot als een UTF‑8‑string.

**Bijschriften verwijderen uit een video‑frame**

Dit voorbeeld verwijdert alle bijschriften van het video‑frame op de eerste vormpositie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een video‑frame is.

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

Als u slechts één bijschrifttrack wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) in plaats van [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Video extraheren van een dia**

Naast het toevoegen van video’s aan dia’s, maakt Aspose.Slides het mogelijk video’s die in presentaties zijn ingesloten te extraheren.

Dit voorbeeld extraheren ingesloten video’s van elke dia naar afzonderlijke, genummerde binaire bestanden. Gelinkte video’s worden overgeslagen omdat ze geen ingesloten data hebben. De console drukt het MIME‑type van elke video en het totale aantal af. De output gebruikt de generieke extensie `.bin`; verander deze om overeen te komen met het gerapporteerde mediatype indien nodig.

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

**Welke afspeelparameters van een video‑frame kunnen worden aangepast?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (auto of bij klik) en de [herhaling](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) regelen. Deze opties zijn beschikbaar via de methoden van het [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig toeneemt met de bestandsgrootte. Wanneer u naar een online video linkt en een miniatuur toevoegt, slaat de presentatie de koppeling en het preview‑beeld op in plaats van de video‑data, waardoor de grootte‑toename meestal kleiner is.

**Kan ik de video in een bestaand video‑frame vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video‑inhoud](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) dat u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.