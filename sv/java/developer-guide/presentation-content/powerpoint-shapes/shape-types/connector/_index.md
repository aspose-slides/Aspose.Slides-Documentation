---
title: Hantera konnektorer i presentationer i Java
linktitle: Konnektor
type: docs
weight: 10
url: /sv/java/connector/
keywords:
- konnektor
- konnektortyp
- konnektorpunkt
- konnektorlina
- konnektorvinkel
- anslutningsplats
- justeringspunkt
- anslut former
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till, fäster, omruttar, justerar och inspekterar raka, böjda och kurvade PowerPoint‑konnektorer med Aspose.Slides för Java."
---
## **Översikt**

En konnektor är en linje som kan förbli fäst vid två former när någon av formerna flyttas. Dess ändar ansluts till anslutningsplatser, representerade av gröna prickar i PowerPoint. Vissa böjda och kurvade konnektorer visar även justeringspunkter, representerade av orange prickar, som styr positionen för enskilda konnektorsegment.

Aspose.Slides representerar konnektorer via gränssnittet [IConnector](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iconnector/). Du kan skapa dem, fästa deras ändar på former, välja anslutningsplatser, omrutta dem och modifiera geometrin för konnektorer som har justeringspunkter.

## **Konnektortyper**

Klassen [ShapeType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapetype/) innehåller raka, böjda och kurvade konnektorpresetar. Följande tabell visar de tillgängliga konnektorgeometrierna och antalet justeringspunkter som definieras av varje preset.

| Konnektor | Bild | Antal justeringspunkter |
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

Antalet och betydelsen av justeringspunkter är en del av den valda konnektorpreseten. Anta inte att två olika konnektor­typer exponerar samma samlingslayout.

## **Koppla två former**

