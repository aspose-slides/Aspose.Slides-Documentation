---
title: "Transición de diapositiva"
type: docs
weight: 110
url: /es/php-java/examples/elements/slide-transition/
keywords:
- transición de diapositiva
- añadir transición de diapositiva
- acceder a transición de diapositiva
- eliminar transición de diapositiva
- duración de la transición
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Controla las transiciones de diapositivas en PHP con Aspose.Slides: elige tipos, velocidad, sonido y temporización para perfeccionar presentaciones en PPT, PPTX y ODP."
---
Demuestra cómo aplicar efectos de transición de diapositivas y temporizaciones con **Aspose.Slides for PHP via Java**.

## **Agregar una transición de diapositiva**

Aplica un efecto de transición de desvanecimiento a la primera diapositiva.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aplicar una transición de desvanecimiento.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acceder a una transición de diapositiva**

Lee el tipo de transición asignado a una diapositiva.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acceder al tipo de transición.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar una transición de diapositiva**

Elimina cualquier efecto de transición estableciendo el tipo a `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Eliminar la transición estableciendo none.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Establecer la duración de la transición**

Especifica cuánto tiempo se muestra la diapositiva antes de avanzar automáticamente.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // en milisegundos.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```