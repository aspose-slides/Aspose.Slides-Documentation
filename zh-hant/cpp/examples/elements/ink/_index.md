---
title: 墨跡
type: docs
weight: 180
url: /zh-hant/cpp/examples/elements/ink/
keywords:
- 程式碼範例
- 墨跡
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中使用墨跡：繪製、匯入與編輯筆畫，調整顏色與寬度，並使用 C++ 範例匯出為 PPT、PPTX 與 ODP。"
---
本文提供了使用 **Aspose.Slides for C++** 存取現有墨跡圖形並將其移除的範例。

> ❗ **注意:** 墨跡圖形代表來自專用裝置的使用者輸入。Aspose.Slides 無法以程式方式建立新的墨跡筆畫，但您可以讀取並修改現有的墨跡。

## **存取墨跡**

讀取投影片上第一個墨跡圖形的標籤。

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // 根據需要使用 tagName。
        }
    }

    presentation->Dispose();
}
```

## **移除墨跡**

如果投影片中存在墨跡圖形，將其刪除。

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```