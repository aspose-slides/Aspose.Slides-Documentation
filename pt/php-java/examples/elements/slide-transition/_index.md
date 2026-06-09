---
title: Transição de Slide
type: docs
weight: 110
url: /pt/php-java/examples/elements/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- acessar transição de slide
- remover transição de slide
- duração da transição
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Controle as transições de slide em PHP com Aspose.Slides: escolha tipos, velocidade, som e tempo para aprimorar apresentações em PPT, PPTX e ODP."
---
Demonstrar a aplicação de efeitos de transição de slides e tempos com **Aspose.Slides for PHP via Java**.

## **Adicionar uma Transição de Slide**
Aplicar um efeito de transição de fade ao primeiro slide.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aplicar uma transição de fade.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acessar uma Transição de Slide**
Ler o tipo de transição atribuído a um slide.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acessar o tipo de transição.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover uma Transição de Slide**
Remover qualquer efeito de transição definindo o tipo como `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Remover a transição definindo como nenhum.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Definir a Duração da Transição**
Especificar por quanto tempo o slide é exibido antes de avançar automaticamente.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // em milissegundos.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```