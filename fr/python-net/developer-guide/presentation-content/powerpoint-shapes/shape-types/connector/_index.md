---
title: Gérer les connecteurs dans les présentations avec Python
linktitle: Connecteur
type: docs
weight: 10
url: /fr/python-net/connector/
keywords:
- connecteur
- type de connecteur
- point de connexion
- ligne de connexion
- angle du connecteur
- connecter des formes
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Permettre aux applications Python de dessiner, connecter et router automatiquement les lignes dans les diapositives PowerPoint & OpenDocument — obtenez un contrôle total sur les connecteurs droits, coudés et courbes."
---

## **Introduction**

Un connecteur PowerPoint est une ligne spécialisée qui relie deux formes et reste attachée lorsque les formes sont déplacées ou repositionnées sur une diapositive. Les connecteurs s’attachent aux **points de connexion** (points verts) sur les formes. Les points de connexion apparaissent lorsque le pointeur s’en approche. Les **poignées d’ajustement** (points jaunes), disponibles sur certains connecteurs, vous permettent de modifier la position et la forme du connecteur.

## **Types de connecteur**

Dans PowerPoint, vous pouvez utiliser trois types de connecteurs : droit, coudé (anglé) et courbe.

Aspose.Slides prend en charge les types de connecteurs suivants :

| Type de connecteur               | Image                                                     | Nombre de points d’ajustement |
| -------------------------------- | ---------------------------------------------------------- | ------------------------------ |
| `ShapeType.LINE`                 | ![Connecteur linéaire](shapetype-lineconnector.png)       | 0                              |
| `ShapeType.STRAIGHT_CONNECTOR1`  | ![Connecteur droit 1](shapetype-straightconnector1.png)   | 0                              |
| `ShapeType.BENT_CONNECTOR2`      | ![Connecteur coudé 2](shapetype-bent-connector2.png)      | 0                              |
| `ShapeType.BENT_CONNECTOR3`      | ![Connecteur coudé 3](shapetype-bentconnector3.png)       | 1                              |
| `ShapeType.BENT_CONNECTOR4`      | ![Connecteur coudé 4](shapetype-bentconnector4.png)       | 2                              |
| `ShapeType.BENT_CONNECTOR5`      | ![Connecteur coudé 5](shapetype-bentconnector5.png)       | 3                              |
| `ShapeType.CURVED_CONNECTOR2`    | ![Connecteur courbe 2](shapetype-curvedconnector2.png)    | 0                              |
| `ShapeType.CURVED_CONNECTOR3`    | ![Connecteur courbe 3](shapetype-curvedconnector3.png)    | 1                              |
| `ShapeType.CURVED_CONNECTOR4`    | ![Connecteur courbe 4](shapetype-curvedconnector4.png)    | 2                              |
| `ShapeType.CURVED_CONNECTOR5`    | ![Connecteur courbe 5](shapetype.curvedconnector5.png)    | 3                              |

## **Connecter des formes avec des connecteurs**

