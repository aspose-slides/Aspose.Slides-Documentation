---
title: Zarządzanie dźwiękiem w prezentacjach przy użyciu C++
linktitle: Rama audio
type: docs
weight: 10
url: /pl/cpp/audio-frame/
keywords:
- dźwięk
- ramka audio
- miniatura
- dodaj dźwięk
- właściwości dźwięku
- opcje dźwięku
- wyodrębnij dźwięk
- C++
- Aspose.Slides
description: "Tworzenie i kontrolowanie ramek audio w Aspose.Slides dla C++ — przykłady kodu do osadzania, przycinania, pętli i konfigurowania odtwarzania w prezentacjach PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z ramkami audio w Aspose.Slides. Pokazuje, jak dodać osadzony dźwięk do slajdów, dostosować miniaturę ramki audio, skonfigurować opcje odtwarzania takie jak głośność, pętla, ukrywanie, przycinanie i czasy wyciszenia, oraz wyodrębnić dźwięk używany w przejściach pokazu slajdów.

## **Tworzenie ramek audio**

Aspose.Slides for C++ umożliwia dodawanie plików audio do slajdów. Pliki audio są osadzane w slajdach jako ramki audio.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Pobierz odniesienie do slajdu przez jego indeks.
3. Wczytaj strumień pliku audio, który chcesz osadzić w slajdzie.
4. Dodaj osadzoną ramkę audio (zawierającą plik audio) do slajdu.
5. Ustaw [PlayMode](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) oraz `Volume` udostępnione przez obiekt [IAudioFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_audio_frame).
6. Zapisz zmodyfikowaną prezentację.

Ten kod C++ pokazuje, jak dodać osadzoną ramkę audio do slajdu:

