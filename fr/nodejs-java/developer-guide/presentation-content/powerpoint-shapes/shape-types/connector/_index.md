---
title: Gérer les connecteurs dans les présentations avec JavaScript
linktitle: Connecteur
type: docs
weight: 10
url: /fr/nodejs-java/connector/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez comment ajouter, attacher, rerouter, ajuster et inspecter les connecteurs PowerPoint droits, coudés et courbes avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Un connecteur est une ligne qui peut rester attachée à deux formes lorsque l’une ou l’autre se déplace. Ses extrémités se fixent à des points de connexion, représentés par des points verts dans PowerPoint. Certains connecteurs coudés et courbes exposent également des points d’ajustement, représentés par des points orange, qui contrôlent la position des segments individuels du connecteur.

Aspose.Slides représente les connecteurs via la classe [Connector](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/connector/). Vous pouvez les créer, attacher leurs extrémités aux formes, choisir les sites de connexion, les rerouter et modifier la géométrie des connecteurs qui possèdent des points d’ajustement.

## **Types de connecteurs**

La classe [ShapeType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapetype/) comprend des préréglages de connecteurs droits, coudés et courbes. Le tableau suivant montre les géométries de connecteur disponibles et le nombre de points d’ajustement définis par chaque préréglage.

| Connecteur | Image | Nombre de points d'ajustement |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Le nombre et la signification des points d’ajustement font partie du préréglage de connecteur sélectionné. Ne supposez pas que deux types de connecteur différents exposent la même disposition de collection.

## **Connecter deux formes**

Utilisez [ShapeCollection.addConnector](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/addconnector/) pour ajouter un connecteur, et utilisez [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) et [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) pour attacher ses extrémités. Une fois les deux extrémités attachées, [Connector.reroute](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/connector/reroute/) sélectionne un itinéraire court entre les formes.

L’exemple suivant connecte une ellipse et un rectangle avec un connecteur coudé :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Avertissement" %}}

