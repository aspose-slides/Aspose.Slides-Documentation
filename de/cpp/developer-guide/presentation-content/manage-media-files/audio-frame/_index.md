---
title: Audio in Präsentationen mit C++ verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/cpp/audio-frame/
keywords:
- Audio
- Audio-Frame
- Vorschaubild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- C++
- Aspose.Slides
description: "Erstellen und steuern Sie Audio-Frames in Aspose.Slides für C++ – Codebeispiele zum Einbetten, Trimmen, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---

## **Audio‑Frames erstellen**

Aspose.Slides für C++ ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in den Folien als Audio‑Frames eingebettet. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Laden Sie den Audiostream, den Sie in die Folie einbetten möchten.  
4. Fügen Sie den eingebetteten Audio‑Frame (der die Audiodatei enthält) zur Folie hinzu.  
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame) Objekt bereitgestellt werden.  
6. Speichern Sie die geänderte Präsentation.  

``` cpp
// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>();

// Holt die erste Folie
auto sld = pres->get_Slides()->idx_get(0);

// Lädt die wav-Audiodatei in einen Stream
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Fügt den Audio-Frame hinzu
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Setzt den Wiedergabemodus und die Lautstärke des Audios
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Schreibt die PowerPoint-Datei auf die Festplatte
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```


## **Thumbnail des Audio‑Frames ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, wird das Audio als Frame mit einem standardmäßigen Standardbild angezeigt (siehe das Bild im nachfolgenden Abschnitt). Sie können die Miniatur des Audio‑Frames ändern (ein bevorzugtes Bild festlegen).  

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Fügt dem Folie einen Audio-Frame mit einer angegebenen Position und Größe hinzu.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Fügt ein Bild zu den Präsentationsressourcen hinzu.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Setzt das Bild für den Audio-Frame.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Speichert die geänderte Präsentation auf die Festplatte
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```



## **Audio‑Wiedergabeoptionen ändern**

Aspose.Slides für C++ ermöglicht es, Optionen zu ändern, die die Wiedergabe oder Eigenschaften eines Audios steuern. Beispielsweise können Sie die Lautstärke anpassen, das Audio schleifen lassen oder das Audiosymbol ausblenden.  

Das **Audio‑Options**‑Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio‑Options**, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/)‑Methoden entsprechen:

- **Start** Dropdown‑Liste entspricht der [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playmode/) Methode  
- **Volume** entspricht der [AudioFrame::set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volume/) Methode  
- **Play Across Slides** entspricht der [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playacrossslides/) Methode  
- **Loop until Stopped** entspricht der [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playloopmode/) Methode  
- **Hide During Show** entspricht der [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_hideatshowing/) Methode  
- **Rewind after Playing** entspricht der [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_rewindaudio/) Methode  

PowerPoint **Bearbeitungs**‑Optionen, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/)‑Eigenschaften entsprechen:

- **Fade In** entspricht der [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeinduration/) Methode  
- **Fade Out** entspricht der [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeoutduration/) Methode  
- **Trim Audio Start Time** entspricht der [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromstart/) Methode  
- **Trim Audio End Time** entspricht dem Audiolänge‑Minus‑Wert der [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromend/) Methode  

Der PowerPoint **Volume‑Regler** im Audiosteuerungsfeld entspricht der [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volumevalue/) Methode. Er ermöglicht das Ändern der Lautstärke in Prozent.  

So ändern Sie die Audio‑Wiedergabeoptionen:

1. **Erstellen** ([Create](#creating-audio-frame)) oder holen Sie den Audio‑Frame.  
2. Setzen Sie neue Werte für die Audio‑Frame‑Eigenschaften, die Sie anpassen möchten.  
3. Speichern Sie die geänderte PowerPoint‑Datei.  

``` cpp
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Holt eine Form
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Wandelt die Form in einen AudioFrame um
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Setzt den Wiedergabemodus auf Klick
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Setzt die Lautstärke auf Niedrig
audioFrame->set_Volume(AudioVolumeMode::Low);

// Setzt das Audio auf Wiedergabe über Folien hinweg
audioFrame->set_PlayAcrossSlides(true);

// Deaktiviert die Schleife für das Audio
audioFrame->set_PlayLoopMode(false);

// Versteckt den AudioFrame während der Präsentation
audioFrame->set_HideAtShowing(true);

// Spult das Audio nach der Wiedergabe zum Anfang zurück
audioFrame->set_RewindAudio(true);

// Speichert die PowerPoint-Datei auf die Festplatte
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```


Dieses C++‑Beispiel zeigt, wie ein neuer Audio‑Frame mit eingebettetem Audio hinzugefügt, zugeschnitten und die Einblend‑ bzw. Ausblendzeiten festgelegt werden:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Setzt den Trimm-Startversatz auf 1,5 Sekunden
audioFrame->set_TrimFromStart(1500);
// Setzt den Trimm-Endversatz auf 2 Sekunden
audioFrame->set_TrimFromEnd(2000);

// Setzt die Einblenddauer auf 200 ms
audioFrame->set_FadeInDuration(200);
// Setzt die Ausblenddauer auf 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


Der folgende Code demonstriert, wie ein Audio‑Frame mit eingebettetem Audio abgerufen und die Lautstärke auf 85 % gesetzt wird:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Holt ein Audio-Frame-Shape
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Setzt die Lautstärke des Audios auf 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


## **Audio extrahieren**

Aspose.Slides ermöglicht das Extrahieren des bei Folienübergängen verwendeten Sounds. Beispielsweise können Sie den Sound einer bestimmten Folie extrahieren.  

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse und laden Sie die Präsentation, die das Audio enthält.  
2. Rufen Sie die relevante Folie über ihren Index ab.  
3. Greifen Sie auf die Folienübergänge der Folie zu.  
4. Extrahieren Sie den Sound als Byte‑Daten.  

``` cpp
String presName = u"AudioSlide.pptx";

// Instanziert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>(presName);

// Greift auf die gewünschte Folie zu
auto slide = pres->get_Slides()->idx_get(0);

// Holt die Folienübergangseffekte für die Folie
auto transition = slide->get_SlideShowTransition();

// Extrahiert den Sound als Byte-Array
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```


## **FAQ**

**Kann ich dasselbe Audio‑Asset auf mehreren Folien verwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur geteilten [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) der Präsentation hinzu und erstellen Sie weitere Audio‑Frames, die auf dieses vorhandene Asset verweisen. So wird eine Duplizierung von Mediendaten vermieden und die Präsentationsgröße bleibt kontrollierbar.  

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_linkpathlong/) auf die neue Datei. Für einen eingebetteten Sound tauschen Sie das [embedded audio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_embeddedaudio/)‑Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.  

**Ändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Das Trimmen passt nur die Wiedergabegrenzen an. Die ursprünglichen Audiodaten bleiben unverändert und sind über das eingebettete Audio oder die Audio‑Collection der Präsentation weiterhin zugänglich.