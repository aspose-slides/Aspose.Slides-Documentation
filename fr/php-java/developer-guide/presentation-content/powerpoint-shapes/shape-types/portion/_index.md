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
description: "Apprenez à gérer les portions de texte dans les présentations PowerPoint à l'aide d'Aspose.Slides pour PHP via Java, en améliorant les performances et la personnalisation."
---

## **Obtenir les coordonnées d'une portion de texte**
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) a été ajoutée aux classes [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) et [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) qui permet de récupérer les coordonnées du début de la portion.
```php
  # Instanciez la classe Presentation qui représente le PPTX
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

**Puis-je appliquer un hyperlien uniquement à une partie du texte au sein d'un même paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/php-java/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l'héritage des styles : qu’est‑ce qu’une Portion surcharge, et qu’est‑ce qui est repris du Paragraph/TextFrame ?**

Les propriétés au niveau de la Portion ont la priorité la plus élevée. Si une propriété n’est pas définie sur la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/), le moteur la récupère du [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/); si elle n’est pas définie non plus là, il la prend du [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) ou du style du [theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/).

**Que se passe‑t‑il si la police spécifiée pour une Portion est absente sur la machine/serveur cible ?**

Les [règles de substitution de police](/slides/fr/php-java/font-selection-sequence/) s’appliquent. Le texte peut se réarranger : les métriques, la césure et la largeur peuvent changer, ce qui importe pour le positionnement précis.

**Puis‑je définir une transparence ou un dégradé de remplissage de texte spécifique à une Portion, indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) peuvent différer des fragments voisins.