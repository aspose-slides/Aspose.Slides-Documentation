---
title: Beheer videoframes in presentaties met JavaScript
linktitle: Videoframe
type: docs
weight: 10
url: /nl/nodejs-java/video-frame/
keywords:
- video toevoegen
- video maken
- video embedden
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
description: "Leer hoe u programmatically videoframes kunt toevoegen en extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Node.js via Java. Snelle handleiding."
---
## **Inleiding**

Een goed geplaatste video in een presentatie kan uw boodschap overtuigender maken en de betrokkenheid van uw publiek vergroten. 

PowerPoint stelt u in staat om video's aan een dia in een presentatie toe te voegen op twee manieren:

* Voeg een lokale video toe of embed deze (opgeslagen op uw computer)
* Voeg een online video toe (van een webbron zoals YouTube).

Om u in staat te stellen video's (video‑objecten) aan een presentatie toe te voegen, biedt Aspose.Slides de [Video](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/video/)‑klasse, de [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/)‑klasse en andere relevante types.

## **Maak een ingesloten videoframe**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie te embedden. 

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)klasse.
1. Haal een referentie naar een dia op via de index. 
1. Voeg een [Video](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/video/)‑object toe en geef het pad naar het videobestand door om de video in de presentatie te embedden.
1. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/)‑object toe om een frame voor de video te maken.
1. Sla de gewijzigde presentatie op. 

Deze JavaScript‑code laat zien hoe u een lokaal opgeslagen video aan een presentatie toevoegt:

```javascript
// Instantieert de Presentation-klasse
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Laadt de video
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Haalt de eerste dia op en voegt een videoframe toe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Slaat de presentatie op schijf
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

U kunt ook een video toevoegen door het bestandspad direct door te geven aan de [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-)‑methode:

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

## **Maak videoframe met video van webbron**

Microsoft [PowerPoint 2013 en nieuwer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ondersteunt YouTube‑video’s in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze via de web‑link aan uw presentatie toevoegen. 

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)klasse
1. Haal een referentie naar een dia op via de index. 
1. Voeg een [Video](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/video/)‑object toe en geef de link naar de video door.
1. Stel een miniatuurafbeelding in voor het videoframe. 
1. Sla de presentatie op. 

Deze JavaScript‑code laat zien hoe u een video van het web aan een dia in een PowerPoint‑presentatie toevoegt:

```javascript
// Instantieert een Presentation-object dat een presentatiebestand vertegenwoordigt
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

## **Beheer videobijschriften**

Aspose.Slides stelt u in staat om gesloten bijschriften voor videoframes in PowerPoint‑presentaties te beheren. Bijschriften worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/#getCaptionTracks)‑methode.

**Bijschriften toevoegen aan een videoframe**

Om bijschriften toe te voegen aan een videoframe:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Voeg een video toe aan de presentatie.
1. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/)‑object toe aan een dia.
1. Gebruik de [CaptionsCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/)‑collectie om een WebVTT‑bijschrifttrack toe te voegen.
1. Sla de gewijzigde presentatie op.

De volgende code laat zien hoe u bijschriften toevoegt aan een videoframe:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Voegt een nieuw bijschrifttrack toe vanuit een WebVTT-bestand.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De [CaptionsCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/)‑klasse biedt ook de [addFromStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/#addFromStream)‑methode waarmee u bijschriften vanuit een stream kunt toevoegen.

**Bijschriften extraheren uit een videoframe**

Om bijschriften te extraheren uit een videoframe:

1. Laad de presentatie die de video bevat.
1. Zoek het gewenste [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/)‑object.
1. Doorloop de [CaptionsCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/)‑collectie.
1. Sla elke bijschrifttrack op in een `.vtt`‑bestand.

De volgende code laat zien hoe u bijschriften uit een videoframe extraheren:

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
                // Slaat het bijschrifttrack op naar een WebVTT-bestand.
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

Elk [Captions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captions/)‑object geeft de bijschrift‑identifier, het label, binaire gegevens en de bijschrifttekst weer als een UTF‑8‑string.

**Bijschriften verwijderen uit een videoframe**

Om bijschriften te verwijderen uit een videoframe:

1. Laad de presentatie die de video bevat.
1. Haal het gewenste [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/)‑object op.
1. Verwijder bijschrifttracks uit de [CaptionsCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/)‑collectie.
1. Sla de gewijzigde presentatie op.

De volgende code laat zien hoe u alle bijschriften uit een videoframe verwijdert:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // type: com.aspose.slides.VideoFrame

    // Verwijdert alle bijschriften van het videoframe.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u slechts één bijschrifttrack wilt verwijderen, gebruik dan de [remove](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/#remove)‑ of [removeAt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/#removeAt)‑methoden in plaats van [clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/#clear).

## **Video extraheren van dia**

Naast het toevoegen van video’s aan dia’s, maakt Aspose.Slides het mogelijk video’s die in presentaties zijn ingesloten te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse om de presentatie te laden die de video bevat.
2. Doorloop alle [Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/)‑objecten.
3. Doorloop alle [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/)‑objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/) te vinden.
4. Sla de video op schijf.

Deze JavaScript‑code laat zien hoe u de video van een presentatiedia extraheren:

```javascript
// Instantieert een Presentation-object dat een presentatiebestand vertegenwoordigt
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
                // Haalt de bestandsextensie op
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

**Welke video‑afspeelparameters kunnen worden aangepast voor een VideoFrame?**

U kunt de afspeelmodus (automatisch of bij klik) en het herhalen regelen. Deze opties zijn beschikbaar via de eigenschappen van het VideoFrame‑object.

**Heeft het toevoegen van een video invloed op de grootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video embed, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig toeneemt met de bestandsgrootte. Wanneer u een online video toevoegt, worden alleen een link en een miniatuurafbeelding embedded, waardoor de grootte‑toename kleiner is.

**Kan ik de video in een bestaand VideoFrame vervangen zonder positie en grootte te wijzigen?**

Ja. U kunt de video‑inhoud binnen het frame vervangen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay‑out.

**Kan het contenttype (MIME) van een embedded video worden bepaald?**

Ja. Een embedded video heeft een contenttype dat u kunt uitlezen en bijvoorbeeld kunt gebruiken bij het opslaan op schijf.