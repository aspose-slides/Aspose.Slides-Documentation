---
title: Cuadro de texto
type: docs
weight: 40
url: /es/php-java/examples/elements/text-box/
keywords:
- cuadro de texto
- añadir cuadro de texto
- acceder al cuadro de texto
- eliminar cuadro de texto
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Cree y formatee cuadros de texto en PHP con Aspose.Slides: establezca fuentes, alineación, ajuste de texto, autofit y enlaces para perfeccionar diapositivas para PowerPoint y OpenDocument."
---
En Aspose.Slides, un **cuadro de texto** está representado por un `AutoShape`. Casi cualquier forma puede contener texto, pero un cuadro de texto típico no tiene relleno ni borde y solo muestra texto.

Esta guía explica cómo agregar, acceder y eliminar cuadros de texto mediante código.

## **Agregar un cuadro de texto**

Un cuadro de texto es simplemente un `AutoShape` sin relleno ni borde y con algún texto con formato. He aquí cómo crear uno:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Crear una forma rectangular (por defecto con relleno y borde y sin texto).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Eliminar relleno y borde para que parezca un cuadro de texto típico.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Establecer el formato del texto.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Asignar el contenido de texto real.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Nota:** Cualquier `AutoShape` que contenga un `TextFrame` no vacío puede funcionar como un cuadro de texto.

## **Acceder a los cuadros de texto por contenido**

Para encontrar todos los cuadros de texto que contengan una palabra clave específica (p. ej., "Slide"), recorre las formas y verifica su texto:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acceder al primer cuadro de texto en la diapositiva.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Realizar alguna acción con el cuadro de texto coincidente.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar los cuadros de texto por contenido**

Este ejemplo encuentra y elimina todos los cuadros de texto en la primera diapositiva que contengan una palabra clave específica:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Consejo:** Siempre crea una copia de la colección de formas antes de modificarla durante la iteración para evitar errores de modificación de la colección.