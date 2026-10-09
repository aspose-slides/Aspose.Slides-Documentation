---
title: "PythonでPowerPointプレゼンテーションのチャートを作成または更新"
linktitle: "チャートの作成または更新"
type: docs
weight: 10
url: /ja/python-java/create-chart/
keywords:
- "チャートを追加"
- "チャートを作成"
- "チャートを編集"
- "チャートを変更"
- "チャートを更新"
- "散布図"
- "円グラフ"
- "折れ線グラフ"
- "ツリーマップチャート"
- "株価チャート"
- "箱ひげ図"
- "ファンネルチャート"
- "サンバーストチャート"
- "ヒストグラムチャート"
- "レーダーチャート"
- "マルチカテゴリチャート"
- "PowerPoint"
- "プレゼンテーション"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java を使用して PowerPoint プレゼンテーション内のチャートを作成およびカスタマイズします。実用的な Python コード例でチャートの追加、書式設定、編集を行う方法を紹介します。"
---
## **概要**

この記事では、Aspose.Slides を使用してチャートを作成およびカスタマイズするための包括的なガイドを提供します。スライドにプログラムでチャートを追加し、データを入力し、特定のデザイン要件に合わせてさまざまな書式設定オプションを適用する方法を学びます。記事全体で、プレゼンテーションとチャート オブジェクトの初期化から、系列、軸、凡例の構成まで、各手順を示す詳細なコード例が示されています。このガイドに従うことで、動的なチャート生成をアプリケーションに統合し、データ駆動型プレゼンテーションの作成プロセスを効率化する方法を確実に習得できます。

## **チャートの作成**

チャートは、データをすばやく視覚化し、表やスプレッドシートからはすぐに把握できない洞察を得るのに役立ちます。

**なぜチャートを作成するのか？**

チャートを使用すると、  

* 大量のデータを単一のスライドに集約、要約、または凝縮できる  
* データのパターンやトレンドを明らかにできる  
* 時間経過や特定の測定単位に対するデータの方向性と勢いを推測できる  
* 外れ値、異常、偏差、エラー、意味不明なデータなどを検出できる  
* 複雑なデータを効果的に伝達または提示できる  

PowerPoint では *Insert* 機能を使用してチャートを作成し、さまざまなタイプのテンプレートからデザインできます。Aspose.Slides を使用すると、一般的なチャート タイプに基づく標準チャートとカスタム チャートの両方を作成できます。

{{% alert color="info" title="Note" %}}
チャートを作成するには、[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) クラスを使用します。このクラスのフィールドはさまざまなチャート タイプに対応しています。
{{% /alert %}}

### **クラスター化列チャートの作成**

このセクションでは、Aspose.Slides を使用してクラスター化列チャートを作成する方法を説明します。プレゼンテーションの初期化、チャートの追加、タイトル、データ、系列、カテゴリ、スタイルなどの要素のカスタマイズ方法を学びます。以下の手順に従って、標準的なクラスター化列チャートがどのように生成されるかをご確認ください。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. `ChartType.ClusteredColumn` タイプを指定して、データを含むチャートを追加します。  
1. チャートにタイトルを追加します。  
1. チャートのデータ ワークシートにアクセスします。  
1. 既定の系列とカテゴリをすべてクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. チャート系列の新しいデータを追加します。  
1. チャート系列に塗りつぶし色を適用します。  
1. チャート系列にラベルを追加します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、クラスター化列チャートの作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドにアクセスします
    slide = presentation.getSlides().get_Item(0)

    # デフォルト データでチャートを追加します
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # チャートのタイトルを設定します
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # チャート データシートのインデックスを設定します
    default_worksheet_index = 0

    # チャート データ ワークシートを取得します
    workbook = chart.getChartData().getChartDataWorkbook()

    # デフォルトで生成された系列とカテゴリを削除します
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # 新しい系列を追加します
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # 新しいカテゴリを追加します
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # 最初のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(0)

    # 系列データを現在設定します
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # 系列の塗りつぶし色を設定します
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # 2 番目のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(1)

    # 系列データを設定します
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # 系列の塗りつぶし色を設定します
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #新しい系列の各カテゴリにカスタム ラベルを作成します
    # 最初のラベルにカテゴリ名を表示するよう設定します
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # 3 番目のラベルに値を表示します
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # チャート付きのプレゼンテーションを保存します
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **散布図の作成**

散布図（別名散布プロットまたは X‑Y グラフ）は、2 つの変数間のパターンや相関関係を確認する際に頻繁に使用されます。

散布図を使用する場面：

* 対になった数値データがあるとき  
* 2 つの変数が相互に関連しているとき  
* 2 つの変数が関係しているかどうかを判断したいとき  
* 従属変数に対して複数の値を持つ独立変数があるとき  

