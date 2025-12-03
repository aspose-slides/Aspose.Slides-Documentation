---
title: Verwalten von Videorahmen in Präsentationen mit Java
linktitle: Videorahmen
type: docs
weight: 10
url: /de/java/video-frame/
keywords:
- Video hinzufügen
- Video erstellen
- Video einbetten
- Video extrahieren
- Video abrufen
- Videorahmen
- Webquelle
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Videorahmen in PowerPoint‑ und OpenDocument‑Folien mit Aspose.Slides für Java hinzufügen und extrahieren. Schnelle Anleitung."
---

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und die Interaktionsrate mit Ihrem Publikum erhöhen. 

PowerPoint ermöglicht es Ihnen, Videos auf einer Folie in einer Präsentation auf zwei Arten hinzuzufügen:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online‑Video hinzufügen (aus einer Web‑Quelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Video‑Objekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides das Interface [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , das Interface [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) und weitere relevante Typen bereit. 

## **Einbetten von Videorahmen erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Videorahmen erstellen, um das Video in Ihrer Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Rufen Sie die Referenz einer Folie über deren Index ab. 
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten. 
4. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/)‑Objekt hinzu, um einen Rahmen für das Video zu erstellen.  
5. Speichern Sie die geänderte Präsentation. 

Dieser Java‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:
```java
// Instanziiert die Presentation-Klasse
Presentation pres = new Presentation("pres.pptx");
try {
    // Lädt das Video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Holt die erste Folie und fügt einen Videorahmen hinzu
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Speichert die Präsentation auf dem Datenträger
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


Alternativ können Sie ein Video hinzufügen, indem Sie dessen Dateipfad direkt an die Methode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) übergeben:
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```



## **Videorahmen mit Videos aus Web‑Quellen erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das von Ihnen gewünschte Video online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Web‑Link zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Rufen Sie die Referenz einer Folie über deren Index ab. 
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Link zum Video.
4. Legen Sie ein Vorschau‑Bild (Thumbnail) für den Videorahmen fest. 
5. Speichern Sie die Präsentation. 

Dieser Java‑Code zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:
```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Fügt einen VideoFrame hinzu
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Lädt das Vorschaubild
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```


## **Video aus Folien extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), um die Präsentation zu laden, die das Video enthält. 
2. Iterieren Sie über alle [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/)‑Objekte.
3. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑Objekte, um einen [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) zu finden. 
4. Speichern Sie das Video auf dem Datenträger.

Dieser Java‑Code zeigt, wie Sie das Video von einer Präsentationsfolie extrahieren:
```java
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                // Holt die Dateierweiterung
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Welche Wiedergabeparameter können für einen VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/)-Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die PPTX‑Dateigröße?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße zunimmt. Wenn Sie ein Online‑Video hinzufügen, werden nur ein Link und ein Vorschaubild eingebettet, wodurch die Größenzunahme kleiner ist.

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) innerhalb des Rahmens austauschen, während Sie die Geometrie der Form beibehalten; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video besitzt einen [Content‑Typ](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) , den Sie auslesen und beispielsweise beim Speichern auf die Festplatte verwenden können.