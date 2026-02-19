---
title: 图表
type: docs
weight: 60
url: /zh/cpp/examples/elements/chart/
keywords:
- 代码示例
- 图表
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 掌握图表：创建、格式化、绑定数据，并使用 C++ 示例将图表导出为 PPT、PPTX 和 ODP。"
---
以下示例展示了使用 **Aspose.Slides for C++** 添加、访问、删除和更新不同图表类型的操作。下面的代码片段演示了基本的图表操作。

## **添加图表**

此方法在第一张幻灯片中添加一个简单的面积图。

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 向第一张幻灯片添加一个简单的面积图。
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **访问图表**

创建图表后，您可以通过形状集合检索它。

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // 访问幻灯片上的第一个图表。
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **删除图表**

以下代码用于从幻灯片中删除图表。

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // 移除图表。
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **更新图表数据**

您可以更改图表属性，例如标题。

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // 更改图表标题。
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```