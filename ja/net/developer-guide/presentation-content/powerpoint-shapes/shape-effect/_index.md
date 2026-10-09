---
title: ".NET のプレゼンテーションで形状エフェクトを適用する"
linktitle: "形状エフェクト"
type: docs
weight: 30
url: /ja/net/shape-effect/
keywords:
- "形状エフェクト"
- "影エフェクト"
- "反射エフェクト"
- "発光エフェクト"
- "ソフトエッジエフェクト"
- "エフェクト形式"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して高度な形状エフェクトで PPT と PPTX ファイルを変換し、数秒でインパクトのあるプロフェッショナルなスライドを作成します。"
---
## **概要**

PowerPoint のエフェクトは図形を強調表示するために使用できますが、[塗りつぶし](/slides/ja/net/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、図形にリアルな反射を作成したり、図形の発光を広げたりすることができます。

![形状効果](shape-effect.png)

PowerPoint は、図形に適用できる 6 つのエフェクトを提供しています。1 つまたは複数のエフェクトを図形に適用できます。

エフェクトの組み合わせによっては、他よりも見栄えが良くなります。このため、PowerPoint には **Preset** (プリセット) オプションがあります。プリセット オプションは、実質的に 2 つ以上のエフェクトの見栄えの良い既知の組み合わせです。したがって、プリセットを選択すれば、さまざまなエフェクトを試したり組み合わせたりして最適な組み合わせを見つける時間を無駄にしません。

Aspose.Slides は、PowerPoint プレゼンテーションの図形に同じエフェクトを適用できるように、[EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供します。

## **影エフェクトの適用**

Aspose.Slides for .NET は、図形に対する外部影と内部影をサポートしています。プレゼンテーションのデザインに合わせて、影の色、方向、距離、ぼかし半径をカスタマイズできます。

### **外部影の適用**

外部影を使用すると、カードやパネルをスライドの背景から際立たせることができます。影は図形のエッジを超えて伸び、図形がスライド上に持ち上がっているように見せます。テンプレートの照明やスタイルに合わせて、影の色、方向、距離、ぼかし半径を調整してください。

この C# コードは、矩形に[外部影効果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)を適用する方法を示しています:
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

![影効果](shadow_effect.png)

### **内部影の適用**

テンプレートのビジュアル スタイルを再現する際は、カードやパネルに凹んだ外観を与えるために内部影を使用します。外部影は図形の外側に広がり、持ち上がっているように見せますが、内部影はエッジの内部を陰影で表現します。

[EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) を呼び出し、次に [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) を設定します。値が大きいほどエッジが柔らかくなります。

この C# の例は、淡い青色のカードに濃い灰色の内部影を付けて PPTX ファイルとして保存します:
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

![内部影付きの淡青色矩形](inner_shadow_effect.png)

内部影を削除するには、形状の EffectFormat で [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) を呼び出します。

## **反射エフェクトの適用**

Aspose.Slides for .NET で反射エフェクトを適用するには、形状に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。このエフェクトは、形状により洗練された外観を与えることで、プレゼンテーションの美しさを向上させます。シンプルなコードで簡単に実装でき、複数の要素に素早く適用して一貫したデザインを実現できます。

この C# コードは、形状に[反射効果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/)を適用する方法を示しています:
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

## **発光エフェクトの適用**

Aspose.Slides for .NET で図形に発光エフェクトを適用するには、色やサイズなどのプロパティを調整しながら、図形の周囲に柔らかく光るオーラを追加します。このエフェクトは図形を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の外観を向上させます。

この C# コードは、形状に[発光効果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/)を適用する方法を示しています:
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

![発光効果](glow_effect.png)

## **ソフトエッジエフェクトの適用**

Aspose.Slides for .NET でソフトエッジエフェクトを適用すると、図形のエッジ周辺に滑らかでぼやけたトランジションを作成できます。このエフェクトは、より繊細で洗練された外観を加え、柔らかく穏やかなデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に目的の効果を適用できます。

この C# コードは、形状に[ソフトエッジ](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/)を適用する方法を示しています:
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

## **FAQ**

**同じ図形に複数のエフェクトを適用できますか？**

はい、影、反射、発光などの異なるエフェクトを単一の図形に組み合わせて、より動的な外観を作成できます。

**どのような図形にエフェクトを適用できますか？**

自動図形、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形にエフェクトを適用できます。

**グループ化した図形にエフェクトを適用できますか？**

はい、グループ化した図形にもエフェクトを適用できます。エフェクトはグループ全体に適用されます。