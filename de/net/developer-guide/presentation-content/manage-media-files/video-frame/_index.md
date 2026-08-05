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
description: "Erfahren Sie, wie Sie programmatisch Video-Frames in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für .NET hinzufügen und extrahieren. Schnelle Anleitung."
---
## **Einleitung**

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und die Engagement‑Level Ihres Publikums erhöhen. 

PowerPoint ermöglicht das Hinzufügen von Videos zu einer Folie in einer Präsentation auf zwei Arten:

* Ein lokales Video hinzufügen oder einbetten (auf Ihrem Gerät gespeichert)
* Ein Online‑Video hinzufügen (aus einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Video‑Objekten) zu einer Präsentation zu ermöglichen, stellt Aspose.Slides die [IVideo](https://reference.aspose.com/slides/de/net/aspose.slides/ivideo/)‑Schnittstelle, die [IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/)‑Schnittstelle und weitere relevante Typen bereit. 

## **Ein eingebettetes Video‑Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihre Präsentation einzubetten. 

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/net/aspose.slides/ivideo/)-Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten.  
4. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/)-Objekt hinzu, um einen Frame für das Video zu erstellen.  
5. Speichern Sie die geänderte Präsentation.  

Dieser C#‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```c#
// Instanziiert die Presentation-Klasse
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
Alternativ können Sie ein Video hinzufügen, indem Sie seinen Dateipfad direkt an die [AddVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addvideoframe/)‑Methode übergeben:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Ein Video‑Frame mit Video aus einer Web‑Quelle erstellen**
Neuere Versionen von Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) unterstützen Online‑Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z. B. auf YouTube), können Sie es über seinen Web‑Link zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/net/aspose.slides/ivideo/)-Objekt hinzu und übergeben Sie den Link zum Video.  
4. Legen Sie ein Vorschaubild für den Video‑Frame fest.  
5. Speichern Sie die Präsentation.  

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
    // Fügt einen Video-Frame hinzu
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Lädt das Vorschaubild
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Trimmen eines Video‑Frames**

Aspose.Slides ermöglicht die Steuerung, welcher Teil eines Videos abgespielt wird, indem die Werte trim‑from‑start und trim‑from‑end über [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/trimfromstart/) und [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/trimfromend/) festgelegt werden. Beide Werte werden in Millisekunden angegeben und bestimmen, wie viel Zeit am Anfang bzw. Ende des Videos übersprungen wird. Diese Einstellungen ändern die Wiedergabe­parameter im Präsentations‑Dokument; sie schneiden das eingebettete Video‑Binärdaten nicht zu oder verändern sie anderweitig.

**Trim‑Einstellungen festlegen**

Um einen Video‑Frame zu erstellen und seine Trim‑Einstellungen festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.  
2. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/de/net/aspose.slides/ivideo/)-Objekt zur Präsentation hinzu.  
3. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/)-Objekt zu einer Folie hinzu.  
4. Setzen Sie die Werte trim‑from‑start und trim‑from‑end über [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/trimfromstart/) und [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/trimfromend/).  
5. Speichern Sie die geänderte Präsentation.  

Das folgende Codebeispiel überspringt die ersten 2,5 Sekunden und die letzte Sekunde eines eingebetteten Videos während der Wiedergabe:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Trim‑Einstellungen auslesen**

Um vorhandene Trim‑Einstellungen zu prüfen, laden Sie eine Präsentation, finden ein [IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/)-Objekt unter den Formen auf der ersten Folie und lesen die Werte über [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/trimfromstart/) und [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/trimfromend/) aus.

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Video‑Untertitel verwalten**

Aspose.Slides ermöglicht das Verwalten von Closed‑Captions für Video‑Frames in PowerPoint‑Präsentationen. Untertitel werden im WebVTT‑Format gespeichert und über die Eigenschaft [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/captiontracks/) bereitgestellt.

