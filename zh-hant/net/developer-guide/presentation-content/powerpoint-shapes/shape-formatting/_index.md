---
title: 在 .NET 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/net/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 手繪效果
- 手繪圖形線條
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 圖形透明度
- 黑白圖形呈現
- 灰階圖形呈現
- 旋轉圖形
- 3D 倒角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習如何在 C# 中使用 Aspose.Slides 格式化 PowerPoint 圖形——精確且完整地設定 PPT 與 PPTX 檔案的填色、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中調整圖案的輪廓、填色與效果。Aspose.Slides for .NET 讓您能以程式方式控制這些設定，包括透明度、旋轉與 3D 格式設定。

![PowerPoint 中的圖案格式選項](format-shape-powerpoint.png)

Aspose.Slides for .NET 提供介面與屬性，讓您使用 PowerPoint 中相同的選項來格式化圖案。

## **格式線條**

使用[IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) 來控制圖案的輪廓。此範例建立一個未填充、藍色虛線輪廓的矩形。[ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) 會選取粗細交替的複合線，而[ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) 將寬度設定為 7 點，且[ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) 會選擇虛線樣式。

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

![簡報中已格式化的線條](formatted-lines.png)

### **設定自訂虛線模式**

當預先定義的線條樣式無法提供所需的虛線長度與間隔時，可使用[ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/)，例如品牌輪廓或技術圖表。指定模式會自動將[ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) 設為[LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/)。

陣列項目交替為虛線與間隔長度，從虛線開始。每個數值都是線寬的倍數：在寬度為 3 點時，`{ 4, 2 }` 產生 12 點的虛線，接著 6 點的間隔。使用成對的有限、非負值來定義完整的虛線-間隔段落。範例使用正值以確保每段虛線與間隔皆可見。

此範例建立五條相同長度且端點為平坦的藍線。前三條在寬度 3 點時比較不同模式。第四條以兩倍寬度重複第一種模式，從而將虛線與間隔長度同時加倍。第五條則從自訂模式切換為實線。

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

若要改回預先定義的虛線樣式，請將[LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) 指派給[ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/)。選取的樣式會控制線條的外觀。

PowerPoint 中由上至下的結果：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![三種自訂虛線模式、使用第一種模式的較寬線條，以及 PowerPoint 中的實線](custom-dash-patterns.png)


### **設定線條端點樣式**

使用[ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) 來設定開放線條的兩端。[LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) 列舉提供三種明確的端點樣式：

- `Flat`：筆畫在端點處停止。
- `Round`：半圓形端點延伸至端點之外，長度為線寬的一半。
- `Square`：方形端點延伸至端點之外，長度為線寬的一半。

列舉同時包含 `NotDefined`，表示未明確指派端點樣式。

端點樣式不同於箭頭（在端點加入符號）以及接合樣式（控制線段之間的拐角）。此範例透過[ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) 與[ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) 停用箭頭，以便僅比較端點形狀。

以下範例建立三條在其他屬性完全相同的水平線，寬度為 20 點。由上至下分別使用平坦、圓形與方形端點。它們的端點水平座標相同；圓形與方形端點會在每端延伸 10 點。

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

![PowerPoint 中相同粗線的平坦、圓形與方形端點](line-caps.png)

## **對圖案線條套用手繪效果**

