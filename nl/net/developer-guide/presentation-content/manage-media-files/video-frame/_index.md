---
title: Beheer videoframes in presentaties in .NET
linktitle: Video‑frame
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
description: "Leer hoe je programmatisch video‑frames kunt toevoegen en extraheren in PowerPoint‑ en OpenDocument‑dia's met Aspose.Slides voor .NET. Snelle handleiding."
---
## **Inleiding**

Video's kunnen helpen ideeën uit te leggen en een publiek te betrekken. Aspose.Slides voor .NET stelt je in staat videoframes toe te voegen aan dia's, afspeelinstellingen aan te passen, ondertitels te beheren en ingesloten videogegevens te extraheren.

PowerPoint ondersteunt lokale video’s en koppelingen naar online‑video’s, zoals YouTube‑video’s.

Om videogegevens en videoframes te vertegenwoordigen, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) interface, de [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) interface en andere relevante types.

## **Een ingesloten videoframe aanmaken**

Als het videobestand dat je aan je dia wilt toevoegen lokaal is opgeslagen, kun je een videoframe aanmaken om de video in je presentatie in te sluiten.

Dit voorbeeld sluit een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en afmetingen worden uitgedrukt in points. De stream blijft open tot het opslaan voltooid is omdat [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) het vergrendeld houdt terwijl de presentatie het gebruikt.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Je kunt ook een lokaal videopad rechtstreeks doorgeven aan [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Dit voorbeeld sluit de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven tot de presentatie is opgeslagen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Video‑volume nauwkeurig instellen**

In Aspose.Slides voor .NET 26.11 of later stelt [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) een zwevend‑komma percentage in van 0 tot 100 in. Gebruik het wanneer de [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) presets te grof zijn. Bijvoorbeeld, `75.5f` vraagt om 75,5 % volume.

Dit voorbeeld vereist [Aspose.Slides for .NET](/slides/nl/net/installation/) 26.11 of later en een lokale `video.mp4`. Het sluit de video in, initialiseert expliciet het afspelen, slaat de presentatie op en leest het opgeslagen percentage terug.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

Valideer de invoer zelf; vertrouw niet op de setter om waarden buiten het gedocumenteerde bereik te weigeren. De Low, Medium en Loud presets komen overeen met 20, 50 en 80 in 26.11. Het instellen van een preset kan een eerder percentage vervangen, dus wijs het percentage als laatste toe wanneer je een exacte waarde nodig hebt. Gebruik [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) voor de expliciete dempinstelling; een numerieke nul en de preset‑enum zijn geen uitwisselbare toestanden.

Stel expliciet [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) in wanneer je een gekoppelde video configureert, en houd het mediabestand beschikbaar voor de kijker. Opslaan en opnieuw openen verifieert de opgeslagen instelling; daadwerkelijke weergave en luidheid hangen af van de presentatiespeler en diens audio‑instellingen.

## **Een videoframe met video van een webbron aanmaken**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online‑video’s in presentaties. Je kunt een videoframe maken dat koppelt naar een online video, zoals een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videolink en miniatuur toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) instelling vraagt om automatische weergave. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatieweergave moet eveneens online‑videoweergave ondersteunen.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Een video afspelen in volledig‑schermmodus**

In een trainingspresentatie kun je een software‑demo in volledig‑schermmodus afspelen zodat het publiek de details kan zien. Stel [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) in op `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, vindt de eerste [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) op de eerste dia, en schakelt volledig‑schermafspelen in. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

Volledig‑schermafspelen bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan bepaalt [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) of deze automatisch of bij klik start, en [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) of hij herhaalt. Om het start‑gedrag te kiezen, stel je de afspeelmodus in op [VideoPlayModePreset.Auto of VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lussinstellingen.

## **Een video terugspoelen na afspelen**

In een trainingspresentatie maakt het terugspoelen van een demovideo naar het begin het klaar voor de presentator om opnieuw af te spelen. Stel [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) in op `true` om de video na afloop van het afspelen naar het begin terug te brengen.

Dit voorbeeld opent een presentatie, vindt de eerste [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) op de eerste dia, en schakelt terugspoelen in. Het schakelt lussen uit zodat het afspelen kan eindigen en stelt afspelen in op starten bij klik. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Terugspoelen brengt de video terug naar het begin zonder opnieuw te starten. Daarentegen herhaalt het inschakelen van [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) het afspelen automatisch. Houd lussen uitgeschakeld wanneer je wilt dat de video eindigt en klaar blijft om opnieuw afgespeeld te worden. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) regelt onafhankelijk automatisch of bij klik starten; dit voorbeeld gebruikt [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen begint. Stel de afspeelmodus in na de lusinstelling, zoals in het voorbeeld getoond. Terugspoelen werkt onafhankelijk van [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Een videoframe bijsnijden**

Gebruik [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) en [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) om het begin‑ of eindgedeelte van een video over te slaan tijdens het afspelen. Beide waarden zijn in milliseconden. Bijsnijden wijzigt afspeelinstellingen zonder de ingesloten videogegevens aan te passen.

**Triminstellingen instellen**

Dit voorbeeld sluit een lokale video in en slaat de eerste 2,5 seconde en de laatste seconde over tijdens het afspelen. Gebruik een video die langer is dan 3,5 seconde zodat er een afspeelbaar segment overblijft.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Triminstellingen lezen**

Dit voorbeeld drukt de trim‑waarden van het eerste videoframe op de eerste dia af in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen videoframe heeft, wordt er niets afgedrukt. Het voorgaande voorbeeld levert waarden van 2500 en 1000 op.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Videocaptions beheren**

Aspose.Slides stelt je in staat gesloten captions voor videoframes in PowerPoint‑presentaties te beheren. Captions worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de eigenschap [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

### **Captions toevoegen aan een videoframe**

Dit voorbeeld sluit een lokale video in en voegt een WebVTT‑captiontrack met de naam English toe. De caption‑tijdstempels moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de captions.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

De [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) interface biedt ook een overload waarmee je captions uit een stream kunt toevoegen.

### **Captions extraheren uit een videoframe**

Dit voorbeeld slaat alle caption‑tracks van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Sequentiële nummers houden de uitvoerbestanden uniek. De console rapporteert het aantal geëxtraheerde tracks. De presentatie moet minstens één dia bevatten.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Elk [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) object biedt de caption‑identifier, het label, binaire data en de caption‑tekst als een UTF‑8‑string.

### **Captions verwijderen uit een videoframe**

Dit voorbeeld verwijdert alle captions van het videoframe op de eerste shape‑positie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en shape bestaan en dat de shape een videoframe is.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Als je slechts één caption‑track wilt verwijderen, gebruik dan de [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) of [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) methoden in plaats van [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

### **Videocaptions zoeken**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) retourneert de complete WebVTT‑track, inclusief header, timing‑regels en caption‑tekst. Om een uitgesproken frase en de bijbehorende tijdstempel te vinden, lees je de cues in het geheugen. Bijvoorbeeld, een Engelse track op dia 2 kan de volgende tekst bevatten:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Het voorbeeld bezoekt elke dia en leest de tracks van de bovenliggende videoframes via [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). In een platte‑tekst cue bevat de timing‑regel `-->` en een lege regel beëindigt de cue. Wanneer de caption‑tekst “café” bevat, drukt het voorbeeld het diapad, track‑label, originele timing‑regel en volledige caption af.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

Zoeken naar “café” levert één overeenkomst op voor de voorbeeld‑track. De header en de timing‑instelling staan buiten de cue‑tekst.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Video extraheren uit een dia**

Naast het toevoegen van video’s aan dia’s, maakt Aspose.Slides het mogelijk video’s die in presentaties zijn ingesloten te extraheren.

Dit voorbeeld extraheert ingesloten video’s van elke dia naar afzonderlijke, genummerde binaire bestanden. Gekoppelde video’s worden overgeslagen omdat ze geen ingesloten data hebben. De console drukt het MIME‑type van elke video en het totale aantal af. De uitvoer gebruikt de generieke `.bin` extensie; wijzig deze indien nodig zodat hij overeenkomt met het gerapporteerde mediatype.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**Welke afspeelparameters van een video kunnen voor een videoframe gewijzigd worden?**

Je kunt de [afspeelmodus](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (auto of bij klik) en [lusinstelling](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) beheren. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de grootte van het PPTX‑bestand?**

Ja. Wanneer je een lokale video insluit, wordt de binaire data in het document opgenomen, waardoor de presentatiegrootte evenredig groeit met de bestandsgrootte. Wanneer je linkt naar een online video en een miniatuur toevoegt, slaat de presentatie de link en preview‑afbeelding op in plaats van de video‑data, waardoor de omvangstoename doorgaans kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en grootte te wijzigen?**

Ja. Je kunt de [video‑inhoud](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) binnen het frame verwisselen terwijl je de geometrie van de shape behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content‑type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) dat je kunt lezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.