---
title: Personnaliser les formes dans les présentations avec Python
linktitle: Forme personnalisée
type: docs
weight: 20
url: /fr/python-net/custom-shape/
keywords:
- forme personnalisée
- ajouter forme
- créer forme
- modifier forme
- géométrie de forme
- chemin géométrique
- points du chemin
- modifier les points
- ajouter un point
- supprimer un point
- opération de modification
- coin arrondi
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET : chemins géométriques, coins arrondis, formes composites."
---

## **Vue d'ensemble**

Considérez un carré. Dans PowerPoint, grâce aux **Edit Points**, vous pouvez :

* déplacer le coin du carré vers l'intérieur ou l'extérieur,
* ajuster la courbure d’un coin ou d’un point,
* ajouter de nouveaux points au carré,
* manipuler ses points.

Vous pouvez appliquer ces opérations à n'importe quelle forme. Avec les **Edit Points**, vous pouvez modifier une forme ou créer une nouvelle forme à partir d’une forme existante.

## **Conseils de modification de forme**

!["Edit Points" command](custom_shape_0.png)

Avant de commencer à modifier les formes PowerPoint avec les **Edit Points**, prenez en compte les notes suivantes concernant les formes :

* Une forme (ou son tracé) peut être **fermée** ou **ouverte**.
* Une forme fermée n’a pas de point de départ ni d’arrivée ; une forme ouverte possède un début et une fin.
* Chaque forme possède au moins deux points d’ancrage reliés par des segments de ligne.
* Un segment est soit droit, soit courbe ; les points d’ancrage déterminent la nature du segment.
* Les points d’ancrage peuvent être **coin**, **lisse** ou **droit** :
  * Un point **coin** est un endroit où deux segments droits se rencontrent sous un angle.
  * Un point **lisse** possède deux poignées collinéaires, et les segments adjacents forment une courbe fluide. Dans ce cas, les deux poignées sont à la même distance du point d’ancrage.
  * Un point **droit** possède également deux poignées collinéaires, mais les segments adjacents forment une courbe fluide. Dans ce cas, les poignées n’ont pas besoin d’être à la même distance du point d’ancrage.
* En déplaçant ou en modifiant les points d’ancrage (et donc les angles des segments), vous pouvez modifier l’apparence de la forme.

Pour modifier les formes PowerPoint, Aspose.Slides fournit la classe [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) .

* Une instance de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) représente le tracé géométrique d’un objet [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) .
* Pour récupérer le [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) d’une instance de [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) , utilisez la méthode [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) .
* Pour définir le [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) d’une forme, utilisez [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) pour les *formes solides* et [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) pour les *formes composites*.
* Pour ajouter des segments, utilisez les méthodes de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) .
* Utilisez les propriétés [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) et [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) pour contrôler l’apparence d’un tracé géométrique.
* Utilisez la propriété [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) pour récupérer le tracé géométrique d’une forme sous forme de tableau de segments de chemin.

## **Opérations de modification simples**

Les méthodes suivantes sont utilisées pour les opérations de modification simples.

**Ajouter une ligne** à la fin d’un chemin :
```py
line_to(point)
line_to(x, y)
```


**Ajouter une ligne** à une position spécifiée dans un chemin :
```py    
line_to(point, index)
line_to(x, y, index)
```


**Ajouter une courbe de Bézier cubique** à la fin d’un chemin :
```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```


**Ajouter une courbe de Bézier cubique** à une position spécifiée dans un chemin :
```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```


