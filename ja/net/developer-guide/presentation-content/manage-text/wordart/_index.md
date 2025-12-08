---
title: C# で WordArt 効果を作成および適用する
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
- 光彩効果
- WordArt 変形
- 3D 効果
- 外側の影効果
- 内側の影効果
- C#
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET で WordArt 効果を作成およびカスタマイズする方法を学びます。このステップバイステップ ガイドは、開発者が C# でスタイリッシュでプロフェッショナルなテキストを使用してプレゼンテーションを向上させるのに役立ちます。"
---

## **概要**

WordArt 効果を使用すると、PowerPoint プレゼンテーションに視覚的に魅力的でスタイリッシュなテキストを追加できます。Aspose.Slides for .NET を使用すれば、Office をインストールせずに、Microsoft PowerPoint と同様に WordArt をプログラムで作成、カスタマイズ、管理できます。本記事では、.NET で WordArt を扱う概要を説明し、テキスト変換、塗りつぶしスタイル、アウトライン、影、その他の書式設定オプションを適用して、プレゼンテーションの内容をより表現力豊かで魅力的にする方法を紹介します。WordArt はテキストをグラフィック オブジェクトとして扱うことができます。テキストに対して適用される効果や特別な変更により、テキストをより目立たせたり魅力的にしたりします。

## **シンプルな WordArt テンプレートを作成しテキストに適用する**

このセクションでは、Aspose.Slides for .NET を使用してシンプルな WordArt テンプレートを作成し、テキストに適用する方法を探ります。WordArt は、印象的なビジュアル効果やスタイルでテキストの外観を向上させる簡単な手段です。WordArt の作成と使用の基本手順を学べば、任意のプロジェクトにすぐに適用でき、プレゼンテーションをより鮮やかで記憶に残るものにできます。

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


次に、以下のコードでテキストのフォントの高さを大きく設定し、効果を目立たせます。
```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```


ここでは、SmallGrid パターン塗りつぶしをテキストに適用し、幅 1 の黒いテキスト枠線を追加します。
```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```


結果のテキスト:

![単純なWordArtテンプレート](WordArt_template.png)

## **その他の WordArt 効果を適用する**

基本的な変形に加えて、Aspose.Slides for .NET では、テキストの外観を強化するさまざまな高度な WordArt 効果を適用できます。これらにはアウトライン、塗りつぶし、影、反射、光彩効果が含まれます。これらの機能を組み合わせることで、プレゼンテーションで際立つ目を引くテキスト スタイルを作成できます。このセクションでは、シンプルでクリーンなコード例を使って、これらの効果をプログラムで適用する方法を示します。

### **外側の影効果を適用する**

外側の影効果は、テキストの輪郭の背後に影を付けて深みと背景からの分離感を生み出し、テキストを際立たせます。Aspose.Slides for .NET を使用すると、WordArt テキストに外側の影を簡単に適用およびカスタマイズできます。このセクションでは、影の色、方向、距離、ぼかし半径などを設定して、目的のビジュアル インパクトを実現する方法を学びます。

次の C# コード スニペットは、上記で作成したテキストに影効果を適用します。
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

![外側の影効果](outer_shadow_effect.png)

{{% alert color="primary" %}} 
- OuterShadow と PresetShadow を同時に使用すると、適用されるのは OuterShadow 効果のみです。  
- OuterShadow と InnerShadow を同時に使用した場合、結果の効果は PowerPoint のバージョンに依存します。たとえば、PowerPoint 2013 では効果が二重になり、PowerPoint 2007 では OuterShadow 効果のみが適用されます。  
{{% /alert %}}

### **反射効果を適用する**

このセクションでは、Aspose.Slides for .NET を使用してスライドに反射効果を適用する方法を探ります。反射効果は、テキストや図形にスタイリッシュでモダンな外観を与え、重要な要素を際立たせ、プレゼンテーションに奥行きを加える効果的な手段です。これらの効果の適用とカスタマイズ手順を理解すれば、デザイン要件やブランド要件に合わせて簡単に調整できます。

次の C# コード例でテキストに反射効果を追加します。
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

![反射効果](reflection_effect.png)

### **光彩効果を適用する**