手繪效果會讓圖案線條看起來像手繪。使用[IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) 取得線條設定，使用[ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) 取得手繪設定，並使用[ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) 從[LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 列舉中選取值。

以下 C# 程式碼示範如何套用[LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 效果、讀取明確指派的值，並以[LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 移除效果：

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

由[ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) 回傳的值代表直接指派給圖案的設定。如果線條格式可能從佈景主題、母片或版面投影繼承，請使用[ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/)，存取[ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/)，並讀取[ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/)。有效值會反映在繼承解析後實際套用的格式。此範例需要一個已有的簡報，且其第一張投影片上至少有一個圖案，會同時輸出兩個值：

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

## **格式接合樣式**

以下是三種接合類型選項：

* Round
* Miter
* Bevel

接合樣式控制兩條輪廓線在拐角處的相遇方式。使用 **Round** 取得圓角，使用 **Miter** 取得尖角，使用 **Bevel** 取得平坦角。

![簡報中的接合樣式](join-style-powerpoint.png)

此範例建立三個藍色輪廓、寬度 15 點的黑色矩形，分別將[ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) 設為[LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) 的斜角、斜面與圓形值，以比較角落的繪製方式。

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

### **在銳利拐角處限制斜角接合**

使用[ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) 搭配將[ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) 設為[LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) 以限制尖角可延伸的程度。

此限制是接合內外角之間距離與線寬的比例。例如，值為 `8` 時允許斜角長度最多為線寬的八倍；它不是以點為單位的測量。如果拐角超過此限制，PowerPoint 會在該拐角使用斜面接合。較大的限制允許更銳利的尖端。此設定僅影響斜角接合，當拐角仍在兩個限制之內時，變更不會產生可見效果。

此範例建立兩個相同、未填充的三角形，輪廓寬度為 20 點。左側三角形使用限制 `2`，右側使用 `8`。每個三角形寬 80 點、高 160 點，使其頂端拐角的斜角長度與線寬比例約為 `4.12`。因此，PowerPoint 會將左側的頂點斜面化，而保留右側的尖銳頂點。

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

PowerPoint 中的結果：左側為 **Miter limit 2**，右側為 **miter limit 8**。

![PowerPoint 中斜角限制 2 的斜面頂點與斜角限制 8 的尖銳頂點](miter-limits.png)

## **漸層填色**

漸層填色會在圖形內混合顏色。此範例使用[IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/) 以 45 度角從紅色到紫色的線性漸層填滿橢圓。透過[IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) 方法將顏色定位點放置於 0 與 1，分別代表漸層的開始與結束。清除現有的定位點可確保僅使用這兩種顏色。

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

![具有漸層填色的橢圓](gradient-fill.png)

如果匯出的影像與 PowerPoint 中的漸層外觀不同，請參考 [Choose a Gradient Rendering Style](/slides/zh-hant/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不變更簡報中儲存的漸層填色的情況下，選擇不同的渲染樣式。

### **設定線性漸層角度**

使用[IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) 來控制[GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) 填色的方向。角度以度為單位，時計方向遞增：`0` 從左至右，`90` 從上至下，`180` 從右至左，`270` 從下至上。支援小數角度。超出 `[0, 360)` 的有限角度會正規化為一個完整旋轉；例如 `-45` 變為 `315`，`360` 變為 `0`。

此範例建立六個矩形，均使用相同的紅、綠、藍三個定位點，分別位於 `0`、`0.5`、`1`。停用比例縮放，使得角度可在不受矩形比例影響的情況下比較。左到右的角度分別為第一列的 `0`、`45`、`90`，第二列的 `135`、`180`、`270`。

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

![上排 0、45、90 度的線性漸層，下排 135、180、270 度的線性漸層](linear-gradient-angles.png)

### **以圖形縮放線性漸層**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) 接受[NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 值。將其明確設為 `False` 可在圖形比例變動時保持幾何漸層角度不變，或設為 `True` 使漸層隨圖形寬高縮放。啟用縮放時，非正方形圖形的可見角度可能與指派的角度不同。

以下範例使用 `45` 度角度與與角度比較相同的顏色定位點。左欄使用 `False`；右欄使用 `True`。每欄包含一個寬矩形上方與一個高矩形下方。兩者起始寬度相同；變更第二個矩形的寬高可示範在不改變漸層設定的情況下，填色如何因重新調整大小而回應。

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

PowerPoint 中的結果：左側縮放停用，右側縮放啟用：

![寬與高矩形的 45 度漸層，左側 LinearGradientScaled 為 False，右側為 True](linear-gradient-scaling.png)

停用縮放時，對角色帶在兩個矩形中保持相同方向。啟用縮放時，色帶會隨圖形比例伸展。這有助於在將圖形調整至不同大小時，仍能重現模板的漸層。在正方形上啟用縮放不會改變此 `45` 度漸層的外觀。

角度與縮放設定皆適用於線性漸層，對 [GradientShape.Radial] 或 [GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) 填色無效。

### **結合角度與漸層方向**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) 會從[GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/) 列舉中選取漸層樣式；它並非數值角度的替代品。對於線性漸層，角落樣式可在不變更[LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) 的情況下，改變顏色分佈的區域。比較角度或縮放時，請保持方向不變。

以下範例以相反順序套用相同設定。兩個矩形的外觀相同：先設定方向再設定角度或相反均不會改變結果。

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

圖案填色會套用雙色設計，例如點狀、條紋或格子。此範例使用[IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) 來選取格柵圖案。[IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) 提供淡灰色背景，而[IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) 提供黃色圖案色。

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

![具有圖案填色的矩形](pattern-fill.png)

## **圖片填色**

圖片填色會在圖形內使用圖像。此範例需要本機圖像，並使用[Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) 將其載入簡報的圖像集合。將[IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) 設為平鋪模式，可在矩形內重複圖像。以下顯示使用的來源圖像：

![蓮花圖片](lotus.png)

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

![具有圖片填色的圖形](picture-fill.png)

### **將圖片平鋪為紋理**

如果要將平鋪圖片設為紋理並自訂平鋪行為，可使用[IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) 介面與[PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) 類別的以下屬性：

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/)：設定圖片填色模式—`Tile` 或 `Stretch`。
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/)：指定平鋪在圖形內的對齊方式。
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/)：控制平鋪是否水平、垂直或雙向翻轉。
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/)：設定平鋪相對於圖形原點的水平偏移（單位：點）。
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/)：設定平鋪相對於圖形原點的垂直偏移（單位：點）。
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/)：定義平鋪的水平縮放百分比。
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/)：定義平鋪的垂直縮放百分比。