Använd [IShapeCollection.addConnector](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) för att lägga till en konnektor, och använd [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) och [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) för att fästa dess ändar. När båda ändarna är fästa väljer [IConnector.reroute](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iconnector/#reroute--) en kort rutt mellan formerna.

Följande exempel kopplar en ellips och en rektangel med en böjd konnektor:

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

Att anropa `reroute` kan ändra värdena för [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) och [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). Tilldela specifika anslutningsplatser efter omruttning om dessa platser måste förbli fasta.

{{% /alert %}}

## **Välj en anslutningsplats**

Varje form som kan anslutas rapporterar sitt antal platser via [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Validera ett föredraget nollbaserat platsindex innan du tilldelar det till en konnektors ände; antalet platser varierar beroende på formens geometri.

Detta exempel fäster konnektorn på en viss plats på ellipsen när den platsen finns:

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

## **Justera en konnektorpunkt**

Konnektorer med justeringspunkter exponerar dem via [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/sv/java/com.aspose.slides/igeometryshape/#getAdjustments--). Inspektera varje [IAdjustValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iadjustvalue/) och kontrollera dess [getType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iadjustvalue/#getType--)‑värde innan du ändrar det med [setRawValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iadjustvalue/#setRawValue-long-). De allmänna reglerna för att identifiera preset‑formjusteringar beskrivs i [Shape Manipulation](/slides/sv/java/shape-manipulations/).

Antalet, ordningen, betydelsen och det giltiga värdeintervallet för konnektorjusteringar beror på konnektorpreseten. Justeringstypen är skrivskyddad, medan justeringsvärdet är skrivbart. Den skrivskyddade metoden [getName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iadjustvalue/#getName--) ger ytterligare identifiering när en konnektor innehåller fler än en justering av samma semantiska typ.

### **Rutt runt ett hinder**

I den följande layouten passerar en `BentConnector5`‑konnektor mellan två former genom en tredje form:

![connector-obstruction](connector-obstruction.png)

Denna kod skapar den hindrade konnektorn:

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

Att flytta den vertikala böjen ändrar rutten så att konnektorn går förbi hindret:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Istället för att anta att samlingsindex `1` alltid representerar den vertikala böjen söker detta exempel efter `ConnectorBendPositionY` och ändrar det endast när den förväntade semantiska typen finns:

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

En `BentConnector5` har två `ConnectorBendPositionX`‑justeringar och en `ConnectorBendPositionY`‑justering. Om den typ du behöver förekommer mer än en gång, inspektera `getName` och den kända geometrin för den preset innan du väljer en. Om en justering rapporterar `ShapeAdjustmentType.Custom` behandla dess betydelse och intervall som preset‑specifikt och ändra den inte förrän kontraktet är känt.

## **Relatera justeringsvärden till konnektorgeometri**

För böjda konnektorer kan justeringsvärden användas för att uppskatta positionerna för enskilda segment. Dessa beräkningar är specifika för konnektorpreseten:

- `BentConnector4` exponerar normalt en `ConnectorBendPositionX`‑ och en `ConnectorBendPositionY`‑justering.
- För dessa böjpositioner ger division av värdet som returneras av `getRawValue` med `100000f` bråkdelen av konnektorramens bredd eller höjd som används i exemplen nedan.
- En konnektorram kan roteras eller vändas, så ramkoordinater måste transformeras innan de jämförs med bildens koordinater.

Följande exempel använder `getType` för att först identifiera justeringarna. De behandlar inte samlingsindex som portabla identifierare.

### **Icke-roterad konnektor**

Den initiala layouten innehåller två textformer kopplade med en `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Detta exempel inspekterar konnektorn och hämtar dess horisontella och vertikala böjningsjusteringar:

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

Resultatet blir en konnektor vars horisontella och vertikala segment har flyttats:

![connector-adjusted-1](connector-adjusted-1.png)

När de semantiska typerna är kända kan deras värden konverteras till konnektor‑ramkoordinater. Detta exempel ritar en tunn rektangel över det vertikala segmentet som styrs av de två böjningsjusteringarna:

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

Guide‑formen markerar det beräknade segmentet:

![connector-adjusted-2](connector-adjusted-2.png)

### **Roterad eller speglad konnektor**

När samma konnektorgeometri är orienterad vertikalt påverkar [IShape.getFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapeframe/#getFlipH--) och [ShapeFrame.getFlipV](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapeframe/#getFlipV--) värdena konverteringen från konnektor‑ramkoordinater till bildkoordinater.

Detta exempel skapar och justerar den vertikalt orienterade konnektorn:

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

Den justerade konnektorn visas vertikalt mellan formerna:

![connector-adjusted-3](connector-adjusted-3.png)

För en godtycklig rotationsvinkel `alpha`, rotera en point i konnektor‑ramen `(x, y)` runt ramens centrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Följande kod hanterar den 90‑graders orientering som används i detta exempel och ritar en röd guide över motsvarande konnektorsegment:

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

Den röda guiden markerar det beräknade segmentet efter koordinattransformationen:

![connector-adjusted-4](connector-adjusted-4.png)

Dessa formler beskriver presetarna som används i exemplen, inte en universell konnektormodell. Validera justeringstyper, ramorientering och värdeintervall innan du tillämpar samma beräkning på en annan preset.

## **Hitta en konnektorriktningsvinkel**

Riktningen för en rak konnektor kan beräknas från dess bredd och höjd, med horisontella och vertikala speglingar tillämpade. Följande exempel rapporterar den medurs vinkel från den positiva horisontella axi­sen i bildkoordinater:

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

**Hur kan jag avgöra om en konnektor kan fästas vid en form?**

Kontrollera formens [getConnectionSiteCount](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getConnectionSiteCount--)‑värde. Ett positivt antal betyder att formen exponerar anslutningsplatser. Validera det valda platsindexet innan du tilldelar det till någon av konnektorens ändar.

**Kan jag identifiera en konnektorjustering via dess samlingsindex?**

Ett index är meningsfullt endast för en känd konnektorpreset och samlingslayout. Kontrollera [IAdjustValue.getType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iadjustvalue/#getType--) innan du ändrar ett värde, och använd [IAdjustValue.getName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iadjustvalue/#getName--) som ytterligare information när samma semantiska typ förekommer mer än en gång.

**Vad händer när en ansluten form raderas?**

Den motsvarande konnektoränden blir fristående. Konnektorn förblir på bilden och kan raderas, placeras som en fri linje eller fästas på en annan form.

**Behålls konnektorbindingar när en bild kopieras?**

Bindningar bevaras i allmänhet när de anslutna formerna kopieras med bilden. Om en konnektor kopieras utan någon av sina målformer måste den påverkade änden fästas igen.