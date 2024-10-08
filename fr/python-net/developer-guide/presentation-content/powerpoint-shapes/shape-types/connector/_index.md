---
title: Connecteur
type: docs
weight: 10
url: /fr/python-net/connector/
keywords: "Connecter des formes, connecteurs, formes PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Connecter des formes PowerPoint en Python"
---

Un connecteur PowerPoint est une ligne spéciale qui connecte ou relie deux formes ensemble et reste attachée aux formes même lorsqu'elles sont déplacées ou repositionnées sur une diapositive donnée.

Les connecteurs sont généralement connectés à des *points de connexion* (points verts), qui existent sur toutes les formes par défaut. Les points de connexion apparaissent lorsqu'un curseur s'en approche.

Des *points d'ajustement* (points orange), qui existent uniquement sur certains connecteurs, sont utilisés pour modifier les positions et les formes des connecteurs.

## **Types de connecteurs**

Dans PowerPoint, vous pouvez utiliser des connecteurs droits, en coude (angulaires) et courbés.

Aspose.Slides fournit ces connecteurs :

| Connecteur                      | Image                                                        | Nombre de points d'ajustement |
| ------------------------------- | ------------------------------------------------------------ | ------------------------------ |
| `ShapeType.LINE`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                              |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                              |
| `ShapeType.BENT_CONNECTOR2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                              |
| `ShapeType.BENT_CONNECTOR3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                              |
| `ShapeType.BENT_CONNECTOR4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                              |
| `ShapeType.BENT_CONNECTOR5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                              |
| `ShapeType.CURVED_CONNECTOR2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                              |
| `ShapeType.CURVED_CONNECTOR3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                              |
| `ShapeType.CURVED_CONNECTOR4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                              |
| `ShapeType.CURVED_CONNECTOR5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                              |

## **Connecter des formes à l'aide de connecteurs**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive via son index.
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive en utilisant la méthode `add_auto_shape` exposée par l'objet `Shapes`.
1. Ajoutez un connecteur en utilisant la méthode `add_auto_shape` exposée par l'objet `Shapes` en définissant le type de connecteur.
1. Connectez les formes en utilisant le connecteur.
1. Appelez la méthode `reroute` pour appliquer le chemin de connexion le plus court.
1. Enregistrez la présentation.

Ce code Python vous montre comment ajouter un connecteur (un connecteur coudé) entre deux formes (une ellipse et un rectangle) :

```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier PPTX
with slides.Presentation() as input:
    # Accède à la collection de formes pour une diapositive spécifique
    shapes = input.slides[0].shapes

    # Ajoute une autoshape Ellipse
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Ajoute une autoshape Rectangle
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 300, 100, 100)

    # Ajoute une forme de connecteur à la collection de formes de la diapositive
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Connecte les formes à l'aide du connecteur
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Appelle reroute qui définit le chemin automatique le plus court entre les formes
    connector.reroute()

    # Enregistre la présentation
    input.save("Connecting shapes using connectors_out.pptx", slides.export.SaveFormat.PPTX)

```

{{%  alert title="REMARQUE"  color="warning"   %}} 

La méthode `connector.reroute` reroute un connecteur et l'oblige à prendre le chemin le plus court possible entre les formes. Pour atteindre cet objectif, la méthode peut changer les points `start_shape_connection_site_index` et `end_shape_connection_site_index`. 

{{% /alert %}} 

## **Spécifier le point de connexion**

Si vous souhaitez qu'un connecteur relie deux formes en utilisant des points spécifiques sur les formes, vous devez spécifier vos points de connexion préférés de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive via son index.
1. Ajoutez deux [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) à la diapositive en utilisant la méthode `add_auto_shape` exposée par l'objet `Shapes`.
1. Ajoutez un connecteur en utilisant la méthode `add_connector` exposée par l'objet `Shapes` en définissant le type de connecteur.
1. Connectez les formes en utilisant le connecteur. 
1. Définissez vos points de connexion préférés sur les formes. 
1. Enregistrez la présentation.

Ce code Python démontre une opération où un point de connexion préféré est spécifié :

