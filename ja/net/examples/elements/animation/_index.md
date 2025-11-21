---
title: アニメーション
type: docs
weight: 100
url: /ja/net/examples/elements/animation/
keywords:
- アニメーションの例
- アニメーションの追加
- アニメーションへのアクセス
- アニメーションの削除
- アニメーションシーケンス
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してスライド アニメーションをマスターし、効果、タイミング、トリガーを追加、編集、削除して、PPT、PPTX、ODP で動的なプレゼンテーションを作成します。"
---

**Aspose.Slides for .NET** を使用して、シンプルなアニメーションを作成し、そのシーケンスを管理する方法を示します。

## アニメーションを追加

矩形シェイプを作成し、クリック時にトリガーされるフェードイン効果を適用します。
```csharp
static void Add_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // フェードイン効果
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```


## アニメーションにアクセス

スライドのタイムラインから最初のアニメーション効果を取得します。
```csharp
static void Access_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // 最初のアニメーション効果にアクセス
    var effect = slide.Timeline.MainSequence[0];
}
```


## アニメーションを削除

シーケンスからアニメーション効果を削除します。
```csharp
static void Remove_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // 効果を削除
    slide.Timeline.MainSequence.Remove(effect);
}
```


## アニメーションのシーケンス

複数の効果を追加し、アニメーションが発生する順序を示します。
```csharp
static void Sequence_Animations()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var seq = slide.Timeline.MainSequence;
    seq.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    seq.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```
