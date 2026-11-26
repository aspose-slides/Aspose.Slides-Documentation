---
title: 在 .NET 中自訂簡報形狀
linktitle: 自訂形狀
type: docs
weight: 20
url: /zh-hant/net/custom-shape/
keywords:
- 自訂形狀
- 新增形狀
- 建立形狀
- 變更形狀
- 形狀幾何
- 幾何路徑
- 路徑點
- 編輯點
- 新增點
- 移除點
- 編輯操作
- 曲線角
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 簡報中建立和自訂形狀：幾何路徑、曲線角、複合形狀。"
---
## **概觀**

本文說明如何透過編輯點與幾何路徑編輯形狀幾何，來自訂 Aspose.Slides 簡報中的形狀。它展示如何使用 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 與 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) 來修改現有形狀、執行基本的路徑編輯操作、加入或刪除點，並將更新後的幾何套用回形狀。  
它同時示範如何建立自訂與複合形狀、構建具有曲線角的形狀、判斷形狀幾何是否為閉合，以及使用舊版的 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 與 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) 之間的轉換，以支援額外的幾何自訂情境。

## **使用編輯點變更形狀**

在 PowerPoint 中，您可以使用 **Edit Points** 來修改正方形：

* 將角落向內或向外移動。
* 調整某點的曲率。
* 新增點。

編輯點讓您能修改形狀的輪廓，或以現有形狀作為新形狀的基礎。

## **形狀編輯技巧**

![概觀圖](custom_shape_0.png)

編輯 PowerPoint 形狀時，請記住以下概念：

* 形狀（或其路徑）可以是閉合的或開放的。
* 形狀的路徑由錨點透過線段連接而成。
* 線段可以是直線或曲線。錨點與控制手柄決定其形狀。
* 錨點可分為角點、直線點或平滑點：
  * 在角點，相鄰的線段可以以角度相接。
  * 在平滑點，兩個控制手柄保持對齊且與錨點的距離相等。
  * 在直線點，兩個控制手柄保持對齊，但距離錨點的距離可以不同。
* 移動錨點或調整其手柄會改變形狀的輪廓。

若要透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 類別與 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) 介面。

* 一個 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 實例代表 [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) 物件的幾何路徑。
* 若要從 [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) 實例取得 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)，可使用 [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) 方法。
* 若要為形狀設定 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)，可使用以下方法：對於單一路徑的形狀使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)；對於多路徑的形狀使用 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)。
* 若要新增線段，可使用 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) 下的方法。
* 使用 [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) 與 [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) 屬性，可設定幾何路徑的外觀。
* 透過 [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) 屬性，可將 [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) 的幾何路徑取回為線段陣列。
* 在支援以下轉換方法的舊版中，您可以將 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 轉換為 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)。
* 使用 [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) 與 [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) 方法（來自 [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/) 類別）在 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 與 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) 之間進行轉換。

## **簡單編輯操作**

使用以下方法編輯幾何路徑。接受索引的多載會在路徑的線段陣列中以零為基礎的位址插入線段。

| 操作 | 方法 |
| --- | --- |
| 加入或插入直線。 | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| 加入或插入具有兩個控制點與終點的三次貝塞爾曲線。 | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| 加入或插入具有一個控制點與終點的二次貝塞爾曲線。 | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| 加入具有指定尺寸與角度（以度為單位）的橢圓弧。 | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| 關閉目前的圖形，將終點連接回起點。 | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| 設定圖形的起始點。 | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| 移除位於零為基礎索引的線段。 | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **為形狀加入自訂點**

此範例使用 [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) 將兩個點插入矩形形狀，並使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 套用編輯後的路徑。座標是相對於形狀本身的：兩個新點位於形狀中心，距左側 100 點、距上方 50 點。線段索引 1 與 4 分別將它們放置於上、下邊緣，將這些邊緣向內拉。

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

![範例1圖](custom_shape_1.png)

## **從形狀移除點**

此範例透過使用 [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) 移除零為基礎索引 2 的線段，來更改心形輪廓。使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 套用修改後的路徑，即可更新形狀的外輪廓。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```

![範例2圖](custom_shape_2.png)

## **建立自訂形狀**

此範例使用 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 建立一個五角星。外半徑與內半徑交替為 100 點與 50 點，定義星尖與凹陷；每 72 度的步進均勻分布五個星尖。路徑以 [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) 關閉，並使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 套用至矩形形狀，取代其輪廓。

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

![範例3圖](custom_shape_3.png)

## **建立複合自訂形狀**

此範例為形狀的上、下三分之一定義兩個閉合的 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 物件。使用 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) 套用兩條路徑，會產生一個單一的複合形狀，其中部三分之一留下空隙。

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
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```

![範例4圖](custom_shape_4.png)

## **建立具有曲線角的自訂形狀**

此範例將直線段與 [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) 結合，建立具有內向曲線角的形狀。每個角的大小以點為單位設定弧線的寬度與高度，而 -90 度的掃描角則繪製逆時針四分之一橢圓。完成的路徑使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 套用，最後將簡報儲存為 PPTX 格式。

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