Cette section montre comment lier des formes avec des connecteurs dans Aspose.Slides. Vous ajouterez un connecteur à une diapositive, puis attacherez son début et sa fin aux formes cibles. L’utilisation de sites de connexion garantit que le connecteur reste « collé » aux formes même lorsqu’elles sont déplacées ou redimensionnées.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son indice.
3. Ajoutez deux objets [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive à l’aide de la méthode `add_auto_shape` exposée par l’objet [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Ajoutez un connecteur à l’aide de la méthode `add_connector` exposée par l’objet [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) et spécifiez le type de connecteur.
5. Reliez les formes avec le connecteur.
6. Appelez la méthode `reroute` pour appliquer le chemin de connexion le plus court.
7. Enregistrez la présentation.

Le code Python suivant montre comment ajouter un connecteur coudé entre deux formes (une ellipse et un rectangle) :

```python
import aspose.slides as slides

# Instancier la classe Presentation pour créer un fichier PPTX.
with slides.Presentation() as presentation:

    # Accéder à la collection de formes de la première diapositive.
    shapes = presentation.slides[0].shapes

    # Ajouter une forme AutoShape ellipse.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Ajouter une forme AutoShape rectangle.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Ajouter un connecteur à la diapositive.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Relier les formes avec le connecteur.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Appeler reroute pour définir le chemin le plus court.
    connector.reroute()

    # Enregistrer la présentation.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

La méthode `connector.reroute` re‑route un connecteur, le forçant à emprunter le chemin le plus court possible entre les formes. Pour ce faire, la méthode peut modifier les valeurs `start_shape_connection_site_index` et `end_shape_connection_site_index`.

{{% /alert %}}

## **Spécifier les points de connexion**

Cette section explique comment attacher un connecteur à un point de connexion précis sur une forme dans Aspose.Slides. En ciblant des sites de connexion exacts, vous pouvez contrôler le routage et la disposition du connecteur, produisant des diagrammes propres et prévisibles dans vos présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son indice.
3. Ajoutez deux objets [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive via la méthode `add_auto_shape` de [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Ajoutez un connecteur avec la méthode `add_connector` sur [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) et spécifiez le type de connecteur.
5. Reliez les formes avec le connecteur.
6. Définissez les points de connexion souhaités sur les formes.
7. Enregistrez la présentation.

Le code Python suivant montre comment spécifier un point de connexion préféré :

```python
import aspose.slides as slides

# Instancier la classe Presentation pour créer un fichier PPTX.
with slides.Presentation() as presentation:

    # Accéder à la collection de formes de la première diapositive.
    shapes = presentation.slides[0].shapes

    # Ajouter une forme AutoShape ellipse.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Ajouter une forme AutoShape rectangle.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Ajouter un connecteur à la collection de formes de la diapositive.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Relier les formes avec le connecteur.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Définir l’indice du site de connexion préféré sur l’ellipse.
    site_index = 6

    # Vérifier que l’indice préféré est dans la plage disponible.
    if ellipse.connection_site_count > site_index:
        # Affecter le site de connexion préféré sur l’ellipse AutoShape.
        connector.start_shape_connection_site_index = site_index

    # Enregistrer la présentation.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajuster les points du connecteur**

Vous pouvez modifier les connecteurs à l’aide de leurs points d’ajustement. Seuls les connecteurs qui exposent des points d’ajustement peuvent être édités de cette façon. Pour connaître les connecteurs qui supportent les ajustements, consultez le tableau sous **Types de connecteur**.

### **Cas simple**

Considérez une situation où un connecteur entre deux formes (A et B) intersecte une troisième forme (C) :

![Obstruction du connecteur](connector-obstruction.png)

Exemple de code :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

Pour éviter la troisième forme, ajustez le connecteur en déplaçant son segment vertical vers la gauche :

![Obstruction du connecteur corrigée](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Cas complexes**

Pour des ajustements plus avancés, considérez les points suivants :

- Un point d’ajustement du connecteur est régi par une formule qui détermine sa position. Modifier ce point peut changer la forme globale du connecteur.
- Les points d’ajustement du connecteur sont stockés dans un tableau strictement ordonné, numéroté du début vers la fin du connecteur.
- Les valeurs des points d’ajustement représentent des pourcentages de la largeur/hauteur de la forme du connecteur.
  - La forme est bornée par les points de début et de fin du connecteur et mise à l’échelle par 1000.
  - Le premier, deuxième et troisième points d’ajustement représentent respectivement : pourcentage de largeur, pourcentage de hauteur et à nouveau pourcentage de largeur.
- Lors du calcul des coordonnées des points d’ajustement, il faut tenir compte de la rotation et du retournement du connecteur. **Remarque :** pour tous les connecteurs listés sous **Types de connecteur**, l’angle de rotation est 0.

#### **Cas 1**

Considérez une situation où deux objets de zone de texte sont reliés par un connecteur :

![Formes liées](connector-shape-complex.png)

Exemple de code :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation pour créer un fichier PPTX.
with slides.Presentation() as presentation:

    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Créer la forme de départ.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Ajouter un connecteur.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Définir la direction du connecteur.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Définir la couleur du connecteur.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Définir l’épaisseur de la ligne du connecteur.
    connector.line_format.width = 3

    # Lier les formes avec le connecteur.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Obtenir les points d’ajustement du connecteur.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Ajustement**

Modifiez les valeurs des points d’ajustement du connecteur en augmentant le pourcentage de largeur de 20 % et le pourcentage de hauteur de 200 % :

```python
    # Modifier les valeurs des points d’ajustement.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Résultat :

![Ajustement du connecteur 1](connector-adjusted-1.png)

Pour définir un modèle qui permette de déterminer les coordonnées et la forme des segments du connecteur, créez une forme qui correspond à la composante verticale du connecteur à `connector.adjustments[0]` :

```python
    # Dessiner la composante verticale du connecteur.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Résultat :

![Ajustement du connecteur 2](connector-adjusted-2.png)

#### **Cas 2**

Dans le **Cas 1**, nous avons montré un ajustement simple du connecteur en appliquant des principes de base. Dans des scénarios typiques, il faut également tenir compte de la rotation du connecteur et de ses paramètres d’affichage (`connector.rotation`, `connector.frame.flip_h` et `connector.frame.flip_v`). Voici comment procéder.

1. Ajoutez un nouvel objet de zone de texte (**To 1**) à la diapositive (pour la connexion) et créez un nouveau connecteur vert qui le relie aux objets existants.

```python
    # Créer un nouvel objet cible.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Créer un nouveau connecteur.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Connecter les objets avec le nouveau connecteur.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Obtenir les points d’ajustement du connecteur.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Modifier les valeurs des points d’ajustement.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Résultat :

![Ajustement du connecteur 3](connector-adjusted-3.png)

2. Créez une forme qui correspond au segment **horizontal** du connecteur traversant le point d’ajustement `connector.adjustments[0]`. Utilisez les valeurs de `connector.rotation`, `connector.frame.flip_h` et `connector.frame.flip_v`, puis appliquez la formule de conversion de coordonnées pour une rotation autour d’un point `x0` :

```
X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;
```

Dans notre cas, l’angle de rotation de l’objet est de 90° et le connecteur est affiché verticalement, le code correspondant est :

```python
    # Sauvegarder les coordonnées du connecteur.
    x = connector.x
    y = connector.y
    
    # Corriger les coordonnées si le connecteur est retourné.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Utiliser la valeur du point d’ajustement comme coordonnée.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Convertir les coordonnées car sin(90°) = 1 et cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Déterminer la largeur du segment horizontal à l’aide du second point d’ajustement.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Résultat :

![Ajustement du connecteur 4](connector-adjusted-4.png)

Nous avons démontré les calculs impliquant des ajustements simples et des points d’ajustement plus complexes (qui tiennent compte de la rotation). En vous appuyant sur ces connaissances, vous pouvez développer votre propre modèle — ou écrire du code — pour obtenir un objet `GraphicsPath` ou même définir les valeurs des points d’ajustement d’un connecteur en fonction de coordonnées précises de la diapositive.

## **Trouver les angles des lignes de connecteur**

Utilisez l’exemple ci‑dessous pour déterminer l’angle des lignes de connecteur sur une diapositive avec Aspose.Slides. Vous apprendrez à lire les extrémités d’un connecteur et à calculer son orientation afin d’aligner précisément les flèches, les étiquettes et les autres formes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son indice.
3. Accédez à la forme de ligne du connecteur.
4. Utilisez la largeur et la hauteur de la ligne, ainsi que la largeur et la hauteur du cadre de forme, pour calculer l’angle.

Le code Python suivant montre comment calculer l’angle d’une forme de ligne de connecteur :

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **FAQ**

**Comment savoir si un connecteur peut être « collé » à une forme spécifique ?**

Vérifiez que la forme expose des [sites de connexion](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/). S’il n’y en a aucun ou si le compteur est à zéro, le collage n’est pas disponible ; dans ce cas, utilisez des extrémités libres et positionnez‑les manuellement. Il est judicieux de vérifier le nombre de sites avant d’attacher le connecteur.

**Que se passe‑t‑il lorsqu’on supprime l’une des formes connectées à un connecteur ?**

Ses extrémités seront détachées ; le connecteur reste sur la diapositive en tant que ligne ordinaire avec un début/fin libres. Vous pouvez soit le supprimer, soit réattribuer les connexions et, si nécessaire, appeler [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/).

**Les liaisons de connecteur sont‑elles conservées lors de la copie d’une diapositive vers une autre présentation ?**

En principe oui, à condition que les formes cibles soient également copiées. Si la diapositive est insérée dans un autre fichier sans les formes connectées, les extrémités deviennent libres et vous devrez les rattacher à nouveau.