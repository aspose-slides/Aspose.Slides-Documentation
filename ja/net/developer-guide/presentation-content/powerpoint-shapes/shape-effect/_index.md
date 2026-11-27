---
title: .NET でプレゼンテーションのシェイプ エフェクトを適用する
linktitle: シェイプ エフェクト
type: docs
weight: 30
url: /ja/net/shape-effect/
keywords:
- シェイプ エフェクト
- 影 エフェクト
- 反射 エフェクト
- グロー エフェクト
- ソフトエッジ エフェクト
- エフェクト フォーマット
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して高度なシェイプ エフェクトで PPT と PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **導入**

PowerPoint のエフェクトは図形を目立たせるために使用できますが、[塗りつぶし](/slides/ja/net/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、図形にリアルな反射を作成したり、図形のグローを広げたりすることができます。

![シェイプ効果](shape-effect.png)

PowerPoint は図形に適用できる 6 つのエフェクトを提供しています。1 つまたは複数のエフェクトを図形に適用できます。

エフェクトの組み合わせの中には他より見栄えが良いものがあります。このため、PowerPoint には **Preset** のオプションがあります。Preset オプションは、実質的に 2 つ以上のエフェクトの見栄えの良い組み合わせを事前に用意したものです。プリセットを選択すれば、さまざまなエフェクトをテストしたり組み合わせたりして最適な組み合わせを探す時間を節約できます。

Aspose.Slides は [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供し、PowerPoint プレゼンテーションの図形に同じエフェクトを適用できるようにします。

## **影エフェクトの適用**

Aspose.Slides for .NET は図形の外側および内側のシャドウをサポートしています。色、方向、距離、ぼかし半径などをカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側のシャドウの適用**

外側のシャドウを使用すると、カードやパネルがスライドの背景に対して際立ちます。シャドウは図形のエッジを超えて広がり、図形がスライド上で持ち上げられているように見せます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この C# コードは、[外側シャドウ効果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) を長方形に適用する方法を示しています：

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

#### **図形が回転したときのシャドウ方向の制御**

デフォルトでは、[RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) は `true` であり、シャドウは図形とともに回転します。異なる回転を持つ図形が同じ方向から光が当たっているように見せるには、このプロパティを `false` に設定し、シャドウに同じ [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/) を指定します。

この例では、右方向にオフセットした灰色のシャドウ（`Direction = 0`）を持つ 2 本の矢印を作成します。その後、スライドを複製し、両方の矢印を時計回りに 90° 回転させます。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

2 枚目のスライドでは、左側の矢印のシャドウは下向きに投影され、右側の矢印のシャドウは依然として右向きのままです。両方のシャドウの設定された方向は 0° のままです。

![90° 回転前後の PowerPoint 表示。両方のシャドウは右側から開始し、回転後、左矢印の下にシャドウが移動し、右矢印は右側に残ります。](arrow-shadow-rotation.png)

### **内側のシャドウの適用**

テンプレートのビジュアルスタイルを再現する際は、内側シャドウを使用してカードやパネルにくぼんだ外観を付けます。外側シャドウは図形の外側に広がり持ち上げられたように見せ、内側シャドウはエッジ内部を影付けします。

[EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) を呼び出し、次に [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) を設定します。値が大きいほどエッジが柔らかくなります。

この C# の例は、淡い青色のカードに濃い灰色の内側シャドウを付け、PPTX ファイルとして保存します：

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

![内側シャドウ付きの淡い青い長方形](inner_shadow_effect.png)

内側シャドウを削除するには、図形の EffectFormat で [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) を呼び出します。

### **プリセットシャドウの適用、変更、削除**

[EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) を呼び出し、[Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) を名前付きの [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) に設定します。同じ図形でスタイルを切り替えるには、プリセットを変更します。[DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) を呼び出すと、塗りつぶしとアウトラインは保持したままシャドウを削除できます。

この例では、各段階で長方形のコピーを保持します。両方のシャドウは 10 ポイントオフセットされています。方向 225° は最初のシャドウを長方形の左上に配置し、45° は二番目のシャドウを右下に配置します。

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

| 元の状態 | 最初のプリセット | 2 番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![シャドウなし](preset_shadow_original.png) | ![左上ドロップシャドウ](preset_shadow_top_left.png) | ![右下ドロップシャドウ](preset_shadow_bottom_right.png) | ![削除後のシャドウなし](preset_shadow_removed.png) |

## **反射エフェクトの適用**

Aspose.Slides for .NET で反射エフェクトを適用するには、図形に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。このエフェクトは図形により洗練された外観を与え、プレゼンテーションの美しさを高めます。シンプルなコードで簡単に実装でき、複数の要素に素早く適用してデザインの一貫性を保てます。

この C# コードは、[反射エフェクト](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) を図形に適用する方法を示しています：

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

![反射エフェクト](reflection_effect.png)

## **グロウエフェクトの適用**

Aspose.Slides for .NET で図形にグロウエフェクトを適用するには、図形の周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整します。このエフェクトは図形を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の外観を向上させます。

この C# コードは、[グロウエフェクト](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) を図形に適用する方法を示しています：

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

![グロウエフェクト](glow_effect.png)

## **ソフトエッジエフェクトの適用**

Aspose.Slides for .NET でソフトエッジエフェクトを適用するには、図形のエッジ周辺に滑らかでぼやけたトランジションを作成できます。このエフェクトはより微妙で洗練された外観を付加し、柔らかく穏やかな外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形で目的の効果を得られます。

この C# コードは、[ソフトエッジ](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) を図形に適用する方法を示しています：

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

![ソフトエッジエフェクト](soft_edges_effect.png)

## **ぼかしエフェクトの適用**

シェイプブラーを使用すると、図形を編集可能なまま塗りつぶしとアウトラインを柔らかくできます。図形の EffectFormat で [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) を呼び出します。半径はポイント（1/72 インチ）で測定され、負でない値を使用し、値が大きいほど強いぼかしになります。半径が 0 の場合は外観は変わりません。

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) 設定はエフェクトの表示範囲を制御します。`false` の場合、ぼかしは元の描画範囲（アウトラインを含む）にクリップされます。`true` の場合、ぼかしはその範囲を超えて拡張できます。どちらの設定も図形の位置やサイズは変更しません。

以下の比較では、同じ塗りつぶし、アウトライン、図形サイズを使用しています。上段は `grow = false`、下段は `grow = true` を使用しています。

![ぼかし半径 5 と 15 ポイント、grow 無効・有効の比較（元の長方形）](shape_blur_comparison.png)

この C# の例は、オレンジの長方形に濃い青のアウトラインを付け、5 ポイントのぼかしを適用し、次に再度 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) を呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、その後 [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) を呼び出してぼかしなしの図形を保存します。

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

シェイプブラーは塗りつぶしとアウトラインの両方に影響します。ソフトエッジエフェクトは図形のエッジをフェードさせ、シャドウのぼかしはシャドウのみを柔らかくします。画像変換エフェクトは画像コンテンツに適用されますが、この例は図形を画像に変換せず、直接図形の EffectFormat にぼかしを適用しています。

## **よくある質問**

**同じ図形に複数のエフェクトを適用できますか？**

はい、影、反射、グロウなどの異なるエフェクトを単一の図形に組み合わせて、より動的な外観にすることができます。

**どのような図形にエフェクトを適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形にエフェクトを適用できます。

**グループ化された図形にエフェクトを適用できますか？**

はい、グループ化された図形にもエフェクトを適用できます。エフェクトはグループ全体に適用されます。