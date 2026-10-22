---
title: 在 .NET 中自訂簡報圖形
linktitle: 自訂圖形
type: docs
weight: 20
url: /zh-hant/net/custom-shape/
keywords:
- 自訂圖形
- 新增圖形
- 建立圖形
- 變更圖形
- 圖形幾何
- 幾何路徑
- 路徑點
- 編輯點
- 新增點
- 移除點
- 編輯操作
- 圓角
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 簡報中建立並自訂圖形：幾何路徑、圓角、組合圖形。"
---
## **概述**

本文說明如何透過編輯點與幾何路徑來自訂 Aspose.Slides 簡報中的圖形形狀。它展示了如何使用 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 與 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) 來修改現有圖形、執行基本路徑編輯操作、加入或移除點，並將更新後的幾何套用回圖形。

它亦示範如何建立自訂與組合圖形、建構具有圓角的圖形、判斷圖形幾何是否閉合，並使用舊版的 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 與 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) 之間的轉換，以因應其他幾何自訂情境。

## **使用編輯點變更圖形**

在 PowerPoint 中，您可以使用 **Edit Points** 來修改正方形：

* 向內或向外移動角落。
* 調整點的曲率。
* 新增點。

編輯點讓您調整圖形的輪廓，或以現有圖形作為新圖形的基礎。

## **圖形編輯提示**

![overview_image](custom_shape_0.png)

編輯 PowerPoint 圖形時，請記住以下概念：

* 圖形（或其路徑）可以是閉合的或開放的。
* 圖形的路徑由以線段相連的錨點組成。
* 線段可以是直線或曲線。錨點與控制手柄決定其形狀。
* 錨點有三種形式：角點、直線點或平滑點：
  * 角點：相鄰線段可在此處形成角度。
  * 平滑點：兩個控制手柄對齊且與錨點的距離相等。
  * 直線點：兩個控制手柄對齊，但與錨點的距離可不同。
* 移動錨點或調整其手柄會改變圖形的輪廓。

為了透過編輯點編輯 PowerPoint 圖形，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 類別與 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) 介面。

* [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 個例代表 [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) 物件的幾何路徑。
* 若要從 [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) 取得 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)，可使用 [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) 方法。
* 若要為圖形設定 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)，可使用以下方法：單一路徑圖形使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)；多路徑圖形使用 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)。
* 若要加入線段，可使用屬於 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) 的方法。
* 透過 [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) 與 [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) 屬性，可設定幾何路徑的外觀。
* 透過 [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) 屬性，可將 [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) 的幾何路徑取回為路徑線段陣列。
* 在支援以下轉換方法的舊版中，您可以將 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 轉換為 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)。
* 使用 [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) 與 [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) 方法（來自 [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/) 類別）在 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 與 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) 之間進行轉換。

## **簡易編輯操作**

使用下列方法編輯幾何路徑。接受索引的重載會在路徑的線段陣列中於該零基位置插入線段。

| 操作 | 方法 |
| --- | --- |
| 附加或插入直線。 | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| 附加或插入具有兩個控制點與端點的三次貝茲曲線。 | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| 附加或插入具有一個控制點與端點的二次貝茲曲線。 | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| 附加指定尺寸與角度（以度為單位）的橢圓弧。 | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| 透過將端點連回起始點來關閉目前圖形。 | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| 設定圖形的起始點。 | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| 移除零基索引處的線段。 | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **為圖形加入自訂點**

此範例使用 [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) 在矩形圖形中插入兩個點，並利用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 套用編輯後的路徑。座標是相對於圖形的本地座標：兩個新點皆位於圖形中心，距左側 100 點、距頂部 50 點。線段索引 1 與 4 分別將它們放在上緣與下緣，將這兩條邊向內拉。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **從圖形移除點**

此範例透過 [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) 移除零基索引 2 處的線段，以更改心形輪廓。使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 套用修改後的路徑，即可更新圖形的輪廓。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **建立自訂圖形**

此範例使用 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 建立五角星。交替的外半徑與內半徑分別為 100 點與 50 點，決定星尖與凹部；以 72 度的步幅均勻分布五個星尖。路徑最後以 [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) 關閉，並使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 套用到矩形圖形，取代其原始輪廓。

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **建立組合自訂圖形**

此範例為圖形的上、下三分之一各定義一個閉合的 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 物件。利用 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) 同時套用兩條路徑，即可產生一個在中間三分之一留下空隙的單一組合圖形。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **建立具有圓角的自訂圖形**

