---
title: Zarządzanie dźwiękiem w prezentacjach na Androidzie
linktitle: Klatka audio
type: docs
weight: 10
url: /pl/androidjava/audio-frame/
keywords:
- dźwięk
- klatka audio
- miniatura
- dodaj dźwięk
- właściwości dźwięku
- opcje dźwięku
- wyodrębnij dźwięk
- Android
- Java
- Aspose.Slides
description: "Twórz i kontroluj klatki audio w Aspose.Slides dla Androida — przykłady w Javie dotyczące osadzania, przycinania, pętli i konfigurowania odtwarzania w prezentacjach PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z klatkami audio w Aspose.Slides. Pokazuje, jak dodać osadzony dźwięk do slajdów, dostosować miniaturę klatki audio, skonfigurować opcje odtwarzania takie jak głośność, pętla, ukrywanie, przycinanie i czasy zanikania oraz wyodrębnić dźwięk używany w przejściach pokazu slajdów.

## **Tworzenie klatek audio**
Aspose.Slides for Android via Java umożliwia dodawanie plików audio do slajdów. Pliki audio są osadzane w slajdach jako klatki audio.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Wczytaj strumień pliku audio, który chcesz osadzić w slajdzie.
4. Dodaj osadzoną klatkę audio (zawierającą plik audio) do slajdu.
5. Ustaw [PlayMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/AudioPlayModePreset) oraz `Volume` udostępnione przez obiekt [IAudioFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IAudioFrame).
6. Zapisz zmodyfikowaną prezentację.

Ten kod Java pokazuje, jak dodać osadzoną klatkę audio do slajdu:

