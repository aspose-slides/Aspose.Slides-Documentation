---
title: Audio-Frames in Präsentationen mit JavaScript verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/nodejs-java/audio-frame/
keywords:
- Audio
- Audio-Frame
- Vorschaubild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- Node.js
- JavaScript
- Aspose.Slides
description: "Audio in Folien einbetten, das Audiosymbol ändern, die Wiedergabe konfigurieren, WebVTT-Untertitel verwalten und Folienübergangstöne mit Aspose.Slides for Node.js via Java extrahieren."
---
## **Übersicht**

Ein Audio‑Frame ermöglicht das Abspielen eines Sounds auf einer Folie. Mit Aspose.Slides for Node.js via Java können Sie einen Audioclip einbetten, das Bild auswählen, das ihn darstellt, die Wiedergabe anpassen und Untertitel anhängen. Sie können auch einen einem Folienübergang zugewiesenen Sound abrufen.

## **Audio‑Frames erstellen**

Verwenden Sie [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) um einen lokalen Audioclip in die erste Folie einzubetten. Die ersten beiden Koordinaten positionieren den Frame auf der Folie, und die nächsten beiden Werte setzen seine Breite und Höhe, alles in Punkten. Dieses Beispiel ruft [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) auf, um den Clip automatisch zu starten, und ruft [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) auf, um die laute Voreinstellung auszuwählen.

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

## **Audio‑Frame‑Vorschaubild ändern**

Standardmäßig zeigt ein Audio‑Frame ein Lautsprechersymbol an. Um ein benutzerdefiniertes Vorschaubild anzuzeigen, fügen Sie ein Bild zur Präsentation mit [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) hinzu und setzen es auf das Bild des Frames mit [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage). Das Beispiel verwendet `eagle.jpeg` als Vorschaubild für einen eingebetteten Audioclip.

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

## **Audio‑Wiedergabeoptionen ändern**

PowerPoint‑**Audio‑Optionen**‑Steuerelemente bestimmen, wann ein Clip startet, wie laut er klingt und wie er sich während einer Bildschirmanzeige verhält.

![PowerPoint-Audio-Optionen-Steuerelemente für einen Audio‑Frame](audio_frame_0.png)

| PowerPoint‑Steuerelement | Aspose.Slides for Node.js via Java‑Methode |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Lautstärke‑Voreinstellung | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Über Folien hinweg abspielen | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Schleife bis gestoppt | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Während der Anzeige ausblenden | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Nach Wiedergabe zurückspulen | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Einblenden | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Ausblenden | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Audio‑Startzeit zuschneiden | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Audio‑Endzeit zuschneiden | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Lautstärkeregler | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

Das Beispiel findet den ersten Audio‑Frame auf der ersten Folie, ruft [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) auf, um die Wiedergabe bei einem Klick zu starten, und wählt die niedrige Lautstärke‑Voreinstellung. Der Clip läuft über Folien hinweg, wobei die Schleife deaktiviert ist. Das Symbol bleibt während der Anzeige ausgeblendet, und der Clip wird nach der Wiedergabe zurückgespult.

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

Für einen Clip, der länger als 3,5 Sekunden ist, überspringt dieses Beispiel die ersten 1,5 Sekunden und die letzten 2 Sekunden. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) nimmt die Dauer, die am Ende des Clips weggelassen werden soll. Um die Endzeit zu erhalten, die in PowerPoint angezeigt wird, subtrahieren Sie diesen Versatz von der Gesamtdauer des Clips. Der zugeschnittene Clip blendet über 200 Millisekunden ein und über 500 Millisekunden aus. Alle vier Methoden erwarten Werte in Millisekunden.

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

Um die Wiedergabelautstärke auf einen bestimmten Prozentsatz einzustellen, verwenden Sie [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Dieses Beispiel setzt den ersten Audio‑Frame auf der ersten Folie auf 85 %.

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

## **Audio‑Untertitel verwalten**

Jeder Audio‑Frame bietet Zugriff auf seine Untertitelspuren über [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Verwenden Sie die Sammlung, um WebVTT‑Untertitel an den Clip anzuhängen, vorhandene Spuren zu exportieren oder sie zu entfernen.

### **Audio‑Untertitel hinzufügen**

Das Beispiel bettet einen Audio‑Clip auf der ersten Folie ein und verwendet [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) um eine lokale WebVTT‑Spur anzuhängen. Das erste Argument liefert das Spuren‑Label, das zweite identifiziert die Datei, die die zeitlichen Untertitel enthält.

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

### **Audio‑Untertitel extrahieren**

Dieses Beispiel exportiert jede an einen Audio‑Frame auf der ersten Folie angehängte Untertitelspur. Es schreibt die von [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) zurückgegebenen Bytes in eine WebVTT‑Datei und verwendet den von [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) zurückgegebenen Bezeichner als Dateinamen, sodass jede Spur eine separate Ausgabe hat.

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

### **Audio‑Untertitel entfernen**

Verwenden Sie [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) um eine einzelne Spur zu löschen. Das Beispiel verwendet [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) um alle Untertitel vom ersten Audio‑Frame auf der ersten Folie zu entfernen, wobei der Clip erhalten bleibt.

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

### **Eine Zeile in Audio‑Untertiteln finden**

Um eine Zeile in den Audio‑Untertiteln auf der ersten Folie zu finden, durchsuchen Sie den Text, den [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) im Speicher zurückgibt. In einem reinen Text‑WebVTT‑Cue enthält die Timing‑Zeile `-->`, die Untertitelzeilen folgen ihr, und eine leere Zeile beendet den Cue. Dieses Beispiel gibt das Spuren‑Label und jede Untertitelzeile aus, die “café” enthält.

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

## **Audio extrahieren**

Ein Folienübergang kann einen eigenen Sound haben. Um ihn abzurufen, rufen Sie [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) auf dem Folienübergang auf. Das Beispiel greift auf die von [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) zurückgegebenen Bytes zu und gibt die Anzahl der Bytes aus. Wenn die erste Folie keinen Übergangssound hat, wird stattdessen eine Meldung ausgegeben.

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

**Kann ich denselben Audioclip auf mehreren Folien wiederverwenden, ohne ihn zu duplizieren?**

Ja. Fügen Sie den Clip einmal zur [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) der Präsentation hinzu und übergeben Sie dasselbe Audio‑Objekt an [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) für jede Folie.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen?**

Ja. Für einen verknüpften Sound verwenden Sie [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) um auf die Ersatzdatei zu verweisen. Für einen eingebetteten Sound wählen Sie einen anderen Clip aus der Audio‑Sammlung der Präsentation mit [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio). Beide Ansätze behalten den bestehenden Frame bei.

**Ändert das Trimmen die in der Präsentation gespeicherten Audiodaten?**

Nein. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) und [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) setzen Wiedergabebereiche. Sie können den vollständigen Clip weiterhin über [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio) abrufen.