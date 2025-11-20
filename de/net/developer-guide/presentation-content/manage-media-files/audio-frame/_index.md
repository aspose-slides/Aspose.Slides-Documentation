---
title: Audio in Präsentationen mit C# verwalten
linktitle: Audio‑Frame
type: docs
weight: 10
url: /de/net/audio-frame/
keywords:
- Audio
- Audio‑Frame
- Miniaturansicht
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- .NET
- C#
- Aspose.Slides
description: "Erstellen und steuern Sie Audio‑Frames in Aspose.Slides für .NET—C#‑Beispiele zum Einbetten, Zuschneiden, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX‑ und ODP‑Präsentationen."
---

## **Audio-Frames erstellen**

Aspose.Slides für .NET ermöglicht es Ihnen, Audiodateien zu Folien hinzuzufügen. Die Audiodateien werden als Audio-Frames in die Folien eingebettet. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
2. Holen Sie sich über den Index den Verweis auf eine Folie.
3. Laden Sie den Audiodatei‑Stream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio‑Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioplaymodepreset) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe)-Objekt bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie einen eingebetteten Audio‑Frame zu einer Folie hinzufügen:
```c#
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert
using (Presentation pres = new Presentation())
{
    // Lädt die erste Folie
    ISlide sld = pres.Slides[0];
    
    // Lädt die WAV-Audiodatei in einen Stream
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


## **Audio‑Frame‑Vorschaubild ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, erscheint das Audio als Frame mit einer Standard‑Standardgrafik (siehe Bild im nachfolgenden Abschnitt). Sie können das Vorschaubild des Audio‑Frames ändern (ein bevorzugtes Bild festlegen).

Dieser C#‑Code zeigt, wie Sie das Vorschaubild bzw. die Vorschau­grafik eines Audio‑Frames ändern:
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
    
	//Speichert die geänderte Präsentation auf die Festplatte
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


## **Audio‑Wiedergabeoptionen ändern**

Aspose.Slides für .NET ermöglicht es Ihnen, Optionen zu ändern, die die Audiowiedergabe oder -eigenschaften steuern. Beispielsweise können Sie die Lautstärke anpassen, das Audio in einer Schleife abspielen oder das Audiosymbol ausblenden.

Das **Audio‑Optionen**‑Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint‑**Audio‑Optionen**, die den Aspose.Slides‑[AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe)-Eigenschaften entsprechen:

- **Start**‑Dropdown‑Menü entspricht der [AudioFrame.PlayMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playmode)-Eigenschaft
- **Volume** entspricht der [AudioFrame.Volume](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/volume)-Eigenschaft
- **Play Across Slides** entspricht der [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playacrossslides)-Eigenschaft
- **Loop until Stopped** entspricht der [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/playloopmode)-Eigenschaft
- **Hide During Show** entspricht der [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/hideatshowing)-Eigenschaft
- **Rewind after Playing** entspricht der [AudioFrame.RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/properties/rewindaudio)-Eigenschaft

PowerPoint‑**Bearbeitungs**‑Optionen, die den Aspose.Slides‑[AudioFrame](https://reference.aspose.com/slides/net/aspose.slides/audioframe)-Eigenschaften entsprechen:

- **Fade In** entspricht der [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeinduration/)-Eigenschaft
- **Fade Out** entspricht der [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/audioframe/fadeoutduration/)-Eigenschaft
- **Trim Audio Start Time** entspricht der [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromstart/)-Eigenschaft
- **Trim Audio End Time** entspricht dem Wert der Audiodauer minus dem Wert von [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/audioframe/trimfromend/)-Eigenschaft

Der PowerPoint‑**Volume‑Regler** im Audiosteuerungs‑Panel entspricht der [AudioFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/audioframe/volumevalue/)-Eigenschaft. Er ermöglicht die Einstellung der Lautstärke in Prozent.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. [Create](#create-audio-frame) oder holen Sie den Audio‑Frame.
2. Setzen Sie neue Werte für die Audio‑Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint‑Datei.

Dieser C#‑Code demonstriert einen Vorgang, bei dem die Optionen eines Audios angepasst werden:
``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Holt das AudioFrame-Shape
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Setzt den Wiedergabemodus auf Klick
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Setzt die Lautstärke auf Niedrig
    audioFrame.Volume = AudioVolumeMode.Low;

    // Setzt das Audio auf Wiedergabe über Folien hinweg
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


Dieses C#‑Beispiel zeigt, wie man einen neuen Audio‑Frame mit eingebettetem Audio hinzufügt, ihn zuschneidet und die Einblend‑Dauern festlegt:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Setzt den Trimm-Startversatz auf 1.5 Sekunden
    audioFrame.TrimFromStart = 1500f;
    // Setzt den Trimm-Endversatz auf 2 Sekunden
    audioFrame.TrimFromEnd = 2000f;

    // Setzt die Einblend-Dauer auf 200 ms
    audioFrame.FadeInDuration = 200f;
    // Setzt die Ausblend-Dauer auf 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```


Der folgende Code‑Abschnitt zeigt, wie man einen Audio‑Frame mit eingebettetem Audio abruft und die Lautstärke auf 85 % setzt:
```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Holt das Audio-Frame-Shape
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Setzt die Audiolautstärke auf 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```


## **Audio extrahieren**

Aspose.Slides für .NET ermöglicht es Ihnen, den in Folienübergängen verwendeten Klang zu extrahieren. Beispielsweise können Sie den Klang extrahieren, der in einer bestimmten Folie verwendet wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie sich über den Index den Verweis auf die betreffende Folie.
3. Greifen Sie auf die Folien‑Übergänge der Folie zu.
4. Extrahieren Sie den Klang als Byte‑Daten.

Dieser C#‑Code zeigt, wie Sie das in einer Folie verwendete Audio extrahieren:
```c#
string presName = "AudioSlide.pptx";

// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation(presName);

// Greift auf die Folie zu
ISlide slide = pres.Slides[0];

// Ermittelt die Folienübergangseffekte für die Folie
ISlideShowTransition transition = slide.SlideShowTransition;

//Extrahiert den Sound in ein Byte-Array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```


## **FAQ**

**Kann ich dasselbe Audio‑Asset in mehreren Folien wiederverwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur gemeinsam genutzten [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) der Präsentation hinzu und erstellen Sie weitere Audio‑Frames, die auf dieses vorhandene Asset verweisen. Dadurch werden Mediendaten nicht dupliziert und die Präsentationsgröße bleibt kontrollierbar.

**Kann ich den Klang in einem bestehenden Audio‑Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Klang aktualisieren Sie den [link path](https://reference.aspose.com/slides/net/aspose.slides/audioframe/linkpathlong/) auf die neue Datei. Für einen eingebetteten Klang tauschen Sie das [embedded audio](https://reference.aspose.com/slides/net/aspose.slides/audioframe/embeddedaudio/)-Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Ändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Das Trimmen passt nur die Wiedergabegrenzen an. Die ursprünglichen Audiodaten bleiben unverändert und über das eingebettete Audio bzw. die Audio‑Collection der Präsentation zugänglich.