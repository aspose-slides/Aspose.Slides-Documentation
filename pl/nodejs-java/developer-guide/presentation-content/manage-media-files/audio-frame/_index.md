---
title: Zarządzanie ramkami audio w prezentacjach przy użyciu JavaScript
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
description: "Osadź audio na slajdach, zmień ikonę audio, skonfiguruj odtwarzanie, zarządzaj napisami WebVTT i wyodrębnij dźwięki przejść slajdów przy użyciu Aspose.Slides dla Node.js via Java."
---
## **Przegląd**

Ramka audio umożliwia odtworzenie dźwięku na slajdzie. Za pomocą Aspose.Slides for Node.js via Java możesz osadzić klip audio, wybrać obraz go przedstawiający, dostosować odtwarzanie oraz dołączyć napisy. Możesz także pobrać dźwięk przypisany do przejścia slajdu.

## **Tworzenie ramek audio**

Użyj [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded), aby osadzić lokalny klip audio na pierwszym slajdzie. Pierwsze dwie współrzędne określają pozycję ramki na slajdzie, a kolejne dwie wartości ustawiają jej szerokość i wysokość, wszystkie w punktach. Ten przykład wywołuje [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode), aby klip uruchamiał się automatycznie, oraz [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume), aby wybrać głośny preset.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zmiana miniatury ramki audio**

Domyślnie ramka audio wyświetla ikonę głośnika. Aby wyświetlić własną miniaturę, dodaj obraz do prezentacji przy pomocy [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) i ustaw go w ramce za pomocą [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage). W przykładzie użyto `eagle.jpeg` jako miniatury dla osadzonego klipu audio.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zmiana opcji odtwarzania audio**

Opcje **Audio** w programie PowerPoint określają, kiedy klip ma się rozpocząć, jak głośno ma być odtwarzany i jak zachowuje się podczas pokazu slajdów.

![Elementy sterujące Audio Options w programie PowerPoint dla ramki audio](audio_frame_0.png)

| Kontrolka PowerPoint | Metoda Aspose.Slides for Node.js via Java |
| --- | --- |
| Rozpoczęcie | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Ustawienie głośności | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Odtwarzanie na wielu slajdach | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Pętla aż do zatrzymania | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Ukryj podczas pokazu | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Przewiń po odtworzeniu | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Płynne włączenie | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Płynne wyłączenie | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Przytnij początek audio | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Przytnij koniec audio | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Suwak głośności | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

Przykład znajduje pierwszą ramkę audio na pierwszym slajdzie, wywołuje [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode), aby odtwarzanie rozpoczęło się po kliknięciu, oraz wybiera niski preset głośności. Klip odtwarzany jest na kolejnych slajdach, przy czym pętla jest wyłączona. Ikona pozostaje ukryta podczas pokazu, a po odtworzeniu klip jest przewijany do początku.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Dla klipu dłuższego niż 3,5 s tego przykładu pomija się pierwsze 1,5 s oraz ostatnie 2 s. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) przyjmuje czas, który ma zostać pominięty na końcu klipu. Aby uzyskać czas końcowy wyświetlany w PowerPoint, odejmij ten offset od pełnej długości klipu. Przycięty klip płynnie wchodzi w ciągu 200 ms i wychodzi w ciągu 500 ms. Wszystkie cztery metody przyjmują wartości w milisekundach.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby ustawić głośność odtwarzania na określony procent, użyj [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Ten przykład ustawia pierwszą ramkę audio na pierwszym slajdzie na 85 %.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Zarządzanie napisami audio**

Każda ramka audio zapewnia dostęp do swoich ścieżek napisów poprzez [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Użyj kolekcji, aby dołączyć napisy WebVTT do klipu, wyeksportować istniejące ścieżki lub je usunąć.

### **Dodawanie napisów audio**

Przykład osadza klip audio na pierwszym slajdzie i używa [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add), aby dołączyć lokalną ścieżkę WebVTT. Pierwszy argument podaje etykietę ścieżki, a drugi identyfikuje plik zawierający napisy z określonym czasem.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Eksportowanie napisów audio**

Ten przykład eksportuje każdą ścieżkę napisów dołączoną do ramki audio na pierwszym slajdzie. Zapisuje bajty zwrócone przez [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) do pliku WebVTT i wykorzystuje identyfikator zwrócony przez [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) jako nazwę pliku, tak aby każda ścieżka miała osobny plik wyjściowy.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **Usuwanie napisów audio**

Użyj [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) lub [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt), aby usunąć pojedynczą ścieżkę. Przykład używa [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear), aby usunąć wszystkie napisy z pierwszej ramki audio na pierwszym slajdzie, zachowując klip.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Wyszukiwanie linii w napisach audio**

Aby znaleźć linię w napisach audio na pierwszym slajdzie, przeszukaj tekst zwrócony przez [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) w pamięci. W czystym pliku WebVTT linia z czasem zawiera `-->`, linie napisów następują po niej, a pusty wiersz kończy cue. Ten przykład wypisuje etykietę ścieżki oraz każdą linię napisu zawierającą „café”.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Eksportowanie audio**

Przejście slajdu może mieć własny dźwięk. Aby go pobrać, wywołaj [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) na przejściu slajdu. Przykład uzyskuje bajty zwrócone przez [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) i wypisuje liczbę bajtów. Jeśli pierwszy slajd nie ma dźwięku przejścia, zamiast tego wypisuje komunikat.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę używać tego samego klipu audio na wielu slajdach bez jego duplikacji?**

Tak. Dodaj klip raz do [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) prezentacji i przekaż ten sam obiekt audio do [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) dla każdego slajdu.

**Czy mogę zamienić dźwięk w istniejącej ramce audio?**

Tak. W przypadku dźwięku powiązanego, użyj [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong), aby wskazać plik zamienny. W przypadku dźwięku osadzonego, wybierz inny klip z kolekcji audio prezentacji przy pomocy [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio). Oba podejścia zachowują istniejącą ramkę.

**Czy przycinanie zmienia dane audio przechowywane w prezentacji?**

Nie. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) i [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) ustalają granice odtwarzania. Pełny klip wciąż można pobrać za pomocą [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio).