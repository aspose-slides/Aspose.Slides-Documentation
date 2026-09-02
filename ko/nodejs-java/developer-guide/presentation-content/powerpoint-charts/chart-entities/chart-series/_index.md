---
title: JavaScript를 사용하여 프레젠테이션에서 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/nodejs-java/chart-series/
keywords:
- 차트 시리즈
- 시리즈 겹침
- 시리즈 색상
- 시리즈 이름
- 데이터 포인트
- 워크북 셀
- 시리즈 간격
- 음수 값
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript를 사용하여 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식, 겹침, 간격 너비 및 음수 값을 관리하는 방법을 배웁니다."
---
## **개요**

A chart stores its plotted data in a chart data workbook. A [ChartSeries](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/) represents one set of related values, and each [ChartDataPoint](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapoint/) in the series refers to one or more workbook cells. [ChartCategory](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartcategory/) objects provide the labels or grouping values shared by the series. The series name, categories, and point values are therefore connected to [ChartDataCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatacell/) objects rather than stored only as display text.

For a typical category chart, the default workbook uses row 0 for series names, column 0 for category names, and the remaining cells for series values. Worksheet, row, and column indexes passed to [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdataworkbook/#getCell) are zero-based. This layout is useful when you create a chart with default data, but do not assume that every existing chart uses it. For a loaded presentation, inspect the cells referenced by the series, categories, and data points before changing workbook values.

Chart settings have three different scopes:

- Series-level settings, such as [ChartSeries.getFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#getFormat), provide the default appearance for all points in one series.
- Data-point settings, such as [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapoint/#getFormat), override the series appearance for one point.
- Group settings apply to compatible series that belong to the same [ChartSeriesGroup](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseriesgroup/). Access the group through [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) when you need to set options such as overlap or gap width.

When no explicit point or series fill is set, the chart style and theme determine the automatic appearance. When both series and point formatting are present, the point formatting takes precedence for that point.

![차트-시리즈-파워포인트](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#getOverlap) reports how much bars or columns overlap in a 2D chart, from -100 through 100 percent. It is a read-only projection of the setting on the parent series group. Use [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) to update every compatible series in that group. This option applies to chart types that display grouped bars or columns; it does not affect unrelated series groups in a combination chart.

The following example sets the overlap for the group that contains the first series:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 새로운 차트에는 샘플 시리즈, 카테고리 및 값이 포함됩니다.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The result:

![시리즈 겹침](series_overlap.png)

## **시리즈 채우기 색상 변경**

Use [ChartSeries.getFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#getFormat) to set the default fill for an entire series. If a point already has an explicit fill, its [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapoint/#getFormat) setting overrides the series fill for that point.

The following example applies a solid blue fill to the first series:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The result:

![시리즈 색상](series_color.png)

## **시리즈 이름 변경**

A series name is stored in the chart data workbook and is normally displayed in the legend. In the default workbook created for a clustered column chart, cell B1 is at row 0, column 1 and contains the name of the first series. The named constants in the following example make that structure explicit:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

You can also update the cell already referenced by [ChartSeries.getName](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#getName). This approach avoids assuming a particular row and column in an existing chart:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The result:

![시리즈 이름](series_name.png)

## **자동 시리즈 채우기 색상 가져오기**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) returns the color calculated from the series index and the chart style. This is the color used when the series fill has not been explicitly defined. Calling the method reads the calculated color; it does not assign a new fill.

The following example prints the automatic color of each default series:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Example output for the default chart style:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

The exact colors depend on the chart style and theme.

## **차트 시리즈에 대한 반전 채우기 색상 설정**

For bar, column, and bubble series, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) can display negative values with a different fill. Set the regular series fill to solid, enable inversion, and assign the negative-value color through [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negative numbers remain unchanged in the workbook; only their display color changes.

The following example replaces the default chart data with one series. Worksheet row 0 contains the series name, column 0 contains category names, and column 1 contains the values:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The result:

![반전된 단색 채우기 색상](inverted_solid_fill_color.png)

You can enable inversion for one point through [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). In the following example, inversion is disabled for the series and enabled only for the selected point. The point is also assigned a negative value so that the effect is visible:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **특정 데이터 포인트 값 지우기**

To make one point empty without removing the other points, set its backing workbook cell to `null`. For a column chart, the plotted value is available through [ChartDataPoint.getValue](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapoint/#getValue). The data point stays at the same category position, but the chart treats its value as blank according to the chart's blank-value settings.

The following example clears only the second point in the first series:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Scatter charts use separate X and Y cells, and bubble charts also use a size cell. Clear only the cell that represents the value you intend to remove. Do not call [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapointcollection/#clear) when you want to keep the other points, because that method removes every data point from the collection.

## **시리즈 간격 너비 설정**

Gap width is the space between adjacent bar or column clusters, expressed as a percentage of the bar or column width. Like overlap, it belongs to the parent series group rather than to one series. Call [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) once for the group. A larger value creates more space between clusters; a smaller value makes them denser.

The following example changes the gap width and saves only the final presentation:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The result:

![간격 너비](gap_width.png)

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원합니까?**

All chart types represented by the [ChartType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/charttype/) enumeration use chart data, but their series do not all have the same value structure or settings. For example, category charts use categories and values, scatter charts use X and Y values, and bubble charts add bubble sizes. Use the data-point creation method that matches the series type. Options such as overlap and gap width apply only to compatible bar or column groups.

**차트 시리즈 그룹이란 무엇입니까?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseriesgroup/) contains compatible series that share group-level plotting settings. A combination chart can contain more than one group, so changing the group reached through one series does not necessarily change every series in the chart.

**새로 만든 차트에 기본 데이터가 포함되어 있습니까?**

Yes. By default, [ShapeCollection.addChart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/#addChart) creates sample series, categories, and values. You can edit those cells or clear both the series and category collections before adding a completely custom data set. An overload can also create a chart without default data.

**차트 객체가 워크북 셀과 어떻게 연결되어 있습니까?**

Series names, category labels, and data-point values reference cells in a [ChartDataWorkbook](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdataworkbook/). Changing a referenced cell updates the corresponding chart element. When you build custom data, keep category rows and series-value rows aligned so that each point is plotted under the intended category.

**하나의 포인트만 지우려면 어떻게 해야 합니까?**

Set the relevant value cell to `null` to retain the point's category position as an empty point. Use [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapointcollection/#clear) only when you intend to remove all points from that series. If you also remove categories, update every series so their values remain aligned with the category collection.

**빈 포인트는 어떻게 표시됩니까?**

The result depends on the chart type and the value configured through [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Supported charts can display blanks as gaps, as zero values, or by connecting neighboring points. Choose the setting that matches the meaning of missing data in your presentation.

**음수 값은 어떻게 서식이 지정됩니까?**

For supported bar, column, and bubble series, call [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) and set the color returned by [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). You can override the behavior for an individual point with [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). These methods affect formatting, not the stored numeric values.

**시리즈와 포인트가 모두 서식이 지정된 경우 어느 것이 우선합니까?**

Explicit data-point formatting takes precedence for that point. Other points continue to use the explicit series format or, when the series format is not defined, the automatic chart style and theme. Group settings such as overlap and gap width control layout and are not point-level formatting overrides.

**차트에 포함될 수 있는 시리즈 수에 제한이 있습니까?**

Aspose.Slides does not impose a separate fixed series-count limit. In practice, presentation file constraints, available memory, rendering time, and chart readability determine a useful limit.

**열이 너무 가깝거나 너무 멀리 떨어져 있으면 무엇을 변경해야 합니까?**

Call [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) on the appropriate parent series group. Increase the value to widen the space between clusters, or decrease it to bring the clusters closer together.