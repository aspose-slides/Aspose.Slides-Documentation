---
title: Zarządzanie klatkami wideo w prezentacjach na Androidzie
linktitle: Klatka wideo
type: docs
weight: 10
url: /pl/androidjava/video-frame/
keywords:
- dodaj wideo
- utwórz wideo
- osadź wideo
- wyodrębij wideo
- pobierz wideo
- klatka wideo
- źródło internetowe
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Naucz się programowo dodawać i wyodrębniać klatki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Android via Java. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Filmy mogą pomóc w wyjaśnianiu pomysłów i angażowaniu odbiorców. Aspose.Slides for Android via Java umożliwia dodawanie klatek wideo do slajdów, dostosowywanie ustawień odtwarzania, zarządzanie napisami oraz wyodrębnianie osadzonych danych wideo.

PowerPoint obsługuje lokalne filmy oraz odnośniki do filmów online, takich jak filmy z YouTube.

Aby reprezentować dane wideo i klatki wideo, Aspose.Slides udostępnia interfejs [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) oraz interfejs [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/), a także inne odpowiednie typy.

## **Utworzenie osadzonej klatki wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć klatkę wideo, aby osadzić wideo w swojej prezentacji.

Ten przykład osadza lokalny film na pierwszym slajdzie istniejącej prezentacji i zapisuje wynik. Współrzędne i wymiary klatki są podawane w punktach. Strumień pozostaje otwarty aż do zakończenia zapisu, ponieważ [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) utrzymuje go zablokowany, gdy prezentacja go używa.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Możesz także przekazać ścieżkę do lokalnego filmu bezpośrednio do [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Ten przykład osadza wideo na pierwszym slajdzie nowej prezentacji. Film musi pozostać dostępny aż do zapisania prezentacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utworzenie klatki wideo z wideo z źródła internetowego**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) obsługuje filmy online w prezentacjach. Możesz utworzyć klatkę wideo, która odwołuje się do filmu online, takiego jak film z YouTube.

Ten przykład dodaje odnośnik do filmu z YouTube oraz miniaturę na pierwszy slajd. Zastąp identyfikator filmu, aby użyć innego filmu. Metoda [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) żąda automatycznego odtwarzania. Pobranie miniatury i odtworzenie filmu wymaga dostępu do Internetu. Odtwarzacz prezentacji musi również obsługiwać odtwarzanie filmów online.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Odtworzenie wideo w trybie pełnoekranowym**

W prezentacji szkoleniowej możesz odtworzyć demonstrację oprogramowania w trybie pełnoekranowym, aby publiczność mogła zobaczyć szczegóły. Wywołaj [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) z wartością `true`, aby włączyć to zachowanie podczas odtwarzania.

Ten przykład otwiera prezentację, znajduje pierwszą [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) na pierwszym slajdzie i włącza odtwarzanie pełnoekranowe. Wejściowa prezentacja musi zawierać co najmniej jeden slajd z istniejącą klatką wideo na pierwszym slajdzie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Odtwarzanie w trybie pełnoekranowym kontroluje sposób wyświetlania wideo. Oddzielnie, [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) kontroluje, czy zaczyna się automatycznie czy po kliknięciu, a [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) określa, czy się powtarza. Aby wybrać zachowanie przy uruchamianiu, ustaw tryb odtwarzania na [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). Przykład zachowuje istniejące ustawienia startu i pętli.

## **Cofnięcie wideo po odtworzeniu**

W prezentacji szkoleniowej przywrócenie filmu demonstracyjnego do jego początku przygotowuje go do ponownego odtworzenia przez prezentera. Wywołaj [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) z `true`, aby po zakończeniu odtwarzania cofnąć wideo do początku.

