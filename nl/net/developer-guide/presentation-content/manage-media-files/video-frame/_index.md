---
title: Beheer videoframes in presentaties in .NET
linktitle: Videoframe
type: docs
weight: 10
url: /nl/net/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- videoframe
- webbron
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u programmeermatig video-frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor .NET. Snelle stapsgewijze handleiding."
---
## **Inleiding**

Een goed geplaatste video in een presentatie kan uw boodschap overtuigender maken en de betrokkenheid van uw publiek verhogen.

PowerPoint stelt u in staat om video's aan een dia in een presentatie toe te voegen op twee manieren:

* Een lokale video toevoegen of insluiten (opgeslagen op uw computer)
* Een online video toevoegen (van een webbron zoals YouTube).

Om u in staat te stellen video's (videobjecten) aan een presentatie toe te voegen, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideo/) interface, [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) interface en andere relevante types.

## **Maak een ingesloten videoframe**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een [IVideo](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideo/)‑object toe en geef het pad naar het videobestand door om de video in de presentatie in te sluiten.  
4. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/)‑object toe om een frame voor de video te maken.  
5. Sla de aangepaste presentatie op.  

```c#
// Instantieert de Presentation-klasse
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Laadt de video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Haalt de eerste dia op en voegt een videoframe toe
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Slaat de presentatie op naar schijf
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
U kunt ook een video toevoegen door het bestandspad rechtstreeks door te geven aan de [AddVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addvideoframe/)‑methode:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Maak een videoframe met video van een webbron**
Microsoft [PowerPoint 2013 en nieuwer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ondersteunt YouTube‑video’s in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze aan uw presentatie toevoegen via de web‑link.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een [IVideo](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideo/)‑object toe en geef de link naar de video door.  
4. Stel een miniatuurafbeelding in voor het videoframe.  
5. Sla de presentatie op.  

```c#
public static void Run()
{
    // Instantieert een Presentation-object dat een presentatiebestand vertegenwoordigt 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Voegt een VideoFrame toe
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Laadt miniatuurafbeelding
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Beheer video‑ondertitels**

Aspose.Slides stelt u in staat om gesloten ondertitels voor video‑frames in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn beschikbaar via de eigenschap [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/captiontracks/).

**Voeg ondertitels toe aan een videoframe**

Om ondertitels toe te voegen aan een videoframe:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.  
2. Voeg een video toe aan de presentatie.  
3. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/)‑object toe aan een dia.  
4. Gebruik de [CaptionTracks](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/captiontracks/)‑collectie om een WebVTT‑ondertiteltrack toe te voegen.  
5. Sla de aangepaste presentatie op.  

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Voegt een nieuw ondertiteltrack toe vanuit een WebVTT-bestand.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

De interface [ICaptionsCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/icaptionscollection/) biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

**Extraheer ondertitels uit een videoframe**

Om ondertitels uit een videoframe te extraheren:

1. Laad de presentatie die de video bevat.  
2. Zoek het gewenste [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/)‑object.  
3. Doorloop de [CaptionTracks](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/captiontracks/)‑collectie.  
4. Sla elke ondertiteltrack op naar een `.vtt`‑bestand.  

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
                // Slaat het ondertiteltrack op naar een WebVTT-bestand.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Elk [ICaptions](https://reference.aspose.com/slides/nl/net/aspose.slides/icaptions/)‑object geeft de ondertitel‑identifier, het label, de binaire gegevens en de ondertiteltekst als een UTF‑8‑string weer.

**Verwijder ondertitels uit een videoframe**

Om ondertitels uit een videoframe te verwijderen:

1. Laad de presentatie die de video bevat.  
2. Haal het gewenste [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/)‑object op.  
3. Verwijder ondertitel‑tracks uit de [CaptionTracks](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/captiontracks/)‑collectie.  
4. Sla de aangepaste presentatie op.  

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Verwijdert alle ondertitels uit het videoframe.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de methoden [Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/captionscollection/remove/) of [RemoveAt](https://reference.aspose.com/slides/nl/net/aspose.slides/captionscollection/removeat/) in plaats van [Clear](https://reference.aspose.com/slides/nl/net/aspose.slides/captionscollection/clear/).

## **Video extraheren van een dia**
Naast het toevoegen van video's aan dia’s stelt Aspose.Slides u in staat om video’s die in presentaties zijn ingesloten te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse om de presentatie met de video te laden.  
2. Doorloop alle [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide)‑objecten.  
3. Doorloop alle [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape)‑objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/videoframe) te vinden.  
4. Sla de video op op schijf.  

```c#
 // Instantieert een Presentation-object dat een presentatiebestand vertegenwoordigt 
 Presentation presentation = new Presentation("Video.pptx");

 // Doorloopt de dia's
 foreach (ISlide slide in presentation.Slides)
 {
     // Doorloopt de vormen
     foreach (IShape shape in presentation.Slides[0].Shapes)
     {
         // Slaat de video op naar schijf zodra een VideoFrame met video wordt gevonden
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

**Welke afspeelparameters van een videoframe kunnen worden aangepast?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/nl/net/aspose.slides/videoframe/playmode/) (automatisch of bij klik) en de [loopmodus](https://reference.aspose.com/slides/nl/net/aspose.slides/videoframe/playloopmode/) regelen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/videoframe/)‑object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig toeneemt met de bestandsgrootte. Wanneer u een online video toevoegt, worden alleen een link en een miniatuurafbeelding ingesloten, waardoor de toename kleiner is.

**Kan ik de video in een bestaande VideoFrame vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video‑inhoud](https://reference.aspose.com/slides/nl/net/aspose.slides/videoframe/embeddedvideo/) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay‑out.

**Kan het inhoudstype (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/nl/net/aspose.slides/video/contenttype/) dat u kunt uitlezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.