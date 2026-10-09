---
title: Zarządzanie ramkami wideo w prezentacjach w .NET
linktitle: Ramka wideo
type: docs
weight: 10
url: /pl/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides for .NET. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Filmy mogą pomóc wyjaśnić pomysły i zaangażować publiczność. Aspose.Slides for .NET pozwala dodawać ramki wideo do slajdów, regulować ustawienia odtwarzania, zarządzać napisami i wyodrębniać osadzone dane wideo.

PowerPoint obsługuje lokalne filmy oraz linki do filmów online, takich jak filmy z YouTube.

Aby reprezentować dane wideo i ramki wideo, Aspose.Slides udostępnia interfejs [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), interfejs [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) oraz inne odpowiednie typy.

## **Utwórz osadzoną ramkę wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w prezentacji.

Ten przykład osadza lokalny film na pierwszym slajdzie istniejącej prezentacji i zapisuje wynik. Współrzędne i wymiary ramki podane są w punktach. Strumień pozostaje otwarty aż do zakończenia zapisywania, ponieważ [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) utrzymuje go zablokowanym, gdy prezentacja go używa.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Możesz także przekazać ścieżkę do lokalnego wideo bezpośrednio do [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Ten przykład osadza wideo na pierwszym slajdzie nowej prezentacji. Wideo musi pozostać dostępne aż do zapisania prezentacji.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Utwórz ramkę wideo z wideo z źródła internetowego**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) obsługuje filmy online w prezentacjach. Możesz utworzyć ramkę wideo, która odwołuje się do filmu online, takiego jak film z YouTube.

Ten przykład dodaje link do filmu z YouTube oraz miniaturę na pierwszy slajd. Zamień identyfikator filmu, aby użyć innego filmu. Ustawienie [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) wymaga automatycznego odtwarzania. Pobieranie miniatury i odtwarzanie filmu wymaga dostępu do internetu. Przeglądarka prezentacji musi także obsługiwać odtwarzanie filmów online.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Odtwórz wideo w trybie pełnoekranowym**

W prezentacji szkoleniowej możesz odtworzyć demonstrację oprogramowania w trybie pełnoekranowym, aby publiczność mogła zobaczyć szczegóły. Ustaw [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) na `true`, aby włączyć to zachowanie podczas odtwarzania.

Ten przykład otwiera prezentację, znajduje pierwszą [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) na pierwszym slajdzie i włącza odtwarzanie w trybie pełnoekranowym. Wejściowa prezentacja musi zawierać co najmniej jeden slajd z istniejącą ramką wideo na pierwszym slajdzie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

Odtwarzanie w trybie pełnoekranowym kontroluje, jak wideo jest wyświetlane. Oddzielnie, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) kontroluje, czy zaczyna się automatycznie czy po kliknięciu, a [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) kontroluje, czy się powtarza. Aby wybrać zachowanie startu, ustaw tryb odtwarzania na [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). Przykład zachowuje istniejące ustawienia startu i pętli.

## **Przewiń wideo po odtworzeniu**

W prezentacji szkoleniowej przywrócenie filmu demonstracyjnego do początku sprawia, że jest gotowy do ponownego odtworzenia przez prezentera. Ustaw [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) na `true`, aby po zakończeniu odtwarzania przewinąć wideo do początku.

