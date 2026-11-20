---
title: Beheer videoframes in presentaties met PHP
linktitle: Videoframe
type: docs
weight: 10
url: /nl/php-java/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- videoframe
- webbron
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u programmatisch videoframes kunt toevoegen en extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor PHP via Java. Snelle stap-voor-stap gids."
---
## **Inleiding**

Video's kunnen helpen om ideeën uit te leggen en een publiek te boeien. Aspose.Slides voor PHP via Java stelt u in staat om videoframes aan dia's toe te voegen, afspeelinstellingen aan te passen, ondertitels te beheren en ingebedde videogegevens te extraheren.

PowerPoint ondersteunt lokale video's en koppelingen naar online video's, zoals YouTube‑video's.

Om video‑gegevens en videoframes weer te geven, biedt Aspose.Slides de [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/)‑klasse, de [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)‑klasse en andere relevante types.

## **Een ingebedde videoframe maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten.

Dit voorbeeld legt een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en -afmetingen worden opgegeven in points. De stream blijft open tot het opslaan voltooid is, omdat [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) deze vergrendeld houdt terwijl de presentatie hem gebruikt.

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

U kunt ook direct een lokaal videopad doorgeven aan [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Dit voorbeeld legt de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven tot de presentatie is opgeslagen.

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

## **Een videoframe maken met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online‑video's in presentaties. U kunt een videoframe maken dat naar een online video linkt, bijvoorbeeld een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videokoppeling en miniatuur toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode)‑methode vraagt om automatisch afspelen. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatieweergave moet ook online‑video’s kunnen afspelen.

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

## **Een video in volledig scherm afspelen**

In een trainingspresentatie kunt u een software‑demonstratie in volledig scherm afspelen zodat het publiek de details kan zien. roep [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) aan met `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, vindt het eerste [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) op de eerste dia, en schakelt afspelen op volledig scherm in. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Afspelen in volledig scherm bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan bepaalt [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) of hij automatisch of bij klik start, en [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) of hij herhaalt. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset::Auto of VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lussinstellingen.

## **Een video terugspoelen na afspelen**

In een trainingspresentatie maakt het terugspoelen van een demonstratie‑video naar het begin de video gereed voor een nieuwe weergave. Roep [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) aan met `true` om de video na het afspelen naar het begin te laten terugkeren.

Dit voorbeeld opent een presentatie, vindt het eerste [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) op de eerste dia, en schakelt terugspoelen in. Het schakelt lussen uit zodat het afspelen kan eindigen en stelt afspelen in op starten bij klik. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Terugspoelen plaatst de video terug aan het begin zonder hem opnieuw te starten. Daarentegen zorgt [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) met `true` voor automatisch herhalen. Houd lussen uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft om opnieuw afgespeeld te worden. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) regelt onafhankelijk automatisch of bij klik starten; dit voorbeeld gebruikt [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen start. Stel de afspeelmodus in na de luseigenschap, zoals in het voorbeeld wordt getoond. Terugspoelen werkt onafhankelijk van [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Een videoframe inkorten**

Gebruik [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) en [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) om een deel aan het begin of einde van een video over te slaan tijdens het afspelen. Beide waarden worden opgegeven in milliseconden. Inknippen wijzigt afspeelinstellingen zonder de ingebedde videogegevens te wijzigen.

**Triminstellingen instellen**

Dit voorbeeld legt een lokale video in en slaat de eerste 2,5 seconde en de laatste seconde over tijdens het afspelen. Gebruik een video die langer is dan 3,5 seconde zodat er een afspeelbaar segment overblijft.

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

Dit voorbeeld print de trim‑waarden van het eerste videoframe op de eerste dia in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen videoframe heeft, wordt er niets geprint. Het voorgaande voorbeeld levert de waarden 2500 en 1000 op.

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

## **Video‑ondertitels beheren**

Aspose.Slides laat u gesloten ondertitels voor videoframes in PowerPoint‑presentaties beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks)‑methode.

### **Ondertitels aan een videoframe toevoegen**

Dit voorbeeld legt een lokale video in en voegt een WebVTT‑ondertiteltrack toe met de label “English”. De tijdstempels van de ondertitels moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de ondertitels.

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

De [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/)‑klasse biedt ook een overload waarmee u ondertitels uit een stream kunt toevoegen.

### **Ondertitels uit een videoframe extraheren**

Dit voorbeeld slaat alle ondertitel‑tracks van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Sequentiële nummers houden de uitvoerbestanden uniek. De console meldt het aantal geëxtraheerde tracks. De presentatie moet minstens één dia bevatten.

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

Elk [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/)‑object geeft de ondertitel‑identifier, label, binaire gegevens en ondertiteltekst als een UTF‑8‑string weer.

### **Ondertitels uit een videoframe verwijderen**

Dit voorbeeld verwijdert alle ondertitels van het videoframe op de eerste shape‑positie op de eerste dia en slaat het resultaat op. Er wordt vanuit gegaan dat de dia en de shape bestaan en dat de shape een videoframe is.

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

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove)‑ of [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt)‑methoden in plaats van [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

### **Video‑ondertitels doorzoeken**

[Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) retourneert de volledige WebVTT‑track, inclusief header, timing‑regels en ondertiteltekst. U kunt de cues in het geheugen doorzoeken om een gesproken zin en de bijbehorende tijdstempel te vinden. Bijvoorbeeld, een Engelse track op dia 2 kan de volgende tekst bevatten.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Het voorbeeld opent `captioned_media.pptx` en gebruikt [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) om de tracks van elk videoframe op elke dia te lezen. In een plain‑text cue bevat de timing‑regel `-->`, en een lege regel beëindigt de cue. Wanneer de ondertitel het woord “café” bevat, ongeacht hoofd‑/kleine letters, print het voorbeeld het dia‑nummer, track‑label, originele timing‑regel en de volledige ondertitel.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("captioned_media.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                continue;
            }
            $trackCount = java_values($shape->getCaptionTracks()->getCount());
            for ($index = 0; $index < $trackCount; $index++) {
                $track = $shape->getCaptionTracks()->get_Item($index);
                $lines = preg_split('/\r\n|\n|\r/', java_values($track->getDataAsString()));
                $lineCount = count($lines);
                for ($i = 0; $i < $lineCount; $i++) {
                    $timing = $lines[$i];
                    if (strpos($timing, "-->") === false) {
                        continue;
                    }
                    $captionLines = [];
                    while (++$i < $lineCount && $lines[$i] !== "") {
                        $captionLines[] = $lines[$i];
                    }
                    $caption = implode("\n", $captionLines);
                    if (preg_match('/café/iu', $caption)) {
                        printf("Slide %d | %s | %s\n", java_values($slide->getSlideNumber()), java_values($track->getLabel()), $timing);
                        echo $caption, "\n";
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Zoeken op “café” levert één overeenkomst op voor de voorbeeldtrack. De zoekopdracht sluit de track‑header uit en behoudt de timing‑instelling in de uitvoer.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Video uit een dia extraheren**

Naast het toevoegen van video’s aan dia’s maakt Aspose.Slides het mogelijk om video’s die in presentaties zijn ingebed te extraheren.

Dit voorbeeld extraheert ingebedde video’s van elke dia naar afzonderlijke, genummerde bin‑bestanden. Gelinkte video’s worden overgeslagen omdat ze geen ingebedde gegevens bevatten. De console print het MIME‑type van elke video en het totale aantal. De uitvoer gebruikt de generieke extensie `.bin`; wijzig deze indien nodig zodat hij overeenkomt met het gerapporteerde mediatype.

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

**Welke afspeelparameters kunnen voor een videoframe worden aangepast?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (automatisch of bij klik) en het [herhalen](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) regelen. Deze opties zijn beschikbaar via de methoden van het [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)‑object.

**Heeft het toevoegen van een video impact op de grootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video inbedt, wordt de binaire data in het document opgenomen, waardoor de grootte van de presentatie evenredig toeneemt met de bestandsgrootte. Wanneer u linkt naar een online video en een thumbnail toevoegt, slaat de presentatie alleen de koppeling en het voorbeeldbeeld op, waardoor de toename meestal kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en afmetingen te wijzigen?**

Ja. U kunt de [videoinhoud](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) binnen het frame omwisselen terwijl u de geometrie van de shape behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingebedde video worden bepaald?**

Ja. Een ingebedde video heeft een [content‑type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) dat u kunt uitlezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.