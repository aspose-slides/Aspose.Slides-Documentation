---
title: Gerenciar SmartArt em Apresentações PowerPoint Usando Python
linktitle: Gerenciar SmartArt
type: docs
weight: 10
url: /pt/python-java/manage-smartart/
keywords:
- SmartArt
- Texto do SmartArt
- tipo de layout
- propriedade oculta
- organograma
- organograma com imagem
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt no PowerPoint com Aspose.Slides para Python via Java usando exemplos de código claros que aceleram o design de slides e a automação."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com Aspose.Slides para Python via Java, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organogramas e criar organogramas com imagens.

## **Obter texto de um objeto SmartArt**

Um nó SmartArt pode conter uma ou mais formas. Para ler o texto visível, percorra [SmartArt.getAllNodes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/#getAllNodes), então leia o [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/) retornado por [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartshape/#getTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape

        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartlayouttype/), altera para o valor `BasicProcess` e salva a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verificar se um nó SmartArt está oculto**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnode/#isHidden) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos visíveis do diagrama.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartlayouttype/) e verifica o estado oculto do nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que utilizam um layout de organograma, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) e [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) definem como os nós filhos são organizados sob um nó pai. Por exemplo, você pode definir que os nós filhos pendam à esquerda, à direita ou em ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/organizationchartlayouttype/) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/organizationchartlayouttype/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Criar um organograma com imagens**

Um organograma com imagens é um layout SmartArt projetado para diagramas hierárquicos que incluem marcadores de posição de imagem. Use o valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartlayouttype/) ao adicionar o objeto SmartArt a um slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**O SmartArt suporta espelhamento ou inversão para idiomas RTL?**

Sim. O método [SmartArt.setReversed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/#setReversed) altera a direção do diagrama de esquerda‑para‑direita para direita‑para‑esquerda, ou vice‑versa, quando o layout SmartArt selecionado suporta inversão.

**Como posso copiar o SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/python-java/shape-manipulations/) com [ShapeCollection.addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addClone) ou [clonar o slide inteiro](/slides/pt/python-java/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam tamanho, posição e formatação.

**Como renderizar o SmartArt para uma imagem raster para visualização ou exportação web?**

[Renderizar o slide](/slides/pt/python-java/convert-powerpoint-to-png/) ou a apresentação inteira para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como encontrar um objeto SmartArt específico em um slide se houver vários?**

Defina um valor distintivo em [Shape.getAlternativeText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getAlternativeText) ou [Shape.getName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getName) na forma SmartArt, procure esse valor em [BaseSlide.getShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getShapes), e então verifique se a forma correspondente é um [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/).