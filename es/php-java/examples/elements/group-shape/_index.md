---
title: GroupShape
type: docs
weight: 170
url: /es/php-java/examples/elements/group-shape/
keywords:
- grupo
- agregar forma de grupo
- acceder a forma de grupo
- eliminar forma de grupo
- desagrupar formas
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Trabaja con formas de grupo en PHP usando Aspose.Slides: crea y desagrupa, reordena formas hijas, establece transformaciones y límites en PowerPoint y OpenDocument."
---
Ejemplos de creación de grupos de formas, acceso a los mismos, desagrupación y eliminación usando **Aspose.Slides for PHP via Java**.

## **Agregar una forma de grupo**

Crea un grupo que contiene dos formas básicas.

```php
function addGroupShape() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $group = $slide->getShapes()->addGroupShape();
        $group->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $group->getShapes()->addAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

        $presentation->save("group_shape.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acceder a una forma de grupo**

Obtén la primera forma de grupo de una diapositiva.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accede a la primera forma de grupo en la diapositiva.
        $firstGroup = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $firstGroup = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar una forma de grupo**

Elimina una forma de grupo de la diapositiva.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Suponiendo que la primera forma en la diapositiva es una forma de grupo.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Desagrupar formas**

Mueve las formas fuera de un contenedor de grupo.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma en la diapositiva es una forma de grupo.
        $group = $slide->getShapes()->get_Item(0);

        // Clona cada forma del grupo y la agrega a la diapositiva.
        $shapeCount = java_values($group->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $group->getShapes()->get_Item($index);
            $slide->getShapes()->addClone($shape);
        }

        $slide->getShapes()->remove($group);

        $presentation->save("ungrouped_shapes.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```