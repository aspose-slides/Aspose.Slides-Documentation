---
title: Gérer les portions de texte dans les présentations avec PHP
linktitle: Portion de texte
type: docs
weight: 70
url: /fr/php-java/portion/
keywords:
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à gérer les portions de texte dans les présentations PowerPoint en utilisant Aspose.Slides pour PHP via Java, améliorant les performances et la personnalisation."
---

## **Obtenir les coordonnées d'une portion de texte**
La méthode [**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/portion/getcoordinates/) a été ajoutée à la classe [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) qui permet de récupérer les coordonnées du début de la portion.
```php
  # Instancier la classe Prseetation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Remodeler le contexte de la présentation
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis-je appliquer un hyperlien uniquement à une partie du texte dans un même paragraphe ?**

Oui, vous pouvez [assigner un hyperlien](/slides/fr/php-java/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l’héritage de style : qu’est‑ce qu’une Portion remplace, et qu’est‑ce qui provient de Paragraph/TextFrame ?**

Les propriétés au niveau de la Portion ont la priorité la plus élevée. Si une propriété n’est pas définie sur la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/), le moteur la récupère du [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) ; si elle n’est pas définie non plus là, du [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) ou du [theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/) style.

**Que se passe-t-il si la police spécifiée pour une Portion est absente sur la machine/serveur cible ?**

Les [règles de substitution de police](/slides/fr/php-java/font-selection-sequence/) s’appliquent. Le texte peut se reflower : les métriques, la césure et la largeur peuvent changer, ce qui importe pour un positionnement précis.

**Puis-je définir une transparence ou un dégradé de remplissage de texte spécifique à une Portion, indépendant du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) peuvent différer des fragments voisins.