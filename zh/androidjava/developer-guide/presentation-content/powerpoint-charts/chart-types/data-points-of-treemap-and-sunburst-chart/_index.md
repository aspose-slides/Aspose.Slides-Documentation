---
title: 在 Android 上自定义 Treemap 和 Sunburst 图表的数据点
linktitle: Treemap 和 Sunburst 图表的数据点
type: docs
url: /zh/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap 图表
- sunburst 图表
- 分层图表
- 数据点
- 数据标签
- 分支颜色
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 创建层级数据并自定义 Treemap 和 Sunburst 图表的层级、标签和颜色。"
---
## **概述**

Treemap 和 Sunburst 图表显示相同类型的层级数据，但它们使用不同的布局。Treemap 将层级绘制为嵌套矩形，矩形面积代表叶子值。Sunburst 则以同心环的形式绘制：顶层组位于中心附近，叶子类别位于外环。

在 Aspose.Slides for Android via Java 中，每个数值都是一个 [IChartDataPoint](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapoint/)。其 [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) 方法提供对叶子及其父级组的访问。本文解释了该映射，并展示如何使用相同的示例数据创建和格式化这两种图表类型。

![带有 Consumer 和 Business 分支的 Treemap 图表](treemap-hierarchy.png)

![带有相同 Consumer 和 Business 层级的 Sunburst 图表](sunburst-hierarchy.png)

## **了解类别、数据点和层级**

下面使用的示例包含三个类别层级和一个数值序列：

| 分支 | 主干 | 叶子 | 收入 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每行创建一个叶子类别和一个数据点。类别分组层级描述了从该叶子到其父级的路径。第一行的路径为 `Consumer > Computers > Laptops`。

[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) 返回的索引从叶子向上：

| `getDataPointLevels()` 索引 | 逻辑层级 | Treemap 表示 | Sunburst 表示 |
| ---: | --- | --- | --- |
| `0` | 叶子 | 值矩形 | 外环片段 |
| `1` | 主干 | 父矩形或标题 | 中环片段 |
| `2` | 分支 | 顶层矩形或标题 | 内环片段 |

此顺序对两种图表类型都相同，尽管它们的可视布局不同。父级片段由多个叶子共享。要格式化它，请使用该组中第一个数据点对应的层级。例如，`Consumer` 分支从 `Laptops` 点开始，而 `Software` 主干从 `Licenses` 点开始。保留对这些点的引用比使用诸如 `dataPoints.get_Item(0)` 或 `dataPoints.get_Item(6)` 的不明表达式更清晰也更安全。

## **创建并自定义两种图表类型**

以下完整示例在第一张幻灯片上创建 Treemap，在第二张幻灯片上创建 Sunburst。它构建层级，显示 `Tablets` 的值，对选定层级应用固定颜色，格式化分支标签，并保存演示文稿。

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // 添加叶子类别。当新组开始时才设置分组项；
        // 后续的类别保持在该组中，直到设置另一个项。
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // 在 Tablets 叶子上显示类别和数值。
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // 通过该分支的第一个叶子格式化 Consumer 分支。
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // 通过该主干的第一个叶子格式化 Software 主干。
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout 影响 Treemap 的父标签；Sunburst 使用环段。
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

类别单元格和值单元格使用同一工作表行，因此它们的集合位置保持对齐。当你处理已有图表而不是创建新图表时，请先检查类别行，并存储要格式化的数据点和层级的命名引用。

## **行为与实际考虑**

### **Treemap 和 Sunburst 的差异**

- Treemap 使用面积传达数值，使用嵌套矩形传达层级。[IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) 方法控制父标签在此图表类型中的显示方式。  
- Sunburst 使用角度传达数值，使用环深度传达层级。[IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) 并不控制其环标签。  
- 两种图表类型使用相同的类别分组层级和相同的叶子到父级顺序（由 [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) 返回），因此数据构建和层级格式化代码可以共享。  
- 父级值由其后代叶子计算得出。不要为分支或主干单独添加数值点。

### **排序和片段顺序**

图表布局引擎决定矩形和环片段的最终位置。添加之前请将相关的类别行放在一起，但不要依赖特定的矩形位置或起始角度。如果顺序本身具有意义，请将其包含在标签中，或使用带显式类别轴的图表类型。

### **主题与固定颜色**

未格式化的图表层级会从演示文稿主题继承颜色。示例使用显式 RGB 填充以获得可预测的输出。如果图表应随主题变化，请使用方案颜色而非固定 RGB 值，并避免覆盖每个层级。更改分支或主干填充后，还需检查标签的对比度。

### **标签与可用空间**

当片段太小时，PowerPoint 可能会隐藏或截断标签。增大图表尺寸、缩短类别名称或显示更少的标签字段通常能得到更清晰的结果。标签可以通过 [IDataLabelFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatalabelformat/) 将类别名称、序列名称和数值组合在一起，但启用所有字段往往会使层级图表难以阅读。

### **导出与渲染**

保存为 PPTX 可保持图表可编辑。Aspose.Slides 将演示文稿渲染为 PDF 或图像时，支持的填充和标签设置会随图表一起渲染。字体替换以及可用布局空间的细微差异可能导致换行或标签可见性变化，请确保已安装所需字体并验证重要的导出目标。

## **常见问题解答**

**为什么修改父级层会影响多个叶子？**

分支或主干是共享的可视片段。其 [IChartDataPointLevel](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatapointlevel/) 可以通过后代叶子访问，但格式属于共享的父片段，而不仅仅是该叶子本身。

**为什么数据标签缺失？**

首先在标签的 [IDataLabelFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatalabelformat/) 对象上启用所需字段。然后检查片段是否有足够空间。Treemap 父标签布局、图表尺寸、标签长度、字体大小以及启用的字段数量都会影响标签是否能够显示。

**我能设置片段的精确顺序或坐标吗？**

可以控制源行的顺序并保持每组连续，但不能为 Treemap 矩形或 Sunburst 角度指定精确坐标。图表布局引擎根据层级、数值和可用空间计算这些位置。

**为什么主题变化后颜色会改变？**

基于主题的填充设计为跟随演示文稿调色板。对必须保持固定的层级使用显式 RGB 颜色，或在需要适配新主题时保留方案颜色。

**自定义格式在 PDF 和图像导出时会保留吗？**

会的，受支持的图表填充和标签设置在渲染时会被包含。为获得跨系统的一致结果，请提供所需字体并测试最终导出尺寸，因为标签适配受布局影响。

## **参见**

- [创建 Treemap 图表](/slides/zh/androidjava/create-chart/#create-tree-map-charts)
- [创建 Sunburst 图表](/slides/zh/androidjava/create-chart/#create-sunburst-charts)
- [导出演示文稿图表](/slides/zh/androidjava/export-chart/)
- [管理演示文稿主题](/slides/zh/androidjava/presentation-theme/)