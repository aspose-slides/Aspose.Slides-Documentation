---
title: .NET で WordArt 効果を作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/net/wordart/
keywords:
- WordArt
- WordArt の作成
- WordArt テンプレート
- WordArt 効果
- 影効果
- 表示効果
- 発光効果
- WordArt 変形
- 3D 効果
- 外側影効果
- 内側影効果
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で WordArt 効果を作成およびカスタマイズします。このステップバイステップ ガイドは、開発者が C# でプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---

## **概要**

WordArt の効果を使用すると、PowerPoint プレゼンテーションに視覚的に魅力的で装飾されたテキストを追加できます。Aspose.Slides for .NET を使用すれば、Office をインストールせずに、Microsoft PowerPoint と同様に WordArt をプログラムで作成、カスタマイズ、管理できます。本稿では、.NET で WordArt を操作する概要を示し、テキスト変形、塗りつぶしスタイル、輪郭、影、その他の書式設定オプションを適用して、プレゼンテーションの内容をより表現力豊かで魅力的にする方法を解説します。WordArt はテキストをグラフィック オブジェクトとして扱います。テキストに対して適用される効果や特殊な修飾によって、より目立ちやすく、印象的にします。

## **シンプルな WordArt テンプレートを作成しテキストに適用する**

このセクションでは、Aspose.Slides for .NET を使ってシンプルな WordArt テンプレートを作成し、テキストに適用する方法を紹介します。WordArt は、印象的な視覚効果とスタイルでテキストの外観を強化する簡単な方法を提供します。WordArt の作成と使用の基本手順を学べば、任意のプロジェクトにすぐに応用でき、プレゼンテーションをより鮮やかで記憶に残るものにできます。

まず、次の C# コードでシンプルなテキストを作成します。
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```


次に、以下のコードでフォントの高さを大きく設定し、効果を目立たせます。
```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```


ここでは、テキストに SmallGrid パターン塗りつぶしを適用し、幅 1 の黒いテキスト枠線を追加するコードを示します。
```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```


結果のテキスト:

![The simple WordArt template](WordArt_template.png)

## **その他の WordArt 効果を適用する**

基本的な変形に加えて、Aspose.Slides for .NET では、テキストの外観を向上させるさまざまな高度な WordArt 効果を適用できます。これらには輪郭、塗りつぶし、影、反射、発光効果が含まれます。これらの機能を組み合わせることで、プレゼンテーションで目立つテキスト スタイルを作成できます。このセクションでは、シンプルで明快なコード例を用いて、プログラムでこれらの効果を適用する方法を示します。

### **外側の影効果を適用する**

外側の影効果は、テキストの輪郭の背後に影を付けることで、奥行き感と背景からの分離感を生み出し、テキストを際立たせます。Aspose.Slides for .NET を使用すると、WordArt テキストに外側の影を簡単に適用およびカスタマイズできます。このセクションでは、影の色、方向、距離、ぼかし半径などを設定して、目的の視覚効果を実現する方法を学びます。

以下の C# コード スニペットは、前述のテキストに影効果を適用します。
```cs
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


結果のテキスト:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="primary" %}} 
- OuterShadow と PresetShadow を同時に使用すると、適用されるのは OuterShadow 効果のみです。
- OuterShadow と InnerShadow を同時に使用した場合、適用結果は PowerPoint のバージョンに依存します。たとえば、PowerPoint 2013 では効果が二重になり、PowerPoint 2007 では OuterShadow 効果のみが適用されます。
{{% /alert %}}

### **反射効果を適用する**

このセクションでは、Aspose.Slides for .NET を使用してスライドに反射効果を適用する方法を紹介します。反射効果は、テキストや図形にスタイリッシュでモダンな外観を与え、重要な要素を際立たせ、プレゼンテーションに深みを加える効果的な手段です。反射効果の適用とカスタマイズ手順を理解すれば、デザイン要件やブランディングに合わせて簡単に調整できます。

