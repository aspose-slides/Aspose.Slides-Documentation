---
title: Zarządzanie ramkami audio w prezentacjach przy użyciu Java
linktitle: Rama audio
type: docs
weight: 10
url: /pl/java/audio-frame/
keywords:
- dźwięk
- ramka audio
- miniatura
- dodaj audio
- właściwości audio
- opcje audio
- wyodrębnij audio
- Java
- Aspose.Slides
description: "Osadź dźwięk na slajdach, zmień ikonę audio, skonfiguruj odtwarzanie, zarządzaj napisami WebVTT i wyodrębnij dźwięki przejść slajdów przy użyciu Aspose.Slides dla Java."
---
## **Przegląd**

Rama audio pozwala odtwarzać dźwięk na slajdzie. Dzięki Aspose.Slides for Java możesz osadzić klip audio, wybrać obraz go reprezentujący, dostosować odtwarzanie i dodać napisy. Możesz także pobrać dźwięk przypisany do przejścia slajdu.

## **Tworzenie ramek audio**

Użyj [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) aby osadzić lokalny klip audio na pierwszym slajdzie. Pierwsze dwie współrzędne określają pozycję ramki na slajdzie, a kolejne dwie wartości ustawiają jej szerokość i wysokość, wszystkie w punktach. Ten przykład wywołuje [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) aby rozpocząć klip automatycznie i wywołuje [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) aby wybrać głośny preset.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zmiana miniaturki ramki audio**

Domyślnie rama audio wyświetla ikonę głośnika. Aby wyświetlić własną miniaturkę, dodaj obraz do prezentacji za pomocą [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) i ustaw go w ramce przy pomocy [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). Przykład używa pliku JPEG jako miniaturki osadzonego klipu audio.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zmiana opcji odtwarzania audio**

Kontrole **Audio Options** w programie PowerPoint określają, kiedy klip się rozpoczyna, jak głośny jest i jak zachowuje się podczas pokazu slajdów.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Kontrola PowerPoint | Metoda Aspose.Slides for Java |
| --- | --- |
| Rozpocznij | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Ustawienie głośności | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Odtwarzaj na wszystkich slajdach | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Pętla do zatrzymania | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Ukryj podczas pokazu | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Przewiń po odtworzeniu | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Płynne wejście | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Płynne wyjście | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Przytnij początek audio | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Przytnij koniec audio | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Suwak głośności | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

Przykład znajduje pierwszą ramkę audio na pierwszym slajdzie, wywołuje [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) aby rozpocząć odtwarzanie po kliknięciu i wybiera niski preset głośności. Klip odtwarzany jest na kolejnych slajdach przy wyłączonej pętli. Ikona pozostaje ukryta podczas pokazu, a klip przewija się po zakończeniu odtwarzania.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Dla klipu dłuższego niż 3,5 s przykład pomija pierwsze 1,5 s i ostatnie 2 s. [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) przyjmuje czas, który ma zostać odcięty od końca klipu. Aby uzyskać czas końcowy wyświetlany w PowerPoint, odejmij tę wartość od całkowitej długości klipu. Przycięty klip płynnie wchodzi w ciągu 200 ms i płynnie wychodzi w ciągu 500 ms. Wszystkie cztery metody przyjmują wartości w milisekundach.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby ustawić głośność odtwarzania na określony procent, użyj [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Przykład ustawia pierwszą ramkę audio na pierwszym slajdzie na 85 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Zarządzanie napisami audio**

Każda rama audio zapewnia dostęp do swoich ścieżek napisów poprzez [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Użyj kolekcji, aby dołączyć napisy WebVTT do klipu, wyeksportować istniejące ścieżki lub je usunąć.

### **Dodawanie napisów audio**

Przykład osadza klip audio na pierwszym slajdzie i używa [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) aby dołączyć lokalną ścieżkę WebVTT. Pierwszy argument podaje etykietę ścieżki, a drugi identyfikuje plik zawierający napisy czasowe.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ekstrahowanie napisów audio**

Ten przykład wyeksportowuje każdą ścieżkę napisów dołączoną do ramki audio na pierwszym slajdzie. Zapisuje bajty zwrócone przez [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) do pliku WebVTT i używa identyfikatora zwróconego przez [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) jako nazwy pliku, tak aby każda ścieżka miała osobny wynik.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            Path output = Paths.get(track.getCaptionId() + ".vtt");
            Files.write(output, track.getBinaryData());
        }
    }
} finally {
    presentation.dispose();
}
```

### **Usuwanie napisów audio**

Użyj [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) lub [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) aby usunąć pojedynczą ścieżkę. Przykład wykorzystuje [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) aby usunąć wszystkie napisy z pierwszej ramki audio na pierwszym slajdzie, zachowując klip.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Znajdowanie linii w napisach audio**

Aby znaleźć linię w napisach audio na pierwszym slajdzie, przeszukaj tekst zwrócony przez [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) w pamięci. W czystym tekście WebVTT linia z czasem zawiera `-->`, linie napisów następują po niej, a pusta linia kończy segment. Ten przykład wypisuje etykietę ścieżki i każdą linię napisu zawierającą słowo „café”.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\R")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ekstrahowanie audio**

Przejście slajdu może mieć własny dźwięk. Aby go pobrać, wywołaj [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) na przejściu slajdu. Przykład odczytuje bajty zwrócone przez [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) i wypisuje ich liczbę. Jeśli pierwszy slajd nie ma dźwięku przejścia, wypisuje odpowiedni komunikat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę ponownie użyć tego samego klipu audio na wielu slajdach bez jego duplikowania?**

Tak. Dodaj klip raz do [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) prezentacji i przekaż ten sam obiekt audio do [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) dla każdego slajdu.

**Czy mogę zamienić dźwięk w istniejącej ramce audio?**

Tak. W przypadku dźwięku powiązanego, użyj [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) aby wskazać plik zastępczy. W przypadku dźwięku osadzonego, wybierz inny klip z kolekcji audio prezentacji za pomocą [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Oba podejścia zachowują istniejącą ramkę.

**Czy przycinanie zmienia dane audio przechowywane w prezentacji?**

Nie. [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) i [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) ustalają granice odtwarzania. Pełny klip wciąż można pobrać za pomocą [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).