## **判斷形狀幾何是否閉合**

以下輔助程式檢查每個非空的幾何路徑是否以閉合線段結束。它讀取 [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) ，並比較最後線段的 [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) 是否為 [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/)。若無非空路徑則回傳 false。此檢查每條路徑的最後指令，並不會檢查路徑內的每個子圖形。範例會對矩形印出 `True`。

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

## **檢查幾何路徑指令**

下載 [contour.pptx](contour.pptx) 並放置於應用程式的工作目錄中。第一張投影片包含一個形狀，其上邊緣為直線、具有一條三次貝塞爾曲線，且下邊緣為直線閉合。使用 [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) 讀取其路徑。每條路徑於 [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) 中以繪製順序列出其線段。每個線段的 [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) 決定如何讀取其 [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/)。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

該形狀位於投影片上的 (200, 100) 點。報告的點是相對於形狀本身的座標，(0, 0) 位於左上角，X 向右遞增，Y 向下遞增。閉合線段不使用其他座標即可返回起始點。

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint 形狀（上緣直線、右上至左下曲線、左緣直線）](contour.png)

## **擷取與檢查形狀元素**

使用 [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) 可將現有形狀檢查為包含路徑點與點類型的元素。將每個返回的 [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) 轉型為 [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) 以讀取其 [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) 與 [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) 陣列。此表示方式適用於輪廓分析或將幾何傳遞給自訂繪圖工具。

範例會開啟簡報，直接在第一張投影片上找到第一個幾何形狀，並印出其路徑線段。請使用包含直線與曲線線段的形狀之簡報，以觀察兩種輸出。此程式不會在群組內搜尋。

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
                i += 2; // 同時消耗兩個控制點和終點。
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

這些陣列依索引對應：`points[i]` 為點，`types[i]` 描述其角色。類型 `0` 表示開始圖形，類型 `1` 從前一點畫線至目前點。三次貝塞爾線段從前一終點開始，使用連續三個 type-`3` 項目：兩個控制點接著新的終點。迴圈會一次消費這三個項目，並檢查終點是否閉合。

點類型同時包含旗標。以 `0x07` 進行遮罩可識別線段類型，另以 `0x80` 測試可偵測閉合子路徑。例如，`129` (`0x81`) 代表閉合子路徑的直線終點，`131` (`0x83`) 代表閉合的貝塞爾終點。僅比較原始值與 `1` 或 `3` 會遺漏這些情況。其他旗標，如虛線 (`0x10`) 與標記 (`0x20`)，不會改變基礎線段類型。

**座標與變換。** 點的單位為 point (1/72 吋)，X 向右遞增，Y 向下遞增。對於未群組的形狀，擷取的座標已包含其 [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) 與 [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) 位置，且反映其目前的寬度與高度。例如，未旋轉的矩形位於 `(100, 200)`，大小為 `120 × 80`，其輪廓邊界為 `(100, 200)`–`(220, 280)`。不要再次加上形狀的位置。應減去其 X 與 Y 以取得相對於未旋轉框架的座標。

擷取的點未套用形狀的 [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) 或水平、垂直翻轉。若要重現顯示的輪廓，需在形狀中心周圍套用那些變換。對於群組形狀，亦須考慮群組座標映射與變換；請勿假設擷取的點即為最終渲染的投影片座標，或在子形狀框架已反映的情況下再次套用平移或縮放。

**檢查 vs. 編輯。** 擷取的陣列僅描述輪廓，變更它們不會更新原始形狀。當您的分析或繪圖程式碼需要點/類型陣列時，可採用此方式。若需要在形狀本地座標系統中的幾何指令或想編輯其幾何，請使用 [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/)。透過 [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 或 [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) 套用編輯後的路徑。

## **將 GeometryPath 轉換為 GraphicsPath (System.Drawing.Drawing2D)**

以下範例需要支援 [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) 的舊版 Aspose.Slides for .NET 組件，例如 25.10 版，且需在具備 `System.Drawing.Common` 的 Windows 環境下執行。這些轉換方法已於 [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) 中移除。

此範例將矩形輪廓與轉換為幾何的文字結合。輪廓的 [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) 設為停用填滿。[GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) 儲存文字輪廓，然後由 [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) 轉換為填滿的幾何路徑。使用 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) 套用兩條路徑，即可產生包含矩形與文字的單一形狀。若要進行相反方向的轉換，請使用 [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/)。

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

![範例5圖](custom_shape_5.png)

## **FAQ**

**在替換幾何後，填色與輪廓會發生什麼變化？**  
樣式仍保留在形狀上；僅輪廓會變更。填色與輪廓會自動套用至新的幾何。

**如何正確旋轉自訂形狀以及其幾何？**  
使用形狀的 [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) 屬性；幾何會隨形狀一起旋轉，因為它綁定於形狀自己的座標系統。

**我可以將自訂形狀轉換為影像以「鎖定」結果嗎？**  
可以。將所需的 [slide](/slides/zh-hant/net/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/net/create-shape-thumbnails/) 本身匯出為點陣格式；這可簡化後續對複雜幾何的處理。