---
title: 从 C++ 演示文稿获取段落边界
linktitle: 段落
type: docs
weight: 60
url: /zh/cpp/paragraph/
keywords:
- 段落边界
- 文本片段边界
- 段落坐标
- 片段坐标
- 段落大小
- 文本片段大小
- 文本框
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中检索段落和文本片段的边界，以优化 PowerPoint 演示文稿中的文本定位。"
---

## **获取 TextFrame 中段落和文本片段的坐标**
使用 Aspose.Slides for C++，开发人员现在可以获取 TextFrame 中段落集合内段落的矩形坐标。它还允许获取段落中文本片段集合内片段的坐标。在本主题中，我们将通过示例演示如何获取段落的矩形坐标以及段落内文本片段的位置。

## **获取段落的矩形坐标**
新增了 **GetRect()** 方法。它用于获取段落的边界矩形。
``` cpp
// 实例化一个表示演示文稿文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```


## **获取表格单元格 TextFrame 中段落和文本片段的大小**
要获取表格单元格 TextFrame 中[Portion](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)或[Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph)的大小和坐标，可使用[IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9)和[IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t)方法。

以下示例代码演示了上述操作：
``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```


## **常见问题**

**段落和文本片段的坐标以什么单位返回？**

以点（points）为单位，1 英寸 = 72 点。此单位适用于幻灯片上的所有坐标和尺寸。

**自动换行会影响段落的边界吗？**

会。如果在[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/)中启用了[wrapping](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/)，文本会根据区域宽度换行，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

可以。使用公式：pixels = points × (DPI / 72)。结果取决于渲染/导出时选择的 DPI。

**如何获取“有效”的段落格式参数，以考虑样式继承？**

使用[effective paragraph formatting data structure](/slides/zh/cpp/shape-effective-properties/)，它返回缩进、间距、换行、RTL 等属性的最终合并值。