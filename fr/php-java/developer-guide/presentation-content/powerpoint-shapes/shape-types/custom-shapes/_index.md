---
title: Personnaliser les formes de présentation en PHP
linktitle: Forme personnalisée
type: docs
weight: 20
url: /fr/php-java/custom-shape/
keywords:
- forme personnalisée
- ajouter forme
- créer une forme
- modifier forme
- géométrie de forme
- chemin géométrique
- points de chemin
- points d'édition
- ajouter point
- supprimer point
- opération d'édition
- coin arrondi
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour PHP via Java : chemins géométriques, coins arrondis, formes composites."
---

## **Modifier une forme à l'aide de points d'édition**
Considérez un carré. Dans PowerPoint, en utilisant **points d'édition**, vous pouvez 

* déplacer le coin du carré vers l'intérieur ou l'extérieur  
* spécifier la courbure d'un coin ou d'un point  
* ajouter de nouveaux points au carré  
* manipuler les points du carré, etc.  

En fait, vous pouvez effectuer les tâches décrites sur n'importe quelle forme. En utilisant les points d'édition, vous pouvez modifier une forme ou créer une nouvelle forme à partir d'une forme existante.  

## **Conseils pour l'édition de formes**

![overview_image](custom_shape_0.png)

Avant de commencer à modifier les formes PowerPoint à l'aide de points d'édition, vous voudrez peut‑être prendre en compte les points suivants concernant les formes :

* Une forme (ou son tracé) peut être fermée ou ouverte.  
* Lorsqu'une forme est fermée, elle ne possède ni point de départ ni point d'arrivée. Lorsqu'une forme est ouverte, elle possède un début et une fin.  
* Toutes les formes sont composées d'au moins 2 points d'ancrage reliés entre eux par des lignes  
* Une ligne est soit droite, soit courbe. Les points d'ancrage déterminent la nature de la ligne.  
* Les points d'ancrage existent sous forme de points d'angle, points droits ou points lisses :  
  * Un point d'angle est un point où 2 lignes droites se rejoignent à un angle.  
  * Un point lisse est un point où 2 poignées existent sur une ligne droite et les segments de ligne se rejoignent dans une courbe douce. Dans ce cas, toutes les poignées sont séparées du point d'ancrage par une même distance.  
  * Un point droit est un point où 2 poignées existent sur une ligne droite et les segments de cette ligne se rejoignent dans une courbe douce. Dans ce cas, les poignées n'ont pas besoin d'être séparées du point d'ancrage par une même distance.  
* En déplaçant ou en modifiant les points d'ancrage (ce qui change l'angle des lignes), vous pouvez modifier l'apparence d'une forme.  

Pour modifier les formes PowerPoint à l'aide de points d'édition, **Aspose.Slides** fournit la classe [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) et l'interface [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).

* Une instance [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) représente le tracé géométrique de l'objet [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape).  
* Pour récupérer le `GeometryPath` à partir de l'instance `IGeometryShape`, vous pouvez utiliser la méthode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--).  
* Pour définir le `GeometryPath` d'une forme, vous pouvez utiliser ces méthodes : [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) pour les *formes pleines* et [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) pour les *formes composites*.  
* Pour ajouter des segments, vous pouvez utiliser les méthodes de [IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).  
* En utilisant les méthodes [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) et [IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-), vous pouvez définir l'apparence d'un tracé géométrique.  
* En appelant la méthode [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--) vous pouvez récupérer le tracé géométrique d'un `GeometryShape` sous forme de tableau de segments de tracé.  
* Pour accéder à des options supplémentaires de personnalisation de la géométrie d'une forme, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).  
* Utilisez les méthodes [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) et [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (de la classe [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil)) pour convertir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) et inversement.  

## **Opérations d'édition simples**

Ce code PHP montre comment  

**Ajouter une ligne** à la fin d'un tracé  
```php

```
  
