---
title: .NET 中树形图和日晷图数据点自定义
linktitle: 树形图和日晷图数据点
type: docs
url: /zh/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- 树形图
- 日晷图
- 层次图
- 数据点
- 数据标签
- 分支颜色
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 创建层次数据并自定义树形图和日晷图中的层级、标签和颜色。"
---
## **概述**

树形图（Treemap）和日晷图（Sunburst）显示相同类型的层次数据，但采用不同的布局。树形图将层次绘制为嵌套矩形，矩形面积代表叶子节点的数值。日晷图则以同心环的形式展示：顶层组位于中心，叶子类别位于外环。

在 Aspose.Slides for .NET 中，每个数值都是一个[IChartDataPoint](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/)。其[IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/datapointlevels/)集合提供对叶子及其父级组的访问。本文阐述了这种映射关系，并演示如何使用相同的示例数据创建和格式化这两种图表类型。

![带有 Consumer 和 Business 分支的树形图](treemap-hierarchy.png)

![带有相同 Consumer 和 Business 层次的日晷图](sunburst-hierarchy.png)

## **了解类别、数据点和层级**

下面使用的示例包含三个类别层级和一个数值序列：

| 分支 | 子干 | 叶子 | 收入 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每行创建一个叶子类别和一个数据点。类别分组层级描述了该叶子到其父级的路径。第一行的路径为 `Consumer > Computers > Laptops`。

[IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) 中的索引从叶子向上递增：

| `DataPointLevels` 索引 | 逻辑层级 | 树形图表示 | 日晷图表示 |
| ---: | --- | --- | --- |
| `0` | Leaf | 值矩形 | 外环段 |
| `1` | Stem | 父矩形或标题 | 中环段 |
| `2` | Branch | 顶层矩形或标题 | 内环段 |

该顺序在两种图表中保持一致，尽管它们的可视布局不同。一个父级段会被多个叶子共享。要对其进行格式化，请使用该组中第一个数据点对应的层级。例如，`Consumer` 分支从 `Laptops` 点开始，而 `Software` 子干从 `Licenses` 点开始。保留这些点的引用比使用诸如 `dataPoints[0]` 或 `dataPoints[6]` 之类的未解释表达式更清晰、更安全。

## **创建并自定义两种图表类型**

下面的完整示例在第一张幻灯片上创建树形图，在第二张幻灯片上创建日晷图。它构建层次结构，显示 `Tablets` 的数值，对选定层级使用固定颜色，格式化分支标签，并保存演示文稿。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // 添加叶子类别。仅在新组开始时设置分组项；
    // 随后类别会保持在该组中，直到设置了另一个项。
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // 在 Tablets 叶子上显示类别和数值。
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // 通过该分支的第一个叶子来格式化 Consumer 分支。
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // 通过该干的第一个叶子来格式化 Software 子干。
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout 影响树形图的父标签；日晷图使用环段。
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

类别单元格和数值单元格使用相同的工作表行，因此它们的集合位置保持对齐。当您处理已有图表而非新建图表时，首先检查类别行并存储要格式化的数据点和层级的命名引用。

## **行为与实际注意事项**

### **树形图与日晷图的区别**

- 树形图使用面积来传达数值，使用嵌套矩形来传达层次结构。该图表类型的 [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/parentlabellayout/) 属性控制父标签的显示方式。
- 日晷图使用角度来传达数值，使用环的深度来传达层次结构。`IChartSeries.ParentLabelLayout` 不会控制其环标签。
- 两种图表使用相同的类别分组层级以及相同的叶子到父级的顺序（`DataPointLevels`），因此构建数据和层级格式化的代码可以共享。
- 父级数值是从其子叶子计算得出的。不要为分支或子干单独添加数值点。

### **排序与段顺序**

图表布局引擎决定矩形和环段的最终位置。将相关的类别行聚在一起后再添加它们，但不要依赖特定的矩形位置或起始角度。如果顺序具有含义，请在标签中包含该信息，或使用带有显式类别轴的图表类型。

### **主题与固定颜色**

未格式化的图表层级会继承演示文稿主题的颜色。示例使用显式的 RGB 填充以获得可预测的输出。如果希望图表随主题变化，请使用方案颜色而非固定 RGB 值，并避免对每个层级都进行覆盖。更改分支或子干填充后，还需检查标签的对比度。

### **标签与可用空间**

当段太小时，PowerPoint 可能会隐藏或截断标签。增大图表尺寸、缩短类别名称或显示更少的标签字段通常能得到更清晰的效果。标签可以通过[IDataLabelFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/idatalabelformat/) 将类别名称、系列名称和数值组合在一起，但启用所有字段往往会使层次图难以阅读。

### **导出与渲染**

保存为 PPTX 可保持图表可编辑。当 Aspose.Slides 将演示文稿渲染为 PDF 或图像时，支持的填充和标签设置会随图表一起渲染。字体替换以及可用布局空间的细微差异可能导致换行或标签可见性变化，因此请安装所需字体并验证关键的导出目标。

## **常见问题解答**

**更改父级层级为何会影响多个叶子？**

分支或子干是共享的可视段。其[IChartDataPointLevel](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapointlevel/)可以通过子叶子访问，但格式化属于共享的父段，而不仅仅属于该叶子。

**为什么缺少数据标签？**

首先在标签的[IDataLabelFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/idatalabelformat/)对象上启用所需字段。然后检查该段是否有足够空间。树形图的父标签布局、图表尺寸、标签长度、字体大小以及启用的字段数量都会影响标签是否能够显示。

**我能设置段的确切顺序或坐标吗？**

可以控制源行的顺序并保持每个组连续，但无法为树形图矩形或日晷角度指定精确坐标。图表布局引擎会根据层次结构、数值和可用空间计算它们。

**主题更改后颜色为何会变化？**

基于主题的填充设计为跟随演示文稿调色板。对必须保持不变的层级使用显式 RGB 颜色，或在需要适配新主题时保留方案颜色。

**自定义格式在 PDF 和图像导出时会被保留吗？**

会的，支持的图表填充和标签设置在渲染时会被包括。为获得跨系统一致的结果，请提供所需字体并测试最终导出尺寸，因为标签适配取决于布局。

## **参见**

- [创建树形图](/slides/zh/net/create-chart/#create-tree-map-charts)
- [创建日晷图](/slides/zh/net/create-chart/#create-sunburst-charts)
- [导出演示文稿图表](/slides/zh/net/export-chart/)
- [管理演示文稿主题](/slides/zh/net/presentation-theme/)