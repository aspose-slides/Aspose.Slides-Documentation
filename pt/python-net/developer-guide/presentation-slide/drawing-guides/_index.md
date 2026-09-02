---
title: Gerenciar Guias de Desenho em Apresentações em Python
linktitle: Guias de Desenho
type: docs
weight: 85
url: /pt/python-net/drawing-guides/
keywords:
- guia de desenho
- guia horizontal
- guia vertical
- guia de alinhamento
- visualização de slide
- slide mestre
- slide de layout
- mestre de notas
- mestre de folheto
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Adicionar, acessar e limpar guias de desenho horizontais e verticais em apresentações do PowerPoint usando Aspose.Slides para Python via .NET."
---
## **Visão geral**

Guias de desenho são linhas horizontais e verticais ajustáveis que ajudam os usuários a alinhar formas de forma consistente ao editar uma apresentação no PowerPoint. Elas são especialmente úteis quando um aplicativo gera uma apresentação que será refinada manualmente posteriormente: o aplicativo pode salvar os mesmos auxílios de alinhamento que os autores devem seguir ao adicionar ou mover conteúdo.

Guias de desenho são auxílios de edição, não conteúdo de slide. Elas não aparecem em uma apresentação de slide ou saída renderizada. Aspose.Slides for Python via .NET as\nexibe por meio da interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/idrawingguidescollection/). Um guia é representado por [IDrawingGuide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/idrawingguide/) e possui uma orientação, uma posição e uma cor.

A posição é medida em pontos a partir do canto superior esquerdo do slide ou mestre relevante. Um guia vertical usa uma coordenada horizontal, normalmente entre zero e a largura do slide. Um guia horizontal usa uma coordenada vertical, normalmente entre zero e a altura do slide.

## **Adicionar guias à visualização de slides**

Use [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) para gerenciar os guias exibidos ao editar slides normais. Chame [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/pt/python-net/aspose.slides/idrawingguidescollection/add/) com um valor de [Orientation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/orientation/) e uma posição em pontos.

O exemplo a seguir adiciona um guia vertical à direita do centro do slide e um guia horizontal abaixo dele:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar guias de desenho**

A propriedade [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/pt/python-net/aspose.slides/idrawingguidescollection/count/) e o indexador fornecem acesso aos guias existentes. As propriedades [IDrawingGuide.orientation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/pt/python-net/aspose.slides/idrawingguide/position/) e [IDrawingGuide.color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/idrawingguide/color/) podem ser lidas ou alteradas.

O exemplo a seguir lê os guias da visualização de slides da apresentação criada acima:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Adicionar guias a mestres e slides de layout**

Um slide mestre e cada um de seus slides de layout podem ter suas próprias coleções de guias de desenho. Use [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imasterslide/drawing_guides/) para um slide mestre e [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ilayoutslide/drawing_guides/) para um slide de layout.

O exemplo a seguir adiciona um guia vertical ao primeiro slide mestre e um guia horizontal ao primeiro slide de layout:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Adicionar guias a mestres de notas e de folhetos**

Mestres de notas e mestres de folhetos também suportam guias de desenho. Use [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imasternotesslide/drawing_guides/) e [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) para acessar suas coleções. Se uma apresentação não contiver um desses mestres, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) ou [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) cria o mestre padrão e o retorna.

O exemplo a seguir adiciona um guia horizontal a um mestre de notas e um guia vertical a um mestre de folhetos:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Limpar guias de desenho**

Chame [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/pt/python-net/aspose.slides/idrawingguidescollection/clear/) para remover todos os guias de uma coleção específica. Limpar uma coleção não afeta os guias armazenados em outro escopo.

O exemplo a seguir limpa os guias da visualização de slides e todos os guias em mestres de slides, slides de layout, mestre de notas e mestre de folhetos sem criar mestres ausentes:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**Os guias de desenho aparecem em uma apresentação de slides ou em imagens exportadas?**

Não. Guias de desenho são auxílios de alinhamento para edição e não são renderizados como conteúdo da apresentação.

**Um guia de desenho pode ser adicionado diretamente a um slide normal individual?**

Os guias de edição de slide normal são armazenados nas propriedades de visualização de slide da apresentação. Coleções de guias separadas estão disponíveis para mestres de slides, slides de layout, mestres de notas e mestres de folhetos.

**Quais unidades são usadas para as posições dos guias?**

As posições são especificadas em pontos, onde 72 pontos correspondem a uma polegada. Posições verticais são medidas a partir da borda esquerda e posições horizontais são medidas a partir da borda superior.

**Limpar guias de desenho remove formas ou altera o conteúdo do slide?**

Não. O método `clear` remove apenas os guias na coleção selecionada. Formas e outros conteúdos do slide permanecem inalterados.