---
title: Adicionar vídeos a apresentações em Python
linktitle: Quadro de vídeo
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
description: "Aprenda a adicionar e extrair programaticamente quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET. Guia rápido passo a passo."
---
## **Introdução**

Um vídeo bem posicionado em uma apresentação pode tornar sua mensagem mais atraente e aumentar os níveis de engajamento com o público.

O PowerPoint permite que você adicione vídeos a um slide em uma apresentação de duas maneiras:

* Adicionar ou incorporar um vídeo local (armazenado na sua máquina)
* Adicionar um vídeo online (de uma fonte web como o YouTube).

Para permitir que você adicione vídeos (objetos de vídeo) a uma apresentação, o Aspose.Slides fornece a classe [Video](https://reference.aspose.com/slides/pt/python-net/aspose.slides/video/) , a classe [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) e outros tipos relevantes. 

## **Criar quadro de vídeo incorporado**

Se o arquivo de vídeo que você deseja adicionar ao seu slide estiver armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo na sua apresentação. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Obtenha a referência de um slide através de seu índice. 
1. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/python-net/aspose.slides/video/) e passe o caminho do arquivo de vídeo para incorporar o vídeo na apresentação. 
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

Alternativamente, você pode adicionar um vídeo passando seu caminho de arquivo diretamente para o método `add_video_frame(x, y, width, height, fname)` :

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Criar quadro de vídeo com vídeo de fonte web**

Versões mais recentes do Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) suportam vídeos online em apresentações. Se o vídeo que você deseja usar estiver disponível online (por exemplo, no YouTube), você pode adicioná‑lo à sua apresentação por meio do link da web.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) 
1. Obtenha a referência de um slide através de seu índice. 
1. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/python-net/aspose.slides/video/) e passe o link para o vídeo.
1. Defina uma miniatura para o quadro de vídeo. 
1. Salve a apresentação. 

Este código Python mostra como adicionar um vídeo da web a um slide em uma apresentação do PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Adiciona um VideoFrame
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

## **Cortar um quadro de vídeo**

O Aspose.Slides permite que você controle qual parte de um vídeo é reproduzida definindo os valores trim‑from‑start e trim‑from‑end através de [VideoFrame.trim_from_start](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/trim_from_start/) e [VideoFrame.trim_from_end](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/trim_from_end/). Ambos os valores são especificados em milissegundos e definem quanto tempo é pulado do início e do final do vídeo, respectivamente. Essas configurações alteram as opções de reprodução do vídeo na apresentação; elas não cortam nem modificam os dados binários do vídeo incorporado.

**Definir configurações de corte**

Para criar um quadro de vídeo e definir suas configurações de corte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/python-net/aspose.slides/video/) à apresentação.
1. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) a um slide.
1. Defina os valores trim‑from‑start e trim‑from‑end através de [VideoFrame.trim_from_start](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/trim_from_start/) e [VideoFrame.trim_from_end](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/trim_from_end/) .
1. Salve a apresentação modificada.

O exemplo de código a seguir pula os primeiros 2,5 segundos e o último segundo de um vídeo incorporado durante a reprodução:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Ler configurações de corte**

Para inspecionar as configurações de corte existentes, carregue uma apresentação, encontre um objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) entre as formas no primeiro slide e leia os valores através de [VideoFrame.trim_from_start](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/trim_from_start/) e [VideoFrame.trim_from_end](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/trim_from_end/) .

O exemplo de código a seguir encontra o primeiro quadro de vídeo no primeiro slide e relata suas configurações de corte em milissegundos:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **Gerenciar legendas de vídeo**

O Aspose.Slides permite que você gerencie legendas fechadas para quadros de vídeo em apresentações do PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas por meio da propriedade [VideoFrame.caption_tracks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/caption_tracks/) .

**Adicionar legendas a um quadro de vídeo**

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

**Extrair legendas de um quadro de vídeo**

Para extrair legendas de um quadro de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Encontre o objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) alvo.
1. Percorra a coleção [caption_tracks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/caption_tracks/) .
1. Salve cada faixa de legenda em um arquivo `.vtt` .

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

Cada objeto [Captions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captions/) expõe o identificador da legenda, rótulo, dados binários e texto da legenda como uma string UTF‑8.

**Remover legendas de um quadro de vídeo**

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

## **Extrair vídeo do slide**

Além de adicionar vídeos aos slides, o Aspose.Slides permite que você extraia vídeos incorporados em apresentações.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para carregar a apresentação que contém o vídeo. 
2. Percorra todos os objetos [Slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/) .
3. Percorra todos os objetos [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/) para encontrar um [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) . 
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

Você pode controlar o [modo de reprodução](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/play_mode/) (automático ou ao clicar) e o [looping](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/play_loop_mode/). Essas opções estão disponíveis nas propriedades do objeto [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) .

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você adiciona um vídeo online, um link e uma miniatura são incorporados, de modo que o aumento de tamanho é menor.

**Posso substituir o vídeo em um VideoFrame existente sem mudar sua posição e tamanho?**

Sim. Você pode trocar o [conteúdo de vídeo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/embedded_video/) dentro do quadro mantendo a geometria da forma; esse é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [tipo de conteúdo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/video/content_type/) que pode ser lido e usado, por exemplo ao salvá‑‑lo no disco.