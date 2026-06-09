---
title: Slide
type: docs
weight: 10
url: /pt/php-java/examples/elements/slide/
keywords:
- slide
- adicionar slide
- acessar slide
- índice do slide
- clonar slide
- reordenar slides
- remover slide
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie slides em PHP com Aspose.Slides: crie, clone, reordene, oculte, defina fundos e tamanho, aplique transições e exporte para PowerPoint e OpenDocument."
---
Este artigo fornece uma série de exemplos que demonstram como trabalhar com slides usando **Aspose.Slides for PHP via Java**. Você aprenderá como adicionar, acessar, clonar, reordenar e remover slides usando a classe `Presentation`.

Cada exemplo abaixo inclui uma breve explicação seguida por um trecho de código em PHP.

## **Adicionar um Slide**

Para adicionar um novo slide, você deve primeiro selecionar um layout. Neste exemplo, usamos o layout `Blank` e adicionamos um slide vazio à apresentação.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Cada slide é baseado em um layout, que por sua vez é baseado em um slide mestre.
        // Use o layout Blank para criar um novo slide.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Adicione um novo slide vazio usando o layout selecionado.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Dica:** Cada layout de slide é derivado de um slide mestre, que define o design geral e a estrutura de espaços reservados. A imagem abaixo ilustra como os slides mestres e seus layouts associados são organizados no PowerPoint.

![Relacionamento entre Mestre e Layout](master-layout-slide.png)

## **Acessar Slides por Índice**

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Acesse um slide por índice.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Clonar um Slide**

Este exemplo demonstra como clonar um slide existente. O slide clonado é adicionado automaticamente ao final da coleção de slides.

```php
function cloneSlide() {
    // Por padrão, a apresentação contém um slide vazio.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Clone o primeiro slide; ele será adicionado ao final da apresentação.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // O índice do slide clonado é 1 (segundo slide na apresentação).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Reordenar Slides**

Você pode mudar a ordem dos slides movendo um para um novo índice. Neste caso, movemos um slide para a primeira posição.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Mover o slide para a primeira posição (os demais são deslocados para baixo).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover um Slide**

Para remover um slide, basta referenciá‑lo e chamar `remove`. Este exemplo remove slides por índice e por referência.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Remova um slide por índice.
        $presentation->getSlides()->removeAt(0);

        // Remova um slide por referência.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```