L’appel à `reroute` peut modifier les valeurs de [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) et [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Attribuez des sites de connexion spécifiques après le reroutage si ces sites doivent rester fixes.

{{% /alert %}}

## **Choisir un site de connexion**

Chaque forme connectable indique son nombre de sites via [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Validez un index de site zéro‑base préféré avant de l’attribuer à l’extrémité d’un connecteur ; le nombre de sites varie selon la géométrie de la forme.

Cet exemple attache le connecteur à un site particulier de l’ellipse lorsque ce site existe :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    const preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        console.log(`The ellipse has only ${ellipse.getConnectionSiteCount()} connection sites.`);
    }

    presentation.save("specific-connection-site.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajuster un point de connecteur**

Les connecteurs avec points d’ajustement les exposent via [GeometryShape.getAdjustments](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/geometryshape/). Examinez chaque [AdjustValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/adjustvalue/) et vérifiez sa valeur [getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/adjustvalue/) avant de la modifier avec [setRawValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/adjustvalue/setrawvalue/). Les règles générales d’identification des ajustements de forme préréglée sont décrites dans [Shape Manipulation](/slides/fr/nodejs-java/shape-manipulations/).

Le nombre, l’ordre, la signification et la plage de valeurs valides des ajustements de connecteur dépendent du préréglage du connecteur. Le type d’ajustement est en lecture seule, tandis que la valeur d’ajustement est modifiable. La méthode en lecture seule [getName](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/adjustvalue/getname/) fournit une identification supplémentaire lorsqu’un connecteur contient plusieurs ajustements du même type sémantique.

### **Contourner un obstacle**

Dans la disposition suivante, un connecteur `BentConnector5` entre deux formes traverse une troisième forme :

![connector-obstruction](connector-obstruction.png)

Ce code crée le connecteur obstrué :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Déplacer la courbure verticale modifie l’itinéraire afin que le connecteur contourne l’obstacle :

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Au lieu de supposer que l’index de collection `1` représente toujours la courbure verticale, cet exemple recherche `ConnectorBendPositionY` et le modifie uniquement lorsque le type sémantique attendu est présent :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend === null) {
        console.log("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Un `BentConnector5` possède deux ajustements `ConnectorBendPositionX` et un ajustement `ConnectorBendPositionY`. Si le type dont vous avez besoin apparaît plusieurs fois, inspectez `getName` et la géométrie connue de ce préréglage avant de choisir l’un d’eux. Si un ajustement renvoie `ShapeAdjustmentType.Custom`, considérez que sa signification et sa plage sont spécifiques au préréglage et ne le modifiez pas tant que le contrat n’est pas connu.

## **Relier les valeurs d’ajustement à la géométrie du connecteur**

Pour les connecteurs coudés, les valeurs d’ajustement peuvent être utilisées pour estimer les positions des segments individuels. Ces calculs sont spécifiques au préréglage du connecteur :

- `BentConnector4` expose normalement un ajustement `ConnectorBendPositionX` et un ajustement `ConnectorBendPositionY`.
- Pour ces positions de courbure, diviser la valeur renvoyée par `getRawValue` par `100000` produit la fraction de la largeur ou de la hauteur du cadre du connecteur utilisée dans les exemples ci‑dessous.
- Un cadre de connecteur peut être tourné ou retourné, de sorte que les coordonnées du cadre doivent être transformées avant d’être comparées aux coordonnées de la diapositive.

Les exemples suivants utilisent `getType` pour identifier d’abord les ajustements. Ils ne traitent pas les index de collection comme des identifiants portables.

### **Connecteur non tourné**

La disposition initiale contient deux formes de texte connectées par un `BentConnector4` :

![connector-shape-complex](connector-shape-complex.png)

Cet exemple inspecte le connecteur et obtient ses ajustements de courbure horizontale et verticale :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
    }
} finally {
    presentation.dispose();
}
```

Pour modifier les deux courbures, localisez chaque type attendu et modifiez les valeurs uniquement après les avoir toutes les deux trouvées :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Le résultat est un connecteur dont les segments horizontaux et verticaux ont été déplacés :

![connector-adjusted-1](connector-adjusted-1.png)

Une fois les types sémantiques connus, leurs valeurs peuvent être converties en coordonnées du cadre du connecteur. Cet exemple dessine un rectangle fin sur le segment vertical contrôlé par les deux ajustements de courbure :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        const x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const y = connector.getY();
        const height = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(x);
        const guideY = java.newFloat(y);
        const guideWidth = java.newFloat(1);
        const guideHeight = java.newFloat(height);
        slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        presentation.save("connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

La forme guide indique le segment calculé :

![connector-adjusted-2](connector-adjusted-2.png)

### **Connecteur tourné ou retourné**

Lorsque la même géométrie de connecteur est orientée verticalement, les valeurs de [Shape.getFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapeframe/getfliph/) et [ShapeFrame.getFlipV](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapeframe/getflipv/) influent sur la conversion des coordonnées du cadre du connecteur vers les coordonnées de la diapositive.

Cet exemple crée et ajuste le connecteur orienté verticalement :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const connectorColor = java.newInstanceSync("java.awt.Color", 102, 205, 170);
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le connecteur ajusté apparaît verticalement entre les formes :

![connector-adjusted-3](connector-adjusted-3.png)

Pour un angle de rotation arbitraire `alpha`, faire pivoter un point du cadre du connecteur `(x, y)` autour du centre du cadre `(x0, y0)` :

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Le code suivant gère l’orientation à 90 degrés utilisée dans cet exemple et dessine un guide rouge sur le segment de connecteur correspondant :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        let x = connector.getX();
        let y = connector.getY();
        if (connector.getFrame().getFlipH() === aspose.slides.NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() === aspose.slides.NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        const rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        const segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(rotatedX);
        const guideY = java.newFloat(rotatedY);
        const guideWidth = java.newFloat(segmentWidth);
        const guideHeight = java.newFloat(1);
        const guide = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        const red = java.getStaticFieldValue("java.awt.Color", "RED");
        const solidFillType = java.newByte(aspose.slides.FillType.Solid);
        guide.getLineFormat().getFillFormat().setFillType(solidFillType);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

        presentation.save("rotated-connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Le guide rouge indique le segment calculé après la transformation des coordonnées :

![connector-adjusted-4](connector-adjusted-4.png)

Ces formules décrivent les préréglages utilisés dans les exemples, pas un modèle universel de connecteur. Validez les types d’ajustement, l’orientation du cadre et les plages de valeurs avant d’appliquer le même calcul à un préréglage différent.

## **Trouver l’angle de direction d’un connecteur**

La direction d’un connecteur droit peut être calculée à partir de sa largeur et de sa hauteur, en tenant compte des retournements horizontaux et verticaux. L’exemple suivant renvoie l’angle horaire à partir de l’axe horizontal positif dans les coordonnées de la diapositive :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 100, 100, 200, 100);

    const flipH = connector.getFrame().getFlipH() === aspose.slides.NullableBool.True;
    const flipV = connector.getFrame().getFlipV() === aspose.slides.NullableBool.True;
    const deltaX = connector.getWidth() * (flipH ? -1 : 1);
    const deltaY = connector.getHeight() * (flipV ? -1 : 1);
    let angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    console.log(`Connector direction: ${angle.toFixed(2)} degrees`);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Comment savoir si un connecteur peut se rattacher à une forme ?**

Vérifiez la valeur de [getConnectionSiteCount](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/getconnectionsitecount/) de la forme. Un compteur positif indique que la forme expose des sites de connexion. Validez l’index du site sélectionné avant de l’attribuer à l’une ou l’autre des extrémités du connecteur.

**Puis‑je identifier un ajustement de connecteur par son index de collection ?**

Un index n’est significatif que pour un préréglage de connecteur connu et une disposition de collection donnée. Vérifiez [AdjustValue.getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/adjustvalue/) avant de modifier une valeur, et utilisez [AdjustValue.getName](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/adjustvalue/getname/) comme information supplémentaire lorsque le même type sémantique apparaît plusieurs fois.

**Que se passe‑t‑il lorsqu’une forme connectée est supprimée ?**

L’extrémité du connecteur correspondante se détache. Le connecteur reste sur la diapositive et peut être supprimé, positionné comme une ligne libre ou rattaché à une autre forme.

**Les liaisons de connecteur sont‑elles conservées lorsqu’une diapositive est copiée ?**

Les liaisons sont généralement conservées lorsque les formes connectées sont copiées avec la diapositive. Si un connecteur est copié sans l’une de ses formes cibles, l’extrémité concernée doit être rattachée à nouveau.