---
title: Seção
type: docs
weight: 90
url: /pt/php-java/examples/elements/section/
keywords:
- seção
- seção de slide
- adicionar seção
- acessar seção
- remover seção
- renomear seção
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie seções de slides em PHP com Aspose.Slides: crie, renomeie, reordene facilmente, mova slides entre seções e controle a visibilidade para PPT, PPTX e ODP."
---
Exemplos de gerenciamento de seções de apresentação — adicionar, acessar, remover e renomear programaticamente usando **Aspose.Slides for PHP via Java**.

## **Adicionar uma Seção**

Crie uma seção que começa em um slide específico.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Especifique o slide que marca o início da seção.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acessar uma Seção**

Leia as informações da seção a partir de uma apresentação.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Acesse uma seção por índice.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover uma Seção**

Exclua uma seção previamente adicionada.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Remova a seção.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Renomear uma Seção**

Altere o nome de uma seção existente.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```