---
title: 在 .NET 中於簡報套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/net/shape-effect
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
description: "使用 Aspose.Slides for .NET 以進階形狀效果轉換您的 PPT 與 PPTX 檔案——在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

在 PowerPoint 中，效果可用於讓形狀突顯，但它們不同於 [填充](/slides/zh-hant/net/shape-formatting/#gradient-fill) 或輪廓。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。

某些效果組合看起來比其他組合更佳。為此，PowerPoint 在 **Preset** 下提供選項。Preset 選項本質上是兩個或多個效果的已知好看組合。透過選取預設，您就不必浪費時間測試或組合不同的效果以尋找合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/effectformat/) 類別下提供屬性和方法，讓您能在 PowerPoint 簡報中的形狀套用相同的效果。

## **套用陰影效果**

在 Aspose.Slides for .NET 中套用形狀的陰影效果時，您可以輕鬆調整顏色、模糊半徑與方向等參數。這使您的形狀呈現更具動態感與專業外觀，增添深度與焦點。透過簡單的程式碼片段，您能將這些效果套用於多個形狀，提升簡報的整體視覺吸引力。

以下 C# 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/effectformat/outershadoweffect/) 套用到矩形上：

```c#
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

## **套用反射效果**

在 Aspose.Slides for .NET 中套用反射效果時，您可以為形狀加入鏡面般的反射，並調整距離、透明度與大小等參數。此效果提升簡報的美感，使形狀呈現更光滑、精緻的外觀。只需簡單程式碼即可輕鬆實作，快速在多個元件上套用，確保設計的一致性。

以下 C# 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/effectformat/reflectioneffect/) 套用到形狀上：

```c#
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

在 Aspose.Slides for .NET 中套用形狀的發光效果時，您可以在形狀周圍添加柔和、發光的光暈，並調整顏色與大小等屬性。此效果有助於讓形狀更突出，為您的簡報增添吸引人的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體外觀。

以下 C# 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/effectformat/gloweffect/) 套用到形狀上：

```c#
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

在 Aspose.Slides for .NET 中套用柔和邊緣效果時，您可以在形狀的邊緣製造平滑、模糊的過渡。此效果增添更細膩、精緻的外觀，非常適合需要柔和外形的設計。您可輕鬆調整半徑等參數，以在簡報中的各種形狀上達成理想的效果。

以下 C# 程式碼示範如何將 [柔和邊緣](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/effectformat/softedgeeffect/) 套用到形狀上：

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![柔和邊緣效果](soft_edges_effect.png)

## **常見問題**

**我可以將多個效果套用在同一個形狀上嗎？**

是的，您可以在單一形狀上結合不同的效果，例如陰影、反射與發光，以打造更具動態的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。該效果將套用至整個群組。