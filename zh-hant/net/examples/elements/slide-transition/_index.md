---
title: 投影片轉場
type: docs
weight: 110
url: /zh-hant/net/examples/elements/slide-transition/
keywords:
- 投影片轉場
- 新增投影片轉場
- 存取投影片轉場
- 移除投影片轉場
- 轉場持續時間
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中掌握投影片轉場：使用 C# 範例為 PPT、PPTX 與 ODP 簡報新增、客製化及排序效果與持續時間。"
---
本文說明如何在 **Aspose.Slides for .NET** 中套用投影片轉場效果與計時。

## **新增投影片轉場**

為第一張投影片套用淡入淡出轉場效果。

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 套用淡入淡出轉場.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **存取投影片轉場**

讀取目前指派給投影片的轉場類型。

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // 存取轉場類型。
    var type = slide.SlideShowTransition.Type;
}
```

## **移除投影片轉場**

將類型設定為 `None` 以清除所有轉場效果。

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // 透過設定為 None 來移除轉場。
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **設定轉場持續時間**

指定投影片在自動前進前顯示的時間長度。

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // 以毫秒為單位
}
```