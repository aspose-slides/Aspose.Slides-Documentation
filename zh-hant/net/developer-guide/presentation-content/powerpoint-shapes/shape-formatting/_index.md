---
title: 在 .NET 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/net/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 草圖效果
- 形狀線條草圖
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 形狀透明度
- 黑白形狀渲染
- 灰階形狀渲染
- 旋轉形狀
- 3D 倒角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 C# 中使用 Aspose.Slides 格式化 PowerPoint 形狀——精確且完整控制 PPT 與 PPTX 檔案的填色、線條與效果樣式。"
---
## **簡介**

格式化 PowerPoint 中的形狀，透過調整輪廓、填色和效果。Aspose.Slides for .NET 讓您以程式方式控制這些設定，包括透明度、旋轉和 3D 格式設定。

![PowerPoint 中的形狀格式化選項](format-shape-powerpoint.png)

Aspose.Slides for .NET 提供介面和屬性，讓您使用 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用 [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) 來控制形狀的輪廓。此範例建立一個未填充的矩形，藍色、虛線輪廓。 [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) 選取粗細複合線， while [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) 設定寬度為 7 點，且 [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) 選擇虛線樣式。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

結果：

![投影片中格式化的線條](formatted-lines.png)

### **設定自訂線條虛線模式**

當預先定義的線條樣式無法提供所需的虛線長度與間隙時，使用 [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/)。例如品牌輪廓或技術圖表。指派圖案會自動將 [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) 設為 [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/)。

陣列項目在虛線與間隙長度之間交替，從虛線開始。每個值都是線寬的倍數：`{ 4, 2 }` 在寬度 3 點時產生 12 點虛線，接著 6 點間隙。使用成對的有限、非負值來定義完整的虛線‑間隙區段。範例使用正值，以確保每段虛線與間隙均可見。

此範例建立五條相同長度且端點為平頭的藍色線條。前三條在寬度 3 點時比較不同圖案；第四條以兩倍寬度重複第一個圖案，將虛線與間隙長度皆加倍；第五條則從自訂圖案切換為實線。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Return the last line to a solid style.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

若要改回預先定義的虛線樣式，將 [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) 指派給 [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/)。所選樣式控制線條的外觀。

PowerPoint 中由上至下的結果：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![三種自訂虛線圖案、使用第一種圖案的較寬線條，以及 PowerPoint 中的實線](custom-dash-patterns.png)


### **設定線條端點樣式**

使用 [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) 來設定開放線條的兩端。 [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) 列舉提供三種明確的端點樣式：

- `Flat`：筆畫在端點停止。
- `Round`：半圓形端點延伸超過端點半個線寬。
- `Square`：方形端點延伸超過端點半個線寬。

列舉同時包含 `NotDefined`，表示未明確指定端點樣式。

端點樣式不同於箭頭（會在端點加入符號）與接合方式（控制線段之間的角落）。此範例透過 [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) 與 [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) 停用箭頭，以便僅比較端點形狀。

以下範例建立三條在其他屬性上相同的水平線，寬度為 20 點。從上到下分別使用平頭、圓頭與方頭。它們的端點具有相同的水平座標；圓頭與方頭各在端點之外延伸 10 點。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

PowerPoint 中由上至下的結果：**Flat**、**Round** 與 **Square**。

![PowerPoint 中相同粗線的平頭、圓頭與方頭端點](line-caps.png)

## **將草圖效果套用到形狀線條**

草圖效果讓形狀線條看起來手繪。使用 [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) 取得線條設定，使用 [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) 取得草圖設定，並使用 [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) 從 [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 列舉中選擇值。

以下 C# 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 效果、讀取明確指派的值，以及使用 [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 移除效果：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

由 [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) 回傳的值代表直接指派給形狀的設定。如果線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/)，取得 [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/)，並讀取 [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/)。有效值反映繼承解析後實際套用的格式。此範例需要一個已有投影片且第一張投影片上至少有一個形狀的簡報，並輸出兩個值：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var shape = presentation.Slides[0].Shapes[0];

var lineFormat = shape.LineFormat;
var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **格式化接合樣式**

以下是三種接合類型選項：

* Round
* Miter
* Bevel

接合樣式決定兩段輪廓在拐角處的相遇方式。使用 **Round** 取得圓角，**Miter** 取得尖角，或 **Bevel** 取得平緩角。

![投影片中的接合樣式](join-style-powerpoint.png)

此範例建立三個黑色矩形，藍色輪廓寬度 15 點。分別將 [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) 設為 [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) 的 miter、bevel 與 round 值，以比較角落的繪製方式。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **在尖銳拐角限制斜接**

使用 [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) 搭配將 [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) 設為 [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) 以限制尖銳拐角的延伸距離。

此限制是內外拐角距離與線寬的比例。例如，數值 `8` 允許斜接長度最高為線寬的八倍；它不是以點數作為測量單位。如果拐角超過此限制，PowerPoint 會在該拐角使用斜接。較大的限制會產生更尖銳的點。此設定僅影響斜接，當拐角未超過限制時，變更不會產生可見效果。

