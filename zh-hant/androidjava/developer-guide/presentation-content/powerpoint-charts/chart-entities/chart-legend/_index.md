---
title: 在 Android 上的簡報中自訂圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/androidjava/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 來自訂圖表圖例，優化 PowerPoint 簡報的圖例格式設定。"
---
## **概述**

Aspose.Slides for Android via Java 提供在 PowerPoint 簡報中自訂圖表圖例的選項。本文章說明如何設定圖例的位置與大小、為整個圖例設定字型大小、格式化單一圖例項目，以及隱藏或還原所選的項目。

常見問題解答涵蓋相關行為，包括為圖例保留空間、顯示多行標籤，以及從簡報主題繼承格式設定。

## **圖例位置設定**

使用圖例的 [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-)、[setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-)、[setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-) 和 [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) 方法，以圖表尺寸的比例指定其位置與大小。

此範例建立簡報，並在第一張投影片中加入具有預設資料的叢集柱狀圖。將所需的圖例偏移量與尺寸除以圖表的寬度和高度，即可轉換為相對值：圖例從圖表左上角偏移 50 點，大小為 100 × 100 點。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // 以相對於圖表的方式表達圖例的位置與大小。
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

使用圖例的 [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) 取得其文字格式，並使用 [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) 以點為單位設定字型大小。

此範例建立一個具有預設資料的圖表，並將圖例文字設定為 20 點。同時停用垂直軸的自動範圍，並將其範圍設定為 -5 到 10。

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

使用圖例的 [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) 方法回傳的集合，以存取特定項目的格式。項目索引是從零開始計算，因此索引 `1` 代表第二個項目。

此範例建立一個預設資料包含至少兩個系列的叢集柱狀圖。它將第二個圖例項目格式化為粗體、斜體、20 點藍色文字。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **隱藏單一圖例項目**

若要在保持資料可見的情況下，將輔助系列排除於圖例之外，請透過 [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) 呼叫 [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) 並傳入 `true`。這僅會隱藏所選的圖例項目；不會移除系列或其資料點。相較之下，呼叫 [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) 並傳入 `false` 則會隱藏整個圖例。

以下範例使用預設資料建立具有多個系列的叢集柱狀圖。它隱藏第二個系列的圖例項目（索引 `1`）並儲存簡報，然後透過呼叫 [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) 並傳入 `false` 來還原該項目，並儲存第二個副本。兩個檔案的柱狀皆保持可見。

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

下面的比較顯示相同圖表在所有項目皆可見與第二項目被隱藏的情況。第二系列的柱狀保持不變。

![比較圖表在所有圖例項目可見與系列 2 從圖例中隱藏的情況；所有柱狀仍保持可見。](hide-legend-entry.png)

在直條圖、長條圖和折線圖中，圖例項目用於識別系列。對於圓餅圖，則用於識別個別資料點（切片），因此請對選取的切片使用 [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--)。API 為 `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie` 與 `BarOfPie` 圖表類型記錄此資料點方法。不要假設它適用於環形圖，因為環形圖未列於此清單中。

## **常見問題**

**我可以讓圖表為圖例保留空間，而不是覆蓋它嗎？**

可以。呼叫 [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) 並傳入 `false`，即可為圖例保留空間，而不是讓其覆蓋繪圖區域。

**我可以製作多行圖例標籤嗎？**

可以。當可用寬度不足時，長標籤會自動換行。您也可以在系列名稱中加入換行字元以要求換行。

**如何讓圖例遵循簡報主題的配色方案？**

保持圖例的顏色、填色與字型未設定，讓其能夠繼承主題格式。明確的格式設定會覆寫相應的主題設定。