---
title: Forme Personnalisée
type: docs
weight: 20
url: /python-net/custom-shape/
keywords: "forme PowerPoint, forme personnalisée, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter une forme personnalisée dans une présentation PowerPoint en Python"
---

# Modifier une Forme à l'Aide des Points d'Édition

Considérez un carré. Dans PowerPoint, en utilisant les **points d'édition**, vous pouvez 

* déplacer le coin du carré vers l'intérieur ou vers l'extérieur
* spécifier la courbure pour un coin ou un point
* ajouter de nouveaux points au carré
* manipuler des points sur le carré, etc. 

Essentiellement, vous pouvez effectuer les tâches décrites sur n'importe quelle forme. En utilisant les points d'édition, vous pouvez changer une forme ou créer une nouvelle forme à partir d'une forme existante.

## Conseils pour l'Édition de Formes

![overview_image](custom_shape_0.png)

Avant de commencer à éditer les formes PowerPoint via les points d'édition, vous voudrez peut-être considérer ces points concernant les formes :

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Lorsqu'une forme est fermée, elle n'a pas de point de départ ou de point d'arrivée. Lorsqu'une forme est ouverte, elle a un début et une fin. 
* Toutes les formes se composent d'au moins 2 points d'ancrage liés entre eux par des lignes
* Une ligne est soit droite soit courbe. Les points d'ancrage déterminent la nature de la ligne. 
* Les points d'ancrage existent sous forme de points de coin, de points droits ou de points lisses :
  * Un point de coin est un point où 2 lignes droites se rejoignent à un angle. 
  * Un point lisse est un point où 2 poignées existent en ligne droite et où les segments de ligne se rejoignent dans une courbe lisse. Dans ce cas, toutes les poignées sont séparées du point d'ancrage par une distance égale. 
  * Un point droit est un point où 2 poignées existent en ligne droite et que les segments de ligne de cette ligne se rejoignent dans une courbe lisse. Dans ce cas, les poignées n'ont pas besoin d'être séparées du point d'ancrage par une distance égale. 
* En déplaçant ou en éditant les points d'ancrage (ce qui change l'angle des lignes), vous pouvez changer l'apparence d'une forme. 

Pour éditer les formes PowerPoint via les points d'édition, **Aspose.Slides** fournit la classe [**GeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) et l'interface [**IGeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) représente un chemin géométrique de l'objet [IGeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/)
* Pour récupérer le `GeometryPath` de l'instance `IGeometryShape`, vous pouvez utiliser la méthode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/). 
* Pour définir le `GeometryPath` pour une forme, vous pouvez utiliser ces méthodes : [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) pour les *formes solides* et [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) pour les *formes composites*.
* Pour ajouter des segments, vous pouvez utiliser les méthodes sous [IGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/).
* En utilisant les propriétés [IGeometryPath.Stroke](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) et [IGeometryPath.FillMode](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/), vous pouvez définir l'apparence d'un chemin géométrique.
* En utilisant la propriété [IGeometryPath.PathData](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/properties/pathdata), vous pouvez récupérer le chemin géométrique d'une `GeometryShape` sous forme de tableau de segments de chemin. 
* Pour accéder à des options de personnalisation supplémentaires de la géométrie de la forme, vous pouvez convertir [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) en [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
* Utilisez les méthodes `GeometryPathToGraphicsPath` et `GraphicsPathToGeometryPath` (de la classe [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/)) pour convertir `GeometryPath` en `GraphicsPath` et vice versa.

## **Opérations d'Édition Simples**

Ce code python vous montre comment

**Ajouter une ligne** à la fin d'un chemin :

```py
line_to(point)
line_to(x, y)
```
**Ajouter une ligne** à une position spécifiée sur un chemin :

```py    
line_to(point, index)
line_to(x, y, index)
```
**Ajouter une courbe de Bézier cubique** à la fin d'un chemin :

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```
**Ajouter une courbe de Bézier cubique** à la position spécifiée sur un chemin :

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```
**Ajouter une courbe de Bézier quadratique** à la fin d'un chemin :
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```
**Ajouter une courbe de Bézier quadratique** à une position spécifiée sur un chemin :

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```
**Ajouter un arc** donné à un chemin :
```py
arc_to(width, heigth, startAngle, sweepAngle)
```
**Fermer la figure actuelle** d'un chemin :
```py
close_figure()
```
**Définir la position pour le prochain point** :
```py
move_to(point)
move_to(x, y)
```
**Supprimer le segment de chemin** à un index donné :

```py
remove_at(index)
```
## Ajouter des Points Personnalisés à une Forme
1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) et définissez le [ShapeType.Rectangle](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) depuis la forme.
3. Ajoutez un nouveau point entre les deux points supérieurs sur le chemin.
4. Ajoutez un nouveau point entre les deux points inférieurs sur le chemin.
6. Appliquez le chemin à la forme.

