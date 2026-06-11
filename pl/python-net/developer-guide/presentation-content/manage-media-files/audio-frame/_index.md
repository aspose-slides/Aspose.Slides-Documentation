---
title: Zarządzanie dźwiękiem w prezentacjach przy użyciu Pythona
linktitle: Ramka audio
type: docs
weight: 10
url: /pl/python-net/audio-frame/
keywords:
- dodaj audio
- osadź audio
- ramka audio
- plik audio
- właściwości audio
- wyodrębnij audio
- pobierz audio
- zmień audio
- opcje odtwarzania
- tryb odtwarzania
- odtwarzaj na wszystkich slajdach
- pętla do zatrzymania
- ukryj podczas pokazu
- przewiń po odtworzeniu
- głośność audio
- domyślny obraz
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Łatwo dodawaj, wyodrębniaj i zarządzaj ramkami audio w PPT, PPTX i ODP za pomocą Aspose.Slides for Python via .NET. Odkryj przykłady kodu i ulepsz swoje prezentacje już dziś."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z ramkami audio w Aspose.Slides. Pokazuje, jak dodać osadzone audio do slajdów, dostosować miniaturę ramki audio, skonfigurować opcje odtwarzania, takie jak głośność, pętla, ukrywanie, przycinanie i czasy zanikania, oraz wyodrębnić dźwięk używany w przejściach pokazu slajdów.

## **Tworzenie ramek audio**

Aspose.Slides for Python via .NET umożliwia dodawanie plików audio do slajdów. Pliki audio są osadzane w slajdach jako ramki audio.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Wczytaj strumień pliku audio, który chcesz osadzić w slajdzie.
4. Dodaj osadzoną ramkę audio (zawierającą plik audio) do slajdu.
5. Ustaw [PlayMode](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioplaymodepreset) oraz `Volume` udostępniane przez obiekt [IAudioFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/).
6. Zapisz zmodyfikowaną prezentację.

Ten kod w Pythonie pokazuje, jak dodać osadzoną ramkę audio do slajdu:

