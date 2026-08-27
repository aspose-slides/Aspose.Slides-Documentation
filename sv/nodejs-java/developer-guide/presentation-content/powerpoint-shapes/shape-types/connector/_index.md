---
title: Hantera kopplingar i presentationer med JavaScript
linktitle: Koppling
type: docs
weight: 10
url: /sv/nodejs-java/connector/
keywords:
- koppling
- kopplingstyp
- kopplingspunkt
- kopplingslinje
- kopplingsvinkel
- anslutningsställe
- justeringspunkt
- koppla former
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du lägger till, fäster, omruttar, justerar och inspekterar raka, böjda och kurviga PowerPoint-kopplingar med Aspose.Slides för Node.js via Java."
---
## **Översikt**

En connector är en linje som kan förbli fäst vid två former när någon av formerna flyttas. Dess ändar fästs vid anslutningsställen, som visas av gröna prickar i PowerPoint. Vissa böjda och kurviga connectors har också justeringspunkter, som visas av orange prickar, som styr positionen för enskilda connector-segment.

Aspose.Slides representerar connectors genom klassen [Connector](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/connector/). Du kan skapa dem, fästa deras ändar på former, välja anslutningsställen, omruttas dem och ändra geometrin för connectors som har justeringspunkter.

## **Connector‑typer**

Klassen [ShapeType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapetype/) innehåller förinställningar för raka, böjda och kurviga connectors. Tabellen nedan visar de tillgängliga connector‑geometrierna och antalet justeringspunkter som definieras av varje förinställning.

| Connector | Bild | Antal justeringspunkter |
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

Antalet och innebörden av justeringspunkterna är en del av den valda connector‑förinställningen. Anta inte att två olika connector‑typer exponerar samma samlingslayout.

## **Koppla två former**

Använd [ShapeCollection.addConnector](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/addconnector/) för att lägga till en connector, och använd [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) samt [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) för att fästa dess ändar. När båda ändarna är fästa, väljer [Connector.reroute](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/connector/reroute/) en kort väg mellan formerna.

Följande exempel kopplar en ellips och en rektangel med en böjd connector:

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

{{% alert color="warning" title="Warning" %}}

