---
title: Java を使用してプレゼンテーションのチャート凡例をカスタマイズする
linktitle: チャート凡例
type: docs
url: /ja/java/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してチャート凡例をカスタマイズし、カスタム書式設定された凡例で PowerPoint プレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides for Java は、PowerPoint プレゼンテーションのチャート凡例をカスタマイズするオプションを提供します。この記事では、凡例の位置とサイズの指定、凡例全体のフォントサイズ設定、個別の凡例エントリの書式設定、選択したエントリの非表示または復元方法を示します。

FAQ では、凡例のためのスペース確保、複数行ラベルの表示、プレゼンテーションテーマからの書式継承などの関連動作について説明します。

## **凡例の位置指定**

凡例の [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) メソッドを使用して、位置とサイズをチャートの寸法の割合として指定します。

この例ではプレゼンテーションを作成し、デフォルトデータを持つクラスター化された縦棒グラフを最初のスライドに追加します。凡例のオフセットとサイズをチャートの幅と高さで割ることで相対値に変換します。凡例はチャートの左上隅から 50 ポイントオフセットされ、サイズは 100 x 100 ポイントになります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // チャートに対して凡例の位置とサイズを相対的に設定します。
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

凡例の [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) を使用してテキスト書式にアクセスし、[setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) でフォントサイズをポイント単位で設定します。

この例ではデフォルトデータのチャートを作成し、凡例のテキストを 20 ポイントに設定します。また、縦軸の自動境界を無効にし、範囲を -5 から 10 に設定します。

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

## **個別の凡例エントリのフォントサイズの設定**

凡例の [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) メソッドが返すコレクションを使用して、特定のエントリの書式にアクセスします。エントリのインデックスはゼロベースなので、インデックス `1` は2番目のエントリを指します。

この例では、デフォルトデータに少なくとも2つの系列が含まれるクラスター化された縦棒グラフを作成します。2番目の凡例エントリを太字、斜体、20ポイントの青色テキストで書式設定します。

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

## **個別の凡例エントリの非表示**

データは表示されたまま、補助シリーズを凡例から除外するには、[IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) を介して [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) を `true` で呼び出します。これにより選択した凡例エントリだけが非表示になり、シリーズやデータポイントは削除されません。対照的に、[IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) を `false` で呼び出すと、凡例全体が非表示になります。

以下の例では、デフォルトデータを使用して複数系列のクラスター化された縦棒グラフを作成します。2番目の系列の凡例エントリ（インデックス `1`）を非表示にし、プレゼンテーションを保存します。その後、[setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) を `false` で呼び出してエントリを復元し、2つ目のコピーを保存します。両方のファイルで列は表示されたままです。

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

    // チャートデータを変更せずに同じエントリを復元します。
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下の比較は、すべてのエントリが表示された状態と2番目のエントリが非表示の状態の同一チャートを示します。2番目の系列の列は変わりません。

![全凡例エントリが表示された状態とシリーズ 2 が凡例から非表示の状態のチャート比較；すべての列は表示されたまま。](hide-legend-entry.png)

縦棒、棒、折れ線チャートでは、凡例エントリは系列を識別します。円グラフの場合、凡例エントリは個々のデータポイント（スライス）を識別するため、選択したスライスに対して [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) を使用します。このデータポイントメソッドは `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie`、`BarOfPie` のチャートタイプについて API に記載されています。ドーナツチャートには適用されないことに注意してください。

## **FAQ**

**チャートが凡例の上に重ねるのではなく、凡例用のスペースを確保するようにできますか？**

はい。`false` を指定して [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) を呼び出すと、プロット領域に重なるのを防ぎ、凡例用のスペースを確保できます。

**複数行の凡例ラベルを作成できますか？**

はい。利用可能な幅が不足している場合、長いラベルは自動的に折り返されます。また、系列名に改行文字を入れることで改行を要求することもできます。

**凡例をプレゼンテーションテーマのカラースキームに従わせるにはどうすればよいですか？**

凡例の色、塗りつぶし、フォントを設定せずに残すことで、テーマの書式設定を継承させます。明示的に書式を設定すると、対応するテーマ設定が上書きされます。