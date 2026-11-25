---
title: 在 .NET 簡報中套用形狀效果
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
description: "使用 Aspose.Slides for .NET 以進階形狀效果轉換您的 PPT 與 PPTX 檔案，讓您在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用於讓形狀突出，但它們與 [填色](/slides/zh-hant/net/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 的效果，您可以在形狀上產生逼真的反射、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對一個形狀套用一個或多個效果。

某些效果組合看起來比其他組合更佳。為此，PowerPoint 在 **Preset** 下提供選項。Preset 選項本質上是已知的好看組合，由兩種或更多效果組成。這樣，選取預設即可免去測試或組合不同效果以找到合適組合的時間。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 類別中提供屬性與方法，使您能在 PowerPoint 簡報中對形狀套用相同的效果。

## **套用陰影效果**

Aspose.Slides for .NET 支援形狀的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景上凸顯。陰影延伸超出形狀邊緣，產生形狀高於投影片的感覺。調整其顏色、方向、距離與模糊半徑，以符合模板的光源與樣式。

以下 C# 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) 套用到矩形：

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

### **套用內部陰影**

在重製模板的視覺樣式時，可使用內部陰影為卡片或面板營造凹陷感。外部陰影位於形狀外側，使其看起來凸起；而內部陰影則在其邊緣內側著色。

呼叫 [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)，然後設定 [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)。較大的數值會產生較柔和的邊緣。

以下 C# 範例建立一個淡藍色卡片，帶有深灰色內部陰影，並將其儲存為 PPTX 檔案：

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

![帶內部陰影的淡藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請在形狀的 effect format 上呼叫 [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/)。

### **套用、變更與移除預設陰影**

呼叫 [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) 並將 [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) 設定為具名的 [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/)。若要切換樣式，只需在同一形狀上變更預設。呼叫 [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) 可在保留填色與輪廓的同時移除陰影。

此範例在每個階段保留矩形的副本。兩個陰影的偏移皆為 10 點。225° 的方向將第一個陰影置於矩形的左上方，45° 的方向則將第二個陰影置於右下方。

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

在 Aspose.Slides for .NET 中套用反射效果時，您可以為形狀加入鏡面反射，並調整距離、透明度與大小等參數。此效果提升簡報的美感，使形狀更具質感與精緻感。透過簡單程式碼即可輕鬆實作，快速在多個元素上套用，以維持設計的一致性。

以下 C# 程式碼示範如何將 [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) 套用於形狀：

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

在 Aspose.Slides for .NET 中為形狀套用發光效果時，您可以在形狀周圍加入柔和、發光的光暈，調整顏色與大小等屬性。此效果有助於讓形狀脫穎而出，為簡報增添吸引人的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體外觀。

以下 C# 程式碼示範如何將 [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) 套用於形狀：

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

在 Aspose.Slides for .NET 中套用柔和邊緣效果時，您可以在形狀的邊緣建立平滑、模糊的過渡。此效果帶來更細緻、精緻的外觀，適合需要柔和外觀的設計。您可以輕鬆調整半徑等參數，以在簡報中各種形狀上實現所需效果。

以下 C# 程式碼示範如何將 [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) 套用於形狀：

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

使用形狀模糊可在保持形狀可編輯的同時柔化其填色與輪廓。於形狀的 effect format 呼叫 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/)。半徑以點 (1/72 吋) 為單位：使用非負值，較大的數值會產生較強的模糊。半徑為零則不改變外觀。

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) 設定控制效果的可見範圍。設定為 `false` 時，模糊會被裁剪至原始繪製範圍（含輪廓）。設定為 `true` 時，模糊可延伸超出該範圍。無論哪種設定，都不會改變形狀的位置或尺寸。

以下比較皆使用相同的填色、輪廓與形狀尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形與模糊半徑 5 點與 15 點的比較（grow 停用與啟用）](shape_blur_comparison.png)

以下 C# 範例建立一個橙色矩形，搭配深藍色輪廓，先套用 5 點模糊，然後再次呼叫 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) 將其更新為 15 點模糊。程式會儲存兩個模糊狀態，之後呼叫 [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) 並儲存未模糊的形狀。

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

形狀模糊同時影響填色與輪廓。柔和邊緣效果會淡化形狀的邊緣，而陰影模糊僅使陰影變柔。影像變換效果作用於影像內容；此範例直接對形狀的 effect format 套用模糊，未將形狀轉換為影像。

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以在單一形狀上結合不同的效果，例如陰影、反射與發光，以產生更具動態感的外觀。

**哪些形狀可以套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果，該效果會套用於整個群組。