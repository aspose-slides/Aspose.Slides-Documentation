---
title: Audio in Präsentationen auf Android verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/androidjava/audio-frame/
keywords:
- Audio
- Audio-Frame
- Vorschaubild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- Android
- Java
- Aspose.Slides
description: "Erstellen und steuern Sie Audio-Frames in Aspose.Slides für Android-Java-Beispiele zum Einbetten, Trimmen, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---
## **Audio‑Frames erstellen**
Aspose.Slides für Android via Java ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in den Folien als Audio‑Frames eingebettet.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
2. Holen Sie sich den Bezug zu einer Folie über deren Index.
3. Laden Sie den Audiostream der Datei, die Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio‑Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/AudioPlayModePreset) und `Volume`, die vom Objekt [IAudioFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IAudioFrame) bereitgestellt werden.
6. Speichern Sie die modifizierte Präsentation.

Dieser Java‑Code zeigt, wie ein eingebetteter Audio‑Frame zu einer Folie hinzugefügt wird:

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
Wenn Sie einer Präsentation eine Audiodatei hinzufügen, erscheint das Audio als Frame mit einem standardmäßigen Standardbild (siehe das Bild im Abschnitt unten). Sie können das Vorschaubild des Audio‑Frames ändern (Ihr gewünschtes Bild festlegen).

Dieser Java‑Code zeigt, wie das Thumbnail bzw. Vorschaubild eines Audio‑Frames geändert wird:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügt der Folie einen Audio-Frame mit angegebener Position und Größe hinzu.
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

    //Speichert die modifizierte Präsentation auf der Festplatte
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Audio‑Wiedergabeoptionen ändern**
Aspose.Slides für Android via Java ermöglicht das Ändern von Optionen, die die Audiowiedergabe oder deren Eigenschaften steuern. Beispielsweise können Sie die Lautstärke anpassen, das Audio in einer Schleife abspielen oder das Audiosymbol ausblenden.

Das **Audio‑Options**‑Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio‑Options**, die den Aspose.Slides‑[AudioFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/AudioFrame)-Eigenschaften entsprechen:

- **Start** Dropdown‑Liste entspricht der Eigenschaft [AudioFrame.PlayMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Volume** entspricht der Eigenschaft [AudioFrame.Volume](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Play Across Slides** entspricht der Eigenschaft [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Loop until Stopped** entspricht der Eigenschaft [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Hide During Show** entspricht der Eigenschaft [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Rewind after Playing** entspricht der Eigenschaft [AudioFrame.RewindAudio](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

PowerPoint **Editing**‑Optionen, die den Aspose.Slides‑[AudioFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/audioframe/)-Eigenschaften entsprechen:

- **Fade In** entspricht der Eigenschaft [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Fade Out** entspricht der Eigenschaft [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Trim Audio Start Time** entspricht der Eigenschaft [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Trim Audio End Time** entspricht dem Wert *Audio‑Dauer minus* dem Wert der Eigenschaft [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

Der PowerPoint **Volume‑Regler** im Audio‑Steuerfeld entspricht der Eigenschaft [AudioFrame.VolumeValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/audioframe/#getVolumeValue--). Er ermöglicht das Ändern der Lautstärke als Prozentsatz.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. [Erstellen](#create-audio-frame) oder holen Sie den Audio‑Frame.
2. Setzen Sie neue Werte für die Audio‑Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die modifizierte PowerPoint‑Datei.

Dieser Java‑Code demonstriert eine Operation, bei der die Optionen eines Audios angepasst werden:

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

    // Versteckt das AudioFrame während der Bildschirmpräsentation
    audioFrame.setHideAtShowing(true);

    // Spult das Audio nach dem Abspielen zum Anfang zurück
    audioFrame.setRewindAudio(true);

    // Speichert die PowerPoint-Datei auf die Festplatte
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Java‑Beispiel zeigt, wie ein neuer Audio‑Frame mit eingebettetem Audio hinzugefügt, zugeschnitten und die Fade‑Dauern gesetzt werden:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Setzt den Trimm-Startversatz auf 1,5 Sekunden
    audioFrame.setTrimFromStart(1500f);
    // Setzt den Trimm-Endversatz auf 2 Sekunden
    audioFrame.setTrimFromEnd(2000f);

    // Setzt die Einblenddauer auf 200 ms
    audioFrame.setFadeInDuration(200f);
    // Setzt die Ausblenddauer auf 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Der folgende Codeausschnitt zeigt, wie ein Audio‑Frame mit eingebettetem Audio abgerufen und die Lautstärke auf 85 % gesetzt wird:

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
Aspose.Slides ermöglicht das Hinzufügen von Untertiteln zu einem Audio‑Frame über die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Diese Methode gibt eine [ICaptionsCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/) zurück, mit der Sie WebVTT‑Untertitelspuren hinzufügen, vorhandene Spuren durchlaufen und bei Bedarf entfernen können.

**Audio‑Untertitel hinzufügen**

Verwenden Sie die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--), um einer Audio‑Frame‑Instanz ein oder mehrere Untertitelspuren anzuhängen. Im folgenden Beispiel wird einer Folie eine Audiodatei hinzugefügt und anschließend eine neue Untertitelspur aus einer `.vtt`‑Datei geladen.

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

Sie können die mit einem Audio‑Frame verbundenen Untertitelspuren durchlaufen und sie als `.vtt`‑Dateien speichern. Jede Untertitelspur stellt ihre Binärdaten und ihre eindeutige Kennung bereit, die beim Exportieren der Untertitel verwendet werden können.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Speichere die Untertitelspur als .vtt-Datei.
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

**Audio‑Untertitel entfernen**

Um Untertitel aus einem Audio‑Frame zu entfernen, nutzen Sie die Methoden der [ICaptionsCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/), wie [clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) oder [removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). Das folgende Beispiel entfernt alle Untertitelspuren aus einem Audio‑Frame.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Entferne alle Untertitelspuren vom Audio-Frame.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Audio extrahieren**
Aspose.Slides für Android via Java ermöglicht das Extrahieren des bei Folienübergängen verwendeten Sounds. Zum Beispiel können Sie den Sound einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie sich den Bezug zur entsprechenden Folie über deren Index.
3. Greifen Sie auf die [slideshow transitions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) der Folie zu.
4. Extrahieren Sie den Sound als Byte‑Daten.

Dieser Java‑Code zeigt, wie Sie den in einer Folie verwendeten Sound extrahieren:

```java
// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Zugriff auf die gewünschte Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ruft die Übergangseffekte der Bildschirmpräsentation für die Folie ab
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Extrahiert den Sound als Byte-Array
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kann ich dieselbe Audiodatei auf mehreren Folien wiederverwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur geteilten [audio collection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getAudios--) der Präsentation hinzu und erstellen Sie weitere Audio‑Frames, die auf dieses vorhandene Asset verweisen. So wird die Medien­datei nicht dupliziert und die Präsentationsgröße bleibt kontrollierbar.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Sound ändern Sie den [link path](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-), sodass er auf die neue Datei zeigt. Für einen eingebetteten Sound tauschen Sie das [embedded audio](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-)‑Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getAudios--) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Ändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Beim Trimmen werden nur die Wiedergabegrenzen angepasst. Die ursprünglichen Audio‑Bytes bleiben unverändert und sind über das eingebettete Audio oder die Audio‑Collection der Präsentation weiterhin zugänglich.