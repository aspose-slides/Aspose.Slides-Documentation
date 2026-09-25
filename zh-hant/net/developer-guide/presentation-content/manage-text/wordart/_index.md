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
- 反射效果
- 發光效果
- WordArt 變形
- 3D 效果
- 外部陰影效果
- 內部陰影效果
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中建立與自訂 WordArt 效果。本步驟指南協助開發人員使用 C# 為簡報增添專業文字。"
---
## **概述**

WordArt 效果讓您可以使用填充、輪廓、陰影、反射、發光、變形和 3D 格式化來設定文字樣式。本篇文章說明如何在未安裝 Microsoft Office 的情況下，使用 Aspose.Slides for .NET 在 PowerPoint 簡報中建立與自訂這些效果。

## **建立簡單的 WordArt 範本並套用到文字**

以下範例透過設定文字、字型、圖樣填充與輪廓，建立簡單的 WordArt 風格。

每個範例都會建立一個新簡報，並在第一張投影片中加入一個矩形；不需要輸入檔案。第一個範例將文字設定為「Aspose.Slides」。形狀的位置與尺寸以點 (point) 為單位：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

將字型設為 36 點的 Arial Black，使格式更為明顯：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

套用具有深橙色前景與白色背景的 [SmallGrid](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/patternstyle/) 圖樣，然後加入寬度為 1 點的黑色文字輪廓：

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

產生的文字：

![簡單的 WordArt 範本](WordArt_template.png)

## **套用其他 WordArt 效果**

以下範例示範如何對文字套用陰影、反射、發光、變形與 3D 效果。

### **套用外部陰影效果**

外部陰影透過在文字後方放置陰影來增添深度。您可以自訂其顏色、方向、距離、模糊半徑、比例與斜切。

此範例呼叫 [EnableOuterShadowEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/effectformat/enableoutershadoweffect/) 並設定一個 4 點模糊半徑、230 度方向、30 點距離的黑色陰影。比例值 100 能保留陰影大小，而水平斜切會將其傾斜 20 度。Alpha 變換將不透明度設定為 32%：

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

產生的文字：

![外部陰影效果](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 當同時使用外部陰影與預設陰影時，只會套用外部陰影。
- 如果同時使用外部陰影與內部陰影，最終效果取決於 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果會加倍；而在 PowerPoint 2007 中，僅套用外部陰影。
{{% /alert %}}

### **套用反射效果**

反射會產生文字的鏡像副本。可調整其位置、比例、模糊與不透明度，以控制外觀。

此範例呼叫 [EnableReflectionEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/effectformat/enablereflectioneffect/) 並將反射垂直翻轉，比例為 -100%。使用 0.5 點的模糊半徑與 4.72 點的距離。不透明度在反射的 0% 到 60% 位置之間，從 60% 下降至 0.9%：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

產生的文字：

![反射效果](reflection_effect.png)

### **套用發光效果**

發光會在文字周圍加入柔和的彩色輪廓。可調整顏色、不透明度與半徑以控制效果。

此範例呼叫 [EnableGlowEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/effectformat/enablegloweffect/) 並套用紅色發光，透明度 54%，半徑 7 點：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

產生的文字：

![發光效果](glow_effect.png)

### **套用 WordArt 變形**

WordArt 變形可彎曲、拉伸或扭曲文字區塊。

將 [Transform](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat/transform/) 設為 [ArchUpPour](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textshapetype/)，以向上彎曲整個文字框：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

產生的文字：

![WordArt 變形](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET 提供一組預先定義的 [變形類型](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textshapetype/)。
{{% /alert %}}

### **套用 3D 效果於形狀與文字**

您可以對形狀或其文字套用 3D 效果。斜角、拉伸、光源與相機設定會控制最終外觀。

以下範例使用 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/) 為矩形添加圓形斜角、橙色拉伸與深紅色輪廓。斜角尺寸、拉伸高度、輪廓寬度與深度皆以點為單位。塑膠材質、繞 Z 軸旋轉 40 度的平衡光源，以及透視相機定義其外觀：

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
```

產生的形狀：

![形狀 3D 效果](shape_3D_effect.png)

此範例透過 [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat/threedformat/) 對文字套用類似的 3D 格式。較小的斜角塑造字母邊緣，而拉伸與光源則為文字增添深度：

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
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
```

產生的文字：

![文字 3D 效果](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
將 3D 效果套用於文字或其形狀——以及這些效果之間的互動——受到特定規則的管控。請考慮同時涉及文字與其所在形狀的場景。3D 效果包含物件的 3D 表示以及其所處的場景。

- 如果同時為形狀與文字設置了場景，則形狀的場景具有優先權，文字的場景會被忽略。
- 如果形狀沒有自己的場景，但具有 3D 表示，則使用文字的場景。
- 如果形狀根本沒有 3D 效果，則視為平面，僅對文字套用 3D 效果。

這些行為與 [ThreeDFormat.LightRig](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/lightrig/) 與 [ThreeDFormat.Camera](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/threedformat/camera/) 屬性有關。
{{% /alert %}}

若要在保留形狀的 3D 格式的同時，使文字保持平面且易讀，請參閱 [在 3D 形狀上保持文字平面](/slides/zh-hant/net/3d-presentation/)，了解兩種設定的比較以及完整的 C# 範例。

## **常見問題**

**我可以將 WordArt 效果套用於不同的字體或文字系統（例如阿拉伯文、中文）嗎？**

是的，Aspose.Slides for .NET 支援 Unicode，且相容所有主要字體與文字系統。無論語言為何，都可套用陰影、填充與輪廓等 WordArt 效果，但字體的可用性與渲染可能取決於系統字體。

**我可以將 WordArt 效果套用於投影片母片元素嗎？**

可以，您可以對母片投影片上的形狀套用 WordArt 效果，包括標題佔位符、頁腳或背景文字。對母片版面的變更會自動套用至所有相關投影片。

**WordArt 效果會影響簡報檔案大小嗎？**

會有輕微影響。陰影、發光與漸層填充等 WordArt 效果會因為額外的格式化中繼資料而略微增加檔案大小，但差異通常可忽略不計。

**我可以在未儲存簡報的情況下預覽 WordArt 效果的結果嗎？**

可以，您可以使用 [ISlide.GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/getimage/) 將包含 WordArt 的投影片渲染為影像（例如 PNG、JPEG），或使用 [IShape.GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/getimage/) 渲染個別形狀。這讓您在儲存或匯出完整簡報之前，於記憶體或螢幕上預覽結果。