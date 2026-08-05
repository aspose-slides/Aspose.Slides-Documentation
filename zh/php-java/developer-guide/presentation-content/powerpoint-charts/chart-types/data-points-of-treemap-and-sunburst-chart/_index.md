---
title: 在 PHP 中自定义树形图和日晕图的数据点
linktitle: 树形图和日晕图的数据点
type: docs
url: /zh/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- 树形图
- 日晕图
- 层次结构图
- 数据点
- 数据标签
- 分支颜色
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 创建层次数据并自定义树形图和日晕图的层级、标签和颜色。"
---
## **概述**

树形图（Treemap）和日晕图（Sunburst）显示相同类型的层次数据，但它们使用不同的布局。树形图将层次结构绘制为嵌套矩形，其面积代表叶子值。日晕图则绘制为同心环：顶级组位于中心附近，叶子类别位于外环。

在 Aspose.Slides for PHP via Java 中，每个数值都是一个 [ChartDataPoint](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/)。其 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) 方法提供对叶子及其父级组的访问。本文解释了该映射，并展示如何使用相同的示例数据创建和格式化两种图表类型。

![展示 Consumer 和 Business 分支的树形图](treemap-hierarchy.png)

![展示相同 Consumer 和 Business 层次的日晕图](sunburst-hierarchy.png)

## **了解类别、数据点和层级**

下面使用的示例包含三个类别层级和一个数值系列：

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

每行创建一个叶子类别和一个数据点。类别分组层级描述该叶子到其父级的路径。对于第一行，路径为 `Consumer > Computers > Laptops`。

由 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) 返回的索引从叶子向上递增：

| `getDataPointLevels()` 索引 | 逻辑层级 | 树形图表示 | 日晕图表示 |
| ---: | --- | --- | --- |
| `0` | 叶子 | 值矩形 | 外环片段 |
| `1` | 主干 | 父矩形或标题 | 中环片段 |
| `2` | 分支 | 顶层矩形或标题 | 内环片段 |

即使两种图表的可视布局不同，这一顺序在两者之间是相同的。父级片段会被多个叶子共享。要对其进行格式化，请使用该组中第一个数据点对应的层级。例如，`Consumer` 分支从 `Laptops` 点开始，而 `Software` 主干从 `Licenses` 点开始。保留对这些点的引用比使用未解释的表达式如 `$dataPoints->get_Item(0)` 或 `$dataPoints->get_Item(6)` 更清晰安全。

## **创建并自定义两种图表类型**

下面的完整示例在第一张幻灯片上创建树形图，在第二张幻灯片上创建日晕图。它构建层次结构，显示 `Tablets` 的数值，对选定层级应用固定颜色，格式化分支标签，并保存演示文稿。

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // 添加叶子类别。仅在新组开始时设置分组项；
        // 随后类别将保持在该组中，直到设置另一个项。
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // 在 Tablets 叶子上显示类别和数值。
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // 通过该分支的第一个叶子格式化 Consumer 分支。
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // 通过该主干的第一个叶子格式化 Software 主干。
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout 影响 Treemap 父标签；Sunburst 使用环段。
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

类别单元格和数值单元格使用相同的工作表行，因此它们的集合位置保持对齐。使用已有图表而不是创建新图表时，请先检查类别行，并保存要格式化的数据点和层级的具名引用。

## **行为和实际考虑**

### **树形图和日晕图的差异**

- 树形图使用面积来表达数值，使用嵌套矩形来表达层次。`[ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#setParentLabelLayout)` 方法控制此图表类型中父标签的显示方式。
- 日晕图使用角度来表达数值，使用环的深度来表达层次。`[ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartseries/#setParentLabelLayout)` 不控制其环标签。
- 两种图表使用相同的类别分组层级和由 `[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapoint/#getDataPointLevels)` 返回的叶子到父级的顺序，因此数据构建和层级格式化代码可以共享。
- 父级数值由其后代叶子计算得出。不要为分支或主干添加单独的数值点。

### **排序和片段顺序**

图表布局引擎决定矩形和环片段的最终位置。请在添加之前将相关的类别行放在一起，但不要依赖特定的矩形位置或起始角度。如果顺序具有含义，请将其包含在标签中或使用具有显式类别轴的图表类型。

### **主题和固定颜色**

未格式化的图表层级从演示文稿主题继承颜色。示例使用显式 RGB 填充以获得可预测的输出。如果希望图表随主题变化，请使用配色方案颜色而非固定 RGB 值，并避免对每个层级都进行覆盖。更改分支或主干填充后，还需检查标签对比度。

### **标签和可用空间**

当片段过小时，PowerPoint 可能会隐藏或截断标签。增大图表尺寸、缩短类别名称或显示更少的标签字段通常能产生更清晰的结果。标签可以通过 `[DataLabelFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabelformat/)` 将类别名称、系列名称和数值组合，但启用所有字段往往会使层次图表难以阅读。

### **导出和渲染**

保存为 PPTX 可保持图表可编辑。当 Aspose.Slides 将演示文稿渲染为 PDF 或图像时，受支持的填充和标签设置会随图表一起渲染。字体替换以及可用布局空间的细微差异可能导致换行或标签可见性变化，故请安装所需字体并验证重要的导出目标。

## **常见问题**

**为什么更改父级会影响多个叶子？**

分支或主干是共享的可视片段。可通过后代叶子访问其 `[ChartDataPointLevel](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatapointlevel/)`，但格式化属于共享的父片段，而不是仅属于该叶子。

**为什么缺少数据标签？**

首先在标签的 `[DataLabelFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datalabelformat/)` 对象上启用所需字段。然后检查片段是否有足够空间。树形图的父标签布局、图表尺寸、标签长度、字体大小以及启用字段的数量都会影响标签是否能够显示。

**我可以设置片段的精确顺序或坐标吗？**

可以控制源行的顺序并保持每个组连续，但不能为树形图矩形或日晕图角度指定精确坐标。图表布局引擎根据层次结构、数值和可用空间计算它们。

**为什么在更改演示文稿主题后颜色会变化？**

基于主题的填充设计为遵循演示配色方案。对必须保持固定的层级使用显式 RGB 颜色，或在需要适配新主题时保留配色方案颜色。

**自定义格式在 PDF 和图像导出时会被保留吗？**

会的，受支持的图表填充和标签设置在渲染时会被包含。为获得跨系统一致的结果，请提供所需字体并测试最终导出尺寸，因为标签适配取决于布局。

## **另请参阅**

- [创建树形图](/slides/zh/php-java/create-chart/#create-tree-map-charts)
- [创建日晕图](/slides/zh/php-java/create-chart/#create-sunburst-charts)
- [导出演示文稿图表](/slides/zh/php-java/export-chart/)
- [管理演示文稿主题](/slides/zh/php-java/presentation-theme/)