このセクションでは、Aspose.Slides for .NET を使用してテキストに光彩効果を適用する方法を探ります。光彩効果は、テキストに光る輪郭を付けて際立たせ、スライドの視覚的魅力を高めます。色や強度などの設定を調整することで、デザインやブランドのニーズに合わせた光彩を簡単に作成でき、プレゼンテーションの重要ポイントを観客の注意に引き付けることができます。

次のコードでテキストに光彩効果を適用し、輝かせます。
```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```


結果のテキスト:

![光彩効果](glow_effect.png)

### **WordArt の変形を適用する**

このセクションでは、Aspose.Slides for .NET で WordArt の変形を使用する方法を探ります。変形によりテキストを曲げたり伸ばしたり、歪めたりして、独自で視覚的に際立った効果を作り出せます。これらのテクニックを習得すれば、テキストの形状やスタイルをブランドやクリエイティブなビジョンに合わせて簡単に調整でき、説得力のある洗練されたプレゼンテーションを実現できます。

次のコードで `Transform` プロパティ（テキスト全体に適用）を使用します。
```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```


結果のテキスト:

![WordArt 変形効果](transform_effect.png)

{{% alert color="primary" %}} 
Aspose.Slides for .NET は、事前定義された[変形タイプ](https://reference.aspose.com/slides/net/aspose.slides/textshapetype/)のセットを提供します。  
{{% /alert %}} 

### **シェイプとテキストに 3D 効果を適用する**

リアルで目を引くビジュアルを作成すると、プレゼンテーションのインパクトが大幅に向上します。このセクションでは、Aspose.Slides for .NET を使用してシェイプに三次元 (3D) 効果を適用する方法を探ります。深さ、角度、照明などのパラメーターを操作することで、観客の注意を瞬時に引く印象的な 3D 変形を作成できます。微妙なハイライトからドラマチックな錯覚まで、これらの機能はデザインを格上げし、アイデアをより魅力的に伝える柔軟な手段を提供します。

次のサンプルコードでシェイプに 3D 効果を設定します。
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

![シェイプの 3D 効果](shape_3D_effect.png)

次のサンプルコードでテキストに 3D 効果を設定します。
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

![テキストの 3D 効果](text_3D_effect.png)

{{% alert color="primary" %}} 
テキストまたはそのシェイプに 3D 効果を適用する際のルールと、これらの効果間の相互作用は特定の規則に従います。テキストとそのテキストを含むシェイプの両方がシーンを持つケースを考えてみましょう。3D 効果にはオブジェクトの 3D 表現と配置先シーンが含まれます。

- シェイプとテキストの両方にシーンが設定されている場合、シェイプのシーンが優先され、テキストのシーンは無視されます。  
- シェイプにシーンがないが 3D 表現がある場合、テキストのシーンが使用されます。  
- シェイプに 3D 効果がまったくない場合、フラットとして扱われ、3D 効果はテキストのみに適用されます。  

これらの挙動は [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/lightrig/) と [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/camera/) プロパティに関連しています。  
{{% /alert %}} 

## **FAQ**

**異なるフォントやスクリプト（例: アラビア語、中国語）でも WordArt 効果は使えますか？**

はい、Aspose.Slides for .NET は Unicode をサポートし、すべての主要フォントとスクリプトで動作します。影、塗りつぶし、アウトラインなどの WordArt 効果は言語に関係なく適用できますが、フォントの可用性や描画はシステムにインストールされたフォントに依存する場合があります。

**スライド マスターの要素にも WordArt 効果を適用できますか？**

はい、マスタースライド上のシェイプ（タイトル プレースホルダー、フッター、背景テキストなど）にも WordArt 効果を適用できます。マスター レイアウトに加えた変更は、関連付けられたすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？**

わずかに影響します。影、光彩、グラデーション塗りつぶしなどの効果は、追加の書式メタデータが発生するためファイルサイズを少しだけ増加させますが、差は通常は無視できる程度です。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**

はい、`GetImage` メソッドを使用して、WordArt を含むスライドを画像（PNG、JPEG など）にレンダリングできます。これは、[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) または [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) インターフェイスから取得でき、保存やエクスポートを行う前にメモリ内または画面上で結果をプレビューできます。