---
title: 在 C++ 中从演示文稿获取文本片段边界
linktitle: 片段边界
type: docs
weight: 47
url: /zh/cpp/portion-bounds/
keywords:
- 文本片段边界
- 文本片段
- 文本部分
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中检索文本片段边界。"
---
## **概述**

文本片段表示段落内的特定文字片段，并允许您独立于周围内容对该片段进行操作。在 Aspose.Slides 中，当您需要获取文本片段的边界、仅对段落的一部分应用格式，或在更细粒度上控制文本行为时，可以使用片段。

本文展示了如何使用 [IPortion::GetRect](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/getrect/) 获取片段的边界矩形。它还展示了如何使用 [IPortion::GetCoordinates](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/getcoordinates/) 获取片段起始位置的坐标。此外，还重点介绍了常见的片段相关场景，例如为单个文本片段添加超链接、了解格式如何通过片段、段落、文本框和主题继承进行解析，以及处理指定字体不可用的情况。

## **获取文本片段的边界**

使用 [IPortion::GetRect](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/getrect/) 检索文本片段的边界矩形：

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **获取文本片段的坐标**

使用 [IPortion::GetCoordinates](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/getcoordinates/) 检索文本片段起始位置的坐标：

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **常见问题**

**我可以仅对单段落中的部分文本应用超链接吗？**

是的，您可以[分配超链接](/slides/zh/cpp/manage-hyperlinks/)给单个片段；仅该片段可点击，而不是整段。

**样式继承是如何工作的：片段会覆盖哪些属性，哪些属性来自段落或文本框？**

片段级属性具有最高优先级。如果在 [IPortion](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/) 上未设置属性，Aspose.Slides 会从 [IParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/) 获取。如果仍未设置，则使用 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 或 [theme](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/theme/) 的样式。

**如果片段指定的字体在目标机器或服务器上缺失会怎样？**

[字体替换规则](/slides/zh/cpp/font-selection-sequence/) 会生效。文本可能会重新排版：度量、连字符和宽度可能会变化，这对精确定位很重要。

**我可以为片段单独设置文本填充透明度或渐变，而不影响段落的其他部分吗？**

是的，在 [IPortion](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/) 级别的文本颜色、填充和透明度可以与相邻片段不同。