---
title: Zone de texte
type: docs
weight: 40
url: /fr/php-java/examples/elements/text-box/
keywords:
- zone de texte
- ajouter zone de texte
- accéder à la zone de texte
- supprimer zone de texte
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Créer et formater des zones de texte en PHP avec Aspose.Slides : définir les polices, l'alignement, le renvoi à la ligne, l'ajustement automatique et les liens pour peaufiner les diapositives pour PowerPoint et OpenDocument."
---
Dans Aspose.Slides, une **zone de texte** est représentée par un `AutoShape`. Pratiquement n'importe quelle forme peut contenir du texte, mais une zone de texte typique n'a ni remplissage ni bordure et n'affiche que du texte.

Ce guide explique comment ajouter, accéder et supprimer des zones de texte par programmation.

## **Ajouter une zone de texte**

Une zone de texte est simplement un `AutoShape` sans remplissage ni bordure et contenant du texte formaté. Voici comment en créer une :

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Créer une forme rectangulaire (par défaut remplie avec bordure et sans texte).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Supprimer le remplissage et la bordure pour qu'elle ressemble à une zone de texte typique.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Définir le formatage du texte.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Assigner le contenu texte réel.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Note :** Tout `AutoShape` qui contient un `TextFrame` non vide peut fonctionner comme une zone de texte.

## **Accéder aux zones de texte par contenu**

Pour trouver toutes les zones de texte contenant un mot‑clé spécifique (par ex. "Slide"), parcourez les formes et vérifiez leur texte :

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accéder à la première zone de texte sur la diapositive.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Faire quelque chose avec la zone de texte correspondante.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer les zones de texte par contenu**

Cet exemple trouve et supprime toutes les zones de texte de la première diapositive qui contiennent un mot‑clé spécifique :

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

> 💡 **Conseil :** Créez toujours une copie de la collection de formes avant de la modifier pendant l'itération afin d'éviter les erreurs de modification de la collection.