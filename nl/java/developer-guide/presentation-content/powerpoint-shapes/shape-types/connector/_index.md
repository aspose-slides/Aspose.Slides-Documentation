---
title: Connectoren beheren in presentaties in Java
linktitle: Connector
type: docs
weight: 10
url: /nl/java/connector/
keywords:
- connector
- connector type
- connectorpunt
- connectorlijn
- connectorhoek
- verbindingspunt
- aanpassingspunt
- vormen verbinden
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u rechte, gebogen en kromme PowerPoint-connectoren kunt toevoegen, koppelen, opnieuw routeren, aanpassen en inspecteren met Aspose.Slides voor Java."
---
## **Overzicht**

Een connector is een lijn die aan twee vormen kan blijven bevestigd blijven wanneer een van beide vormen beweegt. De uiteinden hechten zich aan verbindingspunten, weergegeven door groene stippen in PowerPoint. Sommige gebogen en kromme connectoren tonen ook aanpassingspunten, weergegeven door oranje stippen, die de positie van individuele connectorsegmenten regelen.

Aspose.Slides vertegenwoordigt connectoren via de [IConnector](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iconnector/)‑interface. Je kunt ze maken, hun uiteinden aan vormen koppelen, verbindingspunten kiezen, ze opnieuw routeren en de geometrie van connectoren met aanpassingspunten aanpassen.

## **Connector‑types**

De [ShapeType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapetype/)‑klasse bevat rechte, gebogen en gekromde connector‑presets. De onderstaande tabel toont de beschikbare connector‑geometrieën en het aantal aanpassingspunten dat door elk preset wordt gedefinieerd.

| Connector | Afbeelding | Aantal aanpassingspunten |
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

Het aantal en de betekenis van aanpassingspunten maken deel uit van het gekozen connector‑preset. Ga er niet van uit dat twee verschillende connector‑types dezelfde lay‑out van de collectie tonen.

## **Twee vormen verbinden**

