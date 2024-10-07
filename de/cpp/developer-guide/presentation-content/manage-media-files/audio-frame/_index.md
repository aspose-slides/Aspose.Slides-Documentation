---
title: Audio-Frame
type: docs
weight: 10
url: /cpp/audio-frame/
keywords: "Audio hinzufügen, Audio-Frame, Audio-Eigenschaften, Audio extrahieren, C++, CPP, Aspose.Slides für C++"
description: "Audio zu einer PowerPoint-Präsentation in C++ hinzufügen"
---

## **Audio-Frame erstellen**
Aspose.Slides für C++ ermöglicht es, Audiodateien in Folien einzufügen. Die Audiodateien werden als Audio-Frames in die Folien eingebettet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.
3. Laden Sie den Audiodateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame) Objekt bereitgestellt werden.
6. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie einen eingebetteten Audio-Frame zu einer Folie hinzufügen:

``` cpp
// Erstellt eine Präsentation-Instanz, die eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>();

// Holt die erste Folie
auto sld = pres->get_Slides()->idx_get(0);

// Lädt die wav-Audiodatei in den Stream
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Fügt den Audio-Frame hinzu
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Setzt den Wiedergabemodus und die Lautstärke des Audios
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Schreibt die PowerPoint-Datei auf die Festplatte
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Thumbnail des Audio-Frames ändern**

Wenn Sie eine Audiodatei zu einer Präsentation hinzufügen, erscheint die Audiodatei als Frame mit einem standardmäßigen Standardbild (siehe das Bild im Abschnitt unten). Sie können das Thumbnail des Audio-Frames ändern (setzen Sie Ihr bevorzugtes Bild).

Dieser C++-Code zeigt Ihnen, wie Sie das Thumbnail oder das Vorschau-Bild eines Audio-Frames ändern:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Fügt dem Slide einen Audio-Frame mit einer bestimmten Position und Größe hinzu.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Fügt ein Bild zu den Präsentationsressourcen hinzu.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Setzt das Bild für den Audio-Frame.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Speichert die modifizierte Präsentation auf der Festplatte
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Audio-Wiedergabeeinstellungen ändern**

Aspose.Slides für C++ ermöglicht es Ihnen, Optionen zu ändern, die die Wiedergabe oder Eigenschaften eines Audios steuern. Zum Beispiel können Sie die Lautstärke eines Audios anpassen, das Audio auf Schleife setzen oder sogar das Audio-Symbol ausblenden.

Das **Audio-Optionen** Feld in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint-Audiooptionen, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame) Methoden entsprechen:
- Audiooptionen **Start** Dropdown-Liste entspricht der [AudioFrame::get_PlayMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a5379c1a9c1166234d674b32413215a2b) Methode 
- Audiooptionen **Lautstärke** entsprechen der [AudioFrame::get_Volume()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#af06a3176684b6a13326bc8526747d9f3) Methode 
- Audiooptionen **Auf Folien wiedergeben** entsprechen der [AudioFrame::get_PlayAcrossSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a3c6ffc45b319ce127384fc37e188f7b0) Methode 
- Audiooptionen **Schleife bis gestoppt** entsprechen der [AudioFrame::get_PlayLoopMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a99b5b9cc650e93eba813bd8b2371315b) Methode 
- Audiooptionen **Ausblenden während der Präsentation** entsprechen der [AudioFrame::get_HideAtShowing()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#abd008322e6a3d7d06bed527e329a9082) Methode 
- Audiooptionen **Zurückspulen nach der Wiedergabe** entsprechen der [AudioFrame::get_RewindAudio()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a4900e1df6477db16e8cdd859ad54e637) Methode 

So ändern Sie die Audio-Wiedergabeeinstellungen:

1. [Erstellen](#creating-audio-frame) oder holen Sie sich den Audio-Frame.
2. Setzen Sie neue Werte für die Audio-Frame-Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die modifizierte PowerPoint-Datei.

Dieser C++-Code demonstriert eine Operation, bei der die Optionen eines Audios angepasst werden:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Holt eine Form
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Wandelt die Form in eine AudioFrame-Form um
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Setzt den Wiedergabemodus auf Wiedergabe bei Klick
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Setzt die Lautstärke auf Niedrig
audioFrame->set_Volume(AudioVolumeMode::Low);

// Setzt das Audio auf Wiedergabe über Folien
audioFrame->set_PlayAcrossSlides(true);

// Deaktiviert die Schleife für das Audio
audioFrame->set_PlayLoopMode(false);

// Blendet den AudioFrame während der Präsentation aus
audioFrame->set_HideAtShowing(true);

// Spult das Audio nach der Wiedergabe zurück auf den Anfang
audioFrame->set_RewindAudio(true);

// Speichert die PowerPoint-Datei auf der Festplatte
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

## **Audio extrahieren**
Aspose.Slides für .NET ermöglicht es Ihnen, den Ton, der in Folienübergängen verwendet wird, zu extrahieren. Zum Beispiel können Sie den Ton extrahieren, der in einer bestimmten Folie verwendet wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie sich einen Verweis auf die relevante Folie über ihren Index.
3. Greifen Sie auf die Folienübergänge für die Folie zu.
4. Extrahieren Sie den Ton in Byte-Daten.

Dieser C++-Code zeigt Ihnen, wie Sie das in einer Folie verwendete Audio extrahieren:

``` cpp
String presName = u"AudioSlide.pptx";

// Erstellt eine Präsentation-Instanz, die eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>(presName);

// Greift auf die gewünschte Folie zu
auto slide = pres->get_Slides()->idx_get(0);

// Holt sich die Übergangseffekte für die Folie
auto transition = slide->get_SlideShowTransition();

// Extrahiert den Ton in ein Byte-Array
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Länge: ") + audio->get_Length());
```