---
title: Gerenciar Quadros de Vídeo em Apresentações Usando JavaScript
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
- fonte web
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a adicionar e extrair programaticamente quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para Node.js via Java. Guia rápido passo a passo."
---
## **Introdução**

Um vídeo bem posicionado em uma apresentação pode tornar sua mensagem mais atraente e aumentar os níveis de engajamento com o seu público. 

O PowerPoint permite adicionar vídeos a um slide em uma apresentação de duas maneiras:

* Adicionar ou incorporar um vídeo local (armazenado em sua máquina)
* Adicionar um vídeo online (de uma fonte web como o YouTube).

Para permitir que você adicione vídeos (objetos de vídeo) a uma apresentação, o Aspose.Slides fornece a classe [Video](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/video/) , a classe [VideoFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/) e outros tipos relevantes.

## **Criar Quadro de Vídeo Incorporado**

Se o arquivo de vídeo que você deseja adicionar ao seu slide estiver armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo na sua apresentação. 

1. Criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obter a referência de um slide através de seu índice. 
3. Adicionar um objeto [Video](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/video/) e passar o caminho do arquivo de vídeo para incorporar o vídeo na apresentação.
4. Adicionar um objeto [VideoFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/) para criar um quadro para o vídeo.
5. Salvar a apresentação modificada. 

Este código JavaScript mostra como adicionar um vídeo armazenado localmente a uma apresentação:

```javascript
// Instancia a classe Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Carrega o vídeo
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Obtém o primeiro slide e adiciona um videoframe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Salva a apresentação no disco
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Alternativamente, você pode adicionar um vídeo passando seu caminho de arquivo diretamente para o método [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Criar Quadro de Vídeo com Vídeo de Fonte Web**

O Microsoft [PowerPoint 2013 e posteriores](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) suporta vídeos do YouTube em apresentações. Se o vídeo que você deseja usar está disponível online (por exemplo, no YouTube), você pode adicioná‑lo à sua apresentação através de seu link web. 

1. Criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation)
2. Obter a referência de um slide através de seu índice. 
3. Adicionar um objeto [Video](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/video/) e passar o link para o vídeo.
4. Definir uma miniatura para o quadro de vídeo. 
5. Salvar a apresentação. 

Este código JavaScript mostra como adicionar um vídeo da web a um slide em uma apresentação PowerPoint:

```javascript
// Instancia um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **Cortar um Quadro de Vídeo**

O Aspose.Slides permite controlar qual parte de um vídeo é reproduzida definindo os valores trim-from-start e trim-from-end por meio dos métodos [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/settrimfromstart/) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/settrimfromend/). Ambos os valores são especificados em milissegundos e definem quanto tempo é pulado do início e do fim do vídeo, respectivamente. Essas configurações alteram as opções de reprodução do vídeo na apresentação; elas não cortam nem modificam os dados binários do vídeo incorporado.

**Definir Configurações de Corte**

Para criar um quadro de vídeo e definir suas configurações de corte:

1. Criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Adicionar um objeto [Video](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/video/) à apresentação.
3. Adicionar um objeto [VideoFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/) a um slide.
4. Definir os valores trim-from-start e trim-from-end por meio dos métodos [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/settrimfromstart/) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/settrimfromend/).
5. Salvar a apresentação modificada.

O exemplo de código a seguir pula os primeiros 2,5 segundos e o último segundo de um vídeo incorporado durante a reprodução:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Ler Configurações de Corte**

Para inspecionar as configurações de corte existentes, carregue uma apresentação, encontre um objeto [VideoFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/) entre as formas no primeiro slide e leia os valores através dos métodos [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) e [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/gettrimfromend/).

O exemplo de código a seguir encontra o primeiro quadro de vídeo no primeiro slide e relata suas configurações de corte em milissegundos:

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gerenciar Legendas de Vídeo**

O Aspose.Slides permite gerenciar legendas fechadas para quadros de vídeo em apresentações PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas através do método [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Adicionar Legendas a um Quadro de Vídeo**

Para adicionar legendas a um quadro de vídeo:

1. Criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Adicionar um vídeo à apresentação.
3. Adicionar um objeto [VideoFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/) a um slide.
4. Usar a coleção [CaptionsCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/) para adicionar uma faixa de legenda WebVTT.
5. Salvar a apresentação modificada.

O código a seguir mostra como adicionar legendas a um quadro de vídeo:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Adiciona uma nova faixa de legendas a partir de um arquivo WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A classe [CaptionsCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/) também fornece o método [addFromStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/#addFromStream) que permite adicionar legendas a partir de um stream.

**Extrair Legendas de um Quadro de Vídeo**

Para extrair legendas de um quadro de vídeo:

1. Carregar a apresentação que contém o vídeo.
2. Encontrar o objeto [VideoFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/) alvo.
3. Percorrer a coleção [CaptionsCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/).
4. Salvar cada faixa de legenda em um arquivo `.vtt`.

O código a seguir mostra como extrair legendas de um quadro de vídeo:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // Salva a faixa de legendas em um arquivo WebVTT.
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

Cada objeto [Captions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captions/) expõe o identificador da legenda, o rótulo, os dados binários e o texto da legenda como uma string UTF-8.

**Remover Legendas de um Quadro de Vídeo**

Para remover legendas de um quadro de vídeo:

1. Carregar a apresentação que contém o vídeo.
2. Obter o objeto [VideoFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/) alvo.
3. Remover as faixas de legenda da coleção [CaptionsCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/).
4. Salvar a apresentação modificada.

O código a seguir mostra como remover todas as legendas de um quadro de vídeo:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // tipo: com.aspose.slides.VideoFrame

    // Remove todas as legendas do quadro de vídeo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se precisar remover apenas uma faixa de legenda, use os métodos [remove](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/#removeAt) em vez de [clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/captionscollection/#clear).

## **Extrair Vídeo de um Slide**

Além de adicionar vídeos a slides, o Aspose.Slides permite extrair vídeos incorporados em apresentações.

1. Criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) para carregar a apresentação que contém o vídeo.
2. Percorrer todos os objetos [Slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/).
3. Percorrer todos os objetos [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) para encontrar um [VideoFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/).
4. Salvar o vídeo no disco.

Este código JavaScript mostra como extrair o vídeo de um slide de apresentação:

```javascript
// Instancia um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Obtém a extensão do arquivo
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas Frequentes**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um VideoFrame?**

Você pode controlar o [modo de reprodução](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/setplaymode/) (automático ou ao clique) e o [looping](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Essas opções estão disponíveis nas propriedades do objeto [VideoFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/).

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, fazendo com que o tamanho da apresentação cresça proporcionalmente ao tamanho do arquivo. Quando você adiciona um vídeo online, um link e uma miniatura são incorporados, de modo que o aumento de tamanho é menor.

**Posso substituir o vídeo em um VideoFrame existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [conteúdo do vídeo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) dentro do quadro preservando a geometria da forma; esse é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [tipo de conteúdo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/video/getcontenttype/) que pode ser lido e utilizado, por exemplo, ao salvá‑lo no disco.