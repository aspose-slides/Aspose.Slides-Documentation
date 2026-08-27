---
title: Hantera anslutningar i presentationer på Android
linktitle: Anslutning
type: docs
weight: 10
url: /sv/androidjava/connector/
keywords:
- anslutning
- anslutningstyp
- anslutningspunkt
- anslutningslinje
- anslutningsvinkel
- anslutningsplats
- justeringspunkt
- anslut former
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till, fäster, omdirigerar, justerar och inspekterar raka, böjda och kurviga PowerPoint-anslutningar med Aspose.Slides för Android via Java."
---
## **Översikt**

En anslutning är en linje som kan förbli fäst vid två former när någon av formerna flyttas. Dess ändar fästs vid anslutningsplatser, som representeras av gröna prickar i PowerPoint. Vissa böjda och kurviga anslutningar visar också justeringspunkter, representerade av orange prickar, som styr positionen för enskilda anslutningssegment.

Aspose.Slides representerar anslutningar via gränssnittet [IConnector](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iconnector/). Du kan skapa dem, fästa deras ändar vid former, välja anslutningsplatser, omdirigera dem och ändra geometrin för anslutningar som har justeringspunkter.

## **Anslutningstyper**

Klassen [ShapeType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapetype/) innehåller raka, böjda och kurviga anslutningsförinställningar. Följande tabell visar tillgängliga anslutningsgeometrier och antalet justeringspunkter som definieras av varje förinställning.

| Anslutning | Bild | Antal justeringspunkter |
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

Antalet och betydelsen av justeringspunkterna är en del av den valda anslutningsförinställningen. Anta inte att två olika anslutningstyper visar samma samlingslayout.

## **Anslut två former**

