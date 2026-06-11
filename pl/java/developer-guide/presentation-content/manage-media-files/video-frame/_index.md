---
title: "Zarządzanie ramkami wideo w prezentacjach przy użyciu Javy"
linktitle: "Ramka wideo"
type: docs
weight: 10
url: /pl/java/video-frame/
keywords:
- "dodaj wideo"
- "utwórz wideo"
- "osadź wideo"
- "wyodrębnij wideo"
- "pobierz wideo"
- "ramka wideo"
- "źródło internetowe"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Java"
- "Aspose.Slides"
description: "Naucz się programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Odpowiednio umieszczone wideo w prezentacji może uczynić twoją wiadomość bardziej przekonującą i zwiększyć poziom zaangażowania odbiorców. 

PowerPoint pozwala dodać wideo do slajdu w prezentacji na dwa sposoby:

* Dodaj lub osadź wideo lokalne (przechowywane na twoim komputerze)
* Dodaj wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia interfejs [IVideo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideo/) , interfejs [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) oraz inne powiązane typy. 

## **Utwórz osadzone ramki wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w prezentacji. 

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation)class.
1. Pobierz referencję do slajdu przez jego indeks. 
1. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideo/) i przekaż ścieżkę pliku wideo, aby osadzić wideo w prezentacji. 
1. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) aby utworzyć ramkę dla wideo.  
1. Zapisz zmodyfikowaną prezentację. 

Ten kod w języku Java pokazuje, jak dodać lokalnie przechowywane wideo do prezentacji:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Ładuje wideo
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Pobiera pierwszy slajd i dodaje ramkę wideo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Zapisuje prezentację na dysk
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternatywnie możesz dodać wideo, przekazując jego ścieżkę pliku bezpośrednio do metody [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Utwórz ramki wideo z wideo z źródeł internetowych**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) obsługuje wideo z YouTube w prezentacjach. Jeśli wideo, którego chcesz użyć, jest dostępne online (np. na YouTube), możesz dodać je do prezentacji za pomocą jego linku internetowego. 

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation)class
1. Pobierz referencję do slajdu przez jego indeks. 
1. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideo/) i przekaż link do wideo.
1. Ustaw miniaturę dla ramki wideo. 
1. Zapisz prezentację. 

Ten kod w języku Java pokazuje, jak dodać wideo z internetu do slajdu w prezentacji PowerPoint:

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

## **Zarządzaj napisami wideo**

Aspose.Slides umożliwia zarządzanie zamkniętymi napisami dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane poprzez metodę [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Dodaj napisy do ramki wideo**

Aby dodać napisy do ramki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) .
1. Dodaj wideo do prezentacji.
1. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) do slajdu.
1. Użyj [ICaptionsCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/) zwróconego przez [getCaptionTracks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) aby dodać ścieżkę napisów WebVTT.
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak dodać napisy do ramki wideo:

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

**Wyodrębnij napisy z ramki wideo**

Aby wyodrębnić napisy z ramki wideo:

1. Wczytaj prezentację zawierającą wideo.
1. Znajdź docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) .
1. Przejdź przez wszystkie ścieżki napisów w [ICaptionsCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/) .
1. Zapisz każdą ścieżkę napisów do pliku `.vtt` .

Poniższy kod pokazuje, jak wyodrębnić napisy z ramki wideo:

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

**Usuń napisy z ramki wideo**

Aby usunąć napisy z ramki wideo:

1. Wczytaj prezentację zawierającą wideo.
1. Pobierz docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) .
1. Usuń ścieżki napisów z [ICaptionsCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/) .
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak usunąć wszystkie napisy z ramki wideo:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Usuwa wszystkie napisy z ramki wideo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisów, użyj metod [remove](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) lub [removeAt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/#removeAt-int-) zamiast [clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/#clear--) .

## **Wyodrębnij wideo ze slajdów**

Poza dodawaniem wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) aby wczytać prezentację zawierającą wideo. 
2. Przejdź przez wszystkie obiekty [ISlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/) .
3. Przejdź przez wszystkie obiekty [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) aby znaleźć [VideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/videoframe/) . 
4. Zapisz wideo na dysku.

Ten kod w języku Java pokazuje, jak wyodrębnić wideo ze slajdu prezentacji:

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

**Jakie parametry odtwarzania wideo można zmienić w VideoFrame?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/pl/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatyczny lub po kliknięciu) oraz [pętlę odtwarzania](https://reference.aspose.com/slides/pl/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/videoframe/) .

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzisz lokalne wideo, dane binarne są włączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodasz wideo online, osadzany jest jedynie link i miniatura, więc przyrost rozmiaru jest mniejszy.

**Czy mogę zastąpić wideo w istniejącej VideoFrame bez zmiany jej położenia i rozmiaru?**

Tak. Możesz wymienić [zawartość wideo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) w ramce, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo posiada [typ zawartości](https://reference.aspose.com/slides/pl/java/com.aspose.slides/video/#getContentType--) , który możesz odczytać i wykorzystać, na przykład przy zapisie na dysk.