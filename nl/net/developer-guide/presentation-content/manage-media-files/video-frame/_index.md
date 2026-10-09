---
title: Beheer video‑frames in presentaties in .NET
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
- video‑frame
- webbron
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u programmatisch video‑frames kunt toevoegen en extraheren in PowerPoint‑ en OpenDocument‑dia's met Aspose.Slides voor .NET. Snel overzichtsgids."
---
## **Introductie**

Video's kunnen helpen ideeën uit te leggen en een publiek te boeien. Aspose.Slides voor .NET stelt u in staat videoframes aan dia's toe te voegen, afspeelinstellingen aan te passen, ondertitels te beheren en ingesloten video‑gegevens te extraheren.

PowerPoint ondersteunt lokale video’s en koppelingen naar online video’s, zoals YouTube‑video’s.

Om video‑data en videoframes te vertegenwoordigen, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) interface, de [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) interface en andere relevante types.

## **Maak een ingesloten videoframe**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten.

Dit voorbeeld sluit een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en afmetingen zijn in points. De stroom blijft open tot het opslaan voltooid is omdat [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) deze vergrendeld terwijl de presentatie deze gebruikt.

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

U kunt ook een lokaal video‑pad rechtstreeks doorgeven aan [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Dit voorbeeld sluit de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven tot de presentatie is opgeslagen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Maak een videoframe met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video’s in presentaties. U kunt een videoframe maken dat naar een online video linkt, bijvoorbeeld een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videokoppeling en miniatuur toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De instelling [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) vraagt om automatische weergave. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatieviewer moet ook online video‑afspelen ondersteunen.

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

## **Speel een video af in volledig scherm**

In een trainingspresentatie kunt u een software‑demonstratie in volledig scherm afspelen zodat het publiek de details kan zien. Stel [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) in op `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, zoekt de eerste [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) op de eerste dia, en schakelt afspelen in volledig scherm in. De invoerpresentatie moet ten minste één dia bevatten met een bestaande videoframe op de eerste dia.

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

Afspelen in volledig scherm bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan bepaalt [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) of deze automatisch of bij klikken start, en [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) bepaalt of deze wordt herhaald. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset.Auto of VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lusinstellingen.

## **Terugspoelen van een video na afspelen**

In een trainingspresentatie maakt het terugbrengen van een demonstratie‑video naar het begin deze klaar voor de presentator om opnieuw af te spelen. Stel [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) in op `true` om de video na het afspelen terug te zetten naar het begin.

Dit voorbeeld opent een presentatie, zoekt de eerste [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) op de eerste dia, en schakelt terugspoelen in. Het schakelt herhalen uit zodat het afspelen kan eindigen en stelt het afspelen in om bij klikken te starten. De invoerpresentatie moet ten minste één dia bevatten met een bestaande videoframe op de eerste dia.

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

Terugspoelen zet de video terug naar het begin zonder deze opnieuw te starten. Daarentegen zorgt het inschakelen van [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) voor automatische herhaling van het afspelen. Houd herhalen uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft om opnieuw af te spelen. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) bepaalt onafhankelijk of het automatisch of bij klikken start; dit voorbeeld gebruikt [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen begint. Stel de afspeelmodus in na de lusinstelling, zoals in het voorbeeld weergegeven. Terugspoelen werkt onafhankelijk van [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Een videoframe inkorten**

Gebruik [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) en [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) om een deel van het begin of het einde van een video over te slaan tijdens het afspelen. Beide waarden zijn in milliseconden. Inkorten wijzigt de afspeelinstellingen zonder de ingesloten video‑data aan te passen.

**Stel Trim‑instellingen in**

Dit voorbeeld sluit een lokale video in en slaat de eerste 2,5 seconden en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconden zodat er een afspeelbaar segment overblijft.

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

**Lees Trim‑instellingen**

Dit voorbeeld drukt de inkortwaarden van de eerste videoframe op de eerste dia af in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen videoframe heeft, wordt er niets afgedrukt. Het voorgaande voorbeeld levert de waarden 2500 en 1000 op.

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

## **Beheer videobijschriften**

Aspose.Slides stelt u in staat gesloten ondertitels voor videoframes in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de eigenschap [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Voeg ondertitels toe aan een videoframe**

Dit voorbeeld sluit een lokale video in en voegt een WebVTT‑ondertitelspoor toe met het label English. De tijdstempels van de ondertitels moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de ondertitels.

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

De interface [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

**Extraheer ondertitels uit een videoframe**

Dit voorbeeld slaat alle ondertitelsporen van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Opeenvolgende nummers houden de uitvoerbestanden gescheiden. De console meldt het aantal geëxtraheerde sporen. De presentatie moet minstens één dia bevatten.

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

Elk [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) object biedt de ondertitel‑identifier, het label, binaire gegevens en de ondertiteltekst als een UTF‑8‑string.

**Verwijder ondertitels uit een videoframe**

Dit voorbeeld verwijdert alle ondertitels van de videoframe op de eerste vormpositie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een videoframe is.

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

Als u slechts één ondertitelspoor wilt verwijderen, gebruik dan de methoden [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) of [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) in plaats van [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Video extraheren van een dia**

Naast het toevoegen van video’s aan dia’s, maakt Aspose.Slides het mogelijk video’s die in presentaties zijn ingesloten te extraheren.

Dit voorbeeld extrahert ingesloten video’s van elke dia naar afzonderlijke, genummerde binaire bestanden. Gelinkte video’s worden overgeslagen omdat ze geen ingesloten data hebben. De console drukt het MIME‑type van elke video en het totale aantal af. De output gebruikt de algemene extensie `.bin`; wijzig deze indien nodig om overeen te komen met het gerapporteerde mediatype.

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

**Welke video‑afspeelparameters kunnen voor een videoframe worden aangepast?**

U kunt de [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (auto of bij klikken) en [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) regelen. Deze opties zijn beschikbaar via de eigenschappen van het object [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Heeft het toevoegen van een video invloed op de bestandsgrootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig met de bestandsgrootte toeneemt. Wanneer u naar een online video linkt en een miniatuur toevoegt, slaat de presentatie de koppeling en de voorbeeldafbeelding op in plaats van de videogegevens, waardoor de grootte‑toename gewoonlijk kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en afmetingen te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) binnen het frame vervangen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario om media in een bestaande lay-out bij te werken.

**Kan het contenttype (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) dat u kunt uitlezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.