---
title: .NET でプレゼンテーションのシェイプ効果を適用する
linktitle: シェイプ効果
type: docs
weight: 30
url: /ja/net/shape-effect/
keywords:
- シェイプ効果
- 影効果
- 反射効果
- グロー効果
- ソフトエッジ効果
- エフェクトフォーマット
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して高度なシェイプ効果で PPT と PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **概要**

PowerPoint のエフェクトはシェイプを目立たせるために使用できますが、[fills](/slides/ja/net/shape-formatting/#gradient-fill) やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、シェイプにリアルな反射を作成したり、シェイプのグローを広げたりすることができます。

![シェイプ効果](shape-effect.png)

PowerPoint はシェイプに適用できる 6 つのエフェクトを提供しています。シェイプには 1 つまたは複数のエフェクトを適用できます。

エフェクトの組み合わせの中には、他よりも見栄えが良いものがあります。そのため、PowerPoint には **Preset** のオプションがあります。Preset オプションは、実質的に 2 つ以上のエフェクトの見栄えの良い組み合わせがあらかじめ定義されたものです。このように、プリセットを選択すれば、さまざまなエフェクトをテストしたり組み合わせたりして最適な組み合わせを探す手間が省けます。

Aspose.Slides は、PowerPoint プレゼンテーションのシェイプに同じエフェクトを適用できるように、[EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供します。

## **影エフェクトを適用する**

Aspose.Slides for .NET はシェイプに対して外部シャドウと内部シャドウをサポートしています。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外部シャドウを適用する**

外部シャドウを使用して、カードやパネルをスライドの背景から際立たせます。シャドウはシェイプのエッジの外側に広がり、シェイプがスライド上で浮き上がっているように見せます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この C# コードは、矩形に [外部シャドウ効果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) を適用する方法を示しています：

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

![シャドウ効果](shadow_effect.png)

### **内部シャドウを適用する**

テンプレートのビジュアルスタイルを再現する際には、内部シャドウを使用してカードやパネルに凹んだ外観を与えます。外部シャドウはシェイプの外側に広がり、浮き上がって見えるのに対し、内部シャドウはエッジの内部に影を付けます。

まず [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) を呼び出し、次に [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) を設定します。値が大きいほどエッジが柔らかくなります。

この C# の例は、淡い青のカードに濃い灰色の内部シャドウを付け、PPTX ファイルとして保存します：

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

![内部シャドウ付きの淡い青い矩形](inner_shadow_effect.png)

内部シャドウを削除するには、シェイプのエフェクトフォーマットで [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) を呼び出します。

## **反射エフェクトを適用する**

Aspose.Slides for .NET で反射エフェクトを適用するには、シェイプに鏡のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。このエフェクトはシェイプに洗練された外観を与え、プレゼンテーションの美的感覚を高めます。シンプルなコードで簡単に実装でき、複数の要素に迅速に適用して一貫したデザインを実現できます。

この C# コードは、シェイプに [反射効果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) を適用する方法を示しています：

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

![反射効果](reflection_effect.png)

## **グローエフェクトを適用する**

Aspose.Slides for .NET でシェイプにグローエフェクトを適用するには、シェイプの周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整します。このエフェクトはシェイプを際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の見た目を向上させます。

この C# コードは、シェイプに [グロー効果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) を適用する方法を示しています：

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

![グロー効果](glow_effect.png)

## **ソフトエッジエフェクトを適用する**

Aspose.Slides for .NET でソフトエッジエフェクトを適用するには、シェイプのエッジ周辺に滑らかでぼやけたトランジションを作成できます。このエフェクトは、より繊細で洗練された外観を加え、柔らかく穏やかな外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまなシェイプに目的の効果を適用できます。

この C# コードは、シェイプに [ソフトエッジ効果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) を適用する方法を示しています：

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

![ソフトエッジ効果](soft_edges_effect.png)

## **ぼかしエフェクトを適用する**

シェイプのぼかしを使用して、シェイプを編集可能なまま塗りつぶしとアウトラインを柔らかくします。シェイプのエフェクトフォーマットで [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) を呼び出します。半径はポイント単位 (1/72 インチ) で測定され、負の値は使用できません。値が大きいほどぼかしが強くなります。半径がゼロの場合、外観は変わりません。

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) 設定はエフェクトの可視範囲を制御します。`false` の場合、ぼかしは元の描画範囲（アウトラインを含む）にクリップされます。`true` の場合、ぼかしはその範囲を超えて広がることができます。どちらの設定もシェイプの位置やサイズは変更しません。

以下の比較では、全体で同じ塗りつぶし、アウトライン、シェイプのサイズを使用しています。上の行は `grow = false`、下の行は `grow = true` を使用しています。

![元の矩形とぼかし半径 5 と 15 ポイントの比較（grow 無効/有効）](shape_blur_comparison.png)

この C# の例は、オレンジ色の矩形に濃い青のアウトラインを付け、5 ポイントのぼかしを適用し、[SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、その後 [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) を呼び出してぼかしのないシェイプを保存します。

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

シェイプのぼかしは塗りつぶしとアウトラインの両方に影響します。ソフトエッジ効果はシェイプのエッジをフェードさせますが、シャドウのぼかしはシャドウだけを柔らかくします。画像変換エフェクトは画像コンテンツに対して適用されますが、この例ではシェイプを画像に変換せずにシェイプのエフェクトフォーマットに直接ぼかしを適用しています。

## **FAQ**

**同じシェイプに複数のエフェクトを適用できますか？**

はい、影、反射、グローなどの異なるエフェクトを単一のシェイプに組み合わせて、より動的な外観を作成できます。

**どのシェイプにエフェクトを適用できますか？**

自動シェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまなシェイプにエフェクトを適用できます。

**グループ化されたシェイプにエフェクトを適用できますか？**

はい、グループ化されたシェイプにもエフェクトを適用できます。エフェクトはグループ全体に適用されます。