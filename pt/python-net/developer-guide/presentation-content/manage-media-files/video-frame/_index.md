---
title: Adicionar Vídeos a Apresentações em Python
linktitle: Quadro de Vídeo
type: docs
weight: 10
url: /pt/python-net/video-frame/
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
description: "Aprenda a adicionar e extrair quadros de vídeo programaticamente em slides PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET. Guia rápido passo a passo."
---
## **Introdução**

Um vídeo bem colocado em uma apresentação pode tornar sua mensagem mais impactante e aumentar os níveis de engajamento com o seu público. 

O PowerPoint permite que você adicione vídeos a um slide em uma apresentação de duas maneiras:

* Adicionar ou incorporar um vídeo local (armazenado em sua máquina)
* Adicionar um vídeo online (de uma fonte web como o YouTube).

Para permitir que você adicione vídeos (objetos de vídeo) a uma apresentação, o Aspose.Slides fornece as classes [Video](https://reference.aspose.com/slides/pt/python-net/aspose.slides/video/) , [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) e outros tipos relevantes. 

## **Criar Quadro de Vídeo Incorporado**

Se o arquivo de vídeo que você deseja adicionar ao seu slide está armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo em sua apresentação. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Obtenha a referência de um slide através de seu índice. 
1. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/python-net/aspose.slides/video/) e passe o caminho do arquivo de vídeo para incorporá-lo na apresentação. 
1. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) para criar um quadro para o vídeo.  
1. Salve a apresentação modificada. 

Este código Python mostra como adicionar um vídeo armazenado localmente a uma apresentação:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Obtém o primeiro slide e adiciona um quadro de vídeo
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Salva a apresentação no disco
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternativamente, você pode adicionar um vídeo passando seu caminho de arquivo diretamente para o método `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Criar Quadro de Vídeo com Vídeo de Fonte Web**

O Microsoft PowerPoint 2013 e versões mais recentes suportam vídeos do YouTube em apresentações. Se o vídeo que você deseja usar está disponível online (por exemplo, no YouTube), você pode adicioná-lo à sua apresentação por meio de seu link web. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) 
1. Obtenha a referência de um slide através de seu índice. 
1. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/python-net/aspose.slides/video/) e passe o link do vídeo.
1. Defina uma miniatura para o quadro de vídeo. 
1. Salve a apresentação. 

Este código Python mostra como adicionar um vídeo da web a um slide em uma apresentação PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Adiciona um videoFrame
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Carrega a miniatura
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenciar Legendas de Vídeo**

O Aspose.Slides permite que você gerencie legendas fechadas para quadros de vídeo em apresentações PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas por meio da propriedade [VideoFrame.caption_tracks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/caption_tracks/) .

**Adicionar Legendas a um Quadro de Vídeo**

Para adicionar legendas a um quadro de vídeo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Adicione um vídeo à apresentação.
1. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) a um slide.
1. Use a [CaptionsCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captionscollection/) retornada por [caption_tracks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/caption_tracks/) para adicionar uma faixa de legenda WebVTT.
1. Salve a apresentação modificada.

O código a seguir mostra como adicionar legendas a um quadro de vídeo:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Adiciona uma nova faixa de legendas a partir de um arquivo WebVTT.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

A classe [CaptionsCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captionscollection/) também fornece uma sobrecarga que permite adicionar legendas a partir de um fluxo.

**Extrair Legendas de um Quadro de Vídeo**

Para extrair legendas de um quadro de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Encontre o objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) alvo.
1. Itere através da coleção [caption_tracks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/caption_tracks/) .
1. Salve cada faixa de legenda em um arquivo `.vtt`.

O código a seguir mostra como extrair legendas de um quadro de vídeo:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Salva a faixa de legendas em um arquivo WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Cada objeto [Captions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captions/) expõe o identificador da legenda, rótulo, dados binários e o texto da legenda como uma string UTF-8.

**Remover Legendas de um Quadro de Vídeo**

Para remover legendas de um quadro de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Obtenha o objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) alvo.
1. Remova as faixas de legenda da [CaptionsCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captionscollection/) .
1. Salve a apresentação modificada.

O código a seguir mostra como remover todas as legendas de um quadro de vídeo:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # tipo: slides.VideoFrame

    # Remove todas as legendas do quadro de vídeo.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Se precisar remover apenas uma faixa de legenda, use os métodos [remove](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captionscollection/remove/) ou [remove_at](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captionscollection/remove_at/) em vez de [clear](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captionscollection/clear/) .

## **Extrair Vídeo de um Slide**

Além de adicionar vídeos aos slides, o Aspose.Slides permite extrair vídeos incorporados em apresentações.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para carregar a apresentação que contém o vídeo. 
2. Itere por todos os objetos [Slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/) .
3. Itere por todos os objetos [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/) para encontrar um [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) . 
4. Salve o vídeo no disco.

Este código Python mostra como extrair o vídeo de um slide de apresentação:

```python
import aspose.slides as slides

# Instancia um objeto Presentation que representa um arquivo de apresentação 
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um VideoFrame?**

Você pode controlar o [playback mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/play_mode/) (automático ou ao clique) e o [looping](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/play_loop_mode/). Essas opções estão disponíveis por meio das propriedades do objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) .

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você adiciona um vídeo online, um link e uma miniatura são incorporados, de modo que o aumento de tamanho é menor.

**Posso substituir o vídeo em um VideoFrame existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [video content](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/embedded_video/) dentro do quadro mantendo a geometria da forma; esse é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado tem um [content type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/video/content_type/) que pode ser lido e usado, por exemplo, ao salvá‑lo no disco.