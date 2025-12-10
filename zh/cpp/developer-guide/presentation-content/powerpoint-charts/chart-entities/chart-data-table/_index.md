---
title: 使用 С++ 在演示文稿中自定义图表数据表
linktitle: 数据表
type: docs
url: /zh/cpp/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- С++
- Aspose.Slides
description: "使用 С++ 在 PPT 和 PPTX 中通过 Aspose.Slides 定制图表数据表，以提升演示文稿的效率和吸引力。"
---

## **设置图表数据表的字体属性**
Aspose.Slides for C++ 允许更改图表数据表的字体属性。

1. 实例化 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表表格。
1. 设置字体高度。
1. 保存修改后的演示文稿。

下面给出示例代码。  
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

是的。数据表支持[图例键](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datatable/set_showlegendkey/)，您可以打开或关闭它们。

**在将演示文稿导出为 PDF、HTML 或图像时，数据表会被保留吗？**

是的。Aspose.Slides 将图表渲染为幻灯片的一部分，因此导出的[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/zh/cpp/convert-powerpoint-to-html/)/[image](/slides/zh/cpp/convert-powerpoint-to-png/) 包含带数据表的图表。

**模板文件中的图表是否支持数据表？**

是的。对于任何从现有演示文稿或模板加载的图表，您可以使用图表的属性检查并更改数据表是否[显示](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/set_hasdatatable/)。

**我如何快速找出文件中哪些图表启用了数据表？**

检查每个图表的属性以判断数据表是否[显示](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_hasdatatable/)，并遍历幻灯片以识别已启用数据表的图表。