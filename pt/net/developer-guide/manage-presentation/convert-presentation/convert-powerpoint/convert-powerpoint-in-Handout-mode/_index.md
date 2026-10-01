---
title: Converter apresentações PowerPoint no modo Folheto em .NET
linktitle: Modo Folheto
type: docs
weight: 150
url: /pt/net/convert-powerpoint-in-handout-mode/
keywords:
- converter PowerPoint
- converter apresentação
- modo folheto
- folheto
- PowerPoint
- apresentação
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Converta apresentações em folhetos no .NET. Defina slides por página, mantenha notas, exporte para PDF ou imagens com Aspose.Slides, com código de exemplo em C#. Experimente gratuitamente."
---
## **Introdução**

Aspose.Slides permite converter apresentações para formatos de saída que suportam o modo Folheto. Nesse modo, vários slides são organizados em uma única página, o que é útil para imprimir materiais de apresentação para conferências, seminários e eventos semelhantes.

O modo Folheto é configurado por meio da propriedade `SlidesLayoutOptions`, que está disponível em [IPdfOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ihtmloptions/) e [ITiffOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/itiffoptions/). Para definir o layout do folheto, use o objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/handoutlayoutingoptions/).

Para definir as dimensões e a orientação da página do folheto antes da exportação, veja [Notes Page Size](/slides/pt/net/notes-size/).

## **Exportação no Modo Folheto**

Para exportar uma apresentação no modo Folheto, defina a propriedade `SlidesLayoutOptions` nas opções de exportação de destino e atribua uma instância de [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/handoutlayoutingoptions/) que especifica o número de slides por página e parâmetros de exibição relacionados.

Abaixo está um exemplo de código que mostra como converter uma apresentação para PDF no modo Folheto.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Carregar uma apresentação.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 slides em uma página horizontalmente
        PrintSlideNumbers = true,                   // imprimir números dos slides
        PrintFrameSlide = true,                     // imprimir uma moldura ao redor dos slides
        PrintComments = false                       // sem comentários
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Lembre‑se de que a propriedade `SlidesLayoutOptions` está disponível somente para alguns formatos de saída, como PDF, HTML, TIFF e ao renderizar como imagens.
{{% /alert %}} 

## **FAQ**

### Qual é o número máximo de miniaturas de slide por página no modo Folheto?

Aspose.Slides suporta [presets](https://reference.aspose.com/slides/pt/net/aspose.slides.export/handouttype/) de até 9 miniaturas por página com ordenação horizontal ou vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) e 9 (horizontal/vertical).

### Posso definir uma grade personalizada, como 5 ou 8 slides por página?

Não. O número e a ordenação das miniaturas são controlados estritamente pela enumeração [HandoutType](https://reference.aspose.com/slides/pt/net/aspose.slides.export/handouttype/); layouts arbitrários não são suportados.

### Posso incluir slides ocultos na saída do Folheto?

Sim. Ative a opção `ShowHiddenSlides` nas configurações de exportação para o formato de destino, como [PdfOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/tiffoptions/).