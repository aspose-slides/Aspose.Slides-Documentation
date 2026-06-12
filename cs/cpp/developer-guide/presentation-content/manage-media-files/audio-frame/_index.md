---
title: Správa zvuku v prezentacích pomocí C++
linktitle: Audio rámec
type: docs
weight: 10
url: /cs/cpp/audio-frame/
keywords:
- audio
- audio rámec
- náhled
- přidat audio
- vlastnosti audio
- možnosti audio
- extrahovat audio
- C++
- Aspose.Slides
description: "Vytvářejte a ovládejte audio rámečky v Aspose.Slides pro C++ — příklady kódu pro vložení, oříznutí, opakování a konfiguraci přehrávání v prezentacích PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s audio rámci v Aspose.Slides. Ukazuje, jak přidat vložený zvuk do snímků, přizpůsobit miniaturu audio rámce, nakonfigurovat možnosti přehrávání, jako je hlasitost, opakování, skrytí, oříznutí a dobu přechodů, a získat zvuk použitý v přechodech prezentace.

## **Vytvoření audio rámců**

Aspose.Slides pro C++ vám umožňuje přidávat zvukové soubory na snímky. Zvukové soubory jsou do snímků vloženy jako audio rámce. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte odkaz na snímek přes jeho index.
3. Načtěte stream zvukového souboru, který chcete do snímku vložit.
4. Přidejte vložený audio rámec (obsahující zvukový soubor) na snímek.
5. Nastavte [PlayMode](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) a `Volume` poskytované objektem [IAudioFrame](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_audio_frame).
6. Uložte upravenou prezentaci.

