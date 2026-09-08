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
- wyodrębnij wideo
- pobierz wideo
- ramka wideo
- źródło internetowe
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Naucz się programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona poprzez Java. Szybki przewodnik instruktażowy."
---
## **Wprowadzenie**

Odpowiednio umieszczone wideo w prezentacji może uczynić Twoje przesłanie bardziej przekonującym i zwiększyć poziom zaangażowania odbiorców.

PowerPoint umożliwia dodawanie wideo do slajdu w prezentacji na dwa sposoby:

* Dodaj lub osadź lokalne wideo (przechowywane na Twoim komputerze)
* Dodaj wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia klasę [Video](https://reference.aspose.com/slides/pl/python-java/aspose.slides/video/) klasę [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/) oraz inne odpowiednie typy.

## **Utwórz osadzone ramki wideo**

Jeśli plik wideo, który chcesz dodać do swojego slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w swojej prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Pobierz referencję do slajdu poprzez jego indeks.
3. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/python-java/aspose.slides/video/) i przekaż dane pliku wideo, aby osadzić wideo w prezentacji.
4. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/) , aby utworzyć ramkę dla wideo.
5. Zapisz zmodyfikowaną prezentację.

Ten kod w języku Python pokazuje, jak dodać wideo przechowywane lokalnie do prezentacji:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ewentualnie możesz dodać wideo, przekazując jego ścieżkę pliku bezpośrednio do metody [addVideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addVideoFrame):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Utwórz ramki wideo z wideo ze źródeł internetowych**

Microsoft [PowerPoint 2013 i nowsze](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) obsługuje wideo z YouTube w prezentacjach. Jeśli wideo, którego chcesz użyć, jest dostępne online (np. na YouTube), możesz dodać je do prezentacji za pomocą linku internetowego.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Pobierz referencję do slajdu poprzez jego indeks.
3. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/) i przekaż link do wideo.
4. Ustaw miniaturkę dla ramki wideo.
5. Zapisz prezentację.

Ten kod w języku Python pokazuje, jak dodać wideo z internetu do slajdu w prezentacji PowerPoint:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Załaduj miniaturkę.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Przytnij ramkę wideo**

Aspose.Slides pozwala kontrolować, która część wideo jest odtwarzana, ustawiając wartości trim-from-start i trim-from-end za pomocą [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/#setTrimFromStart) i [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/#setTrimFromEnd). Obie wartości podawane są w milisekundach i określają, ile czasu pomijać od początku i końca wideo. Te ustawienia zmieniają sposób odtwarzania wideo w prezentacji; nie przycinają ani nie modyfikują danych binarnych osadzonego wideo.

**Ustawienia przycięcia**

Aby utworzyć ramkę wideo i ustawić jej przycięcia:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/python-java/aspose.slides/video/) do prezentacji.
3. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/) do slajdu.
4. Ustaw wartości trim-from-start i trim-from-end za pomocą [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/#setTrimFromStart) i [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/#setTrimFromEnd).
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład kodu pomija pierwsze 2,5 sekundy oraz ostatnią sekundę osadzonego wideo podczas odtwarzania:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Odczyt ustawień przycięcia**

Aby sprawdzić istniejące ustawienia przycięcia, załaduj prezentację, znajdź obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/) spośród kształtów na pierwszym slajdzie i odczytaj wartości za pomocą [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/#getTrimFromStart) i [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/#getTrimFromEnd).

Poniższy przykład kodu znajduje pierwszą ramkę wideo na pierwszym slajdzie i raportuje jej ustawienia przycięcia w milisekundach:

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

Aspose.Slides umożliwia zarządzanie napisami zamkniętymi dla ramek wideo w prezentacjach PowerPoint. Napisy przechowywane są w formacie WebVTT i udostępniane za pośrednictwem metody [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Dodaj napisy do ramki wideo**

Aby dodać napisy do ramki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Dodaj wideo do prezentacji.
3. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/) do slajdu.
4. Użyj [CaptionsCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/) , zwróconego przez [getCaptionTracks](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/#getCaptionTracks) , aby dodać ścieżkę napisów WebVTT.
5. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak dodać napisy do ramki wideo:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Dodaj nową ścieżkę napisów z pliku WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Klasa [CaptionsCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/) zapewnia również przeciążenie, które umożliwia dodawanie napisów ze strumienia.

**Wyodrębnij napisy z ramki wideo**

Aby wyodrębnić napisy z ramki wideo:

1. Załaduj prezentację, która zawiera wideo.
2. Znajdź docelowy obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/).
3. Przejdź przez ścieżki napisów w [CaptionsCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/).
4. Zapisz każdą ścieżkę napisów do pliku `.vtt`.

Poniższy kod pokazuje, jak wyodrębnić napisy z ramki wideo:

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
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Zapisz ścieżkę napisów do pliku WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Każdy obiekt [Captions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF-8.

**Usuń napisy z ramki wideo**

Aby usunąć napisy z ramki wideo:

1. Załaduj prezentację, która zawiera wideo.
2. Pobierz docelowy obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/).
3. Usuń ścieżki napisów z [CaptionsCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/).
4. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak usunąć wszystkie napisy z ramki wideo:

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

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisów, użyj metod [remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/#remove) lub [removeAt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/#removeAt) zamiast [clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/captionscollection/#clear).

## **Wyodrębnij wideo ze slajdów**

Oprócz dodawania wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), aby załadować prezentację zawierającą wideo.
2. Przejdź przez wszystkie obiekty [Slide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/).
3. Przejdź przez wszystkie obiekty [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/), aby znaleźć [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/).
4. Zapisz wideo na dysk.

Poniższy kod w języku Python pokazuje, jak wyodrębnić wideo ze slajdu prezentacji:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **FAQ**

**Które parametry odtwarzania wideo można zmienić w VideoFrame?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/#setPlayMode) (automatycznie lub po kliknięciu) oraz [pętlę](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/#setPlayLoopMode). Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/).

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalne wideo, dane binarne są dołączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodajesz wideo online, osadzany jest link oraz miniaturka, więc przyrost rozmiaru jest mniejszy.

**Czy mogę zastąpić wideo w istniejącej VideoFrame bez zmiany jej pozycji i rozmiaru?**

Tak. Możesz wymienić [zawartość wideo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/#setEmbeddedVideo) w ramce, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ treści (MIME) osadzonego wideo?**

Tak. Osadzone wideo posiada [typ treści](https://reference.aspose.com/slides/pl/python-java/aspose.slides/video/#getContentType), który możesz odczytać i użyć, na przykład przy zapisywaniu go na dysk.