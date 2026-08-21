---
title: Gerenciar guias de desenho em apresentações em JavaScript
linktitle: Guias de Desenho
type: docs
weight: 85
url: /pt/nodejs-java/drawing-guides/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Adicionar, acessar e limpar guias de desenho horizontais e verticais em apresentações do PowerPoint usando Aspose.Slides for Node.js via Java."
---
## **Visão geral**

Os guias de desenho são linhas horizontais e verticais ajustáveis que ajudam os usuários a alinhar formas de forma consistente ao editar uma apresentação no PowerPoint. Eles são especialmente úteis quando um aplicativo gera uma apresentação que será refinada manualmente posteriormente: o aplicativo pode salvar os mesmos auxílios de alinhamento que os autores devem seguir ao adicionar ou mover conteúdo.

Os guias de desenho são auxílios de edição, não conteúdo de slide. Eles não aparecem em uma apresentação de slides nem na saída renderizada. O Aspose.Slides for Node.js via Java os expõe através da classe [DrawingGuidesCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/drawingguidescollection/) . Um guia é representado por [DrawingGuide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/drawingguide/) e possui uma orientação, uma posição e uma cor.

A posição é medida em pontos a partir do canto superior esquerdo do slide ou master relevante. Um guia vertical usa uma coordenada horizontal, tipicamente entre zero e a largura do slide. Um guia horizontal usa uma coordenada vertical, tipicamente entre zero e a altura do slide.

## **Adicionar guias à visualização de slides**

Use [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) para gerenciar os guias exibidos ao editar slides normais. Chame [DrawingGuidesCollection.add](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/drawingguidescollection/#add) com um valor de [Orientation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/orientation/) e uma posição em pontos.

O exemplo a seguir adiciona um guia vertical à direita do centro do slide e um guia horizontal abaixo dele:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acessar guias de desenho**

Os métodos [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/drawingguidescollection/#getCount) e [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) fornecem acesso aos guias existentes. Os métodos [DrawingGuide.getOrientation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/drawingguide/#getPosition) e [DrawingGuide.getColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/drawingguide/#getColor) retornam valores que também podem ser alterados pelos respectivos métodos setter.

O exemplo a seguir lê os guias da visualização de slides da apresentação criada acima:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Adicionar guias a master e slides de layout**

Um slide mestre e cada um de seus slides de layout podem ter suas próprias coleções de guias de desenho. Use [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) para um slide mestre e [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) para um slide de layout.

O exemplo a seguir adiciona um guia vertical ao primeiro slide mestre e um guia horizontal ao primeiro slide de layout:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar guias a notas e handout masters**

Masters de notas e handout também suportam guias de desenho. Use [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) e [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) para acessar suas coleções. Se uma apresentação não contiver um desses masters, `MasterNotesSlideManager.setDefaultMasterNotesSlide` ou `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` cria o master padrão e o retorna.

O exemplo a seguir adiciona um guia horizontal a um master de notas e um guia vertical a um master de handout:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Limpar guias de desenho**

Chame [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/drawingguidescollection/#clear) para remover todos os guias de uma coleção específica. Limpar uma coleção não afeta os guias armazenados em outro escopo.

O exemplo a seguir limpa os guias da visualização de slides e todos os guias em masters de slides, slides de layout, master de notas e master de handout sem criar masters ausentes:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Os guias de desenho aparecem em uma apresentação de slides ou em imagens exportadas?**

Não. Os guias de desenho são auxílios de alinhamento para edição e não são renderizados como conteúdo da apresentação.

**Um guia de desenho pode ser adicionado diretamente a um slide normal individual?**

Os guias de edição de slides normais são armazenados nas propriedades de visualização de slides da apresentação. Coleções de guias separadas estão disponíveis para masters de slides, slides de layout, masters de notas e masters de handout.

**Quais unidades são usadas para as posições dos guias?**

As posições são especificadas em pontos, onde 72 pontos equivalem a uma polegada. As posições verticais são medidas a partir da borda esquerda e as posições horizontais a partir da borda superior.

**Limpar os guias de desenho remove formas ou altera o conteúdo do slide?**

Não. O método [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/drawingguidescollection/#clear) remove apenas os guias na coleção selecionada. Formas e outros conteúdos do slide permanecem inalterados.