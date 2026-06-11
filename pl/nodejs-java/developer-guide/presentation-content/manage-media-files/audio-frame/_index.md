---
title: Zarządzanie audio w prezentacjach przy użyciu JavaScript
linktitle: Ramka audio
type: docs
weight: 10
url: /pl/nodejs-java/audio-frame/
keywords:
- audio
- ramka audio
- miniatura
- dodaj audio
- właściwości audio
- opcje audio
- wyodrębnij audio
- Node.js
- JavaScript
- Aspose.Slides
description: "Tworzenie i kontrolowanie ramek audio w Aspose.Slides dla Node.js — przykłady osadzania, przycinania, pętlowania i konfigurowania odtwarzania w prezentacjach PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z ramkami audio w Aspose.Slides. Pokazuje, jak dodać osadzony dźwięk do slajdów, dostosować miniaturę ramki audio, skonfigurować opcje odtwarzania, takie jak głośność, pętlowanie, ukrywanie, przycinanie i czasy zanikania, oraz wyodrębnić dźwięk używany w przejściach pokazu slajdów.

## **Utworzenie ramek audio**

Aspose.Slides dla Node.js poprzez Java umożliwia dodawanie plików audio do slajdów. Pliki audio są osadzane w slajdach jako ramki audio.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Wczytaj strumień pliku audio, który chcesz osadzić w slajdzie.
4. Dodaj osadzoną ramkę audio (zawierającą plik audio) do slajdu.
5. Ustaw [PlayMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AudioPlayModePreset) i `Volume` udostępniane przez obiekt [AudioFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AudioFrame).
6. Zapisz zmodyfikowaną prezentację.

Ten kod JavaScript pokazuje, jak dodać osadzoną ramkę audio do slajdu:

