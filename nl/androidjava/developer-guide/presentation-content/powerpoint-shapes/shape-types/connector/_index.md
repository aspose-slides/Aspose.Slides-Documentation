---
title: Beheer connectors in presentaties op Android
linktitle: Connector
type: docs
weight: 10
url: /nl/androidjava/connector/
keywords:
- connector
- type connector
- connectorpunt
- connectorlijn
- connectorhoek
- aansluitpunt
- aanpassingspunt
- vormen verbinden
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u rechte, gebogen en gekromde PowerPoint-connectors kunt toevoegen, koppelen, opnieuw routeren, aanpassen en inspecteren met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Een connector is een lijn die aan twee vormen kan blijven verbonden wanneer een van de vormen wordt verplaatst. De uiteinden worden gekoppeld aan aansluitpunten, weergegeven door groene stippen in PowerPoint. Sommige gebogen en gekromde connectors tonen bovendien aanpassingspunten, weergegeven door oranje stippen, die de positie van individuele connectorsegmenten regelen.

Aspose.Slides vertegenwoordigt connectors via de [IConnector](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iconnector/) interface. Je kunt ze maken, hun uiteinden aan vormen koppelen, aansluitpunten kiezen, ze opnieuw routeren en de geometrie van connectors die aanpassingspunten hebben aanpassen.

## **Connector‑typen**

De [ShapeType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapetype/) klasse bevat rechte, gebogen en gekromde connector‑presets. De volgende tabel toont de beschikbare connector‑geometrieën en het aantal aanpassingspunten dat door elk preset wordt gedefinieerd.

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

Het aantal en de betekenis van aanpassingspunten maken deel uit van het geselecteerde connector‑preset. Ga er niet vanuit dat twee verschillende connector‑types dezelfde collectielay-out blootleggen.

## **Twee vormen verbinden**

