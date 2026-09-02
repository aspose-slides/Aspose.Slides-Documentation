---
title: Zarządzanie klatkami wideo w prezentacjach w .NET
linktitle: Klatka wideo
type: docs
weight: 10
url: /pl/net/video-frame/
keywords:
- dodaj wideo
- tworzenie wideo
- osadzanie wideo
- wyodrębnianie wideo
- pobieranie wideo
- klatka wideo
- źródło internetowe
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Naucz się programowo dodawać i wyodrębniać klatki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Dobrze dobrane wideo w prezentacji może uczynić Twoje przesłanie bardziej przekonujące i zwiększyć poziom zaangażowania odbiorców. 

PowerPoint pozwala dodawać wideo do slajdu w prezentacji na dwa sposoby:

* Dodaj lub osadź lokalne wideo (przechowywane na twoim komputerze)
* Dodaj wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia interfejs [IVideo](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideo/) , interfejs [IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/) oraz inne powiązane typy. 

## **Utwórz osadzoną klatkę wideo**

Jeśli plik wideo, który chcesz dodać do swojego slajdu, jest przechowywany lokalnie, możesz utworzyć klatkę wideo, aby osadzić wideo w swojej prezentacji. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj referencję do slajdu poprzez jego indeks. 
3. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideo/), przekazując ścieżkę do pliku wideo, aby osadzić wideo w prezentacji. 
4. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/), aby utworzyć klatkę dla wideo.  
5. Zapisz zmodyfikowaną prezentację. 

Ten kod C# pokazuje, jak dodać wideo przechowywane lokalnie do prezentacji:

```c#
 // Tworzy instancję klasy Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Ładuje wideo
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Pobiera pierwszy slajd i dodaje klatkę wideo
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Zapisuje prezentację na dysk
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternatywnie możesz dodać wideo, przekazując jego ścieżkę bezpośrednio do metody [AddVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Utwórz klatkę wideo z wideo pochodzącym ze źródła internetowego**
Nowe wersje Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) obsługują wideo online w prezentacjach. Jeśli wideo, którego chcesz użyć, jest dostępne online (np. na YouTube), możesz dodać je do swojej prezentacji za pomocą jego linku internetowego.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj referencję do slajdu poprzez jego indeks. 
3. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideo/), przekazując link do wideo.
4. Ustaw miniaturkę dla klatki wideo. 
5. Zapisz prezentację. 

Ten kod C# pokazuje, jak dodać wideo z sieci do slajdu w prezentacji PowerPoint:

```c#
public static void Run()
{
    // Tworzy obiekt Presentation, który reprezentuje plik prezentacji 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Dodaje klatkę wideo
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Ładuje miniaturkę
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Przytnij klatkę wideo**

Aspose.Slides pozwala kontrolować, którą część wideo odtwarzać, ustawiając wartości trim-from-start i trim-from-end poprzez [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/trimfromstart/) i [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/trimfromend/). Obie wartości podawane są w milisekundach i określają, ile czasu jest pomijane od początku i końca wideo. Te ustawienia zmieniają sposób odtwarzania wideo w prezentacji; nie przycinają ani nie modyfikują w żaden sposób danych binarnych osadzonego wideo.

**Ustawienia przycięcia**

Aby utworzyć klatkę wideo i ustawić jej ustawienia przycięcia:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideo/) do prezentacji.
3. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/) do slajdu.
4. Ustaw wartości trim-from-start i trim-from-end poprzez [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/trimfromstart/) i [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/trimfromend/).
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład kodu pomija pierwsze 2,5 sekundy oraz ostatnią sekundę osadzonego wideo podczas odtwarzania:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Odczytaj ustawienia przycięcia**

Aby sprawdzić istniejące ustawienia przycięcia, wczytaj prezentację, znajdź obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/) wśród kształtów na pierwszym slajdzie i odczytaj wartości poprzez [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/trimfromstart/) i [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/trimfromend/).

