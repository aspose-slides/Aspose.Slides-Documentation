---
title: Hantera video-ramar i presentationer med PHP
linktitle: Video-ram
type: docs
weight: 10
url: /sv/php-java/video-frame/
keywords:
- lägga till video
- skapa video
- bädda in video
- extrahera video
- hämta video
- video-ram
- webbkälla
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig programatiskt lägga till och extrahera video-ramar i PowerPoint- och OpenDocument-bilder med Aspose.Slides för PHP via Java. Snabb steg-för-steg-guide."
---
## **Introduktion**

Videor kan hjälpa till att förklara idéer och engagera en publik. Aspose.Slides för PHP via Java låter dig lägga till video‑ramar på bilder, justera uppspelningsinställningar, hantera undertexter och extrahera inbäddad videodata.

PowerPoint stöder lokala videor och länkar till online‑videor, till exempel YouTube‑videor.

För att representera videodata och video‑ramar tillhandahåller Aspose.Slides klasserna [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/), [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) och andra relevanta typer.

## **Skapa en inbäddad video‑ram**

Om videofilen du vill lägga till på bilden finns lokalt kan du skapa en video‑ram för att bädda in videon i presentationen.

Detta exempel bäddar in en lokal video på den första bilden i en befintlig presentation och sparar resultatet. Ramens koordinater och dimensioner anges i punkter. Strömmen förblir öppen tills sparandet är klart eftersom [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) håller den låst medan presentationen använder den.

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