此範例建立兩個相同、未填充的三角形，輪廓寬度 20 點。左側三角形使用限制 `2`，右側使用 `8`。每個三角形寬 80 點、高 160 點，使其頂部拐角的斜接長度與線寬比例約為 `4.12`。因此，PowerPoint 會將左側頂點斜接，右側則保留尖銳頂點。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

PowerPoint 中的結果：左側 **Miter limit 2**，右側 **miter limit 8**。

![PowerPoint 中斜接限制 2 的斜角與斜接限制 8 的尖角](miter-limits.png)

## **漸層填色**

漸層填色在形狀內混合顏色。此範例使用 [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/) 以 45 度角將橢圓由紅色漸變為紫色的線性漸層。透過 [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) 方法將顏色停點放在 0 與 1（漸層的起點與終點）。清除現有的停點可確保僅使用這兩種顏色。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

結果：

![使用漸層填色的橢圓](gradient-fill.png)

如果匯出影像時的漸層與 PowerPoint 中顯示不同，請參閱 [Choose a Gradient Rendering Style](/slides/zh-hant/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不更改投影片中儲存的漸層填色的情況下選擇渲染樣式。

### **設定線性漸層角度**

使用 [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) 來控制 [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) 填色的方向。角度以度為單位，順時針遞增：`0` 從左到右，`90` 從上到下，`180` 從右到左，`270` 從下到上。支援小數角度。超出 `[0, 360)` 的有限角度會正規化為一圈，例如 `-45` 轉為 `315`，`360` 轉為 `0`。

此範例建立六個矩形，紅、綠、藍三種停點皆位於位置 `0`、`0.5`、`1`。關閉縮放，使角度比較不受矩形比例影響。左至右的角度分別為第一行的 `0`、`45`、`90`，第二行的 `135`、`180`、`270`。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

PowerPoint 中的結果：

![上排 0、45、90 度線性漸層，下排 135、180、270 度線性漸層](linear-gradient-angles.png)

### **以形狀縮放線性漸層**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) 接受 [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 值。明確設定為 `False` 可在形狀比例變化時保持幾何漸層角度不變，設定為 `True` 則會隨形狀寬高縮放漸層。啟用縮放時，非正方形形狀的可見角度可能與指派的角度不同。

以下範例使用 `45` 度角度與與角度比較相同的顏色停點。左欄使用 `False`，右欄使用 `True`。每欄包含一個寬矩形上方與一個高矩形下方。兩者起始皆為相同的寬尺寸；改變第二個矩形的寬高即可示範在不變更漸層設定的情況下，填色如何回應大小調整。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

PowerPoint 中的結果，左側縮放停用、右側縮放啟用：

![左側 LinearGradientScaled 為 False、右側為 True 的寬高矩形比較圖](linear-gradient-scaling.png)

縮放停用時，對角色帶在兩個矩形中保持相同方向。啟用縮放時，色帶會隨形狀比例伸展。這有助於在將形狀調整為不同尺寸時，重新製作範本的漸層。於正方形上，啟用縮放不會改變此 `45` 度漸層的外觀。

角度與縮放設定皆套用於線性漸層，並不控制 [GradientShape.Radial] 或 [GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) 填色。

### **將角度與漸層方向結合**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) 從 [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/) 列舉中選取漸層樣式；它並非數值角度的替代品。對於線性漸層，角落樣式可在不變更 [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) 的情況下改變顏色分佈區域。比較角度或縮放時請保持方向不變。

以下範例以相反順序套用相同設定。兩個矩形的外觀相同：先設定方向再設定角度或相反順序皆不會改變結果。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **圖案填色**

圖案填色套用兩色設計，例如點、條紋或格子。此範例使用 [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) 選取格子圖案。 [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) 提供淡灰色背景， [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) 提供黃色圖案顏色。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

結果：

![使用圖案填色的矩形](pattern-fill.png)

## **圖片填色**

圖片填色在形狀內使用圖像。此範例需要本機圖片，並使用 [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) 將其載入簡報的影像集合。將 [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) 設為平鋪模式，可在矩形內重複圖像。以下顯示本範例使用的來源圖像：

![蓮花圖案](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

結果：

![使用圖片填色的形狀](picture-fill.png)

### **將圖片作為紋理平鋪**

若要將平鋪圖片設定為紋理並自訂平鋪行為，可使用下列 [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) 類別的屬性：

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/)：設定圖片填色模式—`Tile` 或 `Stretch`。
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/)：指定平鋪在形狀內的對齊方式。
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/)：控制平鋪是否水平、垂直或同時翻轉。
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/)：設定平鋪相對於形狀原點的水平位移（點）。
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/)：設定平鋪相對於形狀原點的垂直位移（點）。
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/)：以百分比定義水平縮放。
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/)：以百分比定義垂直縮放。

此範例需要本機圖片，並將 [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) 設定為以原始大小 50% 重複平鋪。將 X 與 Y 偏移設定為 -32 點，使平鋪在水平與垂直方向上移動；右下對齊且同時翻轉，決定重複紋理的排列方式。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

結果：

![平鋪選項示意圖](tile-options.png)

## **純色填色**

