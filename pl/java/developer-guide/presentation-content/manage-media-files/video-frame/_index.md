---
title: Zarządzanie klatkami wideo w prezentacjach przy użyciu Javy
linktitle: Klatka wideo
type: docs
weight: 10
url: /pl/java/video-frame/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak programowo dodawać i wyodrębniać klatki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Odpowiednio umieszczone wideo w prezentacji może uczynić Twoją wiadomość bardziej przekonującą i zwiększyć poziom zaangażowania odbiorców.  

PowerPoint umożliwia dodawanie wideo do slajdu w prezentacji na dwa sposoby:

* Dodaj lub osadź lokalne wideo (przechowywane na komputerze)
* Dodaj wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia interfejs [IVideo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideo/) , interfejs [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) oraz inne istotne typy.  

## **Utworzenie osadzonych klatek wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć klatkę wideo, aby osadzić wideo w prezentacji.  

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideo/) i przekaż ścieżkę do pliku wideo, aby osadzić wideo w prezentacji. 
1. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) , aby utworzyć klatkę dla wideo.  
1. Zapisz zmodyfikowaną prezentację. 

Poniższy kod Java pokazuje, jak dodać lokalnie przechowywane wideo do prezentacji:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Ładuje wideo
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Pobiera pierwszy slajd i dodaje klatkę wideo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Zapisuje prezentację na dysku
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternatywnie możesz dodać wideo, przekazując bezpośrednio jego ścieżkę do metody [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Tworzenie klatek wideo z wideo pochodzącym ze źródeł internetowych**

Microsoft [PowerPoint 2013 i nowsze](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) obsługuje filmy z YouTube w prezentacjach. Jeśli wideo, którego chcesz użyć, jest dostępne online (np. na YouTube), możesz dodać je do prezentacji za pomocą jego linku internetowego.  

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideo/) i przekaż link do wideo.
1. Ustaw miniaturę dla klatki wideo. 
1. Zapisz prezentację. 

```java
// Instancjonuje obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Dodaje klatkę wideo
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Ładuje miniaturę
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Przycinanie klatki wideo**

Aspose.Slides pozwala kontrolować, która część wideo jest odtwarzana, ustawiając wartości trim‑from‑start i trim‑from‑end za pomocą metod [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) oraz [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Obie wartości podawane są w milisekundach i określają, ile czasu pomijać od początku i końca wideo. Ustawienia te zmieniają sposób odtwarzania wideo w prezentacji; nie tną ani nie modyfikują binarnych danych osadzonego wideo.  

**Ustawienia przycięcia**

Aby utworzyć klatkę wideo i ustawić jej parametry przycięcia:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) .
1. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideo/) do prezentacji.
1. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) do slajdu.
1. Ustaw wartości trim‑from‑start i trim‑from‑end za pomocą metod [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) oraz [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Zapisz zmodyfikowaną prezentację.

Poniższy przykład kodu pomija pierwsze 2,5 s i ostatnią sekundę osadzonego wideo podczas odtwarzania:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Odczyt ustawień przycięcia**

Aby sprawdzić istniejące ustawienia przycięcia, wczytaj prezentację, znajdź obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) wśród kształtów na pierwszym slajdzie i odczytaj wartości za pomocą metod [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) oraz [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Zarządzanie napisami wideo**

Aspose.Slides umożliwia zarządzanie napisami zamkniętymi dla klatek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i dostępne są przez metodę [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .  

**Dodawanie napisów do klatki wideo**

Aby dodać napisy do klatki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) .
1. Dodaj wideo do prezentacji.
1. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) do slajdu.
1. Użyj [ICaptionsCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/) zwróconego przez [getCaptionTracks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) aby dodać ścieżkę napisów w formacie WebVTT.
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak dodać napisy do klatki wideo:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Dodaje nową ścieżkę napisów z pliku WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Interfejs [ICaptionsCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/) udostępnia także przeciążenie, które pozwala dodać napisy z strumienia.  

**Wyodrębnianie napisów z klatki wideo**

Aby wyodrębnić napisy z klatki wideo:

1. Wczytaj prezentację zawierającą wideo.
1. Znajdź docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) .
1. Przejdź przez wszystkie ścieżki napisów w [ICaptionsCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/) .
1. Zapisz każdą ścieżkę napisów do pliku `.vtt`.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Zapisuje ścieżkę napisów do pliku WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Każdy obiekt [ICaptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF‑8.  

**Usuwanie napisów z klatki wideo**

Aby usunąć napisy z klatki wideo:

1. Wczytaj prezentację zawierającą wideo.
1. Pobierz docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) .
1. Usuń ścieżki napisów z [ICaptionsCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/) .
1. Zapisz zmodyfikowaną prezentację.

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Usuwa wszystkie napisy z klatki wideo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli trzeba usunąć tylko jedną ścieżkę, użyj metod [remove](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) lub [removeAt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/#removeAt-int-) zamiast [clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/#clear--) .  

## **Wyodrębnianie wideo ze slajdów**

Poza dodawaniem wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) aby wczytać prezentację zawierającą wideo. 
2. Przejdź przez wszystkie obiekty [ISlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/) .
3. Przejdź przez wszystkie obiekty [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) aby znaleźć [VideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/videoframe/) . 
4. Zapisz wideo na dysku.

```java
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                // Pobiera rozszerzenie pliku
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Which video playback parameters can be changed for a VideoFrame?**  
Można kontrolować [playback mode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/videoframe/#setPlayMode-int-) (auto lub po kliknięciu) oraz [looping](https://reference.aspose.com/slides/pl/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Opcje te są dostępne w właściwościach obiektu [VideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/videoframe/) .  

**Does adding a video affect the PPTX file size?**  
Tak. Gdy osadzisz lokalne wideo, dane binarne są dołączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodasz wideo online, osadzany jest jedynie link i miniatura, więc przyrost rozmiaru jest mniejszy.  

**Can I replace the video in an existing VideoFrame without changing its position and size?**  
Tak. Możesz zamienić [video content](https://reference.aspose.com/slides/pl/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) w klatce, zachowując jednocześnie jej położenie i wymiary; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.  

**Can the content type (MIME) of an embedded video be determined?**  
Tak. Osadzone wideo posiada [content type](https://reference.aspose.com/slides/pl/java/com.aspose.slides/video/#getContentType--) , który można odczytać i wykorzystać, np. przy zapisywaniu go na dysku.