1. [クラスター化列チャートの作成](#クラスター化列チャートの作成) の手順に従います。  
2. 3 番目の手順で、チャートを追加し、以下のいずれかのチャート タイプを指定します：  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _散布図を表します。_  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _曲線で接続された散布図で、データ マーカーがあります。_  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _曲線で接続された散布図で、データ マーカーがありません。_  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _直線で接続された散布図で、データ マーカーがあります。_  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _直線で接続された散布図で、データ マーカーがありません。_

この Python コードは、各系列に異なるマーカーを使用した散布図の作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドにアクセスします
    slide = presentation.getSlides().get_Item(0)

    # デフォルトのチャートを作成します
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # デフォルトのチャート データ ワークシート インデックスを取得します
    default_worksheet_index = 0

    # チャート データ ワークシートを取得します
    workbook = chart.getChartData().getChartDataWorkbook()

    # デモ系列を削除します
    chart.getChartData().getSeries().clear()

    # 新しい系列を追加します
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # 最初のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(0)

    # 系列に新しいポイント (1:3) を追加します
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # 新しいポイント (2:10) を追加します
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # 系列のタイプを変更します
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # チャート系列のマーカーを変更します
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # 2 番目のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(1)

    # そこに新しいポイント (5:2) を追加します
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # 新しいポイント (3:1) を追加します
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # 新しいポイント (2:2) を追加します
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # 新しいポイント (5:1) を追加します
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # チャート系列のマーカーを変更します
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **円グラフの作成**

円グラフは、データ内の部分‑全体関係を示すのに最適です。特にカテゴリ ラベルと数値が対応している場合に有効です。ただし、項目やラベルが多数ある場合は、棒グラフの使用を検討してください。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データを持つチャートを追加し、[ChartType.Pie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Pie) タイプを指定します。  
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. チャート系列の新しいデータを追加します。  
8. 円グラフのセクターにカスタム 色を適用します。  
9. 系列のラベルを設定します。  
10. 系列ラベルにリーダー ラインを有効にします。  
11. 円グラフセクターの回転角度を設定します。  
12. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、円グラフの作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドにアクセスします
    slide = presentation.getSlides().get_Item(0)

    # デフォルト データでチャートを追加します
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # チャートのタイトルを設定します
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # チャート データ シートのインデックスを設定します
    default_worksheet_index = 0

    # チャート データ ワークシートを取得します
    workbook = chart.getChartData().getChartDataWorkbook()

    # デフォルトで生成された系列とカテゴリを削除します
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # 新しいカテゴリを追加します
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # 新しい系列を追加します
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #系列データを設定します
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # 新しいポイントを追加し、セクタの色を設定します
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # セクタの枠線を設定します
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # セクタの枠線を設定します
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # セクタの枠線を設定します
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # 新しい系列の各カテゴリにカスタム ラベルを作成します
    first_label = series.getDataPoints().get_Item(0).getLabel()

    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # チャートのリーダー ラインを表示します
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # 円グラフのセクタの回転角度を設定します
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # チャート付きのプレゼンテーションを保存します
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **折れ線グラフの作成**

折れ線グラフ（別名折れ線図）は、時間経過による値の変化を示すのに最適です。折れ線グラフを使用すると、膨大なデータを同時に比較し、時間に伴う変化やトレンドを追跡し、系列内の異常を強調表示することができます。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. デフォルト データを持つチャートを追加し、[ChartType.Line](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Line) タイプを指定します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、折れ線グラフの作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

デフォルトでは、折れ線グラフのポイントは連続した直線で結ばれます。ポイントを破線で結びたい場合は、次のように希望の破線タイプを指定できます：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ツリーマップチャートの作成**

ツリーマップチャートは、売上データなどでカテゴリごとの相対的なサイズを示し、各カテゴリ内で大きく貢献している項目に注意を引きやすくするのに最適です。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データを持つチャートを追加し、[ChartType.Treemap](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Treemap) タイプを指定します。  
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. チャート系列の新しいデータを追加します。  
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、ツリーマップチャートの作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #ブランチ 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #ブランチ 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **株価チャートの作成**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データを持つチャートを追加し、[ChartType.OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#OpenHighLowClose) タイプを指定します。  
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. チャート系列の新しいデータを追加します。  
8. 高低線の書式を指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、株価チャートの作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **箱ひげ図の作成**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データを持つチャートを追加し、[ChartType.BoxAndWhisker](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#BoxAndWhisker) タイプを指定します。  
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. チャート系列の新しいデータを追加します。  
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、箱ひげ図の作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ファンネルチャートの作成**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データを持つチャートを追加し、[ChartType.Funnel](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Funnel) タイプを指定します。  
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、ファンネルチャートの作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **サンバーストチャートの作成**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データを持つチャートを追加し、[ChartType.Sunburst](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Sunburst) タイプを指定します。  
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、サンバーストチャートの作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #ブランチ 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #ブランチ 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ヒストグラムチャートの作成**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データを持つチャートを追加し、[ChartType.Histogram](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Histogram) タイプを指定します。  
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、ヒストグラムチャートの作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **レーダーチャートの作成**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. データを含むチャートを追加し、[ChartType.Radar](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Radar) タイプを指定します。  
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、レーダーチャートの作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **マルチカテゴリチャートの作成**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データを持つチャートを追加し、[ChartType.ClusteredColumn](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ClusteredColumn) タイプを指定します。  
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. チャート系列の新しいデータを追加します。  
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、マルチカテゴリチャートの作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # シリーズを追加
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # チャート付きのプレゼンテーションを保存
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **マップチャートの作成**

マップチャートは地理データを可視化し、地域ごとの値を比較するのに役立ちます。

この Python コードは、マップチャートの作成方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **コンビネーションチャートの作成**

コンビネーションチャート（またはコンボチャート）は、単一のグラフ内に 2 つ以上のチャート タイプを組み合わせます。このチャートを使用すると、複数のデータ セット間の違いをハイライト、比較、検証でき、相互の関係を把握しやすくなります。

![組み合わせチャート](combination_chart.png)

以下の Python コードは、上記のコンビネーションチャートを PowerPoint プレゼンテーションに作成する方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # チャートのタイトルを設定します。
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # チャートの凡例を設定します。
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # デフォルトで生成された系列とカテゴリを削除します。
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # 新しいカテゴリを追加します。
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # 最初の系列を追加します。
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # 水平軸を設定します。
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # 垂直軸を設定します。
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # 垂直軸の主要目盛線の色を設定します。
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # 副水平軸を設定します。
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # 副垂直軸を設定します。
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **チャートの更新**

1. 更新したいチャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. すべてのシェイプを走査して目的のチャートを見つけます。  
4. チャート データ ワークシートにアクセスします。  
5. 系列値を変更してチャート データ系列を修正します。  
6. 新しい系列を追加し、そのデータを入力します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、チャートを更新する方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 更新するチャートが含まれるプレゼンテーションを開きます
presentation = Presentation("ExistingChart.pptx")
try:
    # 最初のスライドにアクセスします
    slide = presentation.getSlides().get_Item(0)

    # スライドからチャートを取得します
    chart = slide.getShapes().get_Item(0)

    # チャート データ シートのインデックスを設定します
    default_worksheet_index = 0

    # チャート データ ワークシートを取得します
    workbook = chart.getChartData().getChartDataWorkbook()

    # チャートのカテゴリ名を変更します
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # 最初のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(0)

    # 系列データを更新します
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# 系列名を変更
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # 2 番目のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(1)

    # 系列データを更新します
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# 系列名を変更
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # 新しい系列を追加します
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # 3 番目のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(2)

    # 系列データを追加します
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # チャート付きのプレゼンテーションを保存します
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャートのデータ範囲の設定**

既存のチャートが使用している範囲を確認するには、[Retrieve a Chart's Data Range](/slides/ja/python-java/chart-workbook/#retrieve-a-charts-data-range) を参照してください。

チャートのデータ範囲を設定する手順は次のとおりです：

1. 対象のチャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. すべてのシェイプを走査して目的のチャートを見つけます。  
4. チャート データにアクセスし、範囲を設定します。  
5. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、チャートのデータ範囲を設定する方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# チャートが含まれるプレゼンテーションを開きます
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャートでデフォルト マーカーを使用する**

チャートでデフォルト マーカーを使用すると、各系列に自動的に異なるマーカー記号が割り当てられます。

この Python コードは、系列マーカーを自動的に設定する方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    #2 番目のチャート系列を取得
    second_series = chart.getChartData().getSeries().get_Item(1)

    #系列データを現在設定
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides がサポートするチャートタイプは何ですか？**

Aspose.Slides は、棒、折れ線、円、エリア、散布、ヒストグラム、レーダーなど、多数の [chart types](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) をサポートします。この柔軟性により、データ可視化のニーズに最適なチャート タイプを選択できます。

**スライドに新しいチャートを追加する方法は？**

チャートを追加するには、まず [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成し、インデックスで目的のスライドを取得してから、チャート タイプと初期データを指定してチャートを追加するメソッドを呼び出します。このプロセスにより、チャートがプレゼンテーションに直接組み込まれます。

**チャートに表示されるデータを更新するには？**

チャートのデータは、データ ワークブック ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)) にアクセスし、既定の系列とカテゴリをクリアしてからカスタム データを追加することで更新できます。これにより、最新のデータを反映するようにチャートをリフレッシュできます。

**チャートの外観をカスタマイズすることは可能ですか？**

はい、Aspose.Slides には豊富なカスタマイズ オプションがあります。色、フォント、ラベル、凡例、その他の [formatting elements](/slides/ja/python-java/chart-entities/) を変更して、チャートの外観を特定のデザイン要件に合わせて調整できます。