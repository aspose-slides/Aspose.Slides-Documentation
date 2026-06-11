---
title: Hantera ljud i presentationer med C++
linktitle: Ljudram
type: docs
weight: 10
url: /sv/cpp/audio-frame/
keywords:
- ljud
- ljudram
- miniatyrbild
- lägg till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- C++
- Aspose.Slides
description: "Skapa och kontrollera ljudramar i Aspose.Slides för C++—kodexempel för att bädda in, trimma, loopa och konfigurera uppspelning i PPT-, PPTX- och ODP-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med ljudramar i Aspose.Slides. Den visar hur man lägger till inbäddat ljud i bilder, anpassar ljudramens miniatyrbild, konfigurerar uppspelningsalternativ såsom volym, upprepning, dölja, trimning och toningsvaraktigheter, och extraherar ljud som används i bildspelsövergångar.

## **Skapa ljudramar**

Aspose.Slides för C++ låter dig lägga till ljudfiler i bilder. Ljudfilerna bäddas in i bilder som ljudramar. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Hämta en bilds referens via dess index.
3. Läs in ljudfilströmmen du vill bädda in i bilden.
4. Lägg till den inbäddade ljudramen (som innehåller ljudfilen) till bilden.
5. Ställ in [PlayMode](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) och `Volume` som exponeras av objektet [IAudioFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_audio_frame).
6. Spara den modifierade presentationen.

Den här C++-koden visar hur du lägger till en inbäddad ljudram i en bild:

``` cpp
// Instansierar en Presentation-klass som representerar en presentationsfil
auto pres = System::MakeObject<Presentation>();

// Hämtar den första bilden
auto sld = pres->get_Slides()->idx_get(0);

// Läser in wav-ljudfilen till en ström
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Lägger till ljudramen
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Ställer in uppspelningsläge och volym för ljudet
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Skriver PowerPoint-filen till disk
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Ändra ljudramens miniatyrbild**

När du lägger till en ljudfil i en presentation visas ljudet som en ram med en standardstandardbild (se bilden i avsnittet nedan). Du kan ändra ljudramens miniatyrbild (ange din föredragna bild).

Den här C++-koden visar hur du ändrar en ljudramens miniatyrbild eller förhandsgranskningsbild:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Lägger till en ljudram på bilden med en specifik position och storlek.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Lägger till en bild i presentationens resurser.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Ställer in bilden för ljudramen.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Sparar den modifierade presentationen till disk
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ändra ljuduppspelningsalternativ**

Aspose.Slides för C++ låter dig ändra alternativ som styr ett ljuds uppspelning eller egenskaper. Till exempel kan du justera ett ljuds volym, ställa in ljudet att spelas i loop, eller till och med dölja ljudikonen.

The **Audio Options** panel i Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** som motsvarar metoder i Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/) methods:

- **Start**-rullgardinsmenyn motsvarar metoden [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_playmode/) 
- **Volume** motsvarar metoden [AudioFrame::set_Volume](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_volume/) 
- **Play Across Slides** motsvarar metoden [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_playacrossslides/) 
- **Loop until Stopped** motsvarar metoden [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_playloopmode/) 
- **Hide During Show** motsvarar metoden [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_hideatshowing/) 
- **Rewind after Playing** motsvarar metoden [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_rewindaudio/) method 

PowerPoint **Editing**-alternativ som motsvarar egenskaper i Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/) properties:

- **Fade In** motsvarar metoden [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_fadeinduration/) 
- **Fade Out** motsvarar metoden [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_fadeoutduration/) 
- **Trim Audio Start Time** motsvarar metoden [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_trimfromstart/) 
- **Trim Audio End Time** värdet är ljudets varaktighet minus värdet från metoden [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_trimfromend/) method

PowerPoint **Volume controll** på ljudkontrollpanelen motsvarar metoden [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_volumevalue/) method. Den låter dig ändra ljudvolymen i procent.

Så här ändrar du Audio Play options:

1. [Сreate](#creating-audio-frame) eller hämta Audio Frame.
2. Ställ in nya värden för de Audio Frame-egenskaper du vill justera.
3. Spara den modifierade PowerPoint-filen.

Den här C++-koden demonstrerar en operation där ett ljuds alternativ justeras:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Hämta en form
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Kastar om formen till en AudioFrame-form
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Ställer in uppspelningsläget till att spela vid klick
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Ställer in volymen till Låg
audioFrame->set_Volume(AudioVolumeMode::Low);

// Ställer in ljudet att spela över flera bilder
audioFrame->set_PlayAcrossSlides(true);

// Inaktiverar loop för ljudet
audioFrame->set_PlayLoopMode(false);

// Döljer AudioFrame under bildspelet
audioFrame->set_HideAtShowing(true);

// Spolar tillbaka ljudet till början efter uppspelning
audioFrame->set_RewindAudio(true);

// Sparar PowerPoint-filen till disk
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Detta C++-exempel visar hur du lägger till en ny ljudram med inbäddat ljud, trimmar den och anger toningsvaraktigheterna:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Ställer in trimningsstartoffset till 1,5 sekunder
audioFrame->set_TrimFromStart(1500);
// Ställer in trimningsslutoffset till 2 sekunder
audioFrame->set_TrimFromEnd(2000);

// Ställer in toningsinslagningsvaraktigheten till 200 ms
audioFrame->set_FadeInDuration(200);
// Ställer in toningsutslagningsvaraktigheten till 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

Följande kodexempel visar hur du hämtar en ljudram med inbäddat ljud och ställer in dess volym till 85 %:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Hämtar en ljudramform
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Ställer in ljudvolymen till 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Hantera ljudtextning**

Aspose.Slides låter dig lägga till stängda undertexter till en ljudram via metoden [get_CaptionTracks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iaudioframe/get_captiontracks/). Denna metod returnerar en [ICaptionsCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icaptionscollection/), som låter dig lägga till WebVTT-undertextspår, iterera genom befintliga spår och ta bort dem vid behov.

**Lägg till ljudtextning**

Använd metoden [get_CaptionTracks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iaudioframe/get_captiontracks/) för att fästa ett eller flera undertextspår till en ljudram. I följande exempel läggs en ljudfil till en bild, och sedan laddas ett nytt undertextspår från en `.vtt`‑fil.

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

**Extrahera ljudtextning**

Du kan iterera genom undertextspåren som är associerade med en ljudram och spara dem som `.vtt`‑filer. Varje undertextspår exponerar sina binära data och unika identifierare, vilket kan användas vid export av undertexter.

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
            // Spara varje undertextspår som en .vtt fil.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Ta bort ljudtextning**

För att ta bort undertexter från en ljudram, använd metoderna som tillhandahålls av [ICaptionsCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icaptionscollection/), såsom [Clear](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icaptionscollection/remove/), eller [RemoveAt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icaptionscollection/removeat/). Följande exempel tar bort alla undertextspår från en ljudram.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Ta bort alla undertextspår från ljudramen.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Extrahera ljud**

Aspose.Slides låter dig extrahera ljudet som används i bildspelsövergångar. Till exempel kan du extrahera ljudet som används i en specifik bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) och läs in presentationen som innehåller ljudet.
2. Hämta den relevanta bildens referens via dess index.
3. Åtkomst till bildspelsövergångarna för bilden.
4. Extrahera ljudet som byte‑data.

Den här C++-koden visar hur du extraherar ljudet som används i en bild:

``` cpp
String presName = u"AudioSlide.pptx";

