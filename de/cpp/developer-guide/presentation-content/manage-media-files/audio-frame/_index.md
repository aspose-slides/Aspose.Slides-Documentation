---
title: Audio‑Frames in Präsentationen mit C++ verwalten
linktitle: Audio‑Frame
type: docs
weight: 10
url: /de/cpp/audio-frame/
keywords:
- Audio
- Audio-Frame
- Miniaturbild
- Audio hinzufügen
- Audioeigenschaften
- Audio-Optionen
- Audio extrahieren
- C++
- Aspose.Slides
description: "Audio in Folien einbetten, das Audiosymbol ändern, die Wiedergabe konfigurieren, WebVTT-Untertitel verwalten und Folienübergangstöne mit Aspose.Slides für C++ extrahieren."
---
## **Übersicht**

Ein Audio‑Frame ermöglicht das Abspielen eines Tons auf einer Folie. Mit Aspose.Slides für C++ können Sie einen Audioclip einbetten, das Bild auswählen, das ihn darstellt, die Wiedergabe anpassen und Untertitel anhängen. Sie können auch einen einer Folienübergang zugewiesenen Ton abrufen.

## **Audio‑Frames erstellen**

Verwenden Sie [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) um einen lokalen Audioclip auf der ersten Folie einzubetten. Die ersten beiden Koordinaten positionieren den Frame auf der Folie, und die nächsten beiden Werte setzen Breite und Höhe, alles in Punkten. Dieses Beispiel ruft [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) auf, um den Clip automatisch zu starten, und ruft [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) auf, um die laute Voreinstellung auszuwählen.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

presentation->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Audio‑Frame‑Miniatur ändern**

Standardmäßig zeigt ein Audio‑Frame ein Lautsprechersymbol an. Um eine benutzerdefinierte Miniatur anzuzeigen, fügen Sie der Präsentation ein Bild mit [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) hinzu und setzen es mit [set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) als Bild des Frames. Das Beispiel verwendet ein JPEG als Miniatur für einen eingebetteten Audioclip.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageStream = File::OpenRead(u"eagle.jpeg");
auto thumbnail = presentation->get_Images()->AddImage(imageStream);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

## **Audio‑Wiedergabeoptionen ändern**

Die **Audio‑Optionen**‑Steuerelemente von PowerPoint bestimmen, wann ein Clip startet, wie laut er klingt und wie er sich während einer Bildschirmpräsentation verhält.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint control | Aspose.Slides for C++ method |
| --- | --- |
| Start | [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) |
| Volume preset | [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) |
| Play Across Slides | [set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playacrossslides/) |
| Loop until Stopped | [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playloopmode/) |
| Hide During Show | [set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_hideatshowing/) |
| Rewind after Playing | [set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_rewindaudio/) |
| Fade In | [set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeinduration/) |
| Fade Out | [set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeoutduration/) |
| Trim Audio start time | [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) |
| Trim Audio end time | [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) |
| Volume slider | [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) |

Das Beispiel findet den ersten Audio‑Frame auf der ersten Folie, ruft [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) auf, um die Wiedergabe bei einem Klick zu starten, und wählt die niedrige Lautstärke‑Voreinstellung. Der Clip wird über Folien hinweg fortgesetzt, wobei die Schleife deaktiviert ist. Das Symbol bleibt während der Darstellung ausgeblendet, und der Clip wird nach der Wiedergabe zurückgespult.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);
    audioFrame->set_Volume(AudioVolumeMode::Low);
    audioFrame->set_PlayAcrossSlides(true);
    audioFrame->set_PlayLoopMode(false);
    audioFrame->set_HideAtShowing(true);
    audioFrame->set_RewindAudio(true);

    presentation->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

Für einen Clip, der länger als 3,5 Sekunden ist, überspringt dieses Beispiel die ersten 1,5 Sekunden und die letzten 2 Sekunden. Das Argument von [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) gibt die Dauer an, die am Ende des Clips weggelassen werden soll. Um die in PowerPoint angezeigte Endzeit zu erhalten, ziehen Sie diesen Versatz von der Gesamtdauer des Clips ab. Der beschnittene Clip blendet über 200 Millisekunden ein und über 500 Millisekunden aus. Alle vier Setter erwarten Werte in Millisekunden.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame->set_TrimFromStart(1500);
audioFrame->set_TrimFromEnd(2000);
audioFrame->set_FadeInDuration(200);
audioFrame->set_FadeOutDuration(500);

