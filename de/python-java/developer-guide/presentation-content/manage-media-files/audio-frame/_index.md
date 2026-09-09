---
title: Audio in Präsentationen mit Python verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/python-java/audio-frame/
keywords:
- Audio
- Audio-Frame
- Miniaturbild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- Python
- Aspose.Slides
description: "Erstellen und steuern Sie Audio-Frames in Aspose.Slides für Python via Java – Codebeispiele zum Einbetten, Trimmen, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Audio‑Frames in Aspose.Slides arbeitet. Er zeigt, wie man eingebettete Audiodateien zu Folien hinzufügt, das Miniaturbild des Audio‑Frames anpasst, Wiedergabeoptionen wie Lautstärke, Schleifen, Ausblenden, Trimmen und Einblendungs‑Dauern konfiguriert und Audiodaten extrahiert, die in Folien‑Show‑Übergängen verwendet werden.

## **Audio‑Frames erstellen**

Aspose.Slides für Python via Java ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden als Audio‑Frames in die Folien eingebettet. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
2. Rufen Sie eine Referenz auf eine Folie anhand ihres Index ab.
3. Laden Sie die Audiodatei, die Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio‑Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Verwenden Sie die von dem Objekt [AudioFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/) bereitgestellten Methoden [setPlayMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setPlayMode) und [setVolume](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setVolume).
6. Speichern Sie die geänderte Präsentation.

Dieser Python‑Code zeigt, wie Sie einen eingebetteten Audio‑Frame zu einer Folie hinzufügen:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Audio‑Frame‑Miniaturbild ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, erscheint das Audio als Frame mit einem standardmäßigen Standardbild (siehe das Bild im nachfolgenden Abschnitt). Sie können das Vorschau‑Bild des Audio‑Frames durch ein Bild Ihrer Wahl ersetzen.

Dieser Python‑Code zeigt, wie Sie das Miniatur‑ bzw. Vorschau‑Bild eines Audio‑Frames ändern:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Audio‑Wiedergabeoptionen ändern**

Aspose.Slides für Python via Java ermöglicht das Ändern von Optionen, die die Audiowiedergabe oder -eigenschaften steuern. Beispielsweise können Sie die Lautstärke anpassen, das Audio in einer Schleife wiedergeben oder das Audiosymbol sogar ausblenden.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio‑Optionen**, die den Aspose.Slides‑[AudioFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/)‑Eigenschaften entsprechen:

- **Start**‑Dropdown‑Liste entspricht der Methode [setPlayMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** entspricht der Methode [setVolume](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** entspricht der Methode [setPlayAcrossSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** entspricht der Methode [setPlayLoopMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** entspricht der Methode [setHideAtShowing](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** entspricht der Methode [setRewindAudio](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setRewindAudio)

PowerPoint‑**Bearbeitungs**‑Optionen, die den Aspose.Slides‑[AudioFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/)‑Eigenschaften entsprechen:

- **Fade In** entspricht der Methode [setFadeInDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** entspricht der Methode [setFadeOutDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** entspricht der Methode [setTrimFromStart](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time**‑Wert entspricht der Audiodauer minus dem Wert, der durch die Methode [setTrimFromEnd](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setTrimFromEnd) festgelegt wird

Die PowerPoint‑**Lautstärkeregelung** im Audiosteuerungs‑Panel entspricht der Methode [setVolumeValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setVolumeValue). Sie ermöglicht das Ändern der Lautstärke als Prozentsatz.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. [Create](#create-audio-frames) oder holen Sie den Audio‑Frame.
2. Setzen Sie neue Werte für die Audio‑Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint‑Datei.

Dieser Python‑Code demonstriert einen Vorgang, bei dem Audio‑Optionen angepasst werden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Beim Klicken mit niedriger Lautstärke wiedergeben, über Folien hinweg, ohne Schleife.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Den Frame während der Bildschirmanzeige ausblenden und nach der Wiedergabe zurückspulen.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Dieses Python‑Beispiel zeigt, wie man einen neuen Audio‑Frame mit eingebettetem Audio hinzufügt, ihn trimmt und die Einblendungs‑Dauern festlegt:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # 1,5 Sekunden vom Anfang und 2 Sekunden vom Ende trimmen.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Fade‑In auf 200 ms und Fade‑Out auf 500 ms setzen.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das folgende Codebeispiel zeigt, wie man einen Audio‑Frame mit eingebettetem Audio abruft und seine Lautstärke auf 85 % setzt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Audio‑Untertitel verwalten**

Aspose.Slides ermöglicht das Hinzufügen von geschlossenen Untertiteln zu einem Audio‑Frame über die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#getCaptionTracks). Diese Methode gibt eine [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/) zurück, mit der Sie WebVTT‑Untertitelspuren hinzufügen, durch vorhandene Spuren iterieren und sie bei Bedarf entfernen können.

**Audio‑Untertitel hinzufügen**

Verwenden Sie die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#getCaptionTracks), um einer Audiodatei ein oder mehrere Untertitel‑Spuren hinzuzufügen. Im folgenden Beispiel wird einer Folie eine Audiodatei hinzugefügt und anschließend eine neue Untertitel‑Spur aus einer `.vtt`‑Datei geladen.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Neue Untertitelspur aus einer WebVTT-Datei hinzufügen.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Audio‑Untertitel extrahieren**

Sie können durch die mit einem Audio‑Frame verbundenen Untertitel‑Spuren iterieren und sie als `.vtt`‑Dateien speichern. Jede Untertitel‑Spur gibt ihre Binärdaten und eine eindeutige Kennung frei, die beim Exportieren der Untertitel verwendet werden kann.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Die Untertitelspur als .vtt-Datei speichern.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Audio‑Untertitel entfernen**

Um Untertitel aus einem Audio‑Frame zu entfernen, verwenden Sie die von [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/) bereitgestellten Methoden, wie [clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#removeAt). Das folgende Beispiel entfernt alle Untertitel‑Spuren aus einem Audio‑Frame.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Audio extrahieren**

Aspose.Slides für Python via Java ermöglicht das Extrahieren des in Folien‑Show‑Übergängen verwendeten Sounds. Zum Beispiel können Sie den Sound, der in einer bestimmten Folie verwendet wird, extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie sich eine Referenz auf die entsprechende Folie anhand ihres Index.
3. Greifen Sie auf die [slideshow transitions](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie zu.
4. Extrahieren Sie den Sound als Byte‑Daten.

Dieser Python‑Code zeigt, wie Sie das in einer Folie verwendete Audio extrahieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich dieselbe Audiodatei in mehreren Folien wiederverwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur geteilten [audio collection](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getAudios) der Präsentation hinzu und erstellen Sie weitere Audio‑Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird das Duplizieren von Mediendaten vermieden und die Präsentationsgröße bleibt überschaubar.

**Kann ich den Sound in einem vorhandenen Audio‑Frame ersetzen, ohne die Form erneut zu erstellen?**

Ja. Bei einem verknüpften Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setLinkPathLong), sodass er auf die neue Datei zeigt. Bei einem eingebetteten Sound tauschen Sie das [embedded audio](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setEmbeddedAudio)-Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getAudios) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Ändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Trimmen passt nur die Wiedergabebereiche an. Die originalen Audiodaten bleiben unverändert und sind über das eingebettete Audio oder die Audio‑Collection der Präsentation zugänglich.