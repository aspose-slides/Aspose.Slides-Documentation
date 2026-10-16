---
title: Android のプレゼンテーション チャートにトレンドラインを追加する
linktitle: トレンドライン
type: docs
url: /ja/androidjava/trend-line/
keywords:
- チャート
- トレンドライン
- 指数トレンドライン
- 線形トレンドライン
- 対数トレンドライン
- 移動平均トレンドライン
- 多項式トレンドライン
- パワートレンドライン
- カスタムトレンドライン
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java で PowerPoint のチャートにトレンドラインを素早く追加・カスタマイズし、聴衆を惹きつける実践的なガイドです。"
---
## **概要**

本記事では、Aspose.Slides を使用してプレゼンテーションのチャートにトレンドラインを追加する方法を説明します。チャートの作成方法、チャートシリーズへのトレンドラインの追加方法、指数、線形、対数、移動平均、多項式、パワーなどの複数のトレンドラインタイプの使用方法を示します。

また、ラインシェイプを挿入してチャートにカスタムラインを追加する方法を説明し、トレンドラインの前方・後方投影値や、PDF や SVG へのエクスポート時、チャートを画像としてレンダリングする際にトレンドラインが保持されるかどうかに関する簡単な FAQ も含まれています。

## **トレンドラインの追加**

チャートシリーズにトレンドラインを追加するには、[ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) を使用し、[TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/) でタイプを選択します。この例では、デフォルトデータのクラスター化された縦棒グラフを作成し、3 つのシリーズそれぞれに 2 本のトレンドラインを追加しています。

指数トレンドラインは、[setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) と [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) によって方程式と決定係数の表示を非表示にし、線形トレンドラインは赤色です。対数トレンドラインはカスタムラベル用に [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) を使用します。移動平均は 3 点のデータポイントの [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) とカスタムの [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) を使用します。

多項式トレンドラインは [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) が 3 で、[setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-) によってカテゴリを 1 前方に拡張します。パワートレンドラインは [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-) によってカテゴリを 1 後方に拡張します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **トレンドラインの切片の設定**

[setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) を使用して、トレンドラインの X = 0 における Y 値を固定します。この設定は線形、指数、多項式トレンドラインでサポートされています。

例として、生産コストモデルは、非ゼロの生産量で測定されたベースラインが異なる場合でも、既知の固定コスト 100 から開始する必要があるかもしれません。線形トレンドラインの場合、切片を固定すると方程式 `y = ax + b` が `b = 100` に制約され、傾きはその制約下でデータに合わせてフィットします。これは既にフィットしたラインを単に移動させるだけではありません。軸交差設定はチャートの軸が交わる位置を制御し、フィットしたトレンドラインの係数を変更するものではありません。

以下の例では、生産量 1 から 4 の散布図 (XY) チャートを作成し、コストを 170、200、230、260 とします。デフォルトの自動切片でチャートを保存し、切片を 100 に設定して 2 番目の PPTX を保存します。2 つのファイルは切片設定だけが異なります。トレンドラインは方程式を表示し、X = 0 まで延長されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

自動計算の場合、これらのデータは `y = 30x + 140` を生成します。切片を 100 に設定すると、約 `y = 43.33x + 100` となります。ゼロでのフィット値が既知のベースラインと一致し、ラインはすべてのデータポイントを通過しなくなります。

| 自動切片 | 切片 100 の固定 |
| --- | --- |
| ![自動的に計算された切片 140 の線形トレンドライン](intercept-automatic.png) | ![切片 100 が固定された線形トレンドライン](intercept-fixed.png) |

両方の画像は同じデータと軸スケールを使用しています。トレンドラインは切片を示すために X = 0 まで延長されています。

デフォルトでは、[getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) は `Double.NaN` を返します。これは切片が未指定であることを示し、ゼロではありません。その後、切片はデータから自動的に計算されます。

## **カスタムラインの追加**

カスタムラインは、シリーズデータから計算されたトレンドラインではなく、チャート上に描画されたシェイプです。この例では、[IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) を使用して、チャート上に水平線をスライドに追加します。線の位置はポイント単位のスライド座標で指定され、チャートの左端から開始し、チャートの高さの中間に配置されます。その幅はチャートの幅と一致します。[getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) により、線は塗りつぶしの赤色になります。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**トレンドラインの「forward」と「backward」は何を意味しますか？**

トレンドラインを前方/後方に投影した長さです。散布図（XY）チャートの場合は軸単位で、散布図でないチャートの場合はカテゴリ数で表されます。負の値は使用できません。

**プレゼンテーションを PDF または SVG にエクスポートしたり、スライドを画像としてレンダリングしたりするときに、トレンドラインは保持されますか？**

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/) または [SVG](/slides/ja/androidjava/render-a-slide-as-an-svg-image/) に変換し、チャートを画像としてレンダリングします。チャートの一部であるトレンドラインはこれらの操作中に保持されます。また、チャート自体の画像を [チャートの画像をエクスポート](/slides/ja/androidjava/create-shape-thumbnails/) するメソッドも利用可能です。