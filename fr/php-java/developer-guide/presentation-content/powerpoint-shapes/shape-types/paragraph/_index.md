---
title: Obtenir les limites du paragraphe dans les présentations en PHP
linktitle: Paragraphe
type: docs
weight: 60
url: /fr/php-java/paragraph/
keywords:
- limites du paragraphe
- limites de la portion de texte
- coordonnée du paragraphe
- coordonnée de la portion
- taille du paragraphe
- taille de la portion de texte
- cadre de texte
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à récupérer les limites du paragraphe et de la portion de texte dans Aspose.Slides pour PHP via Java afin d'optimiser le positionnement du texte dans les présentations PowerPoint."
---

## **Obtenir les coordonnées du paragraphe et de la portion dans un TextFrame**
En utilisant Aspose.Slides pour PHP via Java, les développeurs peuvent désormais obtenir les coordonnées rectangulaires d’un Paragraph à l’intérieur de la collection de paragraphes d’un TextFrame. Cela permet également d’obtenir [les coordonnées de la portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) à l’intérieur de la collection de portions d’un paragraphe. Dans ce sujet, nous allons montrer, à l’aide d’un exemple, comment obtenir les coordonnées rectangulaires du paragraphe ainsi que la position de la portion à l’intérieur du paragraphe.
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **Obtenir les coordonnées rectangulaires d’un paragraphe**
En utilisant la méthode [**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--) les développeurs peuvent obtenir le rectangle englobant du paragraphe.
```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtenir la taille d’un paragraphe et d’une portion à l’intérieur d’un TextFrame de cellule de tableau**
Pour obtenir la taille et les coordonnées d’une [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) ou d’un [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) dans un TextFrame de cellule de tableau, vous pouvez utiliser les méthodes [IPortion.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getRect--) et [IParagraph.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--).
Ce code d’exemple illustre l’opération décrite :
```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Dans quelles unités les coordonnées retournées pour un paragraphe et les portions de texte sont‑elles mesurées ?**  
En points, où 1 pouce = 72 points. Cela s’applique à toutes les coordonnées et dimensions sur la diapositive.

**L’ajustement du texte affecte‑t‑il les limites d’un paragraphe ?**  
Oui. Si le [wrapping](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/) est activé dans le [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), le texte se répartit pour s’ajuster à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent‑elles être converties de façon fiable en pixels dans l’image exportée ?**  
Oui. Convertissez les points en pixels en utilisant : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu/l’exportation.

**Comment obtenir les paramètres de mise en forme « effectifs » du paragraphe, en tenant compte de l’héritage de style ?**  
Utilisez la [structure de données de mise en forme effective du paragraphe](/slides/fr/php-java/shape-effective-properties/) ; elle renvoie les valeurs consolidées finales pour les retraits, l’espacement, le wrapping, RTL, etc.