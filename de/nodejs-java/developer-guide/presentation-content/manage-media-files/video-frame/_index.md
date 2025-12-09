---
title: Video-Frame
type: docs
weight: 10
url: /de/nodejs-java/video-frame/
keywords: "Video hinzufügen, Video-Frame erstellen, Video extrahieren, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Video-Frame zu einer PowerPoint-Präsentation in JavaScript hinzufügen"
---

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums steigern.  

PowerPoint ermöglicht es Ihnen, Videos auf einer Folie in einer Präsentation auf zwei Arten hinzuzufügen:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online‑Video hinzufügen (aus einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Video‑Objekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) , die Klasse [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) und weitere relevante Typen zur Verfügung.  

## **Eingebetteten Video‑Frame erstellen**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten.  

1. Erstellen Sie eine Instanz der Klasse [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)class.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie ein [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/)-Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.  
4. Fügen Sie ein [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)-Objekt hinzu, um einen Frame für das Video zu erstellen.  
5. Speichern Sie die geänderte Präsentation.  

Dieser JavaScript‑Code zeigt Ihnen, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:
```javascript
// Instanziiert die Presentation-Klasse
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Lädt das Video
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Holt die erste Folie und fügt einen Video-Frame hinzu
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Speichert die Präsentation auf dem Datenträger
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Alternativ können Sie ein Video hinzufügen, indem Sie den Dateipfad direkt an die Methode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) übergeben:
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

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Weblink zu Ihrer Präsentation hinzufügen.  

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)class  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie ein [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/)-Objekt hinzu und übergeben Sie den Link zum Video.  
4. Legen Sie ein Thumbnail für den Video‑Frame fest.  
5. Speichern Sie die Präsentation.  

Dieser JavaScript‑Code zeigt Ihnen, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:
```javascript
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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


## **Video von Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.  

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class, um die Präsentation zu laden, die das Video enthält.  
2. Durchlaufen Sie alle [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/)-Objekte.  
3. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)-Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) zu finden.  
4. Speichern Sie das Video auf dem Datenträger.  

Dieser JavaScript‑Code zeigt Ihnen, wie Sie das Video einer Präsentationsfolie extrahieren:
```javascript
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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

**Welche Wiedergabeparameter können für einen VideoFrame geändert werden?**  
Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) steuern. Diese Optionen sind über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)-Objekts verfügbar.  

**Hat das Hinzufügen eines Videos Auswirkungen auf die PPTX-Dateigröße?**  
Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße zunimmt. Wenn Sie ein Online‑Video hinzufügen, werden nur ein Link und ein Thumbnail eingebettet, wodurch die Größensteigerung geringer ausfällt.  

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**  
Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) im Frame austauschen, während die Geometrie der Form erhalten bleibt; dies ist ein häufiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.  

**Kann der Content‑Typ (MIME) eines eingebetteten Videos ermittelt werden?**  
Ja. Ein eingebettetes Video verfügt über einen [Content‑Typ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/), den Sie auslesen und beispielsweise beim Speichern auf dem Datenträger verwenden können.