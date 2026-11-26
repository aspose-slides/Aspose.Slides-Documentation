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
- points du chemin
- points d'édition
- ajouter point
- supprimer point
- opération d'édition
- coin arrondi
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour Python via Java : chemins géométriques, coins arrondis, formes composites."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les formes d’une présentation dans Aspose.Slides en modifiant la géométrie des formes à l’aide des points d’édition et des chemins géométriques. Il montre comment travailler avec [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) pour modifier des formes existantes, effectuer des opérations d’édition de base sur le chemin, ajouter ou supprimer des points, et appliquer la géométrie mise à jour à une forme.

Il montre également comment créer des formes personnalisées et composites, construire des formes aux coins arrondis, déterminer si la géométrie d’une forme est fermée, inspecter les éléments de forme, et convertir les contours de texte Java AWT en chemins géométriques.

## **Modifier une forme à l’aide des points d’édition**

Dans PowerPoint, vous pouvez utiliser **Edit Points** pour modifier un carré :

* Déplacer un coin vers l’intérieur ou l’extérieur.
* Ajuster la courbure à un point.
* Ajouter de nouveaux points.

La modification des points vous permet de changer le contour d’une forme ou d’utiliser une forme existante comme base pour une nouvelle.

## **Conseils pour la modification de forme**

![overview_image](custom_shape_0.png)

Lors de la modification des formes PowerPoint, gardez à l’esprit les concepts suivants :

* Une forme (ou son tracé) peut être fermée ou ouverte.
* Le tracé d’une forme est composé de points d’ancrage reliés par des segments.
* Un segment peut être droit ou courbe. Les points d’ancrage et les poignées de contrôle déterminent sa forme.
* Les points d’ancrage existent sous forme de points d’angle, de points droits ou de points lisses :
  * À un point d’angle, les segments adjacents peuvent se rejoindre sous un angle.
  * À un point lisse, les deux poignées de contrôle sont alignées et à égale distance du point d’ancrage.
  * À un point droit, les deux poignées de contrôle sont alignées mais peuvent être à des distances différentes du point d’ancrage.
* Déplacer les points d’ancrage ou ajuster leurs poignées modifie le contour de la forme.

