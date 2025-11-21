---
title: 幻灯片过渡
type: docs
weight: 110
url: /zh/net/examples/elements/slide-transition/
keywords:
- 幻灯片过渡示例
- 添加幻灯片过渡
- 访问幻灯片过渡
- 移除幻灯片过渡
- 过渡持续时间
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中控制幻灯片过渡：选择类型、速度、声音和时间，以完善 PPT、PPTX 和 ODP 演示文稿。"
---

演示了在 **Aspose.Slides for .NET** 中应用幻灯片过渡效果和时序。

## 添加幻灯片过渡

对第一张幻灯片应用淡入过渡效果。
```csharp
static void Add_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 应用淡入过渡
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```


## 访问幻灯片过渡

读取当前分配给幻灯片的过渡类型。
```csharp
static void Access_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Push;

    // 访问过渡类型
    var type = slide.SlideShowTransition.Type;
}
```


## 移除幻灯片过渡

通过将类型设置为 `None` 来清除所有过渡效果。
```csharp
static void Remove_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Fade;

    // 通过将类型设置为 None 删除过渡
    slide.SlideShowTransition.Type = TransitionType.None;
}
```


## 设置过渡持续时间

指定幻灯片在自动前进之前的显示时长。
```csharp
static void Set_Transition_Duration()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // 以毫秒为单位
}
```
