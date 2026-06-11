---
title: Hantera video-ramar i presentationer i .NET
linktitle: Video-ram
type: docs
weight: 10
url: /sv/net/video-frame/
keywords:
- lägga till video
- skapa video
- bädda in video
- extrahera video
- hämta video
- video-ram
- webbkälla
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig programatiskt lägga till och extrahera video-ramar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET. Snabb guide."
---
## **Introduktion**

En välplacerad video i en presentation kan göra ditt budskap mer övertygande och öka engagemangsnivåerna hos din publik. 

PowerPoint låter dig lägga till videor på en bild i en presentation på två sätt:

* Lägg till eller bädda in en lokal video (sparad på din dator)
* Lägg till en online‑video (från en webbkälla såsom YouTube).

För att du ska kunna lägga till videor (videoobjekt) i en presentation tillhandahåller Aspose.Slides [IVideo](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideo/)‑gränssnittet, [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/)‑gränssnittet och andra relevanta typer. 

## **Skapa en inbäddad video‑ram**

Om videofilen du vill lägga till på din bild är sparad lokalt kan du skapa en video‑ram för att bädda in videon i din presentation. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideo/)‑objekt och skicka videofilens sökväg för att bädda in videon i presentationen. 
1. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/)‑objekt för att skapa en ram för videon.  
1. Spara den ändrade presentationen. 

```c#
// Skapar en instans av Presentation-klassen
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Laddar videon
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Hämtar den första bilden och lägger till en video-ram
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Sparar presentationen till disk
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternativt kan du lägga till en video genom att skicka dess filsökväg direkt till metoden [AddVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Skapa en video‑ram med video från en webbkälla**

Microsoft [PowerPoint 2013 och nyare](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) stöder YouTube‑videor i presentationer. Om videon du vill använda finns tillgänglig online (t.ex. på YouTube) kan du lägga till den i din presentation via dess webblänk. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideo/)‑objekt och skicka länken till videon.
1. Ställ in en miniatyr för video‑ramen. 
1. Spara presentationen. 

```c#
public static void Run()
{
    // Skapar ett Presentation-objekt som representerar en presentationsfil 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Lägger till en VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Laddar miniatyr
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Hantera video‑undertexter**

Aspose.Slides låter dig hantera stängda undertexter för video‑ramar i PowerPoint‑presentationer. Undertexter lagras i WebVTT‑format och exponeras via egenskapen [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/captiontracks/).

**Lägg till undertexter på en video‑ram**

För att lägga till undertexter på en video‑ram:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
1. Lägg till en video i presentationen.
1. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/)‑objekt på en bild.
1. Använd samlingen [CaptionTracks](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/captiontracks/) för att lägga till ett WebVTT‑undertextspår.
1. Spara den ändrade presentationen.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Lägger till ett nytt undertextspår från en WebVTT-fil.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Gränssnittet [ICaptionsCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/icaptionscollection/) erbjuder också en överlagring som låter dig lägga till undertexter från en ström.

**Extrahera undertexter från en video‑ram**

För att extrahera undertexter från en video‑ram:

1. Läs in presentationen som innehåller videon.
1. Hitta mål‑objektet [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/) .
1. Iterera genom samlingen [CaptionTracks](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/captiontracks/) .
1. Spara varje undertextspår till en `.vtt`‑fil.

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
                // Sparar undertextspåret till en WebVTT-fil.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Varje [ICaptions](https://reference.aspose.com/slides/sv/net/aspose.slides/icaptions/)‑objekt exponerar undertextens identifierare, etikett, binärdata och undertexten som en UTF‑8‑sträng.

**Ta bort undertexter från en video‑ram**

För att ta bort undertexter från en video‑ram:

1. Läs in presentationen som innehåller videon.
1. Hämta mål‑objektet [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/) .
1. Ta bort undertextspår från samlingen [CaptionTracks](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/captiontracks/) .
1. Spara den ändrade presentationen.

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Tar bort alla undertexter från video-ramen.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Om du bara behöver ta bort ett undertextspår, använd metoderna [Remove](https://reference.aspose.com/slides/sv/net/aspose.slides/captionscollection/remove/) eller [RemoveAt](https://reference.aspose.com/slides/sv/net/aspose.slides/captionscollection/removeat/) istället för [Clear](https://reference.aspose.com/slides/sv/net/aspose.slides/captionscollection/clear/).

## **Extrahera video från en bild**
Förutom att lägga till videor på bilder tillåter Aspose.Slides dig att extrahera videor som är inbäddade i presentationer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) för att läsa in presentationen som innehåller videon. 
2. Iterera igenom alla [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide)‑objekt.
3. Iterera igenom alla [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape)‑objekt för att hitta ett [VideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/videoframe). 
4. Spara videon till disk.

```c#
// Skapar ett Presentation-objekt som representerar en presentationsfil 
Presentation presentation = new Presentation("Video.pptx");

// Itererar genom bilder
foreach (ISlide slide in presentation.Slides)
{
    // Itererar genom former
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Sparar video till disk när en VideoFrame som innehåller video hittas
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

## **Vanliga frågor**

**Vilka videouppspelningsparametrar kan ändras för en VideoFrame?**

Du kan styra [playback mode](https://reference.aspose.com/slides/sv/net/aspose.slides/videoframe/playmode/) (auto eller vid klick) och [looping](https://reference.aspose.com/slides/sv/net/aspose.slides/videoframe/playloopmode/). Dessa alternativ är tillgängliga via egenskaperna för objektet [VideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/videoframe/).

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas binärdata i dokumentet, så presentationens storlek ökar i proportion till filens storlek. När du lägger till en online‑video bäddas en länk och en miniatyr in, så storleksökningen blir mindre.

**Kan jag ersätta videon i en befintlig VideoFrame utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/sv/net/aspose.slides/videoframe/embeddedvideo/) i ramen samtidigt som du behåller figurens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/sv/net/aspose.slides/video/contenttype/) som du kan läsa och använda, exempelvis när du sparar den till disk.