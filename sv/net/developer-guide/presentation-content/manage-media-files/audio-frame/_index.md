---
title: Hantera ljudramar i presentationer i .NET
linktitle: Ljudram
type: docs
weight: 10
url: /sv/net/audio-frame/
keywords:
- ljud
- ljudram
- miniatyrbild
- lägg till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- .NET
- C#
- Aspose.Slides
description: "Skapa och kontrollera ljudramar i Aspose.Slides för .NET—C#-exempel för att bädda in, beskära, loopa och konfigurera uppspelning i PPT-, PPTX- och ODP-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med ljudramar i Aspose.Slides. Den visar hur man lägger till inbäddat ljud i bilder, anpassar ljudramens miniatyr, konfigurerar uppspelningsalternativ såsom volym, loopning, gömning, beskärning och toningsvaraktigheter, samt extraherar ljud som används i bildspelsövergångar.

## **Skapa ljudramar**

Aspose.Slides för .NET låter dig lägga till ljudfiler i bilder. Ljudfilerna bäddas in i bilder som ljudramar. 

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)klassen.  
2. Hämta en bilds referens via dess index.  
3. Läs in ljudfilströmmen som du vill bädda in i bilden.  
4. Lägg till den inbäddade ljudramen (som innehåller ljudfilen) till bilden.  
5. Ställ in [PlayMode](https://reference.aspose.com/slides/sv/net/aspose.slides/audioplaymodepreset) och `Volume` som exponeras av [IAudioFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe)-objektet.  
6. Spara den ändrade presentationen.

Den här C#-koden visar hur du lägger till en inbäddad ljudram i en bild:

```c#
// Skapar en presentationsklass som representerar en presentationsfil
using (Presentation pres = new Presentation())
{
    // Hämtar den första bilden
    ISlide sld = pres.Slides[0];
    
    // Laddar wav-ljudfilen till en ström
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Lägger till ljudramen
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Ställer in uppspelningsläget och volymen för ljudet
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Skriver PowerPoint-filen till disk
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Ändra ljudramens miniatyr**

När du lägger till en ljudfil i en presentation visas ljudet som en ram med en standardstandardbild (se bilden i avsnittet nedan). Du kan ändra ljudramens miniatyr (ange din föredragna bild).

Den här C#-koden visar hur du ändrar en ljudramens miniatyr eller förhandsgranskningsbild:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Lägger till en ljudram på bilden med en angiven position och storlek.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Lägger till en bild i presentationens resurser.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Ställer in bilden för ljudramen.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//Sparar den ändrade presentationen till disk
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Ändra ljuduppspelningsalternativ**

Aspose.Slides för .NET låter dig ändra alternativ som styr ett ljuds uppspelning eller egenskaper. Till exempel kan du justera ett ljuds volym, ställa in att ljudet spelas i loop, eller till och med dölja ljudikonen.

Audio Options-fönstret i Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** som motsvarar Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe) egenskaper:

- **Start**‑rullgardinsmenyn motsvarar egenskapen [AudioFrame.PlayMode](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/properties/playmode).  
- **Volume** motsvarar egenskapen [AudioFrame.Volume](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/properties/volume).  
- **Play Across Slides** motsvarar egenskapen [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/properties/playacrossslides).  
- **Loop until Stopped** motsvarar egenskapen [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/properties/playloopmode).  
- **Hide During Show** motsvarar egenskapen [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/properties/hideatshowing).  
- **Rewind after Playing** motsvarar egenskapen [AudioFrame.RewindAudio](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/properties/rewindaudio).

PowerPoint **Editing**-alternativ som motsvarar Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe) egenskaper:

- **Fade In** motsvarar egenskapen [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/fadeinduration/).  
- **Fade Out** motsvarar egenskapen [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/fadeoutduration/).  
- **Trim Audio Start Time** motsvarar egenskapen [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/trimfromstart/).  
- **Trim Audio End Time** värdet är ljudets varaktighet minus värdet för [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/trimfromend/).

PowerPoint **Volume control** på ljudkontrollpanelen motsvarar egenskapen [AudioFrame.VolumeValue](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/volumevalue/). Den låter dig ändra ljudvolymen i procent.

Så här ändrar du ljuduppspelningsalternativen:

1. [Skapa](#create-audio-frame) eller hämta ljudramen.  
2. Ställ in nya värden för de Audio Frame‑egenskaper du vill justera.  
3. Spara den ändrade PowerPoint‑filen.

Den här C#-koden demonstrerar en operation där ett ljuds alternativ justeras:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Hämtar AudioFrame-formen
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Ställer in uppspelningsläget till att spela vid klick
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Ställer in volymen till Låg
    audioFrame.Volume = AudioVolumeMode.Low;

    // Ställer in ljudet att spela över bildspel
    audioFrame.PlayAcrossSlides = true;

    // Inaktiverar loop för ljudet
    audioFrame.PlayLoopMode = false;

    // Dölj AudioFrame under bildspelet
    audioFrame.HideAtShowing = true;

    // Spolar tillbaka ljudet till start efter uppspelning
    audioFrame.RewindAudio = true;

    // Sparar PowerPoint-filen till disk
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Detta C#‑exempel visar hur man lägger till en ny ljudram med inbäddat ljud, beskär den och ställer in toningsvaraktigheterna:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Ställer in beskärningens startoffset till 1,5 sekunder
    audioFrame.TrimFromStart = 1500f;
    // Ställer in beskärningens slutoffset till 2 sekunder
    audioFrame.TrimFromEnd = 2000f;

    // Ställer in fade-in-varaktigheten till 200 ms
    audioFrame.FadeInDuration = 200f;
    // Ställer in fade-out-varaktigheten till 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

Följande kodexempel visar hur du hämtar en ljudram med inbäddat ljud och sätter dess volym till 85 %:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Hämtar en ljudram-form
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Ställer in ljudvolymen till 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Hantera ljudundertexter**

Aspose.Slides låter dig lägga till stängda undertexter till en ljudram via egenskapen [CaptionTracks](https://reference.aspose.com/slides/sv/net/aspose.slides/iaudioframe/captiontracks/). Denna egenskap returnerar en [ICaptionsCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/icaptionscollection/), som låter dig lägga till WebVTT‑undertextspår, iterera genom befintliga spår och ta bort dem vid behov.

### **Lägg till ljudundertexter**

Använd egenskapen [CaptionTracks](https://reference.aspose.com/slides/sv/net/aspose.slides/iaudioframe/captiontracks/) för att bifoga ett eller flera undertextspår till en ljudram. I följande exempel läggs en ljudfil till en bild och sedan laddas ett nytt undertextspår från en `.vtt`‑fil.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Lägg till ett nytt undertextspår från en WebVTT-fil.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

### **Extrahera ljudundertexter**

Du kan iterera genom undertextspåren som är kopplade till en ljudram och spara dem som `.vtt`‑filer. Varje undertextspår exponerar sin binära data och unika identifierare, som kan användas vid export av undertexter.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // Spara undertextspåret som en .vtt-fil.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

### **Ta bort ljudundertexter**

För att ta bort undertexter från en ljudram, använd metoderna som tillhandahålls av [ICaptionsCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/icaptionscollection/), såsom [Clear](https://reference.aspose.com/slides/sv/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/sv/net/aspose.slides/icaptionscollection/remove/), eller [RemoveAt](https://reference.aspose.com/slides/sv/net/aspose.slides/icaptionscollection/removeat/). Följande exempel tar bort alla undertextspår från en ljudram.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Ta bort alla undertextspår från ljudramen.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Extrahera ljud**

Aspose.Slides för .NET låter dig extrahera ljudet som används i bildspelsövergångar. Till exempel kan du extrahera ljudet som används i en specifik bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) och läs in presentationen som innehåller ljudet.  
2. Hämta den aktuella bildens referens via dess index.  
3. Åtkomst till bildspelsövergångarna för bilden.  
4. Extrahera ljudet som byte‑data.

Den här C#‑koden visar hur du extraherar ljudet som används i en bild:

```c#
string presName = "AudioSlide.pptx";

// Skapar en Presentation-klass som representerar en presentationsfil
Presentation pres = new Presentation(presName);

// Åtkomst till bilden
ISlide slide = pres.Slides[0];

// Hämtar bildspelsövergångseffekterna för bilden
ISlideShowTransition transition = slide.SlideShowTransition;

//Extraherar ljudet i en byte-array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**Kan jag återanvända samma ljudresurs i flera bilder utan att öka filstorleken?**

Ja. Lägg till ljudet en gång i presentationens delade [audio collection](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/audios/) och skapa ytterligare ljudramar som refererar till den befintliga resursen. Detta undviker duplicering av mediadata och håller presentationens storlek under kontroll.

**Kan jag ersätta ljudet i en befintlig ljudram utan att återskapa formen?**

Ja. För ett länkat ljud, uppdatera [link path](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/linkpathlong/) så att det pekar på den nya filen. För ett inbäddat ljud, byt ut objektet [embedded audio](https://reference.aspose.com/slides/sv/net/aspose.slides/audioframe/embeddedaudio/) mot ett annat från presentationens [audio collection](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/audios/). Ramens formatering och de flesta uppspelningsinställningar förblir intakta.

**Ändrar beskärning den underliggande ljuddata som lagras i presentationen?**

Nej. Beskärning justerar bara uppspelningsgränserna. De ursprungliga ljudbytena förblir orörda och är åtkomliga via det inbäddade ljudet eller presentationens ljudsamling.