---
title: "Hantera videoramar i presentationer i .NET"
linktitle: "Videoram"
type: docs
weight: 10
url: /sv/net/video-frame/
keywords:
- "lägga till video"
- "skapa video"
- "bädda in video"
- "extrahera video"
- "hämta video"
- "videoram"
- "webbkälla"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Lär dig programatiskt lägga till och extrahera videoramar i PowerPoint- och OpenDocument-bilder med Aspose.Slides för .NET. Snabb steg-för-steg-guide."
---
## **Introduktion**

En välplacerad video i en presentation kan göra ditt budskap mer övertygande och öka engagemangsgraden hos din publik. 

PowerPoint låter dig lägga till videor på en bild i en presentation på två sätt:

* Lägg till eller bädda in en lokal video (sparad på din dator)
* Lägg till en online‑video (från en webbkälla såsom YouTube).

För att du ska kunna lägga till videor (videoobjekt) i en presentation tillhandahåller Aspose.Slides [IVideo](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideo/)‑gränssnittet, [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/)‑gränssnittet och andra relevanta typer. 

## **Skapa en inbäddad videoram**

Om videofilen du vill lägga till på din bild lagras lokalt kan du skapa en videoram för att bädda in videon i din presentation. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta en bilds referens via dess index. 
3. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideo/)-objekt och skicka videofilens sökväg för att bädda in videon i presentationen. 
4. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/)-objekt för att skapa en ram för videon.  
5. Spara den förändrade presentationen. 

Denna C#‑kod visar hur du lägger till en lokalt lagrad video i en presentation:

```c#
 // Instansierar Presentation-klassen
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Laddar videon
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Hämtar den första bilden och lägger till en videoram
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


## **Skapa en videoram med video från en webbkälla**
Nyare versioner av Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) stöder online‑videor i presentationer. Om videon du vill använda finns online (t.ex. på YouTube) kan du lägga till den i din presentation via dess webblänk.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta en bilds referens via dess index. 
3. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideo/)-objekt och skicka länken till videon.
4. Ange en miniatyr för videoramen. 
5. Spara presentationen. 

Denna C#‑kod visar hur du lägger till en video från webben på en bild i en PowerPoint‑presentation:

```c#
public static void Run()
{
    // Instansierar ett Presentation-objekt som representerar en presentationsfil 
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

## **Trimma en videoram**

Aspose.Slides låter dig kontrollera vilken del av en video som spelas genom att ställa in värdena trim‑from‑start och trim‑from‑end via [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/trimfromstart/) och [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/trimfromend/). Båda värdena anges i millisekunder och definierar hur mycket tid som hoppas över i början respektive slutet av videon. Dessa inställningar ändrar uppspelningsinställningarna i presentationen; de klipper inte eller på annat sätt modifierar den inbäddade video‑binärdatan.

**Ange triminställningar**

För att skapa en videoram och ange dess triminställningar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
2. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideo/)-objekt i presentationen.
3. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/)-objekt på en bild.
4. Ställ in värdena trim‑from‑start och trim‑from‑end via [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/trimfromstart/) och [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/trimfromend/).
5. Spara den ändrade presentationen.

Följande kodexempel hoppar över de första 2,5 sekunderna och den sista sekunden av en inbäddad video under uppspelning:

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

**Läs triminställningar**

För att granska befintliga triminställningar, ladda en presentation, hitta ett [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/)‑objekt bland formerna på den första bilden och läs värdena via [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/trimfromstart/) och [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/trimfromend/).

Följande kodexempel hittar den första videoramen på den första bilden och rapporterar dess triminställningar i millisekunder:

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

## **Hantera videobeskrivningar**

Aspose.Slides låter dig hantera stängda undertexter för videoramar i PowerPoint‑presentationer. Undertexter lagras i WebVTT‑format och exponeras via egenskapen [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/captiontracks/).

**Lägg till undertexter i en videoram**

För att lägga till undertexter i en videoram:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
2. Lägg till en video i presentationen.
3. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/)‑objekt på en bild.
4. Använd samlingen [CaptionTracks](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/captiontracks/) för att lägga till ett WebVTT‑undertextspår.
5. Spara den ändrade presentationen.

Följande kod visar hur du lägger till undertexter i en videoram:

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

Gränssnittet [ICaptionsCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/icaptionscollection/) tillhandahåller också en överlagring som låter dig lägga till undertexter från en ström.

**Extrahera undertexter från en videoram**

För att extrahera undertexter från en videoram:

1. Läs in presentationen som innehåller videon.
2. Hitta mål‑[IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/)-objektet.
3. Iterera genom samlingen [CaptionTracks](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/captiontracks/).
4. Spara varje undertextspår till en `.vtt`‑fil.

Följande kod visar hur du extraherar undertexter från en videoram:

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

Varje [ICaptions](https://reference.aspose.com/slides/sv/net/aspose.slides/icaptions/)‑objekt exponerar undertextens identifierare, etikett, binärdata och undertextens text som en UTF‑8‑sträng.

**Ta bort undertexter från en videoram**

För att ta bort undertexter från en videoram:

1. Läs in presentationen som innehåller videon.
2. Hämta mål‑[IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/)-objektet.
3. Ta bort undertextspår från samlingen [CaptionTracks](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/captiontracks/).
4. Spara den ändrade presentationen.

Följande kod visar hur du tar bort alla undertexter från en videoram:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Tar bort alla undertexter från videoramen.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Om du bara behöver ta bort ett undertextspår, använd metoderna [Remove](https://reference.aspose.com/slides/sv/net/aspose.slides/captionscollection/remove/) eller [RemoveAt](https://reference.aspose.com/slides/sv/net/aspose.slides/captionscollection/removeat/) istället för [Clear](https://reference.aspose.com/slides/sv/net/aspose.slides/captionscollection/clear/).

## **Extrahera video från en bild**
Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) för att läsa in presentationen som innehåller videon. 
2. Iterera genom alla [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide)-objekt.
3. Iterera genom alla [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape)-objekt för att hitta en [VideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/videoframe). 
4. Spara videon till disk.

Denna C#‑kod visar hur du extraherar videon på en presentationsbild:

```c#
// Instansierar ett Presentation-objekt som representerar en presentationsfil 
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

## **FAQ**

**Vilka videouppspelningsparametrar kan ändras för en VideoFrame?**

Du kan styra [uppspelningsläget](https://reference.aspose.com/slides/sv/net/aspose.slides/videoframe/playmode/) (automatiskt eller vid klick) och [loopning](https://reference.aspose.com/slides/sv/net/aspose.slides/videoframe/playloopmode/). Dessa alternativ finns tillgängliga via objektets egenskaper för [VideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/videoframe/).

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas binärdata i dokumentet, vilket gör att presentationens storlek ökar i proportion till filens storlek. När du lägger till en online‑video bäddas en länk och en miniatyr in, så ökningen blir mindre.

**Kan jag ersätta videon i en befintlig VideoFrame utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/sv/net/aspose.slides/videoframe/embeddedvideo/) inom ramen samtidigt som du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/sv/net/aspose.slides/video/contenttype/) som du kan läsa och använda, exempelvis när du sparar den till disk.