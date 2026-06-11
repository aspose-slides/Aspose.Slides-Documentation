---
title: Zarządzanie dźwiękiem w prezentacjach przy użyciu Javy
linktitle: Ramka audio
type: docs
weight: 10
url: /pl/java/audio-frame/
keywords:
- dźwięk
- ramka audio
- miniatura
- dodaj dźwięk
- właściwości dźwięku
- opcje dźwięku
- wyodrębnij dźwięk
- Java
- Aspose.Slides
description: "Twórz i steruj ramkami audio w Aspose.Slides dla Javy — przykłady kodu do osadzania, przycinania, pętli i konfigurowania odtwarzania w prezentacjach PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z ramkami audio w Aspose.Slides. Pokazuje, jak dodać osadzone audio do slajdów, dostosować miniaturę ramki audio, skonfigurować opcje odtwarzania, takie jak głośność, pętla, ukrywanie, przycinanie i czasy wyciszenia, oraz wyodrębnić dźwięk używany w przejściach pokazu slajdów.

## **Tworzenie ramek audio**

Aspose.Slides dla Javy umożliwia dodawanie plików audio do slajdów. Pliki audio są osadzane w slajdach jako ramki audio. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Wczytaj strumień pliku audio, który chcesz osadzić w slajdzie.
4. Dodaj osadzoną ramkę audio (zawierającą plik audio) do slajdu.
5. Ustaw [PlayMode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/AudioPlayModePreset) oraz `Volume` udostępniane przez obiekt [IAudioFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAudioFrame).
6. Zapisz zmodyfikowaną prezentację.

Ten kod w Javie pokazuje, jak dodać osadzoną ramkę audio do slajdu:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);

    // Wczytuje plik dźwiękowy wav do strumienia
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Dodaje ramkę audio
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Ustawia tryb odtwarzania i głośność dźwięku
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Zapisuje plik PowerPoint na dysku
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zmiana miniatury ramki audio**

Gdy dodasz plik audio do prezentacji, audio wyświetlane jest jako ramka ze standardowym domyślnym obrazem (zobacz obraz w sekcji poniżej). Możesz zmienić podglądowy obraz ramki audio (ustawić wybrany obraz).

Ten kod w Javie pokazuje, jak zmienić miniaturę lub podglądowy obraz ramki audio:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaje ramkę audio do slajdu z określonym położeniem i rozmiarem.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Dodaje obraz do zasobów prezentacji.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ustawia obraz dla ramki audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Saves the modified presentation to disk
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zmiana opcji odtwarzania audio**

Aspose.Slides dla Javy umożliwia zmianę opcji kontrolujących odtwarzanie lub właściwości audio. Na przykład można dostosować głośność audio, ustawić odtwarzanie w pętli lub nawet ukryć ikonę audio.

Panel **Audio Options** w Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opcje **Audio Options** w PowerPoint odpowiadające właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/AudioFrame) :

