---
title: "Audio in Präsentationen mit C++ verwalten"
linktitle: "Audio-Frame"
type: docs
weight: 10
url: /de/cpp/audio-frame/
keywords:
- Audio
- Audio-Frame
- Miniaturbild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- C++
- Aspose.Slides
description: "Audio-Frames in Aspose.Slides für C++ erstellen und steuern – Codebeispiele zum Einbetten, Trimmen, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---
## **Audio‑Frames erstellen**

Aspose.Slides für C++ ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in den Folien als Audio‑Frames eingebettet. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation) .
2. Rufen Sie eine Referenz auf eine Folie über ihren Index ab.
3. Laden Sie den Audiodateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio‑Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/de/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) und `Volume`, die vom Objekt [IAudioFrame](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_audio_frame) bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code zeigt, wie Sie einen eingebetteten Audio‑Frame zu einer Folie hinzufügen:

``` cpp
// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>();

// Ruft die erste Folie ab
auto sld = pres->get_Slides()->idx_get(0);

// Lädt die wav-Audiodatei in einen Stream
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Fügt den Audio-Frame hinzu
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Setzt den Wiedergabemodus und die Lautstärke des Audios
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Speichert die PowerPoint-Datei auf dem Datenträger
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Audio‑Frame‑Miniaturbild ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, wird das Audio als Frame mit einem standardmäßigen Standardbild angezeigt (siehe das Bild im folgenden Abschnitt). Sie können das Miniaturbild des Audio‑Frames ändern (ein bevorzugtes Bild festlegen).

Dieser C++‑Code zeigt, wie Sie das Miniatur‑ bzw. Vorschaubild eines Audio‑Frames ändern:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Fügt der Folie einen Audio-Frame mit angegebenen Position und Größe hinzu.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Fügt ein Bild zu den Präsentationsressourcen hinzu.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Setzt das Bild für den Audio-Frame.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
// Speichert die geänderte Präsentation auf dem Datenträger
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Audio‑Wiedergabe‑Optionen ändern**

Aspose.Slides für C++ ermöglicht das Ändern von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Sie können beispielsweise die Lautstärke anpassen, das Audio in einer Schleife abspielen oder das Audiosymbol sogar ausblenden.

Das **Audio Options**‑Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, die den Aspose.Slides‑Methoden [AudioFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/) entsprechen:

- **Start**‑Dropdown‑Liste entspricht der Methode [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_playmode/) 
- **Volume** entspricht der Methode [AudioFrame::set_Volume](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_volume/) 
- **Play Across Slides** entspricht der Methode [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_playacrossslides/) 
- **Loop until Stopped** entspricht der Methode [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_playloopmode/) 
- **Hide During Show** entspricht der Methode [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_hideatshowing/) 
- **Rewind after Playing** entspricht der Methode [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_rewindaudio/) method 

PowerPoint **Editing**‑Optionen, die den Aspose.Slides‑Eigenschaften [AudioFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/) entsprechen:

- **Fade In** entspricht der Methode [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_fadeinduration/) 
- **Fade Out** entspricht der Methode [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_fadeoutduration/) 
- **Trim Audio Start Time** entspricht der Methode [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_trimfromstart/) 
- **Trim Audio End Time**‑Wert entspricht der Audiodauer minus dem Wert der Methode [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_trimfromend/) 

Der PowerPoint-**Volume controll** auf dem Audiosteuerungsfeld entspricht der Methode [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_volumevalue/) . Er ermöglicht das Ändern der Lautstärke des Audios als Prozentsatz.

So ändern Sie die Audio‑Wiedergabe‑Optionen:

1. [Create](#creating-audio-frame) oder holen Sie den Audio‑Frame.
2. Setzen Sie neue Werte für die Audio‑Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint‑Datei.

Dieser C++‑Code demonstriert einen Vorgang, bei dem die Optionen eines Audios angepasst werden:

``` cpp
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Ruft eine Form ab
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Castet die Form zu einem AudioFrame-Shape
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Setzt den Play-Modus auf Klick
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Setzt die Lautstärke auf niedrig
audioFrame->set_Volume(AudioVolumeMode::Low);

// Setzt das Audio so, dass es über Folien hinweg abgespielt wird
audioFrame->set_PlayAcrossSlides(true);

// Deaktiviert die Schleife für das Audio
audioFrame->set_PlayLoopMode(false);

