---
title: Gérer les connecteurs dans les présentations avec Python
linktitle: Connecteur
type: docs
weight: 10
url: /fr/python-net/connector/
keywords:
- connecteur
- type de connecteur
- point de connecteur
- ligne de connecteur
- angle du connecteur
- site de connexion
- point d'ajustement
- connecter des formes
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment ajouter, attacher, rerouter, ajuster et inspecter les connecteurs PowerPoint droits, coudés et courbes avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Un connecteur est une ligne qui peut rester attachée à deux formes lorsque l'une ou l'autre se déplace. Ses extrémités se fixent à des sites de connexion, représentés par des points verts dans PowerPoint. Certains connecteurs coudés et courbes exposent également des points d’ajustement, représentés par des points orange, qui contrôlent la position des segments individuels du connecteur.

Aspose.Slides représente les connecteurs via l’interface [IConnector](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iconnector/). Vous pouvez les créer, attacher leurs extrémités à des formes, choisir des sites de connexion, les rerouter et modifier la géométrie des connecteurs qui possèdent des points d’ajustement.

## **Types de connecteur**

L’énumération [ShapeType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapetype/) comprend des préréglages de connecteurs droits, coudés et courbes. Le tableau suivant indique les géométries de connecteur disponibles et le nombre de points d’ajustement définis par chaque préréglage.

| Connecteur | Image | Nombre de points d'ajustement |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Le nombre et la signification des points d’ajustement font partie du préréglage de connecteur sélectionné. Ne supposez pas que deux types de connecteur différents exposent la même disposition de collection.

## **Connecter deux formes**

Utilisez [IShapeCollection.add_connector](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ishapecollection/add_connector/) pour ajouter un connecteur, et attribuez ses propriétés [start_shape_connected_to](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iconnector/start_shape_connected_to/) et [end_shape_connected_to](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iconnector/end_shape_connected_to/). Une fois les deux extrémités attachées, [IConnector.reroute](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iconnector/reroute/) sélectionne un trajet court entre les formes.

L’exemple suivant relie une ellipse et un rectangle avec un connecteur coudé :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Avertissement" %}}
L’appel à `reroute` peut modifier les valeurs [start_shape_connection_site_index](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) et [end_shape_connection_site_index](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iconnector/end_shape_connection_site_index/). Attribuez des sites de connexion spécifiques après le reroutage si ces sites doivent rester fixes.
{{% /alert %}}

## **Choisir un site de connexion**

