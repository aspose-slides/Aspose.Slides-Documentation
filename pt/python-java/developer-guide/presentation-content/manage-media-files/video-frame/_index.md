---
title: Gerenciar quadros de vídeo em apresentações usando Python
linktitle: Quadro de vídeo
type: docs
weight: 10
url: /pt/python-java/video-frame/
keywords:
- adicionar vídeo
- criar vídeo
- incorporar vídeo
- extrair vídeo
- recuperar vídeo
- quadro de vídeo
- fonte web
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a adicionar e extrair programaticamente quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para Python via Java. Guia prático rápido."
---
## **Introdução**

Um vídeo bem posicionado em uma apresentação pode tornar sua mensagem mais persuasiva e aumentar os níveis de engajamento com o público.

O PowerPoint permite que você adicione vídeos a um slide em uma apresentação de duas maneiras:

* Adicionar ou incorporar um vídeo local (armazenado na sua máquina)
* Adicionar um vídeo online (de uma fonte web como o YouTube).

Para permitir que você adicione vídeos (objetos de vídeo) a uma apresentação, o Aspose.Slides fornece a classe [Video](https://reference.aspose.com/slides/pt/python-java/aspose.slides/video/) , a classe [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) e outros tipos relevantes.

## **Criar quadros de vídeo incorporados**

Se o arquivo de vídeo que você deseja adicionar ao seu slide estiver armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo na sua apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/python-java/aspose.slides/video/) e passe os dados do arquivo de vídeo para incorporar o vídeo na apresentação.
1. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) para criar um quadro para o vídeo.
1. Salve a apresentação modificada.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alternativamente, você pode adicionar um vídeo passando seu caminho de arquivo diretamente para o método [addVideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addVideoFrame) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Criar quadros de vídeo com vídeo de fontes web**

O Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) oferece suporte a vídeos do YouTube em apresentações. Se o vídeo que você deseja usar estiver disponível online (por exemplo, no YouTube), você pode adicioná‑lo à sua apresentação por meio do seu link web.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) e passe o link para o vídeo.
1. Defina uma miniatura para o quadro de vídeo.
1. Salve a apresentação.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Carregar a miniatura.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cortar um quadro de vídeo**

Aspose.Slides permite que você controle qual parte de um vídeo é reproduzida definindo os valores trim‑from‑start e trim‑from‑end através de [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setTrimFromStart) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setTrimFromEnd). Ambos os valores são especificados em milissegundos e definem quanto tempo é pulado do início e do fim do vídeo, respectivamente. Essas configurações alteram as propriedades de reprodução do vídeo na apresentação; elas não cortam nem modificam os dados binários do vídeo incorporado.

**Definir configurações de corte**

Para criar um quadro de vídeo e definir suas configurações de corte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
1. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/python-java/aspose.slides/video/) à apresentação.
1. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) a um slide.
1. Defina os valores trim‑from‑start e trim‑from‑end através de [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setTrimFromStart) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setTrimFromEnd) .
1. Salve a apresentação modificada.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Ler configurações de corte**

Para inspecionar as configurações de corte existentes, carregue uma apresentação, encontre um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) entre as formas do primeiro slide e leia os valores através de [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#getTrimFromStart) e [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#getTrimFromEnd) .

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Gerenciar legendas de vídeo**

Aspose.Slides permite que você gerencie legendas ocultas para quadros de vídeo em apresentações do PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas através do método [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#getCaptionTracks) .

**Adicionar legendas a um quadro de vídeo**

Para adicionar legendas a um quadro de vídeo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
1. Adicione um vídeo à apresentação.
1. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) a um slide.
1. Use a [CaptionsCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/) retornada por [getCaptionTracks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#getCaptionTracks) para adicionar uma faixa de legenda WebVTT.
1. Salve a apresentação modificada.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Adicionar uma nova faixa de legenda a partir de um arquivo WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A classe [CaptionsCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/) também oferece uma sobrecarga que permite adicionar legendas a partir de um fluxo.

**Extrair legendas de um quadro de vídeo**

Para extrair legendas de um quadro de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Encontre o objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) alvo.
1. Percorra as faixas de legenda na [CaptionsCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/) .
1. Salve cada faixa de legenda em um arquivo `.vtt` .

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Salvar a faixa de legenda em um arquivo WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Cada objeto [Captions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captions/) expõe o identificador da legenda, rótulo, dados binários e o texto da legenda como uma string UTF‑8.

**Remover legendas de um quadro de vídeo**

Para remover legendas de um quadro de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Obtenha o objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) alvo.
1. Remova as faixas de legenda da [CaptionsCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/) .
1. Salve a apresentação modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Remover todas as legendas do quadro de vídeo.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Se precisar remover apenas uma faixa de legenda, use os métodos [remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/#removeAt) em vez de [clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/#clear) .

## **Extrair vídeo de slides**

Além de adicionar vídeos aos slides, o Aspose.Slides permite extrair vídeos incorporados em apresentações.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) para carregar a apresentação que contém o vídeo.
2. Percorra todos os objetos [Slide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/) .
3. Percorra todos os objetos [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) para encontrar um [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) .
4. Salve o vídeo em disco.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um VideoFrame?**

Você pode controlar o [modo de reprodução](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setPlayMode) (automático ou ao clicar) e o [looping](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setPlayLoopMode). Essas opções estão disponíveis nas propriedades do objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) .

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você adiciona um vídeo online, um link e uma miniatura são incorporados, de modo que o aumento de tamanho é menor.

**Posso substituir o vídeo em um VideoFrame existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [conteúdo do vídeo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setEmbeddedVideo) dentro do quadro preservando a geometria da forma; esse é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [tipo de conteúdo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/video/#getContentType) que você pode ler e usar, por exemplo, ao salvá‑lo em disco.