Pour modifier les formes PowerPoint à l’aide de points d’édition, **Aspose.Slides** fournit la classe [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) représente un chemin géométrique de l’objet [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Pour récupérer le [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) depuis l’instance de [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), vous pouvez utiliser la méthode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Pour définir le [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) d’une forme, vous pouvez utiliser ces méthodes : [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) pour les formes avec un seul chemin et [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) pour les formes avec plusieurs chemins.
* Pour ajouter des segments, vous pouvez utiliser les méthodes sous [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* En utilisant les méthodes [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) et [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode), vous pouvez définir l’apparence d’un chemin géométrique.
* En utilisant la méthode [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData), vous pouvez récupérer le chemin géométrique d’un [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) sous forme de tableau de segments de chemin.
* Pour accéder à des options supplémentaires de personnalisation de la géométrie des formes, vous pouvez lire un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) via son [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) et rejouer les segments sur un [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Opérations d’édition simples**

Utilisez les méthodes suivantes pour éditer un chemin géométrique. Les surcharges qui acceptent un indice insèrent un segment à cette position, indexée à zéro, dans le tableau de segments du chemin.

| Opération | Méthode |
| --- | --- |
| Ajouter ou insérer une ligne droite. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Ajouter ou insérer une courbe de Bézier cubique avec deux points de contrôle et un point final. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Ajouter ou insérer une courbe de Bézier quadratique avec un point de contrôle et un point final. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Ajouter un arc elliptique avec les dimensions et angles spécifiés en degrés. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Fermer la figure actuelle en reliant son point final à son point de départ. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Définir le point de départ d’une figure. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Supprimer un segment à un indice indexé à zéro. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Ajouter des points personnalisés à une forme**

Cet exemple insère deux points dans une forme rectangulaire en utilisant [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) et applique le chemin modifié avec [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Les coordonnées sont locales à la forme : les deux nouveaux points se trouvent à son centre, à 100 points du bord gauche et 50 points du bord supérieur. Les indices de segment 1 et 4 les placent respectivement sur les bords supérieur et inférieur, tirant ces bords vers l’intérieur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **Supprimer des points d’une forme**

Cet exemple modifie le contour d’une forme en forme de cœur en supprimant le segment à l’indice 2 (indexé à zéro) avec [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Appliquer le chemin modifié avec [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) met à jour le contour de la forme.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Créer une forme personnalisée**

Cet exemple construit une étoile à cinq branches avec [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Des rayons extérieurs et intérieurs alternés de 100 et 50 points définissent les pointes et les enfoncements ; un pas de 72 degrés espace uniformément les cinq pointes. Le chemin est fermé avec [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) et appliqué à une forme rectangulaire à l’aide de [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), remplaçant son contour.

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
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Créer une forme personnalisée composite**

Cet exemple définit deux objets [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) fermés pour le tiers supérieur et le tiers inférieur d’une forme. Appliquer les deux chemins avec [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) crée une forme composite unique avec une ouverture au milieu du tiers central.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

## **Créer une forme personnalisée avec des coins arrondis**

Cet exemple combine des segments droits avec [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) pour créer une forme aux coins incurvés vers l’intérieur. La taille de chaque coin définit la largeur et la hauteur de l’arc en points, et le balayage de -90 degrés trace un quart d’ellipse dans le sens inverse des aiguilles d’une montre. Le chemin complété est appliqué avec [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), et la présentation est enregistrée au format PPTX.

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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

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

## **Déterminer si la géométrie d’une forme est fermée**

L’assistant suivant vérifie si chaque chemin géométrique non vide se termine par un segment de fermeture. Il lit [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) et compare la commande du segment final [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) avec [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Il renvoie `False` lorsqu’il n’y a aucun chemin non vide. Cette vérification porte sur la commande finale de chaque chemin ; elle n’inspecte pas chaque sous‑figure à l’intérieur d’un chemin. L’exemple affiche `True` pour un rectangle.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **Inspecter les commandes du chemin géométrique**

Téléchargez [contour.pptx](contour.pptx) et placez‑le dans le répertoire de travail de l’application. La première forme de la première diapositive possède un bord supérieur droit, une courbe de Bézier cubique et un bord de clôture droit. Utilisez [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) pour lire les chemins de la forme et [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) pour lire les segments de chaque chemin dans l’ordre de dessin. Pour chaque segment, [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) identifie la commande et détermine comment interpréter les valeurs renvoyées par [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

La forme se trouve à (200, 100) points sur la diapositive. Les coordonnées rapportées sont locales à la forme, avec (0, 0) en haut à gauche, x augmentant vers la droite et y augmentant vers le bas. Le segment de fermeture revient au point de départ sans coordonnées supplémentaires.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Forme PowerPoint avec un bord supérieur droit, un bord courbe du coin supérieur droit au coin inférieur gauche, et un bord gauche droit](contour.png)

## **Extraire et inspecter les éléments de forme**

Utilisez [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) pour inspecter une forme existante en tant qu’éléments contenant des points de chemin et des types de points. Convertissez chaque élément retourné en [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) avec `jpype.JObject` afin de récupérer les tableaux de points et de types via les méthodes [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) et [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Cette représentation est utile pour l’analyse de contours ou le passage de la géométrie à des outils de dessin personnalisés.

L’exemple ouvre input.pptx, trouve la première forme géométrique directement sur la première diapositive, et affiche ses segments de chemin. Utilisez une présentation contenant une forme avec des segments droits et courbes pour voir les deux types de sortie. Il ne recherche pas à l’intérieur des groupes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Conserver le type de segment, en excluant les drapeaux.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consommer les deux points de contrôle et le point final.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Les tableaux correspondent par index : `points[i]` est un point et `types[i]` décrit son rôle. Le type `0` commence une figure, et le type `1` trace une ligne du point précédent au point actuel. Un segment de Bézier cubique commence au point final précédent et utilise trois entrées consécutives de type `3` : deux points de contrôle suivis du nouveau point final. La boucle consomme ces trois entrées ensemble et vérifie la fermeture du point final.

Les types de points contiennent également des drapeaux. Masquez avec `0x07` pour identifier le type de segment, et testez `0x80` séparément pour détecter un sous‑chemin fermé. Par exemple, `129` (`0x81`) indique un point final de ligne qui ferme un sous‑chemin, et `131` (`0x83`) indique un point final de Bézier qui en ferme un. Java stocke ces drapeaux dans des octets signés ; le masquage préserve les valeurs de bits prévues. Comparer la valeur brute uniquement à `1` ou `3` manquerait ces cas. D’autres drapeaux, comme le tiret (`0x10`) et le marqueur (`0x20`), ne modifient pas le type de segment de base.

**Coordonnées et transformations.** Les points sont mesurés en points (1/72 pouce), X augmentant vers la droite et Y augmentant vers le bas. Pour une forme non groupée, les coordonnées extraites intègrent déjà la position renvoyée par [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) et [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) et reflètent sa largeur et hauteur actuelles. Par exemple, un rectangle non pivoté à `(100, 200)` avec une taille de `120 × 80` a des limites de contour `(100, 200)`–`(220, 280)`. N’ajoutez pas de nouveau la position de la forme. Soustrayez son X et Y pour obtenir des coordonnées relatives à son cadre non pivoté.

Les points extraits n’appliquent pas la rotation de la forme, renvoyée par [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), ni les retournements horizontaux et verticaux. Pour reproduire le contour affiché, appliquez ces transformations autour du centre de la forme. Pour les formes groupées, tenez également compte du mappage des coordonnées du groupe et des transformations ; ne supposez pas que les points extraits soient les coordonnées finales rendues sur la diapositive ou n’appliquez pas une translation ou une mise à l’échelle deux fois si elle est déjà reflétée dans le cadre de l’enfant.

**Inspection versus édition.** Les tableaux extraits décrivent le contour ; les modifier ne met pas à jour la forme originale. Choisissez cette approche lorsque votre code d’analyse ou de dessin a besoin de tableaux points/types. Utilisez [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) lorsque vous avez besoin des commandes géométriques dans le système de coordonnées local de la forme ou que vous souhaitez éditer sa géométrie. Appliquez les chemins modifiés via [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ou [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Convertir une forme Java AWT en GeometryPath**

Cet exemple combine un contour rectangulaire avec du texte converti en géométrie. La méthode [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) du contour désactive son remplissage. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) crée le contour du texte dans un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Son [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fournit des segments de type move, line, quadratic, cubic et de fermeture, que l’exemple rejoue sur un [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Le texte utilise une police Arial de 40 points. Le contour est décalé de 20 points horizontalement et positionné avec son sommet visuel 10 points sous le bord supérieur de la forme. Le chemin du texte est rempli, tandis que le rectangle original reste un contour. Appliquer les deux chemins avec [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) produit une seule forme contenant le rectangle et le texte.

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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Obtenir le chemin géométrique de la forme.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Créer un nouveau chemin graphique avec le texte.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
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

**Que se passe-t-il pour le remplissage et le contour après avoir remplacé la géométrie ?**

Le style reste associé à la forme ; seul le contour change. Le remplissage et le contour sont automatiquement appliqués à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la méthode [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) de la forme ; la géométrie pivote avec la forme car elle est liée au système de coordonnées propre de la forme.

**Puis‑je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone de [diapositive](/slides/fr/python-java/convert-powerpoint-to-png/) requise ou la [forme](/slides/fr/python-java/create-shape-thumbnails/) elle‑même vers un format raster ; cela simplifie le travail ultérieur avec des géométries complexes.