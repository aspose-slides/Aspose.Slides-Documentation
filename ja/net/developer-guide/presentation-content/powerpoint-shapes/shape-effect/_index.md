---
title: C# を使用して PowerPoint でシェイプ効果を適用する
linktitle: シェイプ効果
type: docs
weight: 30
url: /ja/net/shape-effect
keywords:
- 形状効果
- 影効果
- 反射効果
- 光彩効果
- ソフト エッジ効果
- ベベル効果
- 3D フォーマット
- 3D 回転
- PowerPoint
- プレゼンテーション
- C#
- .NET
- Aspose.Slides
description: ".NET 用 Aspose.Slides を使用して、影や反射、光彩などの魅力的なシェイプ効果で PowerPoint プレゼンテーションを強化します。使いやすいコードで視覚的な強化を自動化し、手間なくプロ品質のスライドを作成できます。"
---

## **概要**

PowerPoint のエフェクトは図形を目立たせるために使用できますが、[fills](/slides/ja/net/shape-formatting/#gradient-fill) やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、図形にリアルな反射を作成したり、図形の輝きを広げたりすることができます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint には図形に適用できる 6 つのエフェクトがあります。1 つまたは複数のエフェクトを図形に適用できます。

エフェクトの組み合わせの中には、他より見栄えが良いものがあります。そのため、PowerPoint には **Preset** のオプションがあります。Preset オプションは、実質的に 2 つ以上のエフェクトの見栄えの良い組み合わせをあらかじめ定義したものです。これにより、プリセットを選択するだけで、さまざまなエフェクトを試したり組み合わせて好みの組み合わせを見つける手間が省けます。

Aspose.Slides は [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) クラスにプロパティとメソッドを提供しており、PowerPoint プレゼンテーション内の図形に同じエフェクトを適用できます。

## **影エフェクトの適用**

Aspose.Slides for .NET で図形に影エフェクトを適用するには、色、ぼかし半径、方向などのパラメータを簡単に調整できます。これにより、図形がよりダイナミックでプロフェッショナルに見え、奥行きと焦点が加わります。シンプルなコードスニペットを使用すれば、複数の図形にこのエフェクトを適用でき、プレゼンテーション全体のビジュアル魅力が向上します。

この C# コードは、矩形に [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) を適用する方法を示しています。
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


![影エフェクト](shadow_effect.png)

## **反射エフェクトの適用**

Aspose.Slides for .NET で反射エフェクトを適用するには、図形に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整できます。このエフェクトは、図形に洗練された外観を与えることでプレゼンテーションの美しさを高めます。シンプルなコードで簡単に実装でき、複数の要素に素早く適用できるため、デザインの一貫性が保たれます。

この C# コードは、図形に [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) を適用する方法を示しています。
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


![反射エフェクト](reflection_effect.png)

## **Glow エフェクトの適用**

Aspose.Slides for .NET で図形に Glow エフェクトを適用するには、図形の周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整します。このエフェクトは図形を目立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の見栄えが向上します。

この C# コードは、図形に [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) を適用する方法を示しています。
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```


![Glow エフェクト](glow_effect.png)

## **ソフトエッジエフェクトの適用**

Aspose.Slides for .NET でソフトエッジエフェクトを適用すると、図形のエッジ周辺に滑らかでぼかされたトランジションを作成できます。このエフェクトは、より控えめで洗練された外観を加え、穏やかで柔らかな見た目が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に希望の効果を実現できます。

この C#コードは、図形に [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) を適用する方法を示しています。
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```


![ソフトエッジエフェクト](soft_edges_effect.png)

## **よくある質問**

**同じ図形に複数のエフェクトを適用できますか？**

はい、影、反射、Glow などの異なるエフェクトを単一の図形に組み合わせて、よりダイナミックな外観にすることができます。

**どのような図形にエフェクトを適用できますか？**

自動図形、グラフ、表、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形にエフェクトを適用できます。

**グループ化された図形にエフェクトを適用できますか？**

はい、グループ化された図形にもエフェクトを適用できます。エフェクトはグループ全体に適用されます。