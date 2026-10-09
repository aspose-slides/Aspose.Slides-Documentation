---
title: "Zarządzanie ramkami wideo w prezentacjach przy użyciu PHP"
linktitle: "Ramka wideo"
type: docs
weight: 10
url: /pl/php-java/video-frame/
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
- "PHP"
- "Aspose.Slides"
description: "Dowiedz się, jak programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP via Java. Szybki przewodnik instruktażowy."
---
## **Wprowadzenie**

Filmy mogą pomóc wyjaśnić pomysły i zaangażować odbiorców. Aspose.Slides for PHP via Java umożliwia dodawanie ramek wideo do slajdów, dostosowywanie ustawień odtwarzania, zarządzanie napisami i wyodrębnianie osadzonych danych wideo.

PowerPoint obsługuje lokalne filmy oraz odnośniki do filmów online, takich jak filmy z YouTube.

Aby reprezentować dane wideo i ramki wideo, Aspose.Slides udostępnia klasę [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) klasę [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) oraz inne istotne typy.

## **Utwórz osadzoną ramkę wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w swojej prezentacji.

Ten przykład osadza lokalny plik wideo na pierwszym slajdzie istniejącej prezentacji i zapisuje wynik. Współrzędne i wymiary ramki podawane są w punktach. Strumień pozostaje otwarty aż do zakończenia zapisu, ponieważ [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) utrzymuje go zablokowanym, gdy prezentacja go używa.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

Możesz również przekazać ścieżkę do lokalnego wideo bezpośrednio do [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Ten przykład osadza wideo na pierwszym slajdzie nowej prezentacji. Wideo musi pozostać dostępne aż do zapisania prezentacji.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Utwórz ramkę wideo z wideo ze źródła internetowego**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) obsługuje wideo online w prezentacjach. Możesz utworzyć ramkę wideo, która odwołuje się do wideo online, takiego jak wideo z YouTube.

Ten przykład dodaje odnośnik do wideo z YouTube oraz miniaturę na pierwszy slajd. Zastąp identyfikator wideo, aby użyć innego filmu. Metoda [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) żąda automatycznego odtwarzania. Pobieranie miniatury i odtwarzanie wideo wymagają dostępu do internetu. Przeglądarka prezentacji musi również obsługiwać odtwarzanie wideo online.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Odtwórz wideo w trybie pełnoekranowym**

W prezentacji szkoleniowej możesz odtworzyć demonstrację oprogramowania w trybie pełnoekranowym, aby publiczność widziała szczegóły. Wywołaj [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) z `true`, aby włączyć to zachowanie podczas odtwarzania.

