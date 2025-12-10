---
title: 动画
type: docs
weight: 100
url: /zh/net/examples/elements/animation/
keywords:
- 动画示例
- 添加动画
- 访问动画
- 删除动画
- 动画序列
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中掌握幻灯片动画：添加、编辑和删除效果、时间和触发器，以创建 PPT、PPTX 和 ODP 动态演示文稿。"
---

展示如何使用 **Aspose.Slides for .NET** 创建简单动画并管理其顺序。

## **添加动画**

创建一个矩形形状，并在点击时应用淡入效果。
```csharp
static void Add_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // 淡入效果
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```


## **访问动画**

从幻灯片时间轴检索第一个动画效果。
```csharp
static void Access_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // 访问第一个动画效果
    var effect = slide.Timeline.MainSequence[0];
}
```


## **删除动画**

从序列中移除动画效果。
```csharp
static void Remove_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // 移除效果
    slide.Timeline.MainSequence.Remove(effect);
}
```


## **顺序动画**

添加多个效果并演示动画发生的顺序。
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
