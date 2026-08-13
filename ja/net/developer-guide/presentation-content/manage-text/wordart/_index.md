---
title: ".NET で WordArt エフェクトを作成および適用する"
linktitle: "WordArt"
type: docs
weight: 110
url: /ja/net/wordart/
keywords:
- WordArt
- WordArt の作成
- WordArt テンプレート
- WordArt エフェクト
- 影エフェクト
- 表示エフェクト
- グローエフェクト
- WordArt 変形
- 3D エフェクト
- 外側影エフェクト
- 内側影エフェクト
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で WordArt エフェクトを作成およびカスタマイズします。このステップバイステップガイドは、開発者が C# でプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---
## **概要**

WordArt エフェクトを使用すると、PowerPoint プレゼンテーションに視覚的に魅力的でスタイライズされたテキストを追加できます。Aspose.Slides for .NET を使用すれば、Office をインストールせずに、Microsoft PowerPoint と同様に WordArt をプログラムで作成、カスタマイズ、管理できます。本記事では、.NET で WordArt を操作する概要を紹介します。テキスト変形、塗りつぶしスタイル、アウトライン、影、その他の書式設定オプションを適用して、プレゼンテーションのコンテンツをより表現力豊かに、魅力的にする方法を解説します。WordArt はテキストをグラフィックオブジェクトとして扱います。テキストに対して適用される効果や特殊な変更により、テキストをより目立たせたり注目させたりします。

## **シンプルな WordArt テンプレートを作成し、テキストに適用する**

このセクションでは、Aspose.Slides for .NET を使用してシンプルな WordArt テンプレートを作成し、テキストに適用する方法を紹介します。WordArt は、印象的なビジュアル効果とスタイルでテキストの外観を簡単に向上させる手段です。WordArt の作成と使用の基本手順を学べば、任意のプロジェクトにすぐに適用でき、プレゼンテーションをより鮮やかで記憶に残るものにできます。

まず、以下の C# コードでシンプルなテキストを作成します。

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

次に、効果を目立たせるためにテキストのフォント高さを大きく設定します。

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

ここでは、テキストに SmallGrid パターン塗りつぶしを適用し、幅 1 の黒いテキスト枠線を追加します。

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

結果のテキスト:

![シンプルな WordArt テンプレート](WordArt_template.png)

## **その他の WordArt エフェクトを適用する**

基本的な変形に加えて、Aspose.Slides for .NET では、テキストの外観を向上させるさまざまな高度な WordArt エフェクトを適用できます。これらにはアウトライン、塗りつぶし、影、反射、グロー効果が含まれます。これらの機能を組み合わせることで、プレゼンテーションで目立つテキストスタイルを作成できます。このセクションでは、シンプルでクリーンなコード例を使って、プログラムでこれらの効果を適用する方法を示します。

### **外側影効果を適用する**

外側影効果は、テキストのアウトラインの背後に影を付けて、深みと背景からの分離感を生み出し、テキストを際立たせます。Aspose.Slides for .NET を使用すると、WordArt テキストに外側影を簡単に適用およびカスタマイズできます。このセクションでは、影の色、方向、距離、ぼかし半径などを設定して、期待通りのビジュアルインパクトを得る方法を学びます。

以下の C# コードスニペットが、先ほど作成したテキストに影効果を適用します。

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

結果のテキスト:

![外側影効果](outer_shadow_effect.png)

{{% alert color="info" %}} 
- OuterShadow と PresetShadow を同時に使用すると、適用されるのは OuterShadow 効果だけです。
- OuterShadow と InnerShadow を同時に使用した場合、効果は PowerPoint のバージョンによって異なります。たとえば PowerPoint 2013 では効果が二重になり、PowerPoint 2007 では OuterShadow 効果のみが適用されます。
{{% /alert %}}

### **反射効果を適用する**

このセクションでは、Aspose.Slides for .NET を使用してスライドに反射効果を適用する方法を紹介します。反射効果は、テキストや図形にスタイリッシュでモダンな外観を与え、重要な要素を目立たせ、プレゼンテーションに奥行きを加える効果的な手段です。これらの効果の適用とカスタマイズのプロセスを理解すれば、デザインニーズやブランド要件に合わせて簡単に調整できます。

以下の C# コード例でテキストに反射効果を追加します。

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

結果のテキスト:

![反射効果](reflection_effect.png)

### **グロー効果を適用する**

