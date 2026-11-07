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
description: "Leer video-frames programmatisch toe te voegen en te extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor .NET. Snelle how-to gids."
---
## **Inleiding**

Video's kunnen helpen ideeën uit te leggen en een publiek te boeien. Aspose.Slides for .NET stelt u in staat videoframes toe te voegen aan dia's, afspeelinstellingen aan te passen, ondertitels te beheren en ingesloten videogegevens te extraheren.

PowerPoint ondersteunt lokale video's en koppelingen naar online video's, zoals YouTube‑video's.

Om videogegevens en videoframes weer te geven, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) interface, de [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) interface en andere relevante types.

## **Maak een ingesloten videoframe**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten.

Dit voorbeeld sluit een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en -afmetingen zijn in points. De stream blijft open tot het opslaan klaar is omdat [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) het vergrendeld zolang de presentatie het gebruikt.

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

U kunt ook rechtstreeks een lokaal videopad doorgeven aan [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Dit voorbeeld sluit de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven tot de presentatie is opgeslagen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Stel videovolume nauwkeurig in**

In Aspose.Slides for .NET 26.11 of later, stelt [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) een zwevend‑kommagetal in als percentage van 0 tot 100. Gebruik dit wanneer de [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/)‑presets te grof zijn. Bijvoorbeeld, `75.5f` vraagt om 75,5 % volume.

Dit voorbeeld vereist [Aspose.Slides for .NET](/slides/nl/net/installation/) 26.11 of later en een lokale `video.mp4`. Het sluit de video in, initialiseert de afspeelinstelling expliciet, slaat de presentatie op en leest het opgeslagen percentage terug.

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

Valideer de invoer zelf; vertrouw niet op de setter om waarden buiten het gedocumenteerde bereik af te wijzen. De presets Low, Medium en Loud corresponderen met 20, 50 en 80 in 26.11. Het instellen van een preset kan een eerder percentage vervangen, dus wijs het percentage als laatste toe wanneer u een exacte waarde nodig heeft. Gebruik [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) voor de expliciete dempinstelling; een numerieke nul en de preset‑enum zijn geen uitwisselbare toestanden.

Stel expliciet [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) in bij het configureren van een gekoppelde video, en houd het mediabestand beschikbaar voor de kijker. Opslaan en opnieuw openen verifiëren de opgeslagen instelling; daadwerkelijke afspelen en luidheid hangen af van de presentatiespeler en diens audio‑instellingen.

## **Maak een videoframe met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video’s in presentaties. U kunt een videoframe maken dat linkt naar een online video, zoals een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videolink en miniatuur toe aan de eerste dia. Vervang de video‑identificator om een andere video te gebruiken. De [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/)‑instelling vraagt om automatisch afspelen. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatie‑viewer moet ook online video‑afspelen ondersteunen.

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

In een trainingspresentatie kunt u een softwares demonstratie afspelen in volledig‑scherm modus zodat het publiek de details kan zien. Stel [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) in op `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, zoekt het eerste [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) op de eerste dia, en schakelt volledig‑scherm afspelen in. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Volledig‑scherm afspelen bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan bepaalt [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) of deze automatisch of bij klikken start, en [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) of deze herhaalt. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset.Auto of VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en loop‑instellingen.

## **Spoel een video terug na afspelen**

In een trainingspresentatie maakt het terugbrengen van een demonstratie‑video naar het begin deze klaar voor de presentator om opnieuw af te spelen. Stel [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) in op `true` om de video na afloop van het afspelen naar het begin terug te brengen.

Dit voorbeeld opent een presentatie, zoekt het eerste [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) op de eerste dia, en schakelt terugspoelen in. Het schakelt looping uit zodat het afspelen kan eindigen en stelt afspelen in om bij klikken te starten. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Terugspoelen brengt de video naar het begin zonder deze opnieuw te starten. Daarentegen zorgt het inschakelen van [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) voor automatisch herhalen van het afspelen. Houd looping uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft om opnieuw afgespeeld te worden. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) bepaalt onafhankelijk automatisch of bij klikken starten; dit voorbeeld gebruikt [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen start. Stel de afspeelmodus in na de loop‑instelling, zoals in het voorbeeld getoond. Terugspoelen werkt onafhankelijk van [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Trim een videoframe**

Gebruik [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) en [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) om het begin of het einde van een video over te slaan tijdens het afspelen. Beide waarden zijn in milliseconden. Trimmen wijzigt de afspeelinstellingen zonder de ingesloten videogegevens aan te passen.

**Instellen trim‑instellingen**

Dit voorbeeld sluit een lokale video in en slaat de eerste 2,5 seconde en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconde zodat er een afspeelbaar segment overblijft.

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

**Lezen trim‑instellingen**

Dit voorbeeld drukt de trimwaarden van het eerste videoframe op de eerste dia af in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen videoframe heeft, wordt er niets afgedrukt. Het voorgaande voorbeeld levert waarden van 2500 en 1000 op.

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

## **Beheer video‑ondertitels**

Aspose.Slides stelt u in staat ondertitels voor videoframes in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de eigenschap [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Ondertitels toevoegen aan een videoframe**

Dit voorbeeld sluit een lokale video in en voegt een WebVTT‑ondertiteltrack toe met het label English. De ondertitel‑tijdstempels moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de ondertitels.

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

**Extracteer ondertitels uit een videoframe**

Dit voorbeeld slaat alle ondertiteltracks van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Sequentiële nummers houden de uitvoerbestanden gescheiden. De console rapporteert het aantal geëxtraheerde tracks. De presentatie moet minstens één dia bevatten.

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

Elk [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) object geeft de ondertitel‑identificator, het label, binaire gegevens en de ondertiteltekst als een UTF‑8‑string weer.

**Verwijder ondertitels van een videoframe**

Dit voorbeeld verwijdert alle ondertitels van het videoframe op de eerste vormpositie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een videoframe is.

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

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de methoden [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) of [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) in plaats van [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Extract video van een dia**

Naast het toevoegen van video’s aan dia’s, stelt Aspose.Slides u in staat video’s die in presentaties zijn ingesloten te extraheren.

Dit voorbeeld extraheert ingesloten video’s van elke dia naar afzonderlijke, genummerde binaire bestanden. Gekoppelde video’s worden overgeslagen omdat ze geen ingesloten gegevens hebben. De console drukt het MIME‑type van elke video en het totale aantal af. De output gebruikt de generieke `.bin`‑extensie; wijzig deze om te passen bij het gerapporteerde mediatype indien nodig.

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

**Welke videoweergave‑parameters kunnen worden gewijzigd voor een videoframe?**

U kunt de [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (auto of bij klikken) en het [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) regelen. Deze opties zijn beschikbaar via de eigenschappen van het object [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Heeft het toevoegen van een video invloed op de grootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens aan het document toegevoegd, waardoor de presentatiegrootte evenredig met de bestandsgrootte toeneemt. Wanneer u linkt naar een online video en een miniatuur toevoegt, slaat de presentatie de link en preview‑afbeelding op in plaats van de videogedata, waardoor de vergroting meestal kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) binnen het frame verwisselen terwijl de geometrie van de vorm behouden blijft; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) dat u kunt uitlezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.