Poniższy przykład kodu znajduje pierwszą klatkę wideo na pierwszym slajdzie i zgłasza jej ustawienia przycięcia w milisekundach:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Zarządzaj napisami wideo**

Aspose.Slides pozwala zarządzać zamkniętymi napisami dla klatek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i dostępne za pośrednictwem właściwości [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/captiontracks/).

**Dodaj napisy do klatki wideo**

Aby dodać napisy do klatki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Dodaj wideo do prezentacji.
3. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/) do slajdu.
4. Użyj kolekcji [CaptionTracks](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/captiontracks/), aby dodać ścieżkę napisu WebVTT.
5. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak dodać napisy do klatki wideo:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Dodaje nową ścieżkę napisów z pliku WebVTT.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

Interfejs [ICaptionsCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/icaptionscollection/) zapewnia również przeciążenie, które pozwala dodawać napisy z strumienia.

**Wyodrębnij napisy z klatki wideo**

Aby wyodrębnić napisy z klatki wideo:

1. Wczytaj prezentację zawierającą wideo.
2. Znajdź docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/).
3. Iteruj po kolekcji [CaptionTracks](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/captiontracks/).
4. Zapisz każdą ścieżkę napisu do pliku `.vtt`.

Poniższy kod pokazuje, jak wyodrębnić napisy z klatki wideo:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Zapisuje ścieżkę napisów do pliku WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Każdy obiekt [ICaptions](https://reference.aspose.com/slides/pl/net/aspose.slides/icaptions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF-8.

**Usuń napisy z klatki wideo**

Aby usunąć napisy z klatki wideo:

1. Wczytaj prezentację zawierającą wideo.
2. Uzyskaj docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/).
3. Usuń ścieżki napisów z kolekcji [CaptionTracks](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/captiontracks/).
4. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak usunąć wszystkie napisy z klatki wideo:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Usuwa wszystkie napisy z klatki wideo.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisu, użyj metod [Remove](https://reference.aspose.com/slides/pl/net/aspose.slides/captionscollection/remove/) lub [RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides/captionscollection/removeat/), zamiast [Clear](https://reference.aspose.com/slides/pl/net/aspose.slides/captionscollection/clear/).

## **Wyodrębnij wideo ze slajdu**
Oprócz dodawania wideo do slajdów, Aspose.Slides pozwala wyodrębniać wideo osadzone w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation), aby wczytać prezentację zawierającą wideo. 
2. Iteruj przez wszystkie obiekty [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide).
3. Iteruj przez wszystkie obiekty [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape), aby znaleźć [VideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/videoframe). 
4. Zapisz wideo na dysk.

Ten kod C# pokazuje, jak wyodrębnić wideo ze slajdu prezentacji:

```c#
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji 
Presentation presentation = new Presentation("Video.pptx");

// Iteruje po slajdach
foreach (ISlide slide in presentation.Slides)
{
    // Iteruje po kształtach
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Zapisuje wideo na dysk po znalezieniu VideoFrame zawierającego wideo
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **FAQ**

**Które parametry odtwarzania wideo można zmienić dla VideoFrame?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/pl/net/aspose.slides/videoframe/playmode/) (automatyczny lub na kliknięcie) oraz [pętlę](https://reference.aspose.com/slides/pl/net/aspose.slides/videoframe/playloopmode/). Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/videoframe/).

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalne wideo, dane binarne są włączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodasz wideo online, osadzany jest link i miniaturka, więc przyrost rozmiaru jest mniejszy.

**Czy mogę zastąpić wideo w istniejącej VideoFrame bez zmiany jej położenia i rozmiaru?**

Tak. Możesz zamienić [zawartość wideo](https://reference.aspose.com/slides/pl/net/aspose.slides/videoframe/embeddedvideo/) w ramach klatki, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo ma [typ zawartości](https://reference.aspose.com/slides/pl/net/aspose.slides/video/contenttype/), który możesz odczytać i wykorzystać, na przykład przy zapisywaniu go na dysk.