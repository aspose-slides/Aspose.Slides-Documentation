---
title: 動畫
type: docs
weight: 100
url: /zh-hant/net/examples/elements/animation/
keywords:
- 動畫
- 新增動畫
- 存取動畫
- 移除動畫
- 動畫序列
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 的動畫範例：使用 C# 為 PPT、PPTX 與 ODP 簡報新增、排序及自訂效果與轉場。"
---
本文示範如何使用 **Aspose.Slides for .NET** 建立簡單的動畫並管理其序列。

## **新增動畫**

建立一個矩形形狀，並套用點擊時觸發的淡出效果。

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

## **存取動畫**

從投影片時間軸取得第一個動畫效果。

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 存取第一個動畫效果。
    var effect = slide.Timeline.MainSequence[0];
}
```

## **移除動畫**

從序列中移除動畫效果。

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 移除效果。
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **動畫序列**

新增多個效果，並示範動畫發生的順序。

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