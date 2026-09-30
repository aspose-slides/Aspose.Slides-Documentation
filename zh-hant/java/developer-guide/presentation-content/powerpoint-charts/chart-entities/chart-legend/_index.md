---
title: 使用 Java 自訂簡報中的圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/java/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 自訂圖表圖例，以量身打造的圖例格式優化 PowerPoint 簡報。"
---
## **概觀**

Aspose.Slides for Java 提供在 PowerPoint 簡報中自訂圖表圖例的選項。本文章說明如何設定圖例的位置與大小、為整個圖例設定字型大小、格式化單一圖例項目，以及隱藏或還原選取的項目。

常見問題解答涵蓋相關行為，包括為圖例保留空間、顯示多行標籤，以及從簡報主題繼承格式設定。

## **圖例位置設定**

使用圖例的 [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-)、[setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-)、[setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-) 和 [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) 方法，以圖表尺寸的比例指定其位置與大小。

此範例建立一個簡報，並在第一張投影片加入預設資料的叢集柱狀圖。將所需的圖例偏移量與尺寸除以圖表的寬度和高度，即可轉換為相對值：圖例相對於圖表左上角偏移 50 點，大小為 100 × 100 點。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // 說明圖例相對於圖表的位置與大小。
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定圖例的字型大小**

使用圖例的 [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) 取得文字格式，並使用 [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) 設定字型大小（單位為點）。

此範例建立一個預設資料的圖表，並將圖例文字設定為 20 點。它同時停用垂直坐標軸的自動邊界，並將範圍設定為 -5 至 10。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定單一圖例項目的字型大小**

使用圖例的 [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) 方法回傳的集合，存取特定項目的格式。項目索引從 0 開始，因此索引 `1` 代表第二個項目。

此範例建立一個包含至少兩個資料系列的叢集柱狀圖，並將第二個圖例項目格式設為粗斜體、藍色、20 點字型。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **隱藏個別圖例項目**

若要在保留資料可見的前提下，將輔助系列從圖例中排除，請透過 [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) 取得對應的圖例項目，並呼叫 [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) 並傳入 `true`。此動作僅隱藏選取的圖例項目，並不會移除系列或其資料點。相較之下，將 [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) 設為 `false` 會隱藏整個圖例。

以下範例建立一個包含多個系列的叢集柱狀圖（使用預設資料），隱藏第二個系列的圖例項目（索引 `1`），並儲存簡報。接著再呼叫 [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) 並傳入 `false` 以還原該項目，並儲存第二個副本。兩個檔案中的柱狀皆保持可見。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // 在不更改圖表資料的情況下還原相同的項目。
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下圖比較了全部圖例項目皆可見與隱藏第二項目之後的同一圖表。第二系列的柱狀未受到影響。

![比較顯示所有圖例項目與隱藏第二項目之圖表；所有柱狀皆保持可見。](hide-legend-entry.png)

在柱狀圖、條形圖與折線圖中，圖例項目用來辨識系列。對於圓餅圖，圖例項目則對應個別資料點（切片），因此請對選取的切片使用 [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--)。API 為 `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie` 與 `BarOfPie` 圖表類型提供此資料點方法。請勿假設此方法適用於環形圖（doughnut），因為環形圖未列於支援清單中。

## **常見問題**

**我可以讓圖表為圖例保留空間，而不是將其覆蓋在上嗎？**

可以。將 [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) 設為 `false`，即可為圖例保留空間，而不是讓它覆蓋繪圖區域。

**我可以製作多行圖例標籤嗎？**

可以。當可用寬度不足時，長標籤會自動換行。也可以在系列名稱中插入換行字元，以強制換行。

**如何讓圖例遵循簡報主題的配色方案？**

保持圖例的顏色、填充與字型未設定，讓它繼承主題格式。若明確設定格式，則會覆寫相對應的主題設定。