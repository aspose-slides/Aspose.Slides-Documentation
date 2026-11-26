---
title: Personnaliser les formes de présentation en Python
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
- points de chemin
- points d'édition
- ajouter point
- supprimer point
- opération d'édition
- coin arrondi
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Créer et personnaliser des formes dans les présentations PowerPoint avec Aspose.Slides pour Python via .NET : chemins géométriques, coins arrondis, formes composites."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les formes de présentation dans Aspose.Slides en modifiant la géométrie des formes via les points d’édition et les chemins géométriques. Il montre comment travailler avec [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) pour modifier des formes existantes, effectuer des opérations de base d’édition de chemin, ajouter ou supprimer des points, et appliquer la géométrie mise à jour à une forme.

Il montre également comment créer des formes personnalisées et composites, construire des formes avec des coins arrondis, déterminer si une géométrie de forme est fermée, et extraire les éléments de forme pour une analyse de contour.

## **Modifier une forme à l’aide de points d’édition**

Dans PowerPoint, vous pouvez utiliser **Edit Points** pour modifier un carré :

* Déplacer un coin vers l’intérieur ou vers l’extérieur.
* Ajuster la courbure à un point.
* Ajouter de nouveaux points.

L’édition de points vous permet de modifier le contour d’une forme ou d’utiliser une forme existante comme base pour une nouvelle.

## **Conseils de modification de forme**

![overview_image](custom_shape_0.png)

Lorsque vous modifiez des formes PowerPoint, gardez ces concepts à l’esprit :

* Une forme (ou son chemin) peut être fermée ou ouverte.
* Le chemin d’une forme est composé de points d’ancrage reliés par des segments.
* Un segment peut être droit ou courbe. Les points d’ancrage et les poignées de contrôle déterminent sa forme.
* Les points d’ancrage existent sous forme de points de coin, points droits ou points lisses :
  * À un point de coin, les segments adjacents peuvent se rejoindre sous un angle.
  * À un point lisse, les deux poignées de contrôle sont alignées et à égale distance du point d’ancrage.
  * À un point droit, les deux poignées de contrôle sont alignées mais peuvent être à des distances différentes du point d’ancrage.
* Déplacer les points d’ancrage ou ajuster leurs poignées modifie le contour de la forme.

Pour éditer les formes PowerPoint via les points d’édition, **Aspose.Slides** fournit la classe [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Une instance de [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) représente le chemin géométrique de l’objet [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Pour récupérer le [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) depuis l’instance [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), vous pouvez utiliser la méthode [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Pour définir le [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) d’une forme, vous pouvez utiliser ces méthodes : [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) pour les formes à chemin unique et [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) pour les formes à chemins multiples.
* Pour ajouter des segments, vous pouvez utiliser les méthodes sous [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* En utilisant les propriétés [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) et [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/), vous pouvez définir l’apparence d’un chemin géométrique.
* En utilisant la propriété [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/), vous pouvez récupérer le chemin géométrique d’un [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) sous forme de tableau de segments de chemin.

## **Opérations d’édition simples**

Utilisez les méthodes suivantes pour éditer un chemin géométrique. Les surcharges qui acceptent un indice insèrent un segment à cette position zéro‑based dans le tableau des segments du chemin.

| Opération | Méthode |
| --- | --- |
| Ajouter ou insérer une ligne droite. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Ajouter ou insérer une courbe de Bézier cubique avec deux points de contrôle et un point final. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Ajouter ou insérer une courbe de Bézier quadratique avec un point de contrôle et un point final. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Ajouter un arc elliptique avec les dimensions et angles spécifiés en degrés. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Fermer la figure courante en reliant son point final à son point de départ. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Définir le point de départ d’une figure. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Supprimer un segment à un indice zéro‑based. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Ajouter des points personnalisés à une forme**

Cet exemple insère deux points dans une forme rectangulaire à l’aide de [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) et applique le chemin édité avec [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Les coordonnées sont locales à la forme : les deux nouveaux points sont au centre, à 100 points du bord gauche et à 50 points du bord supérieur. Les indices de segment 1 et 4 les placent respectivement sur les bords supérieur et inférieur, tirant ces bords vers l’intérieur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **Supprimer des points d’une forme**

Cet exemple modifie le contour d’une forme en forme de cœur en supprimant le segment à l’indice zéro‑based 2 avec [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). L’application du chemin modifié avec [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) met à jour le contour de la forme.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **Créer une forme personnalisée**

Cet exemple construit une étoile à cinq branches avec [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Des rayons extérieurs et intérieurs alternés de 100 et 50 points définissent les pointes et les retrous ; un pas de 72 degrés espace les cinq pointes de façon égale. Le chemin est fermé avec [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) et appliqué à une forme rectangulaire à l’aide de [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), remplaçant son contour.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **Créer une forme composite personnalisée**

Cet exemple définit deux [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) fermés pour le tiers supérieur et le tiers inférieur d’une forme. L’application des deux chemins avec [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) crée une seule forme composite comportant un espace à travers son tiers central.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **Créer une forme personnalisée avec des coins arrondis**

Cet exemple combine des segments droits avec [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) pour créer une forme dont les coins sont courbés vers l’intérieur. Chaque taille de coin définit la largeur et la hauteur de l’arc en points, et le balayage de ‑90 degrés dessine un quart d’ellipse dans le sens antihoraire. Le chemin complet est appliqué avec [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), et la présentation est enregistrée au format PPTX.

```python
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

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Déterminer si la géométrie d’une forme est fermée**

L’assistant suivant vérifie si chaque chemin géométrique non vide se termine par un segment de fermeture. Il lit [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) et compare la commande du dernier segment [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) avec [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Il retourne false lorsqu’il n’y a aucun chemin non vide. Cette vérification porte sur la commande finale de chaque chemin ; elle n’inspecte pas chaque sous‑figure à l’intérieur d’un chemin. L’exemple affiche `True` pour un rectangle.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **Inspecter les commandes de chemin géométrique**

Téléchargez [contour.pptx](contour.pptx) et placez‑le dans votre répertoire de travail. La première forme de la première diapositive possède un bord supérieur droit, une courbe de Bézier cubique et un bord de fermeture droit. Utilisez [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) pour lire ses chemins. Pour chaque chemin, [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) répertorie les segments dans l’ordre de dessin. La commande de chaque segment [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) détermine comment interpréter ses données [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/).

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

La forme se trouve aux coordonnées (200, 100) points sur la diapositive. Les coordonnées rapportées sont locales à la forme. Son coin supérieur gauche est (0, 0), x augmente vers la droite et y augmente vers le bas. Le segment de fermeture revient au point de départ sans coordonnées supplémentaires.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Extraire et inspecter les éléments de forme**

Utilisez [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) pour inspecter une forme existante sous forme d’éléments contenant les points de chemin et les types de points. Chaque [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) retourné expose ses tableaux [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) et [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Cette représentation est utile pour l’analyse de contour ou le passage de la géométrie à des outils de dessin personnalisés.

L’exemple ouvre une présentation, trouve la première forme géométrique directement sur la première diapositive, et affiche ses segments de chemin. Utilisez une présentation contenant une forme avec des segments droits et courbes pour voir les deux types de sortie. Il ne recherche pas à l’intérieur des groupes.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
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

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Les tableaux sont corrélés par indice : `points[i]` est un point et `types[i]` décrit son rôle. Le type `0` démarre une figure, et le type `1` trace une ligne du point précédent au point actuel. Un segment de Bézier cubique démarre au point final précédent et utilise trois entrées consécutives de type `3` : deux points de contrôle suivis du nouveau point final. La boucle consomme ces trois entrées ensemble et vérifie le point final pour la fermeture.

Les types de points contiennent aussi des drapeaux. Masquez avec `0x07` pour identifier le type de segment, et testez `0x80` séparément pour détecter un sous‑chemin fermé. Par exemple, `129` (`0x81`) signifie un point final de ligne qui ferme un sous‑chemin, et `131` (`0x83`) signifie un point final de Bézier qui en ferme un. Comparer la valeur brute uniquement à `1` ou `3` manquerait ces cas. D’autres drapeaux, comme le tiret (`0x10`) et le marqueur (`0x20`), ne changent pas le type de segment de base.

**Coordonnées et transformations.** Les points sont mesurés en points (1/72 pouce), X augmente vers la droite et Y augmente vers le bas. Pour une forme non groupée, les coordonnées extraites incluent déjà sa position [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) et [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) et reflètent sa largeur et hauteur actuelles. Par exemple, un rectangle non tourné à `(100, 200)` avec une taille de `120 × 80` a des limites de contour `(100, 200)`‑`(220, 280)`. N’ajoutez pas la position de la forme a nouveau. Soustrayez son X et Y pour obtenir des coordonnées relatives à son cadre non tourné.

Les points extraits n’appliquent pas la [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) de la forme ni les retournements horizontaux et verticaux. Pour reproduire le contour affiché, appliquez ces transformations autour du centre de la forme. Pour les formes groupées, tenez également compte du mappage des coordonnées du groupe et des transformations ; ne supposez pas que les points extraits sont les coordonnées finales rendues sur la diapositive ou appliquez une traduction ou une mise à l’échelle deux fois s’il est déjà reflété dans le cadre de l’enfant.

**Inspection versus édition.** Les tableaux extraits décrivent le contour ; les modifier ne met pas à jour la forme originale. Choisissez cette approche lorsque votre analyse ou votre code de dessin a besoin de tableaux point/type. Utilisez [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) lorsque vous avez besoin des commandes de géométrie dans le système de coordonnées local de la forme ou que vous souhaitez éditer sa géométrie. Appliquez les chemins édités via [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) ou [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **FAQ**

**Que se passe‑t‑il du remplissage et du contour après le remplacement de la géométrie ?**

Le style reste attaché à la forme ; seul le contour change. Le remplissage et le contour sont appliqués automatiquement à la nouvelle géométrie.

**Comment faire pivoter correctement une forme personnalisée avec sa géométrie ?**

Utilisez la propriété [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) de la forme ; la géométrie pivote avec la forme car elle est liée au système de coordonnées propre à la forme.

**Puis‑je convertir une forme personnalisée en image pour « verrouiller » le résultat ?**

Oui. Exportez la zone de la [slide](/slides/fr/python-net/convert-powerpoint-to-png/) requise ou la [shape](/slides/fr/python-net/create-shape-thumbnails/) elle‑même vers un format raster ; cela simplifie le travail ultérieur avec des géométries complexes.