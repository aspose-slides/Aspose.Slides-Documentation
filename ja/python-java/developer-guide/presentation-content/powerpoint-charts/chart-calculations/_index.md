---
title: "Python via Java でのプレゼンテーション向けチャート計算の最適化"
linktitle: "チャート計算"
type: docs
weight: 50
url: /ja/python-java/chart-calculations/
keywords:
- "チャート計算"
- "チャート要素"
- "要素の位置"
- "実際の位置"
- "子要素"
- "親要素"
- "チャート値"
- "実際の値"
- "PowerPoint"
- "プレゼンテーション"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java における PPT と PPTX 用のチャート計算、データ更新、精度制御を理解し、実用的な Python コード例を通じて学びます。"
---
## **概要**

Aspose.Slides は、プレゼンテーション内のチャート計算とレイアウト データを操作する API を提供します。本記事では、チャート要素の実際の値（チャート要素の実際の位置とサイズ、チャート軸の実際の値）を取得する方法を示します。また、これらの値はチャート レイアウトの検証後に設定されることを説明します。

さらに、親チャート要素の実際の位置の取得方法や、タイトル、軸、凡例、グリッド線などのチャート コンポーネントを非表示にする方法も示します。これらの例を組み合わせることで、プログラムから PowerPoint プレゼンテーションのチャート レイアウト情報を検査し、チャート要素の表示/非表示を制御できます。

## **チャート要素の実際の値を計算する**
Aspose.Slides for Python via Java は、これらのプロパティを取得するためのシンプルな API を提供します。  
[Axis](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/) クラスのメソッドは、チャート軸の実際の値に関する情報を提供します（[getActualMaxValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#getActualMaxValue)、[getActualMinValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#getActualMinValue)、[getActualMajorUnit](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#getActualMajorUnit)、[getActualMinorUnit](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#getActualMinorUnit)、[getActualMajorUnitScale](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#getActualMajorUnitScale)、[getActualMinorUnitScale](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#getActualMinorUnitScale)）。これらのプロパティに実際の値を設定するには、まず[Chart.validateChartLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#validateChartLayout)メソッドを呼び出してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **親チャート要素の実際の位置を計算する**
Aspose.Slides for Python via Java は、これらのプロパティを取得するためのシンプルな API を提供します。  
[ChartPlotArea](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartplotarea/) クラスのメソッドは、チャート プロット領域の実際の位置とサイズに関する情報を提供します（[getActualX](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartplotarea/#getActualX)、[getActualY](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartplotarea/#getActualY)、[getActualWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartplotarea/#getActualWidth)、[getActualHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartplotarea/#getActualHeight)）。これらのプロパティに実際の値を設定するには、まず[Chart.validateChartLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#validateChartLayout)メソッドを呼び出してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **チャート要素を非表示にする**
このセクションでは、チャートから情報を非表示にする方法を説明します。Aspose.Slides for Python via Java を使用すると、**タイトル、縦軸、横軸、グリッド線**を非表示にできます。以下のコード例は、これらのプロパティの使用方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # チャートのタイトルを非表示にします。
    chart.setTitle(False)

    # 数値軸を非表示にします。
    chart.getAxes().getVerticalAxis().setVisible(False)

    # カテゴリ軸を非表示にします。
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # 凡例を非表示にします。
    chart.setLegend(False)

    # 主要なグリッド線を非表示にします。
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # 最初の系列だけを残します。末尾から削除すると、残りのインデックスが有効なままです。
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # 系列の線の色を設定します。
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **よくある質問**

**外部のExcelブックをデータ ソースとして使用できますか、再計算にはどう影響しますか？**

はい。チャートは外部ブックを参照できます。外部ソースに接続または再読み込みすると、数式と値がそのブックから取得され、開く/編集する操作中にチャートが更新されます。API を使用して[外部ブックを指定する](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setExternalWorkbook)パスを設定し、リンクされたデータを管理できます。

**回帰分析を自分で実装せずに、トレンドラインを計算・表示できますか？**

はい。[トレンドライン](/slides/ja/python-java/trend-line/)（線形、指数など）は Aspose.Slides が自動的に追加・更新し、パラメータは系列データから再計算されます。独自の計算を実装する必要はありません。

**プレゼンテーションに外部リンク付きのチャートが複数ある場合、各チャートが使用するブックを個別に制御できますか？**

はい。各チャートはそれぞれの[外部ブック](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setExternalWorkbook)を指定できます。また、他のチャートとは独立して、チャートごとに外部ブックを作成または置き換えることも可能です。