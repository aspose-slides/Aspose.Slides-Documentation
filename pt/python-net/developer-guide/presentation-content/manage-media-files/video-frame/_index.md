---
title: Gerenciar Quadros de Vídeo em Apresentações em Python
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
description: "Aprenda a programar a adição e extração de quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET. Guia rápido passo a passo."
---
## **Introdução**

Os vídeos podem ajudar a explicar ideias e envolver o público. Aspose.Slides for Python via .NET permite adicionar quadros de vídeo aos slides, ajustar configurações de reprodução, gerenciar legendas e extrair dados de vídeo incorporados.

O PowerPoint suporta vídeos locais e links para vídeos online, como vídeos do YouTube.

Para representar dados de vídeo e quadros de vídeo, Aspose.Slides fornece a [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) class, [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) class, e outros tipos relevantes.

## **Criar um Quadro de Vídeo Incorporado**

Se o arquivo de vídeo que você deseja adicionar ao seu slide está armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo na sua apresentação.

Este exemplo incorpora um vídeo local no primeiro slide de uma apresentação existente e salva o resultado. As coordenadas e dimensões do quadro estão em pontos. O fluxo permanece aberto até que a gravação termine porque [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) o mantém bloqueado enquanto a apresentação o usa.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Você também pode passar um caminho de vídeo local diretamente para [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Este exemplo incorpora o vídeo no primeiro slide de uma nova apresentação. O vídeo deve permanecer acessível até que a apresentação seja salva.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Criar um Quadro de Vídeo com Vídeo de uma Fonte Web**

O Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) suporta vídeos online em apresentações. Você pode criar um quadro de vídeo que vincula a um vídeo online, como um vídeo do YouTube.

Este exemplo adiciona um link de vídeo do YouTube e uma miniatura ao primeiro slide. Substitua o identificador do vídeo para usar outro vídeo. A configuração [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) solicita reprodução automática. Baixar a miniatura e reproduzir o vídeo requer acesso à internet. O visualizador da apresentação também deve suportar a reprodução de vídeo online.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Reproduzir um Vídeo em Modo de Tela Cheia**

Em uma apresentação de treinamento, você pode reproduzir uma demonstração de software em modo de tela cheia para que o público veja os detalhes. Defina [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) como `True` para habilitar esse comportamento durante a reprodução.

Este exemplo abre uma apresentação, encontra o primeiro [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) no primeiro slide e habilita a reprodução em tela cheia. A apresentação de entrada deve conter ao menos um slide com um quadro de vídeo existente no primeiro slide.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

A reprodução em tela cheia controla como o vídeo é exibido. Independentemente disso, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) controla se ele inicia automaticamente ou ao clicar, e [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) controla se ele se repete. Para escolher o comportamento de início, defina o modo de reprodução para [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). O exemplo preserva as configurações existentes de início e loop.

## **Retroceder um Vídeo Após a Reprodução**

Em uma apresentação de treinamento, retornar um vídeo de demonstração ao início o deixa pronto para o apresentador reproduzir novamente. Defina [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) como `True` para devolver o vídeo ao início após a reprodução terminar.

Este exemplo abre uma apresentação, encontra o primeiro [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) no primeiro slide e habilita o retrocesso. Ele desabilita o loop para que a reprodução possa terminar e define a reprodução para iniciar ao clicar. A apresentação de entrada deve conter ao menos um slide com um quadro de vídeo existente no primeiro slide.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