Gebruik [IShapeCollection.addConnector](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) om een connector toe te voegen, en gebruik [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) en [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) om de uiteinden te koppelen. Nadat beide uiteinden zijn gekoppeld, selecteert [IConnector.reroute](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iconnector/#reroute--) een korte route tussen de vormen.

Het volgende voorbeeld verbindt een ellips en een rechthoek met een gebogen connector:

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

{{% alert color="warning" title="Waarschuwing" %}}
Het aanroepen van `reroute` kan de waarden van [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) en [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) wijzigen. Wijs specifieke verbindingspunten toe na het opnieuw routeren als die punten vast moeten blijven.
{{% /alert %}}

## **Kies een verbindingspunt**

Elke koppelbare vorm rapporteert zijn aantal verbindingspunten via [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Controleer een voorkeurs‑index (nul‑gebaseerd) voordat je die toewijst aan een connector‑uiteinde; het aantal punten varieert per vorm‑geometrie.

Dit voorbeeld koppelt de connector aan een specifiek punt op de ellips wanneer dat punt bestaat:

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

## **Pas een connectorpunt aan**

Connectoren met aanpassingspunten tonen ze via [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/nl/java/com.aspose.slides/igeometryshape/#getAdjustments--). Inspecteer elke [IAdjustValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/) en controleer zijn [getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#getType--) voordat je de waarde wijzigt met [setRawValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#setRawValue-long-). De algemene regels voor het identificeren van presets voor vorm‑aanpassingen staan beschreven in [Shape Manipulation](/slides/nl/java/shape-manipulations/).

Het aantal, de volgorde, de betekenis en het geldige waardebereik van connector‑aanpassingen hangen af van het connector‑preset. Het aanpassingstype is alleen‑lezen, terwijl de aanpassingswaarde schrijfbaar is. De alleen‑lezen [getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#getName--)‑methode geeft extra identificatie wanneer een connector meer dan één aanpassing van hetzelfde semantische type bevat.

### **Route om een obstakel heen**

In de volgende lay‑out loopt een `BentConnector5`‑connector tussen twee vormen door een derde vorm:

![connector-obstruction](connector-obstruction.png)

Deze code maakt de geblokkeerde connector:

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

Het verplaatsen van de verticale buiging wijzigt de route zodat de connector het obstakel omzeilt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

In plaats van ervan uit te gaan dat collectie‑index `1` altijd de verticale buiging representeert, zoekt dit voorbeeld naar `ConnectorBendPositionY` en wijzigt het alleen wanneer het verwachte semantische type aanwezig is:

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

Een `BentConnector5` heeft twee `ConnectorBendPositionX`‑aanpassingen en één `ConnectorBendPositionY`‑aanpassing. Als het type dat je nodig hebt vaker voorkomt, inspecteer dan `getName` en de bekende geometrie van dat preset voordat je er één selecteert. Als een aanpassing `ShapeAdjustmentType.Custom` rapporteert, behandel dan de betekenis en het bereik als preset‑specifiek en wijzig het niet totdat die contractuele afspraak bekend is.

## **Relate Adjustment Values to Connector Geometry**

Voor gebogen connectoren kunnen aanpassingswaarden worden gebruikt om de posities van individuele segmenten in te schatten. Deze berekeningen zijn specifiek voor het connector‑preset:

- `BentConnector4` toont normaal één `ConnectorBendPositionX`‑ en één `ConnectorBendPositionY`‑aanpassing.
- Voor deze buigposities levert het delen van de waarde die door `getRawValue` wordt geretourneerd door `100000f` de fractie van de connector‑framebreedte of -hoogte op die in de voorbeelden hieronder wordt gebruikt.
- Een connector‑frame kan worden gedraaid of gespiegeld, dus frame‑coördinaten moeten worden getransformeerd voordat ze worden vergeleken met dia‑coördinaten.

De volgende voorbeelden gebruiken `getType` om eerst de aanpassingen te identificeren. Ze behandelen collectie‑indexen niet als draagbare identifier.

### **Niet‑geroteerde connector**

De initiële lay‑out bevat twee tekstvormen verbonden door een `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Dit voorbeeld inspecteert de connector en verkrijgt de horizontale en verticale buig‑aanpassingen:

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

Om beide buigingen te wijzigen, zoek elk verwacht type en wijzig de waarden pas nadat beide zijn gevonden:

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

Het resultaat is een connector waarvan de horizontale en verticale segmenten zijn verschoven:

![connector-adjusted-1](connector-adjusted-1.png)

Zodra de semantische types bekend zijn, kunnen hun waarden worden omgezet naar connector‑frame‑coördinaten. Dit voorbeeld tekent een dunne rechthoek over het verticale segment dat wordt bestuurd door de twee buig‑aanpassingen:

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

De hulpsvorm markeert het berekende segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Geroteerde of omgekeerde connector**

Wanneer dezelfde connector‑geometrie verticaal georiënteerd is, beïnvloeden de waarden van [IShape.getFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapeframe/#getFlipH--) en [ShapeFrame.getFlipV](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapeframe/#getFlipV--) de omzetting van connector‑frame‑coördinaten naar dia‑coördinaten.

Dit voorbeeld maakt en past de verticaal georiënteerde connector aan:

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

De aangepaste connector verschijnt verticaal tussen de vormen:

![connector-adjusted-3](connector-adjusted-3.png)

Voor een willekeurige rotatiehoek `alpha` wordt een connector‑frame‑punt `(x, y)` rond het frame‑middelpunt `(x0, y0)` geroteerd:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

De volgende code handelt de 90‑graden‑oriëntatie die in dit voorbeeld wordt gebruikt af en tekent een rode gids over het corresponderende connector‑segment:

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

De rode gids markeert het berekende segment na de coördinaat‑transformatie:

![connector-adjusted-4](connector-adjusted-4.png)

Deze formules beschrijven de presets die in de voorbeelden worden gebruikt, niet een universeel connector‑model. Valideer de aanpassingstypes, frame‑oriëntatie en waardebereiken voordat je dezelfde berekening toepast op een ander preset.

## **Vind de richtingshoek van een connector**

De richting van een rechte connector kan worden berekend uit zijn breedte en hoogte, met horizontale en verticale spiegels toegepast. Het volgende voorbeeld rapporteert de klokwijzerige hoek ten opzichte van de positieve horizontale as in dia‑coördinaten:

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

**Hoe kan ik zien of een connector aan een vorm kan worden gekoppeld?**

Controleer de waarde van de vorm‑[getConnectionSiteCount](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Een positief aantal betekent dat de vorm verbindingspunten exposeert. Valideer de geselecteerde punt‑index voordat je die toewijst aan een connector‑uiteinde.

**Kan ik een connector‑aanpassing identificeren aan de hand van zijn collectie‑index?**

Een index is alleen betekenisvol voor een bekend connector‑preset en collectie‑lay‑out. Controleer [IAdjustValue.getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#getType--) voordat je een waarde wijzigt, en gebruik [IAdjustValue.getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iadjustvalue/#getName--) als extra informatie wanneer hetzelfde semantische type meerdere keren voorkomt.

**Wat gebeurt er als een gekoppelde vorm wordt verwijderd?**

Het corresponderende connector‑uiteinde wordt losgekoppeld. De connector blijft op de dia staan en kan worden verwijderd, als vrije lijn worden gepositioneerd, of aan een andere vorm worden gekoppeld.

**Worden connector‑koppelingen behouden wanneer een dia wordt gekopieerd?**

Koppelingen blijven over het algemeen behouden wanneer de gekoppelde vormen samen met de dia worden gekopieerd. Als een connector wordt gekopieerd zonder een van zijn doel‑vormen, moet het getroffen uiteinde opnieuw worden gekoppeld.