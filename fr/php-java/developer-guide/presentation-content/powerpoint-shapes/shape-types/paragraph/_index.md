---
title: Paragraphe
type: docs
weight: 60
url: /fr/php-java/paragraph/
---


## Obtenir les coordonnées de paragraphe et de portion dans TextFrame ##
En utilisant Aspose.Slides pour PHP via Java, les développeurs peuvent désormais obtenir les coordonnées rectangulaires pour les Paragraphes à l'intérieur de la collection de paragraphes de TextFrame. Cela permet également d'obtenir [les coordonnées de portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) dans la collection de portions d'un paragraphe. Dans ce sujet, nous allons démontrer à l'aide d'un exemple comment obtenir les coordonnées rectangulaires d'un paragraphe ainsi que la position de la portion à l'intérieur d'un paragraphe.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **Obtenir les coordonnées rectangulaires du paragraphe**
En utilisant la méthode [**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--), les développeurs peuvent obtenir le rectangle des limites du paragraphe.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Largeur: " . $rect->$width . " Hauteur: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtenir la taille d'un paragraphe et d'une portion dans le cadre de texte d'une cellule de tableau** ##

Pour obtenir la taille et les coordonnées de la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) ou du [Paragraphe](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) dans le cadre de texte d'une cellule de tableau, vous pouvez utiliser les méthodes [IPortion.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getRect--) et [IParagraph.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--).

Ce code d'exemple démontre l'opération décrite :

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