presentation->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
```

Um die Wiedergabelautstärke auf einen bestimmten Prozentsatz zu setzen, verwenden Sie [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/). Dieses Beispiel setzt den ersten Audio‑Frame auf der ersten Folie auf 85 %.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_VolumeValue(85);

    presentation->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

## **Audio‑Untertitel verwalten**

Jeder Audio‑Frame stellt seine Untertitelsammlung über [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_captiontracks/) bereit. Verwenden Sie sie, um WebVTT‑Untertitel an den Clip anzuhängen, vorhandene Spuren zu exportieren oder zu entfernen.

### **Audio‑Untertitel hinzufügen**

Das Beispiel bettet einen Audioclip auf der ersten Folie ein und verwendet [ICaptionsCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/add/) , um eine lokale WebVTT‑Spur anzuhängen. Das erste Argument liefert die Spurbeschrift, das zweite identifiziert die Datei, die die zeitlich gesteuerten Untertitel enthält.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
```

### **Audio‑Untertitel extrahieren**

Dieses Beispiel exportiert jede an einen Audio‑Frame auf der ersten Folie angefügte Untertitelspur. Es schreibt die von [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_binarydata/) zurückgegebenen Bytes in eine WebVTT‑Datei und verwendet den von [get_CaptionId](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_captionid/) zurückgegebenen Wert als Dateinamen, sodass jede Spur eine separate Ausgabe hat.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto fileName = track->get_CaptionId().ToString() + u".vtt";
        File::WriteAllBytes(fileName, track->get_BinaryData());
    }
}
```

### **Audio‑Untertitel entfernen**

Verwenden Sie [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/remove/) oder [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/removeat/) , um eine einzelne Spur zu löschen. Das Beispiel nutzt [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/clear/) , um alle Untertitel vom ersten Audio‑Frame auf der ersten Folie zu entfernen, wobei der Clip erhalten bleibt.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->get_CaptionTracks()->Clear();

    presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

### **Eine Zeile in Audio‑Untertiteln finden**

Um eine Zeile in den Audio‑Untertiteln auf der ersten Folie zu finden, rufen Sie [get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) für jede Spur auf, um deren WebVTT‑Text im Speicher zu lesen. In einem Klartext‑WebVTT‑Cue enthält die Zeitlinie `-->`, die Untertitelzeilen folgen ihr, und eine leere Zeile beendet den Cue. Dieses Beispiel gibt die Spurbeschrift und jede Untertitelzeile aus, die „café“ enthält.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto reader = MakeObject<StringReader>(track->get_DataAsString());
        auto inCue = false;
        for (auto line = reader->ReadLine(); !line.IsNull(); line = reader->ReadLine())
        {
            if (line.get_Length() == 0)
                inCue = false;
            else if (line.Contains(u"-->"))
                inCue = true;
            else if (inCue && line.IndexOf(u"caf\u00e9", StringComparison::OrdinalIgnoreCase) >= 0)
                Console::WriteLine(track->get_Label() + u": " + line);
        }
    }
}
```

## **Audio extrahieren**

Ein Folienübergang kann einen eigenen Ton haben. Um ihn abzurufen, rufen Sie [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_sound/) auf dem Übergang auf. Das Beispiel holt die Audiodaten mit [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) und gibt die Anzahl der Bytes aus. Hat die erste Folie keinen Übergangston, wird stattdessen eine Meldung ausgegeben.

```cpp
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioSlide.pptx");
auto slide = presentation->get_Slide(0);

auto sound = slide->get_SlideShowTransition()->get_Sound();
if (sound)
{
    auto audioData = sound->get_BinaryData();
    Console::WriteLine(u"Transition sound: {0} bytes.", audioData->get_Length());
}
else
{
    Console::WriteLine(u"The first slide has no transition sound.");
}
```

## **FAQ**

**Kann ich denselben Audioclip auf mehreren Folien wiederverwenden, ohne ihn zu duplizieren?**

Ja. Fügen Sie den Clip einmal zur [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) der Präsentation hinzu und übergeben Sie dasselbe Audio‑Objekt an [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) für jede Folie.

**Kann ich den Ton in einem bestehenden Audio‑Frame ersetzen?**

Ja. Für einen verknüpften Ton rufen Sie [set_LinkPathLong](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_linkpathlong/) mit dem Pfad zur Ersatzdatei auf. Für einen eingebetteten Ton übergeben Sie einen anderen Clip aus der Audio‑Sammlung der Präsentation an [set_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_embeddedaudio/). Beide Vorgehensweisen erhalten den bestehenden Frame.

**Ändert das Trimmen die im Dokument gespeicherten Audiodaten?**

Nein. [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) und [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) setzen nur die Wiedergabebereiche. Sie können den vollständigen Clip weiterhin über [get_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_embeddedaudio/) abrufen.