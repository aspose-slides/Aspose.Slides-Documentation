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
- 柔化邊緣效果
- 效果格式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 以先進的形狀效果轉換您的 PPT 與 PPTX 檔案──在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用於讓形狀突出，但它們與 [填充](/slides/zh-hant/net/shape-formatting/#gradient-fill) 或輪廓不同。利用 PowerPoint 效果，您可以在形狀上製作逼真的反射、散佈形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。

某些效果組合看起來比其他組合更佳。為此，PowerPoint 在 **預設** 下提供選項。預設選項本質上是已知的兩種或以上效果的好看組合。如此，一旦選取預設，您就不必浪費時間測試或組合不同效果以找出合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 類別提供屬性與方法，讓您能將相同的效果套用於 PowerPoint 簡報中的形狀。

## **套用陰影效果**

Aspose.Slides for .NET 支援形狀的外部與內部陰影。您可以自訂它們的顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景中凸顯。陰影延伸至形狀邊緣之外，營造形狀高於投影片的感覺。調整其顏色、方向、距離與模糊半徑，以符合範本的光線與樣式。

以下 C# 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) 套用至矩形：

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

在重現範本的視覺樣式時，可使用內部陰影為卡片或面板營造凹陷的外觀。外部陰影延伸至形狀外部，使其看起來突出；而內部陰影則在其邊緣內部產生陰影。

呼叫 [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)，然後設定 [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)。較大的值會產生較柔和的邊緣。

以下 C# 範例建立一個淡藍色的卡片，帶有深灰色內部陰影，並將其儲存為 PPTX 檔案：

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

![帶有內部陰影的淡藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請在形狀的 effect format 上呼叫 [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/)。

## **套用反射效果**

要在 Aspose.Slides for .NET 中套用反射效果，您可以為形狀加入鏡面般的反射，調整距離、透明度與大小等參數。此效果透過賦予形狀更光滑、精緻的外觀，提升簡報的美感。只需簡單程式碼即可輕鬆實作，讓多個元素快速套用以維持一致的設計。

以下 C# 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) 套用至形狀：

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

要在 Aspose.Slides for .NET 中為形狀套用發光效果，您可以在形狀周圍加入柔和、光亮的光暈，調整顏色與大小等屬性。此效果協助形狀突出，為簡報增添吸睛的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體外觀。

以下 C# 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) 套用至形狀：

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

## **套用柔化邊緣效果**

要在 Aspose.Slides for .NET 中套用柔化邊緣效果，您可以在形狀的邊緣建立平滑、模糊的過渡。此效果增添更細緻、優雅的外觀，適合需要柔和外觀的設計。您可以輕鬆調整半徑等參數，以在簡報中的各種形狀上獲得理想效果。

以下 C# 程式碼示範如何將 [柔化邊緣](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) 套用至形狀：

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

![柔化邊緣效果](soft_edges_effect.png)

## **套用模糊效果**

使用形狀模糊可軟化形狀的填充與輪廓，同時保持形狀可編輯。對形狀的 effect format 呼叫 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/)。半徑以點 (1/72 吋) 為單位：使用非負值，較大的數值會產生較強的模糊。半徑為零則保持外觀不變。

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) 設定控制效果的可見範圍。設定為 `false` 時，模糊僅限於原始繪製範圍（包括輪廓）。設定為 `true` 時，模糊可延伸至該範圍之外。這兩種設定皆不會改變形狀的位置或尺寸。

下表的比較使用相同的填充、輪廓與形狀尺寸。上列使用 `grow = false`；下列使用 `grow = true`。

![原始矩形與模糊半徑 5 與 15 點的比較（grow 停用與啟用）](shape_blur_comparison.png)

以下 C# 範例建立一個橘色矩形，帶深藍色輪廓，先套用 5 點模糊，然後再次呼叫 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) 將其升級為 15 點模糊。它會儲存兩個模糊狀態，接著呼叫 [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) 並儲存沒有模糊的形狀。

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

形狀模糊同時影響填充與輪廓。柔化邊緣效果會淡化形狀的邊緣，而陰影模糊僅柔化陰影本身。影像轉換效果作用於影像內容；本範例直接對形狀的 effect format 套用模糊，無需將形狀轉換為影像。

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以在單一形狀上結合不同的效果，例如陰影、反射與發光，以產生更具動態的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。效果將套用至整個群組。