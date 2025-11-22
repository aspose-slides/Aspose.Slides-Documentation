---
title: Video-Frame
type: docs
weight: 10
url: /de/net/video-frame/
keywords: "Video hinzufügen, Video-Frame erstellen, Video extrahieren, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Video-Frame zu PowerPoint-Präsentation in C# oder .NET hinzufügen"
---

Ein gut platziertes Video in einer Präsentation kann Ihre Botschaft überzeugender machen und die Engagement‑Rate bei Ihrem Publikum steigern.  

PowerPoint ermöglicht es Ihnen, Videos auf einer Folie in einer Präsentation auf zwei Arten hinzuzufügen:

* Video lokal hinzufügen oder einbetten (auf Ihrem Rechner gespeichert)
* Online‑Video hinzufügen (von einer Webquelle wie YouTube).

Damit Sie Videos (Video‑Objekte) zu einer Präsentation hinzufügen können, stellt Aspose.Slides das Interface [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) bereit, das Interface [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) sowie weitere relevante Typen.  

## **Eingebetteten Video‑Frame erstellen**

Wenn die Videodatei, die Sie zu Ihrer Folie hinzufügen möchten, lokal gespeichert ist, können Sie einen Video‑Frame erstellen, um das Video in Ihrer Präsentation einzubetten.  

1. Erstellen Sie eine Instanz der Klasse [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Rufen Sie über den Index eine Referenz auf die Folie ab. 
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Pfad zur Videodatei, um das Video in die Präsentation einzubetten. 
1. Fügen Sie ein [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)‑Objekt hinzu, um einen Frame für das Video zu erstellen.  
1. Speichern Sie die modifizierte Präsentation.  

Dieser C#‑Code zeigt, wie Sie ein lokal gespeichertes Video zu einer Präsentation hinzufügen:
```c#
// Instanziiert die Presentation-Klasse
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Lädt das Video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Holt die erste Folie und fügt einen Videoframe hinzu
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Speichert die Präsentation auf dem Datenträger
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```

Alternativ können Sie ein Video hinzufügen, indem Sie dessen Dateipfad direkt an die Methode [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) übergeben:
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Video‑Frame mit Video aus Web‑Quelle erstellen**
Microsoft [PowerPoint 2013 und neuer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) unterstützt YouTube‑Videos in Präsentationen. Wenn das gewünschte Video online verfügbar ist (z. B. auf YouTube), können Sie es über dessen Web‑Link zu Ihrer Präsentation hinzufügen.  

1. Erstellen Sie eine Instanz der Klasse [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Rufen Sie über den Index eine Referenz auf die Folie ab. 
1. Fügen Sie ein [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)‑Objekt hinzu und übergeben Sie den Link zum Video. 
1. Legen Sie ein Vorschaubild für den Video‑Frame fest. 
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
    // Fügt einen VideoFrame hinzu
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


## **Video aus Folie extrahieren**
Neben dem Hinzufügen von Videos zu Folien ermöglicht Aspose.Slides das Extrahieren von in Präsentationen eingebetteten Videos.  

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), um die Präsentation zu laden, die das Video enthält. 
2. Iterieren Sie über alle [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)-Objekte. 
3. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)-Objekte, um einen [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe) zu finden. 
4. Speichern Sie das Video auf dem Datenträger. 

Dieser C#‑Code zeigt, wie Sie das Video auf einer Präsentationsfolie extrahieren:
```c#
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation("Video.pptx");

// Iteriert durch Folien
foreach (ISlide slide in presentation.Slides)
{
    // Iteriert durch Formen
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Speichert das Video auf die Festplatte, sobald ein VideoFrame, das ein Video enthält, gefunden wurde
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

**Welche Videowiedergabe‑Parameter können für einen VideoFrame geändert werden?**  
Sie können den [Wiedergabemodus](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatisch oder bei Klick) und das [Looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) steuern. Diese Optionen sind über die Eigenschaften des [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/)‑Objekts verfügbar.  

**Wirkt sich das Hinzufügen eines Videos auf die PPTX‑Dateigröße aus?**  
Ja. Wenn Sie ein lokales Video einbetten, werden die Binärdaten in das Dokument aufgenommen, sodass die Präsentationsgröße proportional zur Dateigröße anwächst. Wenn Sie ein Online‑Video hinzufügen, werden nur ein Link und ein Vorschaubild eingebettet, sodass die Größen­zunahme geringer ist.  

**Kann ich das Video in einem bestehenden VideoFrame ersetzen, ohne Position und Größe zu ändern?**  
Ja. Sie können den [Video‑Inhalt](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) im Frame austauschen, während Sie die Geometrie der Form beibehalten; dies ist ein häufiges Szenario zum Aktualisieren von Medien in einem bestehenden Layout.  

**Kann der Inhaltstyp (MIME) eines eingebetteten Videos ermittelt werden?**  
Ja. Ein eingebettetes Video besitzt einen [Content‑Typ](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/), den Sie auslesen und verwenden können, beispielsweise beim Speichern auf dem Datenträger.