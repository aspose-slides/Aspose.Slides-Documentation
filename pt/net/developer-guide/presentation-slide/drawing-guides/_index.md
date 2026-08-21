---
title: Gerenciar guias de desenho em apresentações em .NET
linktitle: Guias de desenho
type: docs
weight: 85
url: /pt/net/drawing-guides/
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
- .NET
- C#
- Aspose.Slides
description: "Adicionar, acessar e remover guias de desenho horizontais e verticais em apresentações PowerPoint usando Aspose.Slides para .NET."
---
## **Visão geral**

Guias de desenho são linhas horizontais e verticais ajustáveis que ajudam os usuários a alinhar formas de forma consistente ao editar uma apresentação no PowerPoint. Elas são especialmente úteis quando uma aplicação gera uma apresentação que será refinada manualmente posteriormente: a aplicação pode salvar os mesmos auxiliares de alinhamento que os autores devem seguir ao adicionar ou mover conteúdo.

Guias de desenho são auxiliares de edição, não conteúdo de slide. Elas não aparecem em uma apresentação de slides ou na saída renderizada. Aspose.Slides for .NET as as expõe por meio da interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/idrawingguidescollection/). Um guia é representado por [IDrawingGuide](https://reference.aspose.com/slides/pt/net/aspose.slides/idrawingguide/) e possui uma orientação, uma posição e uma cor.

A posição é medida em pontos a partir do canto superior esquerdo do slide ou mestre relevante. Um guia vertical usa uma coordenada horizontal, normalmente entre zero e a largura do slide. Um guia horizontal usa uma coordenada vertical, normalmente entre zero e a altura do slide.

## **Adicionar guias à visualização de slide**

Use [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/pt/net/aspose.slides/icommonslideviewproperties/drawingguides/) para gerenciar os guias exibidos ao editar slides normais. Chame [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/pt/net/aspose.slides/idrawingguidescollection/add/) com um valor de [Orientation](https://reference.aspose.com/slides/pt/net/aspose.slides/orientation/) e uma posição em pontos.

O exemplo a seguir adiciona um guia vertical à direita do centro do slide e um guia horizontal abaixo dele:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Acessar guias de desenho**

A propriedade [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/pt/net/aspose.slides/idrawingguidescollection/count/) e o indexador fornecem acesso aos guias existentes. As propriedades [IDrawingGuide.Orientation](https://reference.aspose.com/slides/pt/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/pt/net/aspose.slides/idrawingguide/position/) e [IDrawingGuide.Color](https://reference.aspose.com/slides/pt/net/aspose.slides/idrawingguide/color/) podem ser lidas ou alteradas.

O exemplo a seguir lê os guias da visualização de slide da apresentação criada acima:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Adicionar guias a slides mestre e de layout**

Um slide mestre e cada um de seus slides de layout podem ter suas próprias coleções de guias de desenho. Use [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/drawingguides/) para um slide mestre e [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/drawingguides/) para um slide de layout.

O exemplo a seguir adiciona um guia vertical ao primeiro slide mestre e um guia horizontal ao primeiro slide de layout:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Adicionar guias a mestres de notas e de folheto**

Mestres de notas e mestres de folheto também suportam guias de desenho. Use [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/pt/net/aspose.slides/imasternotesslide/drawingguides/) e [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterhandoutslide/drawingguides/) para acessar suas coleções. Se uma apresentação não contiver um desses mestres, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) ou [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) cria o mestre padrão e o retorna.

O exemplo a seguir adiciona um guia horizontal a um mestre de notas e um guia vertical a um mestre de folheto:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Remover guias de desenho**

Chame [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/pt/net/aspose.slides/idrawingguidescollection/clear/) para remover todos os guias de uma determinada coleção. Limpar uma coleção não afeta os guias armazenados em outro escopo.

O exemplo a seguir limpa os guias da visualização de slide e todos os guias em slides mestres, slides de layout, o mestre de notas e o mestre de folheto sem criar mestres ausentes:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **Perguntas frequentes**

**Os guias de desenho aparecem em uma apresentação de slides ou em imagens exportadas?**

Não. Os guias de desenho são auxílios de alinhamento para edição e não são renderizados como conteúdo da apresentação.

**Um guia de desenho pode ser adicionado diretamente a um slide normal individual?**

Os guias de edição de slide normal são armazenados nas propriedades de visualização de slide da apresentação. Coleções de guias separadas estão disponíveis para slides mestres, slides de layout, mestres de notas e mestres de folheto.

**Quais unidades são usadas para as posições dos guias?**

As posições são especificadas em pontos, onde 72 pontos equivalem a uma polegada. As posições verticais são medidas a partir da borda esquerda, e as posições horizontais são medidas a partir da borda superior.

**A limpeza dos guias de desenho remove formas ou altera o conteúdo do slide?**

Não. O método `Clear` remove apenas os guias na coleção selecionada. Formas e outros conteúdos do slide permanecem inalterados.