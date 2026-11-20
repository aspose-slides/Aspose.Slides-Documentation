---
title: Gerenciar quadros de áudio em apresentações usando Python
linktitle: Quadro de Áudio
type: docs
weight: 10
url: /pt/python-java/audio-frame/
keywords:
- áudio
- quadro de áudio
- miniatura
- adicionar áudio
- propriedades de áudio
- opções de áudio
- extrair áudio
- Python
- Aspose.Slides
description: "Incorpore áudio em slides, altere o ícone de áudio, configure a reprodução, gerencie legendas WebVTT e extraia sons de transição de slides com Aspose.Slides para Python via Java."
---
## **Visão geral**

Um quadro de áudio permite reproduzir um som em um slide. Com Aspose.Slides for Python via Java, você pode incorporar um clipe de áudio, escolher a imagem que o representa, ajustar a reprodução e anexar legendas. Também é possível recuperar um som atribuído a uma transição de slide.

## **Criar quadros de áudio**

Adicione os bytes de `audio.wav` à coleção de áudio da apresentação e, em seguida, use [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) para incorporar um clipe de áudio local no primeiro slide. As duas primeiras coordenadas posicionam o quadro no slide e os dois valores seguintes definem sua largura e altura, todos em pontos. Este exemplo chama [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) para iniciar o clipe automaticamente e chama [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) para selecionar o preset alto.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alterar a miniatura do quadro de áudio**

Por padrão, um quadro de áudio exibe um ícone de alto-falante. Para exibir uma miniatura personalizada, adicione uma imagem à apresentação com [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) e defina-a na imagem do quadro com [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). O exemplo usa um JPEG como miniatura para um clipe de áudio incorporado.

```python
from pathlib import Path

import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alterar opções de reprodução de áudio**

Os controles **Audio Options** do PowerPoint determinam quando um clipe começa, quão alto ele soa e como ele se comporta durante a apresentação de slides.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Controle do PowerPoint | Método Aspose.Slides for Python via Java |
| --- | --- |
| Iniciar | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Predefinição de volume | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Play Across Slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Loop até parar | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Ocultar durante a apresentação | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Retroceder após a reprodução | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Cortar início do áudio | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Cortar fim do áudio | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Controle deslizante de volume | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

O exemplo encontra o primeiro quadro de áudio no primeiro slide, chama [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) para iniciar a reprodução com um clique e seleciona a predefinição de volume baixo. O clipe continua em vários slides com o loop desativado. O ícone permanece oculto durante a apresentação e o clipe retrocede após a reprodução.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # Reproduzir ao clicar em volume baixo, em todos os slides, sem repetição.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Ocultar o quadro durante a apresentação e retroceder após a reprodução.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

Para um clipe com mais de 3,5 segundos, este exemplo omite os primeiros 1,5 segundos e os últimos 2 segundos. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) recebe a duração a ser omitida do final do clipe. Para obter o tempo final mostrado no PowerPoint, subtraia esse deslocamento da duração total do clipe. O clipe recortado faz fade in em 200 milissegundos e fade out em 500 milissegundos. Todos os quatro métodos aceitam valores em milissegundos.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Recortar 1,5 segundos do início e 2 segundos do final.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Definir fade-in para 200 ms e fade-out para 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para definir o volume de reprodução como uma porcentagem específica, use [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). Este exemplo define o primeiro quadro de áudio no primeiro slide para 85%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **Gerenciar legendas de áudio**

Cada quadro de áudio fornece acesso às suas faixas de legendas através de [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Use a coleção para anexar legendas WebVTT ao clipe, exportar faixas existentes ou removê‑las.

### **Adicionar legendas de áudio**

O exemplo incorpora um clipe de áudio no primeiro slide e usa [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) para anexar uma faixa WebVTT local. O primeiro argumento fornece o rótulo da faixa e o segundo identifica o arquivo que contém as legendas cronometradas.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Adicionar uma nova faixa de legenda a partir de um arquivo WebVTT.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Extrair legendas de áudio**

Este exemplo exporta cada faixa de legenda anexada a um quadro de áudio no primeiro slide. Ele grava os bytes retornados por [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) em um arquivo WebVTT e usa o identificador retornado por [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) como nome do arquivo, de modo que cada faixa tenha uma saída separada.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Salvar a faixa de legenda como um arquivo .vtt.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Remover legendas de áudio**

Use [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) para excluir uma faixa individual. O exemplo usa [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) para remover todas as legendas do primeiro quadro de áudio no primeiro slide, mantendo o clipe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **Encontrar uma linha nas legendas de áudio**

Para encontrar uma linha nas legendas de áudio do primeiro slide, pesquise o texto retornado por [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) na memória. Em um cue WebVTT em texto simples, a linha de tempo contém `-->`, as linhas de legenda seguem‑a e uma linha em branco encerra o cue. Este exemplo imprime o rótulo da faixa e cada linha de legenda que contém “café”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **Extrair áudio**

Uma transição de slide pode ter seu próprio som. Para recuperá‑lo, chame [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) na transição de slide. O exemplo acessa os bytes retornados por [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) e imprime o número de bytes. Se o primeiro slide não possuir som de transição, ele imprime uma mensagem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Posso reutilizar o mesmo clipe de áudio em vários slides sem duplicá‑lo?**

Sim. Adicione o clipe uma vez à [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) da apresentação e passe o mesmo objeto de áudio para [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) em cada slide.

**Posso substituir o som em um quadro de áudio existente?**

Sim. Para um som vinculado, use [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) para apontar para o arquivo de substituição. Para um som incorporado, selecione outro clipe da coleção de áudio da apresentação com [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Ambas as abordagens preservam o quadro existente.

**O recorte altera os dados de áudio armazenados na apresentação?**

Não. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) e [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) definem os limites da reprodução. Você ainda pode recuperar o clipe completo com [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).