Ten przykład otwiera prezentację, znajduje pierwszą [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) na pierwszym slajdzie i włącza przewijanie. Wyłącza pętlę, aby odtwarzanie mogło się zakończyć i ustawia odtwarzanie, aby rozpoczęło się po kliknięciu. Wejściowa prezentacja musi zawierać co najmniej jeden slajd z istniejącą ramką wideo na pierwszym slajdzie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Przewijanie przywraca wideo do początku bez ponownego uruchamiania. Natomiast włączenie [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) powoduje automatyczne powtarzanie odtwarzania. Trzymaj pętlę wyłączoną, gdy chcesz, aby wideo zakończyło się i było gotowe do ponownego odtworzenia. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) niezależnie kontroluje automatyczny lub klikowy start; ten przykład używa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/), aby prezenter kontrolował moment rozpoczęcia odtwarzania. Ustaw tryb odtwarzania po ustawieniu pętli, jak pokazano w przykładzie. Przewijanie działa niezależnie od [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Przytnij ramkę wideo**

Użyj [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) i [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/), aby pominąć część początku lub końca wideo podczas odtwarzania. Obie wartości podawane są w milisekundach. Przycinanie zmienia ustawienia odtwarzania bez modyfikacji osadzonych danych wideo.

**Ustawienia przycinania**

Ten przykład osadza lokalny film i pomija pierwsze 2,5 sekundy oraz ostatnią sekundę podczas odtwarzania. Użyj wideo dłuższego niż 3,5 sekundy, aby pozostał odtwarzalny segment.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Odczytaj ustawienia przycinania**

Ten przykład wypisuje wartości przycinania pierwszej ramki wideo na pierwszym slajdzie w milisekundach. Prezentacja musi zawierać co najmniej jeden slajd. Jeśli ten slajd nie ma ramki wideo, nic nie zostanie wypisane. Poprzedni przykład generuje wartości 2500 i 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Zarządzaj napisami wideo**

Aspose.Slides pozwala zarządzać zamkniętymi napisami dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane poprzez właściwość [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Dodaj napisy do ramki wideo**

Ten przykład osadza lokalny film i dodaje ścieżkę napisów WebVTT oznaczoną jako English. Znaczniki czasu napisów powinny odpowiadać wideo. Zapisana prezentacja zawiera zarówno film, jak i jego napisy.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

Interfejs [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) udostępnia również przeciążenie, które pozwala dodać napisy z strumienia.

**Wyodrębnij napisy z ramki wideo**

Ten przykład zapisuje wszystkie ścieżki napisów z ramek wideo na pierwszym slajdzie jako oddzielne pliki WebVTT. Kolejne numery utrzymują pliki wyjściowe odrębne. Konsola raportuje liczbę wyodrębnionych ścieżek. Prezentacja musi zawierać co najmniej jeden slajd.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Każdy obiekt [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF‑8.

**Usuń napisy z ramki wideo**

Ten przykład usuwa wszystkie napisy z ramki wideo znajdującej się w pierwszej pozycji kształtu na pierwszym slajdzie i zapisuje wynik. Zakłada, że slajd i kształt istnieją oraz że kształt jest ramką wideo.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisu, użyj metod [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) lub [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) zamiast [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Wyodrębnij wideo ze slajdu**

Oprócz dodawania filmów do slajdów, Aspose.Slides umożliwia wyodrębnianie filmów osadzonych w prezentacjach.

Ten przykład wyodrębnia osadzone filmy ze wszystkich slajdów do oddzielnych, numerowanych plików binarnych. Filmy powiązane są pomijane, ponieważ nie mają osadzonych danych. Konsola wypisuje typ MIME każdego filmu oraz łączną liczbę. Wyjście używa ogólnego rozszerzenia `.bin`; w razie potrzeby zmień je, aby pasowało do zgłoszonego typu mediów.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**Jakie parametry odtwarzania wideo można zmienić dla ramki wideo?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatyczny lub po kliknięciu) oraz [pętlę](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalny film, dane binarne są dołączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy linkujesz do filmu online i dodajesz miniaturę, prezentacja przechowuje link i obraz podglądu zamiast danych wideo, więc zwiększenie rozmiaru jest zazwyczaj mniejsze.

**Czy mogę zamienić wideo w istniejącej ramce wideo bez zmiany jej położenia i rozmiaru?**

Tak. Możesz wymienić [zawartość wideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) w ramce, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji multimediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo ma [typ zawartości](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/), który możesz odczytać i wykorzystać, na przykład przy zapisywaniu go na dysk.