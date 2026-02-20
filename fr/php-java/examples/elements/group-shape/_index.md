---
title: Forme de groupe
type: docs
weight: 170
url: /fr/php-java/examples/elements/group-shape/
keywords:
- groupe
- ajouter forme de groupe
- accéder forme de groupe
- supprimer forme de groupe
- dégrouper formes
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Travaillez avec les formes de groupe en PHP à l'aide d'Aspose.Slides : créez et désassemblez, réordonnez les formes enfant, définissez les transformations et les limites dans PowerPoint et OpenDocument."
---
Exemples de création de groupes de formes, d'accès à ceux-ci, de désassemblage et de suppression en utilisant **Aspose.Slides for PHP via Java**.

## **Ajouter une forme de groupe**

Créer un groupe contenant deux formes de base.

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

## **Accéder à une forme de groupe**

Récupérer la première forme de groupe depuis une diapositive.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accéder à la première forme de groupe sur la diapositive.
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

## **Supprimer une forme de groupe**

Supprimer une forme de groupe de la diapositive.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // En supposant que la première forme sur la diapositive est une forme de groupe.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Dégrouper les formes**

Déplacer les formes hors du conteneur du groupe.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que la première forme sur la diapositive est une forme de groupe.
        $group = $slide->getShapes()->get_Item(0);

        // Cloner chaque forme du groupe et l'ajouter à la diapositive.
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