Du kan också skicka en lokal videoväg direkt till [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Detta exempel bäddar in videon på den första bilden i en ny presentation. Videon måste förbli åtkomlig tills presentationen sparas.

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

## **Skapa en video‑ram med video från en webbkälla**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) stöder online‑videor i presentationer. Du kan skapa en video‑ram som länkar till en online‑video, till exempel en YouTube‑video.

Detta exempel lägger till en YouTube‑videolänk och miniatyr på den första bilden. Ersätt video‑identifikatorn för att använda en annan video. Metoden [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) begär automatisk uppspelning. Nedladdning av miniatyren och uppspelning av videon kräver internetåtkomst. Visningsprogrammet för presentationen måste också stödja online‑uppspelning.

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

## **Spela en video i helskärmsläge**

I en träningspresentation kan du spela en mjukvarudemonstration i helskärmsläge så publiken kan se detaljerna. Anropa [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) med `true` för att aktivera detta beteende under uppspelning.

Detta exempel öppnar en presentation, hittar den första [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) på den första bilden och aktiverar helskärm. Inmatningspresentationen måste innehålla minst en bild med en befintlig video‑ram på den första bilden.

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

Helskärmsuppspelning styr hur videon visas. Oberoende styr [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) om den startas automatiskt eller vid klick, och [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) om den upprepas. För att välja startbeteende, ange uppspelningsläget till [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Exemplet bevarar de befintliga start‑ och loop‑inställningarna.

## **Spola tillbaka en video efter uppspelning**

I en träningspresentation gör det att spola tillbaka en demonstrationsvideo till början så den är redo för presentatören att spela igen. Anropa [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) med `true` för att återställa videon till början efter att uppspelningen är klar.

Detta exempel öppnar en presentation, hittar den första [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) på den första bilden och aktiverar återspolning. Det inaktiverar loopning så att uppspelningen kan avslutas och sätter uppspelning att starta vid klick. Inmatningspresentationen måste innehålla minst en bild med en befintlig video‑ram på den första bilden.

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

Att spola tillbaka återställer videon till början utan att starta den igen. Däremot gör ett anrop till [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) med `true` att uppspelningen repeteras automatiskt. Ha loopning inaktiverad när du vill att videon ska avslutas och förbli redo för uppspelning igen. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) styr oberoende automatisk eller klick‑uppstart; detta exempel använder [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) så att presentatören kontrollerar när uppspelningen startar. Ställ in uppspelningsläget efter loop‑inställningen, som i exemplet. Återspolning fungerar oberoende av [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Trimma en video‑ram**

Använd [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) och [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) för att hoppa över början eller slutet av en video under uppspelning. Båda värdena anges i millisekunder. Trimning ändrar uppspelningsinställningarna utan att modifiera den inbäddade videodatan.

**Ange trim‑inställningar**

Detta exempel bäddar in en lokal video och hoppar över de första 2,5 sekunderna samt den sista sekunden under uppspelning. Använd en video som är längre än 3,5 sekunder så att ett spelbart segment återstår.

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

**Läs trim‑inställningar**

Detta exempel skriver ut trim‑värdena för den första video‑ramen på den första bilden i millisekunder. Presentationen måste innehålla minst en bild. Om den bilden saknar video‑ram skrivs inget ut. Föregående exempel ger värdena 2500 och 1000.

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

## **Hantera video‑undertexter**

Aspose.Slides låter dig hantera stängda undertexter för video‑ramar i PowerPoint‑presentationer. Undertexter lagras i WebVTT‑format och exponeras via metoden [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

### **Lägg till undertexter i en video‑ram**

Detta exempel bäddar in en lokal video och lägger till ett WebVTT‑undertextspår med etiketten English. Undertexternas tidsstämplar ska matcha videon. Den sparade presentationen innehåller både video och dess undertexter.

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

Klassen [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) erbjuder också en overload som låter dig lägga till undertexter från en ström.

### **Extrahera undertexter från en video‑ram**

Detta exempel sparar alla undertextspår från video‑ramar på den första bilden som separata WebVTT‑filer. Sekventiella nummer håller utdatafilernas namn unika. Konsolen rapporterar antalet extraherade spår. Presentationen måste innehålla minst en bild.

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

Varje [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/)‑objekt exponerar undertextens identifierare, etikett, binära data och undertext som en UTF‑8‑sträng.

### **Ta bort undertexter från en video‑ram**

Detta exempel tar bort alla undertexter från video‑ramen på den första formens position på den första bilden och sparar resultatet. Det förutsätter att bilden och formen finns samt att formen är en video‑ram.

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

Om du bara behöver ta bort ett undertextspår, använd metoderna [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) i stället för [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

### **Sök i video‑undertexter**

[Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) returnerar hela WebVTT‑spåret, inklusive rubrik, tidlinjer och undertext. Du kan söka i cue‑erna i minnet för att hitta en talad fras och dess tidsstämpel. Till exempel kan ett engelskt spår på bild 2 innehålla följande text.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Exemplet öppnar `captioned_media.pptx` och använder [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) för att läsa spåren för varje överordnad video‑ram på alla bilder. I en ren‑text‑cue innehåller tidlinjen `-->`, och en tom rad avslutar cue‑en. När undertexten innehåller “café” i någon bokstavsstorlek skriver exemplet ut bildnumret, spårets etikett, original‑tidlinje och fullständig undertext.

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

Sökning efter “café” ger en matchning för exempelspåret. Söket exkluderar spår‑rubriken och bevarar tidsinställningen i utdata.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrahera video från en bild**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

Detta exempel extraherar inbäddade videor från varje bild till separata, numrerade binära filer. Länkade videor hoppas över eftersom de saknar inbäddad data. Konsolen skriver ut varje videos MIME‑typ och det totala antalet. Utdata använder den generiska `.bin`‑ändelsen; ändra den för att matcha den rapporterade mediatypen vid behov.

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

**Vilka uppspelningsparametrar kan ändras för en video‑ram?**

Du kan kontrollera [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (auto eller on click) och [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Dessa alternativ är tillgängliga via [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)‑objektets metoder.

**Påverkar tillägget av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas den binära datan i dokumentet, så presentationens storlek ökar i proportion till filens storlek. När du länkar till en online‑video och lägger till en miniatyr lagrar presentationen länken och förhandsbilden i stället för videodata, så storleksökningen är vanligtvis mindre.

**Kan jag ersätta videon i en befintlig video‑ram utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) inom ramen medan du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) som du kan läsa och använda, till exempel när du sparar den till disk.