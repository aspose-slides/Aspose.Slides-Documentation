---
title: Personnaliser les formes de présentation sur Android
linktitle: Forme personnalisée
type: docs
weight: 20
url: /fr/androidjava/custom-shape/
keywords:
- forme personnalisée
- ajouter une forme
- créer une forme
- modifier une forme
- géométrie de forme
- chemin géométrique
- points du chemin
- points d'édition
- ajouter un point
- supprimer un point
- opération d'édition
- coin arrondi
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour Android via Java : chemins géométriques, coins arrondis, formes composites."
---

## **Modifier une forme à l’aide des points d’édition**
Considérez un carré. Dans PowerPoint, à l’aide des **points d’édition**, vous pouvez

* déplacer le coin du carré vers l’intérieur ou vers l’extérieur
* spécifier la courbure d’un coin ou d’un point
* ajouter de nouveaux points au carré
* manipuler les points du carré, etc. 

Essentiellement, vous pouvez effectuer les tâches décrites sur n’importe quelle forme. En utilisant les points d’édition, vous pouvez modifier une forme ou créer une nouvelle forme à partir d’une forme existante. 

## **Conseils pour l'édition de formes**

![overview_image](custom_shape_0.png)

Avant de commencer à modifier les formes PowerPoint à l’aide des points d’édition, vous voudrez peut‑être considérer ces points concernant les formes :

* Une forme (ou son tracé) peut être fermée ou ouverte.
* Lorsqu’une forme est fermée, elle ne possède ni point de départ ni point de fin. Lorsqu’une forme est ouverte, elle possède un début et une fin. 
* Toutes les formes sont constituées d’au moins 2 points d’ancrage liés entre eux par des lignes
* Une ligne est soit droite, soit courbe. Les points d’ancrage déterminent la nature de la ligne. 
* Les points d’ancrage existent sous forme de points d’angle, points droits ou points lisses :
  * Un point d’angle est un point où 2 lignes droites se rejoignent sous un angle. 
  * Un point lisse est un point où 2 poignées existent sur une ligne droite et les segments de la ligne se rejoignent dans une courbe fluide. Dans ce cas, toutes les poignées sont séparées du point d’ancrage par une distance égale. 
  * Un point droit est un point où 2 poignées existent sur une ligne droite et les segments de cette ligne se rejoignent dans une courbe fluide. Dans ce cas, les poignées n’ont pas besoin d’être séparées du point d’ancrage par une distance égale. 
* En déplaçant ou en modifiant les points d’ancrage (ce qui change l’angle des lignes), vous pouvez modifier l’apparence d’une forme. 

Pour modifier les formes PowerPoint via les points d’édition, **Aspose.Slides** fournit la classe [**GeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) et l’interface [**IGeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) représente le tracé géométrique de l’objet [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape).
* Pour récupérer le`GeometryPath` depuis l’instance `IGeometryShape`, vous pouvez utiliser la méthode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--).
* Pour définir le `GeometryPath` d’une forme, vous pouvez utiliser ces méthodes : [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) pour les *formes pleines* et [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) pour les *formes composites*.
* Pour ajouter des segments, vous pouvez utiliser les méthodes sous [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath).
* En utilisant les méthodes [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) et [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-), vous pouvez définir l’apparence d’un tracé géométrique.
* En utilisant la méthode [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#getPathData--) , vous pouvez récupérer le tracé géométrique d’un `GeometryShape` sous forme d’un tableau de segments de tracé.
* Pour accéder à des options supplémentaires de personnalisation de la géométrie des formes, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Utilisez les méthodes [geometryPathToGraphicsPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) et [graphicsPathToGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (de la classe [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil)) pour convertir [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) et inversement.

## **Opérations d'édition simples**

Ce code Java montre comment

**Ajouter une ligne** à la fin d’un tracé
``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```

**Ajouter une ligne** à une position spécifiée sur un tracé :
``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```

**Ajouter une courbe de Bézier cubique** à la fin d’un tracé :
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Ajouter une courbe de Bézier cubique** à la position spécifiée sur un tracé :
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```

**Ajouter une courbe de Bézier quadratique** à la fin d’un tracé :
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Ajouter une courbe de Bézier quadratique** à la position spécifiée sur un tracé :
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```

**Ajouter un arc donné** à un tracé :
``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Fermer la figure actuelle** d’un tracé :
``` java
public void closeFigure();
```

**Définir la position du point suivant** :
``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```

**Supprimer le segment du tracé** à un indice donné :
``` java
public void removeAt(int index);
```


## **Ajouter des points personnalisés à une forme**
1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) et définissez le type [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) à partir de la forme.
3. Ajoutez un nouveau point entre les deux points supérieurs du tracé.
4. Ajoutez un nouveau point entre les deux points inférieurs du tracé.
5. Appliquez le tracé à la forme.

Ce code Java montre comment ajouter des points personnalisés à une forme :
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

## **Supprimer des points d'une forme**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) et définissez le type [ShapeType.Heart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) à partir de la forme.
3. Supprimez le segment du tracé.
4. Appliquez le tracé à la forme.

Ce code Java montre comment supprimer des points d'une forme :
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

## **Créer une forme personnalisée**

1. Calculez les points de la forme.
2. Créez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
3. Remplissez le tracé avec les points.
4. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
5. Appliquez le tracé à la forme.

Ce code Java montre comment créer une forme personnalisée :
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


## **Créer une forme personnalisée composite**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
2. Créez une première instance de la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
3. Créez une deuxième instance de la classe [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
4. Appliquez les tracés à la forme.

Ce code Java montre comment créer une forme personnalisée composite :
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

## **Créer une forme personnalisée avec des coins arrondis**

Ce code Java montre comment créer une forme personnalisée avec des coins arrondis (vers l’intérieur) ;
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
    if (pres!= null) pres.dispose();
}
```


## **Déterminer si la géométrie d'une forme est fermée**

Une forme fermée est définie comme une forme dont tous les côtés se rejoignent, formant une frontière unique sans lacunes. Une telle forme peut être une forme géométrique simple ou un contour personnalisé complexe. L’exemple de code suivant montre comment vérifier si la géométrie d’une forme est fermée :
```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```


## **Convertir GeometryPath en java.awt.Shape** 

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
2. Créez une instance de la classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Convertissez l’instance [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) en instance [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) à l’aide de [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil).
4. Appliquez les tracés à la forme.

Ce code Java—mise en œuvre des étapes ci‑dessus—démontre le processus de conversion de **GeometryPath** en **GraphicsPath** :
``` java
Presentation pres = new Presentation();
try {
    // Créer une nouvelle forme
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Obtenir le chemin de géométrie de la forme
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Créer un nouveau chemin graphique avec du texte
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
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

    // Convertir le chemin graphique en chemin de géométrie
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Définir la combinaison du nouveau chemin de géométrie et du chemin de géométrie d'origine sur la forme
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Que se passe-t-il avec le remplissage et le contour après le remplacement de la géométrie ?**

Le style reste attaché à la forme ; seul le contour change. Le remplissage et le contour sont automatiquement appliqués à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la méthode [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) de la forme ; la géométrie pivote avec la forme car elle est liée au système de coordonnées propre à la forme.

**Puis‑je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone de [slide](/slides/fr/androidjava/convert-powerpoint-to-png/) requise ou la [shape](/slides/fr/androidjava/create-shape-thumbnails/) elle‑même au format raster ; cela simplifie le travail ultérieur avec des géométries complexes.