---
title: "Gerenciar Gráficos SmartArt em Apresentações Usando Python"
linktitle: "Gráficos SmartArt"
type: docs
weight: 20
url: /pt/python-java/manage-smartart-shape/
keywords:
- objeto SmartArt
- gráfico SmartArt
- estilo SmartArt
- cor SmartArt
- criar SmartArt
- adicionar SmartArt
- editar SmartArt
- alterar SmartArt
- acessar SmartArt
- tipo de layout SmartArt
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Automatize a criação, edição e estilização de SmartArt no PowerPoint em Python usando Aspose.Slides, com exemplos de código concisos e orientações focadas em desempenho."
---
## **Visão geral**

Aspose.Slides permite criar e gerenciar gráficos SmartArt em apresentações do PowerPoint programaticamente. Este artigo explica como adicionar uma forma SmartArt a um slide, acessar formas SmartArt existentes, encontrar SmartArt por um tipo de layout específico e atualizar sua aparência visual alterando o estilo SmartArt ou o estilo de cor.

Os exemplos mostram como trabalhar com formas SmartArt através da coleção de formas do slide da apresentação, verificar se uma forma é SmartArt e então modificar ou inspecionar suas propriedades.

## **Criar uma forma SmartArt**
Aspose.Slides for Python via Java fornece uma API para criar formas SmartArt. Para criar uma forma SmartArt em um slide, siga as etapas abaixo:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) class.
1. Obtenha um slide pelo seu índice.
1. [Adicionar um SmartArt shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addSmartArt) especificando um [SmartArtLayoutType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartartlayouttype/).
1. Salve a apresentação modificada como um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Salvar a apresentação.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt adicionada ao slide**|

## **Acessar uma forma SmartArt em um slide**
O exemplo a seguir acessa formas SmartArt em um slide de apresentação. Ele itera por todas as formas do slide e verifica se a forma é uma instância de [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iterar por todas as formas no primeiro slide.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Acessar uma forma SmartArt com um tipo de layout específico**
O exemplo a seguir acessa uma forma [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/) com um tipo de layout específico, retornado por [SmartArt.getLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/#getLayout).

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) class e carregue a apresentação que contém uma forma SmartArt.
1. Obtenha o primeiro slide pelo seu índice.
1. Itere por todas as formas do primeiro slide.
1. Verifique se a forma é uma instância de [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/).
1. Verifique se a forma SmartArt tem o tipo de layout especificado e execute a operação necessária.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iterar por todas as formas no primeiro slide.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Verificar o layout do SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Alterar o estilo de uma forma SmartArt**
Este exemplo mostra como alterar o estilo rápido de uma forma SmartArt.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) class e carregue a apresentação que contém uma forma SmartArt.
1. Obtenha o primeiro slide pelo seu índice.
1. Itere por todas as formas do primeiro slide.
1. Verifique se a forma é uma instância de [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/).
1. Encontre a forma SmartArt com o estilo especificado.
1. Defina o novo estilo para a forma SmartArt.
1. Salve a apresentação.

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Iterar por todas as formas no primeiro slide.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Verificar e alterar o estilo do SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt com estilo alterado**|

## **Alterar o estilo de cor de uma forma SmartArt**
Este exemplo acessa uma forma SmartArt com um estilo de cor específico e altera esse estilo.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) class e carregue a apresentação que contém uma forma SmartArt.
1. Obtenha o primeiro slide pelo seu índice.
1. Itere por todas as formas do primeiro slide.
1. Verifique se a forma é uma instância de [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/).
1. Encontre a forma SmartArt com o estilo de cor especificado.
1. Defina o novo estilo de cor para a forma SmartArt.
1. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Iterar por todas as formas no primeiro slide.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Verificar e alterar o estilo do SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt com estilo de cor alterado**|

## **FAQ**

**Posso animar SmartArt como um único objeto?**

Sim. SmartArt é uma forma, portanto você pode aplicar [standard animations](/slides/pt/python-java/powerpoint-animation/) via a API de animações (entrada, saída, ênfase, caminhos de movimento) da mesma forma que para outras formas.

**Como posso encontrar um SmartArt específico em um slide se não conheço seu ID interno?**

Defina e use o [alternative text](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#setAlternativeText) e procure a forma por esse valor — essa é a forma recomendada para localizar a forma alvo.

**Posso agrupar SmartArt com outras formas?**

Sim. Você pode agrupar SmartArt com outras formas (imagens, tabelas, etc.) e então [manipulate the group](/slides/pt/python-java/group/).

**Como obtenho uma imagem de um SmartArt específico (por exemplo, para pré‑visualização ou relatório)?**

Exporte uma miniatura/imagem da forma; a biblioteca pode [render individual shapes](/slides/pt/python-java/create-shape-thumbnails/) para arquivos raster (PNG/JPG/TIFF).

**A aparência do SmartArt será preservada ao converter toda a apresentação para PDF?**

Sim. O motor de renderização visa alta fidelidade para [PDF export](/slides/pt/python-java/convert-powerpoint-to-pdf/), com uma variedade de opções de qualidade e compatibilidade.