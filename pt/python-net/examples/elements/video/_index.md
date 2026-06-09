---
title: Vídeo
type: docs
weight: 80
url: /pt/python-net/examples/elements/video/
keywords:
- vídeo
- quadro de vídeo
- adicionar vídeo
- acessar vídeo
- remover vídeo
- reprodução de vídeo
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Trabalhe com vídeo em Python usando Aspose.Slides: inserir, substituir, cortar, definir quadros de pôster e opções de reprodução, e exportar apresentações para PPT, PPTX e ODP."
---
Mostra como incorporar quadros de vídeo e definir opções de reprodução usando **Aspose.Slides for Python via .NET**.

## **Adicionar um Quadro de Vídeo**

Insira um quadro de vídeo vazio em um slide.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Adicionar um quadro de vídeo.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar um Quadro de Vídeo**

Recupere o primeiro quadro de vídeo adicionado a um slide.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Acessar o primeiro quadro de vídeo no slide.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Remover um Quadro de Vídeo**

Exclua um quadro de vídeo do slide.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Presumindo que o primeiro shape seja um quadro de vídeo.
        video_frame = slide.shapes[0]

        # Remover o quadro de vídeo.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Reprodução de Vídeo**

Configure o vídeo para reproduzir automaticamente quando o slide for exibido.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Presumindo que o primeiro shape seja um quadro de vídeo.
        video_frame = slide.shapes[0]

        # Configurar o vídeo para reproduzir automaticamente.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```