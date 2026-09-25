---
title: .NETでWordArtエフェクトを作成して適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/net/wordart/
keywords:
- WordArt
- WordArt を作成
- WordArt テンプレート
- WordArt エフェクト
- 影エフェクト
- 反射エフェクト
- グローエフェクト
- WordArt 変形
- 3D エフェクト
- 外側の影エフェクト
- 内側の影エフェクト
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で WordArt エフェクトを作成およびカスタマイズします。このステップバイステップガイドは、開発者が C# でプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---
## **概要**

WordArt エフェクトを使用すると、塗り、輪郭、影、反射、グロー、変形、3D 書式設定でテキストを装飾できます。本記事では、Microsoft Office をインストールせずに、Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションでこれらのエフェクトを作成およびカスタマイズする方法を説明します。

## **シンプルな WordArt テンプレートを作成しテキストに適用する**

以下の例では、テキスト、フォント、パターン塗り、輪郭を設定してシンプルな WordArt スタイルを作成します。

各例は新しいプレゼンテーションを作成し、最初のスライドに長方形を追加します。入力ファイルは不要です。最初の例ではテキストを「Aspose.Slides」に設定します。シェイプの位置とサイズはポイントで測定されます：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

フォントを Arial Black の 36 ポイントに設定して、書式設定を目立たせます：

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

