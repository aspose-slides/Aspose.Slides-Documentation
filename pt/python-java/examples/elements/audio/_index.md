---
title: Áudio
type: docs
weight: 70
url: /pt/python-java/examples/elements/audio/
keywords:
- exemplo de código
- áudio
- quadro de áudio
- adicionar áudio
- acessar áudio
- remover áudio
- reprodução de áudio
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Use o Aspose.Slides for Python via Java para adicionar, acessar, remover e configurar quadros de áudio em apresentações PowerPoint e OpenDocument."
---
Este artigo demonstra como incorporar quadros de áudio e controlar a reprodução usando **Aspose.Slides for Python via Java**. Os exemplos a seguir mostram operações básicas de áudio.

Instale o pacote como descrito em [Installation](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides` antes de iniciar a JVM e, em seguida, importa a API após a JVM estar em execução.

## **Add an Audio Frame**

Insira um quadro de áudio vazio que pode futuramente conter dados de áudio incorporados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # Crie um quadro de áudio vazio (o áudio será incorporado posteriormente).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Access an Audio Frame**

Este código recupera o primeiro quadro de áudio em um slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Acesse o primeiro quadro de áudio no slide.
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **Remove an Audio Frame**

Exclua um quadro de áudio adicionado anteriormente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Remova o quadro de áudio.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Set Audio Playback**

Configure o quadro de áudio para reproduzir automaticamente quando o slide aparecer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # Reproduza automaticamente quando o slide aparecer.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```