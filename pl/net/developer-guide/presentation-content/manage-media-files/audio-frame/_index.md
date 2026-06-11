---
title: Zarządzanie ramkami audio w prezentacjach w .NET
linktitle: Ramka audio
type: docs
weight: 10
url: /pl/net/audio-frame/
keywords:
- dźwięk
- ramka audio
- miniatura
- dodaj dźwięk
- właściwości dźwięku
- opcje dźwięku
- wyodrębnij dźwięk
- .NET
- C#
- Aspose.Slides
description: "Twórz i kontroluj ramki audio w Aspose.Slides dla .NET—przykłady C# umożliwiające osadzanie, przycinanie, pętlowanie i konfigurowanie odtwarzania w prezentacjach PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z ramkami audio w Aspose.Slides. Pokazuje, jak dodać osadzony dźwięk do slajdów, dostosować miniaturę ramki audio, skonfigurować opcje odtwarzania, takie jak głośność, pętla, ukrywanie, przycinanie i czas trwania zanikania, oraz wyodrębnić dźwięk używany w przejściach pokazu slajdów.

## **Utwórz ramki audio**

Aspose.Slides for .NET umożliwia dodawanie plików audio do slajdów. Pliki audio są osadzane w slajdach jako ramki audio.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Wczytaj strumień pliku audio, który chcesz osadzić w slajdzie.
4. Dodaj osadzoną ramkę audio (zawierającą plik audio) do slajdu.
5. Ustaw [PlayMode](https://reference.aspose.com/slides/pl/net/aspose.slides/audioplaymodepreset) oraz `Volume` udostępniane przez obiekt [IAudioFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe).
6. Zapisz zmodyfikowaną prezentację.

Ten kod C# pokazuje, jak dodać osadzoną ramkę audio do slajdu:

```c#
// Tworzy instancję klasy prezentacji reprezentującej plik prezentacji
using (Presentation pres = new Presentation())
{
    // Pobiera pierwszy slajd
    ISlide sld = pres.Slides[0];
    
    // Wczytuje plik dźwiękowy wav do strumienia
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Dodaje ramkę audio
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Ustawia tryb odtwarzania i głośność audio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Zapisuje plik PowerPoint na dysku
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Zmień miniaturę ramki audio**

Kiedy dodajesz plik audio do prezentacji, audio pojawia się jako ramka z domyślnym standardowym obrazem (zobacz obraz w sekcji poniżej). Możesz zmienić miniaturę ramki audio (ustawić wybrany obraz).

Ten kod C# pokazuje, jak zmienić miniaturę lub obraz podglądu ramki audio:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Dodaje ramkę audio do slajdu z określoną pozycją i rozmiarem.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Dodaje obraz do zasobów prezentacji.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Ustawia obraz dla ramki audio.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//Zapisuje zmodyfikowaną prezentację na dysku
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Zmień opcje odtwarzania audio**

Aspose.Slides for .NET umożliwia zmianę opcji kontrolujących odtwarzanie lub właściwości audio. Na przykład możesz dostosować głośność audio, ustawić odtwarzanie w pętli lub nawet ukryć ikonę audio.

Panel **Audio Options** w Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opcje **Audio** w PowerPoint odpowiadają właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe):

- **Start** menu rozwijane odpowiada właściwości [AudioFrame.PlayMode](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/properties/playmode)
- **Volume** odpowiada właściwości [AudioFrame.Volume](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/properties/volume)
- **Play Across Slides** odpowiada właściwości [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/properties/playacrossslides)
- **Loop until Stopped** odpowiada właściwości [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/properties/playloopmode)
- **Hide During Show** odpowiada właściwości [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/properties/hideatshowing)
- **Rewind after Playing** odpowiada właściwości [AudioFrame.RewindAudio](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/properties/rewindaudio)

Opcje **Editing** w PowerPoint odpowiadają właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe):

- **Fade In** odpowiada właściwości [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/fadeinduration/)
- **Fade Out** odpowiada właściwości [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/fadeoutduration/)
- **Trim Audio Start Time** odpowiada właściwości [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/trimfromstart/)
- **Trim Audio End Time** wartość równa jest długości audio minus wartość właściwości [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/trimfromend/)

Kontrola **Volume** w PowerPoint na panelu sterowania audio odpowiada właściwości [AudioFrame.VolumeValue](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/volumevalue/). Pozwala zmienić głośność audio w procentach.

Tak zmieniasz opcje odtwarzania audio:

1. [Utwórz](#create-audio-frame) lub pobierz ramkę audio.
2. Ustaw nowe wartości dla właściwości ramki audio, które chcesz zmienić.
3. Zapisz zmodyfikowany plik PowerPoint.

Ten kod C# demonstruje operację, w której dostosowywane są opcje audio:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Pobiera kształt AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Ustawia tryb odtwarzania na odtwarzanie po kliknięciu
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Ustawia głośność na niski poziom
    audioFrame.Volume = AudioVolumeMode.Low;

    // Ustawia odtwarzanie audio na wszystkie slajdy
    audioFrame.PlayAcrossSlides = true;

    // Wyłącza pętlę dla audio
    audioFrame.PlayLoopMode = false;

    // Ukrywa AudioFrame podczas pokazu slajdów
    audioFrame.HideAtShowing = true;

    // Przewija audio do początku po odtworzeniu
    audioFrame.RewindAudio = true;

    // Zapisuje plik PowerPoint na dysku
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Ten przykład C# pokazuje, jak dodać nową ramkę audio z osadzonym dźwiękiem, przyciąć ją i ustawić czasy zanikania:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Ustawia początkowy offset przycinania na 1,5 sekundy
    audioFrame.TrimFromStart = 1500f;
    // Ustawia końcowy offset przycinania na 2 sekundy
    audioFrame.TrimFromEnd = 2000f;

    // Ustawia czas trwania płynnego wejścia na 200 ms
    audioFrame.FadeInDuration = 200f;
    // Ustawia czas trwania płynnego wyjścia na 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

Poniższy fragment kodu pokazuje, jak pobrać ramkę audio z osadzonym dźwiękiem i ustawić jej głośność na 85%:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Pobiera kształt AudioFrame
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Ustawia głośność audio na 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Zarządzaj napisami audio**

Aspose.Slides umożliwia dodawanie zamkniętych napisów do ramki audio za pomocą właściwości [CaptionTracks](https://reference.aspose.com/slides/pl/net/aspose.slides/iaudioframe/captiontracks/). Właściwość ta zwraca [ICaptionsCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/icaptionscollection/), co pozwala dodawać ścieżki napisów WebVTT, iterować po istniejących ścieżkach oraz usuwać je w razie potrzeby.

**Dodaj napisy audio**

Użyj właściwości [CaptionTracks](https://reference.aspose.com/slides/pl/net/aspose.slides/iaudioframe/captiontracks/), aby dołączyć jedną lub więcej ścieżek napisów do ramki audio. W poniższym przykładzie plik audio jest dodawany do slajdu, a następnie nowa ścieżka napisów jest wczytywana z pliku `.vtt`.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Dodaj nową ścieżkę napisów z pliku WebVTT.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Wyodrębnij napisy audio**

Możesz iterować po ścieżkach napisów powiązanych z ramką audio i zapisywać je jako pliki `.vtt`. Każda ścieżka napisów udostępnia swoje dane binarne oraz unikalny identyfikator, które mogą być użyte przy eksportowaniu napisów.

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
                // Zapisz ścieżkę napisów jako plik .vtt.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Usuń napisy audio**

Aby usunąć napisy z ramki audio, użyj metod udostępnionych przez [ICaptionsCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/icaptionscollection/), takich jak [Clear](https://reference.aspose.com/slides/pl/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/pl/net/aspose.slides/icaptionscollection/remove/), lub [RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides/icaptionscollection/removeat/). Poniższy przykład usuwa wszystkie ścieżki napisów z ramki audio.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Usuń wszystkie ścieżki napisów z ramki audio.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Wyodrębnij audio**

Aspose.Slides for .NET umożliwia wyodrębnienie dźwięku używanego w przejściach pokazu slajdów. Na przykład możesz wyodrębnić dźwięk używany w konkretnym slajdzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) i wczytaj prezentację zawierającą audio.
2. Uzyskaj referencję do odpowiedniego slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do przejść pokazu slajdów dla tego slajdu.
4. Wyodrębnij dźwięk jako dane bajtowe.

Ten kod C# pokazuje, jak wyodrębnić audio użyte w slajdzie:

```c#
string presName = "AudioSlide.pptx";

// Tworzy instancję klasy Presentation reprezentującej plik prezentacji
Presentation pres = new Presentation(presName);

// Uzyskuje dostęp do slajdu
ISlide slide = pres.Slides[0];

// Pobiera efekty przejścia pokazu slajdów dla slajdu
ISlideShowTransition transition = slide.SlideShowTransition;

//Ekstrahuje dźwięk w tablicy bajtów
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**Czy mogę ponownie używać tego samego zasobu audio na wielu slajdach bez zwiększania rozmiaru pliku?**

Tak. Dodaj audio raz do współdzielonej [audio collection](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/audios/) prezentacji i utwórz dodatkowe ramki audio, które odwołują się do istniejącego zasobu. To zapobiega duplikowaniu danych multimedialnych i utrzymuje rozmiar prezentacji pod kontrolą.

**Czy mogę zastąpić dźwięk w istniejącej ramce audio bez ponownego tworzenia kształtu?**

Tak. W przypadku dźwięku powiązanego, zaktualizuj [link path](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/linkpathlong/), aby wskazywał na nowy plik. W przypadku dźwięku osadzonego, zamień obiekt [embedded audio](https://reference.aspose.com/slides/pl/net/aspose.slides/audioframe/embeddedaudio/) na inny z [audio collection](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/audios/) prezentacji. Formatowanie ramki i większość ustawień odtwarzania pozostają niezmienione.

**Czy przycinanie zmienia podstawowe dane audio przechowywane w prezentacji?**

Nie. Przycinanie zmienia jedynie granice odtwarzania. Oryginalne bajty audio pozostają nienaruszone i dostępne poprzez osadzony dźwięk lub kolekcję audio prezentacji.