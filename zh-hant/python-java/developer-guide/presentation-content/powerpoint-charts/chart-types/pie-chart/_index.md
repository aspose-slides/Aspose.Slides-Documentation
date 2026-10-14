---
title: 在演示文稿中使用 Python via Java 自訂圓餅圖
linktitle: 圓餅圖
type: docs
url: /zh-hant/python-java/pie-chart/
keywords:
- 圓餅圖
- 管理圖表
- 自訂圖表
- 圖表選項
- 圖表設定
- 繪圖選項
- 切片顏色
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 於 Python via Java 建立並自訂圓餅圖。設定次要圖表、顯示資料標籤，並在 PowerPoint 中套用自動切片顏色。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圓餅圖。它展示了如何為 Pie of Pie 與 Bar of Pie 圖表設定次要圖表選項，以及如何為標準圓餅圖啟用自動切片著色。

範例著重於圖表自訂工作，例如將圖表加入投影片、調整系列與標籤設定、以自訂類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **Pie of Pie 與 Bar of Pie 圖表的次要圖表選項**

Aspose.Slides for Python via Java 支援 Pie of Pie 與 Bar of Pie 圖表的次要圖表選項。這些選項可控制次要圖表的大小以及資料點在兩個圖表之間的分割方式。

下列範例在新簡報中建立 Pie of Pie 圖表，並以標籤顯示資料點數值。[setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) 方法將次要圖表大小設定為主圖表的 149%。[setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 選擇以比例分割，而 [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) 則將門檻設為 53%。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # 顯示數值並設定次要圖表。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **為次要圖表選取類別**

當您想要在次要圖表中將特定類別聚集在一起，而不考慮其比例值時，可使用自訂分割。例如，銷售報表可能會把 Online 與 Events 兩個管道放在一起，以便讀者比較這兩個渠道，即使它們分別佔總銷售的 35% 與 10%。

呼叫 [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 並傳入 [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom)，再透過 [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) 取得集合。集合的 [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) 方法接受系列中的零基索引；使用 [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) 可加入資料點物件。在此範例中，索引 1 選取 Online，索引 3 選取 Events。Partners 也暫時加入，然後使用 [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem) 移除。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpapi.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # 用渠道的銷售資料取代預設資料。
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # 透過零基索引選取 Online，並以資料點物件選取 Events。
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # 將 Partners 從選取中排除，但不刪除其來源資料。
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) 與 Events (10) 會在次要圖表中顯示為獨立切片。在主圖表中，它們以合併切片 45 代表，與 Retail (40) 與 Partners (15) 共同顯示。從自訂選取中移除 Partners 後，它仍保留在主圖表中；不會從圖表的來源資料中移除該類別或其數值。

以下圖片顯示已儲存的 PowerPoint 簡報：

![Pie of Pie 圖表，其中 Online 與 Events 在次要圖表中，且在主圖表中合併為 45 的數值](pie_of_pie_custom.png)

## **設定自動圓餅圖切片顏色**

Aspose.Slides for Python via Java 可以自動為圓餅圖的每個切片指派不同顏色。下列範例建立一個置中標題的圓餅圖，並以三個季節類別及其數值取代預設資料。[setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) 方法在標籤中顯示 20、50 與 30 的數值，而 [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) 則為每個切片啟用不同顏色。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # 新增置中圖表標題。
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # 使用第一個工作表取代預設資料。
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # 顯示數值並為切片指派不同顏色。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**是否支援 Pie of Pie 與 Bar of Pie 變形？**

是的，函式庫[支援](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 圓餅圖的次要圖表，包括 Pie of Pie 與 Bar of Pie 類型。

**我可以只將圖表匯出為影像檔案（例如 PNG）嗎？**

可以，您可以[將圖表本身匯出為影像](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage)（如 PNG），而不必匯出整個簡報。