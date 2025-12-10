---
title: 幻灯片转场
type: docs
weight: 110
url: /zh/net/examples/elements/slide-transition/
keywords:
- 幻灯片转场示例
- 添加幻灯片转场
- 访问幻灯片转场
- 移除幻灯片转场
- 转场持续时间
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 C# 中使用 Aspose.Slides 控制幻灯片转场：选择类型、速度、声音和时间，以打磨 PPT、PPTX 和 ODP 演示文稿。"
---

演示如何使用 **Aspose.Slides for .NET** 应用幻灯片转场效果和时间设置。

## **添加幻灯片转场**

对第一张幻灯片应用淡入转场效果。
```csharp
static void Add_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 应用淡入转场
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```


## **访问幻灯片转场**

读取当前分配给幻灯片的转场类型。
```csharp
static void Access_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Push;

    // 访问转场类型
    var type = slide.SlideShowTransition.Type;
}
```


## **移除幻灯片转场**

通过将类型设置为 `None` 来清除所有转场效果。
```csharp
static void Remove_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Fade;

    // 通过设置 None 移除转场
    slide.SlideShowTransition.Type = TransitionType.None;
}
```


## **设置转场持续时间**

指定在自动切换前幻灯片显示的时长。
```csharp
static void Set_Transition_Duration()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // 以毫秒为单位
}
```
