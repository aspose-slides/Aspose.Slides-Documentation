---
title: Converter apresentações PowerPoint no modo Folheto usando Python
linktitle: Modo Folheto
type: docs
weight: 150
url: /pt/python-java/convert-powerpoint-in-handout-mode/
keywords:
  - converter PowerPoint
  - converter apresentação
  - modo folheto
  - folheto
  - PPT
  - PPTX
  - PowerPoint
  - apresentação
  - Python
  - Java
  - Aspose.Slides
description: "Converter apresentações PowerPoint para folhetos em Python via Java. Organizar vários slides por página e exportar para PDF com Aspose.Slides."
---
## **Introdução**

Aspose.Slides para Python via Java permite exportar apresentações no modo de folheto, organizando vários slides em uma única página. Isso é útil para imprimir materiais de apresentação para conferências, seminários e eventos semelhantes.

Configure o layout através do método [setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Os layouts de folheto são suportados por [PdfOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/htmloptions/) e [TiffOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tiffoptions/). Use um objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/handoutlayoutingoptions/) para especificar as configurações de layout e exibição.

## **Exportação no Modo Folheto**

Para exportar uma apresentação no modo folheto, crie uma instância de [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/handoutlayoutingoptions/) e atribua-a às opções de exportação de destino usando [setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

O exemplo a seguir carrega `sample.pptx` e o exporta para PDF com quatro slides por página em ordem horizontal. Ele inclui números de slide e quadros ao redor dos slides, e exclui comentários.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Carregar uma apresentação.
presentation = Presentation("sample.pptx")
try:
    # Configurar o layout de folheto.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Exportar a apresentação para PDF com o layout escolhido.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Aviso" %}}
As configurações de layout de folheto se aplicam aos formatos de saída suportados, como PDF, HTML, TIFF e imagens renderizadas. Elas não reorganizam os slides na apresentação original.
{{% /alert %}}

## **Perguntas Frequentes**

**Qual é o número máximo de miniaturas de slide por página no modo folheto?**

O Aspose.Slides suporta até nove miniaturas por página. As predefinições de [HandoutType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/handouttype/) fornecem um, dois, três, quatro, seis ou nove slides por página. As predefinições de quatro, seis e nove slides oferecem ordenação horizontal e vertical.

**Posso definir uma grade personalizada, como cinco ou oito slides por página?**

Não. O número e a ordem das miniaturas são controlados pelos valores predefinidos de [HandoutType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/handouttype/). Grades arbitrárias não são suportadas por essas configurações de layout de folheto.

**Posso incluir slides ocultos na saída de folheto?**

Sim. Habilite slides ocultos nas configurações de exportação do formato de destino. Para PDF, chame [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) com `True` antes de salvar a apresentação.