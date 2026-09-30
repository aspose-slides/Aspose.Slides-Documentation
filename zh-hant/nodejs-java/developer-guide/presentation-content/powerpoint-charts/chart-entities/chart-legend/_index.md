---
title: 使用 JavaScript 自訂簡報中的圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/nodejs-java/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 來自訂圖表圖例，以量身打造的圖例格式化優化 PowerPoint 簡報。"
---
## **概述**

Aspose.Slides for Node.js via Java 提供在 PowerPoint 簡報中自訂圖表圖例的選項。本文說明如何定位與調整圖例大小、設定整個圖例的字型大小、格式化單一圖例項目，以及隱藏或還原選取的項目。

FAQ 介紹相關行為，包括為圖例保留空間、顯示多行標籤，以及從簡報主題繼承格式設定。

## **圖例定位**

使用圖例的 [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/)、[setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/)、[setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/)和 [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) 方法，以圖表尺寸的比例指定其位置與大小。

此範例建立一個簡報，並在第一張投影片加入一個具有預設資料的聚合柱狀圖。將欲設定的圖例位移與尺寸除以圖表的寬度與高度，即可轉換為相對值：圖例相對於圖表左上角偏移 50 點，大小為 100 × 100 點。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // 表示圖例相對於圖表的位置和大小。
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定圖例的字型大小**

使用圖例的 [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) 取得其文字格式，並使用 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) 以點為單位設定字型大小。

此範例建立一個具有預設資料的圖表，並將圖例文字設定為 20 點。它同時停用垂直軸的自動界限，並將其範圍設為 -5 到 10。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定單一圖例項目的字型大小**

使用圖例的 [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) 方法回傳的集合，以取得特定項目的格式。項目索引採零基礎，所以索引 `1` 代表第二個項目。

此範例建立一個聚合柱狀圖，其預設資料至少包含兩個系列。它將第二個圖例項目格式化為粗體、斜體、20 點藍色文字。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **隱藏單一圖例項目**

若要在保持資料可見的同時，將輔助系列排除於圖例之外，可透過 [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/) 呼叫 [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) 並傳入 `true`。這僅隱藏選取的圖例項目；不會移除系列或其資料點。相反地，呼叫 [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) 並傳入 `false` 會隱藏整個圖例。

以下範例建立一個使用預設資料的多系列聚合柱狀圖。它隱藏第二個系列的圖例項目（索引 `1`），並儲存簡報。然後透過呼叫 [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) 並傳入 `false` 復原該項目，並另存第二個副本。兩個檔案中的柱形皆保持可見。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // 恢復相同的項目而不更改圖表資料。
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下方比較顯示相同圖表在所有項目皆可見與第二項目被隱藏的情況。第二系列的柱形保持不變。

![所有圖例項目皆可見與第二系列圖例項目被隱藏的圖表比較；所有柱形仍保持可見。](hide-legend-entry.png)

在柱形圖、條形圖與折線圖中，圖例項目用於識別系列。對於圓餅圖，它們用於識別單獨的資料點（切片），因此請改在選取的切片上使用 [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/)。API 為 `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie` 與 `BarOfPie` 圖表類型記錄了此資料點方法。不要假設它適用於環形圖，環形圖未列於此清單中。

## **常見問題**

**我可以讓圖表為圖例保留空間而不是覆蓋它嗎？**

可以。呼叫 [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) 並傳入 `false`，即可為圖例保留空間，而不是讓它覆蓋繪圖區域。

**我可以製作多行圖例標籤嗎？**

可以。當可用寬度不足時，長標籤會自動換行。您也可以在系列名稱中使用換行字元，以要求換行。

**我要如何讓圖例遵循簡報主題的配色方案？**

不要設定圖例的顏色、填色與字型，讓其自行繼承主題的格式。明確設定的格式會覆寫相對應的主題設定。