純色填色為形狀賦予單一均勻的顏色。此範例將 [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 設為純色填色模式，並透過 [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) 指派黃色，最後將矩形儲存於簡報中。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

結果：

![使用純色填色的形狀](solid-color-fill.png)

## **使用投影片背景作為形狀填色**

當形狀應與投影片背景相同（例如在投影片範本中）時，使用 [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/)。先將 [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 設為 [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 以移除任何明確的填色。此組合會讓形狀使用投影片背景而非其樣式填色。僅啟用此旗標不會移除已存在的明確填色。

此行為不同於 [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/)：背景填色會以投影片背景的相應區域覆蓋形狀後面的物件，而無填色則會讓這些物件保持可見。漸層會與投影片對齊，而不會在每個形狀內重新開始。

以下範例建立一個由母片繼承的背景，並在三個矩形後放置品紅色帶。左側矩形使用背景，中間矩形無填色，右側矩形則從背景填色切換為明確的橙色填色。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// 從母片繼承漸層。
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// 先加入此物件，使其位於矩形後方。
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// 在套用明確填色之前停用背景填色。
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

結果由左到右：**背景填色**、**無填色**、**明確填色**。品紅色帶在左、右矩形後方被遮蔽，但在中間矩形仍可見。

![背景填色、無填色與明確橙色填色覆蓋在品紅色帶之上](background-fill.png)

相同的行為也適用於直接定義於投影片或從版面繼承的背景。形狀使用解析後的投影片背景；本範例未在投影片與版面上設定背景，因此由母片提供。

## **設定透明度**

對於純色填色，顏色的 alpha 成分控制不透明度：0 為完全透明，255 為完全不透明。此範例將 alpha 值設定為 128，為黃色矩形設定大約 50% 透明度，使底層矩形仍可見。顏色透過 [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) 指派。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

結果：

![透明的形狀](shape-transparency.png)

## **旋轉形狀**

使用 [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) 以度為單位在投影片平面上旋轉形狀。此範例將矩形順時針旋轉 5 度，並儲存簡報。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

結果：

![形狀旋轉效果](shape-rotation.png)

## **加入 3D 倒角效果**

使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) 為形狀賦予深度與倒角。此範例建立綠色橢圓、橙色輪廓，將 [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) 設為 4 點，並透過 [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/) 套用寬度與高度皆為 6 點的圓形上倒角。前視正投影相機與三點照明讓倒角可見。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

結果：

![3D 倒角效果示意圖](3D-bevel-effect.png)

## **加入 3D 旋轉效果**

形狀的 3D 觀察方式由相機設定控制。此範例使用 [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) 設定緯度、經度與旋轉角度分別為 40、35、20 度。透過 [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) 選擇等角相機，並使用 [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) 設定平衡光源，最後儲存格式化後的矩形。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

結果：

![3D 旋轉效果示意圖](3D-rotation-effect.png)

## **控制形狀的黑白渲染模式**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) 屬性指定在以黑白模式檢視或處理簡報時，個別形狀的渲染方式。它本身不會啟動黑白顯示，也不會在正常彩色模式下更改形狀的填色、線條或其他格式設定。

使用來自 [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) 列舉的值來選擇所需行為。例如，`Automatic` 讓渲染應用程式自行決定轉換方式，`Gray` 與 `LightGray` 使用灰階顏色，`BlackWhite` 只使用黑白，`Black` 與 `White` 強制單一顏色，`Color` 保持正常彩色，`Hidden` 在黑白模式下省略形狀。`NotDefined` 表示未指派形狀層級模式。

此範例建立橙色矩形，將 [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) 設為 `Gray`。儲存的形狀在正常彩色顯示時保留橙色填色，並在支援黑白顯示設定的應用程式中要求以灰階顯示：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

在正常彩色模式下，矩形保留橙色填色。於黑白顯示工作流程中，因模式設定為 `Gray`，它會以灰階顏色呈現。這讓您在保留全彩投影片的同時，為列印、預覽或其他遵循簡報黑白顯示設定的工作流程定義不同外觀。

## **重設格式化**

使用 [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) 從對應的版面佔位符還原投影片佔位符的位置、大小與格式。此範例需要一個已存在且版面連結佔位符的簡報，並在儲存前重設每張投影片。沒有對應版面佔位符的形狀不會被重設。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **常見問題集**

**形狀格式化會影響最終簡報檔案大小嗎？**

顏色、線條樣式與效果設定相較於嵌入的影像與媒體通常只會增加極少資料。圖片填色可能因圖像儲存於簡報中而增加檔案大小。

**如何偵測投影片上具有相同格式的形狀，以便將它們分組？**

比較每個形狀的關鍵格式屬性——填色、線條與效果設定。若所有對應值相符，便可將它們視為相同樣式，並在邏輯上將這些形狀分組，這樣可簡化之後的樣式管理。

**我可以將一組自訂形狀樣式儲存為單獨檔案，以便在其他簡報中重複使用嗎？**

可以。將帶有所需樣式的範本形狀存放於範本投影片或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製所需的樣式形狀，並在需要的地方重新套用其格式。