---
title: Audio in Präsentationen mit JavaScript verwalten
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
description: "Audio-Frames in Aspose.Slides für Node.js erstellen und steuern — JavaScript‑Beispiele zum Einbetten, Trimmen, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX‑ und ODP‑Präsentationen."
---

## **Audio-Frames erstellen**

Aspose.Slides für Node.js via Java ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in den Folien als Audio-Frames eingebettet.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Laden Sie den Audio-Dateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioPlayModePreset) und `Volume`, die vom [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame) Objekt bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

```javascript
// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei repräsentiert
const pres = new aspose.slides.Presentation();
try {
    // Holt die erste Folie
    const sld = pres.getSlides().get_Item(0);
    // Lädt die wav-Audiodatei in einen Stream
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


## **Audio-Frame-Vorschaubild ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, erscheint das Audio als Frame mit einem standardmäßigen Standardbild (siehe das Bild im folgenden Abschnitt). Sie ändern das Vorschaubild des Audio-Frames (setzen Sie Ihr bevorzugtes Bild).

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Fügt der Folie einen Audio-Frame an einer angegebenen Position und Größe hinzu.
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
    // Speichert die modifizierte Präsentation auf der Festplatte
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides für Node.js via Java ermöglicht das Ändern von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Sie können beispielsweise die Lautstärke eines Audios anpassen, das Audio in einer Schleife abspielen lassen oder sogar das Audiosymbol ausblenden.

Das **Audio Options**‑Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/) Eigenschaften entsprechen:

- **Start**‑Dropdown-Liste entspricht der Methode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** entspricht der Methode [AudioFrame.setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** entspricht der Methode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** entspricht der Methode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** entspricht der Methode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** entspricht der Methode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

PowerPoint **Editing**‑Optionen, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/) Eigenschaften entsprechen:

- **Fade In** entspricht der Methode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** entspricht der Methode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** entspricht der Methode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time**‑Wert entspricht der Audiodauer minus dem Wert der Methode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

Die PowerPoint **Volume controll** im Audiosteuerfeld entspricht der Methode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Sie ermöglicht das Ändern der Lautstärke des Audios als Prozentsatz.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. [Сreate](#create-audio-frame) oder holen Sie den Audio-Frame.
2. Setzen Sie neue Werte für die Audio-Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint‑Datei.

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Holt das AudioFrame-Shape
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Setzt den Wiedergabemodus auf Klick abspielen
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Setzt die Lautstärke auf leise
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Setzt das Audio so, dass es über Folien hinweg abgespielt wird
    audioFrame.setPlayAcrossSlides(true);
    // Deaktiviert die Wiederholung für das Audio
    audioFrame.setPlayLoopMode(false);
    // Blendet das AudioFrame während der Vorführung aus
    audioFrame.setHideAtShowing(true);
    // Spult das Audio nach dem Abspielen zum Anfang zurück
    audioFrame.setRewindAudio(true);
    // Speichert die PowerPoint-Datei auf der Festplatte
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Dieser JavaScript‑Code zeigt eine Operation, bei der die Optionen eines Audios angepasst werden:
```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Setzt den Trimmstart‑Versatz auf 1,5 Sekunden
    audioFrame.setTrimFromStart(1500);
    // Setzt den Trimmen‑Endversatz auf 2 Sekunden
    audioFrame.setTrimFromEnd(2000);

    // Setzt die Einblenddauer (Fade‑In) auf 200 ms
    audioFrame.setFadeInDuration(200);
    // Setzt die Ausblenddauer (Fade‑Out) auf 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Das folgende Codebeispiel zeigt, wie Sie einen Audio‑Frame mit eingebettetem Audio abrufen und dessen Lautstärke auf 85 % setzen:
```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Ruft ein Audio-Frame-Shape ab
    const audioFrame = slide.getShapes().get_Item(0);

    // Setzt die Audio-Lautstärke auf 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **Audio extrahieren**

Aspose.Slides für Node.js via Java ermöglicht das Extrahieren des in Folienübergängen verwendeten Tons. Sie können beispielsweise den Ton einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) und laden Sie die Präsentation, die das Audio enthält.
2. Rufen Sie die Referenz der entsprechenden Folie über deren Index ab.
3. Greifen Sie auf die [slideshow transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) der Folie zu.
4. Extrahieren Sie den Ton als Byte‑Daten.

```javascript
// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei repräsentiert
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Greift auf die gewünschte Folie zu
    const slide = pres.getSlides().get_Item(0);
    // Holt die Folienübergangseffekte für die Folie
    const transition = slide.getSlideShowTransition();
    // Extrahiert den Ton als Byte-Array
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich dasselbe Audio‑Asset auf mehreren Folien wiederverwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur geteilten [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) der Präsentation hinzu und erstellen Sie weitere Audio‑Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird eine Duplizierung von Mediendaten vermieden und die Präsentationsgröße bleibt kontrollierbar.

**Kann ich den Ton in einem bestehenden Audio‑Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Ton aktualisieren Sie den [link path](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) sodass er auf die neue Datei verweist. Für einen eingebetteten Ton tauschen Sie das [embedded audio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Ändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Trimmen passt lediglich die Wiedergabegrenzen an. Die ursprünglichen Audiodaten bleiben unverändert und sind über das eingebettete Audio oder die Audio‑Collection der Präsentation zugänglich.