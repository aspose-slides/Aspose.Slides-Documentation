---
title: Áudio
type: docs
weight: 70
url: /pt/java/examples/elements/audio/
keywords:
- exemplo de código
- áudio
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Descubra exemplos de áudio do Aspose.Slides for Java: inserir, reproduzir, aparar e extrair som em apresentações PPT, PPTX e ODP com código Java claro."
---
Este artigo demonstra como incorporar quadros de áudio e controlar a reprodução com **Aspose.Slides for Java**. Os exemplos a seguir mostram operações básicas de áudio.

## **Adicionar um quadro de áudio**

Inserir um quadro de áudio vazio que pode, posteriormente, conter dados de som incorporados.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Crie um quadro de áudio vazio (o áudio será incorporado mais tarde).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um quadro de áudio**

Este código recupera o primeiro quadro de áudio em um slide.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Acesse o primeiro quadro de áudio no slide.
        IAudioFrame firstAudio = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAudioFrame) {
                firstAudio = (IAudioFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um quadro de áudio**

Excluir um quadro de áudio adicionado anteriormente.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Remova o quadro de áudio.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Definir reprodução de áudio**

Configure o quadro de áudio para reproduzir automaticamente quando o slide aparecer.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Reproduza automaticamente quando o slide aparecer.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```