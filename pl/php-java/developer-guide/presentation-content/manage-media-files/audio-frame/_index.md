---
title: "Zarządzanie dźwiękiem w prezentacjach przy użyciu PHP"
linktitle: "Ramka audio"
type: docs
weight: 10
url: /pl/php-java/audio-frame/
keywords:
- dźwięk
- ramka audio
- miniatura
- dodaj dźwięk
- właściwości dźwięku
- opcje dźwięku
- wyodrębnij dźwięk
- PHP
- Aspose.Slides
description: "Tworzenie i kontrolowanie ramek audio w Aspose.Slides dla PHP — przykłady kodu do osadzania, przycinania, pętli i konfigurowania odtwarzania w prezentacjach PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z ramkami audio w Aspose.Slides. Pokazuje, jak dodać osadzony dźwięk do slajdów, dostosować miniaturę ramki audio, skonfigurować opcje odtwarzania, takie jak głośność, pętla, ukrywanie, przycinanie i czasy zanikania, oraz wyodrębnić dźwięk używany w przejściach pokazu slajdów.

## **Tworzenie ramek audio**

Aspose.Slides for PHP via Java umożliwia dodawanie plików audio do slajdów. Pliki audio są osadzane w slajdach jako ramki audio.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu poprzez jego indeks.
3. Wczytaj strumień pliku audio, który chcesz osadzić w slajdzie.
4. Dodaj osadzoną ramkę audio (zawierającą plik audio) do slajdu.
5. Ustaw [PlayMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/AudioPlayModePreset) i `Volume` udostępniane przez obiekt [AudioFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/).
6. Zapisz zmodyfikowaną prezentację.

Ten kod PHP pokazuje, jak dodać osadzoną ramkę audio do slajdu:

