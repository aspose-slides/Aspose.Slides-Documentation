---
title: 在 .NET 中管理簡報的連接線
linktitle: 連接線
type: docs
weight: 10
url: /zh-hant/net/connector/
keywords:
- 連接線
- 連接線類型
- 連接點
- 連接線條
- 連接角度
- 連接站點
- 調整點
- 連接形狀
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 新增、附加、重新路由、調整與檢查直線、彎折與曲線 PowerPoint 連接線。"
---
## **概覽**

連接線是一條在任一形狀移動時仍可保持連接兩個形狀的線。其兩端會連接到連接點，這些連接點在 PowerPoint 中以綠點顯示。某些彎曲和曲線連接線還會顯示調整點，以橙點表示，這些點可控制個別連接線段的位置。

Aspose.Slides 透過 [IConnector](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iconnector/) 介面表示連接線。您可以建立連接線、將其兩端連接到形狀、選擇連接點、重新路由，並修改具有調整點的連接線的幾何形狀。

## **連接線類型**

[ShapeType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapetype/) 列舉包含直線、彎折與曲線連接線的預設。下表顯示可用的連接線幾何形狀以及每個預設定義的調整點數量。

| 連接線 | 圖片 | 調整點數量 |
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

調整點的數量與意義屬於所選的連接線預設。不要假設兩種不同的連接線類型會暴露相同的集合佈局。

## **連接兩個形狀**

使用 [IShapeCollection.AddConnector](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addconnector/) 新增連接線，並設定其 [StartShapeConnectedTo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/connector/startshapeconnectedto/) 與 [EndShapeConnectedTo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/connector/endshapeconnectedto/) 屬性。兩端皆連接後，呼叫 [IConnector.Reroute](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iconnector/reroute/) 會在形狀之間選擇最短路徑。

以下範例使用彎折連接線將橢圓與矩形連接：

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

{{% alert color="warning" title="Warning" %}}
呼叫 `Reroute` 可能會變更 [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/connector/startshapeconnectionsiteindex/) 與 [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/connector/endshapeconnectionsiteindex/) 的值。若這些連接點必須保持固定，請在重新路由後再指定特定的連接點。
{{% /alert %}}

## **選擇連接點**

每個可連接的形狀會透過 [ConnectionSiteCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/connectionsitecount/) 回傳其連接點數量。將首選的零基索引傳入連接線兩端前，請先驗證該索引是否在範圍內；不同形狀的幾何形狀會有不同的點數。

以下範例在橢圓上存在該點時，將連接線附加至該特定位點：

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

## **調整連接線點**

具有調整點的連接線會透過 [IGeometryShape.Adjustments](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometryshape/adjustments/) 暴露。檢查每個 [IAdjustValue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iadjustvalue/) 並於變更其 [RawValue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/adjustvalue/rawvalue/) 前先確認其 [Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/adjustvalue/type/)。有關辨識預設形狀調整的通則，請參考 [Shape Manipulation](/slides/zh-hant/net/shape-manipulations/)。

調整點的數量、順序、意義及有效值範圍取決於連接線的預設。`Type` 屬性為唯讀，而調整值則可寫入。唯讀的 [Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/adjustvalue/name/) 屬性在連接線包含多個相同語意類型的調整時，可提供額外辨識資訊。

### **繞過障礙物**

下圖的版面中，兩個形狀之間的 `BentConnector5` 穿過第三個形狀：

![connector-obstruction](connector-obstruction.png)

以下程式碼建立此受阻的連接線：

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

移動垂直彎折會改變路徑，使連接線繞過障礙物：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

此範例不假設集合索引 `1` 永遠代表垂直彎折，而是搜尋 `ConnectorBendPositionY`，且僅在預期的語意類型存在時才變更：

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

`BentConnector5` 具有兩個 `ConnectorBendPositionX` 調整與一個 `ConnectorBendPositionY` 調整。若需要的類型出現多次，請先檢查 `Name` 以及該預設的已知幾何形狀後再選擇。若調整回報 `ShapeAdjustmentType.Custom`，則其意義與範圍為特定預設專屬，除非已確認合約，否則不要變更它。

## **將調整值映射至連接線幾何形狀**

對於彎折連接線，調整值可用於估算各段的座標位置。以下計算僅適用於該連接線預設：

- `BentConnector4` 通常會暴露一個 `ConnectorBendPositionX` 與一個 `ConnectorBendPositionY` 調整。
- 對於這些彎折位置，`RawValue / 100000f` 會得到連接框寬度或高度的比例（見下例）。
- 連接框可能會旋轉或翻轉，因此在與投影片座標比較前必須先轉換框座標。

以下範例先使用 `Type` 辨識調整，再進行操作，未將集合索引視為可移植的識別子。

### **未旋轉的連接線**

初始版面包含兩個文字形狀，由 `BentConnector4` 連接：

![connector-shape-complex](connector-shape-complex.png)

此範例檢查連接線並取得其水平與垂直彎折調整：

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

若要同時變更兩個彎折，請先找到每個預期的類型，且僅在兩者皆找到後才修改其值：

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

結果是水平與垂直段皆已移動的連接線：

![connector-adjusted-1](connector-adjusted-1.png)

一旦確認語意類型，即可將其值轉換為連接框座標。此範例在兩個彎折調整所控制的垂直段上繪製一個細長的矩形：

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

指南形狀標示了計算出的段落：

![connector-adjusted-2](connector-adjusted-2.png)

### **旋轉或翻轉的連接線**

當相同的連接線幾何形狀以垂直方式呈現時，其 [Frame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/frame/)、[FlipH](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapeframe/fliph/)、[FlipV](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapeframe/flipv/) 會影響從連接框座標到投影片座標的轉換。

此範例建立並調整垂直方向的連接線：

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

調整後的連接線垂直顯示於兩形狀之間：

![connector-adjusted-3](connector-adjusted-3.png)

對於任意旋轉角度 `alpha`，將連接框點 `(x, y)` 圍繞框中心 `(x0, y0)` 旋轉：

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下程式碼處理本例使用的 90 度方向，並在相應的連接段上繪製紅色指南：

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

紅色指南標示了座標變換後的計算段：

![connector-adjusted-4](connector-adjusted-4.png)

這些公式說明了範例中使用的預設，而非通用的連接線模型。請在將相同計算套用至不同預設前，驗證調整類型、框方向與值範圍。

## **取得連接線方向角度**

可根據直線連接線的寬度與高度（考慮水平與垂直翻轉）計算其方向角度。以下範例回傳投影片座標系中正水平軸的順時針角度：

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

## **常見問題**

**如何判斷連接線是否可以附著於形狀？**

檢查形狀的 `ConnectionSiteCount`。正值表示該形狀公開連接點。將選取的點索引指派給任一連接線端之前，請先驗證索引是否有效。

**我可以依據集合索引辨識連接線調整嗎？**

索引僅在已知的連接線預設與集合佈局下才具有意義。變更值前先檢查 `IAdjustValue.Type`，如同一語意類型出現多次，請使用 `IAdjustValue.Name` 取得額外資訊。

**當已連接的形狀被刪除會發生什麼？**

對應的連接線端會變為分離狀態。連接線仍保留在投影片上，可自行刪除、作為自由線定位，或重新附著至其他形狀。

**複製投影片時，連接線的綁定會被保留嗎？**

在將形狀連同投影片一起複製時，綁定通常會被保留。如果僅複製了連接線而未複製其目標形狀，則必須再次將受影響的端點附著至適當的形狀。