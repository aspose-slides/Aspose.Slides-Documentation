---
title: Audio-Frames in Präsentationen mit Python verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/python-java/audio-frame/
keywords:
- Audio
- Audio-Frame
- Miniaturansicht
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- Python
- Aspose.Slides
description: "Audio in Folien einbetten, das Audiosymbol ändern, die Wiedergabe konfigurieren, WebVTT-Untertitel verwalten und Übergangstöne von Folien extrahieren mit Aspose.Slides für Python via Java."
---
## **Übersicht**

Ein Audio‑Frame ermöglicht das Abspielen eines Sounds auf einer Folie. Mit Aspose.Slides for Python via Java können Sie einen Audioclip einbetten, das Bild auswählen, das ihn repräsentiert, die Wiedergabe anpassen und Untertitel hinzufügen. Sie können außerdem einen einer Folienübergang zugeordneten Sound abrufen.

## **Audio‑Frames erstellen**

Fügen Sie die Bytes aus `audio.wav` zur Audio‑Sammlung der Präsentation hinzu und verwenden Sie dann [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded), um einen lokalen Audioclip auf der ersten Folie einzubetten. Die ersten beiden Koordinaten positionieren den Frame auf der Folie, die nächsten beiden Werte setzen Breite und Höhe, alles in Punkten. Dieses Beispiel ruft [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) auf, um den Clip automatisch zu starten, und ruft [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) auf, um die laute Voreinstellung auszuwählen.

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

## **Thumbnail des Audio‑Frames ändern**

Standardmäßig zeigt ein Audio‑Frame ein Lautsprechersymbol an. Um ein benutzerdefiniertes Thumbnail anzuzeigen, fügen Sie der Präsentation ein Bild mit [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) hinzu und setzen es mit [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) auf das Bild des Frames. Das Beispiel verwendet ein JPEG als Thumbnail für einen eingebetteten Audioclip.

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

    audio_data = Path("audio.wav").read_bytes()
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

PowerPoints **Audio‑Optionen** bestimmen, wann ein Clip startet, wie laut er ist und wie er sich während einer Bildschirmpräsentation verhält.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint‑Steuerelement | Aspose.Slides for Python via Java‑Methode |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Lautstärke‑Voreinstellung | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Während Folien wiedergeben | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Schleife bis zum Anhalten | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Während der Präsentation ausblenden | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Nach Wiedergabe zurückspulen | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Einblenden | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Ausblenden | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Audio-Anfangszeit trimmen | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Audio-Endzeit trimmen | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Lautstärke‑Schieberegler | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

Das Beispiel findet den ersten Audio‑Frame auf der ersten Folie, ruft [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) auf, um die Wiedergabe per Klick zu starten, und wählt die niedrige Lautstärke‑Voreinstellung. Der Clip wird über Folien hinweg weitergegeben, wobei die Schleife deaktiviert ist. Das Symbol bleibt während der Show ausgeblendet, und der Clip wird nach der Wiedergabe zurückgespult.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # Bei Mausklick mit niedriger Lautstärke, über Folien hinweg, ohne Schleife abspielen.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Den Frame während der Bildschirmpräsentation ausblenden und nach dem Abspielen zurückspulen.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

Für einen Clip, der länger als 3,5 Sekunden ist, überspringt dieses Beispiel die ersten 1,5 Sekunden und die letzten 2 Sekunden. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) gibt die Dauer an, die am Ende des Clips weggelassen werden soll. Um die Endzeit zu erhalten, die in PowerPoint angezeigt wird, subtrahieren Sie diesen Offset von der Gesamtdauer des Clips. Der getrimmte Clip blendet über 200 Millisekunden ein und über 500 Millisekunden aus. Alle vier Methoden erwarten Werte in Millisekunden.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Entferne 1,5 Sekunden vom Anfang und 2 Sekunden vom Ende.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Setze Einblenden auf 200 ms und Ausblenden auf 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um die Wiedergabelautstärke auf einen bestimmten Prozentsatz zu setzen, verwenden Sie [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). Dieses Beispiel setzt den ersten Audio‑Frame auf der ersten Folie auf 85 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **Audio‑Untertitel verwalten**

Jeder Audio‑Frame bietet Zugriff auf seine Untertitelspuren über [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Verwenden Sie die Sammlung, um WebVTT‑Untertitel an den Clip anzuhängen, vorhandene Spuren zu exportieren oder sie zu entfernen.

### **Audio‑Untertitel hinzufügen**

Das Beispiel bettet einen Audioclip auf der ersten Folie ein und nutzt [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add), um eine lokale WebVTT‑Spur anzuhängen. Das erste Argument liefert das Track‑Label, das zweite identifiziert die Datei mit den zeitgesteuerten Untertiteln.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Neue Untertitelspur aus einer WebVTT-Datei hinzufügen.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Audio‑Untertitel extrahieren**

Dieses Beispiel exportiert jede Untertitelspur, die einem Audio‑Frame auf der ersten Folie zugeordnet ist. Es schreibt die von [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) zurückgegebenen Bytes in eine WebVTT‑Datei und verwendet den von [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) zurückgegebenen Bezeichner als Dateinamen, sodass jede Spur eine separate Ausgabe erhält.

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
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Audio‑Untertitel entfernen**

Verwenden Sie [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt), um eine einzelne Spur zu löschen. Das Beispiel nutzt [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear), um alle Untertitel vom ersten Audio‑Frame auf der ersten Folie zu entfernen, während der Clip erhalten bleibt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **Eine Zeile in Audio‑Untertiteln finden**

Um eine Zeile in den Audio‑Untertiteln auf der ersten Folie zu finden, durchsuchen Sie den Text, den [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) im Speicher zurückgibt. In einem reinen Text‑WebVTT‑Cue enthält die Zeile mit der Zeitangabe `-->`, darauf folgen die Untertitelzeilen, und eine leere Zeile beendet den Cue. Dieses Beispiel gibt das Track‑Label und jede Untertitelzeile aus, die „café“ enthält.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **Audio extrahieren**

Ein Folienübergang kann einen eigenen Sound besitzen. Um ihn abzurufen, rufen Sie [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) am Folienübergang auf. Das Beispiel greift auf die von [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) zurückgegebenen Bytes zu und gibt die Anzahl der Bytes aus. Hat die erste Folie keinen Übergangssound, wird stattdessen eine Meldung ausgegeben.

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
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich denselben Audioclip auf mehreren Folien verwenden, ohne ihn zu duplizieren?**

Ja. Fügen Sie den Clip einmal zur [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) der Präsentation hinzu und übergeben Sie dasselbe Audio‑Objekt jeder Folie bei [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded).

**Kann ich den Sound in einem bereits vorhandenen Audio‑Frame ersetzen?**

Ja. Für einen verlinkten Sound verwenden Sie [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong), um auf die Ersatzdatei zu verweisen. Für einen eingebetteten Sound wählen Sie einen anderen Clip aus der Audio‑Sammlung der Präsentation mit [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Beide Ansätze bewahren den vorhandenen Frame.

**Ändert das Trimmen die Audiodaten, die in der Präsentation gespeichert sind?**

Nein. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) und [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) legen nur die Wiedergabebereiche fest. Sie können den vollständigen Clip weiterhin über [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio) abrufen.