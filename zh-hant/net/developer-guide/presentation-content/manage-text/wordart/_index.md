---
title: 在 .NET 中建立與套用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh-hant/net/wordart/
keywords:
- WordArt
- 建立 WordArt
- WordArt 範本
- WordArt 效果
- 陰影效果
- 顯示效果
- 發光效果
- WordArt 變形
- 3D 效果
- 外部陰影效果
- 內部陰影效果
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中建立與自訂 WordArt 效果。本一步步指南協助開發人員使用 C# 以專業文字強化簡報。"
---
## **概觀**

WordArt 效果讓您在 PowerPoint 簡報中加入視覺上吸引人、具風格的文字。使用 Aspose.Slides for .NET，開發人員可像在 Microsoft PowerPoint 中一樣，透過程式碼建立、客製化與管理 WordArt，而不需要安裝 Office。本篇文章概述在 .NET 中使用 WordArt，包括如何套用文字轉換、填滿樣式、輪廓、陰影及其他格式設定，讓簡報內容更具表現力與吸引力。WordArt 允許您將文字視為圖形物件，透過各種效果或特殊變形，使文字更吸睛或更突出。

## **建立簡易 WordArt 範本並套用至文字**

在本節中，我們將探討如何使用 Aspose.Slides for .NET 建立簡易 WordArt 範本並套用至文字。WordArt 提供簡單的方式，以醒目的視覺效果與樣式提升文字外觀。學會建立與使用 WordArt 的基本步驟後，您即可將這些技術套用至任何專案，讓簡報更生動、難忘。

首先，我們使用以下 C# 程式碼建立簡單文字：

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

接著，使用下列程式碼將文字的字型高度設為較大值，以使效果更明顯：

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

在此，我們將 SmallGrid 圖樣填滿套用至文字，並使用下列程式碼為文字加上寬度為 1 的黑色邊框：

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

產生的文字：

![簡易 WordArt 範本](WordArt_template.png)

## **套用其他 WordArt 效果**

除了基本的變形，Aspose.Slides for .NET 還允許您套用各種進階 WordArt 效果，以提升文字外觀。這些效果包括輪廓、填滿、陰影、反射與發光效果。透過結合這些功能，您可以打造在簡報中脫穎而出的吸睛文字樣式。本節示範如何以簡潔的程式碼範例，程式化地套用這些效果。

### **套用外部陰影效果**

外部陰影效果透過在文字輪廓後方加入陰影，使文字更突出，並產生深度感與與背景的分離。Aspose.Slides for .NET 可輕鬆為 WordArt 文字套用與自訂外部陰影。在本節中，您將學習設定陰影顏色、方向、距離、模糊半徑等，以達到理想的視覺效果。

以下 C# 程式碼片段為先前建立的文字套用陰影效果。

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
}
```

產生的文字：

![外部陰影效果](outer_shadow_effect.png)

{{% alert color="info" %}} 
- 同時使用 OuterShadow 與 PresetShadow 時，僅會套用 OuterShadow 效果。
- 同時使用 OuterShadow 與 InnerShadow 時，最終效果視 PowerPoint 版本而定。例如，在 PowerPoint 2013 中效果會重疊兩次，而在 PowerPoint 2007 中僅套用 OuterShadow 效果。
{{% /alert %}}

### **套用反射效果**

本節將探討如何使用 Aspose.Slides for .NET 在投影片中套用反射效果。反射效果是為文字或圖形增添時尚、現代外觀的有效方式，可讓關鍵元素更突出，並為簡報增添深度。了解如何套用與自訂這些效果後，您即可輕鬆依設計需求與品牌規範調整它們。

使用以下 C# 程式碼為文字加入反射效果：

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableReflectionEffect();
    portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
}
```

產生的文字：

![反射效果](reflection_effect.png)

### **套用發光效果**

本節將說明如何使用 Aspose.Slides for .NET 為文字套用發光效果。發光效果可讓文字以發光輪廓突顯，提升投影片的視覺吸引力。透過調整顏色與強度等設定，您可以輕鬆將發光效果調整至符合設計與品牌需求，確保簡報中的重點能抓住觀眾注意力。

