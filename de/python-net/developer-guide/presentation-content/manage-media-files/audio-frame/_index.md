---
title: Audio in Präsentationen mit Python verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/python-net/audio-frame/
keywords:
- Audio hinzufügen
- Audio einbetten
- Audio-Frame
- Audiodatei
- Audioeigenschaften
- Audio extrahieren
- Audio abrufen
- Audio ändern
- Wiedergabeoptionen
- Wiedergabemodus
- Über Folien hinweg abspielen
- Schleife bis Stopp
- Während der Präsentation ausblenden
- Nach dem Abspielen zurückspulen
- Audio-Lautstärke
- Standardbild
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie Audio-Frames in PPT, PPTX und ODP ganz einfach hinzu, extrahieren und verwalten Sie sie mit Aspose.Slides für Python via .NET. Entdecken Sie Codebeispiele und verbessern Sie noch heute Ihre Präsentationen."
---
## **Audio-Frames erstellen**

Aspose.Slides für Python via .NET ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden als Audio-Frames in die Folien eingebettet. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) .
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Laden Sie den Audiodateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/de/python-net/aspose.slides/audioplaymodepreset) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/audioframe/)‑Objekt bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieser Python‑Code zeigt, wie Sie einen eingebetteten Audio-Frame zu einer Folie hinzufügen:

```python
import aspose.slides as slides

# Instanziiere eine Präsentationsklasse, die eine Präsentationsdatei darstellt
with slides.Presentation() as pres:
    # Holt die erste Folie
    sld = pres.slides[0]

    # Lädt die wav-Sounddatei in einen Stream
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Fügt den Audio-Frame hinzu
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Setzt den Wiedergabemodus und die Lautstärke des Audios
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Schreibt die PowerPoint-Datei auf die Festplatte
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio-Frame-Vorschaubild ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, erscheint das Audio als Frame mit einem standardmäßigen Standardbild (siehe das Bild im untenstehenden Abschnitt). Sie können das Vorschaubild des Audio-Frames ändern (ein gewünschtes Bild festlegen).

Dieser Python‑Code zeigt, wie Sie das Vorschaubild eines Audio-Frames ändern oder ein neues Bild festlegen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Fügt der Folie einen Audio-Frame mit einer angegebenen Position und Größe hinzu.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Fügt ein Bild zu den Präsentationsressourcen hinzu.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Setzt das Bild für den Audio-Frame.
        audioFrame.picture_format.picture.image = audioImage
        
        # Speichert die geänderte Präsentation auf der Festplatte
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides für Python via .NET ermöglicht das Ändern von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Beispielsweise können Sie die Lautstärke des Audios anpassen, das Audio in einer Schleife abspielen lassen oder das Audiosymbol sogar ausblenden.

Der **Audio-Optionen**-Bereich in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint-**Audio-Optionen**, die den Aspose.Slides-[AudioFrame]-Eigenschaften entsprechen:

- **Start**-Dropdown-Liste entspricht der [AudioFrame.play_mode]-Eigenschaft 
- **Lautstärke** entspricht der [AudioFrame.volume]-Eigenschaft 
- **Über Folien hinweg abspielen** entspricht der [AudioFrame.play_across_slides]-Eigenschaft 
- **Schleife bis Stopp** entspricht der [AudioFrame.play_loop_mode]-Eigenschaft 
- **Während der Präsentation ausblenden** entspricht der [AudioFrame.hide_at_showing]-Eigenschaft 
- **Nach dem Abspielen zurückspulen** entspricht der [AudioFrame.rewind_audio]-Eigenschaft 

PowerPoint-**Bearbeitungsoptionen**, die den Aspose.Slides-[AudioFrame]-Eigenschaften entsprechen:

- **Einblenden** entspricht der [AudioFrame.fade_in_duration]-Eigenschaft 
- **Ausblenden** entspricht der [AudioFrame.fade_out_duration]-Eigenschaft 
- **Audio-Startzeit zuschneiden** entspricht der [AudioFrame.trim_from_start]-Eigenschaft 
- **Audio-Endzeit zuschneiden** hat den Wert der Audiodauer minus dem Wert der [AudioFrame.trim_from_end]-Eigenschaft 

Der PowerPoint-**Lautstärkeregler** im Audiosteuerungsfeld entspricht der [AudioFrame.volume_value]-Eigenschaft. Er ermöglicht das Ändern der Lautstärke des Audios als Prozentsatz.

So ändern Sie die Audio-Wiedergabeoptionen:

1. [Erstellen](#create-audio-frame) oder holen Sie den Audio-Frame.
2. Setzen Sie neue Werte für die Audio-Frame-Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint-Datei.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Holt die AudioFrame-Form
    audioFrame = pres.slides[0].shapes[0]

    # Setzt den Wiedergabemodus auf Klick
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Setzt die Lautstärke auf Niedrig
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Setzt das Audio so, dass es über Folien hinweg abgespielt wird
    audioFrame.play_across_slides = True

    # Deaktiviert die Schleife für das Audio
    audioFrame.play_loop_mode = False

    # Blendet den AudioFrame während der Präsentation aus
    audioFrame.hide_at_showing = True

    # Spult das Audio nach dem Abspielen zum Anfang zurück
    audioFrame.rewind_audio = True

    # Speichert die PowerPoint-Datei auf die Festplatte
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Dieses Python-Beispiel zeigt, wie man einen neuen Audio-Frame mit eingebettetem Audio hinzufügt, zuschneidet und die Ein-/Ausblenddauer festlegt:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Setzt den Trimm-Startversatz auf 1,5 Sekunden
    audio_frame.trim_from_start = 1500.0
    # Setzt den Trimm-Endversatz auf 2 Sekunden
    audio_frame.trim_from_end = 2000.0

    # Setzt die Einblenddauer auf 200 ms
    audio_frame.fade_in_duration = 200.0
    # Setzt die Ausblenddauer auf 500 ms
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Das folgende Codebeispiel zeigt, wie man einen Audio-Frame mit eingebettetem Audio abruft und dessen Lautstärke auf 85% setzt:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Holt das Audio-Frame-Shape
    audio_frame = pres.slides[0].shapes[0]

    # Setzt die Audio-Lautstärke auf 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio-Untertitel verwalten**

Aspose.Slides ermöglicht das Hinzufügen von Closed Captions zu einem Audio-Frame über die Eigenschaft [caption_tracks]. Diese Eigenschaft gibt eine [CaptionsCollection] zurück, mit der Sie WebVTT-Untertitelspuren hinzufügen, durch vorhandene Spuren iterieren und sie bei Bedarf entfernen können.

**Audio-Untertitel hinzufügen**

Verwenden Sie die Eigenschaft [caption_tracks], um einer Audio-Frame-Instanz eine oder mehrere Untertitelspuren anzuhängen. Im folgenden Beispiel wird einer Folie eine Audiodatei hinzugefügt und anschließend eine neue Untertitelspur aus einer `.vtt`-Datei geladen.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Füge eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Audio-Untertitel extrahieren**

Sie können durch die mit einem Audio-Frame verknüpften Untertitelspuren iterieren und sie als `.vtt`-Dateien speichern. Jede Untertitelspur stellt ihre Binärdaten und eine eindeutige Kennung bereit, die beim Exportieren der Untertitel verwendet werden kann.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Speichere die Untertitelspur als .vtt-Datei.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Audio-Untertitel entfernen**

Um Untertitel aus einem Audio-Frame zu entfernen, verwenden Sie die von [CaptionsCollection] bereitgestellten Methoden, wie [clear], [remove] oder [remove_at]. Das folgende Beispiel entfernt alle Untertitelspuren aus einem Audio-Frame.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # Typ: slides.AudioFrame

    # Entferne alle Untertitelspuren aus dem Audio-Frame.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio extrahieren**

Aspose.Slides für Python via .NET ermöglicht das Extrahieren des bei Folienübergängen verwendeten Sounds. Beispielsweise können Sie den Sound einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation] und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie die Referenz der betreffenden Folie über ihren Index.
3. Greifen Sie auf die Folienübergänge der Folie zu.
4. Extrahieren Sie den Sound als Byte-Daten.

Dieser Python‑Code zeigt, wie Sie das in einer Folie verwendete Audio extrahieren:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Greift auf die gewünschte Folie zu
    slide = pres.slides[0]  

    # Holt die Folienübergangseffekte für die Folie
    transition = slide.slide_show_transition

    #Extrahiert den Sound als Byte-Array
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**Kann ich dasselbe Audio-Asset in mehreren Folien wiederverwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur gemeinsamen [audio collection](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/audios/) der Präsentation hinzu und erstellen Sie weitere Audio-Frames, die auf dieses vorhandene Asset verweisen. Dadurch werden Mediendaten nicht dupliziert und die Größe der Präsentation bleibt kontrollierbar.

**Kann ich den Sound in einem bestehenden Audio-Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/de/python-net/aspose.slides/audioframe/link_path_long/), damit er auf die neue Datei verweist. Für einen eingebetteten Sound tauschen Sie das [embedded audio](https://reference.aspose.com/slides/de/python-net/aspose.slides/audioframe/embedded_audio/)‑Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/audios/) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben unverändert.

**Ändert das Zuschneiden die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Das Zuschneiden passt nur die Wiedergabegrenzen an. Die ursprünglichen Audiodaten bleiben unverändert und sind über das eingebettete Audio oder die Audio-Collection der Präsentation zugänglich.