Ten przykład otwiera prezentację, znajduje pierwszą [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) na pierwszym slajdzie i włącza cofanie. Wyłącza pętlę, aby odtwarzanie mogło się zakończyć, i ustawia odtwarzanie na rozpoczęcie po kliknięciu. Wejściowa prezentacja musi zawierać co najmniej jeden slajd z istniejącą klatką wideo na pierwszym slajdzie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cofanie przywraca wideo do początku bez jego ponownego uruchamiania. Natomiast wywołanie [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) z `true` powoduje automatyczne powtarzanie odtwarzania. Utrzymuj pętlę wyłączoną, gdy chcesz, aby wideo zakończyło się i było gotowe do ponownego odtworzenia. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) niezależnie kontroluje automatyczne lub ręczne uruchomienie; ten przykład używa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) aby prezenter decydował o rozpoczęciu odtwarzania. Ustaw tryb odtwarzania po ustawieniu pętli, jak pokazano w przykładzie. Cofanie działa niezależnie od [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Przycięcie klatki wideo**

Użyj [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) i [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) , aby pominąć część początku lub końca wideo podczas odtwarzania. Obie wartości podawane są w milisekundach. Przycinanie zmienia ustawienia odtwarzania bez modyfikacji osadzonych danych wideo.

**Ustawienia przycięcia**

Ten przykład osadza lokalny film i pomija pierwsze 2,5 sekundy oraz ostatnią sekundę podczas odtwarzania. Użyj filmu dłuższego niż 3,5 sekundy, aby pozostał odtwarzalny fragment.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Odczyt ustawień przycięcia**

Ten przykład wypisuje wartości przycięcia pierwszej klatki wideo na pierwszym slajdzie w milisekundach. Prezentacja musi zawierać co najmniej jeden slajd. Jeśli ten slajd nie ma klatki wideo, nic nie zostanie wypisane. Poprzedni przykład generuje wartości 2500 i 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Zarządzanie napisami wideo**

Aspose.Slides umożliwia zarządzanie napisami zamkniętymi dla klatek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane za pośrednictwem metody [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

### **Dodanie napisów do klatki wideo**

Ten przykład osadza lokalny film i dodaje ścieżkę napisów WebVTT oznaczoną jako English. Znaczniki czasu napisów powinny odpowiadać wideo. Zapisana prezentacja zawiera zarówno film, jak i jego napisy.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Interfejs [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) udostępnia również przeciążenie, które pozwala dodać napisy z strumienia.

### **Wyodrębnienie napisów z klatki wideo**

Ten przykład zapisuje wszystkie ścieżki napisów z klatek wideo na pierwszym slajdzie jako osobne pliki WebVTT. Kolejne numery utrzymują pliki wyjściowe odrębne. Konsola raportuje liczbę wyodrębnionych ścieżek. Prezentacja musi zawierać co najmniej jeden slajd.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Każdy obiekt [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF-8.

### **Usunięcie napisów z klatki wideo**

Ten przykład usuwa wszystkie napisy z klatki wideo znajdującej się na pierwszej pozycji kształtu na pierwszym slajdzie i zapisuje wynik. Zakłada, że slajd i kształt istnieją oraz że kształt jest klatką wideo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisu, użyj metod [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) lub [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) zamiast [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--).

### **Wyszukiwanie napisów wideo**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) zwraca kompletną ścieżkę WebVTT, włącznie z nagłówkiem, liniami czasowymi i tekstem napisu. Możesz przeszukać wskazówki w pamięci, aby znaleźć wypowiedziane zdanie i jego znacznik czasu. Na przykład, angielska ścieżka na slajdzie 2 może zawierać następujący tekst.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Przykład otwiera `captioned_media.pptx` i używa [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) , aby odczytać ścieżki każdej najwyższej klatki wideo na każdym slajdzie. W tekście surowym wskazówki linia czasowa zawiera `-->`, a pusty wiersz kończy wskazówkę. Gdy napis zawiera słowo „café” w dowolnej wielkości liter, przykład wypisuje numer slajdu, etykietę ścieżki, oryginalną linię czasową i pełny napis.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringBuilder caption = new StringBuilder();
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            if (caption.length() > 0) {
                                caption.append('\n');
                            }
                            caption.append(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Wyszukiwanie „café” zwraca jedno dopasowanie w przykładowej ścieżce. Wyszukiwanie pomija nagłówek ścieżki i zachowuje ustawienie czasu w wyniku.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Wyodrębnienie wideo ze slajdu**

Oprócz dodawania wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

Ten przykład wyodrębnia osadzone filmy ze wszystkich slajdów do osobnych, ponumerowanych plików binarnych. Filmy powiązane są pomijane, ponieważ nie mają osadzonych danych. Konsola wypisuje typ MIME każdego filmu oraz całkowitą liczbę. Wyjście używa ogólnego rozszerzenia `.bin`; zmień je w razie potrzeby, aby pasowało do zgłaszanego typu mediów.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jakie parametry odtwarzania wideo można zmienić dla klatki wideo?**

Możesz kontrolować [playback mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (auto lub po kliknięciu) oraz [looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Opcje te są dostępne poprzez metody obiektu [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalny film, dane binarne są dołączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy odwołujesz się do filmu online i dodajesz miniaturę, prezentacja przechowuje odnośnik i obraz podglądu zamiast danych wideo, więc przyrost rozmiaru jest zazwyczaj mniejszy.

**Czy mogę wymienić wideo w istniejącej klatce wideo bez zmiany jej położenia i rozmiaru?**

Tak. Możesz zamienić [video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) w ramach klatki, zachowując geometrię kształtu; jest to częsty scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo ma [content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) , którą możesz odczytać i wykorzystać, na przykład przy zapisywaniu go na dysk.