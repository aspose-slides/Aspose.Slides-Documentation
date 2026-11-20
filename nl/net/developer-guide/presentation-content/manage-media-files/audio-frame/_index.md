---
title: Audioframes beheren in presentaties in .NET
linktitle: Audioframe
type: docs
weight: 10
url: /nl/net/audio-frame/
keywords:
- audio
- audioframe
- miniatuur
- audio toevoegen
- audio‑eigenschappen
- audio‑opties
- audio extraheren
- .NET
- C#
- Aspose.Slides
description: "Audio insluiten in dia's, het audio‑icoon wijzigen, afspelen configureren, WebVTT‑bijschriften beheren en geluiden van dia‑overgangen extraheren met Aspose.Slides for .NET."
---
## **Overzicht**

Een audioframe stelt u in staat een geluid af te spelen op een dia. Met Aspose.Slides for .NET kunt u een audiobestand invoegen, de afbeelding kiezen die het voorstelt, de weergave aanpassen en bijschriften toevoegen. U kunt ook een geluid ophalen dat aan een dia‑overgang is toegewezen.

## **Audioframes maken**

Gebruik [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) om een lokaal audiobestand in te voegen op de eerste dia. De eerste twee coördinaten positioneren het frame op de dia, en de volgende twee waarden bepalen de breedte en hoogte, allemaal in punten. Dit voorbeeld stelt [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) in om het fragment automatisch te starten en [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) op de harde voorinstelling.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **Miniatuur van het audioframe wijzigen**

Standaard toont een audioframe een luidsprekerpictogram. Om een aangepaste miniatuur weer te geven, voegt u een afbeelding toe aan de presentatie met [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) en wijst u deze toe aan de eigenschap [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) van het frame. Het voorbeeld gebruikt een JPEG als miniatuur voor een ingebed audiobestand.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **Audio‑afspeelopties wijzigen**

De **Audio‑opties**‑besturingen van PowerPoint bepalen wanneer een fragment start, hoe hard het klinkt en hoe het zich gedraagt tijdens een diavoorstelling.

![PowerPoint‑audio‑optiebeheerelementen voor een audioframe](audio_frame_0.png)

| PowerPoint‑besturing | Aspose.Slides‑eigenschap |
| --- | --- |
| Start | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Volumepreset | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Afspelen over dia's | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Lus tot gestopt | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Verbergen tijdens voorstelling | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Terugspoelen na afspelen | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Invloeien | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Uivloeien | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Audio‑begintijd trimmen | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Audio‑eindtijd trimmen | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Volumeschuifregelaar | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

Het voorbeeld zoekt het eerste audioframe op de eerste dia, stelt [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) in om de afspeling te starten bij een klik, en kiest de lage volumepreset. Het fragment gaat door over dia's met uitgeschakelde lus. Het pictogram blijft verborgen tijdens de voorstelling, en het fragment spoelt terug na het afspelen.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

Voor een fragment langer dan 3,5 seconden slaat dit voorbeeld de eerste 1,5 seconde en de laatste 2 seconden over. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) meet de duur die aan het einde van het fragment moet worden weggelaten. Om de eindtijd te krijgen die in PowerPoint wordt weergegeven, trekt u die offset af van de volledige fragmentduur. Het bijgesneden fragment vloeit 200 ms in en vloeit 500 ms uit. Alle vier eigenschappen nemen waarden in milliseconden.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

Om het afspeelvolume op een specifiek percentage in te stellen, gebruikt u [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). Dit voorbeeld stelt het eerste audioframe op de eerste dia in op 85 %.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **Audio‑bijschriften beheren**

Elk audioframe heeft een [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/)‑collectie. Gebruik deze om WebVTT‑bijschriften aan het fragment toe te voegen, bestaande tracks te exporteren of te verwijderen.

### **Audio‑bijschriften toevoegen**

Het voorbeeld voegt een audiobestand in op de eerste dia en gebruikt [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) om een lokale WebVTT‑track toe te voegen. Het eerste argument levert het track‑label, en het tweede identificeert het bestand dat de getimede bijschriften bevat.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **Audio‑bijschriften exporteren**

Dit voorbeeld exporteert elke bijschrifttrack die aan een audioframe op de eerste dia is gekoppeld. Het schrijft de [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) van de track naar een WebVTT‑bestand en gebruikt de [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) als bestandsnaam zodat elke track een afzonderlijke output heeft.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **Audio‑bijschriften verwijderen**

Gebruik [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) of [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) om een individuele track te verwijderen. Het voorbeeld gebruikt [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) om alle bijschriften van het eerste audioframe op de eerste dia te verwijderen terwijl het fragment behouden blijft.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **Een regel in audio‑bijschriften vinden**

Om een regel in de audio‑bijschriften op de eerste dia te vinden, leest u elke track's [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) in het geheugen. In een platte‑tekst WebVTT‑cue bevat de timelijn `-->`, de bijschriftregels volgen deze, en een lege regel beëindigt de cue. Dit voorbeeld print het track‑label en elke bijschriftregel die “café” bevat.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **Audio extraheren**

Een dia‑overgang kan een eigen geluid hebben. Om dit op te halen, leest u de eigenschap [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) van de overgang. Het voorbeeld krijgt toegang tot de [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) van het geluid en toont de grootte in bytes. Als de eerste dia geen overgangsgeluid heeft, wordt in plaats daarvan een bericht getoond.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **FAQ**

**Kan ik hetzelfde audiobestand op meerdere dia's hergebruiken zonder het te dupliceren?**

Ja. Voeg het fragment één keer toe aan de [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) van de presentatie en geef hetzelfde audio‑object door aan [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) voor elke dia.

**Kan ik het geluid in een bestaand audioframe vervangen?**

Ja. Voor een gekoppeld geluid werkt u [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) bij zodat het naar het vervangende bestand wijst. Voor een ingebed geluid wijst u een ander fragment uit de audio‑collectie van de presentatie toe aan [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Beide benaderingen behouden het bestaande frame.

**Verandert trimmen de audiodata die in de presentatie is opgeslagen?**

Nee. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) en [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) stellen afspeelgrenzen in. U kunt nog steeds het volledige fragment ophalen via [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).