Använd [IShapeCollection.addConnector](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) för att lägga till en anslutning, och använd [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) och [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) för att fästa dess ändar. När båda ändarna är fästa, väljer [IConnector.reroute](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iconnector/#reroute--) en kort rutt mellan formerna.

Följande exempel ansluter en ellips och en rektangel med en böjd anslutning:

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

{{% alert color="warning" title="Varning" %}}
Att anropa `reroute` kan ändra värdena för [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) och [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). Tilldela specifika anslutningsplatser efter omdirigering om dessa platser måste förbli fasta.
{{% /alert %}}

## **Välj en anslutningsplats**

Varje form som kan anslutas rapporterar sitt antal platser via [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--). Validera ett föredraget nollbaserat platsindex innan du tilldelar det till en anslutningsände; antalet platser varierar beroende på formens geometri.

Detta exempel fäster anslutningen vid en specifik plats på ellipsen när den platsen finns:

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

## **Justera en anslutningspunkt**

Anslutningar med justeringspunkter visar dem via [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--). Inspektera varje [IAdjustValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iadjustvalue/) och kontrollera dess [getType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iadjustvalue/#getType--) innan du ändrar det med [setRawValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-). De allmänna reglerna för att identifiera förinställda formjusteringar beskrivs i [Shape Manipulation](/slides/sv/androidjava/shape-manipulations/).

Antalet, ordningen, betydelsen och giltiga värdeintervall för anslutningsjusteringar beror på anslutningsförinställningen. Justeringstypen är skrivskyddad, medan justeringsvärdet är skrivbart. Den skrivskyddade metoden [getName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iadjustvalue/#getName--) ger ytterligare identifiering när en anslutning innehåller mer än en justering av samma semantiska typ.

### **Rutt runt ett hinder**

I följande layout passerar en `BentConnector5`-anslutning mellan två former genom en tredje form:

![connector-obstruction](connector-obstruction.png)

Denna kod skapar den hindrade anslutningen:

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

Att flytta den vertikala böjen ändrar rutten så att anslutningen går runt hindret:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Istället för att anta att samlingsindex `1` alltid representerar den vertikala böjen, söker detta exempel efter `ConnectorBendPositionY` och ändrar den bara när den förväntade semantiska typen finns:

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

En `BentConnector5` har två `ConnectorBendPositionX`-justeringar och en `ConnectorBendPositionY`-justering. Om den typ du behöver förekommer mer än en gång, inspektera `getName` och den kända geometrin för den förinställningen innan du väljer en. Om en justering rapporterar `ShapeAdjustmentType.Custom` bör dess betydelse och intervall behandlas som förinställningsspecifika och inte ändras förrän kontraktet är känt.

## **Relatera justeringsvärden till anslutningsgeometri**

För böjda anslutningar kan justeringsvärden användas för att uppskatta positionerna för enskilda segment. Dessa beräkningar är specifika för anslutningsförinställningen:

- `BentConnector4` visar normalt en `ConnectorBendPositionX` och en `ConnectorBendPositionY`-justering.
- För dessa böjningspositioner ger division av värdet som returneras av `getRawValue` med `100000f` bråkdelen av anslutningsramens bredd eller höjd som används i exemplen nedan.
- En anslutningsram kan roteras eller speglas, så ramkoordinater måste transformeras innan de jämförs med bildens koordinater.

Följande exempel använder `getType` för att först identifiera justeringarna. De behandlar inte samlingsindex som portabla identifierare.

### **Orotinerad anslutning**

Den ursprungliga layouten innehåller två textformer som är förenade av en `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Detta exempel inspekterar anslutningen och hämtar dess horisontella och vertikala böjningsjusteringar:

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

För att ändra båda böjarna, lokalisera varje förväntad typ och modifiera värdena först när båda har hittats:

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

Resultatet blir en anslutning vars horisontella och vertikala segment har förflyttats:

![connector-adjusted-1](connector-adjusted-1.png)

När de semantiska typerna är kända kan deras värden konverteras till anslutningsramens koordinater. Detta exempel ritar en tunn rektangel över det vertikala segmentet som styrs av de två böjningsjusteringarna:

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

Guidformen markerar det beräknade segmentet:

![connector-adjusted-2](connector-adjusted-2.png)

### **Roterad eller speglad anslutning**

När samma anslutningsgeometri är orienterad vertikalt påverkar värdena för [IShape.getFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapeframe/#getFlipH--) och [ShapeFrame.getFlipV](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapeframe/#getFlipV--) konverteringen från anslutningsramens koordinater till bildkoordinater.

Detta exempel skapar och justerar den vertikalt orienterade anslutningen:

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

Den justerade anslutningen visas vertikalt mellan formerna:

![connector-adjusted-3](connector-adjusted-3.png)

För en godtycklig rotationsvinkel `alpha`, rotera en punkt i anslutningsramen `(x, y)` kring ramcentrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Följande kod hanterar den 90‑graders orientering som används i detta exempel och ritar en röd guide över motsvarande anslutningssegment:

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

Den röda guiden markerar det beräknade segmentet efter koordinattransformationen:

![connector-adjusted-4](connector-adjusted-4.png)

Dessa formler beskriver förinställningarna som används i exemplen, inte en universell anslutningsmodell. Validera justeringstyper, ramorientering och värdeintervall innan du tillämpar samma beräkning på en annan förinställning.

## **Hitta en anslutningsriktningens vinkel**

Riktningen för en rak anslutning kan beräknas från dess bredd och höjd, med horisontella och vertikala speglingar tillämpade. Följande exempel rapporterar vinkeln i medurs riktning från den positiva horisontella axeln i bildkoordinater:

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

## **Vanliga frågor**

**Hur kan jag avgöra om en anslutning kan fästa på en form?**

Kontrollera formens [getConnectionSiteCount](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--)‑värde. Ett positivt antal betyder att formen exponerar anslutningsplatser. Validera den valda platsindexen innan du tilldelar den till någon av anslutningens ändar.

**Kan jag identifiera en anslutningsjustering genom dess samlingsindex?**

Ett index är meningsfullt endast för en känd anslutningsförinställning och samlingslayout. Kontrollera [IAdjustValue.getType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iadjustvalue/#getType--) innan du ändrar ett värde, och använd [IAdjustValue.getName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iadjustvalue/#getName--) som ytterligare information när samma semantiska typ förekommer mer än en gång.

**Vad händer när en ansluten form raderas?**

Den motsvarande anslutningsänden blir frikopplad. Anslutningen förblir på bilden och kan raderas, placeras som en fri linje eller fästas till en annan form.

**Behåller anslutningskopplingar sig när en bild kopieras?**

Kopplingar bevaras i allmänhet när de anslutna formerna kopieras med bilden. Om en anslutning kopieras utan någon av sina målformer måste den berörda änden fästas på nytt.