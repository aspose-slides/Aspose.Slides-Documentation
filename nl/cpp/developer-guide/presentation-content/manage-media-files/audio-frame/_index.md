---
title: Audio beheren in presentaties met C++
linktitle: Audioframe
type: docs
weight: 10
url: /nl/cpp/audio-frame/
keywords:
- audio
- audioframe
- miniatuur
- audio toevoegen
- audio-eigenschappen
- audio-opties
- audio extraheren
- C++
- Aspose.Slides
description: "Maak en beheer audio-frames in Aspose.Slides voor C++—codevoorbeelden om audio in te sluiten, te trimmen, te loopen en het afspelen te configureren in PPT-, PPTX- en ODP-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u werkt met audio‑kaders in Aspose.Slides. Het laat zien hoe u ingesloten audio toevoegt aan dia’s, de miniatuur van het audio‑kader aanpast, afspeelopties configureert zoals volume, looping, verbergen, trimmen en fade‑tijden, en audio extraheert die wordt gebruikt in diavoorstelling‑overgangen.

## **Audiokaders maken**

Aspose.Slides voor C++ stelt u in staat audio‑bestanden toe te voegen aan dia’s. De audio‑bestanden worden ingesloten in dia’s als audio‑kaders.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Laad de audio‑bestandstream die u in de dia wilt insluiten.
4. Voeg het ingesloten audio‑kader (met het audio‑bestand) toe aan de dia.
5. Stel [PlayMode](https://reference.aspose.com/slides/nl/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) en `Volume` in die worden blootgesteld door het [IAudioFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_audio_frame)‑object.
6. Sla de gewijzigde presentatie op.

Deze C++‑code laat zien hoe u een ingesloten audio‑kader aan een dia toevoegt:

``` cpp
// Instantieert een Presentation‑klasse die een presentatiebestand vertegenwoordigt
auto pres = System::MakeObject<Presentation>();

// Haalt de eerste dia op
auto sld = pres->get_Slides()->idx_get(0);

// Laadt het wav‑geluidsbestand naar een stream
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Voegt het Audio‑frame toe
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Stelt de afspeelmodus en het volume van de audio in
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Schrijft het PowerPoint‑bestand naar de schijf
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Miniatuur van audio‑kader wijzigen**

Wanneer u een audio‑bestand aan een presentatie toevoegt, verschijnt de audio als een kader met een standaard‑afbeelding (zie de afbeelding in de sectie hieronder). U kunt de miniatuur van het audio‑kader wijzigen (uw favoriete afbeelding instellen).

Deze C++‑code laat zien hoe u de miniatuur of voorbeeldafbeelding van een audio‑kader wijzigt:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Voegt een audio‑frame toe aan de dia met een opgegeven positie en grootte.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Voegt een afbeelding toe aan de presentatieresources.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Stelt de afbeelding in voor het audio‑frame. // <-----
        
//Slaat de gewijzigde presentatie op naar schijf
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Afspelenopties van audio wijzigen**

Aspose.Slides voor C++ laat u opties aanpassen die het afspelen of de eigenschappen van audio regelen. U kunt bijvoorbeeld het volume aanpassen, de audio in een lus afspelen, of het audiosymbool verbergen.

Het **Audio‑opties**‑paneel in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio‑opties** die overeenkomen met Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/)‑methoden:

- **Start** keuzelijst komt overeen met de [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_playmode/)‑methode
- **Volume** komt overeen met de [AudioFrame::set_Volume](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_volume/)‑methode
- **Play Across Slides** komt overeen met de [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_playacrossslides/)‑methode
- **Loop until Stopped** komt overeen met de [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_playloopmode/)‑methode
- **Hide During Show** komt overeen met de [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_hideatshowing/)‑methode
- **Rewind after Playing** komt overeen met de [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_rewindaudio/)‑methode

PowerPoint **Bewerken**‑opties die overeenkomen met Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/)‑eigenschappen:

- **Fade In** komt overeen met de [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_fadeinduration/)‑methode
- **Fade Out** komt overeen met de [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_fadeoutduration/)‑methode
- **Trim Audio Start Time** komt overeen met de [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_trimfromstart/)‑methode
- **Trim Audio End Time** heeft een waarde die gelijk is aan de audio‑duur min de waarde van de [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_trimfromend/)‑methode

De PowerPoint **Volume‑regelaar** op het audio‑bedieningspaneel komt overeen met de [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_volumevalue/)‑methode. Hiermee kunt u het audiovolume wijzigen als een percentage.

Zo wijzigt u de afspelenopties van audio:

1. [Create](#creating-audio-frame) of verkrijg het audio‑kader.
2. Stel nieuwe waarden in voor de audio‑kader‑eigenschappen die u wilt aanpassen.
3. Sla het gewijzigde PowerPoint‑bestand op.

Deze C++‑code demonstreert een bewerking waarbij de opties van een audio‑bestand worden aangepast:

``` cpp
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Haalt een vorm op
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Converteert de vorm naar een AudioFrame‑vorm
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Stelt de afspeelmodus in op afspelen bij klik
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Stelt het volume in op laag
audioFrame->set_Volume(AudioVolumeMode::Low);

// Stelt in dat de audio over meerdere dia's wordt afgespeeld
audioFrame->set_PlayAcrossSlides(true);

// Schakelt lus voor de audio uit
audioFrame->set_PlayLoopMode(false);

// Verbergt het AudioFrame tijdens de diavoorstelling
audioFrame->set_HideAtShowing(true);

// Spoelt de audio terug naar het begin na het afspelen
audioFrame->set_RewindAudio(true);

// Slaat het PowerPoint‑bestand op naar schijf
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Dit C++‑voorbeeld laat zien hoe u een nieuw audio‑kader met ingesloten audio toevoegt, het trimt en de fade‑tijden instelt:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Stelt de trim-startoffset in op 1,5 seconden
// Stelt de trim-eindoffset in op 2 seconden
// Stelt de fade-in-duur in op 200 ms
// Stelt de fade-out-duur in op 500 ms

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

De volgende code‑sample laat zien hoe u een audio‑kader met ingesloten audio ophaalt en het volume op 85 % zet:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Haalt een audio-frame-vorm op
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Stelt het audio volume in op 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Audiobijschriften beheren**

Aspose.Slides stelt u in staat gesloten bijschriften toe te voegen aan een audio‑kader via de [get_CaptionTracks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iaudioframe/get_captiontracks/)‑methode. Deze methode retourneert een [ICaptionsCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/), waarmee u WebVTT‑bijschriftsporen kunt toevoegen, door bestaande sporen kunt itereren en ze kunt verwijderen wanneer nodig.

**Audiobijschriften toevoegen**

Gebruik de [get_CaptionTracks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iaudioframe/get_captiontracks/)‑methode om een of meer bijschriftsporen aan een audio‑kader te koppelen. In het volgende voorbeeld wordt een audio‑bestand aan een dia toegevoegd en vervolgens wordt een nieuw bijschriftspoor geladen vanuit een `.vtt`‑bestand.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Audiobijschriften extraheren**

U kunt door de bijschriftsporen die aan een audio‑kader zijn gekoppeld itereren en ze opslaan als `.vtt`‑bestanden. Elk bijschriftspoor stelt zijn binaire gegevens en unieke identificator bloot, die gebruikt kan worden bij het exporteren van bijschriften.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // Sla elk bijschriftspoor op als een .vtt-bestand.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Audiobijschriften verwijderen**

Om bijschriften van een audio‑kader te verwijderen, gebruikt u de methoden die worden aangeboden door [ICaptionsCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/), zoals [Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/remove/), of [RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/removeat/). Het onderstaande voorbeeld verwijdert alle bijschriftsporen van een audio‑kader.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Verwijder alle bijschriftsporen van het audio‑frame.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Audio extraheren**
Aspose.Slides stelt u in staat het geluid dat wordt gebruikt in diavoorstellings‑overgangen te extraheren. U kunt bijvoorbeeld het geluid extraheren dat in een specifieke dia wordt gebruikt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse en laad de presentatie die de audio bevat.
2. Verkrijg de referentie naar de betreffende dia via de index.
3. Benader de diavoorstellings‑overgangen voor de dia.
4. Extraheer het geluid als byte‑gegevens.

Deze C++‑code laat zien hoe u de audio extrahereert die in een dia wordt gebruikt:

``` cpp
String presName = u"AudioSlide.pptx";

// Instantieert een Presentation‑klasse die een presentatiebestand vertegenwoordigt
auto pres = System::MakeObject<Presentation>(presName);

// Toegang tot de gewenste dia
auto slide = pres->get_Slides()->idx_get(0);

// Haalt de diavoorstelling‑overgangseffecten op voor de dia
auto transition = slide->get_SlideShowTransition();

// Extraheert het geluid als byte‑array
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**Kan ik hetzelfde audio‑bestand hergebruiken op meerdere dia’s zonder de bestandsgrootte te laten toenemen?**

Ja. Voeg de audio één keer toe aan de gedeelde [audio collection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_audios/) van de presentatie en maak extra audio‑kaders die naar dat bestaande bestand verwijzen. Dit voorkomt duplicatie van mediagegevens en houdt de presentatiegrootte onder controle.

**Kan ik het geluid in een bestaand audio‑kader vervangen zonder de vorm opnieuw te maken?**

Ja. Voor een gelinkte audio past u het [link path](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_linkpathlong/) aan zodat het naar het nieuwe bestand wijst. Voor een ingesloten audio verwisselt u het [embedded audio](https://reference.aspose.com/slides/nl/cpp/aspose.slides/audioframe/set_embeddedaudio/)‑object met een ander uit de [audio collection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_audios/) van de presentatie. De opmaak van het kader en de meeste afspeelinstellingen blijven behouden.

**Verandert trimmen de onderliggende audio‑gegevens die in de presentatie zijn opgeslagen?**

Nee. Trimmen past alleen de afspeelgrenzen aan. De oorspronkelijke audio‑bytes blijven ongewijzigd en zijn toegankelijk via de ingesloten audio of de audio‑collectie van de presentatie.