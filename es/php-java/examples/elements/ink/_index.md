---
title: Tinta
type: docs
weight: 180
url: /es/php-java/examples/elements/ink/
keywords:
- tinta
- acceder a la tinta
- eliminar tinta
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Gestiona tinta digital en diapositivas en PHP con Aspose.Slides: agrega trazos de lápiz, edita rutas, establece color y ancho, y exporta los resultados para PowerPoint y OpenDocument."
---
Proporciona ejemplos de acceso a formas de tinta existentes y de su eliminación usando **Aspose.Slides for PHP via Java**.

> ❗ **Nota:** Las formas de tinta representan la entrada del usuario desde dispositivos especializados. Aspose.Slides no puede crear nuevos trazos de tinta de forma programática, pero puedes leer y modificar la tinta existente.

## **Acceder a la tinta**

Obtén la primera forma de tinta en una diapositiva.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accede a la primera forma de tinta en la diapositiva.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar tinta**

Elimina una forma de tinta de la diapositiva.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma en la diapositiva es una forma de tinta.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```