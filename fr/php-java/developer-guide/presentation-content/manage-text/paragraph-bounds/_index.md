---
title: Obtenir les limites des paragraphes des présentations en PHP
linktitle: Limites du paragraphe
type: docs
weight: 43
url: /fr/php-java/paragraph-bounds/
keywords:
- limites du paragraphe
- coordonnée du paragraphe
- taille du paragraphe
- cadre de texte
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à récupérer les limites des paragraphes dans Aspose.Slides pour PHP via Java afin d'optimiser le positionnement du texte dans les présentations PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment obtenir les limites, la taille et les coordonnées des paragraphes dans Aspose.Slides. Il montre comment récupérer le rectangle d'un paragraphe à partir d'un [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) en utilisant [Paragraph::getRect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/getrect/), comment obtenir les coordonnées du paragraphe dans le texte d'une cellule de tableau, et met en évidence des détails importants tels que les unités de mesure, l'effet du retour à la ligne sur les limites, la conversion en pixels et les valeurs de formatage effectif du paragraphe.

## **Obtenir les coordonnées rectangulaires d'un paragraphe**

Utilisez [Paragraph::getRect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/getrect/) pour obtenir le rectangle englobant d'un paragraphe.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **Obtenir la taille d'un paragraphe dans un TextFrame de cellule de tableau**

Pour obtenir la taille et les coordonnées d'un [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/) dans le texte d'une cellule de tableau, utilisez [Paragraph::getRect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/getrect/). Le rectangle retourné est relatif au TextFrame de la cellule du tableau, il faut donc ajouter la position du tableau et le décalage de la cellule lorsque vous avez besoin de coordonnées au niveau de la diapositive.

L'exemple suivant récupère les limites du paragraphe à l'intérieur d'une cellule de tableau et dessine des rectangles sur la diapositive pour visualiser ces limites :

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Dans quelles unités les coordonnées du paragraphe sont‑elles mesurées ?**

Ils sont mesurés en points, où 1 pouce équivaut à 72 points. Cela s'applique à toutes les coordonnées et dimensions de la diapositive.

**Le retour à la ligne affecte‑t‑il les limites d'un paragraphe ?**

Oui. Si [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/setwraptext/) est activé pour le [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/), le texte se coupe pour s'adapter à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent‑elles être converties de manière fiable en pixels dans l'image exportée ?**

Oui. Convertissez les points en pixels avec la formule suivante : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu ou l'exportation.

**Comment obtenir les paramètres de formatage « effectif » du paragraphe, en tenant compte de l'héritage des styles ?**

Utilisez la [effective paragraph formatting data structure](/slides/fr/php-java/shape-effective-properties/); elle renvoie les valeurs consolidées finales pour les retraits, l'espacement, le renvoi à la ligne, le texte de droite à gauche et plus encore.