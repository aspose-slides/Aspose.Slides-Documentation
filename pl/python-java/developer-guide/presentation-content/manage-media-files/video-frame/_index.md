---
title: Zarządzaj ramkami wideo w prezentacjach przy użyciu Pythona
linktitle: Ramka wideo
type: docs
weight: 10
url: /pl/python-java/video-frame/
keywords:
- dodaj wideo
- utwórz wideo
- osadź wideo
- wyodrębnij wideo
- pobierz wideo
- ramka wideo
- źródło internetowe
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona poprzez Javę. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Filmy mogą pomóc wyjaśnić pomysły i zaangażować odbiorców. Aspose.Slides for Python via Java pozwala dodawać ramki wideo do slajdów, dostosowywać ustawienia odtwarzania, zarządzać napisami i wyodrębniać osadzone dane wideo.

PowerPoint obsługuje lokalne filmy oraz linki do filmów online, takich jak filmy z YouTube.

Aby reprezentować dane wideo i ramki wideo, Aspose.Slides udostępnia klasę [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/), klasę [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) oraz inne istotne typy.

## **Utwórz osadzoną ramkę wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w swojej prezentacji.

Ten przykład osadza lokalny plik wideo na pierwszym slajdzie istniejącej prezentacji i zapisuje wynik. Współrzędne i wymiary ramki są podane w punktach. Python odczytuje bajty wideo z dysku, a JPype konwertuje je na tablicę bajtów Javy przed dodaniem wideo do prezentacji.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Możesz również przekazać lokalną ścieżkę do wideo bezpośrednio do [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Ten przykład osadza wideo na pierwszym slajdzie nowej prezentacji. Wideo musi pozostawać dostępne aż do zapisania prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Utwórz ramkę wideo z wideo z źródła internetowego**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) obsługuje filmy online w prezentacjach. Możesz utworzyć ramkę wideo, która odwołuje się do filmu online, takiego jak film z YouTube.

Ten przykład dodaje link do filmu YouTube oraz miniaturę na pierwszy slajd. Zamień identyfikator wideo, aby użyć innego filmu. Metoda [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) żąda automatycznego odtwarzania. Pobranie miniatury i odtworzenie wideo wymaga dostępu do Internetu. Odtwarzacz prezentacji musi również obsługiwać odtwarzanie wideo online.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Odtwórz wideo w trybie pełnoekranowym**

W prezentacji szkoleniowej możesz odtworzyć demonstrację oprogramowania w trybie pełnoekranowym, aby odbiorcy mogli zobaczyć szczegóły. Wywołaj [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) z wartością `True`, aby włączyć to zachowanie podczas odtwarzania.

