---
title: 动画
type: docs
weight: 100
url: /zh/net/examples/elements/animation/
keywords:
- 动画
- 添加动画
- 访问动画
- 删除动画
- 动画序列
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 动画示例：使用 C# 为 PPT、PPTX 和 ODP 演示文稿添加、排序和自定义效果与切换。"
---
本文演示如何使用 **Aspose.Slides for .NET** 创建简单动画并管理其顺序。

## **添加动画**

创建一个矩形形状，并在点击时应用淡入效果。

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // 淡入效果。
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **访问动画**

从幻灯片时间线中检索第一个动画效果。

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 访问第一个动画效果。
    var effect = slide.Timeline.MainSequence[0];
}
```

## **删除动画**

从序列中删除动画效果。

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 删除效果。
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **序列动画**

添加多个效果，并演示动画执行的顺序。

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