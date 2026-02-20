---
title: Sección
type: docs
weight: 90
url: /es/php-java/examples/elements/section/
keywords:
- sección
- sección de diapositiva
- añadir sección
- acceder a la sección
- eliminar sección
- renombrar sección
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Administre secciones de diapositivas en PHP con Aspose.Slides: cree, renombre, reorganice fácilmente, mueva diapositivas entre secciones y controle la visibilidad para PPT, PPTX y ODP."
---
Ejemplos para gestionar secciones de presentación—añadir, acceder, eliminar y renombrar programáticamente usando **Aspose.Slides for PHP via Java**.

## **Agregar una sección**

Cree una sección que empiece en una diapositiva específica.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Especifique la diapositiva que marca el comienzo de la sección.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acceder a una sección**

Lea la información de la sección de una presentación.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Acceda a una sección por índice.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar una sección**

Elimine una sección previamente añadida.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Elimine la sección.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Renombrar una sección**

Cambie el nombre de una sección existente.

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