---
title: Video‑Frames in Präsentationen mit JavaScript verwalten
linktitle: Video‑Frame
type: docs
weight: 10
url: /de/nodejs-java/video-frame/
keywords:
- Video hinzufügen
- Video erstellen
- Video einbetten
- Video extrahieren
- Video abrufen
- Video‑Frame
- Web‑Quelle
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Video‑Frames in PowerPoint‑ und OpenDocument‑Folien mithilfe von Aspose.Slides für Node.js via Java hinzufügen und extrahieren. Schnelle Anleitung."
---
## **Einleitung**

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums erhöhen. 

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Hinzufügen oder Einbetten eines lokalen Videos (auf Ihrem Rechner gespeichert)  
* Hinzufügen eines Online‑Videos (von einer Webquelle wie YouTube).  

Um Ihnen das Hinzufügen von Videos (Videoobjekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/video/) , die Klasse [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/) und weitere relevante Typen bereit.

## **Einbetten eines Video‑Frames erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation).  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/video/)‑Objekt hinzu und übergeben Sie den Pfad der Videodatei, um das Video in die Präsentation einzubetten.  
4. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)‑Objekt hinzu, um einen Frame für das Video zu erstellen.  
5. Speichern Sie die geänderte Präsentation.  

```javascript
// Instanziiert die Presentation-Klasse
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Lädt das Video
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Holt die erste Folie und fügt einen Video-Frame hinzu
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Speichert die Präsentation auf der Festplatte
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Alternativ können Sie ein Video hinzufügen, indem Sie dessen Dateipfad direkt an die Methode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) übergeben:

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

## **Video‑Frame mit Video aus Webquelle erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das gewünschte Video online verfügbar ist (z. B. auf YouTube), können Sie es über dessen Web‑Link zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation).  
2. Holen Sie die Referenz einer Folie über ihren Index.  
3. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/video/)‑Objekt hinzu und übergeben Sie den Link zum Video.  
4. Legen Sie ein Vorschaubild für den Video‑Frame fest.  
5. Speichern Sie die Präsentation.  

```javascript
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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

## **Trimmen eines Video‑Frames**

Aspose.Slides ermöglicht es, welchen Teil eines Videos Sie abspielen, indem Sie die Werte trim‑from‑start und trim‑from‑end über [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/settrimfromstart/) bzw. [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/settrimfromend/) festlegen. Beide Werte werden in Millisekunden angegeben und definieren, wie viel Zeit zu Beginn bzw. am Ende des Videos übersprungen wird. Diese Einstellungen ändern die Wiedergabe‑Parameter im Präsentations‑Video; sie schneiden oder verändern die eingebetteten Video‑Binärdaten nicht.

**Trim‑Einstellungen festlegen**

Um einen Video‑Frame zu erstellen und dessen Trim‑Einstellungen festzulegen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).  
2. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/video/)‑Objekt zur Präsentation hinzu.  
3. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)‑Objekt zu einer Folie hinzu.  
4. Setzen Sie die Werte trim‑from‑start und trim‑from‑end über [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/settrimfromstart/) und [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/settrimfromend/).  
5. Speichern Sie die geänderte Präsentation.  

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

**Trim‑Einstellungen auslesen**

Um vorhandene Trim‑Einstellungen zu prüfen, laden Sie eine Präsentation, finden ein [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)‑Objekt auf der ersten Folie und lesen die Werte über [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) und [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/gettrimfromend/) aus.

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

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht das Verwalten von Closed‑Captions für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/).  
2. Fügen Sie ein Video zur Präsentation hinzu.  
3. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)‑Objekt zu einer Folie hinzu.  
4. Verwenden Sie die Sammlung [CaptionsCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/), um einen WebVTT‑Untertitel‑Track hinzuzufügen.  
5. Speichern Sie die geänderte Präsentation.  

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Fügt eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/) bietet außerdem die Methode [addFromStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/#addFromStream), mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

1. Laden Sie die Präsentation, die das Video enthält.  
2. Finden Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)‑Objekt.  
3. Durchlaufen Sie die Sammlung [CaptionsCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/).  
4. Speichern Sie jeden Untertitel‑Track in einer `.vtt`‑Datei.  

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
                // Speichert die Untertitelspur in einer WebVTT-Datei.
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

Jedes [Captions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captions/)‑Objekt gibt den Untertitel‑Identifier, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑String zurück.

**Untertitel aus einem Video‑Frame entfernen**

1. Laden Sie die Präsentation, die das Video enthält.  
2. Holen Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)‑Objekt.  
3. Entfernen Sie Untertitel‑Tracks aus der Sammlung [CaptionsCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/).  
4. Speichern Sie die geänderte Präsentation.  

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // Typ: com.aspose.slides.VideoFrame

    // Entfernt alle Untertitel vom Video-Frame.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Möchten Sie nur einen einzelnen Untertitel‑Track entfernen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/#removeAt) anstelle von [clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/#clear).

## **Video aus Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation), um die Präsentation zu laden, die das Video enthält.  
2. Durchlaufen Sie alle [Slide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/)‑Objekte.  
3. Durchsuchen Sie alle [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/) zu finden.  
4. Speichern Sie das Video auf der Festplatte.  

```javascript
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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
                // Ermittelt die Dateierweiterung
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

**Welche Video‑Wiedergabeparameter können für einen VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/setplayloopmode/) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)-Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die PPTX-Dateigröße?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Beim Hinzufügen eines Online‑Videos werden nur ein Link und ein Vorschaubild eingebettet, sodass die Größensteigerung geringer ist.

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) im Frame austauschen und dabei die Geometrie der Form beibehalten; das ist ein gängiges Szenario zum Aktualisieren von Medien in bestehenden Layouts.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video besitzt einen [Content‑Type](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/video/getcontenttype/), den Sie auslesen und beispielsweise beim Speichern auf die Festplatte verwenden können.