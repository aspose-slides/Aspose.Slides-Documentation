---
title: Gerenciar áudio em apresentações usando Python
linktitle: Quadro de áudio
type: docs
weight: 10
url: /pt/python-net/audio-frame/
keywords:
- adicionar áudio
- incorporar áudio
- quadro de áudio
- arquivo de áudio
- propriedades de áudio
- extrair áudio
- recuperar áudio
- alterar áudio
- opções de reprodução
- modo de reprodução
- reproduzir entre slides
- repetir até interromper
- ocultar durante a apresentação
- retroceder após reproduzir
- volume do áudio
- imagem padrão
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Adicione, extraia e gerencie quadros de áudio em PPT, PPTX e ODP com Aspose.Slides for Python via .NET com facilidade. Explore exemplos de código e aprimore suas apresentações hoje."
---
## **Visão geral**

Este artigo explica como trabalhar com quadros de áudio no Aspose.Slides. Ele mostra como adicionar áudio incorporado aos slides, personalizar a miniatura do quadro de áudio, configurar opções de reprodução como volume, repetição, ocultação, corte e durações de fade, e extrair o áudio usado nas transições de apresentação de slides.

## **Criar quadros de áudio**

Aspose.Slides for Python via .NET permite que você adicione arquivos de áudio aos slides. Os arquivos de áudio são incorporados nos slides como quadros de áudio.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha a referência de um slide pelo seu índice.
3. Carregue o fluxo do arquivo de áudio que deseja incorporar ao slide.
4. Adicione o quadro de áudio incorporado (contendo o arquivo de áudio) ao slide.
5. Defina [PlayMode](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioplaymodepreset) e `Volume` expostos pelo objeto [IAudioFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/).
6. Salve a apresentação modificada.

Este código Python mostra como adicionar um quadro de áudio incorporado a um slide:

