---
title: "Video-Frames in Präsentationen mithilfe von JavaScript verwalten"
linktitle: "Video-Frame"
type: docs
weight: 10
url: /de/nodejs-java/video-frame/
keywords:
- "Video hinzufügen"
- "Video erstellen"
- "Video einbetten"
- "Video extrahieren"
- "Video abrufen"
- "Video-Frame"
- "Webquelle"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Lernen Sie, wie Sie programmgesteuert Video‑Frames in PowerPoint‑ und OpenDocument‑Folien mit Aspose.Slides für Node.js über Java hinzufügen und extrahieren. Schnelle Anleitung."
---
Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und die Engagement‑Level mit Ihrem Publikum erhöhen. 

PowerPoint ermöglicht es Ihnen, Videos auf einer Folie in einer Präsentation auf zwei Arten hinzuzufügen:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online‑Video hinzufügen (von einer Web‑Quelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Video‑Objekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/video/) , die Klasse [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/) und weitere relevante Typen bereit.

## **Eingebetteten Video‑Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation).
1. Holen Sie sich eine Referenz auf eine Folie über ihren Index. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/video/)‑Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)‑Objekt hinzu, um einen Frame für das Video zu erstellen.
1. Speichern Sie die geänderte Präsentation. 

Dieser JavaScript‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```javascript
// Instanziert die Presentation-Klasse
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

## **Video‑Frame mit Video aus Web‑Quelle erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Web‑Link zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation).
1. Holen Sie sich eine Referenz auf eine Folie über ihren Index. 
1. Fügen Sie ein [Video](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/video/)‑Objekt hinzu und übergeben Sie den Link zum Video.
1. Legen Sie ein Thumbnail für den Video‑Frame fest. 
1. Speichern Sie die Präsentation. 

Dieser JavaScript‑Code zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:

```javascript
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
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

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht es Ihnen, geschlossene Untertitel für Video‑Frames in PowerPoint‑Präsentationen zu verwalten. Untertitel werden im WebVTT‑Format gespeichert und über die Methode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

Um Untertitel zu einem Video‑Frame hinzuzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) .
1. Fügen Sie ein Video zur Präsentation hinzu.
1. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)‑Objekt zu einer Folie hinzu.
1. Verwenden Sie die Sammlung [CaptionsCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/) , um eine WebVTT‑Untertitelspur hinzuzufügen.
1. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie Sie Untertitel zu einem Video‑Frame hinzufügen:

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

Die Klasse [CaptionsCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/) bietet außerdem die Methode [addFromStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/#addFromStream) , mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

Um Untertitel aus einem Video‑Frame zu extrahieren:

1. Laden Sie die Präsentation, die das Video enthält.
1. Finden Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)‑Objekt.
1. Durchlaufen Sie die Sammlung [CaptionsCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/) .
1. Speichern Sie jede Untertitelspur in einer `.vtt`‑Datei.

Der folgende Code zeigt, wie Sie Untertitel aus einem Video‑Frame extrahieren:

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

Jedes [Captions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captions/)‑Objekt stellt die Untertitel‑Kennung, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenkette bereit.

**Untertitel aus einem Video‑Frame entfernen**

Um Untertitel aus einem Video‑Frame zu entfernen:

1. Laden Sie die Präsentation, die das Video enthält.
1. Holen Sie das Ziel‑[VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)‑Objekt.
1. Entfernen Sie Untertitelspuren aus der Sammlung [CaptionsCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/) .
1. Speichern Sie die geänderte Präsentation.

Der folgende Code zeigt, wie Sie alle Untertitel aus einem Video‑Frame entfernen:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // Typ: com.aspose.slides.VideoFrame

    // Entfernt alle Untertitel aus dem Video-Frame.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn Sie nur eine Untertitelspur entfernen müssen, verwenden Sie die Methoden [remove](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/#removeAt) anstelle von [clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/#clear).

## **Video aus Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation) , um die Präsentation zu laden, die das Video enthält.
2. Durchlaufen Sie alle [Slide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/)‑Objekte.
3. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/) zu finden.
4. Speichern Sie das Video auf dem Datenträger.

Dieser JavaScript‑Code zeigt, wie Sie das Video aus einer Präsentationsfolie extrahieren:

```javascript
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
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

**Welche Videowiedergabe‑Parameter können für einen Video‑Frame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatisch oder per Klick) und das [Looping](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/setplayloopmode/) steuern. Diese Optionen sind über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/)‑Objekts verfügbar.

**Wirkt sich das Hinzufügen eines Videos auf die Größe der PPTX‑Datei aus?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Beim Hinzufügen eines Online‑Videos wird ein Link und ein Thumbnail eingebettet, wodurch die Größensteigerung geringer ist.

**Kann ich das Video in einem bestehenden Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Videoinhalt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) im Frame austauschen, während Sie die Geometrie des Shapes beibehalten; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video verfügt über einen [Content‑Typ](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/video/getcontenttype/) , den Sie auslesen und verwenden können, beispielsweise beim Speichern auf dem Datenträger.