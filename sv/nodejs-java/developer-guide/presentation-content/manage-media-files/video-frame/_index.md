---
title: Hantera videoramar i presentationer med Node.js
linktitle: Videoram
type: docs
weight: 10
url: /sv/nodejs-java/video-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig att på ett programatiskt sätt lägga till och extrahera videoramar i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Node.js via Java. Snabb guide."
---
## **Introduktion**

Videor kan hjälpa till att förklara idéer och engagera en publik. Aspose.Slides for Node.js via Java låter dig lägga till videoramar i bilder, justera uppspelningsinställningar, hantera undertexter och extrahera inbäddade videodata.

PowerPoint stödjer lokala videor och länkar till online‑videor, såsom YouTube‑videor.

För att representera videodata och videoramar tillhandahåller Aspose.Slides klassen [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) , klassen [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) , och andra relevanta typer.

## **Skapa en inbäddad videoram**

Om videofilen du vill lägga till i bilden är lagrad lokalt kan du skapa en videoram för att bädda in videon i din presentation.

Detta exempel bäddar in en lokal video på den första bilden i en befintlig presentation och sparar resultatet. Ramens koordinater och dimensioner är i punkter. Strömmen hålls öppen tills sparandet är klart eftersom [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) låser den medan presentationen använder den.

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

Du kan också skicka en lokal videoväg direkt till [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Detta exempel bäddar in videon på den första bilden i en ny presentation. Videon måste förbli åtkomlig tills presentationen sparas.

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

## **Skapa en videoram med video från en webbkälla**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) stöder online‑videor i presentationer. Du kan skapa en videoram som länkar till en online‑video, såsom en YouTube‑video.

Detta exempel lägger till en YouTube‑videolänk och miniatyr på den första bilden. Ersätt videointifikatorn för att använda en annan video. Metoden [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) begär automatisk uppspelning. Nedladdning av miniatyren och uppspelning av videon kräver internetåtkomst. Presentationsvisaren måste också stödja uppspelning av online‑videor.

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

## **Spela upp en video i fullskärmsläge**

I en utbildningspresentation kan du spela upp en mjukvarudemonstration i fullskärmsläge så att publiken kan se detaljerna. Anropa [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) med `true` för att aktivera detta beteende under uppspelning.

Detta exempel öppnar en presentation, hittar den första [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) på den första bilden och aktiverar fullskärmsuppspelning. Indatapresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

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

Fullskärmsuppspelning styr hur videon visas. Oberoende styr [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) om den startar automatiskt eller vid klick, och [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) styr om den upprepas. För att välja startbeteende, sätt uppspelningsläget till [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). Exemplet behåller de befintliga start‑ och loop‑inställningarna.

## **Spola tillbaka en video efter uppspelning**

I en utbildningspresentation gör en återgång av demonstrationsvideon till början den redo för presentatören att spela igen. Anropa [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) med `true` för att återföra videon till början efter att uppspelning avslutats.

Detta exempel öppnar en presentation, hittar den första [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) på den första bilden och aktiverar spolning tillbaka. Det inaktiverar loopning så att uppspelning kan avslutas och sätter uppspelning att starta vid klick. Indatapresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

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

Spolning tillbaka återför videon till början utan att starta den igen. I kontrast återupptar ett anrop av [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) med `true` uppspelning automatiskt. Håll loopning inaktiverad när du vill att videon ska avslutas och vara redo att spelas igen. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) styr oberoende automatisk eller klick‑start; detta exempel använder [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) så presentatören kontrollerar när uppspelning startar. Ställ in uppspelningsläget efter loop‑inställningen, som visas i exemplet. Spolning tillbaka fungerar oberoende av [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Trimma en videoram**

Använd [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) och [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) för att hoppa över en del av början eller slutet av en video under uppspelning. Båda värdena är i millisekunder. Trimning ändrar uppspelningsinställningarna utan att ändra den inbäddade videodatan.

**Ange triminställningar**

Detta exempel bäddar in en lokal video och hoppar över de första 2,5 sekunderna och den sista sekunden under uppspelning. Använd en video som är längre än 3,5 sekunder så att ett spelbart segment återstår.

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

**Läs triminställningar**

Detta exempel skriver ut trimvärdena för den första videoramen på den första bilden i millisekunder. Presentationen måste innehålla minst en bild. Om den bilden saknar videoram skrivs inget ut. Det föregående exemplet ger värdena 2500 och 1000.

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

## **Hantera videokaptions**

Aspose.Slides låter dig hantera stängda undertexter för videoramar i PowerPoint-presentationer. Undertexterna lagras i WebVTT-format och exponeras via metoden [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Lägg till undertexter till en videoram**

Detta exempel bäddar in en lokal video och lägger till ett WebVTT‑undertextspår märkt English. Undertextens tidsstämplar bör matcha videon. Den sparade presentationen innehåller både videon och dess undertexter.

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

Klassen [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) erbjuder också metoden [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) för att lägga till undertexter från en ström.

**Extrahera undertexter från en videoram**

Detta exempel sparar alla undertextspår från videoramar på den första bilden som separata WebVTT‑filer. Sekventiella nummer håller utdatafilerna distinkta. Konsolen rapporterar antalet extraherade spår. Presentationen måste innehålla minst en bild.

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

Varje [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/)‑objekt visar undertextens identifierare, etikett, binära data och undertexten som en UTF‑8‑sträng.

**Ta bort undertexter från en videoram**

Detta exempel tar bort alla undertexter från videoramen på den första formens position på den första bilden och sparar resultatet. Det förutsätter att bilden och formen finns och att formen är en videoram.

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

Om du behöver ta bort endast ett undertextspår, använd metoderna [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) istället för [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

## **Extrahera video från en bild**

Förutom att lägga till videor i bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

Detta exempel extraherar inbäddade videor från varje bild till separata, numrerade binära filer. Länkade videor hoppas över eftersom de saknar inbäddad data. Konsolen skriver ut varje videos MIME‑typ och det totala antalet. Utdata använder den generiska filändelsen `.bin`; ändra den för att matcha den rapporterade mediatypen vid behov.

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

**Vilka videouppspelningsparametrar kan ändras för en videoram?**

Du kan styra [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (auto eller vid klick) och [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Dessa alternativ är tillgängliga via metoderna på objektet [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas den binära datan i dokumentet, så presentationens storlek ökar i proportion till filens storlek. När du länkar till en online‑video och lägger till en miniatyr sparar presentationen länken och förhandsbilden i stället för videodata, så storleksökningen blir vanligtvis mindre.

**Kan jag ersätta videon i en befintlig videoram utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) inom ramen samtidigt som du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) som du kan läsa och använda, till exempel när du sparar den till disk.