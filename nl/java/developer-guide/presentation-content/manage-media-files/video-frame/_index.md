---
title: Beheer video-frames in presentaties met Java
linktitle: Video-frame
type: docs
weight: 10
url: /nl/java/video-frame/
keywords:
- video toevoegen
- video aanmaken
- video insluiten
- video extraheren
- video ophalen
- video-frame
- webbron
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u programmatisch video-frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument-slides met Aspose.Slides voor Java. Snelle how-to gids."
---
## **Introductie**

Video's kunnen helpen ideeën uit te leggen en een publiek te boeien. Aspose.Slides for Java stelt u in staat videoframes aan dia's toe te voegen, afspeelinstellingen aan te passen, ondertitels te beheren en ingebedde videogedata te extraheren.

PowerPoint ondersteunt lokale videos en koppelingen naar online videos, zoals YouTube videos.

Om videogegevens en videoframes weer te geven, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) interface, de [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) interface en andere relevante typen.

## **Maak een ingebed videoframe**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten.

Dit voorbeeld embedde een lokale video op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en -afmetingen zijn in points. De stream blijft open tot het opslaan voltooid is omdat [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) deze vergrendeld houdt zolang de presentatie het gebruikt.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

U kunt ook een lokaal video‑pad rechtstreeks doorgeven aan [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Dit voorbeeld embedde de video op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven tot de presentatie is opgeslagen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Maak een videoframe met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video’s in presentaties. U kunt een videoframe maken dat linkt naar een online video, zoals een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videolink en thumbnail toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De methode [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) vraagt om automatische weergave. Het downloaden van de thumbnail en het afspelen van de video vereisen internettoegang. De presentatieweergave moet ook online video‑afspelen ondersteunen.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Afspelen van een video in volledig‑schermmodus**

In een trainingspresentatie kunt u een software‑demo in volledig‑schermmodus afspelen zodat het publiek de details kan zien. Roep [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) aan met `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, vindt de eerste [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) op de eerste dia, en schakelt volledig‑schermafspelen in. De invoerpresentatie moet minimaal één dia bevatten met een bestaand videoframe op de eerste dia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Volledig‑schermafspelen bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan regelt [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) of de video automatisch of bij een klik start, en [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) of deze herhaalt. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lusinstellingen.

## **Spoel een video terug na het afspelen**

In een trainingspresentatie maakt het terugplaatsen van een demonstratievideo naar het begin de video klaar voor de presentator om opnieuw af te spelen. Roep [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) aan met `true` om de video na het afspelen naar het begin te laten terugkeren.

Dit voorbeeld opent een presentatie, vindt de eerste [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) op de eerste dia, en schakelt terugspoelen in. Het schakelt lus uit zodat het afspelen kan eindigen en stelt het afspelen in om bij een klik te starten. De invoerpresentatie moet minimaal één dia bevatten met een bestaand videoframe op de eerste dia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Terugspoelen brengt de video naar het begin zonder deze opnieuw te starten. Daarentegen zorgt een aanroep van [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) met `true` voor automatische herhaling van de weergave. Houd lus uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft om opnieuw afgespeeld te worden. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) regelt onafhankelijk of de weergave automatisch of bij een klik start; dit voorbeeld gebruikt [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen begint. Stel de afspeelmodus in na de lusinstelling, zoals in het voorbeeld wordt getoond. Terugspoelen werkt onafhankelijk van [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Trim een videoframe**

Gebruik [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) en [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) om aan het begin of einde van een video tijdens het afspelen een deel over te slaan. Beide waarden zijn in milliseconden. Trimmen wijzigt de afspeelinstellingen zonder de ingebedde videogedata te wijzigen.

**Stel triminstellingen in**

Dit voorbeeld embedde een lokale video en slaat de eerste 2,5 seconden en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconden zodat er een afspeelbaar segment overblijft.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lees triminstellingen**

Dit voorbeeld drukt de trimwaarden van het eerste videoframe op de eerste dia af in milliseconden. De presentatie moet minimaal één dia bevatten. Als die dia geen videoframe heeft, wordt er niets afgedrukt. Het voorgaande voorbeeld levert waarden van 2500 en 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Beheer video‑ondertitels**

Aspose.Slides stelt u in staat gesloten ondertitels voor videoframes in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Voeg ondertitels toe aan een videoframe**

Dit voorbeeld embedde een lokale video en voegt een WebVTT‑ondertiteltrack met het label Engels toe. De tijdstempels van de ondertitels moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de ondertitels.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De interface [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) biedt ook een overload waarmee u ondertitels uit een stream kunt toevoegen.

**Extraheer ondertitels uit een videoframe**

Dit voorbeeld slaat alle ondertiteltracks van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Sequentiële nummers houden de uitvoerbestanden uniek. De console geeft het aantal geëxtraheerde tracks weer. De presentatie moet minimaal één dia bevatten.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Elk [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) object geeft de ondertitel‑identifier, het label, binaire gegevens en de ondertiteltekst weer als een UTF‑8‑string.

**Verwijder ondertitels uit een videoframe**

Dit voorbeeld verwijdert alle ondertitels van het videoframe op de eerste shape‑positie op de eerste dia en slaat het resultaat op. Er wordt aangenomen dat de dia en shape bestaan en dat de shape een videoframe is.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) of [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) methoden in plaats van [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

## **Extraheer video van een dia**

Naast het toevoegen van videos aan dia’s, maakt Aspose.Slides het mogelijk videos die in presentaties zijn ingebed te extraheren.

Dit voorbeeld extraheert ingebedde videos van elke dia naar afzonderlijke, genummerde binaire bestanden. Gelinkte videos worden overgeslagen omdat ze geen ingebedde gegevens hebben. De console drukt het MIME‑type van elke video en het totale aantal af. De output gebruikt de generieke extensie `.bin`; wijzig deze om overeen te stemmen met het gerapporteerde mediatype indien nodig.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Welke video‑afspeelparameters kunnen voor een videoframe aangepast worden?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (auto of bij een klik) en [herhaling](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) regelen. Deze opties zijn beschikbaar via de methoden van het [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de grootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video embedt, wordt de binaire data in het document opgenomen, waardoor de presentatiegrootte evenredig groeit met de bestandsgrootte. Wanneer u linkt naar een online video en een thumbnail toevoegt, slaat de presentatie de koppeling en voorbeeldafbeelding op in plaats van de videocontent, waardoor de grootte‑toename doorgaans kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) binnen het frame verwisselen terwijl u de vormgeometrie behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay‑out.

**Kan het contenttype (MIME) van een ingebedde video worden bepaald?**

Ja. Een ingebedde video heeft een [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) die u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.