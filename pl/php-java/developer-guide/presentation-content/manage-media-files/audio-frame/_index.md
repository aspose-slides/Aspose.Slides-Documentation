---
title: Zarządzanie ramkami audio w prezentacjach przy użyciu PHP
linktitle: Ramka audio
type: docs
weight: 10
url: /pl/php-java/audio-frame/
keywords:
- dźwięk
- ramka audio
- miniatura
- dodaj dźwięk
- właściwości audio
- opcje audio
- wyodrębnij audio
- PHP
- Aspose.Slides
description: "Osadź audio na slajdach, zmień ikonę audio, skonfiguruj odtwarzanie, zarządzaj napisami WebVTT i wyodrębnij dźwięki przejść slajdów za pomocą Aspose.Slides for PHP via Java."
---
## **Przegląd**

Ramka audio umożliwia odtwarzanie dźwięku na slajdzie. Za pomocą Aspose.Slides for PHP via Java możesz osadzić klip audio, wybrać obraz go reprezentujący, dostosować odtwarzanie i dołączyć napisy. Możesz także pobrać dźwięk przypisany do przejścia slajdu.

## **Tworzenie ramek audio**

Użyj [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) aby osadzić lokalny klip audio na pierwszym slajdzie. Pierwsze dwa współrzędne określają pozycję ramki na slajdzie, a kolejne dwie wartości ustawiają jej szerokość i wysokość, wszystkie w punktach. Ten przykład wywołuje [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) aby uruchomić klip automatycznie i wywołuje [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) aby wybrać głośny preset.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zmiana miniaturki ramki audio**

Domyślnie ramka audio wyświetla ikonę głośnika. Aby wyświetlić własną miniaturkę, dodaj obraz do prezentacji za pomocą [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) i ustaw go w ramce za pomocą [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/). Przykład używa pliku JPEG jako miniaturki dla osadzonego klipu audio.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zmiana opcji odtwarzania audio**

Kontrolki **Audio Options** w programie PowerPoint określają, kiedy klip się rozpoczyna, jak głośny jest i jak zachowuje się podczas pokazu slajdów.

![Kontrolki Audio Options w PowerPoint dla ramki audio](audio_frame_0.png)

| Kontrola PowerPoint | Metoda Aspose.Slides for PHP via Java |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Volume preset | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Play Across Slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Loop until Stopped | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Hide During Show | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Rewind after Playing | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Trim Audio start time | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Trim Audio end time | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volume slider | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

Przykład znajduje pierwszą ramkę audio na pierwszym slajdzie, wywołuje [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) aby rozpocząć odtwarzanie po kliknięciu i wybiera niski preset głośności. Klip kontynuuje odtwarzanie na kolejnych slajdach z wyłączoną pętlą. Ikona pozostaje ukryta podczas pokazu, a klip przewija się po odtworzeniu.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

Jeśli klip jest dłuższy niż 3,5 sekundy, ten przykład pomija pierwsze 1,5 sekundy i ostatnie 2 sekundy. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) przyjmuje czas do pominięcia od końca klipu. Aby uzyskać czas końcowy wyświetlany w PowerPoint, odejmij ten offset od pełnej długości klipu. Przycięty klip wznika w ciągu 200 milisekund i zanika w ciągu 500 milisekund. Wszystkie cztery metody przyjmują wartości w milisekundach.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aby ustawić głośność odtwarzania na określony procent, użyj [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Ten przykład ustawia pierwszą ramkę audio na pierwszym slajdzie na 85%.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **Zarządzanie napisami audio**

Każda ramka audio udostępnia dostęp do swoich ścieżek napisów poprzez [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks). Użyj kolekcji, aby dołączyć napisy WebVTT do klipu, wyeksportować istniejące ścieżki lub je usunąć.

### **Dodawanie napisów audio**

Przykład osadza klip audio na pierwszym slajdzie i używa [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) aby dołączyć lokalną ścieżkę WebVTT. Pierwszy argument podaje etykietę ścieżki, a drugi identyfikuje plik zawierający napisy czasowe.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Eksportowanie napisów audio**

Ten przykład eksportuje każdą ścieżkę napisów dołączoną do ramki audio na pierwszym slajdzie. Zapisuje bajty zwrócone przez [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) do pliku WebVTT i używa identyfikatora zwróconego przez [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) jako nazwy pliku, tak aby każda ścieżka miała osobny wynik.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **Usuwanie napisów audio**

Użyj [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) lub [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt), aby usunąć pojedynczą ścieżkę. Przykład używa [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear), aby usunąć wszystkie napisy z pierwszej ramki audio na pierwszym slajdzie, zachowując klip.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

### **Znajdowanie linii w napisach audio**

Aby znaleźć linię w napisach audio na pierwszym slajdzie, przeszukaj tekst zwrócony przez [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) w pamięci. W czystym pliku WebVTT cue linia z czasem zawiera `-->`, linie napisów następują po niej, a pusta linia kończy cue. Ten przykład wypisuje etykietę ścieżki i każdą linię napisu zawierającą „café”.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Eksportowanie audio**

Przejście slajdu może mieć własny dźwięk. Aby go pobrać, wywołaj [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) na przejściu slajdu. Przykład uzyskuje bajty zwrócone przez [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) i wypisuje liczbę bajtów. Jeśli pierwszy slajd nie ma dźwięku przejścia, wypisuje odpowiedni komunikat.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy mogę ponownie użyć tego samego klipu audio na wielu slajdach bez jego duplikowania?**

Tak. Dodaj klip raz do [kolekcji audio](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) prezentacji i przekaż ten sam obiekt audio do [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) dla każdego slajdu.

**Czy mogę zastąpić dźwięk w istniejącej ramce audio?**

Tak. Dla dźwięku powiązanego użyj [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) aby wskazać plik zastępczy. Dla dźwięku osadzonego wybierz inny klip z kolekcji audio prezentacji przy użyciu [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). Oba podejścia zachowują istniejącą ramkę.

**Czy przycinanie zmienia dane audio przechowywane w prezentacji?**

Nie. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) i [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) ustalają granice odtwarzania. Nadal możesz pobrać pełny klip za pomocą [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/).