``` cpp
// Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji
auto pres = System::MakeObject<Presentation>();

// Pobiera pierwszy slajd
auto sld = pres->get_Slides()->idx_get(0);

// Ładuje plik dźwiękowy wav do strumienia
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Dodaje ramkę audio
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Ustawia tryb odtwarzania i głośność dźwięku
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Zapisuje plik PowerPoint na dysku
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Zmiana miniatury ramki audio**

Gdy dodajesz plik audio do prezentacji, audio pojawia się jako ramka z domyślnym standardowym obrazem (zobacz obraz w sekcji poniżej). Możesz zmienić miniaturę ramki audio (ustawić własny obraz).

Ten kod C++ pokazuje, jak zmienić miniaturę lub podglądowy obraz ramki audio:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Dodaje ramkę audio do slajdu z określonym położeniem i rozmiarem.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Dodaje obraz do zasobów prezentacji.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Ustawia obraz dla ramki audio.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Zapisuje zmodyfikowaną prezentację na dysk
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Zmiana opcji odtwarzania audio**

Aspose.Slides for C++ umożliwia zmianę opcji kontrolujących odtwarzanie lub właściwości audio. Na przykład możesz regulować głośność audio, ustawić odtwarzanie w pętli lub nawet ukryć ikonę audio.

Panel **Audio Options** w Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opcje **Audio Options** w PowerPoint, które odpowiadają metodom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/):

- **Start** w menu rozwijanym odpowiada metodzie [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_playmode/)
- **Volume** odpowiada metodzie [AudioFrame::set_Volume](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_volume/)
- **Play Across Slides** odpowiada metodzie [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_playacrossslides/)
- **Loop until Stopped** odpowiada metodzie [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_playloopmode/)
- **Hide During Show** odpowiada metodzie [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_hideatshowing/)
- **Rewind after Playing** odpowiada metodzie [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_rewindaudio/)

Opcje **Editing** w PowerPoint, które odpowiadają właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/):

- **Fade In** odpowiada metodzie [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_fadeinduration/)
- **Fade Out** odpowiada metodzie [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_fadeoutduration/)
- **Trim Audio Start Time** odpowiada metodzie [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_trimfromstart/)
- **Trim Audio End Time** – wartość równa jest długości audio pomniejszonej o wartość zwróconą przez metodę [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_trimfromend/)

Suwak **Volume** w panelu sterowania audio w PowerPoint odpowiada metodzie [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_volumevalue/). Pozwala on zmienić głośność audio w procentach.

Tak zmieniasz opcje odtwarzania audio:

1. [Create](#creating-audio-frame) lub pobierz ramkę audio.
2. Ustaw nowe wartości właściwości ramki audio, które chcesz zmodyfikować.
3. Zapisz zmodyfikowany plik PowerPoint.

Ten kod C++ demonstruje operację, w której dostosowywane są opcje audio:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Pobiera kształt
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Konwertuje kształt na kształt AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Ustawia tryb odtwarzania na odtwarzanie po kliknięciu
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Ustawia głośność na niski poziom
audioFrame->set_Volume(AudioVolumeMode::Low);

// Ustawia odtwarzanie dźwięku na wszystkie slajdy
audioFrame->set_PlayAcrossSlides(true);

// Wyłącza pętlę dla dźwięku
audioFrame->set_PlayLoopMode(false);

// Ukrywa ramkę audio podczas pokazu slajdów
audioFrame->set_HideAtShowing(true);

// Przewija dźwięk do początku po odtworzeniu
audioFrame->set_RewindAudio(true);

// Zapisuje plik PowerPoint na dysku
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Ten przykład C++ pokazuje, jak dodać nową ramkę audio z osadzonym dźwiękiem, przyciąć go oraz ustawić czasy wyciszenia:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Ustawia początkowy offset przycinania na 1,5 sekundy
audioFrame->set_TrimFromStart(1500);
// Ustawia końcowy offset przycinania na 2 sekundy
audioFrame->set_TrimFromEnd(2000);

// Ustawia czas trwania efektu fade-in na 200 ms
audioFrame->set_FadeInDuration(200);
// Ustawia czas trwania efektu fade-out na 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

Poniższy fragment kodu pokazuje, jak pobrać ramkę audio z osadzonym dźwiękiem i ustawić jej głośność na 85%:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Pobiera kształt ramki audio
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Ustawia głośność audio na 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Zarządzanie napisami audio**

Aspose.Slides umożliwia dodawanie zamkniętych napisów do ramki audio za pomocą metody [get_CaptionTracks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iaudioframe/get_captiontracks/). Metoda ta zwraca [ICaptionsCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/), co pozwala dodawać ścieżki napisów WebVTT, iterować istniejące ścieżki i usuwać je w razie potrzeby.

**Dodawanie napisów audio**

Użyj metody [get_CaptionTracks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iaudioframe/get_captiontracks/), aby dołączyć jedną lub więcej ścieżek napisów do ramki audio. W poniższym przykładzie plik audio jest dodawany do slajdu, a następnie nowa ścieżka napisów jest wczytywana z pliku `.vtt`.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Dodaj nową ścieżkę napisów z pliku WebVTT.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Wyodrębnianie napisów audio**

Możesz iterować po ścieżkach napisów powiązanych z ramką audio i zapisywać je jako pliki `.vtt`. Każda ścieżka napisów udostępnia swoje dane binarne oraz unikalny identyfikator, który może być użyty przy eksportowaniu napisów.

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
            // Zapisz każdą ścieżkę napisów jako plik .vtt.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Usuwanie napisów audio**

Aby usunąć napisy z ramki audio, użyj metod udostępnionych przez [ICaptionsCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/), takich jak [Clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/remove/) lub [RemoveAt](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/removeat/). Poniższy przykład usuwa wszystkie ścieżki napisów z ramki audio.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Usuń wszystkie ścieżki napisów z ramki audio.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Wyodrębnianie audio**
Aspose.Slides umożliwia wyodrębnienie dźwięku używanego w przejściach pokazu slajdów. Na przykład możesz wyodrębnić dźwięk używany w konkretnym slajdzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) i wczytaj prezentację zawierającą audio.
2. Pobierz odniesienie do odpowiedniego slajdu przez jego indeks.
3. Uzyskaj dostęp do przejść pokazu slajdów dla tego slajdu.
4. Wyodrębnij dźwięk w postaci danych bajtowych.

Ten kod C++ pokazuje, jak wyodrębnić audio używane w slajdzie:

``` cpp
String presName = u"AudioSlide.pptx";

// Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji
auto pres = System::MakeObject<Presentation>(presName);

// Uzyskuje dostęp do żądanego slajdu
auto slide = pres->get_Slides()->idx_get(0);

// Pobiera efekty przejścia pokazu slajdów dla slajdu
auto transition = slide->get_SlideShowTransition();

// Wyodrębnia dźwięk w tablicy bajtów
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**Czy mogę używać tego samego zasobu audio na wielu slajdach bez zwiększania rozmiaru pliku?**

Tak. Dodaj audio raz do współdzielonej [audio collection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_audios/) prezentacji i twórz kolejne ramki audio, które odwołują się do tego istniejącego zasobu. Dzięki temu unikasz duplikowania danych multimedialnych i utrzymujesz rozmiar prezentacji pod kontrolą.

**Czy mogę zamienić dźwięk w istniejącej ramce audio bez ponownego tworzenia kształtu?**

Tak. W przypadku dźwięku połączonego zewnętrznie, zaktualizuj [link path](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_linkpathlong/), aby wskazywał na nowy plik. W przypadku dźwięku osadzonego, podmień obiekt [embedded audio](https://reference.aspose.com/slides/pl/cpp/aspose.slides/audioframe/set_embeddedaudio/) na inny z [audio collection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_audios/) prezentacji. Formatowanie ramki oraz większość ustawień odtwarzania pozostaną niezmienione.

**Czy przycinanie zmienia podstawowe dane audio przechowywane w prezentacji?**

Nie. Przycinanie modyfikuje wyłącznie granice odtwarzania. Oryginalne bajty audio pozostają nienaruszone i dostępne zarówno w osadzonym audio, jak i w kolekcji audio prezentacji.