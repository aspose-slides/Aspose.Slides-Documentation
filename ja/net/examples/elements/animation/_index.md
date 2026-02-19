---
title: アニメーション
type: docs
weight: 100
url: /ja/net/examples/elements/animation/
keywords:
- アニメーション
- アニメーションの追加
- アニメーションへのアクセス
- アニメーションの削除
- アニメーションシーケンス
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のアニメーション例を探索しましょう：C# を使用して PPT、PPTX、ODP プレゼンテーションのエフェクトやトランジションを追加、シーケンス化、カスタマイズできます。"
---
この記事では、**Aspose.Slides for .NET** を使用してシンプルなアニメーションを作成し、そのシーケンスを管理する方法を示します。

## **アニメーションの追加**

矩形シェイプを作成し、クリックでトリガーされるフェード効果を適用します。

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // フェード効果。
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **アニメーションへのアクセス**

スライドのタイムラインから最初のアニメーション効果を取得します。

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 最初のアニメーション効果にアクセスします。
    var effect = slide.Timeline.MainSequence[0];
}
```

## **アニメーションの削除**

シーケンスからアニメーション効果を削除します。

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // エフェクトを削除します。
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **アニメーションのシーケンス化**

複数の効果を追加し、アニメーションが実行される順序を示します。

```csharp
static void SequenceAnimations()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var sequence = slide.Timeline.MainSequence;
    sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```