---
title: Converter apresentações PowerPoint no modo Folheto usando C++
linktitle: Modo Folheto
type: docs
weight: 150
url: /pt/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- converter PowerPoint
- converter apresentação
- modo folheto
- folheto
- PPT
- PPTX
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Converta apresentações em folhetos em C++. Defina slides por página, mantenha notas, exporte para PDF ou imagens com Aspose.Slides, com código de exemplo. Experimente grátis."
---
## **Introdução**

O Aspose.Slides oferece a capacidade de converter apresentações em vários formatos, incluindo a criação de folhetos para impressão no modo Folheto. Esse modo permite configurar como múltiplos slides aparecem em uma única página, sendo útil para conferências, seminários e outros eventos. Você pode habilitar esse modo definindo o método `set_SlidesLayoutOptions` nas interfaces [IPdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/ihtmloptions/) e [ITiffOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/itiffoptions/).

## **Exportação no Modo Folheto**

Para configurar o modo Folheto, use o objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/handoutlayoutingoptions/), que determina quantos slides são colocados em uma única página e outros parâmetros de exibição.

Abaixo está um exemplo de código que mostra como converter uma apresentação para PDF no modo Folheto.

```cpp
// Carregar uma apresentação.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Definir as opções de exportação.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 slides em uma página horizontalmente
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // imprimir números dos slides
slidesLayoutOptions->set_PrintFrameSlide(true);                      // imprimir uma moldura ao redor dos slides
slidesLayoutOptions->set_PrintComments(false);                       // sem comentários

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Exportar a apresentação para PDF com o layout escolhido.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Lembre-se de que o método `set_SlidesLayoutOptions` está disponível apenas para alguns formatos de saída, como PDF, HTML, TIFF e ao renderizar como imagens.
{{% /alert %}} 

## **Perguntas Frequentes**

**Qual é o número máximo de miniaturas de slide por página no modo Folheto?**

O Aspose.Slides suporta [presets](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/handouttype/) de até 9 miniaturas por página com ordenação horizontal ou vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) e 9 (horizontal/vertical).

**Posso definir uma grade personalizada, como 5 ou 8 slides por página?**

Não. O número e a ordenação das miniaturas são controlados estritamente pela enumeração [HandoutType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/handouttype/); layouts arbitrários não são suportados.

**Posso incluir slides ocultos na saída do Folheto?**

Sim. Use o método `set_ShowHiddenSlides` nas configurações de exportação para o formato de destino, como [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/tiffoptions/).