[SmallGrid](https://reference.aspose.com/slides/ja/net/aspose.slides/patternstyle/) パターンをダークオレンジの前景色と白の背景色で適用し、幅 1 ポイントの黒いテキスト輪郭を追加します：

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

結果のテキスト：

![シンプルな WordArt テンプレート](WordArt_template.png)

## **その他の WordArt エフェクトを適用する**

以下の例では、影、反射、グロー、変形、3D エフェクトをテキストに適用する方法を示します。

### **外側の影エフェクトを適用する**

外側の影はテキストの背後に影を置くことで奥行きを追加します。色、方向、距離、ぼかし半径、スケール、せん断をカスタマイズできます。

この例では [EnableOuterShadowEffect](https://reference.aspose.com/slides/ja/net/aspose.slides/effectformat/enableoutershadoweffect/) を呼び出し、ぼかし半径 4 ポイント、方向 230 度、距離 30 ポイントの黒い影を設定します。スケール 100 は影のサイズを保持し、水平せん断で 20 度傾けます。アルファ変換で不透明度を 32% に設定します：

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

結果のテキスト：

![外側の影エフェクト](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 外側の影とプリセットの影を同時に使用すると、外側の影のみが適用されます。
- 外側の影と内部の影を同時に使用すると、結果のエフェクトは PowerPoint のバージョンに依存します。たとえば、PowerPoint 2013 ではエフェクトが二重になり、PowerPoint 2007 では外側の影のみが適用されます。
{{% /alert %}}

### **反射エフェクトを適用する**

反射はテキストの鏡像コピーを作成します。位置、スケール、ぼかし、不透明度を調整して外観を制御します。

この例では [EnableReflectionEffect](https://reference.aspose.com/slides/ja/net/aspose.slides/effectformat/enablereflectioneffect/) を呼び出し、スケール -100% で垂直に反射を反転します。ぼかし半径 0.5 ポイント、距離 4.72 ポイントを使用します。不透明度は反射位置 0% から 60% の間で 60% から 0.9% に減少します：

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

結果のテキスト：

![反射エフェクト](reflection_effect.png)

### **グローエフェクトを適用する**

グローはテキストの周囲に柔らかい色付き輪郭を追加します。色、不透明度、半径を調整してエフェクトを制御します。

この例では [EnableGlowEffect](https://reference.aspose.com/slides/ja/net/aspose.slides/effectformat/enablegloweffect/) を呼び出し、54% の不透明度で半径 7 ポイントの赤いグローを適用します：

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

結果のテキスト：

![グローエフェクト](glow_effect.png)

### **WordArt 変形を適用する**

WordArt 変形はテキストブロックを曲げたり、伸ばしたり、歪めたりします。

[Transform](https://reference.aspose.com/slides/ja/net/aspose.slides/textframeformat/transform/) を [ArchUpPour](https://reference.aspose.com/slides/ja/net/aspose.slides/textshapetype/) に設定して、テキストフレーム全体を上向きにカーブさせます：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

結果のテキスト：

![WordArt 変形](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET は、事前定義された [transformation types](https://reference.aspose.com/slides/ja/net/aspose.slides/textshapetype/) を提供します。
{{% /alert %}}

### **シェイプとテキストに 3D エフェクトを適用する**

シェイプまたはテキストに 3D エフェクトを適用できます。ベベル、押し出し、ライティング、カメラ設定が最終的な外観を制御します。

以下の例では [ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/threedformat/) を使用して、長方形に円形ベベル、オレンジの押し出し、濃い赤の輪郭を追加します。ベベルサイズ、押し出し高さ、輪郭幅、深さはポイントで測定されます。プラスチック素材、Z 軸周りに 40 度回転したバランスの取れた照明、遠近カメラが外観を定義します：

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

結果のシェイプ：

![シェイプの 3D エフェクト](shape_3D_effect.png)

この例では [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/textframeformat/threedformat/) を通じてテキストにも同様の 3D 書式設定を適用します。小さなベベルが文字エッジを形作り、押し出しとライティングがテキストに奥行きを与えます：

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

結果のテキスト：

![テキストの 3D エフェクト](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
テキストまたはシェイプへの 3D エフェクトの適用、およびこれらのエフェクト間の相互作用は特定のルールで管理されます。テキストとそれを含むシェイプの両方が関与するシーンを考慮してください。3D エフェクトは対象オブジェクトの 3D 表現と配置されるシーンを含みます。

- シェイプとテキストの両方にシーンが設定されている場合、シェイプのシーンが優先され、テキストのシーンは無視されます。
- シェイプに独自のシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。
- シェイプに 3D エフェクトが全くない場合、平面として扱われ、3D エフェクトはテキストにのみ適用されます。

これらの動作は [ThreeDFormat.LightRig](https://reference.aspose.com/slides/ja/net/aspose.slides/threedformat/lightrig/) および [ThreeDFormat.Camera](https://reference.aspose.com/slides/ja/net/aspose.slides/threedformat/camera/) プロパティに関連しています。
{{% /alert %}}

テキストを平坦かつ読みやすく保ちつつシェイプの 3D 書式設定を保持する方法については、[Keep Text Flat on a 3D Shape](/slides/ja/net/3d-presentation/) を参照し、両方の設定の比較と完全な C# サンプルをご覧ください。

## **よくある質問**

**Can I use WordArt effects with different fonts or scripts (e.g., Arabic, Chinese)?**

はい、Aspose.Slides for .NET は Unicode をサポートし、主要なフォントやスクリプトすべてで動作します。影、塗り、輪郭などの WordArt エフェクトは言語に関係なく適用できますが、フォントの可用性や描画はシステムにインストールされているフォントに依存する場合があります。

**Can I apply WordArt effects to slide master elements?**

はい、マスタースライド上のシェイプ（タイトルプレースホルダー、フッター、背景テキストなど）にも WordArt エフェクトを適用できます。マスターのレイアウトを変更すると、関連付けられたすべてのスライドに自動的に反映されます。

**Do WordArt effects affect presentation file size?**

わずかに影響します。影やグロー、グラデーション塗りなどの WordArt エフェクトは、追加の書式メタデータを伴うためファイルサイズが若干増加することがありますが、通常は無視できる程度です。

**Can I preview the result of WordArt effects without saving the presentation?**

はい、[ISlide.GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/getimage/) や [IShape.GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/getimage/) を使用して、WordArt を含むスライドや個別シェイプを画像（PNG、JPEG など）としてレンダリングできます。これにより、プレゼンテーションを保存またはエクスポートする前にメモリ上または画面上で結果をプレビューできます。