**Untertitel zu einem Video‑Frame hinzufügen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.  
2. Fügen Sie ein Video zur Präsentation hinzu.  
3. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/)‑Objekt zu einer Folie hinzu.  
4. Verwenden Sie die [CaptionTracks](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/captiontracks/)‑Auflistung, um eine WebVTT‑Untertitelspur hinzuzufügen.  
5. Speichern Sie die geänderte Präsentation.  

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

Die [ICaptionsCollection](https://reference.aspose.com/slides/de/net/aspose.slides/icaptionscollection/)‑Schnittstelle bietet zudem eine Überladung, mit der Sie Untertitel aus einem Stream hinzufügen können.

**Untertitel aus einem Video‑Frame extrahieren**

1. Laden Sie die Präsentation, die das Video enthält.  
2. Suchen Sie das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/)‑Objekt.  
3. Iterieren Sie durch die [CaptionTracks](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/captiontracks/)‑Auflistung.  
4. Speichern Sie jede Untertitelspur in einer `.vtt`‑Datei.  

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

Jedes [ICaptions](https://reference.aspose.com/slides/de/net/aspose.slides/icaptions/)‑Objekt stellt die Untertitel‑ID, das Label, die Binärdaten und den Untertiteltext als UTF‑8‑String bereit.

**Untertitel aus einem Video‑Frame entfernen**

1. Laden Sie die Präsentation, die das Video enthält.  
2. Holen Sie das Ziel‑[IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/)‑Objekt.  
3. Entfernen Sie Untertitelspuren aus der [CaptionTracks](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/captiontracks/)‑Auflistung.  
4. Speichern Sie die geänderte Präsentation.  

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

Wenn Sie nur eine Untertitelspur entfernen möchten, verwenden Sie die [Remove](https://reference.aspose.com/slides/de/net/aspose.slides/captionscollection/remove/)‑ oder [RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides/captionscollection/removeat/)‑Methoden anstelle von [Clear](https://reference.aspose.com/slides/de/net/aspose.slides/captionscollection/clear/).

## **Video aus einer Folie extrahieren**
Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)‑Klasse, um die Präsentation zu laden, die das Video enthält.  
2. Iterieren Sie durch alle [ISlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide)‑Objekte.  
3. Iterieren Sie durch alle [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape)‑Objekte, um ein [VideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/videoframe) zu finden.  
4. Speichern Sie das Video auf dem Datenträger.  

```c#
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation("Video.pptx");

// Durchläuft die Folien
foreach (ISlide slide in presentation.Slides)
{
    // Durchläuft die Formen
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Speichert das Video auf dem Datenträger, sobald ein VideoFrame, das das Video enthält, gefunden wird
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

**Welche Video‑Wiedergabeparameter können für einen VideoFrame geändert werden?**

Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/de/net/aspose.slides/videoframe/playmode/) (automatisch oder beim Klicken) und das [Looping](https://reference.aspose.com/slides/de/net/aspose.slides/videoframe/playloopmode/) steuern. Diese Optionen stehen über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/videoframe/)‑Objekts zur Verfügung.

**Wirkt sich das Hinzufügen eines Videos auf die PPTX-Dateigröße aus?**

Ja. Beim Einbetten eines lokalen Videos werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße zunimmt. Beim Hinzufügen eines Online‑Videos werden nur ein Link und ein Vorschaubild eingebettet, sodass die Größen­zunahme geringer ist.

**Kann ich das Video in einem vorhandenen VideoFrame ersetzen, ohne Position und Größe zu ändern?**

Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/de/net/aspose.slides/videoframe/embeddedvideo/) im Frame austauschen, während die Geometrie der Form erhalten bleibt; das ist ein gängiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**

Ja. Ein eingebettetes Video hat einen [Content‑Typ](https://reference.aspose.com/slides/de/net/aspose.slides/video/contenttype/), den Sie auslesen und beispielsweise beim Speichern auf die Festplatte verwenden können.