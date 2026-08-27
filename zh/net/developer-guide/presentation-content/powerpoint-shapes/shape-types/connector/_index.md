---
title: 在 .NET 中管理演示文稿中的连接器
linktitle: 连接器
type: docs
weight: 10
url: /zh/net/connector/
keywords:
- 连接器
- 连接器类型
- 连接器点
- 连接器线
- 连接器角度
- 连接点
- 调整点
- 连接形状
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 添加、附加、重新路由、调整和检查 PowerPoint 中的直线、弯折和曲线连接器。"
---
## **概述**

连接器是一条线，当任一形状移动时仍可保持连接到两个形状。它的两端连接到连接点，在 PowerPoint 中表现为绿色点。某些弯曲和曲线连接器还会暴露调节点，表现为橙色点，用于控制各个连接器段的位置。

Aspose.Slides 通过 [IConnector](https://reference.aspose.com/slides/zh/net/aspose.slides/iconnector/) 接口表示连接器。您可以创建它们、将两端连接到形状、选择连接点、重新路由，并修改具有调节点的连接器几何形状。

## **连接器类型**

[ShapeType](https://reference.aspose.com/slides/zh/net/aspose.slides/shapetype/) 枚举包含直线、弯折和曲线连接器预设。下表显示了可用的连接器几何形状以及每个预设定义的调节点数量。

| 连接器 | 图片 | 调节点数量 |
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

调节点的数量和含义是所选连接器预设的一部分。不要假设两种不同的连接器类型会暴露相同的集合布局。

## **连接两个形状**

使用 [IShapeCollection.AddConnector](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addconnector/) 添加连接器，并为其分配 [StartShapeConnectedTo](https://reference.aspose.com/slides/zh/net/aspose.slides/connector/startshapeconnectedto/) 和 [EndShapeConnectedTo](https://reference.aspose.com/slides/zh/net/aspose.slides/connector/endshapeconnectedto/) 属性。两端都连接后，[IConnector.Reroute](https://reference.aspose.com/slides/zh/net/aspose.slides/iconnector/reroute/) 会在形状之间选择一条短路径。

以下示例使用弯折连接器将椭圆和矩形相连：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="警告" %}}
调用 `Reroute` 可能会更改 [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh/net/aspose.slides/connector/startshapeconnectionsiteindex/) 和 [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh/net/aspose.slides/connector/endshapeconnectionsiteindex/) 的值。若这些连接点必须保持固定，请在重新路由后再次指定具体的连接点。
{{% /alert %}}

## **选择连接点**

每个可连接的形状通过 [ConnectionSiteCount](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/connectionsitecount/) 报告其连接点数量。在将其分配给连接器端点之前，请先验证所选的零基索引；不同形状的几何形状会导致连接点数量不同。

下面的示例在椭圆上存在该连接点时，将连接器附加到该特定连接点：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **调整连接点**

具有调节点的连接器通过 [IGeometryShape.Adjustments](https://reference.aspose.com/slides/zh/net/aspose.slides/igeometryshape/adjustments/) 暴露这些点。检查每个 [IAdjustValue](https://reference.aspose.com/slides/zh/net/aspose.slides/iadjustvalue/) 并在更改其 [RawValue](https://reference.aspose.com/slides/zh/net/aspose.slides/adjustvalue/rawvalue/) 之前先检查其 [Type](https://reference.aspose.com/slides/zh/net/aspose.slides/adjustvalue/type/)。有关识别预设形状调节的通用规则，请参阅 [Shape Manipulation](/slides/zh/net/shape-manipulations/)。

调节的数量、顺序、含义以及有效值范围取决于连接器预设。`Type` 属性为只读，而调节值是可写的。只读的 [Name](https://reference.aspose.com/slides/zh/net/aspose.slides/adjustvalue/name/) 属性在连接器包含多个相同语义类型的调节时提供额外的标识。

### **绕过障碍物的路径**

在下图布局中，`BentConnector5` 连接器在两形状之间经过第三个形状：

![connector-obstruction](connector-obstruction.png)

以下代码创建了受阻的连接器：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

移动垂直弯折会改变路径，使连接器绕过障碍物：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

本示例不假设集合索引 `1` 始终表示垂直弯折，而是搜索 `ConnectorBendPositionY`，仅在存在预期的语义类型时才进行更改：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

`BentConnector5` 拥有两个 `ConnectorBendPositionX` 调节和一个 `ConnectorBendPositionY` 调节。如果所需的类型出现多次，请在选择之前检查 `Name` 并参考该预设的已知几何形状。如果某个调节报告 `ShapeAdjustmentType.Custom`，则其含义和范围应视为特定预设，且在未明确合同前不要更改。

## **将调整值关联到连接器几何形状**

对于弯折连接器，调节值可用于估算各段位置。这些计算特定于连接器预设：

- `BentConnector4` 通常暴露一个 `ConnectorBendPositionX` 和一个 `ConnectorBendPositionY` 调节。
- 对于这些弯折位置，`RawValue / 100000f` 生成示例中使用的连接器框宽度或高度的比例。
- 连接器框可能被旋转或翻转，因而在与幻灯片坐标比较之前必须先转换框坐标。

以下示例首先使用 `Type` 来识别调节，而不是把集合索引当作通用标识符。

### **未旋转的连接器**

初始布局包含两个通过 `BentConnector4` 连接的文本形状：

![connector-shape-complex](connector-shape-complex.png)

本示例检查连接器并获取其水平和垂直弯折调节：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

要更改两个弯折，先定位每个预期的类型，待两者均找到后再修改其值：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

结果是水平和垂直段均已移动的连接器：

![connector-adjusted-1](connector-adjusted-1.png)

一旦确认语义类型，可将其值转换为连接器框坐标。本示例在由两个弯折调节控制的垂直段上绘制一个细矩形：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

导向形状标记出计算得到的段落：

![connector-adjusted-2](connector-adjusted-2.png)

### **旋转或翻转的连接器**

当相同的连接器几何形状以垂直方向呈现时，其 [Frame](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/frame/)、[FlipH](https://reference.aspose.com/slides/zh/net/aspose.slides/shapeframe/fliph/)、[FlipV](https://reference.aspose.com/slides/zh/net/aspose.slides/shapeframe/flipv/) 值会影响从连接器框坐标到幻灯片坐标的转换。

本示例创建并调整了垂直方向的连接器：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

调整后的连接器在形状之间垂直显示：

![connector-adjusted-3](connector-adjusted-3.png)

对于任意旋转角度 `alpha`，将连接器框点 `(x, y)` 绕框中心 `(x0, y0)` 旋转：

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下代码处理本示例中使用的 90 度方向，并在相应的连接器段上绘制红色导向：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

红色导向标记出坐标转换后的计算段：

![connector-adjusted-4](connector-adjusted-4.png)

这些公式描述的是示例中使用的预设，而非通用的连接器模型。请在将相同计算应用于不同预设之前，验证调节类型、框方向以及数值范围。

## **查找连接器方向角度**

直线连接器的方向可以根据其宽高并结合水平/垂直翻转进行计算。下面的示例报告了相对于幻灯片坐标中正水平轴的顺时针角度：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **常见问题**

**如何判断连接器是否可以附着到某个形状？**

检查形状的 `ConnectionSiteCount`。正数表示该形状公开连接点。在将站点索引分配给任一连接器端之前，请先验证所选索引。

**我能通过集合索引识别连接器调节吗？**

索引仅在已知的连接器预设和集合布局下有意义。修改值前请先检查 `IAdjustValue.Type`，当同一语义类型出现多次时，可使用 `IAdjustValue.Name` 作为补充信息。

**当已连接的形状被删除会发生什么？**

相应的连接器端点会被分离。连接器仍保留在幻灯片上，可删除、作为自由线移动，或重新附加到其他形状。

**复制幻灯片时连接器的绑定会保留吗？**

当与幻灯片一起复制了已连接的形状时，绑定通常会保留。如果只复制了连接器而未复制其目标形状，则必须再次将受影响的端点附加到相应形状。