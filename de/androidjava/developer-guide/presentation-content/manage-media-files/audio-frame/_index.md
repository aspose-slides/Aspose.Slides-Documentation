---
title: Audio in Präsentationen auf Android verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/androidjava/audio-frame/
keywords:
- Audio
- Audio-Frame
- Miniaturbild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- Android
- Java
- Aspose.Slides
description: "Audio-Frames in Aspose.Slides für Android erstellen und steuern – Java-Beispiele zum Einbetten, Zuschneiden, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---

## **Audio-Frames erstellen**
Aspose.Slides für Android via Java ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in Folien als Audio-Frames eingebettet.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Laden Sie den Audio-Dateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame)‑Objekt bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieser Java‑Code zeigt, wie Sie einen eingebetteten Audio‑Frame zu einer Folie hinzufügen:
```java
// Instanziiert eine Presentation‑Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Lädt die wav‑Audiodatei in einen Stream
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Fügt das Audio‑Frame hinzu
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Setzt den Wiedergabemodus und die Lautstärke des Audios
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Schreibt die PowerPoint‑Datei auf die Festplatte
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Audio-Frame-Vorschaubild ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, wird das Audio als Frame mit einem standardmäßigen Standardbild angezeigt (siehe das Bild im nachfolgenden Abschnitt). Sie können das Vorschaubild des Audio‑Frames ändern (ein gewünschtes Bild festlegen).

Dieser Java‑Code zeigt, wie Sie das Miniatur‑ bzw. Vorschaubild eines Audio‑Frames ändern:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügt der Folie einen Audio-Frame mit angegebener Position und Größe hinzu.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Fügt dem Präsentations-Resource ein Bild hinzu.
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


## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides für Android via Java ermöglicht das Anpassen von Optionen, die die Audio‑Wiedergabe oder Eigenschaften steuern. Beispielsweise können Sie die Lautstärke anpassen, das Audio in Schleife abspielen oder das Audiosymbol ausblenden.

Das **Audio-Optionen**-Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio-Optionen**, die den Aspose.Slides‑[AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame)‑Eigenschaften entsprechen:

- **Start**‑Dropdown-Liste entspricht der Eigenschaft [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- **Lautstärke** entspricht der Eigenschaft [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--) 
- **Wiedergabe über Folien hinweg** entspricht der Eigenschaft [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- **Schleife bis Stopp** entspricht der Eigenschaft [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 
- **Ausblenden während der Show** entspricht der Eigenschaft [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 
- **Nach dem Abspielen zurückspulen** entspricht der Eigenschaft [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 

PowerPoint **Bearbeitungsoptionen**, die den Aspose.Slides‑[AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/)‑Eigenschaften entsprechen:

- **Einblenden** entspricht der Eigenschaft [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 
- **Ausblenden** entspricht der Eigenschaft [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 
- **Startzeit des Audios zuschneiden** entspricht der Eigenschaft [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 
- **Endzeit des Audios zuschneiden** Wert entspricht der Audiodauer minus dem Wert der Eigenschaft [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 

Der PowerPoint **Lautstärkeregler** im Audiosteuerungsfeld entspricht der Eigenschaft [AudioFrame.VolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) . Er ermöglicht das Ändern der Lautstärke als Prozentsatz.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. [Erstellen](#create-audio-frame) oder holen Sie den Audio‑Frame.
2. Setzen Sie neue Werte für die Audio‑Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint‑Datei.

Dieser Java‑Code demonstriert einen Vorgang, bei dem die Optionen eines Audios angepasst werden:
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Holt das AudioFrame-Shape
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Setzt den Wiedergabemodus auf Bei Klick abspielen
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Setzt die Lautstärke auf Niedrig
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Setzt das Audio so, dass es über Folien hinweg abgespielt wird
    audioFrame.setPlayAcrossSlides(true);

    // Deaktiviert die Schleife für das Audio
    audioFrame.setPlayLoopMode(false);

    // Blendet das AudioFrame während der Präsentation aus
    audioFrame.setHideAtShowing(true);

    // Spult das Audio nach dem Abspielen zum Start zurück
    audioFrame.setRewindAudio(true);

    // Speichert die PowerPoint-Datei auf die Festplatte
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Dieses Java‑Beispiel zeigt, wie man einen neuen Audio‑Frame mit eingebettetem Audio hinzufügt, zuschneidet und die Ein‑ und Ausblendezeiten festlegt:
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


Das folgende Codebeispiel zeigt, wie man einen Audio‑Frame mit eingebettetem Audio abruft und dessen Lautstärke auf 85 % setzt:
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
Aspose.Slides für Android via Java ermöglicht das Extrahieren des bei Folienübergängen verwendeten Tons. Beispielsweise können Sie den in einer bestimmten Folie verwendeten Ton extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) und laden Sie die Präsentation, die das Audio enthält.
2. Rufen Sie die Referenz der betreffenden Folie über ihren Index ab.
3. Greifen Sie auf die [Folienübergänge](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) der Folie zu.
4. Extrahieren Sie den Ton als Byte‑Daten.

Dieser Java‑Code zeigt, wie Sie das in einer Folie verwendete Audio extrahieren:
```java
// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Greift auf die gewünschte Folie zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Holt die Folienübergangseffekte für die Folie
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Extrahiert den Ton in ein Byte-Array
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich dasselbe Audio-Asset über mehrere Folien hinweg wiederverwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur geteilten [Audio‑Sammlung](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) der Präsentation hinzu und erstellen Sie weitere Audio‑Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird eine Duplizierung von Mediendaten vermieden und die Präsentationsgröße bleibt kontrollierbar.

**Kann ich den Ton in einem bestehenden Audio-Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Ton aktualisieren Sie den [Linkpfad](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) , damit er auf die neue Datei zeigt. Für ein eingebettetes Audio tauschen Sie das [eingebettete Audio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-)‑Objekt gegen ein anderes aus der [Audio‑Sammlung](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben unverändert.

**Ändert das Zuschneiden die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Das Zuschneiden ändert nur die Wiedergabegrenzen. Die ursprünglichen Audiodaten bleiben unverändert und sind über das eingebettete Audio oder die Audio‑Sammlung der Präsentation zugänglich.