```javascript
// Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji
const pres = new aspose.slides.Presentation();
try {
    // Pobiera pierwszy slajd
    const sld = pres.getSlides().get_Item(0);
    // Wczytuje plik dźwiękowy wav do strumienia
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Dodaje ramkę audio
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Ustawia tryb odtwarzania i głośność audio
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Zapisuje plik PowerPoint na dysku
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zmiana miniatury ramki audio**

Po dodaniu pliku audio do prezentacji, dźwięk wyświetlany jest jako ramka ze standardowym domyślnym obrazem (zobacz obraz w sekcji poniżej). Możesz zmienić podglądowy obraz ramki audio (ustawić wybrany obraz).

Ten kod JavaScript pokazuje, jak zmienić miniaturę lub obraz podglądu ramki audio:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Dodaje ramkę audio do slajdu z określonym położeniem i rozmiarem.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Dodaje obraz do zasobów prezentacji.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ustawia obraz dla ramki audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Zapisuje zmodyfikowaną prezentację na dysku
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Zmiana opcji odtwarzania audio**

Aspose.Slides dla Node.js poprzez Java umożliwia zmianę opcji kontrolujących odtwarzanie lub właściwości dźwięku. Na przykład możesz dostosować głośność audio, ustawić odtwarzanie w pętli lub nawet ukryć ikonę audio.

Panel **Audio Options** w Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Opcje **Audio** w PowerPoint odpowiadają właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/) :

- **Start** lista rozwijana odpowiada metodzie [AudioFrame.setPlayMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** odpowiada metodzie [AudioFrame.setVolume](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** odpowiada metodzie [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** odpowiada metodzie [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** odpowiada metodzie [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** odpowiada metodzie [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

Opcje **Editing** w PowerPoint odpowiadają właściwościom Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/) :

- **Fade In** odpowiada metodzie [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** odpowiada metodzie [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** odpowiada metodzie [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** wartość równa jest czasie trwania audio minus wartość z metody [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

Suwak **Volume control** w panelu sterowania dźwiękiem w PowerPoint odpowiada metodzie [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Umożliwia zmianę głośności audio w procentach.

Tak zmienisz opcje odtwarzania audio:

1. [Utwórz](#create-audio-frame) lub pobierz ramkę audio.
2. Ustaw nowe wartości właściwości ramki audio, które chcesz zmodyfikować.
3. Zapisz zmodyfikowany plik PowerPoint.

Ten kod JavaScript demonstruje operację, w której zmieniane są opcje audio:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Pobiera kształt AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Ustawia tryb odtwarzania na odtwarzanie po kliknięciu
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Ustawia głośność na niski poziom
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Ustawia odtwarzanie audio na wszystkie slajdy
    audioFrame.setPlayAcrossSlides(true);
    // Wyłącza pętlę dla audio
    audioFrame.setPlayLoopMode(false);
    // Ukrywa AudioFrame podczas pokazu slajdów
    audioFrame.setHideAtShowing(true);
    // Przewija audio do początku po odtworzeniu
    audioFrame.setRewindAudio(true);
    // Zapisuje plik PowerPoint na dysku
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ten przykład JavaScript pokazuje, jak dodać nową ramkę audio z osadzonym dźwiękiem, przyciąć go i ustawić czasy zanikania:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Ustawia początkowy offset przycinania na 1,5 sekundy
    audioFrame.setTrimFromStart(1500);
    // Ustawia końcowy offset przycinania na 2 sekundy
    audioFrame.setTrimFromEnd(2000);

    // Ustawia czas trwania płynnego włączenia na 200 ms
    audioFrame.setFadeInDuration(200);
    // Ustawia czas trwania płynnego wyciszenia na 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Poniższy przykład kodu pokazuje, jak pobrać ramkę audio z osadzonym dźwiękiem i ustawić jej głośność na 85%:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Pobiera kształt ramki audio
    const audioFrame = slide.getShapes().get_Item(0);

    // Ustawia głośność audio na 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Zarządzanie napisami audio**

Aspose.Slides umożliwia dodawanie zamkniętych napisów do ramki audio za pomocą metody [getCaptionTracks](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Metoda ta zwraca [CaptionsCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/), co pozwala dodać ścieżki napisów WebVTT, iterować po istniejących ścieżkach oraz usuwać je w razie potrzeby.

### **Dodawanie napisów audio**

Użyj metody [getCaptionTracks](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/#getCaptionTracks), aby dołączyć jedną lub więcej ścieżek napisów do ramki audio. W poniższym przykładzie plik audio jest dodawany do slajdu, a następnie nowa ścieżka napisów jest wczytywana z pliku `.vtt`.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Dodaj nową ścieżkę napisów z pliku WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Wyodrębnianie napisów audio**

Możesz iterować po ścieżkach napisów powiązanych z ramką audio i zapisywać je jako pliki `.vtt`. Każda ścieżka napisów udostępnia swoje dane binarne oraz unikalny identyfikator, który może być użyty przy eksportowaniu napisów.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // Zapisz ścieżkę napisów jako plik .vtt.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **Usuwanie napisów audio**

Aby usunąć napisy z ramki audio, użyj metod udostępnionych przez [CaptionsCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/), takich jak [clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/#remove), lub [removeAt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/#removeAt). Poniższy przykład usuwa wszystkie ścieżki napisów z ramki audio.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // typ: aspose.slides.AudioFrame

    // Usuń wszystkie ścieżki napisów z ramki audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wyodrębnianie audio**

Aspose.Slides dla Node.js poprzez Java umożliwia wyodrębnienie dźwięku używanego w przejściach pokazu slajdów. Na przykład możesz wyodrębnić dźwięk użyty w konkretnym slajdzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) i wczytaj prezentację zawierającą audio.
2. Pobierz odniesienie do odpowiedniego slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do [slideshow transitions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) dla slajdu.
4. Wyodrębnij dźwięk jako dane bajtowe.

Ten kod w JavaScript pokazuje, jak wyodrębnić dźwięk użyty w slajdzie:

```javascript
// Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Uzyskuje dostęp do żądanego slajdu
    const slide = pres.getSlides().get_Item(0);
    // Pobiera efekty przejścia pokazu slajdów dla slajdu
    const transition = slide.getSlideShowTransition();
    // Wyodrębnia dźwięk do tablicy bajtów
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę ponownie używać tego samego zasobu audio na wielu slajdach bez zwiększania rozmiaru pliku?**

Tak. Dodaj dźwięk raz do udostępnionej [audio collection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getaudios/) prezentacji i utwórz dodatkowe ramki audio, które odwołują się do tego istniejącego zasobu. Dzięki temu unikniesz duplikacji danych multimedialnych i zachowasz kontrolę nad rozmiarem prezentacji.

**Czy mogę zamienić dźwięk w istniejącej ramce audio bez ponownego tworzenia kształtu?**

Tak. W przypadku dźwięku powiązanego, zaktualizuj [link path](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) , aby wskazywał na nowy plik. W przypadku dźwięku osadzonego, wymień obiekt [embedded audio](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) na inny z [audio collection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getaudios/) prezentacji. Formatowanie ramki oraz większość ustawień odtwarzania pozostają niezmienione.

**Czy przycinanie zmienia bazowe dane audio przechowywane w prezentacji?**

Nie. Przycinanie zmienia jedynie granice odtwarzania. Oryginalne bajty audio pozostają niezmienione i dostępne poprzez osadzony dźwięk lub kolekcję audio prezentacji.