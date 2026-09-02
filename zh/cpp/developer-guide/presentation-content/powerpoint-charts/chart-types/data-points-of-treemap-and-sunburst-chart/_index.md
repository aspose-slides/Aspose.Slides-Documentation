---
title: 自定义 C++ 中矩形树图和旭日图的数据点
linktitle: 矩形树图和旭日图的数据点
type: docs
url: /zh/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- 矩形树图
- 旭日图
- 层次结构图
- 数据点
- 数据标签
- 分支颜色
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 创建层次数据并自定义矩形树图和旭日图中的层级、标签和颜色。"
---
## **概述**

矩形树图和旭日图显示相同类型的层次数据，但它们使用不同的布局。矩形树图将层次结构绘制为嵌套矩形，其面积表示叶子值。旭日图将其绘制为同心环：顶层组位于中心附近，叶子类别位于外环。

在 Aspose.Slides for C++中，每个数值都是[IChartDataPoint](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapoint/)。其[IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/)方法提供对叶子及其父组的访问。本文解释了该映射并展示如何使用相同的示例数据创建和格式化这两种图表类型。

![带有 Consumer 和 Business 分支的矩形树图](treemap-hierarchy.png)

![带有相同 Consumer 和 Business 层次的旭日图](sunburst-hierarchy.png)

## **了解类别、数据点和层级**

下面使用的示例包含三个类别层级和一个数值序列：

| 分支 | 干线 | 叶子 | 收入 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每行创建一个叶子类别和一个数据点。类别分组层级描述从该叶子到其父级的路径。第一行的路径为 `Consumer > Computers > Laptops`。

[IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/)返回的索引从叶子向上：

| `get_DataPointLevels()` 索引 | 逻辑层级 | 矩形树图表示 | 旭日图表示 |
| ---: | --- | --- | --- |
| `0` | 叶子 | 值矩形 | 外环段 |
| `1` | 干线 | 父矩形或标题 | 中环段 |
| `2` | 分支 | 顶层矩形或标题 | 内环段 |

这种顺序对两种图表类型都相同，尽管它们的可视布局不同。父段由多个叶子共享。要对其进行格式化，请使用该组中第一个数据点对应的层级。例如，`Consumer` 分支从 `Laptops` 点开始，而 `Software` 干线从 `Licenses` 点开始。保留这些点的引用比使用未说明的表达式如 `dataPoints->idx_get(0)` 或 `dataPoints->idx_get(6)` 更清晰也更安全。

## **创建并自定义两种图表类型**

以下完整示例在第一页创建矩形树图，在第二页创建旭日图。它构建层次结构，显示 `Tablets` 的值，对选定层级使用固定颜色，格式化分支标签，并保存演示文稿。

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // 添加叶子类别。仅在新组开始时设置分组项；
    // 随后的类别保持在该组中，直到设置另一个项。
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // 在 Tablets 叶子上显示类别和数值。
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // 通过该分支的第一个叶子对 Consumer 分支进行格式化。
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // 通过该干线的第一个叶子对 Software 干线进行格式化。
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout 影响矩形树图的父标签；旭日图使用环段。
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

类别单元格和数值单元格使用相同的工作表行，因此它们的集合位置保持对齐。当您使用已有图表而不是创建新图表时，首先检查类别行并存储要格式化的数据点和层级的命名引用。

## **行为和实际注意事项**

### **矩形树图和旭日图的差异**

- 矩形树图使用面积传达数值，使用嵌套矩形传达层次结构。`[IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/)` 方法控制此图表类型中父标签的显示方式。
- 旭日图使用角度传达数值，使用环深度传达层次结构。`[IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/)` 不控制其环标签。
- 两种图表使用相同的类别分组层级和相同的叶子到父级顺序（由`[IChartDataPoint::get_DataPointLevels()]`返回），因此数据构建和层级格式化代码可以共享。
- 父值由其后代叶子计算得出。不要为分支或干线单独添加数值点。

### **排序和段顺序**

图表布局引擎决定矩形和环段的最终位置。将相关的类别行放在一起再添加，但不要依赖特定的矩形位置或起始角度。如果顺序本身有意义，请将其包含在标签中或使用带显式类别轴的图表类型。

### **主题和固定颜色**

未格式化的图表层级会从演示文稿主题继承颜色。示例使用显式的 RGB 填充以获得可预测的输出。如果图表应随主题变化，请使用配色方案颜色而不是固定的 RGB 值，并避免对每个层级都进行覆盖。更改分支或干线填充后，还需检查标签对比度。

### **标签和可用空间**

当段太小时，PowerPoint 可能会隐藏或截断标签。增大图表尺寸、缩短类别名称或显示更少的标签字段通常能得到更清晰的结果。标签可以通过 `[IDataLabelFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/idatalabelformat/)` 将类别名、系列名和数值组合在一起，但启用所有字段往往会使层次图表难以阅读。

### **导出和渲染**

保存为 PPTX 能保留图表的可编辑性。当 Aspose.Slides 将演示文稿渲染为 PDF 或图像时，支持的填充和标签设置会随图表一起渲染。字体替换以及可用布局空间的细微差异可能导致换行或标签可见性变化，因此请安装所需字体并验证重要的导出目标。

## **常见问题**

**为什么更改父层级会影响多个叶子？**  
分支或干线是共享的可视段。它的 `[IChartDataPointLevel](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatapointlevel/)` 可以通过后代叶子访问，但格式化属于共享的父段，而不是仅属于该叶子。

**为什么缺少数据标签？**  
首先在标签的 `[IDataLabelFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/idatalabelformat/)` 对象上启用所需字段。然后检查该段是否有足够空间。矩形树图的父标签布局、图表尺寸、标签长度、字体大小以及启用字段的数量都会影响标签是否能够显示。

**我可以设置段的精确顺序或坐标吗？**  
可以控制源行的顺序并保持每个组连续，但不能为矩形树图矩形或旭日图角度指定精确值。图表布局引擎会根据层次结构、数值和可用空间计算它们。

**为什么在更改演示文稿主题后颜色会变化？**  
基于主题的填充设计为跟随演示文稿调色板。对必须保持不变的层级使用显式的 RGB 颜色，或在适应新主题时使用配色方案颜色。

**自定义格式会在 PDF 和图像导出中保留吗？**  
会，支持的图表填充和标签设置在渲染时会被包含。为获得跨系统的一致结果，请提供所需字体并测试最终导出尺寸，因为标签适配受布局影响。

## **参见其他内容**

- [Create Treemap charts](/slides/zh/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/zh/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/zh/cpp/export-chart/)
- [Manage presentation themes](/slides/zh/cpp/presentation-theme/)