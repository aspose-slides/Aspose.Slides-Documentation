---
title: Vídeo
type: docs
weight: 80
url: /pt/java/examples/elements/video/
keywords:
- exemplo de código
- vídeo
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Adicione e controle vídeos com Aspose.Slides for Java: insira, reproduza, aparar, defina quadros de pôster e exporte com exemplos Java para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como incorporar quadros de vídeo e definir opções de reprodução usando **Aspose.Slides for Java**.

## **Adicionar um Quadro de Vídeo**

Insira um quadro de vídeo vazio em um slide.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Adicionar um vídeo.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um Quadro de Vídeo**

Recupere o primeiro quadro de vídeo adicionado a um slide.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Acessar o primeiro quadro de vídeo no slide.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
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

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Remover o quadro de vídeo.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Definir Reprodução de Vídeo**

Configure o vídeo para reproduzir automaticamente quando o slide for exibido.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Configurar o vídeo para reproduzir automaticamente.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```