此範例將直線段與 [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) 結合，以建立具有內縮圓角的圖形。每個角的大小決定弧線的寬度與高度（單位為點），-90 度的掃描角畫出逆時針四分之一橢圓。完成的路徑使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 套用，最後將簡報存為 PPTX 格式。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **判斷圖形幾何是否閉合**

以下輔助程式會檢查每個非空幾何路徑是否以閉合線段結尾。它會讀取 [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/)，並將最後一段的 [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) 與 [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) 進行比較。若沒有非空路徑則回傳 false。此檢查僅檢視每條路徑的最後指令，並未檢查路徑內的每個子圖形。範例會對矩形輸出 `True`。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **擷取與檢查圖形元素**

使用 [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) 可將現有圖形檢查為包含路徑點與點類型的元素。將每個回傳的 [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) 轉型為 [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) 後，即可讀取其 [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) 與 [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) 陣列。此表示法適用於輪廓分析或將幾何傳遞給自訂繪圖工具。

範例會開啟簡報、在第一張投影片上直接找出第一個幾何圖形，並輸出其路徑線段。請使用包含直線與曲線線段的圖形來觀察雙種輸出。此程式不會在群組內部搜尋。

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // 保留線段類型，排除旗標。
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

陣列以索引對應：`points[i]` 為點，`types[i]` 描述其角色。類型 `0` 表示開始一個圖形，類型 `1` 表示從前一點畫直線至當前點。三次貝茲線段會從前一端點開始，使用連續三個類型 `3` 的項目：兩個控制點與新的端點。迴圈會一次消耗這三個項目，並檢查端點是否閉合。

點類型同時包含旗標。使用 `0x07` 取掩碼可辨識線段類型，另外測試 `0x80` 可偵測閉合子路徑。例如 `129`（`0x81`）代表閉合的直線端點，`131`（`0x83`）代表閉合的貝茲端點。僅比較原始值等於 `1` 或 `3` 會遺漏這些情況。其他旗標（例如虛線 `0x10`、標記 `0x20`）不會改變基礎線段類型。

**座標與變換。** 點的單位為點（1/72 吋），X 向右遞增，Y 向下遞增。對於未群組的圖形，擷取的座標已包含其 [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) 與 [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) 位置，並反映其目前的寬高。例如，未旋轉的矩形位於 `(100, 200)`、大小為 `120 × 80`，其輪廓界限為 `(100, 200)`–`(220, 280)`。請勿再次加上圖形的位置。若要取得相對於未旋轉框架的座標，請減去其 X 與 Y。

擷取的點不會套用圖形的 [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) 或水平、垂直翻轉。若要還原顯示的輪廓，需在圖形中心周圍套用這些變換。對於群組圖形，還必須考慮群組的座標映射與變換；不要假設擷取的點已是最終投影片座標，也不要在已反映於子項框架的情況下再次平移或縮放。

**檢查 vs. 編輯。** 擷取的陣列僅描述輪廓，變更它們不會更新原始圖形。當分析或繪圖程式需要點/類型陣列時，可使用此方式。若需要圖形指令在圖形本地座標系統中或想編輯其幾何，請使用 [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/)；編輯後透過 [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 或 [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) 套用。

## **將 GeometryPath 轉換為 GraphicsPath（System.Drawing.Drawing2D）**

以下範例需要支援 [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) 的舊版 Aspose.Slides for .NET 組件（例如 25.10 版），以及具備 `System.Drawing.Common` 的 Windows 環境。此轉換方法在 [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) 中已移除。

此範例將矩形輪廓與轉換為幾何的文字結合。輪廓的 [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) 設為不填充。[GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) 用於儲存文字輪廓，然後透過 [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) 轉換為填充的幾何路徑。將兩條路徑同時以 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) 套用，即可產生包含矩形與文字的單一圖形。若要反向轉換，請使用 [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/)。

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![example5_image](custom_shape_5.png)

## **常見問題**

**取代幾何後，填色與輪廓會發生什麼變化？**

樣式仍保留在圖形上，只有輪廓會變更。填色與輪廓會自動套用到新的幾何上。

**如何正確地讓自訂圖形連同其幾何一起旋轉？**

使用圖形的 [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) 屬性；幾何會隨圖形一起旋轉，因為它綁定於圖形自身的座標系統。

**我可以將自訂圖形轉換為影像以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/net/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/net/create-shape-thumbnails/) 本身匯出為點陣圖格式；這樣可簡化對複雜幾何的後續處理。