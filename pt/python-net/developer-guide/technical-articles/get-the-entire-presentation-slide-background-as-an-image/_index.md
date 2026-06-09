---
title: Obter todo o fundo do slide de uma apresentação como imagem
linktitle: Fundo Completo do Slide
type: docs
weight: 95
url: /pt/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slide
- fundo
- fundo do slide
- fundo final
- fundo para imagem
- PowerPoint
- OpenDocument
- apresentação
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Extrair fundos completos de slides como imagens de apresentações PowerPoint e OpenDocument usando Aspose.Slides para Python via .NET, simplificando fluxos de trabalho visuais."
---
## **Visão geral**

Nas apresentações do PowerPoint, o fundo de um slide pode ser formado por vários elementos, incluindo a imagem de fundo do slide, o tema da apresentação, o esquema de cores e objetos colocados no slide mestre ou no slide de layout.

Este artigo mostra como extrair todo o fundo do slide como uma imagem usando o Aspose.Slides. Como não há um método único para essa tarefa, a abordagem envolve clonar o slide selecionado em uma apresentação temporária, remover as formas do slide e, em seguida, converter o fundo resultante do slide em uma imagem.

## **Obter todo o fundo do slide**

Aspose.Slides for Python não fornece um método simples para extrair todo o fundo do slide da apresentação como uma imagem, mas você pode seguir os passos abaixo para fazer isso:
1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha o tamanho do slide a partir da apresentação.
1. Selecione um slide.
1. Crie uma apresentação temporária.
1. Defina o mesmo tamanho do slide na apresentação temporária.
1. Clone o slide selecionado para a apresentação temporária.
1. Exclua as formas do slide clonado.
1. Converta o slide clonado em uma imagem.

O exemplo de código a seguir extrai todo o fundo do slide da apresentação como uma imagem.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **Perguntas frequentes**

**Os gradientes complexos, texturas ou preenchimentos de imagem de um slide mestre serão preservados na imagem de fundo resultante?**

Sim. Aspose.Slides renderiza preenchimentos de gradiente, imagem e textura definidos no slide, layout ou mestre. Se precisar isolar a aparência dos mestres herdados, [defina um fundo próprio](/slides/pt/python-net/presentation-background/) no slide atual antes de exportar.

**Posso adicionar uma marca d'água à imagem de fundo resultante antes de salvá‑la?**

Sim. Você pode [adicionar uma marca d'água](/slides/pt/python-net/watermark/) como forma ou imagem em uma [cópia de trabalho do slide](/slides/pt/python-net/clone-slides/) (colocada atrás de outro conteúdo) e depois exportar. Isso permite gerar uma imagem de fundo com a marca d'água incorporada.

**Posso obter o fundo de um layout ou mestre específico sem vinculá‑lo a um slide existente?**

Sim. Acesse o mestre ou layout desejado, aplique‑o a um [slide temporário](/slides/pt/python-net/clone-slides/) com o tamanho necessário e exporte esse slide para obter o fundo derivado desse layout ou mestre.

**Existem limitações de licenciamento que afetam a exportação de imagens?**

Os recursos de renderização estão totalmente disponíveis com uma [licença válida](/slides/pt/python-net/licensing/). No modo de avaliação, a saída pode incluir limitações, como uma marca d'água. Ative a licença uma vez por processo antes de executar exportações em lote.