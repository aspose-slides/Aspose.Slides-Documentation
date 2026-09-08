---
title: Gerenciar Quadros de Vídeo em Apresentações Usando Python
linktitle: Quadro de Vídeo
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
description: "Aprenda a adicionar e extrair programaticamente quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para Python via Java. Guia rápido passo a passo."
---
## **Introdução**

Um vídeo bem posicionado em uma apresentação pode tornar sua mensagem mais atraente e aumentar os níveis de engajamento com seu público.

O PowerPoint permite que você adicione vídeos a um slide em uma apresentação de duas maneiras:

* Adicionar ou incorporar um vídeo local (armazenado em sua máquina)
* Adicionar um vídeo online (de uma fonte web como o YouTube).

Para permitir que você adicione vídeos (objetos de vídeo) a uma apresentação, o Aspose.Slides fornece a classe [Video](https://reference.aspose.com/slides/pt/python-java/aspose.slides/video/) , a classe [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) e outros tipos relevantes.

## **Criar Quadros de Vídeo Incorporados**

Se o arquivo de vídeo que você deseja adicionar ao seu slide estiver armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo em sua apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
2. Obtenha a referência de um slide através de seu índice.
3. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/python-java/aspose.slides/video/) e passe os dados do arquivo de vídeo para incorporar o vídeo na apresentação.
4. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) para criar um quadro para o vídeo.
5. Salve a apresentação modificada.

Este código Python mostra como adicionar um vídeo armazenado localmente a uma apresentação:

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

Alternativamente, você pode adicionar um vídeo passando seu caminho de arquivo diretamente ao método [addVideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addVideoFrame) :

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

## **Criar Quadros de Vídeo com Vídeo de Fontes Web**

O Microsoft [PowerPoint 2013 e posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) suportam vídeos do YouTube em apresentações. Se o vídeo que você deseja usar estiver disponível online (por exemplo, no YouTube), você pode adicioná-lo à sua apresentação através do link da web.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
2. Obtenha a referência de um slide através de seu índice.
3. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) e passe o link para o vídeo.
4. Defina uma miniatura para o quadro de vídeo.
5. Salve a apresentação.

Este código Python mostra como adicionar um vídeo da web a um slide em uma apresentação do PowerPoint:

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

## **Aparar um Quadro de Vídeo**

O Aspose.Slides permite controlar qual parte de um vídeo é reproduzida definindo os valores trim-from-start e trim-from-end através de [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setTrimFromStart) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setTrimFromEnd). Ambos os valores são especificados em milissegundos e definem quanto tempo é pulado do início e do final do vídeo, respectivamente. Essas configurações alteram as configurações de reprodução do vídeo na apresentação; elas não cortam nem modificam de outra forma os dados binários do vídeo incorporado.

**Definir Configurações de Aparagem**

Para criar um quadro de vídeo e definir suas configurações de aparagem:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
2. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/python-java/aspose.slides/video/) à apresentação.
3. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) a um slide.
4. Defina os valores trim-from-start e trim-from-end através de [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setTrimFromStart) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setTrimFromEnd) .
5. Salve a apresentação modificada.

O exemplo de código a seguir pula os primeiros 2,5 segundos e o último segundo de um vídeo incorporado durante a reprodução:

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

**Ler Configurações de Aparagem**

Para inspecionar as configurações de aparagem existentes, carregue uma apresentação, encontre um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) entre as formas no primeiro slide e leia os valores através de [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#getTrimFromStart) e [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#getTrimFromEnd) .

O exemplo de código a seguir encontra o primeiro quadro de vídeo no primeiro slide e relata suas configurações de aparagem em milissegundos:

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

## **Gerenciar Legendas de Vídeo**

O Aspose.Slides permite que você gerencie legendas fechadas para quadros de vídeo em apresentações do PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas através do método [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#getCaptionTracks) .

**Adicionar Legendas a um Quadro de Vídeo**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) .
2. Adicione um vídeo à apresentação.
3. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) a um slide.
4. Use a [CaptionsCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/) retornada por [getCaptionTracks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#getCaptionTracks) para adicionar uma faixa de legendas WebVTT.
5. Salve a apresentação modificada.

O código a seguir mostra como adicionar legendas a um quadro de vídeo:

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

A classe [CaptionsCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/) também fornece uma sobrecarga que permite adicionar legendas a partir de um stream.

**Extrair Legendas de um Quadro de Vídeo**

1. Carregue a apresentação que contém o vídeo.
2. Encontre o objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) alvo.
3. Itere pelas faixas de legendas na [CaptionsCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/) .
4. Salve cada faixa de legenda em um arquivo `.vtt` .

O código a seguir mostra como extrair legendas de um quadro de vídeo:

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

Cada objeto [Captions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captions/) expõe o identificador da legenda, rótulo, dados binários e o texto da legenda como uma string UTF-8.

**Remover Legendas de um Quadro de Vídeo**

1. Carregue a apresentação que contém o vídeo.
2. Obtenha o objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) alvo.
3. Remova as faixas de legenda da [CaptionsCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/) .
4. Salve a apresentação modificada.

O código a seguir mostra como remover todas as legendas de um quadro de vídeo:

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

## **Extrair Vídeo de Slides**

Além de adicionar vídeos a slides, o Aspose.Slides permite extrair vídeos incorporados em apresentações.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) para carregar a apresentação que contém o vídeo.
2. Itere por todos os objetos [Slide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/) .
3. Itere por todos os objetos [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) para encontrar um [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) .
4. Salve o vídeo no disco.

Este código Python mostra como extrair o vídeo de um slide de apresentação:

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

## **FAQ**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um VideoFrame?**

Você pode controlar o [modo de reprodução](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setPlayMode) (auto ou ao clicar) e o [looping](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setPlayLoopMode). Essas opções estão disponíveis nas propriedades do objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) .

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você adiciona um vídeo online, um link e uma miniatura são incorporados, de modo que o aumento de tamanho é menor.

**Posso substituir o vídeo em um VideoFrame existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [conteúdo do vídeo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/#setEmbeddedVideo) dentro do quadro preservando a geometria da forma; esse é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [tipo de conteúdo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/video/#getContentType) que pode ser lido e usado, por exemplo ao salvá‑lo no disco.