此範例需要本機圖像，並將[IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) 設定為以原始大小 50% 重複。將 X 與 Y 偏移設為 −32 點，使平鋪在水平與垂直方向上平移；底部右側對齊且雙向翻轉決定了重複紋理的排列方式。

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

純色填色會為圖形套用單一均勻的顏色。此範例將[IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 設為純色模式，並透過[IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) 指派黃色，最後將矩形存入簡報。

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

![具有純色填色的圖形](solid-color-fill.png)

### **在保留佈景主題參照的情況下複製顏色**

使用[IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) 可複製顏色定義，包含其顏色類型、佈景主題參照與轉換。此功能在將填色在應保持簡報主題的圖形之間轉移時特別有用。此方法僅複製顏色本身：不會複製填充類型、輪廓或其他圖形格式。請明確設定目標的[IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)。

此範例建立三個矩形，從左至右分別為來源、具佈景感知的副本，以及固定 RGB 的副本。來源使用[IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) 參照第一個強調色，並透過[IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/) 加上色調。RGB 副本使用來源的有效填色，使得三者最初看起來相同。將[IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) 指派為固定的 RGB 值，會清除任何既有的顏色轉換。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// 主題參照會遵循新的強調色；固定的 RGB 值則不會。
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

在主題變更前，三個填色皆相同：

![來源、CopyFrom 目的地與固定 RGB 目的地的相同藍色填色](color-copy-before.png)

主題變更後，來源與具佈景感知的副本會遵循新的強調色並保留其色調，固定 RGB 副本仍保持藍色：

![來源與 CopyFrom 目的地為橙色填色，固定 RGB 目的地仍為藍色](color-copy-after.png)

被複製的定義與來源獨立。之後變更來源的佈景參照、指派其他顏色，或新增/移除其轉換，都不會影響目的地。佈景變更仍會影響兩個圖形，因為它們各自獨立參照相同的佈景色。

儲存並重新開啟 PPTX 會保留複製顏色的[IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/)、佈景參照與[IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/) 集合；不會將定義展平為 RGB。

在不同佈景主題環境（例如使用不同強調調色板的簡報）之間複製時，複製的參照會以目的地的佈景主題解析。因此，同一參照與轉換在不同目的地可能產生不同的可見顏色。更多關於設定佈景顏色的資訊，請參閱[Presentation Theme](/slides/zh-hant/net/presentation-theme/)。

## **將投影片背景作為圖形填色**

當圖形應與投影片背景相同（例如在投影片範本中）時，可使用[IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/)。首先將[IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 設為[FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 以移除任何明確的填色。使用此組合時，圖形會改用投影片背景，而非其樣式填色。僅啟用此旗標不會移除已存在的明確填色。

此行為不同於[FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/)：背景填色會覆蓋圖形背後的物件，使其以投影片背景的對應區域顯示；而無填色則會讓那些物件保持可見。梯度仍會相對於投影片對齊，而不會在每個圖形內重新開始。

以下範例建立一個被投影片繼承的母片背景，並在三個矩形後方放置一條品紅色條帶。左側矩形使用背景填色，中央矩形無填色，右側矩形則由背景填色切換為明確的橙色填色。

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

// 先加入此物件，使它顯示在矩形的後面。
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

// 在套用明確填色之前先停用背景填色。
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

結果，從左至右分別為 **背景填色**、**無填色**、**明確填色**。品紅條帶被左、右矩形遮蔽，但仍透過中間矩形可見。

![背景填色、無填色與明確橙色填色覆蓋在品紅條帶上](background-fill.png)

相同的行為亦適用於直接在投影片上定義的背景或從版面繼承的背景。圖形會使用投影片解析後的背景；此範例讓投影片與版面背景皆未設定，讓母片提供背景。

## **設定透明度**

對於純色填色，顏色的 alpha 分量控制不透明度：0 為完全透明，255 為完全不透明。此範例將 alpha 值設為 128，為黃色矩形提供約 50% 的透明度，使底下的矩形仍可見。顏色透過[IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) 指派。

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

![具有透明度的圖形](shape-transparency.png)

## **旋轉圖形**

使用[IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) 以在投影片平面上旋轉圖形。角度以度為單位；此範例將矩形順時針旋轉 5 度，並儲存簡報。

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

![圖形旋轉效果](shape-rotation.png)

## **新增 3D 倒角效果**

使用[IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) 為圖形賦予深度與倒角邊緣。此範例建立一個綠色橢圓，橙色輪廓，將[IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) 設為 4 點，並透過[IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/) 以寬度與高度各 6 點的圓形上倒角。前視正投影相機與三點光源使倒角可見。

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

![3D 倒角效果圖](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

圖形的 3D 觀感受相機設定控制。此範例使用[ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/)，將緯度、經度與旋轉角分別設為 40、35 與 20 度。接著透過[ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) 選擇等軸相機，並以[ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) 設定平衡光源，最後儲存已格式化的矩形。

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

![3D 旋轉效果圖](3D-rotation-effect.png)

## **控制圖形的黑白顯示模式**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) 屬性指定在以黑白模式檢視或處理簡報時，單一圖形的呈現方式。它本身不會啟用黑白顯示，也不會在一般彩色模式下改變圖形的填色、線條或其他格式。

使用[BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) 列舉中的值來選取所需行為。例如，`Automatic` 讓渲染應用程式自行決定轉換方式，`Gray` 與 `LightGray` 使用灰階，`BlackWhite` 僅使用黑白，`Black` 與 `White` 強制單色，`Color` 保持正常彩色，`Hidden` 在黑白模式下省略圖形，`NotDefined` 表示未指派圖形層級模式。

此範例建立一個橙色矩形，將[IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) 設為灰色。儲存的圖形在一般彩色顯示時仍保留橙色填色，並在支援黑白顯示設定的應用程式中請求灰階顯示：

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

在一般彩色模式下，矩形保留橙色填色。於黑白顯示工作流程中，因其模式設為 `Gray`，所以會使用灰階顏色。這讓您在保留完整彩色投影片的同時，為列印、預覽或其他尊重簡報黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

使用[ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) 以從對應的版面占位元復原投影片占位元的位置、大小與格式。此範例需要一個已存在、且占位元與版面連結的簡報，並在儲存前重設每張投影片。未對應版面占位元的圖形不會被重設。

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

**圖形格式化會影響最終簡報檔案大小嗎？**

顏色、線條樣式與效果設定相較於嵌入的圖像與媒體，通常只會增加極少的資料。圖片填色可能會因圖像儲存在簡報中而增加檔案大小。

**我要如何偵測投影片上具有相同格式的圖形，以便將它們分組？**

比較每個圖形的關鍵格式屬性——填色、線條與效果設定。如果所有對應值皆相同，則可視為樣式相同，並在邏輯上將這些圖形分組，這樣可簡化之後的樣式管理。

**我可以將自訂的圖形樣式集合另存為檔案，以在其他簡報中重複使用嗎？**

可以。將帶有所需樣式的樣本圖形存於範本投影片或 .POTX 範本檔。建立新簡報時，開啟該範本，複製需要的樣式圖形，並在需要的地方重新套用其格式。