O retrocesso devolve o vídeo ao início sem iniciá-lo novamente. Em contraste, habilitar [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) repete a reprodução automaticamente. Mantenha o loop desativado quando desejar que o vídeo termine e permaneça pronto para ser reproduzido novamente. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) controla independentemente o início automático ou ao clicar; este exemplo usa [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) para que o apresentador controle quando a reprodução começa. Defina o modo de reprodução após a configuração de loop, como mostrado no exemplo. O retrocesso funciona independentemente de [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Cortar um Quadro de Vídeo**

Use [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) e [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) para pular parte do início ou do fim de um vídeo durante a reprodução. Ambos os valores estão em milissegundos. O corte altera as configurações de reprodução sem modificar os dados de vídeo incorporados.

**Definir Configurações de Corte**

Este exemplo incorpora um vídeo local e pula os primeiros 2,5 segundos e o último segundo durante a reprodução. Use um vídeo com mais de 3,5 segundos para que ainda reste um segmento reproduzível.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Ler Configurações de Corte**

Este exemplo imprime os valores de corte do primeiro quadro de vídeo no primeiro slide em milissegundos. A apresentação deve conter ao menos um slide. Se esse slide não tiver quadro de vídeo, nada será impresso. O exemplo anterior produz valores de 2500 e 1000.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Gerenciar Legendas de Vídeo**

Aspose.Slides permite gerenciar legendas fechadas para quadros de vídeo em apresentações PowerPoint. As legendas são armazenadas no formato WebVTT e expostas através da propriedade [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

### **Adicionar Legendas a um Quadro de Vídeo**

Este exemplo incorpora um vídeo local e adiciona uma faixa de legendas WebVTT rotulada como English. Os carimbos de tempo das legendas devem corresponder ao vídeo. A apresentação salva inclui tanto o vídeo quanto suas legendas.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

A classe [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) também fornece uma sobrecarga que permite adicionar legendas a partir de um fluxo.

### **Extrair Legendas de um Quadro de Vídeo**

Este exemplo salva todas as faixas de legendas de quadros de vídeo no primeiro slide como arquivos WebVTT separados. Números sequenciais mantêm os arquivos de saída distintos. O console relata o número de faixas extraídas. A apresentação deve conter ao menos um slide.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Cada objeto [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) expõe o identificador da legenda, rótulo, dados binários e o texto da legenda como uma string UTF-8.

### **Remover Legendas de um Quadro de Vídeo**

Este exemplo remove todas as legendas do quadro de vídeo na primeira posição de forma no primeiro slide e salva o resultado. Assume-se que o slide e a forma existam e que a forma seja um quadro de vídeo.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Se precisar remover apenas uma faixa de legenda, use os métodos [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) ou [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) em vez de [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

### **Pesquisar Legendas de Vídeo**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) retorna toda a faixa WebVTT, incluindo seu cabeçalho, linhas de temporização e texto da legenda. Por exemplo, uma faixa em English no slide 2 pode conter este cue:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Este exemplo abre `captioned_media.pptx` e lê os [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) de cada quadro de vídeo de nível superior em cada slide. Para cada cue de texto simples, ele encontra a linha de temporização que contém `-->` e coleta as linhas de legenda até a próxima linha em branco ou o fim da faixa. Ele procura no texto da legenda por “café” sem diferenciar maiúsculas e minúsculas e imprime o número do slide, rótulo da faixa, linha de temporização original e a legenda completa para cada correspondência.

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue

                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)

                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

A faixa de exemplo produz uma correspondência. “Café” no cabeçalho está fora do texto da legenda, e a saída preserva a configuração de temporização e ambas as linhas de legenda.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrair Vídeo de um Slide**

Além de adicionar vídeos aos slides, Aspose.Slides permite extrair vídeos incorporados em apresentações.

Este exemplo extrai vídeos incorporados de cada slide em arquivos binários separados e numerados. Vídeos vinculados são ignorados porque não possuem dados incorporados. O console imprime o tipo MIME de cada vídeo e a contagem total. A saída usa a extensão genérica `.bin`; altere-a para corresponder ao tipo de mídia relatado quando necessário.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **FAQ**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um quadro de vídeo?**

Você pode controlar o [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automático ou ao clicar) e o [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Essas opções estão disponíveis através das propriedades do objeto [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você vincula a um vídeo online e adiciona uma miniatura, a apresentação armazena o link e a imagem de pré‑visualização em vez dos dados do vídeo, então o aumento de tamanho costuma ser menor.

**Posso substituir o vídeo em um quadro de vídeo existente sem mudar sua posição e tamanho?**

Sim. Você pode trocar o [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) dentro do quadro preservando a geometria da forma; este é um cenário comum para atualizar a mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) que você pode ler e usar, por exemplo ao salvá‑lo em disco.