---
title: Converter Apresentações PowerPoint no Modo Handout Usando JavaScript
linktitle: Modo Handout
type: docs
weight: 150
url: /pt/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- converter PowerPoint
- converter apresentação
- modo handout
- folheto
- PPT
- PPTX
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter apresentações em folhetos. Defina slides por página, mantenha notas, exporte para PDF ou imagens com Aspose.Slides para Node.js, com código de exemplo. Experimente grátis."
---
## **Introdução**

Aspose.Slides fornece a capacidade de converter apresentações em vários formatos, incluindo a criação de folhetos para impressão no modo Handout. Este modo permite configurar como múltiplos slides aparecem em uma única página, sendo útil para conferências, seminários e outros eventos. Você pode habilitar este modo definindo o método `setSlidesLayoutOptions` nas classes [PdfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/htmloptions/) e [TiffOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tiffoptions/).

Para definir as dimensões e a orientação da página de folheto antes da exportação, veja [Tamanho da Página de Notas](/slides/pt/nodejs-java/notes-size/).

## **Exportação no Modo Handout**

Para configurar o modo Handout, use o objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/handoutlayoutingoptions/), que determina quantos slides são colocados em uma única página e outros parâmetros de exibição.

Abaixo está um exemplo de código que mostra como converter uma apresentação para PDF no modo Handout.

```js
const asposeSlides = require("aspose.slides.via.java");

// Carregar uma apresentação.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Definir as opções de exportação.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 slides em uma página horizontalmente
slidesLayoutOptions.setPrintSlideNumbers(true);                                // imprimir números dos slides
slidesLayoutOptions.setPrintFrameSlide(true);                                  // imprimir uma borda ao redor dos slides
slidesLayoutOptions.setPrintComments(false);                                   // sem comentários

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Exportar a apresentação para PDF com o layout escolhido.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
Lembre-se de que o método `setSlidesLayoutOptions` está disponível apenas para certos formatos de saída, como PDF, HTML, TIFF, e ao renderizar como imagens.
{{% /alert %}} 

## **Perguntas Frequentes**

**Qual é o número máximo de miniaturas de slide por página no modo Handout?**

Aspose.Slides suporta [predefinições](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/handouttype/) de até 9 miniaturas por página com ordenação horizontal ou vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) e 9 (horizontal/vertical).

**Posso definir uma grade personalizada, como 5 ou 8 slides por página?**

Não. O número e a ordenação das miniaturas são controlados estritamente pela enumeração [HandoutType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/handouttype/); layouts arbitrários não são suportados.

**Posso incluir slides ocultos na saída do Handout?**

Sim. Use o método `setShowHiddenSlides` nas configurações de exportação para o formato de destino, como [PdfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tiffoptions/).