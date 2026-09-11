---
title: Gérer les connecteurs dans les présentations en Python via Java
linktitle: Connecteur
type: docs
weight: 10
url: /fr/python-java/connector/
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
description: "Apprenez comment ajouter, attacher, rerouter, ajuster et inspecter les connecteurs PowerPoint droits, coudés et courbés avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Un connecteur est une ligne qui peut rester attachée à deux formes lorsque l'une des formes se déplace. Ses extrémités se fixent à des sites de connexion, représentés par des points verts dans PowerPoint. Certains connecteurs coudés et courbés exposent également des points d’ajustement, représentés par des points orange, qui contrôlent la position des segments individuels du connecteur.

Aspose.Slides représente les connecteurs via la classe [Connector](https://reference.aspose.com/slides/fr/python-java/aspose.slides/connector/). Vous pouvez les créer, attacher leurs extrémités aux formes, choisir des sites de connexion, les reconnecter et modifier la géométrie des connecteurs qui possèdent des points d’ajustement.

## **Types de connecteur**

La classe [ShapeType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/) comprend des préréglages de connecteurs droits, coudés et courbés. Le tableau suivant montre les géométries de connecteur disponibles et le nombre de points d’ajustement définis par chaque préréglage.

| Connecteur | Image | Nombre de points d'ajustement |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Le nombre et la signification des points d’ajustement font partie du préréglage de connecteur sélectionné. Ne supposez pas que deux types de connecteur différents exposent la même disposition de collection.

## **Connecter deux formes**

Utilisez [ShapeCollection.addConnector](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addConnector) pour ajouter un connecteur, et utilisez [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/connector/#setStartShapeConnectedTo) ainsi que [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/connector/#setEndShapeConnectedTo) pour attacher ses extrémités. Après que les deux extrémités soient attachées, [Connector.reroute](https://reference.aspose.com/slides/fr/python-java/aspose.slides/connector/#reroute) sélectionne un itinéraire court entre les formes.

L’exemple suivant connecte une ellipse et un rectangle avec un connecteur coudé :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Avertissement" %}}
Appeler [reroute](https://reference.aspose.com/slides/fr/python-java/aspose.slides/connector/#reroute) peut modifier les valeurs de [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/fr/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) et de [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/fr/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). Affectez des sites de connexion spécifiques après le reroutage si ces sites doivent rester fixes.
{{% /alert %}}

## **Choisir un site de connexion**

Chaque forme connectable indique son nombre de sites via [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getConnectionSiteCount). Validez un indice de site zéro‑based préféré avant de l’attribuer à une extrémité de connecteur ; le nombre de sites varie selon la géométrie de la forme.

Cet exemple attache le connecteur à un site particulier sur l’ellipse lorsque ce site existe :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajuster un point de connecteur**

Les connecteurs avec points d’ajustement les exposent via [GeometryShape.getAdjustments](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/#getAdjustments). Examinez chaque [AdjustValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/) et vérifiez sa valeur [getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getType) avant de la modifier avec [setRawValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#setRawValue). Les règles générales pour identifier les ajustements de forme préréglés sont décrites dans [Shape Manipulation](/slides/fr/python-java/shape-manipulations/).

Le nombre, l’ordre, la signification et la plage de valeurs valides des ajustements de connecteur dépendent du préréglage du connecteur. Le type d’ajustement est en lecture seule, tandis que la valeur d’ajustement est modifiable. La méthode en lecture seule [getName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getName) fournit une identification supplémentaire lorsqu’un connecteur contient plusieurs ajustements du même type sémantique.

### **Itinéraire autour d’un obstacle**

Dans la disposition suivante, un [BentConnector5](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#BentConnector5) entre deux formes passe à travers une troisième forme :

![connector-obstruction](connector-obstruction.png)

Ce code crée le connecteur obstrué :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Déplacer le coude vertical modifie l’itinéraire afin que le connecteur contourne l’obstacle :

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Au lieu de supposer que l’indice de collection `1` représente toujours le coude vertical, cet exemple recherche [ConnectorBendPositionY](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) et ne le modifie que lorsque le type sémantique attendu est présent :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Un [BentConnector5](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#BentConnector5) possède deux ajustements [ConnectorBendPositionX](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) et un ajustement [ConnectorBendPositionY](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY). Si le type dont vous avez besoin apparaît plusieurs fois, examinez [getName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getName) et la géométrie connue de ce préréglage avant de sélectionner l’un d’eux. Si un ajustement renvoie [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#Custom), considérez sa signification et sa plage comme spécifiques au préréglage et ne le changez pas tant que ce contrat n’est pas connu.

## **Mettre en relation les valeurs d'ajustement avec la géométrie du connecteur**

Pour les connecteurs coudés, les valeurs d’ajustement peuvent être utilisées pour estimer les positions des segments individuels. Ces calculs sont spécifiques au préréglage du connecteur :

- [BentConnector4](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#BentConnector4) expose normalement un ajustement [ConnectorBendPositionX](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) et un ajustement [ConnectorBendPositionY](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY).
- Pour ces positions de coude, diviser la valeur renvoyée par [getRawValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getRawValue) par `100000.0` produit la fraction de la largeur ou de la hauteur du cadre du connecteur utilisée dans les exemples ci‑dessous.
- Un cadre de connecteur peut être tourné ou retourné, donc les coordonnées du cadre doivent être transformées avant d’être comparées aux coordonnées de la diapositive.

Les exemples suivants utilisent [getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getType) pour identifier d’abord les ajustements. Ils ne traitent pas les indices de collection comme des identifiants portables.

### **Connecteur non pivoté**

La disposition initiale contient deux formes texte reliées par un [BentConnector4](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#BentConnector4) :

![connector-shape-complex](connector-shape-complex.png)

Cet exemple examine le connecteur et obtient ses ajustements de coude horizontal et vertical :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

Pour modifier les deux coudes, localisez chaque type attendu et changez les valeurs uniquement après les avoir tous deux trouvés :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat est un connecteur dont les segments horizontal et vertical ont été déplacés :

![connector-adjusted-1](connector-adjusted-1.png)

Une fois les types sémantiques connus, leurs valeurs peuvent être converties en coordonnées du cadre du connecteur. Cet exemple dessine un rectangle fin sur le segment vertical contrôlé par les deux ajustements de coude :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La forme guide indique le segment calculé :

![connector-adjusted-2](connector-adjusted-2.png)

### **Connecteur tourné ou retourné**

Lorsque la même géométrie de connecteur est orientée verticalement, les valeurs [Shape.getFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeframe/#getFlipH) et [ShapeFrame.getFlipV](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeframe/#getFlipV) influencent la conversion des coordonnées du cadre du connecteur vers les coordonnées de la diapositive.

Cet exemple crée et ajuste le connecteur orienté verticalement :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le connecteur ajusté apparaît verticalement entre les formes :

![connector-adjusted-3](connector-adjusted-3.png)

Pour un angle de rotation arbitraire `alpha`, faites pivoter un point du cadre du connecteur `(x, y)` autour du centre du cadre `(x0, y0)` :

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Le code suivant gère l’orientation à 90 degrés utilisée dans cet exemple et dessine un guide rouge sur le segment correspondant du connecteur :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le guide rouge indique le segment calculé après la transformation des coordonnées :

![connector-adjusted-4](connector-adjusted-4.png)

Ces formules décrivent les préréglages utilisés dans les exemples, pas un modèle de connecteur universel. Validez les types d’ajustement, l’orientation du cadre et les plages de valeurs avant d’appliquer le même calcul à un préréglage différent.

## **Trouver l’angle de direction d’un connecteur**

La direction d’un connecteur droit peut être calculée à partir de sa largeur et de sa hauteur, en tenant compte des retournements horizontaux et verticaux. L’exemple suivant indique l’angle horaire depuis l’axe horizontal positif dans les coordonnées de la diapositive :

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **FAQ**

**Comment savoir si un connecteur peut se fixer à une forme ?**

Vérifiez la valeur de [getConnectionSiteCount](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getConnectionSiteCount) de la forme. Un compte positif indique que la forme expose des sites de connexion. Validez l’indice de site sélectionné avant de l’attribuer à l’une des extrémités du connecteur.

**Puis‑je identifier un ajustement de connecteur par son indice de collection ?**

Un indice n’est significatif que pour un préréglage de connecteur connu et une disposition de collection donnée. Vérifiez [AdjustValue.getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getType) avant de modifier une valeur, et utilisez [AdjustValue.getName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getName) comme information supplémentaire lorsque le même type sémantique apparaît plusieurs fois.

**Que se passe‑t‑il lorsqu’une forme connectée est supprimée ?**

L’extrémité du connecteur correspondante devient détachée. Le connecteur reste sur la diapositive et peut être supprimé, positionné comme une ligne libre ou attaché à une autre forme.

**Les liaisons de connecteur sont‑elles conservées lors de la copie d’une diapositive ?**

Les liaisons sont généralement conservées lorsque les formes connectées sont copiées avec la diapositive. Si un connecteur est copié sans l’une de ses formes cibles, l’extrémité concernée doit être de nouveau attachée.