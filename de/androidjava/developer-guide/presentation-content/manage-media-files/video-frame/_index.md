---
title: Verwalten von Video-Frames in Präsentationen auf Android
linktitle: Video-Frame
type: docs
weight: 10
url: /de/androidjava/video-frame/
keywords:
- Video hinzufügen
- Video erstellen
- Video einbetten
- Video extrahieren
- Video abrufen
- Video-Frame
- Webquelle
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Android in Java programmgesteuert Video-Frames in PowerPoint- und OpenDocument‑Folien hinzufügen und extrahieren. Schnelle Anleitung."
---

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft eindrucksvoller machen und das Engagement Ihrer Zielgruppe steigern. 

PowerPoint ermöglicht es Ihnen, Videos zu einer Folie in einer Präsentation auf zwei Arten hinzuzufügen:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online-Video hinzufügen (von einer Webquelle wie YouTube). 

Damit Sie Videos (Videoobjekte) zu einer Präsentation hinzufügen können, stellt Aspose.Slides das [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/)‑Interface, das [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)‑Interface und weitere relevante Typen bereit.

## **Ein eingebettetes Video-Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video-Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
1. Holen Sie sich eine Referenz auf eine Folie über deren Index.  
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/)-Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.  
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)-Objekt hinzu, um einen Frame für das Video zu erstellen.  
1. Speichern Sie die geänderte Präsentation.  

Dieser Java-Code zeigt Ihnen, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:
```java
// Instanziiert die Presentation-Klasse
Presentation pres = new Presentation("pres.pptx");
try {
    // Lädt das Video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Holt die erste Folie und fügt einen Video-Frame hinzu
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Speichert die Präsentation auf dem Datenträger
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


Alternativ können Sie ein Video hinzufügen, indem Sie seinen Dateipfad direkt an die Methode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) übergeben:
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Ein Video-Frame mit Video aus einer Webquelle erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube-Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Weblink zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.  
1. Holen Sie sich eine Referenz auf eine Folie über deren Index.  
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/)-Objekt hinzu und übergeben Sie den Link zum Video.  
1. Legen Sie ein Thumbnail für den Video-Frame fest.  
1. Speichern Sie die Präsentation.  

Dieser Java-Code zeigt Ihnen, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:
```java
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
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
    // Fügt ein Video-Frame hinzu
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


## **Video aus einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse, um die Präsentation zu laden, die das Video enthält.  
2. Iterieren Sie über alle [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)-Objekte.  
3. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)-Objekte, um einen [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) zu finden.  
4. Speichern Sie das Video auf dem Datenträger.  

Dieser Java-Code zeigt Ihnen, wie Sie das Video einer Präsentationsfolie extrahieren:
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

                // Ermittelt die Dateierweiterung
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

**Welche Video‑Wiedergabeparameter können für ein VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch oder per Klick) und das [Looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/)-Objekts zur Verfügung.

**Hat das Hinzufügen eines Videos Auswirkungen auf die Größe der PPTX‑Datei?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie ein Online‑Video hinzufügen, werden ein Link und ein Thumbnail eingebettet, sodass die Größensteigerung geringer ist.

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Videoinhalt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) innerhalb des Frames austauschen, während Sie die Geometrie der Form beibehalten; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [Content‑Typ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) , den Sie auslesen und verwenden können, beispielsweise beim Speichern auf die Festplatte.