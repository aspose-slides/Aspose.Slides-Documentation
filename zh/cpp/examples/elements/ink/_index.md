---
title: 墨迹
type: docs
weight: 180
url: /zh/cpp/examples/elements/ink/
keywords:
- 代码示例
- 墨迹
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中使用墨迹：绘制、导入和编辑笔画，调整颜色和宽度，并使用 C++ 示例将其导出为 PPT、PPTX 和 ODP。"
---
本文提供了使用 **Aspose.Slides for C++** 访问现有墨迹形状并将其删除的示例。

> ❗ **注意：** 墨迹形状表示来自专用设备的用户输入。Aspose.Slides 无法以编程方式创建新的墨迹笔画，但您可以读取并修改现有的墨迹。

## **访问墨迹**

读取幻灯片上第一个墨迹形状的标签。

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
            // 根据需要使用 tagName。
        }
    }

    presentation->Dispose();
}
```

## **删除墨迹**

如果幻灯片中存在墨迹形状，则将其删除。

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