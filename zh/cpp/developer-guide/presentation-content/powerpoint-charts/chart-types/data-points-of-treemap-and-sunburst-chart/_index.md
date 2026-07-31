---
title: 使用 C++ 自定义 Treemap 和 Sunburst 图表中的数据点
linktitle: Treemap 和 Sunburst 图表中的数据点
type: docs
url: /zh/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap 图表
- sunburst 图表
- 数据点
- 标签颜色
- 分支颜色
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 管理 treemap 和 sunburst 图表中的数据点，兼容 PowerPoint 格式。"
---
## **介绍**

在 PowerPoint 的其他图表类型中，有两种“层次”类型——**Treemap** 和 **Sunburst** 图表（也称为 Sunburst 图、Sunburst 图示、径向图、径向图表或多层饼图）。这些图表显示以树形结构组织的层次数据——从叶子到分支的顶部。叶子由系列数据点定义，每个后续的嵌套分组级别由相应的类别定义。Aspose.Slides for C++ 允许在 C++ 中格式化 Sunburst 图表和 Treemap 的数据点。

下面是一个 Sunburst 图表，其中 Series1 列中的数据定义了叶子节点，而其他列定义了层次数据点：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

让我们从向演示文稿添加一个新的 Sunburst 图表开始：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="另见" %}} 
- [**创建 Sunburst 图表**](/slides/zh/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

如果需要对图表的数据点进行格式化，应使用以下内容：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)、[**IChartDataPointLevel**](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapointlevel/)类和[**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/)方法提供了对 Treemap 和 Sunburst 图表的数据点进行格式化的访问。

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) 用于访问多级类别——它表示 [**IChartDataPointLevel**](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapointlevel/) 对象的容器。  
本质上它是对 [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) 的包装，并添加了专用于数据点的属性。  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapointlevel/) 类有两个方法： [**get_Format()**](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) 和 [**get_Label()**](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/)，它们提供对相应设置的访问。

## **显示数据点的值**
显示 “Leaf 4” 数据点的值：

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **设置数据点标签和颜色**
将 “Branch 1” 数据标签设置为显示系列名称 (“Series1”) 而不是类别名称。然后将文本颜色设置为黄色：

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **设置数据点分支颜色**
更改 “Stem 4” 分支的颜色：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **常见问题**

**我可以更改 Sunburst/Treemap 中段的顺序（排序）吗？**  
不能。PowerPoint 会自动对段进行排序（通常按值降序、顺时针）。Aspose.Slides 复制了此行为：无法直接更改顺序；只能通过预处理数据来实现。

**演示文稿的主题如何影响段和标签的颜色？**  
图表颜色会继承演示文稿的[主题/调色板](/slides/zh/cpp/presentation-theme/)，除非您显式设置填充/字体。为获得一致的效果，请在必要的层级上锁定纯色填充和文本格式。

**导出为 PDF/PNG 时会保留自定义分支颜色和标签设置吗？**  
会。导出演示文稿时，图表的设置（填充、标签）会在输出格式中保留，因为 Aspose.Slides 会按图表的格式进行渲染。

**我可以计算标签/元素的实际坐标，以在图表上方放置自定义覆盖层吗？**  
可以。图表布局验证后，元素（例如 [DataLabel](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/datalabel/)）的实际 X 和实际 Y 坐标可用，这有助于精确定位覆盖层。