// Instansierar en Presentation-klass som representerar en presentationsfil
auto pres = System::MakeObject<Presentation>(presName);

// Hämtar den önskade bilden
auto slide = pres->get_Slides()->idx_get(0);

// Hämtar bildspelsövergångseffekterna för bilden
auto transition = slide->get_SlideShowTransition();

// Extraherar ljudet i en bytearray
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**Kan jag återanvända samma ljudresurs på flera bilder utan att öka filstorleken?**

Ja. Lägg till ljudet en gång i presentationens delade [audio collection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_audios/) och skapa ytterligare ljudramar som refererar till den befintliga resursen. Detta undviker duplicering av mediedata och håller presentationens storlek under kontroll.

**Kan jag ersätta ljudet i en befintlig ljudram utan att återskapa formen?**

Ja. För ett länkat ljud, uppdatera [link path](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_linkpathlong/) så att det pekar på den nya filen. För ett inbäddat ljud, byt ut objektet [embedded audio](https://reference.aspose.com/slides/sv/cpp/aspose.slides/audioframe/set_embeddedaudio/) mot ett annat från presentationens [audio collection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_audios/). Ramens formatering och de flesta uppspelningsinställningar förblir intakta.

**Ändrar trimning den underliggande ljuddata som lagras i presentationen?**

Nej. Trimning justerar endast uppspelningsgränserna. De ursprungliga ljudbytena förblir orörda och åtkomliga via det inbäddade ljudet eller presentationens ljudsamling.