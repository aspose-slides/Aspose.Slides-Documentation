---
title: Audio
type: docs
weight: 70
url: /de/python-net/examples/elements/audio/
keywords:
- Audio
- Audio-Frame
- Audio hinzufügen
- Audio abrufen
- Audio entfernen
- Audio-Wiedergabe
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Arbeiten Sie mit Audio in Python unter Verwendung von Aspose.Slides: Hinzufügen, Ersetzen, Extrahieren und Kürzen von Sounds, sowie Festlegen von Lautstärke und Wiedergabe für Folien und Formen in PowerPoint und OpenDocument."
---
Zeigt, wie Audio-Frames eingebettet und die Wiedergabe mit **Aspose.Slides for Python via .NET** gesteuert werden kann. Die folgenden Beispiele demonstrieren grundlegende Audio-Operationen.

## **Audio-Frame hinzufügen**

Das nachfolgende Code-Beispiel fügt einen Audio-Frame zu einer Präsentationsfolie hinzu.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio-Frame abrufen**

Dieser Code ruft den ersten Audio-Frame von der Folie ab.

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **Audio-Frame entfernen**

Entfernt einen zuvor hinzugefügten Audio-Frame.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, das erste Shape ist ein AudioFrame.
        audio_frame = slide.shapes[0]

        # Entferne den AudioFrame.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio-Wiedergabe festlegen**

Konfiguriert den Audio-Frame so, dass er automatisch abgespielt wird, wenn die Folie angezeigt wird.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, das erste Shape ist ein AudioFrame.
        audio_frame = slide.shapes[0]

        # Automatisch abspielen, wenn die Folie angezeigt wird.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```