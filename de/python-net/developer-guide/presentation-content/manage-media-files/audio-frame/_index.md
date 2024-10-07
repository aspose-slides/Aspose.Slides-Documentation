---
title: Audio-Frame
type: docs
weight: 10
url: /python-net/audio-frame/
keywords: "Audio hinzufügen, Audio-Frame, Audioeigenschaften, Audio extrahieren, Python, Aspose.Slides für Python über .NET"
description: "Audio zu PowerPoint-Präsentation in Python hinzufügen"
---

## **Audio-Frame erstellen**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, Audiodateien zu Folien hinzuzufügen. Die Audiodateien werden in Folien als Audio-Frames eingebettet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.
3. Laden Sie den Audio-Dateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (mit der Audiodatei) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) und `Volume`, die vom [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) Objekt bereitgestellt werden.
6. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie einen eingebetteten Audio-Frame zu einer Folie hinzufügen:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
with slides.Presentation() as pres:
    # Holt die erste Folie
    sld = pres.slides[0]

    # Lädt die wav-Audiodatei in den Stream
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Fügt den Audio-Frame hinzu
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Setzt den Spielemodus und die Lautstärke des Audios
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Schreibt die PowerPoint-Datei auf die Festplatte
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio-Frame-Daumenbild ändern**

Wenn Sie eine Audiodatei zu einer Präsentation hinzufügen, erscheint das Audio als Frame mit einem standardmäßigen Standardbild (siehe das Bild im folgenden Abschnitt). Sie können das Daumenbild des Audio-Frames ändern (setzen Sie Ihr bevorzugtes Bild).

Dieser Python-Code zeigt Ihnen, wie Sie das Daumenbild oder Vorschaubild eines Audio-Frames ändern:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Fügt der Folie einen Audio-Frame mit einer bestimmten Position und Größe hinzu.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Fügt ein Bild zu den Präsentationsressourcen hinzu.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Setzt das Bild für den Audio-Frame.
        audioFrame.picture_format.picture.image = audioImage
        
        # Speichert die modifizierte Präsentation auf der Festplatte
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides für Python über .NET ermöglicht es Ihnen, Optionen zu ändern, die die Wiedergabe oder Eigenschaften eines Audios steuern. Zum Beispiel können Sie die Lautstärke eines Audios anpassen, das Audio so einstellen, dass es in einer Schleife abgespielt wird, oder das Audio-Icon sogar ausblenden.

Das **Audiooptionen**-Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Die Audiooptionen von PowerPoint, die den Eigenschaften von Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) entsprechen:
- Das Dropdown-Menü **Start** der Audiooptionen entspricht der [AudioFrame.PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) Eigenschaft
- Die **Lautstärke** der Audiooptionen entspricht der [AudioFrame.Volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) Eigenschaft 
- Die Audiooptionen **Über Folien hinweg abspielen** entsprechen der [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) Eigenschaft 
- Die Audiooptionen **Schleife bis gestoppt** entsprechen der [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) Eigenschaft 
- Die Audiooptionen **Während der Präsentation ausblenden** entsprechen der [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) Eigenschaft 
- Die Audiooptionen **Nach dem Abspielen zurückspulen** entsprechen der [AudioFrame.RewindAudio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) Eigenschaft 

So ändern Sie die Audio-Wiedergabeoptionen:

1. [Erstellen](#create-audio-frame) oder erhalten Sie den Audio-Frame.
2. Setzen Sie neue Werte für die Eigenschaften des Audio-Frames, die Sie anpassen möchten.
3. Speichern Sie die modifizierte PowerPoint-Datei.

Dieser Python-Code demonstriert eine Operation, bei der die Optionen eines Audios angepasst werden:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Holt die AudioFrame-Form
    audioFrame = pres.slides[0].shapes[0]

    # Setzt den Spielmodus auf "Beim Klicken abspielen"
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Setzt die Lautstärke auf gering
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Setzt das Audio so, dass es über Folien hinweg abgespielt wird
    audioFrame.play_across_slides = True

    # Deaktiviert die Schleife für das Audio
    audioFrame.play_loop_mode = False

    # Blendet den AudioFrame während der Präsentation aus
    audioFrame.hide_at_showing = True

    # Spult das Audio nach dem Abspielen zurück
    audioFrame.rewind_audio = True

    # Speichert die PowerPoint-Datei auf der Festplatte
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio extrahieren**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, den Sound zu extrahieren, der in Folienübergängen verwendet wird. Zum Beispiel können Sie den Sound extrahieren, der in einer bestimmten Folie verwendet wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie sich die Referenz auf die relevante Folie über ihren Index.
3. Greifen Sie auf die Folienübergänge für die Folie zu.
4. Extrahieren Sie den Sound in Byte-Daten.

Dieser Python-Code zeigt Ihnen, wie Sie das in einer Folie verwendete Audio extrahieren:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Greift auf die gewünschte Folie zu
    slide = pres.slides[0]  

    # Holt die Übergangseffekte für die Folie
    transition = slide.slide_show_transition

    #Extrahiert den Sound in ein Byte-Array
    audio = transition.sound.binary_data

    print("Länge: " + str(len(audio)))
```