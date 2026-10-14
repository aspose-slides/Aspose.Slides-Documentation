---
title: Android でのプレゼンテーションにおける円グラフのカスタマイズ
linktitle: 円グラフ
type: docs
url: /ja/androidjava/pie-chart/
keywords:
- 円グラフ
- チャートの管理
- チャートのカスタマイズ
- チャートオプション
- チャート設定
- プロットオプション
- スライスの色
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides for Android via Java で円グラフを作成およびカスタマイズします。二次プロットを設定し、データラベルを表示し、PowerPoint で自動スライス色を適用します。"
---
## **概要**

この記事では、Aspose.Slides の円グラフの使用方法を説明します。Pie of Pie および Bar of Pie グラフの二次プロットオプションの設定方法と、標準円グラフのスライスの自動着色の有効化方法を示します。

例では、スライドへのチャートの追加、シリーズおよびラベル設定の調整、デフォルトのチャートデータをカスタムカテゴリと値に置き換える、そして更新されたプレゼンテーションの保存といったチャート カスタマイズ タスクに焦点を当てています。

## **Pie of Pie と Bar of Pie グラフの二次プロットオプション**

Aspose.Slides for Android via Java は、Pie of Pie と Bar of Pie グラフの二次プロットオプションをサポートしています。これらのオプションは、二次プロットのサイズとデータポイントが二つのプロット間でどのように分割されるかを制御します。

次の例は、新しいプレゼンテーションに Pie of Pie チャートを作成し、データポイントの値をラベルとして表示します。 [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) メソッドは二次プロットのサイズをメインプロットの 149% に設定します。 [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) はパーセンテージベースの分割を選択し、[setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) はしきい値を 53% に設定します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // 値を表示し、二次プロットを設定します。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **二次プロットのカテゴリを選択**

特定のカテゴリをパーセンテージ値に関係なく二次プロットでグループ化したい場合は、カスタム分割を使用します。たとえば、売上レポートでオンラインとイベントを一緒に表示すると、読者はこれら二つのチャネルを比較でき、全体売上の 35% と 10% を占めていても問題ありません。

[setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) を [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) と共に呼び出し、[getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--) を介してポイントを選択します。コレクションの [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) メソッドはシリーズ内のゼロベースインデックスを受け取り、データポイントオブジェクトを追加するには [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) を使用します。この例では、インデックス 1 が Online を、インデックス 3 が Events を選択します。Partners も一時的に追加され、[removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-) で除外されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // デフォルトのデータをチャネル別の売上で置き換えます。
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Online をゼロベースインデックスで、Events をデータポイントオブジェクトで選択します。
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Partners を選択から除外します（ソースデータは削除しません）。
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) と Events (10) は二次プロットで別々のスライスとして表示されます。一次プロットでは、Retail (40) と Partners (15) とともに、これらが合計 45 の単一スライスとして表されます。Partners をカスタム選択から除外しても、一次プロットには残り、カテゴリやその値がチャートの元データから削除されることはありません。

次の画像は、PowerPoint で保存されたプレゼンテーションを示しています。
![二次プロットに Online と Events を含み、一次プロットで合計値 45 となる Pie of Pie チャート](pie_of_pie_custom.png)

## **自動円グラフスライスの色設定**

Aspose.Slides for Android via Java は、円グラフのスライスに自動的に異なる色を割り当てることができます。次の例は、中央にタイトルを持つ円グラフを作成し、デフォルトデータを 3 つの四半期カテゴリとその値に置き換えます。 [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) メソッドは 20、50、30 の値をラベルとして表示し、[setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) は各スライスに個別の色を有効にします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // 中央に配置されたチャートタイトルを追加します。
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 最初のワークシートを使用してデフォルトデータを置き換えます。
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // 値を表示し、スライスに異なる色を割り当てます。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**Pie of Pie と Bar of Pie のバリエーションはサポートされていますか？**

はい、ライブラリは Pie of Pie と Bar of Pie タイプを含む円グラフの二次プロットを [サポートしています](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/)。

**チャートだけを画像（例えば PNG）としてエクスポートできますか？**

はい、プレゼンテーション全体をエクスポートせずに、[チャート自体を画像としてエクスポート](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (PNG など) が可能です。