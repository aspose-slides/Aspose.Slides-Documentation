---
title: Hantera ljudramar i presentationer i .NET
linktitle: Ljudram
type: docs
weight: 10
url: /sv/net/audio-frame/
keywords:
- ljud
- ljudram
- miniatyr
- lägg till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- .NET
- C#
- Aspose.Slides
description: "Bädda in ljud i bilder, ändra ljudikonen, konfigurera uppspelning, hantera WebVTT-undertexter och extrahera bildövergångsljud med Aspose.Slides för .NET."
---
## **Översikt**

En ljudram låter dig spela ett ljud på en bild. Med Aspose.Slides för .NET kan du bädda in ett ljudklipp, välja bilden som representerar det, justera uppspelning och bifoga bildtexter. Du kan även hämta ett ljud som tilldelats en bildövergång.

## **Skapa ljudramar**

Använd [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) för att bädda in ett lokalt ljudklipp på den första bilden. De två första koordinaterna placerar ramen på bilden, och de nästa två värdena anger dess bredd och höjd, alla i punkter. Detta exempel sätter [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) för att starta klippet automatiskt och [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) till det höga förinställningen.

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

## **Ändra ljudramens miniatyrbild**

Som standard visar en ljudram en högtalarikon. För att visa en anpassad miniatyr, lägg till en bild i presentationen med [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) och tilldela den till ramens [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) egenskap. Exemplet använder en JPEG som miniatyr för ett inbäddat ljudklipp.

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

## **Ändra ljuduppspelningsalternativ**

PowerPoints **Audio Options**-kontroller bestämmer när ett klipp startar, hur högt det låter och hur det beter sig under en bildspelsvisning.

![PowerPoint Audio Options-kontroller för en ljudram](audio_frame_0.png)

| PowerPoint-kontroll | Aspose.Slides-egenskap |
| --- | --- |
| Start | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Volymförinställning | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Spela över bilder | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Loopa tills stoppad | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Dölj under visning | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Spola tillbaka efter uppspelning | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Tona in | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Tona ut | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Trimma ljudets starttid | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Trimma ljudets sluttid | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Volymreglage | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

Exemplet hittar den första ljudramen på den första bilden, sätter [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) för att starta uppspelning vid ett klick och väljer den låga volymförinställningen. Klippet fortsätter över bilder med loopning inaktiverad. Ikonen förblir dold under visningen, och klippet spolar tillbaka efter uppspelning.

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

För ett klipp längre än 3,5 sekunder hoppar detta exempel över de första 1,5 sekunderna och de sista 2 sekunderna. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) mäter varaktigheten som ska utelämnas från klippets slut. För att få sluttiden som visas i PowerPoint, subtrahera den förskjutningen från hela klippets varaktighet. Det trimmade klippet tonar in över 200 millisekunder och tonar ut över 500 millisekunder. Alla fyra egenskaper tar värden i millisekunder.

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

För att sätta uppspelningsvolymen till en specifik procentandel, använd [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). Detta exempel sätter den första ljudramen på den första bilden till 85%.

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

## **Hantera ljudtextning**

Varje ljudram har en [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) samling. Använd den för att bifoga WebVTT-textning till klippet, exportera befintliga spår eller ta bort dem.

### **Lägg till ljudtextning**

Exemplet bäddar in ett ljudklipp på den första bilden och använder [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) för att bifoga ett lokalt WebVTT-spår. Det första argumentet anger spårens etikett, och det andra identifierar filen som innehåller de tidsstämplade undertexterna.

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

### **Extrahera ljudtextning**

Detta exempel exporterar varje undertextspår som är bifogat en ljudram på den första bilden. Det skriver spårets [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) till en WebVTT‑fil och använder dess [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) som filnamn så att varje spår får en separat utdata.

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

### **Ta bort ljudtextning**

Använd [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) eller [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) för att ta bort ett enskilt spår. Exemplet använder [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) för att ta bort alla undertexter från den första ljudramen på den första bilden samtidigt som klippet bevaras.

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

### **Hitta en rad i ljudtextning**

För att hitta en rad i ljudtextning på den första bilden, läs varje spårs [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) i minnet. I en vanlig text WebVTT-cue innehåller tidslinjen `-->`, följt av undertextlinjerna, och en tom rad avslutar cue:n. Detta exempel skriver ut spårens etikett och varje undertextrad som innehåller “café”.

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

## **Extrahera ljud**

En bildövergång kan ha ett eget ljud. För att hämta det, läs övergångens [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) egenskap. Exemplet får åtkomst till ljudets [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) och skriver ut dess storlek i byte. Om den första bilden saknar övergångsljud, skriver det ut ett meddelande istället.

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

## **Vanliga frågor**

**Kan jag återanvända samma ljudklipp på flera bilder utan att duplicera det?**

Ja. Lägg till klippet en gång i presentationens [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) och skicka samma ljudobjekt till [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) för varje bild.

**Kan jag ersätta ljudet i en befintlig ljudram?**

Ja. För ett länkat ljud, uppdatera [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) så att det pekar på ersättningsfilen. För ett inbäddat ljud, tilldela ett annat klipp från presentationens ljudsamling till [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Båda tillvägagångssätten bevarar den befintliga ramen.

**Ändrar trimning ljuddata som lagras i presentationen?**

Nej. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) och [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) sätter uppspelningsgränser. Du kan fortfarande hämta hela klippet från [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).