Chaque forme connectable indique son nombre de sites via [connection_site_count](https://reference.aspose.com/slides/fr/python-net/aspose.slides/igeometryshape/connection_site_count/). Validez un indice de site basé zéro préféré avant de l’attribuer à une extrémité de connecteur ; le nombre de sites varie selon la géométrie de la forme.

Cet exemple attache le connecteur à un site particulier sur l’ellipse lorsque ce site existe :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajuster un point de connecteur**

Les connecteurs avec points d’ajustement les exposent via [IGeometryShape.adjustments](https://reference.aspose.com/slides/fr/python-net/aspose.slides/igeometryshape/adjustments/). Examinez chaque [IAdjustValue](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iadjustvalue/) et vérifiez son [type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iadjustvalue/type/) avant de modifier son [raw_value](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iadjustvalue/raw_value/). Pour la manipulation générale de formes, voir [Shape Manipulation](/slides/fr/python-net/shape-manipulations/).

Le nombre, l’ordre, la signification et la plage de valeurs valides des ajustements de connecteur dépendent du préréglage du connecteur. La propriété `type` est en lecture seule, tandis que la valeur d’ajustement est modifiable. La propriété en lecture seule [name](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iadjustvalue/name/) fournit une identification supplémentaire lorsqu’un connecteur contient plusieurs ajustements du même type sémantique.

### **Contourner un obstacle**

Dans la disposition suivante, un connecteur `ShapeType.BENT_CONNECTOR5` entre deux formes passe à travers une troisième forme :

![connector-obstruction](connector-obstruction.png)

Ce code crée le connecteur obstrué :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

Déplacer la courbe verticale modifie le trajet de façon à ce que le connecteur contourne l’obstacle :

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Plutôt que de supposer que l’indice de collection `1` représente toujours la courbe verticale, cet exemple recherche `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` et ne le modifie que lorsque le type sémantique attendu est présent :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

Un `ShapeType.BENT_CONNECTOR5` possède deux ajustements `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` et un ajustement `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`. Si le type dont vous avez besoin apparaît plusieurs fois, examinez `name` et la géométrie connue du préréglage avant d’en choisir un. Si un ajustement rapporte [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapeadjustmenttype/), considérez sa signification et sa plage comme spécifiques au préréglage et ne le changez pas tant que le contrat n’est pas connu.

## **Faire correspondre les valeurs d'ajustement à la géométrie du connecteur**

Pour les connecteurs coudés, les valeurs d’ajustement peuvent être utilisées pour estimer les positions des segments individuels. Ces calculs sont spécifiques au préréglage du connecteur :

- `ShapeType.BENT_CONNECTOR4` expose normalement un ajustement `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` et un ajustement `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`.
- Pour ces positions de courbe, `raw_value / 100000` produit la fraction de la largeur ou de la hauteur du cadre du connecteur utilisée dans les exemples ci‑dessous.
- Un cadre de connecteur peut être tourné ou retourné, de sorte que les coordonnées du cadre doivent être transformées avant d’être comparées aux coordonnées de la diapositive.

Les exemples suivants utilisent `type` pour identifier d’abord les ajustements. Ils ne traitent pas les indices de collection comme des identifiants portables.

### **Connecteur non tourné**

La disposition initiale contient deux formes de texte reliées par un `ShapeType.BENT_CONNECTOR4` :

![connector-shape-complex](connector-shape-complex.png)

Cet exemple examine le connecteur et obtient ses ajustements de courbe horizontale et verticale :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

Pour modifier les deux courbes, localisez chaque type attendu et changez les valeurs uniquement après les avoir tous deux trouvés :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat est un connecteur dont les segments horizontaux et verticaux ont été déplacés :

![connector-adjusted-1](connector-adjusted-1.png)

Une fois les types sémantiques connus, leurs valeurs peuvent être converties en coordonnées du cadre du connecteur. Cet exemple dessine un rectangle fin sur le segment vertical contrôlé par les deux ajustements de courbe :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

La forme guide indique le segment calculé :

![connector-adjusted-2](connector-adjusted-2.png)

### **Connecteur tourné ou retourné**

Lorsque la même géométrie de connecteur est orientée verticalement, ses valeurs de [frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ishapeframe/flip_h/) et [flip_v](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ishapeframe/flip_v/) influencent la conversion des coordonnées du cadre du connecteur en coordonnées de la diapositive.

Cet exemple crée et ajuste le connecteur orienté verticalement :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Le connecteur ajusté apparaît verticalement entre les formes :

![connector-adjusted-3](connector-adjusted-3.png)

Pour un angle de rotation arbitraire `alpha`, tournez un point du cadre du connecteur `(x, y)` autour du centre du cadre `(x0, y0)` :

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Le code suivant gère l’orientation à 90 degrés utilisée dans cet exemple et dessine un guide rouge sur le segment du connecteur correspondant :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Le guide rouge indique le segment calculé après la transformation des coordonnées :

![connector-adjusted-4](connector-adjusted-4.png)

Ces formules décrivent les préréglages utilisés dans les exemples, pas un modèle de connecteur universel. Validez les types d’ajustement, l’orientation du cadre et les plages de valeurs avant d’appliquer le même calcul à un autre préréglage.

## **Trouver l'angle de direction du connecteur**

La direction d’un connecteur droit peut être calculée à partir de sa largeur et de sa hauteur, en appliquant les retournements horizontaux et verticaux. L’exemple suivant indique l’angle horaire à partir de l’axe horizontal positif dans les coordonnées de la diapositive :

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **FAQ**

**Comment savoir si un connecteur peut se rattacher à une forme ?**

Vérifiez le [connection_site_count](https://reference.aspose.com/slides/fr/python-net/aspose.slides/igeometryshape/connection_site_count/) de la forme. Un compte positif signifie que la forme expose des sites de connexion. Validez l’indice du site sélectionné avant de l’attribuer à l’une ou l’autre extrémité du connecteur.

**Puis‑je identifier un ajustement de connecteur par son indice de collection ?**

Un indice n’est significatif que pour un préréglage de connecteur connu et une disposition de collection donnée. Consultez [IAdjustValue.type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iadjustvalue/type/) avant de modifier une valeur, et utilisez [IAdjustValue.name](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iadjustvalue/name/) comme information supplémentaire lorsque le même type sémantique apparaît plusieurs fois.

**Que se passe‑t‑il lorsqu’une forme connectée est supprimée ?**

L’extrémité du connecteur correspondante devient détachée. Le connecteur reste sur la diapositive et peut être supprimé, positionné comme une ligne libre ou rattaché à une autre forme.

**Les liaisons de connecteur sont‑elles conservées lorsqu’une diapositive est copiée ?**

Les liaisons sont généralement conservées lorsque les formes connectées sont copiées avec la diapositive. Si un connecteur est copié sans l’une de ses formes cibles, l’extrémité concernée doit être de nouveau attachée.