---
title: 在 .NET 中於簡報套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/net/shape-effect/
keywords:
- 形狀效果
- 陰影效果
- 反射效果
- 發光效果
- 柔和邊緣效果
- 效果格式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 以進階形狀效果轉換您的 PPT 與 PPTX 檔案——在幾秒鐘內打造引人注目、專業的投影片。"
---
## **介紹**

雖然 PowerPoint 中的效果可用來讓形狀突顯，但它們與 [填色](/slides/zh-hant/net/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 效果，您可以在形狀上建立逼真的反射、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一種或多種效果。

某些效果組合看起來比其他組合更好。為此，PowerPoint 在 **Preset** 下提供選項。Preset 選項本質上是兩種以上效果的已知好看組合。這樣，選取預設後，您就不必花時間測試或組合不同效果來尋找合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 類別下提供屬性和方法，讓您在 PowerPoint 簡報中對形狀套用相同的效果。

## **套用陰影效果**

Aspose.Slides for .NET 支援形狀的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計需求。

### **套用外部陰影**

使用外部陰影讓卡片或面板在投影片背景上更為突出。陰影延伸至形狀邊緣之外，營造形狀浮起於投影片之上的感覺。調整其顏色、方向、距離與模糊半徑，以配合範本的光源與樣式。

此 C# 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) 套用於矩形：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![陰影效果](shadow_effect.png)

#### **在形狀旋轉時控制陰影方向**

預設情況下，[RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) 為 `true`，因此陰影會隨形狀旋轉。若要讓不同旋轉角度的形狀看起來光源方向相同，請將此屬性設為 `false`，並為它們的陰影設定相同的 [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/)。

此範例建立兩個向右偏移（`Direction = 0`）的灰色陰影箭頭，然後複製投影片並將兩個箭頭順時針旋轉 90°。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

在第二張投影片上，左側箭頭的陰影向下投射，而右側箭頭仍向右投射。兩個陰影的方向仍保持 0°。

![PowerPoint 渲染在 90° 旋轉前後的比較。兩個陰影都從右邊開始。旋轉後，左箭頭的陰影移到下方，右箭頭的陰影仍在右側。](arrow-shadow-rotation.png)

### **套用內部陰影**

在還原範本的視覺樣式時，使用內部陰影可讓卡片或面板呈現凹陷的外觀。外部陰影延伸至形狀之外，使其看起來提升；而內部陰影則在邊緣內側產生陰影。

呼叫 [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)，再設定 [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)。較大的數值會產生較柔和的邊緣。

此 C# 範例建立一個淡藍色卡片，並加入深灰色內部陰影，然後儲存為 PPTX 檔案：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![帶有內部陰影的淺藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請在形狀的 effect format 上呼叫 [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/)。

### **套用、變更與移除預設陰影**

呼叫 [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) 並將 [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) 設為具名的 [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/)。若要切換樣式，可在同一形狀上變更預設。呼叫 [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) 可在保留填色與輪廓的同時移除陰影。

此範例在每個階段保留矩形的副本。兩個陰影均偏移 10 點。225° 的方向將第一個陰影置於矩形左上方，45° 的方向則將第二個陰影置於右下方。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| 原始 | 第一預設 | 第二預設 | 移除後 |
| :---: | :---: | :---: | :---: |
| ![無陰影](preset_shadow_original.png) | ![左上陰影](preset_shadow_top_left.png) | ![右下陰影](preset_shadow_bottom_right.png) | ![移除後無陰影](preset_shadow_removed.png) |

## **套用反射效果**

在 Aspose.Slides for .NET 中套用反射效果時，您可以為形狀加入鏡面般的反射，並調整距離、透明度與尺寸等參數。此效果可提升簡報的美感，使形狀看起來更為精緻與專業。透過簡單的程式碼即可輕鬆實作，快速在多個元素間套用，以保持設計的一致性。

此 C# 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) 套用於形狀：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![反射效果](reflection_effect.png)

## **套用發光效果**

在 Aspose.Slides for .NET 中套用發光效果時，您可以在形狀周圍加入柔和的光暈，並調整顏色與大小等屬性。此效果可讓形狀更為突出，為簡報增添吸睛的視覺元素。實作方式簡單，只需少量程式碼，即可提升投影片的整體觀感。

此 C# 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) 套用於形狀：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![發光效果](glow_effect.png)

## **套用柔和邊緣效果**

在 Aspose.Slides for .NET 中套用柔和邊緣效果時，您可以為形狀的邊緣建立平滑、模糊的過渡。此效果提供更細膩、精緻的外觀，適合需要柔和外觀的設計。您可以輕鬆調整半徑等參數，以在簡報中的各種形狀上達到理想的效果。

此 C# 程式碼示範如何將 [柔和邊緣](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) 套用於形狀：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![柔和邊緣效果](soft_edges_effect.png)

## **套用模糊效果**

使用形狀模糊可在保持形狀可編輯的同時，使其填色與輪廓變得柔和。對形狀的 effect format 呼叫 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/)。半徑以點 (1/72 吋) 為單位：使用非負值，值越大模糊程度越強。半徑為零時外觀保持不變。

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) 設定控制效果的可見範圍。`false` 時，模糊僅限於原始繪製範圍（包括輪廓）；`true` 時，模糊可延伸至該範圍之外。此設定不會改變形狀的位置或尺寸。

下表的比較在整個過程中使用相同的填色、輪廓與形狀尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形與模糊半徑 5 與 15 點的比較，grow 關閉與開啟](shape_blur_comparison.png)

此 C# 範例建立一個橙色矩形，外框為深藍色，先套用 5 點模糊，然後再次呼叫 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) 將模糊升級為 15 點，並分別儲存兩個模糊狀態，最後呼叫 [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) 並儲存未模糊的形狀。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

形狀模糊同時影響填色與輪廓。柔和邊緣效果僅淡化形狀的邊緣，而陰影模糊僅柔化陰影本身。圖像轉換效果作用於圖像內容；本範例直接對形狀的 effect format 套用模糊，未將形狀轉換為圖像。

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

可以，您可以將陰影、反射、發光等不同效果組合在同一個形狀上，以營造更具動態感的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

可以，效果會套用至整個群組。