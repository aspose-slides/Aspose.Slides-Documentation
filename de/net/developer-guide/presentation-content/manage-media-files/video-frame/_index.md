---
title: Verwalten von Video-Frames in Präsentationen in .NET
linktitle: Video-Frame
type: docs
weight: 10
url: /de/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für .NET hinzufügen und extrahieren. Schneller Leitfaden."
---

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement‑Level Ihres Publikums erhöhen.  

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online‑Video hinzufügen (von einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Video‑Objekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Schnittstellen [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) und [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) sowie weitere relevante Typen bereit. 

## **Eingebetteten Videorahmen erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Videorahmen erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.  
2. Holen Sie sich über den Index eine Referenz auf eine Folie.  
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.  
4. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)‑Objekt hinzu, um einen Rahmen für das Video zu erstellen.  
5. Speichern Sie die geänderte Präsentation.  

Dieser C#‑Code zeigt, wie ein lokal gespeichertes Video zu einer Präsentation hinzugefügt wird:
```c#
// Instanziiert die Presentation-Klasse
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Lädt das Video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Holt die erste Folie und fügt einen VideoFrame hinzu
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Speichert die Präsentation auf der Festplatte
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```

Alternativ können Sie ein Video hinzufügen, indem Sie seinen Dateipfad direkt an die Methode [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) übergeben:
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Videorahmen mit Video aus Web‑Quelle erstellen**
Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Web‑Link zur Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.  
2. Holen Sie sich über den Index eine Referenz auf eine Folie.  
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Link zum Video.  
4. Legen Sie ein Thumbnail für den Videorahmen fest.  
5. Speichern Sie die Präsentation.  

Dieser C#‑Code zeigt, wie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzugefügt wird:
```c#
public static void Run()
{
    // Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Fügt einen VideoFrame hinzu
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Lädt das Thumbnail
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```


## **Video aus Folie extrahieren**
Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse, um die Präsentation zu laden, die das Video enthält.  
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)‑Objekte.  
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe) zu finden.  
4. Speichern Sie das Video auf der Festplatte.  

Dieser C#‑Code zeigt, wie das Video aus einer Präsentationsfolie extrahiert wird:
```c#
 // Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
 Presentation presentation = new Presentation("Video.pptx");

// Durchläuft die Folien
foreach (ISlide slide in presentation.Slides)
{
    // Durchläuft die Formen
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Speichert das Video auf die Festplatte, sobald ein VideoFrame mit Video gefunden wird
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```


## **FAQ**

**Welche Wiedergabeparameter können für einen VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die PPTX‑Dateigröße?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Beim Hinzufügen eines Online‑Videos werden lediglich ein Link und ein Thumbnail eingebettet, sodass die Größensteigerung geringer ist.

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) innerhalb des Rahmens austauschen und dabei die Geometrie der Form beibehalten; dies ist ein übliches Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der MIME‑Typ eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video besitzt einen [Content‑Type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/), den Sie auslesen und beispielsweise beim Speichern auf der Festplatte verwenden können.