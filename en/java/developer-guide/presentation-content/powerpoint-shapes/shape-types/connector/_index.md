---
title: Manage Connectors in Presentations in Java
linktitle: Connector
type: docs
weight: 10
url: /java/connector/
keywords:
- connector
- connector type
- connector point
- connector line
- connector angle
- connection site
- adjustment point
- connect shapes
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Learn how to add, attach, reroute, adjust, and inspect straight, bent, and curved PowerPoint connectors with Aspose.Slides for Java."
---

## **Overview**

A connector is a line that can remain attached to two shapes when either shape moves. Its ends attach to connection sites, represented by green dots in PowerPoint. Some bent and curved connectors also expose adjustment points, represented by orange dots, that control the position of individual connector segments.

Aspose.Slides represents connectors through the [IConnector](https://reference.aspose.com/slides/java/com.aspose.slides/iconnector/) interface. You can create them, attach their ends to shapes, choose connection sites, reroute them, and modify the geometry of connectors that have adjustment points.

## **Connector Types**

The [ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/) class includes straight, bent, and curved connector presets. The following table shows the available connector geometries and the number of adjustment points defined by each preset.

| Connector | Image | Number of adjustment points |
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

The number and meaning of adjustment points are part of the selected connector preset. Do not assume that two different connector types expose the same collection layout.

## **Connect Two Shapes**

Use [IShapeCollection.addConnector](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) to add a connector, and use [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) and [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) to attach its ends. After both ends are attached, [IConnector.reroute](https://reference.aspose.com/slides/java/com.aspose.slides/iconnector/#reroute--) selects a short route between the shapes.

The following example connects an ellipse and a rectangle with a bent connector:

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

Calling `reroute` can change the [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) and [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) values. Assign specific connection sites after rerouting if those sites must remain fixed.

{{% /alert %}}

## **Choose a Connection Site**

Each connectable shape reports its number of sites through [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Validate a preferred zero-based site index before assigning it to a connector end; site counts vary by shape geometry.

This example attaches the connector to a particular site on the ellipse when that site exists:

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

## **Adjust a Connector Point**

Connectors with adjustment points expose them through [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getAdjustments--). Inspect every [IAdjustValue](https://reference.aspose.com/slides/java/com.aspose.slides/iadjustvalue/) and check its [getType](https://reference.aspose.com/slides/java/com.aspose.slides/iadjustvalue/#getType--) value before changing it with [setRawValue](https://reference.aspose.com/slides/java/com.aspose.slides/iadjustvalue/#setRawValue-long-). The general rules for identifying preset shape adjustments are described in [Shape Manipulation](/slides/java/shape-manipulations/).

The number, order, meaning, and valid value range of connector adjustments depend on the connector preset. The adjustment type is read-only, while the adjustment value is writable. The read-only [getName](https://reference.aspose.com/slides/java/com.aspose.slides/iadjustvalue/#getName--) method provides additional identification when a connector contains more than one adjustment of the same semantic type.

### **Route Around an Obstacle**

In the following layout, a `BentConnector5` connector between two shapes passes through a third shape:

![connector-obstruction](connector-obstruction.png)

This code creates the obstructed connector:

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

Moving the vertical bend changes the route so that the connector bypasses the obstacle:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Instead of assuming that collection index `1` always represents the vertical bend, this example searches for `ConnectorBendPositionY` and changes it only when the expected semantic type is present:

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

A `BentConnector5` has two `ConnectorBendPositionX` adjustments and one `ConnectorBendPositionY` adjustment. If the type you need occurs more than once, inspect `getName` and the known geometry of that preset before selecting one. If an adjustment reports `ShapeAdjustmentType.Custom`, treat its meaning and range as preset-specific and do not change it until that contract is known.

## **Relate Adjustment Values to Connector Geometry**

For bent connectors, adjustment values can be used to estimate the positions of individual segments. These calculations are specific to the connector preset:

- `BentConnector4` normally exposes one `ConnectorBendPositionX` and one `ConnectorBendPositionY` adjustment.
- For these bend positions, dividing the value returned by `getRawValue` by `100000f` produces the fraction of the connector frame width or height used by the examples below.
- A connector frame can be rotated or flipped, so frame coordinates must be transformed before they are compared with slide coordinates.

The following examples use `getType` to identify the adjustments first. They do not treat collection indexes as portable identifiers.

### **Unrotated Connector**

The initial layout contains two text shapes connected by a `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

This example inspects the connector and obtains its horizontal and vertical bend adjustments:

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

To change both bends, locate each expected type and modify the values only after both have been found:

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

The result is a connector whose horizontal and vertical segments have moved:

![connector-adjusted-1](connector-adjusted-1.png)

Once the semantic types are known, their values can be converted into connector-frame coordinates. This example draws a thin rectangle over the vertical segment controlled by the two bend adjustments:

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

The guide shape marks the calculated segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Rotated or Flipped Connector**

When the same connector geometry is oriented vertically, its [IShape.getFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/#getFlipH--), and [ShapeFrame.getFlipV](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/#getFlipV--) values affect the conversion from connector-frame coordinates to slide coordinates.

This example creates and adjusts the vertically oriented connector:

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

The adjusted connector appears vertically between the shapes:

![connector-adjusted-3](connector-adjusted-3.png)

For an arbitrary rotation angle `alpha`, rotate a connector-frame point `(x, y)` around the frame center `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

The following code handles the 90-degree orientation used in this example and draws a red guide over the corresponding connector segment:

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

The red guide marks the calculated segment after the coordinate transformation:

![connector-adjusted-4](connector-adjusted-4.png)

These formulas describe the presets used in the examples, not a universal connector model. Validate the adjustment types, frame orientation, and value ranges before applying the same calculation to a different preset.

## **Find a Connector Direction Angle**

The direction of a straight connector can be calculated from its width and height, with horizontal and vertical flips applied. The following example reports the clockwise angle from the positive horizontal axis in slide coordinates:

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

**How can I tell whether a connector can attach to a shape?**

Check the shape's [getConnectionSiteCount](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getConnectionSiteCount--) value. A positive count means the shape exposes connection sites. Validate the selected site index before assigning it to either connector end.

**Can I identify a connector adjustment by its collection index?**

An index is meaningful only for a known connector preset and collection layout. Check [IAdjustValue.getType](https://reference.aspose.com/slides/java/com.aspose.slides/iadjustvalue/#getType--) before modifying a value, and use [IAdjustValue.getName](https://reference.aspose.com/slides/java/com.aspose.slides/iadjustvalue/#getName--) as additional information when the same semantic type occurs more than once.

**What happens when a connected shape is deleted?**

The corresponding connector end becomes detached. The connector remains on the slide and can be deleted, positioned as a free line, or attached to another shape.

**Are connector bindings preserved when a slide is copied?**

Bindings are generally preserved when the connected shapes are copied with the slide. If a connector is copied without one of its target shapes, the affected end must be attached again.
