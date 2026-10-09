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
description: "Leer hoe u programmatic videoframes kunt toevoegen en extraheren in PowerPoint- en OpenDocument‑dia’s met Aspose.Slides voor Node.js via Java. Snelle stapsgewijze handleiding."
---
## **Introductie**

Video’s kunnen helpen ideeën uit te leggen en een publiek te betrekken. Aspose.Slides voor Node.js via Java stelt u in staat videoframes aan dia’s toe te voegen, afspeelinstellingen aan te passen, bijschriften te beheren en ingesloten videogegevens te extraheren.

PowerPoint ondersteunt lokale video’s en koppelingen naar online video’s, zoals YouTube‑video’s.

Om videogegevens en videoframes te vertegenwoordigen, biedt Aspose.Slides de [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) klasse, de [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) klasse en andere relevante typen.

## **Maak een ingesloten videoframe**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten.

Dit voorbeeld voegt een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en afmetingen zijn in punten. De stream blijft open tot het opslaan voltooid is omdat [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) deze vergrendeld houdt zolang de presentatie hem gebruikt.

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

U kunt ook een lokaal videopad direct doorgeven aan [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Dit voorbeeld voegt de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven totdat de presentatie is opgeslagen.

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

## **Een videoframe maken met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video’s in presentaties. U kunt een videoframe maken dat koppelt naar een online video, zoals een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videokoppeling en miniatuur toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/)‑methode vraagt om automatisch afspelen. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatieweergave moet ook online video‑afspelen ondersteunen.

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

## **Een video afspelen in volledig scherm‑modus**

In een trainingspresentatie kunt u een software‑demo afspelen in volledig‑scherm‑modus zodat het publiek de details kan zien. Roep [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) aan met `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, zoekt het eerste [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) op de eerste dia en schakelt volledig‑scherm‑afspelen in. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Volledig‑scherm‑afspelen bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan regelt [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) of deze automatisch of bij klikken start, en [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) of deze herhaalt. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset.Auto of VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lusinstellingen.

## **Een video terugspoelen na afspelen**

In een trainingspresentatie maakt het terugspoelen van een demonstratie‑video naar het begin de video weer klaar voor de presentator om opnieuw af te spelen. Roep [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) aan met `true` om de video naar het begin te retourneren nadat het afspelen voltooid is.

Dit voorbeeld opent een presentatie, zoekt het eerste [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) op de eerste dia en schakelt terugspoelen in. Het schakelt lus uit zodat het afspelen kan eindigen en stelt afspelen in om te starten bij klikken. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Terugspoelen brengt de video terug naar het begin zonder deze opnieuw te starten. Daarentegen zorgt een oproep van [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) met `true` voor automatisch herhalen van het afspelen. Houd lus uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft om opnieuw af te spelen. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) regelt onafhankelijk automatisch of bij klikken starten; dit voorbeeld gebruikt [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen start. Stel de afspeelmodus in na de lusinstelling, zoals in het voorbeeld wordt getoond. Terugspoelen werkt onafhankelijk van [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Trimmen van een videoframe**

Gebruik [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) en [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) om een deel van het begin of het einde van een video over te slaan tijdens het afspelen. Beide waarden zijn in milliseconden. Trimmen wijzigt de afspeelinstellingen zonder de ingesloten videogegevens aan te passen.

**Triminstellingen instellen**

Dit voorbeeld voegt een lokale video in en slaat tijdens het afspelen de eerste 2,5 seconde en de laatste seconde over. Gebruik een video langer dan 3,5 seconde zodat er een afspeelbaar segment overblijft.

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

**Triminstellingen lezen**

Dit voorbeeld drukt de trimwaarden van het eerste videoframe op de eerste dia af in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen videoframe heeft, wordt er niets afgedrukt. Het voorafgaande voorbeeld levert waarden van 2500 en 1000 op.

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

## **Videobijschriften beheren**

Aspose.Slides stelt u in staat gesloten bijschriften voor videoframes in PowerPoint‑presentaties te beheren. Bijschriften worden opgeslagen in het WebVTT‑formaat en worden toegankelijk gemaakt via de [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks)‑methode.

**Bijschriften toevoegen aan een videoframe**

Dit voorbeeld voegt een lokale video in en voegt een WebVTT‑bijschrifttrack met de label 'English' toe. De tijdstempels van het bijschrift moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de bijschriften.

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

De [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) klasse biedt bovendien de [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream)‑methode om bijschriften vanuit een stream toe te voegen.

**Bijschriften extraheren uit een videoframe**

Dit voorbeeld slaat alle bijschrifttracks van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Volgorde‑nummers houden de uitvoerbestanden onderscheidend. De console meldt het aantal geëxtraheerde tracks. De presentatie moet minstens één dia bevatten.

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

Elk [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/)‑object maakt de bijschrift‑identifier, het label, binair gegevens en de bijschrifttekst als UTF‑8‑string beschikbaar.

**Bijschriften verwijderen uit een videoframe**

Dit voorbeeld verwijdert alle bijschriften van het videoframe op de eerste vormpositie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een videoframe is.

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

Als u slechts één bijschrifttrack wilt verwijderen, gebruik dan de [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove)‑ of [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt)‑methoden in plaats van [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

## **Video extraheren van een dia**

Naast het toevoegen van video’s aan dia’s, maakt Aspose.Slides het mogelijk video’s die in presentaties zijn ingesloten te extraheren.

Dit voorbeeld extrahert ingesloten video’s van elke dia naar afzonderlijke, genummerde binaire bestanden. Gekoppelde video’s worden overgeslagen omdat ze geen ingesloten gegevens hebben. De console drukt het MIME‑type van elke video en het totale aantal af. De uitvoer gebruikt de algemene extensie `.bin`; wijzig deze indien nodig om overeen te komen met het gerapporteerde mediatype.

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

**Welke video‑afspeelparameters kunnen worden gewijzigd voor een videoframe?**

U kunt de [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (auto of bij klikken) en het [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) regelen. Deze opties zijn beschikbaar via de methoden van het [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)‑object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens in het document opgenomen, waardoor de grootte van de presentatie evenredig toeneemt met de bestandsgrootte. Wanneer u naar een online video linkt en een miniatuur toevoegt, slaat de presentatie de koppeling en de voorbeeldafbeelding op in plaats van de videogegevens, waardoor de grootte‑toename doorgaans kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) dat u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.