Att anropa `reroute` kan ändra värdena för [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) och [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Tilldela specifika anslutningsställen efter omruttning om dessa ställen måste förbli fasta.

{{% /alert %}}

## **Välj ett anslutningsställe**

Varje form som kan anslutas rapporterar sitt antal ställen via [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Validera ett föredraget nollbaserat indeksvärde innan du tilldelar det till en connector‑ände; antalet ställen varierar beroende på formens geometri.

Detta exempel fäster connectorn på ett specifikt ställe på ellipsen när det stället finns:

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

## **Justera en connector‑punkt**

Connectors med justeringspunkter exponerar dem via [GeometryShape.getAdjustments](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/geometryshape/). Granska varje [AdjustValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/adjustvalue/) och kontrollera dess [getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/adjustvalue/) innan du ändrar det med [setRawValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/adjustvalue/setrawvalue/). De allmänna reglerna för att identifiera förinställda formjusteringar beskrivs i [Shape Manipulation](/slides/sv/nodejs-java/shape-manipulations/).

Antalet, ordningen, innebörden och det giltiga värdeintervallet för connector‑justeringar beror på connector‑förinställningen. Justeringstypen är skrivskyddad, medan justeringsvärdet är skrivbart. Den skrivskyddade [getName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/adjustvalue/getname/)‑metoden ger ytterligare identifiering när en connector innehåller mer än en justering av samma semantiska typ.

### **Rutt runt ett hinder**

I layouten nedan passerar en `BentConnector5` mellan två former genom en tredje form:

![connector-obstruction](connector-obstruction.png)

Denna kod skapar den blockerade connectorn:

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

Att flytta den vertikala böjen ändrar rutten så att connectorn går runt hindret:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Istället för att anta att samlingsindex `1` alltid representerar den vertikala böjen, söker detta exempel efter `ConnectorBendPositionY` och ändrar den endast när den förväntade semantiska typen finns:

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

En `BentConnector5` har två `ConnectorBendPositionX`‑justeringar och en `ConnectorBendPositionY`‑justering. Om den typ du behöver förekommer mer än en gång, granska `getName` och den kända geometrin för den förinställningen innan du väljer en. Om en justering rapporterar `ShapeAdjustmentType.Custom`, behandla dess innebörd och intervall som förinställningsspecifikt och ändra den inte förrän kontraktet är känt.

## **Relatera justeringsvärden till connector‑geometri**

För böjda connectors kan justeringsvärden användas för att uppskatta positionerna för enskilda segment. Dessa beräkningar är specifika för connector‑förinställningen:

- `BentConnector4` exponerar normalt en `ConnectorBendPositionX`‑ och en `ConnectorBendPositionY`‑justering.
- För dessa böjpositioner ger division av värdet som returneras av `getRawValue` med `100000` bråkdelen av connector‑ramens bredd eller höjd som används i exemplen nedan.
- En connector‑ram kan roteras eller vändas, så ramkoordinater måste transformeras innan de jämförs med bild‑koordinater.

Följande exempel använder `getType` för att först identifiera justeringarna. De behandlar inte samlingsindex som portabla identifierare.

### **Ej roterad connector**

Den ursprungliga layouten innehåller två textformer kopplade med en `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Detta exempel granskar connectorn och hämtar dess horisontella och vertikala böjningsjusteringar:

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

För att ändra båda böjarna, lokalisera varje förväntad typ och ändra värdena först när båda har hittats:

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

Resultatet blir en connector vars horisontella och vertikala segment har flyttats:

![connector-adjusted-1](connector-adjusted-1.png)

När de semantiska typerna är kända kan deras värden konverteras till connector‑ramens koordinater. Detta exempel ritar en tunn rektangel över det vertikala segmentet som styrs av de två böjningsjusteringarna:

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

Guide‑formen markerar det beräknade segmentet:

![connector-adjusted-2](connector-adjusted-2.png)

### **Roterad eller vänd connector**

När samma connector‑geometri är orienterad vertikalt påverkar dess [Shape.getFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapeframe/getfliph/), och [ShapeFrame.getFlipV](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapeframe/getflipv/) värden konverteringen från connector‑ramens koordinater till bild‑koordinater.

Detta exempel skapar och justerar den vertikalt orienterade connectorn:

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

Den justerade connectorn visas vertikalt mellan formerna:

![connector-adjusted-3](connector-adjusted-3.png)

För en godtycklig rotationsvinkel `alpha`, rotera en punkt i connector‑ramen `(x, y)` kring ramens centrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Följande kod hanterar den 90‑graders orientering som används i detta exempel och ritar en röd guide över motsvarande connector‑segment:

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

Den röda guiden markerar det beräknade segmentet efter koordinat‑transformeringen:

![connector-adjusted-4](connector-adjusted-4.png)

Dessa formler beskriver förinställningarna som används i exemplen, inte en universell connector‑modell. Validera justeringstyper, ramorientering och värdeintervall innan du tillämpar samma beräkning på en annan förinställning.

## **Hitta en connector‑riktningsvinkel**

Riktningen för en rak connector kan beräknas utifrån dess bredd och höjd, med horisontella och vertikala vändningar tillämpade. Följande exempel rapporterar den medurs vinkel från den positiva horisontella axeln i bild‑koordinater:

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

**Hur kan jag avgöra om en connector kan fästas på en form?**

Kontrollera formens [getConnectionSiteCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getconnectionsitecount/)‑värde. Ett positivt antal betyder att formen exponerar anslutningsställen. Validera det valda ställe‑indexet innan du tilldelar det till någon connector‑ände.

**Kan jag identifiera en connector‑justering med dess samlingsindex?**

Ett index är meningsfullt endast för en känd connector‑förinställning och samlingslayout. Kontrollera [AdjustValue.getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/adjustvalue/) innan du ändrar ett värde, och använd [AdjustValue.getName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/adjustvalue/getname/) som ytterligare information när samma semantiska typ förekommer mer än en gång.

**Vad händer när en ansluten form raderas?**

Den motsvarande connector‑änden blir fristående. Connectorn kvarstår på bilden och kan tas bort, placeras som en fri linje eller fästas på en annan form.

**Bevaras connector‑bindningar när en bild kopieras?**

Bindningar bevaras i allmänhet när de anslutna formerna kopieras med bilden. Om en connector kopieras utan någon av sina målformer måste den påverkade änden fästas igen.