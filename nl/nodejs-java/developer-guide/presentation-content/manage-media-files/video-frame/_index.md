---
title: Video-frames beheren in presentaties met JavaScript
linktitle: Video-frame
type: docs
weight: 10
url: /nl/nodejs-java/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- video-frame
- webbron
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u via code video-frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument-dia’s met Aspose.Slides voor Node.js via Java. Snelle handleiding."
---
## **Inleiding**

Een goed geplaatste video in een presentatie kan uw boodschap krachtiger maken en het betrokkenheidsniveau van uw publiek verhogen. 

PowerPoint stelt u in staat om video's aan een dia in een presentatie toe te voegen op twee manieren:

* Voeg een lokale video toe of embed deze (opgeslagen op uw computer)
* Voeg een online video toe (van een webbron zoals YouTube).

Om u video's (video‑objecten) aan een presentatie toe te voegen, biedt Aspose.Slides de klasse [Video](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/video/) , de klasse [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/) en andere relevante types.

## **Ingebedde video‑frame maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een video‑frame maken om de video in uw presentatie in te bedden. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)klasse.
1. Haal een referentie naar een dia op via de index. 
1. Voeg een [Video](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/video/)‑object toe en geef het pad van het videobestand op om de video in de presentatie te embedden.
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
    // Slaat de presentatie op naar schijf
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

U kunt ook een video toevoegen door het bestandspad rechtstreeks door te geven aan de methode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

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


## **Video‑frame maken met video vanaf een webbron**

Microsoft [PowerPoint 2013 en nieuwer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ondersteunt YouTube‑video's in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze aan uw presentatie toevoegen via de web‑link. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)klasse
1. Haal een referentie naar een dia op via de index. 
1. Voeg een [Video](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/video/)‑object toe en geef de link naar de video door.
1. Stel een miniatuurafbeelding in voor het video‑frame. 
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

## **Een video‑frame trimmen**

Aspose.Slides stelt u in staat om te bepalen welk deel van een video wordt afgespeeld door de waarden *trim‑from‑start* en *trim‑from‑end* in te stellen via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/settrimfromstart/) en [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/settrimfromend/). Beide waarden worden in milliseconden opgegeven en definiëren hoeveel tijd er respectievelijk aan het begin en het einde van de video wordt overgeslagen. Deze instellingen wijzigen de afspeelinstellingen van de video in de presentatie; ze knippen of wijzigen de binaire gegevens van de ingebedde video niet.

**Triminstellingen instellen**

Om een video‑frame te maken en de triminstellingen in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)klasse.
1. Voeg een [Video](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/video/)‑object toe aan de presentatie.
1. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/)‑object toe aan een dia.
1. Stel de *trim‑from‑start*‑ en *trim‑from‑end*‑waarden in via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/settrimfromstart/) en [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/settrimfromend/) .
1. Sla de gewijzigde presentatie op.

De volgende code‑voorbeeld slaat de eerste 2,5 seconde en de laatste seconde van een ingebedde video over tijdens het afspelen:

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

**Triminstellingen lezen**

Om bestaande triminstellingen te bekijken, laad een presentatie, zoek een [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/)‑object tussen de vormen op de eerste dia, en lees de waarden via [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) en [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/gettrimfromend/) .

Het volgende code‑voorbeeld vindt het eerste video‑frame op de eerste dia en meldt de triminstellingen in milliseconden:

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

## **Video‑bijschriften beheren**

Aspose.Slides maakt het mogelijk om gesloten bijschriften voor video‑frames in PowerPoint‑presentaties te beheren. Bijschriften worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de methode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) .

**Bijschriften toevoegen aan een video‑frame**

Om bijschriften aan een video‑frame toe te voegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)klasse.
1. Voeg een video toe aan de presentatie.
1. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/)‑object toe aan een dia.
1. Gebruik de collectie [CaptionsCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/) om een WebVTT‑bijschriftspoor toe te voegen.
1. Sla de gewijzigde presentatie op.

De volgende code toont hoe u bijschriften aan een video‑frame toevoegt:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Voegt een nieuw ondertitelingsspoor toe vanuit een WebVTT-bestand.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De klasse [CaptionsCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/) biedt ook de methode [addFromStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/#addFromStream) waarmee u bijschriften vanuit een stream kunt toevoegen.

**Bijschriften extraheren uit een video‑frame**

Om bijschriften uit een video‑frame te extraheren:

1. Laad de presentatie die de video bevat.
1. Zoek het doel‑[VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/)‑object.
1. Doorloop de collectie [CaptionsCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/) .
1. Sla elk bijschriftspoor op in een `.vtd`‑bestand.

De volgende code toont hoe u bijschriften uit een video‑frame extraheren:

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
                // Slaat het ondertitelingsspoor op naar een WebVTT-bestand.
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

Elk [Captions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captions/)‑object geeft de bijschrift‑identifier, label, binaire gegevens en bijschrifttekst als UTF‑8‑string weer.

**Bijschriften verwijderen uit een video‑frame**

Om bijschriften uit een video‑frame te verwijderen:

1. Laad de presentatie die de video bevat.
1. Haal het doel‑[VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/)‑object op.
1. Verwijder bijschriftsporen uit de [CaptionsCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/) .
1. Sla de gewijzigde presentatie op.

De volgende code toont hoe u alle bijschriften uit een video‑frame verwijdert:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // type: com.aspose.slides.VideoFrame

    // Verwijdert alle bijschriften van het video-frame.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u slechts één bijschriftspoor wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/#removeAt) in plaats van [clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/captionscollection/#clear) .


## **Video uit een dia extraheren**

Naast het toevoegen van video's aan dia’s, maakt Aspose.Slides het mogelijk om video's die in presentaties zijn ingebed te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)klasse om de presentatie met de video te laden.
2. Doorloop alle [Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/)‑objecten.
3. Doorloop alle [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/)‑objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/) te vinden.
4. Sla de video op schijf.

Deze JavaScript‑code laat zien hoe u de video op een presentatiedia kunt extraheren:

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

**Welke afspeelparameters kunnen voor een VideoFrame worden aangepast?**

U kunt de [playback‑mode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatisch of bij klik) en [looping](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/setplayloopmode/) regelen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video embedt, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig toeneemt met de bestandsgrootte. Wanneer u een online video toevoegt, worden alleen een link en een miniatuurafbeelding ingebed, waardoor de toename kleiner is.

**Kan ik de video in een bestaand VideoFrame vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video‑content](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het inhoudstype (MIME) van een ingebedde video worden bepaald?**

Ja. Een ingebedde video heeft een [content type](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/video/getcontenttype/) dat u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.