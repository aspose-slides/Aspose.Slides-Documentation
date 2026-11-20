---
title: Zarządzanie ramkami wideo w prezentacjach przy użyciu Pythona
linktitle: Ramka wideo
type: docs
weight: 10
url: /pl/python-java/video-frame/
keywords:
- dodaj wideo
- utwórz wideo
- osadź wideo
- wyodrębij wideo
- pobierz wideo
- ramka wideo
- źródło internetowe
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Naucz się programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via Java. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Wideo może pomóc wyjaśnić pomysły i zaangażować publiczność. Aspose.Slides for Python via Java umożliwia dodawanie ramek wideo do slajdów, dostosowywanie ustawień odtwarzania, zarządzanie napisami oraz wyodrębnianie osadzonych danych wideo.

PowerPoint obsługuje lokalne filmy oraz odnośniki do filmów online, takich jak filmy z YouTube.

Aby reprezentować dane wideo i ramki wideo, Aspose.Slides udostępnia klasę [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/), klasę [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) oraz inne odpowiednie typy.

## **Utworzenie osadzonej ramki wideo**

Jeśli plik wideo, który chcesz dodać do swojego slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w prezentacji.

Ten przykład osadza lokalne wideo na pierwszym slajdzie istniejącej prezentacji i zapisuje wynik. Współrzędne i wymiary ramki są podane w punktach. Python odczytuje bajty wideo z dysku, a JPype konwertuje je na tablicę bajtów Javy przed dodaniem wideo do prezentacji.

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