**Ajouter une ligne** à une position spécifiée sur un tracé :  
```php

```
  
**Ajouter une courbe de Bézier cubique** à la fin d'un tracé :  
```php

```
  
**Ajouter une courbe de Bézier cubique** à la position spécifiée sur un tracé :  
```php

```
  
**Ajouter une courbe de Bézier quadratique** à la fin d'un tracé :  
```php

```
  
**Ajouter une courbe de Bézier quadratique** à une position spécifiée sur un tracé :  
```php

```
  
**Ajouter un arc donné** à un tracé :  
```php

```
  
**Fermer la figure courante** d'un tracé :  
```php

```
  
**Définir la position du point suivant** :  
```php

```
  
**Supprimer le segment de tracé** à un indice donné :  
```php

```
  

## **Ajouter des points personnalisés à une forme**
1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) et définissez le type [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).  
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) depuis la forme.  
3. Ajoutez un nouveau point entre les deux points supérieurs du tracé.  
4. Ajoutez un nouveau point entre les deux points inférieurs du tracé.  
5. Appliquez le tracé à la forme.  

Ce code PHP montre comment ajouter des points personnalisés à une forme :  
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

## **Supprimer des points d'une forme**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) et définissez le type [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).  
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) depuis la forme.  
3. Supprimez le segment du tracé.  
4. Appliquez le tracé à la forme.  

Ce code PHP montre comment supprimer des points d'une forme :  
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

##  **Créer une forme personnalisée**

1. Calculez les points de la forme.  
2. Créez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).  
3. Remplissez le tracé avec les points.  
4. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).  
5. Appliquez le tracé à la forme.  

Ce code Java montre comment créer une forme personnalisée :  
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


## **Créer une forme personnalisée composite**

  1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).  
  2. Créez une première instance de la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).  
  3. Créez une seconde instance de la classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).  
  4. Appliquez les tracés à la forme.  

Ce code PHP montre comment créer une forme personnalisée composite :  
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

## **Créer une forme personnalisée avec coins arrondis**

Ce code PHP montre comment créer une forme personnalisée avec des coins arrondis (vers l'intérieur) ;  
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
  

## **Déterminer si la géométrie d'une forme est fermée**

Une forme fermée est définie comme une forme dont tous les côtés se rejoignent, formant une seule frontière sans espaces. Une telle forme peut être une forme géométrique simple ou un contour personnalisé complexe. L'exemple de code suivant montre comment vérifier si la géométrie d'une forme est fermée :  
```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```
  

## **Convertir GeometryPath en java.awt.Shape** 

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).  
2. Créez une instance de la classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).  
3. Convertissez l'instance [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) en instance [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) à l'aide de [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil).  
4. Appliquez les tracés à la forme.  

Ce code PHP – implémentation des étapes ci‑dessus – montre le processus de conversion de **GeometryPath** en **GraphicsPath** :  
```php
  $pres = new Presentation();
  try {
    # Créer une nouvelle forme
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Obtenir le tracé géométrique de la forme
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Créer un nouveau tracé graphique avec du texte
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Convertir le tracé graphique en tracé géométrique
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Définir la combinaison du nouveau tracé géométrique et du tracé géométrique d'origine à la forme
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
  
![example5_image](custom_shape_5.png)  

## **FAQ**

**Que se passe-t-il pour le remplissage et le contour après le remplacement de la géométrie ?**

Le style reste attaché à la forme ; seule la silhouette change. Le remplissage et le contour sont appliqués automatiquement à la nouvelle géométrie.  

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la méthode [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setrotation/) de la forme ; la géométrie tourne avec la forme car elle est liée au système de coordonnées propre à la forme.  

**Puis‑je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone de [slide](/slides/fr/php-java/convert-powerpoint-to-png/) requise ou la [shape](/slides/fr/php-java/create-shape-thumbnails/) elle‑même au format raster ; cela simplifie le travail ultérieur avec des géométries lourdes.