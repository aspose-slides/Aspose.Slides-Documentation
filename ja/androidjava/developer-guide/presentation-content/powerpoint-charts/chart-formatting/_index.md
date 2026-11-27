---
title: Android でプレゼンテーション チャートの書式設定
linktitle: チャート書式設定
type: docs
weight: 60
url: /ja/androidjava/chart-formatting/
keywords:
- チャートの書式設定
- チャート書式設定
- チャートエンティティ
- チャートプロパティ
- チャート設定
- チャートオプション
- フォントプロパティ
- 角丸境界線
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用したチャート書式設定を学び、カスタム軸、フォント、数値書式、角丸チャート境界線で PowerPoint プレゼンテーションを向上させましょう。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーション内のチャートの書式設定方法を説明します。軸、グリッド線、タイトル、凡例、プロット領域、壁の塗りつぶしなど、チャートの主要要素をカスタマイズして、データの外観と可読性を向上させる方法を示します。

また、チャートのテキストにフォント プロパティを設定し、数値書式をプリセットで適用し、チャート領域に丸みを帯びた角を有効にする方法も示します。これらの例は、プレゼンテーション内のチャートのビジュアル スタイルとデータ表示の両方を制御する方法を示しています。

上昇間隔と下降間隔で別々の塗りつぶしとアウトラインを使用する場合は、[株価チャートの例](/slides/ja/androidjava/create-chart/#create-stock-charts)を参照してください。

## **チャート エンティティの書式設定**

[IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) を使用して、チャート タイトル、軸、グリッド線、凡例、およびプロット領域の書式設定を行います。この例は、マーカー付きの折れ線グラフをデフォルト データで作成し、値軸とカテゴリ軸にそれぞれ別々のテキストと線のスタイルを適用します。フォント サイズと線幅はポイントで指定され、カテゴリ ラベルは 45 度回転します。

値軸はソース セルとは独立して [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) を使用します。そのスケールは -2 から 15 までで、主要間隔が 2、副間隔が 0.5 です。この例では、パーセンテージ書式と [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) を千単位に設定した組み合わせを使用しています。データの意味と規模に合わせてこれらの設定を調整してください。凡例は [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) が `false` で呼び出されるため、プロット領域の外側に配置されます。背面壁とフロアの塗りつぶしは [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) と [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) で構成されますが、これらの面は 3D チャートでのみ表示されます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **チャートのフォント プロパティの設定**

[Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--) を使用して、チャート テキストのデフォルト フォント サイズを設定します。この例は、フォント サイズ 20 ポイントの集積棒グラフを作成し、[setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) によって最初の系列の値ラベルを有効にします。独自の明示的なフォント設定を持つテキスト要素は、チャートのデフォルトを上書きできます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **チャート 凡例のテキスト フレーム書式の再利用**

凡例をスライドの見出しに合わせるには、最初の段落の [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) で見出しのフォントを設定します。その後、凡例の [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) が返す書式に対して [copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) を呼び出します。これにより、テキスト フレーム設定、最初の段落の書式、およびその段落のデフォルト フォント プロパティがコピーされます。個別の部分や後続の段落に直接適用された書式は、元の書式に対してローカルに残ります。

この例では、濃紺の太字 26 ポイント Calibri 見出しをテンプレートとして使用します。凡例のスタイリング後、[copyTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) を呼び出して、同じ書式を別のキャプションに適用します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(Color.rgb(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存されたプレゼンテーションでは、凡例とキャプションがサイズ、太さ、色の点で見出しと一致します。凡例は依然として系列名を表示し、キャプションは独自のテキストを保持します。キャプション内の部分に明示的なフォント サイズが設定されている場合、そのサイズがコピーされた段落のデフォルトより優先されます。

| コピー前 | コピー後 |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **数値書式の設定**

[IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) を使用して、チャート ワークブック セルに組み込みの数値書式を適用します。この例は、デフォルトのセル バック データを持つ集積棒グラフを作成し、各系列の値セルに書式インデックス 10 (`0.00%`) を適用します。これにより、基礎となる数値は変更せずに、ワークブック内での表示が 0.25 → 25.00% のように変わります。軸とデータ ラベルの書式は別々に構成できます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下の表は、英語 (米国) ロケール向けの代表的な Excel 書式とともに組み込み数値書式インデックスを一覧にしたものです。正確な書式文字列と表示はアプリケーションやロケールによって異なる場合があります。特に通貨や日付の書式は差異が生じることがあります。一部の Excel 書式は OOXML 標準のデフォルトとは異なることがあり、詳細は [Microsoft の数値書式実装ノート](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) を参照してください。

| インデックス | 書式 |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **チャート領域の丸みを帯びた枠線の設定**

[IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) を `true` で呼び出すと、チャート領域の角が丸くなります。この例は集積棒グラフを作成し、[getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) を使用してアウトラインに実線のグレー色と単一線スタイルを設定した後、プレゼンテーションを保存します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **既存のチャート注釈の編集**

チャートには、レポートのステータスを説明するテキスト注釈などのカスタム シェイプを含めることができます。これらのシェイプは [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--) で取得でき、Chart API Reference の [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) にも一覧されています。[getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) が返すコレクションには、チャートが所有するシェイプが含まれます。

チャート上に配置された普通のテキスト ボックスはスライドに属し、チャートの一部に見えてもスライドのシェイプとして扱われます。[Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) を反復処理すると、チャートと普通のスライド シェイプが見つかりますが、チャート内部の個々のシェイプは列挙されません。チャート タイトルとデータ ラベルは別個のチャート要素であり、このコレクション内のカスタム 注釈ではありません。

[chart-annotations.pptx](chart-annotations.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置します。最初のスライドには、未グループ化の注釈「Preliminary results」、チャートが所有する線、普通のスライド テキスト ボックス「Slide overlay」が含まれています。この例はそのスライド上の最初のチャートを見つけ、レポートの公開が可能になったときに注釈を「Final results」に変更します。空のコレクションを確認し、[getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) が非 null のテキスト フレームを返す [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) のみを編集対象とし、期待されるテキストと一致するかどうかをチェックします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

線とスライド テキスト ボックスは変更されません。以下の画像は入力と保存後に再度開いた結果を示しています。

| 編集前 | 編集後 |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
この例はトップレベルのチャート所有シェイプのみを検査します。注釈が [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/) 内にある場合は、そのグループの [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) コレクションも検査してください。入れ子になったグループについては同様に再帰的に処理し、子シェイプに対して同じテキストチェックを適用します。グループ自体はコンテナであり、テキスト ボックスとして扱わないでください。
{{% /alert %}}

## **FAQ**

**列やエリアの塗りつぶしを半透明にし、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度とアウトラインは別々に構成できます。これにより、密集したビジュアル化においてグリッドとデータの可読性を向上させることができます。

**ラベルが重なった場合、どのように対処できますか？**

フォント サイズを小さくする、不要なラベル要素（例: カテゴリ）を無効にする、ラベル位置を調整する、必要に応じて選択されたポイントのみラベルを表示する、または形式を「値 + 凡例」に切り替えるなどの方法があります。

**系列にグラデーションやパターン塗りつぶしを適用できますか？**

はい。系列は実線、グラデーション、パターンの塗りつぶしをサポートします。実務ではグラデーションの使用は控えめにし、グリッドやテキストとのコントラストを低下させる組み合わせは避けてください。