```python
import aspose.slides as slides

# Instanciar uma classe de apresentação que representa um arquivo de apresentação
with slides.Presentation() as pres:
    # Obtém o primeiro slide
    sld = pres.slides[0]

    # Carrega o arquivo de som wav para o stream
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Adiciona o quadro de áudio
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Define o modo de reprodução e o volume do áudio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Grava o arquivo PowerPoint no disco
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Alterar miniatura do quadro de áudio**

Ao adicionar um arquivo de áudio a uma apresentação, o áudio aparece como um quadro com uma imagem padrão padrão (veja a imagem na seção abaixo). Você pode mudar a miniatura do quadro de áudio (definir sua imagem preferida).

Este código Python mostra como alterar a miniatura ou a imagem de pré‑visualização de um quadro de áudio:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adiciona um quadro de áudio ao slide com posição e tamanho especificados.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Adiciona uma imagem aos recursos da apresentação.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Define a imagem para o quadro de áudio.
        audioFrame.picture_format.picture.image = audioImage
        
        #Salva a apresentação modificada no disco
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Alterar opções de reprodução de áudio**

Aspose.Slides for Python via .NET permite que você altere opções que controlam a reprodução ou as propriedades de um áudio. Por exemplo, é possível ajustar o volume, definir o áudio para reprodução em loop ou até ocultar o ícone de áudio.

O painel **Opções de áudio** no Microsoft PowerPoint:

![exemplo1_imagem](audio_frame_0.png)

Opções de áudio do PowerPoint que correspondem às propriedades do Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/):

- **Início** lista suspensa corresponde à propriedade [AudioFrame.play_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/play_mode/)
- **Volume** corresponde à propriedade [AudioFrame.volume](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/volume/)
- **Reproduzir entre slides** corresponde à propriedade [AudioFrame.play_across_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/play_across_slides/)
- **Repetir até interromper** corresponde à propriedade [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/play_loop_mode/)
- **Ocultar durante a apresentação** corresponde à propriedade [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/hide_at_showing/)
- **Retroceder após reproduzir** corresponde à propriedade [AudioFrame.rewind_audio](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/rewind_audio/)

Opções de **Edição** do PowerPoint que correspondem às propriedades do Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/):

- **Fade In** corresponde à propriedade [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/fade_in_duration/)
- **Fade Out** corresponde à propriedade [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/fade_out_duration/)
- **Cortar início do áudio** corresponde à propriedade [AudioFrame.trim_from_start](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/trim_from_start/)
- **Cortar final do áudio** o valor corresponde à duração do áudio menos o valor da propriedade [AudioFrame.trim_from_end](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/trim_from_end/)

O **controle de volume** do PowerPoint no painel de controle de áudio corresponde à propriedade [AudioFrame.volume_value](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/volume_value/). Ele permite alterar o volume do áudio como uma porcentagem.

É assim que você altera as opções de reprodução de áudio:

1. [Criar](#create-audio-frame) ou obter o Quadro de Áudio.
2. Defina novos valores para as propriedades do Quadro de Áudio que deseja ajustar.
3. Salve o arquivo PowerPoint modificado.

Este código Python demonstra uma operação na qual as opções de um áudio são ajustadas:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Obtém a forma AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Define o modo de reprodução para reproduzir ao clicar
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Define o volume para Baixo
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Define o áudio para reproduzir entre os slides
    audioFrame.play_across_slides = True

    # Desativa o loop para o áudio
    audioFrame.play_loop_mode = False

    # Oculta o AudioFrame durante a apresentação de slides
    audioFrame.hide_at_showing = True

    # Rebobina o áudio para o início após a reprodução
    audioFrame.rewind_audio = True

    # Salva o arquivo PowerPoint no disco
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Este exemplo Python mostra como adicionar um novo quadro de áudio com áudio incorporado, recortá‑lo e definir as durações de fade:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Define o início do recorte para 1.5 segundos
    audio_frame.trim_from_start = 1500.0
    # Define o fim do recorte para 2 segundos
    audio_frame.trim_from_end = 2000.0

    # Define a duração do fade‑in para 200 ms
    audio_frame.fade_in_duration = 200.0
    # Define a duração do fade‑out para 500 ms
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

O exemplo de código a seguir mostra como recuperar um quadro de áudio incorporado e definir seu volume para 85%:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Obtém uma forma de quadro de áudio
    audio_frame = pres.slides[0].shapes[0]

    # Define o volume do áudio para 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenciar legendas de áudio**

Aspose.Slides permite que você adicione legendas fechadas a um quadro de áudio através da propriedade [caption_tracks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/caption_tracks/). Essa propriedade retorna uma [CaptionsCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captionscollection/), que permite adicionar faixas de legenda WebVTT, iterar pelas faixas existentes e removê‑las quando necessário.

**Adicionar legendas de áudio**

Use a propriedade [caption_tracks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/caption_tracks/) para anexar uma ou mais faixas de legenda a um quadro de áudio. No exemplo a seguir, um arquivo de áudio é adicionado a um slide e, em seguida, uma nova faixa de legenda é carregada a partir de um arquivo `.vtt`.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Adiciona uma nova faixa de legenda a partir de um arquivo WebVTT.
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Extrair legendas de áudio**

Você pode iterar pelas faixas de legenda associadas a um quadro de áudio e salvá‑las como arquivos `.vtt`. Cada faixa de legenda expõe seus dados binários e identificador único, que podem ser usados ao exportar as legendas.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Salve a faixa de legenda como um arquivo .vtt.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Remover legendas de áudio**

Para remover legendas de um quadro de áudio, use os métodos fornecidos por [CaptionsCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captionscollection/), como [clear](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captionscollection/remove/), ou [remove_at](https://reference.aspose.com/slides/pt/python-net/aspose.slides/captionscollection/remove_at/). O exemplo a seguir remove todas as faixas de legenda de um quadro de áudio.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # tipo: slides.AudioFrame

    # Remove todas as faixas de legenda do quadro de áudio.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrair áudio**

Aspose.Slides for Python via .NET permite que você extraia o som usado nas transições de apresentação de slides. Por exemplo, é possível extrair o som usado em um slide específico.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação que contém o áudio.
2. Obtenha a referência do slide relevante pelo seu índice.
3. Acesse as transições de apresentação para o slide.
4. Extraia o som em dados de bytes.

Este código Python mostra como extrair o áudio usado em um slide:

```python
import aspose.slides as slides

#com slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Acessa o slide desejado
    slide = pres.slides[0]  

    # Obtém os efeitos de transição de apresentação de slides para o slide
    transition = slide.slide_show_transition

    #Extrai o som em um array de bytes
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **Perguntas frequentes**

**Posso reutilizar o mesmo recurso de áudio em vários slides sem aumentar o tamanho do arquivo?**

Sim. Adicione o áudio uma única vez à [coleção de áudio compartilhada](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/audios/) da apresentação e crie quadros de áudio adicionais que façam referência a esse recurso existente. Isso evita a duplicação dos dados de mídia e mantém o tamanho da apresentação sob controle.

**Posso substituir o som em um quadro de áudio existente sem recriar a forma?**

Sim. Para um som vinculado, atualize o [caminho do link](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/link_path_long/) para apontar para o novo arquivo. Para um som incorporado, troque o objeto [embedded audio](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/embedded_audio/) por outro da [coleção de áudio](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/audios/) da apresentação. A formatação do quadro e a maioria das configurações de reprodução permanecem intactas.

**O corte altera os dados de áudio subjacentes armazenados na apresentação?**

Não. O corte ajusta apenas os limites de reprodução. Os bytes originais do áudio permanecem inalterados e acessíveis através do áudio incorporado ou da coleção de áudio da apresentação.