---
title: Audio in Präsentationen mit JavaScript verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/nodejs-java/audio-frame/
keywords:
- Audio
- Audio-Frame
- Miniaturbild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen und Steuern von Audio-Frames in Aspose.Slides für Node.js — Beispiele zum Einbetten, Trimmen, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---
## **Audio-Frames erstellen**

Aspose.Slides für Node.js über Java ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden als Audio-Frames in die Folien eingebettet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Klasse.
2. Rufen Sie über den Index die Referenz einer Folie ab.
3. Laden Sie den Audiostream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/AudioPlayModePreset) und `Volume`, die vom [AudioFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/AudioFrame)-Objekt bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieses JavaScript‑Beispiel zeigt, wie Sie einen eingebetteten Audio‑Frame zu einer Folie hinzufügen:

```javascript
// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
const pres = new aspose.slides.Presentation();
try {
    // Ruft die erste Folie ab
    const sld = pres.getSlides().get_Item(0);
    // Lädt die WAV-Audiodatei in einen Stream
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Fügt den Audio-Frame hinzu
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Setzt den Wiedergabemodus und die Lautstärke des Audios
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Schreibt die PowerPoint-Datei auf die Festplatte
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Audio‑Frame‑Miniatur ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, wird das Audio als Frame mit einem standardmäßigen Standardbild angezeigt (siehe das Bild im Abschnitt unten). Sie können das Vorschaubild des Audio‑Frames ändern (Ihr gewünschtes Bild festlegen).

Dieses JavaScript‑Beispiel zeigt, wie Sie die Miniatur bzw. das Vorschaubild eines Audio‑Frames ändern:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Fügt der Folie einen Audio-Frame mit einer angegebenen Position und Größe hinzu.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Fügt ein Bild zu den Präsentationsressourcen hinzu.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Setzt das Bild für den Audio-Frame.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Speichert die geänderte Präsentation auf der Festplatte
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Audio‑Wiedergabeoptionen ändern**

Aspose.Slides für Node.js über Java ermöglicht das Ändern von Optionen, die die Audiowiedergabe oder -eigenschaften steuern. Beispielsweise können Sie die Lautstärke eines Audios anpassen, das Audio in einer Schleife abspielen lassen oder sogar das Audiosymbol ausblenden.

Das **Audio Options**‑Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/)‑Eigenschaften entsprechen:
- **Start**‑Dropdown‑Liste entspricht der Methode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#setPlayMode).
- **Volume** entspricht der Methode [AudioFrame.setVolume](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#setVolume).
- **Play Across Slides** entspricht der Methode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides).
- **Loop until Stopped** entspricht der Methode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode).
- **Hide During Show** entspricht der Methode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#setHideAtShowing).
- **Rewind after Playing** entspricht der Methode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#setRewindAudio).

PowerPoint **Editing**‑Optionen, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/)‑Eigenschaften entsprechen:
- **Fade In** entspricht der Methode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#setFadeInDuration).
- **Fade Out** entspricht der Methode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration).
- **Trim Audio Start Time** entspricht der Methode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#setTrimFromStart).
- **Trim Audio End Time** hat den Wert, der der Audiodauer minus dem Wert der Methode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) entspricht.

Der **Volume**‑Regler im PowerPoint‑Audiosteuerungsfeld entspricht der Methode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Er ermöglicht das Ändern der Lautstärke als Prozentsatz.

So ändern Sie die Audio‑Wiedergabeoptionen:
1. [Сreate](#create-audio-frame) oder erhalten Sie den Audio Frame.
2. Setzen Sie neue Werte für die Audio‑Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint‑Datei.

Dieses JavaScript‑Beispiel demonstriert einen Vorgang, bei dem Audio‑Optionen angepasst werden:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Ermittelt das AudioFrame-Shape
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Setzt den Wiedergabemodus auf Klick
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Setzt die Lautstärke auf Niedrig
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Setzt das Audio auf Wiedergabe über Folien hinweg
    audioFrame.setPlayAcrossSlides(true);
    // Deaktiviert die Schleife für das Audio
    audioFrame.setPlayLoopMode(false);
    // Versteckt den AudioFrame während der Präsentation
    audioFrame.setHideAtShowing(true);
    // Spult das Audio nach dem Abspielen zum Anfang zurück
    audioFrame.setRewindAudio(true);
    // Speichert die PowerPoint-Datei auf die Festplatte
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Dieses JavaScript‑Beispiel zeigt, wie man einen neuen Audio‑Frame mit eingebettetem Audio hinzufügt, ihn trimmt und die Ein‑ und Ausblendzeiten festlegt:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Setzt den Trimm-Startversatz auf 1,5 Sekunden
    audioFrame.setTrimFromStart(1500);
    // Setzt den Trimm-Endversatz auf 2 Sekunden
    audioFrame.setTrimFromEnd(2000);

    // Setzt die Einblendezeit auf 200 ms
    audioFrame.setFadeInDuration(200);
    // Setzt die Ausblendezeit auf 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Das folgende Code‑Beispiel zeigt, wie man einen Audio‑Frame mit eingebettetem Audio abruft und die Lautstärke auf 85 % setzt:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Ermittelt ein Audio-Frame-Shape
    const audioFrame = slide.getShapes().get_Item(0);

    // Setzt die Audio-Lautstärke auf 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Audio‑Untertitel verwalten**

Aspose.Slides ermöglicht das Hinzufügen von Untertiteln zu einem Audio‑Frame über die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Diese Methode gibt eine [CaptionsCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/) zurück, mit der Sie WebVTT‑Untertitelspuren hinzufügen, durch vorhandene Spuren iterieren und sie bei Bedarf entfernen können.

**Audio‑Untertitel hinzufügen**

Verwenden Sie die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/#getCaptionTracks), um einer Audiospur eine oder mehrere Untertitelspuren hinzuzufügen. Im folgenden Beispiel wird einer Folie eine Audiodatei hinzugefügt und anschließend eine neue Untertitelspur aus einer `.vtt`‑Datei geladen.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Fügt eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Audio‑Untertitel extrahieren**

Sie können die mit einem Audio‑Frame verbundenen Untertitelspuren durchlaufen und sie als `.vtt`‑Dateien speichern. Jede Untertitelspur stellt ihre Binärdaten und eine eindeutige Kennung bereit, die beim Export von Untertiteln verwendet werden kann.

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
                // Speichere die Untertitelspur als .vtt-Datei.
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

**Audio‑Untertitel entfernen**

Um Untertitel aus einem Audio‑Frame zu entfernen, verwenden Sie die von [CaptionsCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/) bereitgestellten Methoden, z. B. [clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/captionscollection/#removeAt). Das folgende Beispiel entfernt alle Untertitelspuren aus einem Audio‑Frame.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // Typ: aspose.slides.AudioFrame

    // Entferne alle Untertitelspuren vom Audio-Frame.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Audio extrahieren**

Aspose.Slides für Node.js über Java ermöglicht das Extrahieren des in Folienübergängen verwendeten Sounds. Zum Beispiel können Sie den Sound einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Klasse und laden Sie die Präsentation, die das Audio enthält.
2. Rufen Sie über den Index die Referenz der entsprechenden Folie ab.
3. Greifen Sie auf die [slideshow transitions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) der Folie zu.
4. Extrahieren Sie den Sound als Byte‑Daten.

Dieser JavaScript‑Code zeigt, wie Sie das in einer Folie verwendete Audio extrahieren:

```javascript
// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Greift auf die gewünschte Folie zu
    const slide = pres.getSlides().get_Item(0);
    // Holt die Folienübergangseffekte für die Folie
    const transition = slide.getSlideShowTransition();
    // Extrahiert den Sound als Byte-Array
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kann ich dieselbe Audiodatei in mehreren Folien wiederverwenden, ohne die Dateigröße zu vergrößern?**

Ja. Fügen Sie das Audio einmal zur gemeinsamen [audio collection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getaudios/) der Präsentation hinzu und erstellen Sie weitere Audio‑Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird das Duplizieren von Mediendaten vermieden und die Präsentationsgröße bleibt kontrollierbar.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/setlinkpathlong/), um auf die neue Datei zu zeigen. Für einen eingebetteten Sound tauschen Sie das [embedded audio](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/setembeddedaudio/)‑Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getaudios/) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Ändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Trimmen ändert nur die Wiedergabegrenzen. Die ursprünglichen Audiodaten bleiben unverändert und sind über das eingebettete Audio oder die Audio‑Collection der Präsentation zugänglich.