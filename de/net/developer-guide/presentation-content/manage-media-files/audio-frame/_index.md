---
title: Audio-Frames in Präsentationen in .NET verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/net/audio-frame/
keywords:
- Audio
- Audio-Frame
- Vorschaubild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- .NET
- C#
- Aspose.Slides
description: "Audio-Frames in Aspose.Slides für .NET erstellen und steuern — C#-Beispiele zum Einbetten, Trimmen, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---
## **Audio-Frames erstellen**

Aspose.Slides für .NET ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in den Folien als Audio-Frames eingebettet. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Laden Sie den Audiodateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/de/net/aspose.slides/audioplaymodepreset) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe)-Objekt bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieses C#‑Beispiel zeigt, wie ein eingebetteter Audio‑Frame zu einer Folie hinzugefügt wird:

```c#
// Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation())
{
    // Holt die erste Folie
    ISlide sld = pres.Slides[0];
    
    // Lädt die wav-Sounddatei in einen Stream
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Fügt den Audio-Frame hinzu
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Legt den Wiedergabemodus und die Lautstärke des Audios fest
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Speichert die PowerPoint-Datei auf die Festplatte
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Audio‑Frame‑Vorschaubild ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, erscheint das Audio als Frame mit einem standardmäßigen Standardbild (siehe das Bild im nachfolgenden Abschnitt). Sie können das Vorschaubild des Audio‑Frames ändern (ein bevorzugtes Bild festlegen).

Dieses C#‑Beispiel zeigt, wie das Vorschaubild bzw. das Vorschau‑Bild eines Audio‑Frames geändert wird:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Fügt einen Audio-Frame zur Folie an einer angegebenen Position und Größe hinzu.
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

Aspose.Slides für .NET ermöglicht das Ändern von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Zum Beispiel können Sie die Lautstärke eines Audios anpassen, das Audio in Schleife abspielen oder sogar das Audiosymbol ausblenden.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe) properties:

- **Start**‑Dropdown-Menü entspricht der [AudioFrame.PlayMode](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/properties/playmode)‑Eigenschaft 
- **Volume** entspricht der [AudioFrame.Volume](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/properties/volume)‑Eigenschaft 
- **Play Across Slides** entspricht der [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/properties/playacrossslides)‑Eigenschaft 
- **Loop until Stopped** entspricht der [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/properties/playloopmode)‑Eigenschaft 
- **Hide During Show** entspricht der [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/properties/hideatshowing)‑Eigenschaft 
- **Rewind after Playing** entspricht der [AudioFrame.RewindAudio](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/properties/rewindaudio)‑Eigenschaft 

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe) properties:

- **Fade In** entspricht der [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/fadeinduration/)‑Eigenschaft 
- **Fade Out** entspricht der [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/fadeoutduration/)‑Eigenschaft 
- **Trim Audio Start Time** entspricht der [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/trimfromstart/)‑Eigenschaft 
- **Trim Audio End Time**‑Wert entspricht der Audiodauer minus dem Wert der [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/trimfromend/)‑Eigenschaft

Der **Volume‑Regler** in PowerPoint auf der Audiosteuerungsleiste entspricht der [AudioFrame.VolumeValue](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/volumevalue/)‑Eigenschaft. Er ermöglicht die Einstellung der Lautstärke als Prozentsatz.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. [Erstellen](#create-audio-frame) oder erhalten Sie den Audio‑Frame.
2. Setzen Sie neue Werte für die Audio‑Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint‑Datei.

Dieses C#‑Beispiel demonstriert eine Operation, bei der die Optionen eines Audios angepasst werden:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Holt die AudioFrame-Form
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Setzt den Wiedergabemodus auf Beim Klick abspielen
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Setzt die Lautstärke auf Leise
    audioFrame.Volume = AudioVolumeMode.Low;

    // Setzt das Audio so, dass es über Folien hinweg spielt
    audioFrame.PlayAcrossSlides = true;

    // Deaktiviert die Schleife für das Audio
    audioFrame.PlayLoopMode = false;

    // Versteckt das AudioFrame während der Bildschirmanzeige
    audioFrame.HideAtShowing = true;

    // Spult das Audio nach dem Abspielen zum Anfang zurück
    audioFrame.RewindAudio = true;

    // Speichert die PowerPoint-Datei auf die Festplatte
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Dieses C#‑Beispiel zeigt, wie ein neuer Audio‑Frame mit eingebettetem Audio hinzugefügt, zugeschnitten und die Fade‑Dauern festgelegt werden:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Setzt den Trimm-Startversatz auf 1,5 Sekunden
    // Setzt den Trimm-Endversatz auf 2 Sekunden
    // Setzt die Einblendezeit auf 200 ms
    // Setzt die Ausblendezeit auf 500 ms

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

Das folgende Codebeispiel zeigt, wie ein Audio‑Frame mit eingebettetem Audio abgerufen und die Lautstärke auf 85 % gesetzt wird:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Holt ein Audio-Frame-Shape
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Setzt die Audio-Lautstärke auf 85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Audio‑Untertitel verwalten**

Aspose.Slides ermöglicht das Hinzufügen von Untertiteln zu einem Audio‑Frame über die Eigenschaft [CaptionTracks](https://reference.aspose.com/slides/de/net/aspose.slides/iaudioframe/captiontracks/). Diese Eigenschaft gibt eine [ICaptionsCollection](https://reference.aspose.com/slides/de/net/aspose.slides/icaptionscollection/) zurück, mit der Sie WebVTT‑Untertitelspuren hinzufügen, vorhandene Spuren iterieren und bei Bedarf entfernen können.

**Audio‑Untertitel hinzufügen**

Verwenden Sie die Eigenschaft [CaptionTracks](https://reference.aspose.com/slides/de/net/aspose.slides/iaudioframe/captiontracks/), um einer oder mehreren Untertitelspuren an einen Audio‑Frame anzuhängen. Im folgenden Beispiel wird einer Folie eine Audiodatei hinzugefügt und anschließend eine neue Untertitelspur aus einer `.vtt`‑Datei geladen.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Fügt eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Audio‑Untertitel extrahieren**

Sie können über die mit einem Audio‑Frame verknüpften Untertitelspuren iterieren und sie als `.vtt`‑Dateien speichern. Jede Untertitelspur stellt ihre Binärdaten und eine eindeutige Kennung bereit, die beim Exportieren der Untertitel verwendet werden kann.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // Speichert die Untertitelspur als .vtt-Datei.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Audio‑Untertitel entfernen**

Um Untertitel von einem Audio‑Frame zu entfernen, verwenden Sie die Methoden der [ICaptionsCollection](https://reference.aspose.com/slides/de/net/aspose.slides/icaptionscollection/), wie [Clear](https://reference.aspose.com/slides/de/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/de/net/aspose.slides/icaptionscollection/remove/) oder [RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides/icaptionscollection/removeat/). Das folgende Beispiel entfernt alle Untertitelspuren von einem Audio‑Frame.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Entfernt alle Untertitelspuren aus dem Audio-Frame.
    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Audio extrahieren**

Aspose.Slides für .NET ermöglicht das Extrahieren des in Folienübergängen verwendeten Sounds. Zum Beispiel können Sie den Sound einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie sich die Referenz der betreffenden Folie über deren Index.
3. Greifen Sie auf die Folienübergänge der Folie zu.
4. Extrahieren Sie den Sound als Byte‑Daten.

Dieses C#‑Beispiel zeigt, wie der in einer Folie verwendete Sound extrahiert wird:

```c#
string presName = "AudioSlide.pptx";

// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation(presName);

// Greift auf die Folie zu
ISlide slide = pres.Slides[0];

// Holt die Folienübergangseffekte für die Folie
ISlideShowTransition transition = slide.SlideShowTransition;

//Extrahiert den Sound in ein Byte-Array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**Kann ich dieselbe Audiodatei in mehreren Folien wiederverwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur gemeinsamen [audio collection](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/audios/) der Präsentation hinzu und erstellen Sie weitere Audio‑Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird das Medien‑Daten doppelt vermieden und die Präsentationsgröße bleibt kontrollierbar.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Bei einem verknüpften Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/linkpathlong/) so, dass er auf die neue Datei verweist. Für einen eingebetteten Sound tauschen Sie das [embedded audio](https://reference.aspose.com/slides/de/net/aspose.slides/audioframe/embeddedaudio/)‑Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/audios/) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Ändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Das Trimmen passt nur die Wiedergabegrenzen an. Die ursprünglichen Audiodaten bleiben unverändert und über das eingebettete Audio bzw. die Audio‑Collection der Präsentation weiterhin zugänglich.