---
title: Gérer les connecteurs dans les présentations en Java
linktitle: Connecteur
type: docs
weight: 10
url: /fr/java/connector/
keywords:
- connecteur
- type de connecteur
- point de connecteur
- ligne de connecteur
- angle de connecteur
- site de connexion
- point d'ajustement
- connecter des formes
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à ajouter, rattacher, retracer, ajuster et inspecter les connecteurs PowerPoint droits, coudés et courbés avec Aspose.Slides pour Java."
---
## **Aperçu**

Un connecteur est une ligne qui peut rester attachée à deux formes lorsque l’une ou l’autre se déplace. Ses extrémités se raccordent à des points de connexion, représentés par des points verts dans PowerPoint. Certains connecteurs coudés et courbés exposent également des points d’ajustement, représentés par des points orange, qui contrôlent la position des segments individuels du connecteur.

Aspose.Slides représente les connecteurs via l’interface [IConnector](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iconnector/). Vous pouvez les créer, raccorder leurs extrémités à des formes, choisir des points de connexion, les retracer et modifier la géométrie des connecteurs qui possèdent des points d’ajustement.

## **Types de connecteur**

La classe [ShapeType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shapetype/) comprend des préréglages de connecteurs droits, coudés et courbés. Le tableau suivant montre les géométries de connecteur disponibles ainsi que le nombre de points d’ajustement définis par chaque préréglage.

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

Utilisez [IShapeCollection.addConnector](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) pour ajouter un connecteur, et utilisez [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) et [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) pour raccorder ses extrémités. Après que les deux extrémités soient raccordées, [IConnector.reroute](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iconnector/#reroute--) sélectionne un itinéraire court entre les formes.

L’exemple suivant connecte une ellipse et un rectangle avec un connecteur coudé :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}

Appeler `reroute` peut modifier les valeurs de [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) et de [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). Attribuez des sites de connexion spécifiques après le retracé si ces sites doivent rester fixes.

{{% /alert %}}

## **Choisir un point de connexion**

