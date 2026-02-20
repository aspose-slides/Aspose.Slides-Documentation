---
title: Diapositiva
type: docs
weight: 10
url: /es/php-java/examples/elements/slide/
keywords:
- diapositiva
- añadir diapositiva
- acceder diapositiva
- índice de diapositiva
- clonar diapositiva
- reordenar diapositivas
- eliminar diapositiva
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Gestiona diapositivas en PHP con Aspose.Slides: crea, clona, reordena, oculta, establece fondos y tamaño, aplica transiciones y exporta a PowerPoint y OpenDocument."
---
Este artículo ofrece una serie de ejemplos que demuestran cómo trabajar con diapositivas utilizando **Aspose.Slides for PHP via Java**. Aprenderá a añadir, acceder, clonar, reordenar y eliminar diapositivas mediante la clase `Presentation`.

Cada ejemplo a continuación incluye una breve explicación seguida de un fragmento de código en PHP.

## **Añadir una diapositiva**

Para añadir una nueva diapositiva, primero debe seleccionar una disposición. En este ejemplo, utilizamos la disposición `Blank` y añadimos una diapositiva vacía a la presentación.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Cada diapositiva se basa en una disposición, que a su vez se basa en una diapositiva maestra.
        // Utilice la disposición Blank para crear una nueva diapositiva.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Añada una nueva diapositiva vacía usando la disposición seleccionada.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Consejo:** Cada disposición de diapositiva se deriva de una diapositiva maestra, que define el diseño general y la estructura de los marcadores de posición. La imagen a continuación ilustra cómo se organizan las diapositivas maestras y sus disposiciones asociadas en PowerPoint.

![Relación entre la diapositiva maestra y la disposición](master-layout-slide.png)

## **Acceder a diapositivas por índice**

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Acceda a una diapositiva por índice.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Clonar una diapositiva**

```php
function cloneSlide() {
    // Por defecto, la presentación contiene una diapositiva vacía.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Clona la primera diapositiva; se añadirá al final de la presentación.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // El índice de la diapositiva clonada es 1 (segunda diapositiva en la presentación).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Reordenar diapositivas**

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Mueve la diapositiva a la primera posición (las demás se desplazan hacia abajo).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar una diapositiva**

Para eliminar una diapositiva, simplemente haga referencia a ella y llame a `remove`. Este ejemplo elimina diapositivas por índice y por referencia.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Eliminar una diapositiva por índice.
        $presentation->getSlides()->removeAt(0);

        // Eliminar una diapositiva por referencia.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```