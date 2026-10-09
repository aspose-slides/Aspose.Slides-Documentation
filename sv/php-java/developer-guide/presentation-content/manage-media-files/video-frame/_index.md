---
title: Hantera videoram i presentationer med PHP
linktitle: Videoram
type: docs
weight: 10
url: /sv/php-java/video-frame/
keywords:
- lägg till video
- skapa video
- bädda in video
- extrahera video
- hämta video
- videoram
- webbkälla
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig att programatiskt lägga till och extrahera videoram i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java. Snabb handledning."
---
## **Introduktion**

Videor kan hjälpa till att förklara idéer och engagera en publik. Aspose.Slides for PHP via Java låter dig lägga till videoram i bilder, justera uppspelningsinställningar, hantera undertexter och extrahera inbäddade videodata.

PowerPoint stöder lokala videor och länkar till online‑videor, såsom YouTube‑videor.

För att representera videodata och videoram tillhandahåller Aspose.Slides klassen [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) klassen [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) och andra relevanta typer.

## **Skapa en inbäddad videoram**

Om videofilen du vill lägga till på din bild lagras lokalt kan du skapa en videoram för att bädda in videon i din presentation.

Detta exempel bäddar in en lokal video på den första bilden i en befintlig presentation och sparar resultatet. Ramens koordinater och dimensioner är i punkter. Strömmen förblir öppen tills sparandet slutförs eftersom [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) låser den medan presentationen använder den.

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

Du kan också skicka en lokal videostig direkt till [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Detta exempel bäddar in videon på den första bilden i en ny presentation. Videon måste förbli åtkomlig tills presentationen sparas.

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

## **Skapa en videoram med video från en webbkälla**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) stöder online‑videor i presentationer. Du kan skapa en videoram som länkar till en online‑video, såsom en YouTube‑video.

Detta exempel lägger till en YouTube‑videolänk och miniatyrbild på den första bilden. Ersätt video‑identifieraren för att använda en annan video. Metoden [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) begär automatisk uppspelning. Nedladdning av miniatyrbilden och uppspelning av videon kräver internetåtkomst. Presentationsvisaren måste också stödja online‑videouppspelning.

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

## **Spela upp en video i helskärmsläge**

I en utbildningspresentation kan du spela upp en mjukvarudemonstration i helskärmsläge så att publiken kan se detaljerna. Anropa [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) med `true` för att aktivera detta beteende under uppspelning.

Detta exempel öppnar en presentation, hittar den första [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) på den första bilden och aktiverar helskärmsuppspelning. Inmatningspresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

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

Helskärmsuppspelning styr hur videon visas. Självständigt styr [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) om den startar automatiskt eller på klick, och [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) styr om den upprepas. För att välja startbeteende, ange uppspelningsläget till [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Exemplet bevarar de befintliga start- och loop‑inställningarna.

## **Spola tillbaka en video efter uppspelning**

I en utbildningspresentation gör att återföra en demonstrationsvideo till början den redo för presentatören att spela igen. Anropa [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) med `true` för att återföra videon till början efter att uppspelningen avslutats.

Detta exempel öppnar en presentation, hittar den första [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) på den första bilden och aktiverar spolning tillbaka. Det inaktiverar looping så att uppspelningen kan slutföras och anger att uppspelning ska starta på klick. Inmatningspresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

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

Spolning tillbaka återför videon till dess början utan att starta den igen. I motsats till detta upprepar ett anrop av [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) med `true` uppspelning automatiskt. Håll looping inaktiverat när du vill att videon ska slutföras och vara redo att spelas igen. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) styr oberoende automatisk eller klick‑start; detta exempel använder [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) så att presentatören styr när uppspelning startar. Ställ in uppspelningsläget efter loop‑inställningen, som visas i exemplet. Spolning tillbaka fungerar oberoende av [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Trimma en videoram**

Använd [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) och [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) för att hoppa över en del av början eller slutet av en video under uppspelning. Båda värdena är i millisekunder. Trimning ändrar uppspelningsinställningarna utan att modifiera den inbäddade videodatan.

**Ange triminställningar**

Detta exempel bäddar in en lokal video och hoppar över de första 2,5 sekunderna och den sista sekunden under uppspelning. Använd en video som är längre än 3,5 sekunder så att ett spelbart segment återstår.

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

**Läs triminställningar**

Detta exempel skriver ut trimvärdena för den första videoramen på den första bilden i millisekunder. Presentationen måste innehålla minst en bild. Om den bilden inte har någon videoram skrivs inget ut. Det föregående exemplet ger värdena 2500 och 1000.

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

## **Hantera video-undertexter**

Aspose.Slides låter dig hantera stängda undertexter för videoram i PowerPoint‑presentationer. Undertexterna lagras i WebVTT‑format och exponeras via metoden [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Lägg till undertexter till en videoram**

Detta exempel bäddar in en lokal video och lägger till ett WebVTT‑undertextspår märkt English. Undertextens tidsstämplar bör matcha videon. Den sparade presentationen innehåller både videon och dess undertexter.

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

Klassen [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) erbjuder även en överlagring som låter dig lägga till undertexter från en ström.

**Extrahera undertexter från en videoram**

Detta exempel sparar alla undertextspår från videoram på den första bilden som separata WebVTT‑filer. Sekventiella nummer håller utdata‑filerna tydliga. Konsolen rapporterar antalet extraherade spår. Presentationen måste innehålla minst en bild.

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

Varje [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/)‑objekt exponerar undertextens identifierare, etikett, binärdata och undertextens text som en UTF‑8‑sträng.

**Ta bort undertexter från en videoram**

Detta exempel tar bort alla undertexter från videoramen på den första formens position på den första bilden och sparar resultatet. Det förutsätter att bilden och formen finns samt att formen är en videoram.

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

Om du bara behöver ta bort ett undertextspår, använd metoderna [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) istället för [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Extrahera video från en bild**

Förutom att lägga till videor i bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

Detta exempel extraherar inbäddade videor från varje bild till separata, numrerade binära filer. Länkade videor hoppas över eftersom de saknar inbäddad data. Konsolen skriver ut varje videos MIME‑typ och totala antal. Utdata använder den generiska filändelsen `.bin`; ändra den för att matcha den rapporterade mediatypen vid behov.

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

**Vilka videouppspelningsparametrar kan ändras för en videoram?**

Du kan styra [uppspelningsläget](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (auto eller på klick) och [loopning](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Dessa alternativ är tillgängliga via [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)‑objektets metoder.

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas den binära datan i dokumentet, så presentationens storlek ökar i proportion till filstorleken. När du länkar till en online‑video och lägger till en miniatyrbild lagrar presentationen länken och förhandsvisningsbilden istället för video‑datan, vilket vanligtvis ger en mindre storleksökning.

**Kan jag ersätta videon i en befintlig videoram utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) inom ramen samtidigt som du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan mediatypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [innehållstyp](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) som du kan läsa och använda, till exempel när du sparar den till disk.