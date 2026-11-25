---
title: .NET でプレゼンテーションに形状効果を適用する
linktitle: 形状効果
type: docs
weight: 30
url: /ja/net/shape-effect/
keywords:
- 形状効果
- 影効果
- 反射効果
- グロー効果
- ソフトエッジ効果
- 効果フォーマット
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して高度な形状効果で PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **はじめに**

PowerPoint の効果は形状を際立たせるために使用できますが、[塗りつぶし](/slides/ja/net/shape-formatting/#gradient-fill) やアウトラインとは異なります。PowerPoint の効果を使用すると、形状にリアルな反射を作成したり、形状の光彩を広げたりすることができます。

![形状効果](shape-effect.png)

PowerPoint には、形状に適用できる 6 つの効果が用意されています。1 つまたは複数の効果を形状に適用できます。

効果の組み合わせの中には、他より見栄えが良いものがあります。そのため、PowerPoint では **Preset** にオプションが用意されています。Preset オプションは、実質的に見た目の良い 2 つ以上の効果の組み合わせです。これにより、プリセットを選択するだけで、さまざまな効果をテストしたり組み合わせたりする時間を節約できます。

Aspose.Slides は、PowerPoint プレゼンテーション内の形状に同じ効果を適用できるように、[EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供します。

## **影効果の適用**

Aspose.Slides for .NET は、形状に対して外側影と内側影をサポートしています。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側影の適用**

外側影を使用すると、カードやパネルをスライドの背景に対して際立たせることができます。影は形状のエッジの外側まで広がり、形状がスライド上に浮き上がっているように見せます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この C# コードは、矩形に [外側影効果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) を適用する方法を示しています。

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

### **内側影の適用**

テンプレートのビジュアルスタイルを再現する際は、カードやパネルに凹んだ外観を与えるために内側影を使用します。外側影は形状の外側に広がり、浮き上がって見えますが、内側影はエッジの内側を陰影付けします。

[EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) を呼び出し、次に [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) を設定します。値を大きくするとエッジが柔らかくなります。

この C# の例は、淡い青色のカードに濃い灰色の内側影を付け、PPTX ファイルとして保存します。

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

![内側影付きの淡青色矩形](inner_shadow_effect.png)

内側影を削除するには、形状の EffectFormat で [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) を呼び出します。

### **プリセット影の適用、変更、削除**

[EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) を呼び出し、[Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) に名前付きの [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) を設定します。同じ形状でスタイルを切り替えるには、プリセットを変更します。[DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) を呼び出すと、塗りつぶしとアウトラインを保持したまま影を削除できます。

この例では、各段階で矩形のコピーを保持します。両方の影は 10 ポイントオフセットされています。方向が 225° の場合、最初の影は矩形の左上に配置され、45° の場合、2 番目の影は右下に配置されます。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| 元の状態 | 最初のプリセット | 2番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![影なし](preset_shadow_original.png) | ![左上ドロップ影](preset_shadow_top_left.png) | ![右下ドロップ影](preset_shadow_bottom_right.png) | ![削除後の影なし](preset_shadow_removed.png) |

## **反射効果の適用**

Aspose.Slides for .NET で反射効果を適用するには、形状に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。この効果は、形状に洗練された外観を与えることでプレゼンテーションの美観を向上させます。シンプルなコードで簡単に実装でき、複数の要素に素早く適用して一貫したデザインを実現できます。

この C# コードは、形状に [反射効果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) を適用する方法を示しています。

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

## **グロー効果の適用**

Aspose.Slides for .NET で形状にグロー効果を適用するには、形状の周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整します。この効果は形状を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の外観を向上させます。

この C# コードは、形状に [グロー効果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) を適用する方法を示しています。

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

## **ソフトエッジ効果の適用**

Aspose.Slides for .NET でソフトエッジ効果を適用するには、形状のエッジ周辺に滑らかでぼやけた遷移を作成します。この効果は、より控えめで洗練された外観を追加し、やさしく柔らかい外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな形状に目的の効果を実現できます。

この C# コードは、形状に [ソフトエッジ](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) を適用する方法を示しています。

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

## **ぼかし効果の適用**

シェイプぼかしを使用すると、形状の塗りつぶしとアウトラインをソフトにしながら、形状を編集可能なままにできます。形状の EffectFormat で [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) を呼び出します。半径はポイント（1/72 インチ）で測定され、負の値は使用できません。値が大きいほど強いぼかしになります。半径が 0 の場合、外観は変わりません。

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) 設定は、効果の可視境界を制御します。`false` の場合、ぼかしは元の描画境界（アウトラインを含む）にクリップされます。`true` の場合、ぼかしはその境界を超えて広がります。どちらの設定も形状の位置やサイズは変更しません。

以下の比較では、同じ塗りつぶし、アウトライン、形状の寸法を使用しています。上段は `grow = false`、下段は `grow = true` を使用しています。

![ぼかし半径 5 と 15 ポイント、grow 無効・有効の元の矩形比較](shape_blur_comparison.png)

この C# の例は、オレンジ色の矩形に濃い青色のアウトラインを付け、5 ポイントのぼかしを適用し、次に [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、[DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) を呼び出してぼかしなしの形状を保存します。

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

シェイプぼかしは塗りつぶしとアウトラインの両方に影響します。ソフトエッジ効果は形状のエッジをフェードさせ、シャドウぼかしは影だけを柔らかくします。画像変換効果は画像コンテンツに対して作用しますが、この例では形状を画像に変換せず、直接 Shape の EffectFormat にぼかしを適用しています。

## **よくある質問**

**同じ形状に複数の効果を適用できますか？**

はい、影、反射、グローなどの異なる効果を組み合わせて、単一の形状に適用し、よりダイナミックな外観を作り出すことができます。

**どのような形状に効果を適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな形状に効果を適用できます。

**グループ化された形状に効果を適用できますか？**

はい、グループ化された形状にも効果を適用できます。効果はグループ全体に適用されます。