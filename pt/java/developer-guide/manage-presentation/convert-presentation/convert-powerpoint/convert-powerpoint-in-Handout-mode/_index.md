---
title: Converter apresentações PowerPoint no modo Folheto usando Java
linktitle: Modo Folheto
type: docs
weight: 150
url: /pt/java/convert-powerpoint-in-Handout-mode/
keywords:
- converter PowerPoint
- converter apresentação
- modo folheto
- folheto
- PPT
- PPTX
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Converter apresentações em folhetos em Java. Defina slides por página, mantenha anotações, exporte para PDF ou imagens com Aspose.Slides, com código de exemplo Java. Experimente grátis."
---
## **Introdução**

Aspose.Slides permite converter apresentações para formatos de saída que suportam o modo Folheto. Nesse modo, múltiplos slides são organizados em uma única página, o que é útil para imprimir o material da apresentação para conferências, seminários e eventos semelhantes.

O modo Folheto é configurado através do método `setSlidesLayoutOptions`, que está disponível em [IPdfOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihtmloptions/), e [ITiffOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itiffoptions/). Para definir o layout do folheto, use o objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/handoutlayoutingoptions/).

## **Exportação no Modo Folheto**

Para exportar uma apresentação no modo Folheto, defina o método `setSlidesLayoutOptions` nas opções de exportação de destino e atribua uma instância de [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/handoutlayoutingoptions/) que define o número de slides por página e os parâmetros de exibição relacionados.

Abaixo está um exemplo de código mostrando como converter uma apresentação para PDF no modo Folheto.

```java
// Carregar uma apresentação.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Definir as opções de exportação.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slides em uma página horizontalmente
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // imprimir números dos slides
    slidesLayoutOptions.setPrintFrameSlide(true);                     // imprimir uma moldura ao redor dos slides
    slidesLayoutOptions.setPrintComments(false);                      // sem comentários

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Exportar a apresentação para PDF com o layout escolhido.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
Lembre-se de que o método `setSlidesLayoutOptions` está disponível apenas para certos formatos de saída, como PDF, HTML, TIFF e ao renderizar como imagens.
{{% /alert %}} 

## **FAQ**

**Qual é o número máximo de miniaturas de slide por página no modo Folheto?**

Aspose.Slides suporta [presets](https://reference.aspose.com/slides/pt/java/com.aspose.slides/handouttype/) de até 9 miniaturas por página com ordenação horizontal ou vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) e 9 (horizontal/vertical).

**Posso definir uma grade personalizada, como 5 ou 8 slides por página?**

Não. O número e a ordem das miniaturas são controlados estritamente pela classe [HandoutType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/handouttype/); layouts arbitrários não são suportados.

**Posso incluir slides ocultos na saída do Folheto?**

Sim. Ative os slides ocultos usando o método `setShowHiddenSlides` nas configurações de exportação para o formato de destino, como [PdfOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/htmloptions/), ou [TiffOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tiffoptions/).