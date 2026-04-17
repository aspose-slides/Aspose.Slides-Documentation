---
title: Audio in Präsentationen mit Java verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/java/audio-frame/
keywords:
- Audio
- Audio-Frame
- Miniaturansicht
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- Java
- Aspose.Slides
description: "Erstellen und steuern Sie Audio-Frames in Aspose.Slides für Java – Codebeispiele zum Einbetten, Zuschneiden, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---
## **Audio-Frames erstellen**

Aspose.Slides für Java ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in den Folien als Audio-Frames eingebettet. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Laden Sie den Audiodateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/AudioPlayModePreset) und `Volume`, die vom Objekt [IAudioFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAudioFrame) bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie einer Folie einen eingebetteten Audio‑Frame hinzufügen:

```java
// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Ruft die erste Folie ab
    ISlide sld = pres.getSlides().get_Item(0);

    // Lädt die wav-Audiodatei in einen Stream
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Fügt den Audio-Frame hinzu
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Setzt den Wiedergabemodus und die Lautstärke des Audios
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Schreibt die PowerPoint-Datei auf die Festplatte
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Audio‑Frame‑Vorschaubild ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, erscheint das Audio als Frame mit einem standardmäßigen Standardbild (siehe Bild im folgenden Abschnitt). Sie können das Vorschaubild des Audio‑Frames ändern (Ihr bevorzugtes Bild festlegen).

Dieser Java‑Code zeigt, wie Sie das Vorschaubild oder die Miniaturansicht eines Audio‑Frames ändern:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügt der Folie einen Audio-Frame mit einer angegebenen Position und Größe hinzu.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Fügt ein Bild zu den Präsentationsressourcen hinzu.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Setzt das Bild für den Audio-Frame.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Speichert die geänderte Präsentation auf der Festplatte
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Audio‑Wiedergabeoptionen ändern**

Aspose.Slides für Java ermöglicht das Anpassen von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Beispielsweise können Sie die Lautstärke eines Audios anpassen, das Audio in einer Schleife abspielen lassen oder das Audiosymbol ausblenden.

Die **Audiooptionen**‑Leiste in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audiooptionen**, die den Aspose.Slides‑Eigenschaften von [AudioFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/AudioFrame) entsprechen:

- **Start**‑Dropdown‑Liste entspricht der Methode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/audioframe/#setPlayMode-int-)
- **Volume** entspricht der Methode [AudioFrame.setVolume](https://reference.aspose.com/slides/de/java/com.aspose.slides/audioframe/#setVolume-int-)
- **Play Across Slides** entspricht der Methode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)
- **Loop until Stopped** entspricht der Methode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)
- **Hide During Show** entspricht der Methode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/de/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)
- **Rewind after Playing** entspricht der Methode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/de/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)

PowerPoint **Bearbeitungs**‑Optionen, die den Aspose.Slides‑Eigenschaften von [AudioFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/AudioFrame) entsprechen:

- **Fade In** entspricht der Methode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/de/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)
- **Fade Out** entspricht der Methode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/de/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)
- **Trim Audio Start Time** entspricht der Methode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/de/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)
- **Trim Audio End Time**‑Wert entspricht der Audiodauer minus dem Wert der Methode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/de/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)

Der PowerPoint‑**Lautstärkeregler** auf der Audiosteuerungsleiste entspricht der Methode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/de/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Er ermöglicht die Anpassung der Lautstärke des Audios als Prozentsatz.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. [Сreate](#create-audio-frame) oder holen Sie den Audio‑Frame.
2. Setzen Sie neue Werte für die Audio‑Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint‑Datei.

Dieser Java‑Code demonstriert einen Vorgang, bei dem die Optionen eines Audios angepasst werden:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Holt das AudioFrame-Shape
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Setzt den Wiedergabemodus auf Klick
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Setzt die Lautstärke auf Niedrig
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Setzt das Audio so, dass es über Folien hinweg abgespielt wird
    audioFrame.setPlayAcrossSlides(true);

    // Deaktiviert die Schleife für das Audio
    audioFrame.setPlayLoopMode(false);

    // Verbirgt das AudioFrame während der Bildschirmpräsentation
    audioFrame.setHideAtShowing(true);

    // Spult das Audio nach der Wiedergabe zum Anfang zurück
    audioFrame.setRewindAudio(true);

    // Speichert die PowerPoint-Datei auf die Festplatte
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Java‑Beispiel zeigt, wie Sie einen neuen Audio‑Frame mit eingebettetem Audio hinzufügen, ihn zuschneiden und die Einblend‑Dauern festlegen:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Setzt den Trimm-Startversatz auf 1,5 Sekunden
    // Setzt den Trimm-Endversatz auf 2 Sekunden
    // Setzt die Einblenddauer auf 200 ms
    // Setzt die Ausblenddauer auf 500 ms

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Der folgende Code‑Auszug zeigt, wie Sie einen Audio‑Frame mit eingebettetem Audio abrufen und seine Lautstärke auf 85 % setzen:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Holt ein Audio-Frame-Shape
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Setzt die Audio-Lautstärke auf 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Audio‑Untertitel verwalten**

Aspose.Slides ermöglicht das Hinzufügen von geschlossenen Untertiteln zu einem Audio‑Frame über die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Diese Methode gibt eine [ICaptionsCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/) zurück, mit der Sie WebVTT‑Untertitelspuren hinzufügen, vorhandene Spuren durchlaufen und bei Bedarf entfernen können.

**Audio‑Untertitel hinzufügen**

Verwenden Sie die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) , um einer oder mehreren Untertitelspuren zu einem Audio‑Frame hinzuzufügen. Im folgenden Beispiel wird einer Folie eine Audiodatei hinzugefügt und anschließend eine neue Untertitelspur aus einer `.vtt`‑Datei geladen.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Fügt eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Audio‑Untertitel extrahieren**

Sie können die mit einem Audio‑Frame verknüpften Untertitelspuren durchlaufen und sie als `.vtt`‑Dateien speichern. Jede Untertitelspur stellt ihre Binärdaten und ihre eindeutige Kennung bereit, die beim Exportieren der Untertitel verwendet werden können.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Speichere die Untertitelspur als .vtt-Datei.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Audio‑Untertitel entfernen**

Um Untertitel aus einem Audio‑Frame zu entfernen, verwenden Sie die Methoden der [ICaptionsCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/), z. B. [clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) oder [removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/icaptionscollection/#removeAt-int-). Das folgende Beispiel entfernt alle Untertitelspuren aus einem Audio‑Frame.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Entfernt alle Untertitelspuren vom Audio-Frame.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Audio extrahieren**

Aspose.Slides für Java ermöglicht das Extrahieren des Sounds, der in Folienübergängen verwendet wird. Beispielsweise können Sie den Sound extrahieren, der in einer bestimmten Folie verwendet wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie sich die Referenz der entsprechenden Folie über ihren Index.
3. Greifen Sie auf die [slideshow transitions](https://reference.aspose.com/slides/de/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) der Folie zu.
4. Extrahieren Sie den Sound als Byte‑Daten.

Dieser Java‑Code zeigt, wie Sie das in einer Folie verwendete Audio extrahieren:

```java
// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Greift auf die gewünschte Folie zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ermittelt die Folienübergangseffekte für die Folie
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Extrahiert den Sound als Byte-Array
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kann ich dasselbe Audio‑Asset auf mehreren Folien wiederverwenden, ohne die Dateigröße zu vergrößern?**

Ja. Fügen Sie das Audio einmal zur geteilten [audio collection](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getAudios--) der Präsentation hinzu und erstellen Sie zusätzliche Audio‑Frames, die auf dieses vorhandene Asset verweisen. Das verhindert die Duplizierung von Mediendaten und hält die Präsentationsgröße im Griff.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/de/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) so, dass er auf die neue Datei zeigt. Für einen eingebetteten Sound tauschen Sie das [embedded audio](https://reference.aspose.com/slides/de/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-)‑Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getAudios--) der Präsentation aus. Das Format des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Verändert das Zuschneiden die im Präsentations‑Datei gespeicherten Audiodaten?**

Nein. Das Zuschneiden ändert nur die Wiedergabegrenzen. Die ursprünglichen Audiodaten bleiben unverändert und über das eingebettete Audio oder die Audio‑Collection der Präsentation zugänglich.