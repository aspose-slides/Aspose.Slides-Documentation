---
title: Gerenciar áudio em apresentações usando JavaScript
linktitle: Quadro de áudio
type: docs
weight: 10
url: /pt/nodejs-java/audio-frame/
keywords:
- áudio
- quadro de áudio
- miniatura
- adicionar áudio
- propriedades de áudio
- opções de áudio
- extrair áudio
- Node.js
- JavaScript
- Aspose.Slides
description: "Crie e controle quadros de áudio no Aspose.Slides para Node.js — exemplos para incorporar, cortar, repetir e configurar a reprodução em apresentações PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica como trabalhar com quadros de áudio no Aspose.Slides. Ele mostra como adicionar áudio incorporado aos slides, personalizar a miniatura do quadro de áudio, configurar opções de reprodução como volume, repetição, ocultação, corte e durações de fade, e extrair o áudio usado nas transições de apresentação de slides.

## **Criar quadros de áudio**

O Aspose.Slides para Node.js via Java permite adicionar arquivos de áudio aos slides. Os arquivos de áudio são incorporados aos slides como quadros de áudio.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice.
3. Carregue o fluxo do arquivo de áudio que deseja incorporar no slide.
4. Adicione o quadro de áudio incorporado (contendo o arquivo de áudio) ao slide.
5. Defina [PlayMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AudioPlayModePreset) e `Volume` expostos pelo objeto [AudioFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AudioFrame).
6. Salve a apresentação modificada.

