---
title: Obter callbacks de aviso para substituição de fontes em .NET
type: docs
weight: 120
url: /pt/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback de aviso
- substituição de fontes
- processo de renderização
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a obter callbacks de aviso para substituição de fontes no Aspose.Slides for .NET e exibir apresentações PowerPoint e OpenDocument com precisão."
---
## **Introdução**

O Aspose.Slides for .NET permite receber callbacks de aviso para substituição de fontes quando uma fonte necessária não está disponível na máquina durante a renderização. Esses callbacks ajudam a diagnosticar problemas com fontes ausentes ou inacessíveis.

## **Habilitar Callbacks de Aviso**

O Aspose.Slides for .NET fornece APIs simples para receber callbacks de aviso ao renderizar slides de apresentação. Siga estas etapas para configurar os callbacks de aviso:

1. Crie uma classe de callback personalizada que implemente a interface [IWarningCallback](https://reference.aspose.com/slides/pt/net/aspose.slides.warnings/iwarningcallback/) para tratar avisos.
1. Defina o callback de aviso usando classes de opções como [RenderingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmloptions/), e outras.
1. Carregue uma apresentação que utiliza uma fonte não disponível na máquina de destino.
1. Genere uma miniatura de slide ou exporte a apresentação para observar o efeito.

**Classe de Callback de Aviso Personalizada:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Exemplo de saída:
//
// A fonte será substituída de XYZ para {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Gerar uma Miniatura de Slide:**

```c#
 // Configurar um callback de aviso para tratar avisos relacionados a fontes durante a renderização de slides.
 var options = new RenderingOptions();
 options.WarningCallback = new FontWarningHandler();

 // Carregar a apresentação a partir do caminho de arquivo especificado.
 using var presentation = new Presentation("sample.pptx");

 // Gerar uma imagem em miniatura para cada slide da apresentação.
 foreach (var slide in presentation.Slides)
 {
     // Obter a imagem em miniatura do slide usando as opções de renderização especificadas.
     using var image = slide.GetImage(options);
     // ...
 }
```

**Exportar para Formato PDF:**

```c#
// Configurar um callback de aviso para tratar avisos relacionados a fontes durante a exportação para PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Carregar a apresentação a partir do caminho de arquivo especificado.
using var presentation = new Presentation("sample.pptx");

// Exportar a apresentação como PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**Exportar para Formato HTML:**

```c#
// Configurar um callback de aviso para tratar avisos relacionados a fontes durante a exportação para HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Carregar a apresentação a partir do caminho de arquivo especificado.
using var presentation = new Presentation("sample.pptx");

// Exportar a apresentação no formato HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```