---
title: 使用 C++ 自定义演示文稿中的图表数据表
linktitle: 数据表
type: docs
url: /zh/cpp/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中自定义 PPT 和 PPTX 的图表数据表，以提升演示效率和吸引力。"
---
## **概览**

本文说明了如何在 Aspose.Slides 中使用图表数据表。它展示了如何为图表显示数据表并通过设置诸如粗体样式和字体高度等字体属性来自定义文本格式。示例演示了加载演示文稿、添加图表、启用图表数据表、应用字体设置以及保存更新后的演示文稿。

## **设置图表数据表的字体属性**
Aspose.Slides for C++ 允许更改图表数据表的字体属性。

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表数据表。
1. 设置字体高度。
1. 保存修改后的演示文稿。

下面给出示例。

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **常见问题**

**我可以在图表数据表的数值旁显示小的图例键吗？**

是的。数据表支持 [legend keys](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/datatable/set_showlegendkey/)，您可以打开或关闭它们。

**将演示文稿导出为 PDF、HTML 或图像时，数据表会被保留吗？**

是的。Aspose.Slides 将图表渲染为幻灯片的一部分，因此导出的 [PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/zh/cpp/convert-powerpoint-to-html/)/[image](/slides/zh/cpp/convert-powerpoint-to-png/) 包含带有数据表的图表。

**模板文件中的图表是否支持数据表？**

是的。对于从现有演示文稿或模板加载的任何图表，您可以使用图表的属性检查并更改数据表是否[显示](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chart/set_hasdatatable/)。

**我如何快速查找文件中哪些图表启用了数据表？**

检查每个图表的属性以确定数据表是否[显示](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chart/get_hasdatatable/)，并遍历幻灯片以识别启用了该功能的图表。