``` cpp
// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
auto pres = System::MakeObject<Presentation>();

// Získá první snímek
auto sld = pres->get_Slides()->idx_get(0);

// Načte wav zvukový soubor do streamu
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Přidá Audio Frame
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Nastaví režim přehrávání a hlasitost zvuku
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Zapíše soubor PowerPoint na disk
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Změna miniatury audio rámce**

Když do prezentace přidáte zvukový soubor, zvuk se zobrazí jako rámec se standardním výchozím obrázkem (viz obrázek v následující sekci). Změníte miniaturu audio rámce (nastavíte svůj preferovaný obrázek).

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Přidá audio rámec do snímku s určenou polohou a velikostí.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Přidá obrázek do zdrojů prezentace.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Nastaví obrázek pro audio rámec.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Uloží upravenou prezentaci na disk
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Změna možností přehrávání zvuku**

Aspose.Slides pro C++ vám umožňuje měnit možnosti, které řídí přehrávání zvuku nebo jeho vlastnosti. Například můžete upravit hlasitost zvuku, nastavit přehrávání zvuku v cyklu nebo dokonce skrýt ikonu zvuku.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Možnosti **Audio** v PowerPointu, které odpovídají metodám Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/):

- **Spustit** rozbalovací seznam odpovídá metodě [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_playmode/) 
- **Hlasitost** odpovídá metodě [AudioFrame::set_Volume](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_volume/) 
- **Přehrát napříč snímky** odpovídá metodě [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_playacrossslides/) 
- **Opakovat až do zastavení** odpovídá metodě [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_playloopmode/) 
- **Skrýt během prezentace** odpovídá metodě [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_hideatshowing/) 
- **Přetočit po přehrání** odpovídá metodě [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_rewindaudio/) method 

Možnosti **Úpravy** v PowerPointu, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/):

- **Plynulé zesílení** odpovídá metodě [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_fadeinduration/) 
- **Postupné zeslabení** odpovídá metodě [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_fadeoutduration/) 
- **Zkrátit čas začátku zvuku** odpovídá metodě [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_trimfromstart/) 
- **Zkrátit čas konce zvuku** hodnota se rovná délce zvuku minus hodnota metody [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_trimfromend/) 

Ovládání **hlasitosti** v panelu zvukové kontroly v PowerPointu odpovídá metodě [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_volumevalue/). Umožňuje vám změnit hlasitost zvuku v procentech.

1. [Vytvořit](#creating-audio-frame) nebo získat Audio Frame.
2. Nastavte nové hodnoty vlastností Audio Frame, které chcete upravit.
3. Uložte upravený soubor PowerPoint.

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Získá tvar
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Přetypuje tvar na AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Nastaví režim přehrávání na přehrání při kliknutí
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Nastaví hlasitost na nízkou
audioFrame->set_Volume(AudioVolumeMode::Low);

// Nastaví, aby se zvuk přehrával napříč snímky
audioFrame->set_PlayAcrossSlides(true);

// Zakáže opakování pro zvuk
audioFrame->set_PlayLoopMode(false);

// Skryje AudioFrame během prezentace
audioFrame->set_HideAtShowing(true);

// Přetočí zvuk na začátek po přehrání
audioFrame->set_RewindAudio(true);

// Uloží soubor PowerPoint na disk
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Získá tvar audio rámce
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Nastaví hlasitost zvuku na 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Správa titulků zvuku**

Aspose.Slides vám umožňuje přidat uzavřené titulky k audio rámci pomocí metody [get_CaptionTracks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iaudioframe/get_captiontracks/). Tato metoda vrací [ICaptionsCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icaptionscollection/), což vám umožňuje přidávat WebVTT stopy titulků, procházet existující stopy a odstraňovat je podle potřeby.

**Přidání titulků zvuku**

Použijte metodu [get_CaptionTracks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iaudioframe/get_captiontracks/) k připojení jedné nebo více stop titulků k audio rámci. V následujícím příkladu je zvukový soubor přidán na snímek a poté je načtena nová stopa titulků ze souboru `.vtt`.

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

**Extrahování titulků zvuku**

Můžete procházet stopy titulků přidružené k audio rámci a ukládat je jako soubory `.vtt`. Každá stopa titulků poskytuje své binární údaje a jedinečný identifikátor, který lze použít při exportu titulků.

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
            // Uložte každou stopu titulků jako soubor .vtt.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Odstranění titulků zvuku**

Pro odstranění titulků z audio rámce použijte metody poskytované rozhraním [ICaptionsCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icaptionscollection/), jako jsou [Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icaptionscollection/remove/), nebo [RemoveAt](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icaptionscollection/removeat/). Následující příklad odstraňuje všechny stopy titulků z audio rámce.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Odstraní všechny stopy titulků z audio rámce.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Extrahování zvuku**
Aspose.Slides vám umožňuje extrahovat zvuk použitý v přechodech prezentace. Například můžete extrahovat zvuk použitý v konkrétním snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) a načtěte prezentaci obsahující zvuk.
2. Získejte odkaz na příslušný snímek přes jeho index.
3. Přistupte k přechodům prezentace pro daný snímek.
4. Extrahujte zvuk jako sekvenci bajtů.

``` cpp
String presName = u"AudioSlide.pptx";

// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
auto pres = System::MakeObject<Presentation>(presName);

// Získá požadovaný snímek
auto slide = pres->get_Slides()->idx_get(0);

// Získá efekty přechodu prezentace pro snímek
auto transition = slide->get_SlideShowTransition();

// Extrahuje zvuk do pole bajtů
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **Často kladené otázky**

**Mohu znovu použít stejný zvukový soubor na více snímcích, aniž by se zvětšila velikost souboru?**

Ano. Přidejte zvuk jednou do sdílené [audio kolekce](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_audios/) prezentace a vytvořte další audio rámce, které odkazují na tento existující objekt. Tím se zabrání duplikaci mediálních dat a velikost prezentace zůstane pod kontrolou.

**Mohu nahradit zvuk v existujícím audio rámci, aniž bych musel znovu vytvářet tvar?**

Ano. U propojeného zvuku aktualizujte [cestu odkazu](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_linkpathlong/) tak, aby ukazovala na nový soubor. U vloženého zvuku vyměňte objekt [embedded audio](https://reference.aspose.com/slides/cs/cpp/aspose.slides/audioframe/set_embeddedaudio/) za jiný z [audio kolekce](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_audios/) prezentace. Formátování rámce a většina nastavení přehrávání zůstane beze změny.

**Mění ořezávání podkladová zvuková data uložená v prezentaci?**

Ne. Ořezávání upravuje pouze hranice přehrávání. Původní bajty zvuku zůstávají nedotčeny a jsou přístupné přes vložený zvuk nebo audio kolekci prezentace.