---
title: Personnaliser les formes de présentation en Python via Java
linktitle: Forme personnalisée
type: docs
weight: 20
url: /fr/python-java/custom-shape/
keywords:
- forme personnalisée
- ajouter forme
- créer forme
- modifier forme
- géométrie de forme
- chemin géométrique
- points de chemin
- points d'édition
- ajouter point
- supprimer point
- opération d'édition
- coin courbé
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour Python via Java : chemins géométriques, coins courbés, formes composites."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les formes de présentation dans Aspose.Slides en modifiant la géométrie des formes à l'aide de points d'édition et de chemins géométriques. Il montre comment travailler avec [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/) pour modifier des formes existantes, effectuer des opérations d'édition de base sur les chemins, ajouter ou supprimer des points, et appliquer la géométrie mise à jour à une forme.

Il démontre également comment créer des formes personnalisées et composites, construire des formes avec des coins incurvés, déterminer si la géométrie d'une forme est fermée, et convertir entre [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/) et [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) pour des scénarios de personnalisation géométrique supplémentaires.

## **Modifier une forme à l'aide de points d'édition**

Considérez un carré. Dans PowerPoint, en utilisant **points d'édition**, vous pouvez 

* déplacer le coin du carré vers l'intérieur ou l'extérieur
* spécifier la courbure d'un coin ou d'un point
* ajouter de nouveaux points au carré
* manipuler les points du carré, etc. 

En pratique, vous pouvez exécuter ces tâches sur n'importe quelle forme. Grâce aux points d'édition, vous pouvez modifier une forme ou créer une nouvelle forme à partir d'une forme existante. 

## **Conseils de modification de forme**

![overview_image](custom_shape_0.png)

Avant de commencer à modifier les formes PowerPoint à l'aide de points d'édition, vous pourriez vouloir considérer ces points concernant les formes :

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Lorsqu'une forme est fermée, elle n'a pas de point de départ ou d'arrivée. Lorsqu'une forme est ouverte, elle possède un début et une fin. 
* Toutes les formes sont composées d'au moins 2 points d'ancrage reliés entre eux par des lignes.
* Une ligne est soit droite, soit courbe. Les points d'ancrage déterminent la nature de la ligne. 
* Les points d'ancrage existent sous forme de points d'angle, points droits ou points lisses :
  * Un point d'angle est un point où 2 lignes droites se rejoignent à un angle. 
  * Un point lisse est un point où 2 poignées existent sur une ligne droite et les segments de la ligne se rejoignent en une courbe douce. Dans ce cas, toutes les poignées sont séparées du point d'ancrage par une distance égale. 
  * Un point droit est un point où 2 poignées existent sur une ligne droite et ces segments de ligne se rejoignent en une courbe douce. Dans ce cas, les poignées n'ont pas besoin d'être séparées du point d'ancrage par une distance égale. 
* En déplaçant ou en éditant les points d'ancrage (ce qui modifie l'angle des lignes), vous pouvez changer l'apparence d'une forme. 

Pour éditer les formes PowerPoint via des points d'édition, **Aspose.Slides** fournit la classe [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/). 

