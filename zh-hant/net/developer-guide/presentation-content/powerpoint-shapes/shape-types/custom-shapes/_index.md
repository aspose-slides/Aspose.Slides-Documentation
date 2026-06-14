---
title: .NET 中自訂簡報形狀
linktitle: 自訂形狀
type: docs
weight: 20
url: /zh-hant/net/custom-shape/
keywords:
- 自訂形狀
- 新增形狀
- 建立形狀
- 更改形狀
- 形狀幾何
- 幾何路徑
- 路徑點
- 編輯點
- 新增點
- 移除點
- 編輯操作
- 彎曲角
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 簡報中建立並自訂形狀：幾何路徑、彎曲角、合成形狀。"
---
## **概述**

本文說明如何透過編輯點與幾何路徑，編輯形狀的幾何結構，以自訂 Aspose.Slides 中的呈現形狀。它展示了如何使用 `GeometryPath` 和 `IGeometryPath` 來修改現有形狀、執行基本路徑編輯操作、加入或刪除點，並將更新後的幾何套用回形狀。

此外，本文亦示範如何建立自訂與合成形狀、使用彎曲角建立形狀、判斷形狀幾何是否閉合，以及在 `GeometryPath` 與 `GraphicsPath` 之間轉換，以應對其他幾何自訂情境。

## **使用編輯點變更形狀**

以正方形為例。在 PowerPoint 中，使用 **編輯點**，您可以  

* 將正方形的角向內或向外移動  
* 為角或點指定曲率  
* 為正方形新增點  
* 操控正方形上的點，等等  

基本上，您可以對任何形狀執行上述動作。藉由編輯點，您可以變更形狀或從現有形狀建立新形狀。

## **形狀編輯提示**

![概覽圖片](custom_shape_0.png)

在開始透過編輯點編輯 PowerPoint 形狀之前，您可能需要了解以下關於形狀的要點：

* 形狀（或其路徑）可以是閉合的，也可以是開放的。  
* 所有形狀至少由 2 個相互連接的錨點組成。  
* 線段可以是直線或曲線。錨點決定線段的性質。  
* 錨點可為角點、直點或平滑點：  
  * 角點是兩條直線在一個角度處相交的點。  
  * 平滑點是兩個手柄位於同一直線上，且線段以平滑曲線相接的點。此情況下，所有手柄與錨點的距離相等。  
  * 直點是兩個手柄位於同一直線上，且線段以平滑曲線相接的點。此情況下，手柄與錨點的距離不必相等。  
* 透過移動或編輯錨點（即改變線段的角度），即可改變形狀的外觀。  

為了透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供了[**GeometryPath**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometrypath) 類別與[**IGeometryPath**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometrypath) 介面。

* [GeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometrypath) 實例表示 [IGeometryShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometryshape) 物件的幾何路徑。  
* 若要從 `IGeometryShape` 取得 `GeometryPath`，可使用 [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometryshape/methods/getgeometrypaths) 方法。  
* 若要為形狀設定 `GeometryPath`，請使用以下方法：對 *實心形狀* 使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometryshape/methods/setgeometrypath)，對 *合成形狀* 使用 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometryshape/methods/setgeometrypaths)。  
* 若要新增線段，可使用屬於 [IGeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometrypath) 的方法。  
* 使用 [IGeometryPath.Stroke](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometrypath/properties/stroke) 與 [IGeometryPath.FillMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometrypath/properties/fillmode) 屬性，可設定幾何路徑的外觀。  
* 透過 [IGeometryPath.PathData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometrypath/properties/pathdata) 屬性，可將 `GeometryShape` 的幾何路徑以路徑段陣列的形式取得。  
* 若需額外的形狀幾何自訂選項，可將 [GeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometrypath) 轉換為 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)。  
* 使用 [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) 與 [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) 方法（來自 [ShapeUtil](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/shapeutil) 類別），可在 [GeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometrypath) 與 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 之間來回轉換。

## **簡易編輯操作**

以下 C# 程式碼示範如何  

**在路徑末端新增直線**

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**在路徑的指定位置新增直線：**

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**在路徑末端新增三次方貝塞爾曲線：**

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**在路徑的指定位置新增三次方貝塞爾曲線：**

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**在路徑末端新增二次方貝塞爾曲線：**

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**在路徑的指定位置新增二次方貝塞爾曲線：**

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**將給定弧段附加至路徑：**

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**關閉路徑的目前圖形：**

``` csharp
void CloseFigure();
```
**設定下一個點的位置：**

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**移除指定索引處的路徑段：**

``` csharp
void RemoveAt(int index);
```

## **向形狀加入自訂點**

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometryshape) 類別的實例，並設定 [ShapeType.Rectangle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapetype) 類型。  
2. 從形狀取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometrypath) 類別的實例。  
3. 在路徑的兩個上方錨點之間加入新點。  
4. 在路徑的兩個下方錨點之間加入新點。  
5. 將路徑套用至形狀。  

以下 C# 程式碼示範如何向形狀加入自訂點：

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![範例1圖片](custom_shape_1.png)

## **從形狀移除點**

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometryshape) 類別的實例，並設定 [ShapeType.Heart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapetype) 類型。  
2. 從形狀取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometrypath) 類別的實例。  
3. 移除路徑的段。  
4. 將路徑套用至形狀。  

以下 C# 程式碼示範如何從形狀移除點：

``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```

![範例2圖片](custom_shape_2.png)

## **建立自訂形狀**

1. 計算形狀的各個點。  
2. 建立 [GeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometrypath) 類別的實例。  
3. 用點填入路徑。  
4. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometryshape) 類別的實例。  
5. 將路徑套用至形狀。  

以下 C# 程式碼示範如何建立自訂形狀：

``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```

![範例3圖片](custom_shape_3.png)

## **建立合成自訂形狀**

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometryshape) 類別的實例。  
2. 建立第一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometrypath) 實例。  
3. 建立第二個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometrypath) 實例。  
4. 將這兩條路徑套用至形狀。  

以下 C# 程式碼示範如何建立合成自訂形狀：

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```

![範例4圖片](custom_shape_4.png)

## **建立具有彎曲角的自訂形狀**

以下 C# 程式碼示範如何建立具有內向彎曲角的自訂形狀；

```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **判斷形狀幾何是否閉合**

閉合形狀是指其所有邊緣相連，形成無間隙的單一邊界。此類形狀可以是簡單的幾何形狀，也可以是複雜的自訂輪廓。以下程式碼示例說明如何檢查形狀幾何是否閉合：

```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```

## **將 GeometryPath 轉換為 GraphicsPath（System.Drawing.Drawing2D）**

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometryshape) 類別的實例。  
2. 建立 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) 類別的實例，屬於 [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 命名空間。  
3. 使用 [ShapeUtil](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/shapeutil) 將 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) 實例轉換為 [GeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometrypath) 實例。  
4. 將路徑套用至形狀。  

以下 C# 程式碼—上述步驟的實作—示範 **GeometryPath** 與 **GraphicsPath** 之間的轉換流程：

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```

![範例5圖片](custom_shape_5.png)

## **常見問題**

**替換幾何後，填充與輪廓會發生什麼變化？**

樣式仍屬於形狀本身，僅輪廓會改變。填充與輪廓會自動套用到新幾何上。

**如何正確旋轉自訂形狀及其幾何？**

使用形狀的 [rotation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/rotation/) 屬性；幾何會隨形狀一起旋轉，因為它綁定於形狀自己的座標系統。

**我能將自訂形狀轉換為影像以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/net/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/net/create-shape-thumbnails/) 本身匯出為點陣格式，這樣在後續處理大量幾何時會更為簡便。