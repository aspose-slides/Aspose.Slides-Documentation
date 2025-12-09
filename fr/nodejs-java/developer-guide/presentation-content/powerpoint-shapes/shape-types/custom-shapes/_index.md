---
title: Forme personnalisée
type: docs
weight: 20
url: /fr/nodejs-java/custom-shape/
keywords:
- forme
- forme personnalisée
- créer une forme
- géométrie
- géométrie de forme
- chemin de géométrie
- points du chemin
- points d'édition
- PowerPoint
- présentation
- JavaScript
- Aspose.Slides pour Node.js via Java
description: "Ajouter une forme personnalisée à une présentation PowerPoint en JavaScript"
---

## **Modifier une forme à l'aide des points d'édition**

Considérez un carré. Dans PowerPoint, en utilisant **les points d'édition**, vous pouvez 

* déplacer le coin du carré vers l'intérieur ou l'extérieur
* spécifier la courbure d'un coin ou d'un point
* ajouter de nouveaux points au carré
* manipuler les points du carré, etc. 

Essentiellement, vous pouvez effectuer les tâches décrites sur n'importe quelle forme. En utilisant les points d'édition, vous pouvez modifier une forme ou créer une nouvelle forme à partir d'une forme existante. 

## **Conseils pour l'édition de formes**

![overview_image](custom_shape_0.png)

Avant de commencer à modifier les formes PowerPoint à l'aide des points d'édition, vous voudrez peut‑être prendre en compte les points suivants concernant les formes :

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Lorsqu'une forme est fermée, elle n'a pas de point de départ ou d'arrivée. Lorsqu'une forme est ouverte, elle possède un début et une fin. 
* Toutes les formes sont composées d'au moins 2 points d'ancrage reliés entre eux par des lignes
* Une ligne est soit droite, soit courbe. Les points d'ancrage déterminent la nature de la ligne. 
* Les points d'ancrage existent sous forme de points d'angle, points droits ou points lisses :
  * Un point d'angle est un point où 2 lignes droites se rejoignent sous un angle. 
  * Un point lisse est un point où 2 poignées existent sur une ligne droite et les segments de la ligne se rejoignent dans une courbe fluide. Dans ce cas, toutes les poignées sont séparées du point d'ancrage par une distance égale. 
  * Un point droit est un point où 2 poignées existent sur une ligne droite et les segments de cette ligne se rejoignent dans une courbe fluide. Dans ce cas, les poignées n'ont pas besoin d'être séparées du point d'ancrage par une distance égale. 
* En déplaçant ou en modifiant les points d'ancrage (ce qui change l'angle des lignes), vous pouvez modifier l'apparence d'une forme. 

