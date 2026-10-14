---
title: Python via Java を使用してプレゼンテーションの円グラフをカスタマイズ
linktitle: 円グラフ
type: docs
url: /ja/python-java/pie-chart/
keywords:
- 円グラフ
- グラフの管理
- グラフのカスタマイズ
- グラフオプション
- グラフ設定
- プロットオプション
- スライスの色
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Python via Java で円グラフを作成およびカスタマイズします。セカンダリ プロットを設定し、データラベルを表示し、PowerPoint で自動的にスライスの色を適用します。"
---
## **概要**

この記事では、Aspose.Slides で円グラフを操作する方法を説明します。Pie of Pie および Bar of Pie グラフのセカンダリ プロット オプションの設定方法と、標準的な円グラフで自動的にスライスの色付けを有効にする方法を示します。

例では、スライドにチャートを追加する、シリーズやラベルの設定を調整する、既定のチャート データをカスタム カテゴリと値に置き換える、更新されたプレゼンテーションを保存するなど、チャートのカスタマイズタスクに焦点を当てています。

## **Pie of Pie および Bar of Pie グラフのセカンダリ プロット オプション**

Aspose.Slides for Python via Java は、Pie of Pie および Bar of Pie グラフのセカンダリ プロット オプションをサポートしています。これらのオプションは、セカンダリ プロットのサイズと、2 つのプロット間でデータ ポイントをどのように分割するかを制御します。

以下の例は、新しいプレゼンテーションで Pie of Pie チャートを作成し、データ ポイントの値をラベルとして表示します。[setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) メソッドは、セカンダリ プロットのサイズをメイン プロットの 149% に設定します。[setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) はパーセンテージベースの分割を選択し、[setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) はしきい値を 53% に設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # 値を表示し、セカンダリ プロットを構成します。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **セカンダリ プロット用カテゴリの選択**

パーセンテージ値に関係なく特定のカテゴリをセカンダリ プロットでグループ化したい場合は、カスタム分割を使用します。たとえば、売上レポートで Online と Events を一緒に表示すると、読者はこれら 2 つのチャネルを比較でき、全体の売上の 35% と 10% を占めていても問題ありません。

[setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) を [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) と共に呼び出し、[getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) でポイントを選択します。コレクションの [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) メソッドはシリーズ内のゼロベースインデックスを受け取ります。[addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) を使用してデータ ポイント オブジェクトを追加します。この例では、インデックス 1 が Online を選択し、インデックス 3 のポイントが Events を選択します。Partners も一時的に追加され、[removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem) で除外されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # デフォルトのデータをチャネル別の売上に置き換えます。
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Online をゼロベースインデックスで、Events をデータポイント オブジェクトで選択します。
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Partners を選択から除外しますが、元データは削除しません。
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) と Events (10) はセカンダリ プロットで別々のスライスとして表示されます。プライマリ プロットでは、Retail (40) と Partners (15) と共に、合計 45 の 1 つの結合スライスで表されます。カスタム選択から Partners を削除しても、プライマリ プロットには残り、カテゴリやその値がチャートの元データから削除されることはありません。

以下の画像は、PowerPoint で保存されたプレゼンテーションを示しています。

![セカンダリ プロットに Online と Events があり、プライマリ プロットで合計 45 の結合値を持つ Pie of Pie チャート](pie_of_pie_custom.png)

## **円グラフスライスの自動カラー設定**

Aspose.Slides for Python via Java は、円グラフのスライスに自動的に異なる色を割り当てることができます。以下の例は、中央にタイトルを持つ円グラフを作成し、既定のデータを 3 つの四半期カテゴリとその値に置き換えます。[setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) メソッドは、値 20、50、30 をラベルとして表示し、[setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) は各スライスに個別の色を有効にします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # 中央に配置されたチャートタイトルを追加します。
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # 最初のワークシートを使用してデフォルトデータを置き換えます。
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # 値を表示し、スライスに異なる色を割り当てます。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Pie of Pie と Bar of Pie のバリエーションはサポートされていますか？**

はい、ライブラリは円グラフ用のセカンダリ プロットを[サポート](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)しており、Pie of Pie および Bar of Pie タイプが含まれます。

**チャートだけを画像（例: PNG）としてエクスポートできますか？**

はい、[チャート自体を画像としてエクスポート](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage)（PNG など）することができ、プレゼンテーション全体をエクスポートする必要はありません。