---
title: 幻灯片切换
type: docs
weight: 110
url: /zh/net/examples/elements/slide-transition/
keywords:
- 幻灯片切换
- 添加幻灯片切换
- 访问幻灯片切换
- 移除幻灯片切换
- 切换持续时间
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中精通幻灯片切换：通过 C# 示例为 PPT、PPTX 和 ODP 演示文稿添加、定制和排列效果及持续时间。"
---
本文演示如何使用 **Aspose.Slides for .NET** 应用幻灯片切换效果和时间设置。

## **添加幻灯片切换**

对第一张幻灯片应用淡入切换效果。

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 应用淡入切换。
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **访问幻灯片切换**

读取当前分配给幻灯片的切换类型。

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // 访问切换类型。
    var type = slide.SlideShowTransition.Type;
}
```

## **移除幻灯片切换**

通过将类型设置为 `None` 来清除所有切换效果。

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // 通过将类型设置为 None 移除切换。
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **设置切换持续时间**

指定幻灯片在自动前进之前显示的时长。

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // 以毫秒为单位
}
```