---
title: 获取 C++ 演示文稿中的段落边界
linktitle: 段落边界
type: docs
weight: 43
url: /zh/cpp/paragraph-bounds/
keywords:
- 段落边界
- 段落坐标
- 段落大小
- 文本框
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中检索段落边界，以优化 PowerPoint 演示文稿中的文本定位。"
---
## **概述**

本文说明了如何获取 Aspose.Slides 中段落的边界、大小和坐标。它展示了如何通过使用 [IParagraph::GetRect](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/getrect/) 从 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 中检索段落矩形，如何获取表格单元格文本框内段落的坐标，并强调了测量单位、换行对边界的影响、像素转换以及有效段落格式化值等重要细节。

## **获取段落的矩形坐标**

使用 [IParagraph::GetRect](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/getrect/) 获取段落的边界矩形。

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **获取表格单元格 TextFrame 中段落的大小**

要获取表格单元格文本框中 [IParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/) 的大小和坐标，请使用 [IParagraph::GetRect](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/getrect/)。返回的矩形相对于表格单元格文本框，因此在需要幻灯片级别坐标时，需要加上表格位置和单元格偏移。

下面的示例获取表格单元格内段落的边界，并在幻灯片上绘制矩形以可视化这些边界：

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**段落坐标使用什么单位测量？**

采用点（point）作为单位，1 英寸等于 72 点。该单位适用于幻灯片上的所有坐标和尺寸。

**自动换行会影响段落的边界吗？**

会。若为 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 启用了 [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/set_wraptext/)，文本会根据区域宽度换行，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

可以。使用公式将点转换为像素：pixels = points × (DPI / 72)。结果取决于渲染或导出时选择的 DPI。

**如何获取“有效”的段落格式化参数，以考虑样式继承？**

使用 [effective paragraph formatting data structure](/slides/zh/cpp/shape-effective-properties/)；它返回缩进、间距、换行、RTL 等参数的最终合并值。