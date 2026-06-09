---
title: Gerenciar SmartArt em Apresentações PowerPoint Usando Python
linktitle: Gerenciar SmartArt
type: docs
weight: 10
url: /pt/python-net/manage-smartart/
keywords:
- SmartArt
- texto do SmartArt
- tipo de layout
- propriedade oculta
- organograma
- organograma de imagem
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt do PowerPoint com Aspose.Slides para Python via .NET usando exemplos de código claros que aceleram o design de slides e a automação."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com Aspose.Slides for Python via .NET, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organograma e criar organogramas de imagens.

## **Obter texto de um objeto SmartArt**

Um nó SmartArt pode conter uma ou mais formas. Para ler o texto visível, itere através de [SmartArt.all_nodes](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/all_nodes/), então leia o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) retornado por [SmartArtShape.text_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o valor [SmartArtLayoutType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, altera para o valor `BASIC_PROCESS` e salva a apresentação.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Verificar se um nó SmartArt está oculto**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartartnode/is_hidden/) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos visíveis do diagrama.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o valor [SmartArtLayoutType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` e verifica o estado de ocultação do nó.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que usam um layout de organograma, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) define como os nós filhos são dispostos sob um nó pai. Por exemplo, você pode definir que os nós filhos pendam à esquerda, à direita ou de ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/organizationchartlayouttype/) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Criar um organograma de imagem**

Um organograma de imagem é um layout SmartArt projetado para diagramas hierárquicos que incluem espaços reservados para imagens. Use o valor [SmartArtLayoutType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` ao adicionar o objeto SmartArt a um slide.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**O SmartArt suporta espelhamento ou inversão para idiomas RTL?**

Sim. A propriedade [SmartArt.is_reversed](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/is_reversed/) altera a direção do diagrama de esquerda‑para‑direita para direita‑para‑esquerda, ou vice‑versa, quando o layout SmartArt selecionado oferece suporte à reversão.

**Como posso copiar SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/python-net/shape-manipulations/) com [ShapeCollection.add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_clone/) ou [clonar o slide inteiro](/slides/pt/python-net/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam tamanho, posição e formatação.

**Como renderizar SmartArt para uma imagem raster para visualização ou exportação web?**

[Renderize o slide](/slides/pt/python-net/convert-powerpoint-to-png/) ou a apresentação inteira para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como encontrar um objeto SmartArt específico em um slide se houver vários?**

Defina um texto alternativo distintivo em [Shape.alternative_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/alternative_text/) ou um nome em [Shape.name](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/name/) na forma SmartArt, procure esse valor em [Slide.shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/shapes/) e, em seguida, verifique se a forma correspondente é um [SmartArt](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/).