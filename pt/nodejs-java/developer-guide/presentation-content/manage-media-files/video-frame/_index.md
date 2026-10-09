---
title: Gerenciar Quadros de Vídeo em Apresentações Usando Node.js
linktitle: Quadro de Vídeo
type: docs
weight: 10
url: /pt/nodejs-java/video-frame/
keywords:
- adicionar vídeo
- criar vídeo
- incorporar vídeo
- extrair vídeo
- recuperar vídeo
- quadro de vídeo
- origem web
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a adicionar e extrair programaticamente quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para Node.js via Java. Guia prático rápido."
---
## **Introdução**

Os vídeos podem ajudar a explicar ideias e envolver o público. Aspose.Slides for Node.js via Java permite adicionar quadros de vídeo aos slides, ajustar as configurações de reprodução, gerenciar legendas e extrair dados de vídeo incorporados.

O PowerPoint oferece suporte a vídeos locais e a links para vídeos online, como vídeos do YouTube.

Para representar dados de vídeo e quadros de vídeo, Aspose.Slides fornece a classe [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) class, a classe [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) class e outros tipos relevantes.

## **Criar um Quadro de Vídeo Incorporado**

Se o arquivo de vídeo que você deseja adicionar ao seu slide estiver armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo na sua apresentação.

Este exemplo incorpora um vídeo local no primeiro slide de uma apresentação existente e salva o resultado. As coordenadas e dimensões do quadro estão em pontos. O fluxo permanece aberto até que a gravação termine porque [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) o mantém bloqueado enquanto a apresentação o utiliza.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

Você também pode passar o caminho de um vídeo local diretamente para [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Este exemplo incorpora o vídeo no primeiro slide de uma nova apresentação. O vídeo deve permanecer acessível até que a apresentação seja salva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Criar um Quadro de Vídeo com Vídeo de uma Fonte Web**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) oferece suporte a vídeos online em apresentações. Você pode criar um quadro de vídeo que vincula a um vídeo online, como um vídeo do YouTube.

Este exemplo adiciona um link de vídeo do YouTube e uma miniatura ao primeiro slide. Substitua o identificador do vídeo para usar outro vídeo. O método [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) solicita reprodução automática. Baixar a miniatura e reproduzir o vídeo requer acesso à internet. O visualizador da apresentação também deve suportar a reprodução de vídeo online.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Reproduzir um Vídeo em Modo de Tela Cheia**

Em uma apresentação de treinamento, você pode reproduzir uma demonstração de software em modo de tela cheia para que o público veja os detalhes. Chame [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) com `true` para habilitar esse comportamento durante a reprodução.

Este exemplo abre uma apresentação, encontra o primeiro [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) no primeiro slide e habilita a reprodução em tela cheia. A apresentação de entrada deve conter pelo menos um slide com um quadro de vídeo existente no primeiro slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A reprodução em tela cheia controla como o vídeo é exibido. Independentemente, [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) controla se ele inicia automaticamente ou ao clicar, e [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) controla se ele se repete. Para escolher o comportamento de início, defina o modo de reprodução para [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). O exemplo preserva as configurações existentes de início e repetição.

## **Retroceder um Vídeo Após a Reprodução**

Em uma apresentação de treinamento, devolver um vídeo de demonstração ao seu início o deixa pronto para o apresentador reproduzir novamente. Chame [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) com `true` para retornar o vídeo ao início após a reprodução terminar.

Este exemplo abre uma apresentação, encontra o primeiro [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) no primeiro slide e habilita o retrocesso. Ele desabilita o loop para que a reprodução possa terminar e define a reprodução para iniciar ao clicar. A apresentação de entrada deve conter pelo menos um slide com um quadro de vídeo existente no primeiro slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O retrocesso devolve o vídeo ao início sem iniciá-lo novamente. Em contraste, chamar [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) com `true` repete a reprodução automaticamente. Mantenha o loop desativado quando quiser que o vídeo termine e permaneça pronto para ser reproduzido novamente. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) controla de forma independente o início automático ou ao clicar; este exemplo usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) para que o apresentador controle quando a reprodução começa. Defina o modo de reprodução após a configuração do loop, conforme mostrado no exemplo. O retrocesso funciona de forma independente de [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Cortar um Quadro de Vídeo**

Use [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) para pular parte do início ou do final de um vídeo durante a reprodução. Ambos os valores estão em milissegundos. O corte altera as configurações de reprodução sem modificar os dados de vídeo incorporados.

**Definir Configurações de Corte**

Este exemplo incorpora um vídeo local e pula os primeiros 2,5 segundos e o último segundo durante a reprodução. Use um vídeo com mais de 3,5 segundos para que reste um segmento reproduzível.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Ler Configurações de Corte**

Este exemplo exibe os valores de corte do primeiro quadro de vídeo no primeiro slide em milissegundos. A apresentação deve conter pelo menos um slide. Se esse slide não possuir um quadro de vídeo, nada será impresso. O exemplo anterior produz os valores 2500 e 1000.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gerenciar Legendas de Vídeo**

Aspose.Slides permite gerenciar legendas ocultas para quadros de vídeo em apresentações do PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas por meio do método [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Adicionar Legendas a um Quadro de Vídeo**

Este exemplo incorpora um vídeo local e adiciona uma faixa de legenda WebVTT rotulada como English. Os timestamps das legendas devem corresponder ao vídeo. A apresentação salva inclui tanto o vídeo quanto suas legendas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A classe [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) também fornece o método [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) para adicionar legendas a partir de um fluxo.

**Extrair Legendas de um Quadro de Vídeo**

Este exemplo salva todas as faixas de legenda dos quadros de vídeo no primeiro slide como arquivos WebVTT separados. Números sequenciais mantêm os arquivos de saída distintos. O console relata o número de faixas extraídas. A apresentação deve conter pelo menos um slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Cada objeto [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) expõe o identificador da legenda, o rótulo, os dados binários e o texto da legenda como uma string UTF-8.

**Remover Legendas de um Quadro de Vídeo**

Este exemplo remove todas as legendas do quadro de vídeo na primeira posição de forma no primeiro slide e salva o resultado. Assume que o slide e a forma existem e que a forma é um quadro de vídeo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se precisar remover apenas uma faixa de legenda, use os métodos [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) em vez de [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

## **Extrair Vídeo de um Slide**

Além de adicionar vídeos aos slides, Aspose.Slides permite extrair vídeos incorporados em apresentações.

Este exemplo extrai vídeos incorporados de cada slide para arquivos binários separados e numerados. Vídeos vinculados são ignorados porque não possuem dados incorporados. O console exibe o tipo MIME de cada vídeo e a contagem total. A saída usa a extensão genérica `.bin`; altere-a para corresponder ao tipo de mídia relatado quando necessário.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **Perguntas Frequentes**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um quadro de vídeo?**

Você pode controlar o [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (automático ou ao clicar) e o [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Essas opções estão disponíveis através dos métodos do objeto [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, fazendo com que o tamanho da apresentação aumente proporcionalmente ao tamanho do arquivo. Quando você vincula a um vídeo online e adiciona uma miniatura, a apresentação armazena o link e a imagem de pré‑visualização em vez dos dados do vídeo, portanto o aumento de tamanho costuma ser menor.

**Posso substituir o vídeo em um quadro de vídeo existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) dentro do quadro mantendo a geometria da forma; este é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) que pode ser lido e usado, por exemplo ao salvá‑lo no disco.