---
title: Encre
type: docs
weight: 180
url: /fr/php-java/examples/elements/ink/
keywords:
- encre
- accéder à l'encre
- supprimer l'encre
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Manipulez l'encre numérique sur les diapositives en PHP avec Aspose.Slides : ajoutez des traits de stylo, modifiez les tracés, définissez la couleur et la largeur, et exportez les résultats pour PowerPoint et OpenDocument."
---
Fournit des exemples d'accès aux formes d'encre existantes et de leur suppression à l'aide d'**Aspose.Slides for PHP via Java**.

> ❗ **Note :** Les formes d'encre représentent les entrées utilisateur provenant d'appareils spécialisés. Aspose.Slides ne peut pas créer de nouveaux traits d'encre programmatiquement, mais vous pouvez lire et modifier les encres existantes.

## **Accéder à l'encre**

Obtenez la première forme d'encre d'une diapositive.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accéder à la première forme d'encre sur la diapositive.
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

## **Supprimer l'encre**

Supprimez une forme d'encre de la diapositive.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que la première forme de la diapositive est une forme d'encre.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```