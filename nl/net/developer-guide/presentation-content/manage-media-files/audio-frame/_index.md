---
title: Beheer audio‑frames in presentaties in .NET
linktitle: Audio‑frame
type: docs
weight: 10
url: /nl/net/audio-frame/
keywords:
- audio
- audio‑frame
- miniatuur
- audio toevoegen
- audio‑eigenschappen
- audio‑opties
- audio extraheren
- .NET
- C#
- Aspose.Slides
description: "Aanmaken en beheren van audio‑frames in Aspose.Slides voor .NET—C#‑voorbeelden om in te sluiten, te trimmen, te herhalen en de afspeelinstellingen te configureren in PPT-, PPTX- en ODP‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u audio‑frames kunt gebruiken in Aspose.Slides. Het toont hoe u ingesloten audio aan dia's kunt toevoegen, het miniatuur van het audio‑frame kunt aanpassen, afspeelopties zoals volume, looping, verbergen, trimmen en fade‑tijden kunt configureren, en audio die in dia‑show overgangen wordt gebruikt kunt extraheren.

## **Audio‑frames maken**

Aspose.Slides voor .NET stelt u in staat om audiobestanden aan dia's toe te voegen. De audiobestanden worden ingesloten in dia's als audio‑frames. 

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse.  
2. Haal de referentie van een dia op via de index.  
3. Laad de audiobestandsstroom die u in de dia wilt insluiten.  
4. Voeg het ingesloten audio‑frame (dat het audiobestand bevat) toe aan de dia.  
5. Stel [PlayMode](https://reference.aspose.com/slides/nl/net/aspose.slides/audioplaymodepreset) en `Volume` in die worden blootgesteld door het [IAudioFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe)-object.  
6. Sla de gewijzigde presentatie op.  

Dit C#‑codefragment toont hoe u een ingesloten audio‑frame aan een dia kunt toevoegen:

```c#
// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt
using (Presentation pres = new Presentation())
{
    // Haalt de eerste dia op
    ISlide sld = pres.Slides[0];
    
    // Laadt het wav-geluidsbestand naar een stream
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Voegt het audio-frame toe
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Stelt de afspeelmodus en het volume van de audio in
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Schrijft het PowerPoint-bestand naar schijf
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Miniatuur van audio‑frame wijzigen**

Wanneer u een audiobestand aan een presentatie toevoegt, verschijnt de audio als een frame met een standaardafbeelding (zie de afbeelding in de sectie hieronder). U kunt de miniatuur van het audio‑frame wijzigen (uw gewenste afbeelding instellen).

Dit C#‑codefragment toont hoe u de miniatuur of voorbeeldafbeelding van een audio‑frame kunt wijzigen:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Voegt een audio-frame toe aan de dia met een opgegeven positie en afmeting.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Voegt een afbeelding toe aan de presentatieresources.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Stelt de afbeelding in voor het audio-frame.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//Slaat de gewijzigde presentatie op naar schijf
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Audio‑afspeelopties wijzigen**

Aspose.Slides voor .NET stelt u in staat om opties te wijzigen die de weergave of eigenschappen van een audio regelen. Bijvoorbeeld, u kunt het volume van een audio aanpassen, de audio laten herhalen, of zelfs het audio‑icoon verbergen.

De **Audio‑opties**-paneel in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio‑opties** die overeenkomen met de Aspose.Slides [AudioFrame]‑eigenschappen:

- **Start**-keuzelijst komt overeen met de eigenschap [AudioFrame.PlayMode](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/properties/playmode)  
- **Volume** komt overeen met de eigenschap [AudioFrame.Volume](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/properties/volume)  
- **Afspelen over dia's** komt overeen met de eigenschap [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/properties/playacrossslides)  
- **Herhalen tot gestopt** komt overeen met de eigenschap [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/properties/playloopmode)  
- **Verbergen tijdens diavoorstelling** komt overeen met de eigenschap [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/properties/hideatshowing)  
- **Terugspoelen na afspelen** komt overeen met de eigenschap [AudioFrame.RewindAudio](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/properties/rewindaudio)  

PowerPoint **Bewerkings**‑opties die overeenkomen met de Aspose.Slides [AudioFrame]‑eigenschappen:

- **Fade In** komt overeen met de eigenschap [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/fadeinduration/)  
- **Fade Out** komt overeen met de eigenschap [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/fadeoutduration/)  
- **Trim Audio Start Time** komt overeen met de eigenschap [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/trimfromstart/)  
- **Trim Audio End Time**-waarde is gelijk aan de audioduur min de waarde van de eigenschap [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/trimfromend/)  

De **Volume‑regelaar** op het audio‑bedieningspaneel in PowerPoint komt overeen met de eigenschap [AudioFrame.VolumeValue](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/volumevalue/) . Hiermee kunt u het audio‑volume als percentage aanpassen.

Zo wijzigt u de audio‑afspeelopties:

1. [Maak](#create-audio-frame) of haal het Audio Frame op.  
2. Stel nieuwe waarden in voor de Audio‑frame‑eigenschappen die u wilt aanpassen.  
3. Sla het gewijzigde PowerPoint‑bestand op.  

Deze C#‑code laat een bewerking zien waarbij de opties van een audio worden aangepast:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Haalt de AudioFrame-vorm op
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Stelt de afspeelmodus in op afspelen bij klikken
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Stelt het volume in op Laag
    audioFrame.Volume = AudioVolumeMode.Low;

    // Stelt in dat de audio over dia's wordt afgespeeld
    audioFrame.PlayAcrossSlides = true;

    // Schakelt looping uit voor de audio
    audioFrame.PlayLoopMode = false;

    // Verbergt het AudioFrame tijdens de diavoorstelling
    audioFrame.HideAtShowing = true;

    // Spoelt de audio terug naar het begin na het afspelen
    audioFrame.RewindAudio = true;

    // Slaat het PowerPoint-bestand op naar schijf
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Dit C#‑voorbeeld toont hoe u een nieuw audio‑frame met ingesloten audio kunt toevoegen, het kunt trimmen en de fade‑tijden kunt instellen:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Stelt de trim-start offset in op 1,5 seconden
    audioFrame.TrimFromStart = 1500f;
    // Stelt de trim-eind offset in op 2 seconden
    audioFrame.TrimFromEnd = 2000f;

    // Stelt de fade-in duur in op 200 ms
    audioFrame.FadeInDuration = 200f;
    // Stelt de fade-out duur in op 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

De volgende codevoorbeeld toont hoe u een audio‑frame met ingesloten audio kunt ophalen en het volume op 85 % kunt instellen:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Haalt een audio-frame vorm op
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Stelt het audio-volume in op 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Audio‑bijschriften beheren**

Aspose.Slides stelt u in staat om ondertitels aan een audio‑frame toe te voegen via de eigenschap [CaptionTracks](https://reference.aspose.com/slides/nl/net/aspose.slides/iaudioframe/captiontracks/). Deze eigenschap retourneert een [ICaptionsCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/icaptionscollection/), waarmee u WebVTT‑bijschrift‑tracks kunt toevoegen, door bestaande tracks kunt itereren en ze kunt verwijderen wanneer nodig.

**Audio‑bijschriften toevoegen**

Gebruik de eigenschap [CaptionTracks](https://reference.aspose.com/slides/nl/net/aspose.slides/iaudioframe/captiontracks/) om een of meer bijschrift‑tracks aan een audio‑frame toe te voegen. In het volgende voorbeeld wordt een audiobestand aan een dia toegevoegd, waarna een nieuwe bijschrift‑track wordt geladen vanuit een `.vtt`‑bestand.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Voeg een nieuw ondertitel‑track toe vanuit een WebVTT‑bestand.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Audio‑bijschriften extraheren**

U kunt door de bijschrift‑tracks die aan een audio‑frame zijn gekoppeld itereren en ze opslaan als `.vtt`‑bestanden. Elke bijschrift‑track exposeert zijn binaire gegevens en unieke identifier, die gebruikt kunnen worden bij het exporteren van bijschriften.

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
                // Sla het ondertitel-track op als een .vtt-bestand.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Audio‑bijschriften verwijderen**

Om bijschriften van een audio‑frame te verwijderen, gebruikt u de methoden die worden geboden door [ICaptionsCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/icaptionscollection/), zoals [Clear](https://reference.aspose.com/slides/nl/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/icaptionscollection/remove/) of [RemoveAt](https://reference.aspose.com/slides/nl/net/aspose.slides/icaptionscollection/removeat/). Het volgende voorbeeld verwijdert alle bijschrift‑tracks van een audio‑frame.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Verwijder alle ondertitel‑tracks van het audio‑frame.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Audio extraheren**

Aspose.Slides voor .NET stelt u in staat om het geluid dat in dia‑show overgangen wordt gebruikt te extraheren. Bijvoorbeeld, u kunt het geluid van een specifieke dia extraheren.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse en laad de presentatie die de audio bevat.  
2. Haal de referentie van de betreffende dia op via de index.  
3. Toegang tot de diavoorstelling‑overgangen voor de dia.  
4. Extraheer het geluid als byte‑gegevens.  

Deze C#‑code toont hoe u de audio die in een dia wordt gebruikt kunt extraheren:

```c#
string presName = "AudioSlide.pptx";

// Instantieert een Presentation-klasse die een presentiebestand vertegenwoordigt
Presentation pres = new Presentation(presName);

// Verkrijgt de dia
ISlide slide = pres.Slides[0];

// Haalt de dia‑show overgangseffecten op voor de dia
ISlideShowTransition transition = slide.SlideShowTransition;

//Extraheert het geluid in een byte-array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **Veelgestelde vragen**

**Kan ik hetzelfde audio‑bestand op meerdere dia's hergebruiken zonder de bestandsgrootte te vergroten?**

Ja. Voeg de audio één keer toe aan de gedeelde [audio collection](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/audios/) van de presentatie en maak extra audio‑frames die naar dat bestaande bestand verwijzen. Dit voorkomt dat mediagegevens worden gedupliceerd en houdt de presentatiesgrootte onder controle.

**Kan ik het geluid in een bestaand audio‑frame vervangen zonder de vorm opnieuw te maken?**

Ja. Voor een gelinkte sound, werk het [link path](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/linkpathlong/) bij zodat het naar het nieuwe bestand wijst. Voor een ingesloten sound, wissel het [embedded audio](https://reference.aspose.com/slides/nl/net/aspose.slides/audioframe/embeddedaudio/)‑object met een ander uit de [audio collection](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/audios/) van de presentatie. De opmaak van het frame en de meeste afspeelinstellingen blijven behouden.

**Verandert trimmen de onderliggende audio‑gegevens die in de presentatie zijn opgeslagen?**

Nee. Trimmen past alleen de afspeelgrenzen aan. De originele audio‑bytes blijven ongemoeid en zijn toegankelijk via de ingesloten audio of de audio‑collectie van de presentatie.