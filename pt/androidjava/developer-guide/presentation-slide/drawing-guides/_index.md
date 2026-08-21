---
title: Gerenciar Guias de Desenho em Apresentações no Android
linktitle: Guias de Desenho
type: docs
weight: 85
url: /pt/androidjava/drawing-guides/
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
- Android
- Java
- Aspose.Slides
description: "Adicionar, acessar e limpar guias de desenho horizontais e verticais em apresentações do PowerPoint usando Aspose.Slides para Android via Java."
---
## **Visão geral**

Guias de desenho são linhas horizontais e verticais ajustáveis que ajudam os usuários a alinhar formas de forma consistente ao editar uma apresentação no PowerPoint. Elas são especialmente úteis quando um aplicativo gera uma apresentação que será refinada manualmente posteriormente: o aplicativo pode salvar os mesmos auxílios de alinhamento que os autores devem seguir ao adicionar ou mover conteúdo.

Guias de desenho são auxílios de edição, não conteúdo de slide. Elas não aparecem em uma apresentação de slides ou na saída renderizada. Aspose.Slides para Android via Java as expõe através da interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idrawingguidescollection/). Um guia é representado por [IDrawingGuide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idrawingguide/) e possui uma orientação, uma posição e uma cor.

A posição é medida em pontos a partir do canto superior esquerdo do slide ou mestre relevante. Um guia vertical usa uma coordenada horizontal, normalmente entre zero e a largura do slide. Um guia horizontal usa uma coordenada vertical, normalmente entre zero e a altura do slide.

## **Adicionar guias à visualização de slides**

Use [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) para gerenciar os guias exibidos ao editar slides normais. Chame [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) com um valor de [Orientation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/orientation/) e uma posição em pontos.

O exemplo a seguir adiciona um guia vertical à direita do centro do slide e um guia horizontal abaixo dele:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acessar guias de desenho**

Os métodos [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) e [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) fornecem acesso aos guias existentes. Os métodos [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idrawingguide/#getPosition--) e [IDrawingGuide.getColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idrawingguide/#getColor--) retornam valores que também podem ser alterados através dos métodos setter correspondentes.

O exemplo a seguir lê os guias da visualização de slide da apresentação criada acima:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Adicionar guias a mestres e slides de layout**

Um slide mestre e cada um de seus slides de layout podem ter suas próprias coleções de guias de desenho. Use [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) para um slide mestre e [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) para um slide de layout.

O exemplo a seguir adiciona um guia vertical ao primeiro slide mestre e um guia horizontal ao primeiro slide de layout:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar guias a mestres de notas e de folhetos**

Mestres de notas e mestres de folhetos também suportam guias de desenho. Use [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) e [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) para acessar suas coleções. Se uma apresentação não contiver um desses mestres, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) ou [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) cria o mestre padrão e o retorna.

O exemplo a seguir adiciona um guia horizontal a um mestre de notas e um guia vertical a um mestre de folhetos:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Limpar guias de desenho**

Chame [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) para remover todos os guias de uma coleção específica. Limpar uma coleção não afeta os guias armazenados em outro escopo.

O exemplo a seguir limpa os guias da visualização de slide e todos os guias em mestres de slides, slides de layout, o mestre de notas e o mestre de folhetos sem criar mestres ausentes:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Os guias de desenho aparecem em uma apresentação de slides ou em imagens exportadas?**

Não. Os guias de desenho são auxílios de alinhamento para edição e não são renderizados como conteúdo da apresentação.

**Um guia de desenho pode ser adicionado diretamente a um slide normal individual?**

Os guias de edição de slides normais são armazenados nas propriedades de visualização de slides da apresentação. Coleções de guias separadas estão disponíveis para mestres de slides, slides de layout, mestres de notas e mestres de folhetos.

**Quais unidades são usadas para as posições dos guias?**

As posições são especificadas em pontos, onde 72 pontos equivalem a uma polegada. As posições verticais são medidas a partir da borda esquerda, e as posições horizontais são medidas a partir da borda superior.

**Limpar guias de desenho remove formas ou altera o conteúdo do slide?**

Não. O método [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) remove apenas os guias na coleção selecionada. Formas e outros conteúdos do slide permanecem inalterados.