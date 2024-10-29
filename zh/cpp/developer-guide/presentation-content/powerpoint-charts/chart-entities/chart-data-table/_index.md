---
title: 图表数据表
type: docs
url: /zh/cpp/chart-data-table/
---

## **为图表数据表设置字体属性**
Aspose.Slides for C++ 允许更改图表数据表的字体属性。

1. 实例化 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表表格。
1. 设置字体高度。
1. 保存修改后的演示文稿。

下面给出了示例代码。

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```