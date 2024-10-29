---
title: Forme Personnalisée
type: docs
weight: 20
url: /fr/php-java/custom-shape/
keywords: "forme PowerPoint, forme personnalisée, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Ajouter une forme personnalisée dans une présentation PowerPoint"
---

# Modifier une Forme en Utilisant des Points d'Édition
Considérez un carré. Dans PowerPoint, en utilisant **des points d'édition**, vous pouvez 

* déplacer le coin du carré vers l'intérieur ou vers l'extérieur
* spécifier la courbure d'un coin ou d'un point
* ajouter de nouveaux points au carré
* manipuler des points sur le carré, etc.

Essentiellement, vous pouvez effectuer les tâches décrites sur n'importe quelle forme. En utilisant des points d'édition, vous pouvez modifier une forme ou créer une nouvelle forme à partir d'une forme existante.

## **Conseils pour l'Édition des Formes**

![overview_image](custom_shape_0.png)

Avant de commencer à modifier les formes PowerPoint par le biais des points d'édition, vous voudrez peut-être prendre en considération ces points concernant les formes :

* Une forme (ou son chemin) peut être soit fermée soit ouverte.
* Lorsqu'une forme est fermée, elle n'a pas de point de départ ou d'arrivée. Lorsqu'une forme est ouverte, elle a un début et une fin.
* Toutes les formes se composent d'au moins 2 points d'ancrage liés entre eux par des lignes.
* Une ligne est soit droite soit courbée. Les points d'ancrage déterminent la nature de la ligne.
* Les points d'ancrage existent sous forme de points de coin, de points droits ou de points lisses :
  * Un point de coin est un point où 2 lignes droites se rejoignent à un angle.
  * Un point lisse est un point où 2 poignées existent en ligne droite et les segments de la ligne se rejoignent en une courbe lisse. Dans ce cas, toutes les poignées sont séparées du point d'ancrage par une distance égale.
  * Un point droit est un point où 2 poignées existent en ligne droite et que les segments de ligne de cette ligne se rejoignent en une courbe lisse. Dans ce cas, les poignées ne doivent pas être séparées du point d'ancrage par une distance égale.
* En déplaçant ou en modifiant des points d'ancrage (ce qui change l'angle des lignes), vous pouvez changer l'apparence d'une forme.

Pour modifier les formes PowerPoint à travers des points d'édition, **Aspose.Slides** fournit la classe [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) et l'interface [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) représente un chemin géométrique de l'objet [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape).
* Pour récupérer le `GeometryPath` de l'instance `IGeometryShape`, vous pouvez utiliser la méthode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--).
* Pour définir le `GeometryPath` d'une forme, vous pouvez utiliser ces méthodes : [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) pour *formes solides* et [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) pour *formes composites*.
* Pour ajouter des segments, vous pouvez utiliser les méthodes sous [IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).
* En utilisant les méthodes [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) et [IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-), vous pouvez définir l'apparence d'un chemin géométrique.
* En utilisant la méthode [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--), vous pouvez récupérer le chemin géométrique d'une `GeometryShape` sous forme de tableau de segments de chemin.
* Pour accéder à d'autres options de personnalisation géométrique de la forme, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
* Utilisez les méthodes [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) et [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (de la classe [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil)) pour convertir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) et vice versa.

## **Opérations Simples d'Édition**

Ce code PHP vous montre comment

**Ajouter une ligne** à la fin d'un chemin

```php

```
**Ajouter une ligne** à une position spécifiée sur un chemin :

```php

```
**Ajouter une courbe Bezier cubique** à la fin d'un chemin :

```php

```
**Ajouter une courbe Bezier cubique** à une position spécifiée sur un chemin :

```php

```
**Ajouter une courbe Bezier quadratique** à la fin d'un chemin :

```php

```
**Ajouter une courbe Bezier quadratique** à une position spécifiée sur un chemin :

```php

```
**Ajouter un arc donné** à un chemin :

```php

```
**Fermer la figure actuelle** d'un chemin :

```php

```
**Définir la position pour le prochain point** :

```php

```
**Supprimer le segment de chemin** à un index donné :

```php

```

## **Ajouter des Points Personnalisés à une Forme**
1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) et définissez le type [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) à partir de la forme.
3. Ajoutez un nouveau point entre les deux points supérieurs sur le chemin.
4. Ajoutez un nouveau point entre les deux points inférieurs sur le chemin.
5. Appliquez le chemin à la forme.

Ce code PHP vous montre comment ajouter des points personnalisés à une forme :

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

##  Supprimer des Points d'une Forme

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) et définissez le type [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) à partir de la forme.
3. Supprimez le segment pour le chemin.
4. Appliquez le chemin à la forme.

Ce code PHP vous montre comment supprimer des points d'une forme :

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

##  **Créer une Forme Personnalisée**

1. Calculez les points pour la forme.
2. Créez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. Remplissez le chemin avec les points.
4. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
5. Appliquez le chemin à la forme.

Ce Java vous montre comment créer une forme personnalisée :

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)


## **Créer une Forme Personnalisée Composite**

  1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
  2. Créez une première instance de la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
  3. Créez une deuxième instance de la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
  4. Appliquez les chemins à la forme.

Ce code PHP vous montre comment créer une forme personnalisée composite :

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **Créer une Forme Personnalisée avec des Angles Arrondis**

Ce code PHP vous montre comment créer une forme personnalisée avec des angles arrondis (vers l'intérieur) :

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir GeometryPath en java.awt.Shape** 

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. Créez une instance de la classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. Convertissez l'instance [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) en instance [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) à l'aide de [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil).
4. Appliquez les chemins à la forme.

Ce code PHP—une implémentation des étapes ci-dessus—démontre le processus de conversion **GeometryPath** à **GraphicsPath** :

```php
  $pres = new Presentation();
  try {
    # Créer une nouvelle forme
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Obtenir le chemin géométrique de la forme
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Créer un nouveau chemin graphique avec texte
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Texte dans la forme";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Convertir le chemin graphique en chemin géométrique
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Définir la combinaison du nouveau chemin géométrique et du chemin géométrique d'origine à la forme
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)