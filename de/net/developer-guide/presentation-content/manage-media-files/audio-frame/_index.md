---
title: Audio-Frame - Audio in PowerPoint mit C# einfügen und extrahieren
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/net/audio-frame/
keywords: "Audio-Vorschaubild, Audio hinzufügen, Audio-Frame, Audio-Eigenschaften, Audio extrahieren, C#, Csharp, Aspose.Slides für .NET"
description: "Audio zu PowerPoint-Präsentationen in C# oder .NET hinzufügen"
---

## **Audio-Frame erstellen**
Aspose.Slides für .NET ermöglicht es Ihnen, Audiodateien in Folien hinzuzufügen. Die Audiodateien werden als Audio-Frames in die Folien eingebettet.

1. Erstellen Sie eine Instanz der [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Laden Sie den Audiodateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) Objekt bereitgestellt werden.
6. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie einen eingebetteten Audio-Frame zu einer Folie hinzufügen:

```c#
// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation())
{
    // Ruft die erste Folie ab
    ISlide sld = pres.Slides[0];
    
    // Lädt die wav-Audiodatei in einen Stream
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Fügt den Audio-Frame hinzu
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Setzt den Wiedergabemodus und die Lautstärke des Audios
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Schreibt die PowerPoint-Datei auf die Festplatte
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Thumbnail des Audio-Frames ändern**

Wenn Sie eine Audiodatei zu einer Präsentation hinzufügen, erscheint der Audio-Frame mit einem standardmäßigen Standardbild (siehe das Bild im Abschnitt unten). Sie können das Thumbnail des Audio-Frames ändern (setzen Sie Ihr bevorzugtes Bild).

Dieser C#-Code zeigt Ihnen, wie Sie das Thumbnail oder Vorschau-Bild eines Audio-Frames ändern:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Fügt einen Audio-Frame zur Folie mit einer bestimmten Position und Größe hinzu.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Fügt ein Bild zu den Präsentationsressourcen hinzu.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Setzt das Bild für den Audio-Frame.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//Speichert die modifizierte Präsentation auf der Festplatte
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides für .NET ermöglicht es Ihnen, Optionen zu ändern, die die Wiedergabe oder die Eigenschaften eines Audios steuern. Zum Beispiel können Sie die Lautstärke eines Audios anpassen, das Audio im Loop abspielen oder das Audio-Symbol sogar ausblenden.

Das **Audio-Optionen**-Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint-Audiooptionen, die den Eigenschaften von Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe) entsprechen:

- Die Dropdown-Liste **Start** der Audiooptionen entspricht der [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode) Eigenschaft 
- Die **Lautstärke**-Option der Audiooptionen entspricht der [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume) Eigenschaft 
- **Über Folien abspielen** der Audiooptionen entspricht der [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides) Eigenschaft 
- **Schleife bis zum Stoppen** der Audiooptionen entspricht der [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode) Eigenschaft 
- **Während der Präsentation ausblenden** der Audiooptionen entspricht der  [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing) Eigenschaft 
- **Nach dem Abspielen zurückspulen** der Audiooptionen entspricht der [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio) Eigenschaft 

So ändern Sie die Audio-Wiedergabeoptionen:

1. [Erstellen](#create-audio-frame) oder holen Sie sich den Audio-Frame.
2. Setzen Sie neue Werte für die Audio-Frame-Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die modifizierte PowerPoint-Datei.

Dieser C#-Code demonstriert eine Operation, bei der die Optionen eines Audios angepasst werden:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Ruft die AudioFrame-Gestalt ab
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Setzt den Wiedergabemodus auf klicken
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Setzt die Lautstärke auf niedrig
    audioFrame.Volume = AudioVolumeMode.Low;

    // Setzt das Audio so, dass es über Folien abgespielt wird
    audioFrame.PlayAcrossSlides = true;

    // Deaktiviert die Schleife für das Audio
    audioFrame.PlayLoopMode = false;

    // Blendet den AudioFrame während der Diashow aus
    audioFrame.HideAtShowing = true;

    // Spult das Audio nach dem Abspielen zurück
    audioFrame.RewindAudio = true;

    // Speichert die PowerPoint-Datei auf der Festplatte
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

## **Audio extrahieren**
Aspose.Slides für .NET ermöglicht es Ihnen, den Ton, der in Folienübergängen verwendet wird, zu extrahieren. Zum Beispiel können Sie den Ton, der in einer bestimmten Folie verwendet wird, extrahieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse und laden Sie die Präsentation, die die Audiodatei enthält.
2. Holen Sie sich eine Referenz auf die entsprechende Folie über ihren Index.
3. Greifen Sie auf die Diashowübergänge für die Folie zu.
4. Extrahieren Sie den Ton in Byte-Daten.

Dieser C#-Code zeigt Ihnen, wie Sie die in einer Folie verwendete Audiodatei extrahieren:

```c#
string presName = "AudioSlide.pptx";

// Erstellt eine Präsentationsklasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation(presName);

// Greift auf die Folie zu
ISlide slide = pres.Slides[0];

// Ruft die Diashowübergangseffekte für die Folie ab
ISlideShowTransition transition = slide.SlideShowTransition;

//Extrahiert den Ton in ein Byte-Array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Länge: " + audio.Length);
```