Pour modifier les formes PowerPoint via les points d'édition, **Aspose.Slides** fournit la classe [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) et la classe [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) représente un chemin géométrique de l'objet [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
* Pour récupérer le `GeometryPath` à partir de l'instance `GeometryShape`, vous pouvez utiliser la méthode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--).
* Pour définir le `GeometryPath` d'une forme, vous pouvez utiliser ces méthodes : [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) pour les *formes pleines* et [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) pour les *formes composites*.
* Pour ajouter des segments, vous pouvez utiliser les méthodes de la classe [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
* En utilisant les méthodes [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) et [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-), vous pouvez définir l'apparence d'un chemin géométrique.
* En utilisant la méthode [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#getPathData--) vous pouvez récupérer le chemin géométrique d'un `GeometryShape` sous forme d'un tableau de segments de chemin.
* Pour accéder à des options supplémentaires de personnalisation de la géométrie des formes, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
* Utilisez les méthodes [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) et [graphicsPathToGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (de la classe [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil)) pour convertir [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) et inversement.

## **Opérations d'édition simples**

Ce code JavaScript vous montre comment

**Ajouter une ligne** à la fin d'un chemin
```javascript
lineTo(point);
lineTo(x, y);
```

**Ajouter une ligne** à une position spécifiée sur un chemin :
```javascript
lineTo(point, index);
lineTo(x, y, index);
```

**Ajouter une courbe de Bézier cubique** à la fin d'un chemin :
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**Ajouter une courbe de Bézier cubique** à la position spécifiée sur un chemin :
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**Ajouter une courbe de Bézier quadratique** à la fin d'un chemin :
```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```

**Ajouter une courbe de Bézier quadratique** à la position spécifiée sur un chemin :
```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```

**Ajouter un arc donné** à un chemin :
```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```

**Fermer la figure actuelle** d'un chemin :
```javascript
closeFigure();
```

**Définir la position du point suivant** :
```javascript
moveTo(point);
moveTo(x, y);
```

**Supprimer le segment de chemin** à un indice donné :
```javascript
removeAt(index);
```


## **Ajouter des points personnalisés à la forme**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) et définissez le type [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) à partir de la forme.
3. Ajoutez un nouveau point entre les deux points supérieurs du chemin.
4. Ajoutez un nouveau point entre les deux points inférieurs du chemin.
5. Appliquez le chemin à la forme.

Ce code JavaScript vous montre comment ajouter des points personnalisés à une forme :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example1_image](custom_shape_1.png)

## **Supprimer des points d'une forme**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) et définissez le type [ShapeType.Heart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) à partir de la forme.
3. Supprimez le segment du chemin.
4. Appliquez le chemin à la forme.

Ce code JavaScript vous montre comment supprimer des points d'une forme :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example2_image](custom_shape_2.png)

## **Créer une forme personnalisée**

1. Calculez les points de la forme.
2. Créez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
3. Remplissez le chemin avec les points.
4. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
5. Appliquez le chemin à la forme.

Ce JavaScript vous montre comment créer une forme personnalisée :
```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example3_image](custom_shape_3.png)


## **Créer une forme personnalisée composite**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
2. Créez une première instance de la classe [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
3. Créez une seconde instance de la classe [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
4. Appliquez les chemins à la forme.

Ce code JavaScript vous montre comment créer une forme personnalisée composite :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example4_image](custom_shape_4.png)

## **Créer une forme personnalisée avec coins arrondis**

Ce code JavaScript vous montre comment créer une forme personnalisée avec des coins arrondis (vers l'intérieur) ;
```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
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
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Déterminer si la géométrie d'une forme est fermée**

Une forme fermée est définie comme une forme dont tous les côtés sont reliés, formant une seule frontière sans espaces. Une telle forme peut être une forme géométrique simple ou un contour personnalisé complexe. L'exemple de code suivant montre comment vérifier si la géométrie d'une forme est fermée :
```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```


## **Convertir GeometryPath en java.awt.Shape** 

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
2. Créez une instance de la classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Convertissez l'instance [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) en instance [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) à l'aide de [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil).
4. Appliquez les chemins à la forme.

Ce code JavaScript—une implémentation des étapes ci‑dessus—décrit le processus de conversion de **GeometryPath** en **GraphicsPath** :
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Créer une nouvelle forme
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Obtenir le chemin géométrique de la forme
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Créer un nouveau chemin graphique avec du texte
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // Convertir le chemin graphique en chemin géométrique
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Définir la combinaison du nouveau chemin géométrique et du chemin géométrique original sur la forme
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Que se passe-t-il pour le remplissage et le contour après le remplacement de la géométrie ?**

Le style reste attaché à la forme ; seul le contour change. Le remplissage et le contour sont automatiquement appliqués à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la méthode [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setrotation/) de la forme ; la géométrie tourne avec la forme car elle est liée au système de coordonnées propre à la forme.

**Puis-je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone de la [diapositive](/slides/fr/nodejs-java/convert-powerpoint-to-png/) requise ou la [forme](/slides/fr/nodejs-java/create-shape-thumbnails/) elle‑même vers un format raster ; cela simplifie le travail ultérieur avec des géométries lourdes.