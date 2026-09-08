---
title: Zarządzanie dźwiękiem w prezentacjach przy użyciu Pythona
linktitle: Ramka audio
type: docs
weight: 10
url: /pl/python-java/audio-frame/
keywords:
- dźwięk
- ramka audio
- miniatura
- dodaj dźwięk
- właściwości dźwięku
- opcje dźwięku
- wyodrębnij dźwięk
- Python
- Aspose.Slides
description: "Twórz i kontroluj ramki audio w Aspose.Slides for Python via Java — przykłady kodu do osadzania, przycinania, zapętlania i konfigurowania odtwarzania w prezentacjach PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z ramkami audio w Aspose.Slides. Pokazuje, jak dodać osadzony dźwięk do slajdów, dostosować miniaturę ramki audio, skonfigurować opcje odtwarzania, takie jak głośność, zapętlanie, ukrywanie, przycinanie i czasy zanikania, oraz wyodrębnić dźwięk używany w przejściach pokazu slajdów.

## **Utworzenie ramek audio**

Aspose.Slides for Python via Java umożliwia dodawanie plików audio do slajdów. Pliki audio są osadzane w slajdach jako ramki audio. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Odczytaj plik audio, który chcesz osadzić w slajdzie.
4. Dodaj osadzoną ramkę audio (zawierającą plik audio) do slajdu.
5. Ustaw [setPlayMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setPlayMode) i [setVolume](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setVolume) udostępnione przez obiekt [AudioFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/).
6. Zapisz zmodyfikowaną prezentację.

Ten kod w Pythonie pokazuje, jak dodać osadzoną ramkę audio do slajdu:

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

Kiedy dodajesz plik audio do prezentacji, audio wyświetlane jest jako ramka ze standardowym domyślnym obrazem (zobacz obraz w sekcji poniżej). Możesz zmienić podglądowy obraz ramki audio (ustawić wybrany obraz).

Ten kod w Pythonie pokazuje, jak zmienić miniaturę lub podglądowy obraz ramki audio:

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
    audio_data = Path("sample2.mp3").read_bytes()
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

Aspose.Slides for Python via Java umożliwia zmianę opcji kontrolujących odtwarzanie lub właściwości audio. Na przykład możesz dostosować głośność audio, ustawić odtwarzanie w pętli lub nawet ukryć ikonę audio.

Panel **Audio Options** w Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opcje **Audio Options** w PowerPoint, które odpowiadają właściwościom [AudioFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/) Aspose.Slides:

- **Start** lista rozwijana odpowiada metodzie [setPlayMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** odpowiada metodzie [setVolume](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** odpowiada metodzie [setPlayAcrossSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** odpowiada metodzie [setPlayLoopMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** odpowiada metodzie [setHideAtShowing](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** odpowiada metodzie [setRewindAudio](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setRewindAudio)

Opcje **Editing** w PowerPoint, które odpowiadają właściwościom [AudioFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/) Aspose.Slides:

- **Fade In** odpowiada metodzie [setFadeInDuration](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** odpowiada metodzie [setFadeOutDuration](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** odpowiada metodzie [setTrimFromStart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** wartość równa jest długości audio minus wartość metody [setTrimFromEnd](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setTrimFromEnd)

Kontrola **Volume control** w panelu audio w PowerPoint odpowiada metodzie [setVolumeValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setVolumeValue). Umożliwia zmianę głośności audio w procentach.

Tak zmienisz opcje odtwarzania audio:

1. [Utwórz](#create-audio-frames) lub uzyskaj ramkę audio.
2. Ustaw nowe wartości właściwości ramki audio, które chcesz zmienić.
3. Zapisz zmodyfikowany plik PowerPoint.

Ten kod w Pythonie demonstruje operację, w której zmieniane są opcje audio:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Odtwarzaj po kliknięciu przy niskiej głośności, na wszystkich slajdach, bez zapętlania.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Ukryj ramkę podczas pokazu slajdów i przewiń po odtworzeniu.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Ten przykład w Pythonie pokazuje, jak dodać nową ramkę audio z osadzonym dźwiękiem, przyciąć ją i ustawić czasy zanikania:

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
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpage.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Przytnij 1,5 sekundy od początku i 2 sekundy od końca.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Ustaw fade-in na 200 ms i fade-out na 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poniższy fragment kodu pokazuje, jak pobrać ramkę audio z osadzonym dźwiękiem i ustawić jej głośność na 85%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Zarządzanie napisami audio**

Aspose.Slides umożliwia dodawanie zamkniętych napisów do ramki audio za pomocą metody [getCaptionTracks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#getCaptionTracks). Metoda ta zwraca [CaptionsCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/), co pozwala dodawać ścieżki napisów WebVTT, iterować istniejące ścieżki i usuwać je w razie potrzeby.

**Dodaj napisy audio**

Użyj metody [getCaptionTracks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#getCaptionTracks) aby dołączyć jedną lub więcej ścieżek napisów do ramki audio. W poniższym przykładzie plik audio jest dodawany do slajdu, a następnie nowa ścieżka napisów jest ładowana z pliku `.vtt`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Dodaj nową ścieżkę napisów z pliku WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Wyodrębnij napisy audio**

Możesz iterować po ścieżkach napisów powiązanych z ramką audio i zapisywać je jako pliki `.vtt`. Każda ścieżka napisu udostępnia swoje dane binarne oraz unikalny identyfikator, które mogą być użyte przy eksportowaniu napisów.

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
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Usuń napisy audio**

Aby usunąć napisy z ramki audio, użyj metod udostępnionych przez [CaptionsCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/), takich jak [clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/#remove) lub [removeAt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/#removeAt). Poniższy przykład usuwa wszystkie ścieżki napisów z ramki audio.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Wyodrębnij audio**

Aspose.Slides for Python via Java umożliwia wyodrębnienie dźwięku używanego w przejściach pokazu slajdów. Na przykład możesz wyodrębnić dźwięk używany w konkretnym slajdzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą audio.
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do [slideshow transitions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getSlideShowTransition) dla slajdu.
4. Wyodrębnij dźwięk w postaci danych bajtowych.

Ten kod w Pythonie pokazuje, jak wyodrębnić audio użyte w slajdzie:

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
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę ponownie używać tego samego zasobu audio na wielu slajdach bez zwiększania rozmiaru pliku?**

Tak. Dodaj dźwięk raz do współdzielonej [audio collection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getAudios) prezentacji i utwórz dodatkowe ramki audio, które będą odwoływać się do istniejącego zasobu. Zapobiega to duplikowaniu danych multimedialnych i utrzymuje rozmiar prezentacji pod kontrolą.

**Czy mogę zamienić dźwięk w istniejącej ramce audio bez ponownego tworzenia kształtu?**

Tak. W przypadku dźwięku połączonego, zaktualizuj [link path](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setLinkPathLong), aby wskazywał na nowy plik. W przypadku dźwięku osadzonego, zamień obiekt [embedded audio](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/#setEmbeddedAudio) na inny z [audio collection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getAudios) prezentacji. Formatowanie ramki i większość ustawień odtwarzania pozostają niezmienione.

**Czy przycinanie zmienia podstawowe dane audio przechowywane w prezentacji?**

Nie. Przycinanie zmienia tylko granice odtwarzania. Oryginalne bajty audio pozostają niezmienione i dostępne poprzez osadzony dźwięk lub kolekcję audio prezentacji.