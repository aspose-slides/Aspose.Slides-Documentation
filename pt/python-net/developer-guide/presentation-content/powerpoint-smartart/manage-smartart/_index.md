---
title: "Gerenciar SmartArt em Apresentações PowerPoint usando Python"
linktitle: "Gerenciar SmartArt"
type: docs
weight: 10
url: /pt/python-net/manage-smartart/
keywords:
- SmartArt
- texto SmartArt
- tipo de layout
- propriedade oculta
- organograma
- organograma de imagem
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt no PowerPoint com Aspose.Slides para Python via .NET usando exemplos de código claros que aceleram o design de slides e a automação."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com Aspose.Slides for Python via .NET, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organograma e criar organogramas de imagem.

## **Obter texto de um objeto SmartArt**

Um nó SmartArt pode conter uma ou mais formas. Para ler o texto das formas do nó, itere através de [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), então leia o [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) retornado por [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

O exemplo requer uma apresentação com ao menos um slide e um objeto SmartArt como a primeira forma nesse slide. Ele imprime cada quadro de texto disponível no console.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```
## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` valor, altera‑o para o valor `BASIC_PROCESS` e salva a apresentação. A posição e o tamanho passados para [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) são medidos em pontos. Defina [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) para alterar o layout.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```
## **Verificar se um nó SmartArt está oculto**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos visíveis do diagrama.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` valor e verifica o estado oculto do nó adicionado. Ele exibe uma mensagem se o nó estiver oculto e salva o diagrama.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```
## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que utilizam um layout de organograma, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) define como os nós filhos são organizados sob um nó pai. Por exemplo, você pode definir os nós filhos para pendurar à esquerda, à direita ou em ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor `LEFT_HANGING` do [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/). O índice baseado em zero `0` seleciona o primeiro nó de nível superior; seus nós filhos usam o arranjo selecionado. A apresentação modificada é então salva.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```
## **Criar um organograma de imagem**

Um organograma de imagem é um layout SmartArt projetado para diagramas hierárquicos que incluem espaços reservados para imagens. Use o valor `PICTURE_ORGANIZATION_CHART` do [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) ao adicionar o objeto SmartArt a um slide. Este exemplo salva um diagrama com espaços reservados de imagem; ele não preenche os espaços reservados com imagens.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```
## **Converter diagramas legados em grupos de formas**

Ao modernizar uma apresentação existente, pode ser necessário atualizar um organograma criado originalmente no PowerPoint 97–2003. Aspose.Slides representa esses diagramas legados como objetos [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/). Use [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) para converter um diagrama em um grupo de formas, permitindo editar elementos visuais individuais. Consulte a [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) para detalhes.

A conversão adiciona um novo grupo à coleção de formas sem remover o diagrama original. Após a conversão bem‑sucedida, remova o original com [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) para evitar conteúdo duplicado. Reúna os diagramas legados em uma lista antes de convertê‑los, de modo que a adição e remoção de formas não interrompa a iteração.

O exemplo a seguir abre uma apresentação, procura em cada slide, converte os diagramas em grupos de formas e salva a apresentação atualizada como PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```
A apresentação salva contém grupos de formas editáveis no lugar dos diagramas legados convertidos, sem diagramas originais restantes ao lado deles. Abra o PPTX no PowerPoint para editar elementos individuais dentro de cada grupo, como texto, preenchimento ou posição.

## **Perguntas frequentes**

**O SmartArt oferece suporte a espelhamento ou inversão para idiomas RTL?**

Sim. A propriedade [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) altera a direção do diagrama de esquerda‑para‑direita para direita‑para‑esquerda, ou vice‑versa, quando o layout SmartArt selecionado suporta inversão.

**Como posso copiar o SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/python-net/shape-manipulations/) com [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) ou [clonar o slide inteiro](/slides/pt/python-net/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam tamanho, posição e formatação.

**Como renderizar o SmartArt para uma imagem raster para visualização ou exportação web?**

[Renderizar o slide](/slides/pt/python-net/convert-powerpoint-to-png/) ou a apresentação inteira para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como encontrar um objeto SmartArt específico em um slide se houver vários?**

Defina um [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) ou um valor [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) distintivo na forma SmartArt, procure esse valor em [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), e então verifique se a forma correspondente é um [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).