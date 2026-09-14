---
title: Gerenciar Guias de Desenho em Apresentações em Python
linktitle: Guias de Desenho
type: docs
weight: 85
url: /pt/python-java/drawing-guides/
keywords:
- guia de desenho
- guia horizontal
- guia vertical
- guia de alinhamento
- visualização de slide
- slide mestre
- slide de layout
- mestre de notas
- mestre de folhetos
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Adicionar, acessar e limpar guias de desenho horizontais e verticais em apresentações do PowerPoint usando Aspose.Slides para Python via Java."
---
## **Visão geral**

Guias de desenho são linhas horizontais e verticais ajustáveis que ajudam os usuários a alinhar formas de forma consistente ao editar uma apresentação no PowerPoint. Elas são especialmente úteis quando um aplicativo gera uma apresentação que será refinada manualmente posteriormente: o aplicativo pode salvar os mesmos auxílios de alinhamento que os autores devem seguir ao adicionar ou mover conteúdo.

Guias de desenho são auxílios de edição, não conteúdo de slide. Elas não aparecem em uma apresentação de slides ou na saída renderizada. Aspose.Slides for Python via Java as expõe por meio da classe [DrawingGuidesCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/drawingguidescollection/). Um guia é representado por [DrawingGuide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/drawingguide/) e possui uma orientação, uma posição e uma cor.

A posição é medida em pontos a partir do canto superior esquerdo do slide ou mestre relevante. Um guia vertical usa uma coordenada horizontal, normalmente entre zero e a largura do slide. Um guia horizontal usa uma coordenada vertical, normalmente entre zero e a altura do slide.

## **Adicionar guias à visualização de slides**

Use [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) para gerenciar guias exibidas ao editar slides normais. Chame [DrawingGuidesCollection.add](https://reference.aspose.com/slides/pt/python-java/aspose.slides/drawingguidescollection/#add) com um valor de [Orientation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/orientation/) e uma posição em pontos.

O exemplo a seguir adiciona um guia vertical à direita do centro do slide e um guia horizontal abaixo dele:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acessar guias de desenho**

Os métodos [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/pt/python-java/aspose.slides/drawingguidescollection/#getCount) e [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/pt/python-java/aspose.slides/drawingguidescollection/#get_Item) fornecem acesso aos guias existentes. Os métodos [DrawingGuide.getOrientation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/drawingguide/#getPosition) e [DrawingGuide.getColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/drawingguide/#getColor) retornam valores que podem também ser alterados pelos métodos setters correspondentes.

O exemplo a seguir lê os guias da visualização de slides da apresentação criada acima:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Adicionar guias aos Slides Mestres e de Layout**

Um slide mestre e cada um de seus slides de layout podem ter suas próprias coleções de guias de desenho. Use [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#getDrawingGuides) para um slide mestre e [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/#getDrawingGuides) para um slide de layout.

O exemplo a seguir adiciona um guia vertical ao primeiro slide mestre e um guia horizontal ao primeiro slide de layout:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Adicionar guias aos Mestres de Notas e Folhetos**

Mestres de notas e mestres de folhetos também suportam guias de desenho. Use [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslide/#getDrawingGuides) e [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) para acessar suas coleções. Se uma apresentação não contiver um desses mestres, `MasterNotesSlideManager.setDefaultMasterNotesSlide` ou `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` cria o mestre padrão e o retorna.

O exemplo a seguir adiciona um guia horizontal a um mestre de notas e um guia vertical a um mestre de folhetos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Limpar guias de desenho**

Chame [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/drawingguidescollection/#clear) para remover todos os guias de uma coleção específica. Limpar uma coleção não afeta os guias armazenados em outro escopo.

O exemplo a seguir limpa os guias da visualização de slides e todos os guias em mestres de slides, slides de layout, o mestre de notas e o mestre de folhetos sem criar mestres ausentes:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Os guias de desenho aparecem em uma apresentação de slides ou em imagens exportadas?**

Não. Guias de desenho são auxílios de alinhamento para edição e não são renderizados como conteúdo da apresentação.

**Um guia de desenho pode ser adicionado diretamente a um slide normal individual?**

Guias de edição de slides normais são armazenados nas propriedades de visualização de slides da apresentação. Coleções de guias separadas estão disponíveis para mestres de slides, slides de layout, mestres de notas e mestres de folhetos.

**Quais unidades são usadas para as posições dos guias?**

As posições são especificadas em pontos, onde 72 pontos equivalem a uma polegada. Posições verticais são medidas a partir da borda esquerda e posições horizontais são medidas a partir da borda superior.

**Limpar guias de desenho remove formas ou altera o conteúdo do slide?**

Não. O método [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/drawingguidescollection/#clear) remove apenas os guias na coleção selecionada. Formas e outros conteúdos do slide permanecem inalterados.