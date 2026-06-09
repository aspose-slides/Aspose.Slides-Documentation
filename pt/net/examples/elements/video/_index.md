---
title: Vídeo
type: docs
weight: 80
url: /pt/net/examples/elements/video/
keywords:
- vídeo
- quadro de vídeo
- adicionar vídeo
- acessar vídeo
- remover vídeo
- reprodução de vídeo
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Adicione e controle vídeos com Aspose.Slides for .NET: insira, reproduza, corte, defina quadros de pôster e exporte com exemplos em C# para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como incorporar quadros de vídeo e definir opções de reprodução usando **Aspose.Slides for .NET**.

## **Adicionar um Quadro de Vídeo**

Insira um quadro de vídeo vazio em um slide.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Adicione um vídeo.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Acessar um Quadro de Vídeo**

Recupere o primeiro quadro de vídeo adicionado a um slide.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Acesse o primeiro quadro de vídeo no slide.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Remover um Quadro de Vídeo**

Exclua um quadro de vídeo do slide.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Remova o quadro de vídeo.
    slide.Shapes.Remove(videoFrame);
}
```

## **Definir Reprodução de Vídeo**

Configure o vídeo para reproduzir automaticamente quando o slide for exibido.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Configure o vídeo para reproduzir automaticamente.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```