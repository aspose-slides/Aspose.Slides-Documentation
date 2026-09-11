---
title: Gerenciar nós de forma SmartArt em apresentações usando Python
linktitle: Nó de forma SmartArt
type: docs
weight: 30
url: /pt/python-java/manage-smartart-shape-node/
keywords:
- nó SmartArt
- nó filho
- adicionar nó
- posição do nó
- acessar nó
- remover nó
- posição personalizada
- nó assistente
- formato de preenchimento
- renderizar nó
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Gerencie nós de forma SmartArt em PPT e PPTX com Aspose.Slides for Python via Java. Obtenha exemplos de código claros e dicas para otimizar suas apresentações."
---
## **Visão geral**

Os gráficos SmartArt nas apresentações do PowerPoint são organizados por meio de nós que contêm texto e definem a estrutura do diagrama. Aspose.Slides permite que você trabalhe com esses nós SmartArt programaticamente: adicionar novos nós e nós filhos, inserir nós filhos em uma posição específica, acessar nós existentes e ler seu texto, nível e posição.

Este artigo explica como gerenciar nós de formas SmartArt. Ele mostra como remover nós, trabalhar com nós filhos por índice ou posição, alterar um nó assistente para um nó normal, ajustar a posição, tamanho e rotação das formas dos nós SmartArt, definir formatos de preenchimento dos nós e gerar uma imagem em miniatura para um nó filho SmartArt.

