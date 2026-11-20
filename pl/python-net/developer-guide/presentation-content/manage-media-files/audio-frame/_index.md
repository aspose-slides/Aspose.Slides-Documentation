---
title: Zarządzanie ramkami audio w prezentacjach przy użyciu Pythona
linktitle: Rama audio
type: docs
weight: 10
url: /pl/python-net/audio-frame/
keywords:
- dźwięk
- ramka audio
- miniatura
- dodaj audio
- właściwości audio
- opcje audio
- wyodrębnij audio
- WebVTT
- Python
- Aspose.Slides
description: "Osadź dźwięk w slajdach, zmień ikonę audio, skonfiguruj odtwarzanie, zarządzaj napisami WebVTT i wyodrębnij dźwięki przejść slajdów przy użyciu Aspose.Slides for Python via .NET."
---
## **Przegląd**

Rama dźwiękowa umożliwia odtworzenie dźwięku na slajdzie. Dzięki Aspose.Slides for Python via .NET możesz wstawić klip audio, wybrać obraz go reprezentujący, dostosować odtwarzanie i dodać napisy. Możesz także pobrać dźwięk przypisany do przejścia slajdu.

## **Utwórz ramki audio**

Użyj [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) aby osadzić lokalny klip audio na pierwszym slajdzie. Pierwsze dwa współrzędne określają pozycję ramki na slajdzie, a kolejne dwie wartości ustawiają jej szerokość i wysokość, wszystkie w punktach. Ten przykład ustawia [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) na automatyczne uruchomienie klipu oraz [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) na głośny preset.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmień miniaturkę ramki audio**

Domyślnie rama audio wyświetla ikonę głośnika. Aby wyświetlić własną miniaturkę, dodaj obraz do prezentacji za pomocą [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) i przypisz go do własności [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/). Przykład używa pliku JPEG jako miniaturki dla osadzonego klipu audio.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmień opcje odtwarzania audio**

Kontrole **Audio Options** w PowerPoint określają, kiedy klip się rozpoczyna, jak głośno brzmi i jak zachowuje się podczas pokazu slajdów.

![Kontrole Audio Options w PowerPoint dla ramki audio](audio_frame_0.png)

| Kontrola PowerPoint | Właściwość Aspose.Slides |
| --- | --- |
| Rozpocznij | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Ustawienie głośności | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Odtwarzaj na wielu slajdach | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Pętla aż do zatrzymania | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Ukryj podczas pokazu | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Przewiń po odtworzeniu | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Płynne pojawienie | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Płynne zniknięcie | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Przytnij początek audio | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Przytnij koniec audio | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Suwak głośności | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

Przykład znajduje pierwszą ramkę audio na pierwszym slajdzie, ustawia [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) na rozpoczęcie odtwarzania po kliknięciu i wybiera niskie ustawienie głośności. Klip kontynuuje odtwarzanie na kolejnych slajdach przy wyłączonej pętli. Ikona pozostaje ukryta podczas pokazu, a klip przewija się po odtworzeniu.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Dla klipu dłuższego niż 3,5 sekundy, ten przykład pomija pierwsze 1,5 sekundy i ostatnie 2 sekundy. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) mierzy czas do pominięcia na końcu klipu. Aby uzyskać czas końcowy wyświetlany w PowerPoint, odejmij tę wartość od całkowitej długości klipu. Przycięty klip płynnie wchodzi w ciągu 200 milisekund i płynnie wychodzi w ciągu 500 milisekund. Wszystkie cztery właściwości przyjmują wartości w milisekundach.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Aby ustawić głośność odtwarzania na określony odsetek, użyj [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Ten przykład ustawia pierwszą ramkę audio na pierwszym slajdzie na 85%.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zarządzaj napisami audio**

Każda rama audio posiada kolekcję [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/) . Użyj jej, aby dołączyć napisy WebVTT do klipu, wyeksportować istniejące ścieżki lub je usunąć.

### **Dodaj napisy audio**

Przykład osadza klip audio na pierwszym slajdzie i używa [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) aby dołączyć lokalną ścieżkę WebVTT. Pierwszy argument podaje etykietę ścieżki, a drugi identyfikuje plik zawierający napisy czasowe.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Wyodrębnij napisy audio**

Ten przykład eksportuje każdą ścieżkę napisów dołączoną do ramki audio na pierwszym slajdzie. Zapisuje [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) ścieżki do pliku WebVTT i używa jej [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) jako nazwy pliku, aby każda ścieżka miała osobny wynik.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **Usuń napisy audio**

Użyj [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) lub [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) aby usunąć pojedynczą ścieżkę. Przykład używa [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) aby usunąć wszystkie napisy z pierwszej ramki audio na pierwszym slajdzie, zachowując klip.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Znajdź wiersz w napisach audio**

Aby znaleźć wiersz w napisach audio na pierwszym slajdzie, odczytaj w pamięci [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) każdej ścieżki. W zwykłej wskazówce WebVTT linia z czasem zawiera `-->`, po niej następują linie napisów, a pusty wiersz kończy wskazówkę. Ten przykład wypisuje etykietę ścieżki oraz każdą linię napisu zawierającą „café”.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **Wyodrębnij audio**

Przejście slajdu może mieć własny dźwięk. Aby go pobrać, odczytaj własność [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) przejścia. Przykład uzyskuje dostęp do [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) dźwięku i wypisuje jego rozmiar w bajtach. Jeśli pierwszy slajd nie ma dźwięku przejścia, wypisuje komunikat.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **FAQ**

**Czy mogę ponownie używać tego samego klipu audio na wielu slajdach bez jego duplikowania?**

Tak. Dodaj klip raz do [kolekcja audio](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) i przekaż ten sam obiekt audio do [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) dla każdego slajdu.

**Czy mogę zamienić dźwięk w istniejącej ramce audio?**

Tak. Dla dźwięku połączonego, zaktualizuj [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) aby wskazywał na plik zastępczy. Dla dźwięku osadzonego, przypisz inny klip z [kolekcja audio] prezentacji do [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/). Oba podejścia zachowują istniejącą ramkę.

**Czy przycinanie zmienia dane audio przechowywane w prezentacji?**

Nie. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) i [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) ustalają granice odtwarzania. Nadal możesz pobrać pełny klip z [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/).