```php
// Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji
$pres = new Presentation();
try {
    # Pobiera pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Wczytuje plik dźwiękowy wav do strumienia
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Dodaje ramkę audio
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Ustawia tryb odtwarzania i głośność audio
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Zapisuje plik PowerPoint na dysku
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Zmiana miniatury ramki audio**

Po dodaniu pliku audio do prezentacji, audio wyświetlane jest jako ramka z domyślnym standardowym obrazem (zobacz obraz w poniższej sekcji). Możesz zmienić podgląd obrazu ramki audio (ustawić wybrany obraz).

Ten kod PHP pokazuje, jak zmienić miniaturę lub podgląd obrazu ramki audio:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Dodaje ramkę audio do slajdu w określonej pozycji i rozmiarze.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Dodaje obraz do zasobów prezentacji.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Ustawia obraz dla ramki audio.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Zapisuje zmodyfikowaną prezentację na dysku
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Zmiana opcji odtwarzania audio**

Aspose.Slides for PHP via Java umożliwia zmianę ustawień kontrolujących odtwarzanie lub właściwości dźwięku. Na przykład możesz dostosować głośność audio, ustawić odtwarzanie w pętli lub ukryć ikonę audio.

Panel **Opcje audio** w programie Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Opcje audio**, które odpowiadają właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/) :

- **Start** lista rozwijana odpowiada metodzie [AudioFrame::setPlayMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** odpowiada metodzie [AudioFrame::setVolume](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** odpowiada metodzie [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** odpowiada metodzie [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** odpowiada metodzie [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** odpowiada metodzie [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#setRewindAudio)

Opcje **Edycja** w PowerPoint, które odpowiadają właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/) :

- **Fade In** odpowiada metodzie [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** odpowiada metodzie [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** odpowiada metodzie [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** wartość równa jest długości audio minus wartość metody [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#setTrimFromEnd)

Pole **Volume controll** w panelu sterowania audio w PowerPoint odpowiada metodzie [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#setVolumeValue). Pozwala zmienić głośność audio w procentach.

Tak zmienisz opcje odtwarzania audio:

1. [Сreate](#create-audio-frame) lub pobierz ramkę audio.
2. Ustaw nowe wartości właściwości ramki audio, które chcesz dostosować.
3. Zapisz zmodyfikowany plik PowerPoint.

Ten kod PHP demonstruje operację, w której zmieniane są opcje audio:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Pobiera kształt AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ustawia tryb odtwarzania na odtwarzanie po kliknięciu
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Ustawia głośność na niski poziom
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Ustawia odtwarzanie audio na wszystkie slajdy
    $audioFrame->setPlayAcrossSlides(true);
    # Wyłącza pętlę dla audio
    $audioFrame->setPlayLoopMode(false);
    # Ukrywa AudioFrame podczas pokazu slajdów
    $audioFrame->setHideAtShowing(true);
    # Przewija audio do początku po odtworzeniu
    $audioFrame->setRewindAudio(true);
    # Zapisuje plik PowerPoint na dysku
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Ten przykład PHP pokazuje, jak dodać nową ramkę audio z osadzonym dźwiękiem, przyciąć ją i ustawić czasy zanikania:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Ustawia początkowe przesunięcie przycięcia na 1,5 sekundy
    $audioFrame->setTrimFromStart(1500);
    // Ustawia końcowe przesunięcie przycięcia na 2 sekundy
    $audioFrame->setTrimFromEnd(2000);

    // Ustawia czas trwania fade-in na 200 ms
    $audioFrame->setFadeInDuration(200);
    // Ustawia czas trwania fade-out na 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

Poniższy przykład kodu pokazuje, jak pobrać ramkę audio z osadzonym dźwiękiem i ustawić jej głośność na 85%:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Pobiera kształt ramki audio
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Ustawia głośność audio na 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Zarządzanie napisami audio**

Aspose.Slides umożliwia dodawanie zamkniętych napisów do ramki audio za pomocą metody [getCaptionTracks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#getCaptionTracks). Metoda ta zwraca [CaptionsCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/captionscollection/), co pozwala dodać ścieżki napisów WebVTT, iterować istniejące ścieżki i usuwać je w razie potrzeby.

**Dodawanie napisów audio**

Użyj metody [getCaptionTracks](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/#getCaptionTracks) aby dołączyć jedną lub więcej ścieżek napisów do ramki audio. W poniższym przykładzie plik audio jest dodawany do slajdu, a następnie nowa ścieżka napisów jest wczytywana z pliku `.vtt`.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Dodaj nową ścieżkę napisów z pliku WebVTT.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Wyodrębnianie napisów audio**

Możesz iterować po ścieżkach napisów powiązanych z ramką audio i zapisywać je jako pliki `.vtt`. Każda ścieżka napisów udostępnia swoje dane binarne oraz unikalny identyfikator, które mogą być użyte przy eksporcie napisów.

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // Zapisz każdą ścieżkę napisów jako plik .vtt.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Usuwanie napisów audio**

Aby usunąć napisy z ramki audio, użyj metod udostępnionych przez [CaptionsCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/captionscollection/), takich jak [clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/captionscollection/#remove), lub [removeAt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/captionscollection/#removeAt). Poniższy przykład usuwa wszystkie ścieżki napisów z ramki audio.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // typ: AudioFrame

    // Usuń wszystkie ścieżki napisów z ramki audio.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Wyodrębnianie dźwięku**

Aspose.Slides for PHP via Java umożliwia wyodrębnienie dźwięku używanego w przejściach pokazu slajdów. Na przykład możesz wyodrębnić dźwięk użyty w określonym slajdzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) i wczytaj prezentację zawierającą dźwięk.
2. Uzyskaj odniesienie do odpowiedniego slajdu poprzez jego indeks.
3. Uzyskaj dostęp do [slideshow transitions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/#getSlideShowTransition) dla slajdu.
4. Wyodrębnij dźwięk jako dane bajtowe.

Ten kod pokazuje, jak wyodrębnić dźwięk użyty w slajdzie:

```php
# Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Uzyskuje dostęp do żądanego slajdu
	$slide = $pres->getSlides()->get_Item(0);
	# Pobiera efekty przejścia pokazu slajdów dla slajdu
	$transition = $slide->getSlideShowTransition();
	# Wyodrębnia dźwięk jako tablicę bajtów
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**Czy mogę ponownie używać tego samego zasobu audio na wielu slajdach bez zwiększania rozmiaru pliku?**

Tak. Dodaj audio raz do wspólnej [audio collection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getaudios/) prezentacji i utwórz dodatkowe ramki audio, które odwołują się do istniejącego zasobu. Dzięki temu unikniesz duplikowania danych multimedialnych i utrzymasz rozmiar prezentacji pod kontrolą.

**Czy mogę zastąpić dźwięk w istniejącej ramce audio bez ponownego tworzenia kształtu?**

Tak. W przypadku dźwięku powiązanego, zaktualizuj [link path](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/setlinkpathlong/) tak, aby wskazywał na nowy plik. W przypadku dźwięku osadzonego, zamień obiekt [embedded audio](https://reference.aspose.com/slides/pl/php-java/aspose.slides/audioframe/setembeddedaudio/) na inny z [audio collection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getaudios/) prezentacji. Formatowanie ramki oraz większość ustawień odtwarzania pozostanie niezmieniona.

**Czy przycinanie zmienia podstawowe dane audio przechowywane w prezentacji?**

Nie. Przycinanie zmienia jedynie granice odtwarzania. Oryginalne bajty audio pozostają niezmienione i są dostępne przez osadzony dźwięk lub kolekcję audio prezentacji.