---
title: Redimensionner les formes sur les diapositives de présentation en PHP
type: docs
weight: 130
url: /fr/php-java/resizing-shapes-on-slide/
aliases:
  - /fr/php-java/re-sizing-shapes-on-slide/
keywords:
- redimensionner forme
- modifier la taille de la forme
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java — automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---
## **Aperçu**

Lorsque vous modifiez la taille des diapositives d'une présentation, il peut également être nécessaire de redimensionner et de repositionner ses formes pour les adapter aux nouvelles dimensions. Cet article montre comment mettre à l'échelle les formes manuellement et comment gérer les tableaux sur les diapositives, les maîtres et les mises en page.

## **Redimensionner les formes**

Pour conserver la position et la taille relatives de chaque forme, multipliez ses coordonnées horizontales et sa largeur par le rapport de la nouvelle largeur de diapositive à la largeur d'origine. Appliquez le rapport de hauteur correspondant à ses coordonnées verticales et à sa hauteur.

Le premier exemple charge une présentation dont les diapositives ne contiennent aucun tableau, change la taille des diapositives en A4 et enregistre le résultat. Il utilise [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) avec [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) afin que la boucle suivante contrôle le redimensionnement. Les rapports sont sans unité ; les positions et dimensions des formes sont mesurées en points. Des rapports de largeur et de hauteur différents peuvent déformer les formes, et modifier les dimensions d'une forme ne met pas à l'échelle la taille de ses polices.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Remarque" %}}
Les tableaux nécessitent un traitement séparé : mettre à l'échelle leurs largeurs de colonne et hauteurs de ligne au lieu d'assigner la largeur et la hauteur globales du tableau. Les hauteurs de ligne peuvent rester supérieures à la valeur demandée si le contenu des cellules nécessite plus d'espace.
{{% /alert %}}

Le deuxième exemple prend en charge les tableaux et traite les formes sur les maîtres et les mises en page ainsi que les diapositives individuelles avant d'enregistrer la présentation redimensionnée. Son assistant gère chaque [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) en mettant à l'échelle les largeurs de colonne avec [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) et les hauteurs minimales de ligne avec [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Il met ensuite à l'échelle la position du tableau sans mettre séparément à l'échelle ses dimensions globales.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // Les dimensions du tableau sont contrôlées par les largeurs des colonnes et les hauteurs des lignes.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Redimensionner les formes définies sur les maîtres et les mises en page ainsi que sur les diapositives individuelles.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **FAQ**

**Pourquoi les formes sont-elles déformées ou coupées après le redimensionnement d'une diapositive ?**

Si vous modifiez la taille de la diapositive sans mettre à l'échelle les formes, elles conservent leurs positions et dimensions d'origine et peuvent dépasser de la diapositive. Mettre à l'échelle la largeur et la hauteur avec des rapports différents peut également déformer les formes.

**Le code fourni fonctionne-t-il pour tous les types de formes ?**

Le premier exemple modifie directement les limites des formes et est prévu pour les diapositives sans tableaux. Le deuxième exemple traite les tableaux séparément. Vérifiez la mise en page résultante, en particulier le texte et les tableaux, car ces exemples ne mettent pas à l'échelle la taille des polices et le contenu des tableaux peut contraindre les hauteurs de ligne.

**Comment redimensionner les tableaux lors du redimensionnement d'une diapositive ?**

Mettez à l'échelle les largeurs de colonne selon le rapport de largeur et les hauteurs minimales de ligne selon le rapport de hauteur, puis mettez à l'échelle la position du tableau, comme indiqué dans le deuxième exemple.

**Ce redimensionnement fonctionnera-t-il pour les diapositives maîtres et les diapositives de mise en page ?**

Oui. Le deuxième exemple parcourt [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) et les [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) de chaque maître, et applique la même logique de redimensionnement à leurs formes.

**Puis-je changer l'orientation d'une diapositive (portrait/paysage) lors du redimensionnement ?**

Oui. Appelez [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) après avoir modifié la taille de la diapositive et avant de lire les dimensions cibles, afin que les facteurs d'échelle reflètent l'orientation finale.

**Existe-t-il une limite à la taille de diapositive que je peux définir ?**

Vous pouvez spécifier des dimensions de diapositive personnalisées avec [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). Les dimensions prises en charge dépendent également du format de la présentation et de l'application utilisée pour ouvrir le fichier.

**Comment empêcher les formes à ratio d'aspect fixe de se déformer ?**

Utilisez le même facteur d'échelle pour la largeur et la hauteur. Pour adapter la mise en page originale aux nouvelles dimensions de la diapositive, utilisez le plus petit des rapports de largeur et de hauteur pour les deux dimensions et positions. Cela préserve les proportions mais peut laisser un espace inutilisé le long d'un bord.