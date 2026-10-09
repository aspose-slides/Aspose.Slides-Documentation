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
description: "使用 Aspose.Slides for .NET，將您的 PPT 和 PPTX 檔案轉換為進階形狀效果——在數秒內創建引人注目、專業的投影片。"
---
## **介紹**

雖然 PowerPoint 中的效果可用於讓形狀脫穎而出，但它們與 [填色](/slides/zh-hant/net/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 效果，您可以在形狀上建立逼真的反射、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。

某些效果組合看起來比其他組合更好。基於此原因，PowerPoint 在 **Preset** 下提供選項。Preset 選項本質上是一個已知好看的兩個或多個效果的組合。因此，選取預設後，您不必花時間測試或組合不同的效果來尋找合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 類別中提供屬性與方法，使您能在 PowerPoint 簡報的形狀上套用相同的效果。

## **套用陰影效果**

Aspose.Slides for .NET 支援形狀的外部陰影與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景中突出。陰影延伸至形狀邊緣之外，營造形狀浮於投影片之上的感覺。調整其顏色、方向、距離與模糊半徑，以匹配範本的光線與樣式。

以下 C# 程式碼示範如何將 [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) 套用到矩形上：

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

在重製範本的視覺樣式時，使用內部陰影可為卡片或面板營造凹陷的外觀。外部陰影延伸至形狀外部，使其看起來凸起，而內部陰影則在其邊緣內側加深陰影。

呼叫 [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)，然後設定 [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)。較大的值會產生較柔和的邊緣。

以下 C# 範例建立一個淡藍色卡片，並套用深灰色內部陰影，最後將其儲存為 PPTX 檔案：

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

若要移除內部陰影，可在形狀的 EffectFormat 上呼叫 [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/)。

## **套用反射效果**

在 Aspose.Slides for .NET 中套用反射效果時，您可以為形狀新增類似鏡面的反射，並調整距離、透明度與大小等參數。此效果提升簡報的美感，使形狀呈現更精緻與高級的外觀。透過簡單程式碼即可輕鬆實作，快速在多個元素間套用以達成一致的設計。

以下 C# 程式碼示範如何將 [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) 套用到形狀上：

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

在 Aspose.Slides for .NET 中為形狀套用發光效果時，您可以在形狀周圍添加柔和、發光的光環，並調整顏色與大小等屬性。此效果協助形狀突顯，為簡報增添吸引目光的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體外觀。

以下 C# 程式碼示範如何將 [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) 套用到形狀上：

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

在 Aspose.Slides for .NET 中套用柔和邊緣效果時，您可以在形狀的邊緣建立平滑、模糊的過渡。此效果帶來更細緻、雅緻的外觀，非常適合需要柔和外形的設計。您可輕鬆調整半徑等參數，以在簡報的各種形狀上獲得理想的效果。

以下 C# 程式碼示範如何將 [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) 套用到形狀上：

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

## **FAQ**

**我可以將多個效果套用到同一個形狀嗎？**

是的，您可以在單一形狀上結合不同的效果，如陰影、反射與發光，以產生更具動態感的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。該效果會套用到整個群組。