Ten przykład otwiera prezentację, znajduje pierwszą [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) na pierwszym slajdzie i włącza odtwarzanie pełnoekranowe. Wejściowa prezentacja musi zawierać co najmniej jeden slajd z istniejącą ramką wideo na pierwszym slajdzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Odtwarzanie pełnoekranowe kontroluje, jak wideo jest wyświetlane. Oddzielnie, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) określa, czy rozpoczyna się automatycznie czy po kliknięciu, a [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) określa, czy powtarza się. Aby wybrać zachowanie początkowe, ustaw tryb odtwarzania na [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Przykład zachowuje istniejące ustawienia rozpoczęcia i pętli.

## **Przewiń wideo po odtworzeniu**

W prezentacji szkoleniowej przywrócenie demonstracji wideo do początku pozwala prelegentowi odtworzyć ją ponownie. Wywołaj [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) z wartością `True`, aby po zakończeniu odtwarzania wideo wróciło do początku.

Ten przykład otwiera prezentację, znajduje pierwszą [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) na pierwszym slajdzie i włącza przewijanie. Wyłącza pętlę, aby odtwarzanie mogło się zakończyć, i ustawia odtwarzanie na rozpoczęcie po kliknięciu. Wejściowa prezentacja musi zawierać co najmniej jeden slajd z istniejącą ramką wideo na pierwszym slajdzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Przewijanie zwraca wideo do początku bez ponownego uruchamiania. W przeciwieństwie do tego, wywołanie [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) z wartością `True` powoduje automatyczne powtarzanie odtwarzania. Utrzymuj pętlę wyłączoną, gdy chcesz, aby wideo zakończyło się i było gotowe do ponownego odtworzenia. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) niezależnie kontroluje automatyczne lub kliknięciowe uruchomienie; w przykładzie użyto [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/), aby prelegent kontrolował moment rozpoczęcia odtwarzania. Ustaw tryb odtwarzania po ustawieniu pętli, jak pokazano w przykładzie. Przewijanie działa niezależnie od [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Przytnij ramkę wideo**

Użyj [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) i [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd), aby pominąć część początku lub końca wideo podczas odtwarzania. Obie wartości podawane są w milisekundach. Przycinanie zmienia ustawienia odtwarzania bez modyfikacji osadzonych danych wideo.

**Ustawienia przycięcia**

Ten przykład osadza lokalny plik wideo i pomija pierwsze 2,5 sekundy oraz ostatnią sekundę podczas odtwarzania. Użyj wideo dłuższego niż 3,5 sekundy, aby pozostał odtwarzalny fragment.

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Odczytaj ustawienia przycięcia**

Ten przykład wypisuje wartości przycięcia pierwszej ramki wideo na pierwszym slajdzie w milisekundach. Prezentacja musi zawierać co najmniej jeden slajd. Jeśli ten slajd nie ma ramki wideo, nic nie zostanie wypisane. Poprzedni przykład generuje wartości 2500 i 1000.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Zarządzaj napisami wideo**

Aspose.Slides umożliwia zarządzanie zamkniętymi napisami dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane za pośrednictwem metody [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Dodaj napisy do ramki wideo**

Ten przykład osadza lokalny plik wideo i dodaje ścieżkę napisów WebVTT oznaczoną jako English. Znaczniki czasu napisów powinny pasować do wideo. Zapisana prezentacja zawiera zarówno wideo, jak i jego napisy.

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

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Dodaj nową ścieżkę napisów z pliku WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Klasa [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) zapewnia również przeciążenie, które pozwala dodać napisy z strumienia.

**Wyodrębnij napisy z ramki wideo**

Ten przykład zapisuje wszystkie ścieżki napisów z ramek wideo na pierwszym slajdzie jako oddzielne pliki WebVTT. Numeracja zapewnia uniknięcie konfliktów nazw plików wyjściowych. Konsola raportuje liczbę wyodrębnionych ścieżek. Prezentacja musi zawierać co najmniej jeden slajd.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Każdy obiekt [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF‑8.

**Usuń napisy z ramki wideo**

Ten przykład usuwa wszystkie napisy z ramki wideo znajdującej się na pierwszej pozycji kształtu na pierwszym slajdzie i zapisuje wynik. Zakłada, że slajd i kształt istnieją oraz że kształt jest ramką wideo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Usuń wszystkie napisy z ramki wideo.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisów, użyj metod [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) lub [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) zamiast [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **Wyodrębnij wideo ze slajdu**

Oprócz dodawania wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

Ten przykład wyodrębnia osadzone wideo ze wszystkich slajdów do oddzielnych, numerowanych plików binarnych. Połączone (linkowane) wideo jest pomijane, ponieważ nie ma osadzonych danych. Konsola wypisuje typ MIME każdego wideo oraz łączną liczbę. Wyjściowe pliki używają ogólnego rozszerzenia `.bin`; w razie potrzeby zmień je na odpowiednie w zależności od typu mediów.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **Najczęściej zadawane pytania**

**Jakie parametry odtwarzania wideo można zmienić dla ramki wideo?**

Możesz kontrolować [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto lub po kliknięciu) oraz [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Opcje te są dostępne poprzez metody obiektu [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalny plik wideo, dane binarne są dołączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy linkujesz wideo online i dodajesz miniaturę, prezentacja przechowuje jedynie link i obraz podglądu, a nie dane wideo, więc przyrost rozmiaru jest zazwyczaj mniejszy.

**Czy mogę wymienić wideo w istniejącej ramce wideo bez zmiany jej pozycji i rozmiaru?**

Tak. Możesz zamienić [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) w ramce, zachowując geometrię kształtu; jest to częsty scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo posiada [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType), który można odczytać i wykorzystać, na przykład przy zapisie na dysk.