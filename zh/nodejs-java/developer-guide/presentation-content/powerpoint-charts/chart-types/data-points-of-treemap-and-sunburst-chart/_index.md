---
title: 使用 JavaScript 定制 Treemap 和 Sunburst 图表中的数据点
linktitle: Treemap 和 Sunburst 图表中的数据点
type: docs
url: /zh/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- 树状图表
- 旭日图表
- 层次结构图表
- 数据点
- 数据标签
- 分支颜色
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 创建层次数据并自定义 Treemap 和 Sunburst 图表中的层级、标签和颜色。"
---
## **概述**

Treemap 和 Sunburst 图表显示相同类型的层次结构数据，但它们使用不同的布局。Treemap 将层次结构绘制为嵌套矩形，矩形面积代表叶子值。Sunburst 将其绘制为同心环：顶层组位于中心附近，叶子类别位于外环。

在 Aspose.Slides for Node.js via Java 中，每个数值都是一个 [ChartDataPoint](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapoint/)。它的 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) 方法提供对叶子及其父级组的访问。本文解释了该映射，并展示了如何使用相同的示例数据创建和格式化这两种图表类型。

![带有“消费者”和“商务”分支的 Treemap 图表](treemap-hierarchy.png)

![具有相同“消费者”和“商务”层次结构的 Sunburst 图表](sunburst-hierarchy.png)

## **了解类别、数据点和层级**

下面使用的示例包含三个类别层级和一个数值序列：

| 分支 | 干 | 叶子 | 收入 |
| --- | --- | --- | ---: |
| 消费者 | 电脑 | 笔记本电脑 | 12 |
| 消费者 | 电脑 | 台式机 | 8 |
| 消费者 | 移动设备 | 手机 | 15 |
| 消费者 | 移动设备 | 平板电脑 | 6 |
| 商务 | 服务 | 咨询 | 10 |
| 商务 | 服务 | 支持 | 7 |
| 商务 | 软件 | 许可证 | 11 |
| 商务 | 软件 | 订阅 | 14 |

每行创建一个叶子类别和一个数据点。类别分组层级描述了从该叶子到其父级的路径。第一行的路径为 `消费者 > 电脑 > 笔记本电脑`。

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) 返回的索引从叶子向上：

| `getDataPointLevels()` 索引 | 逻辑层级 | Treemap 表示 | Sunburst 表示 |
| ---: | --- | --- | --- |
| `0` | 叶子 | 值矩形 | 外环段 |
| `1` | 干 | 父矩形或标题 | 中环段 |
| `2` | 分支 | 顶层矩形或标题 | 内环段 |

该顺序对两种图表类型都相同，尽管它们的视觉布局不同。父级段由多个叶子共享。要格式化它，请使用该组中第一个数据点对应的层级。例如，`消费者` 分支从 `笔记本电脑` 点开始，而 `软件` 干从 `许可证` 点开始。保留对这些点的引用比使用诸如 `dataPoints.get_Item(0)` 或 `dataPoints.get_Item(6)` 等不明确的表达式更清晰、更安全。

## **创建并自定义两种图表类型**

以下完整示例在第一张幻灯片上创建 Treemap，在第二张幻灯片上创建 Sunburst。它构建层次结构，显示 `平板电脑` 的数值，对选定层级应用固定颜色，格式化分支标签，并保存演示文稿。

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // 添加叶子类别。仅在新分组开始时设置分组项；
        // 随后类别保持在该分组中，直到设置另一项。
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // 在 Tablets 叶子上显示类别和数值。
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // 通过该分支的第一个叶子格式化 Consumer 分支。
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // 通过该干的第一个叶子格式化 Software 干。
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout 影响 Treemap 的父标签；Sunburst 使用环段。
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

类别单元格和值单元格使用相同的工作表行，因此它们的集合位置保持对齐。当您处理现有图表而不是创建新图表时，请先检查类别行，并存储要格式化的数据点和层级的命名引用。

## **行为和实际注意事项**

### **Treemap 和 Sunburst 的区别**

- Treemap 使用面积传达数值，使用嵌套矩形传达层次结构。此图表类型中的父标签显示方式由 [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) 方法控制。
- Sunburst 使用角度传达数值，使用环深度传达层次结构。[ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) 不控制其环标签。
- 两种图表类型使用相同的类别分组层级和相同的叶子到父级顺序，由 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) 返回，因此构建数据和层级格式化的代码可以共享。
- 父级数值通过其子叶子计算得出。不要为分支或干单独添加数值点。

### **排序和段顺序**

图表布局引擎决定矩形和环段的最终位置。请在添加之前将相关的类别行放在一起，但不要依赖特定的矩形位置或起始角度。如果顺序具有意义，请将其包含在标签中或使用具有显式类别轴的图表类型。

### **主题和固定颜色**

未格式化的图表层级从演示文稿主题继承颜色。示例使用显式 RGB 填充以获得可预测的输出。如果图表应随主题变化，请使用方案颜色而不是固定的 RGB 值，并避免对每个层级都进行覆盖。更改分支或干的填充后，还需检查标签对比度。

### **标签和可用空间**

当段太小时，PowerPoint 可能会隐藏或截断标签。增大图表尺寸、缩短类别名称或显示更少的标签字段通常会得到更清晰的结果。标签可以通过 [DataLabelFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabelformat/) 将类别名称、系列名称和数值组合起来，但启用所有字段往往会使层次图表难以阅读。

### **导出和渲染**

保存为 PPTX 可保持图表可编辑。当 Aspose.Slides 将演示文稿渲染为 PDF 或图像时，支持的填充和标签设置会随图表一起渲染。字体替换以及可用布局空间的细微差异会改变换行或标签可见性，因此请安装所需字体并验证重要的导出目标。

## **常见问题解答**

**为什么更改父级层级会影响多个叶子？**

分支或干是共享的可视段。其 [ChartDataPointLevel](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatapointlevel/) 可以通过子叶子访问，但格式化属于共享的父段，而不仅仅是该叶子。

**为什么缺少数据标签？**

首先在标签的 [DataLabelFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datalabelformat/) 对象上启用所需字段。然后检查该段是否有足够空间。Treemap 的父标签布局、图表尺寸、标签长度、字体大小以及已启用字段的数量都会影响标签是否能够显示。

**我可以设置段的精确顺序或坐标吗？**

您可以控制源行的顺序并保持每个组连续，但无法为 Treemap 矩形或 Sunburst 角度指定精确坐标。图表布局引擎会根据层次结构、数值和可用空间计算它们。

**为何在演示文稿主题更改后颜色会改变？**

基于主题的填充设计为遵循演示文稿调色板。对必须保持固定的层级使用显式 RGB 颜色，或在需要适应新主题时保留方案颜色。

**自定义格式在 PDF 和图像导出时会被保留吗？**

会的，支持的图表填充和标签设置在渲染时会被包含。为获得跨系统一致的结果，请提供所需字体并测试最终导出尺寸，因为标签适配取决于布局。

## **另请参阅**

- [Create Treemap charts](/slides/zh/nodejs-java/create-chart/#creating-tree-map-charts)
- [Create Sunburst charts](/slides/zh/nodejs-java/create-chart/#creating-sunburst-charts)
- [Export presentation charts](/slides/zh/nodejs-java/export-chart/)
- [Manage presentation themes](/slides/zh/nodejs-java/presentation-theme/)