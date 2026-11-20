---
title: Beheer videoframes in presentaties op Android
linktitle: Videoframe
type: docs
weight: 10
url: /nl/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Leer hoe u programmaal video‑frames kunt toevoegen en extraheren in PowerPoint‑ en OpenDocument‑dia’s met Aspose.Slides voor Android via Java. Snelle stap‑voor‑stap‑gids."
---
## **Inleiding**

Video's kunnen helpen om ideeën uit te leggen en een publiek te betrekken. Aspose.Slides for Android via Java stelt u in staat videoframes aan dia's toe te voegen, afspeelinstellingen aan te passen, bijschriften te beheren en ingebedde videogegevens te extraheren.

PowerPoint ondersteunt lokale video’s en koppelingen naar online video’s, zoals YouTube‑video’s.

Om video‑gegevens en videoframes weer te geven, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) interface, de [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) interface, en andere relevante types.

## **Maak een ingebedde videoframe**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten.

Dit voorbeeld voegt een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en afmetingen zijn in punten. De stream blijft open tot het opslaan voltooid is omdat [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) deze vergrendeld houdt terwijl de presentatie deze gebruikt.

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

U kunt ook een lokaal video‑pad rechtstreeks doorgeven aan [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Dit voorbeeld voegt de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven tot de presentatie is opgeslagen.

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

## **Maak een videoframe met video vanaf een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video’s in presentaties. U kunt een videoframe maken dat koppelt aan een online video, zoals een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videokoppeling en miniatuur toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De methode [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) vraagt om automatische weergave. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatie‑viewer moet ook online videoweergave ondersteunen.

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

## **Speel een video af in volledig‑schermmodus**

In een trainingspresentatie kunt u een software‑demo afspelen in volledig‑schermmodus zodat het publiek de details kan zien. Roep [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) aan met `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, vindt het eerste [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) op de eerste dia, en schakelt volledig‑schermweergave in. De invoer‑presentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Volledig‑schermweergave bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan regelt [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) of deze automatisch of bij klik start, en [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) of deze herhaalt. Om het startgedrag te kiezen, stel de afspeelmodus in op [VideoPlayModePreset.Auto of VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lusinstellingen.

## **Spoel een video terug na het afspelen**

In een trainingspresentatie maakt het terugzetten van een demonstratievideo naar het begin deze klaar voor de presentator om opnieuw af te spelen. Roep [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) aan met `true` om de video na afloop van het afspelen naar het begin terug te keren.

Dit voorbeeld opent een presentatie, vindt het eerste [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) op de eerste dia, en schakelt terugspoelen in. Het schakelt lus uit zodat het afspelen kan eindigen en stelt afspelen in om bij klik te starten. De invoer‑presentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Terugspoelen brengt de video naar het begin zonder deze opnieuw te starten. In tegenstelling tot het aanroepen van [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) met `true`, die het afspelen automatisch herhaalt. Houd lus uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft om opnieuw afgespeeld te worden. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) regelt onafhankelijk automatisch of bij‑klik opstarten; dit voorbeeld gebruikt [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen start. Stel de afspeelmodus in na de lusinstelling, zoals in het voorbeeld wordt getoond. Terugspoelen werkt onafhankelijk van [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Trim een videoframe**

Gebruik [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) en [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) om een deel van het begin of einde van een video over te slaan tijdens het afspelen. Beide waarden zijn in milliseconden. Bijsnijden wijzigt de afspeelinstellingen zonder de ingebedde videogegevens te wijzigen.

**Triminstellingen instellen**

Dit voorbeeld voegt een lokale video in en slaat de eerste 2,5 seconde en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconde zodat er een afspeelbaar segment overblijft.

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

**Triminstellingen lezen**

Dit voorbeeld drukt de trimwaarden van het eerste videoframe op de eerste dia af in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen videoframe heeft, wordt er niets afgedrukt. Het voorgaande voorbeeld levert waarden van 2500 en 1000 op.

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

## **Beheer video‑bijschriften**

Aspose.Slides stelt u in staat gesloten bijschriften voor videoframes in PowerPoint‑presentaties te beheren. Bijschriften worden opgeslagen in WebVTT‑formaat en worden toegankelijk gemaakt via de methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

### **Bijschriften toevoegen aan een videoframe**

Dit voorbeeld voegt een lokale video in en voegt een WebVTT‑bijschrifttrack met het label English toe. De tijdstempels van het bijschrift moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de bijschriften.

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

De [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) interface biedt ook een overload waarmee u bijschriften vanuit een stream kunt toevoegen.

### **Bijschriften extraheren uit een videoframe**

Dit voorbeeld slaat alle bijschrift‑tracks van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Opeenvolgende nummers houden de uitvoerbestanden gescheiden. De console geeft het aantal geëxtraheerde tracks weer. De presentatie moet minstens één dia bevatten.

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

Elk [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) object onthult de bijschrift‑identifier, label, binaire gegevens en de bijschrift‑tekst als een UTF‑8‑string.

### **Bijschriften verwijderen uit een videoframe**

Dit voorbeeld verwijdert alle bijschriften van het videoframe op de eerste vormpositie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een videoframe is.

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

Als u slechts één bijschrifttrack wilt verwijderen, gebruik dan de [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) of [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) methoden in plaats van [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) .

### **Zoeken in video‑bijschriften**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) retourneert de volledige WebVTT‑track, inclusief header, timing‑regels en bijschrifttekst. U kunt de cues in het geheugen doorzoeken om een gesproken zin en bijbehorend tijdstempel te vinden. Bijvoorbeeld, een Engelse track op dia 2 kan de volgende tekst bevatten.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Het voorbeeld opent `captioned_media.pptx` en gebruikt [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) om de tracks van elk videoframe van het bovenste niveau op elke dia te lezen. In een platte‑tekst cue bevat de timing‑regel `-->`, en een lege regel beëindigt de cue. Wanneer het bijschrift “café” bevat in welke hoofd‑ of kleine‑letter dan ook, drukt het voorbeeld het dia‑nummer, track‑label, originele timing‑regel en volledige bijschrift af.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;

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
                        StringBuilder caption = new StringBuilder();
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            if (caption.length() > 0) {
                                caption.append('\n');
                            }
                            caption.append(line);
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

Zoeken naar “café” levert één overeenstemming op voor de voorbeeldtrack. De zoekopdracht sluit de track‑header uit en behoudt de timing‑instelling in de uitvoer.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Video extraheren van een dia**

Naast het toevoegen van video’s aan dia's, stelt Aspose.Slides u in staat video’s die in presentaties zijn ingebed te extraheren.

Dit voorbeeld extrahert ingebedde video’s van elke dia naar afzonderlijke, genummerde binaire bestanden. Gelinkte video’s worden overgeslagen omdat ze geen ingebedde gegevens hebben. De console drukt het MIME‑type van elke video en het totale aantal af. De output gebruikt de generieke extensie `.bin`; wijzig deze om overeen te komen met het gerapporteerde mediatype indien nodig.

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

## **Veelgestelde vragen**

**Welke video‑afspeelparameters kunnen worden aangepast voor een videoframe?**

U kunt de [playback mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (auto of bij klik) en [looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) regelen. Deze opties zijn beschikbaar via de methoden van het [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de grootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video inbedt, wordt de binaire data opgenomen in het document, waardoor de presentatiegrootte evenredig toeneemt met de bestandsgrootte. Wanneer u naar een online video linkt en een miniatuur toevoegt, slaat de presentatie de koppeling en voorbeeldafbeelding op in plaats van de video‑data, waardoor de grootte‑toename meestal kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) binnen het frame vervangen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het inhoudstype (MIME) van een ingebedde video worden bepaald?**

Ja. Een ingebedde video heeft een [content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) die u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.