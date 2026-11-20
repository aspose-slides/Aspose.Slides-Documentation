---
title: Beheer videoframes in presentaties met Node.js
linktitle: Videoframe
type: docs
weight: 10
url: /nl/nodejs-java/video-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u programmatisch video-frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Node.js via Java. Snelle praktische gids."
---
## **Introductie**

Video's kunnen helpen ideeën uit te leggen en een publiek te betrekken. Aspose.Slides for Node.js via Java stelt u in staat videoframes aan dia's toe te voegen, afspeelinstellingen aan te passen, ondertitels te beheren en ingebedde videogegevens te extraheren.

PowerPoint ondersteunt lokale video's en koppelingen naar online video's, zoals YouTube-video's.

Om videogegevens en videoframes te representeren, biedt Aspose.Slides de [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) klasse, de [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) klasse en andere relevante typen.

## **Maak een ingesloten videoframe**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten.

Dit voorbeeld voegt een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. Framecoördinaten en -afmetingen zijn in points. De stream blijft open tot het opslaan is voltooid omdat [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) het vergrendelt zolang de presentatie het gebruikt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

U kunt ook een lokaal video'spad rechtstreeks doorgeven aan [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Dit voorbeeld voegt de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven tot de presentatie is opgeslagen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Maak een videoframe met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video's in presentaties. U kunt een videoframe maken dat naar een online video linkt, zoals een YouTube-video.

Dit voorbeeld voegt een YouTube-videokoppeling en miniatuurafbeelding toe aan de eerste dia. Vervang de video-identifier om een andere video te gebruiken. De methode [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) vraagt om automatische weergave. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatieweergave moet ook online videoweergave ondersteunen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Speel een video af in volledig-schermmodus**

