---
title: Gerenciar áudio em apresentações usando Python
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
description: "Criar e controlar quadros de áudio no Aspose.Slides para Python via Java — exemplos de código para incorporar, cortar, repetir e configurar a reprodução em apresentações PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica como trabalhar com quadros de áudio no Aspose.Slides. Ele mostra como adicionar áudio incorporado aos slides, personalizar a miniatura do quadro de áudio, configurar opções de reprodução, como volume, repetição, ocultação, corte e durações de fade, e extrair o áudio usado nas transições de apresentação de slides.

## **Criar quadros de áudio**

Aspose.Slides for Python via Java permite adicionar arquivos de áudio aos slides. Os arquivos de áudio são incorporados nos slides como quadros de áudio. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Leia o arquivo de áudio que deseja incorporar ao slide.
4. Adicione o quadro de áudio incorporado (contendo o arquivo de áudio) ao slide.
5. Use [setPlayMode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setPlayMode) e [setVolume](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setVolume) expostos pelo objeto [AudioFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/).
6. Salve a apresentação modificada.

Este código Python mostra como adicionar um quadro de áudio incorporado a um slide:

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

Quando você adiciona um arquivo de áudio a uma apresentação, o áudio aparece como um quadro com uma imagem padrão (veja a imagem na seção abaixo). Você pode alterar a imagem de visualização do quadro de áudio para uma imagem de sua escolha.

Este código Python mostra como alterar a miniatura ou a imagem de visualização de um quadro de áudio:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
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

Aspose.Slides for Python via Java permite alterar opções que controlam a reprodução ou propriedades do áudio. Por exemplo, você pode ajustar o volume do áudio, definir o áudio para repetição ou até mesmo ocultar o ícone de áudio.

O painel **Audio Options** no Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** que correspondem às propriedades do [AudioFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/) do Aspose.Slides:
- **Start** lista suspensa corresponde ao método [setPlayMode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** corresponde ao método [setVolume](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** corresponde ao método [setPlayAcrossSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** corresponde ao método [setPlayLoopMode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** corresponde ao método [setHideAtShowing](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** corresponde ao método [setRewindAudio](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setRewindAudio)

Opções de **Edição** do PowerPoint que correspondem às propriedades do [AudioFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/) do Aspose.Slides:
- **Fade In** corresponde ao método [setFadeInDuration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fade Out** corresponde ao método [setFadeOutDuration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Trim Audio Start Time** corresponde ao método [setTrimFromStart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setTrimFromStart)
- **Trim Audio End Time** o valor é igual à duração do áudio menos o valor definido pelo método [setTrimFromEnd](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setTrimFromEnd)

O **controle de volume** do PowerPoint no painel de controle de áudio corresponde ao método [setVolumeValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setVolumeValue). Ele permite alterar o volume do áudio como porcentagem.

Assim você altera as opções de reprodução de áudio:
1. [Create](#create-audio-frames) ou obtenha o quadro de áudio.
2. Defina novos valores para as propriedades do quadro de áudio que deseja ajustar.
3. Salve o arquivo PowerPoint modificado.

Este código Python demonstra uma operação na qual as opções de áudio são ajustadas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Reproduzir ao clicar com volume baixo, em todas as slides, sem repetição.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Ocultar o quadro durante a apresentação de slides e retroceder após a reprodução.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Este exemplo Python mostra como adicionar um novo quadro de áudio com áudio incorporado, cortá‑lo e definir as durações de fade:

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
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Cortar 1,5 segundos do início e 2 segundos do final.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Definir fade-in para 200 ms e fade-out para 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O exemplo de código a seguir mostra como recuperar um quadro de áudio com áudio incorporado e definir seu volume para 85%:

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Gerenciar legendas de áudio**

Aspose.Slides permite adicionar legendas fechadas a um quadro de áudio através do método [getCaptionTracks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#getCaptionTracks). Esse método retorna uma [CaptionsCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/), que permite adicionar faixas de legenda WebVTT, iterar pelas faixas existentes e removê‑las quando necessário.

**Adicionar legendas de áudio**

Use o método [getCaptionTracks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#getCaptionTracks) para anexar uma ou mais faixas de legenda a um quadro de áudio. No exemplo a seguir, um arquivo de áudio é adicionado a um slide e, em seguida, uma nova faixa de legenda é carregada a partir de um arquivo `.vtt`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Adicionar uma nova faixa de legenda de um arquivo WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Extrair legendas de áudio**

Você pode iterar pelas faixas de legenda associadas a um quadro de áudio e salvá‑las como arquivos `.vtt`. Cada faixa de legenda expõe seus dados binários e identificador único, que podem ser usados ao exportar legendas.

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
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Remover legendas de áudio**

Para remover legendas de um quadro de áudio, use os métodos fornecidos pela [CaptionsCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/), como [clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/captionscollection/#removeAt). O exemplo a seguir remove todas as faixas de legenda de um quadro de áudio.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Extrair áudio**

Aspose.Slides for Python via Java permite extrair o som usado nas transições da apresentação de slides. Por exemplo, você pode extrair o som usado em um slide específico.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação que contém o áudio.
2. Obtenha uma referência ao slide relevante pelo seu índice.
3. Acesse as [slideshow transitions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getSlideShowTransition) do slide.
4. Extraia o som como dados de bytes.

Este código em Python mostra como extrair o áudio usado em um slide:

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
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Posso reutilizar o mesmo recurso de áudio em vários slides sem aumentar o tamanho do arquivo?**

Sim. Adicione o áudio uma vez à [audio collection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getAudios) compartilhada da apresentação e crie quadros de áudio adicionais que referenciam esse recurso existente. Isso evita duplicar os dados de mídia e mantém o tamanho da apresentação sob controle.

**Posso substituir o som em um quadro de áudio existente sem recriar a forma?**

Sim. Para um som vinculado, atualize o [link path](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setLinkPathLong) para apontar para o novo arquivo. Para um som incorporado, troque o objeto [embedded audio](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/#setEmbeddedAudio) por outro da [audio collection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getAudios) da apresentação. A formatação do quadro e a maioria das configurações de reprodução permanecem intactas.

**O corte altera os dados de áudio subjacentes armazenados na apresentação?**

Não. O corte ajusta apenas os limites de reprodução. Os bytes originais do áudio permanecem intactos e acessíveis através do áudio incorporado ou da coleção de áudio da apresentação.