Chaque forme connectable indique son nombre de sites via [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Validez un indice de site zéro‑base préféré avant de l’attribuer à une extrémité du connecteur ; le nombre de sites varie selon la géométrie de la forme.

Cet exemple rattache le connecteur à un site particulier sur l’ellipse lorsque ce site existe :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajuster un point du connecteur**

Les connecteurs avec points d’ajustement les exposent via [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/fr/java/com.aspose.slides/igeometryshape/#getAdjustments--). Inspectez chaque [IAdjustValue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iadjustvalue/) et vérifiez sa valeur [getType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iadjustvalue/#getType--) avant de la modifier avec [setRawValue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iadjustvalue/#setRawValue-long-). Les règles générales d’identification des ajustements de forme prédéfinis sont décrites dans [Shape Manipulation](/slides/fr/java/shape-manipulations/).

Le nombre, l’ordre, la signification et la plage de valeurs valides des ajustements d’un connecteur dépendent du préréglage du connecteur. Le type d’ajustement est en lecture seule, tandis que la valeur d’ajustement est modifiable. La méthode en lecture seule [getName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iadjustvalue/#getName--) fournit une identification supplémentaire lorsqu’un connecteur contient plusieurs ajustements du même type sémantique.

### **Contourner un obstacle**

Dans la disposition suivante, un connecteur `BentConnector5` entre deux formes traverse une troisième forme :

![connector-obstruction](connector-obstruction.png)

Ce code crée le connecteur obstrué :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Déplacer la courbure verticale modifie l’itinéraire afin que le connecteur contourne l’obstacle :

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Au lieu de supposer que l’indice de collection `1` représente toujours la courbure verticale, cet exemple recherche `ConnectorBendPositionY` et ne le change que lorsque le type sémantique attendu est présent :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Un `BentConnector5` possède deux ajustements `ConnectorBendPositionX` et un ajustement `ConnectorBendPositionY`. Si le type dont vous avez besoin apparaît plusieurs fois, inspectez `getName` et la géométrie connue de ce préréglage avant d’en sélectionner un. Si un ajustement rapporte `ShapeAdjustmentType.Custom`, considérez sa signification et sa plage comme spécifiques au préréglage et ne le modifiez pas tant que ce contrat n’est pas connu.

## **Mettre en relation les valeurs d’ajustement avec la géométrie du connecteur**

Pour les connecteurs coudés, les valeurs d’ajustement peuvent être utilisées pour estimer les positions des segments individuels. Ces calculs sont spécifiques au préréglage du connecteur :

- `BentConnector4` expose habituellement un ajustement `ConnectorBendPositionX` et un ajustement `ConnectorBendPositionY`.
- Pour ces positions, diviser la valeur retournée par `getRawValue` par `100000f` donne la fraction de la largeur ou de la hauteur du cadre du connecteur utilisée dans les exemples ci‑dessous.
- Un cadre de connecteur peut être pivoté ou retourné, de sorte que les coordonnées du cadre doivent être transformées avant d’être comparées aux coordonnées de la diapositive.

Les exemples suivants utilisent `getType` pour identifier d’abord les ajustements. Ils ne traitent pas les indices de collection comme des identifiants portables.

### **Connecteur non pivoté**

La disposition initiale contient deux formes texte reliées par un `BentConnector4` :

![connector-shape-complex](connector-shape-complex.png)

Cet exemple inspecte le connecteur et obtient ses ajustements de courbure horizontale et verticale :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

Pour modifier les deux courbures, localisez chaque type attendu et ajustez les valeurs uniquement après les avoir toutes deux trouvées :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Le résultat est un connecteur dont les segments horizontaux et verticaux ont été déplacés :

![connector-adjusted-1](connector-adjusted-1.png)

Une fois les types sémantiques connus, leurs valeurs peuvent être converties en coordonnées du cadre du connecteur. Cet exemple trace un rectangle fin sur le segment vertical contrôlé par les deux ajustements de courbure :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

La forme de guidage indique le segment calculé :

![connector-adjusted-2](connector-adjusted-2.png)

### **Connecteur pivoté ou retourné**

Lorsque la même géométrie de connecteur est orientée verticalement, les valeurs de [IShape.getFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shapeframe/#getFlipH--) et [ShapeFrame.getFlipV](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shapeframe/#getFlipV--) influencent la conversion des coordonnées du cadre du connecteur vers les coordonnées de la diapositive.

Cet exemple crée et ajuste le connecteur orienté verticalement :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(102, 205, 170));
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le connecteur ajusté apparaît verticalement entre les formes :

![connector-adjusted-3](connector-adjusted-3.png)

Pour un angle de rotation arbitraire `alpha`, faites pivoter un point du cadre du connecteur `(x, y)` autour du centre du cadre `(x0, y0)` :

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Le code suivant gère l’orientation à 90 degrés utilisée dans cet exemple et trace un guide rouge sur le segment correspondant du connecteur :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Le guide rouge indique le segment calculé après la transformation des coordonnées :

![connector-adjusted-4](connector-adjusted-4.png)

Ces formules décrivent les préréglages utilisés dans les exemples, et non un modèle de connecteur universel. Validez les types d’ajustement, l’orientation du cadre et les plages de valeurs avant d’appliquer le même calcul à un autre préréglage.

## **Trouver l’angle de direction d’un connecteur**

La direction d’un connecteur droit peut être calculée à partir de sa largeur et de sa hauteur, en tenant compte des retournements horizontaux et verticaux. L’exemple suivant renvoie l’angle horaire à partir de l’axe horizontal positif dans les coordonnées de la diapositive :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Comment savoir si un connecteur peut se rattacher à une forme ?**

Vérifiez la valeur de [getConnectionSiteCount](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getConnectionSiteCount--) de la forme. Un compte positif signifie que la forme expose des sites de connexion. Validez l’indice du site sélectionné avant de l’attribuer à l’une ou l’autre extrémité du connecteur.

**Puis‑je identifier un ajustement de connecteur par son indice de collection ?**

Un indice n’est significatif que pour un préréglage de connecteur et une disposition de collection connus. Vérifiez [IAdjustValue.getType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iadjustvalue/#getType--) avant de modifier une valeur, et utilisez [IAdjustValue.getName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iadjustvalue/#getName--) comme information supplémentaire lorsque le même type sémantique apparaît plusieurs fois.

**Que se passe‑t‑il lorsqu’une forme connectée est supprimée ?**

L’extrémité du connecteur correspondante se détache. Le connecteur demeure sur la diapositive et peut être supprimé, positionné comme une ligne libre ou rattaché à une autre forme.

**Les liaisons de connecteur sont‑elles conservées lorsqu’une diapositive est copiée ?**

Les liaisons sont généralement conservées lorsque les formes connectées sont copiées avec la diapositive. Si un connecteur est copié sans l’une de ses formes cibles, l’extrémité concernée doit être rattachée à nouveau.