---
title: Zarządzanie ramkami wideo w prezentacjach w Pythonie
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
description: "Naucz się programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Filmy mogą pomóc wyjaśnić pomysły i zaangażować odbiorców. Aspose.Slides for Python via .NET pozwala dodawać ramki wideo do slajdów, dostosowywać ustawienia odtwarzania, zarządzać napisami i wyodrębniać osadzone dane wideo.

PowerPoint obsługuje lokalne filmy oraz linki do filmów online, takich jak filmy z YouTube.

Aby reprezentować dane wideo i ramki wideo, Aspose.Slides udostępnia klasę [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/), klasę [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) oraz inne odpowiednie typy.

## **Utwórz osadzoną ramkę wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w swojej prezentacji.

Ten przykład osadza lokalny film na pierwszym slajdzie istniejącej prezentacji i zapisuje wynik. Współrzędne i wymiary ramki podawane są w punktach. Strumień pozostaje otwarty aż do zakończenia zapisu, ponieważ [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) utrzymuje go zablokowanym, gdy prezentacja go używa.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Możesz również przekazać ścieżkę do lokalnego wideo bezpośrednio do [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Ten przykład osadza wideo na pierwszym slajdzie nowej prezentacji. Wideo musi być dostępne aż do zapisania prezentacji.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Utwórz ramkę wideo z wideo z źródła internetowego**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) obsługuje filmy online w prezentacjach. Możesz utworzyć ramkę wideo, która linkuje do filmu online, takiego jak film z YouTube.

Ten przykład dodaje link do filmu YouTube oraz miniaturę na pierwszy slajd. Zastąp identyfikator wideo, aby użyć innego filmu. Ustawienie [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) powoduje automatyczne odtwarzanie. Pobieranie miniatury i odtwarzanie wideo wymaga dostępu do internetu. Odtwarzacz prezentacji musi również obsługiwać odtwarzanie wideo online.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Odtwórz wideo w trybie pełnoekranowym**

W prezentacji szkoleniowej możesz odtworzyć demonstrację oprogramowania w trybie pełnoekranowym, aby publiczność mogła zobaczyć szczegóły. Ustaw [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) na `True`, aby włączyć to zachowanie podczas odtwarzania.

Ten przykład otwiera prezentację, znajduje pierwszą [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) na pierwszym slajdzie i włącza odtwarzanie pełnoekranowe. Wejściowa prezentacja musi zawierać co najmniej jeden slajd z istniejącą ramką wideo na pierwszym slajdzie.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

