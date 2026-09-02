---
title: "Zarządzanie ramkami wideo w prezentacjach na Androidzie"
linktitle: "Ramka wideo"
type: docs
weight: 10
url: /pl/androidjava/video-frame/
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
- "Android"
- "Java"
- "Aspose.Slides"
description: "Dowiedz się, jak programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w języku Java. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Odpowiednio umieszczone wideo w prezentacji może uczynić Twoją wiadomość bardziej przekonującą i zwiększyć poziom zaangażowania odbiorców. 

PowerPoint umożliwia dodawanie wideo do slajdu w prezentacji na dwa sposoby:

* Dodaj lub osadź lokalne wideo (przechowywane na Twoim komputerze)
* Dodaj wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia interfejs [IVideo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideo/) , interfejs [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) oraz inne odpowiednie typy.

## **Utworzenie osadzonej ramki wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w swojej prezentacji. 

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideo/) i przekaż ścieżkę do pliku wideo, aby osadzić wideo w prezentacji.
1. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) w celu utworzenia ramki dla wideo.
1. Zapisz zmodyfikowaną prezentację. 

Ten kod Java pokazuje, jak dodać lokalnie przechowywane wideo do prezentacji:

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

Alternatywnie, możesz dodać wideo, przekazując jego ścieżkę pliku bezpośrednio do metody [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Utworzenie ramki wideo z wideo ze źródła internetowego**

Nowsze wersje Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) obsługują wideo online w prezentacjach. Jeśli wideo, którego chcesz użyć, jest dostępne w Internecie (np. na YouTube), możesz dodać je do prezentacji za pomocą linku internetowego.

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideo/) i przekaż link do wideo.
1. Ustaw miniaturę dla ramki wideo. 
1. Zapisz prezentację. 

Ten kod Java pokazuje, jak dodać wideo z Internetu do slajdu w prezentacji PowerPoint:

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

## **Przycięcie ramki wideo**

Aspose.Slides umożliwia kontrolowanie, która część wideo jest odtwarzana, poprzez ustawienie wartości trim-from-start i trim-from-end za pomocą [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) i [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Obie wartości podawane są w milisekundach i określają, ile czasu zostaje pominięte na początku i końcu wideo. Te ustawienia zmieniają sposób odtwarzania wideo w prezentacji; nie przycinają ani nie modyfikują binarnych danych osadzonego wideo.

**Ustawienia przycięcia**

Aby utworzyć ramkę wideo i ustawić jej przycięcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideo/) do prezentacji.
1. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) do slajdu.
1. Ustaw wartości trim-from-start i trim-from-end za pomocą [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) i [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Zapisz zmodyfikowaną prezentację.

Poniższy przykład kodu pomija pierwsze 2,5 sekundy oraz ostatnią sekundę osadzonego wideo podczas odtwarzania:

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

Aby sprawdzić istniejące ustawienia przycięcia, załaduj prezentację, znajdź obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) wśród kształtów na pierwszym slajdzie i odczytaj wartości za pomocą [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) oraz [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

Poniższy przykład kodu znajduje pierwszą ramkę wideo na pierwszym slajdzie i zgłasza jej ustawienia przycięcia w milisekundach:

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

Aspose.Slides umożliwia zarządzanie zamkniętymi napisami dla ramek wideo w prezentacjach PowerPoint. Napisy przechowywane są w formacie WebVTT i udostępniane są za pomocą metody [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Dodawanie napisów do ramki wideo**

Aby dodać napisy do ramki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) .
1. Dodaj wideo do prezentacji.
1. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) do slajdu.
1. Użyj [ICaptionsCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/) zwróconego przez [getCaptionTracks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) , aby dodać ścieżkę napisów WebVTT.
1. Zapisz zmodyfikowaną prezentację.

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

Interfejs [ICaptionsCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/) udostępnia również przeciążenie, które pozwala dodać napisy z strumienia.

**Wyodrębnianie napisów z ramki wideo**

Aby wyodrębnić napisy z ramki wideo:

1. Załaduj prezentację zawierającą wideo.
2. Znajdź docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) .
3. Iteruj przez ścieżki napisów zwrócone przez [getCaptionTracks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .
4. Zapisz każdą ścieżkę napisów do pliku `.vtt` .

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

Każdy [ICaptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz dane napisu jako ciąg UTF-8.

**Usuwanie napisów z ramki wideo**

Aby usunąć napisy z ramki wideo:

1. Załaduj prezentację zawierającą wideo.
2. Uzyskaj docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ivideoframe/) .
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

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisów, użyj metod [remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) lub [removeAt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) zamiast [clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/#clear--) .

## **Wyodrębnianie wideo ze slajdu**

Oprócz dodawania wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) w celu załadowania prezentacji zawierającej wideo.
2. Iteruj przez wszystkie obiekty [ISlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/) .
3. Iteruj przez wszystkie obiekty [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) , aby znaleźć [VideoFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/videoframe/) .
4. Zapisz wideo na dysku.

Ten kod Java pokazuje, jak wyodrębnić wideo ze slajdu w prezentacji:

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

                //Pobiera rozszerzenie pliku
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

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzisz lokalne wideo, dane binarne są zawarte w dokumencie, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodasz wideo online, osadzany jest jedynie link i miniatura, więc wzrost rozmiaru jest mniejszy.

**Czy mogę wymienić wideo w istniejącej VideoFrame bez zmiany jej położenia i rozmiaru?**

Tak. Możesz wymienić [zawartość wideo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) w ramce, zachowując geometryczne właściwości kształtu; jest to częsty scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo ma [typ zawartości](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/video/#getContentType--) , który możesz odczytać i wykorzystać, na przykład przy zapisywaniu go na dysk.