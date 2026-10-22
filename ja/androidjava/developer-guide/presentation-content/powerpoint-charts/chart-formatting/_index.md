---
title: Androidでプレゼンテーションチャートをフォーマットする
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/androidjava/chart-formatting/
keywords:
- チャートの書式設定
- チャートの書式設定
- チャートエンティティ
- チャートのプロパティ
- チャート設定
- チャートオプション
- フォントプロパティ
- 角丸境界線
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android用 Aspose.Slides でのチャート書式設定を学び、カスタム軸、フォント、数値書式、角丸チャート境界線で PowerPoint プレゼンテーションを向上させましょう。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションのチャートをフォーマットする方法を説明します。軸、グリッド線、タイトル、凡例、プロット領域、壁の塗りつぶしなどの主要なチャート要素をカスタマイズし、チャート データの外観と可読性を向上させる方法を示します。

また、チャート テキストのフォント プロパティの設定、チャート データへの事前定義数値書式の適用、チャート領域の角を丸める方法も示します。これらの例を組み合わせることで、プレゼンテーション内のチャートのビジュアル スタイルとデータ表示の両方を制御できることが示されています。

## **チャート要素のフォーマット**

チャートのタイトル、軸、グリッド線、凡例、およびプロット領域をフォーマットするには、[IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) を使用します。この例では、マーカー付きの折れ線グラフをデフォルト データで作成し、値軸とカテゴリ軸それぞれに別々のテキストと線のスタイルを適用します。フォント サイズと線幅はポイント単位で指定され、カテゴリ ラベルは 45 度回転します。

値軸は、ソースセルに依存せず [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) を使用します。スケールは -2 から 15 までで、メジャー間隔は 2、マイナー間隔は 0.5 に設定されています。この例では、パーセンテージ書式と [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) を千単位に設定したものを組み合わせているため、データの意味や規模に合わせて設定を調整してください。凡例は、[setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) に `false` を指定しているため、プロット領域の外側に表示されます。背面壁と床の塗りつぶしは [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) と [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) で設定しますが、これらの面は 3D チャートでのみ表示されます。

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

[Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--) を使用して、チャート テキストのデフォルト フォント サイズを設定します。この例では、20 ポイントのフォントを持つクラスター化縦棒グラフを作成し、[setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) を使用して最初の系列の値ラベルを有効にします。独自の明示的なフォント設定を持つテキスト要素は、チャートのデフォルト設定を上書きできます。

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

## **数値書式の設定**

[IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) を使用して、チャートのブックセルに組み込み数値書式を適用します。この例では、デフォルトのセルベース データを持つクラスター化縦棒グラフを作成し、各系列の値セルにフォーマット インデックス 10（`0.00%`）を適用します。これにより、基となる数値は変更せずにブック上での表示が変わります。たとえば、0.25 は 25.00% と表示されます。軸とデータ ラベルの書式は個別に設定できます。

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

以下の表は、英語（米国）ロケール向けの代表的な Excel 書式とともに、組み込み数値書式インデックスを一覧表示しています。正確な書式文字列とその表示はアプリケーションやロケールにより異なる場合があり、特に通貨や日付で顕著です。一部の Excel 書式は、[Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) に記載されているように OOXML 標準のデフォルトとは異なることがあります。

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

## **チャート領域の角丸境界線の設定**

`true` を指定して [IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) を呼び出すと、チャート領域の角が丸くなります。この例では、クラスター化縦棒グラフを作成し、[getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) を使用して輪郭に単色のグレーと単線スタイルを設定し、プレゼンテーションを保存します。

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

チャートには、レポートのステータスを説明するテキスト注釈などのカスタム シェイプを含めることができます。これらのシェイプは [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--) を介して取得でき、Chart API リファレンスの [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) にも記載されています。[getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) が返すコレクションには、チャートが所有するシェイプが含まれます。

チャート上に配置された通常のテキスト ボックスは、たとえチャートの一部に見えてもスライドに属します。[Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) を反復処理すると、チャートと通常のスライド シェイプが取得できますが、チャート内部の個別シェイプは列挙されません。チャート タイトルやデータ ラベルは、別個のチャート要素であり、このコレクション内のカスタム注釈ではありません。

アプリケーションの作業ディレクトリに [chart-annotations.pptx](chart-annotations.pptx) をダウンロードして配置します。最初のスライドには、"Preliminary results" と表示された非グループ化注釈と、チャートが所有する線、そして "Slide overlay" と表示された通常のスライド テキスト ボックスを含むチャートが配置されています。この例では、そのスライド上の最初のチャートを見つけ、レポートの公開準備ができたときに注釈を "Final results" に変更します。空のコレクションを確認し、[getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) が非 null のテキスト フレームを返す [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) のみを編集し、期待されるテキストかどうかをチェックします。

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

線とスライドのテキスト ボックスは変更されません。以下の画像は、入力と保存後に再度開いた結果を示しています。

| Before editing | After editing |
| --- | --- |
| ![「Preliminary results」と表示されたチャート注釈](chart-annotations-before.png) | ![「Final results」と表示されたチャート注釈](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
この例は、トップレベルのチャート所有シェイプのみを調べます。[IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/) 内に注釈がある場合、そのグループの [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) コレクションも確認します。入れ子になったグループに対して再帰的に同じ操作を行い、子シェイプにも同様のテキストチェックを適用します。グループ自体はコンテナであり、テキスト ボックスとして扱わないでください。
{{% /alert %}}

## **FAQ**

**列や領域の塗りつぶしを半透明にし、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度と輪郭は別々に設定できます。これは、密集した可視化でグリッドやデータの可読性を向上させるのに役立ちます。

**データ ラベルが重なったときはどう対処すればよいですか？**

フォント サイズを縮小したり、不要なラベル要素（例: カテゴリ）を無効にしたり、ラベル位置を調整したり、必要に応じて選択したポイントのみラベルを表示したり、書式を「値 + 凡例」に切り替えるなどの方法があります。

**系列にグラデーションやパターン 塗りつぶしを適用できますか？**

はい。系列は単色、グラデーション、パターン 塗りつぶしをサポートします。実務ではグラデーションは控えめに使用し、グリッドやテキストとのコントラストを低下させる組み合わせは避けてください。