---
title: SmartArt
type: docs
weight: 140
url: /es/php-java/examples/elements/smartart/
keywords:
- SmartArt
- añadir SmartArt
- acceder a SmartArt
- eliminar SmartArt
- diseño de SmartArt
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Crea y edita SmartArt en PHP con Aspose.Slides: añade nodos, cambia diseños y estilos, conviértelo en formas con precisión y exporta a PPT, PPTX y ODP."
---
Muestra cómo agregar gráficos SmartArt, acceder a ellos, eliminarlos y cambiar los diseños usando **Aspose.Slides for PHP via Java**.

## **Agregar SmartArt**

Inserta un gráfico SmartArt utilizando uno de los diseños integrados.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acceder a SmartArt**

Obtén el primer objeto SmartArt de una diapositiva.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acceder al primer SmartArt en la diapositiva.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar SmartArt**

Elimina una forma SmartArt de la diapositiva.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma en la diapositiva es un SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Cambiar el diseño de SmartArt**

Actualiza el tipo de diseño de un gráfico SmartArt existente.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma en la diapositiva es un SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Cambiar el diseño del SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```