Odtwarzanie pełnoekranowe kontroluje sposób wyświetlania wideo. Oddzielnie, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) decyduje, czy rozpoczyna się automatycznie czy po kliknięciu, a [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) określa, czy się powtarza. Aby wybrać zachowanie przy uruchamianiu, ustaw tryb odtwarzania na [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Przykład zachowuje istniejące ustawienia startu i pętli.

## **Cofnij wideo po odtworzeniu**

W prezentacji szkoleniowej cofnięcie filmu demonstracyjnego do początku przygotowuje go do ponownego odtworzenia przez prezentującego. Ustaw [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) na `True`, aby po zakończeniu odtwarzania wideo wróciło na początek.

Ten przykład otwiera prezentację, znajduje pierwszą [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) na pierwszym slajdzie i włącza cofanie. Wyłącza pętlę, aby odtwarzanie mogło się zakończyć, i ustawia odtwarzanie na start po kliknięciu. Wejściowa prezentacja musi zawierać co najmniej jeden slajd z istniejącą ramką wideo na pierwszym slajdzie.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

Cofanie przywraca wideo do początku bez ponownego uruchamiania. Natomiast włączenie [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) powoduje automatyczne powtarzanie odtwarzania. Trzymaj pętlę wyłączoną, gdy chcesz, aby wideo zakończyło się i było gotowe do ponownego odtworzenia. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) niezależnie kontroluje automatyczny lub ręczny start; ten przykład używa [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/), aby prezenter decydował o rozpoczęciu odtwarzania. Ustaw tryb odtwarzania po ustawieniu pętli, jak pokazano w przykładzie. Cofanie działa niezależnie od [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Przytnij ramkę wideo**

Użyj [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) i [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/), aby pominąć część początku lub końca filmu podczas odtwarzania. Obie wartości podawane są w milisekundach. Przycięcie zmienia ustawienia odtwarzania bez modyfikacji osadzonych danych wideo.

**Ustawienia przycięcia**

Ten przykład osadza lokalny film i pomija pierwsze 2,5 sekundy oraz ostatnią sekundę podczas odtwarzania. Użyj filmu dłuższego niż 3,5 sekundy, aby pozostał odtwarzalny segment.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Odczytaj ustawienia przycięcia**

Ten przykład wypisuje wartości przycięcia pierwszej ramki wideo na pierwszym slajdzie w milisekundach. Prezentacja musi zawierać co najmniej jeden slajd. Jeśli ten slajd nie ma ramki wideo, nic nie jest wypisane. Poprzedni przykład zwraca wartości 2500 i 1000.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Zarządzaj napisami wideo**

Aspose.Slides umożliwia zarządzanie zamkniętymi napisami dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane za pośrednictwem właściwości [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

### **Dodaj napisy do ramki wideo**

Ten przykład osadza lokalny film i dodaje ścieżkę napisów WebVTT oznaczoną jako English. Znaczniki czasu napisów powinny pasować do wideo. Zapisana prezentacja zawiera zarówno wideo, jak i jego napisy.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Klasa [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) oferuje również przeciążenie, które pozwala dodać napisy ze strumienia.

### **Wyodrębnij napisy z ramki wideo**

Ten przykład zapisuje wszystkie ścieżki napisów z ramek wideo na pierwszym slajdzie jako osobne pliki WebVTT. Kolejne liczby utrzymują odrębność plików wyjściowych. Konsola raportuje liczbę wyodrębnionych ścieżek. Prezentacja musi zawierać co najmniej jeden slajd.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Każdy obiekt [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciag UTF-8.

### **Usuń napisy z ramki wideo**

Ten przykład usuwa wszystkie napisy z ramki wideo znajdującej się na pierwszej pozycji kształtu na pierwszym slajdzie i zapisuje wynik. Zakłada, że slajd i kształt istnieją oraz że kształt jest ramką wideo.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisów, użyj metod [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) lub [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) zamiast [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

### **Wyszukaj napisy wideo**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) zwraca cały sled WebVTT, w tym nagłowek, linie czasowe i tekst napisu. Na przyklad angielska ścieżka na slajdzie 2 może zawierać ten cue:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Ten przykład otwiera `captioned_media.pptx` i odczytuje [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) każdej ramki wideo najwyższego poziomu na każdym slajdzie. Dla każdego cue w zwykłym tekście znajduje linie czasowa zawierajaca `-->` i zbiera linie napisow az do nastepnej pustej linii lub konca sledu. Przeszukuje tekst napisow pod kątem „café” bez uwzgledniania wielkosci liter i wypisuje numer slajdu, etykiete sledu, oryginalna linie czasowa oraz pelny napis dla kazdego dopasowania.

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
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
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

Przykladowa ścieżka generuje jedno dopasowanie. „Café” w nagłówku znajduje się poza tekstem napisu, a wynik zachowuje ustawienie czasu i obie linie napisu.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Wyodrębnij wideo ze slajdu**

Oprócz dodawania wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

Ten przykład wyodrębnia osadzone wideo ze każdego slajdu do osobnych, ponumerowanych plikow binarnych. Wideo połączone są pomijane, ponieważ nie mają osadzonych danych. Konsola wypisuje typ MIME każdego wideo oraz łączną liczbę. Wyjście używa ogólnego rozszerzenia `.bin`; w razie potrzeby zmień je, aby pasowało do zgłaszanego typu multimedialnego.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **FAQ**

**Jakie parametry odtwarzania wideo można zmienić dla ramki wideo?**

Możesz kontrolować [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automatycznie lub po kliknięciu) oraz [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalny film, dane binarne są włączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy linkujesz do filmu online i dodajesz miniaturę, prezentacja przechowuje link i obraz podglądu zamiast danych wideo, więc przyrost rozmiaru jest zazwyczaj mniejszy.

**Czy mogę zamienić wideo w istniejącej ramce wideo bez zmiany jej pozycji i rozmiaru?**

Tak. Możesz zamienić [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) w ramce, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo posiada [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/), który możesz odczytać i wykorzystać, na przykład przy zapisywaniu go na dysk.