---
title: Gerenciar frames de áudio em apresentações usando JavaScript
linktitle: Frame de áudio
type: docs
weight: 10
url: /pt/nodejs-java/audio-frame/
keywords:
- áudio
- frame de áudio
- miniatura
- adicionar áudio
- propriedades de áudio
- opções de áudio
- extrair áudio
- Node.js
- JavaScript
- Aspose.Slides
description: "Incorpore áudio em slides, altere o ícone de áudio, configure a reprodução, gerencie legendas WebVTT e extraia sons de transição de slides com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Um frame de áudio permite reproduzir um som em um slide. Com Aspose.Slides for Node.js via Java, você pode incorporar um clipe de áudio, escolher a imagem que o representa, ajustar a reprodução e anexar legendas. Você também pode recuperar um som atribuído a uma transição de slide.

## **Criar frames de áudio**

Use [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) para incorporar um clipe de áudio local no primeiro slide. As duas primeiras coordenadas posicionam o frame no slide, e os dois valores seguintes definem sua largura e altura, tudo em pontos. Este exemplo chama [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) para iniciar o clipe automaticamente e chama [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) para selecionar a predefinição alta.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alterar a miniatura do frame de áudio**

Por padrão, um frame de áudio exibe um ícone de alto-falante. Para exibir uma miniatura personalizada, adicione uma imagem à apresentação com [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) e defina-a na imagem do frame com [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage). O exemplo usa `eagle.jpeg` como a miniatura para um clipe de áudio incorporado.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alterar opções de reprodução de áudio**

Os controles de **Opções de Áudio** do PowerPoint determinam quando um clipe inicia, quão alto ele soa e como ele se comporta durante uma apresentação de slides.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint control | Aspose.Slides for Node.js via Java method |
| --- | --- |
| Iniciar | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Predefinição de volume | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Reproduzir em todos os slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Loop até parar | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Ocultar durante a apresentação | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Retroceder após reproduzir | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Fade in | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fade out | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Cortar início do áudio | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Cortar fim do áudio | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Controle deslizante de volume | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

O exemplo encontra o primeiro frame de áudio no primeiro slide, chama [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) para iniciar a reprodução ao clicar e seleciona a predefinição de volume baixo. O clipe continua entre slides com o looping desativado. O ícone permanece oculto durante a apresentação, e o clipe retrocede após a reprodução.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Para um clipe com mais de 3,5 segundos, este exemplo pula os primeiros 1,5 segundos e os últimos 2 segundos. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) recebe a duração a ser omitida do final do clipe. Para obter o tempo final exibido no PowerPoint, subtraia esse deslocamento da duração total do clipe. O clipe cortado faz fade in em 200 milissegundos e fade out em 500 milissegundos. Todos os quatro métodos recebem valores em milissegundos.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para definir o volume de reprodução em uma porcentagem específica, use [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Este exemplo define o primeiro frame de áudio no primeiro slide para 85 %.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Gerenciar legendas de áudio**

Cada frame de áudio fornece acesso às suas faixas de legenda por meio de [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Use a coleção para anexar legendas WebVTT ao clipe, exportar faixas existentes ou removê‑las.

### **Adicionar legendas de áudio**

O exemplo incorpora um clipe de áudio no primeiro slide e usa [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) para anexar uma faixa WebVTT local. O primeiro argumento fornece o rótulo da faixa, e o segundo identifica o arquivo que contém as legendas cronometradas.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Extrair legendas de áudio**

Este exemplo exporta cada faixa de legenda anexada a um frame de áudio no primeiro slide. Ele grava os bytes retornados por [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) em um arquivo WebVTT e usa o identificador retornado por [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) como nome do arquivo, de modo que cada faixa tenha uma saída separada.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **Remover legendas de áudio**

Use [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) para excluir uma faixa individual. O exemplo usa [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) para remover todas as legendas do primeiro frame de áudio no primeiro slide, preservando o clipe.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Encontrar uma linha nas legendas de áudio**

Para encontrar uma linha nas legendas de áudio no primeiro slide, procure o texto retornado por [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) na memória. Em uma cue WebVTT em texto simples, a linha de tempo contém `-->`, as linhas de legenda seguem‑na, e uma linha em branco finaliza a cue. Este exemplo imprime o rótulo da faixa e cada linha de legenda que contém “café”.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extrair áudio**

Uma transição de slide pode ter seu próprio som. Para recuperá‑lo, chame [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) na transição de slide. O exemplo acessa os bytes retornados por [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) e imprime o número de bytes. Se o primeiro slide não possuir som de transição, ele imprime uma mensagem em vez disso.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso reutilizar o mesmo clipe de áudio em vários slides sem duplicá‑lo?**

Sim. Adicione o clipe uma vez à [coleção de áudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) e passe o mesmo objeto de áudio para [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) em cada slide.

**Posso substituir o som em um frame de áudio existente?**

Sim. Para um som vinculado, use [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) para apontar para o arquivo de substituição. Para um som incorporado, selecione outro clipe da coleção de áudio da apresentação com [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio). Ambas as abordagens preservam o frame existente.

**O corte altera os dados de áudio armazenados na apresentação?**

Não. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) e [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) definem limites de reprodução. Você ainda pode recuperar o clipe completo por meio de [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio).