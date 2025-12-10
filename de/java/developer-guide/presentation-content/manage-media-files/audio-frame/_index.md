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
description: "Audio-Frames in Aspose.Slides für Java erstellen und steuern – Codebeispiele zum Einbetten, Trimmen, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP‑Präsentationen."
---

## **Audio-Frames erstellen**

Aspose.Slides for Java ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in den Folien als Audio-Frames eingebettet. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Laden Sie den Audiodateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) der Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame)-Objekt bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieser Java-Code zeigt, wie Sie einen eingebetteten Audio-Frame zu einer Folie hinzufügen:
```java
// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Lädt die wav-Audiodatei in einen Stream
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Fügt das Audio-Frame hinzu
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


## **Miniaturansicht des Audio-Frames ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, wird das Audio als Frame mit einem standardmäßigen Standardbild angezeigt (siehe das Bild im nachfolgenden Abschnitt). Sie können das Vorschaubild des Audio-Frames ändern (ein bevorzugtes Bild festlegen).

Dieser Java-Code zeigt, wie Sie die Miniaturansicht oder das Vorschaubild eines Audio-Frames ändern:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügt der Folie einen Audio-Frame an einer angegebenen Position und Größe hinzu.
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

    //Speichert die geänderte Präsentation auf die Festplatte
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides for Java ermöglicht das Ändern von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Beispielsweise können Sie die Lautstärke eines Audios anpassen, das Audio in einer Schleife abspielen lassen oder sogar das Audiosymbol ausblenden.

Das **Audio Options**-Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, die den Aspose.Slides-[AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame)-Eigenschaften entsprechen:

- **Start**-Dropdown-Liste entspricht der Methode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayMode-int-) .
- **Volume** entspricht der Methode [AudioFrame.setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolume-int-) .
- **Play Across Slides** entspricht der Methode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) .
- **Loop until Stopped** entspricht der Methode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) .
- **Hide During Show** entspricht der Methode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) .
- **Rewind after Playing** entspricht der Methode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) .

PowerPoint **Editing**-Optionen, die den Aspose.Slides-[AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame)-Eigenschaften entsprechen:

- **Fade In** entspricht der Methode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) .
- **Fade Out** entspricht der Methode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) .
- **Trim Audio Start Time** entspricht der Methode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) .
- **Trim Audio End Time**-Wert entspricht der Audiodauer minus dem Wert der Methode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) .

Der PowerPoint-**Volume-Kontrolle** im Audiosteuerungsfeld entspricht der Methode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Sie ermöglicht das Ändern der Lautstärke des Audios in Prozent.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. [Erstellen](#create-audio-frame) oder holen Sie den Audio-Frame.
2. Setzen Sie neue Werte für die Audio-Frame-Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint-Datei.

Dieser Java-Code demonstriert einen Vorgang, bei dem die Optionen eines Audios angepasst werden:
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Holt das AudioFrame-Shape
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Setzt den Wiedergabemodus auf Beim Klick
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Setzt die Lautstärke auf Niedrig
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Setzt das Audio auf Wiedergabe über Folien hinweg
    audioFrame.setPlayAcrossSlides(true);

    // Deaktiviert die Schleife für das Audio
    audioFrame.setPlayLoopMode(false);

    // Versteckt das AudioFrame während der Bildschirmanzeige
    audioFrame.setHideAtShowing(true);

    // Spult das Audio nach der Wiedergabe zum Anfang zurück
    audioFrame.setRewindAudio(true);

    // Speichert die PowerPoint-Datei auf die Festplatte
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Dieses Java-Beispiel zeigt, wie man einen neuen Audio-Frame mit eingebettetem Audio hinzufügt, ihn trimmt und die Fade-Dauern festlegt:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Setzt den Trimm-Startversatz auf 1,5 Sekunden
    audioFrame.setTrimFromStart(1500f);
    // Setzt den Trimm-Endversatz auf 2 Sekunden
    audioFrame.setTrimFromEnd(2000f);

    // Setzt die Fade-In-Dauer auf 200 ms
    audioFrame.setFadeInDuration(200f);
    // Setzt die Fade-Out-Dauer auf 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Das folgende Codebeispiel zeigt, wie man einen Audio-Frame mit eingebettetem Audio abruft und die Lautstärke auf 85 % setzt:
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


## **Audio extrahieren**

Aspose.Slides for Java ermöglicht das Extrahieren des bei Folienübergängen verwendeten Tons. Beispielsweise können Sie den Ton einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie sich die Referenz der entsprechenden Folie über deren Index.
3. Greifen Sie auf die [slideshow transitions](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) der Folie zu.
4. Extrahieren Sie den Ton als Byte‑Daten.

Dieser Java-Code zeigt, wie Sie das in einer Folie verwendete Audio extrahieren:
```java
// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Greift auf die gewünschte Folie zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Holt die Übergangseffekte der Bildschirmanzeige für die Folie
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Extrahiert den Klang als Byte-Array
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich dieselbe Audio-Datei in mehreren Folien wiederverwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur gemeinsam genutzten [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) der Präsentation hinzu und erstellen Sie weitere Audio-Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird das Duplizieren von Mediendaten vermieden und die Präsentationsgröße bleibt kontrollierbar.

**Kann ich den Ton in einem bestehenden Audio-Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Bei einem verknüpften Ton aktualisieren Sie den [link path](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) auf die neue Datei. Bei einem eingebetteten Ton tauschen Sie das [embedded audio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-)‑Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Ändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Das Trimmen passt nur die Wiedergabegrenzen an. Die ursprünglichen Audio‑Bytes bleiben unverändert und sind über das eingebettete Audio oder die Audio‑Collection der Präsentation zugänglich.