```python
import aspose.slides as slides

# Utwórz klasę prezentacji reprezentującą plik prezentacji
with slides.Presentation() as pres:
    # Pobiera pierwszy slajd
    sld = pres.slides[0]

    # Wczytuje plik wav do strumienia
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Dodaje ramkę audio
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Ustawia tryb odtwarzania i głośność audio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Zapisuje plik PowerPoint na dysku
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmienianie miniatury ramki audio**

Gdy dodajesz plik audio do prezentacji, audio pojawia się jako ramka z domyślnym standardowym obrazem (zobacz obraz w sekcji poniżej). Możesz zmienić miniaturę ramki audio (ustawić wybrany obraz).

Ten kod w Pythonie pokazuje, jak zmienić miniaturę lub podglądowy obraz ramki audio:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dodaje ramkę audio do slajdu z określonym położeniem i rozmiarem.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Dodaje obraz do zasobów prezentacji.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Ustawia obraz dla ramki audio.
        audioFrame.picture_format.picture.image = audioImage
        
        #Zapisuje zmodyfikowaną prezentację na dysku
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmiana opcji odtwarzania audio**

Aspose.Slides for Python via .NET umożliwia zmianę opcji kontrolujących odtwarzanie lub właściwości audio. Na przykład możesz dostosować głośność audio, ustawić odtwarzanie w pętli lub nawet ukryć ikonę audio.

Panel **Audio Options** w Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opcje **Audio** w PowerPoint, które odpowiadają właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/) :

- **Start** lista rozwijana odpowiada właściwości [AudioFrame.play_mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/play_mode/) 
- **Volume** odpowiada właściwości [AudioFrame.volume](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/volume/) 
- **Play Across Slides** odpowiada właściwości [AudioFrame.play_across_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/play_across_slides/) 
- **Loop until Stopped** odpowiada właściwości [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/play_loop_mode/) 
- **Hide During Show** odpowiada właściwości [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/hide_at_showing/) 
- **Rewind after Playing** odpowiada właściwości [AudioFrame.rewind_audio](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/rewind_audio/) 

Opcje **Editing** w PowerPoint, które odpowiadają właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/) :

- **Fade In** odpowiada właściwości [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/fade_in_duration/) 
- **Fade Out** odpowiada właściwości [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/fade_out_duration/) 
- **Trim Audio Start Time** odpowiada właściwości [AudioFrame.trim_from_start](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/trim_from_start/) 
- **Trim Audio End Time** wartość równa jest długości audio minus wartość właściwości [AudioFrame.trim_from_end](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/trim_from_end/) 

Kontrolka **Volume** w panelu sterowania audio w PowerPoint odpowiada właściwości [AudioFrame.volume_value](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/volume_value/). Umożliwia zmianę głośności audio w procentach.

Tak zmieniasz opcje odtwarzania audio:

1. [Utwórz](#create-audio-frame) lub uzyskaj ramkę audio.
2. Ustaw nowe wartości właściwości ramki audio, które chcesz zmienić.
3. Zapisz zmodyfikowany plik PowerPoint.

Ten kod w Pythonie demonstruje operację, w której zmieniane są opcje audio:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Pobiera kształt AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Ustawia tryb odtwarzania na odtwarzanie po kliknięciu
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Ustawia głośność na niski poziom
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Ustawia odtwarzanie audio na wszystkich slajdach
    audioFrame.play_across_slides = True

    # Wyłącza pętlę dla audio
    audioFrame.play_loop_mode = False

    # Ukrywa AudioFrame podczas pokazu slajdów
    audioFrame.hide_at_showing = True

    # Przewija audio do początku po odtworzeniu
    audioFrame.rewind_audio = True

    # Zapisuje plik PowerPoint na dysku
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Ten przykład w Pythonie pokazuje, jak dodać nową ramkę audio z osadzonym dźwiękiem, przyciąć ją i ustawić czasy zanikania:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Ustawia początkowy offset przycinania na 1,5 sekundy
    audio_frame.trim_from_start = 1500.0
    # Ustawia końcowy offset przycinania na 2 sekundy
    audio_frame.trim_from_end = 2000.0

    # Ustawia czas trwania fade-in na 200 ms
    audio_frame.fade_in_duration = 200.0
    # Ustawia czas trwania fade-out na 500 ms
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Poniższy fragment kodu pokazuje, jak pobrać ramkę audio z osadzonym dźwiękiem i ustawić jej głośność na 85%:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Pobiera kształt ramki audio
    audio_frame = pres.slides[0].shapes[0]

    # Ustawia głośność audio na 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zarządzanie napisami audio**

Aspose.Slides umożliwia dodawanie napisów zamkniętych do ramki audio za pomocą właściwości [caption_tracks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/caption_tracks/). Właściwość ta zwraca [CaptionsCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/), co pozwala dodawać ścieżki napisów WebVTT, iterować po istniejących ścieżkach i usuwać je w razie potrzeby.

**Dodaj napisy audio**

Użyj właściwości [caption_tracks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/caption_tracks/) , aby dołączyć jedną lub więcej ścieżek napisów do ramki audio. W poniższym przykładzie plik audio jest dodawany do slajdu, a następnie nowa ścieżka napisów jest wczytywana z pliku `.vtt`.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Dodaj nową ścieżkę napisów z pliku WebVTT.
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Wyodrębnij napisy audio**

Możesz iterować po ścieżkach napisów powiązanych z ramką audio i zapisywać je jako pliki `.vtt`. Każda ścieżka napisów udostępnia swoje dane binarne oraz unikalny identyfikator, które mogą być użyte przy eksportowaniu napisów.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Zapisz ścieżkę napisów jako plik .vtt.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Usuń napisy audio**

Aby usunąć napisy z ramki audio, użyj metod dostępnych w [CaptionsCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/), takich jak [clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/remove/), lub [remove_at](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/remove_at/). Poniższy przykład usuwa wszystkie ścieżki napisów z ramki audio.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # type: slides.AudioFrame

    # Usuń wszystkie ścieżki napisów z ramki audio.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Wyodrębnianie audio**

Aspose.Slides for Python via .NET umożliwia wyodrębnienie dźwięku używanego w przejściach pokazu slajdów. Na przykład możesz wyodrębnić dźwięk używany w konkretnym slajdzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wczytaj prezentację zawierającą audio.
2. Uzyskaj odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do przejść pokazu slajdów dla slajdu.
4. Wyodrębnij dźwięk w postaci danych bajtowych.

Ten kod w Pythonie pokazuje, jak wyodrębnić audio używane w slajdzie:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Uzyskuje dostęp do wybranego slajdu
    slide = pres.slides[0]  

    # Pobiera efekty przejścia pokazu slajdów dla slajdu
    transition = slide.slide_show_transition

    #Wyodrębnia dźwięk w tablicy bajtów
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**Czy mogę ponownie używać tego samego zasobu audio na wielu slajdach bez zwiększania rozmiaru pliku?**

Tak. Dodaj audio raz do współdzielonej [audio collection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/audios/) prezentacji i utwórz dodatkowe ramki audio, które odwołują się do istniejącego zasobu. Dzięki temu unika się duplikowania danych medialnych i rozmiar prezentacji pozostaje pod kontrolą.

**Czy mogę wymienić dźwięk w istniejącej ramce audio bez ponownego tworzenia kształtu?**

Tak. W przypadku dźwięku powiązanego, zaktualizuj [link path](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/link_path_long/) , aby wskazywał na nowy plik. W przypadku dźwięku osadzonego, zamień obiekt [embedded audio](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audioframe/embedded_audio/) na inny z [audio collection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/audios/) prezentacji. Formatowanie ramki i większość ustawień odtwarzania pozostają niezmienione.

**Czy przycinanie zmienia podstawowe dane audio przechowywane w prezentacji?**

Nie. Przycinanie zmienia tylko granice odtwarzania. Oryginalne bajty audio pozostają niezmienione i dostępne poprzez osadzony audio lub kolekcję audio prezentacji.