```java
// Instancjonuje klasę Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);

    // Ładuje plik dźwiękowy wav do strumienia
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Dodaje klatkę audio
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

## **Zmiana miniatury klatki audio**

Po dodaniu pliku audio do prezentacji audio wyświetlane jest jako klatka ze standardowym domyślnym obrazem (zobacz obraz w poniższej sekcji). Możesz zmienić podgląd klatki audio (ustawić własny obraz).

Ten kod Java pokazuje, jak zmienić miniaturę lub obraz podglądu klatki audio:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaje klatkę audio do slajdu z określonym położeniem i rozmiarem.
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

    // Ustawia obraz dla klatki audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Zapisuje zmodyfikowaną prezentację na dysk
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zmiana opcji odtwarzania audio**

Aspose.Slides for Android via Java umożliwia zmianę opcji kontrolujących odtwarzanie lub właściwości audio. Na przykład możesz dostosować głośność, ustawić odtwarzanie w pętli lub nawet ukryć ikonę audio.

Panel **Opcje audio** w Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opcje **Audio** w PowerPoint odpowiadają właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/AudioFrame):

- **Start** – lista rozwijana odpowiada właściwości [AudioFrame.PlayMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** – odpowiada właściwości [AudioFrame.Volume](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** – odpowiada właściwości [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** – odpowiada właściwości [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** – odpowiada właściwości [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** – odpowiada właściwości [AudioFrame.RewindAudio](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

Opcje **Edycja** w PowerPoint odpowiadają właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/audioframe/):

- **Fade In** – odpowiada właściwości [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** – odpowiada właściwości [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** – odpowiada właściwości [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trim Audio End Time** – wartość równa jest czasie trwania audio pomniejszonemu o wartość [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

Suwak **Volume** w panelu kontrolnym audio w PowerPoint odpowiada właściwości [AudioFrame.VolumeValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/audioframe/#getVolumeValue--). Umożliwia zmianę głośności audio w procentach.

Tak zmieniasz opcje odtwarzania audio:

1. **Utwórz** ([Create](#create-audio-frame)) lub pobierz klatkę audio.  
2. Ustaw nowe wartości właściwości klatki audio, które chcesz zmienić.  
3. Zapisz zmodyfikowany plik PowerPoint.

Ten kod Java demonstruje operację, w której zmieniane są opcje audio:

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

    // Cofa audio do początku po odtworzeniu
    audioFrame.setRewindAudio(true);

    // Zapisuje plik PowerPoint na dysku
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ten przykład Java pokazuje, jak dodać nową klatkę audio z osadzonym dźwiękiem, przyciąć go i ustawić czasy zanikania:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Ustawia początkowy offset przycinania na 1,5 sekundy
    audioFrame.setTrimFromStart(1500f);
    // Ustawia końcowy offset przycinania na 2 sekundy
    audioFrame.setTrimFromEnd(2000f);

    // Ustawia czas trwania płynnego włączenia na 200 ms
    audioFrame.setFadeInDuration(200f);
    // Ustawia czas trwania płynnego wyłączenia na 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Poniższy fragment kodu pokazuje, jak pobrać klatkę audio z osadzonym dźwiękiem i ustawić jej głośność na 85 %:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Pobiera kształt klatki audio
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

Aspose.Slides umożliwia dodawanie zamkniętych napisów do klatki audio za pomocą metody [getCaptionTracks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Metoda ta zwraca [ICaptionsCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/), co pozwala na dodawanie ścieżek napisów WebVTT, iterowanie po istniejących ścieżkach oraz ich usuwanie w razie potrzeby.

### Dodawanie napisów audio

Użyj metody [getCaptionTracks](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) aby dołączyć jedną lub więcej ścieżek napisów do klatki audio. W poniższym przykładzie plik audio jest dodawany do slajdu, a następnie nowa ścieżka napisów jest wczytywana z pliku `.vtt`.

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

### Wyodrębnianie napisów audio

Możesz iterować po ścieżkach napisów powiązanych z klatką audio i zapisywać je jako pliki `.vtt`. Każda ścieżka udostępnia swoje dane binarne oraz unikalny identyfikator, który może być użyty przy eksportowaniu napisów.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Zapisz ścieżkę napisów jako plik .vtt.
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

### Usuwanie napisów audio

Aby usunąć napisy z klatki audio, użyj metod udostępnionych przez [ICaptionsCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/), takich jak [clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) lub [removeAt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). Poniższy przykład usuwa wszystkie ścieżki napisów z klatki audio.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Usuń wszystkie ścieżki napisów z klatki audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wyodrębnianie audio**

Aspose.Slides for Android via Java umożliwia wyodrębnienie dźwięku używanego w przejściach pokazu slajdów. Na przykład możesz wyodrębnić dźwięk używany w określonym slajdzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) i wczytaj prezentację zawierającą audio.  
2. Uzyskaj odniesienie do odpowiedniego slajdu za pomocą jego indeksu.  
3. Uzyskaj dostęp do [slideshow transitions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) dla tego slajdu.  
4. Wyodrębnij dźwięk jako tablicę bajtów.

Ten kod w Javie pokazuje, jak wyodrębnić audio używane w slajdzie:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Uzyskuje dostęp do wybranego slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Pobiera efekty przejścia pokazu slajdów dla slajdu
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Wyodrębnia dźwięk do tablicy bajtów
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę używać tego samego pliku audio w wielu slajdach bez zwiększania rozmiaru pliku?**

Tak. Dodaj audio raz do współdzielonej [audio collection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getAudios--) prezentacji i utwórz dodatkowe klatki audio odwołujące się do istniejącego zasobu. Zapobiega to duplikacji danych multimedialnych i utrzymuje rozmiar prezentacji pod kontrolą.

**Czy mogę wymienić dźwięk w istniejącej klatce audio bez ponownego tworzenia kształtu?**

Tak. W przypadku dźwięku linkowanego zaktualizuj [link path](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) tak, aby wskazywał na nowy plik. W przypadku dźwięku osadzonego wymień obiekt [embedded audio](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) na inny z [audio collection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getAudios--) prezentacji. Formatowanie klatki i większość ustawień odtwarzania pozostają niezmienione.

**Czy przycinanie zmienia podstawowe dane audio zapisane w prezentacji?**

Nie. Przycinanie modyfikuje jedynie granice odtwarzania. Oryginalne bajty audio pozostają nietknięte i są dostępne poprzez osadzony dźwięk lub kolekcję audio prezentacji.