```javascript
// Instancia uma classe Presentation que representa um arquivo de apresentação
const pres = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide
    const sld = pres.getSlides().get_Item(0);
    // Carrega o arquivo de som wav para stream
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Adiciona o Quadro de Áudio
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Define o modo de reprodução e o volume do áudio
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Grava o arquivo PowerPoint no disco
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alterar miniatura do quadro de áudio**

Ao adicionar um arquivo de áudio a uma apresentação, o áudio aparece como um quadro com uma imagem padrão (veja a imagem na seção abaixo). Você pode alterar a imagem de visualização do quadro de áudio (defina sua imagem preferida).

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Adiciona um quadro de áudio ao slide com posição e tamanho especificados.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Adiciona uma imagem aos recursos da apresentação.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Define a imagem para o quadro de áudio.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Salva a apresentação modificada no disco
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Alterar opções de reprodução de áudio**

O Aspose.Slides para Node.js via Java permite alterar opções que controlam a reprodução ou propriedades de um áudio. Por exemplo, você pode ajustar o volume de um áudio, definir o áudio para reprodução em loop ou até ocultar o ícone de áudio.

O painel **Opções de áudio** no Microsoft PowerPoint:

![exemplo1_imagem](audio_frame_0.png)

Opções de áudio do PowerPoint que correspondem às propriedades [AudioFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/) do Aspose.Slides:
- **Iniciar** (lista suspensa) corresponde ao método [AudioFrame.setPlayMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** corresponde ao método [AudioFrame.setVolume](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Reproduzir em todos os slides** corresponde ao método [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop até parar** corresponde ao método [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Ocultar durante a apresentação** corresponde ao método [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Retroceder após a reprodução** corresponde ao método [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

Opções de **Edição** do PowerPoint que correspondem às propriedades [AudioFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/) do Aspose.Slides:
- **Fade In** corresponde ao método [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** corresponde ao método [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Cortar início do áudio** corresponde ao método [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Cortar fim do áudio** o valor corresponde à duração do áudio menos o valor do método [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

O **controle de volume** do PowerPoint no painel de controle de áudio corresponde ao método [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Ele permite alterar o volume do áudio em porcentagem.

É assim que você altera as opções de reprodução de áudio:
1. [Crie](#create-audio-frame) ou obtenha o Quadro de Áudio.
2. Defina novos valores para as propriedades do Quadro de Áudio que deseja ajustar.
3. Salve o arquivo PowerPoint modificado.

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtém a forma AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Define o modo de reprodução para reproduzir ao clicar
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Define o volume como Baixo
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Define o áudio para reproduzir em todos os slides
    audioFrame.setPlayAcrossSlides(true);
    // Desativa o loop para o áudio
    audioFrame.setPlayLoopMode(false);
    // Oculta o AudioFrame durante a apresentação
    audioFrame.setHideAtShowing(true);
    // Rebobina o áudio para o início após a reprodução
    audioFrame.setRewindAudio(true);
    // Salva o arquivo PowerPoint no disco
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Este exemplo JavaScript mostra como adicionar um novo quadro de áudio com áudio incorporado, cortá‑lo e definir as durações de fade:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Define o deslocamento de início do corte para 1,5 segundos
    audioFrame.setTrimFromStart(1500);
    // Define o deslocamento de fim do corte para 2 segundos
    audioFrame.setTrimFromEnd(2000);

    // Define a duração do fade-in para 200 ms
    audioFrame.setFadeInDuration(200);
    // Define a duração do fade-out para 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

O exemplo de código a seguir mostra como recuperar um quadro de áudio com áudio incorporado e definir seu volume para 85%:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Obtém uma forma de quadro de áudio
    const audioFrame = slide.getShapes().get_Item(0);

    // Define o volume do áudio para 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Gerenciar legendas de áudio**

O Aspose.Slides permite adicionar legendas fechadas a um quadro de áudio através do método [getCaptionTracks](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Esse método retorna uma [CaptionsCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/), que permite adicionar faixas de legenda WebVTT, iterar pelas faixas existentes e removê‑las quando necessário.

**Adicionar legendas de áudio**

Use o método [getCaptionTracks](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) para anexar uma ou mais faixas de legenda a um quadro de áudio. No exemplo a seguir, um arquivo de áudio é adicionado a um slide e, em seguida, uma nova faixa de legenda é carregada de um arquivo `.vtt`.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Adicionar uma nova faixa de legenda a partir de um arquivo WebVTT.
    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Extrair legendas de áudio**

Você pode iterar pelas faixas de legenda associadas a um quadro de áudio e salvá‑las como arquivos `.vtt`. Cada faixa de legenda expõe seus dados binários e identificador exclusivo, que podem ser usados ao exportar legendas.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // Salvar a faixa de legenda como um arquivo .vtt.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Remover legendas de áudio**

Para remover legendas de um quadro de áudio, use os métodos fornecidos pela [CaptionsCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/), como [clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/#removeAt). O exemplo a seguir remove todas as faixas de legenda de um quadro de áudio.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // tipo: aspose.slides.AudioFrame

    // Remover todas as faixas de legenda do quadro de áudio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extrair áudio**

O Aspose.Slides para Node.js via Java permite extrair o som usado nas transições de apresentação de slides. Por exemplo, você pode extrair o som usado em um slide específico.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) e carregue a apresentação que contém o áudio.
2. Obtenha a referência do slide relevante através de seu índice.
3. Acesse as [transições de apresentação de slides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) do slide.
4. Extraia o som em dados binários.

```javascript
// Instancia uma classe Presentation que representa um arquivo de apresentação
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Acessa o slide desejado
    const slide = pres.getSlides().get_Item(0);
    // Obtém os efeitos de transição da apresentação de slides para o slide
    const transition = slide.getSlideShowTransition();
    // Extrai o som em um array de bytes
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas frequentes**

**Posso reutilizar o mesmo recurso de áudio em vários slides sem aumentar o tamanho do arquivo?**

Sim. Adicione o áudio uma única vez à [coleção de áudio](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getaudios/) compartilhada da apresentação e crie quadros de áudio adicionais que façam referência a esse recurso existente. Isso evita duplicação de dados de mídia e mantém o tamanho da apresentação sob controle.

**Posso substituir o som em um quadro de áudio existente sem recriar a forma?**

Sim. Para um som vinculado, atualize o [caminho do link](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) para apontar para o novo arquivo. Para um som incorporado, troque o objeto [áudio incorporado](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) por outro da [coleção de áudio](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getaudios/) da apresentação. A formatação do quadro e a maioria das configurações de reprodução permanecem intactas.

**O corte altera os dados de áudio subjacentes armazenados na apresentação?**

Não. O corte ajusta apenas os limites de reprodução. Os bytes originais do áudio permanecem inalterados e acessíveis através do áudio incorporado ou da coleção de áudio da apresentação.