Ten przykład otwiera prezentację, znajduje pierwszą [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) na pierwszym slajdzie i włącza odtwarzanie w trybie pełnoekranowym. Wejściowa prezentacja musi zawierać przynajmniej jeden slajd z istniejącą ramką wideo na pierwszym slajdzie.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Odtwarzanie w trybie pełnoekranowym kontroluje sposób wyświetlania wideo. Niezależnie od tego, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) określa, czy odtwarzanie rozpoczyna się automatycznie czy po kliknięciu, a [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) określa, czy wideo się powtarza. Aby wybrać zachowanie startu, ustaw tryb odtwarzania na [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Przykład zachowuje istniejące ustawienia startu i pętli.

## **Przewiń wideo po odtworzeniu**

W prezentacji szkoleniowej przywrócenie filmu demonstracyjnego do początku sprawia, że jest gotowy do ponownego odtworzenia przez prezentera. Wywołaj [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) z `true`, aby po zakończeniu odtwarzania przewinąć wideo do początku.

Ten przykład otwiera prezentację, znajduje pierwszą [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) na pierwszym slajdzie i włącza przewijanie. Wyłącza pętlę, aby odtwarzanie mogło się zakończyć, i ustawia odtwarzanie na start po kliknięciu. Wejściowa prezentacja musi zawierać przynajmniej jeden slajd z istniejącą ramką wideo na pierwszym slajdzie.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Przewijanie zwraca wideo do początku bez ponownego uruchamiania. Natomiast wywołanie [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) z `true` powtarza odtwarzanie automatycznie. Wyłącz pętlę, gdy chcesz, aby wideo zakończyło się i było gotowe do ponownego odtworzenia. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) niezależnie steruje automatycznym lub klikowym uruchomieniem; ten przykład używa [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/), aby prezenter kontrolował moment rozpoczęcia odtwarzania. Ustaw tryb odtwarzania po ustawieniu pętli, jak pokazano w przykładzie. Przewijanie działa niezależnie od [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Przytnij ramkę wideo**

Użyj [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) oraz [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd), aby pominąć część początku lub końca wideo podczas odtwarzania. Obie wartości podawane są w milisekundach. Przycinanie zmienia ustawienia odtwarzania bez modyfikacji osadzonych danych wideo.

**Ustawienia przycięcia**

Ten przykład osadza lokalny plik wideo i pomija pierwsze 2,5 sekundy oraz ostatnią sekundę podczas odtwarzania. Użyj wideo dłuższego niż 3,5 sekundy, aby pozostał odtwarzalny segment.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Odczytaj ustawienia przycięcia**

Ten przykład wypisuje wartości przycięcia pierwszej ramki wideo na pierwszym slajdzie w milisekundach. Prezentacja musi zawierać przynajmniej jeden slajd. Jeśli ten slajd nie ma ramki wideo, nic nie zostanie wypisane. Poprzedni przykład generuje wartości 2500 i 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Zarządzaj napisami wideo**

Aspose.Slides umożliwia zarządzanie zamkniętymi napisami dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane za pośrednictwem metody [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Dodaj napisy do ramki wideo**

Ten przykład osadza lokalny plik wideo i dodaje ścieżkę napisów WebVTT oznaczoną jako English. Znaczniki czasu napisów powinny odpowiadać wideo. Zapisana prezentacja zawiera zarówno wideo, jak i jego napisy.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Klasa [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) również oferuje przeciążenie umożliwiające dodanie napisów ze strumienia.

**Wyodrębnij napisy z ramki wideo**

Ten przykład zapisuje wszystkie ścieżki napisów z ramek wideo na pierwszym slajdzie jako oddzielne pliki WebVTT. Kolejne liczby utrzymują pliki wynikowe jako odrębne. Konsola raportuje liczbę wyodrębnionych ścieżek. Prezentacja musi zawierać przynajmniej jeden slajd.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Każdy obiekt [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF-8.

**Usuń napisy z ramki wideo**

Ten przykład usuwa wszystkie napisy z ramki wideo znajdującej się na pierwszej pozycji kształtu na pierwszym slajdzie i zapisuje wynik. Zakłada, że slajd i kształt istnieją oraz że kształt jest ramką wideo.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisów, użyj metod [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) lub [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) zamiast [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Wyodrębnij wideo ze slajdu**

Oprócz dodawania wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

Ten przykład wyodrębnia osadzone wideo z każdego slajdu do osobnych, numerowanych plików binarnych. Wideo połączone (linkowane) są pomijane, ponieważ nie mają osadzonych danych. Konsola wypisuje typ MIME każdego wideo oraz całkowitą liczbę. Wyjście używa ogólnego rozszerzenia `.bin`; w razie potrzeby zmień je, aby pasowało do zgłoszonego typu mediów.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Jakie parametry odtwarzania wideo można zmienić dla ramki wideo?**

Możesz kontrolować [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (auto lub po kliknięciu) oraz [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Opcje te są dostępne poprzez metody obiektu [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalny plik wideo, dane binarne są włączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy linkujesz do wideo online i dodajesz miniaturę, prezentacja zapisuje odnośnik oraz obraz podglądu zamiast danych wideo, więc przyrost rozmiaru jest zazwyczaj mniejszy.

**Czy mogę zastąpić wideo w istniejącej ramce wideo bez zmiany jej pozycji i rozmiaru?**

Tak. Możesz wymienić [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) w ramce, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo posiada [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType), który możesz odczytać i używać, na przykład przy zapisywaniu go na dysk.