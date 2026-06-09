---
title: Forma de Grupo
type: docs
weight: 170
url: /pt/php-java/examples/elements/group-shape/
keywords:
- grupo
- adicionar forma de grupo
- acessar forma de grupo
- remover forma de grupo
- desagrupar formas
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Trabalhe com formas de grupo em PHP usando Aspose.Slides: crie e desagrupe, reorganize formas filhas, defina transformações e limites em PowerPoint e OpenDocument."
---
Exemplos de criação de grupos de formas, acesso a eles, desagrupamento e remoção usando **Aspose.Slides for PHP via Java**.

## **Adicionar um Grupo de Formas**

Crie um grupo contendo duas formas básicas.

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

## **Acessar um Grupo de Formas**

Recupere a primeira forma de grupo de um slide.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acesse a primeira forma de grupo no slide.
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

## **Remover um Grupo de Formas**

Exclua uma forma de grupo do slide.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Assumindo que a primeira forma no slide é uma forma de grupo.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Desagrupar Formas**

Mova as formas para fora de um contêiner de grupo.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma no slide é uma forma de grupo.
        $group = $slide->getShapes()->get_Item(0);

        // Clone cada forma do grupo e adicione-a ao slide.
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