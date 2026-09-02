---
title: Gerenciar Guias de Desenho em Apresentações em PHP
linktitle: Guias de Desenho
type: docs
weight: 85
url: /pt/php-java/drawing-guides/
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
- PHP
- Aspose.Slides
description: "Adicionar, acessar e limpar guias de desenho horizontais e verticais em apresentações do PowerPoint usando Aspose.Slides para PHP via Java."
---
## **Visão geral**

Guias de desenho são linhas horizontais e verticais ajustáveis que ajudam os usuários a alinhar formas de forma consistente ao editar uma apresentação no PowerPoint. Elas são especialmente úteis quando um aplicativo gera uma apresentação que será refinada manualmente posteriormente: o aplicativo pode salvar os mesmos recursos de alinhamento que os autores devem seguir ao adicionar ou mover conteúdo.

Guias de desenho são auxiliares de edição, não conteúdo de slide. Elas não aparecem em uma apresentação de slides ou saída renderizada. Aspose.Slides para PHP via Java as disponibiliza através da classe [DrawingGuidesCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/drawingguidescollection/). Um guia é representado por [DrawingGuide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/drawingguide/) e tem uma orientação, uma posição e uma cor.

A posição é medida em pontos a partir do canto superior esquerdo do slide ou mestre relevante. Um guia vertical usa uma coordenada horizontal, tipicamente entre zero e a largura do slide. Um guia horizontal usa uma coordenada vertical, tipicamente entre zero e a altura do slide.

## **Adicionar Guias à Visualização de Slides**

Use [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) para gerenciar os guias exibidos ao editar slides normais. Chame [DrawingGuidesCollection::add](https://reference.aspose.com/slides/pt/php-java/aspose.slides/drawingguidescollection/#add) com um valor de [Orientation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/orientation/) e uma posição em pontos.

O exemplo a seguir adiciona um guia vertical à direita do centro do slide e um guia horizontal abaixo dele:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Acessar Guias de Desenho**

Os métodos [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/pt/php-java/aspose.slides/drawingguidescollection/#getCount) e [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/pt/php-java/aspose.slides/drawingguidescollection/#get_Item) fornecem acesso aos guias existentes. Os métodos [DrawingGuide::getOrientation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/pt/php-java/aspose.slides/drawingguide/#getPosition) e [DrawingGuide::getColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/drawingguide/#getColor) retornam valores que também podem ser alterados através dos respectivos métodos setter.

O exemplo a seguir lê os guias da visualização de slide da apresentação criada acima:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Adicionar Guias ao Mestre e aos Slides de Layout**

Um mestre de slide e cada um de seus slides de layout podem ter suas próprias coleções de guias de desenho. Use [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/#getDrawingGuides) para um slide mestre e [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/#getDrawingGuides) para um slide de layout.

O exemplo a seguir adiciona um guia vertical ao primeiro slide mestre e um guia horizontal ao primeiro slide de layout:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Adicionar Guias a Mestres de Notas e Folhetos**

Mestres de notas e mestres de folhetos também suportam guias de desenho. Use [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masternotesslide/#getDrawingGuides) e [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) para acessar suas coleções. Se uma apresentação não contiver um desses mestres, recupere o gerenciador adequado com [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) ou [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), então crie o mestre padrão com `setDefaultMasterNotesSlide` ou `setDefaultMasterHandoutSlide`.

O exemplo a seguir adiciona um guia horizontal a um mestre de notas e um guia vertical a um mestre de folhetos:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Limpar Guias de Desenho**

Chame [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/pt/php-java/aspose.slides/drawingguidescollection/#clear) para remover todos os guias de uma coleção específica. Limpar uma coleção não afeta os guias armazenados em outro escopo.

O exemplo a seguir limpa os guias da visualização de slide e todos os guias nos mestres de slide, slides de layout, mestre de notas e mestre de folhetos sem criar mestres ausentes:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Perguntas frequentes**

**Os guias de desenho aparecem em uma apresentação de slides ou imagens exportadas?**

Não. Os guias de desenho são auxílios de alinhamento para edição e não são renderizados como conteúdo da apresentação.

**Um guia de desenho pode ser adicionado diretamente a um slide normal individual?**

Os guias de edição de slides normais são armazenados nas propriedades de visualização de slide da apresentação. Coleções de guias separadas estão disponíveis para mestres de slide, slides de layout, mestres de notas e mestres de folhetos.

**Quais unidades são usadas para as posições dos guias?**

As posições são especificadas em pontos, onde 72 pontos equivalem a uma polegada. As posições verticais são medidas a partir da borda esquerda, e as posições horizontais são medidas a partir da borda superior.

**Limpar os guias de desenho remove formas ou altera o conteúdo do slide?**

Não. O método [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/pt/php-java/aspose.slides/drawingguidescollection/#clear) remove apenas os guias na coleção selecionada. Formas e outros conteúdos do slide permanecem inalterados.