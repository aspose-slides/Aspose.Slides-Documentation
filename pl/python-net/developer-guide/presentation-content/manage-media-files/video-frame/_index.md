---
title: Dodawanie wideo do prezentacji w Pythonie
linktitle: Klatka wideo
type: docs
weight: 10
url: /pl/python-net/video-frame/
keywords:
- dodaj wideo
- utwórz wideo
- osadź wideo
- wyodrębnij wideo
- pobierz wideo
- klatka wideo
- źródło internetowe
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak programowo dodawać i wyodrębniać klatki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona via .NET. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Odpowiednio umieszczone wideo w prezentacji może uczynić Twoją wiadomość bardziej przekonującą i zwiększyć poziom zaangażowania odbiorców. 

PowerPoint umożliwia dodawanie wideo do slajdu w prezentacji na dwa sposoby:

* Dodaj lub osadź lokalne wideo (przechowywane na Twoim komputerze)
* Dodaj wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia klasę [Video](https://reference.aspose.com/slides/pl/python-net/aspose.slides/video/) , klasę [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) oraz inne istotne typy. 

## **Utworzenie osadzonej klatki wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć klatkę wideo, aby osadzić wideo w prezentacji. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/python-net/aspose.slides/video/) i przekaż ścieżkę do pliku wideo, aby osadzić wideo w prezentacji. 
1. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) , aby utworzyć klatkę dla wideo.  
1. Zapisz zmodyfikowaną prezentację. 

Ten kod w Pythonie pokazuje, jak dodać lokalnie przechowywane wideo do prezentacji:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Uzyskuje pierwszy slajd i dodaje klatkę wideo
        # Zapisuje prezentację na dysku
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Saves the presentation to disk
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternatywnie możesz dodać wideo, przekazując jego ścieżkę pliku bezpośrednio do metody `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Utworzenie klatki wideo z wideo pochodzącego ze źródła internetowego**

Microsoft [PowerPoint 2013 i nowsze](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) obsługuje wideo z YouTube w prezentacjach. Jeśli wideo, które chcesz użyć, jest dostępne online (np. na YouTube), możesz dodać je do prezentacji poprzez jego link internetowy. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) 
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/python-net/aspose.slides/video/) i przekaż link do wideo.
1. Ustaw miniaturę dla klatki wideo. 
1. Zapisz prezentację. 

Ten kod w Pythonie pokazuje, jak dodać wideo z sieci do slajdu w prezentacji PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Dodaje klatkę wideo
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

## **Zarządzanie napisami wideo**

Aspose.Slides umożliwia zarządzanie zamkniętymi napisami dla klatek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane za pośrednictwem właściwości [VideoFrame.caption_tracks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/caption_tracks/) .

**Dodaj napisy do klatki wideo**

Aby dodać napisy do klatki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
1. Dodaj wideo do prezentacji.
1. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) do slajdu.
1. Użyj [CaptionsCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/) zwróconego przez [caption_tracks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/caption_tracks/) , aby dodać ścieżkę napisów WebVTT.
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak dodać napisy do klatki wideo:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Dodaje nową ścieżkę napisów z pliku WebVTT.
    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Klasa [CaptionsCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/) zapewnia również przeciążenie, które pozwala dodać napisy ze strumienia.

**Wyodrębnij napisy z klatki wideo**

Aby wyodrębnić napisy z klatki wideo:

1. Załaduj prezentację, która zawiera wideo.
1. Znajdź docelowy obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) .
1. Iteruj po kolekcji [caption_tracks](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/caption_tracks/) .
1. Zapisz każdą ścieżkę napisów do pliku `.vtt` .

Poniższy kod pokazuje, jak wyodrębnić napisy z klatki wideo:

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

Każdy obiekt [Captions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF‑8.

**Usuń napisy z klatki wideo**

Aby usunąć napisy z klatki wideo:

1. Załaduj prezentację, która zawiera wideo.
1. Uzyskaj docelowy obiekt [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) .
1. Usuń ścieżki napisów z [CaptionsCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/) .
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak usunąć wszystkie napisy z klatki wideo:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # typ: slides.VideoFrame

    # Usuwa wszystkie napisy z klatki wideo.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisów, użyj metod [remove](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/remove/) lub [remove_at](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/remove_at/) zamiast [clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides/captionscollection/clear/) .

## **Wyodrębnij wideo ze slajdu**

Oprócz dodawania wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) , aby wczytać prezentację zawierającą wideo. 
2. Iteruj po wszystkich obiektach [Slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/) .
3. Iteruj po wszystkich obiektach [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) , aby znaleźć [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) . 
4. Zapisz wideo na dysku.

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

Możesz kontrolować [playback mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/play_mode/) (automatycznie lub po kliknięciu) oraz [looping](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/play_loop_mode/) . Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/) .

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalne wideo, dane binarne są włączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodajesz wideo online, osadzany jest jedynie link i miniatura, więc przyrost rozmiaru jest mniejszy.

**Czy mogę wymienić wideo w istniejącej klatce VideoFrame bez zmiany jej położenia i rozmiaru?**

Tak. Możesz zamienić [video content](https://reference.aspose.com/slides/pl/python-net/aspose.slides/videoframe/embedded_video/) w ramach klatki, zachowując geometrię kształtu; jest to częsty scenariusz aktualizacji multimediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo posiada [content type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/video/content_type/) , który można odczytać i wykorzystać, na przykład przy zapisywaniu go na dysku.