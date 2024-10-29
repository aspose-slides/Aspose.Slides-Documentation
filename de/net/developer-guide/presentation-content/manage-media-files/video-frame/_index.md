---
title: Video-Rahmen
type: docs
weight: 10
url: /de/net/video-frame/
keywords: "Video hinzufügen, Video-Rahmen erstellen, Video extrahieren, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Fügen Sie einen Video-Rahmen zu einer PowerPoint-Präsentation in C# oder .NET hinzu"
---

Ein gut platzierter Video in einer Präsentation kann Ihre Botschaft überzeugender machen und das Engagement Ihres Publikums erhöhen.

PowerPoint ermöglicht es Ihnen, Videos auf zwei Arten zu einer Folie in einer Präsentation hinzuzufügen:

* Fügen Sie ein lokales Video hinzu oder betten Sie es ein (auf Ihrem Rechner gespeichert)
* Fügen Sie ein Online-Video hinzu (aus einer Webquelle wie YouTube).

Um Ihnen das Hinzufügen von Videos (Videoobjekten) zu einer Präsentation zu ermöglichen, bietet Aspose.Slides die [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) Schnittstelle, die [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) Schnittstelle und andere relevante Typen.

## **Embedded Video-Rahmen erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video-Rahmen erstellen, um das Video in Ihrer Präsentation einzubetten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video mit der Präsentation einzubetten.
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) Objekt hinzu, um einen Rahmen für das Video zu erstellen.
1. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:

```c#
// Instanziiert die Presentation-Klasse
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Lädt das Video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Holt die erste Folie und fügt einen Video-Rahmen hinzu
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Speichert die Präsentation auf der Festplatte
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternativ können Sie ein Video hinzufügen, indem Sie den Pfad zur Datei direkt an die [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) Methode übergeben:

```csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Video-Rahmen mit Video aus einer Webquelle erstellen**
Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube-Videos in Präsentationen. Wenn das Video, das Sie verwenden möchten, online verfügbar ist (z.B. auf YouTube), können Sie es über seinen Weblink zu Ihrer Präsentation hinzufügen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) Objekt hinzu und übergeben Sie den Link zum Video.
1. Setzen Sie ein Miniaturbild für den Video-Rahmen.
1. Speichern Sie die Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie ein Video aus dem Web zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

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
    // Fügt einen Video-Rahmen hinzu
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

## **Video von Folie extrahieren**
Neben dem Hinzufügen von Videos zu Folien ermöglicht es Aspose.Slides Ihnen auch, Videos, die in Präsentationen eingebettet sind, zu extrahieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, um die Präsentation zu laden, die das Video enthält.
2. Durchlaufen Sie alle [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) Objekte.
3. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) Objekte, um einen [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe) zu finden.
4. Speichern Sie das Video auf der Festplatte.

Dieser C#-Code zeigt Ihnen, wie Sie das Video auf einer Präsentationsfolie extrahieren:

```c#
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation("Video.pptx");

// Durchläuft die Folien
foreach (ISlide slide in presentation.Slides)
{
    // Durchläuft die Formen
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Speichert das Video auf der Festplatte, sobald der Video-Rahmen mit dem Video gefunden wird
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