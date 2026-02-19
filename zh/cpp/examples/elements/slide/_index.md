---
title: 幻灯片
type: docs
weight: 10
url: /zh/cpp/examples/elements/slide/
keywords:
- 代码示例
- 幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中控制幻灯片：创建、克隆、重新排序、调整大小、设置背景，并对 PPT、PPTX 和 ODP 演示文稿应用过渡效果。"
---
本文提供了一系列示例，演示如何使用 **Aspose.Slides for C++** 处理幻灯片。您将学习如何使用 `Presentation` 类添加、访问、克隆、重新排序和删除幻灯片。

下列每个示例均包含简要说明以及对应的 C++ 代码片段。

## **添加幻灯片**

要添加新幻灯片，首先需要选择一个布局。本例使用 `Blank` 布局，并向演示文稿添加一个空白幻灯片。

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡**注意:** 每个幻灯片布局都来源于母版幻灯片，母版定义了整体设计和占位符结构。下图展示了 PowerPoint 中母版幻灯片及其关联布局的组织方式。

![母版和布局关系](master-layout-slide.png)

## **按索引访问幻灯片**

您可以通过索引访问幻灯片，或根据引用查找幻灯片的索引。这对于遍历或修改特定幻灯片非常有用。

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 添加另一个空白幻灯片。
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // 按索引访问幻灯片。
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // 从引用获取幻灯片索引，然后按索引访问。
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **克隆幻灯片**

本示例演示如何克隆现有幻灯片。克隆后的幻灯片会自动添加到幻灯片集合的末尾。

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **重新排序幻灯片**

您可以通过将幻灯片移动到新索引来更改其顺序。在本例中，我们将克隆的幻灯片移动到第一位置。

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **删除幻灯片**

要删除幻灯片，只需引用它并调用 `Remove`。本示例先添加第二张幻灯片，然后删除原始幻灯片，最终仅保留新添加的那张。

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```