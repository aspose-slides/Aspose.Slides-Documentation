---
title: "Cabeçalho e Rodapé"
type: docs
weight: 220
url: /pt/net/examples/elements/header-footer/
keywords:
- cabeçalho rodapé
- adicionar cabeçalho rodapé
- atualizar cabeçalho rodapé
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Controle cabeçalhos e rodapés de slides com Aspose.Slides for .NET: adicione datas, números de slide e texto personalizado em PPT, PPTX e ODP com exemplos em C#."
---
Este artigo demonstra como adicionar rodapés e atualizar marcadores de data e hora usando **Aspose.Slides for .NET**.

## **Adicionar um Rodapé**

Adicione texto à área de rodapé de um slide e torne-o visível.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Atualizar Data e Hora**

Modifique o marcador de data e hora em um slide.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```