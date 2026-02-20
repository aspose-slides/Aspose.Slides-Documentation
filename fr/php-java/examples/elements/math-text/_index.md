---
title: TexteMathématique
type: docs
weight: 160
url: /fr/php-java/examples/elements/math-text/
keywords:
- texte mathématique
- ajouter texte mathématique
- accéder texte mathématique
- supprimer texte mathématique
- formater texte mathématique
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Travailler avec le texte mathématique en PHP à l'aide d'Aspose.Slides: créer et modifier des équations, des fractions, des radicaux, des scripts, le formatage, et rendre les résultats pour PPT et PPTX."
---
Illustre la manipulation de formes de texte mathématique et le formatage d'équations à l'aide de **Aspose.Slides for PHP via Java**.

## **Ajouter du texte mathématique**

Créez une forme mathématique contenant une fraction et la formule de Pythagore.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Ajouter une forme Math à la diapositive.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // Accéder au paragraphe mathématique.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // Ajouter une fraction simple : x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // Ajouter une équation : c² = a² + b².
        $mathBlock = (new MathematicalText("c"))
            - >setSuperscript("2")
            - >join("=")
            - >join((new MathematicalText("a"))->setSuperscript("2"))
            - >join("+")
            - >join((new MathematicalText("b"))->setSuperscript("2"));
        $mathParagraph->add($mathBlock);

        $presentation->save("math_text.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder au texte mathématique**

Localisez une forme qui contient un paragraphe mathématique sur la diapositive.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Trouver la première forme qui contient un paragraphe mathématique.
        $mathShape = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $textFrame = $shape->getTextFrame();
                if ($textFrame !== null) {
                    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
                    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                        $portionCount = java_values($paragraph->getPortions()->getCount());
                        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                            $portion = $paragraph->getPortions()->get_Item($portionIndex);
                            if (java_instanceof($portion, new JavaClass("com.aspose.slides.MathPortion"))) {
                                $mathShape = $shape;
                                break 3;
                            }
                        }
                    }
                }
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Supprimer le texte mathématique**

Supprimez une forme mathématique de la diapositive.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supposer que la première forme sur la diapositive est une forme Math.
        $mathShape = $slide->getShapes()->get_Item(0);

        // Supprimer la forme Math de la diapositive.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Formater le texte mathématique**

Définissez les propriétés de police pour une portion mathématique.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supposer que la première forme sur la diapositive est une forme Math.
        $mathShape = $slide->getShapes()->get_Item(0);

        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(20);

        $presentation->save("math_text_formatted.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```