Gebruik [IShapeCollection.addConnector](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) om een connector toe te voegen, en gebruik [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) en [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) om de uiteinden te koppelen. Nadat beide uiteinden zijn gekoppeld, selecteert [IConnector.reroute](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iconnector/#reroute--) een korte route tussen de vormen.

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
Het aanroepen van `reroute` kan de waarden van [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) en [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) wijzigen. Wijs specifieke aansluitpunten toe na het opnieuw routeren als die aansluitpunten vast moeten blijven.
{{% /alert %}}

## **Kies een aansluitpunt**

Elke koppeltbare vorm meldt het aantal aansluitpunten via [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--). Valideer een gewenste nulgebaseerde index voordat je deze aan een connector‑uiteinde toewijst; het aantal aansluitpunten varieert per vormgeometrie.

Dit voorbeeld koppelt de connector aan een specifiek aansluitpunt op de ellips wanneer dat aansluitpunt bestaat:

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

## **Een connectorpunt aanpassen**

Connectors met aanpassingspunten maken ze beschikbaar via [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--). Inspecteer elke [IAdjustValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iadjustvalue/) en controleer de [getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iadjustvalue/#getType--) waarde voordat je deze wijzigt met [setRawValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-). De algemene regels voor het identificeren van preset‑vormaanpassingen staan beschreven in [Shape Manipulation](/slides/nl/androidjava/shape-manipulations/).

Het aantal, de volgorde, de betekenis en het geldige waardebereik van connector‑aanpassingen hangen af van het connector‑preset. Het aanpassingstype is alleen-lezen, terwijl de aanpassingswaarde schrijfbaar is. De alleen-lezen [getName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iadjustvalue/#getName--) methode biedt extra identificatie wanneer een connector meer dan één aanpassing van hetzelfde semantische type bevat.

### **Route om een obstakel**

In de volgende lay-out gaat een `BentConnector5`‑connector tussen twee vormen door een derde vorm:

![connector-obstruction](connector-obstruction.png)

Deze code maakt de geblokkeerde connector:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Het verplaatsen van de verticale buiging verandert de route zodat de connector het obstakel omzeilt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

In plaats van aan te nemen dat collectie‑index `1` altijd de verticale buiging representeert, zoekt dit voorbeeld naar `ConnectorBendPositionY` en wijzigt deze alleen wanneer het verwachte semantische type aanwezig is:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Een `BentConnector5` heeft twee `ConnectorBendPositionX`‑aanpassingen en één `ConnectorBendPositionY`‑aanpassing. Als het type dat je nodig hebt meer dan één keer voorkomt, inspecteer dan `getName` en de bekende geometrie van dat preset voordat je er één selecteert. Als een aanpassing `ShapeAdjustmentType.Custom` meldt, behandel dan de betekenis en het bereik als preset‑specifiek en wijzig het niet totdat dat contract bekend is.

## **Aanpassingswaarden relateren aan connector‑geometrie**

Voor gebogen connectors kunnen aanpassingswaarden worden gebruikt om de posities van individuele segmenten te schatten. Deze berekeningen zijn specifiek voor het connector‑preset:

- `BentConnector4` toont normaal één `ConnectorBendPositionX`‑ en één `ConnectorBendPositionY`‑aanpassing.
- Voor deze buigposities, levert het delen van de door `getRawValue` geretourneerde waarde door `100000f` de fractie van de connector‑framebreedte of -hoogte op die in de onderstaande voorbeelden wordt gebruikt.
- Een connector‑frame kan gedraaid of gespiegeld worden, dus frame‑coördinaten moeten worden getransformeerd voordat ze met dia‑coördinaten worden vergeleken.

De volgende voorbeelden gebruiken eerst `getType` om de aanpassingen te identificeren. Ze behandelen collectie‑indices niet als draagbare identifiers.

### **Niet-gedraaide connector**

De beginlay-out bevat twee tekstvormen die verbonden zijn door een `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Dit voorbeeld inspecteert de connector en haalt de horizontale en verticale buig‑aanpassingen op:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Om beide buigingen te wijzigen, zoek je elk verwacht type en wijzig je de waarden pas nadat beide zijn gevonden:

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

Het resultaat is een connector waarvan de horizontale en verticale segmenten zijn verplaatst:

![connector-adjusted-1](connector-adjusted-1.png)

Zodra de semantische types bekend zijn, kunnen hun waarden omgezet worden naar connector‑framecoördinaten. Dit voorbeeld tekent een dunne rechthoek over het verticale segment dat wordt bestuurd door de twee buig‑aanpassingen:

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

De hulplijn markeert het berekende segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Gedraaide of gespiegelde connector**

Wanneer dezelfde connector‑geometrie verticaal georiënteerd is, beïnvloeden de waarden van [IShape.getFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapeframe/#getFlipH--), en [ShapeFrame.getFlipV](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapeframe/#getFlipV--) de conversie van connector‑framecoördinaten naar dia‑coördinaten.

Dit voorbeeld maakt en past de verticaal georiënteerde connector aan:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int connectorColor = Color.rgb(102, 205, 170);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
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

Voor een willekeurige rotatiehoek `alpha` roteer je een connector‑framepunt `(x, y)` rond het frame‑centrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

De volgende code behandelt de 90‑graden oriëntatie die in dit voorbeeld wordt gebruikt en tekent een rode gids over het bijbehorende connectorsegment:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

De rode gids markeert het berekende segment na de coördinatentransformatie:

![connector-adjusted-4](connector-adjusted-4.png)

Deze formules beschrijven de presets die in de voorbeelden worden gebruikt, niet een universeel connector‑model. Valideer de aanpassingstypen, frame‑oriëntatie en waardebereiken voordat je dezelfde berekening op een ander preset toepast.

## **De richtinghoek van een connector vinden**

De richting van een rechte connector kan berekend worden uit de breedte en hoogte, met horizontale en verticale flips toegepast. Het volgende voorbeeld meldt de klokwijzerzinhoek vanaf de positieve horizontale as in dia‑coördinaten:

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

Controleer de [getConnectionSiteCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) waarde van de vorm. Een positieve telling betekent dat de vorm aansluitpunten blootlegt. Valideer de gekozen site‑index voordat je deze aan een connector‑uiteinde toewijst.

**Kan ik een connector‑aanpassing identificeren aan de hand van de collectie‑index?**

Een index is alleen betekenisvol voor een bekend connector‑preset en een bekende collectielay-out. Controleer [IAdjustValue.getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iadjustvalue/#getType--) voordat je een waarde wijzigt, en gebruik [IAdjustValue.getName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iadjustvalue/#getName--) als aanvullende informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.

**Wat gebeurt er als een gekoppelde vorm wordt verwijderd?**

Het corresponderende connector‑uiteinde wordt losgekoppeld. De connector blijft op de dia bestaan en kan worden verwijderd, als een vrije lijn gepositioneerd, of aan een andere vorm gekoppeld.

**Blijven connector‑bindingen behouden wanneer een dia wordt gekopieerd?**

Bindingen blijven over het algemeen behouden wanneer de gekoppelde vormen mee gekopieerd worden met de dia. Als een connector wordt gekopieerd zonder een van zijn doelvormen, moet het desbetreffende uiteinde opnieuw worden gekoppeld.