---
title: Dodawanie wideo do prezentacji w Pythonie
linktitle: Ramka wideo
type: docs
weight: 10
url: /pl/python-net/video-frame/
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
description: "Naucz się programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona w .NET. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Odpowiednio umieszczone wideo w prezentacji może uczynić Twoją wiadomość bardziej przekonującą i zwiększyć poziom zaangażowania odbiorców.

PowerPoint umożliwia dodawanie wideo do slajdu w prezentacji na dwa sposoby:

* Dodaj lub osadź lokalny plik wideo (przechowywany na twoim komputerze)
* Dodaj wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia klasy [Video](https://reference.aspose.com/slides/pl/python-net/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) oraz inne odpowiednie typy.

## **Utwórz osadzoną ramkę wideo**

Jeśli plik wideo, który chcesz dodać do swojego slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w swojej prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
1. Pobierz odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/python-net/aspose.slides/video/) i przekaż ścieżkę do pliku wideo, aby osadzić wideo w prezentacji. 
1. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) , aby utworzyć ramkę dla wideo.  
1. Zapisz zmodyfikowaną prezentację. 

Ten kod w Pythonie pokazuje, jak dodać lokalnie przechowywane wideo do prezentacji:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Pobiera pierwszy slajd i dodaje ramkę wideo
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Zapisuje prezentację na dysk
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternatywnie możesz dodać wideo, przekazując bezpośrednio ścieżkę do pliku do metody `add_video_frame(x, y, width, height, fname)`.

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Utwórz ramkę wideo z wideo z źródła internetowego**

Nowsze wersje Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) obsługują wideo online w prezentacjach. Jeśli wideo, którego chcesz użyć, jest dostępne w Internecie (np. na YouTube), możesz dodać je do swojej prezentacji za pomocą linku internetowego.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
1. Pobierz odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/python-net/aspose.slides/video/) i przekaż link do wideo.
1. Ustaw miniaturę dla ramki wideo. 
1. Zapisz prezentację. 

Ten kod w Pythonie pokazuje, jak dodać wideo z Internetu do slajdu w prezentacji PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Dodaje ramkę wideo
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Ładuje miniaturę
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Przytnij ramkę wideo**

Aspose.Slides pozwala kontrolować, która część wideo jest odtwarzana, ustawiając wartości trim-from-start i trim-from-end za pomocą [VideoFrame.trim_from_start](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/trim_from_start/) i [VideoFrame.trim_from_end](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/trim_from_end/). Obie wartości podawane są w milisekundach i określają, ile czasu ma zostać pominięte od początku i końca wideo. Ustawienia te zmieniają sposób odtwarzania wideo w prezentacji; nie przycinają ani nie modyfikują binarnych danych osadzonego wideo.

**Ustawienia przycinania**

Aby utworzyć ramkę wideo i ustawić jej parametry przycinania:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
1. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/python-net/aspose.slides/video/) do prezentacji.
1. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) do slajdu.
1. Ustaw wartości trim-from-start i trim-from-end za pomocą [VideoFrame.trim_from_start](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/trim_from_start/) i [VideoFrame.trim_from_end](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/trim_from_end/) .
1. Zapisz zmodyfikowaną prezentację.

Poniższy przykład kodu pomija pierwsze 2,5 sekundy i ostatnią sekundę osadzonego wideo podczas odtwarzania:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Odczytaj ustawienia przycinania**

Aby zbadać istniejące ustawienia przycinania, załaduj prezentację, znajdź obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) wśród kształtów na pierwszym slajdzie i odczytaj wartości za pomocą [VideoFrame.trim_from_start](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/trim_from_start/) i [VideoFrame.trim_from_end](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/trim_from_end/) .

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **Zarządzaj napisami wideo**

Aspose.Slides pozwala zarządzać napisami zamkniętymi dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane poprzez właściwość [VideoFrame.caption_tracks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/caption_tracks/) .

**Dodaj napisy do ramki wideo**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
1. Dodaj wideo do prezentacji.
1. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) do slajdu.
1. Użyj [CaptionsCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/) , zwróconego przez [caption_tracks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/caption_tracks/) , aby dodać ścieżkę napisów WebVTT.
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak dodać napisy do ramki wideo:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Dodaje nową ścieżkę napisów z pliku WebVTT.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Klasa [CaptionsCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/) posiada również przeciążenie umożliwiające dodawanie napisów ze strumienia.

**Wyodrębnij napisy z ramki wideo**

1. Załaduj prezentację zawierającą wideo.
1. Znajdź docelowy obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) .
1. Przeglądaj kolekcję [caption_tracks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/caption_tracks/) .
1. Zapisz każdą ścieżkę napisów do pliku `.vtt` .

Poniższy kod pokazuje, jak wyodrębnić napisy z ramki wideo:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Zapisuje ścieżkę napisów do pliku WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Każdy obiekt [Captions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captions/) udostępnia identyfikator napisu, etykietę, dane binarne i tekst napisu jako ciąg UTF-8.

**Usuń napisy z ramki wideo**

1. Załaduj prezentację zawierającą wideo.
1. Pobierz docelowy obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) .
1. Usuń ścieżki napisów z [CaptionsCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/) .
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak usunąć wszystkie napisy z ramki wideo:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # typ: slides.VideoFrame

    # Usuwa wszystkie napisy z ramki wideo.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisu, użyj metod [remove](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/remove/) lub [remove_at](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/remove_at/) zamiast [clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/clear/) .

## **Wyodrębnij wideo ze slajdu**

Oprócz dodawania wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) , aby załadować prezentację zawierającą wideo. 
2. Przeglądaj wszystkie obiekty [Slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/) .
3. Przeglądaj wszystkie obiekty [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) , aby znaleźć [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) . 
4. Zapisz wideo na dysk.

Ten kod w Pythonie pokazuje, jak wyodrębnić wideo ze slajdu prezentacji:

```python
import aspose.slides as slides

# Tworzy obiekt Presentation, który reprezentuje plik prezentacji
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Jakie parametry odtwarzania wideo można zmienić dla VideoFrame?**

Możesz kontrolować [playback mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/play_mode/) (automatyczne lub po kliknięciu) oraz [looping](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/play_loop_mode/) . Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) .

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzisz lokalne wideo, dane binarne są włączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodasz wideo online, osadzany jest jedynie link i miniatura, więc przyrost rozmiaru jest mniejszy.

**Czy mogę zastąpić wideo w istniejącej VideoFrame, nie zmieniając jej pozycji i rozmiaru?**

Tak. Możesz zamienić [video content](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/embedded_video/) wewnątrz ramki, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji multimediów w istniejącym układzie.

**Czy można ustalić typ treści (MIME) osadzonego wideo?**

Tak. Osadzone wideo posiada [content type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/video/content_type/) , który możesz odczytać i wykorzystać, na przykład przy zapisywaniu go na dysk.