**Ajouter une courbe de Bézier quadratique** à la fin d’un chemin :
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```


**Ajouter une courbe de Bézier quadratique** à une position spécifiée dans un chemin :
```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```


**Ajouter un arc** à un chemin :
```py
arc_to(width, heigth, startAngle, sweepAngle)
```


**Fermer la figure courante** d’un chemin :
```py
close_figure()
```


**Définir la position du point suivant** :
```py
move_to(point)
move_to(x, y)
```


**Supprimer le segment de chemin** à un indice donné :
```py
remove_at(index)
```


## **Ajouter des points personnalisés aux formes**

Dans cette section, vous apprendrez à définir une forme libre en ajoutant votre propre séquence de points. En spécifiant des points ordonnés et des types de segment (droit ou courbe) et en fermant éventuellement le tracé, vous pouvez dessiner des graphiques personnalisés précis — polygones, icônes, bulles d’appel ou logos — directement sur vos diapositives.

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) et définissez son [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) .
2. Obtenez une instance de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) à partir de la forme.
3. Insérez un nouveau point entre les deux points supérieurs du tracé.
4. Insérez un nouveau point entre les deux points inférieurs du tracé.
5. Appliquez le tracé mis à jour à la forme.

Le code Python suivant montre comment ajouter des points personnalisés à une forme :
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```


![Points personnalisés](custom_shape_1.png)

## **Supprimer des points des formes**

Parfois, une forme personnalisée contient des points inutiles qui compliquent sa géométrie ou affectent son rendu. Cette section montre comment supprimer des points spécifiques du tracé d’une forme afin de simplifier le contour et d’obtenir des résultats plus propres et plus précis.

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) et définissez son type [ShapeType.HEART](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) .
2. Obtenez une instance de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) à partir de la forme.
3. Supprimez un segment du tracé.
4. Appliquez le tracé mis à jour à la forme.

Le code Python suivant montre comment supprimer des points d’une forme :
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```


![Points supprimés](custom_shape_2.png)

## **Créer des formes personnalisées**

Créez des formes vectorielles sur mesure en définissant un [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) et en le composant à partir de lignes, d’arcs et de courbes de Bézier. Cette section montre comment construire une géométrie personnalisée à partir de zéro et ajouter la forme résultante à votre diapositive.

1. Calculez les points de la forme.
2. Créez une instance de la classe [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) .
3. Remplissez le tracé avec les points.
4. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) .
5. Appliquez le tracé à la forme.

Le code Python suivant montre comment créer une forme personnalisée :
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

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```


![Forme personnalisée](custom_shape_3.png)

## **Créer des formes personnalisées composites**

Créer une forme personnalisée composite vous permet de combiner plusieurs tracés géométriques en une seule forme réutilisable sur une diapositive. Définissez et fusionnez ces tracés afin de construire des visuels complexes qui vont au-delà de l’ensemble de formes standard.

1. Créez une instance de la classe [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) .
2. Créez la première instance de la classe [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) .
3. Créez la deuxième instance de la classe [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) .
4. Appliquez les deux tracés à la forme.

Le code Python suivant montre comment créer une forme personnalisée composite :
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```


![Forme composite](custom_shape_4.png)

## **Créer des formes personnalisées avec coins arrondis**

Cette section montre comment dessiner une forme personnalisée avec des coins lisses en utilisant un tracé géométrique. Vous combinerez des segments droits et des arcs circulaires pour former le contour, puis ajouterez la forme finie à votre diapositive.

Le code Python suivant montre comment créer une forme personnalisée avec des coins arrondis :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```


![Coins arrondis](custom_shape_6.png)

## **Déterminer si la géométrie d’une forme est fermée**

Une forme fermée est définie comme une forme dont tous les côtés sont connectés, formant une seule bordure sans trous. Une telle forme peut être une forme géométrique simple ou un contour personnalisé complexe. L’exemple de code suivant montre comment vérifier si la géométrie d’une forme est fermée :
```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```


## **FAQ**

**Que se passe-t-il pour le remplissage et le contour après avoir remplacé la géométrie ?**

Le style reste attaché à la forme ; seul le contour change. Le remplissage et le contour sont appliqués automatiquement à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la propriété [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/rotation/) de la forme ; la géométrie pivote avec la forme car elle est liée au système de coordonnées de la forme elle‑même.

**Puis‑je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone de la [slide](/slides/fr/python-net/convert-powerpoint-to-png/) requise ou la [shape](/slides/fr/python-net/create-shape-thumbnails/) elle‑même vers un format raster ; cela simplifie le travail ultérieur avec des géométries lourdes.