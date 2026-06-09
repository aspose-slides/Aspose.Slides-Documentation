---
title: Áudio
type: docs
weight: 70
url: /pt/python-net/examples/elements/audio/
keywords:
- áudio
- quadro de áudio
- adicionar áudio
- acessar áudio
- remover áudio
- reprodução de áudio
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Trabalhe com áudio em Python usando Aspose.Slides: adicione, substitua, extraia e corte sons, defina volume e reprodução para slides e formas no PowerPoint e OpenDocument."
---
Ilustra como incorporar quadros de áudio e controlar a reprodução com **Aspose.Slides for Python via .NET**. Os exemplos a seguir mostram operações básicas de áudio.

## **Adicionar um Quadro de Áudio**

O exemplo de código abaixo adiciona um quadro de áudio em um slide de apresentação.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar um Quadro de Áudio**

Este código recupera o primeiro quadro de áudio do slide.

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

## **Remover um Quadro de Áudio**

Exclua um quadro de áudio adicionado anteriormente.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Supondo que a primeira forma seja um AudioFrame.
        audio_frame = slide.shapes[0]

        # Remova o quadro de áudio.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Reprodução de Áudio**

Configure o quadro de áudio para reproduzir automaticamente quando o slide aparecer.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Supondo que a primeira forma seja um AudioFrame.
        audio_frame = slide.shapes[0]

        # Reproduzir automaticamente quando o slide aparecer.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```