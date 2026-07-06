---
title: Obtenir les limites de la portion de texte à partir des présentations en PHP
linktitle: Limites de la portion
type: docs
weight: 47
url: /fr/php-java/portion-bounds/
keywords:
- limites de portion de texte
- portion de texte
- partie de texte
- coordonnées de texte
- position du texte
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez comment récupérer les limites des portions de texte dans les présentations PowerPoint en utilisant Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Une portion de texte représente un fragment spécifique de texte à l’intérieur d’un paragraphe et vous permet de travailler avec ce fragment de manière indépendante du contenu environnant. Dans Aspose.Slides, les portions peuvent être utilisées lorsque vous devez récupérer les limites d’un fragment de texte, appliquer un formatage à seule partie d’un paragraphe ou contrôler le comportement du texte à un niveau plus détaillé.

Cet article montre comment obtenir le rectangle englobant d’une portion en utilisant [Portion::getRect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/getrect/). Il montre également comment obtenir les coordonnées du début d’une portion en utilisant [Portion::getCoordinates](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/getcoordinates/). De plus, il met en évidence des scénarios courants liés aux portions, tels que l’application d’un hyperlien à un fragment de texte unique, la compréhension de la résolution du formatage à travers la portion, le paragraphe, le cadre de texte et l’héritage du thème, ainsi que la gestion des cas où une police spécifiée est indisponible.

## **Obtenir les limites d’une portion de texte**

Utilisez [Portion::getRect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/getrect/) pour récupérer le rectangle englobant d’une portion de texte :

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Obtenir les coordonnées d’une portion de texte**

Utilisez [Portion::getCoordinates](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/getcoordinates/) pour récupérer les coordonnées du début d’une portion de texte :

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Puis-je appliquer un hyperlien uniquement à une partie du texte au sein d’un même paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/php-java/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l’héritage des styles : qu’est‑ce qu’une portion surcharge, et qu’est‑ce qui est hérité d’un paragraphe ou d’un cadre de texte ?**

Les propriétés au niveau de la [Portion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/) ont la priorité la plus élevée. Si une propriété n’est pas définie sur la [Portion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/), Aspose.Slides la récupère depuis le [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/). Si elle n’est pas non plus définie là, Aspose.Slides utilise le style du [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) ou du [theme](https://reference.aspose.com/slides/fr/php-java/aspose.slides/theme/).

**Que se passe‑t‑il si la police spécifiée pour une portion est absente sur la machine ou le serveur cible ?**

Les [règles de substitution de police](/slides/fr/php-java/font-selection-sequence/) s’appliquent. Le texte peut se réorganiser : les métriques, la césure et la largeur peuvent changer, ce qui est important pour un positionnement précis.

**Puis‑je définir la transparence ou un dégradé de remplissage de texte propre à une portion indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/) peuvent différer des fragments voisins.