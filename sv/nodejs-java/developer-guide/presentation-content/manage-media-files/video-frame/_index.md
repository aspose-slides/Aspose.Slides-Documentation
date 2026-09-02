---
title: Hantera videoramar i presentationer med JavaScript
linktitle: Videoram
type: docs
weight: 10
url: /sv/nodejs-java/video-frame/
keywords:
- lägga till video
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
description: "Lär dig att programatiskt lägga till och extrahera videoramar i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Node.js via Java. Snabb guide."
---
## **Introduktion**

En välplacerad video i en presentation kan göra ditt budskap mer övertygande och öka engagemangsgraden hos din publik. 

PowerPoint låter dig lägga till videor på en bild i en presentation på två sätt:

* Lägg till eller bädda in en lokal video (lagrad på din dator)
* Lägg till en online-video (från en webbkälla som YouTube).

För att låta dig lägga till videor (video‑objekt) i en presentation tillhandahåller Aspose.Slides klassen [Video](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/video/) , klassen [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/) och andra relevanta typer.

## **Skapa inbäddad videoram**

Om videofilen du vill lägga till på din bild är lagrad lokalt kan du skapa en videoram för att bädda in videon i din presentation. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Lägg till ett [Video](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/video/)-objekt och skicka videofilens sökväg för att bädda in videon i presentationen.
4. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/)-objekt för att skapa en ram för videon.
5. Spara den modifierade presentationen. 

Den här JavaScript‑koden visar hur du lägger till en lokalt lagrad video i en presentation:

```javascript
// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Laddar videon
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Hämtar den första bilden och lägger till en videoram
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Sparar presentationen till disk
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Alternativt kan du lägga till en video genom att skicka dess filsökväg direkt till metoden [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Skapa videoram med video från webbkälla**

Microsoft [PowerPoint 2013 och nyare](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) stödjer YouTube‑videor i presentationer. Om videon du vill använda finns online (t.ex. på YouTube) kan du lägga till den i din presentation via dess webblänk. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Lägg till ett [Video](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/video/)-objekt och skicka länken till videon.
4. Ställ in en miniatyr för videoramen. 
5. Spara presentationen. 

Den här JavaScript‑koden visar hur du lägger till en video från webben på en bild i en PowerPoint‑presentation:

```javascript
// Skapar ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **Trimma en videoram**

Aspose.Slides låter dig kontrollera vilken del av en video som spelas genom att sätta värdena trim‑from‑start och trim‑from‑end via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/settrimfromstart/) och [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/settrimfromend/). Båda värdena anges i millisekunder och definierar hur mycket tid som hoppas över i början respektive slutet av videon. Dessa inställningar ändrar videouppspelningsinställningarna i presentationen; de klipper inte eller modifierar på annat sätt den inbäddade video‑binärdaten.

**Ställ in triminställningar**

För att skapa en videoram och ställa in dess trim‑inställningar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Lägg till ett [Video](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/video/)-objekt i presentationen.
3. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/)-objekt på en bild.
4. Sätt värdena trim‑from‑start och trim‑from‑end via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/settrimfromstart/) och [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/settrimfromend/).
5. Spara den modifierade presentationen.

Följande kodexempel hoppar över de första 2,5 sekunderna och den sista sekunden av en inbäddad video under uppspelning:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Läs trim‑inställningar**

För att inspektera befintliga trim‑inställningar, läs in en presentation, hitta ett [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/)‑objekt bland formerna på den första bilden, och läs värdena via [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) och [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/gettrimfromend/).

Följande kodexempel hittar den första videoramen på den första bilden och rapporterar dess trim‑inställningar i millisekunder:

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Hantera videobeskrivningar**

Aspose.Slides låter dig hantera closed captions för videoramar i PowerPoint‑presentationer. Captions lagras i WebVTT‑format och exponeras via metoden [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Lägg till textning i en videoram**

För att lägga till textning i en videoram:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Lägg till en video i presentationen.
3. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/)-objekt på en bild.
4. Använd samlingen [CaptionsCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/) för att lägga till ett WebVTT‑textspår.
5. Spara den modifierade presentationen.

Följande kod visar hur du lägger till textning i en videoram:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Lägger till ett nytt textningsspår från en WebVTT-fil.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klassen [CaptionsCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/) tillhandahåller även metoden [addFromStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/#addFromStream) som låter dig lägga till textning från en ström.

**Extrahera textning från en videoram**

För att extrahera textning från en videoram:

1. Läs in presentationen som innehåller videon.
2. Hitta mål‑[VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/)‑objektet.
3. Iterera genom samlingen [CaptionsCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/).
4. Spara varje textspår till en `.vtt`‑fil.

Följande kod visar hur du extraherar textning från en videoram:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // Sparar textningsspåret till en WebVTT-fil.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Varje [Captions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captions/)‑objekt exponeras för caption‑identifieraren, etiketten, binärdata och caption‑text som en UTF‑8‑sträng.

**Ta bort textning från en videoram**

För att ta bort textning från en videoram:

1. Läs in presentationen som innehåller videon.
2. Hämta mål‑[VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/)‑objektet.
3. Ta bort textspår från samlingen [CaptionsCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/).
4. Spara den modifierade presentationen.

Följande kod visar hur du tar bort alla textningsspår från en videoram:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // typ: com.aspose.slides.VideoFrame

    // Tar bort alla textningar från videoramen.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om du bara behöver ta bort ett textningsspår, använd metoderna [remove](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/#removeAt) istället för [clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/#clear).

## **Extrahera video från bild**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) för att läsa in presentationen som innehåller videon.
2. Iterera genom alla [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/)-objekt.
3. Iterera genom alla [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/)-objekt för att hitta ett [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/).
4. Spara videon till disk.

Den här JavaScript‑koden visar hur du extraherar videon på en presentationsbild:

```javascript
// Instansierar ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Hämtar filändelsen
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Vilka videouppspelningsparametrar kan ändras för en VideoFrame?**

Du kan kontrollera [playback mode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatiskt eller vid klick) och [looping](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Dessa alternativ är tillgängliga via egenskaperna för [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/)‑objektet.

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas binärdata i dokumentet, så presentationens storlek ökar i proportion till filens storlek. När du lägger till en online‑video bäddas en länk och en miniatyr in, så ökningen blir mindre.

**Kan jag ersätta videon i en befintlig VideoFrame utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) inom ramen samtidigt som du bevarar figurens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/video/getcontenttype/) som du kan läsa och använda, till exempel när du sparar den till disk.