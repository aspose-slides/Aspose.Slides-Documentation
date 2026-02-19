---
title: 布局幻灯片
type: docs
weight: 20
url: /zh/cpp/examples/elements/layout-slide/
keywords:
- 代码示例
- 布局幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中掌握布局幻灯片：选择、应用和自定义幻灯片布局、占位符和母版，提供针对 PPT、PPTX 和 ODP 演示文稿的 C++ 示例。"
---
本文演示如何在 Aspose.Slides for C++ 中使用 **Layout Slides**。布局幻灯片定义了普通幻灯片继承的设计和格式。您可以添加、访问、克隆和删除布局幻灯片，还可以清理未使用的布局幻灯片以减小演示文稿的大小。

## **添加布局幻灯片**

您可以创建自定义布局幻灯片以定义可重用的格式。例如，您可以添加一个在使用此布局的所有幻灯片上显示的文本框。

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // 创建具有空白布局类型和自定义名称的布局幻灯片。
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // 向布局幻灯片添加文本框。
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // 使用此布局添加两个幻灯片；两者都将继承布局中的文本。
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1:** 布局幻灯片充当各个幻灯片的模板。您可以一次定义通用元素，并在多个幻灯片中重复使用。  
> 💡 **Note 2:** 当您向布局幻灯片添加形状或文本时，基于该布局的所有幻灯片将自动显示这些共享内容。  
> 下面的截图显示了两张幻灯片，它们各自从同一布局幻灯片继承了文本框。

![Slides Inheriting Layout Content](layout-slide-result.png)

## **访问布局幻灯片**

布局幻灯片可以通过索引或布局类型（例如 `Blank`、`Title`、`SectionHeader` 等）进行访问。

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 通过索引访问布局幻灯片。
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // 通过类型访问布局幻灯片。
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **删除布局幻灯片**

如果不再需要，您可以删除特定的布局幻灯片。

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 通过类型获取布局幻灯片并将其删除。
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **删除未使用的布局幻灯片**

为减小演示文稿的大小，您可能想要删除未被任何普通幻灯片使用的布局幻灯片。

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // 自动删除所有未被任何幻灯片引用的布局幻灯片。
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **克隆布局幻灯片**

您可以使用 `AddClone` 方法复制布局幻灯片。

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // 获取现有的布局幻灯片（按类型）。
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // 将布局幻灯片克隆到布局幻灯片集合的末尾。
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Summary:** 布局幻灯片是管理幻灯片之间一致格式的强大工具。Aspose.Slides 提供了对创建、管理和优化布局幻灯片的完整控制。