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
description: "Erfahren Sie, wie Sie mithilfe von Aspose.Slides für .NET programmgesteuert Video-Frames in PowerPoint- und OpenDocument-Folien hinzufügen und extrahieren. Schnelle Kurzanleitung."
---

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums erhöhen.

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Ein Online‑Video hinzufügen (aus einer Web‑Quelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Video‑Objekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides das Interface [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) bereit, das Interface [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) und weitere relevante Typen.

## **Ein eingebettetes Video‑Frame erstellen**

Wenn die Videodatei, die Sie Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie ein Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Holen Sie sich den Verweis auf eine Folie über ihren Index.
1. Fügen Sie ein Objekt vom Typ [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.
1. Fügen Sie ein Objekt vom Typ [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) hinzu, um ein Frame für das Video zu erstellen.
1. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:
```c#
// Instanziiert die Klasse Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Lädt das Video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Holt die erste Folie und fügt einen Video-Frame hinzu
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Speichert die Präsentation auf dem Datenträger
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```

Alternativ können Sie ein Video hinzufügen, indem Sie den Datei‑Pfad direkt an die Methode [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) übergeben:
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Ein Video‑Frame mit Video aus einer Web‑Quelle erstellen**

Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das gewünschte Video online verfügbar ist (z. B. auf YouTube), können Sie es über den Web‑Link Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Holen Sie sich den Verweis auf eine Folie über ihren Index.
1. Fügen Sie ein Objekt vom Typ [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) hinzu und übergeben Sie den Link zum Video.
1. Legen Sie ein Miniaturbild für das Video‑Frame fest.
1. Speichern Sie die Präsentation.

Dieser C#‑Code zeigt, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:
```c#
public static void Run()
{
    // Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Fügt ein VideoFrame hinzu
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Lädt das Miniaturbild
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```


## **Video von einer Folie extrahieren**

Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), um die Präsentation zu laden, die das Video enthält.
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)-Objekte.
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)-Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe) zu finden.
4. Speichern Sie das Video auf dem Datenträger.

Dieser C#‑Code zeigt, wie Sie das Video einer Präsentationsfolie extrahieren:
```c#
 // Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation("Video.pptx");

// Durchläuft die Folien
foreach (ISlide slide in presentation.Slides)
{
    // Durchläuft die Formen
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Speichert das Video auf dem Datenträger, sobald ein VideoFrame mit Video gefunden wird
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

**Welche Wiedergabeparameter können für ein VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) steuern. Diese Optionen stehen über die Eigenschaften des Objekts [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) zur Verfügung.

**Wirkt sich das Hinzufügen eines Videos auf die PPTX-Dateigröße aus?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie ein Online‑Video hinzufügen, werden nur ein Link und ein Miniaturbild eingebettet, sodass der Größenzuwachs geringer ist.

**Kann ich das Video in einem vorhandenen VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) im Frame austauschen, wobei die Geometrie der Form erhalten bleibt; dies ist ein häufiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video verfügt über einen [Inhaltstyp](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/), den Sie auslesen und verwenden können, beispielsweise beim Speichern auf dem Datenträger.