---
title: Áudio
type: docs
weight: 70
url: /pt/net/examples/elements/audio/
keywords:
- áudio
- quadro de áudio
- adicionar áudio
- acessar áudio
- remover áudio
- reprodução de áudio
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra exemplos de áudio do Aspose.Slides for .NET: inserir, reproduzir, cortar e extrair som em apresentações PPT, PPTX e ODP com código C# claro."
---
Este artigo demonstra como incorporar quadros de áudio e controlar a reprodução com **Aspose.Slides for .NET**. Os exemplos a seguir mostram operações básicas de áudio.

## **Adicionar um Quadro de Áudio**

Insira um quadro de áudio vazio que pode posteriormente conter dados de som incorporados.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Crie um quadro de áudio vazio (o áudio será incorporado mais tarde).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Acessar um Quadro de Áudio**

Este código recupera o primeiro quadro de áudio em um slide.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Acesse o primeiro quadro de áudio no slide.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Remover um Quadro de Áudio**

Exclua um quadro de áudio adicionado anteriormente.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Remova o quadro de áudio.
    slide.Shapes.Remove(audioFrame);
}
```

## **Definir Reprodução de Áudio**

Configure o quadro de áudio para reproduzir automaticamente quando o slide aparecer.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Reproduza automaticamente quando o slide aparecer.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```