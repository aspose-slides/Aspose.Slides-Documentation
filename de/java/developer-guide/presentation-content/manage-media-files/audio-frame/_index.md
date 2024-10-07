---
title: Audio Frame
type: docs
weight: 10
url: /java/audio-frame/
keywords: "Audio hinzufügen, Audio Frame, Audioeigenschaften, Audio extrahieren, Java, Aspose.Slides für Java"
description: "Audio in PowerPoint-Präsentation in Java hinzufügen"
---

## **Audio Frame erstellen**
Aspose.Slides für Java ermöglicht es Ihnen, Audiodateien zu Folien hinzuzufügen. Die Audiodateien werden als Audio-Frames in die Folien eingebettet. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Laden Sie den Audiostream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame) Objekt bereitgestellt werden.
6. Speichern Sie die bearbeitete Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie einen eingebetteten Audio-Frame zu einer Folie hinzufügen:

```Java
// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Lädt die wav Audiodatei in den Stream
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Fügt den Audio Frame hinzu
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Setzt den Play Mode und die Lautstärke des Audios
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Schreibt die PowerPoint-Datei auf die Festplatte
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Audio Frame Thumbnail ändern**

Wenn Sie eine Audiodatei zu einer Präsentation hinzufügen, erscheint das Audio als ein Frame mit einem standardmäßigen Standardbild (siehe das Bild im Abschnitt unten). Sie können das Vorschaubild des Audio-Frames ändern (setzen Sie Ihr bevorzugtes Bild).

Dieser Java-Code zeigt Ihnen, wie Sie das Thumbnail oder Vorschaubild eines Audio-Frames ändern:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügt einen Audio Frame zur Folie mit einer bestimmten Position und Größe hinzu.
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

    // Setzt das Bild für den Audio Frame.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Speichert die bearbeitete Präsentation auf der Festplatte
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides für Java ermöglicht es Ihnen, Optionen zu ändern, die die Wiedergabe oder Eigenschaften eines Audios steuern. Zum Beispiel können Sie die Lautstärke eines Audios anpassen, das Audio zum wiederholten Abspielen festlegen oder sogar das Audio-Symbol ausblenden.

Das **Audio Optionen** Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint Audio-Optionen, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) Eigenschaften entsprechen:
- Das Dropdown-Menü **Start** der Audio-Optionen entspricht der [AudioFrame.PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayMode--) Eigenschaft
- Die Audio-Optionen **Lautstärke** entsprechen der [AudioFrame.Volume](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getVolume--) Eigenschaft
- Die Audio-Optionen **Über Folien abspielen** entsprechen der [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) Eigenschaft
- Die Audio-Optionen **Schleife bis gestoppt** entsprechen der [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayLoopMode--) Eigenschaft
- Die Audio-Optionen **Während der Präsentation ausblenden** entsprechen der [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getHideAtShowing--) Eigenschaft
- Die Audio-Optionen **Nach dem Abspielen zurückspulen** entsprechen der [AudioFrame.RewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getRewindAudio--) Eigenschaft

So ändern Sie die Audio-Wiedergabeoptionen:

1. [Erstellen](#create-audio-frame) oder holen Sie sich den Audio Frame.
2. Setzen Sie neue Werte für die Audio Frame Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die bearbeitete PowerPoint-Datei.

Dieser Java-Code demonstriert eine Operation, in der die Optionen eines Audios angepasst werden:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Holt die AudioFrame Form
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Setzt den Wiedergabemodus auf "bei Klick abspielen"
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Setzt die Lautstärke auf niedrig
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Setzt das Audio so, dass es über Folien abgespielt wird
    audioFrame.setPlayAcrossSlides(true);

    // Deaktiviert die Schleife für das Audio
    audioFrame.setPlayLoopMode(false);

    // Versteckt den AudioFrame während der Präsentation
    audioFrame.setHideAtShowing(true);

    // Spult das Audio nach dem Abspielen zurück
    audioFrame.setRewindAudio(true);

    // Speichert die PowerPoint-Datei auf der Festplatte
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Audio extrahieren**

Aspose.Slides für Java ermöglicht es Ihnen, den Ton zu extrahieren, der in Folienübergängen verwendet wird. Zum Beispiel können Sie den Ton extrahieren, der in einer bestimmten Folie verwendet wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse und laden Sie die Präsentation mit Folienübergängen.
2. Greifen Sie auf die gewünschte Folie zu.
3. Greifen Sie auf die [Folienübergänge](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) der Folie zu.
4. Extrahieren Sie den Ton in Byte-Daten.

Dieser Code in Java zeigt Ihnen, wie Sie das Audio, das in einer Folie verwendet wird, extrahieren:

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
    System.out.println("Länge: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```