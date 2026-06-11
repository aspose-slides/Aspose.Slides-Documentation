---
title: Zarządzanie ramkami wideo w prezentacjach na Androidzie
linktitle: Ramka wideo
type: docs
weight: 10
url: /pl/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w Javie. Szybki przewodnik instruktażowy."
---
## **Wprowadzenie**

Dobrze dobrany film w prezentacji może uczynić przekaz bardziej przekonującym i zwiększyć poziom zaangażowania odbiorców.

PowerPoint umożliwia dodanie filmów do slajdu w prezentacji na dwa sposoby:

* Dodanie lub osadzenie lokalnego filmu (przechowywanego na komputerze)
* Dodanie filmu online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie filmów (obiektów wideo) do prezentacji, Aspose.Slides udostępnia interfejs [IVideo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideo/), interfejs [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) oraz inne powiązane typy.

## **Utworzenie osadzonej ramki wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić film w prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Pobierz odwołanie do slajdu za pomocą jego indeksu. 
3. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideo/) i przekaż ścieżkę do pliku wideo, aby osadzić go w prezentacji.
4. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) w celu utworzenia ramki dla wideo.
5. Zapisz zmodyfikowaną prezentację. 

Ten kod Java pokazuje, jak dodać lokalnie przechowywany film do prezentacji:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Ładuje wideo
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Pobiera pierwszy slajd i dodaje ramkę wideo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Zapisuje prezentację na dysku
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternatywnie możesz dodać film, przekazując jego ścieżkę bezpośrednio do metody [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Utworzenie ramki wideo z filmem ze źródła internetowego**

Microsoft [PowerPoint 2013 i nowsze](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) obsługuje filmy z YouTube w prezentacjach. Jeśli film, którego chcesz użyć, jest dostępny online (np. na YouTube), możesz dodać go do prezentacji, podając jego link internetowy.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Pobierz odwołanie do slajdu za pomocą jego indeksu. 
3. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideo/) i przekaż link do filmu.
4. Ustaw miniaturkę dla ramki wideo. 
5. Zapisz prezentację. 

Ten kod Java pokazuje, jak dodać film z sieci do slajdu w prezentacji PowerPoint:

```java
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
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
    // Dodaje ramkę wideo
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Ładuje miniaturkę
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

## **Zarządzanie napisami wideo**

Aspose.Slides umożliwia zarządzanie napisami zamkniętymi dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane poprzez metodę [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Dodawanie napisów do ramki wideo**

Aby dodać napisy do ramki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) .
2. Dodaj film do prezentacji.
3. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) do slajdu.
4. Skorzystaj z [ICaptionsCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/) zwróconego przez [getCaptionTracks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) w celu dodania ścieżki napisów WebVTT.
5. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak dodać napisy do ramki wideo:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
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

Interfejs [ICaptionsCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/) oferuje również przeciążenie umożliwiające dodanie napisów ze strumienia.

**Wyodrębnianie napisów z ramki wideo**

Aby wyodrębnić napisy z ramki wideo:

1. Załaduj prezentację zawierającą film.
2. Znajdź docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) .
3. Przejdź przez ścieżki napisów zwrócone przez [getCaptionTracks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .
4. Zapisz każdą ścieżkę napisów do pliku `.vtt`.

Poniższy kod pokazuje, jak wyodrębnić napisy z ramki wideo:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Zapisuje ścieżkę napisów do pliku WebVTT.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Każdy obiekt [ICaptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz treść napisu jako łańcuch UTF‑8.

**Usuwanie napisów z ramki wideo**

Aby usunąć napisy z ramki wideo:

1. Załaduj prezentację zawierającą film.
2. Pobierz docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) .
3. Usuń ścieżki napisów z kolekcji zwróconej przez [getCaptionTracks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .
4. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak usunąć wszystkie napisy z ramki wideo:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Usuwa wszystkie napisy z ramki wideo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli chcesz usunąć tylko jedną ścieżkę, użyj metod [remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) lub [removeAt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) zamiast [clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/#clear--) .

## **Wyodrębnianie wideo ze slajdu**

Oprócz dodawania filmów do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) w celu załadowania prezentacji zawierającej film.
2. Przejdź przez wszystkie obiekty [ISlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/) .
3. Przejdź przez wszystkie obiekty [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) w poszukiwaniu [VideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/videoframe/) .
4. Zapisz film na dysku.

Ten kod Java pokazuje, jak wyodrębnić film ze slajdu prezentacji:

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

**Jakie parametry odtwarzania wideo można zmienić dla VideoFrame?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatyczny lub po kliknięciu) oraz [pętlę](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/videoframe/) .

**Czy dodanie filmu wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalny film, dane binarne są włączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodajesz film online, osadzany jest jedynie link i miniaturka, więc przyrost rozmiaru jest mniejszy.

**Czy mogę zamienić film w istniejącej ramce VideoFrame bez zmiany jej położenia i rozmiaru?**

Tak. Możesz zamienić [zawartość wideo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) w ramce, zachowując geometrę kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego filmu?**

Tak. Osadzony film posiada [typ zawartości](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/video/#getContentType--) , który możesz odczytać i wykorzystać, np. przy zapisywaniu go na dysku.