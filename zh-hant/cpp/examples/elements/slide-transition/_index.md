---
title: 投影片轉場
type: docs
weight: 110
url: /zh-hant/cpp/examples/elements/slide-transition/
keywords:
- 程式碼範例
- 投影片轉場
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "精通 Aspose.Slides for C++ 中的投影片轉場：使用 C++ 範例為 PPT、PPTX 與 ODP 簡報新增、客製化及排序效果與持續時間。"
---
本文示範如何使用 **Aspose.Slides for C++** 套用投影片轉場效果與時間設定。

## **新增投影片轉場**

對第一張投影片套用淡入轉場效果。

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // 套用淡入轉場。
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **取得投影片轉場**

讀取投影片目前指定的轉場類型。

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // 存取轉場類型。
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **移除投影片轉場**

將類型設為 `None` 以清除所有轉場效果。

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // 透過設定為 None 來移除轉場。
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **設定轉場持續時間**

指定投影片在自動前進前顯示的時間長度。

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // 以毫秒為單位。

    presentation->Dispose();
}
```