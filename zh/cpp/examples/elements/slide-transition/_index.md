---
title: 幻灯片切换
type: docs
weight: 110
url: /zh/cpp/examples/elements/slide-transition/
keywords:
- 代码示例
- 幻灯片切换
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中掌握幻灯片切换：使用 C++ 示例为 PPT、PPTX 和 ODP 演示文稿添加、定制和排序效果及持续时间。"
---
本文演示了如何使用 **Aspose.Slides for C++** 应用幻灯片切换效果和时间设置。

## **添加幻灯片切换**

对第一张幻灯片应用淡入切换效果。

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // 应用淡入切换。
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **访问幻灯片切换**

读取当前分配给幻灯片的切换类型。

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // 访问切换类型。
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **删除幻灯片切换**

通过将类型设置为 `None` 来清除任何切换效果。

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // 通过设置为 None 移除切换。
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **设置切换持续时间**

指定幻灯片在自动前进前显示的时间长度。

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // 毫秒。

    presentation->Dispose();
}
```