* Une instance de [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/) représente un chemin géométrique de l'objet [GeometryShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/). 
* Pour récupérer le [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/) d'une instance de [GeometryShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/), vous pouvez utiliser la méthode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/#getGeometryPaths). 
* Pour définir le [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/) d'une forme, vous pouvez utiliser ces méthodes : [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/#setGeometryPath) pour les *formes pleines* et [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/#setGeometryPaths) pour les *formes composites*.
* Pour ajouter des segments, vous pouvez utiliser les méthodes de la classe [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/). 
* En utilisant les méthodes [GeometryPath.setStroke](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/#setStroke) et [GeometryPath.setFillMode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/#setFillMode), vous pouvez définir l'apparence d'un chemin géométrique.
* En appelant la méthode [GeometryPath.getPathData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/#getPathData), vous pouvez récupérer le chemin géométrique d'un [GeometryShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/) sous forme de tableau de segments de chemin. 
* Pour accéder à des options supplémentaires de personnalisation de la géométrie de forme, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
* Utilisez les méthodes [geometryPathToGraphicsPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeutil/) et [graphicsPathToGeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeutil/) (de la classe [ShapeUtil](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeutil/)) pour convertir [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/) vers [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) et inversement. 

## **Opérations d'édition simples**

Les signatures suivantes montrent les opérations d'édition de base :

**Ajouter une ligne** à la fin d'un chemin :

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Ajouter une ligne** à une position spécifiée sur un chemin :

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Ajouter une courbe de Bézier cubique** à la fin d'un chemin :

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Ajouter une courbe de Bézier cubique** à la position spécifiée sur un chemin :

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Ajouter une courbe de Bézier quadratique** à la fin d'un chemin :

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Ajouter une courbe de Bézier quadratique** à une position spécifiée sur un chemin :

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Ajouter un arc donné** à un chemin :

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**Fermer la figure courante** d'un chemin :

- `geometry_path.closeFigure()`

**Définir la position du point suivant** :

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Supprimer le segment de chemin** à un indice donné :

- `geometry_path.removeAt(index)`


## **Ajouter des points personnalisés à une forme**
1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/) et définissez le type [ShapeType.Rectangle](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#Rectangle).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/) à partir de la forme.
3. Ajoutez un nouveau point entre les deux points supérieurs du chemin.
4. Ajoutez un nouveau point entre les deux points inférieurs du chemin.
5. Appliquez le chemin à la forme.

Ce code Python montre comment ajouter des points personnalisés à une forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **Supprimer des points d'une forme**

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/) et définissez le type [ShapeType.Heart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#Heart). 
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/) à partir de la forme.
3. Supprimez le segment du chemin.
4. Appliquez le chemin à la forme.

Ce code Python montre comment supprimer des points d'une forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Créer une forme personnalisée**

1. Calculez les points de la forme.
2. Créez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/). 
3. Remplissez le chemin avec les points.
4. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/). 
5. Appliquez le chemin à la forme.

Ce code Python montre comment créer une forme personnalisée :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)


## **Créer une forme composite personnalisée**

  1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/).
  2. Créez une première instance de la classe [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/).
  3. Créez une seconde instance de la classe [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/).
  4. Appliquez les chemins à la forme.

Ce code Python montre comment créer une forme composite personnalisée :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Créer une forme personnalisée avec des coins courbés**

Ce code Python montre comment créer une forme personnalisée avec des coins courbés (vers l'intérieur) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    shape.setGeometryPath(geometry_path)
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Déterminer si la géométrie d'une forme est fermée**

Une forme fermée est définie comme une forme dont tous les côtés se rejoignent, formant une frontière unique sans lacunes. Une telle forme peut être une forme géométrique simple ou un contour personnalisé complexe. L'exemple de code suivant montre comment vérifier si la géométrie d'une forme est fermée :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **Convertir GeometryPath en java.awt.Shape** 

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/).
2. Créez une instance de la classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Convertissez l'instance [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) en instance [GeometryPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometrypath/) en parcourant son [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) et en rejouant chaque segment sur le chemin.
4. Appliquez les chemins à la forme.

Ce code Python implémente les étapes ci‑dessus pour convertir un chemin graphique en chemin géométrique :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    # Créer une nouvelle forme.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Obtenir le chemin géométrique de la forme.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Créer un nouveau chemin graphique avec du texte.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
    finally:
        graphics.dispose()

    # Convertir le chemin graphique en chemin géométrique.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # Appliquer le chemin texte avec le chemin géométrique original.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Que se passe-t-il avec le remplissage et le contour après le remplacement de la géométrie ?**

Le style reste attaché à la forme ; seul le contour change. Le remplissage et le contour sont appliqués automatiquement à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la méthode [setRotation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#setRotation) de la forme ; la géométrie pivote avec la forme car elle est liée au système de coordonnées de la forme.

**Puis‑je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone de la [slide](/slides/fr/python-java/convert-powerpoint-to-png/) requise ou la [shape](/slides/fr/python-java/create-shape-thumbnails/) elle‑même au format raster ; cela simplifie le travail ultérieur avec des géométries lourdes.