## **Adicionar um nó SmartArt**
Aspose.Slides for Python via Java fornece uma API para gerenciar formas SmartArt. O exemplo a seguir adiciona um nó e um nó filho a uma forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação que contém uma forma SmartArt.
1. Obtenha o primeiro slide pelo seu índice.
1. Itere por todas as formas no primeiro slide.
1. Verifique se a forma é uma instância de [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/).
1. [Adicione um novo nó](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnodecollection/#addNode) à [coleção de nós](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/#getAllNodes) da forma SmartArt e defina seu texto através de [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/).
1. [Adicione](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnodecollection/#addNode) um [nó filho](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnode/#getChildNodes) ao novo nó e defina seu texto através de [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/).
1. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Adicionar um nó SmartArt em uma posição específica**
O exemplo a seguir adiciona um nó filho em uma posição específica em um nó SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha o primeiro slide pelo seu índice.
1. Adicione uma forma [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/) com o layout [StackedList](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartlayouttype/#StackedList) ao slide.
1. Acesse o primeiro nó na forma SmartArt adicionada.
1. Adicione um nó filho ao nó selecionado na posição 2 usando [addNodeByPosition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) e defina seu texto.
1. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acessar um nó SmartArt**
O exemplo a seguir acessa nós em uma forma SmartArt. O layout retornado por [getLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/#getLayout) é somente leitura e é definido quando a forma SmartArt é adicionada.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação que contém uma forma SmartArt.
1. Obtenha o primeiro slide pelo seu índice.
1. Itere por todas as formas no primeiro slide.
1. Verifique se a forma é uma instância de [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/).
1. Itere por todos os [nós](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/#getAllNodes) na forma SmartArt.
1. Leia e exiba a posição, nível e texto de cada nó SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Acessar um nó filho SmartArt**
O exemplo a seguir acessa os nós filhos de cada nó em uma forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação que contém uma forma SmartArt.
1. Obtenha o primeiro slide pelo seu índice.
1. Itere por todas as formas no primeiro slide.
1. Verifique se a forma é uma instância de [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/).
1. Itere por todos os nós na forma SmartArt.
1. Para cada nó, itere pelos seus [nós filhos](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnode/#getChildNodes).
1. Leia e exiba a posição, nível e texto do [nó filho](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Acessar um nó filho SmartArt em uma posição específica**
O exemplo a seguir acessa um nó filho em um índice específico na coleção de seu nó pai.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha o primeiro slide pelo seu índice.
1. Adicione uma forma SmartArt com o layout [StackedList](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartlayouttype/#StackedList).
1. Acesse a forma SmartArt adicionada.
1. Acesse o nó no índice 0 na forma SmartArt.
1. Acesse o nó filho no índice 1 usando [get_Item](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnodecollection/#get_Item).
1. Leia e exiba a posição, nível e texto do [nó filho](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Remover um nó SmartArt**
O exemplo a seguir remove um nó de uma forma SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação que contém uma forma SmartArt.
1. Obtenha o primeiro slide pelo seu índice.
1. Itere por todas as formas no primeiro slide.
1. Verifique se a forma é uma instância de [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/).
1. Verifique se a forma [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/) contém pelo menos um nó.
1. Selecione o nó SmartArt a ser excluído.
1. Remova o nó selecionado usando [removeNode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remover um nó SmartArt de uma posição específica**
O exemplo a seguir remove um nó filho em um índice específico na coleção de nós de um SmartArt.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha o primeiro slide pelo seu índice.
1. Itere por todas as formas no primeiro slide.
1. Verifique se a forma é uma instância de [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/).
1. Acesse o nó SmartArt no índice 0 se existir.
1. Verifique se o nó SmartArt selecionado tem pelo menos dois nós filhos.
1. Remova o nó filho no índice 1 usando [removeNode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir uma posição personalizada para um nó filho em um objeto SmartArt**
Aspose.Slides for Python via Java oferece suporte à definição da posição de um [SmartArtShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartshape/) usando [setX](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#setX) e [setY](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#setY). O exemplo a seguir define uma posição personalizada, tamanho e rotação para as formas dos nós SmartArt. A adição de novos nós recalcula as posições e tamanhos de todos os nós. O posicionamento personalizado permite organizar os nós conforme necessário.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verificar um nó assistente**
{{% alert color="info" title="Nota" %}} 

Esta seção explora formas SmartArt adicionadas a slides de apresentação programaticamente usando Aspose.Slides for Python via Java.

{{% /alert %}} 

A forma SmartArt de origem a seguir é usada neste exemplo.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt de origem em um slide**|

O exemplo a seguir identifica nós assistentes em uma coleção de nós SmartArt e os altera para nós normais.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação que contém uma forma SmartArt.
1. Obtenha o primeiro slide pelo seu índice.
1. Itere por todas as formas no primeiro slide.
1. Verifique se a forma é uma instância de [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/).
1. Itere por todos os nós na forma SmartArt e verifique se são [Assistant Nodes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartnode/#isAssistant).
1. Altere cada nó assistente para um nó normal.
1. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nós assistentes alterados em uma forma SmartArt em um slide**|

## **Definir o formato de preenchimento de um nó**
Aspose.Slides for Python via Java permite adicionar formas SmartArt personalizadas e definir seu formato de preenchimento. Este artigo explica como criar e acessar formas SmartArt e definir seu formato de preenchimento usando Aspose.Slides for Python via Java.

Por favor, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha um slide pelo seu índice.
1. Adicione uma forma [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/) com o layout [ClosedChevronProcess](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess).
1. Defina o [FillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getFillFormat) para os nós da forma SmartArt.
1. Grave a apresentação modificada como um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gerar uma miniatura de um nó filho SmartArt**
Para gerar uma miniatura de um nó filho SmartArt, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. [Adicione uma forma SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addSmartArt).
1. Obtenha um nó pelo seu índice.
1. Obtenha a imagem da miniatura.
1. Salve a imagem da miniatura em qualquer formato de imagem desejado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**A animação SmartArt é suportada?**

Sim. SmartArt é tratada como uma forma comum, portanto você pode [aplicar animações padrão](/slides/pt/python-java/shape-animation/) (entrada, saída, ênfase, caminhos de movimento) e ajustar o tempo. Você também pode animar formas dentro dos nós SmartArt quando necessário.

**Como posso localizar de forma confiável um SmartArt específico em um slide se seu ID interno for desconhecido?**

Atribua e procure por [texto alternativo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getAlternativeText). Definir um texto alternativo distintivo no SmartArt permite encontrá-lo programaticamente sem depender de identificadores internos.

**A aparência do SmartArt será preservada ao converter a apresentação para PDF?**

Sim. Aspose.Slides renderiza SmartArt com alta fidelidade visual durante a [exportação para PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/), preservando layout, cores e efeitos.

**Posso extrair uma imagem de todo o SmartArt (para pré-visualizações ou relatórios)?**

Sim. Você pode renderizar uma forma SmartArt para [formatos raster](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getImage) ou para [SVG](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#writeAsSvgToBytes) para saída vetorial escalável, tornando-a adequada para miniaturas, relatórios ou uso na web.