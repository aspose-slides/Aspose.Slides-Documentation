---
title: Vídeo
type: docs
weight: 80
url: /pt/nodejs-java/examples/elements/video/
keywords:
- exemplo de código
- vídeo
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Adicione e controle vídeos com Aspose.Slides para Node.js: insira, reproduza, corte, defina quadros de poster e exporte com exemplos para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como incorporar quadros de vídeo e definir opções de reprodução usando **Aspose.Slides for Node.js via Java**.

## **Adicionar um Quadro de Vídeo**

Adicione um quadro de vídeo a um slide.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Adiciona um vídeo.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um Quadro de Vídeo**

Recupere o primeiro quadro de vídeo adicionado a um slide.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Acessa o primeiro quadro de vídeo no slide.
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Quadro de Vídeo**

Exclua um quadro de vídeo do slide.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assume que a primeira forma é o quadro de vídeo.
        let videoFrame = slide.getShapes().get_Item(0);

        // Remove o quadro de vídeo.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Definir Reprodução de Vídeo**

Configure o vídeo para reproduzir automaticamente quando o slide for exibido.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Assume que a primeira forma é o quadro de vídeo.
        let videoFrame = slide.getShapes().get_Item(0);

        // Configura o vídeo para reproduzir automaticamente.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```