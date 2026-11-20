---
title: Beheer videoframes in presentaties met Java
linktitle: Videoframe
type: docs
weight: 10
url: /nl/java/video-frame/
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
- Java
- Aspose.Slides
description: "Leer hoe u programmatig video-frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument-slides met Aspose.Slides for Java. Snelle stapsgewijze handleiding."
---
## **Inleiding**

Video's kunnen helpen ideeën uit te leggen en een publiek te betrekken. Aspose.Slides voor Java stelt u in staat videoframes aan dia's toe te voegen, afspeelinstellingen aan te passen, ondertitels te beheren en ingesloten videogegevens te extraheren.

PowerPoint ondersteunt lokale video's en koppelingen naar online video's, zoals YouTube‑video's.

Om videogegevens en videoframes weer te geven, biedt Aspose.Slides de interface [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , de interface [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) en andere relevante typen.

## **Een ingesloten videoframe maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten.

Dit voorbeeld legt een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. De coördinaten en afmetingen van het frame zijn in punten. De stream blijft open tot het opslaan voltooid is, omdat [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) deze vergrendeld houdt terwijl de presentatie er gebruik van maakt.

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

U kunt ook een lokaal videopad rechtstreeks doorgeven aan [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Dit voorbeeld legt de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven tot de presentatie is opgeslagen.

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

## **Een videoframe maken met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video's in presentaties. U kunt een videoframe maken dat naar een online video linkt, zoals een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videokoppeling en miniatuurafbeelding toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De methode [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) vraagt om automatische afspelen. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatie‑viewer moet ook online video‑afspelen ondersteunen.

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

## **Een video afspelen in volledig‑schermmodus**

In een trainingspresentatie kunt u een software‑demonstratie in volledig‑schermmodus afspelen zodat het publiek de details kan zien. Roep [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) aan met `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, zoekt het eerste [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) op de eerste dia en schakelt afspelen in volledig scherm in. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Volledig‑scherm afspelen bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan regelt [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) of de video automatisch of bij klikken start, en [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) of deze herhaalt. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset.Auto of VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lussinstellingen.

## **Een video terugspoelen na afspelen**

In een trainingspresentatie maakt het terugbrengen van een demonstratievideo naar het begin de video klaar om opnieuw afgespeeld te worden. Roep [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) aan met `true` om de video na afloop van het afspelen naar het begin terug te laten gaan.

Dit voorbeeld opent een presentatie, zoekt het eerste [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) op de eerste dia en schakelt terugspoelen in. Het schakelt herhalen uit zodat het afspelen kan eindigen en stelt het afspelen in om bij klik te starten. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Terugspoelen brengt de video terug naar het begin zonder deze opnieuw te starten. Daarentegen zorgt het aanroepen van [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) met `true` voor automatische herhaling van het afspelen. Laat herhalen uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft om opnieuw afgespeeld te worden. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) regelt onafhankelijk of de video automatisch of bij klikken start; dit voorbeeld gebruikt [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) zodat de presentator beslist wanneer het afspelen begint. Stel de afspeelmodus in na de lussinstelling, zoals in het voorbeeld wordt getoond. Terugspoelen werkt onafhankelijk van [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Een videoframe bijsnijden**

Gebruik [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) en [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) om het begin‑ of einddeel van een video tijdens het afspelen over te slaan. Beide waarden worden in milliseconden opgegeven. Bijsnijden wijzigt de afspeelinstellingen zonder de ingebedde videogegevens te wijzigen.

**Instellingen voor bijsnijden**

Dit voorbeeld legt een lokale video in en slaat de eerste 2,5 seconde en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconde zodat er een afspeelbaar segment overblijft.

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

**Lees bijsnijdinstellingen**

Dit voorbeeld print de bijsnijdwaarden van het eerste videoframe op de eerste dia in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen videoframe heeft, wordt er niets afgedrukt. Het voorgaande voorbeeld levert de waarden 2500 en 1000 op.

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

## **Videobijschriften beheren**

Aspose.Slides stelt u in staat ondertitels voor videoframes in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

### **Ondertitels toevoegen aan een videoframe**

Dit voorbeeld legt een lokale video in en voegt een WebVTT‑ondertiteltrack toe met het label English. De tijdstempels van de ondertitels moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de ondertitels.

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

De interface [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

### **Ondertitels extraheren uit een videoframe**

Dit voorbeeld slaat alle ondertiteltracks van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Opeenvolgende nummers houden de uitvoerbestanden gescheiden. De console geeft het aantal geëxtraheerde tracks weer. De presentatie moet minstens één dia bevatten.

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

Elk [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) object biedt de ondertitel‑identifier, het label, binaire gegevens en de ondertiteltekst als een UTF‑8‑string.

### **Ondertitels verwijderen uit een videoframe**

Dit voorbeeld verwijdert alle ondertitels van het videoframe op de eerste vormpositie op de eerste dia en slaat het resultaat op. Er wordt aangenomen dat de dia en vorm bestaan en dat de vorm een videoframe is.

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

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) of [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) in plaats van [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

### **Videobijschriften doorzoeken**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) retourneert de volledige WebVTT‑track, inclusief header, timing‑regels en ondertiteltekst. U kunt de cues in het geheugen doorzoeken om een gesproken zin en de bijbehorende tijdstempel te vinden. Bijvoorbeeld, een Engelse track op dia 2 kan de volgende tekst bevatten.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Het voorbeeld opent `captioned_media.pptx` en gebruikt [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) om de tracks van elk videoframe op hoogste niveau op elke dia te lezen. In een platte‑tekst cue bevat de timing‑regel `-->` en een lege regel beëindigt de cue. Wanneer de ondertitel “café” bevat, ongeacht hoofd‑ of kleine letters, print het voorbeeld het dia‑nummer, track‑label, originele timing‑regel en volledige ondertitel.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;
import java.util.StringJoiner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringJoiner caption = new StringJoiner(System.lineSeparator());
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            caption.add(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Zoeken naar “café” levert één overeenkomst op voor de voorbeeldtrack. De zoekopdracht sluit de track‑header uit en behoudt de timing‑instelling in de uitvoer.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Video extraheren van een dia**

Naast het toevoegen van video's aan dia's, stelt Aspose.Slides u in staat video's die in presentaties zijn ingesloten te extraheren.

Dit voorbeeld haalt ingesloten video's van elke dia op en slaat ze op als afzonderlijke genummerde binaire bestanden. Gelinkte video's worden overgeslagen omdat ze geen ingesloten gegevens hebben. De console print het MIME‑type van elke video en het totale aantal. De uitvoer gebruikt de algemene extensie `.bin`; pas deze aan om overeen te komen met het gerapporteerde mediatype indien nodig.

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

**Welke video‑afspeelparameters kunnen worden aangepast voor een videoframe?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch of bij klikken) en de [herhaling](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) regelen. Deze opties zijn beschikbaar via de methoden van het object [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens in het document opgenomen, waardoor de presentatie‑grootte evenredig toeneemt met de bestandsgrootte. Wanneer u naar een online video linkt en een miniatuurafbeelding toevoegt, slaat de presentatie de koppeling en het voorbeeldbeeld op in plaats van de videogegevens, waardoor de toename van de grootte meestal kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [videoinhoud](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario om media in een bestaande lay-out bij te werken.

**Kan het content‑type (MIME) van een ingesloten video worden vastgesteld?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) die u kunt uitlezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.