// Versteckt den Audio-Frame während der Präsentation
audioFrame->set_HideAtShowing(true);

// Spult das Audio nach dem Abspielen zum Anfang zurück
audioFrame->set_RewindAudio(true);

// Speichert die PowerPoint-Datei auf dem Datenträger
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Dieses C++‑Beispiel zeigt, wie man einen neuen Audio‑Frame mit eingebettetem Audio hinzufügt, ihn trimmt und die Fade‑Dauern festlegt:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

Das folgende Codebeispiel zeigt, wie man einen Audio‑Frame mit eingebettetem Audio abruft und dessen Lautstärke auf 85 % setzt:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Ruft ein Audio-Frame-Shape ab
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Setzt die Lautstärke des Audios auf 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Audio‑Untertitel verwalten**

Aspose.Slides ermöglicht das Hinzufügen von Untertiteln zu einem Audio‑Frame über die Methode [get_CaptionTracks](https://reference.aspose.com/slides/de/cpp/aspose.slides/iaudioframe/get_captiontracks/) . Diese Methode gibt eine [ICaptionsCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/) zurück, mit der Sie WebVTT‑Untertitelspuren hinzufügen, durch vorhandene Spuren iterieren und sie bei Bedarf entfernen können.

### **Audio‑Untertitel hinzufügen**

Verwenden Sie die Methode [get_CaptionTracks](https://reference.aspose.com/slides/de/cpp/aspose.slides/iaudioframe/get_captiontracks/) , um einer Audio‑Frame‑Instanz eine oder mehrere Untertitelspuren anzuhängen. Im folgenden Beispiel wird einer Folie eine Audiodatei hinzugefügt und anschließend eine neue Untertitelspur aus einer `.vtt`‑Datei geladen.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Audio‑Untertitel extrahieren**

Sie können durch die Untertitelspuren eines Audio‑Frames iterieren und sie als `.vtt`‑Dateien speichern. Jede Untertitelspur stellt ihre Binärdaten und ihre eindeutige Kennung bereit, die beim Exportieren der Untertitel verwendet werden können.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // Speichern Sie jede Untertitelspur als .vtt-Datei.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

### **Audio‑Untertitel entfernen**

Um Untertitel aus einem Audio‑Frame zu entfernen, verwenden Sie die Methoden der [ICaptionsCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/) , wie [Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/remove/) oder [RemoveAt](https://reference.aspose.com/slides/de/cpp/aspose.slides/icaptionscollection/removeat/). Das folgende Beispiel entfernt alle Untertitelspuren aus einem Audio‑Frame.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Entfernt alle Untertitelspuren aus dem Audio-Frame.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Audio extrahieren**

Aspose.Slides ermöglicht das Extrahieren des in Folien‑Übergängen verwendeten Sounds. Beispielsweise können Sie den Sound einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation) und laden Sie die Präsentation, die das Audio enthält.
2. Rufen Sie die Referenz der relevanten Folie über ihren Index ab.
3. Greifen Sie auf die Folienübergänge der Folie zu.
4. Extrahieren Sie den Sound als Byte‑Daten.

Dieser C++‑Code zeigt, wie Sie das in einer Folie verwendete Audio extrahieren:

``` cpp
String presName = u"AudioSlide.pptx";

// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>(presName);

// Greift auf die gewünschte Folie zu
auto slide = pres->get_Slides()->idx_get(0);

// Ruft die Folienübergangseffekte für die Folie ab
auto transition = slide->get_SlideShowTransition();

// Extrahiert den Sound als Byte-Array
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**Kann ich dasselbe Audio-Asset in mehreren Folien wiederverwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur freigegebenen [audio collection](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_audios/) der Präsentation hinzu und erzeugen Sie weitere Audio‑Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird das Duplizieren von Mediendaten vermieden und die Präsentationsgröße bleibt überschaubar.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_linkpathlong/) so, dass er auf die neue Datei zeigt. Für ein eingebettetes Audio ersetzen Sie das [embedded audio](https://reference.aspose.com/slides/de/cpp/aspose.slides/audioframe/set_embeddedaudio/)‑Objekt durch ein anderes aus der [audio collection](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_audios/) der Präsentation. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Verändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Das Trimmen passt nur die Wiedergabegrenzen an. Die ursprünglichen Audiodaten bleiben unverändert und sind über das eingebettete Audio oder die Audio‑Collection der Präsentation zugänglich.