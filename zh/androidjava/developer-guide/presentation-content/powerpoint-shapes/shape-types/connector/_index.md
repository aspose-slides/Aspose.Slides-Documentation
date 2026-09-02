---
title: 在 Android 上管理演示文稿中的连接线
linktitle: 连接线
type: docs
weight: 10
url: /zh/androidjava/connector/
keywords:
- 连接线
- 连接线类型
- 连接点
- 连接线
- 连接角度
- 连接站点
- 调整点
- 连接形状
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android（Java）添加、附加、重新路由、调整和检查 PowerPoint 中的直线、弯曲和曲线连接线。"
---
## **概述**

连接线是一种在任意形状移动时仍可保持连接的线段。它的两端连接到连接点，在 PowerPoint 中表现为绿色的小圆点。某些弯曲和曲线连接线还会暴露出橙色的调整点，用于控制单个连接线段的位置。

Aspose.Slides 通过 [IConnector](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iconnector/) 接口来表示连接线。您可以创建连接线、将其两端连接到形状、选择连接点、重新路由以及修改具有调整点的连接线几何形状。

## **连接线类型**

[ShapeType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shapetype/) 类包含直线、弯曲和曲线连接线预设。下表显示了可用的连接线几何形状以及每个预设定义的调整点数量。

| 连接线 | 图像 | 调整点数量 |
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

调整点的数量和含义是所选连接线预设的一部分。不要假设不同的连接线类型会暴露相同的集合布局。

## **连接两个形状**

使用 [IShapeCollection.addConnector](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) 添加连接线，并使用 [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) 与 [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) 将两端连接到形状。两端均连接后，调用 [IConnector.reroute](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iconnector/#reroute--) 可在形状之间选择一条短路线。

下面的示例使用弯曲连接线将椭圆和矩形连接起来：

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
调用 `reroute` 可能会更改 [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) 与 [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) 的值。若这些站点必须保持固定，请在重新路由后再分配具体的连接点。
{{% /alert %}}

## **选择连接点**

每个可连接的形状可通过 [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) 报告其站点数量。在将首选的零基站点索引分配给连接线两端之前，请先验证该索引，因为站点数量随形状几何而异。

下面的示例在椭圆上存在特定站点时将连接线附着到该站点：

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

## **调整连接线点**

具有调整点的连接线可通过 [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) 访问。检查每个 [IAdjustValue](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iadjustvalue/) 并在更改前通过其 [getType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iadjustvalue/#getType--) 确认类型，然后使用 [setRawValue](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) 进行修改。[Shape Manipulation](/slides/zh/androidjava/shape-manipulations/) 中描述了识别预设形状调整的一般规则。

调整点的数量、顺序、含义以及有效值范围取决于连接线预设。调整类型为只读，调整值可写。只读的 [getName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iadjustvalue/#getName--) 方法在连接线包含多个相同语义类型的调整时提供额外的标识信息。

### **绕过障碍物的路径**

在下图布局中，一个 `BentConnector5` 连接线在两形状之间穿过第三个形状：

![connector-obstruction](connector-obstruction.png)

以下代码创建了受阻的连接线：

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

移动垂直弯曲点后，路径会改变，使连接线绕过障碍物：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

此示例避免假设集合索引 `1` 始终代表垂直弯曲，而是搜索 `ConnectorBendPositionY` 并仅在出现预期语义类型时进行修改：

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

`BentConnector5` 具有两个 `ConnectorBendPositionX` 调整和一个 `ConnectorBendPositionY` 调整。如果所需类型出现多次，请在选择之前检查 `getName` 与该预设已知的几何结构。若某调整报告为 `ShapeAdjustmentType.Custom`，则其含义和范围为特定预设专有，除非明确了解其契约，否则不要更改。

## **将调整值关联到连接线几何**

对于弯曲连接线，调整值可用于估算各段的位置。这些计算特定于连接线预设：

- `BentConnector4` 通常暴露一个 `ConnectorBendPositionX` 与一个 `ConnectorBendPositionY` 调整。
- 对于这些弯曲位置，将 `getRawValue` 返回的值除以 `100000f` 可得到连接线框宽度或高度的比例（如下例所示）。
- 连接线框可能被旋转或翻转，因此在与幻灯片坐标比较之前必须对框坐标进行变换。

以下示例首先使用 `getType` 来识别调整点，而不将集合索引视为可移植标识符。

### **未旋转的连接线**

初始布局中有两个文本形状由 `BentConnector4` 连接：

![connector-shape-complex](connector-shape-complex.png)

此示例检查连接线并获取其水平与垂直弯曲调整：

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

要更改两个弯曲点，请先定位每种预期类型并在找到全部后再修改其值：

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

结果是水平段和垂直段均已移动的连接线：

![connector-adjusted-1](connector-adjusted-1.png)

一旦知道语义类型，其值即可转换为连接线框坐标。此示例在受两段弯曲调整控制的垂直段上绘制一个细矩形：

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

导向形状标记出计算得到的段落：

![connector-adjusted-2](connector-adjusted-2.png)

### **旋转或翻转的连接线**

当相同的连接线几何垂直放置时，其 [IShape.getFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getFrame--)、[ShapeFrame.getFlipH](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shapeframe/#getFlipH--) 与 [ShapeFrame.getFlipV](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shapeframe/#getFlipV--) 值会影响从连接线框坐标到幻灯片坐标的转换。

此示例创建并调整了垂直方向的连接线：

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

调整后的连接线在形状之间垂直显示：

![connector-adjusted-3](connector-adjusted-3.png)

对于任意旋转角度 `alpha`，将连接线框点 `(x, y)` 绕框中心 `(x0, y0)` 旋转：

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下代码处理本示例中使用的 90 度方向，并在相应的连接线段上绘制红色导向：

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

红色导向标记出坐标变换后的计算段：

![connector-adjusted-4](connector-adjusted-4.png)

这些公式描述的是示例中使用的预设，而非通用的连接线模型。在将相同计算应用于其他预设之前，请务必验证调整类型、框方向以及数值范围。

## **获取连接线方向角度**

可以根据直线连接线的宽度和高度（并考虑水平、垂直翻转）计算其方向角度。以下示例报告幻灯片坐标系中相对于正水平轴的顺时针角度：

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

## **常见问题**

**如何判断连接线是否可以附着到形状上？**

检查形状的 [getConnectionSiteCount](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) 值。正值表示该形状公开连接点。分配站点索引之前请先验证所选索引。

**我能通过集合索引识别连接线的调整吗？**

索引仅在已知的连接线预设和集合布局下才有意义。修改值前请先检查 [IAdjustValue.getType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iadjustvalue/#getType--)，并在同一语义类型出现多次时使用 [IAdjustValue.getName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iadjustvalue/#getName--) 作为补充信息。

**当连接的形状被删除会怎样？**

相应的连接线端会被分离。连接线仍留在幻灯片上，可删除、作为自由线定位或重新附着到其他形状。

**复制幻灯片时是否会保留连接线的绑定？**

当连同幻灯片一起复制连接的形状时，绑定通常会被保留。如果仅复制了连接线而未复制其目标形状，则需要重新附着受影响的端点。