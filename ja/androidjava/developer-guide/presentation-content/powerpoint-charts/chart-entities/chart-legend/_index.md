---
title: Android のプレゼンテーションでチャート凡例をカスタマイズ
linktitle: チャート凡例
type: docs
url: /ja/androidjava/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用してチャート凡例をカスタマイズし、カスタマイズされた凡例書式で PowerPoint プレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides for Android via Java は、PowerPoint プレゼンテーション内のチャート凡例をカスタマイズするオプションを提供します。この記事では、凡例の位置とサイズの指定、凡例全体のフォントサイズ設定、個別凡例エントリの書式設定、選択エントリの非表示や復元方法を示します。

FAQ では、凡例のためにスペースを確保する方法、複数行ラベルの表示、プレゼンテーションテーマから書式を継承する方法など、関連する動作について説明します。

## **凡例の配置**

凡例の位置とサイズをチャートのサイズの比率として指定するには、凡例の[setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-)、[setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-)、[setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-)、および[setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-)メソッドを使用します。

この例はプレゼンテーションを作成し、最初のスライドにデフォルト データのクラスター化された縦棒グラフを追加します。凡例のオフセットとサイズをチャートの幅と高さで割ることで相対値に変換します。凡例はチャート左上隅から 50 ポイントオフセットされ、サイズは 100 × 100 ポイントです。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // チャートに対して凡例の位置とサイズを相対的に表現します。
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **凡例のフォントサイズの設定**

凡例の[getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) を使用してテキスト書式情報にアクセスし、[setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) でポイント単位のフォントサイズを設定します。

この例はデフォルト データのグラフを作成し、凡例テキストを 20 ポイントに設定します。また、縦軸の自動範囲設定を無効にし、範囲を -5 から 10 に設定します。

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

## **個別凡例エントリのフォントサイズの設定**

凡例の[getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) メソッドが返すコレクションを使用して、特定エントリの書式にアクセスします。エントリ インデックスはゼロベースなので、インデックス `1` は 2 番目のエントリを指します。

この例は、デフォルト データに少なくとも 2 系列が含まれるクラスター化縦棒グラフを作成します。2 番目の凡例エントリを太字・斜体・20 ポイントの青色テキストで書式設定します。

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

## **個別凡例エントリの非表示**

補助系列をデータは表示したまま凡例から除外するには、[ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) を `true` に設定し、[IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) から取得します。これにより選択した凡例エントリだけが非表示になり、系列やデータ ポイントは削除されません。対照的に、[IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) を `false` に設定すると、凡例全体が非表示になります。

以下の例では、デフォルト データを使用した複数系列のクラスター化縦棒グラフを作成します。2 番目の系列の凡例エントリ（インデックス `1`）を非表示にしてプレゼンテーションを保存します。その後、[setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) を `false` に設定してエントリを復元し、2 番目のコピーを保存します。列は両方のファイルで表示されたままです。

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

    // 同じエントリをチャート データを変更せずに復元します。
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下の比較は、すべてのエントリが表示されているチャートと、2 番目のエントリが凡例から非表示になっているチャートを示します。2 番目の系列の列は変わりません。

![凡例エントリがすべて表示されているチャートと、シリーズ 2 のエントリが凡例から非表示になっているチャートの比較；すべての列は表示されたままです。](hide-legend-entry.png)

列、棒、折れ線グラフでは、凡例エントリは系列を識別します。円グラフの場合、エントリは個々のデータ ポイント（スライス）を識別するため、選択したスライスに対して[IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) を使用します。このデータ ポイント メソッドは `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie`、`BarOfPie` の各チャート タイプの API ドキュメントに記載されています。ドーナツ グラフには適用されないことに注意してください。

## **FAQ**

**凡例が重ねて表示されるのではなく、チャートが凡例用にスペースを確保するようにできますか？**

Yes. Call [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) with `false` to reserve space for the legend instead of allowing it to overlap the plot area.

**複数行の凡例ラベルを作成できますか？**

Yes. Long labels can wrap when the available width is insufficient. You can also use newline characters in series names to request line breaks.

**凡例をプレゼンテーションテーマの配色に合わせるにはどうすればよいですか？**

Leave the legend's colors, fills, and fonts unset so that it can inherit theme formatting. Explicit formatting overrides the corresponding theme settings.