Możesz także przekazać ścieżkę do lokalnego wideo bezpośrednio do [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Ten przykład osadza wideo na pierwszym slajdzie nowej prezentacji. Wideo musi pozostać dostępne aż do zapisania prezentacji.

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

## **Utworzenie ramki wideo z wideo pochodzącego ze źródła internetowego**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) obsługuje filmy online w prezentacjach. Możesz utworzyć ramkę wideo, która odwołuje się do filmu online, takiego jak film z YouTube.

Ten przykład dodaje odnośnik do filmu YouTube oraz miniaturę na pierwszy slajd. Zastąp identyfikator wideo, aby użyć innego filmu. Metoda [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) żąda automatycznego odtwarzania. Pobieranie miniatury i odtwarzanie wideo wymaga dostępu do internetu. Odtwarzacz prezentacji musi również obsługiwać odtwarzanie wideo online.

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

## **Odtwarzanie wideo w trybie pełnoekranowym**

W prezentacji szkoleniowej możesz odtwarzać demonstrację oprogramowania w trybie pełnoekranowym, aby publiczność mogła zobaczyć szczegóły. Wywołaj [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) z wartością `True`, aby włączyć to zachowanie podczas odtwarzania.

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

Odtwarzanie pełnoekranowe kontroluje sposób wyświetlania wideo. Niezależnie od tego, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) kontroluje, czy odtwarzanie zaczyna się automatycznie czy po kliknięciu, a [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) kontroluje, czy wideo jest powtarzane. Aby wybrać zachowanie przy uruchamianiu, ustaw tryb odtwarzania na [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Przykład zachowuje istniejące ustawienia uruchamiania i pętli.

## **Cofnięcie wideo po odtworzeniu**

W prezentacji szkoleniowej przywrócenie filmu demonstracyjnego do jego początku sprawia, że jest gotowy do ponownego odtworzenia przez prezentera. Wywołaj [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) z wartością `True`, aby po zakończeniu odtwarzania cofnąć wideo do początku.

Ten przykład otwiera prezentację, znajduje pierwszą [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) na pierwszym slajdzie i włącza cofanie. Wyłącza pętlę, aby odtwarzanie mogło się zakończyć i ustawia odtwarzanie na start po kliknięciu. Wejściowa prezentacja musi zawierać co najmniej jeden slajd z istniejącą ramką wideo na pierwszym slajdzie.

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

Cofanie zwraca wideo do początku bez ponownego uruchamiania. W przeciwieństwie do tego, wywołanie [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) z wartością `True` powoduje automatyczne powtarzanie odtwarzania. Trzymaj pętlę wyłączoną, gdy chcesz, aby wideo zakończyło się i pozostało gotowe do ponownego odtworzenia. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) niezależnie kontroluje automatyczne lub kliknięciowe uruchomienie; ten przykład używa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/), aby prezenter kontrolował, kiedy odtwarzanie się rozpocznie. Ustaw tryb odtwarzania po ustawieniu pętli, jak pokazano w przykładzie. Cofanie działa niezależnie od [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Przycięcie ramki wideo**

Użyj [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) i [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd), aby pominąć część początku lub końca wideo podczas odtwarzania. Obie wartości podawane są w milisekundach. Przycinanie zmienia ustawienia odtwarzania bez modyfikacji osadzonych danych wideo.

**Ustawienia przycięcia**

Ten przykład osadza lokalne wideo i pomija pierwsze 2,5 sekundy oraz ostatnią sekundę podczas odtwarzania. Użyj wideo dłuższego niż 3,5 sekundy, aby pozostał odtwarzalny segment.

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

**Odczyt ustawień przycięcia**

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

## **Zarządzanie napisami wideo**

Aspose.Slides umożliwia zarządzanie zamkniętymi napisami dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane za pomocą metody [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

### **Dodawanie napisów do ramki wideo**

Ten przykład osadza lokalne wideo i dodaje ścieżkę napisów WebVTT oznaczoną jako English. Znaczniki czasu napisów powinny odpowiadać wideo. Zapisana prezentacja zawiera zarówno wideo, jak i jego napisy.

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

Klasa [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) zapewnia również przeciążenie umożliwiające dodawanie napisów ze strumienia.

### **Wyodrębnianie napisów z ramki wideo**

Ten przykład zapisuje wszystkie ścieżki napisów z ramek wideo na pierwszym slajdzie jako osobne pliki WebVTT. Kolejne numery zachowują odrębność plików wyjściowych. Konsola informuje o liczbie wyodrębnionych ścieżek. Prezentacja musi zawierać co najmniej jeden slajd.

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

Każdy obiekt [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg znaków UTF-8.

### **Usuwanie napisów z ramki wideo**

Ten przykład usuwa wszystkie napisy z ramki wideo znajdującej się w pierwszej pozycji kształtu na pierwszym slajdzie i zapisuje wynik. Zakłada, że slajd i kształt istnieją oraz że kształt jest ramką wideo.

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

Jeśli musisz usunąć tylko jedną ścieżkę napisu, użyj metod [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) lub [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) zamiast [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

### **Wyszukiwanie napisów wideo**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) zwraca kompletną ścieżkę WebVTT, w tym nagłówek, linie czasowe i tekst napisu. Możesz przeszukać napisy w pamięci, aby znaleźć frazę i jej znacznik czasu. Na przykład, angielska ścieżka na slajdzie 2 może zawierać następujący tekst.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Ten przykład otwiera `captioned_media.pptx` i używa [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks), aby odczytać ścieżki każdej ramki wideo najwyższego poziomu na każdym slajdzie. W wskazówce w formacie tekstowym linia czasowa zawiera `-->`, a pusty wiersz kończy wskazówkę. Dla każdego napisu zawierającego „café” w dowolnej wielkości liter, przykład wypisuje numer slajdu, etykietę ścieżki, oryginalną linię czasową oraz pełny napis.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

Wyszukiwanie „café” zwraca jeden dopasowanie dla przykładowej ścieżki. Wyszukiwanie pomija nagłówek ścieżki i zachowuje ustawienia czasowe oraz podziały wierszy w wyniku.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Wyodrębnianie wideo ze slajdu**

Oprócz dodawania wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

Ten przykład wyodrębnia osadzone wideo ze wszystkich slajdów do osobnych, numerowanych plików binarnych. Wideo z linkami jest pomijane, ponieważ nie posiada osadzonych danych. Konsola wypisuje typ MIME każdego wideo oraz łączną liczbę. Wyjście używa ogólnego rozszerzenia `.bin`; w razie potrzeby zmień je, aby odpowiadało zgłoszonemu typowi mediów.

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

## **FAQ**

**Jakie parametry odtwarzania wideo można zmienić dla ramki wideo?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto lub po kliknięciu) oraz [pętlę](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Opcje te są dostępne za pośrednictwem metod obiektu [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalne wideo, dane binarne są dołączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy odwołujesz się do wideo online i dodajesz miniaturę, prezentacja przechowuje odnośnik i obraz podglądu zamiast danych wideo, więc zwiększenie rozmiaru jest zazwyczaj mniejsze.

**Czy mogę zamienić wideo w istniejącej ramce wideo bez zmiany jej pozycji i rozmiaru?**

Tak. Możesz wymienić [zawartość wideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) w ramach, zachowując geometrykę kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo posiada [typ zawartości](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType), który możesz odczytać i wykorzystać, na przykład przy zapisywaniu go na dysk.