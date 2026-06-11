---
title: Zarządzanie klatkami wideo w prezentacjach w .NET
linktitle: Klatka wideo
type: docs
weight: 10
url: /pl/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Naucz się programowo dodawać i wyodrębniać klatki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Szybki przewodnik krok po kroku."
---
## **Wstęp**

Dobrze umieszczone wideo w prezentacji może sprawić, że Twoje przesłanie będzie bardziej przekonujące i zwiększyć poziom zaangażowania odbiorców.

PowerPoint umożliwia dodawanie wideo do slajdu w prezentacji na dwa sposoby:

* Dodanie lub osadzenie lokalnego wideo (przechowywanego na Twoim komputerze)
* Dodanie wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia interfejs [IVideo](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideo/), interfejs [IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/) oraz inne powiązane typy.

## **Utworzenie osadzonej klatki wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć klatkę wideo, aby osadzić wideo w prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Pobierz odniesienie do slajdu za jego indeksem.
3. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideo/) i przekaż ścieżkę do pliku wideo, aby osadzić wideo w prezentacji.
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
        
        // Zapisuje prezentację na dysku
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternatywnie możesz dodać wideo, przekazując bezpośrednio jego ścieżkę do metody [AddVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Utworzenie klatki wideo z wideo z źródła internetowego**
Microsoft [PowerPoint 2013 i nowsze](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) obsługuje wideo z YouTube w prezentacjach. Jeśli wideo, którego chcesz użyć, jest dostępne online (np. na YouTube), możesz dodać je do prezentacji za pomocą linku internetowego.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Pobierz odniesienie do slajdu za jego indeksem.
3. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideo/) i przekaż link do wideo.
4. Ustaw miniaturę dla klatki wideo.
5. Zapisz prezentację.

Ten kod C# pokazuje, jak dodać wideo z internetu do slajdu w prezentacji PowerPoint:

```c#
public static void Run()
{
    // Tworzy obiekt Presentation reprezentujący plik prezentacji 
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

    // Ładuje miniaturę
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Zarządzanie napisami wideo**

Aspose.Slides umożliwia zarządzanie napisami zamkniętymi dla klatek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane za pośrednictwem właściwości [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/captiontracks/).

**Dodawanie napisów do klatki wideo**

Aby dodać napisy do klatki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) .
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

Interfejs [ICaptionsCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/icaptionscollection/) udostępnia również przeciążenie, które pozwala dodać napisy z strumienia.

**Wyodrębnianie napisów z klatki wideo**

Aby wyodrębnić napisy z klatki wideo:

1. Załaduj prezentację zawierającą wideo.
2. Znajdź docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/).
3. Przejdź przez kolekcję [CaptionTracks](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/captiontracks/).
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

Każdy obiekt [ICaptions](https://reference.aspose.com/slides/pl/net/aspose.slides/icaptions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF‑8.

**Usuwanie napisów z klatki wideo**

Aby usunąć napisy z klatki wideo:

1. Załaduj prezentację zawierającą wideo.
2. Pobierz docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/).
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

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisu, użyj metod [Remove](https://reference.aspose.com/slides/pl/net/aspose.slides/captionscollection/remove/) lub [RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides/captionscollection/removeat/) zamiast [Clear](https://reference.aspose.com/slides/pl/net/aspose.slides/captionscollection/clear/).

## **Wyodrębnianie wideo ze slajdu**
Oprócz dodawania wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation), aby załadować prezentację zawierającą wideo. 
2. Przejdź przez wszystkie obiekty [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide). 
3. Przejdź przez wszystkie obiekty [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape), aby znaleźć [VideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/videoframe). 
4. Zapisz wideo na dysku.

Ten kod C# pokazuje, jak wyodrębnić wideo z slajdu prezentacji:

```c#
 // Tworzy obiekt Presentation, który reprezentuje plik prezentacji 
Presentation presentation = new Presentation("Video.pptx");

// Przechodzi przez slajdy
foreach (ISlide slide in presentation.Slides)
{
    // Przechodzi przez kształty
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Zapisuje wideo na dysku, gdy zostanie znaleziony VideoFrame zawierający wideo
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

**Jakie parametry odtwarzania wideo można zmienić dla VideoFrame?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/pl/net/aspose.slides/videoframe/playmode/) (automatyczny lub po kliknięciu) oraz [pętlę](https://reference.aspose.com/slides/pl/net/aspose.slides/videoframe/playloopmode/). Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/videoframe/).

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Kiedy osadzasz lokalne wideo, dane binarne są włączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Dodając wideo online, osadzany jest jedynie link i miniatura, więc przyrost rozmiaru jest mniejszy.

**Czy mogę zastąpić wideo w istniejącym VideoFrame bez zmiany jego pozycji i rozmiaru?**

Tak. Możesz podmienić [zawartość wideo](https://reference.aspose.com/slides/pl/net/aspose.slides/videoframe/embeddedvideo/) w ramce, zachowując geometrykę kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ treści (MIME) osadzonego wideo?**

Tak. Osadzone wideo ma [typ treści](https://reference.aspose.com/slides/pl/net/aspose.slides/video/contenttype/), który możesz odczytać i wykorzystać, na przykład przy zapisywaniu go na dysk.