In een trainingspresentatie kunt u een software-demonstratie afspelen in volledig-schermmodus zodat het publiek de details kan zien. Roep [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) aan met `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, zoekt het eerste [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) op de eerste dia, en schakelt volledig-schermweergave in. De invoerpresentatie moet ten minste één dia bevatten met een bestaand videoframe op de eerste dia.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Volledig-schermweergave bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan bepaalt [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) of deze automatisch of bij klikken start, en [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) of deze herhaalt. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset.Auto of VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start- en lusinstellingen.

## **Spoel een video terug na afspelen**

In een trainingspresentatie, het terugzetten van een demonstratievideo naar het begin maakt deze klaar voor de presentator om opnieuw af te spelen. Roep [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) aan met `true` om de video na afloop van het afspelen naar het begin te retourneren.

Dit voorbeeld opent een presentatie, zoekt het eerste [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) op de eerste dia, en schakelt terugspoelen in. Het schakelt looping uit zodat het afspelen kan eindigen en stelt het afspelen in op starten bij klikken. De invoerpresentatie moet ten minste één dia bevatten met een bestaand videoframe op de eerste dia.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Terugspoelen zet de video terug naar het begin zonder deze opnieuw te starten. Daarentegen zorgt een aanroep van [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) met `true` voor automatische herhaling. Houd looping uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft om opnieuw afgespeeld te worden. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) bepaalt onafhankelijk automatisch of op-klik start; dit voorbeeld gebruikt [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen start. Stel de afspeelmodus in na de lusinstelling, zoals in het voorbeeld wordt getoond. Terugspoelen werkt onafhankelijk van [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Bijsnijden van een videoframe**

Gebruik [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) en [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) om een deel van het begin of einde van een video over te slaan tijdens het afspelen. Beide waarden zijn in milliseconden. Bijsnijden wijzigt de afspeelinstellingen zonder de ingebedde videogegevens te wijzigen.

**Bijsnijdinstellingen instellen**

Dit voorbeeld voegt een lokale video in en slaat de eerste 2,5 seconden en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconden zodat er een afspeelbaar segment overblijft.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lees bijsnijdinstellingen**

Dit voorbeeld geeft de bijsnijdwaarden van het eerste videoframe op de eerste dia weer in milliseconden. De presentatie moet ten minste één dia bevatten. Als die dia geen videoframe heeft, wordt er niets afgedrukt. Het voorgaande voorbeeld levert waarden van 2500 en 1000 op.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Beheer video-bijschriften**

Aspose.Slides stelt u in staat gesloten bijschriften voor videoframes in PowerPoint-presentaties te beheren. Bijschriften worden opgeslagen in WebVTT-formaat en zijn toegankelijk via de methode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

### **Voeg bijschriften toe aan een videoframe**

Dit voorbeeld voegt een lokale video in en voegt een WebVTT-bijschrifttrack toe met het label English. De tijdstempels van het bijschrift moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de bijschriften.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De klasse [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) biedt ook de methode [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) om bijschriften vanaf een stream toe te voegen.

### **Extraheer bijschriften uit een videoframe**

Dit voorbeeld slaat alle bijschrifttracks van videoframes op de eerste dia op als afzonderlijke WebVTT-bestanden. Sequentiële nummers houden de uitvoerbestanden onderscheidend. De console meldt het aantal geëxtraheerde tracks. De presentatie moet ten minste één dia bevatten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Elk [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) object onthult de bijschrift-identifier, het label, binaire gegevens en de bijschrifttekst als een UTF-8-string.

### **Verwijder bijschriften van een videoframe**

Dit voorbeeld verwijdert alle bijschriften van het videoframe op de eerste shape-positie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en shape bestaan en dat de shape een videoframe is.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u slechts één bijschrifttrack wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) in plaats van [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

### **Zoek video-bijschriften**

De methode [Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) retourneert de volledige WebVTT-track, inclusief de header, tijdlijnen en bijschrifttekst. U kunt de bijschrifttekst in het geheugen doorzoeken om een zin en de bijbehorende tijdstempel te vinden. Bijvoorbeeld, een Engelse track op dia 2 kan deze cue bevatten:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Dit voorbeeld opent `captioned_media.pptx` en gebruikt [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) om de tracks van elk top-level videoframe op elke dia te lezen. In een platte-tekst cue bevat de tijdslijn `-->`, en een lege regel beëindigt de cue. Voor elk bijschrift dat “café” bevat, ongeacht hoofd- of kleine letters, geeft het voorbeeld het slidennummer, track-label, originele tijdslijn en volledige bijschrift weer.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("captioned_media.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const shapes = slide.getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                continue;
            }

            const tracks = shape.getCaptionTracks();
            for (let trackIndex = 0; trackIndex < tracks.getCount(); trackIndex++) {
                const track = tracks.get_Item(trackIndex);
                const lines = track.getDataAsString().split(/\r\n|\n|\r/);
                for (let i = 0; i < lines.length; i++) {
                    const timing = lines[i];
                    if (!timing.includes("-->")) {
                        continue;
                    }
                    const start = i + 1;
                    i = start;
                    while (i < lines.length && lines[i] !== "") {
                        i++;
                    }
                    const caption = lines.slice(start, i).join("\n");
                    if (caption.toLowerCase().includes("café")) {
                        console.log(`Slide ${slide.getSlideNumber()} | ${track.getLabel()} | ${timing}`);
                        console.log(caption);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Zoeken naar “café” vindt één overeenkomst in de voorbeeld-track. De zoekopdracht slaat de track-header over en behoudt de timing-instelling en regeleinde in de uitvoer.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extraheer video van een dia**

Naast het toevoegen van video's aan dia's, stelt Aspose.Slides u in staat video's die in presentaties zijn ingebed te extraheren.

Dit voorbeeld extraheert ingebedde video's van elke dia naar afzonderlijke, genummerde binaire bestanden. Gelinkte video's worden overgeslagen omdat ze geen ingebedde gegevens hebben. De console toont het MIME-type van elke video en het totale aantal. De uitvoer gebruikt de algemene extensie `.bin`; wijzig deze indien nodig om overeen te stemmen met het gerapporteerde mediatype.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Welke video-afspeelparameters kunnen worden gewijzigd voor een videoframe?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (auto of bij klikken) en de [lusinstelling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) beheren. Deze opties zijn beschikbaar via de methoden van het [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van het PPTX?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig toeneemt met de bestandsgrootte. Wanneer u linkt naar een online video en een miniatuur toevoegt, slaat de presentatie de koppeling en de voorbeeldafbeelding op in plaats van de videogegevens, waardoor de grootte-toename meestal kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [videoinhoud](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) binnen het frame verwisselen terwijl u de geometrie van de shape behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content-type (MIME) van een ingebedde video worden bepaald?**

Ja. Een ingebedde video heeft een [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) dat u kunt uitlezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.