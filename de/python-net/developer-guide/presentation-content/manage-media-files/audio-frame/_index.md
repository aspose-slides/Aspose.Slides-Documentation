---
title: Audio-Frames in Präsentationen mit Python verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/python-net/audio-frame/
keywords:
- Audio
- Audio-Frame
- Vorschaubild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- WebVTT
- Python
- Aspose.Slides
description: "Audio in Folien einbetten, das Audiosymbol ändern, die Wiedergabe konfigurieren, WebVTT-Untertitel verwalten und Sounds von Folienübergängen mit Aspose.Slides für Python via .NET extrahieren."
---
## **Übersicht**

Ein Audio-Frame ermöglicht das Abspielen eines Tons auf einer Folie. Mit Aspose.Slides für Python via .NET können Sie einen Audio-Clip einbetten, das Bild auswählen, das ihn darstellt, die Wiedergabe anpassen und Untertitel hinzufügen. Sie können auch einen Sound abrufen, der einer Folienübergangs zugewiesen ist.

## **Audio-Frames erstellen**

Verwenden Sie [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/), um einen lokalen Audio-Clip auf der ersten Folie einzubetten. Die ersten beiden Koordinaten positionieren den Frame auf der Folie, und die nächsten beiden Werte setzen seine Breite und Höhe, alle in Punkten. Dieses Beispiel setzt [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) so, dass der Clip automatisch startet, und [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) auf die laute Voreinstellung.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Thumbnail des Audio-Frames ändern**

Standardmäßig zeigt ein Audio-Frame ein Lautsprecher-Symbol an. Um ein benutzerdefiniertes Thumbnail anzuzeigen, fügen Sie der Präsentation ein Bild mit [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) hinzu und weisen Sie es der Eigenschaft [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) des Frames zu. Das Beispiel verwendet ein JPEG als Thumbnail für einen eingebetteten Audio-Clip.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio-Wiedergabeoptionen ändern**

Die **Audio-Optionen** von PowerPoint bestimmen, wann ein Clip startet, wie laut er klingt und wie er sich während einer Bildschau verhält.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint-Steuerung | Aspose.Slides-Eigenschaft |
| --- | --- |
| Start | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Lautstärkepreset | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Über Folien wiedergeben | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Schleifen bis gestoppt | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Während der Vorführung ausblenden | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Nach Wiedergabe zurückspulen | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Einblenden | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Ausblenden | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Audio-Startzeit trimmen | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Audio-Endzeit trimmen | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Lautstärkeregler | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

Das Beispiel findet den ersten Audio-Frame auf der ersten Folie, setzt [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) so, dass die Wiedergabe bei einem Klick startet, und wählt die niedrige Lautstärkepreset aus. Der Clip wird über Folien hinweg fortgesetzt, wobei die Schleife deaktiviert ist. Das Symbol bleibt während der Vorführung ausgeblendet, und der Clip wird nach der Wiedergabe zurückgespult.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Für einen Clip, der länger als 3,5 Sekunden ist, überspringt dieses Beispiel die ersten 1,5 Sekunden und die letzten 2 Sekunden. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) misst die Dauer, die vom Ende des Clips weggelassen werden soll. Um die in PowerPoint angezeigte Endzeit zu erhalten, ziehen Sie diesen Versatz von der Gesamtdauer des Clips ab. Der zugeschnittene Clip blendet über 200 Millisekunden ein und über 500 Millisekunden aus. Alle vier Eigenschaften akzeptieren Werte in Millisekunden.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Um die Wiedergabelautstärke auf einen bestimmten Prozentsatz zu setzen, verwenden Sie [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Dieses Beispiel setzt den ersten Audio-Frame auf der ersten Folie auf 85 %.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio-Untertitel verwalten**

Jeder Audio-Frame verfügt über eine [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/)‑Sammlung. Verwenden Sie sie, um dem Clip WebVTT-Untertitel hinzuzufügen, vorhandene Spuren zu exportieren oder sie zu entfernen.

### **Audio-Untertitel hinzufügen**

Das Beispiel bettet einen Audio-Clip auf der ersten Folie ein und verwendet [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/), um eine lokale WebVTT‑Spur anzuhängen. Das erste Argument liefert das Spurlabel, und das zweite gibt die Datei an, die die zeitgesteuerten Untertitel enthält.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Audio-Untertitel extrahieren**

Dieses Beispiel exportiert jede an einen Audio-Frame auf der ersten Folie angehängte Untertitelspur. Es schreibt die [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) der Spur in eine WebVTT‑Datei und verwendet deren [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) als Dateinamen, sodass jede Spur eine separate Ausgabe hat.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **Audio-Untertitel entfernen**

Verwenden Sie [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) oder [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/), um eine einzelne Spur zu löschen. Das Beispiel verwendet [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/), um alle Untertitel vom ersten Audio-Frame auf der ersten Folie zu entfernen, wobei der Clip erhalten bleibt.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Zeile in Audio-Untertiteln finden**

Um eine Zeile in den Audio-Untertiteln auf der ersten Folie zu finden, lesen Sie die [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) jeder Spur im Speicher. In einem Klartext‑WebVTT‑Cue enthält die Timing‑Zeile `-->`, die Untertitelzeilen folgen darauf, und eine leere Zeile beendet den Cue. Dieses Beispiel gibt das Spurlabel und jede Untertitelzeile aus, die „café“ enthält.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **Audio extrahieren**

Ein Folienübergang kann einen eigenen Sound haben. Um ihn abzurufen, lesen Sie die [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/)‑Eigenschaft des Übergangs. Das Beispiel greift auf die [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) des Sounds zu und gibt dessen Größe in Bytes aus. Wenn die erste Folie keinen Übergangssound hat, wird stattdessen eine Meldung ausgegeben.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **FAQ**

**Kann ich denselben Audio-Clip auf mehreren Folien wiederverwenden, ohne ihn zu duplizieren?**

Ja. Fügen Sie den Clip einmal zur [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) der Präsentation hinzu und übergeben Sie dasselbe Audio‑Objekt bei jedem Aufruf von [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) an jede Folie.

**Kann ich den Sound in einem bestehenden Audio-Frame ersetzen?**

Ja. Für einen verknüpften Sound aktualisieren Sie [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/), sodass er auf die Ersatzdatei zeigt. Für einen eingebetteten Sound weisen Sie einem anderen Clip aus der Audio‑Sammlung der Präsentation [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) zu. Beide Ansätze erhalten den bestehenden Frame.

**Ändert das Trimmen die Audiodaten, die in der Präsentation gespeichert sind?**

Nein. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) und [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) legen Wiedergabebereiche fest. Sie können den vollständigen Clip weiterhin über [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) abrufen.