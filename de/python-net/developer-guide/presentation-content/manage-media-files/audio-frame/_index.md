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
description: "Einfach Audio-Frames in PPT, PPTX und ODP mit Aspose.Slides für Python via .NET hinzufügen, extrahieren und verwalten. Entdecken Sie Codebeispiele und verbessern Sie noch heute Ihre Präsentationen."
---

## **Audio-Frames erstellen**

Aspose.Slides für Python via .NET ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden als Audio-Frames in die Folien eingebettet. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Rufen Sie die Referenz einer Folie über ihren Index ab.
3. Laden Sie den Audiodateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) Objekt bereitgestellt werden.
6. Speichern Sie die modifizierte Präsentation.

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
with slides.Presentation() as pres:
    # Holt die erste Folie
    sld = pres.slides[0]

    # Lädt die wav-Audiodatei in einen Stream
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Fügt den Audio-Frame hinzu
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Legt den Wiedergabemodus und die Lautstärke des Audios fest
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Schreibt die PowerPoint-Datei auf die Festplatte
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Audio-Frame-Vorschaubild ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, erscheint das Audio als Frame mit einem standardmäßigen Standardbild (siehe das Bild im folgenden Abschnitt). Sie können das Vorschaubild des Audio-Frames ändern (legen Sie Ihr bevorzugtes Bild fest).

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Fügt der Folie einen Audio-Frame an einer angegebenen Position und Größe hinzu.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Fügt ein Bild zu den Präsentationsressourcen hinzu.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Setzt das Bild für den Audio-Frame.
        audioFrame.picture_format.picture.image = audioImage
        
        #Speichert die geänderte Präsentation auf die Festplatte
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides für Python via .NET ermöglicht das Ändern von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Beispielsweise können Sie die Lautstärke eines Audios anpassen, das Audio in Schleife abspielen lassen oder sogar das Audiosymbol ausblenden.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) Eigenschaften entsprechen:

- **Start**‑Dropdown‑Liste entspricht der [AudioFrame.play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) Eigenschaft 
- **Volume** entspricht der [AudioFrame.volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) Eigenschaft 
- **Play Across Slides** entspricht der [AudioFrame.play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) Eigenschaft 
- **Loop until Stopped** entspricht der [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) Eigenschaft 
- **Hide During Show** entspricht der [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) Eigenschaft 
- **Rewind after Playing** entspricht der [AudioFrame.rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) Eigenschaft 

PowerPoint **Editing**‑Optionen, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) Eigenschaften entsprechen:

- **Fade In** entspricht der [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) Eigenschaft 
- **Fade Out** entspricht der [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) Eigenschaft 
- **Trim Audio Start Time** entspricht der [AudioFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) Eigenschaft 
- **Trim Audio End Time**‑Wert entspricht der Audiodauer minus dem Wert der [AudioFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) Eigenschaft

Der PowerPoint **Volume‑Regler** im Audiosteuerungsfeld entspricht der [AudioFrame.volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) Eigenschaft. Damit können Sie die Lautstärke des Audios als Prozentsatz ändern.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. [Erstellen](#create-audio-frame) oder holen Sie den Audio-Frame.
2. Setzen Sie neue Werte für die Audio-Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die modifizierte PowerPoint‑Datei.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Holt das AudioFrame-Shape
    audioFrame = pres.slides[0].shapes[0]

    # Setzt den Wiedergabemodus auf beim Klicken abspielen
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Setzt die Lautstärke auf Niedrig
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Setzt das Audio so, dass es über Folien hinweg abgespielt wird
    audioFrame.play_across_slides = True

    # Deaktiviert die Schleife für das Audio
    audioFrame.play_loop_mode = False

    # Blendet das AudioFrame während der Präsentation aus
    audioFrame.hide_at_showing = True

    # Spult das Audio nach dem Abspielen zum Anfang zurück
    audioFrame.rewind_audio = True

    # Speichert die PowerPoint-Datei auf die Festplatte
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```


Dieses Python‑Beispiel zeigt, wie man einen neuen Audio‑Frame mit eingebettetem Audio hinzufügt, ihn trimmt und die Fade‑Dauern festlegt:
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


Das folgende Code‑Beispiel zeigt, wie man einen Audio‑Frame mit eingebettetem Audio abruft und dessen Lautstärke auf 85 % setzt:
```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Holt das Audio-Frame-Shape
    audio_frame = pres.slides[0].shapes[0]

    # Setzt die Audiolautstärke auf 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Audio extrahieren**

Aspose.Slides für Python via .NET ermöglicht das Extrahieren des in Folienübergängen verwendeten Sounds. Beispielsweise können Sie den Sound einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die das Audio enthält.
2. Rufen Sie die Referenz der entsprechenden Folie über ihren Index ab.
3. Greifen Sie auf die Folienübergänge der Folie zu.
4. Extrahieren Sie den Sound als Byte‑Daten.

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Greift auf die gewünschte Folie zu
    slide = pres.slides[0]  

    # Ermittelt die Folienübergangseffekte für die Folie
    transition = slide.slide_show_transition

    #Extrahiert den Sound in einem Byte-Array
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```


## **FAQ**

**Kann ich dieselbe Audiodatei über mehrere Folien hinweg wiederverwenden, ohne die Dateigröße zu vergrößern?**

Ja. Fügen Sie das Audio einmal zur gemeinsam genutzten [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) der Präsentation hinzu und erstellen Sie weitere Audio‑Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird das Duplizieren von Mediendaten vermieden und die Präsentationsgröße bleibt überschaubar.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/), sodass er auf die neue Datei zeigt. Für einen eingebetteten Sound ersetzen Sie das [embedded audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/)‑Objekt durch ein anderes aus der [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) der Präsentation. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben unverändert.

**Ändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Trimmen verändert nur die Wiedergabegrenzen. Die ursprünglichen Audio‑Bytes bleiben unverändert und sind über das eingebettete Audio oder die Audio‑Collection der Präsentation zugänglich.