Ce code python vous montre comment ajouter des points personnalisés à une forme :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    geometryPath = shape.get_geometry_paths()[0]

    geometryPath.line_to(100, 50, 1)
    geometryPath.line_to(100, 50, 4)
    shape.set_geometry_path(geometryPath)
```

![example1_image](custom_shape_1.png)

## Supprimer des Points de la Forme

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) et définissez le type [ShapeType.Heart](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/). 
2. Obtenez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) depuis la forme.
3. Supprimez le segment pour le chemin.
4. Appliquez le chemin à la forme.

Ce code python vous montre comment supprimer des points d'une forme :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)
    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## Créer une Forme Personnalisée

1. Calculez les points pour la forme.
2. Créez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). 
3. Remplissez le chemin avec les points.
4. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/). 
5. Appliquez le chemin à la forme.

Ce code python vous montre comment créer une forme personnalisée :

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

starPath = slides.GeometryPath()
starPath.move_to(points[0])

for i in range(len(points)):
    starPath.line_to(points[i])

starPath.close_figure()

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(starPath)
```
![example3_image](custom_shape_3.png)


## Créer une Forme Composite Personnalisée

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
2. Créez une première instance de la classe [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. Créez une deuxième instance de la classe [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
4. Appliquez les chemins à la forme.

Ce code python vous montre comment créer une forme composite personnalisée :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometryPath0 = slides.GeometryPath()
    geometryPath0.move_to(0, 0)
    geometryPath0.line_to(shape.width, 0)
    geometryPath0.line_to(shape.width, shape.height/3)
    geometryPath0.line_to(0, shape.height / 3)
    geometryPath0.close_figure()

    geometryPath1 = slides.GeometryPath()
    geometryPath1.move_to(0, shape.height/3 * 2)
    geometryPath1.line_to(shape.width, shape.height / 3 * 2)
    geometryPath1.line_to(shape.width, shape.height)
    geometryPath1.line_to(0, shape.height)
    geometryPath1.close_figure()

    shape.set_geometry_paths([ geometryPath0, geometryPath1])
```
![example4_image](custom_shape_4.png)

## **Créer une Forme Personnalisée Avec des Coins Arrondis**

Ce code python vous montre comment créer une forme personnalisée avec des coins arrondis (vers l'intérieur) :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shapeX = 20
shapeY = 20
shapeWidth = 300
shapeHeight = 200

leftTopSize = 50
rightTopSize = 20
rightBottomSize = 40
leftBottomSize = 10

with slides.Presentation() as presentation:
    childShape = presentation.slides[0].shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shapeX, shapeY, shapeWidth, shapeHeight)

    geometryPath = slides.GeometryPath()

    point1 = draw.PointF(leftTopSize, 0)
    point2 = draw.PointF(shapeWidth - rightTopSize, 0)
    point3 = draw.PointF(shapeWidth, shapeHeight - rightBottomSize)
    point4 = draw.PointF(leftBottomSize, shapeHeight)
    point5 = draw.PointF(0, leftTopSize)

    geometryPath.move_to(point1)
    geometryPath.line_to(point2)
    geometryPath.arc_to(rightTopSize, rightTopSize, 180, -90)
    geometryPath.line_to(point3)
    geometryPath.arc_to(rightBottomSize, rightBottomSize, -90, -90)
    geometryPath.line_to(point4)
    geometryPath.arc_to(leftBottomSize, leftBottomSize, 0, -90)
    geometryPath.line_to(point5)
    geometryPath.arc_to(leftTopSize, leftTopSize, 90, -90)

    geometryPath.close_figure()

    childShape.set_geometry_path(geometryPath)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## Conversion de GeometryPath en GraphicsPath (System.Drawing.Drawing2D) 

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
2. Créez une instance de la classe [GrpahicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) du namespace [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Convertissez l'instance [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) en instance de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) à l'aide de [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/).
4. Appliquez les chemins à la forme.

Ce code python — une implémentation des étapes ci-dessus — démontre le processus de conversion de **GeometryPath** à **GraphicsPath** :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 100)

    originalPath = shape.get_geometry_paths()[0]
    originalPath.fill_mode = slides.PathFillModeType.NONE

    gPath = draw.drawing2d.GraphicsPath()

    gPath.add_string("Texte dans la forme", draw.FontFamily("Arial"), 1, 40, draw.PointF(10, 10), draw.StringFormat.generic_default)

    textPath = slides.util.ShapeUtil.graphics_path_to_geometry_path(gPath)
    textPath.fill_mode = slides.PathFillModeType.NORMAL

    shape.set_geometry_paths([originalPath, textPath])
```
![example5_image](custom_shape_5.png)