使用以下程式碼為文字套用發光，使其發亮或突出：

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

產生的文字：

![發光效果](glow_effect.png)

### **套用 WordArt 變形**

本節將說明如何在 Aspose.Slides for .NET 中使用 WordArt 變形。變形允許您彎曲、拉伸或扭曲文字，產生獨特且視覺衝擊力強的效果。掌握這些技巧後，您即可依品牌或創意願景調整文字形狀與樣式，打造引人入勝且精緻的簡報。

使用 `Transform` 屬性（套用於整個文字區塊）如下程式碼：

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

產生的文字：

![WordArt 變形效果](transform_effect.png)

{{% alert color="info" %}} 
Aspose.Slides for .NET 提供一組預先定義的 [變形類型](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textshapetype/)。
{{% /alert %}} 

### **套用 3D 效果於圖形與文字**

建立寫實且吸睛的視覺效果，可大幅提升簡報的衝擊力。本節將探討如何使用 Aspose.Slides for .NET 為圖形套用三維 (3D) 效果。透過調整深度、角度與光源等參數，您可以產生令人印象深刻的 3D 變形，立即抓住觀眾注意力。無論是微妙的強調還是戲劇性的幻覺，這些功能皆提供彈性方式提升設計，讓概念更具說服力。

使用下列範例程式碼為圖形設定 3D 效果：

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.TextFrame.Text = "Aspose.Slides";

    autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
    autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

    autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelTop.Height = 12.5;
    autoShape.ThreeDFormat.BevelTop.Width = 11;

    autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    autoShape.ThreeDFormat.ExtrusionHeight = 6;

    autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    autoShape.ThreeDFormat.ContourWidth = 1.5;

    autoShape.ThreeDFormat.Depth = 3;

    autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

    autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

產生的圖形：

![圖形 3D 效果](shape_3D_effect.png)

使用下列範例程式碼為文字設定 3D 效果：

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

產生的文字：

![文字 3D 效果](text_3D_effect.png)

{{% alert color="info" %}} 
文字或其所在圖形套用 3D 效果的行為與互動，遵循特定規則。以同時包含文字與其容納圖形的情境為例。3D 效果包含物件的 3D 表現以及放置該物件的場景。

- 若圖形與文字皆設定了場景，圖形的場景具有優先權，文字的場景將被忽略。
- 若圖形未設定場景但具備 3D 表現，則使用文字的場景。
- 若圖形根本沒有 3D 效果，則視為平面，僅對文字套用 3D 效果。

此行為與 [ThreeDFormat.LightRig](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/lightrig/) 與 [ThreeDFormat.Camera](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/camera/) 屬性相關。
{{% /alert %}} 

## **常見問題** 

### 可以在不同字型或文字系統（例如阿拉伯文、中文）中使用 WordArt 效果嗎？

可以，Aspose.Slides for .NET 支援 Unicode，能與所有主要字型與文字系統相容。影子、填滿與輪廓等 WordArt 效果不受語言限制，儘管字型可用性與渲染可能取決於系統字型。

### 可以將 WordArt 效果套用至投影片母版元素嗎？

可以，您可以將 WordArt 效果套用至母版投影片上的圖形，包括標題預留位、頁腳或背景文字。對母版版面的變更會同步反映至所有相關投影片。

### WordArt 效果會影響簡報檔案大小嗎？

會有輕微影響。陰影、發光與漸層填滿等效果會因額外的格式資訊稍微增加檔案大小，但差異通常可忽略不計。

### 能在不儲存簡報的情況下預覽 WordArt 效果嗎？

可以，您可使用 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 或 [ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/) 介面的 `GetImage` 方法，將含有 WordArt 的投影片渲染為影像（如 PNG、JPEG），以在記憶體或螢幕上即時預覽結果，無需先儲存或匯出完整簡報。