---
title: Audio-Frames in Präsentationen in .NET verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/net/audio-frame/
keywords:
- Audio
- Audio-Frame
- Miniaturbild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- .NET
- C#
- Aspose.Slides
description: "Erstellen und steuern Sie Audio-Frames in Aspose.Slides für .NET - C#-Beispiele zum Einbetten, Trimmen, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---

## **Audio-Frames erstellen**

Aspose.Slides für .NET ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in den Folien als Audio-Frames eingebettet. 

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Laden Sie den Audiodatei-Stream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe)-Objekt bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieser C#-Code zeigt, wie Sie einen eingebetteten Audio-Frame zu einer Folie hinzufügen:
```c#
    // Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
    using (Presentation pres = new Presentation())
    {
        // Holt die erste Folie
        ISlide sld = pres.Slides[0];
        
        // Lädt die wav‑Audiodatei in einen Stream
        FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

        // Fügt den Audio‑Frame hinzu
        IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

        // Setzt den Wiedergabemodus und die Lautstärke des Audios
        audioFrame.PlayMode = AudioPlayModePreset.Auto;
        audioFrame.Volume = AudioVolumeMode.Loud;

        // Schreibt die PowerPoint‑Datei auf die Festplatte
        pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
    }
```


## **Audio-Frame-Miniaturbild ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, wird das Audio als Frame mit einem standardmäßigen Standardbild dargestellt (siehe das Bild im nachfolgenden Abschnitt). Sie können das Miniaturbild des Audio-Frames ändern (Ihr bevorzugtes Bild festlegen).

Dieser C#-Code zeigt, wie Sie das Miniatur- oder Vorschaubild eines Audio-Frames ändern:
```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Fügt der Folie einen Audio-Frame mit einer angegebenen Position und Größe hinzu.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Fügt ein Bild zu den Präsentationsressourcen hinzu.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Setzt das Bild für den Audio-Frame.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//Speichert die geänderte Präsentation auf der Festplatte
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides für .NET ermöglicht das Ändern von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Sie können beispielsweise die Lautstärke eines Audios anpassen, das Audio in einer Schleife abspielen lassen oder sogar das Audiosymbol ausblenden.

Das **Audio-Optionen**‑Fenster in Microsoft PowerPoint:
![example1_image](audio_frame_0.png)

PowerPoint **Audio-Optionen**, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe)-Eigenschaften entsprechen:
- **Start**‑Dropdown entspricht der [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode)-Eigenschaft
- **Volume** entspricht der [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume)-Eigenschaft
- **Play Across Slides** entspricht der [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides)-Eigenschaft
- **Loop until Stopped** entspricht der [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode)-Eigenschaft
- **Hide During Show** entspricht der [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing)-Eigenschaft
- **Rewind after Playing** entspricht der [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio)-Eigenschaft

PowerPoint **Bearbeitungs**‑Optionen, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe)-Eigenschaften entsprechen:
- **Fade In** entspricht der [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/)-Eigenschaft
- **Fade Out** entspricht der [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/)-Eigenschaft
- **Trim Audio Start Time** entspricht der [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/)-Eigenschaft
- **Trim Audio End Time**‑Wert entspricht der Audiodauer minus dem Wert der [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/)-Eigenschaft

Der PowerPoint **Lautstärkeregler** im Audiosteuerungsfeld entspricht der [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/)-Eigenschaft. Er ermöglicht die Anpassung der Lautstärke als Prozentsatz.

So ändern Sie die Audio‑Wiedergabeoptionen:
1. [Erstellen](#create-audio-frame) oder holen Sie den Audio-Frame.
2. Setzen Sie neue Werte für die Audio-Frame-Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint-Datei.

Dieser C#‑Code demonstriert einen Vorgang, bei dem Audio-Optionen angepasst werden:
``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Holt das AudioFrame-Shape
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Setzt den Wiedergabemodus auf Klick
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Setzt die Lautstärke auf niedrig
    audioFrame.Volume = AudioVolumeMode.Low;

    // Setzt das Audio auf Wiedergabe über Folien
    audioFrame.PlayAcrossSlides = true;

    // Deaktiviert die Schleife für das Audio
    audioFrame.PlayLoopMode = false;

    // Versteckt das AudioFrame während der Vorführung
    audioFrame.HideAtShowing = true;

    // Spult das Audio nach dem Abspielen zurück zum Anfang
    audioFrame.RewindAudio = true;

    // Speichert die PowerPoint-Datei auf die Festplatte
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```


Dieses C#‑Beispiel zeigt, wie ein neuer Audio-Frame mit eingebettetem Audio hinzugefügt, zugeschnitten und die Fade-Dauern festgelegt werden:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Setzt den Trimm-Start-Offset auf 1,5 Sekunden
    audioFrame.TrimFromStart = 1500f;
    // Setzt den Trimm-End-Offset auf 2 Sekunden
    audioFrame.TrimFromEnd = 2000f;

    // Setzt die Fade-In-Dauer auf 200 ms
    audioFrame.FadeInDuration = 200f;
    // Setzt die Fade-Out-Dauer auf 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```


Das folgende Code-Beispiel zeigt, wie ein Audio-Frame mit eingebettetem Audio abgerufen und dessen Lautstärke auf 85 % gesetzt wird:
```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Holt ein Audio-Frame-Shape
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Setzt die Lautstärke auf 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```


## **Audio extrahieren**

Aspose.Slides für .NET ermöglicht das Extrahieren des in Folienübergängen verwendeten Sounds. Sie können beispielsweise den Sound einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie die Referenz der betreffenden Folie über ihren Index.
3. Greifen Sie auf die Folienübergänge der Folie zu.
4. Extrahieren Sie den Sound als Byte-Daten.

Dieser C#-Code zeigt, wie Sie den in einer Folie verwendeten Audio extrahieren:
```c#
string presName = "AudioSlide.pptx";

// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation(presName);

// Greift auf die Folie zu
ISlide slide = pres.Slides[0];

// Holt die Folienübergangseffekte für die Folie
ISlideShowTransition transition = slide.SlideShowTransition;

//Extrahiert den Sound als Byte-Array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **FAQ**

**Kann ich dasselbe Audio-Asset auf mehreren Folien wiederverwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur gemeinsam genutzten [Audio-Sammlung](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) der Präsentation hinzu und erstellen Sie weitere Audio-Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird das Duplizieren von Mediendaten vermieden und die Präsentationsgröße bleibt überschaubar.

**Kann ich den Sound in einem bestehenden Audio-Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verlinkten Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) so, dass er auf die neue Datei zeigt. Für einen eingebetteten Sound tauschen Sie das [embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/)-Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Verändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Das Trimmen passt nur die Wiedergabebereiche an. Die ursprünglichen Audiodaten bleiben unverändert und sind über das eingebettete Audio oder die Audio-Sammlung der Präsentation zugänglich.