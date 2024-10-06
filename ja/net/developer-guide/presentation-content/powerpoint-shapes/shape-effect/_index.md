---
title: シェイプ効果
type: docs
weight: 30
url: /ja/net/shape-effect
keywords: "シェイプ効果, PowerPoint プレゼンテーション C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint シェイプに効果を適用する"
---

PowerPoint の効果はシェイプを引き立てるために使用できますが、[塗りつぶし](/slides/ja/net/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint の効果を使用すると、シェイプに説得力のある反射を作成したり、シェイプの輝きを広げたりできます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint には、シェイプに適用できる6つの効果があります。1つ以上の効果をシェイプに適用できます。

* 効果の組み合わせによっては、他のものよりも見栄えが良くなる場合があります。この理由から、PowerPoint のオプションの中に **プリセット** があります。プリセットオプションは、2つ以上の効果の既知の良い組み合わせです。これにより、プリセットを選択することで、良い組み合わせを見つけるために異なる効果をテストまたは組み合わせする時間を無駄にすることがありません。

Aspose.Slides では、[EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) クラスのプロパティとメソッドを使用して、PowerPoint プレゼンテーション内のシェイプに同じ効果を適用できます。

## **影効果を適用します**

この C# コードは、長方形に外側の影効果 ([OuterShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)) を適用する方法を示しています。

```c#
using (var pres = new Presentation())
{
    var shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableOuterShadowEffect();
    shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
    shape.EffectFormat.OuterShadowEffect.Distance = 10;
    shape.EffectFormat.OuterShadowEffect.Direction = 45;

    pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **反射効果を適用します**

この C# コードは、シェイプに反射効果を適用する方法を示しています。

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableReflectionEffect();
    shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
    shape.EffectFormat.ReflectionEffect.Direction = 90;
    shape.EffectFormat.ReflectionEffect.Distance = 55;
    shape.EffectFormat.ReflectionEffect.BlurRadius = 4;

    pres.Save("reflection.pptx", SaveFormat.Pptx);
}
```

## **グロー効果を適用します**

この C# コードは、シェイプにグロー効果を適用する方法を示しています。

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableGlowEffect();
    shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
    shape.EffectFormat.GlowEffect.Radius = 15;

    pres.Save("glow.pptx", SaveFormat.Pptx);
}
```

## **ソフトエッジ効果を適用します**

この C# コードは、シェイプにソフトエッジを適用する方法を示しています。

```c#
using (var pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.EffectFormat.EnableSoftEdgeEffect();
    shape.EffectFormat.SoftEdgeEffect.Radius = 15;

    pres.Save("softEdges.pptx", SaveFormat.Pptx);
}
```