```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier PPTX
with slides.Presentation() as presentation:
    # Accède à la collection de formes pour une diapositive spécifique
    shapes = presentation.slides[0].shapes

    # Ajoute une forme de connecteur à la collection de formes de la diapositive
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Ajoute une autoshape Ellipse
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Ajoute une autoshape Rectangle
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 100, 100)

    # Connecte les formes à l'aide du connecteur
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Définit l'index du point de connexion préféré sur la forme Ellipse
    wantedIndex = 6

    # Vérifie si l'index préféré est inférieur au nombre maximum de sites d'index
    if ellipse.connection_site_count > wantedIndex:
        # Définit le point de connexion préféré sur l'autoshape Ellipse
        connector.start_shape_connection_site_index = wantedIndex

    # Enregistre la présentation
    presentation.save("Connecting_Shape_on_desired_connection_site_out.pptx", slides.export.SaveFormat.PPTX)

```

## **Ajuster le point du connecteur**

Vous pouvez ajuster un connecteur existant via ses points d'ajustement. Seuls les connecteurs avec des points d'ajustement peuvent être modifiés de cette manière. Consultez le tableau sous **[Types de connecteurs.](/slides/fr/python-net/connector/#types-of-connectors)** 

#### **Cas simple**

Considérons un cas où un connecteur entre deux formes (A et B) passe par une troisième forme (C) :

![connector-obstruction](connector-obstruction.png)

Code :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    sld = pres.slides[0]
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shapeFrom
    connector.end_shape_connected_to = shapeTo
    connector.start_shape_connection_site_index = 2
```

Pour éviter ou contourner la troisième forme, nous pouvons ajuster le connecteur en déplaçant sa ligne verticale vers la gauche de cette manière :

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```python
    adj2 = connector.adjustments[1]
    adj2.raw_value += 10000
```

### **Cas complexes** 

Pour effectuer des ajustements plus compliqués, vous devez prendre en compte ces éléments :

* Un point d'ajustement d'un connecteur est fortement lié à une formule qui calcule et détermine sa position. Ainsi, des modifications à l'emplacement du point peuvent altérer la forme du connecteur.
* Les points d'ajustement d'un connecteur sont définis dans un ordre strict dans un tableau. Les points d'ajustement sont numérotés depuis le point de départ d'un connecteur jusqu'à son point d'arrivée.
* Les valeurs des points d'ajustement reflètent le pourcentage de la largeur/hauteur d'une forme de connecteur. 
  * La forme est délimitée par les points de départ et d'arrivée du connecteur multipliés par 1000. 
  * Le premier point, le deuxième point et le troisième point définissent respectivement le pourcentage de la largeur, le pourcentage de la hauteur et le pourcentage de la largeur (à nouveau).
* Pour les calculs qui déterminent les coordonnées des points d'ajustement d'un connecteur, vous devez tenir compte de la rotation du connecteur et de sa réflexion. **Remarque** que l'angle de rotation pour tous les connecteurs montrés sous **[Types de connecteurs](/slides/fr/python-net/connector/#types-of-connectors)** est 0.

#### **Cas 1**

Considérons un cas où deux objets de cadre de texte sont liés ensemble par un connecteur :

![connector-shape-complex](connector-shape-complex.png)

Code :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie une classe de présentation qui représente un fichier PPTX
with slides.Presentation() as pres:
    # Obtient la première diapositive de la présentation
    sld = pres.slides[0]
    # Ajoute des formes qui seront reliées ensemble par un connecteur
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shapeFrom.text_frame.text = "De"
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shapeTo.text_frame.text = "À"
    # Ajoute un connecteur
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Spécifie la direction du connecteur
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Spécifie la couleur du connecteur
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Spécifie l'épaisseur de la ligne du connecteur
    connector.line_format.width = 3

    # Lie les formes ensemble avec le connecteur
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shapeTo
    connector.end_shape_connected_to = 2

    # Obtient les points d'ajustement pour le connecteur
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
```

**Ajustement**

Nous pouvons changer les valeurs des points d'ajustement du connecteur en augmentant le pourcentage de largeur et de hauteur correspondants de 20 % et 200 %, respectivement :

```python
    # Change les valeurs des points d'ajustement
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

Le résultat :

![connector-adjusted-1](connector-adjusted-1.png)

Pour définir un modèle qui nous permet de déterminer les coordonnées et la forme des parties individuelles du connecteur, créons une forme qui correspond à la composante horizontale du connecteur au point connector.adjustments[0] :

```python
    # Dessine la composante verticale du connecteur

    x = connector.x + connector.width * adjValue_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjValue_1.raw_value / 100000
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Le résultat :

![connector-adjusted-2](connector-adjusted-2.png)

#### **Cas 2**

Dans **le Cas 1**, nous avons démontré une opération d'ajustement de connecteur simple en utilisant des principes de base. Dans des situations normales, vous devez prendre en compte la rotation et l'affichage du connecteur (qui sont réglés par connector.rotation, connector.frame.flip_h et connector.frame.flip_v). Nous allons maintenant démontrer le processus.

Tout d'abord, ajoutons un nouvel objet de cadre de texte (**À 1**) à la diapositive (pour des raisons de connexion) et créons un nouveau connecteur (vert) qui le relie aux objets que nous avons déjà créés.

```python
    # Crée un nouvel objet de liaison
    shapeTo_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shapeTo_1.text_frame.text = "À 1"
    # Crée un nouveau connecteur
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    # Connecte les objets à l'aide du nouveau connecteur
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shapeTo_1
    connector.end_shape_connected_site_index = 3
    # Obtient les points d'ajustement du connecteur
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
    # Change les valeurs des points d'ajustement 
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

Le résultat :

![connector-adjusted-3](connector-adjusted-3.png)

Deuxièmement, créons une forme qui correspondra à la composante horizontale du connecteur qui passe par le point d'ajustement connector.adjustments[0]. Nous utiliserons les valeurs des données du connecteur pour connector.rotation, connector.frame.flip_h et connector.frame.flip_v et appliquerons la formule de conversion de coordonnées populaire pour une rotation autour d'un point donné x0 :

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Dans notre cas, l'angle de rotation de l'objet est de 90 degrés et le connecteur est affiché verticalement, donc voici le code correspondant :

```python
    # Sauvegarde les coordonnées du connecteur
    x = connector.x
    y = connector.y
    # Corrige les coordonnées du connecteur au cas où elles apparaîtraient
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Prend la valeur du point d'ajustement comme coordonnée
    x += connector.width * adjValue_0.raw_value / 100000
    
    #  Convertit les coordonnées puisque Sin(90) = 1 et Cos(90) = 0
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Détermine la largeur de la composante horizontale en utilisant la valeur du deuxième point d'ajustement
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Le résultat :

![connector-adjusted-4](connector-adjusted-4.png)

Nous avons démontré des calculs impliquant des ajustements simples et des points d'ajustement compliqués (points d'ajustement avec des angles de rotation). En utilisant les connaissances acquises, vous pouvez développer votre propre modèle (ou écrire un code) pour obtenir un objet `GraphicsPath` ou même définir les valeurs des points d'ajustement d'un connecteur en fonction des coordonnées spécifiques de la diapositive.

## **Trouver l'angle des lignes de connecteur**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive via son index.
1. Accédez à la forme de ligne de connecteur.
1. Utilisez la largeur de ligne, la hauteur, la hauteur de cadre de forme et la largeur de cadre de forme pour calculer l'angle.

Ce code Python démontre une opération dans laquelle nous avons calculé l'angle pour une forme de ligne de connecteur :

```python
import aspose.slides as slides
import math

def get_direction(w, h, flipH, flipV):
    endLineX = w * (-1 if flipH else 1)
    endLineY = h * (-1 if flipV else 1)
    endYAxisX = 0
    endYAxisY = h
    angle = math.atan2(endYAxisY, endYAxisX) - math.atan2(endLineY, endLineX)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation(path + "ConnectorLineAngle.pptx") as pres:
    slide = pres.slides[0]
    for i in range(len(slide.shapes)):
        dir = 0.0
        shape = slide.shapes[i]
        if (type(shape) is slides.AutoShape):
            if shape.shape_type == slides.ShapeType.LINE:
                dir = get_direction(shape.width, shape.Height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            dir = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)

        print(dir)

```