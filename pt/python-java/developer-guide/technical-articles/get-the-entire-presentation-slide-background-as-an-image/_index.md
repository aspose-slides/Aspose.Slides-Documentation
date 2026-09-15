---
title: Obter o plano de fundo completo do slide de uma apresentação como imagem
linktitle: Plano de fundo completo do slide
type: docs
weight: 95
url: /pt/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- plano de fundo do slide
- plano de fundo final
- extrair plano de fundo
- plano de fundo total
- plano de fundo para imagem
- plano de fundo PPT
- plano de fundo PPTX
- plano de fundo ODP
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Extrair planos de fundo completos dos slides como imagens de apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via Java, simplificando fluxos de trabalho visuais."
---
## **Visão geral**

Em apresentações do PowerPoint, o plano de fundo de um slide pode ser formado por vários elementos, incluindo a imagem de fundo do slide, o tema da apresentação, o esquema de cores e objetos colocados no slide mestre ou no slide de layout.

Este artigo mostra como extrair o plano de fundo inteiro do slide como uma imagem usando Aspose.Slides for Python via Java. Como não existe um único método para essa tarefa, a abordagem envolve clonar o slide selecionado em uma apresentação temporária, remover as formas do slide e então converter o plano de fundo resultante em uma imagem.

## **Obter o plano de fundo inteiro do slide**

Aspose.Slides for Python via Java não fornece um método simples para extrair o plano de fundo inteiro do slide da apresentação como uma imagem, mas você pode seguir as etapas abaixo para fazer isso:

1. Carregue a apresentação usando a classe [Apresentação](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha o tamanho do slide a partir da apresentação.
1. Selecione um slide.
1. Crie uma apresentação temporária.
1. Defina o mesmo tamanho de slide na apresentação temporária.
1. Clone o slide selecionado na apresentação temporária.
1. Exclua as formas do slide clonado.
1. Converta o slide clonado em uma imagem.

O exemplo de código a seguir extrai o plano de fundo inteiro do slide da apresentação como uma imagem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Os gradientes complexos, texturas ou preenchimentos de imagem de um slide mestre serão preservados na imagem de fundo resultante?**

Sim. Aspose.Slides renderiza preenchimentos de gradiente, imagem e textura definidos no slide, layout ou mestre. Se precisar isolar a aparência dos mestres herdados, [defina um plano de fundo personalizado](/slides/pt/python-java/presentation-background/) no slide atual antes de exportar.

**Posso adicionar uma marca d'água à imagem de plano de fundo resultante antes de salvá‑la?**

Sim. Você pode [adicionar uma marca d'água](/slides/pt/python-java/watermark/) forma ou imagem em uma [cópia de trabalho do slide](/slides/pt/python-java/clone-slides/) (colocada atrás de outro conteúdo) e então exportar. Isso permite gerar uma imagem de fundo com a marca d'água incorporada.

**Posso obter o plano de fundo de um layout ou mestre específico sem vinculá‑lo a um slide existente?**

Sim. Acesse o mestre ou layout desejado, aplique‑o a um [slide temporário](/slides/pt/python-java/clone-slides/) com o tamanho necessário e exporte esse slide para obter o plano de fundo derivado desse layout ou mestre.

**Existem limitações de licenciamento que afetam a exportação de imagens?**

Os recursos de renderização estão totalmente disponíveis com uma [licença válida](/slides/pt/python-java/licensing/). No modo de avaliação, a saída pode incluir limitações como uma marca d'água. Ative a licença uma vez por processo antes de executar exportações em lote.