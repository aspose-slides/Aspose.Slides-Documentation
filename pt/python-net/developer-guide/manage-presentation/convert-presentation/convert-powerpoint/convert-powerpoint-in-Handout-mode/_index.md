---
title: Converter apresentações no modo Handout com Python
linktitle: Modo Handout
type: docs
weight: 150
url: /pt/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- converter PowerPoint
- converter apresentação
- modo handout
- handout
- PowerPoint
- apresentação
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Converter apresentações em folhetos com Python. Defina slides por página, mantenha anotações, exporte para PDF ou imagens com Aspose.Slides, com código de exemplo. Experimente grátis."
---
## **Introdução**

Aspose.Slides oferece a capacidade de converter apresentações em vários formatos, incluindo a criação de folhetos para impressão no modo Handout. Esse modo permite que você configure como vários slides aparecem em uma única página, sendo útil para conferências, seminários e outros eventos. Você pode habilitar esse modo definindo a propriedade `slides_layout_options` nas classes [PdfOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmloptions/), e [TiffOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/tiffoptions/) .

## **Exportação no modo Handout**

Para configurar o modo Handout, use o objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/handoutlayoutingoptions/) , que determina quantos slides são colocados em uma única página e outros parâmetros de exibição.

Abaixo está um exemplo de código que demonstra como converter uma apresentação para PDF no modo Handout.

```py
# Carregar uma apresentação.
with slides.Presentation("sample.pptx") as presentation:

    # Definir as opções de exportação.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 slides em uma página horizontalmente
    slides_layout_options.print_slide_numbers = True                                 # imprimir números dos slides
    slides_layout_options.print_frame_slide = True                                   # imprimir uma moldura ao redor dos slides
    slides_layout_options.print_comments = False                                     # sem comentários

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Exportar a apresentação para PDF com o layout escolhido.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Observe que a propriedade `slides_layout_options` está disponível somente para determinados formatos de saída, como PDF, HTML, TIFF, e ao renderizar como imagens.
{{% /alert %}} 

## **Perguntas Frequentes**

**Qual é o número máximo de miniaturas de slide por página no modo Handout?**

Aspose.Slides suporta [presets](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/handouttype/) de até 9 miniaturas por página com ordenação horizontal ou vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) e 9 (horizontal/vertical).

**Posso definir uma grade personalizada, como 5 ou 8 slides por página?**

Não. O número e a ordenação das miniaturas são controlados estritamente pela enumeração [HandoutType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/handouttype/) ; layouts arbitrários não são suportados.

**Posso incluir slides ocultos na saída do Handout?**

Sim. Habilite a opção `show_hidden_slides` nas configurações de exportação para o formato de destino, como [PdfOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/tiffoptions/).