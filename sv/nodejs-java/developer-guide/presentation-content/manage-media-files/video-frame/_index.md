---
title: Hantera videoram i presentationer med JavaScript
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
description: "Lär dig att programatiskt lägga till och extrahera videoram i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Node.js via Java. Snabb guide."
---
## **Introduktion**

En väl placerad video i en presentation kan göra ditt budskap mer övertygande och öka engagemangsnivån hos din publik. 

PowerPoint låter dig lägga till videor på en bild i en presentation på två sätt:

* Lägg till eller bädda in en lokal video (lagrad på din dator)
* Lägg till en online-video (från en webbkälla såsom YouTube).

För att du ska kunna lägga till videor (videoobjekt) i en presentation tillhandahåller Aspose.Slides klassen [Video](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/video/), klassen [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/) och andra relevanta typer.

## **Skapa inbäddad videoram**

Om videofilen du vill lägga till på din bild är lagrad lokalt kan du skapa ett videoram för att bädda in videon i din presentation. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)klass.
1. Hämta en slides referens via dess index. 
1. Lägg till ett [Video](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/video/)‑objekt och ange videofilens sökväg för att bädda in videon i presentationen.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/)‑objekt för att skapa ett videoram.
1. Spara den ändrade presentationen. 

Denna JavaScript‑kod visar hur du lägger till en lokalt lagrad video i en presentation:

```javascript
// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Laddar videon
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Hämtar den första bilden och lägger till ett videoram
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

Microsoft [PowerPoint 2013 och nyare](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) stöder YouTube‑videor i presentationer. Om videon du vill använda är tillgänglig online (t.ex. på YouTube) kan du lägga till den i din presentation via dess webblänk. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)klass
1. Hämta en slides referens via dess index. 
1. Lägg till ett [Video](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/video/)‑objekt och ange länken till videon.
1. Ange en miniatyr för videoramen. 
1. Spara presentationen. 

Denna JavaScript‑kod visar hur du lägger till en video från webben till en bild i en PowerPoint‑presentation:

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

## **Hantera video undertexter**

Aspose.Slides låter dig hantera stängda undertexter för videoram i PowerPoint‑presentationer. Undertexterna lagras i WebVTT‑format och exponeras via metoden [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Lägg till undertexter i ett videoram**

För att lägga till undertexter i ett videoram:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)klass.
1. Lägg till en video i presentationen.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/)‑objekt på en bild.
1. Använd samlingen [CaptionsCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/) för att lägga till ett WebVTT‑undertextspår.
1. Spara den ändrade presentationen.

Följande kod visar hur du lägger till undertexter i ett videoram:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Lägger till ett nytt undertextspår från en WebVTT-fil.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klassen [CaptionsCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/) erbjuder även metoden [addFromStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/#addFromStream) som låter dig lägga till undertexter från en ström.

**Extrahera undertexter från ett videoram**

För att extrahera undertexter från ett videoram:

1. Läs in presentationen som innehåller videon.
1. Hitta mål‑objektet [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/).
1. Iterera genom samlingen [CaptionsCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/).
1. Spara varje undertextspår till en `.vtt`‑fil.

Följande kod visar hur du extraherar undertexter från ett videoram:

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
                // Sparar undertextspåret till en WebVTT-fil.
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

Varje [Captions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captions/)‑objekt exponerar undertextens identifierare, etikett, binär data och undertexten som en UTF‑8‑sträng.

**Ta bort undertexter från ett videoram**

För att ta bort undertexter från ett videoram:

1. Läs in presentationen som innehåller videon.
1. Hämta mål‑objektet [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/).
1. Ta bort undertextspår från samlingen [CaptionsCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/).
1. Spara den ändrade presentationen.

Följande kod visar hur du tar bort alla undertexter från ett videoram:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // typ: com.aspose.slides.VideoFrame

    // Tar bort alla undertexter från videoramen.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om du bara behöver ta bort ett undertextspår, använd metoderna [remove](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/#removeAt) istället för [clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/captionscollection/#clear).

## **Extrahera video från bild**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) för att läsa in presentationen som innehåller videon.
2. Iterera genom alla [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/)‑objekt.
3. Iterera genom alla [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/)‑objekt för att hitta ett [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/).
4. Spara videon till disk.

Denna JavaScript‑kod visar hur du extraherar videon på en presentationsbild:

```javascript
// Skapar ett Presentation-objekt som representerar en presentationsfil
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

## **FAQ**

**Vilka videouppspelningsparametrar kan ändras för ett VideoFrame?**

Du kan styra [playback mode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/setplaymode/) (auto eller vid klick) och [looping](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Dessa alternativ finns tillgängliga via egenskaperna för objektet [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/).

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas den binära datan i dokumentet, vilket gör att presentationens storlek ökar i proportion till filens storlek. När du lägger till en online‑video bäddas en länk och en miniatyr in, så ökningsstorleken blir mindre.

**Kan jag byta ut videon i ett befintligt VideoFrame utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) i ramen samtidigt som du behåller figurens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/video/getcontenttype/) som du kan läsa och använda, till exempel när du sparar den till disk.