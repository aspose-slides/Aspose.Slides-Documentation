---
title: Video‑frames beheren in presentaties op Android
linktitle: Video‑frame
type: docs
weight: 10
url: /nl/androidjava/video-frame/
keywords:
- video toevoegen
- video aanmaken
- video insluiten
- video extraheren
- video ophalen
- video‑frame
- webbron
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u programmatic video‑frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument‑dia's met Aspose.Slides voor Android via Java. Snelle stapsgewijze gids."
---
## **Inleiding**

Video's kunnen helpen ideeën uit te leggen en een publiek te boeien. Aspose.Slides voor Android via Java stelt u in staat video‑frames toe te voegen aan dia's, afspeelinstellingen aan te passen, bijschriften te beheren en ingesloten video‑gegevens te extraheren.

PowerPoint ondersteunt lokale video’s en koppelingen naar online video’s, zoals YouTube‑video’s.

Om video‑gegevens en video‑frames weer te geven, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) interface, de [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) interface en andere relevante types.

## **Een ingebed video‑frame maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een video‑frame maken om de video in uw presentatie in te sluiten.

Dit voorbeeld integreert een lokale video op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en afmetingen zijn in punten. De stream blijft open tot het opslaan voltooid is omdat [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) deze vergrendeld houdt terwijl de presentatie hem gebruikt.

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

U kunt ook een lokaal video‑pad rechtstreeks doorgeven aan [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Dit voorbeeld integreert de video op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven totdat de presentatie is opgeslagen.

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

## **Video‑frame maken met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video’s in presentaties. U kunt een video‑frame maken dat naar een online video koppelt, zoals een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videokoppeling en miniatuur toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De methode [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) vraagt om automatische weergave. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatie‑viewer moet ook online video‑afspelen ondersteunen.

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

## **Een video afspelen in volledig scherm-modus**

In een trainingspresentatie kunt u een software‑demonstratie in volledig scherm-modus afspelen zodat het publiek de details kan zien. Roep [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) aan met `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, vindt het eerste [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) op de eerste dia en schakelt volledig‑scherm‑afspelen in. De invoerpresentatie moet minstens één dia bevatten met een bestaand video‑frame op de eerste dia.

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

Volledig‑scherm‑afspelen bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan bepaalt [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) of deze automatisch of bij klikken start, en [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) of deze wordt herhaald. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset.Auto of VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en loop‑instellingen.

## **Een video terugspoelen na afspelen**

In een trainingspresentatie maakt het terugzetten van een demonstratie‑video naar het begin deze opnieuw klaar voor de presentator. Roep [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) aan met `true` om de video na afloop van het afspelen naar het begin te laten terugkeren.

Dit voorbeeld opent een presentatie, vindt het eerste [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) op de eerste dia en schakelt terugspoelen in. Het schakelt looping uit zodat het afspelen kan eindigen en stelt de afspeelmodus in op starten bij klikken. De invoerpresentatie moet minstens één dia bevatten met een bestaand video‑frame op de eerste dia.

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

Terugspoelen zet de video terug naar het begin zonder deze opnieuw te starten. Daarentegen zorgt het aanroepen van [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) met `true` voor automatische herhaling van het afspelen. Houd looping uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft om opnieuw afgespeeld te worden. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) bestuurt onafhankelijk automatisch of bij klikken starten; dit voorbeeld gebruikt [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen start. Stel de afspeelmodus in na de loop‑instelling, zoals in het voorbeeld getoond. Terugspoelen werkt onafhankelijk van [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Een video‑frame trimmen**

Gebruik [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) en [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) om het begin of het einde van een video tijdens het afspelen over te slaan. Beide waarden zijn in milliseconden. Trimmen wijzigt de afspeelinstellingen zonder de ingesloten video‑gegevens te wijzigen.

**Trim‑instellingen instellen**

Dit voorbeeld integreert een lokale video en slaat de eerste 2,5 seconde en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconde zodat er een afspeelbaar segment overblijft.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Trim‑instellingen lezen**

Dit voorbeeld drukt de trim‑waarden van het eerste video‑frame op de eerste dia af in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen video‑frame heeft, wordt er niets afgedrukt. Het voorgaande voorbeeld levert waarden van 2500 en 1000 op.

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

## **Video‑bijschriften beheren**

Aspose.Slides stelt u in staat gesloten bijschriften voor video‑frames in PowerPoint‑presentaties te beheren. Bijschriften worden opgeslagen in WebVTT‑formaat en toegankelijk gemaakt via de methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Bijschriften aan een video‑frame toevoegen**

Dit voorbeeld integreert een lokale video en voegt een WebVTT‑bijschrifttrack met het label English toe. De tijdstempels van het bijschrift moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de bijschriften.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De interface [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) biedt ook een overload waarmee u bijschriften vanuit een stream kunt toevoegen.

**Bijschriften uit een video‑frame extraheren**

Dit voorbeeld slaat alle bijschrift‑tracks van video‑frames op de eerste dia op als afzonderlijke WebVTT‑bestanden. Sequentiële nummers houden de uitvoerbestanden onderscheidend. De console meldt het aantal geëxtraheerde tracks. De presentatie moet minstens één dia bevatten.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Elk [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) object geeft de bijschrift‑identifier, label, binaire gegevens en de bijschrifttekst als een UTF‑8‑string weer.

**Bijschriften van een video‑frame verwijderen**

Dit voorbeeld verwijdert alle bijschriften van het video‑frame op de eerste vormpositie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een video‑frame is.

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

Als u slechts één bijschrifttrack wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) of [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) in plaats van [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--).

## **Video uit een dia extraheren**

Naast het toevoegen van video’s aan dia’s, stelt Aspose.Slides u in staat video’s die in presentaties zijn ingesloten te extraheren.

Dit voorbeeld extrahiert ingesloten video’s van elke dia naar afzonderlijke genummerde binaire bestanden. Gekoppelde video’s worden overgeslagen omdat ze geen ingesloten gegevens hebben. De console drukt het MIME‑type van elke video en het totale aantal af. De output gebruikt de generieke extensie `.bin`; pas deze aan om overeen te komen met het gemelde mediatype indien nodig.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

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
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
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

**Welke afspeelparameters kunnen voor een video‑frame gewijzigd worden?**

U kunt de [playback‑modus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (auto of bij klikken) en de [loop‑instelling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) regelen. Deze opties zijn beschikbaar via de methoden van het object [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).

**Heeft het toevoegen van een video invloed op de grootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte proportioneel toeneemt met de bestandsgrootte. Wanneer u naar een online video linkt en een miniatuur toevoegt, slaat de presentatie de koppeling en preview‑afbeelding op in plaats van de video‑gegevens, waardoor de grootte‑toename meestal kleiner is.

**Kan ik de video in een bestaand video‑frame vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video‑inhoud](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingesloten video bepaald worden?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) dat u kunt uitlezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.