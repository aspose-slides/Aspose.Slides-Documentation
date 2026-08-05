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
description: "Leer hoe u programmatisch video-frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument-slides met Aspose.Slides voor .NET. Snelle how-to gids."
---
## **Inleiding**

Een goed gepositioneerde video in een presentatie kan uw boodschap overtuigender maken en de betrokkenheid van uw publiek verhogen. 

PowerPoint stelt u in staat om video's op twee manieren aan een dia in een presentatie toe te voegen:

* Voeg een lokale video toe of embedde deze (opgeslagen op uw computer)
* Voeg een online video toe (van een webbron zoals YouTube).

Om u in staat te stellen video's (video‑objecten) aan een presentatie toe te voegen, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideo/) interface, de [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) interface en andere relevante types. 

## **Maak een ingesloten video‑frame**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een video‑frame maken om de video in uw presentatie te embedden. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Haal een referentie naar een dia op via de index. 
3. Voeg een [IVideo](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideo/) object toe en geef het pad naar het videobestand door om de video in de presentatie te embedden. 
4. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) object toe om een frame voor de video te maken.  
5. Sla de gewijzigde presentatie op. 

Deze C#‑code toont hoe u een lokaal opgeslagen video aan een presentatie toevoegt:

```c#
 // Maakt een instantie van de Presentation-klasse
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
U kunt ook een video toevoegen door het bestandspad direct door te geven aan de [AddVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addvideoframe/) methode:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Maak een video‑frame met video van een webbron**
Nieuwere versies van Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunen online video’s in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze via de weblink aan uw presentatie toevoegen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse
2. Haal een referentie naar een dia op via de index. 
3. Voeg een [IVideo](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideo/) object toe en geef de link naar de video door.
4. Stel een miniatuurafbeelding in voor het video‑frame. 
5. Sla de presentatie op. 

Deze C#‑code toont hoe u een video van het web aan een dia in een PowerPoint‑presentatie toevoegt:

```c#
public static void Run()
{
    // Maakt een Presentation-object aan dat een presentatiebestand vertegenwoordigt
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

## **Een video‑frame trimmen**

Met Aspose.Slides kunt u bepalen welk deel van een video wordt afgespeeld door de waarden trim‑from‑start en trim‑from‑end in te stellen via [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/trimfromstart/) en [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/trimfromend/). Beide waarden worden gespecificeerd in milliseconden en bepalen hoeveel tijd er respectievelijk aan het begin en einde van de video wordt overgeslagen. Deze instellingen wijzigen de afspeelinstellingen van de video in de presentatie; ze knippen of wijzigen de binaire gegevens van de ingesloten video niet.

**Triminstellingen instellen**

Om een video‑frame te maken en de triminstellingen in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
2. Voeg een [IVideo](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideo/) object toe aan de presentatie.
3. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) object toe aan een dia.
4. Stel de trim‑from‑start en trim‑from‑end waarden in via [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/trimfromstart/) en [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/trimfromend/).
5. Sla de gewijzigde presentatie op.

De volgende code‑voorbeeld slaat de eerste 2,5 seconde en de laatste seconde van een ingesloten video over tijdens het afspelen:

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

**Triminstellingen lezen**

Om bestaande triminstellingen te inspecteren, laadt u een presentatie, vindt u een [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) object onder de vormen op de eerste dia en leest u de waarden via [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/trimfromstart/) en [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/trimfromend/).

Het volgende code‑voorbeeld vindt het eerste video‑frame op de eerste dia en rapporteert de triminstellingen in milliseconden:

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

## **Video‑bijschriften beheren**

Met Aspose.Slides kunt u ondertitels voor video‑frames in PowerPoint‑presentaties beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn beschikbaar via de eigenschap [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/captiontracks/).

**Ondertitels aan een video‑frame toevoegen**

Om ondertitels aan een video‑frame toe te voegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
2. Voeg een video toe aan de presentatie.
3. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) object toe aan een dia.
4. Gebruik de [CaptionTracks](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/captiontracks/) collectie om een WebVTT‑ondertiteltrack toe te voegen.
5. Sla de gewijzigde presentatie op.

De volgende code toont hoe u ondertitels aan een video‑frame toevoegt:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Voegt een nieuw ondertiteltrack toe vanuit een WebVTT-bestand.
    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

De [ICaptionsCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/icaptionscollection/) interface biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

**Ondertitels uit een video‑frame extraheren**

Om ondertitels uit een video‑frame te extraheren:

1. Laad de presentatie die de video bevat.
2. Zoek het doel-[IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) object.
3. Itereer door de [CaptionTracks](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/captiontracks/) collectie.
4. Sla elke ondertiteltrack op in een `.vtt`‑bestand.

De volgende code toont hoe u ondertitels uit een video‑frame kunt extraheren:

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
                // Slaat de ondertiteltrack op naar een WebVTT-bestand.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Elk [ICaptions](https://reference.aspose.com/slides/nl/net/aspose.slides/icaptions/) object geeft de ondertitel‑identificator, label, binaire gegevens en ondertiteltekst weer als een UTF‑8‑string.

**Ondertitels uit een video‑frame verwijderen**

Om ondertitels uit een video‑frame te verwijderen:

1. Laad de presentatie die de video bevat.
2. Haal het doel-[IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) object op.
3. Verwijder ondertitel‑tracks uit de [CaptionTracks](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/captiontracks/) collectie.
4. Sla de gewijzigde presentatie op.

De volgende code toont hoe u alle ondertitels uit een video‑frame verwijdert:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Verwijdert alle ondertitels van het video-frame.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de methoden [Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/captionscollection/remove/) of [RemoveAt](https://reference.aspose.com/slides/nl/net/aspose.slides/captionscollection/removeat/) in plaats van [Clear](https://reference.aspose.com/slides/nl/net/aspose.slides/captionscollection/clear/).

## **Video uit een dia extraheren**
Naast het toevoegen van video's aan dia's, stelt Aspose.Slides u in staat om video's die in presentaties zijn ingesloten te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse om de presentatie die de video bevat te laden. 
2. Itereer door alle [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide) objecten.
3. Itereer door alle [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape) objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/videoframe) te vinden. 
4. Sla de video op schijf.

Deze C#‑code toont hoe u de video van een presentatiedia kunt extraheren:

```c#
// Maakt een Presentation-object aan dat een presentiebestand representeert
Presentation presentation = new Presentation("Video.pptx");

// Doorloopt de dia's
foreach (ISlide slide in presentation.Slides)
{
    // Doorloopt de vormen
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Slaat de video op schijf zodra een VideoFrame met video gevonden wordt
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

**Welke video‑afspeelparameters kunnen worden aangepast voor een VideoFrame?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/nl/net/aspose.slides/videoframe/playmode/) (automatisch of bij klikken) en [herhaling](https://reference.aspose.com/slides/nl/net/aspose.slides/videoframe/playloopmode/) controleren. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video embedt, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig met de bestandsgrootte toeneemt. Wanneer u een online video toevoegt, worden een link en een miniatuurafbeelding ingesloten, waardoor de grootte‑toename kleiner is.

**Kan ik de video in een bestaand VideoFrame vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [videoinhoud](https://reference.aspose.com/slides/nl/net/aspose.slides/videoframe/embeddedvideo/) binnen het frame vervangen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/nl/net/aspose.slides/video/contenttype/) dat u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.