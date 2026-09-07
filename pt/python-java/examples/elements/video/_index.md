---
title: Vídeo
type: docs
weight: 80
url: /pt/python-java/examples/elements/video/
keywords:
- exemplo de código
- vídeo
- quadro de vídeo
- adicionar vídeo
- acessar vídeo
- remover vídeo
- reprodução de vídeo
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Use o Aspose.Slides for Python via Java para adicionar, acessar, remover e configurar quadros de vídeo em apresentações PowerPoint e OpenDocument."
---
Este artigo demonstra como adicionar quadros de vídeo e definir opções de reprodução usando **Aspose.Slides for Python via Java**.

Instale o pacote conforme descrito em [Instalação](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM, depois importa a API após a JVM estar em execução.

## **Adicionar um Quadro de Vídeo**

Insira um quadro de vídeo que faça referência a um arquivo de vídeo externo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adicionar um quadro de vídeo vinculado a um arquivo de vídeo.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **Acessar um Quadro de Vídeo**

Recupere o primeiro quadro de vídeo adicionado a um slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Acessar o primeiro quadro de vídeo no slide.
    first_video = None
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            first_video = shape
            break

    if first_video is None:
        print("The slide contains no video frames.")
finally:
    presentation.dispose()
```

## **Remover um Quadro de Vídeo**

Exclua um quadro de vídeo do slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Remover o quadro de vídeo.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **Definir Reprodução de Vídeo**

Configure o vídeo para reproduzir automaticamente quando o slide for exibido.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # Configurar o vídeo para reproduzir automaticamente.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```