このセクションでは、Aspose.Slides for .NET を使用してテキストにグロー効果を適用する方法を紹介します。グロー効果は、光るアウトラインでテキストを際立たせ、スライドの視覚的魅力を高めます。色や強度などの設定を調整することで、デザインやブランドのニーズに合わせてグローを簡単にカスタマイズでき、プレゼンテーションの重要ポイントが聴衆の注意を引くようになります。

以下のコードでテキストにグロー効果を適用し、光らせます。

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

結果のテキスト:

![グロー効果](glow_effect.png)

### **WordArt 変形を適用する**

このセクションでは、Aspose.Slides for .NET で WordArt の変形を使用する方法を紹介します。変形により、テキストを曲げたり伸ばしたり、ねじったりして、独自で視覚的に印象的な効果を作り出せます。これらのテクニックを習得すれば、テキストの形状やスタイルをブランドやクリエイティブなビジョンに合わせて簡単に調整でき、説得力のある洗練されたプレゼンテーションが実現します。

以下のコードで `Transform` プロパティ（テキスト全体に適用）を使用します。

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

結果のテキスト:

![WordArt 変形](transform_effect.png)

{{% alert color="info" %}} 
Aspose.Slides for .NET は、事前定義された[変換タイプ](https://reference.aspose.com/slides/ja/net/aspose.slides/textshapetype/)のセットを提供します。
{{% /alert %}} 

### **シェイプとテキストに 3D 効果を適用する**

リアルで目を引くビジュアルを作成すると、プレゼンテーションのインパクトが大幅に向上します。このセクションでは、Aspose.Slides for .NET を使用してシェイプに三次元 (3D) 効果を適用する方法を探ります。深さ、角度、照明などのパラメータを操作することで、観客の注意をすぐに引く印象的な 3D 変形を実現できます。微妙なハイライトからドラマチックな錯覚まで、これらの機能はデザインを高め、アイデアをより魅力的に伝える柔軟な方法を提供します。

以下のサンプルコードでシェイプに 3D 効果を設定します。

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

結果のシェイプ:

![シェイプ 3D 効果](shape_3D_effect.png)

以下のサンプルコードでテキストに 3D 効果を設定します。

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

結果のテキスト:

![テキスト 3D 効果](text_3D_effect.png)

{{% alert color="info" %}} 
テキストまたはそのシェイプへの 3D 効果の適用と、これらの効果間の相互作用は特定のルールに従います。テキストとそのテキストを含むシェイプの両方があるシーンを考えてみましょう。3D 効果はオブジェクトの 3D 表現と配置されるシーンを含みます。

- シェイプとテキストの両方にシーンが設定されている場合、シェイプのシーンが優先され、テキストのシーンは無視されます。
- シェイプに独自のシーンがなく 3D 表現だけがある場合、テキストのシーンが使用されます。
- シェイプに 3D 効果が全くない場合、平面として扱われ、3D 効果はテキストのみに適用されます。

これらの動作は[ThreeDFormat.LightRig](https://reference.aspose.com/slides/ja/net/aspose.slides/threedformat/lightrig/) と [ThreeDFormat.Camera](https://reference.aspose.com/slides/ja/net/aspose.slides/threedformat/camera/) プロパティに関連しています。
{{% /alert %}} 

## **FAQ**

### 異なるフォントやスクリプト（例: アラビア語、中文）で WordArt エフェクトを使用できますか？

はい、Aspose.Slides for .NET は Unicode をサポートし、主要なフォントとスクリプトすべてで動作します。影、塗りつぶし、アウトラインなどの WordArt エフェクトは言語に関係なく適用でき、フォントの可用性とレンダリングはシステムフォントに依存する場合があります。

### スライドマスターの要素に WordArt エフェクトを適用できますか？

はい、マスタースライド上の形状（タイトルプレースホルダー、フッター、背景テキストなど）に WordArt エフェクトを適用できます。マスターレイアウトに加えた変更は、関連付けられたすべてのスライドに反映されます。

### WordArt エフェクトはプレゼンテーションのファイルサイズに影響しますか？

やや影響します。影、グロー、グラデーション 塗りつぶしなどのエフェクトは、追加の書式メタデータを伴うためファイルサイズが若干増加しますが、差は通常無視できる程度です。

### プレゼンテーションを保存せずに WordArt エフェクトの結果をプレビューできますか？

はい、`GetImage` メソッドを使用して、[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) または [ISlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/) インターフェイスから WordArt を含むスライドを画像（PNG、JPEG など）にレンダリングできます。これにより、プレゼンテーション全体を保存またはエクスポートする前に、メモリ内または画面上で結果をプレビューできます。