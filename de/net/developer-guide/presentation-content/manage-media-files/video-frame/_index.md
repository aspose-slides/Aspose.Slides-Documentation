---
title: Video-Frames in Präsentationen in .NET verwalten
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
description: "Erfahren Sie, wie Sie programmgesteuert Video-Frames in PowerPoint‑ und OpenDocument‑Folien mit Aspose.Slides für .NET hinzufügen und extrahieren. Schnelle Anleitung."
---
Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement‑Level Ihres Publikums erhöhen. 

PowerPoint ermöglicht es Ihnen, Videos auf einer Folie einer Präsentation auf zwei Arten hinzuzufügen:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Computer gespeichert)
* Ein Online‑Video hinzufügen (aus einer Web‑Quelle wie YouTube). 

Um Ihnen das Hinzufügen von Videos (Videoobjekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die Schnittstelle [IVideo](https://reference.aspose.com/slides/de/net/aspose.slides/ivideo/), die Schnittstelle [IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/) und weitere relevante Typen bereit. 

## **Ein eingebettetes Video‑Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie ein Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)-Klasse.  
1. Holen Sie sich den Verweis auf eine Folie über deren Index.  
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/net/aspose.slides/ivideo/)-Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.  
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/)-Objekt hinzu, um einen Frame für das Video zu erstellen.  
1. Speichern Sie die geänderte Präsentation. 

Dieser C#‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```c#
// Instanziert die Presentation-Klasse
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Lädt das Video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Holt die erste Folie und fügt ein Video-Frame hinzu
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Speichert die Präsentation auf dem Datenträger
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternativ können Sie ein Video hinzufügen, indem Sie dessen Dateipfad direkt an die Methode [AddVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addvideoframe/) übergeben:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Ein Video‑Frame mit Video aus einer Web‑Quelle erstellen**
Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über dessen Web‑Link zu Ihrer Präsentation hinzufügen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)-Klasse  
1. Holen Sie sich den Verweis auf eine Folie über deren Index.  
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/net/aspose.slides/ivideo/)-Objekt hinzu und übergeben Sie den Link zum Video.  
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

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht es Ihnen, geschlossene Untertitel für Video‑Frames in PowerPoint‑Präsentationen zu verwalten. Untertitel werden im WebVTT‑Format gespeichert und über die Eigenschaft [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/captiontracks/) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

So fügen Sie Untertitel zu einem Video‑Frame hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)-Klasse.  
1. Fügen Sie der Präsentation ein Video hinzu.  
1. Fügen Sie einem Folie ein [IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/)-Objekt hinzu.  
1. Verwenden Sie die Sammlung [CaptionTracks](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/captiontracks/), um einen WebVTT‑Untertitel‑Track hinzuzufügen.  
1. Speichern Sie die geänderte Präsentation.  

Der folgende Code zeigt, wie Sie Untertitel zu einem Video‑Frame hinzufügen:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Fügt eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Die Schnittstelle [ICaptionsCollection](https://reference.aspose.com/slides/de/net/aspose.slides/icaptionscollection/) bietet außerdem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

So extrahieren Sie Untertitel aus einem Video‑Frame:

1. Laden Sie die Präsentation, die das Video enthält.  
1. Finden Sie das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/)-Objekt.  
1. Iterieren Sie über die Sammlung [CaptionTracks](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/captiontracks/).  
1. Speichern Sie jeden Untertitel‑Track in einer `.vtt`‑Datei.  

Der folgende Code zeigt, wie Sie Untertitel aus einem Video‑Frame extrahieren:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Speichert die Untertitelspur in einer WebVTT-Datei.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Jedes [ICaptions](https://reference.aspose.com/slides/de/net/aspose.slides/icaptions/)-Objekt stellt den Untertitel‑Bezeichner, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑Zeichenfolge bereit.

**Untertitel aus einem Video‑Frame entfernen**

So entfernen Sie Untertitel aus einem Video‑Frame:

1. Laden Sie die Präsentation, die das Video enthält.  
1. Holen Sie das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/)-Objekt.  
1. Entfernen Sie Untertitel‑Tracks aus der Sammlung [CaptionTracks](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/captiontracks/).  
1. Speichern Sie die geänderte Präsentation.  

Der folgende Code zeigt, wie Sie alle Untertitel aus einem Video‑Frame entfernen:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Entfernt alle Untertitel vom Video-Frame.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Wenn Sie nur einen Untertitel‑Track entfernen müssen, verwenden Sie die Methoden [Remove](https://reference.aspose.com/slides/de/net/aspose.slides/captionscollection/remove/) oder [RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides/captionscollection/removeat/) anstelle von [Clear](https://reference.aspose.com/slides/de/net/aspose.slides/captionscollection/clear/).

## **Video aus einer Folie extrahieren**
Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)-Klasse, um die Präsentation zu laden, die das Video enthält.  
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide)-Objekte.  
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape)-Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/videoframe) zu finden.  
4. Speichern Sie das Video auf dem Datenträger.  

Dieser C#‑Code zeigt, wie Sie das Video einer Präsentationsfolie extrahieren:

```c#
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation("Video.pptx");

// Durchläuft die Folien
foreach (ISlide slide in presentation.Slides)
{
    // Durchläuft die Shapes
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

**Welche Video‑Wiedergabeparameter können für ein Video‑Frame geändert werden?**

Sie können den [playback mode](https://reference.aspose.com/slides/de/net/aspose.slides/videoframe/playmode/) (automatisch oder per Klick) und das [looping](https://reference.aspose.com/slides/de/net/aspose.slides/videoframe/playloopmode/) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/videoframe/)-Objekts zur Verfügung.

**Beeinflusst das Hinzufügen eines Videos die PPTX‑Dateigröße?**

Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße wächst. Wenn Sie ein Online‑Video hinzufügen, werden ein Link und ein Miniaturbild eingebettet, sodass die Größe weniger stark zunimmt.

**Kann ich das Video in einem vorhandenen Video‑Frame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [video content](https://reference.aspose.com/slides/de/net/aspose.slides/videoframe/embeddedvideo/) innerhalb des Frames austauschen, während Sie die Geometrie der Form beibehalten; dies ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [content type](https://reference.aspose.com/slides/de/net/aspose.slides/video/contenttype/), den Sie auslesen und verwenden können, zum Beispiel beim Speichern auf dem Datenträger.