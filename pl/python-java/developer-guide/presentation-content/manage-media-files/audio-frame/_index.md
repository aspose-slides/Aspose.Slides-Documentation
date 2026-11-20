---
title: Zarządzanie ramkami audio w prezentacjach przy użyciu Pythona
linktitle: Ramka audio
type: docs
weight: 10
url: /pl/python-java/audio-frame/
keywords:
- dźwięk
- ramka audio
- miniatura
- dodaj dźwięk
- właściwości audio
- opcje audio
- wyodrębnij dźwięk
- Python
- Aspose.Slides
description: "Osadź dźwięk na slajdach, zmień ikonę audio, skonfiguruj odtwarzanie, zarządzaj napisami WebVTT i wyodrębnij dźwięki przejść slajdów przy użyciu Aspose.Slides dla Pythona via Java."
---
## **Przegląd**

Ramka audio pozwala odtwarzać dźwięk na slajdzie. Za pomocą Aspose.Slides for Python via Java możesz osadzić klip audio, wybrać obraz go reprezentujący, dostosować odtwarzanie i dołączyć napisy. Możesz także pobrać dźwięk przypisany do przejścia slajdu.

## **Utwórz ramki audio**

Dodaj bajty z `audio.wav` do kolekcji audio prezentacji, a następnie użyj [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) aby osadzić lokalny klip audio na pierwszym slajdzie. Pierwsze dwie współrzędne określają pozycję ramki na slajdzie, a kolejne dwie wartości ustawiają jej szerokość i wysokość, wszystkie w punktach. Ten przykład wywołuje [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) aby uruchomić klip automatycznie i wywołuje [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) aby wybrać głośny preset.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zmień miniaturę ramki audio**

Domyślnie ramka audio wyświetla ikonę głośnika. Aby wyświetlić niestandardową miniaturę, dodaj obraz do prezentacji za pomocą [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage), a następnie ustaw go w obrazie ramki za pomocą [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). Przykład używa pliku JPEG jako miniatury dla osadzonego klipu audio.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zmień opcje odtwarzania audio**

Kontrole **Audio Options** w PowerPoint określają, kiedy klip się rozpoczyna, jak głośno brzmi i jak zachowuje się podczas pokazu slajdów.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Kontrola PowerPoint | Metoda Aspose.Slides for Python via Java |
| --- | --- |
| Rozpocznij | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Ustawienie głośności | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Odtwarzaj na kilku slajdach | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Pętla aż do zatrzymania | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Ukryj podczas pokazu | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Przewiń po odtworzeniu | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Płynne włączenie | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Płynne wyłączenie | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Przytnij początkowy czas audio | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Przytnij końcowy czas audio | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Suwak głośności | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

Przykład znajduje pierwszą ramkę audio na pierwszym slajdzie, wywołuje [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) aby uruchomić odtwarzanie po kliknięciu i wybiera niski preset głośności. Klip kontynuuje odtwarzanie na kolejnych slajdach przy wyłączonej pętli. Ikona pozostaje ukryta podczas pokazu, a klip przewija się po odtworzeniu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # Odtwarzaj po kliknięciu przy niskiej głośności, na wielu slajdach, bez pętli.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Ukryj ramkę podczas pokazu slajdów i przewiń po odtworzeniu.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

Dla klipu dłuższego niż 3,5 s, ten przykład pomija pierwsze 1,5 s i ostatnie 2 s. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) przyjmuje czas do pominięcia na końcu klipu. Aby uzyskać czas końcowy wyświetlany w PowerPoint, odejmij ten offset od pełnej długości klipu. Przycięty klip wchodzi płynnie w ciągu 200 ms i wychodzi w ciągu 500 ms. Wszystkie cztery metody przyjmują wartości w milisekundach.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Przytnij 1,5 sekundy od początku i 2 sekundy od końca.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Ustaw płynne włączenie na 200 ms i płynne wyłączenie na 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aby ustawić głośność odtwarzania na określony procent, użyj [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). Ten przykład ustawia pierwszą ramkę audio na pierwszym slajdzie na 85 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **Zarządzaj napisami audio**

Każda ramka audio udostępnia dostęp do swoich ścieżek napisów poprzez [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Użyj kolekcji, aby dołączyć napisy WebVTT do klipu, wyeksportować istniejące ścieżki lub je usunąć.

### **Dodaj napisy audio**

Przykład osadza klip audio na pierwszym slajdzie i używa [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) aby dołączyć lokalną ścieżkę WebVTT. Pierwszy argument podaje etykietę ścieżki, a drugi wskazuje plik zawierający napisy czasowe.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Dodaj nową ścieżkę napisów z pliku WebVTT.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Wyodrębnij napisy audio**

Ten przykład eksportuje każdą ścieżkę napisów podłączoną do ramki audio na pierwszym slajdzie. Zapisuje bajty zwrócone przez [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) do pliku WebVTT i używa identyfikatora zwróconego przez [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) jako nazwy pliku, tak aby każda ścieżka miała osobny wynik.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Zapisz ścieżkę napisów jako plik .vtt.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Usuń napisy audio**

Użyj [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) lub [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) aby usunąć pojedynczą ścieżkę. Przykład używa [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) aby usunąć wszystkie napisy z pierwszej ramki audio na pierwszym slajdzie, zachowując klip.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **Znajdź linię w napisach audio**

Aby znaleźć linię w napisach audio na pierwszym slajdzie, przeszukaj tekst zwrócony przez [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) w pamięci. W zwykłym pliku WebVTT linia z czasem zawiera `-->`, linie napisów następują po niej, a pusta linia kończy podpowiedź. Ten przykład wypisuje etykietę ścieżki oraz każdą linię napisu zawierającą „café”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **Wyodrębnij audio**

Przejście slajdu może mieć własny dźwięk. Aby go pobrać, wywołaj [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) na przejściu slajdu. Przykład uzyskuje bajty zwrócone przez [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) i wypisuje liczbę bajtów. Jeśli pierwszy slajd nie ma dźwięku przejścia, wypisuje komunikat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę ponownie użyć tego samego klipu audio na wielu slajdach bez duplikowania go?**

Tak. Dodaj klip raz do [kolekcja audio](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) prezentacji i przekaż ten sam obiekt audio do [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) dla każdego slajdu.

**Czy mogę zastąpić dźwięk w istniejącej ramce audio?**

Tak. Dla dźwięku powiązanego użyj [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong), aby wskazać plik zastępczy. Dla dźwięku osadzonego wybierz inny klip z kolekcji audio prezentacji przy pomocy [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Oba podejścia zachowują istniejącą ramkę.

**Czy przycinanie zmienia dane audio przechowywane w prezentacji?**

Nie. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) i [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) ustalają granice odtwarzania. Pełny klip wciąż można pobrać za pomocą [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).