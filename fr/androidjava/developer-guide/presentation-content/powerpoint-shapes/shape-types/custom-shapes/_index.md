---
title: Forme Personnalisée
type: docs
weight: 20
url: /fr/androidjava/custom-shape/
keywords: "forme PowerPoint, forme personnalisée, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Ajouter une forme personnalisée dans une présentation PowerPoint en Java"
---

# Modifier une Forme en Utilisant des Points d'Édition
Considérons un carré. Dans PowerPoint, en utilisant **des points d'édition**, vous pouvez 

* déplacer le coin du carré vers l'intérieur ou l'extérieur
* spécifier la courbure pour un coin ou un point
* ajouter de nouveaux points au carré
* manipuler des points sur le carré, etc. 

Essentiellement, vous pouvez effectuer les tâches décrites sur n'importe quelle forme. En utilisant des points d'édition, vous pouvez changer une forme ou créer une nouvelle forme à partir d'une forme existante.

## **Conseils pour l'Édition des Formes**

![overview_image](custom_shape_0.png)

Avant de commencer à modifier les formes PowerPoint à travers des points d'édition, vous pourriez vouloir considérer ces points concernant les formes :

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Lorsqu'une forme est fermée, elle n'a pas de point de départ ou d'arrivée. Lorsqu'une forme est ouverte, elle a un début et une fin. 
* Toutes les formes consistent en au moins 2 points d'ancrage liés entre eux par des lignes.
* Une ligne est soit droite soit courbée. Les points d'ancrage déterminent la nature de la ligne.
* Les points d'ancrage existent en tant que points de coin, points droits ou points lisses :
  * Un point de coin est un point où 2 lignes droites se rejoignent à un angle.
  * Un point lisse est un point où 2 poignées existent en ligne droite et les segments de la ligne se rejoignent en une courbe lisse. Dans ce cas, toutes les poignées sont séparées du point d'ancrage par une distance égale.
  * Un point droit est un point où 2 poignées existent en ligne droite et que les segments de cette ligne se rejoignent en une courbe lisse. Dans ce cas, les poignées ne doivent pas être séparées du point d'ancrage par une distance égale.
* En déplaçant ou en éditant les points d'ancrage (ce qui change l'angle des lignes), vous pouvez modifier l'apparence d'une forme.

Pour éditer les formes PowerPoint à l'aide de points d'édition, **Aspose.Slides** fournit la classe [**GeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) et l'interface [**IGeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) représente un chemin géométrique de l'objet [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape).
* Pour récupérer le `GeometryPath` à partir de l'instance `IGeometryShape`, vous pouvez utiliser la méthode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--).
* Pour définir le `GeometryPath` d'une forme, vous pouvez utiliser ces méthodes : [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) pour *les formes solides* et [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) pour *les formes composites*.
* Pour ajouter des segments, vous pouvez utiliser les méthodes sous [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath).
* En utilisant les méthodes [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) et [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-), vous pouvez définir l'apparence d'un chemin géométrique.
* En utilisant la méthode [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#getPathData--), vous pouvez récupérer le chemin géométrique d'une `GeometryShape` sous forme de tableau de segments de chemin.
* Pour accéder à des options supplémentaires de personnalisation de la géométrie des formes, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Utilisez [geometryPathToGraphicsPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) et [graphicsPathToGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (de la classe [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil)) pour convertir [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) et inversement.

## **Opérations d'Édition Simples**

Ce code Java vous montre comment

**Ajouter une ligne** à la fin d'un chemin

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Ajouter une ligne** à une position spécifiée sur un chemin :

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Ajouter une courbe de Bézier cubique** à la fin d'un chemin :

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Ajouter une courbe de Bézier cubique** à la position spécifiée sur un chemin :

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Ajouter une courbe de Bézier quadratique** à la fin d'un chemin :

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Ajouter une courbe de Bézier quadratique** à une position spécifiée sur un chemin :

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Ajouter un arc donné** à un chemin :

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Fermer la figure actuelle** d'un chemin :

``` java
public void closeFigure();
```
**Définir la position du prochain point** :

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Supprimer le segment de chemin** à un indice donné :

``` java
public void removeAt(int index);
```

## **Ajouter des Points Personnalisés à une Forme**
1. Créer une instance de la classe [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) et définir le type [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType).
2. Obtenir une instance de la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) à partir de la forme.
3. Ajouter un nouveau point entre les deux points supérieurs sur le chemin.
4. Ajouter un nouveau point entre les deux points inférieurs sur le chemin.
5. Appliquer le chemin à la forme.

Ce code Java vous montre comment ajouter des points personnalisés à une forme :

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example1_image](custom_shape_1.png)

##  Supprimer des Points de la Forme

1. Créer une instance de la classe [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) et définir le type [ShapeType.Heart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType).
2. Obtenir une instance de la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) à partir de la forme.
3. Supprimer le segment pour le chemin.
4. Appliquer le chemin à la forme.

Ce code Java vous montre comment supprimer des points d'une forme :

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![example2_image](custom_shape_2.png)

##  **Créer une Forme Personnalisée**

1. Calculer les points pour la forme.
2. Créer une instance de la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
3. Remplir le chemin avec les points.
4. Créer une instance de la classe [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
5. Appliquer le chemin à la forme.

Ce code Java vous montre comment créer une forme personnalisée :

``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Créer une Forme Composite Personnalisée**

1. Créer une instance de la classe [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
2. Créer une première instance de la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
3. Créer une seconde instance de la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
4. Appliquer les chemins à la forme.

Ce code Java vous montre comment créer une forme composite personnalisée :

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Créer une Forme Personnalisée Avec des Coins Arrondis**

Ce code Java vous montre comment créer une forme personnalisée avec des coins arrondis (vers l'intérieur) :

```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.closeFigure();

    childShape.setGeometryPath(geometryPath);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir GeometryPath en java.awt.Shape** 

1. Créer une instance de la classe [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
2. Créer une instance de la classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Convertir l'instance de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) en instance de [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) en utilisant [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil).
4. Appliquer les chemins à la forme.

Ce code Java—une implémentation des étapes ci-dessus—démontre le processus de conversion **GeometryPath** en **GraphicsPath** :

``` java
Presentation pres = new Presentation();
try {
    // Créer une nouvelle forme
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Obtenir le chemin géométrique de la forme
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Créer un nouveau chemin graphique avec du texte
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Texte dans la forme";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // Convertir le chemin graphique en chemin géométrique
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Définir la combinaison du nouveau chemin géométrique et du chemin géométrique d'origine pour la forme
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)