以下の C# コード例でテキストに反射効果を追加します。
```cs
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


結果のテキスト:

![The Reflection effect](reflection_effect.png)

### **発光効果を適用する**

このセクションでは、Aspose.Slides for .NET を使用してテキストに発光効果を適用する方法を紹介します。発光効果は、テキストに光る輪郭を付加してスライドの視覚的魅力を高めます。色や強度などの設定を調整することで、デザインやブランディングに合わせた発光効果を簡単に作成でき、プレゼンテーションの重要ポイントを際立たせられます。

以下のコードでテキストに発光効果を適用し、輝かせます。
```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```


結果のテキスト:

![The Glow effect](glow_effect.png)

### **WordArt 変形を適用する**

このセクションでは、Aspose.Slides for .NET を使用した WordArt の変形方法を紹介します。変形を利用すると、テキストを曲げたり、伸ばしたり、歪めたりして、ユニークで視覚的に印象的な効果を作り出せます。これらのテクニックを習得すれば、ブランドやクリエイティブなビジョンに合わせてテキスト形状やスタイルを柔軟に調整でき、説得力のある仕上がりを実現できます。

以下のコードでテキスト全体に適用される `Transform` プロパティを使用します。
```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```


結果のテキスト:

![The WordArt transformation](transform_effect.png)

{{% alert color="primary" %}} 
Aspose.Slides for .NET は、事前定義された[変形タイプ](https://reference.aspose.com/slides/net/aspose.slides/textshapetype/)のセットを提供します。
{{% /alert %}} 

### **シェイプとテキストへの 3D 効果の適用**

リアルで目を引くビジュアルは、プレゼンテーションのインパクトを大幅に高めます。このセクションでは、Aspose.Slides for .NET を使用してシェイプに三次元 (3D) 効果を適用する方法を解説します。深さ、角度、照明などのパラメータを操作することで、観客の注意をすぐに引く印象的な 3D 変換を作成できます。 subtle なハイライトから劇的な錯覚まで、これらの機能はデザインを向上させ、アイデアをより魅力的に伝える柔軟な手段を提供します。

以下のサンプルコードでシェイプに 3D 効果を設定します。
```cs
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


結果のシェイプ:

![The shape 3D effect](shape_3D_effect.png)

以下のサンプルコードでテキストに 3D 効果を設定します。
```cs
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```


結果のテキスト:

![The text 3D effect](text_3D_effect.png)

{{% alert color="primary" %}} 
テキストやそのシェイプへの 3D 効果の適用と、これらの効果間の相互作用は、特定のルールで制御されます。テキストとそのテキストを含むシェイプの両方が存在するシーンを考えてみましょう。3D 効果は、オブジェクトの 3D 表現と配置されるシーンの両方を含みます。

- シェイプとテキストの両方にシーンが設定されている場合、シェイプのシーンが優先され、テキストのシーンは無視されます。
- シェイプに独自のシーンがなく 3D 表現だけがある場合、テキストのシーンが使用されます。
- シェイプに 3D 効果が全くない場合、フラットとして扱われ、3D 効果はテキストのみに適用されます。

これらの動作は、[ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/lightrig/) および [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/camera/) プロパティに関連しています。
{{% /alert %}} 

## **FAQ**

**異なるフォントやスクリプト（例: アラビア語、中国語）でも WordArt 効果は使用できますか？**

はい、Aspose.Slides for .NET は Unicode をサポートし、主要なフォントとスクリプトすべてで動作します。影、塗りつぶし、輪郭などの WordArt 効果は言語に関係なく適用できますが、フォントの可用性や描画はシステムにインストールされたフォントに依存する場合があります。

**スライド マスターの要素にも WordArt 効果を適用できますか？**

はい、マスタースライド上のタイトル プレースホルダー、フッター、背景テキストなどのシェイプにも WordArt 効果を適用できます。マスター レイアウトに行った変更は、関連するすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？**

僅かに影響します。影、発光、グラデーション塗りつぶしなどの効果は、追加の書式設定メタデータを伴うためファイルサイズが若干増加しますが、差は通常無視できる程度です。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**

はい、`GetImage` メソッドを使用して、[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) または [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) インターフェイスから WordArt を含むスライドを画像 (PNG、JPEG など) にレンダリングできます。これにより、保存やエクスポート前にメモリ内または画面上で結果をプレビューできます。