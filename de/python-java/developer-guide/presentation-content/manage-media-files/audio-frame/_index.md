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

Dieser Artikel erklärt, wie man mit Audio-Frames in Aspose.Slides arbeitet. Er zeigt, wie man eingebettete Audiodateien zu Folien hinzufügt, das Miniaturbild des Audio-Frames anpasst, Wiedergabeoptionen wie Lautstärke, Schleifen, Ausblenden, Trimmen und Fade-Dauern konfiguriert und Audiodaten, die in Folienpräsentationsübergängen verwendet werden, extrahiert.

## **Audio-Frames erstellen**

Aspose.Slides for Python via Java ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in den Folien als Audio-Frames eingebettet. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.
2. Rufen Sie über den Index die Referenz einer Folie ab.
3. Lesen Sie die Audiodatei, die Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [setPlayMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setPlayMode) und [setVolume](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setVolume), die vom [AudioFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/) Objekt bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieser Python-Code zeigt, wie Sie einen eingebetteten Audio-Frame zu einer Folie hinzufügen:

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

## **Miniaturbild des Audio-Frames ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, erscheint das Audio als Frame mit einem Standard‑Standardbild (siehe das Bild im Abschnitt unten). Sie können das Vorschau‑Bild des Audio‑Frames ändern (Ihr bevorzugtes Bild festlegen).

Dieser Python-Code zeigt, wie Sie das Miniaturbild oder das Vorschau‑Bild eines Audio‑Frames ändern:

```python
from pathlib import Path

import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpime.JArray(jpime.JByte)(audio_data)
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

## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides for Python via Java ermöglicht das Ändern von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Sie können beispielsweise die Lautstärke eines Audios anpassen, das Audio in einer Schleife abspielen oder das Audiosymbol ausblenden.

Das **Audio Options**‑Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/) Eigenschaften entsprechen:

- **Start** Dropdown‑Liste entspricht der [setPlayMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setPlayMode) Methode
- **Volume** entspricht der [setVolume](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setVolume) Methode
- **Play Across Slides** entspricht der [setPlayAcrossSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) Methode
- **Loop until Stopped** entspricht der [setPlayLoopMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setPlayLoopMode) Methode
- **Hide During Show** entspricht der [setHideAtShowing](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setHideAtShowing) Methode
- **Rewind after Playing** entspricht der [setRewindAudio](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setRewindAudio) Methode

PowerPoint **Editing**‑Optionen, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/) Eigenschaften entsprechen:

- **Fade In** entspricht der [setFadeInDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setFadeInDuration) Methode 
- **Fade Out** entspricht der [setFadeOutDuration](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setFadeOutDuration) Methode 
- **Trim Audio Start Time** entspricht der [setTrimFromStart](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setTrimFromStart) Methode 
- **Trim Audio End Time** Wert entspricht der Audiodauer minus dem Wert der [setTrimFromEnd](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setTrimFromEnd) Methode

Die PowerPoint **Volume control** im Audiosteuerungsfeld entspricht der [setVolumeValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setVolumeValue) Methode. Sie ermöglicht das Ändern der Lautstärke des Audios als Prozentsatz.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. Erstellen Sie ([Create](#create-audio-frames)) oder holen Sie den Audio-Frame.
2. Setzen Sie neue Werte für die Audio-Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint‑Datei.

Dieser Python-Code demonstriert einen Vorgang, bei dem die Optionen eines Audios angepasst werden:

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
        # Bei Klick abspielen bei niedriger Lautstärke, über Folien hinweg, ohne Schleife.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Den Frame während der Bildschirmpräsentation ausblenden und nach dem Abspielen zurückspulen.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Dieses Python-Beispiel zeigt, wie ein neuer Audio-Frame mit eingebettetem Audio hinzugefügt, getrimmt und die Fade‑Dauern eingestellt werden:

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

    # Schneiden Sie 1,5 Sekunden vom Anfang und 2 Sekunden vom Ende ab.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Setzen Sie Fade-in auf 200 ms und Fade-out auf 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das folgende Codebeispiel zeigt, wie ein Audio-Frame mit eingebettetem Audio abgerufen und seine Lautstärke auf 85 % gesetzt wird:

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

## **Audio-Untertitel verwalten**

Aspose.Slides ermöglicht das Hinzufügen von Untertiteln zu einem Audio-Frame über die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#getCaptionTracks). Diese Methode gibt eine [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/) zurück, mit der Sie WebVTT-Untertitelspuren hinzufügen, durch vorhandene Spuren iterieren und sie bei Bedarf entfernen können.

### **Audio-Untertitel hinzufügen**

Verwenden Sie die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#getCaptionTracks), um einer Audiodatei ein oder mehrere Untertitelspuren anzuhängen. Im folgenden Beispiel wird einer Folie eine Audiodatei hinzugefügt und anschließend eine neue Untertitelspur aus einer `.vtt`‑Datei geladen.

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

    # Füge eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Audio-Untertitel extrahieren**

Sie können durch die dem Audio-Frame zugeordneten Untertitelspuren iterieren und sie als `.vtt`‑Dateien speichern. Jede Untertitelspur stellt ihre Binärdaten und eine eindeutige Kennung zur Verfügung, die beim Exportieren der Untertitel verwendet werden kann.

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
                # Speichere die Untertitelspur als .vtt-Datei.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Audio-Untertitel entfernen**

Um Untertitel aus einem Audio-Frame zu entfernen, verwenden Sie die von [CaptionsCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/) bereitgestellten Methoden, wie [clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/de/python-java/aspose.slides/captionscollection/#removeAt). Das folgende Beispiel entfernt alle Untertitelspuren aus einem Audio-Frame.

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

Aspose.Slides for Python via Java ermöglicht das Extrahieren des in Folienübergängen verwendeten Sounds. Beispielsweise können Sie den Sound einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die das Audio enthält.
2. Rufen Sie über den Index die Referenz der entsprechenden Folie ab.
3. Greifen Sie auf die [slideshow transitions](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie zu.
4. Extrahieren Sie den Sound als Byte‑Daten.

Dieser Python-Code zeigt, wie Sie das in einer Folie verwendete Audio extrahieren:

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

Ja. Fügen Sie das Audio einmal zur geteilten [audio collection](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getAudios) der Präsentation hinzu und erstellen Sie weitere Audio-Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird eine Duplizierung der Mediendaten vermieden und die Größe der Präsentation bleibt kontrollierbar.

**Kann ich den Sound in einem bestehenden Audio-Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verlinkten Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setLinkPathLong), damit er auf die neue Datei verweist. Für ein eingebettetes Audio ersetzen Sie das [embedded audio](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/#setEmbeddedAudio) Objekt durch ein anderes aus der [audio collection](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getAudios) der Präsentation. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Verändert das Trimmen die im Präsentationsdokument gespeicherten Audiodaten?**

Nein. Das Trimmen passt nur die Wiedergabebereiche an. Die ursprünglichen Audiodaten bleiben unverändert und sind über das eingebettete Audio oder die [audio collection](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getAudios) der Präsentation zugänglich.