- **Start** lista rozwijana odpowiada metodzie [AudioFrame.setPlayMode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/audioframe/#setPlayMode-int-).
- **Volume** odpowiada metodzie [AudioFrame.setVolume](https://reference.aspose.com/slides/pl/java/com.aspose.slides/audioframe/#setVolume-int-).
- **Play Across Slides** odpowiada metodzie [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-).
- **Loop until Stopped** odpowiada metodzie [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-).
- **Hide During Show** odpowiada metodzie [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/pl/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-).
- **Rewind after Playing** odpowiada metodzie [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/pl/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-).

Opcje **Editing** w PowerPoint odpowiadające właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/AudioFrame) :

- **Fade In** odpowiada metodzie [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/pl/java/com.aspose.slides/audioframe/#setFadeInDuration-float-).
- **Fade Out** odpowiada metodzie [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/pl/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-).
- **Trim Audio Start Time** odpowiada metodzie [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/audioframe/#setTrimFromStart-float-).
- **Trim Audio End Time** wartość równa jest długości audio minus wartość metody [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/pl/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-).

Kontrolka **Volume** w PowerPoint na panelu sterowania audio odpowiada metodzie [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Umożliwia zmianę głośności audio w procentach.

Tak zmieniasz opcje odtwarzania audio:

1. [Utwórz](#create-audio-frame) lub pobierz ramkę audio.
2. Ustaw nowe wartości właściwości ramki audio, które chcesz zmodyfikować.
3. Zapisz zmodyfikowany plik PowerPoint.

Ten kod w Javie demonstruje operację, w której dostosowywane są opcje audio:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Pobiera kształt AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Ustawia tryb odtwarzania na odtwarzanie po kliknięciu
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Ustawia głośność na niski poziom
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Ustawia odtwarzanie audio na wszystkie slajdy
    audioFrame.setPlayAcrossSlides(true);

    // Wyłącza pętlę dla audio
    audioFrame.setPlayLoopMode(false);

    // Ukrywa AudioFrame podczas pokazu slajdów
    audioFrame.setHideAtShowing(true);

    // Przewija audio do początku po odtworzeniu
    audioFrame.setRewindAudio(true);

    // Zapisuje plik PowerPoint na dysku
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ten przykład w Javie pokazuje, jak dodać nową ramkę audio z osadzonym dźwiękiem, przyciąć go i ustawić czasy wyciszenia:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Ustawia offset przycinania początkowego na 1,5 sekundy
    // Ustawia offset przycinania końcowego na 2 sekundy
    // Ustawia czas trwania płynnego włączenia na 200 ms
    // Ustawia czas trwania płynnego wyłączenia na 500 ms

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Poniższy fragment kodu pokazuje, jak pobrać ramkę audio z osadzonym dźwiękiem i ustawić jej głośność na 85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Pobiera kształt ramki audio
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Ustawia głośność audio na 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Zarządzanie napisami audio**

Aspose.Slides umożliwia dodanie zamkniętych napisów do ramki audio za pomocą metody [getCaptionTracks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) . Metoda ta zwraca [ICaptionsCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/), co pozwala dodawać ścieżki napisów WebVTT, iterować istniejące ścieżki i usuwać je w razie potrzeby.

**Dodaj napisy audio**

Użyj metody [getCaptionTracks](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) aby dołączyć jedną lub więcej ścieżek napisów do ramki audio. W poniższym przykładzie plik audio jest dodany do slajdu, a następnie nowa ścieżka napisów jest wczytana z pliku `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Dodaj nową ścieżkę napisów z pliku WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Wyodrębnij napisy audio**

Możesz iterować po ścieżkach napisów powiązanych z ramką audio i zapisywać je jako pliki `.vtt`. Każda ścieżka napisów udostępnia swoje dane binarne oraz unikalny identyfikator, który można wykorzystać przy eksporcie napisów.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Zapisz ścieżkę napisów jako plik .vtt.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Usuń napisy audio**

Aby usunąć napisy z ramki audio, użyj metod udostępnionych przez [ICaptionsCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/), takich jak [clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), lub [removeAt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icaptionscollection/#removeAt-int-). Poniższy przykład usuwa wszystkie ścieżki napisów z ramki audio.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Usuń wszystkie ścieżki napisów z ramki audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wyodrębnianie audio**

Aspose.Slides dla Javy pozwala wyodrębnić dźwięk używany w przejściach pokazu slajdów. Na przykład można wyodrębnić dźwięk używany w konkretnym slajdzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) i wczytaj prezentację zawierającą audio.
2. Pobierz odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do [slideshow transitions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) dla slajdu.
4. Wyodrębnij dźwięk w postaci danych bajtowych.

Ten kod w Javie pokazuje, jak wyodrębnić audio użyte w slajdzie:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Uzyskuje dostęp do żądanego slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Pobiera efekty przejścia pokazu slajdów dla slajdu
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Wyodrębnia dźwięk w tablicy bajtów
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę ponownie używać tego samego zasobu audio w wielu slajdach bez zwiększania rozmiaru pliku?**

Tak. Dodaj audio raz do współdzielonej [audio collection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getAudios--) prezentacji i utwórz dodatkowe ramki audio, które odwołują się do tego istniejącego zasobu. To unika duplikowania danych multimedialnych i utrzymuje rozmiar prezentacji pod kontrolą.

**Czy mogę zastąpić dźwięk w istniejącej ramce audio bez tworzenia ponownie kształtu?**

Tak. W przypadku dźwięku powiązanego, zaktualizuj [link path](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) tak, aby wskazywał na nowy plik. W przypadku dźwięku osadzonego, zamień obiekt [embedded audio](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) na inny z [audio collection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getAudios--) prezentacji. Formatowanie ramki oraz większość ustawień odtwarzania pozostają niezmienione.

**Czy przycinanie zmienia podstawowe dane audio przechowywane w prezentacji?**

Nie. Przycinanie zmienia jedynie granice odtwarzania. Oryginalne bajty audio pozostają nienaruszone i dostępne poprzez osadzone audio lub kolekcję audio prezentacji.